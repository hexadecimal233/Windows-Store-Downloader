using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
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
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@WriteToTemp.tmpPath + "\\..\\post.log", true))
            {
                file.WriteLine(result);

            }
            if (result.IndexOf("The server returned an empty list") != -1)
            {
                complete = true;
                
                try
                {
                    InitBrowser();
                    //webBrowser1.Navigate("\""+WriteToTemp.tmpPath + @"\" + Language.lang_errhtm+"\"");
                    webBrowser1.Navigate(new Uri("file:///C:/Users/User-WIN/AppData/Roaming/Local/Temp/MSStoreDownloadTemp/xPfeOin6F7/error-cn.html"));
                }
                catch (System.Runtime.InteropServices.InvalidComObjectException) { }
                catch (Exception ex)
                {
                    Language.InternalErrMsgBox(ex);
                }



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
            catch (Exception ex)
            {
                Language.InternalErrMsgBox(ex);
                return "";
            }
            
        }
        private void InitBrowser()
        {
            webBrowser1.ScriptErrorsSuppressed = true; //禁用错误脚本提示  
            webBrowser1.IsWebBrowserContextMenuEnabled = false; // 禁用右键菜单  
            webBrowser1.WebBrowserShortcutsEnabled = false; //禁用快捷键  
            webBrowser1.AllowWebBrowserDrop = false; // 禁止文件拖动 
            


        }
    }
    
}
