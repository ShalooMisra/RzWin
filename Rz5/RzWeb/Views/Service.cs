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
    public class Service : _Item
    {
        public ordhed_service TheService
        {
            get
            {
                return (ordhed_service)Item;
            }
        }
        private service_line TheServiceLine;
        ListViewSpotDetails lvDetails;
        ListViewSpotServices lvServices;
        LabelControl lblInvoice;
        LabelControl lblOrderNumber;
        LabelControl lblStatus;
        LabelControl lblTotalsCap;
        LabelControl lblSubTotalCap;
        LabelControl lblSubTotal;
        LabelControl lblShipping;
        MoneyControl txtShipping;
        LabelControl lblOrderTotalCap;
        LabelControl lblOrderTotal;
        LabelControl lblOrderDate;
        LabelControl txtOrderDate;
        AnchorControl aChangeDate;
        AgentControl agentSalesAgent;
        TextControl txtPhone;
        TextControl txtFax;
        TextControl txtEmail;
        RzWeb.ChoicesControl cboTerms;
        RzWeb.ChoicesControl cboShipVia;
        TextAreaControl txtInternalComment;
        TextAreaControl txtPrintComment;
        CompanyContactControl xCompany;
        TextAreaControl txtBillingAdr;
        TextAreaControl txtShippingAdr;
        TextAreaControl txtTracking;
        RzWeb.ChoicesControl cboShippingAccount;
        ComboBoxControl cboBillingAdr;
        ComboBoxControl cboShippingAdr;
        TextControl txtService;
        Int32Control txtServiceQty;
        MoneyControl txtServiceCost;
        ViewHandle TheView;

        public Service(ContextRz x, ordhed_service i)
            : base(x, i)
        {
            TheService.CalculateAllAmounts(x);
            TheService.trackingnumber = TheService.TrackingNumbersGet(x);
            lblInvoice = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblInvoice", "", TheService.FriendlyOrderType)));
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", TheService.ordernumber)));
            string status = GetStatus(x);
            lblStatus = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStatus", "", status)));
            lblTotalsCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTotalsCap", "", "Totals")));
            lblSubTotalCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSubTotalCap", "", "Sub Total:")));
            lblSubTotal = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSubTotal", "", x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheService.sub_total))));
            lblShipping = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblShipping", "", "Extra:")));
            txtShipping = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("shippingamount", "", TheService.shippingamount, x.TheSys.CurrencySymbol)));
            lblOrderTotalCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderTotalCap", "", "Total:")));
            lblOrderTotal = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderTotal", "", x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheService.ordertotal))));
            lblOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderDate", "", "Order Date")));
            txtOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("txtOrderDate", "", TheService.orderdate.ToString())));
            aChangeDate = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChangeDate", "change date", ActionScript("'change_date'"))));
            ArrayList agents = GetAgentArray(x);
            agentSalesAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("base_mc_user_uid|agentname", "Sales Agent", TheService.base_mc_user_uid, TheService.agentname, "base_mc_user_uid", "agentname", agents)));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphone", "Phone", TheService.primaryphone)));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryfax", "Fax", TheService.primaryfax)));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryemailaddress", "Email", TheService.primaryemailaddress)));
            txtInternalComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comment", TheService.internalcomment)));
            txtPrintComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("printcomment", "Print Comment", TheService.printcomment)));
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("base_company_uid|companyname|base_companycontact_uid|contactname", "Customer", TheService.base_company_uid, TheService.companyname, "base_company_uid", "companyname", TheService.base_companycontact_uid, TheService.contactname, "base_companycontact_uid", "contactname")));
            xCompany.CompanyChanged += new CompanyChangedHandler(xCompany_CompanyChanged);
            xCompany.ContactChanged += new ContactChangedHandler(xCompany_ContactChanged);
            cboTerms = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("terms", "Terms", TheService.terms, GetChoiceList(x, "terms"), "", "terms")));
            cboShipVia = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shipvia", "Ship Via", TheService.shipvia, GetChoiceList(x, "shipvia"), "", "shipvia")));
            //Address Info
            txtBillingAdr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("billingaddress", "Billing Address", TheService.billingaddress)));
            txtShippingAdr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("shippingaddress", "Shipping Address", TheService.shippingaddress)));
            txtTracking = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("trackingnumber", "Tracking Numbers", TheService.trackingnumber)));
            txtTracking.DisableEdit = true;
            cboShippingAccount = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shippingaccount", "Shipping Account", TheService.shippingaccount, LoadAccountList(x), "", "null")));
            cboBillingAdr = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboBillingAdr", "", "", LoadAddressList(x))));
            cboBillingAdr.OnChange = ActionScript("'billing_changed'", "$('#" + cboBillingAdr.ControlId + "').val()");
            cboBillingAdr.IgnoreOnSave = true;
            cboShippingAdr = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboShippingAdr", "", "", LoadAddressList(x))));
            cboShippingAdr.OnChange = ActionScript("'shipping_changed'", "$('#" + cboShippingAdr.ControlId + "').val()");
            cboShippingAdr.IgnoreOnSave = true;
            txtService = (TextControl)SpotAdd(ControlAdd(new TextControl("txtService", "Service Name", "")));
            txtServiceQty = (Int32Control)SpotAdd(ControlAdd(new Int32Control("txtServiceQty", "Quantity", 0)));
            txtServiceCost = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("txtServiceCost", "Cost", 0)));
            lvDetails = (ListViewSpotDetails)SpotAdd(new ListViewSpotDetails());
            lvDetails.SkipParentRender = true;
            lvDetails.TheArgs = TheService.DetailArgsGet(Context);
            lvDetails.TheArgs.LiveItems = TheService.DetailsVar.RefsGetAsItems(Context);
            lvDetails.CurrentTemplate = n_template.GetByName(x, lvDetails.TheArgs.TheTemplate);
            if (lvDetails.CurrentTemplate == null)
                lvDetails.CurrentTemplate = n_template.Create(x, lvDetails.TheArgs.TheClass, lvDetails.TheArgs.TheTemplate);
            lvDetails.CurrentTemplate.GatherColumns(x);
            lvDetails.ColSource = new ColumnSourceTemplate(lvDetails.CurrentTemplate);
            lvDetails.RowSource = new RowSourceItem(lvDetails.TheArgs.LiveItems.AllGet(Context));
            lvDetails.ItemDoubleClicked += new ItemDoubleClickHandler(lvDetails_ItemDoubleClicked);
            lvDetails.AddNewItem += new ItemAddHandler(lvDetails_AddNewItem);
            lvDetails.MenuActionClicked += new MenuActionHandler(lvDetails_MenuActionClicked);
            lvServices = (ListViewSpotServices)SpotAdd(new ListViewSpotServices());
            lvServices.SkipParentRender = true;
            lvServices.TheArgs = TheService.ServicesArgsGet(Context);
            lvServices.TheArgs.LiveItems = TheService.ServiceLines.RefsGetAsItems(Context);
            lvServices.CurrentTemplate = n_template.GetByName(x, lvServices.TheArgs.TheTemplate);
            if (lvServices.CurrentTemplate == null)
                lvServices.CurrentTemplate = n_template.Create(x, lvServices.TheArgs.TheClass, lvServices.TheArgs.TheTemplate);
            lvServices.CurrentTemplate.GatherColumns(x);
            lvServices.ColSource = new ColumnSourceTemplate(lvServices.CurrentTemplate);
            lvServices.RowSource = new RowSourceItem(lvServices.TheArgs.LiveItems.AllGet(Context));
            lvServices.ItemDoubleClicked += new ItemDoubleClickHandler(lvServices_ItemDoubleClicked);
            lvServices.AddNewItem += new ItemAddHandler(lvServices_AddNewItem);
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Service Order";
            if (TheService != null)
                s = TheService.ToString();
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            string s = "";
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"viewinvoice_" + Uid + "\" style=\"position: absolute; top: 0px;\">");
            sb.AppendLine("        <div id=\"ordernumber_info_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"padding: 6px; height: 2px; width: 350px;\">");
            lblInvoice.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<a id=\"aChangeOrderNumber\" href=\"#\" style=\"position: absolute; top: 8px; text-decoration: none; font-size: xx-small;\" onclick=\"" + ActionScript("'change_ordernumber'", "''") + "\"><font color=\"#C0C0C0\">change</font></a>");
            lblStatus.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        </div>");
            s = " visibility: hidden; ";
            int pa = TheService.DetailsListShippableComplete((ContextRz)x).Count;
            int pap = TheService.DetailsListShippablePartial((ContextRz)x).Count;
            if (pa > 0 || pap > 0)
                s = "";
            sb.AppendLine("        <div id=\"action1_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 4px; top: 0px; height: 60px; width: 115px; " + s + "\">");
            sb.AppendLine("<input id=\"cmdAction1\" type=\"button\" value=\"Ship Order\" onclick=\"" + ActionScript("'action1'") + "\">");
            Buttonize(viewHandle, "cmdAction1", "ship_order.png");
            sb.AppendLine("        </div>");
            s = " visibility: hidden; ";
            pa = TheService.DetailsListPutAwayableComplete((ContextRz)x).Count;
            pap = TheService.DetailsListPutAwayablePartial((ContextRz)x).Count;
            if (pa > 0 || pap > 0)
                s = "";
            sb.AppendLine("        <div id=\"action2_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 4px; top: 74px; height: 60px; width: 103px; " + s + "\">");
            sb.AppendLine("<input id=\"cmdAction2\" type=\"button\" value=\"Put Away\" onclick=\"" + ActionScript("'action2'") + "\">");
            Buttonize(viewHandle, "cmdAction2", "put_away.png");
            sb.AppendLine("        </div>");
            s = "";
            sb.AppendLine("        <div id=\"totals_box_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; top: 0px; padding: 6px; height: 110px; width: 228px; " + s + " \">");
            lblTotalsCap.Render(x, sb, screenHandle, viewHandle, session, page);
            lblSubTotalCap.Render(x, sb, screenHandle, viewHandle, session, page);
            lblSubTotal.Render(x, sb, screenHandle, viewHandle, session, page);
            lblShipping.Render(x, sb, screenHandle, viewHandle, session, page);
            txtShipping.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <hr style=\"position: absolute; top: 80px; width: 230px;\">");
            lblOrderTotalCap.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderTotal.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        </div>");
            //tabs
            sb.AppendLine("        <div id=\"tabHeader_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabHeaderNav\">");
            sb.AppendLine("                <li><a href=\"#tabCompany\" style=\"font-size: xx-small\">Company</a></li>");
            sb.AppendLine("                <li><a href=\"#tabAddress\" style=\"font-size: xx-small\">Address</a></li>");
            sb.AppendLine("                <li><a href=\"#tabNotes\" style=\"font-size: xx-small\">Notes</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabCompany\">");
            RenderCompanyTab(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabAddress\">");
            RenderAddressTab(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabNotes\">");
            txtInternalComment.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPrintComment.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("        <div id=\"tabDetails_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabDetailsNav\">");
            sb.AppendLine("                <li><a href=\"#tabLines\" style=\"font-size: xx-small\">Lines</a></li>");
            sb.AppendLine("                <li><a href=\"#tabServices\" style=\"font-size: xx-small\">Services</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabLines\">");
            lvDetails.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabServices\">");
            lvServices.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <div id=\"service_entry_" + Uid + "\" style=\"position: absolute; padding: 6px; height: 2px; width: 350px;\">");// class=\"jqborderstyle ui-corner_all rz-margin\"
            txtService.Render(x, sb, screenHandle, viewHandle, session, page);
            txtServiceQty.Render(x, sb, screenHandle, viewHandle, session, page);
            txtServiceCost.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"cmdsaveservice_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            sb.AppendLine("<input id=\"cmdSaveService\" type=\"button\" value=\"Save\" onclick=\"SaveService()\" style=\"height: 19px; top: 1px; width: 75px;\">");
            sb.AppendLine("</div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function SaveService() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save_service'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#tabHeader_" + Uid + "').tabs( { select: function(event, ui) { " + ActionScript("'tabShow'", "ui.panel.id") + " } });");
            viewHandle.ScriptsToRun.Add("$('#tabDetails_" + Uid + "').tabs( { select: function(event, ui) { " + ActionScript("'tabShow'", "ui.panel.id") + " } });");
            viewHandle.ScriptsToRun.Add("$('#cmdSaveService').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('top', $('#rz_menu').height() + $('#rz_menu').position().top + 10);");
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('height', $(window).height() - $('#viewinvoice_" + Uid + "').position().top - 70);");
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('width', " + xActions.Select + ".position().left - $('#viewinvoice_" + Uid + "').position().left - 15);");
            sb.AppendLine(lblOrderNumber.PlaceRight(lblInvoice, false, 10, 0));
            sb.AppendLine("$('#aChangeOrderNumber').css('left', " + lblOrderNumber.Select + ".position().left + $('#" + lblOrderNumber.InnerDivId + "').width() + 22);");
            sb.AppendLine(lblStatus.Select + ".css('left', $('#ordernumber_info_" + Uid + "').width() - " + lblStatus.Select + ".width() - 5);");
            sb.AppendLine("$('#totals_box_" + Uid + "').css('left', $('#ordernumber_info_" + Uid + "').width() + $('#ordernumber_info_" + Uid + "').position().left + " + Screen.LayoutTheta.ToString() + " + 13);");
            sb.AppendLine(lblSubTotalCap.PlaceBelow(lblTotalsCap, false, 5, 0));
            sb.AppendLine(lblSubTotal.PlaceBelow(lblTotalsCap, false, 2, 0));
            sb.AppendLine(lblSubTotal.Select + ".css('left', $('#totals_box_" + Uid + "').width() - " + lblSubTotal.Select + ".width());");
            sb.AppendLine(lblShipping.PlaceBelow(lblSubTotalCap, false, 7, 0));
            sb.AppendLine(txtShipping.PlaceBelow(lblSubTotalCap));
            sb.AppendLine(txtShipping.Select + ".css('left', $('#totals_box_" + Uid + "').width() - " + txtShipping.Select + ".width() + 2);");
            sb.AppendLine(lblOrderTotalCap.PlaceBelow(txtShipping, false, 11, 0));
            sb.AppendLine(lblOrderTotal.PlaceBelow(txtShipping, false, 13, 0));
            sb.AppendLine(lblOrderTotal.Select + ".css('left', $('#totals_box_" + Uid + "').width() - " + lblOrderTotal.Select + ".width());");
            sb.AppendLine("$('#action1_" + Uid + "').css('left', $('#totals_box_" + Uid + "').position().left + 58);");
            sb.AppendLine("$('#action2_" + Uid + "').css('left', $('#totals_box_" + Uid + "').position().left + 63);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('top', $('#ordernumber_info_" + Uid + "').position().top + $('#ordernumber_info_" + Uid + "').height() + 20);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', $('#ordernumber_info_" + Uid + "').width() + 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', 210);");
            sb.AppendLine("$('#totals_box_" + Uid + "').css('top', $('#tabHeader_" + Uid + "').position().top + $('#tabHeader_" + Uid + "').height() - $('#totals_box_" + Uid + "').height() - 9);");
            sb.AppendLine("$('#tabDetails_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#tabDetails_" + Uid + "').css('top', $('#tabHeader_" + Uid + "').position().top + $('#tabHeader_" + Uid + "').height() + 10);");
            sb.AppendLine("$('#tabDetails_" + Uid + "').css('width', " + xActions.Select + ".position().left - $('#tabDetails_" + Uid + "').position().left - 10);");
            sb.AppendLine("$('#tabDetails_" + Uid + "').css('height', $(window).height() - $('#tabDetails_" + Uid + "').position().top - 77);");
            sb.AppendLine(lblOrderDate.Select + ".css('top', 10);");
            sb.AppendLine(xCompany.Select + ".css('top', 10);");
            sb.AppendLine(xCompany.Select + ".css('left', 2);");
            sb.AppendLine(xCompany.Select + ".css('width', 175);");
            sb.AppendLine(xCompany.Select + ".css('height', 90);");
            sb.AppendLine(lblOrderDate.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left + 18);");
            sb.AppendLine(txtOrderDate.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left);");
            sb.AppendLine(aChangeDate.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left + 33);");
            sb.AppendLine(txtOrderDate.PlaceBelow(lblOrderDate));
            sb.AppendLine(aChangeDate.PlaceBelow(lblOrderDate, false, 13, 0));
            sb.AppendLine(agentSalesAgent.PlaceBelow(aChangeDate));
            sb.AppendLine(agentSalesAgent.Select + ".css('left', " + xCompany.Select + ".width() + " + xCompany.Select + ".position().left);");
            sb.AppendLine(txtPhone.Select + ".css('top', " + xCompany.Select + ".position().top + " + xCompany.Select + ".height() + 5);");
            sb.AppendLine(txtFax.Select + ".css('top', " + xCompany.Select + ".position().top + " + xCompany.Select + ".height() + 5);");
            sb.AppendLine(txtEmail.Select + ".css('top', " + xCompany.Select + ".position().top + " + xCompany.Select + ".height() + 5);");
            sb.AppendLine(txtFax.PlaceRight(txtPhone));
            sb.AppendLine(txtEmail.PlaceBelow(txtPhone));
            sb.AppendLine(cboTerms.PlaceBelow(txtPhone));
            sb.AppendLine(cboTerms.PlaceRight(txtEmail));
            sb.AppendLine(cboShipVia.PlaceBelow(txtPhone));
            sb.AppendLine(cboShipVia.PlaceRight(cboTerms));
            sb.AppendLine(txtInternalComment.Select + ".css('top', 10);");
            sb.AppendLine(txtInternalComment.Select + ".css('left', 10);");
            sb.AppendLine(txtPrintComment.Select + ".css('left', 10);");
            sb.AppendLine(txtPrintComment.PlaceBelow(txtInternalComment));
            sb.AppendLine(cboBillingAdr.Select + ".css('top', 5);");
            sb.AppendLine(cboShippingAdr.Select + ".css('top', 5);");
            sb.AppendLine(cboShippingAdr.PlaceRight(cboBillingAdr));
            sb.AppendLine(txtBillingAdr.PlaceBelow(cboBillingAdr));
            sb.AppendLine(txtShippingAdr.PlaceBelow(cboBillingAdr));
            sb.AppendLine(txtShippingAdr.PlaceRight(txtBillingAdr));
            sb.AppendLine(txtTracking.PlaceBelow(txtBillingAdr));
            sb.AppendLine(cboShippingAccount.PlaceBelow(txtTracking, false, 0, 5));
            sb.AppendLine(lvDetails.Select + ".css('top', 0);");
            sb.AppendLine(lvDetails.Select + ".css('left', 10);");
            sb.AppendLine(lvDetails.Select + ".css('width', $('#tabDetails_" + Uid + "').width() - " + lvDetails.Select + ".position().left - 8);");
            sb.AppendLine(lvDetails.Select + ".css('height', $('#tabDetails_" + Uid + "').height() - " + lvDetails.Select + ".position().top - 29);");
            sb.AppendLine(lvServices.Select + ".css('top', 0);");
            sb.AppendLine(lvServices.Select + ".css('left', 0);");
            sb.AppendLine(lvServices.Select + ".css('width', " + lvDetails.Select + ".width());");
            sb.AppendLine("$('#service_entry_" + Uid + "').css('width',  $('#tabDetails_" + Uid + "').width() - $('#service_entry_" + Uid + "').position().left - 20);");
            sb.AppendLine("$('#service_entry_" + Uid + "').css('height', 10);");
            sb.AppendLine("$('#service_entry_" + Uid + "').css('left', 0);");
            sb.AppendLine("$('#service_entry_" + Uid + "').css('top', $('#tabDetails_" + Uid + "').height() - $('#service_entry_" + Uid + "').height() - 44);");
            sb.AppendLine(txtService.Select + ".css('top', -3);");
            sb.AppendLine(txtService.Select + ".css('left', 2);");
            sb.AppendLine(txtServiceQty.Select + ".css('top', -3);");
            sb.AppendLine(txtServiceQty.PlaceRight(txtService));
            sb.AppendLine(txtServiceCost.Select + ".css('top', -3);");
            sb.AppendLine(txtServiceCost.PlaceRight(txtServiceQty));
            sb.AppendLine(lvServices.Select + ".css('height', $('#service_entry_" + Uid + "').position().top - " + lvServices.Select + ".position().top + 2);");
            sb.AppendLine("$('#cmdsaveservice_" + Uid + "').css('left', " + txtServiceCost.Select + ".position().left +  " + txtServiceCost.Select + ".width() + 5);");
        }
        private void UpdateControls(ContextRz x)
        {
            TheService.CalculateAllAmounts(x);
            lblSubTotal.ValueSet(x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheService.SubTotal(x)));
            lblOrderTotal.ValueSet(x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheService.ordertotal));
            lblSubTotal.Change();
            lblOrderTotal.Change();
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                case "save":
                case "saveexit":
                    UpdateControls((ContextRz)x);
                    break;
                case "action1":
                    Action1((ContextRz)x);
                    break;
                case "action2":
                    Action2((ContextRz)x);
                    break;
                case "change_date":
                    ChangeOrderDate((ContextRz)x, TheService.orderdate.ToString());
                    break;
                case "change_ordernumber":
                    ChangeOrderNumber((ContextRz)x);
                    break;
                case "billing_changed":
                    SetBillingAddress((ContextRz)x, s);
                    break;
                case "shipping_changed":
                    SetShippingAddress((ContextRz)x, s);
                    break;
                case "save_service":
                    SaveService((ContextRz)x, args.ActionParams);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            lblInvoice.AddPadding(GenAlign.Left, 20);
            if (TheService.isvoid)
                lblStatus.TextForeColor = Color.DarkGray;
            else if (TheService.isclosed)
                lblStatus.TextForeColor = Color.Blue;
            else if (TheService.onhold)
                lblStatus.TextForeColor = Color.Red;
            else
                lblStatus.TextForeColor = Color.Green;
            lblOrderNumber.AddPadding(GenAlign.Left, 20);
            lblInvoice.AddPadding(GenAlign.Top, 1);
            lblOrderNumber.AddPadding(GenAlign.Top, 1);
            lblTotalsCap.AddPadding(GenAlign.Top, 5);
            lblTotalsCap.AddPadding(GenAlign.Left, 5);
            lblSubTotalCap.TextFontSize = FontSize.Small;
            lblSubTotalCap.TextForeColor = Color.Gray;
            lblSubTotalCap.AddPadding(GenAlign.Left, 5);
            lblSubTotal.TextBold = true;
            lblShipping.TextFontSize = FontSize.Small;
            lblShipping.TextForeColor = Color.Gray;
            lblShipping.AddPadding(GenAlign.Left, 5);
            txtShipping.TxtAlign = TextAlign.Right;
            txtShipping.FixedWidth = 105;
            lblOrderTotalCap.TextFontSize = FontSize.Small;
            lblOrderTotalCap.TextForeColor = Color.Gray;
            lblOrderTotalCap.AddPadding(GenAlign.Left, 5);
            lblOrderTotalCap.AddPadding(GenAlign.Top, 10);
            lblOrderTotal.TextBold = true;
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
            txtPhone.CaptionFontSize = FontSize.XSmall;
            txtPhone.TextFontSize = FontSize.XSmall;
            txtPhone.FixedWidth = 170;
            txtFax.CaptionFontSize = FontSize.XSmall;
            txtFax.TextFontSize = FontSize.XSmall;
            txtFax.FixedWidth = 170;
            txtEmail.CaptionFontSize = FontSize.XSmall;
            txtEmail.TextFontSize = FontSize.XSmall;
            txtEmail.FixedWidth = 110;
            cboTerms.CaptionFontSize = FontSize.XSmall;
            cboTerms.TextFontSize = FontSize.XSmall;
            cboTerms.FixedWidth = 113;
            cboShipVia.CaptionFontSize = FontSize.XSmall;
            cboShipVia.TextFontSize = FontSize.XSmall;
            cboShipVia.FixedWidth = 113;
            txtInternalComment.CaptionFontSize = FontSize.XSmall;
            txtInternalComment.TextFontSize = FontSize.XSmall;
            txtInternalComment.FixedWidth = 330;
            txtInternalComment.Rows = 3;
            txtPrintComment.CaptionFontSize = FontSize.XSmall;
            txtPrintComment.TextFontSize = FontSize.XSmall;
            txtPrintComment.FixedWidth = 330;
            txtPrintComment.Rows = 3;
            xCompany.TextFontSize = FontSize.XSmall;
            lvDetails.ExtraStyle = "; font-size: small";
            lvServices.ExtraStyle = "; font-size: small";
            txtBillingAdr.CaptionFontSize = FontSize.XSmall;
            txtBillingAdr.TextFontSize = FontSize.XSmall;
            txtBillingAdr.FixedWidth = 168;
            txtBillingAdr.Rows = 2;
            txtShippingAdr.CaptionFontSize = FontSize.XSmall;
            txtShippingAdr.TextFontSize = FontSize.XSmall;
            txtShippingAdr.FixedWidth = 168;
            txtShippingAdr.Rows = 2;
            txtTracking.TextFontSize = FontSize.XSmall;
            txtTracking.CaptionFontSize = FontSize.XSmall;
            txtTracking.FixedWidth = 345;
            txtTracking.Rows = 1;
            cboShippingAccount.TextFontSize = FontSize.XSmall;
            cboShippingAccount.CaptionFontSize = FontSize.XSmall;
            cboShippingAccount.FixedWidth = 353;
            cboBillingAdr.TextFontSize = FontSize.XSmall;
            cboBillingAdr.CaptionFontSize = FontSize.XSmall;
            cboBillingAdr.FixedWidth = 173;
            cboShippingAdr.TextFontSize = FontSize.XSmall;
            cboShippingAdr.CaptionFontSize = FontSize.XSmall;
            cboShippingAdr.FixedWidth = 173;
            txtService.TextFontSize = FontSize.XXSmall;
            txtService.CaptionFontSize = FontSize.XXSmall;
            txtService.FixedWidth = 100;
            txtService.CaptionInLine = true;
            txtServiceQty.TextFontSize = FontSize.XXSmall;
            txtServiceQty.CaptionFontSize = FontSize.XXSmall;
            txtServiceQty.FixedWidth = 100;
            txtServiceQty.CaptionInLine = true;
            txtServiceCost.TextFontSize = FontSize.XXSmall;
            txtServiceCost.CaptionFontSize = FontSize.XXSmall;
            txtServiceCost.FixedWidth = 100;
            txtServiceCost.CaptionInLine = true;
        }
        private void ServiceLoad()
        {
            if (TheServiceLine == null)
                return;
            txtService.ValueSet(TheServiceLine.service_name);
            txtServiceQty.ValueSet(TheServiceLine.quantity);
            txtServiceCost.ValueSet(TheServiceLine.unit_cost);
            txtService.Change();
            txtServiceQty.Change();
            txtServiceCost.Change();
        }
        protected override void SaveData(Context x, SpotActArgs args, Dictionary<string, string> values)
        {
            if (TheService == null)
                return;
            string s = "";
            values.TryGetValue("shipvia", out s);
            if (!Tools.Strings.StrExt(s))
                return;
            foreach (orddet_line l in TheService.DetailsList((ContextRz)x))
            {
                if (!Tools.Strings.StrExt(l.shipvia_service_in))
                {
                    l.shipvia_service_in = s;
                    l.Update(x);
                }
            }
        }
        private void RenderCompanyTab(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            xCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderDate.Render(x, sb, screenHandle, viewHandle, session, page);
            txtOrderDate.Render(x, sb, screenHandle, viewHandle, session, page);
            aChangeDate.Render(x, sb, screenHandle, viewHandle, session, page);
            agentSalesAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            cboTerms.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipVia.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private void ChangeOrderDate(ContextRz x, string date)
        {
            TheService.DateChange(x);
            txtOrderDate.ValueSet(TheService.orderdate.ToString());
            txtOrderDate.Change();
        }
        private void ChangeOrderNumber(ContextRz x)
        {
            TheService.NumberChange(x);
            lblOrderNumber.ValueSet(TheService.ordernumber);
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
        private void RenderAddressTab(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            cboBillingAdr.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShippingAdr.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBillingAdr.Render(x, sb, screenHandle, viewHandle, session, page);
            txtShippingAdr.Render(x, sb, screenHandle, viewHandle, session, page);
            txtTracking.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShippingAccount.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private ArrayList LoadAddressList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            Rz5.company c = (Rz5.company)TheService.CompanyVar.RefGet(x);
            if (c == null)
                return a;
            a = x.SelectScalarArray("SELECT DISTINCT(DESCRIPTION) FROM companyaddress WHERE description > '' and base_company_uid = '" + c.unique_id + "' ORDER BY DESCRIPTION");
            a.Add("[local]");
            return a;
        }
        private ArrayList LoadAccountList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            Rz5.company c = (Rz5.company)TheService.CompanyVar.RefGet(x);
            if (c != null)
                a = x.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + c.unique_id + "' ORDER BY ACCOUNTNUMBER");
            if (Tools.Strings.StrExt(x.Logic.InternalUPS))
                a.Add(x.Logic.InternalUPS);
            if (Tools.Strings.StrExt(x.Logic.InternalFedex))
                a.Add(x.Logic.InternalFedex);
            if (Tools.Strings.StrExt(x.Logic.InternalDHL))
                a.Add(x.Logic.InternalDHL);
            if (Tools.Strings.StrExt(x.Logic.InternalOther))
                a.Add(x.Logic.InternalOther);
            if (Tools.Strings.StrExt(x.GetSetting("dhl_account")))
                a.Add(x.GetSetting("dhl_account"));
            return a;
        }
        private void SetBillingAddress(ContextRz x, string val)
        {
            switch (val.Trim().ToLower())
            {
                case "[local]":
                    if (Tools.Strings.StrExt(x.TheLogicRz.ShipToAddress))
                        txtBillingAdr.Value = x.TheLogicRz.ShipToAddress;
                    else
                        txtBillingAdr.Value = OwnerSettings.GetAddressBlock(x);
                    break;
                default:
                    if (val.StartsWith("Contact address for"))
                    {
                        String contactname = Tools.Strings.ParseDelimit(val, "Contact address for", 2).Trim();
                        if (!Tools.Strings.StrCmp(contactname, TheService.ContactVar.RefGet(x).contactname))
                        {
                            x.TheLeader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txtBillingAdr.Value = TheService.ContactVar.RefGet(x).BuildAddress();
                    }
                    else if (val.ToLower().StartsWith("address option"))
                    {
                        txtBillingAdr.Value = x.GetSetting(val);
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(x, TheService.base_company_uid, val);
                        if (a != null)
                            txtBillingAdr.Value = a.GetAddressString(x);
                    }
                    break;
            }
            txtBillingAdr.Change();
        }
        private void SetShippingAddress(ContextRz x, string val)
        {
            switch (val.Trim().ToLower())
            {
                case "[local]":
                    if (Tools.Strings.StrExt(x.TheLogicRz.ShipToAddress))
                        txtShippingAdr.Value = x.TheLogicRz.ShipToAddress;
                    else
                        txtShippingAdr.Value = OwnerSettings.GetAddressBlock(x);
                    break;
                default:
                    if (val.StartsWith("Contact address for"))
                    {
                        String contactname = Tools.Strings.ParseDelimit(val, "Contact address for", 2).Trim();
                        if (!Tools.Strings.StrCmp(contactname, TheService.ContactVar.RefGet(x).contactname))
                        {
                            x.TheLeader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txtShippingAdr.Value = TheService.ContactVar.RefGet(x).BuildAddress();
                    }
                    else if (val.ToLower().StartsWith("address option"))
                    {
                        txtShippingAdr.Value = x.GetSetting(val);
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(x, TheService.base_company_uid, val);
                        if (a != null)
                            txtShippingAdr.Value = a.GetAddressString(x);
                    }
                    break;
            }
            txtShippingAdr.Change();
        }
        private string GetStatus(ContextRz x)
        {
            if (TheService.isvoid)
                return "Void";
            else if (TheService.isclosed)
                return "Complete";
            else if (TheService.onhold)
                return "Hold";
            else
                return "Open";
        }
        private void Action1(ContextRz x)
        {
            TheService.Ship(x);
            Change();
        }
        private void Action2(ContextRz x)
        {
            TheService.PutAway(x);
            Change();
        }
        private void SaveService(ContextRz x, string s)
        {
            Dictionary<string, string> d = ParseValueString(s);
            if (d == null)
                return;
            if (TheServiceLine == null)
            {
                x.TheLeader.Tell("You need to first select or create a new service line before saving.");
                return;
            }
            string ss = "";
            d.TryGetValue("txtService", out ss);
            TheServiceLine.service_name = ss;
            ss = "";
            d.TryGetValue("txtServiceQty", out ss);
            int q = 0;
            try { q = Convert.ToInt32(ss); }
            catch { q = 0; }
            TheServiceLine.quantity = q;
            ss = "";
            d.TryGetValue("txtServiceCost", out ss);
            ss = ss.Replace("$", "").Trim();
            double c = 0;
            try { c = Convert.ToDouble(ss); }
            catch { c = 0; }
            TheServiceLine.unit_cost = c;
            TheServiceLine.Update(x);
            txtService.ValueSet("");
            txtServiceQty.ValueSet(0);
            txtServiceCost.ValueSet(0);
            txtService.Change();
            txtServiceQty.Change();
            txtServiceCost.Change();
            lvServices.TheArgs.LiveItems = TheService.ServiceLines.RefsGetAsItems((ContextRz)x);
            lvServices.RowSource = new RowSourceItem(lvServices.TheArgs.LiveItems.AllGet(Context));
            lvServices.Change();
        }
        private void xCompany_CompanyChanged(ContextNM x, company c, ViewHandle v)
        {
            if (c == null)
                return;
            TheService.CompanyVar.RefSet(x, c);
            TheService.AbsorbCompany((ContextRz)x, c);
            TheService.Update(x);
            LoadAccountList((ContextRz)x);
            cboTerms.ValueSet(TheService.terms);
            txtPhone.ValueSet(c.primaryphone);
            txtFax.ValueSet(c.primaryfax);
            txtEmail.ValueSet(c.primaryemailaddress);
            txtBillingAdr.ValueSet(c.GetPrimaryBillingAddressString((ContextRz)x));
            txtShippingAdr.ValueSet(c.GetPrimaryShippingAddressString((ContextRz)x));
            cboTerms.Change();
            txtPhone.Change();
            txtFax.Change();
            txtEmail.Change();
            txtBillingAdr.Change();
            txtShippingAdr.Change();
            xCompany.ContactID = "";
            xCompany.ContactName = "";
            xCompany.Change();
        }
        private void xCompany_ContactChanged(ContextNM x, companycontact c, ViewHandle v)
        {
            if (c == null)
                return;
            if (Tools.Strings.StrExt(c.primaryphone))
                txtPhone.ValueSet(c.primaryphone);
            if (Tools.Strings.StrExt(c.primaryfax))
                txtFax.ValueSet(c.primaryfax);
            if (Tools.Strings.StrExt(c.primaryemailaddress))
                txtEmail.ValueSet(c.primaryemailaddress);
            txtPhone.Change();
            txtFax.Change();
            txtEmail.Change();
            TheService.ContactVar.RefSet(x, c);
            TheService.Update(x);
        }
        private void lvDetails_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_line d = null;
            try { d = (orddet_line)item; }
            catch { }
            if (d == null)
                return;
            RzWeb.ServiceLine q = new RzWeb.ServiceLine((ContextRz)x, d);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvDetails_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            TheService.DetailAddWithChecks((ContextRz)x);
            TheService.Update((ContextRz)x);
            TheView.ScriptsToRun.Add("window.close();");
        }
        private void lvDetails_MenuActionClicked(Context x, ActArgs args, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            switch (args.ActionName.ToLower())
            {
                case "open":
                    x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Service));
                    args.Handled = true;
                    break;
            }
        }
        private void lvServices_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            TheServiceLine = (service_line)item;
            ServiceLoad();
        }
        private void lvServices_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            TheServiceLine = TheService.ServiceLines.RefAddNew(x);
            ServiceLoad();
            lvServices.TheArgs.LiveItems = TheService.ServiceLines.RefsGetAsItems((ContextRz)x);
            lvServices.RowSource = new RowSourceItem(lvServices.TheArgs.LiveItems.AllGet(Context));
            lvServices.Change();
            TheService.Update((ContextRz)x);
        }
    }
    public class ListViewSpotServices : ListViewSpotRz
    {
        public ListViewSpotServices()
            : base("service_line")
        {
        }
    }
}
