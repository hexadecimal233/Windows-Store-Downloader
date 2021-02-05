using System;
using System.Windows.Forms;


namespace Windows_Store_Downloader
{
    public partial class Form2 : Form
    {
        private const string LINK_HTTP = "https://store.rg-adguard.net/api/GetFiles";

        public Form2()
        {
            InitializeComponent();
        }

        public void OpenBrowser()
        {
            try
            {
                new Form2().ShowDialog();
                Form1 Form1 = new Form1();
                //dataMSStore.Navigate(LINK_HTTP + "type=" + Form1.typeBox.Text + "&url=" + Form1.langText.Text + "&ring=" + Form1.routeBox.Text +
                //    "&lang=" + Form1.langText.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
