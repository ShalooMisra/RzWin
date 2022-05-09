using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin.Screens
{
    public partial class JournalEntry : UserControl
    {
        public JournalEntry()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            lv.Items.Clear();
            for (int i = 0; i < 20; i++)
            {
                ListViewItem x = lv.Items.Add("");
                x.SubItems.Add("");
                x.SubItems.Add("");
            }

            accountSelection.Items.Clear();
            accountSelection.Items.Add("");

            foreach (account a in RzWin.Context.TheSysRz.TheAccountLogic.GetAccounts(RzWin.Context, new AccountCriteria()))
            {
                accountSelection.Items.Add(account.GetAccountFullNameWithBullet(a));
            }
            //foreach (String s in RzWin.Context.SelectScalarArray("select full_name from account where isnull(is_hidden, 0) = 0 order by number, full_name"))
            //{
            //    accountSelection.Items.Add(s);
            //}

            entryDate.SetValue(DateTime.Now);
            memo.SetValue("");
            PostCheck();
        }

        private void JournalEntry_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            top.Top = 0;
            top.Left = 0;
            top.Width = this.ClientRectangle.Width;

            lv.Left = 0;
            lv.Top = top.Bottom;
            lv.Width = this.ClientRectangle.Width;
            lv.Height = this.ClientRectangle.Height - lv.Top;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                EditJournal(lv.SelectedItems[0]);
            }
            catch { }
        }

        ListViewItem ShownItem;
        journal ShownJournal;
        void EditJournal(ListViewItem i)
        {
            if (i.Tag == null)
            {
                journal jx = journal.New(RzWin.Context);
                jx.unique_id = "none";
                i.Tag = jx;
            }

            journal j = (journal)i.Tag;

            ShownItem = i;
            ShownJournal = j;

            if (j.Account != null)
                accountSelection.Text = j.Account.full_name;
            else
                accountSelection.Text = "";

            debitEntry.Text = Tools.Number.MoneyFormat(j.debit_amount);
            creditEntry.Text = Tools.Number.MoneyFormat(j.credit_amount);

            edit.Visible = true;
            edit.Left = lv.Left + ((lv.ClientRectangle.Width / 2) - (edit.ClientRectangle.Width / 2) );
            edit.Top = lv.Top + ((lv.ClientRectangle.Height / 2) - (edit.ClientRectangle.Height / 2) );

            i.EnsureVisible();
            i.Selected = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(accountSelection.Text))
            {
                ShownItem.Tag = null;
                edit.Visible = false;
                ShownItem = null;
                ShownJournal = null;
                PostCheck();
            }
            else
                SaveJournal();
        }

        void SaveJournal()
        {
            ShownJournal.Account = RzWin.Accounts.GetAccount(RzWin.Context, account.GetAccountFullNameStripBullet(accountSelection.Text));
            ShownJournal.debit_amount = Double.Parse(debitEntry.Text);
            ShownJournal.credit_amount = Double.Parse(creditEntry.Text);
            
            edit.Visible = false;

            RefreshJournal();

            PostCheck();
        }

        void RefreshJournal()
        {
            ShownItem.Text = ShownJournal.Account.full_name;
            ShownItem.SubItems[1].Text = Tools.Number.MoneyFormat(ShownJournal.debit_amount);
            ShownItem.SubItems[2].Text = Tools.Number.MoneyFormat(ShownJournal.credit_amount);
        }

        private void debitEntry_TextChanged(object sender, EventArgs e)
        {
            EditCheck();
        }

        private void creditEntry_TextChanged(object sender, EventArgs e)
        {
            EditCheck();
        }

        void EditCheck()
        {
            okButton.Enabled = false;

            if (!Tools.Number.IsNumeric(debitEntry.Text))
                return;

            if (!Tools.Number.IsNumeric(creditEntry.Text))
                return;

            okButton.Enabled = true;            
        }

        void PostCheck()
        {
            saveButton.Enabled = false;

            if (!Tools.Dates.DateExists(entryDate.GetValue_Date()))
            {
                Warning("Please enter a date for this transaction");
                return;
            }

            if (!Tools.Strings.StrExt(memo.GetValue_String()))
            {
                Warning("Please enter a memo for this transaction");
                return;
            }

            Rz5.JournalEntry je = BuildJournalEntry();

            if (je.Total == 0)
            {
                Warning("Please enter at least two entries");
                return;
            }
            
            if (!je.Balances)
            {
                Warning("This entry does not balance yet");
                return;
            }

            warningLabel.Visible = false;
            saveButton.Enabled = true;
        }

        Rz5.JournalEntry BuildJournalEntry()
        {
            Rz5.JournalEntry ret = new Rz5.JournalEntry(memo.GetValue_String());
            foreach (ListViewItem i in lv.Items)
            {
                if (i.Tag == null)
                    continue;

                journal j = (journal)i.Tag;
                ret.Add(RzWin.Context, j.Account, j.debit_amount, j.credit_amount);
            }
            return ret;
        }

        void Warning(String warning)
        {
            warningLabel.Text = warning;
            warningLabel.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!RzWin.Leader.AreYouSure("post this transaction"))
                return;

            try
            {
                BuildJournalEntry().Post(RzWin.Context, entryDate.GetValue_Date());
                RzWin.Leader.Tell("Post complete.");
                Init();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex);
            }
        }

        private void memo_DataChanged(Tools.GenericEvent e)
        {
            PostCheck();
        }

        private void entryDate_DataChanged(Tools.GenericEvent e)
        {
            PostCheck();
        }
    }
}
