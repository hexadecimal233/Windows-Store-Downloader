using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Store_Downloader_CLI
{
    class INI
    {
        #region API函数声明

        [DllImport("kernel32")]//返回0表示失败，非0为成功
        private static extern long WritePrivateProfileString(string section, string key,
            string val, string filePath);

        [DllImport("kernel32")]//返回取得字符串缓冲区的长度
        private static extern long GetPrivateProfileString(string section, string key,
            string def, StringBuilder retVal, int size, string filePath);
        #endregion
        public string ReadIniData(string Section, string Key, string NoText, string iniFilePath)//读取INI文件
        {
            string str = System.Environment.CurrentDirectory;//获取当前文件目录
            //ini文件路径
            string str1 = "" + str + "\\config.ini";
            if (File.Exists("" + str1 + ""))
            {
                StringBuilder temp = new StringBuilder(1024);
                GetPrivateProfileString(Section, Key, NoText, temp, 1024, iniFilePath);
                return temp.ToString();
            }
            else
            {
                return String.Empty;
            }
        }
        //参数解释：参数1(section):写入ini文件的某个小节名称（不区分大小写）。
        //参数2(key):上面section下某个项的键名(不区分大小写)。
        //参数3(val):上面key对应的value
        //参数4(filePath):ini的文件名，包括其路径(example: "c:\config.ini")。如果没有指定路径，仅有文件名，系统会自动在windows目录中查找是否有对应的ini文件，如果没有则会自动在当前应用程序运行的根目录下创建ini文件。

    }
}
