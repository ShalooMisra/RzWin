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

namespace RzWeb
{
    public class Deposits : RzScreen
    {
        //Private Variables
        account TheAccount;
        ArrayList Checkboxes = new ArrayList();
        ComboBoxControl cboAccount;
        LabelControl lblTotalDeposits;
        TextControl txtMemo;

        //Constructors
        public Deposits(Rz5.ContextRz context)
            : base(context)
        {
            cboAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboAccount", "Bank Account", "", GetBankAccounts(context), "Save('account_changed');")));
            lblTotalDeposits = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTotalDeposits", "Total Deposits:", "0.00")));
            txtMemo = (TextControl)SpotAdd(ControlAdd(new TextControl("txtMemo", "Memo", "")));
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return "Make Deposits";
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"top_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 90px;\">");
            cboAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            lblTotalDeposits.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMemo.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("<input type=\"button\" id=\"refreshButton\" value=\"Refresh\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'refresh'") + "\">");
            Buttonize(viewHandle, "refreshButton", "RefreshBlue3.png");
            sb.Append("<input type=\"button\" id=\"newButton\" value=\"New\" style=\"font-size: x-small; width: 80px;\" onclick=\"" + ActionScript("'new'") + "\">");
            Buttonize(viewHandle, "newButton", "add_32.png");
            sb.Append("<input type=\"button\" id=\"saveButton\" value=\"Save\" style=\"font-size: x-small; width: 80px;\" onclick=\"Save('save');\">");
            Buttonize(viewHandle, "saveButton", "GreenCheck.png");
            sb.AppendLine("<label id=\"warning\" style=\"position: absolute; top: 30px; color: Red; font-size: meduim;\"></label>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bottom_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; overflow: scroll;\">");
            sb.AppendLine(ShowLV((ContextRz)x));
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
                case "check_changed":
                case "check_screen":
                    CheckScreen(xrz, d, args.SourceView);
                    break;
                case "account_changed":
                    AccountChanged(xrz, d, args.SourceView);
                    break;
                case "refresh":
                    Refresh();                    
                    break;
                case "new":
                    xrz.Leader.ReceivePaymentsShow(xrz, null);
                    break;
                case "save":
                    Save(xrz, d);
                    break;
            }
        }
        //Protected Override Functions
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "top_" + Uid);
            RunDivToRight(sb, "top_" + Uid);
            sb.AppendLine(cboAccount.Select + ".css('top', 5);");
            sb.AppendLine(cboAccount.Select + ".css('left', 5);");
            sb.AppendLine(lblTotalDeposits.Select + ".css('top', 5);");
            sb.AppendLine(lblTotalDeposits.PlaceRight(cboAccount, false, 10));
            sb.AppendLine(txtMemo.Select + ".css('left', 5);");
            sb.AppendLine(txtMemo.PlaceBelow(cboAccount));
            sb.AppendLine("$('#refreshButton').css('left', 500);");
            sb.AppendLine("$('#newButton').css('left', 510);");
            sb.AppendLine("$('#saveButton').css('left', 200);");
            sb.AppendLine("$('#saveButton').css('top', 35);");
            sb.AppendLine("$('#warning').css('left', 460);");
            sb.AppendLine("$('#warning').css('top', 75);");
            PlaceDivBelowDiv(sb, "bottom_" + Uid, "top_" + Uid);
            RunDivToBottom(sb, "bottom_" + Uid);
            RunDivToRight(sb, "bottom_" + Uid);
        }
        //Private Functions
        private void CheckScreen(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {            
            viewHandle.ScriptsToRun.Add("HideDiv('saveButton');");
            Double total = GetDepositTotal(x, d);
            lblTotalDeposits.ValueSet("Total Deposit: " + Tools.Number.MoneyFormat(total));
            lblTotalDeposits.Change();
            if (TheAccount == null)
            {
                Warning("Select a bank account.", viewHandle);                
                return;
            }
            string s = "";
            d.TryGetValue("txtMemo", out s);
            if (!Tools.Strings.StrExt(s))
            {
                Warning("Enter a memo.", viewHandle);
                return;
            }
            if (total == 0)
                Warning("Select at least 1 payment to deposit.", viewHandle);
            else
            {
                Warning("", viewHandle);
                viewHandle.ScriptsToRun.Add("ShowDiv('saveButton');");
            }
        }
        private void AccountChanged(ContextRz x, Dictionary<string, string> d, ViewHandle viewHandle)
        {
            string s = "";
            d.TryGetValue("cboAccount", out s);
            if (!Tools.Strings.StrExt(s))
                return;            
            TheAccount = account.GetByFullName(x, account.GetAccountFullNameStripBullet(s));
            CheckScreen(x, d, viewHandle);
        }
        private void Save(ContextRz x, Dictionary<string, string> d)
        {
            try
            {
                string s = "";
                d.TryGetValue("txtMemo", out s);
                deposit.MakeDeposit(x, TheAccount, GetSelectedPayments(x, d), s);
                Change();
            }
            catch (Exception ex)
            {
                x.Leader.Tell("Error: " + ex.Message);
            }
        }
        private void Refresh()
        {
            TheAccount = null;
            txtMemo.ValueSet("");
            Change();
        }
        private string ShowLV(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table border=\"0\" width=\"100%\" cellspacing=\"0\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"2%\" bgcolor=\"#C0C0C0\">&nbsp;</td>");
            sb.AppendLine("    <td width=\"23%\" bgcolor=\"#C0C0C0\"><b>Date</b></td>");
            sb.AppendLine("    <td width=\"26%\" bgcolor=\"#C0C0C0\"><b>Company</b></td>");
            sb.AppendLine("    <td width=\"29%\" bgcolor=\"#C0C0C0\"><b>Memo</b></td>");
            sb.AppendLine("    <td width=\"20%\" bgcolor=\"#C0C0C0\"><b>Amount</b></td>");
            sb.AppendLine("  </tr>");
            Checkboxes = new ArrayList();
            foreach (payment_in p in deposit.ListPayments(context))
            {
                sb.AppendLine("  <tr>");
                string id = "check_" + p.unique_id;
                Checkboxes.Add(id);
                sb.AppendLine("    <td width=\"2%\"><input id=\"" + id + "\" type=\"checkbox\" name=\"" + id + "\" onclick=\"Save('check_changed');\"/></td>");
                sb.AppendLine("    <td width=\"23%\">" + Tools.Dates.DateFormat(p.date_created) + "</td>");
                sb.AppendLine("    <td width=\"26%\">" + p.customer_name + "</td>");
                sb.AppendLine("    <td width=\"29%\">" + p.description + "</td>");
                sb.AppendLine("    <td width=\"20%\">" + Tools.Number.MoneyFormat(p.amount) + "</td>");
                sb.AppendLine("  </tr>  ");
            }
            sb.AppendLine("</table>");
            return sb.ToString();
        }
        private double GetDepositTotal(ContextRz x, Dictionary<string, string> d)
        {
            double total = 0;
            foreach (KeyValuePair<string, string> kvp in d)
            {
                if (!kvp.Key.ToLower().StartsWith("check_"))
                    continue;
                if (!Tools.Strings.StrCmp(kvp.Value, "true"))
                    continue;
                string id = kvp.Key.Replace("check_", "").Trim();
                if (!Tools.Strings.StrExt(id))
                    continue;
                foreach (payment_in p in deposit.ListPayments(x))
                {
                    if (Tools.Strings.StrCmp(id, p.unique_id))
                    {
                        total += p.amount;
                        break;
                    }
                }
            }
            return total;
        }
        private ArrayList GetBankAccounts(ContextRz x)
        {
            List<account> l = x.TheSysRz.TheAccountLogic.GetAccounts(x, new AccountCriteria(AccountType.Bank));
            ArrayList a = new ArrayList();
            foreach (account aa in l)
            {
                if (Tools.Strings.StrCmp("Undeposited Funds", aa.full_name))
                    continue;
                a.Add(account.GetAccountFullNameWithBullet(aa));
            }
            return a;
        }
        private List<payment_in> GetSelectedPayments(ContextRz x, Dictionary<string, string> d)
        {
            List<payment_in> l = new List<payment_in>();
            foreach (KeyValuePair<string, string> kvp in d)
            {
                if (!kvp.Key.ToLower().StartsWith("check_"))
                    continue;
                if (!Tools.Strings.StrCmp(kvp.Value, "true"))
                    continue;
                string id = kvp.Key.Replace("check_", "").Trim();
                if (!Tools.Strings.StrExt(id))
                    continue;
                foreach (payment_in p in deposit.ListPayments(x))
                {
                    if (Tools.Strings.StrCmp(id, p.unique_id))
                    {
                        l.Add(p);
                        break;
                    }
                }
            }
            return l;
        }
        private void Warning(string text, ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#warning').text('" + text + "');");
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
            foreach (string s in Checkboxes)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                sb.AppendLine("data += '|" + s + ":' + $('#" + s + "').is(':checked');");
            }
            sb.AppendLine(ActionScript("action", "data"));
            sb.AppendLine("}");
            sb.AppendLine(txtMemo.Select + ".focusout(function()");
            sb.AppendLine("{");
            sb.AppendLine("     Save('check_screen');");
            sb.AppendLine("});");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("Save('check_screen');");
        }
        private void AdjustControls()
        {
            lblTotalDeposits.CaptionInLine = true;
            txtMemo.FixedWidth = 350;
            cboAccount.ReadOnly = true;
        }
    }    
}
