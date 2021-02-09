using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using WinUtils;

namespace Windows_Store_Downloader
{
    public partial class Form1 : Form
    {

        public static string OSVersion = get_OSVersion();

        public Form1()
        {
            InitializeComponent();
           
        }
        
        private bool textBoxHasText = false;
        Form2 Form2 = new Form2();
 
        WriteToTemp WriteToTemp = new WriteToTemp();
        public static string postContent;
        private void AttributeInputReady(object sender, EventArgs e)
        {
            HasText();
            if (textBoxHasText == false)
            {
                attributeText.Text = "";
                attributeText.ForeColor = Color.Black;
            }
            else
            {
                attributeText.ForeColor = Color.Black;
            }

            
        }//灰色文本
        private void HasText()
        {

                if (attributeText.Text == "" || attributeText.Text == Language.lang_attributes[0] ||
                attributeText.Text == Language.lang_input || attributeText.Text == Language.lang_attributes[1] ||
                attributeText.Text == Language.lang_attributes[2] || attributeText.Text == Language.lang_attributes[3])
                {
                    textBoxHasText = false;
                }
                else
                {
                    textBoxHasText = true;
                }
            

        }//编辑框是否有文字
        private void AttributeInputDeselect(object sender, EventArgs e)
        {
            HasText();
                if (textBoxHasText == false)
            {
                attributeText.Text = SetAttributeText();
                attributeText.ForeColor = Color.Gray;
                textBoxHasText = false;
            }
            else
            {
                textBoxHasText = true;
            }
        }//灰色文本
        private string SetAttributeText() {
            return Language.lang_attributes[typeBox.SelectedIndex];
        }//获取当前项的本地化文本


        private void DownloadButton_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            this.Enabled = false;//禁止重复点击
            Form2.complete = false;
            HasText();
            if (typeBox.SelectedIndex == -1 || routeBox.SelectedIndex == -1 || textBoxHasText == false)
            {
                
                MessageBox.Show(Language.lang_baddown,Language.lang_baddowninfo,MessageBoxButtons.OK,MessageBoxIcon.Error);
                this.Enabled = true;
                return;
            }//参数完整
                if (langText.Text == "")
                {
                    langText.Text = Thread.CurrentThread.CurrentCulture.Name; 
                }//提交语言
                postContent = "type=" + Http_Post.type[typeBox.SelectedIndex] + "&url=" + attributeText.Text + "&ring=" +
                    Http_Post.ring[routeBox.SelectedIndex] + "&lang=" + langText.Text;

            
            Thread post = new Thread(Form2.Browse);
            post.IsBackground = true;
            post.SetApartmentState(ApartmentState.STA);
                post.Start();  //POST线程


            while (Form2.complete == false)
            {
                if (progressBar1.Value <= 99)
                {
                    Random random = new Random(new Guid().GetHashCode());
                    Thread.Sleep(random.Next(67, 101));
                    progressBar1.PerformStep();

                }
               
            }//伪装进度条
            progressBar1.Value = 100;
            this.Enabled = true;


            
            if (Form2.returnid == -1)
                {
                 MessageBox.Show(Language.lang_interr, Language.lang_interr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return;
                }//意外
                if (Form2.returnid == 2) {

                Form2.ShowDialog();
                }//空响应
                if (Form2.returnid == 1)//浏览
                {
                try
                    {
                        new Form2().ShowDialog();
                    } catch (Exception ex)
                    {
                        Language.InternalErrMsgBox(ex);
                    }
                }//OK

            
            
        }//下载&浏览

        private void ChangeLanguage(object sender, EventArgs e)//更改语言
        {
            if (langBox.Text == "English")
            {
                English_Lang();
            } else if (langBox.Text == "中文（简体）") {
                Chinese_Lang();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(WriteToTemp.tmpPath + "\\..\\forcewin7") )
            {
                forceWin7 = true;
            }
           
            SetWindowRegion();
            RefreshForm();
            WriteToTemp.ReadFrom();
            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN") {
                Chinese_Lang();
                langBox.SelectedIndex = 1;
            } else {
                English_Lang();
                langBox.SelectedIndex = 0;
            }
            
            if (IsWinLess10())
            {
                CloseButton.ForeColor = Color.DodgerBlue;
                User32.AnimateWindow(this.Handle, 200, User32.AW_BLEND | User32.AW_ACTIVE | User32.AW_VER_NEGATIVE);
                RefreshForm();
                this.Opacity = 0.90;
            }// Win7淡入淡出
            else
            {
                this.TransparencyKey = Color.FromArgb(0xf1f1f0);//R不等于B
                RefreshForm();
                Acrylic.SetBlur(this.Handle, 0x3FFFFFFF);//亚克力效果
            }//WIN10亚克力
            
        }

        private void Chinese_Lang()
        {
            Language.Chinese_Lang();
            SetLang();
        }
        private void English_Lang()
        {
            Language.English_Lang();
            SetLang();
        }
        private void SetLang() {
            typeLinkText.Text = Language.lang_typelink;
            langPackText.Text = Language.lang_language;
            routeText.Text = Language.lang_route;
            downloadButton.Text = Language.lang_downbutton;
            this.Text = Language.lang_title;
            title.Text = Language.lang_title;
            groupBox1.Text = Language.lang_downbutton;
            attributeText.Text = Language.lang_input;
            progressText.Text = Language.lang_prog;
            button1.Text = Language.lang_forcewin7;
        }//设置语言文本

        private void RefreshText(object sender, EventArgs e)//刷新文本
        {
            HasText();
            if (textBoxHasText == false)
            {
                attributeText.Text = SetAttributeText();
                attributeText.ForeColor = Color.Gray;
                textBoxHasText = false;
            }
            else
            {
                textBoxHasText = true;
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)//淡出
        {

            if (IsWinLess10())
            {
                this.Opacity = 1;
                User32.AnimateWindow(this.Handle, 300, User32.AW_BLEND | User32.AW_HIDE);
            }

        }
        private void RefreshForm()//初始化窗口
        {
            if (forceWin7)
            {
                button1.Visible = false;

            }
            if (!IsWinLess10())
            {
                if (File.Exists("acrylic.dll") == false)
                {
                    MessageBox.Show("acrylic.dll not found.Please put the dll to current directory." +
                        "\n无法找到acrylic.dll。请把它放到当前目录。");
                    Environment.Exit(0);
                }
            }//容错dll
            Bitmap a = Properties.Resources.store;
            a.MakeTransparent(Color.FromArgb(0, 255, 0));//透明图片
            pictureBox1.BackgroundImage = a;
            if (System.Diagnostics.Debugger.IsAttached != true)
            {
                langText.Visible = false;
                langPackText.Visible = false;
            }//调试内容
            typeBox.SelectedIndex = 0;
            routeBox.SelectedIndex = 2;
            //初始化选择框

            attributeText.Text = SetAttributeText();
            attributeText.ForeColor = Color.Gray;
            textBoxHasText = false;
            //初始化文字
          
        }

        private Rectangle rect;
        private bool firstPaint = true;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //防止画窗口出错
            if (firstPaint == true)
            {
                firstPaint = false;
                rect = this.ClientRectangle;
            }

            if (IsWinLess10())
            {


                Graphics g = e.Graphics;   //实例化Graphics 对象g
                Color FColor = Color.FromArgb(0xE8, 0xF1, 0xE7); //颜色1
                Color TColor = Color.FromArgb(0xCA, 0xC7, 0xC7);  //颜色2
                Brush b = new LinearGradientBrush(rect, FColor, TColor, LinearGradientMode.BackwardDiagonal);  //实例化刷子，第一个参数指示上色区域，第二个和第三个参数分别渐变颜色的开始和结束，第四个参数表示颜色的方向。
                g.FillRectangle(b, this.ClientRectangle);  //进行上色 

            } //WIN7渐变背景


        }
        

        private bool forceWin7 = false;//强制win7透明
        public static string get_OSVersion()
        {
            try
            {
             
                ManagementObjectSearcher mos = new ManagementObjectSearcher("Select * From Win32_OperatingSystem");
                string version = null;
                foreach (ManagementObject mo in mos.Get())
                {
                    version = mo["Version"].ToString().Trim();
                    break;
                }
                    if (null == version)
                    return string.Empty;

                return version;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        private bool IsWinLess10()
        {
            if (forceWin7)
            {
                return true;
            }

            
            if ((Environment.OSVersion.Version.Major <= 6 && Environment.OSVersion.Version.Minor < 2 ) ||
                OSVersion.IndexOf("10.0.") == -1)
            {
                return true;
            } else
            {
                return false;
            }
            
        }
        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;
        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            thread2 = new Thread(GoIntoB);
            thread2.IsBackground = true;
            thread2.Start();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void CloseButton_MouseHover(object sender, EventArgs e)
        {
            thread1 = new Thread(GoIntoA);
            thread1.IsBackground = true;
            try { thread1.Start(); } catch { }
            
            
        }
        private void GoIntoA()
        {
            for (int i = 0; i < 228; i += 4)
            {
                Thread.Sleep(1);
                this.CloseButton.BackColor = Color.FromArgb(i, i, 5, 0);
            }

        }
        private void GoIntoB()
        {
            thread1.Abort();
            for (int i = this.CloseButton.BackColor.A; i > 0; i -= 4)
            {
                Thread.Sleep(1);
                this.CloseButton.BackColor = Color.FromArgb(i, i, 0, 0);
            }
            this.CloseButton.BackColor = Color.FromArgb(0, 0, 0, 0);
        }
        private void GoIntoC()
        {
            for (int i = 0; i < 231; i += 3)
            {
                Thread.Sleep(1);
                this.MinimizeButton.BackColor = Color.FromArgb(i, i+3, i+2, i);
            }

        }
        private void GoIntoD()
        {
            thread3.Abort();
            for (int i = this.MinimizeButton.BackColor.B; i > 0; i -= 3)
            {
                Thread.Sleep(1);
                this.MinimizeButton.BackColor = Color.FromArgb(i, i + 3, i + 2, i);
            }
            this.MinimizeButton.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        public void SetWindowRegion()
        {
            GraphicsPath FormPath1, FormPath2;
            
            FormPath1 = new GraphicsPath();
            FormPath2 = new GraphicsPath();
            Rectangle rect1 = new Rectangle(0, 0, this.Width, this.Height);
            FormPath1 = GetRoundedRectPath(rect1, 50);
            Rectangle rect2 = new Rectangle(0, 0, downloadButton.Width, downloadButton.Height);
            FormPath2 = GetRoundedRectPath(rect2, 30);
            this.Region = new Region(FormPath1);
            downloadButton.Region = new Region(FormPath2);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect">窗体大小</param>
        /// <param name="radius">圆角大小</param>
        /// <returns></returns>
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            int diameter =radius;
            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));
            GraphicsPath path = new GraphicsPath();

            path.AddArc(arcRect, 180, 90);//左上角

            arcRect.X = rect.Right - diameter;//右上角
            path.AddArc(arcRect, 270, 90);

            arcRect.Y = rect.Bottom - diameter;// 右下角
            path.AddArc(arcRect, 0, 90);

            arcRect.X = rect.Left;// 左下角
            path.AddArc(arcRect, 90, 90);
            path.CloseFigure();
            return path;
        }



        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                
            } else
            {
                FormUtils.DragWindow(this.Handle);
            }
            
        }//拖拽窗口

        private void downloadButton_MouseEnter(object sender, EventArgs e)
        {
            downloadButton.BackColor = Color.FromArgb(0x4a,0x5f,0xbd);
        }

        private void downloadButton_MouseLeave(object sender, EventArgs e)
        {
            downloadButton.BackColor = Color.FromArgb(0x3f,0x51,0xb5);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            thread3 = new Thread(GoIntoC);
            thread3.IsBackground = true;
            try { thread3.Start(); } catch { }
            
        }

        private void label3_MouseLeave(object sender, EventArgs e) {
            thread4 = new Thread(GoIntoD);
            thread4.IsBackground = true;
            thread4.Start();
            
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(Language.lang_forcewin7, Language.lang_title, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) != DialogResult.OK)
                return;
            button1.Enabled = false;
            try
            {
                File.Create(WriteToTemp.tmpPath + "\\..\\forcewin7");
            } catch { }
            
        }
    }
    class User32
    {
        /// <summary>
        /// 窗体动画函数
        /// </summary>
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>
        /// <param name="dwTime">指定动画持续的时间</param>
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>
        /// <returns></returns>
        [DllImport("user32")]
        public static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        [DllImport("user32")]
        public static extern IntPtr FindWindow(string a, string b);
        [DllImport("user32")]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        //下面是可用的常量，根据不同的动画效果声明自己需要的
        public const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        public const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        public const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志
        public const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志
        public const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展
        public const int AW_HIDE = 0x10000;//隐藏窗口
        public const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志
        public const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略
        public const int AW_BLEND = 0x80000;//使用淡入淡出效果
    }//淡入淡出
    class Acrylic
    {
        
        [DllImport("acrylic", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SetBlur(IntPtr hWnd, int gradientColor);
    }
}
