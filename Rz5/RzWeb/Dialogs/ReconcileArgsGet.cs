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
    public class ReconcileArgsGet : OKCancel
    {
        //Private Variables
        account Account;
        ComboBoxControl cboAccount;
        DateControl dtDate;
        DoubleControl dblBegBalance;
        DoubleControl dblEndBalance;
        LabelControl lblLastReconcile;
        DoubleControl dblServiceCharge;
        DateControl dtServiceDate;
        ComboBoxControl cboServiceAccount;
        DoubleControl dblInterestEarned;
        DateControl dtInterestDate;
        ComboBoxControl cboInterestAccount;

        //Constructors
        public ReconcileArgsGet(ContextRz xs)
        {
            cboAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboAccount", "Account", "", GetAccounts(xs), ActionScriptPlusControls("'account_changed'"))));            
            dtDate = (DateControl)SpotAdd(ControlAdd(new DateControl("dtDate", "Statement Date", Tools.Dates.GetBlankDate())));
            dblBegBalance = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblBegBalance", "Beginning Balance", 0)));
            dblEndBalance = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblEndBalance", "Ending Balance", 0)));
            lblLastReconcile = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblLastReconcile", "", "Last reconcile 1/1/1900")));
            dblServiceCharge = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblServiceCharge", "Service Charge", 0)));
            dtServiceDate = (DateControl)SpotAdd(ControlAdd(new DateControl("dtServiceDate", "Date", Tools.Dates.GetBlankDate())));
            string def = "";
            ArrayList a = GetExpenseAccounts(xs, ref def);
            cboServiceAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboServiceAccount", "Account", def, a, ActionScriptPlusControls("'service_account_changed'"))));
            dblInterestEarned = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblInterestEarned", "Interest Earned", 0)));
            dtInterestDate = (DateControl)SpotAdd(ControlAdd(new DateControl("dtInterestDate", "Date", Tools.Dates.GetBlankDate())));
            def = "";
            a = GetIncomeAccounts(xs, ref def);
            cboInterestAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboInterestAccount", "Account", def, a, ActionScriptPlusControls("'interest_account_changed'"))));
            AdjustControls();
            Init(xs);
        }
        //Public Override Functions
        public override void Act(Core.Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                case "account_changed":
                    AccountChanged(xrz, args);
                    break;
                case "service_account_changed":
                    OtherAccountChanged(xrz, "service", args);
                    break;
                case "interest_account_changed":
                    OtherAccountChanged(xrz, "interest", args);
                    break;
            }
        }
        public override void RenderBody(Core.Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderBody(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div style=\"height: 115px;\">");
            sb.AppendLine("<label id=\"top_lbl_" + Uid + "\" style=\"position: absolute; top: 5px; left: 5px; font-size: xx-small;\">Select an account to reconcile, and then enter the ending balance from your account statement.</label>");
            cboAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            dtDate.Render(x, sb, screenHandle, viewHandle, session, page);
            dblBegBalance.Render(x, sb, screenHandle, viewHandle, session, page);
            dblEndBalance.Render(x, sb, screenHandle, viewHandle, session, page);
            lblLastReconcile.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<label id=\"bottom_lbl_" + Uid + "\" style=\"position: absolute; top: 70px; left: 5px; font-size: xx-small;\">Enter any service charge or interest earned.</label>");
            dblServiceCharge.Render(x, sb, screenHandle, viewHandle, session, page);
            dtServiceDate.Render(x, sb, screenHandle, viewHandle, session, page);
            cboServiceAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            dblInterestEarned.Render(x, sb, screenHandle, viewHandle, session, page);
            dtInterestDate.Render(x, sb, screenHandle, viewHandle, session, page);
            cboInterestAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");            
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
            DialogResultReconcileArgs result = new DialogResultReconcileArgs();
            result.Args = new ReconcileArgs();
            string s = "";
            args.Vars.TryGetValue("ctl_cboaccount", out s);
            s = Tools.Html.FilterInput(s);
            string name = account.GetAccountFullNameStripBullet(s);
            result.Args.Account = account.GetByFullName(xs, name);
            if (result.Args.Account == null || !Tools.Strings.StrExt(name))
            {
                x.TheLeader.Tell("The account '" + name + "' could not be located.");
                result.Success = false;
            }
            s = "";
            args.Vars.TryGetValue("ctl_dtdate", out s);
            DateTime dt = Tools.Dates.GetBlankDate();
            try { dt = Convert.ToDateTime(s); }
            catch { }
            result.Args.StatementDate = dt;
            s = "";
            args.Vars.TryGetValue("ctl_dblbegbalance", out s);
            s = s.Replace(",", "");
            double d = 0;
            try { d = Convert.ToDouble(s); }
            catch { }
            result.Args.BeginAmount = d;
            s = "";
            args.Vars.TryGetValue("ctl_dblendbalance", out s);
            s = s.Replace(",", "");
            d = 0;
            try { d = Convert.ToDouble(s); }
            catch { }
            result.Args.EndAmount = d;
            s = "";
            args.Vars.TryGetValue("ctl_cboserviceaccount", out s);
            s = Tools.Html.FilterInput(s);
            name = account.GetAccountFullNameStripBullet(s);
            account a = account.GetByFullName(xs, name);
            if (a != null)
            {
                result.Args.ServiceArgs.Account = a;
                s = "";
                args.Vars.TryGetValue("ctl_dblservicecharge", out s);
                s = s.Replace(",", "");
                d = 0;
                try { d = Convert.ToDouble(s); }
                catch { }
                result.Args.ServiceArgs.Amount = d;
                s = "";
                args.Vars.TryGetValue("ctl_dtservicedate", out s);
                dt = Tools.Dates.GetBlankDate();
                try { dt = Convert.ToDateTime(s); }
                catch { }
                result.Args.ServiceArgs.Date = dt;
            }
            s = "";
            args.Vars.TryGetValue("ctl_cbointerestaccount", out s);
            s = Tools.Html.FilterInput(s);
            name = account.GetAccountFullNameStripBullet(s);
            a = account.GetByFullName(xs, name);
            if (a != null)
            {
                result.Args.InterestArgs.Account = a;
                s = "";
                args.Vars.TryGetValue("ctl_dblinterestearned", out s);
                s = s.Replace(",", "");
                d = 0;
                try { d = Convert.ToDouble(s); }
                catch { }
                result.Args.InterestArgs.Amount = d;
                s = "";
                args.Vars.TryGetValue("ctl_dtinterestdate", out s);
                dt = Tools.Dates.GetBlankDate();
                try { dt = Convert.ToDateTime(s); }
                catch { }
                result.Args.InterestArgs.Date = dt;
            }            
            ThreadHandle.Result = result;
            base.OK(x, args);
        }
        protected override void Cancel(Core.Context x, SpotActArgs args)
        {
            DialogResultReconcileArgs result = new DialogResultReconcileArgs();
            result.Success = false;
            ThreadHandle.Result = result;
            base.Cancel(x, args);
        }
        protected override int DialogWidth
        {
            get
            {
                return 520;
            }
        }
        protected override int DialogHeight
        {
            get
            {
                return 240;
            }
        }
        //Private Functions
        private void Init(ContextRz x)
        {
            Account = GetTopBankAccount(x);
            if (Account != null)
            {
                cboAccount.ValueSet(account.GetAccountFullNameWithBullet(Account));
                cboAccount.Change();
            }
            SetDates(x);
            SetBeginAmount(x);
        }
        private account GetTopBankAccount(ContextRz x)
        {
            string id = x.SelectScalarString("select top 1 unique_id from account where type = 'Bank' order by number,name");
            if (!Tools.Strings.StrExt(id))
            {
                x.TheLeader.Tell("The system could not find any accounts assiciated with the Bank to reconcile. Please create a Bank account in the system.");
                return null;
            }
            return account.GetById(x, id);
        }
        private void SetDates(ContextRz x)
        {
            DateTime dt = Account.GetLastReconcileDate(x);
            if (!Tools.Dates.DateExists(dt))
            {
                lblLastReconcile.ValueSet("");                
                dt = Tools.Dates.GetPreviousMonthEnd(DateTime.Now);
            }
            else
            {
                lblLastReconcile.ValueSet("last reconciled on " + dt.ToShortDateString());                
                dt = GetNextReconcileDate(dt);
            }
            lblLastReconcile.Change();
            dtDate.ValueSet(dt);
            dtServiceDate.ValueSet(dt);
            dtInterestDate.ValueSet(dt);
            dtDate.Change();
            dtServiceDate.Change();
            dtInterestDate.Change();
        }
        private void SetBeginAmount(ContextRz x)
        {
            if (Account == null)
                dblBegBalance.ValueSet(0);
            else
            {
                double amnt = x.SelectScalarDouble("select sum(total_amount) from deposit where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 1");
                amnt -= x.SelectScalarDouble("select sum(amount) from payment_out where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 1");
                dblBegBalance.ValueSet(amnt);
            }
            dblBegBalance.Change();
        }
        private DateTime GetNextReconcileDate(DateTime d)
        {
            return d.AddMonths(1);
        }
        private void SetLastReconciled(string text, ViewHandle v)
        {
            v.ScriptsToRun.Add("");
        }
        private void AccountChanged(ContextRz x, SpotActArgs args)
        {
            string s = "";
            args.Vars.TryGetValue("ctl_cboaccount", out s);
            if (!Tools.Strings.StrExt(s))
                s = Account.full_name;
            s = Tools.Html.FilterInput(s);
            Account = account.GetByFullName(x, account.GetAccountFullNameStripBullet(s));
            dblEndBalance.ValueSet(0);
            dblServiceCharge.ValueSet(0);
            cboServiceAccount.ValueSet("");
            dblInterestEarned.ValueSet(0);
            cboInterestAccount.ValueSet("");
            dblEndBalance.Change();
            dblServiceCharge.Change();
            cboServiceAccount.Change();
            dblInterestEarned.Change();
            cboInterestAccount.Change();
            SetDates(x);
            SetBeginAmount(x);
            args.SourceView.ScriptsToRun.Add("ResizeReconcile();");
        }
        private void OtherAccountChanged(ContextRz x, string t, SpotActArgs args)
        {
            if (Account == null)
                return;
            string name = "";
            if (t == "service")
                args.Vars.TryGetValue("ctl_cboserviceaccount", out name);
            else
                args.Vars.TryGetValue("ctl_cbointerestaccount", out name);
            if (!Tools.Strings.StrExt(name))
                return;
            name = Tools.Html.FilterInput(name);
            name = account.GetAccountFullNameStripBullet(name);
            if (Tools.Strings.StrCmp(Account.full_name, name))
            {
                x.TheLeader.Tell("You cannot use the account that is currently being reconciled.");
                if (t == "service")
                {
                    cboServiceAccount.ValueSet("");
                    cboServiceAccount.Change();
                }
                else
                {
                    cboInterestAccount.ValueSet("");
                    cboInterestAccount.Change();
                }
            }
            args.SourceView.ScriptsToRun.Add("ResizeReconcile();");
        }
        private string GetScripts()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(GetResize());
            sb.AppendLine("ResizeReconcile();");
            sb.AppendLine("$('#" + dtDate.ControlId + "').datepicker();");
            sb.AppendLine(dblEndBalance.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + dblEndBalance.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblEndBalance.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("});");
            sb.AppendLine(dblServiceCharge.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + dblServiceCharge.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblServiceCharge.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("});");
            sb.AppendLine(dblInterestEarned.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + dblInterestEarned.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + dblInterestEarned.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("});");
            return sb.ToString();
        }
        private String GetResize()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ResizeReconcile() {");
            sb.AppendLine(cboAccount.Select + ".css('top', 15);");
            sb.AppendLine(cboAccount.Select + ".css('left', 5);");
            sb.AppendLine(dtDate.Select + ".css('top', 15);");
            sb.AppendLine(dtDate.PlaceRight(cboAccount));
            sb.AppendLine(dblBegBalance.Select + ".css('top', 15);");
            sb.AppendLine(dblBegBalance.PlaceRight(dtDate));
            sb.AppendLine(dblEndBalance.Select + ".css('top', 15);");
            sb.AppendLine(dblEndBalance.PlaceRight(dblBegBalance));
            sb.AppendLine(lblLastReconcile.Select + ".css('left', 5);");
            sb.AppendLine(lblLastReconcile.PlaceBelow(cboAccount));
            sb.AppendLine(dblServiceCharge.Select + ".css('top', 80);");
            sb.AppendLine(dblServiceCharge.Select + ".css('left', 5);");
            sb.AppendLine(dtServiceDate.Select + ".css('top', 80);");
            sb.AppendLine(dtServiceDate.PlaceRight(dblServiceCharge));
            sb.AppendLine(cboServiceAccount.Select + ".css('top', 80);");
            sb.AppendLine(cboServiceAccount.PlaceRight(dtServiceDate));
            sb.AppendLine(dblInterestEarned.PlaceBelow(dblServiceCharge));
            sb.AppendLine(dblInterestEarned.Select + ".css('left', 5);");
            sb.AppendLine(dtInterestDate.PlaceBelow(dblServiceCharge));
            sb.AppendLine(dtInterestDate.PlaceRight(dblInterestEarned));
            sb.AppendLine(cboInterestAccount.PlaceBelow(dblServiceCharge));
            sb.AppendLine(cboInterestAccount.PlaceRight(dtInterestDate));
            sb.AppendLine("}");
            return sb.ToString();
        }
        private void AdjustControls()
        {
            cboAccount.CaptionFontSize = FontSize.Small;
            cboAccount.TextFontSize = FontSize.Small;
            cboAccount.FixedWidth = 150;
            cboAccount.UseNameInID = true;
            dtDate.CaptionFontSize = FontSize.Small;
            dtDate.TextFontSize = FontSize.Small;
            dtDate.FixedWidth = 110;
            dtDate.UseNameInID = true;
            dblBegBalance.CaptionFontSize = FontSize.Small;
            dblBegBalance.TextFontSize = FontSize.Small;
            dblBegBalance.FixedWidth = 100;
            dblBegBalance.ReadOnly = true;
            dblBegBalance.UseNameInID = true;
            dblEndBalance.CaptionFontSize = FontSize.Small;
            dblEndBalance.TextFontSize = FontSize.Small;
            dblEndBalance.FixedWidth = 100;
            dblEndBalance.UseNameInID = true;
            lblLastReconcile.CaptionFontSize = FontSize.XXSmall;
            lblLastReconcile.TextFontSize = FontSize.XXSmall;
            lblLastReconcile.TextForeColor = Color.Blue;
            lblLastReconcile.UseNameInID = true;
            dblServiceCharge.CaptionFontSize = FontSize.Small;
            dblServiceCharge.TextFontSize = FontSize.Small;
            dblServiceCharge.FixedWidth = 100;
            dblServiceCharge.UseNameInID = true;
            dtServiceDate.CaptionFontSize = FontSize.Small;
            dtServiceDate.TextFontSize = FontSize.Small;
            dtServiceDate.FixedWidth = 110;
            dtServiceDate.UseNameInID = true;
            cboServiceAccount.CaptionFontSize = FontSize.Small;
            cboServiceAccount.TextFontSize = FontSize.Small;
            cboServiceAccount.FixedWidth = 150;
            cboServiceAccount.UseNameInID = true;
            dblInterestEarned.CaptionFontSize = FontSize.Small;
            dblInterestEarned.TextFontSize = FontSize.Small;
            dblInterestEarned.FixedWidth = 100;
            dblInterestEarned.UseNameInID = true;
            dtInterestDate.CaptionFontSize = FontSize.Small;
            dtInterestDate.TextFontSize = FontSize.Small;
            dtInterestDate.FixedWidth = 110;
            dtInterestDate.UseNameInID = true;
            cboInterestAccount.CaptionFontSize = FontSize.Small;
            cboInterestAccount.TextFontSize = FontSize.Small;
            cboInterestAccount.FixedWidth = 150;
            cboInterestAccount.UseNameInID = true;
        }
        private ArrayList GetAccounts(ContextRz x)
        {
            ArrayList l = new ArrayList();
            foreach (account a in x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria()))
            {
                l.Add(account.GetAccountFullNameWithBullet(a));
            }
            return l;
        }
        private ArrayList GetExpenseAccounts(ContextRz x, ref string def)
        {
            ArrayList l = new ArrayList();
            foreach (account a in x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria(AccountCategory.Expense)))
            {
                l.Add(account.GetAccountFullNameWithBullet(a));
                if (Tools.Strings.StrCmp("Bank Service Charges", a.full_name))
                    def = account.GetAccountFullNameWithBullet(a);
            }
            return l;
        }
        private ArrayList GetIncomeAccounts(ContextRz x, ref string def)
        {
            ArrayList l = new ArrayList();
            foreach (account a in x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria(AccountCategory.Income)))
            {
                l.Add(account.GetAccountFullNameWithBullet(a));
                if (Tools.Strings.StrCmp("Interest Income", a.full_name))
                    def = account.GetAccountFullNameWithBullet(a);
            }
            return l;
        }
    }
    public class DialogResultReconcileArgs : DialogResult
    {        
        public ReconcileArgs Args = new ReconcileArgs();
    }
}