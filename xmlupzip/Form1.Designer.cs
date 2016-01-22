namespace xmlupzip
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_chick1 = new System.Windows.Forms.Button();
            this.bt_chick2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_chick1
            // 
            this.bt_chick1.Location = new System.Drawing.Point(208, 84);
            this.bt_chick1.Name = "bt_chick1";
            this.bt_chick1.Size = new System.Drawing.Size(238, 23);
            this.bt_chick1.TabIndex = 0;
            this.bt_chick1.Text = "打开目录";
            this.bt_chick1.UseVisualStyleBackColor = true;
            this.bt_chick1.Click += new System.EventHandler(this.bt_chick1_Click);
            // 
            // bt_chick2
            // 
            this.bt_chick2.Location = new System.Drawing.Point(208, 200);
            this.bt_chick2.Name = "bt_chick2";
            this.bt_chick2.Size = new System.Drawing.Size(238, 23);
            this.bt_chick2.TabIndex = 1;
            this.bt_chick2.Text = "打包ZIP";
            this.bt_chick2.UseVisualStyleBackColor = true;
            this.bt_chick2.Click += new System.EventHandler(this.bt_chick2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 376);
            this.Controls.Add(this.bt_chick2);
            this.Controls.Add(this.bt_chick1);
            this.Name = "Form1";
            this.Text = "客片";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt_chick1;
        private System.Windows.Forms.Button bt_chick2;
    }
}

