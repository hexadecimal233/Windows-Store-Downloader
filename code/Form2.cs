using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Windows_Store_Downloader
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
        }
        public static string result; //post返回的表格
        public static int returnid;
        /// <summary>
        /// Returnid:
        /// -1：意外
        /// 1：完成
        /// 2：空响应
        /// </summary>
        public bool complete = false;
        Http_Post Http_Post = new Http_Post();
        public void Browse()
        {
            WriteToTemp WriteToTemp = new WriteToTemp();
            complete = false;
            result = "";
            string content = Form1.postContent;
            result = Http_Post.StartPostData(content); //POST
            if (result == "")  
            {
                returnid = -1;
                complete = true;
                return;
            }//意外-1
            Thread postlog = new Thread(WriteToTemp.PostLog);
            postlog.Start();//记录日志
            if (result.IndexOf("The server returned an empty list") != -1)
            {
                complete = true;
                returnid = 2;
                return;
            }//空响应0
            string result2 = RemoveUselessContent(result);//格式化
            if (result2 == "") {
                returnid = -1;
                complete = true;
                return;
            } // 处理错误-1
            returnid = 1; //成功
            complete = true;
            Debug.WriteLine(result2);
            return;
        }
        private string RemoveUselessContent(string old)//格式化
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
        private string Mdui(string old)//加入Mdui格式
        {

            return old;
        }
         private void Form2_Load(object sender, EventArgs e)
        {
            var urlString = new Uri(WriteToTemp.tmpPath + @"\" + Language.lang_errhtm);
            Debug.WriteLine(urlString);
            if (System.Diagnostics.Debugger.IsAttached == true)
            {
                webBrowser1.AllowWebBrowserDrop = true;
            }

            webBrowser1.Navigate(urlString);
            webBrowser1.DocumentTitleChanged += DocTitleClose;
        }
        private void DocTitleClose(object sender, EventArgs e)
        {
            if (webBrowser1.DocumentTitle == "IAMOKAY")
            {
                Close();
            }
        }
    }
    
}
