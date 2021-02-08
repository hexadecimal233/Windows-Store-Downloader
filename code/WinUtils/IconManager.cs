using System;
using System.Drawing;

namespace WinUtils
{
    public class IconManager
    {

        public static int GetIconCount(string path)
        {
            IntPtr iconL, iconS;
            return WinAPI.ExtractIconEx(path, -1, out iconL, out iconS, 0);
        }

        public static Icon GetIcon(string path, int index, bool isLargeIcon)
        {
            IntPtr iconL, iconS;
            WinAPI.ExtractIconEx(path, index, out iconL, out iconS, 1);

            IntPtr iconHandle;
            if (isLargeIcon)
            {
                iconHandle = iconL;
                WinAPI.DestroyIcon(iconS);
            }
            else
            {
                iconHandle = iconS;
                WinAPI.DestroyIcon(iconL);
            }


            return iconHandle == IntPtr.Zero ? null : Icon.FromHandle(iconHandle);
        }
    }
}