using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tools.Database;
using System.Threading;

namespace NewMethod.Original.Controls
{
    public partial class nTables : UserControl
    {
        public DataConnectionSqlServer xData;
        int sortColumn = -1;
        public nTables()
        {
            InitializeComponent();
            ShowCheckedTotals();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            lv.Items.Clear();
            throb.ShowThrobber();
            bg.RunWorkerAsync();
        }

        DataTable result;
        List<nTableHandle> Tables;
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            Tables = new List<nTableHandle>();
            result = xData.Select("select name, crdate from sysobjects where type = 'U' order by name");
            foreach (DataRow r in result.Rows)
            {
                nTableHandle h = new nTableHandle();
                h.TableName = nData.NullFilter(r["name"]);
                h.DateCreated = nData.NullFilter_Date(r["crdate"]);
                DataTable sp = xData.Select("EXEC sp_spaceused '" + h.TableName + "'");

                DataRow r1 = sp.Rows[0];

                h.Rows = nData.NullFilter_Int64(r1["rows"]);
                h.DataKB = Int64.Parse(nData.NullFilter(r1["data"]).Replace(" KB", ""));
                h.IndexKB = Int64.Parse(nData.NullFilter(r1["index_size"]).Replace(" KB", ""));

                Tables.Add(h);
            }
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowResult();
            throb.HideThrobber();
        }

        void ShowResult()
        {
            lv.BeginUpdate();
            try
            {
                foreach (nTableHandle h in Tables)
                {
                    ListViewItem i = lv.Items.Add(h.TableName);
                    i.SubItems.Add(nTools.DateFormat(h.DateCreated));
                    i.SubItems.Add(Tools.Number.LongFormat(h.DataKB));
                    i.SubItems.Add(Tools.Number.LongFormat(h.IndexKB));
                    i.SubItems.Add(Tools.Number.LongFormat(h.Rows));

                    i.Tag = h;
                }
            }
            catch { }
            lv.EndUpdate();

            ShowCheckedTotals();
        }

        private void cmdCheckWith_Click(object sender, EventArgs e)
        {
            String s = txtStart.Text;
            if (!Tools.Strings.StrExt(s))
                return;

            lv.BeginUpdate();
            try
            {
                foreach (ListViewItem i in lv.Items)
                {
                    i.Checked = nTools.StartsWith(i.Text, s);
                }
            }
            catch { }

            lv.EndUpdate();
            ShowCheckedTotals();
        }

        void ShowCheckedTotals()
        {
            lblCount.Text = Tools.Number.LongFormat(lv.Items.Count) + " Tables / " + Tools.Number.LongFormat(lv.CheckedItems.Count) + " Checked";
            if (lv.CheckedItems.Count > 0)
            {
                lblDeleteChecked.Enabled = true;
                lblDeleteChecked.Text = "Delete " + Tools.Number.LongFormat(lv.CheckedItems.Count) + " Tables";
            }
            else
            {
                lblDeleteChecked.Enabled = false;
                lblDeleteChecked.Text = "<delete>";
            }
        }

        private void nTables_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height;

                lv.Top = 0;
                lv.Left = gb.Right;
                lv.Height = this.ClientRectangle.Height;
                lv.Width = this.ClientRectangle.Width - lv.Left;
            }
            catch { }
        }

        private void lblDeleteChecked_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ListViewItem i in lv.CheckedItems)
            {
                sb.AppendLine(i.Text);
            }

            Tools.FileSystem.PopText(sb.ToString());

            if (!NMWin.Leader.AreYouSure("permanently delete these " + Tools.Number.LongFormat(lv.CheckedItems.Count) + " tables from " + xData.TheKey.ServerName + "." + xData.TheKey.DatabaseName))
                return;

            NMWin.Leader.StartPopStatus("Deleting...");

            foreach (ListViewItem i in lv.CheckedItems)
            {
                String strTable = i.Text;
                NMWin.Leader.Comment("Dropping " + strTable);
                xData.DropTable(strTable);
            }

            NMWin.Leader.Comment("Done.");
            NMWin.Leader.StopPopStatus(true);
        }

        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lv.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lv.Sorting == SortOrder.Ascending)
                    lv.Sorting = SortOrder.Descending;
                else
                    lv.Sorting = SortOrder.Ascending;
            }

            int intType = (Int32)FieldType.String;

            try
            {
                ColumnHeader col = lv.Columns[e.Column];
                if (col != null)
                {
                    if (col.TextAlign == HorizontalAlignment.Right)
                        intType = (Int32)FieldType.Double;
                    else if (col.TextAlign == HorizontalAlignment.Center)
                        intType = (Int32)FieldType.DateTime;
                }
            }
            catch (Exception)
            { }

            lv.ListViewItemSorter = new NewMethod.ListViewItemComparer(e.Column, lv.Sorting, intType);
            lv.Sort();
        }

        private void cmdCheckZeroRows_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in lv.Items)
            {
                nTableHandle h = (nTableHandle)i.Tag;
                i.Checked = h.Rows == 0;
            }
            ShowCheckedTotals();
        }
    }

    class nTableHandle
    {
        public String TableName = "";
        public DateTime DateCreated;
        public long Rows;
        public long DataKB;
        public long IndexKB;
    }
}
