using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Rz5;

namespace RzInterfaceWin.Views
{
    public partial class Account : ViewPlusMenu
    {
        account TheAccount
        {
            get
            {
                return(account)GetCurrentObject();
            }
        }

        public Account()
        {
            InitializeComponent();
        }

        public override void Init(Core.Item item)
        {
            base.Init(item);
        }

        public override void CompleteLoad()
        {
            base.CompleteLoad();
            categoryLabel.Text = TheAccount.category;

            account parent = TheAccount.GetParent(RzWin.Context);
            if (parent == null)
            {
                parentLabel.Text = "<no parent account>";
                changeSetLabel.Text = "choose a parent account";
            }
            else
            {
                parentLabel.Text = parent.name;
                changeSetLabel.Text = "clear this parent relationship";
            }

            typeList.Text = TheAccount.type;
            subAccountList.Init(TheAccount.SubAccountArgs(RzWin.Context));
            typeList.Enabled = !TheAccount.HasParent;

            if (TheAccount.built_in)
            {
                builtInLabel.Visible = true;
                ctl_name.Enabled = false;
                ctl_number.Enabled = false;
            }
            else
                builtInLabel.Visible = false;

            pExtra_Bank.Visible = false;
            pExtra_CC.Visible = false;

            switch (TheAccount.Type)
            {
                case AccountType.Bank:
                    pExtra_Bank.Visible = true;
                    bankStartingBalance.Visible = (TheAccount.balance == 0);
                    CompleteLoadBank();
                    break;
                case AccountType.CreditCard:
                    pExtra_CC.Visible = true;
                    ccStartingBalance.Visible = (TheAccount.balance == 0);
                    CompleteLoadCC();
                    break;
            }
        }

        public override void CompleteSave()
        {
            base.CompleteSave();
            TheAccount.SetTypeAndCategory(typeList.Text);
            if (TheAccount.Type == AccountType.Bank)
                CompleteSaveBank();
            if (TheAccount.Type == AccountType.CreditCard)
                CompleteSaveCC();
            RzWin.Context.Accounts.InitAccounts(RzWin.Context);
        }

        void CompleteLoadBank()
        {
            bankAccountNumber.SetValue(TheAccount.GetExtra("bank_account_number"));
            routingNumber.SetValue(TheAccount.GetExtra("routing_number"));
        }

        void CompleteSaveBank()
        {
            TheAccount.SetExtra("bank_account_number", bankAccountNumber.GetValue_String());
            TheAccount.SetExtra("routing_number", routingNumber.GetValue_String());
        }

        void CompleteLoadCC()
        {
            ccNumber.SetValue(TheAccount.GetExtra("cc_account_number"));
        }

        void CompleteSaveCC()
        {
            TheAccount.SetExtra("cc_account_number", ccNumber.GetValue_String());
        }

        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                subAccountList.Height = this.ClientRectangle.Height - subAccountList.Top;
            }
            catch { }
        }

        private void subAccountList_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            CompleteSave();
            account a = account.CreateNewAccount(RzWin.Context, TheAccount.unique_id);
            if (a == null)
                return;
            RzWin.Context.Show(a);
            SendCloseRequest();
        }

        private void changeSetLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            account parent = TheAccount.GetParent(RzWin.Context);
            if (parent == null)
            {
                parent = RzWin.Context.TheSysRz.TheAccountLogic.ChooseAnAccount(RzWin.Context, "Parent account for " + TheAccount.name, new AccountCriteria());
                if (parent == null)
                    return;
                if (!RzWin.Leader.AreYouSure("set " + parent.full_name + " as the parent account of " + TheAccount.name))
                    return;
                IsLoading = true;
                CompleteSave();
                TheAccount.SetParent(parent);
                TheAccount.Update(RzWin.Context);
                IsLoading = false;
                CompleteLoad();
            }
            else
            {
                if (!RzWin.Leader.AreYouSure("clear this account's relationship with " + parent.name))
                    return;
                IsLoading = true;
                CompleteSave();
                TheAccount.ClearParent();
                TheAccount.Update(RzWin.Context);
                IsLoading = false;
                CompleteLoad();
            }
        }

        private void SetStartingBalance()
        {
            CompleteSave();
            IsLoading = true;
            TheAccount.SetStartingBankBalance(RzWin.Context);
            SetCurrentObject(account.GetById(RzWin.Context, TheAccount.unique_id));
            IsLoading = false;
            CompleteLoad();
        }

        void bankStartingBalance_Click(object sender, System.EventArgs e)
        {
            SetStartingBalance();
        }

        private void lnkEditNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EditAccountNumber();
        }

        private void EditAccountNumber()
        {
            TheAccount.number = account.EditAccountNumber(RzWin.Context, TheAccount);
            ctl_number.SetValue(TheAccount.number);
            TheAccount.Update(RzWin.Context);
        }

        private void ccStartingBalance_Click(object sender, EventArgs e)
        {
            SetStartingBalance();
        }
    }
}
