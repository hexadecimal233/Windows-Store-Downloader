
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
            this.downloadButton = new System.Windows.Forms.Button();
            this.routeText = new System.Windows.Forms.Label();
            this.routeBox = new System.Windows.Forms.ComboBox();
            this.typeText = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.downloadButton.Location = new System.Drawing.Point(351, 393);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(336, 101);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            // 
            // routeText
            // 
            this.routeText.AutoSize = true;
            this.routeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routeText.Location = new System.Drawing.Point(832, 29);
            this.routeText.Name = "routeText";
            this.routeText.Size = new System.Drawing.Size(225, 32);
            this.routeText.TabIndex = 1;
            this.routeText.Text = "Download Route";
            // 
            // routeBox
            // 
            this.routeBox.FormattingEnabled = true;
            this.routeBox.Items.AddRange(new object[] {
            "Fast",
            "Slow",
            "RP",
            "Retail"});
            this.routeBox.Location = new System.Drawing.Point(838, 92);
            this.routeBox.Name = "routeBox";
            this.routeBox.Size = new System.Drawing.Size(219, 29);
            this.routeBox.TabIndex = 2;
            // 
            // typeText
            // 
            this.typeText.AutoSize = true;
            this.typeText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.typeText.Location = new System.Drawing.Point(26, 29);
            this.typeText.Name = "typeText";
            this.typeText.Size = new System.Drawing.Size(212, 32);
            this.typeText.TabIndex = 3;
            this.typeText.Text = "Download Type";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Url(Link)",
            "ProductID",
            "PackageFamilyName",
            "CategoryID"});
            this.typeBox.Location = new System.Drawing.Point(32, 92);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(219, 29);
            this.typeBox.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 546);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.typeText);
            this.Controls.Add(this.routeBox);
            this.Controls.Add(this.routeText);
            this.Controls.Add(this.downloadButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label routeText;
        private System.Windows.Forms.ComboBox routeBox;
        private System.Windows.Forms.Label typeText;
        private System.Windows.Forms.ComboBox typeBox;
    }
}

