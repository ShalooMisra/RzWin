using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Rz5;
using System.Collections;

namespace RzInterfaceWin
{
    public partial class BudgetEditor : UserControl
    {
        //Private Variables
        budget Budget;        

        //Constructors
        public BudgetEditor()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(budget b)
        {
            Budget = b;
            LoadBudget();
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                pCommands.Top = pbBottom.Top - pCommands.Height - 2;
                pCommands.Width = pbRight.Left - (pCommands.Left * 2);
                lv.Width = pCommands.Width;
                lv.Height = pCommands.Top - lv.Top - 2;
                cmdNew.Left = lv.Right - cmdNew.Width;
                cmdCancel.Left = pCommands.Width - cmdCancel.Width;
                SizeColumns();
            }
            catch { }
        }
        //Private Functions
        private void LoadBudget()
        {
            LoadBudgetDropDown();
            LoadBudgetAccounts();
        }
        private void LoadBudgetDropDown()
        {
            string build = "";
            ArrayList a = RzWin.Context.SelectScalarArray("select distinct(budget_name) from budget where len(isnull(budget_name,'')) > 0 order by budget_name");
            foreach (string s in a)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += s;
            }
            cboBudgets.SimpleList = build;
            cboBudgets.SetValue(Budget.budget_name);
        }
        private void LoadBudgetAccounts()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                foreach (budget_account a in Budget.AccountList(RzWin.Context))
                {
                    ListViewItem xLst = lv.Items.Add(account.GetAccountFullNameWithBullet(a));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.annual_total));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.jan));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.feb));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.march));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.april));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.may));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.june));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.july));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.august));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.sept));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.oct));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.nov));
                    xLst.SubItems.Add(Tools.Number.MoneyFormat(a.december));
                    xLst.Tag = a;
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void SizeColumns()
        {
            int count = 1;
            foreach (ColumnHeader c in lv.Columns)
            {
                int perc = 0;
                switch (count)
                {
                    case 1:
                        perc = 20;
                        break;
                    default:
                        perc = 6;
                        break;
                }
                count += 1;
                c.Width = Convert.ToInt32(lv.Width * (perc / (Decimal)100.0));
            }
        }
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
        private void CloseTab()
        {
            ((LeaderWinUserRz)RzWin.Context.TheLeaderRz).CloseTabsByID(RzWin.Context, "budget-" + Budget.budget_name.Replace(" ", "").ToLower().Trim());
        }
        private void CopyToSelected() 
        {
            bool c = false;
            double d = RzWin.Context.TheLeader.AskForDouble("Enter the amount to apply to all months.", 0, "Enter Amount", ref c);
            if (c)
                return;
            try
            {
                budget_account a = (budget_account)lv.SelectedItems[0].Tag;
                if (a != null)
                    a.ApplyValue(RzWin.Context, d);
            }
            catch { }
            LoadBudgetAccounts();
        }
        private void AdjustSelected() 
        {
            bool c = false;
            double d = RzWin.Context.TheLeader.AskForDouble("Enter the amount to apply to the percentage for all months.", 0, "Enter Amount", ref c);
            if (c)
                return;
            try
            {
                frmBudgetPercent p = new frmBudgetPercent();
                p.ShowDialog();
                if (p.Canceled)
                    return;
                budget_account a = (budget_account)lv.SelectedItems[0].Tag;
                if (a != null)
                    a.ApplyPercent(RzWin.Context, d, p.Percent, p.Decrease);
            }
            catch { }
            LoadBudgetAccounts();
        }
        private void ClearBudget() 
        {
            if (Budget == null)
                return;
            if (!RzWin.Context.TheLeader.AreYouSure("you want to clear this budget"))
                return;
            Budget.ClearBudget(RzWin.Context);
            LoadBudgetAccounts();
        }
        //Buttons
        private void cmdNew_Click(object sender, EventArgs e)
        {
            frmNewBudget n = new frmNewBudget();
            n.ShowDialog();
            if (n.Canceled)
                return;
            Init(n.Budget);
        }
        private void cmdCopy_Click(object sender, EventArgs e)
        {
            CopyToSelected();
        }
        private void cmdAdjust_Click(object sender, EventArgs e)
        {
            AdjustSelected();
        }
        private void cmdClear_Click(object sender, EventArgs e)
        {
            ClearBudget();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            CloseTab();
        }
        //Control Events
        private void BudgetEditor_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void cboBudgets_DataChanged(Tools.GenericEvent e)
        {
            string name = cboBudgets.GetValue_String();
            if (!Tools.Strings.StrExt(name))
                return;
            Budget = budget.GetByName(RzWin.Context, name);
            LoadBudgetAccounts();
        }
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                budget_account a = (budget_account)lv.SelectedItems[0].Tag;
                frmEditBudgetAccount ba = new frmEditBudgetAccount();
                ba.Init(a);
                ba.ShowDialog();
                Budget.GatherAccounts(RzWin.Context);
                LoadBudget();
            }
            catch { }
        }
    }
}
