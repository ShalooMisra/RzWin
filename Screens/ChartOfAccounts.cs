using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using Tools.Database;

namespace RzInterfaceWin.Screens
{
    public partial class ChartOfAccounts : UserControl
    {
        public ChartOfAccounts()
        {
            InitializeComponent();
        }

        public void Init()
        {
            lv.Items.Clear();
            lv.Sorting = SortOrder.None;
            RzWin.Accounts.InitAccounts(RzWin.Context);
            Load(RzWin.Accounts.AllAccounts);
            DoResize();
        }

        void Load(AccountGroup group)
        {
            foreach (account a in group.Accounts)
            {
                Load(a, 0);
            }

            foreach(AccountGroup g in group.SubGroups)
            {
                Load(g);
            }
        }

        new void Load(account a, int offset)
        {
            if (a.name == "Net Income")
                return;
            if (a.is_hidden)
                return;

            String offsetString = "";
            for (int ix = 0; ix < offset; ix++)
            {
                offsetString += " - ";
            }

            ListViewItem i = lv.Items.Add(offsetString + a.name);
            i.SubItems.Add(a.FormattedNumber);
            i.SubItems.Add(a.type);

            //only show balances for balance sheet accounts
            switch (a.Category)
            {
                case AccountCategory.Asset:
                case AccountCategory.Liability:
                case AccountCategory.Equity:
                    //i.BackColor = Color.FromArgb(221, 255, 228);
                    i.SubItems.Add(Tools.Number.MoneyFormat(a.balance));

                    //if (a.balance != 0)
                    //    i.Font = new Font(i.Font, FontStyle.Bold);

                    break;
                default:
                    //i.BackColor = Color.FromArgb(221, 231, 255);
                    i.SubItems.Add("");
                    break;
            }
            i.Tag = a;

            i.ImageKey = a.Category.ToString();

            //if (offset == 0)
            //{
            //    i.ForeColor = Color.Black;
            //}
            //else
            //{
            //    i.ForeColor = Color.DarkGray;
            //}

            foreach (account sub in a.SubAccountsList(RzWin.Context))
            {
                Load(sub, offset + 1);
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void ChartOfAccounts_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                top.Top = 0;
                top.Left = 0;
                top.Width = this.ClientRectangle.Width;

                pSearch.Left = top.ClientRectangle.Width - pSearch.Width;

                lv.Left = 0;
                lv.Top = top.Bottom;
                lv.Width = this.ClientRectangle.Width;
                lv.Height = this.ClientRectangle.Height - lv.Top;
            }
            catch { }
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                account a = (account)lv.SelectedItems[0].Tag;
                if (a.Type == AccountType.Bank)
                    a.ShowCheckRegister(RzWin.Context);
                else
                    a.ShowAccountReport(RzWin.Context);
            }
            catch { }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            account a = account.CreateNewAccount(RzWin.Context);
            if (a == null)
                return;
            RzWin.Context.Show(a);
        }

        private void addASubAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            account a = SelectedAccount;
            if (a == null)
                return;
            account sub = account.CreateNewAccount(RzWin.Context, a.unique_id);
            if (sub == null)
                return;
            RzWin.Context.Show(a);
        }

        account SelectedAccount
        {
            get
            {
                try
                {
                    return (account)lv.SelectedItems[0].Tag;
                }
                catch { return null; }
            }
        }

        private void mnu_Opening(object sender, CancelEventArgs e)
        {
            account selected = SelectedAccount;
            if (selected == null)
            {
                e.Cancel = true;
                return;
            }

            accountReportMenu.Text = "Report on " + selected.full_name;
            editAccountMenu.Text = "Edit " + selected.full_name;
            deleteAccountMenu.Text = "Delete " + selected.full_name;
        }

        private void accountReportMenu_Click(object sender, EventArgs e)
        {
            account sel = SelectedAccount;
            if (sel == null)
                return;

            sel.ShowAccountReport(RzWin.Context);
        }

        private void editAccountMenu_Click(object sender, EventArgs e)
        {
            account sel = SelectedAccount;
            if (sel == null)
                return;

            RzWin.Context.Show(sel);
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Strings.StrExt(searchBox.Text))
            {
                List<ListViewItem> items = SearchForAccounts(searchBox.Text);
                ClearSelection();

                if (items.Count > 0)
                {
                    bool first = true;
                    foreach (ListViewItem i in items)
                    {
                        i.Selected = true;
                        if (first)
                        {
                            i.EnsureVisible();
                            first = false;
                        }
                    }
                }
            }
            else
            {
                ClearSelection();
            }
        }

        void ClearSelection()
        {
            bool first = true;
            foreach (ListViewItem i in lv.Items)
            {
                i.Selected = false;
                if (first)
                {
                    i.EnsureVisible();
                    first = false;
                }
            }
        }

        List<ListViewItem> SearchForAccounts(String textToFind)
        {
            List<ListViewItem> ret = new List<ListViewItem>();
            foreach (ListViewItem i in lv.Items)
            {
                account a = (account)i.Tag;

                if (textToFind.Length > 3)
                {
                    if (Tools.Strings.HasString(a.name, textToFind))
                        ret.Add(i);
                }
                else
                {
                    if (Tools.Strings.StartsWith(a.name, textToFind))
                        ret.Add(i);
                }
            }
            return ret;
        }

        int sortColumn = 0;
        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lv.SuspendLayout();
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
            lv.ResumeLayout();
            lv.Refresh();
        }

        private void deleteAccountMenu_Click(object sender, EventArgs e)
        {
            account a = SelectedAccount;
            if (a == null)
                return;

            String reason = "";
            if (!a.DeletePossible(RzWin.Context, ref reason))
                RzWin.Leader.Tell("Cannot delete: " + reason);
            else
            {
                if (!RzWin.Leader.AreYouSure("delete " + a.full_name))
                    return;

                a.Delete(RzWin.Context);
                Init();
            }
        }
    }
}
