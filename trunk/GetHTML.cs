using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Clone
{
    public partial class GetHTML : Form
    {
        public int iTop { get; set; }
        public int iLeft { get; set; }

        public GetHTML()
        {
            InitializeComponent();
        }

        private void BT_Go_Click(object sender, EventArgs e)
        {
            if (TB_Address.Text.Trim().Length <= 0) return;
            txtHTML.Text = "";
            string sAddress = TB_Address.Text;
            if (sAddress.ToLower().StartsWith("http://") == false && sAddress.ToLower().StartsWith("https://") == false) sAddress = "http://" + sAddress;

            if (HTMLultility.RemoteFileExists(sAddress) == false)
            {
                MessageBox.Show("Link không tồn tại", "MVT - Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TB_Address.Focus();
                return;
            }

            using (WebClient client = new WebClient())
            {
                try
                {
                    txtHTML.Text = client.DownloadString(sAddress);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private void BT_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog openFile = new SaveFileDialog();
            openFile.Filter = "Text File|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(openFile.FileName, false, Encoding.Unicode);
                try
                {
                    streamWriter.Write(txtHTML.Text.Trim());
                }
                catch (ApplicationException ex)
                {
                    throw new ApplicationException(ex.Message);
                }
                finally
                {
                    streamWriter.Dispose();
                }
            }
        }

        private void GetHTML_Load(object sender, EventArgs e)
        {
            this.Top = iTop;
            this.Left = iLeft;
            TB_Address.Focus();
        }

        private void TB_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                BT_Go_Click(sender, e);
            }
        }
    }
}
