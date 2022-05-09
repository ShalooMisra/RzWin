using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using System.Collections;

namespace RzInterfaceWin
{
    public partial class frmPrintChecks : Form
    {
        //Public Variables
        public bool Canceled = true;
        public PrintCheckArgs Args;
        //Private Variables
        private account TheAccount;
        private List<payment_out> Payments;

        //Constructors
        public frmPrintChecks()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(List<payment_out> l, account a = null)
        {
            TheAccount = a;
            Payments = l;
            LoadAccounts();
            LoadLV();
        }
        //Private Functions
        private void LoadAccounts()
        {
            string build = "";
            string first = "";
            foreach (account a in RzWin.Context.Accounts.GetAccounts(RzWin.Context, new AccountCriteria(AccountType.Bank)))
            {
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += account.GetAccountFullNameWithBullet(a);
                if(!Tools.Strings.StrExt (first))
                    first = account.GetAccountFullNameWithBullet(a);
            }
            cboAccount.SimpleList = build;
            if (TheAccount != null)
                first = account.GetAccountFullNameWithBullet(TheAccount);
            cboAccount.SetValue(first);
        }
        private void LoadLV()
        {
            if (TheAccount == null)
                return;
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                ArrayList a = RzWin.Context.QtC("payment_out", "select * from payment_out where account_uid = '" + TheAccount.unique_id + "' and payment_method = 'Print Check' and isnull(check_printed, 0) = 0");
                foreach (payment_out p in a)
                {
                    ListViewItem xLst = lv.Items.Add(p.date_created.ToShortDateString());
                    xLst.SubItems.Add(p.vendor_name);
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(p.amount));
                    xLst.Tag = p;
                    xLst.Checked = CheckItem(p);
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private bool CheckItem(payment_out p)
        {
            if (Payments == null)
                return true;
            if (Payments.Count <= 0)
                return true;
            foreach (payment_out po in Payments)
            {
                if (Tools.Strings.StrCmp(p.unique_id, po.unique_id))
                    return true;
            }
            return false;
        }
        private void CheckUncheckAll(bool check)
        {
            foreach (ListViewItem xLst in lv.Items)
            {
                xLst.Checked = check;
            }
        }
        private void SetStartCheck()
        {
            int c = RzWin.Context.GetSettingInt32("start_check_" + TheAccount.unique_id);
            if (c <= 0)
            {
                c = 1;
                RzWin.Context.SetSettingInt32("start_check_" + TheAccount.unique_id, c);
            }
            txtNumber.SetValue(RzWin.Context.GetSettingInt32("start_check_" + TheAccount.unique_id));
        }
        //Buttons
        private void cmdOK_Click(object sender, EventArgs e)
        {
            Canceled = false;
            Args = new PrintCheckArgs();
            Args.Account = TheAccount;
            Args.Payments = new List<payment_out>();
            Args.CheckNumber = txtNumber.GetValue_Integer();
            foreach (ListViewItem xLst in lv.CheckedItems)
            {
                Args.Payments.Add((payment_out)xLst.Tag);
            }
            Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Canceled = true;
            Close();
        }
        private void cmdSelectAll_Click(object sender, EventArgs e)
        {
            CheckUncheckAll(true);
        }
        private void cmdSelectNone_Click(object sender, EventArgs e)
        {
            CheckUncheckAll(false);
        }
        //Control Events
        private void cboAccount_DataChanged(Tools.GenericEvent e)
        {
            TheAccount = account.GetByFullName(RzWin.Context, account.GetAccountFullNameStripBullet(cboAccount.GetValue_String()));
            LoadLV();
            SetStartCheck();
        }
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {            
            double amnt = 0;
            int count = 0;
            foreach (ListViewItem xLst in lv.CheckedItems)
            {
                count++;
                amnt += ((payment_out)xLst.Tag).amount;
            }
            lblStatus.Text = "There are " + count.ToString() + " Checks to print for " + Tools.Number.MoneyFormat(amnt);
        }
    }
}
