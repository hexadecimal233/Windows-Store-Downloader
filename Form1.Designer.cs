
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.downloadButton.Location = new System.Drawing.Point(367, 401);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(336, 101);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseMnemonic = false;
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // routeText
            // 
            this.routeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeText.Location = new System.Drawing.Point(801, 27);
            this.routeText.Name = "routeText";
            this.routeText.Size = new System.Drawing.Size(238, 67);
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
            this.routeBox.Location = new System.Drawing.Point(807, 101);
            this.routeBox.Name = "routeBox";
            this.routeBox.Size = new System.Drawing.Size(219, 29);
            this.routeBox.TabIndex = 2;
            // 
            // typeLinkText
            // 
            this.typeLinkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.typeLinkText.Location = new System.Drawing.Point(10, 28);
            this.typeLinkText.Name = "typeLinkText";
            this.typeLinkText.Size = new System.Drawing.Size(286, 70);
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
            this.typeBox.Location = new System.Drawing.Point(57, 101);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(219, 29);
            this.typeBox.TabIndex = 4;
            // 
            // attributeText
            // 
            this.attributeText.ForeColor = System.Drawing.SystemColors.GrayText;
            this.attributeText.Location = new System.Drawing.Point(57, 172);
            this.attributeText.Name = "attributeText";
            this.attributeText.Size = new System.Drawing.Size(969, 31);
            this.attributeText.TabIndex = 5;
            this.attributeText.Text = "Input here...";
            this.attributeText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.attributeInputReady);
            this.attributeText.MouseUp += new System.Windows.Forms.MouseEventHandler(this.attributeInputDeselect);
            // 
            // langPackText
            // 
            this.langPackText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.langPackText.Location = new System.Drawing.Point(302, 27);
            this.langPackText.Name = "langPackText";
            this.langPackText.Size = new System.Drawing.Size(477, 67);
            this.langPackText.TabIndex = 6;
            this.langPackText.Text = "Package Language(Example:zh-CN)";
            this.langPackText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // langText
            // 
            this.langText.Location = new System.Drawing.Point(431, 101);
            this.langText.Name = "langText";
            this.langText.Size = new System.Drawing.Size(219, 31);
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
            this.langBox.Location = new System.Drawing.Point(12, 505);
            this.langBox.Name = "langBox";
            this.langBox.Size = new System.Drawing.Size(137, 29);
            this.langBox.TabIndex = 8;
            this.langBox.SelectedIndexChanged += new System.EventHandler(this.changeLanguage);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 477);
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
            this.groupBox1.Location = new System.Drawing.Point(17, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1062, 269);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Download";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 541);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.langBox);
            this.Controls.Add(this.downloadButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Microsoft Store Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

