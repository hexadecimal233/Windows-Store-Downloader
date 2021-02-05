using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Windows_Store_Downloader
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        private bool textBoxHasText = false;
        Form2 Form2 = new Form2();
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

            
        }
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
            

        }
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
        }
        private string SetAttributeText() {
            return Language.lang_attributes[typeBox.SelectedIndex];
        }

        private void DownloadButton_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            if (typeBox.SelectedIndex == -1 || routeBox.SelectedIndex == -1 || langText.Text == "" || attributeText.Text == "")
            {
                MessageBox.Show(Language.lang_baddown,Language.lang_baddowninfo,MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else {
                postContent = "type=" + Http_Post.type[typeBox.SelectedIndex] + "&url=" + attributeText.Text + "&ring=" +
          Http_Post.ring[routeBox.SelectedIndex] + "&lang=" + langText.Text;

                Thread post = new Thread(Form2.Browse);
                post.Start();
                while (Form2.complete == false)
                {
                    if(progressBar1.Value <= 99)
                    {
                        Random random = new Random(new Guid().GetHashCode());
                        Thread.Sleep(random.Next(67, 101));
                        progressBar1.PerformStep();
                    }
                }
                progressBar1.Value = 100;
            }
            
        }

        private void ChangeLanguage(object sender, EventArgs e)
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
            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name == "zh-CN") {
                Chinese_Lang();
                langBox.SelectedIndex = 1;
            } else {
                English_Lang();
                langBox.SelectedIndex = 0;
            }
            typeBox.SelectedIndex = 0;
            routeBox.SelectedIndex = 2;

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
            groupBox1.Text = Language.lang_downbutton;
            attributeText.Text = Language.lang_input;
            progressText.Text = Language.lang_prog;
        }

    }
}
