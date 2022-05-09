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
    public partial class Deposits : UserControl
    {
        public Deposits()
        {
            InitializeComponent();
        }

        bool loading = false;
        public void Init()
        {
            loading = true;
            lv.Items.Clear();
            foreach (payment_in p in deposit.ListPayments(RzWin.Context))
            {
                ListViewItem i = lv.Items.Add(Tools.Dates.DateFormat(p.date_created));
                i.SubItems.Add(p.customer_name);
                i.SubItems.Add(p.description);
                i.SubItems.Add(Tools.Number.MoneyFormat(p.amount));
                i.Tag = p;
            }
            loading = false;

            bankAccount.Init("Bank Account", new AccountCriteria(AccountType.Bank));            
            currentAccount = null;
            memo.SetValue("");
            memo.ClearInfo();
            Display();
        }

        public void Display()
        {
            Double total = DepositTotal;
            totalDepositLabel.Text = "Total Deposit: " + Tools.Number.MoneyFormat(total);

            if (currentAccount == null)
            {
                Warning("Select a bank account");
                saveButton.Enabled = false;
                return;
            }

            if (!Tools.Strings.StrExt(memo.GetValue_String()))
            {
                Warning("Enter a memo");
                saveButton.Enabled = false;
                return;
            }

            if (total == 0)
            {
                Warning("Select at least 1 payment to deposit");
                saveButton.Enabled = false;
            }
            else
            {
                Warning("");
                saveButton.Enabled = true;
            }

        }

        void Warning(String warning)
        {
            warningLabel.Text = warning;
            warningLabel.Visible = true;
        }

        Double DepositTotal
        {
            get
            {
                Double total = 0;
                foreach(payment_in p in SelectedPayments)
                {
                    total += p.amount;
                }
                return total;
            }
        }

        List<payment_in> SelectedPayments
        {
            get
            {
                List<payment_in> ret = new List<payment_in>();
                foreach (ListViewItem i in lv.CheckedItems)
                {
                    ret.Add((payment_in)i.Tag);
                }
                return ret;
            }
        }

        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (loading)
                return;

            Display();
        }

        //void lv_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        //{
        //    if (loading)
        //        return;

        //    Display();
        //}

        private void Deposits_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                top.Left = 0;
                top.Top = 0;
                top.Width = this.ClientRectangle.Width;

                pExtra.Left = top.ClientRectangle.Width - pExtra.Width;

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
                RzWin.Context.Show((payment_in)lv.SelectedItems[0].Tag);
            }
            catch { }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void newPaymentButton_Click(object sender, EventArgs e)
        {
            RzWin.Leader.ReceivePaymentsShow(RzWin.Context, null);
        }

        account currentAccount = null;
        private void bankAccount_AccountSelected(account newAccount, ref bool cancel)
        {
            currentAccount = newAccount;
            Display();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                deposit.MakeDeposit(RzWin.Context, currentAccount, SelectedPayments, memo.GetValue_String());
                Init();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error: " + ex.Message);
            }
        }

        void memo_DataChanged(Tools.GenericEvent e)
        {
            Display();
        }
    }
}
