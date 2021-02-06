using System;
using System.IO;
using System.Windows.Forms;
using System.IO.Compression;
using System.Text;

namespace Windows_Store_Downloader
{
    class WriteToTemp
    {
        //随机字符串生成器的主要功能如下： 
        //1、支持自定义字符串长度
        //2、支持自定义是否包含数字
        //3、支持自定义是否包含小写字母
        //4、支持自定义是否包含大写字母
        //5、支持自定义是否包含特殊符号
        //6、支持自定义字符集
        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="length">目标字符串的长度</param>
        /// <param name="useNum">是否包含数字，1=包含，默认为包含</param>
        /// <param name="useLow">是否包含小写字母，1=包含，默认为包含</param>
        /// <param name="useUpp">是否包含大写字母，1=包含，默认为包含</param>
        /// <param name="useSpe">是否包含特殊字符，1=包含，默认为不包含</param>
        /// <param name="custom">要包含的自定义字符，直接输入要包含的字符列表</param>
        /// <returns>指定长度的随机字符串</returns>
        public string GetRnd(int length, bool useNum, bool useLow, bool useUpp, bool useSpe, string custom)
        {
            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random r = new Random(BitConverter.ToInt32(b, 0));
            string s = null, str = custom;

            if (useNum == true) { str += "0123456789"; }
            if (useLow == true) { str += "abcdefghijklmnopqrstuvwxyz"; }
            if (useUpp == true) { str += "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; }
            if (useSpe == true) { str += "!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~"; }

            for (int i = 0; i < length; i++)
            {
                s += str.Substring(r.Next(0, str.Length - 1), 1);
            }

            return s;
        }
        public static string tmpPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
                "\\Local\\Temp\\MSStoreDownloadTemp\\data" ;
        public void ReadFrom()
        {
            try {
                if (File.Exists(@tmpPath + "\\..\\res.zip") == false)
                {
                    File.WriteAllBytes(@tmpPath + "\\..\\res.zip", Properties.Resources.res);
                }
            } catch (Exception) { }
            try
            {
                if (File.Exists(@tmpPath + "\\error.html") == false)
                {
                    ZipFile.ExtractToDirectory(@tmpPath + "\\..\\res.zip", @tmpPath);
                }
                
            } catch(FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "!");
                Environment.Exit(0);
            }
            catch (IOException)
            {
                return;
            }
            catch (Exception ex)
            {
                Language.InternalErrMsgBox(ex);
            }
            

        }
        public void PostLog()
        {
            try
            {
            File.Delete(WriteToTemp.tmpPath + "\\..\\post.log"); 
            } 
            catch (Exception) { }
            
           

                //压缩
                var str = Form2.result;
                var memoryStream = new MemoryStream();
                var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress);
                var byteList = Encoding.UTF8.GetBytes(str);
                gZipStream.Write(byteList, 0, byteList.Length);
                gZipStream.Close();
                var output = memoryStream.ToArray();
                File.WriteAllBytes(tmpPath + "\\..\\post.log." + GetTimeStamp().ToString() + ".gz", output);


            
        }//记录日志
        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }// 获取时间戳
        

    }
}
