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
    public partial class frmAskNewAccount : Form
    {
        //Public Variables
        public account TheAccount;
        //Private Variables
        public account TheParent;

        //Constructors
        public frmAskNewAccount()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static account AskNewAccount(ContextRz x, string parent_id)
        {
            frmAskNewAccount f = new frmAskNewAccount();
            f.Init(x, parent_id);
            f.ShowDialog();
            return f.TheAccount;
        }
        //Public Functions
        public void Init(ContextRz x, string parent_id)
        {
            if (Tools.Strings.StrExt(parent_id))
                TheParent = account.GetById(x, parent_id);
            LoadParentAccounts(x);
            if (TheParent != null)
            {
                ctlAccountType.SetValue(TheParent.type);
                ctlParentAccount.SetValue(account.GetAccountFullNameWithBullet(TheParent));
            }
        }
        public void DoResize()
        {
            try
            {
                this.Width = panel.Width;
                this.Height = panel.Height;
            }
            catch { }
        }
        //Private Functions
        private void Accept()
        {
            TheAccount = new account();
            TheAccount.name = ctlAccountName.GetValue_String();
            TheAccount.number = ctlAccountNumber.GetValue_Integer();
            TheAccount.type = ctlAccountType.GetValue_String();
            if (TheParent != null)
            {
                TheAccount.parent_id = TheParent.unique_id;
                TheAccount.parent_name = TheParent.full_name;
            }
            TheAccount.Category = account.InferCategory(TheAccount.Type);
            if (Tools.Strings.StrExt(TheAccount.parent_name))
                TheAccount.full_name = TheAccount.parent_name + ":" + TheAccount.name;
            else
                TheAccount.full_name = TheAccount.name;            
        }
        private void LoadParentAccounts(ContextRz x)
        {
            ctlParentAccount.SimpleList = "";
            AccountType t = AccountType.Null;
            if (TheParent != null)
                t = TheParent.Type;
            else
            {
                account temp = new account();
                temp.type = ctlAccountType.GetValue_String();
                try { t = temp.Type; }
                catch { }
            }
            if (t == AccountType.Null)
                return;
            string build = "";
            List<account> l = x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria(t));
            foreach (account a in l)
            {
                if (Tools.Strings.StrCmp("Undeposited Funds", a.full_name))
                    continue;
                if (Tools.Strings.StrExt(build))
                    build += "|";
                build += account.GetAccountFullNameWithBullet(a);
            }
            ctlParentAccount.SimpleList = build;
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            TheAccount = null;
            Close();
        }
        private void cmdAccept_Click(object sender, EventArgs e)
        {
            Accept();
            Close();
        }
        //Control Events
        private void ctlAccountType_DataChanged(Tools.GenericEvent e)
        {
            LoadParentAccounts(RzWin.Context);
            ctlAccountNumber.SetValue("");
        }
        private void ctlParentAccount_DataChanged(Tools.GenericEvent e)
        {
            TheParent = null;
            if (!Tools.Strings.StrExt(ctlParentAccount.GetValue_String()))
            {
                ctlAccountNumber.SetValue("");
                return;
            }
            string name = account.GetAccountFullNameStripBullet(ctlParentAccount.GetValue_String());
            account a = account.GetByFullName(RzWin.Context, name);
            if (a == null)
            {
                RzWin.Context.TheLeader.Tell("The account " + name + " could not be located.");
                ctlAccountNumber.SetValue("");
                return;
            }
            TheParent = a;
            ctlAccountNumber.SetValue(TheParent.GetNextSubAccountNumber(RzWin.Context));
        }
        private void frmAskNewAccount_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
