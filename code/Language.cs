
using System.Windows.Forms;

namespace Windows_Store_Downloader
{
    class Language
    {
        //语言系统
        static zh_CN zh_CN = new zh_CN();
        static global global = new global();

        public static string[] lang_attributes = new string[4];
        public static string lang_baddown;
        public static string lang_baddowninfo;        
        public static string lang_title;
        public static string lang_typelink;
        public static string lang_language;
        public static string lang_route;
        public static string lang_downbutton;
        public static string lang_input;
        public static string lang_down;
        public static string lang_prog;
        public static string lang_interr;
        public static string lang_errhtm;
        public static string lang_neterr;
        public static void Chinese_Lang()
        {
            lang_attributes[0] = zh_CN.lang_attributes[0];
            lang_attributes[1] = zh_CN.lang_attributes[1];
            lang_attributes[2] = zh_CN.lang_attributes[2];
            lang_attributes[3] = zh_CN.lang_attributes[3];
            lang_typelink = zh_CN.lang_typelink;
            lang_language = zh_CN.lang_language;
            lang_route = zh_CN.lang_route;
            lang_downbutton = zh_CN.lang_downbutton;
            lang_title = zh_CN.lang_title;
            lang_baddown = zh_CN.lang_baddown;
            lang_baddowninfo = zh_CN.lang_baddowninfo;
            lang_input = zh_CN.lang_input;
            lang_down = zh_CN.lang_down;
            lang_prog = zh_CN.lang_prog;
            lang_interr = zh_CN.lang_interr;
            lang_errhtm = zh_CN.lang_errhtm;
            lang_neterr = zh_CN.lang_neterr;
    }
        public static void English_Lang()
        {
            lang_attributes[0] = global.lang_attributes[0];
            lang_attributes[1] = global.lang_attributes[1];
            lang_attributes[2] = global.lang_attributes[2];
            lang_attributes[3] = global.lang_attributes[3];
            lang_typelink = global.lang_typelink;
            lang_language = global.lang_language;
            lang_route = global.lang_route;
            lang_downbutton = global.lang_downbutton;
            lang_title = global.lang_title;
            lang_baddown = global.lang_baddown;
            lang_baddowninfo = global.lang_baddowninfo;
            lang_input = global.lang_input;
            lang_down = global.lang_down;
            lang_prog = global.lang_prog;
            lang_interr = global.lang_interr;
            lang_errhtm = global.lang_errhtm;
            lang_neterr = global.lang_neterr;
        }
        public static void InternalErrMsgBox(System.Exception ex){
            MessageBox.Show(Language.lang_interr, Language.lang_interr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@WriteToTemp.tmpPath + "\\..\\exception.log", true))
            {
                file.WriteLine(ex);

            }
        }//内部错误信息框
    }
}
