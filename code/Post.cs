using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System;
namespace Windows_Store_Downloader
{
    class Http_Post
    {
        public static string[] ring = new string[] { "WIF", "WIS", "RP", "Retail" };
        public static string[] type = new string[] { "url", "ProductId", "PackageFamilyName", "CategoryId" };
        private const string LINK_HTTP = "https://store.rg-adguard.net/api/GetFiles";
        public string StartPostData(string content)
        {
            Debug.WriteLine("<POST> Post Link: " + LINK_HTTP + " ; Post Data: " + content + "<POST>");
            try
            {
                return Post(LINK_HTTP, content);
            }
            catch (Exception)
            {
                Language.InternalErrMsgBox();
                return "";
            }
        }
        private static string Post(string url, string content)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            #endregion

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }
    }

}
