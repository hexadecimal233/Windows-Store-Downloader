using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace WinUtils
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MARGINS
    {
        public int m_Left;
        public int m_Right;
        public int m_Top;
        public int m_Buttom;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct DTTOPTS
    {
        public uint dwSize;
        public uint dwFlags;
        public uint crText;
        public uint crBorder;
        public uint crShadow;
        public int iTextShadowType;
        public POINT ptShadowOffset;
        public int iBorderSize;
        public int iFontPropId;
        public int iColorPropId;
        public int iStateId;
        public int fApplyOverlay;
        public int iGlowSize;
        public IntPtr pfnDrawTextCallback;
        public int lParam;
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFOHEADER
    {
        public int biSize;
        public int biWidth;
        public int biHeight;
        public short biPlanes;
        public short biBitCount;
        public int biCompression;
        public int biSizeImage;
        public int biXPelsPerMeter;
        public int biYPelsPerMeter;
        public int biClrUsed;
        public int biClrImportant;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct RGBQUAD
    {
        public byte rgbBlue;
        public byte rgbGreen;
        public byte rgbRed;
        public byte rgbReserved;
    };

    [StructLayout(LayoutKind.Sequential)]
    public struct BITMAPINFO
    {
        public BITMAPINFOHEADER bmiHeader;
        public RGBQUAD bmiColors;
    };


    [StructLayout(LayoutKind.Sequential)]
    public struct DWM_BLURBEHIND
    {
        public uint dwFlags;

        [MarshalAs(UnmanagedType.Bool)]
        public bool fEnable;

        public IntPtr hRgnBlur;    //A pointer to the region

        [MarshalAs(UnmanagedType.Bool)]
        public bool fTransitionOnMaximized;
    };

    public static class Win7Style
    {
        public static void EnableBlurBehindWindow(IntPtr hwnd)
        {
            DWM_BLURBEHIND dbb;
            dbb.fEnable = true;
            dbb.dwFlags = Constants.DWM_BB_BLURREGION | Constants.DWM_BB_ENABLE;
            dbb.hRgnBlur = IntPtr.Zero;
            dbb.fTransitionOnMaximized = false;
            WinAPI.DwmEnableBlurBehindWindow(hwnd, ref dbb);
        }

        public static Color GetThemeColor()
        {
            return Color.FromArgb(int.Parse(
                    Microsoft.Win32.Registry.GetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\DWM", "ColorizationColor", SystemColors.ActiveCaption.ToArgb().ToString())
                    .ToString()
                )
                );
        }

        public static void EnableAero(IntPtr hwnd, int top, int bottom, int left, int right)
        {
            MARGINS mg = new MARGINS();
            mg.m_Buttom = bottom;
            mg.m_Left = left;
            mg.m_Right = right;
            mg.m_Top = top;
            WinAPI.DwmExtendFrameIntoClientArea(hwnd, ref mg);

            Control.FromHandle(hwnd).BackColor = GetAeroBackgroundColor();
            ((Form)Control.FromHandle(hwnd)).TransparencyKey = GetAeroBackgroundColor();
        }


        public static void EnableAero(IntPtr hwnd)
        {
            MARGINS mg = new MARGINS();
            mg.m_Buttom = -1;
            mg.m_Left = -1;
            mg.m_Right = -1;
            mg.m_Top = -1;
            WinAPI.DwmExtendFrameIntoClientArea(hwnd, ref mg);

            Control.FromHandle(hwnd).BackColor = GetAeroBackgroundColor();
            ((Form)Control.FromHandle(hwnd)).TransparencyKey = GetAeroBackgroundColor();
        }

        public static Color GetAeroBackgroundColor()
        {
            return Color.FromArgb(164, 212, 211);
        }

        public static bool IsCompositionEnabled()
        {
            if (Environment.OSVersion.Version.Major < 6)
                return false;

            int compositionEnabled = 0;
            WinAPI.DwmIsCompositionEnabled(ref compositionEnabled);
            return compositionEnabled > 0;
        }

        public static void DrawTextOnGlass(IntPtr hwnd, String text, Font font, Rectangle ctlrct, int iglowSize)
        {
            if (IsCompositionEnabled())
            {
                RECT rc = new RECT();
                RECT rc2 = new RECT();

                rc.left = ctlrct.Left;
                rc.right = ctlrct.Right;// + 2 * iglowSize;  //make it larger to contain the glow effect
                rc.top = ctlrct.Top;
                rc.bottom = ctlrct.Bottom;// + 2 * iglowSize;

                //Just the same rect with rc,but (0,0) at the lefttop
                rc2.left = 0;
                rc2.top = 0;
                rc2.right = rc.right - rc.left;
                rc2.bottom = rc.bottom - rc.top;

                IntPtr destdc = WinAPI.GetDC(hwnd);    //hwnd must be the handle of form,not control
                IntPtr Memdc = WinAPI.CreateCompatibleDC(destdc);   // Set up a memory DC where we'll draw the text.
                IntPtr bitmap;
                IntPtr bitmapOld = IntPtr.Zero;
                IntPtr logfnotOld;

                int uFormat = Constants.DT_SINGLELINE | Constants.DT_CENTER | Constants.DT_VCENTER | Constants.DT_NOPREFIX;   //text format

                IntPtr ptPixels = IntPtr.Zero;

                BITMAPINFO dib = new BITMAPINFO();
                dib.bmiHeader.biHeight = -(rc.bottom - rc.top);         // negative because DrawThemeTextEx() uses a top-down DIB
                dib.bmiHeader.biWidth = rc.right - rc.left;
                dib.bmiHeader.biPlanes = 1;
                dib.bmiHeader.biSize = Marshal.SizeOf(typeof(BITMAPINFOHEADER));
                dib.bmiHeader.biBitCount = 32;
                dib.bmiHeader.biCompression = Constants.BI_RGB;
                dib.bmiColors.rgbBlue = 255;
                if (!(WinAPI.SaveDC(Memdc) == 0))
                {
                    bitmap = WinAPI.CreateDIBSection(Memdc, ref dib, Constants.DIB_RGB_COLORS, out ptPixels, IntPtr.Zero, 0);   // Create a 32-bit bmp for use in offscreen drawing when glass is on
                    if (!(bitmap == IntPtr.Zero))
                    {
                        bitmapOld = WinAPI.SelectObject(Memdc, bitmap);
                        IntPtr hFont = font.ToHfont();
                        logfnotOld = WinAPI.SelectObject(Memdc, hFont);
                        try
                        {

                            System.Windows.Forms.VisualStyles.VisualStyleRenderer renderer = new System.Windows.Forms.VisualStyles.VisualStyleRenderer(System.Windows.Forms.VisualStyles.VisualStyleElement.Window.Caption.Active);

                            DTTOPTS dttOpts = new DTTOPTS();
                            
                            dttOpts.dwSize = (uint)Marshal.SizeOf(typeof(DTTOPTS));

                            dttOpts.dwFlags = Constants.DTT_COMPOSITED | Constants.DTT_GLOWSIZE;


                            dttOpts.iGlowSize = iglowSize;
 
                            for (int i = (-(dib.bmiHeader.biWidth * dib.bmiHeader.biHeight) - 1); i >= 0; i--)
                            {
                                Marshal.WriteInt32(
                                    (IntPtr)((long)ptPixels + Marshal.SizeOf(typeof(int)) * i), 
                                    GetAeroBackgroundColor().ToArgb()
                                    );
                            }
                  
                            WinAPI.DrawThemeTextEx(renderer.Handle, Memdc, 1, 1, text, -1, uFormat, ref rc2, ref dttOpts);

                            WinAPI.BitBlt(destdc, rc.left, rc.top, rc.right - rc.left, rc.bottom - rc.top, Memdc, 0, 0, Constants.SRCCOPY);

                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Trace.WriteLine(e.Message);
                        }


                        //Remember to clean up
                        WinAPI.SelectObject(Memdc, bitmapOld);
                        WinAPI.SelectObject(Memdc, logfnotOld);
                        WinAPI.DeleteObject(bitmap);
                        WinAPI.DeleteObject(hFont);

                        WinAPI.ReleaseDC(Memdc, -1);
                        WinAPI.DeleteDC(Memdc);
                    }
                }
            }

        }

        


    }
}