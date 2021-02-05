using System;
using System.Windows.Forms;

namespace Windows_Store_Downloader
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }
        public bool complete = false;
        Http_Post Http_Post = new Http_Post();
        public void Browse()
        {            
            complete = false;
            string content = Form1.postContent;
            string result = Http_Post.StartPostData(content);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@WriteToTemp.tmpPath + "\\post.log", true))
            {
                file.WriteLine(result);

            }
            if (result.IndexOf("The server returned an empty list") != -1)
            {
                complete = true;
                new Form2().ShowDialog();
                
                System.Diagnostics.Debug.WriteLine("file:///" + WriteToTemp.tmpPath.Replace("\\", "/") + "/" + Language.lang_errhtm);
                webBrowser1.Navigate("file:///" + WriteToTemp.tmpPath.Replace("\\","/") + "/" + Language.lang_errhtm);
                
                return;
            }
            if (result == "") { complete = true; return; }
            string result2 = RemoveUselessContent(result);
            if (result2 == "") { complete = true; return; }
            complete = true;
            MessageBox.Show(result2);
            
            return;
        }
        private string RemoveUselessContent(string old)
        {
            try
            {
                int starta = old.IndexOf("<table class=\"tftable\" border=\"1\" align=\"center\">");
                int startb = old.IndexOf("<script type=\"text/javascript\">");
                string new_1 = old.Substring(starta - 1, startb - starta + 1);
                return new_1;
            }
            catch (Exception)
            {
                Language.InternalErrMsgBox();
                return "";
            }
            
        }
    }
}
