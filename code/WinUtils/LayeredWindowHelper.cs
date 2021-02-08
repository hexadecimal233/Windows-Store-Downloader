using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WinUtils;

namespace WinUtils
{
    public class LayeredWindowHelper
    {
        private WinAPI.WndProcDelegate m_CtrlWndProcDelegate;
        private Dictionary<IntPtr, IntPtr> m_WndProcMap = new Dictionary<IntPtr, IntPtr>();
        private bool m_bIsRefreshing = false;
        private Form host;
        public Color BackColor;

        public LayeredWindowHelper(Form host)
        {
            this.host = host;

            m_CtrlWndProcDelegate = new WinAPI.WndProcDelegate(CtrlWndProc);
            HookChildControl(host);

            RefreshCtrl();
        }

        private void RefreshCtrl()
        {
            if (m_bIsRefreshing)
                return;

            int width = host.ClientRectangle.Width;
            int height = host.ClientRectangle.Height;

            m_bIsRefreshing = true;


            IntPtr hDC = WinAPI.GetDC(host.Handle);
            if (hDC == IntPtr.Zero)
            {
                m_bIsRefreshing = false;
                Debug.Assert(false, "GetDC failed.");
                return;
            }

            IntPtr hdcMemory = WinAPI.CreateCompatibleDC(hDC);

            int nBytesPerLine = ((width * 32 + 31) & (~31)) >> 3;
            BITMAPINFO stBmpInfoHeader = new BITMAPINFO();
            stBmpInfoHeader.bmiHeader.biSize = Marshal.SizeOf(stBmpInfoHeader);
            stBmpInfoHeader.bmiHeader.biWidth = width;
            stBmpInfoHeader.bmiHeader.biHeight = height;
            stBmpInfoHeader.bmiHeader.biPlanes = 1;
            stBmpInfoHeader.bmiHeader.biBitCount = 32;
            stBmpInfoHeader.bmiHeader.biCompression = 0;
            stBmpInfoHeader.bmiHeader.biClrUsed = 0;
            stBmpInfoHeader.bmiHeader.biSizeImage = nBytesPerLine * height;

            IntPtr pvBits = IntPtr.Zero;
            IntPtr hbmpMem = WinAPI.CreateDIBSection(hDC
                , ref stBmpInfoHeader
                , Constants.DIB_RGB_COLORS
                , out pvBits
                , IntPtr.Zero
                , 0
                );
            Debug.Assert(hbmpMem != IntPtr.Zero, "CreateDIBSection failed.");

            if (hbmpMem != null)
            {
                IntPtr hbmpOld = WinAPI.SelectObject(hdcMemory, hbmpMem);

                Graphics graphic = Graphics.FromHdcInternal(hdcMemory);

                graphic.FillRectangle(new SolidBrush(BackColor), graphic.ClipBounds);

                foreach (Control ctrl in host.Controls)
                {
                    Bitmap bmp = new Bitmap(ctrl.Width, ctrl.Height);
                    Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                    ctrl.DrawToBitmap(bmp, rect);
                    graphic.DrawImage(bmp, ctrl.Location);
                }


                POINT ptSrc = new POINT(0, 0);
                POINT ptWinPos = new POINT(host.Left, host.Top);
                SIZE szWin = new SIZE(width, height);
                BLENDFUNCTION stBlend = new BLENDFUNCTION(Constants.AC_SRC_OVER, 0, 0xFF, Constants.AC_SRC_ALPHA);

                WinAPI.UpdateLayeredWindow(host.Handle
                    , hDC
                    , ref ptWinPos
                    , ref szWin
                    , hdcMemory
                    , ref ptSrc
                    , 0
                    , ref stBlend
                    , Constants.ULW_ALPHA
                    );

                graphic.Dispose();
                WinAPI.SelectObject(hbmpMem, hbmpOld);
                WinAPI.DeleteObject(hbmpMem);
            }

            WinAPI.DeleteDC(hdcMemory);
            WinAPI.DeleteDC(hDC);

            m_bIsRefreshing = false;
        }

        private IntPtr CtrlWndProc(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam)
        {
            if (!m_WndProcMap.ContainsKey(hWnd))
                return WinAPI.defWindowProc(hWnd, msg, wParam, lParam);

            IntPtr nRet = WinAPI.CallWindowProc(m_WndProcMap[hWnd], hWnd, msg, wParam, lParam);

            switch (msg)
            {
                case Constants.WM_PAINT:
                case Constants.WM_CTLCOLOREDIT:
                case Constants.WM_CTLCOLORBTN:
                case Constants.WM_CTLCOLORSTATIC:
                case Constants.WM_CTLCOLORMSGBOX:
                case Constants.WM_CTLCOLORDLG:
                case Constants.WM_CTLCOLORLISTBOX:
                case Constants.WM_CTLCOLORSCROLLBAR:
                case Constants.WM_CAPTURECHANGED:
                    RefreshCtrl();
                    break;

                default:
                    break;
            }

            return nRet;
        }

        private void HookChildControl(Control ctrl)
        {
            if (WinAPI.IsWindow(ctrl.Handle))
            {
                m_WndProcMap[ctrl.Handle]
                    = WinAPI.GetWindowLongPtr(ctrl.Handle, Constants.GWL_WNDPROC);

                WinAPI.SetWindowLongPtr(ctrl.Handle
                    , Constants.GWL_WNDPROC
                    , Marshal.GetFunctionPointerForDelegate(m_CtrlWndProcDelegate)
                    );
            }

            if (!ctrl.HasChildren)
                return;
            foreach (Control child in ctrl.Controls)
            {
                HookChildControl(child);
            }
        }

        private void UnHookControls()
        {
            foreach (IntPtr hWnd in m_WndProcMap.Keys)
            {
                WinAPI.SetWindowLongPtr(hWnd
                    , Constants.GWL_WNDPROC
                    , m_WndProcMap[hWnd]
                    );
            }
        }
    }
}
