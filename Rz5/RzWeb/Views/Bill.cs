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

namespace RzWeb
{
    public class Bill : _Item
    {
        public ordhed_purchase TheBill
        {
            get
            {
                return (ordhed_purchase)Item;
            }
        }
        orddet_line TheBillLine;
        ListViewSpotDetails lvDetails;
        LabelControl lblBill;
        LabelControl lblOrderNumber;
        CompanyContactControl xCompany;
        LabelControl lblOrderDate;
        LabelControl txtOrderDate;
        AnchorControl aChangeDate;
        AgentControl agentSalesAgent;
        TextAreaControl txtInternalComment;
        LabelControl lblTotalsCap;
        AnchorControl cmdPost;
        ComboBoxControl cboCC;
        ComboBoxControl cboAccount;
        TextControl txtItem;
        Int32Control txtQuantity;
        MoneyControl txtCost;
        AnchorControl cmdOK;
        ViewHandle TheView;

        //Constructors
        public Bill(ContextRz x, ordhed_purchase i)
            : base(x, i)
        {
            TheBill.CalculateAllAmounts(x);
            TheBill.trackingnumber = TheBill.TrackingNumbersGet(x);
            lblBill = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblBill", "", TheBill.FriendlyOrderType)));
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", TheBill.ordernumber)));
            lblTotalsCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTotalsCap", "", "Totals")));
            lblOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderDate", "", "Order Date")));
            txtOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("txtOrderDate", "", TheBill.orderdate.ToString())));
            aChangeDate = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChangeDate", "change date", ActionScript("'change_date'"))));
            ArrayList agents = GetAgentArray(x);
            agentSalesAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("base_mc_user_uid|agentname", "Sales Agent", TheBill.base_mc_user_uid, TheBill.agentname, "base_mc_user_uid", "agentname", agents)));
            txtInternalComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comment", TheBill.internalcomment)));
            cmdPost = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdPost", "Post", "Action('post');", "null")));
            cboCC = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboCC", "Credit Card", "", GetCCList(x))));
            //Bill Line Entry
            string val = "";
            if (TheBill.is_credit)
            {
                cboAccount.IncludeBlankOption = false;
                val = "Accounts Payable";
            }
            cboAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboAccount", "Account", val, GetAccountList(x))));
            txtItem = (TextControl)SpotAdd(ControlAdd(new TextControl("txtItem", "Item", "")));
            txtQuantity = (Int32Control)SpotAdd(ControlAdd(new Int32Control("txtQuantity", "Quantity", 0)));
            txtCost = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("txtCost", "Unit Cost", 0)));
            cmdOK = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("cmdOK", "OK", "Action('ok');", "null")));
            //Bill Line Entry
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("base_company_uid|companyname|base_companycontact_uid|contactname", "Customer", TheBill.base_company_uid, TheBill.companyname, "base_company_uid", "companyname", TheBill.base_companycontact_uid, TheBill.contactname, "base_companycontact_uid", "contactname")));
            xCompany.CompanyChanged += new CompanyChangedHandler(xCompany_CompanyChanged);
            xCompany.ContactChanged += new ContactChangedHandler(xCompany_ContactChanged);
            lvDetails = (ListViewSpotDetails)SpotAdd(new ListViewSpotDetails());
            lvDetails.SkipParentRender = true;            
            lvDetails.TheArgs = TheBill.DetailArgsGet(Context);
            lvDetails.TheArgs.LiveItems = TheBill.DetailsVar.RefsGetAsItems(Context);
            lvDetails.CurrentTemplate = n_template.GetByName(x, lvDetails.TheArgs.TheTemplate);
            if (lvDetails.CurrentTemplate == null)
                lvDetails.CurrentTemplate = n_template.Create(x, lvDetails.TheArgs.TheClass, lvDetails.TheArgs.TheTemplate);
            lvDetails.CurrentTemplate.GatherColumns(x);
            lvDetails.ColSource = new ColumnSourceTemplate(lvDetails.CurrentTemplate);
            lvDetails.RowSource = new RowSourceItem(lvDetails.TheArgs.LiveItems.AllGet(Context));
            lvDetails.ItemDoubleClicked += new ItemDoubleClickHandler(lvDetails_ItemDoubleClicked);
            lvDetails.AddNewItem += new ItemAddHandler(lvDetails_AddNewItem);
            lvDetails.MenuActionClicked += new MenuActionHandler(lvDetails_MenuActionClicked);
            AdjustControls();
        }
        //Public Override Functions
        public override String Title(Context x)
        {
            string s = "Bill";
            if (TheBill != null)
                s = TheBill.ToString();
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            string s = "";
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"viewinvoice_" + Uid + "\" style=\"position: absolute; top: 0px;\">");
            sb.AppendLine("        <div id=\"ordernumber_info_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"padding: 6px; height: 2px; width: 350px;\">");
            lblBill.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<a id=\"aChangeOrderNumber\" href=\"#\" style=\"position: absolute; top: 8px; text-decoration: none; font-size: xx-small;\" onclick=\"" + ActionScript("'change_ordernumber'", "''") + "\"><font color=\"#C0C0C0\">change</font></a>");
            sb.AppendLine("        </div>");
            cmdPost.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCC.Render(x, sb, screenHandle, viewHandle, session, page);
            s = "";
            sb.AppendLine("        <div id=\"totals_box_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; top: 0px; padding: 6px; height: 50px; width: 228px; " + s + " \">");
            lblTotalsCap.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        </div>");
            //tabs
            sb.AppendLine("        <div id=\"tabHeader_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabHeaderNav\">");
            sb.AppendLine("                <li><a href=\"#tabCompany\" style=\"font-size: xx-small\">Company</a></li>");
            sb.AppendLine("                <li><a href=\"#tabNotes\" style=\"font-size: xx-small\">Notes</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabCompany\">");
            RenderCompanyTab(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabNotes\">");
            txtInternalComment.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            lvDetails.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <div id=\"bill_line_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; top: 0px; padding: 6px; height: 35px;\">");
            cboAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            txtItem.Render(x, sb, screenHandle, viewHandle, session, page);
            txtQuantity.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCost.Render(x, sb, screenHandle, viewHandle, session, page);
            cmdOK.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        </div>");
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
                case "change_date":
                    ChangeOrderDate((ContextRz)x, TheBill.orderdate.ToString());
                    break;
                case "change_ordernumber":
                    ChangeOrderNumber((ContextRz)x);
                    break;
                case "post":
                    DoPost((ContextRz)x, args.SourceView);
                    break;
                case "ok":
                    DoOK((ContextRz)x, args.SourceView);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        //Protected Override Functions
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('top', $('#rz_menu').height() + $('#rz_menu').position().top + 10);");
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('height', $(window).height() - $('#viewinvoice_" + Uid + "').position().top);");
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('width', " + xActions.Select + ".position().left - $('#viewinvoice_" + Uid + "').position().left - 15);");
            sb.AppendLine(lblOrderNumber.PlaceRight(lblBill, false, 10, 0));
            sb.AppendLine("$('#aChangeOrderNumber').css('left', " + lblOrderNumber.Select + ".position().left + $('#" + lblOrderNumber.InnerDivId + "').width() + 22);");
            sb.AppendLine("$('#totals_box_" + Uid + "').css('left', $('#ordernumber_info_" + Uid + "').width() + $('#ordernumber_info_" + Uid + "').position().left + " + Screen.LayoutTheta.ToString() + " + 13);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('top', $('#ordernumber_info_" + Uid + "').position().top + $('#ordernumber_info_" + Uid + "').height() + 20);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', $('#ordernumber_info_" + Uid + "').width() + 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', 120);");//245
            sb.AppendLine(cmdPost.Select + ".css('top', 5);");
            sb.AppendLine(cmdPost.Select + ".css('left', $('#ordernumber_info_" + Uid + "').width() + 20);");
            sb.AppendLine(cboCC.Select + ".css('top', 0);");
            sb.AppendLine(cboCC.PlaceRight(cmdPost, false, 10));
            sb.AppendLine("$('#totals_box_" + Uid + "').css('top', $('#tabHeader_" + Uid + "').position().top + $('#tabHeader_" + Uid + "').height() - $('#totals_box_" + Uid + "').height() - 9);");
            sb.AppendLine(lvDetails.Select + ".css('left', 5);");
            sb.AppendLine(lvDetails.Select + ".css('top', $('#tabHeader_" + Uid + "').position().top + $('#tabHeader_" + Uid + "').height() + 20);");
            sb.AppendLine(lvDetails.Select + ".css('width', " + xActions.Select + ".position().left - " + lvDetails.Select + ".position().left - 10);");
            sb.AppendLine("$('#bill_line_" + Uid + "').css('top', $('#viewinvoice_" + Uid + "').height() - $('#bill_line_" + Uid + "').height() - 18);");
            sb.AppendLine("$('#bill_line_" + Uid + "').css('width', " + lvDetails.Select + ".width() - 10);");
            lvDetails.RunToBottomExcept(sb, "bill_line_" + Uid);
            sb.AppendLine(lblOrderDate.Select + ".css('top', 10);");
            sb.AppendLine(xCompany.Select + ".css('top', 10);");
            sb.AppendLine(xCompany.Select + ".css('left', 2);");
            sb.AppendLine(xCompany.Select + ".css('width', 175);");
            sb.AppendLine(xCompany.Select + ".css('height', 80);");
            sb.AppendLine(lblOrderDate.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left + 18);");
            sb.AppendLine(txtOrderDate.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left);");
            sb.AppendLine(aChangeDate.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left + 33);");
            sb.AppendLine(txtOrderDate.PlaceBelow(lblOrderDate));
            sb.AppendLine(aChangeDate.PlaceBelow(lblOrderDate, false, 13, 0));
            sb.AppendLine(agentSalesAgent.PlaceBelow(aChangeDate));
            sb.AppendLine(agentSalesAgent.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left);");
            sb.AppendLine(txtInternalComment.Select + ".css('top', 10);");
            sb.AppendLine(txtInternalComment.Select + ".css('left', 10);");
            sb.AppendLine(cboAccount.Select + ".css('left', 5);");
            sb.AppendLine(txtItem.PlaceRight(cboAccount));
            sb.AppendLine(txtQuantity.PlaceRight(txtItem));
            sb.AppendLine(txtCost.PlaceRight(txtQuantity));
            sb.AppendLine(cmdOK.PlaceRight(txtCost));
            sb.AppendLine(cmdOK.Select + ".css('top', 16);");
        }
        //Private Functions
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function Action(act) {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("act", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            if (!TheBill.is_credit_card)
                viewHandle.ScriptsToRun.Add("HideDiv('" + cboCC.DivId + "');");
            viewHandle.ScriptsToRun.Add("HideDiv('bill_line_" + Uid + "');");
            viewHandle.ScriptsToRun.Add("$('#tabHeader_" + Uid + "').tabs( { select: function(event, ui) { " + ActionScript("'tabShow'", "ui.panel.id") + " } });");
        }
        private void AdjustControls()
        {
            lblBill.AddPadding(GenAlign.Left, 20);
            lblOrderNumber.AddPadding(GenAlign.Left, 20);
            lblBill.AddPadding(GenAlign.Top, 1);
            lblOrderNumber.AddPadding(GenAlign.Top, 1);
            lblTotalsCap.AddPadding(GenAlign.Top, 5);
            lblTotalsCap.AddPadding(GenAlign.Left, 5);
            lblOrderDate.TextFontSize = FontSize.Small;
            lblOrderDate.TextBold = true;
            txtOrderDate.FixedWidth = 140;
            txtOrderDate.TextFontSize = FontSize.XXSmall;
            txtOrderDate.TextBold = true;
            txtOrderDate.TextForeColor = Color.Blue;
            txtOrderDate.TxtAlign = TextAlign.Center;
            txtOrderDate.RemoveBorder = true;
            txtOrderDate.DisableEdit = true;
            aChangeDate.TextFontSize = FontSize.XXSmall;
            agentSalesAgent.TextFontSize = FontSize.XSmall;
            agentSalesAgent.LabelFontSize = FontSize.XSmall;
            txtInternalComment.CaptionFontSize = FontSize.XSmall;
            txtInternalComment.TextFontSize = FontSize.XSmall;
            txtInternalComment.FixedWidth = 330;
            txtInternalComment.Rows = 3;
            xCompany.TextFontSize = FontSize.XSmall;
            lvDetails.ExtraStyle = "; font-size: small";
            cmdPost.ButtonTopPadding = 0;
            cmdOK.ButtonTopPadding = 0;
        }
        private void RenderCompanyTab(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            xCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderDate.Render(x, sb, screenHandle, viewHandle, session, page);
            txtOrderDate.Render(x, sb, screenHandle, viewHandle, session, page);
            aChangeDate.Render(x, sb, screenHandle, viewHandle, session, page);
            agentSalesAgent.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private void ChangeOrderDate(ContextRz x, string date)
        {
            TheBill.DateChange(x);
            txtOrderDate.ValueSet(TheBill.orderdate.ToString());
            txtOrderDate.Change();
        }
        private void ChangeOrderNumber(ContextRz x)
        {
            TheBill.NumberChange(x);
            lblOrderNumber.ValueSet(TheBill.ordernumber);
            Change();
        }
        private ArrayList GetAgentArray(ContextRz x)
        {
            ArrayList a = new ArrayList();
            foreach (Rz5.n_user u in x.xSys.Users.All)
            {
                a.Add(u.name);
            }
            return a;
        }
        private ArrayList GetAccountList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            if (TheBill.is_credit)
            {
                a.Add("Accounts Payable");
                return a;
            }
            AccountCriteria ac = new AccountCriteria();
            ac.Types.Add(AccountType.Expense);
            ac.Types.Add(AccountType.OtherExpense);
            ac.Types.Add(AccountType.FixedAssets);
            if (TheBill.is_credit_card)
                ac.Types.Add(AccountType.CostOfGoodsSold);
            foreach (account aa in x.Accounts.GetAccounts(x, ac))
            {
                a.Add(aa.full_name);
            }
            return a;
        }
        private ArrayList GetCCList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            foreach (account aa in x.Accounts.GetAccounts(x, new AccountCriteria(AccountType.CreditCard)))
            {
                a.Add(aa.full_name);
            }
            return a;
        }
        private void DoPost(ContextRz x, ViewHandle viewHandle)
        {
            //do post logic
        }
        private void DoOK(ContextRz x, ViewHandle viewHandle)
        {
            //save bill line
            HideBillLine(x, viewHandle);
        }
        private void ShowBillLine(ContextRz x, ViewHandle viewHandle)
        {
            if (TheBillLine == null)
            {
                HideBillLine(x, viewHandle);
                return;
            }
            SetBillLine(TheBillLine);
            viewHandle.ScriptsToRun.Add("ShowDiv('bill_line_" + Uid + "');");
        }
        private void HideBillLine(ContextRz x, ViewHandle viewHandle)
        {
            TheBillLine = null;
            SetBillLine(new orddet_line());
            viewHandle.ScriptsToRun.Add("HideDiv('bill_line_" + Uid + "');");
        }
        private void SetBillLine(orddet_line l)
        {
            cboAccount.ValueSet(l.purchase_expense_account_name);
            txtItem.ValueSet(l.fullpartnumber);
            txtQuantity.ValueSet(l.quantity);
            txtCost.ValueSet(l.unit_cost);
            cboAccount.Change();
            txtItem.Change();
            txtQuantity.Change();
            txtCost.Change();
        }
        //Control Events
        private void xCompany_CompanyChanged(ContextNM x, company c, ViewHandle v)
        {
            if (c == null)
                return;
            TheBill.CompanyVar.RefSet(x, c);
            TheBill.AbsorbCompany((ContextRz)x, c);
            TheBill.Update(x);
            xCompany.ContactID = "";
            xCompany.ContactName = "";
            xCompany.Change();
        }
        private void xCompany_ContactChanged(ContextNM x, companycontact c, ViewHandle v)
        {
            if (c == null)
                return;
            TheBill.ContactVar.RefSet(x, c);
            TheBill.Update(x);
        }
        private void lvDetails_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            TheBillLine = (orddet_line)TheBill.GetNewDetail((ContextRz)x);
            ShowBillLine((ContextRz)x, viewHandle);
        }
        private void lvDetails_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_line d = null;
            try { d = (orddet_line)item; }
            catch { }
            if (d == null)
                return;
            TheBillLine = d;
            ShowBillLine((ContextRz)x, viewHandle);            
        }
        private void lvDetails_MenuActionClicked(Context x, ActArgs args, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            args.Handled = true;
        }
    }
}
