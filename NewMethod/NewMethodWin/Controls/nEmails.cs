using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Tools.Database;

namespace NewMethod
{
    public partial class nEmails : UserControl
    {
        public nEmails()
        {
            InitializeComponent();
        }

        private void lblLoadFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            wb.ReloadWB();
            ClearList();
        }

        void ClearList()
        {
            lv.Items.Clear();
            lv.BeginUpdate();
            try
            {
                String strFile = ToolsWin.FileSystem.ChooseAFile();
                if (!File.Exists(strFile))
                    return;

                String[] ary = Tools.Strings.SplitLines(Tools.Files.OpenFileAsString(strFile));
                foreach(String s in ary)
                {
                    String email = Tools.Strings.ParseDelimit(s, ",", 1).Replace("\"", "").Trim().ToLower();

                    if (nTools.IsEmailAddress(email))
                    {
                        EmailHandle h = new EmailHandle(email);

                        ListViewItem i = lv.Items.Add(h.Email);
                        i.SubItems.Add(h.Domain);
                        i.SubItems.Add(h.Suffix);
                        i.Tag = h;
                    }
                }
            }
            catch (Exception ex)
            {
                NMWin.Leader.Tell("Error: " + ex.Message);
            }
            lv.EndUpdate();
            lv.Sort();
        }

        private void nEmails_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                sp.Left = 0;
                sp.Top = 0;
                sp.Height = this.ClientRectangle.Height;
                sp.Width = this.ClientRectangle.Width;

                gbOptions.Top = 0;
                gbOptions.Left = 0;
                gbOptions.Width = sp.Panel1.ClientRectangle.Width;

                lv.Top = gbOptions.Bottom;
                lv.Left = 0;
                lv.Width = sp.Panel1.ClientRectangle.Width;
                lv.Height = sp.Panel1.ClientRectangle.Height - gbOptions.Height;

                wb.Left = 0;
                wb.Top = 0;
                wb.Width = sp.Panel2.ClientRectangle.Width;
                wb.Height = sp.Panel2.ClientRectangle.Height;
            }
            catch { }
        }

        private void lv_Click(object sender, EventArgs e)
        {
            try
            {
                EmailHandle h = (EmailHandle)lv.SelectedItems[0].Tag;
                wb.Navigate("http://www." + h.Domain);
            }
            catch { }
        }

        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }

        int sortColumn = 0;
        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
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
            catch { }
        }
    }

    class EmailHandle
    {
        public String Email = "";
        public String Domain = "";
        public String Suffix = "";

        public EmailHandle(String email)
        {
            Email = email;
            Domain = nTools.ParseEmailDomain(Email);
            Suffix = nTools.ParseEmailSuffix(Email);
        }
    }
}
