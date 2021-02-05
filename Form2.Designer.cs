
namespace Windows_Store_Downloader
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataMSStore = new System.Windows.Forms.WebBrowser();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // dataMSStore
            // 
            this.dataMSStore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataMSStore.Location = new System.Drawing.Point(0, 0);
            this.dataMSStore.MinimumSize = new System.Drawing.Size(20, 20);
            this.dataMSStore.Name = "dataMSStore";
            this.dataMSStore.Size = new System.Drawing.Size(1256, 656);
            this.dataMSStore.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 656);
            this.Controls.Add(this.dataMSStore);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser dataMSStore;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}