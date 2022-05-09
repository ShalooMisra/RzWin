using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;

namespace RzInterfaceWin
{
    public partial class ReconcileAccount : UserControl
    {
        //Private Variables
        ReconcileArgs Args;
        account Account;
        double PayClear = 0;
        double DepClear = 0;
        double ClearedBal
        {
            get
            {
                return PayClear + DepClear + Args.BeginAmount + Args.InterestArgs.Amount - Args.ServiceArgs.Amount;
            }
        }
        double Difference
        {
            get
            {
                return Args.EndAmount - ClearedBal;
            }
        }
        bool Loading = false;

        //Constructors
        public ReconcileAccount()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(ReconcileArgs args)
        {
            Loading = true;
            Args = args;
            Account = args.Account;
            lblPeriod.Text = "For period: " + Args.StatementDate.ToShortDateString();
            LoadLVs();
            SetStartNumbers();
            Loading = false;
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                int width = (pbRight.Left - pbLeft.Right - 30) / 2;
                lvPayments.Width = width;
                lvDeposits.Left = lvPayments.Right + 10;
                lvDeposits.Width = this.ClientRectangle.Width - lvDeposits.Left - 10;
                lblDepCredit.Left = lvDeposits.Left;
                pControls.Top = pbBottom.Top - pControls.Height - 5;
                pControls.Width = this.ClientRectangle.Width - (pControls.Left * 2);
                pResults.Left = pControls.Width - pResults.Width - 3;
                lvPayments.Height = pControls.Top - lvPayments.Top - 5;
                lvDeposits.Height = lvPayments.Height;
                SizeColumns(lvPayments);
                SizeColumns(lvDeposits);
            }
            catch { }
        }
        //Private Functions
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch
            { }
        }
        private void SizeColumns(ListView lv)
        {
            int count = 1;
            foreach (ColumnHeader c in lv.Columns)
            {
                int perc = 0;
                switch (count)
                {
                    case 1:
                    case 2:
                        perc = 16;
                        break;
                    case 3:
                        perc = 40;
                        break;
                    case 4:
                        perc = 23;
                        break;
                }
                count += 1;
                c.Width = Convert.ToInt32(lv.Width * (perc / (Decimal)100.0));
            }
        }
        private void LoadLVs()
        {
            LoadPayments();
            LoadDeposits();
        }
        private void LoadPayments()
        {
            lvPayments.Items.Clear();
            lvPayments.SuspendLayout();
            try
            {
                DataTable dt = RzWin.Context.Select("select unique_id,date_created,reference_number,check_number,vendor_name,amount from payment_out where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 0 order by date_created asc");
                foreach (DataRow dr in dt.Rows)
                {
                    string id = Tools.Data.NullFilterString(dr["unique_id"]);
                    DateTime date = Tools.Data.NullFilterDate(dr["date_created"]);
                    string ref_num = Tools.Data.NullFilterString(dr["reference_number"]);
                    int numb = Tools.Data.NullFilterIntegerFromIntOrLong(dr["check_number"]);
                    string vend = Tools.Data.NullFilterString(dr["vendor_name"]);
                    double amnt = Tools.Data.NullFilterDouble(dr["amount"]);
                    string r = "";
                    if (numb != 0)
                        r = numb.ToString();
                    if (!Tools.Strings.StrExt(r))
                        r = ref_num;
                    ListViewItem xLst = lvPayments.Items.Add(date.ToShortDateString());
                    xLst.SubItems.Add(r);
                    xLst.SubItems.Add(vend);
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(amnt));
                    xLst.Tag = new LVTag(amnt, id);
                }
            }
            catch { }
            lvPayments.ResumeLayout();
        }
        private void LoadDeposits()
        {
            lvDeposits.Items.Clear();
            lvDeposits.SuspendLayout();
            try
            {
                DataTable dt = RzWin.Context.Select("select unique_id,date_created,name,description,total_amount from deposit where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 0");
                foreach (DataRow dr in dt.Rows)
                {
                    string id = Tools.Data.NullFilterString(dr["unique_id"]);
                    DateTime date = Tools.Data.NullFilterDate(dr["date_created"]);
                    string ref_num = Tools.Data.NullFilterString(dr["name"]);
                    string vend = Tools.Data.NullFilterString(dr["description"]);
                    double amnt = Tools.Data.NullFilterDouble(dr["total_amount"]);
                    ListViewItem xLst = lvDeposits.Items.Add(date.ToShortDateString());
                    xLst.SubItems.Add(ref_num);
                    xLst.SubItems.Add(vend);
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(amnt));
                    xLst.Tag = new LVTag(amnt, id);
                }
            }
            catch { }
            lvDeposits.ResumeLayout();
        }
        private void SetStartNumbers()
        {
            lblDepCount.Text = "0";
            lblPayCount.Text = "0";
            lblBeginBalance.Text = Tools.Number.MoneyFormat(Args.BeginAmount);
            lblDepAmount.Text = "0.00";
            lblPayAmount.Text = "0.00";
            lblServiceAmount.Text = "-" + Tools.Number.MoneyFormat(Args.ServiceArgs.Amount);
            lblInterestAmount.Text = Tools.Number.MoneyFormat(Args.InterestArgs.Amount);
            lblEndBalance.Text = Tools.Number.MoneyFormat(Args.EndAmount);
            lblClearedBalance.Text = Tools.Number.MoneyFormat(ClearedBal);
            lblDifference.Text = Tools.Number.MoneyFormat(Difference);
        }
        private void SetNumbers()
        {
            lblDepCount.Text = Tools.Number.LongFormat(lvDeposits.CheckedItems.Count);
            lblPayCount.Text = Tools.Number.LongFormat(lvPayments.CheckedItems.Count);
            lblDepAmount.Text = Tools.Number.MoneyFormat(DepClear);
            lblPayAmount.Text = Tools.Number.MoneyFormat(PayClear);
            lblClearedBalance.Text = Tools.Number.MoneyFormat(ClearedBal);
            lblDifference.Text = Tools.Number.MoneyFormat(Difference);
        }
        private void CheckUnCheckAll(bool check)
        {
            Loading = true;
            foreach (ListViewItem xLst in lvPayments.Items)
            {
                xLst.Checked = check;
            }
            foreach (ListViewItem xLst in lvDeposits.Items)
            {
                xLst.Checked = check;
            }
            Loading = false;
            SetNumbers();
        }
        private void Reconcile()
        {
            Args.Difference = Difference; 
            if (!Args.CheckDifference(RzWin.Context))
                return;
            foreach (ListViewItem xLst in lvPayments.CheckedItems)
            {
                LVTag t = (LVTag)xLst.Tag;
                RzWin.Context.Execute("update payment_out set cleared = 1 where unique_id = '" + t.ID + "'");
                Args.ClearedPayments.Add(payment_out.GetById(RzWin.Context, t.ID));
            }
            foreach (ListViewItem xLst in lvDeposits.CheckedItems)
            {
                LVTag t = (LVTag)xLst.Tag;
                RzWin.Context.Execute("update deposit set cleared = 1 where unique_id = '" + t.ID + "'");
                Args.ClearedDeposits.Add(deposit.GetById(RzWin.Context, t.ID));
            }
            JournalEntry j = null;
            double bal = Account.balance;
            if (Args.ServiceArgs.Account != null && Args.ServiceArgs.Amount > 0)
            {
                j = new JournalEntry("Bank Service Charge");
                j.Add(RzWin.Context, Account, 0, Args.ServiceArgs.Amount);
                j.Add(RzWin.Context, Args.ServiceArgs.Account, Args.ServiceArgs.Amount, 0);
                j.Post(RzWin.Context);
                payment_out p = new payment_out();
                p.account_full_name = Account.full_name;
                p.account_name = Account.name;
                p.account_number = Account.number;
                p.account_uid = Account.unique_id;
                p.amount = Args.ServiceArgs.Amount;
                bal = bal - Args.ServiceArgs.Amount;
                p.balance = bal;
                p.cleared = true;
                p.description = "Bank Service Charge";
                p.Insert(RzWin.Context);
                Args.ClearedPayments.Add(p);
            }
            if (Args.InterestArgs.Account != null && Args.InterestArgs.Amount > 0)
            {
                j = new JournalEntry("Interest Earned");
                j.Add(RzWin.Context, Account, Args.InterestArgs.Amount, 0);
                j.Add(RzWin.Context, Args.InterestArgs.Account, 0, Args.InterestArgs.Amount);
                j.Post(RzWin.Context);
                deposit d = new deposit();
                d.account_full_name = Account.full_name;
                d.account_name = Account.name;
                d.account_number = Account.number;
                d.account_uid = Account.unique_id;
                d.total_amount = Args.InterestArgs.Amount;
                bal = bal + Args.InterestArgs.Amount;
                d.balance = bal;
                d.cleared = true;
                d.description = "Interest Earned";
                d.Insert(RzWin.Context);
                Args.ClearedDeposits.Add(d);
            }
            Account.SetLastReconcileDate(RzWin.Context, Args.StatementDate);          
            RzWin.Context.TheSysRz.TheAccountLogic.ShowReconciliationReport(RzWin.Context, Args, false);
            CloseTab();
        }
        private void CloseTab()
        {
            ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).CloseTabsByID(RzWin.Context, "reconcileaccount-" + Account.name.Replace(" ", "").ToLower().Trim());
        }
        //Buttons
        private void cmdUnMarkAll_Click(object sender, EventArgs e)
        {
            CheckUnCheckAll(false);
        }
        private void cmdMarkAll_Click(object sender, EventArgs e)
        {
            CheckUnCheckAll(true);
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            CloseTab();
        }
        private void cmdReconcile_Click(object sender, EventArgs e)
        {
            Reconcile();
        }
        //Control Events
        private void ReconcileAccount_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvPayments_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            PayClear = 0;
            foreach (ListViewItem xLst in lvPayments.CheckedItems)
            {
                PayClear += (((LVTag)xLst.Tag).Amount) * -1;
            }
            if (Loading)
                return;
            SetNumbers();
        }
        private void lvDeposits_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            DepClear = 0;
            foreach (ListViewItem xLst in lvDeposits.CheckedItems)
            {
                DepClear += ((LVTag)xLst.Tag).Amount;
            }
            if (Loading)
                return;
            SetNumbers();
        }
        //Private Classes
        private class LVTag
        {
            public double Amount = 0;
            public string ID = "";

            public LVTag(double amnt, string id)
            {
                Amount = amnt;
                ID = id;
            }            
        }
    }
}
