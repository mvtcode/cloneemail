namespace Clone
{
    partial class Export
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RD_Excel = new System.Windows.Forms.RadioButton();
            this.RD_Text = new System.Windows.Forms.RadioButton();
            this.BT_Export = new System.Windows.Forms.Button();
            this.BT_Close = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RD_Excel);
            this.groupBox1.Controls.Add(this.RD_Text);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Export to:";
            // 
            // RD_Excel
            // 
            this.RD_Excel.AutoSize = true;
            this.RD_Excel.Location = new System.Drawing.Point(30, 48);
            this.RD_Excel.Name = "RD_Excel";
            this.RD_Excel.Size = new System.Drawing.Size(67, 17);
            this.RD_Excel.TabIndex = 1;
            this.RD_Excel.TabStop = true;
            this.RD_Excel.Text = "To Excel";
            this.RD_Excel.UseVisualStyleBackColor = true;
            // 
            // RD_Text
            // 
            this.RD_Text.AutoSize = true;
            this.RD_Text.Checked = true;
            this.RD_Text.Location = new System.Drawing.Point(30, 25);
            this.RD_Text.Name = "RD_Text";
            this.RD_Text.Size = new System.Drawing.Size(62, 17);
            this.RD_Text.TabIndex = 0;
            this.RD_Text.TabStop = true;
            this.RD_Text.Text = "To Text";
            this.RD_Text.UseVisualStyleBackColor = true;
            // 
            // BT_Export
            // 
            this.BT_Export.Location = new System.Drawing.Point(56, 101);
            this.BT_Export.Name = "BT_Export";
            this.BT_Export.Size = new System.Drawing.Size(75, 23);
            this.BT_Export.TabIndex = 0;
            this.BT_Export.Text = "Export";
            this.BT_Export.UseVisualStyleBackColor = true;
            this.BT_Export.Click += new System.EventHandler(this.BT_Export_Click);
            // 
            // BT_Close
            // 
            this.BT_Close.Location = new System.Drawing.Point(158, 101);
            this.BT_Close.Name = "BT_Close";
            this.BT_Close.Size = new System.Drawing.Size(75, 23);
            this.BT_Close.TabIndex = 1;
            this.BT_Close.Text = "Close";
            this.BT_Close.UseVisualStyleBackColor = true;
            this.BT_Close.Click += new System.EventHandler(this.BT_Close_Click);
            // 
            // Export
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 136);
            this.Controls.Add(this.BT_Close);
            this.Controls.Add(this.BT_Export);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Export";
            this.Text = "Export";
            this.Load += new System.EventHandler(this.Export_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Export_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RD_Excel;
        private System.Windows.Forms.RadioButton RD_Text;
        private System.Windows.Forms.Button BT_Export;
        private System.Windows.Forms.Button BT_Close;
    }
}