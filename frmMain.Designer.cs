namespace GoogleTranslateTool
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.comboFrom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboTo = new System.Windows.Forms.ComboBox();
            this.btnGoogleTranslate = new System.Windows.Forms.Button();
            this.btnPdfFormat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(12, 57);
            this.txtFrom.Multiline = true;
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFrom.Size = new System.Drawing.Size(400, 477);
            this.txtFrom.TabIndex = 0;
            this.txtFrom.Text = resources.GetString("txtFrom.Text");
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(420, 57);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTo.Size = new System.Drawing.Size(400, 477);
            this.txtTo.TabIndex = 1;
            // 
            // comboFrom
            // 
            this.comboFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFrom.FormattingEnabled = true;
            this.comboFrom.Location = new System.Drawing.Point(12, 22);
            this.comboFrom.Name = "comboFrom";
            this.comboFrom.Size = new System.Drawing.Size(121, 20);
            this.comboFrom.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 11F);
            this.label1.Location = new System.Drawing.Point(139, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "->";
            // 
            // comboTo
            // 
            this.comboTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTo.FormattingEnabled = true;
            this.comboTo.Location = new System.Drawing.Point(169, 21);
            this.comboTo.Name = "comboTo";
            this.comboTo.Size = new System.Drawing.Size(121, 20);
            this.comboTo.TabIndex = 4;
            // 
            // btnGoogleTranslate
            // 
            this.btnGoogleTranslate.Location = new System.Drawing.Point(296, 20);
            this.btnGoogleTranslate.Name = "btnGoogleTranslate";
            this.btnGoogleTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnGoogleTranslate.TabIndex = 5;
            this.btnGoogleTranslate.Text = "翻译";
            this.btnGoogleTranslate.UseVisualStyleBackColor = true;
            this.btnGoogleTranslate.Click += new System.EventHandler(this.btnGoogleTranslate_Click);
            // 
            // btnPdfFormat
            // 
            this.btnPdfFormat.Location = new System.Drawing.Point(377, 20);
            this.btnPdfFormat.Name = "btnPdfFormat";
            this.btnPdfFormat.Size = new System.Drawing.Size(109, 23);
            this.btnPdfFormat.TabIndex = 6;
            this.btnPdfFormat.Text = "PDF格式优化";
            this.btnPdfFormat.UseVisualStyleBackColor = true;
            this.btnPdfFormat.Click += new System.EventHandler(this.btnPdfFormat_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 546);
            this.Controls.Add(this.btnPdfFormat);
            this.Controls.Add(this.btnGoogleTranslate);
            this.Controls.Add(this.comboTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboFrom);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Name = "frmMain";
            this.Text = "谷歌翻译工具";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.ComboBox comboFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboTo;
        private System.Windows.Forms.Button btnGoogleTranslate;
        private System.Windows.Forms.Button btnPdfFormat;
    }
}

