using System.Windows.Forms;

namespace WinUtils
{
    public static class DPI
    {
        private delegate void SetProcessDPIAware();

        public static void SetCurrentProcessDPIAware()
        {
            SetProcessDPIAware addrSetProcessDPIAware = (SetProcessDPIAware)
                WinAPI.GetFunctionAddress(
                WinAPI.GetModuleHandle("user32.dll"), 
                "SetProcessDPIAware", 
                typeof(SetProcessDPIAware));

            if (addrSetProcessDPIAware != null)
                addrSetProcessDPIAware();
            else
                MessageBox.Show("DPI Unsupported");
            
        }

    }
}


