using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Core;
using CoreWeb;
using Rz5;
using System.Text;
using System.Web.UI;
using RzWeb.Screens;
using RzWeb.Controls;
using Rz5.Web;
using NewMethod;
using System.Collections;
using CoreWeb.Controls;

namespace RzWeb
{
    public class CheckRegister : RzScreen
    {
        //Private Variables
        private account Account;
        private CheckRegisterSearchArgs Args;
        //Search Controls
        private DateControl dtStart;
        private DateControl dtEnd;
        private ComboBoxControl ctlPayee;
        private TextControl txtRefNumb;
        private DoubleControl dblAmount;
        private TextControl txtMemo;
        //Recording Controls
        private DateControl ctl_date_created;
        private TextControl ctl_ref_numb;
        private ComboBoxControl ctl_payee;
        private ComboBoxControl ctl_account;
        private DoubleControl ctl_payment;
        private DoubleControl ctl_deposit;
        private TextControl ctl_memo;

        //Constructors
        public CheckRegister(Rz5.ContextRz context, account a)
            : base(context)
        {
            Account = a;
            Args = new CheckRegisterSearchArgs();
            Args.Range = new Tools.Dates.DateRange(Tools.Dates.GetMonthStart(DateTime.Now), DateTime.Now);
            dtStart = (DateControl)SpotAdd(ControlAdd(new DateControl("dtStart", "Start Date", Tools.Dates.GetMonthStart(DateTime.Now))));
            dtEnd = (DateControl)SpotAdd(ControlAdd(new DateControl("dtEnd", "End Date", DateTime.Now)));
            ctlPayee = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("ctlPayee", "Payee/Name", "", GetPayees(context, "payment_out", "vendor_name"))));
            txtRefNumb = (TextControl)SpotAdd(ControlAdd(new TextControl("txtRefNumb", "Number/Ref.", "")));
            dblAmount = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("dblAmount", "Amount", 0)));
            txtMemo = (TextControl)SpotAdd(ControlAdd(new TextControl("txtMemo", "Memo", "")));
            ctl_date_created = (DateControl)SpotAdd(ControlAdd(new DateControl("ctl_date_created", "Date", DateTime.Now)));
            ctl_ref_numb = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_ref_numb", "Number/Ref.", "")));
            ctl_payee = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("ctl_payee", "Payee/Name", "", GetPayees(context, "company", "companyname"))));
            ctl_account = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("ctl_account", "Account", "", GetAccounts(context))));
            ctl_payment = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("ctl_payment", "Payment", 0)));            
            ctl_deposit = (DoubleControl)SpotAdd(ControlAdd(new DoubleControl("ctl_deposit", "Deposit", 0)));
            ctl_memo = (TextControl)SpotAdd(ControlAdd(new TextControl("ctl_memo", "Memo", "")));
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Check Register";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 40px;\">");
            dtStart.Render(x, sb, screenHandle, viewHandle, session, page);
            dtEnd.Render(x, sb, screenHandle, viewHandle, session, page);
            ctlPayee.Render(x, sb, screenHandle, viewHandle, session, page);
            txtRefNumb.Render(x, sb, screenHandle, viewHandle, session, page);
            dblAmount.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMemo.Render(x, sb, screenHandle, viewHandle, session, page);            
            sb.AppendLine("     <div id=\"search_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("         <input type=\"button\" id=\"searchButton\" value=\"Search\" style=\"font-size: small; width: 80px; height: 50px;\" onclick=\"HandleAction('search');\">");
            sb.AppendLine("     </div>");            
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"results_" + Uid + "\" style=\"position: absolute; padding: 6px; overflow: scroll;\">");
            sb.AppendLine(((ContextRz)x).TheSysRz.TheAccountLogic.GetCheckRegisterHTML((ContextRz)x, Account, Args));
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bottom_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 90px;\">");
            ctl_date_created.Render(x, sb, screenHandle, viewHandle, session, page);
            ctl_ref_numb.Render(x, sb, screenHandle, viewHandle, session, page);
            ctl_payee.Render(x, sb, screenHandle, viewHandle, session, page);
            ctl_account.Render(x, sb, screenHandle, viewHandle, session, page);
            ctl_payment.Render(x, sb, screenHandle, viewHandle, session, page);
            ctl_deposit.Render(x, sb, screenHandle, viewHandle, session, page);
            ctl_memo.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("     <div id=\"record_" + Uid + "\" style=\"position: absolute; top: 30px;\">");
            sb.AppendLine("         <input type=\"button\" id=\"recordButton\" value=\"Record\" style=\"font-size: small; width: 80px; height: 50px;\" onclick=\"HandleAction('record');\">");
            sb.AppendLine("     </div>"); 
            sb.AppendLine("</div>");            
            AddScripts(viewHandle);
        }
        public override void ClientScriptsInclude(System.Web.UI.Page page)
        {
            base.ClientScriptsInclude(page);
            page.ClientScript.RegisterClientScriptInclude("Rz", page.ResolveClientUrl("~/Scripts") + "/Rz.js");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            ContextRz xrz = (ContextRz)x;
            Dictionary<string, string> d = ParseValueString(args.ActionParams);
            switch (args.ActionId)
            {
                case "search":
                    DoSearch(xrz, d);
                    break;
                case "record":
                    Record(xrz, d);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(dtStart.Select + ".css('top', 5);");
            sb.AppendLine(dtStart.Select + ".css('left', 20);");
            sb.AppendLine(dtEnd.Select + ".css('top', 5);");
            sb.AppendLine(dtEnd.PlaceRight(dtStart));
            sb.AppendLine(ctlPayee.Select + ".css('top', 5);");
            sb.AppendLine(ctlPayee.PlaceRight(dtEnd));
            sb.AppendLine(txtRefNumb.Select + ".css('top', 5);");
            sb.AppendLine(txtRefNumb.PlaceRight(ctlPayee));
            sb.AppendLine(dblAmount.Select + ".css('top', 5);");
            sb.AppendLine(dblAmount.PlaceRight(txtRefNumb));
            sb.AppendLine(txtMemo.Select + ".css('top', 5);");
            sb.AppendLine(txtMemo.PlaceRight(dblAmount));
            sb.AppendLine("$('#search_" + Uid + "').css('top', 1);");
            sb.AppendLine("$('#search_" + Uid + "').css('left', $('#top_" + Uid + "').width() - $('#search_" + Uid + "').width());");
            sb.AppendLine("$('#" + txtMemo.ControlId + "').css('width', $('#search_" + Uid + "').position().left - " + txtMemo.Select + ".position().left - 20);");
            PlaceDivBelowDiv(sb, "results_" + Uid, "top_" + Uid);
            RunDivToRight(sb, "results_" + Uid);
            PlaceDivAtBottom(sb, "bottom_" + Uid);
            RunDivToRight(sb, "bottom_" + Uid);
            sb.AppendLine(ctl_date_created.Select + ".css('top', 5);");
            sb.AppendLine(ctl_date_created.Select + ".css('left', 20);");
            sb.AppendLine(ctl_ref_numb.Select + ".css('top', 5);");
            sb.AppendLine(ctl_ref_numb.PlaceRight(ctl_date_created));
            sb.AppendLine(ctl_payee.Select + ".css('top', 5);");
            sb.AppendLine(ctl_payee.PlaceRight(ctl_ref_numb));
            sb.AppendLine(ctl_account.Select + ".css('top', 5);");
            sb.AppendLine(ctl_account.PlaceRight(ctl_payee));
            sb.AppendLine(ctl_payment.Select + ".css('top', 5);");
            sb.AppendLine(ctl_payment.PlaceRight(ctl_account));
            sb.AppendLine(ctl_deposit.Select + ".css('top', 5);");
            sb.AppendLine(ctl_deposit.PlaceRight(ctl_payment));
            sb.AppendLine("$('#record_" + Uid + "').css('left', " + ctl_deposit.Select + ".position().left + " + ctl_deposit.Select + ".width() + 5);");           
            sb.AppendLine(ctl_memo.Select + ".css('left', 20);");
            sb.AppendLine(ctl_memo.PlaceBelow(ctl_date_created));
            sb.AppendLine("$('#results_" + Uid + "').css('height', $('#bottom_" + Uid + "').position().top - $('#results_" + Uid + "').position().top - 10);");           
        }
        //Private Functions
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function HandleAction(action)");
            sb.AppendLine("{");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("action", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            sb = new StringBuilder();
            sb.AppendLine(ctl_payment.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + ctl_payment.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + ctl_payment.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("     var n = Number(v);");
            sb.AppendLine("     if(n == 0)");
            sb.AppendLine("         return;");
            sb.AppendLine("     if(n < 0)");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + ctl_payment.ControlId + "').val(0);");
            sb.AppendLine("         $('#" + ctl_deposit.ControlId + "').val(n * -1);");
            sb.AppendLine("     }");
            sb.AppendLine("     else");
            sb.AppendLine("         $('#" + ctl_deposit.ControlId + "').val(0);");
            sb.AppendLine("});");
            sb.AppendLine(ctl_deposit.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     var v = $('#" + ctl_deposit.ControlId + "').val().replace(\"$\", \"\").replace(\",\", \"\");");
            sb.AppendLine("     if(!IsNumeric(v))");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + ctl_deposit.ControlId + "').val(0);");
            sb.AppendLine("         return;");
            sb.AppendLine("     }");
            sb.AppendLine("     var n = Number(v);");
            sb.AppendLine("     if(n == 0)");
            sb.AppendLine("         return;");
            sb.AppendLine("     if(n < 0)");
            sb.AppendLine("     {");
            sb.AppendLine("         $('#" + ctl_deposit.ControlId + "').val(0);");
            sb.AppendLine("         $('#" + ctl_payment.ControlId + "').val(n * -1);");
            sb.AppendLine("     }");
            sb.AppendLine("     else");
            sb.AppendLine("         $('#" + ctl_payment.ControlId + "').val(0);");
            sb.AppendLine("});");
            viewHandle.ScriptsToRun.Add(sb.ToString());
        }
        private void AdjustControls()
        {
            dtStart.FixedWidth = 100;
            dtEnd.FixedWidth = 100;
            txtRefNumb.FixedWidth = 100;
            dblAmount.FixedWidth = 100;
            ctl_account.ReadOnly = true;
            ctl_date_created.FixedWidth = 100;
            ctl_ref_numb.FixedWidth = 100;
            ctl_payment.FixedWidth = 100;
            ctl_deposit.FixedWidth = 100;
            ctl_memo.FixedWidth = 835;
        }
        private ArrayList GetPayees(ContextRz x, string table, string prop)
        {
            return x.SelectScalarArray("select distinct(" + prop + ") from " + table + " order by " + prop + "");
        }
        private ArrayList GetAccounts(ContextRz x)
        {
            List<account> l = x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria());
            ArrayList a = new ArrayList();
            foreach (account aa in l)
            {
                if (Tools.Strings.StrCmp(Account.full_name, aa.full_name))
                    continue;
                if (Tools.Strings.StrCmp("Undeposited Funds", aa.full_name))
                    continue;
                a.Add(account.GetAccountFullNameWithBullet(aa));
            }
            return a;
        }
        private void DoSearch(ContextRz x, Dictionary<string, string> pars)
        {
            if (pars == null)
                return;
            Args = new CheckRegisterSearchArgs();
            string s = "";
            pars.TryGetValue("dtStart", out s);
            if (Tools.Strings.StrExt(s))
            {
                DateTime dt = Tools.Dates.GetBlankDate();
                try { dt = Convert.ToDateTime(s); }
                catch { }
                if (Tools.Dates.DateExists(dt))
                    Args.Range.StartDate = dt;   
                ValueSet(dtStart, dt);
            }
            s = "";
            pars.TryGetValue("dtEnd", out s);
            if (Tools.Strings.StrExt(s))
            {
                DateTime dt = Tools.Dates.GetBlankDate();
                try { dt = Convert.ToDateTime(s); }
                catch { }
                if (Tools.Dates.DateExists(dt))
                    Args.Range.EndDate = dt;
                ValueSet(dtEnd, dt);
            }
            s = "";
            pars.TryGetValue("ctlPayee", out s);
            if (Tools.Strings.StrExt(s))
                Args.Payee = s;
            ValueSet(ctlPayee, s);
            s = "";
            pars.TryGetValue("txtRefNumb", out s);
            if (Tools.Strings.StrExt(s))
                Args.Ref = s;
            ValueSet(txtRefNumb, s);
            s = "";
            pars.TryGetValue("dblAmount", out s);
            double d = 0;
            if (Tools.Strings.StrExt(s))
            {                
                try { d = Convert.ToDouble(s); }
                catch { }
                if (d != 0)
                    Args.Amount = d;
            }
            ValueSet(dblAmount, d);
            s = "";
            pars.TryGetValue("txtMemo", out s);
            if (Tools.Strings.StrExt(s))            
                Args.Memo = s;
            ValueSet(txtMemo, s);
            Change();
        }
        private void Record(ContextRz x, Dictionary<string, string> pars)
        {
            if (pars == null)
                return;
            string s = "";
            pars.TryGetValue("ctl_account", out s);
            if (!Tools.Strings.StrExt(s))
            {
                x.TheLeader.Tell("You need to select an account for this transaction.");
                return;
            }
            string name = account.GetAccountFullNameStripBullet(s);
            account a = account.GetByFullName(x, name);
            if (a == null)
            {
                x.TheLeader.Tell("The account " + name + " could not be located.");
                return;
            }
            s = "";
            pars.TryGetValue("ctl_payee", out s);
            company c = null;
            if (Tools.Strings.StrExt(s))
                c = company.GetByName(x, s);
            if (a.Type == AccountType.AccountsPayable || a.Type == AccountType.AccountsReceivable)
            {
                if (c == null)
                {
                    x.TheLeader.Tell("The account " + a.name + " must have a company reference.");
                    return;
                }
            }
            Account = account.GetById(x, Account.unique_id);//Grab new instance in case the balance has changed?
            s = "";
            pars.TryGetValue("ctl_date_created", out s);
            DateTime dt = DateTime.Now;
            try { dt = Convert.ToDateTime(s); }
            catch { }
            string ref_num = "";
            pars.TryGetValue("ctl_ref_numb", out ref_num);
            string memo = "";
            pars.TryGetValue("ctl_memo", out memo);
            s = "";
            pars.TryGetValue("ctl_payment", out s);
            double pay = 0;
            try { pay = Convert.ToDouble(s); }
            catch { }
            s = "";
            pars.TryGetValue("ctl_deposit", out s);
            double dep = 0;
            try { dep = Convert.ToDouble(s); }
            catch { }
            if (pay > 0)
                Account.RecordPayment(x, a, c, pay, ref_num, memo, dt);
            else if (dep > 0)
                Account.RecordDeposit(x, a, c, dep, ref_num, memo, dt);
            else
            {
                x.TheLeader.Tell("You need to enter a value in either the payment or deposit boxes to record a transaction.");
                return;
            }
            Change();
        }
        private void ValueSet(CoreWeb.Control c, object value)
        {
            c.ValueSet(value);
        }
    }
}
