using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace WinUtils.Dialogs
{
    public class OpenIconDialog
    {
        private string _IconFile = "";

        private int _IconIndex;

        public string IconFile
        {
            get
            {
                return this._IconFile;
            }
            set
            {
                this._IconFile = value;
            }
        }

        public int IconIndex
        {
            get
            {
                return this._IconIndex;
            }
            set
            {
                this._IconIndex = value;
            }
        }



        private void ParseIconPath(string IconPath)
        {
            if (IconPath == null || IconPath.Length == 0)
            {
                this._IconFile = "";
                this._IconIndex = 0;
                return;
            }
            this._IconIndex = 0;
            this._IconFile = IconPath;
            string[] array = IconPath.Split(new char[]
            {
                ','
            }, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length > 1)
            {
                string s = array[array.Length - 1];
                int iconIndex = 0;
                if (int.TryParse(s, out iconIndex))
                {
                    this._IconIndex = iconIndex;
                    this._IconFile = array[0];
                    if (array.Length > 2)
                    {
                        string[] array2 = new string[array.Length - 1];
                        Array.Copy(array, 0, array2, 0, array.Length - 2);
                        this._IconFile = string.Join(",", array2);
                    }
                }
            }
        }

        public OpenIconDialog()
        {
            this._IconFile = "%windir%\\system32\\shell32.dll";
            this._IconIndex = 0;
        }

        public OpenIconDialog(string IconPath)
        {
            this.ParseIconPath(IconPath);
            if (!File.Exists(this._IconFile))
            {
                this._IconFile = "%windir%\\system32\\shell32.dll";
                this._IconIndex = 0;
            }
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto, EntryPoint = "#62")]
        public static extern int PickIconDlg98(IntPtr hwndOwner, StringBuilder lpstrFile, int nMaxFile, ref int lpdwIconIndex);

        public DialogResult ShowDialog(IntPtr OwnerHandle)
        {
            StringBuilder stringBuilder = new StringBuilder(this._IconFile, 500);
            int iconIndex = this._IconIndex;
            int ret = 0;

            try
            {
                ret = WinAPI.PickIconDlg(OwnerHandle, stringBuilder, stringBuilder.Capacity, ref iconIndex);
            }
            catch
            {
                ret = PickIconDlg98(OwnerHandle, stringBuilder, stringBuilder.Capacity, ref iconIndex);
            }


            if (ret == 0)
            {
                this._IconFile = "";
                this._IconIndex = 0;
                return DialogResult.Cancel;
            }
            this._IconFile = Environment.ExpandEnvironmentVariables(stringBuilder.ToString());
            this._IconIndex = iconIndex;
            return DialogResult.OK;
        }
    }
}
    