using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace WinUtils
{

    #region Structs
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
        public int x;
        public int y;

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    };
    
    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
        public int cx;
        public int cy;

        public SIZE(int cx, int cy)
        {
            this.cx = cx;
            this.cy = cy;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct BLENDFUNCTION
    {
        byte BlendOp;
        byte BlendFlags;
        byte SourceConstantAlpha;
        byte AlphaFormat;

        public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
        {
            BlendOp = op;
            BlendFlags = flags;
            SourceConstantAlpha = alpha;
            AlphaFormat = format;
        }
    }
    #endregion


    public static class WinAPI
    {
        public static WndProcDelegate defWindowProc = new WndProcDelegate(DefWindowProc);
        public delegate IntPtr WndProcDelegate(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        static WinAPI()
        {
            InitCommonControls();
        }

        public static Delegate GetFunctionAddress(IntPtr dllModule, string functionName, Type t)
        {
            IntPtr address = GetProcAddress(dllModule, functionName);
            if (address == IntPtr.Zero)
                return null;
            else
                return Marshal.GetDelegateForFunctionPointer(address, t);
        }

        #region DWMAPI
        [DllImport("dwmapi.dll")]
        public static extern void DwmIsCompositionEnabled(ref int enabledptr);
        [DllImport("dwmapi.dll")]
        public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margin);
        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern void DwmGetColorizationColor(out int ColorizationColor, [MarshalAs(UnmanagedType.Bool)]out bool ColorizationOpaqueBlend);
        [DllImport("dwmapi")]
        public static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DWM_BLURBEHIND pBlurBehind);
        #endregion

        #region User32
        [DllImport("user32.dll")]
        public static extern uint ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "PostMessage", CallingConvention = CallingConvention.Winapi)]
        public static extern uint PostMessage(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern uint SendMessage(IntPtr hwnd, uint wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern uint GetCursorPos(ref Point lpPoint);
        [DllImport("User32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)]bool bRevert);
        [DllImport("User32.dll")]
        public static extern int EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);
        [DllImport("user32.dll")]
        public static extern IntPtr TrackPopupMenuEx(IntPtr hMenu, uint flags, uint x, uint y, IntPtr hWnd, IntPtr lpTPMParams);
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);
        [DllImport("user32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hdc);
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int SaveDC(IntPtr hdc);
        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int ReleaseDC(IntPtr hdc, int state);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref POINT pptDst, ref SIZE psize, IntPtr hdcSrc, ref POINT pptSrc, uint crKey, [In] ref BLENDFUNCTION pblend, uint dwFlags);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "SetWindowLongW")]
        private static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetWindowLongPtrW")]
        private static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
        [DllImport("user32.dll", EntryPoint = "GetWindowLongW")]
        private static extern int GetWindowLongPtr32(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "GetWindowLongPtrW")]
        private static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);

        public static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
        {
            if (IntPtr.Size == 8)
                return GetWindowLongPtr64(hWnd, nIndex);
            else
                return new IntPtr(GetWindowLongPtr32(hWnd, nIndex));
        }

        public static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
        {
            if (IntPtr.Size == 8)
                return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
            else
                return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
        }

        [DllImport("user32.dll")]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        #endregion

        #region GDI32
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, ref BITMAPINFO pbmi, uint iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll", ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DeleteDC(IntPtr hdc);
        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwRop);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int FillRect(IntPtr hDC, ref RECT rect, IntPtr hBrush);
        [DllImport("gdi32")]
        public static extern uint SetDCBrushColor(IntPtr hdc, uint crColor);
        [DllImport("gdi32")]
        public static extern IntPtr CreateSolidBrush(int crColor);
        #endregion

        #region UxTheme
        [DllImport("UxTheme.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int DrawThemeTextEx(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags, ref RECT pRect, ref DTTOPTS pOptions);
        [DllImport("UxTheme.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int DrawThemeText(IntPtr hTheme, IntPtr hdc, int iPartId, int iStateId, string text, int iCharCount, int dwFlags1, int dwFlags2, ref RECT pRect);
        [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr OpenThemeData(IntPtr hwnd, string pszClassList);
        #endregion

        #region Shell32
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern int PickIconDlg(IntPtr hwndOwner, StringBuilder lpstrFile, int nMaxFile, ref int lpdwIconIndex);

        [DllImport("shell32.dll")]
        public static extern int ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);

        [DllImport("shell32.dll")]
        public static extern int ExtractIconEx(string lpszFile, int niconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, int nIcons);
        #endregion

        #region Kernel32
        [DllImport("Kernel32")]
        public static extern IntPtr LoadLibrary(string funcname);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr GetProcAddress(IntPtr handle, string funcname);

        [DllImport("Kernel32")]
        public static extern IntPtr GetNativeSystemInfo(ref SYSTEM_INFO systemInfo);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string name);
        #endregion

        #region comctl32
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_BeginDrag(
            IntPtr himlTrack, // Handler of the image list containing the image to drag
            int iTrack,       // Index of the image to drag 
            int dxHotspot,    // x-delta between mouse position and drag image
            int dyHotspot     // y-delta between mouse position and drag image
        );

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragMove(
            int x,   // X-coordinate (relative to the form,
                     // not the treeview) at which to display the drag image.
            int y   // Y-coordinate (relative to the form,
                    // not the treeview) at which to display the drag image.
        );

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern void ImageList_EndDrag();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragEnter(
            IntPtr hwndLock,  // Handle to the control that owns the drag image.
            int x,            // X-coordinate (relative to the treeview)
                              // at which to display the drag image. 
            int y             // Y-coordinate (relative to the treeview)
                              // at which to display the drag image. 
        );

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragLeave(
            IntPtr hwndLock  // Handle to the control that owns the drag image.
        );

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragShowNolock(
            bool fShow       // False to hide, true to show the image
        );

        [DllImport("comctl32.dll", CharSet = CharSet.Unicode, EntryPoint = "TaskDialogIndirect")]
        public static extern int TaskDialogIndirect(ref TASKDIALOGCONFIG pTaskConfig, ref int pnButton, ref int pnRadioButton, [MarshalAs(UnmanagedType.Bool)] ref bool pfVerificationFlagChecked);
        #endregion
    }

    public static class Constants
    {
        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;

        public const int ULW_COLORKEY = 0x00000001;
        public const int ULW_ALPHA = 0x00000002;
        public const int ULW_OPAQUE = 0x00000004;
        public const int ULW_EX_NORESIZE = 0x00000008;

        public const int GWL_WNDPROC = -4;
        public const int GWL_HINSTANCE = -6;
        public const int GWL_HWNDPARENT = -8;
        public const int GWL_STYLE = -16;
        public const int GWL_EXSTYLE = -20;
        public const int GWL_USERDATA = -21;
        public const int GWL_ID = -12;

        public const uint WM_SYSCOMMAND = 0x0112;
        public const uint WM_LBUTTONDOWN = 0x0201;
        public const uint WM_NCLBUTTONDOWN = 0x00A1;
        public const uint WM_PAINT = 0x000F;
        public const uint WM_MOVE = 0x0003;
        public const uint WM_CTLCOLORMSGBOX = 0x0132;
        public const uint WM_CTLCOLOREDIT = 0x0133;
        public const uint WM_CTLCOLORLISTBOX = 0x0134;
        public const uint WM_CTLCOLORBTN = 0x0135;
        public const uint WM_CTLCOLORDLG = 0x0136;
        public const uint WM_CTLCOLORSCROLLBAR = 0x0137;
        public const uint WM_CTLCOLORSTATIC = 0x0138;
        public const uint WM_CAPTURECHANGED = 0x0215;

        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_CLIPCHILDREN = 0x2000000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_MINIMIZEBOX = 0x20000;
        public const int WS_MAXIMIZEBOX = 0x10000;
        public const int WS_SYSMENU = 0x80000;
        public const int WS_CHILD = 0x40000000;

        public const uint SC_MOVE = 0xF010;
        public const uint SC_CLOSE = 0xF060;
        public const uint SC_SIZE = 0xF000;

        public const uint HTCAPTION = 0x0002;

        public const uint BCM_SETSHIELD = 0x160c;

        public const uint TPM_RETURNCMD = 0x0100;
        public const uint TPM_LEFTBUTTON = 0x0;


        public const int DTT_COMPOSITED = (int)(1UL << 13);
        public const int DTT_GLOWSIZE = (int)(1UL << 11);

        //Text format consts
        public const int DT_SINGLELINE = 0x00000020;
        public const int DT_CENTER = 0x00000001;
        public const int DT_VCENTER = 0x00000004;
        public const int DT_NOPREFIX = 0x00000800;

        //Const for BitBlt
        public const int SRCCOPY = 0x00CC0020;


        //Consts for CreateDIBSection
        public const int BI_RGB = 0;
        public const byte DIB_RGB_COLORS = 0;
        public const byte DIB_PAL_COLORS = 1;

        //DWM
        public const uint DWM_BB_ENABLE = 0x00000001;
        public const uint DWM_BB_BLURREGION = 0x00000002;
        public const uint DWM_BB_TRANSITIONONMAXIMIZED = 0x00000004;
    }
    
}