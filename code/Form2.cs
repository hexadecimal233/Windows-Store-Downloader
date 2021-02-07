using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            zh_CN zh_CN = new zh_CN();
            global global = new global();
            WriteToTemp WriteToTemp = new WriteToTemp();
            if (File.Exists(WriteToTemp.tmpPath + @"\" + zh_CN.lang_tablehtm))
            {
                File.Delete(WriteToTemp.tmpPath + @"\" + zh_CN.lang_tablehtm);
            }
            else if (File.Exists(WriteToTemp.tmpPath + @"\" + global.lang_tablehtm))
            {
                File.Delete(WriteToTemp.tmpPath + @"\" + global.lang_tablehtm);
            }//去除文件缓存

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
            string result3 = Mdui(result2);
            Debug.WriteLine(result3);
            string result4;
            if(Language.langUsing == "global")
            {
                result4 = Properties.Resources.table_1 + "\n" + result3 + "\n" + Properties.Resources.table_2;
            } else {
                result4 = Properties.Resources.table_1_cn + "\n" + result3 + "\n" + Properties.Resources.table_2_cn;
            } //language
            
            
            File.WriteAllText(WriteToTemp.tmpPath + @"\" + Language.lang_tablehtm,result4);//写出合并后的文本
            returnid = 1; //成功
            complete = true;            
            return;
        }//POST和格式化等
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
            string new1,new2;
            new1 = old.Replace("class=\"tftable\" border=\"1\" align=\"center\"",
                "class=\"mdui-table\" style=\"margin-left: 20px;margin-right: 20px;margin-top: 20px;\"")
                .Replace("style=\"width:180px;\"", "")
                .Replace("style=\"width:300px;\"", "")
                .Replace("style=\"width:60px;\"", "")
                .Replace("style=\"background-color:rgba(255, 255, 255, 0.8)\"", "")
                .Replace("style=\"background-color:rgba(188, 235, 240, 0.8)\"", "class=\"mdui-color-blue-100\"")
                .Replace("1970-01-01 00:00:00 GMT","Unlimited");
            if (Language.langUsing != "global")
            {
                new2 = new1.Replace("File:", "文件:")
                    .Replace("Expire:","过期时间:").
                    Replace("SHA-1:","SHA-1校验值:")
                    .Replace("Size:","文件大小:");
            } else { new2 = new1; }

                return new2;
        }
         private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = Language.lang_down;
            var urlString = new Uri(WriteToTemp.tmpPath + @"\" + Language.lang_tablehtm);
            Debug.WriteLine(urlString);
            if (System.Diagnostics.Debugger.IsAttached == true)
            {
                webBrowser1.AllowWebBrowserDrop = true;
            }
            if (returnid != 2)
            {
                webBrowser1.Navigate(urlString);
            }
            else
            {
                webBrowser1.Navigate(WriteToTemp.tmpPath + "\\" + Language.lang_errhtm);
            }             //打开网页




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
