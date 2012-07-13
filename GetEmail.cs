using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Net;
using Button = System.Windows.Forms.Button;
using ListBox = System.Windows.Forms.ListBox;

namespace Clone
{
    public partial class GetEmail : Form
    {
        public GetEmail()
        {
            InitializeComponent();
        }

        private int iIndex = 0;
        private Thread thrHTML;
        private Thread thrLink;
        private Thread thrEmail;
        private string sHostname = "";
        private string sCurentPage = "";
        private string sHTML = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            Pic_Loading.Visible = false;
            TB_Address.Focus();
        }

        private void BT_Go_Click(object sender, EventArgs e)
        {
            if (TB_Address.Text.Trim().Length <= 0) return;
            List_Email.Items.Clear();
            List_Link.Items.Clear();
            //TB_HTML.Text = "";
            iIndex = 0;
            string sAddress = TB_Address.Text;
            if (sAddress.ToLower().StartsWith("http://") == false && sAddress.ToLower().StartsWith("https://") == false) sAddress = "http://" + sAddress;

            if (HTMLultility.RemoteFileExists(sAddress) == false)
            {
                MessageBox.Show("Link không tồn tại", "MVT - Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TB_Address.Focus();
                return;
            }

            sHostname = HTMLultility.GetHotName(sAddress);
            Pic_Loading.Visible = true;
            List_Link.Items.Add(sAddress);
            List_Link.SelectedIndex = iIndex;

            thrHTML = new Thread(new ThreadStart(GetHTML));
            thrHTML.Start();

            timer1.Enabled = true;

            TB_Address.Enabled = false;
            BT_Go.Enabled = false;
            BT_Stop.Enabled = true;
            BT_ExportEmail.Enabled = false;
            BT_ExportLink.Enabled = false;
        }

        private void GetHTML()
        {
            RefreshLabelLink();
            RefreshLabelEmail();
            //SetTextBox("");
            sHTML = "";
            string sAddress = List_Link.Items[iIndex].ToString();
            sCurentPage =HTMLultility.GetCurentPage(sAddress);
            using (WebClient client = new WebClient())
            {
                try
                {
                    sHTML = client.DownloadString(sAddress);
                    //SetTextBox(sHTML);
                }
                catch (Exception ex)
                {
                    thrHTML.Abort();
                    if (HTMLultility.RemoteFileExists(sAddress) == false)
                    {
                        List_Link.Items.RemoveAt(iIndex);
                        if (iIndex > 0) iIndex--;
                    }
                    throw new Exception(ex.Message);
                }
            }

            thrLink = new Thread(new ThreadStart(SearchLink));
            thrLink.Start();
            thrEmail = new Thread(new ThreadStart(SearchEmail));
            thrEmail.Start();
        }

        private void SearchLink()
        {
            var oList = GetLink(sHTML);
            foreach (var oItem in oList)
            {
                string sLink = (string)oItem;
                sLink = GetFullLink(sLink);
                if (sLink != "")
                {
                    if (List_Link.Items.Contains(sLink) == false)
                    {
                        SetTextList(List_Link, sLink);
                        RefreshLabelLink();
                        //SetEnableBT(BT_ExportLink, true);
                    }
                }
            }
        }

        private void SearchEmail()
        {
            string[] arrList = cloneEmail(sHTML);
            if (arrList.Length > 0)
            {
                for (int i = 0; i < arrList.Length; i++)
                {
                    if (List_Email.Items.Contains(arrList[i].ToLower()) == false)
                    {
                        SetTextList(List_Email, arrList[i].ToLower());
                        RefreshLabelEmail();
                        //SetEnableBT(BT_ExportEmail, true);
                    }
                }
            }
        }

        private List<string> GetLink(string sContent)
        {
            List<string> oList = new List<string>();
            try
            {
                //Regex regexObj = new Regex("<a href[^>]*>(.*?)</a>", RegexOptions.IgnoreCase);
                Regex regexObj = new Regex("<a [^.]*href=[^>]*>", RegexOptions.IgnoreCase);
                Match matchResult = regexObj.Match(sContent);
                while (matchResult.Success)
                {
                    if (GetHREF(matchResult.Value) != "")
                        oList.Add(GetHREF(matchResult.Value));
                    matchResult = matchResult.NextMatch();
                }
                return oList;
            }
            catch (ArgumentException ex)
            {
                return null;
            }
        }

        private string GetHREF(string slink)
        {
            int n = slink.IndexOf("href=");
            if (n > 0)
            {
                int k = n + 6;
                char sC = slink[n + 5];
                if (sC != '"' && sC != '\'')
                {
                    sC = Convert.ToChar(0);
                }

                while (true)
                {
                    if (slink[k] == sC || slink[k] == '>')
                        break;
                    k++;
                }

                string sHREF = slink.Substring(n + 5, k - n - 4);
                if (sHREF.StartsWith("'") || sHREF.StartsWith("\""))
                {
                    sHREF = sHREF.Substring(1, sHREF.Length - 2);
                }
                return FilterLink(sHREF);
            }

            return "";
        }

        private string FilterLink(string sLink)
        {
            string[] aStart = { "#", "javascript:", "mailto:", "ymsgr:sendim?" };
            string[] aEnd = { ".jpg", ".gif", ".bmp", ".exe", ".msi", ".pdf", ".doc", ".docx", ".xls", "xlsx" };
            foreach (string s in aStart)
            {
                if (sLink.ToLower().StartsWith(s)) return "";
            }
            foreach (string s in aEnd)
            {
                if (sLink.ToLower().EndsWith(s)) return "";
            }

            if (sLink.EndsWith("?") || sLink.EndsWith("/")) sLink = sLink.Substring(0, sLink.Length - 1);

            return sLink;
        }

        private string[] cloneEmail(string sContent)
        {
            string[] emails = sContent.Split(new char[] { ' ', ';', ',', ':', '<', '>', '"', '\'' }, StringSplitOptions.RemoveEmptyEntries);
            return Array.FindAll<string>(emails, IsValidEmail);
        }
        
        private string GetFullLink(string sLink)
        {
            sLink = sLink.Trim();
            //if (sLink.EndsWith("?") || sLink.EndsWith("/")) sLink = sLink.Substring(0, sLink.Length - 1);
            int i = sLink.LastIndexOf("#");
            if (i > 0) sLink = sLink.Substring(0, i);

            if (sLink.StartsWith("/"))
            {
                sLink = sHostname + sLink;
            }
            else
            {
                if (sLink.ToLower().StartsWith("http://") == false && sLink.ToLower().StartsWith("https://") == false)
                {
                    sLink = sCurentPage + "/" + sLink;
                }
                else
                {
                    if (sLink.StartsWith(sHostname) == false) return "";
                }
            }
            return sLink;
        }
        
        private void SetEnableBT(Button obj, bool bEnable)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { SetEnableBT(obj, bEnable); });
                return;
            }
            if (obj.Enabled != bEnable)
                obj.Enabled = bEnable;
        }

        private void SetTextList(ListBox obj, String text)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { SetTextList(obj, text); });
                return;
            }
            obj.Items.Add(text);
        }

        private void RefreshLabelLink()
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { RefreshLabelLink(); });
                return;
            }

            LB_Curent.Text = (iIndex + 1).ToString() + "/" + List_Link.Items.Count.ToString();
        }

        private void RefreshLabelEmail()
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate() { RefreshLabelEmail(); });
                return;
            }

            LB_TotalEmail.Text = List_Email.Items.Count.ToString();
            List_Email.SelectedIndex = List_Email.Items.Count - 1;
        }

        public static bool IsValidEmail(string email)
        {
            string pattern =
                @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex re = new Regex(pattern);

            return re.IsMatch(email);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (thrEmail == null || thrLink == null || thrHTML == null) return;
            if (thrEmail.ThreadState == ThreadState.Stopped && thrHTML.ThreadState == ThreadState.Stopped && thrLink.ThreadState == ThreadState.Stopped)
            {
                if (iIndex < List_Link.Items.Count - 1)
                {
                    iIndex++;
                    List_Link.SelectedIndex = iIndex;
                    thrHTML = new Thread(new ThreadStart(GetHTML));
                    thrHTML.Start();

                }
                else
                {
                    timer1.Enabled = false;
                    StopThread();
                }
            }
        }

        private void TB_Exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "MVT Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (thrEmail != null) thrHTML.Abort();
                if (thrLink != null) thrLink.Abort();
                if (thrEmail != null) thrEmail.Abort();
                this.Close();
            }
        }

        private void TB_Stop_Click(object sender, EventArgs e)
        {
            Button BT = (Button)sender;
            if (BT.Text.ToLower() == "pause")
            {
                StopThread();
                BT.Text = "Continue";
            }
            else
            {
                if (iIndex < List_Link.Items.Count - 1)
                {
                    BT.Text = "Pause";
                    Pic_Loading.Visible = true;
                    BT_ExportEmail.Enabled = false;
                    BT_ExportLink.Enabled = false;
                    List_Link.SelectedIndex = iIndex;
                    timer1.Enabled = true;
                    thrHTML = new Thread(new ThreadStart(GetHTML));
                    thrHTML.Start();
                }
            }
        }

        private void StopThread()
        {
            if (thrHTML != null) thrHTML.Abort();
            if (thrLink != null) thrLink.Abort();
            if (thrEmail != null) thrEmail.Abort();
            Pic_Loading.Visible = false;
            if (iIndex >= List_Link.Items.Count - 1)
            {
                BT_Stop.Enabled = false;
            }
            BT_Go.Enabled = true;
            TB_Address.Enabled = true;
            if (List_Email.Items.Count > 0) BT_ExportEmail.Enabled = true;
            if (List_Link.Items.Count > 0) BT_ExportLink.Enabled = true;
            timer1.Enabled = false;
        }

        private void BT_ExportLink_Click(object sender, EventArgs e)
        {
            //ExportToExcel(List_Link);
            OpenWinExport("Export Link", List_Link);
        }

        private void BT_ExportEmail_Click(object sender, EventArgs e)
        {
            //ExportToExcel(List_Email);
            OpenWinExport("Export Email", List_Email);
        }

        private void OpenWinExport(string sCaption, ListBox oList)
        {
            Export NewWin = new Export(sCaption, oList);
            int iTop = (int)this.Top + (this.Height - NewWin.Height) / 2;
            int iLeft = (int)this.Left + (this.Width - NewWin.Width) / 2;
            NewWin.iTop = iTop;
            NewWin.iLeft = iLeft;
            NewWin.ShowDialog();
        }

        private void TB_Address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                BT_Go_Click(sender, e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetHTML NewWin = new GetHTML();
            NewWin.iTop= (int)this.Top + (this.Height - NewWin.Height) / 2;
            NewWin.iLeft = (int)this.Left + (this.Width - NewWin.Width) / 2;

            NewWin.ShowDialog();
        }
    }
}
