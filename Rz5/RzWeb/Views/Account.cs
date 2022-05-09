using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using Core;
using CoreWeb;
using NewMethod;
using NewMethodWeb;
using Rz5;
using Rz5.Web;
using System.Web.UI;

namespace RzWeb
{
    public class Account : _Item
    {
        //Public Variables
        public account TheAccount
        {
            get
            {
                return (account)Item;
            }
        }
        //Private Variables
        TextControl txtName;
        Int32Control txtNumber;
        ChoicesControl cboType;
        LabelControl lblBuiltIn;
        LabelControl lblCategory;
        TextControl txtBankNumber;
        TextControl txtRoutingNumber;
        TextControl txtDescription;
        TextControl txtCCNumber;
        ListViewSpotSubAccounts lvSubAccounts;
        AnchorControl aEdit;

        //Constructors
        public Account(ContextRz x, account a)
            : base(x, a)
        {
            txtName = (TextControl)SpotAdd(ControlAdd(new TextControl("name", "Name", TheAccount.name)));
            txtNumber = (Int32Control)SpotAdd(ControlAdd(new Int32Control("number", "Number", TheAccount.number)));
            cboType = (ChoicesControl)SpotAdd(ControlAdd(new ChoicesControl("type", "Type", TheAccount.type, GetTypeList(), "CheckShowBankExtra();")));
            cboType.DisableEdit = TheAccount.HasParent;
            string s = "";
            if (TheAccount.built_in)
            {
                s = "Built-In Account";
                txtName.DisableEdit = true;
                txtNumber.DisableEdit = true;
            }
            lblBuiltIn = (LabelControl)SpotAdd(ControlAdd(new LabelControl("builtin", "", s)));
            lblCategory = (LabelControl)SpotAdd(ControlAdd(new LabelControl("category", "Category", TheAccount.Category.ToString())));
            txtBankNumber = (TextControl)SpotAdd(ControlAdd(new TextControl("bank_account_number", "Bank Account #", TheAccount.GetExtra("bank_account_number"))));            
            txtRoutingNumber = (TextControl)SpotAdd(ControlAdd(new TextControl("routing_number", "Routing #", TheAccount.GetExtra("routing_number"))));
            txtCCNumber = (TextControl)SpotAdd(ControlAdd(new TextControl("cc_number", "Credit Card #", TheAccount.GetExtra("cc_account_number"))));            
            txtDescription = (TextControl)SpotAdd(ControlAdd(new TextControl("description", "Description", TheAccount.description)));
            aEdit = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aEdit", "[edit]", ActionScriptPlusControls("'edit_number'"))));
            lvSubAccounts = (ListViewSpotSubAccounts)SpotAdd(new ListViewSpotSubAccounts());
            lvSubAccounts.AllowExport = false;
            lvSubAccounts.ItemDoubleClicked += new ItemDoubleClickHandler(lvSubAccounts_ItemDoubleClicked);
            lvSubAccounts.AddNewItem += new ItemAddHandler(lvSubAccounts_AddNewItem);
            LoadLV(x);
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            return TheAccount.ToString();
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"account_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            txtName.Render(x, sb, screenHandle, viewHandle, session, page);
            txtNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            aEdit.Render(x, sb, screenHandle, viewHandle, session, page);
            cboType.Render(x, sb, screenHandle, viewHandle, session, page);
            lblBuiltIn.Render(x, sb, screenHandle, viewHandle, session, page);
            lblCategory.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescription.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"parent_account\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 55px; width: 400px;\">");
            sb.AppendLine("Parent Account");
            string parent_info = "";
            string change_info = "";
            account parent = TheAccount.GetParent((ContextRz)x);
            if (parent == null)
            {
                parent_info = "[No Parent Account]";
                change_info = "choose a parent account";
            }
            else
            {
                parent_info = parent.name;
                change_info = "clear this parent relationship";
            }
            sb.AppendLine("<label id=\"lblParent\" style=\"position: absolute; color: " + Tools.Html.GetHTMLColor(Color.Blue) + ";\">" + Tools.Html.ConvertTextToHTML(parent_info) + "</label>");
            sb.AppendLine("<a id=\"lblChangeParent\" style=\"position: absolute; font-size: x-small; text-decoration: none; color: grey;\" href=\"#\" onclick=\"" + ActionScript("'change_parent'") + "\" >" + change_info + "</a>");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"bankextra\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; margin-top: 20px; height: 125px; width: 215px;\">");
            txtBankNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            txtRoutingNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<input type=\"button\" id=\"startBalance\" value=\"Set Starting Balance\" style=\"position: absolute; font-size: small; width: 205px;\" onclick=\"" + ActionScriptPlusControls("'set_bank_balance'") + "\">");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"ccextra\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; margin-top: 20px; height: 80px; width: 215px;\">");
            txtCCNumber.Render(x, sb, screenHandle, viewHandle, session, page);            
            sb.AppendLine("<input type=\"button\" id=\"ccBalance\" value=\"Set Starting Balance\" style=\"position: absolute; font-size: small; width: 205px;\" onclick=\"" + ActionScriptPlusControls("'set_cc_balance'") + "\">");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                case "set_bank_balance":
                    SetStartingBalance((ContextRz)x, args);
                    break;
                case "change_parent":
                    ChangeParent((ContextRz)x, args);
                    break;
                case "type_changed":
                    TypeChanged((ContextRz)x, Tools.Html.FilterInput(args.ActionParams));
                    break;
                case "edit_number":
                    EditAccountNumber((ContextRz)x);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        //Protected Override Functions
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "account_" + Uid);
            sb.AppendLine("$('#account_" + Uid + "').css('height', 220);");
            sb.AppendLine("$('#account_" + Uid + "').css('width', (" + xActions.Select + ".position().left - $('#account_" + Uid + "').position().left) - 25);");
            sb.AppendLine(txtName.Select + ".css('top', 10);");
            sb.AppendLine(txtName.Select + ".css('left', 10);");
            sb.AppendLine(txtNumber.Select + ".css('top', 10);");
            sb.AppendLine(txtNumber.PlaceRight(txtName));
            sb.AppendLine(aEdit.Select + ".css('top', 10);");
            sb.AppendLine(aEdit.PlaceRight(txtNumber, false, 0, 33));
            sb.AppendLine(lblBuiltIn.Select + ".css('top', 10);");
            sb.AppendLine(lblBuiltIn.Select + ".css('left', 100);");
            sb.AppendLine(cboType.Select + ".css('left', 10);");
            sb.AppendLine(cboType.PlaceBelow(txtName));
            sb.AppendLine(lblCategory.PlaceBelow(txtName));
            sb.AppendLine(lblCategory.Select + ".css('left', " + txtNumber.Select + ".position().left);");
            sb.AppendLine("$('#bankextra').css('top', $('#account_" + Uid + "').position().top + 16);");            
            sb.AppendLine("$('#bankextra').css('left', $('#" + txtNumber.DivId + "').outerWidth(true) + $('#" + txtNumber.DivId + "').position().left + 26);");            
            sb.AppendLine(txtBankNumber.Select + ".css('top', 10);");
            sb.AppendLine(txtBankNumber.Select + ".css('left', 10);");
            sb.AppendLine(txtRoutingNumber.Select + ".css('left', 10);");
            sb.AppendLine(txtRoutingNumber.PlaceBelow(txtBankNumber));
            sb.AppendLine("$('#startBalance').css('left', 10);");
            sb.AppendLine("$('#startBalance').css('top', 105);");
            sb.AppendLine("$('#ccextra').css('top', $('#account_" + Uid + "').position().top + 16);");
            sb.AppendLine("$('#ccextra').css('left', $('#" + txtNumber.DivId + "').outerWidth(true) + $('#" + txtNumber.DivId + "').position().left + 26);");
            sb.AppendLine(txtCCNumber.Select + ".css('top', 10);");
            sb.AppendLine(txtCCNumber.Select + ".css('left', 10);");
            sb.AppendLine("$('#ccBalance').css('left', 10);");
            sb.AppendLine("$('#ccBalance').css('top', 60);");
            sb.AppendLine(txtDescription.Select + ".css('left', 10);");
            sb.AppendLine(txtDescription.PlaceBelow(cboType));
            sb.AppendLine("$('#parent_account').css('left', 5);");
            sb.AppendLine("$('#parent_account').css('top', $('#" + txtDescription.DivId + "').outerHeight(true) + $('#" + txtDescription.DivId + "').position().top);");
            sb.AppendLine("$('#lblParent').css('top', 25);");
            sb.AppendLine("$('#lblParent').css('left', 5);");
            sb.AppendLine("$('#lblChangeParent').css('left', 5);");
            PlaceDivBelowDiv(sb, "lblChangeParent", "lblParent");
            sb.AppendLine(lvSubAccounts.Select + ".css('left', 10);");
            sb.AppendLine(lvSubAccounts.Select + ".css('top', $('#account_" + Uid + "').outerHeight(true) + $('#account_" + Uid + "').position().top);");
            sb.AppendLine(lvSubAccounts.Select + ".css('width', (" + xActions.Select + ".position().left - " + lvSubAccounts.Select + ".position().left) - 25);");
            lvSubAccounts.RunToBottom(sb);
        }
        protected override void SaveData(Context x, SpotActArgs args, Dictionary<string, string> values)
        {
            if (TheAccount.Type != AccountType.Bank)
            {   //should we clear this?!?
                TheAccount.SetExtra("bank_account_number", "");
                TheAccount.SetExtra("routing_number", "");
            }
            else
            {
                string s = "";
                values.TryGetValue("bank_account_number", out s);
                TheAccount.SetExtra("bank_account_number", s);
                s = "";
                values.TryGetValue("routing_number", out s);
                TheAccount.SetExtra("routing_number", s);
            }
            if (TheAccount.Type != AccountType.CreditCard)
            {   //should we clear this?!?
                TheAccount.SetExtra("cc_account_number", "");                
            }
            else
            {
                string s = "";
                values.TryGetValue("cc_number", out s);
                TheAccount.SetExtra("cc_account_number", s);
            }            
            txtBankNumber.ValueSet(TheAccount.GetExtra("bank_account_number"));
            txtRoutingNumber.ValueSet(TheAccount.GetExtra("routing_number"));
            txtCCNumber.ValueSet(TheAccount.GetExtra("cc_account_number"));
        }
        //Private Functions
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function CheckShowBankExtra()");
            sb.AppendLine("{");
            sb.AppendLine("     var data = $('#" + cboType.ControlId + "').val();");
            sb.AppendLine("     if(data == 'Bank')");
            sb.AppendLine("         $('#bankextra').show();");
            sb.AppendLine("     else");
            sb.AppendLine("         $('#bankextra').hide();");
            sb.AppendLine("     if(data == 'Credit" + (char)160 + "Card' || data == 'Credit Card')");
            sb.AppendLine("         $('#ccextra').show();");
            sb.AppendLine("     else");
            sb.AppendLine("         $('#ccextra').hide();");
            sb.AppendLine("     " + ActionScript("'type_changed'", "data"));
            sb.AppendLine("     DoResize();");
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("CheckShowBankExtra();");
        }
        private void AdjustControls()
        {
            lblBuiltIn.TextFontSize = FontSize.Small;
            lblBuiltIn.TextForeColor = Color.Blue;
            txtDescription.FixedWidth = 408;
            txtNumber.ReadOnly = true;
            aEdit.TextFontSize = FontSize.Small;
        }
        private ArrayList GetTypeList()
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
            a.Add("Cost Of Goods Sold");
            a.Add("Income");
            a.Add("Expense");
            return a;
        }
        private void SetStartingBalance(ContextRz x, SpotActArgs args)
        {
            if (TheAccount.balance != 0)
            {
                x.Leader.Tell("The starting balance has already been configured for this account.");
                return;
            }
            SaveScreen(args.SourceView);
            TheAccount.SetStartingBankBalance(x);
            Change();
        }
        private void TypeChanged(ContextRz x, string t)
        {
            TheAccount.SetTypeAndCategory(t);
            lblCategory.ValueSet(TheAccount.Category.ToString());
            lblCategory.Change();
        }
        private void ChangeParent(ContextRz x, SpotActArgs args)
        {
            SaveScreen(args.SourceView);
            account parent = TheAccount.GetParent(x);
            if (parent == null)
            {
                parent = x.TheSysRz.TheAccountLogic.ChooseAnAccount(x, "Parent account for " + TheAccount.name, new AccountCriteria());
                if (parent == null)
                    return;
                if (Tools.Strings.StrCmp(parent.unique_id, TheAccount.unique_id))
                {
                    x.Leader.Tell("You cannot set an account to be it's own parent.");
                    return;
                }
                if (!x.Leader.AreYouSure("set " + parent.full_name + " as the parent account of " + TheAccount.name))
                    return;
                TheAccount.SetParent(parent);
                TheAccount.Update(x);
            }
            else
            {
                if (!x.Leader.AreYouSure("clear this account's relationship with " + parent.name))
                    return;
                TheAccount.ClearParent();
                TheAccount.Update(x);
            }
            cboType.DisableEdit = TheAccount.HasParent;
            Change();
        }
        private void LoadLV(ContextRz context)
        {
            lvSubAccounts.TheArgs = TheAccount.SubAccountArgs(context);
            lvSubAccounts.TheArgs.TheCaption = "Sub-Accounts";
            lvSubAccounts.TheArgs.AddAllow = true;
            lvSubAccounts.TheArgs.AddCaption = "Add New Sub-Account";
            lvSubAccounts.CurrentTemplate = n_template.GetByName(context, lvSubAccounts.TheArgs.TheTemplate);
            if (lvSubAccounts.CurrentTemplate == null)
                lvSubAccounts.CurrentTemplate = n_template.Create(context, lvSubAccounts.TheArgs.TheClass, lvSubAccounts.TheArgs.TheTemplate);
            lvSubAccounts.CurrentTemplate.GatherColumns(context);
            lvSubAccounts.ColSource = new ColumnSourceTemplate(lvSubAccounts.CurrentTemplate);
            lvSubAccounts.RowSource = new RowSourceTable(context.Select(lvSubAccounts.TheArgs.RenderSql(context, lvSubAccounts.CurrentTemplate)));
            lvSubAccounts.Change();
        }
        private void EditAccountNumber(ContextRz x)
        {
            TheAccount.number = account.EditAccountNumber(x, TheAccount);
            TheAccount.Update(x);
            txtNumber.ValueSet(TheAccount.number);
            txtNumber.Change();
        }
        private void lvSubAccounts_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            account acnt = (account)item;
            if (acnt == null)
                return;
            x.Show(acnt);
        }
        private void lvSubAccounts_AddNewItem(Context x, Page page, ViewHandle viewHandle)
        {
            SaveScreen(viewHandle, true);
            account a = account.CreateNewAccount((ContextRz)x, TheAccount.unique_id);
            if (a == null)
                return;
            x.Show(a);
            LoadLV((ContextRz)x);
        }
    }
    public class ListViewSpotSubAccounts : ListViewSpotRz
    {
        public ListViewSpotSubAccounts()
            : base("account")
        {
        }
    }
}