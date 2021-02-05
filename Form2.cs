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
            complete = true;
            MessageBox.Show(result);
            return;
        }
    }
}
