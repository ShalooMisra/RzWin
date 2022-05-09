using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin
{
    public partial class TableScanner : UserControl
    {
        public TableScanner()
        {
            InitializeComponent();
        }

        private void cmdGo_Click(object sender, EventArgs e)
        {
            wb.Navigate(txtUrl.Text);
        }

        private void cmdList_Click(object sender, EventArgs e)
        {
            List<ToolsWin.TableHandle> tables = wb.TablesGet();
            lvTables.Items.Clear();
            foreach (ToolsWin.TableHandle h in tables)
            {
                ListViewItem i = lvTables.Items.Add(h.TextSample);
                i.SubItems.Add(h.Columns.ToString());
                i.SubItems.Add(h.Rows.ToString());
                i.Tag = h;
            }
        }

        private void lvTables_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                ListViewItem i = lvTables.SelectedItems[0];
                TableHandle h = (TableHandle)i.Tag;
                CurrentHandleSet(h);
            }
            catch { }
        }

        TableHandle CurrentHandle = null;
        void CurrentHandleSet(TableHandle h)
        {
            CurrentHandle = h;
            wbTable.ReloadWB();
            wbTable.Add(h.TheTable.outerHTML);
            txtCols.Text = h.Columns.ToString();
        }

        private void lblView_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ListFileShow();
        }

        void ListFileShow()
        {
            Tools.FileSystem.PopTextFile(ListFileGet());
        }

        String ListFileGet()
        {
            return @"c:\bilge\" + txtList.Text + ".csv";
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (CurrentHandle == null)
                return;

            SavePage(CurrentHandle);
        }

        bool SavePage(TableHandle h)
        {
            String s = Tools.Files.OpenFileAsString(ListFileGet());
            if (s != "")
                s += "\r\n";
            s += h.ConvertToCsv();
            Tools.Files.SaveFileAsString(ListFileGet(), s);
            return true;
        }

        private void cmdCycle_Click(object sender, EventArgs e)
        {
            while(SavePage())
            {
                if (!ClickNext())
                    return;

                wb.WaitForDone();
                System.Windows.Forms.Application.DoEvents();
                wb.WaitForDone();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                wb.WaitForDone();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
                System.Windows.Forms.Application.DoEvents();
            }

            ListFileShow();
            MessageBox.Show("Done");
        }

        bool SavePage()
        {
            int cols = Int32.Parse(txtCols.Text);
            List<TableHandle> tables = wb.TablesGet();
            foreach(TableHandle h in tables)
            {
                if (h.Columns == cols)
                {
                    return SavePage(h);
                }
            }
            return false;
        }

        bool ClickNext()
        {
            return wb.ClickElement("INPUT", "", txtNext.Text, "", "", false, "", ""); 
        }
    }
}
