
namespace Windows_Store_Downloader
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.downloadButton = new System.Windows.Forms.Button();
            this.routeText = new System.Windows.Forms.Label();
            this.routeBox = new System.Windows.Forms.ComboBox();
            this.typeLinkText = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.attributeText = new System.Windows.Forms.TextBox();
            this.langPackText = new System.Windows.Forms.Label();
            this.langText = new System.Windows.Forms.TextBox();
            this.langBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressText = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.downloadButton.Location = new System.Drawing.Point(420, 458);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(336, 115);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseMnemonic = false;
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // routeText
            // 
            this.routeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeText.Location = new System.Drawing.Point(801, 31);
            this.routeText.Name = "routeText";
            this.routeText.Size = new System.Drawing.Size(238, 77);
            this.routeText.TabIndex = 1;
            this.routeText.Text = "Download Route";
            this.routeText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // routeBox
            // 
            this.routeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.routeBox.FormattingEnabled = true;
            this.routeBox.Items.AddRange(new object[] {
            "Fast",
            "Slow",
            "RP",
            "Retail"});
            this.routeBox.Location = new System.Drawing.Point(807, 111);
            this.routeBox.Name = "routeBox";
            this.routeBox.Size = new System.Drawing.Size(219, 32);
            this.routeBox.TabIndex = 2;
            // 
            // typeLinkText
            // 
            this.typeLinkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.typeLinkText.Location = new System.Drawing.Point(19, 27);
            this.typeLinkText.Name = "typeLinkText";
            this.typeLinkText.Size = new System.Drawing.Size(294, 80);
            this.typeLinkText.TabIndex = 3;
            this.typeLinkText.Text = "Download Link Type";
            this.typeLinkText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Url(Link)",
            "ProductID",
            "PackageFamilyName",
            "CategoryID"});
            this.typeBox.Location = new System.Drawing.Point(57, 111);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(239, 32);
            this.typeBox.TabIndex = 4;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.RefreshText);
            // 
            // attributeText
            // 
            this.attributeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.attributeText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.attributeText.Location = new System.Drawing.Point(57, 197);
            this.attributeText.Name = "attributeText";
            this.attributeText.Size = new System.Drawing.Size(969, 29);
            this.attributeText.TabIndex = 5;
            this.attributeText.Enter += new System.EventHandler(this.AttributeInputReady);
            this.attributeText.Leave += new System.EventHandler(this.AttributeInputDeselect);
            // 
            // langPackText
            // 
            this.langPackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langPackText.Location = new System.Drawing.Point(302, 31);
            this.langPackText.Name = "langPackText";
            this.langPackText.Size = new System.Drawing.Size(477, 77);
            this.langPackText.TabIndex = 6;
            this.langPackText.Text = "Language(Example:zh-CN)";
            this.langPackText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // langText
            // 
            this.langText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.langText.Location = new System.Drawing.Point(446, 111);
            this.langText.Name = "langText";
            this.langText.Size = new System.Drawing.Size(219, 29);
            this.langText.TabIndex = 7;
            // 
            // langBox
            // 
            this.langBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.langBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.langBox.FormattingEnabled = true;
            this.langBox.Items.AddRange(new object[] {
            "English",
            "中文（简体）"});
            this.langBox.Location = new System.Drawing.Point(17, 557);
            this.langBox.Name = "langBox";
            this.langBox.Size = new System.Drawing.Size(146, 32);
            this.langBox.TabIndex = 8;
            this.langBox.SelectedIndexChanged += new System.EventHandler(this.ChangeLanguage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Language/语言";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.langText);
            this.groupBox1.Controls.Add(this.langPackText);
            this.groupBox1.Controls.Add(this.attributeText);
            this.groupBox1.Controls.Add(this.typeBox);
            this.groupBox1.Controls.Add(this.typeLinkText);
            this.groupBox1.Controls.Add(this.routeBox);
            this.groupBox1.Controls.Add(this.routeText);
            this.groupBox1.Location = new System.Drawing.Point(17, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 307);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Windows_Store_Downloader.Properties.Resources.store;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(775, 396);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 193);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(145, 334);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(919, 38);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 11;
            // 
            // progressText
            // 
            this.progressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressText.Location = new System.Drawing.Point(11, 329);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(128, 74);
            this.progressText.TabIndex = 12;
            this.progressText.Text = "Query Progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 618);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.langBox);
            this.Controls.Add(this.downloadButton);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Microsoft Store Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label routeText;
        private System.Windows.Forms.Label typeLinkText;
        private System.Windows.Forms.Label langPackText;
        public System.Windows.Forms.ComboBox routeBox;
        public System.Windows.Forms.ComboBox typeBox;
        public System.Windows.Forms.TextBox attributeText;
        public System.Windows.Forms.TextBox langText;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox langBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

