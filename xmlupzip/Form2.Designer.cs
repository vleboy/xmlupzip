namespace xmlupzip
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
            this.chick2_bt = new System.Windows.Forms.Button();
            this.zip2_bt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chick2_bt
            // 
            this.chick2_bt.Location = new System.Drawing.Point(208, 84);
            this.chick2_bt.Name = "chick2_bt";
            this.chick2_bt.Size = new System.Drawing.Size(238, 23);
            this.chick2_bt.TabIndex = 0;
            this.chick2_bt.Text = "打开目录";
            this.chick2_bt.UseVisualStyleBackColor = true;
            this.chick2_bt.Click += new System.EventHandler(this.chick2_bt_Click);
            // 
            // zip2_bt
            // 
            this.zip2_bt.Location = new System.Drawing.Point(208, 200);
            this.zip2_bt.Name = "zip2_bt";
            this.zip2_bt.Size = new System.Drawing.Size(238, 23);
            this.zip2_bt.TabIndex = 1;
            this.zip2_bt.Text = "生成Zip";
            this.zip2_bt.UseVisualStyleBackColor = true;
            this.zip2_bt.Click += new System.EventHandler(this.zip2_bt_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 376);
            this.Controls.Add(this.zip2_bt);
            this.Controls.Add(this.chick2_bt);
            this.Name = "Form2";
            this.Text = "套系";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button chick2_bt;
        private System.Windows.Forms.Button zip2_bt;
    }
}