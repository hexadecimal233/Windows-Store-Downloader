namespace Windows_Store_Downloader
{
    class global
    {
        public string[] lang_attributes = new string[] {
            "Sample Data: https://www.microsoft.com/store/productId/9NSWSBXN8K03",
            "Sample Data: 9NKSQGP7F2NH",
            "Sample Data: Microsoft.WindowsStore_8wekyb3d8bbwe", 
            "Sample Data: d58c3a5f-ca63-4435-842c-7814b5ff91b7"
            };
        public string lang_title = "Microsoft Store Downloader";
        public string lang_typelink = "Download link type";
        public string lang_language = "Post Language(Example:en-US)";
        public string lang_route = "Download Route";
        public string lang_downbutton = "Download";
        public string lang_input = "Input here...";
        public string lang_baddowninfo = "Error";
        public string lang_baddown = "Your download info is incorrect.";
        public string lang_down = "Download";
        public string lang_prog = "Query progress";
        public string lang_interr = "Internal Error Occurred.\nView " + WriteToTemp.tmpPath +
            "\\..\\exception.log" + "for technical information.";
        public string lang_errhtm = "error.html";
        public string lang_neterr = "Network error.";
    }
}
