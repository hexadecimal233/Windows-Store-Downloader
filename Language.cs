
namespace Windows_Store_Downloader
{
    class Language
    {
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
        }
    }
}
