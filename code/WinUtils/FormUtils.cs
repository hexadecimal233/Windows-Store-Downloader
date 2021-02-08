using System;
using System.Drawing;

namespace WinUtils
{
    public class FormUtils
    {
        public static void DragWindow(IntPtr hwnd)
        {
            WinAPI.ReleaseCapture();
            WinAPI.SendMessage(hwnd, Constants.WM_SYSCOMMAND, (IntPtr)(Constants.SC_MOVE + Constants.HTCAPTION), IntPtr.Zero);
        }

        public static void ShowSystemMenu(IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero)
                return;

            Point defPnt = new Point();
            WinAPI.GetCursorPos(ref defPnt);

            IntPtr hmenu = WinAPI.GetSystemMenu(hwnd, false);
            IntPtr cmd = WinAPI.TrackPopupMenuEx(hmenu, Constants.TPM_LEFTBUTTON | Constants.TPM_RETURNCMD, (uint)defPnt.X, (uint)defPnt.Y, hwnd, IntPtr.Zero);


            if (cmd != IntPtr.Zero)
                WinAPI.PostMessage(hwnd, Constants.WM_SYSCOMMAND, cmd, IntPtr.Zero);

        }

        public static void ShowShield(IntPtr buttonHandle, bool showShield)
        {
            WinAPI.SendMessage(buttonHandle, Constants.BCM_SETSHIELD, IntPtr.Zero, showShield ? (IntPtr)1 : IntPtr.Zero);
        }
    }
}