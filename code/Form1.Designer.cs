
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
            this.progressText = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.CloseButton = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.downloadButton = new System.Windows.Forms.Label();
            this.MinimizeButton = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // routeText
            // 
            this.routeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.typeLinkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLinkText.Location = new System.Drawing.Point(19, 28);
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
            this.attributeText.Text = "Input here...";
            this.attributeText.Enter += new System.EventHandler(this.AttributeInputReady);
            this.attributeText.Leave += new System.EventHandler(this.AttributeInputDeselect);
            // 
            // langPackText
            // 
            this.langPackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 525);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Language/语言";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.langText);
            this.groupBox1.Controls.Add(this.langPackText);
            this.groupBox1.Controls.Add(this.attributeText);
            this.groupBox1.Controls.Add(this.typeBox);
            this.groupBox1.Controls.Add(this.typeLinkText);
            this.groupBox1.Controls.Add(this.routeBox);
            this.groupBox1.Controls.Add(this.routeText);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.142858F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 307);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::Windows_Store_Downloader.Properties.Resources.store;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(824, 437);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(273, 176);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // progressText
            // 
            this.progressText.BackColor = System.Drawing.Color.Transparent;
            this.progressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressText.Location = new System.Drawing.Point(11, 378);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(158, 74);
            this.progressText.TabIndex = 12;
            this.progressText.Text = "Query Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.DarkGreen;
            this.progressBar1.Location = new System.Drawing.Point(164, 381);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(910, 38);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 13;
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.CloseButton.ForeColor = System.Drawing.Color.Ivory;
            this.CloseButton.Location = new System.Drawing.Point(1032, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(65, 44);
            this.CloseButton.TabIndex = 15;
            this.CloseButton.Text = "r";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            this.CloseButton.MouseEnter += new System.EventHandler(this.CloseButton_MouseHover);
            this.CloseButton.MouseLeave += new System.EventHandler(this.CloseButton_MouseLeave);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Consolas", 10.71429F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(48, 15);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(378, 31);
            this.title.TabIndex = 16;
            this.title.Text = "Microsoft Store Downloader";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::Windows_Store_Downloader.Properties.Resources.icon;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(6, 10);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 36);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.14286F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(-12, -14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1148, 79);
            this.label2.TabIndex = 18;
            this.label2.Text = "\r\n_______________________________________________________________________________" +
    "__________________";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.label2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label2_MouseDown);
            // 
            // downloadButton
            // 
            this.downloadButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(81)))), ((int)(((byte)(181)))));
            this.downloadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.downloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadButton.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.downloadButton.Location = new System.Drawing.Point(381, 485);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(343, 98);
            this.downloadButton.TabIndex = 19;
            this.downloadButton.Text = "Download";
            this.downloadButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.downloadButton.MouseEnter += new System.EventHandler(this.downloadButton_MouseEnter);
            this.downloadButton.MouseLeave += new System.EventHandler(this.downloadButton_MouseLeave);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.BackColor = System.Drawing.Color.Transparent;
            this.MinimizeButton.Font = new System.Drawing.Font("Webdings", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.MinimizeButton.ForeColor = System.Drawing.Color.Ivory;
            this.MinimizeButton.Location = new System.Drawing.Point(973, 9);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(65, 44);
            this.MinimizeButton.TabIndex = 20;
            this.MinimizeButton.Text = "0";
            this.MinimizeButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.MinimizeButton.MouseEnter += new System.EventHandler(this.label3_MouseEnter);
            this.MinimizeButton.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(241)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1109, 625);
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.title);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.langBox);
            this.Controls.Add(this.label2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Microsoft Store Downloader";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.Label progressText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label CloseButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label downloadButton;
        private System.Windows.Forms.Label MinimizeButton;
    }
}

