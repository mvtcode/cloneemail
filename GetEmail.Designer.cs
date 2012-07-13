namespace Clone
{
    partial class GetEmail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetEmail));
            this.TB_Address = new System.Windows.Forms.TextBox();
            this.LB_Link = new System.Windows.Forms.Label();
            this.BT_Go = new System.Windows.Forms.Button();
            this.List_Email = new System.Windows.Forms.ListBox();
            this.LB_Email = new System.Windows.Forms.Label();
            this.List_Link = new System.Windows.Forms.ListBox();
            this.LB_GetLink = new System.Windows.Forms.Label();
            this.Pic_Loading = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LB_Curent = new System.Windows.Forms.Label();
            this.LB_TotalEmail = new System.Windows.Forms.Label();
            this.BT_Exit = new System.Windows.Forms.Button();
            this.BT_Stop = new System.Windows.Forms.Button();
            this.BT_ExportEmail = new System.Windows.Forms.Button();
            this.BT_ExportLink = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Loading)).BeginInit();
            this.SuspendLayout();
            // 
            // TB_Address
            // 
            this.TB_Address.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Address.Location = new System.Drawing.Point(49, 12);
            this.TB_Address.Name = "TB_Address";
            this.TB_Address.Size = new System.Drawing.Size(410, 20);
            this.TB_Address.TabIndex = 0;
            this.TB_Address.Text = "http://vieclam.24h.com.vn/nha-tuyen-dung/it-phan-mem-c74.html";
            this.TB_Address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TB_Address_KeyDown);
            // 
            // LB_Link
            // 
            this.LB_Link.AutoSize = true;
            this.LB_Link.Location = new System.Drawing.Point(13, 16);
            this.LB_Link.Name = "LB_Link";
            this.LB_Link.Size = new System.Drawing.Size(30, 13);
            this.LB_Link.TabIndex = 1;
            this.LB_Link.Text = "Link:";
            // 
            // BT_Go
            // 
            this.BT_Go.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Go.Location = new System.Drawing.Point(475, 11);
            this.BT_Go.Name = "BT_Go";
            this.BT_Go.Size = new System.Drawing.Size(44, 23);
            this.BT_Go.TabIndex = 1;
            this.BT_Go.Text = "Go";
            this.BT_Go.UseVisualStyleBackColor = true;
            this.BT_Go.Click += new System.EventHandler(this.BT_Go_Click);
            // 
            // List_Email
            // 
            this.List_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_Email.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.List_Email.FormattingEnabled = true;
            this.List_Email.ItemHeight = 14;
            this.List_Email.Location = new System.Drawing.Point(16, 323);
            this.List_Email.Name = "List_Email";
            this.List_Email.Size = new System.Drawing.Size(545, 242);
            this.List_Email.TabIndex = 3;
            // 
            // LB_Email
            // 
            this.LB_Email.AutoSize = true;
            this.LB_Email.Location = new System.Drawing.Point(13, 307);
            this.LB_Email.Name = "LB_Email";
            this.LB_Email.Size = new System.Drawing.Size(69, 13);
            this.LB_Email.TabIndex = 6;
            this.LB_Email.Text = "Get All Email:";
            // 
            // List_Link
            // 
            this.List_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.List_Link.FormattingEnabled = true;
            this.List_Link.Location = new System.Drawing.Point(16, 65);
            this.List_Link.Name = "List_Link";
            this.List_Link.Size = new System.Drawing.Size(545, 238);
            this.List_Link.TabIndex = 2;
            // 
            // LB_GetLink
            // 
            this.LB_GetLink.AutoSize = true;
            this.LB_GetLink.Location = new System.Drawing.Point(13, 48);
            this.LB_GetLink.Name = "LB_GetLink";
            this.LB_GetLink.Size = new System.Drawing.Size(64, 13);
            this.LB_GetLink.TabIndex = 8;
            this.LB_GetLink.Text = "Get All Link:";
            // 
            // Pic_Loading
            // 
            this.Pic_Loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_Loading.Image = global::Clone.Properties.Resources.loading;
            this.Pic_Loading.Location = new System.Drawing.Point(527, 8);
            this.Pic_Loading.Name = "Pic_Loading";
            this.Pic_Loading.Size = new System.Drawing.Size(32, 32);
            this.Pic_Loading.TabIndex = 9;
            this.Pic_Loading.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LB_Curent
            // 
            this.LB_Curent.AutoSize = true;
            this.LB_Curent.Location = new System.Drawing.Point(83, 48);
            this.LB_Curent.Name = "LB_Curent";
            this.LB_Curent.Size = new System.Drawing.Size(0, 13);
            this.LB_Curent.TabIndex = 10;
            // 
            // LB_TotalEmail
            // 
            this.LB_TotalEmail.AutoSize = true;
            this.LB_TotalEmail.Location = new System.Drawing.Point(87, 307);
            this.LB_TotalEmail.Name = "LB_TotalEmail";
            this.LB_TotalEmail.Size = new System.Drawing.Size(0, 13);
            this.LB_TotalEmail.TabIndex = 11;
            // 
            // BT_Exit
            // 
            this.BT_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Exit.Location = new System.Drawing.Point(487, 585);
            this.BT_Exit.Name = "BT_Exit";
            this.BT_Exit.Size = new System.Drawing.Size(75, 23);
            this.BT_Exit.TabIndex = 7;
            this.BT_Exit.Text = "Exit";
            this.BT_Exit.UseVisualStyleBackColor = true;
            this.BT_Exit.Click += new System.EventHandler(this.TB_Exit_Click);
            // 
            // BT_Stop
            // 
            this.BT_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Stop.Enabled = false;
            this.BT_Stop.Location = new System.Drawing.Point(406, 585);
            this.BT_Stop.Name = "BT_Stop";
            this.BT_Stop.Size = new System.Drawing.Size(75, 23);
            this.BT_Stop.TabIndex = 4;
            this.BT_Stop.Text = "Pause";
            this.BT_Stop.UseVisualStyleBackColor = true;
            this.BT_Stop.Click += new System.EventHandler(this.TB_Stop_Click);
            // 
            // BT_ExportEmail
            // 
            this.BT_ExportEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_ExportEmail.Enabled = false;
            this.BT_ExportEmail.Location = new System.Drawing.Point(325, 585);
            this.BT_ExportEmail.Name = "BT_ExportEmail";
            this.BT_ExportEmail.Size = new System.Drawing.Size(75, 23);
            this.BT_ExportEmail.TabIndex = 6;
            this.BT_ExportEmail.Text = "Export Email";
            this.BT_ExportEmail.UseVisualStyleBackColor = true;
            this.BT_ExportEmail.Click += new System.EventHandler(this.BT_ExportEmail_Click);
            // 
            // BT_ExportLink
            // 
            this.BT_ExportLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_ExportLink.Enabled = false;
            this.BT_ExportLink.Location = new System.Drawing.Point(244, 585);
            this.BT_ExportLink.Name = "BT_ExportLink";
            this.BT_ExportLink.Size = new System.Drawing.Size(75, 23);
            this.BT_ExportLink.TabIndex = 5;
            this.BT_ExportLink.Text = "Export Link";
            this.BT_ExportLink.UseVisualStyleBackColor = true;
            this.BT_ExportLink.Click += new System.EventHandler(this.BT_ExportLink_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(16, 585);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Get HTML Page";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // GetEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 616);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BT_ExportLink);
            this.Controls.Add(this.BT_ExportEmail);
            this.Controls.Add(this.BT_Stop);
            this.Controls.Add(this.BT_Exit);
            this.Controls.Add(this.LB_TotalEmail);
            this.Controls.Add(this.LB_Curent);
            this.Controls.Add(this.Pic_Loading);
            this.Controls.Add(this.LB_GetLink);
            this.Controls.Add(this.List_Link);
            this.Controls.Add(this.LB_Email);
            this.Controls.Add(this.List_Email);
            this.Controls.Add(this.BT_Go);
            this.Controls.Add(this.LB_Link);
            this.Controls.Add(this.TB_Address);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GetEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MVT - Get Email";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Loading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Address;
        private System.Windows.Forms.Label LB_Link;
        private System.Windows.Forms.Button BT_Go;
        private System.Windows.Forms.ListBox List_Email;
        private System.Windows.Forms.Label LB_Email;
        private System.Windows.Forms.ListBox List_Link;
        private System.Windows.Forms.Label LB_GetLink;
        private System.Windows.Forms.PictureBox Pic_Loading;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LB_Curent;
        private System.Windows.Forms.Label LB_TotalEmail;
        private System.Windows.Forms.Button BT_Exit;
        private System.Windows.Forms.Button BT_Stop;
        private System.Windows.Forms.Button BT_ExportEmail;
        private System.Windows.Forms.Button BT_ExportLink;
        private System.Windows.Forms.Button button1;
    }
}

