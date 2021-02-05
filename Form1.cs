using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Windows_Store_Downloader
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        
        Form2 Form2 = new Form2();
        private void attributeInputReady(object sender, EventArgs e)
        {
            if (attributeText.Text == Language.lang_input)
            {
                attributeText.Text = "";
                attributeText.ForeColor = Color.Black;
            }
        }

        private void attributeInputDeselect(object sender, MouseEventArgs e)
        {
            if(attributeText.Text == "")
            {
                attributeText.Text = setAttributeText();
                attributeText.ForeColor = Color.Gray;
            }
        }

        private string setAttributeText() {
            return Language.lang_attributes[routeBox.SelectedIndex];
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            if(typeBox.SelectedIndex == -1 || routeBox.SelectedIndex == -1 || langText.Text == "" || attributeText.Text == "")
            {
                MessageBox.Show(Language.lang_baddown,Language.lang_baddowninfo,MessageBoxButtons.OK,MessageBoxIcon.Error);
            } else {
                Form2.OpenBrowser();
            }
            
        }

        private void changeLanguage(object sender, EventArgs e)
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
        }
    }
}
