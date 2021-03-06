using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin
{
    public partial class frmBeginReconciliationCC : Form
    {
        //Public Variables
        public bool Canceled = true;
        public ReconcileArgs Args;
        //Private Variables
        private double BeginAmount = 0;
        private account Account;
        private bool Loading = false;

        //Constructors
        public frmBeginReconciliationCC()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init()
        {
            Loading = true;
            Args = new ReconcileArgs();
            LoadAccounts();
            Account = GetTopCCAccount();
            if (Account != null)
                ctlAccount.SetValue(account.GetAccountFullNameWithBullet(Account));
            SetDates();
            SetBeginAmount();
            Loading = false;
        }
        //Private Functions
        private void LoadAccounts()
        {
            string build = "";
            foreach (account a in RzWin.Context.TheSysRz.TheAccountLogic.GetAccounts(RzWin.Context, new AccountCriteria(AccountType.CreditCard)))
            {
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += account.GetAccountFullNameWithBullet(a);
            }
            ctlAccount.SimpleList = build;
            account def = null;
            build = "";
            foreach (account a in RzWin.Context.TheSysRz.TheAccountLogic.GetAccounts(RzWin.Context, new AccountCriteria(AccountCategory.Expense)))
            {
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += account.GetAccountFullNameWithBullet(a);
                if (Tools.Strings.StrCmp("Bank Service Charges", a.full_name))
                    def = a;
            }
            ctlFinanceAccount.SimpleList = build;
            if (def != null)
                ctlFinanceAccount.SetValue(account.GetAccountFullNameWithBullet(def));
        }
        private void SetDates()
        {
            DateTime dt = Account.GetLastReconcileDate(RzWin.Context);
            if (!Tools.Dates.DateExists(dt))
            {
                lblLastReconciled.Text = "";
                dt = Tools.Dates.GetPreviousMonthEnd(DateTime.Now);
            }
            else
            {
                lblLastReconciled.Text = "last reconciled on " + dt.ToShortDateString();
                dt = GetNextReconcileDate(dt);
            }
            ctlDate.SetValue(dt);
            ctlFinanceDate.SetValue(dt);
        }
        private DateTime GetNextReconcileDate(DateTime d)
        {
            return d.AddMonths(1);
        }
        private account GetTopCCAccount()
        {
            string id = RzWin.Context.SelectScalarString("select top 1 unique_id from account where type = 'Credit Card' order by number,name");
            if (!Tools.Strings.StrExt(id))
            {
                RzWin.Context.TheLeader.Tell("The system could not find any accounts assiciated with Credit Cards to reconcile. Please create a Credit Card account in the system.");
                return null;
            }
            return account.GetById(RzWin.Context, id);
        }
        private void SetBeginAmount()
        {
            if (Account == null)
                BeginAmount = 0;
            else
            {
                BeginAmount = RzWin.Context.SelectScalarDouble("select sum(total_amount) from deposit where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 1");
                BeginAmount -= RzWin.Context.SelectScalarDouble("select sum(amount) from payment_out where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 1");
            }
            lblBeginAmount.Text = Tools.Number.MoneyFormat(BeginAmount);
        }
        private void Continue()
        {
            string name = account.GetAccountFullNameStripBullet(ctlAccount.GetValue_String());
            Args.Account = Account;
            if (Args.Account == null)
            {
                RzWin.Context.TheLeader.Tell("The account " + name + " could not be located.");
                return;
            }
            Args.BeginAmount = BeginAmount;
            Args.EndAmount = ctlEndBalance.GetValue_Double();
            Args.StatementDate = ctlDate.GetValue_Date();

            name = account.GetAccountFullNameStripBullet(ctlFinanceAccount.GetValue_String());
            Args.ServiceArgs.Account = account.GetByFullName(RzWin.Context, name);
            Args.ServiceArgs.Amount = ctlFinanceCharge.GetValue_Double();
            Args.ServiceArgs.Date = ctlFinanceDate.GetValue_Date();

            Close();
        }
        private void ClearScreen(bool clear_main_account = true)
        {
            SetDates();
            if (clear_main_account)
                ctlAccount.cboValue.SelectedItem = null;
            ctlEndBalance.SetValue(0);
            lblBeginAmount.Text = "0.00";
            ctlFinanceAccount.cboValue.SelectedItem = null;
            ctlFinanceCharge.SetValue(0);
        }
        //Buttons
        private void cmdContinue_Click(object sender, EventArgs e)
        {
            Canceled = false;
            Continue();
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Control Events
        private void ctlAccount_DataChanged(Tools.GenericEvent e)
        {
            if (Loading)
                return;
            Account = account.GetByFullName(RzWin.Context, account.GetAccountFullNameStripBullet(ctlAccount.GetValue_String()));
            ClearScreen(false);
            SetDates();
            SetBeginAmount();
        }
        private void ctlFinanceAccount_DataChanged(Tools.GenericEvent e)
        {
            if (Loading)
                return;
            if (Account == null)
                return;
            string name = account.GetAccountFullNameStripBullet(ctlFinanceAccount.GetValue_String());
            if (!Tools.Strings.StrExt(name))
                return;
            if (Tools.Strings.StrCmp(Account.full_name, name))
            {
                RzWin.Context.TheLeader.Tell("You cannot use the account that is currently being reconciled.");
                ctlFinanceAccount.cboValue.SelectedItem = null;
                return;
            }
        }
    }
}
