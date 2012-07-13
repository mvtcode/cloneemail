using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ListBox = System.Windows.Forms.ListBox;
using System.IO;

namespace Clone
{
    public partial class Export : Form
    {
        public Export()
        {
            InitializeComponent();
        }

        private string sCaption;
        private ListBox oList;
        public int iTop { get; set; }
        public int iLeft { get; set; }

        public Export(string sCaption, ListBox oList)
        //public Export(string sCaption, ListBox oList)
        {
            this.sCaption = sCaption;
            this.oList = oList;
            InitializeComponent();
        }

        private void Export_Load(object sender, EventArgs e)
        {
            this.Top = iTop;
            this.Left = iLeft;
            this.Text = sCaption;
        }

        private void BT_Export_Click(object sender, EventArgs e)
        {
            if (RD_Excel.Checked)
            {
                ExportToExcel(oList);
                this.Close();
            }
            else
            {
                ExportToText(oList);
            }
        }

        private void ExportToText(ListBox obj)
        {
            SaveFileDialog openFile = new SaveFileDialog();
            openFile.Filter = "Text File|*.txt";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter streamWriter = new StreamWriter(openFile.FileName, false);
                try
                {
                    foreach (var oItem in oList.Items)
                    {
                        streamWriter.WriteLine(oItem.ToString());
                    }
                    this.Close();
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

        private void ExportToExcel(ListBox obj)
        {
            Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
            xla.Visible = true;
            Workbook wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)xla.ActiveSheet;
            int i = 1;
            try
            {
                foreach (var oItem in obj.Items)
                {
                    ws.Cells[i, 1] = oItem.ToString();
                    i++;
                }
            }
            catch (Exception)
            {
                throw;
            }

            //ws.SaveAs("d:\\test.xls");
            //xla.Quit();
        }

        private void BT_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Export_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyValue==27) this.Close();
        }
    }
}
