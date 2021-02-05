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
        Language Language = new Language();
        
        private void attributeInputReady(object sender, EventArgs e)
        {
            attributeText.Text = "";
            attributeText.ForeColor = Color.Black;
        }

        private void attributeInputDeselect(object sender, MouseEventArgs e)
        {
            if(attributeText.Text != "")
            {
                attributeText.Text = setAttributeText();
                attributeText.ForeColor = Color.Gray;
            }
        }

        private string setAttributeText() {
            //return (Language.GetLanguage(Language.SysLangID, zh_CN.lang_attributes[routeBox.SelectedIndex + 1]));
            return ("bad");
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            Form2.OpenBrowser();
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (langBox.Text == "English")
            {
                typeLinkText.Text = global.lang_typelink;
                langPackText.Text = global.lang_language;
                routeText.Text = global.lang_route;
                downloadButton.Text = global.lang_downbutton;
                this.Text = global.lang_title;
            } else if (langBox.Text == "中文（简体）") {
                typeLinkText.Text = zh_CN.lang_typelink;
                langPackText.Text = zh_CN.lang_language;
                routeText.Text = zh_CN.lang_route;
                downloadButton.Text = zh_CN.lang_downbutton;
                this.Text = zh_CN.lang_title;
            }
        }
        
    }
}
