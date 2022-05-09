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
using System.Drawing;
using System.Data;

namespace RzWeb
{
    public class ReconcileAccount : RzScreen
    {
        //Private Variables
        account Account;
        ReconcileArgs Args;
        double PayCount = 0;
        double DepCount = 0;
        double PayClear = 0;
        double DepClear = 0;
        double ClearedBal
        {
            get
            {
                return PayClear + DepClear + Args.BeginAmount;
            }
        }
        double Difference
        {
            get
            {
                return Args.EndAmount - ClearedBal;
            }
        }
        Dictionary<string, payment_out> Payments = new Dictionary<string, payment_out>();
        Dictionary<string, deposit> Deposits = new Dictionary<string, deposit>();
        ArrayList PaymentCheckboxes = new ArrayList();
        ArrayList DepositCheckboxes = new ArrayList();
        LabelControl lblBegBalance;
        LabelControl lblDepositCount;
        LabelControl lblPaymentCount;
        LabelControl lblDepositAmount;
        LabelControl lblPaymentAmount;
        LabelControl lblServiceCharge;
        LabelControl lblInterestEarned;
        LabelControl lblEndingBalance;
        LabelControl lblClearedBalance;
        LabelControl lblDifference;

        //Constructors
        public ReconcileAccount(Rz5.ContextRz context, ReconcileArgs args)
            : base(context)
        {
            Args = args;
            Account = Args.Account;
            lblBegBalance = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblBegBalance", "", Tools.Number.MoneyFormat(Args.BeginAmount))));
            lblDepositCount = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblDepositCount", "", Tools.Number.LongFormat(DepCount) + "  Deposits and Other Credits")));
            lblPaymentCount = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblPaymentCount", "", Tools.Number.LongFormat(PayCount) + "  Checks and Payments")));
            lblDepositAmount = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblDepositAmount", "", Tools.Number.MoneyFormat(DepClear))));
            lblPaymentAmount = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblPaymentAmount", "", Tools.Number.MoneyFormat(PayClear))));
            lblServiceCharge = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblServiceCharge", "", Tools.Number.MoneyFormat(Args.ServiceArgs.Amount))));
            lblInterestEarned = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblInterestEarned", "", Tools.Number.MoneyFormat(Args.InterestArgs.Amount))));
            lblEndingBalance = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblEndingBalance", "", Tools.Number.MoneyFormat(Args.EndAmount))));
            lblClearedBalance = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblClearedBalance", "", Tools.Number.MoneyFormat(ClearedBal))));
            lblDifference = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblDifference", "", Tools.Number.MoneyFormat(Difference))));
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Reconcile Account";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px;\">");
            sb.AppendLine("<label id=\"date_label\" style=\"position: absolute; top: 5px; left: 5px; font-size: small;\">For Period: " + Args.StatementDate.ToShortDateString() + "</label>");
            sb.AppendLine("<label id=\"check_label\" style=\"position: absolute; font-size: small; top: 20px;\"><b>Checks and Payments</b></label>");
            sb.AppendLine("<label id=\"deposit_label\" style=\"position: absolute; font-size: small; top: 20px;\"><b>Deposits and Other Credits</b></label>");
            sb.AppendLine("<div id=\"checks_payments\" style=\"position: absolute; border-style: solid; border-width: thin; padding: 6px; overflow: scroll;\">");
            sb.AppendLine(GetChecksAndPayments((ContextRz)x));
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"deposits_credits\" style=\"position: absolute; border-style: solid; border-width: thin; padding: 6px; overflow: scroll;\">");
            sb.AppendLine(GetDepositsAndCredits((ContextRz)x));
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bottom_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 120px;\">");
            sb.Append("<input type=\"button\" id=\"unmarkAll\" value=\"Unmark All\" style=\"position: absolute; font-size: x-small; width: 80px;\" onclick=\"CheckUnCheck(false);Save('mark');\">&nbsp;&nbsp;&nbsp;");
            sb.Append("<input type=\"button\" id=\"markAll\" value=\"Mark All\" style=\"position: absolute; font-size: x-small; width: 80px;\" onclick=\"CheckUnCheck(true);Save('mark');\">");
            sb.AppendLine("<div id=\"begbalance_" + Uid + "\" style=\"position: absolute; top: 40px; height: 70px; width: 300px; font-size: small; border-style: solid; border-width: thin; padding: 6px;\">");            
            sb.AppendLine("Beginning Balance<br>");
            sb.AppendLine("Items you have marked as cleared<br>");
            lblBegBalance.Render(x, sb, screenHandle, viewHandle, session, page);
            lblDepositCount.Render(x, sb, screenHandle, viewHandle, session, page);
            lblPaymentCount.Render(x, sb, screenHandle, viewHandle, session, page);
            lblDepositAmount.Render(x, sb, screenHandle, viewHandle, session, page);
            lblPaymentAmount.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"reconcile_" + Uid + "\" style=\"position: absolute; top: 10px; height: 100px; width: 300px; font-size: small; border-style: solid; border-width: thin; padding: 6px;\">");
            sb.AppendLine("Service Charge<br>");
            sb.AppendLine("Interest Earned<br>"); 
            sb.AppendLine("Ending Balance<br>"); 
            sb.AppendLine("Cleared Balance<br>"); 
            sb.AppendLine("Difference<br>");
            lblServiceCharge.Render(x, sb, screenHandle, viewHandle, session, page);
            lblInterestEarned.Render(x, sb, screenHandle, viewHandle, session, page);
            lblEndingBalance.Render(x, sb, screenHandle, viewHandle, session, page);
            lblClearedBalance.Render(x, sb, screenHandle, viewHandle, session, page);
            lblDifference.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("<input type=\"button\" id=\"reconcileButton\" value=\"Reconcile\" style=\"font-size: x-small; width: 80px;\" onclick=\"Save('reconcile');\">");
            sb.AppendLine("</div>");
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
                case "mark":
                    CheckMarked(xrz, d, args.SourceView);
                    break;
                case "reconcile":
                    Reconcile(xrz, d, args.SourceView);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine("$('#bottom_" + Uid + "').css('top', $(window).height() - $('#bottom_" + Uid + "').height() - 22);");
            sb.AppendLine("$('#bottom_" + Uid + "').css('width', $('#top_" + Uid + "').width());");
            sb.AppendLine("$('#top_" + Uid + "').css('height', $('#bottom_" + Uid + "').position().top - $('#top_" + Uid + "').position().top - 16);");
            sb.AppendLine("$('#checks_payments').css('top', 35);");
            sb.AppendLine("$('#checks_payments').css('left', 5);");
            sb.AppendLine("$('#checks_payments').css('width', ($('#top_" + Uid + "').width() / 2) - 15);");
            sb.AppendLine("$('#checks_payments').css('height', $('#top_" + Uid + "').height() - $('#checks_payments').position().top - 5);");
            sb.AppendLine("$('#deposits_credits').css('top', 35);");
            sb.AppendLine("$('#deposits_credits').css('left', $('#checks_payments').position().left + $('#checks_payments').outerWidth(true) + 5);");
            sb.AppendLine("$('#deposits_credits').css('width', $('#top_" + Uid + "').width() - $('#deposits_credits').position().left - 5);");
            sb.AppendLine("$('#deposits_credits').css('height', $('#checks_payments').height());");
            sb.AppendLine("$('#deposit_label').css('left', $('#deposits_credits').position().left);");
            sb.AppendLine("$('#unmarkAll').css('top', 5);");
            sb.AppendLine("$('#unmarkAll').css('left', 5);");
            sb.AppendLine("$('#markAll').css('top', 5);");
            sb.AppendLine("$('#markAll').css('left', 90);");
            sb.AppendLine("$('#reconcile_" + Uid + "').css('left', $('#bottom_" + Uid + "').width() - $('#reconcile_" + Uid + "').width() - 5);");
            sb.AppendLine(lblBegBalance.Select + ".css('top', 5);");
            sb.AppendLine(lblBegBalance.Select + ".css('left', $('#begbalance_" + Uid + "').width() - " + lblBegBalance.Select + ".width());");
            sb.AppendLine(lblDepositCount.Select + ".css('top', 40);");
            sb.AppendLine(lblDepositCount.Select + ".css('left', 5);");
            sb.AppendLine(lblPaymentCount.Select + ".css('top', 55);");
            sb.AppendLine(lblPaymentCount.Select + ".css('left', 5);");
            sb.AppendLine(lblDepositAmount.Select + ".css('top', 40);");
            sb.AppendLine(lblDepositAmount.Select + ".css('left', $('#begbalance_" + Uid + "').width() - " + lblDepositAmount.Select + ".width());");
            sb.AppendLine(lblPaymentAmount.Select + ".css('top', 55);");
            sb.AppendLine(lblPaymentAmount.Select + ".css('left', $('#begbalance_" + Uid + "').width() - " + lblPaymentAmount.Select + ".width());");
            sb.AppendLine(lblServiceCharge.Select + ".css('top', 8);");
            sb.AppendLine(lblServiceCharge.Select + ".css('left', $('#reconcile_" + Uid + "').width() - " + lblServiceCharge.Select + ".width());");
            sb.AppendLine(lblInterestEarned.Select + ".css('top', 24);");
            sb.AppendLine(lblInterestEarned.Select + ".css('left', $('#reconcile_" + Uid + "').width() - " + lblInterestEarned.Select + ".width());");
            sb.AppendLine(lblEndingBalance.Select + ".css('top', 40);");
            sb.AppendLine(lblEndingBalance.Select + ".css('left', $('#reconcile_" + Uid + "').width() - " + lblEndingBalance.Select + ".width());");
            sb.AppendLine(lblClearedBalance.Select + ".css('top', 55);");
            sb.AppendLine(lblClearedBalance.Select + ".css('left', $('#reconcile_" + Uid + "').width() - " + lblClearedBalance.Select + ".width());");
            sb.AppendLine(lblDifference.Select + ".css('top', 70);");
            sb.AppendLine(lblDifference.Select + ".css('left', $('#reconcile_" + Uid + "').width() - " + lblDifference.Select + ".width());");
        }
        //Private Functions
        private string GetChecksAndPayments(ContextRz x)
        {
            Payments = new Dictionary<string, payment_out>();
            PaymentCheckboxes = new ArrayList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"1\" bordercolor=\"#000000\" width=\"100%\" cellspacing=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"1%\" bgcolor=\"#C0C0C0\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"18%\" bgcolor=\"#C0C0C0\">Date</td>");
            sb.AppendLine("    <td width=\"20%\" bgcolor=\"#C0C0C0\">Check/Ref. #</td>");
            sb.AppendLine("    <td width=\"41%\" bgcolor=\"#C0C0C0\">Payee</td>");
            sb.AppendLine("    <td width=\"20%\" bgcolor=\"#C0C0C0\">Amount</td>");
            sb.AppendLine("  </tr>");
            ArrayList a = x.QtC("payment_out", "select * from payment_out where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 0 order by date_created asc");
            foreach(payment_out p in a)
            {
                string r = "";
                if (p.check_number != 0)
                    r = p.check_number.ToString();
                if (!Tools.Strings.StrExt(r))
                    r = p.reference_number;
                string id = "check_payment_" + p.unique_id;
                PaymentCheckboxes.Add(id);
                Payments.Add(p.unique_id, p);
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"1%\"><input id=\"" + id + "\" type=\"checkbox\" name=\"" + id + "\" onclick=\"Save('mark');\"/></td>");
                sb.AppendLine("    <td width=\"18%\">" + p.date_created.ToShortDateString() + "&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">" + r + "&nbsp;</td>");
                sb.AppendLine("    <td width=\"41%\">" + p.vendor_name + "&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\" align=\"right\">" + Tools.Number.MoneyFormat(p.amount) + "&nbsp;</td>");
                sb.AppendLine("  </tr>  ");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        private string GetDepositsAndCredits(ContextRz x)
        {
            Deposits = new Dictionary<string, deposit>();
            DepositCheckboxes = new ArrayList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"1\" bordercolor=\"#000000\" width=\"100%\" cellspacing=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"1%\" bgcolor=\"#C0C0C0\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"18%\" bgcolor=\"#C0C0C0\">Date</td>");
            sb.AppendLine("    <td width=\"20%\" bgcolor=\"#C0C0C0\">Check/Ref. #</td>");
            sb.AppendLine("    <td width=\"41%\" bgcolor=\"#C0C0C0\">Memo</td>");
            sb.AppendLine("    <td width=\"20%\" bgcolor=\"#C0C0C0\">Amount</td>");
            sb.AppendLine("  </tr>");
            ArrayList a = x.QtC("deposit", "select * from deposit where account_uid = '" + Account.unique_id + "' and isnull(cleared,0) = 0");            
            foreach (deposit d in a)
            {
                string id = "check_deposit_" + d.unique_id;
                DepositCheckboxes.Add(id);
                Deposits.Add(d.unique_id, d);
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"1%\"><input id=\"" + id + "\" type=\"checkbox\" name=\"" + id + "\" onclick=\"Save('mark');\"/></td>");
                sb.AppendLine("    <td width=\"18%\">" + d.date_created.ToShortDateString() + "&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\">" + d.name + "&nbsp;</td>");
                sb.AppendLine("    <td width=\"41%\">" + d.description + "&nbsp;</td>");
                sb.AppendLine("    <td width=\"20%\" align=\"right\">" + Tools.Number.MoneyFormat(d.total_amount) + "&nbsp;</td>");
                sb.AppendLine("  </tr>  ");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        private void UpdateValues()
        {
            lblDepositCount.ValueSet(Tools.Number.LongFormat(DepCount) + "  Deposits and Other Credits");
            lblPaymentCount.ValueSet(Tools.Number.LongFormat(PayCount) + "  Checks and Payments");
            lblDepositAmount.ValueSet(Tools.Number.MoneyFormat(DepClear));
            lblPaymentAmount.ValueSet(Tools.Number.MoneyFormat(PayClear));
            lblClearedBalance.ValueSet(Tools.Number.MoneyFormat(ClearedBal));
            lblDifference.ValueSet(Tools.Number.MoneyFormat(Difference));
            lblDepositCount.Change();
            lblPaymentCount.Change();
            lblDepositAmount.Change();
            lblPaymentAmount.Change();
            lblClearedBalance.Change();
            lblDifference.Change();
        }
        private void Reconcile(ContextRz x, Dictionary<string, string> d, ViewHandle v)
        {
            Args.Difference = Difference;
            if (!Args.CheckDifference(x))
                return;
            foreach (KeyValuePair<string, string> kvp in d)
            {
                if (!kvp.Key.ToLower().StartsWith("check_"))
                    continue;
                if (Tools.Strings.StrCmp(kvp.Value, "false"))
                    continue;
                string type = Tools.Strings.ParseDelimit(kvp.Key.ToLower().Replace("check_", "").Trim(), "_", 1).Trim();
                string id = Tools.Strings.ParseDelimit(kvp.Key.ToLower().Replace("check_", "").Trim(), "_", 2).Trim();
                if (Tools.Strings.StrCmp("payment", type))
                {
                    payment_out p = null;
                    Payments.TryGetValue(id, out p);
                    if (p != null)
                    {
                        p.cleared = true;
                        p.Update(x);
                        Args.ClearedPayments.Add(p);
                    }
                }
                else
                {
                    deposit dd = null;
                    Deposits.TryGetValue(id, out dd);
                    if (dd != null)
                    {
                        dd.cleared = true;
                        dd.Update(x);
                        Args.ClearedDeposits.Add(dd);
                    }
                }
            }
            Account.SetLastReconcileDate(x, Args.StatementDate);
            x.TheSysRz.TheAccountLogic.ShowReconciliationReport(x, Args, false);
        }
        private void CheckMarked(ContextRz x, Dictionary<string, string> d, ViewHandle v)
        {
            PayClear = 0;
            DepClear = 0;
            PayCount = 0;
            DepCount = 0;
            foreach (KeyValuePair<string, string> kvp in d)
            {
                if (!kvp.Key.ToLower().StartsWith("check_"))
                    continue;                
                if (Tools.Strings.StrCmp(kvp.Value, "false"))
                    continue;                
                string type = Tools.Strings.ParseDelimit(kvp.Key.ToLower().Replace("check_", "").Trim(), "_", 1).Trim();
                string id = Tools.Strings.ParseDelimit(kvp.Key.ToLower().Replace("check_", "").Trim(), "_", 2).Trim();
                if (Tools.Strings.StrCmp("payment", type))
                {
                    PayCount++;
                    payment_out p = null;
                    Payments.TryGetValue(id, out p);
                    if (p != null)
                        PayClear += p.amount * -1;
                }
                else
                {
                    DepCount++;
                    deposit dd = null;
                    Deposits.TryGetValue(id, out dd);
                    if (dd != null)
                        DepClear += dd.total_amount;
                }
            }
            UpdateValues();
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function Save(action)");
            sb.AppendLine("{");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            foreach (string s in PaymentCheckboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("data += '|" + s + ":' + $('#" + s + "').is(':checked');");
            }
            foreach (string s in DepositCheckboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("data += '|" + s + ":' + $('#" + s + "').is(':checked');");
            }
            sb.AppendLine(ActionScript("action", "data"));
            sb.AppendLine("}");
            sb.AppendLine("function CheckUnCheck(c)");
            sb.AppendLine("{");
            foreach (string s in PaymentCheckboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("$('#" + s + "').prop('checked', c);");
            }
            foreach (string s in DepositCheckboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("$('#" + s + "').prop('checked', c);");
            }
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
        }
        private void AdjustControls()
        {
            lblBegBalance.TextFontSize = FontSize.Small;
            lblDepositCount.TextFontSize = FontSize.Small;
            lblPaymentCount.TextFontSize = FontSize.Small;
            lblDepositAmount.TextFontSize = FontSize.Small;
            lblPaymentAmount.TextFontSize = FontSize.Small;
            lblServiceCharge.TextFontSize = FontSize.Small;
            lblInterestEarned.TextFontSize = FontSize.Small;
            lblEndingBalance.TextFontSize = FontSize.Small;
            lblClearedBalance.TextFontSize = FontSize.Small;
            lblDifference.TextFontSize = FontSize.Small;
        }
    }    
}
