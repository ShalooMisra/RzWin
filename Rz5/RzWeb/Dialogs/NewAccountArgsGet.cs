using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoreWeb;
using Rz5;
using System.Collections;
using System.Text;
using System.Drawing;

namespace RzWeb
{
    public class NewAccountArgsGet : OKCancel
    {
        //Private Variables
        account TheParent;
        ComboBoxControl cboAccountType;
        TextControl txtAccountName;
        Int32Control intAccountNumber;
        ComboBoxControl cboParentAccount;

        //Constructors
        public NewAccountArgsGet(ContextRz xs, string parent_id)
        {
            string type = "";
            string name = "";
            if (Tools.Strings.StrExt(parent_id))
            {
                TheParent = account.GetById(xs, parent_id);
                type = TheParent.type;
                name = account.GetAccountFullNameWithBullet(TheParent);
            }
            cboAccountType = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboAccountType", "Account Type", type, GetAccountTypes(), ActionScriptPlusControls("'load_parent_accounts'"))));
            txtAccountName = (TextControl)SpotAdd(ControlAdd(new TextControl("txtAccountName", "Account Name", "")));
            intAccountNumber = (Int32Control)SpotAdd(ControlAdd(new Int32Control("intAccountNumber", "Account Number", 0)));
            cboParentAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboParentAccount", "Sub-Account Of", name, null, ActionScriptPlusControls("'parent_changed'"))));
            AdjustControls();
        }
        //Public Override Functions
        public override void Act(Core.Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                case "parent_changed":
                    ParentChanged(xrz, args.Vars, args.SourceView);
                    break;
                case "load_parent_accounts":
                    LoadParentAccounts(xrz, args.Vars);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("ResizeNewAccount();");
        }
        public override void RenderBody(Core.Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderBody(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div style=\"height: 80px;\">");
            cboAccountType.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAccountName.Render(x, sb, screenHandle, viewHandle, session, page);
            intAccountNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            cboParentAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            viewHandle.ScriptsToRun.Add(ActionScriptPlusControls("'load_parent_accounts'"));
        }
        public override string AfterHtml
        {
            get
            {
                String ret = base.AfterHtml;
                ret += "<script type=\"text/javascript\">" + GetScripts() + "</script>";
                return ret;
            }
        }
        //Protected Override Functions
        protected override void OK(Core.Context x, SpotActArgs args)
        {
            ContextRz xs = (ContextRz)x;
            DialogResultNewAccountArgs result = new DialogResultNewAccountArgs();
            result.Account = new account();
            string s = "";
            args.Vars.TryGetValue("ctl_cboaccounttype", out s);
            result.Account.type = s;
            s = "";
            args.Vars.TryGetValue("ctl_txtaccountname", out s);
            result.Account.name = s;
            s = "";
            args.Vars.TryGetValue("ctl_intaccountnumber", out s);
            int i = 0;
            try { i = Convert.ToInt32(s); }
            catch { }            
            result.Account.number = i;
            s = "";
            args.Vars.TryGetValue("ctl_cboparentaccount", out s);
            if (Tools.Strings.StrExt(s))
            {
                account a = account.GetByFullName(x, account.GetAccountFullNameStripBullet(s));
                if (a != null)
                {
                    result.Account.parent_id = a.unique_id;
                    result.Account.parent_name = a.full_name;
                }
            }
            result.Account.Category = account.InferCategory(result.Account.Type);
            if (Tools.Strings.StrExt(result.Account.parent_name))
                result.Account.full_name = result.Account.parent_name + ":" + result.Account.name;
            else
                result.Account.full_name = result.Account.name;
            ThreadHandle.Result = result;
            base.OK(x, args);
        }
        protected override void Cancel(Core.Context x, SpotActArgs args)
        {
            DialogResultNewAccountArgs result = new DialogResultNewAccountArgs();
            result.Success = false;
            ThreadHandle.Result = result;
            base.Cancel(x, args);
        }
        protected override int DialogWidth
        {
            get
            {
                return 350;
            }
        }
        protected override int DialogHeight
        {
            get
            {
                return 220;
            }
        }
        //Private Functions
        private void ParentChanged(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle) 
        {
            TheParent = null;
            string s = "";
            d.TryGetValue("ctl_cboparentaccount", out s);
            if (!Tools.Strings.StrExt(s))
                return;
            string name = account.GetAccountFullNameStripBullet(s);
            account a = account.GetByFullName(x, name);
            if (a == null)
            {
                x.TheLeader.Tell("The account " + name + " could not be located.");
                return;
            }
            TheParent = a;
            intAccountNumber.ValueSet(TheParent.GetNextSubAccountNumber(x));
            intAccountNumber.Change();
        }
        private void LoadParentAccounts(ContextRz x, Dictionary<string, string> d)
        {
            cboParentAccount.Choices = new ArrayList();
            cboParentAccount.Change();
            ArrayList a = new ArrayList();
            AccountType t = AccountType.Null;
            if (TheParent != null)
                t = TheParent.Type;
            else
            {
                account temp = new account();
                string s = "";
                d.TryGetValue("ctl_cboaccounttype", out s);
                temp.type = s;
                try { t = temp.Type; }
                catch { }
            }
            if (t == AccountType.Null)
                return;
            x.TheSysRz.TheAccountLogic.InitAccounts(x);
            List<account> l = x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria(t));
            foreach (account aa in l)
            {
                if (Tools.Strings.StrCmp("Undeposited Funds", aa.full_name))
                    continue;
                a.Add(account.GetAccountFullNameWithBullet(aa));
            }
            cboParentAccount.Choices = a;
            cboParentAccount.Change();
            intAccountNumber.ValueSet(0);
            intAccountNumber.Change();
        }
        private ArrayList GetAccountTypes()
        {
            ArrayList a = new ArrayList();
            a.Add("Bank");
            a.Add("Accounts Receivable");
            a.Add("Other Current Assets");
            a.Add("Fixed Assets");
            a.Add("Other Assets");
            a.Add("Accounts Payable");
            a.Add("Credit Card");
            a.Add("Other Current Liabilities");
            a.Add("Long Term Liabilities");
            a.Add("Equity");
            a.Add("Income");
            a.Add("Other Income");
            a.Add("Cost Of Goods Sold");
            a.Add("Expense");
            a.Add("Other Expense");
            return a;
        }
        private string GetScripts()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResize());
            sb.AppendLine("ResizeNewAccount();");
            return sb.ToString();
        }
        private String GetResize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ResizeNewAccount() {");
            sb.AppendLine(cboAccountType.Select + ".css('top', 5);");
            sb.AppendLine(cboAccountType.Select + ".css('left', 5);");
            sb.AppendLine(txtAccountName.PlaceBelow(cboAccountType));
            sb.AppendLine(txtAccountName.Select + ".css('left', 5);");
            sb.AppendLine(intAccountNumber.PlaceBelow(cboAccountType));
            sb.AppendLine(intAccountNumber.PlaceRight(txtAccountName));
            sb.AppendLine(cboParentAccount.PlaceBelow(txtAccountName));
            sb.AppendLine(cboParentAccount.Select + ".css('left', 5);");
            sb.AppendLine("}");
            return sb.ToString();
        }
        private void AdjustControls()
        {
            cboParentAccount.CaptionFontSize = FontSize.Small;
            cboParentAccount.TextFontSize = FontSize.Small;
            cboParentAccount.ReadOnly = true;
            cboParentAccount.FixedWidth = 335;
            cboAccountType.CaptionFontSize = FontSize.Small;
            cboAccountType.TextFontSize = FontSize.Small;
            cboAccountType.ReadOnly = true;
            cboAccountType.FixedWidth = 335;
            txtAccountName.CaptionFontSize = FontSize.Small;
            txtAccountName.TextFontSize = FontSize.Small;
            intAccountNumber.CaptionFontSize = FontSize.Small;
            intAccountNumber.TextFontSize = FontSize.Small;
            intAccountNumber.FixedWidth = 120;
            cboParentAccount.UseNameInID = true;
            cboAccountType.UseNameInID = true;
            txtAccountName.UseNameInID = true;
            intAccountNumber.UseNameInID = true;
        }
    }
    public class DialogResultNewAccountArgs : DialogResult
    {
        public account Account = null;
    }
}