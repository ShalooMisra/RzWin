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
    public class Invoice : _Item
    {
        public ordhed_invoice TheInvoice
        {
            get
            {
                return (ordhed_invoice)Item;
            }
        }
        ListViewSpotDetails lvDetails;
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
        TextControl txtReference;
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
        ViewHandle TheView;

        public Invoice(ContextRz x, ordhed_invoice i)
            : base(x, i)
        {
            TheInvoice.CalculateAllAmounts(x);
            TheInvoice.trackingnumber = TheInvoice.TrackingNumbersGet(x);
            lblInvoice = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblInvoice", "", TheInvoice.FriendlyOrderType)));
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", TheInvoice.ordernumber)));
            string status = GetStatus(x);
            lblStatus = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStatus", "", status)));
            lblTotalsCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTotalsCap", "", "Totals")));
            lblSubTotalCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSubTotalCap", "", "Sub Total:")));
            lblSubTotal = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSubTotal", "", x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheInvoice.sub_total))));
            lblShipping = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblShipping", "", "Extra:")));
            txtShipping = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("shippingamount", "", TheInvoice.shippingamount, x.TheSys.CurrencySymbol)));
            lblOrderTotalCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderTotalCap", "", "Total:")));
            lblOrderTotal = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderTotal", "", x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheInvoice.ordertotal))));
            lblOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderDate", "", "Order Date")));
            txtOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("txtOrderDate", "", TheInvoice.orderdate.ToString())));
            aChangeDate = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChangeDate", "change date", ActionScript("'change_date'"))));
            ArrayList agents = GetAgentArray(x);
            agentSalesAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("base_mc_user_uid|agentname", "Sales Agent", TheInvoice.base_mc_user_uid, TheInvoice.agentname, "base_mc_user_uid", "agentname", agents)));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphone", "Phone", TheInvoice.primaryphone)));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryfax", "Fax", TheInvoice.primaryfax)));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryemailaddress", "Email", TheInvoice.primaryemailaddress)));
            txtInternalComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comment", TheInvoice.internalcomment)));
            txtPrintComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("printcomment", "Print Comment", TheInvoice.printcomment)));
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("base_company_uid|companyname|base_companycontact_uid|contactname", "Customer", TheInvoice.base_company_uid, TheInvoice.companyname, "base_company_uid", "companyname", TheInvoice.base_companycontact_uid, TheInvoice.contactname, "base_companycontact_uid", "contactname")));
            xCompany.CompanyChanged += new CompanyChangedHandler(xCompany_CompanyChanged);
            xCompany.ContactChanged += new ContactChangedHandler(xCompany_ContactChanged);
            txtReference = (TextControl)SpotAdd(ControlAdd(new TextControl("orderreference", "PO Number", TheInvoice.orderreference)));
            cboTerms = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("terms", "Terms", TheInvoice.terms, GetChoiceList(x, "terms"), "", "terms")));
            cboShipVia = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shipvia", "Ship Via", TheInvoice.shipvia, GetChoiceList(x, "shipvia"), "", "shipvia")));
            //Address Info
            txtBillingAdr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("billingaddress", "Billing Address", TheInvoice.billingaddress)));
            txtShippingAdr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("shippingaddress", "Shipping Address", TheInvoice.shippingaddress)));
            txtTracking = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("trackingnumber", "Tracking Numbers", TheInvoice.trackingnumber)));
            txtTracking.DisableEdit = true;
            cboShippingAccount = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shippingaccount", "Shipping Account", TheInvoice.shippingaccount, LoadAccountList(x), "", "null")));
            cboBillingAdr = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboBillingAdr", "", "", LoadAddressList(x))));
            cboBillingAdr.OnChange = ActionScript("'billing_changed'", "$('#" + cboBillingAdr.ControlId + "').val()");
            cboBillingAdr.IgnoreOnSave = true;
            cboShippingAdr = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboShippingAdr", "", "", LoadAddressList(x))));
            cboShippingAdr.OnChange = ActionScript("'shipping_changed'", "$('#" + cboShippingAdr.ControlId + "').val()");
            cboShippingAdr.IgnoreOnSave = true;
            lvDetails = (ListViewSpotDetails)SpotAdd(new ListViewSpotDetails());
            lvDetails.SkipParentRender = true;
            lvDetails.TheArgs = TheInvoice.DetailArgsGet(Context);
            lvDetails.TheArgs.LiveItems = TheInvoice.DetailsVar.RefsGetAsItems(Context);
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
        public override String Title(Context x)
        {
            string s = "Invoice";
            if (TheInvoice != null)
                s = TheInvoice.ToString();
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
            bool is_verifiy = TheInvoice.CheckVerify((ContextRz)x, new StringBuilder());
            int pa = TheInvoice.DetailsListShippable((ContextRz)x).Count;
            if (pa > 0 && is_verifiy)
                s = "";
            sb.AppendLine("        <div id=\"action1_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 4px; top: 0px; height: 60px; width: 115px; " + s + "\">");
            sb.AppendLine("<input id=\"cmdAction1\" type=\"button\" value=\"Ship Order\" onclick=\"" + ActionScript("'action1'") + "\">");
            Buttonize(viewHandle, "cmdAction1", "ship_order.png");
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
            lvDetails.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#tabHeader_" + Uid + "').tabs( { select: function(event, ui) { " + ActionScript("'tabShow'", "ui.panel.id") + " } });");
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
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('top', $('#ordernumber_info_" + Uid + "').position().top + $('#ordernumber_info_" + Uid + "').height() + 20);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', $('#ordernumber_info_" + Uid + "').width() + 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', 245);");
            sb.AppendLine("$('#totals_box_" + Uid + "').css('top', $('#tabHeader_" + Uid + "').position().top + $('#tabHeader_" + Uid + "').height() - $('#totals_box_" + Uid + "').height() - 9);");
            sb.AppendLine(lvDetails.Select + ".css('left', 5);");
            sb.AppendLine(lvDetails.Select + ".css('top', $('#tabHeader_" + Uid + "').position().top + $('#tabHeader_" + Uid + "').height() + 20);");
            sb.AppendLine(lvDetails.Select + ".css('width', " + xActions.Select + ".position().left - " + lvDetails.Select + ".position().left - 10);");
            lvDetails.RunToBottom(sb);
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
            sb.AppendLine(cboShipVia.PlaceRight(txtEmail));
            sb.AppendLine(cboShipVia.PlaceBelow(txtPhone));
            sb.AppendLine(txtReference.PlaceBelow(txtEmail));
            sb.AppendLine(cboTerms.PlaceBelow(txtEmail));
            sb.AppendLine(cboTerms.PlaceRight(txtReference));
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
            sb.AppendLine(cboShippingAccount.PlaceBelow(txtTracking));
        }
        private void UpdateControls(ContextRz x)
        {
            TheInvoice.CalculateAllAmounts(x);
            lblSubTotal.ValueSet(x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheInvoice.SubTotal(x)));
            lblOrderTotal.ValueSet(x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheInvoice.ordertotal));
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
                case "change_date":
                    ChangeOrderDate((ContextRz)x, TheInvoice.orderdate.ToString());
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
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            lblInvoice.AddPadding(GenAlign.Left, 20);
            if (TheInvoice.isvoid)
                lblStatus.TextForeColor = Color.DarkGray;
            else if (TheInvoice.isclosed)
                lblStatus.TextForeColor = Color.Blue;
            else if (TheInvoice.onhold)
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
            txtPhone.FixedWidth = 167;
            txtFax.CaptionFontSize = FontSize.XSmall;
            txtFax.TextFontSize = FontSize.XSmall;
            txtFax.FixedWidth = 167;
            txtEmail.CaptionFontSize = FontSize.XSmall;
            txtEmail.TextFontSize = FontSize.XSmall;
            txtEmail.FixedWidth = 167;
            txtReference.CaptionFontSize = FontSize.XSmall;
            txtReference.TextFontSize = FontSize.XSmall;
            txtReference.FixedWidth = 167;
            cboTerms.CaptionFontSize = FontSize.XSmall;
            cboTerms.TextFontSize = FontSize.XSmall;
            cboTerms.FixedWidth = 173;
            cboShipVia.CaptionFontSize = FontSize.XSmall;
            cboShipVia.TextFontSize = FontSize.XSmall;
            cboShipVia.FixedWidth = 173;
            txtInternalComment.CaptionFontSize = FontSize.XSmall;
            txtInternalComment.TextFontSize = FontSize.XSmall;
            txtInternalComment.FixedWidth = 330;
            txtInternalComment.Rows = 4;
            txtPrintComment.CaptionFontSize = FontSize.XSmall;
            txtPrintComment.TextFontSize = FontSize.XSmall;
            txtPrintComment.FixedWidth = 330;
            txtPrintComment.Rows = 4;
            xCompany.TextFontSize = FontSize.XSmall;
            lvDetails.ExtraStyle = "; font-size: small";
            txtBillingAdr.CaptionFontSize = FontSize.XSmall;
            txtBillingAdr.TextFontSize = FontSize.XSmall;
            txtBillingAdr.FixedWidth = 168;
            txtBillingAdr.Rows = 3;
            txtShippingAdr.CaptionFontSize = FontSize.XSmall;
            txtShippingAdr.TextFontSize = FontSize.XSmall;
            txtShippingAdr.FixedWidth = 168;
            txtShippingAdr.Rows = 3;
            txtTracking.TextFontSize = FontSize.XSmall;
            txtTracking.CaptionFontSize = FontSize.XSmall;
            txtTracking.FixedWidth = 345;
            txtTracking.Rows = 2;
            cboShippingAccount.TextFontSize = FontSize.XSmall;
            cboShippingAccount.CaptionFontSize = FontSize.XSmall;
            cboShippingAccount.FixedWidth = 353;
            cboBillingAdr.TextFontSize = FontSize.XSmall;
            cboBillingAdr.CaptionFontSize = FontSize.XSmall;
            cboBillingAdr.FixedWidth = 173;
            cboShippingAdr.TextFontSize = FontSize.XSmall;
            cboShippingAdr.CaptionFontSize = FontSize.XSmall;
            cboShippingAdr.FixedWidth = 173;
        }
        private void RenderCompanyTab(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            xCompany.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderDate.Render(x, sb, screenHandle, viewHandle, session, page);
            txtOrderDate.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipVia.Render(x, sb, screenHandle, viewHandle, session, page);
            aChangeDate.Render(x, sb, screenHandle, viewHandle, session, page);
            agentSalesAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            txtReference.Render(x, sb, screenHandle, viewHandle, session, page);
            cboTerms.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private void ChangeOrderDate(ContextRz x, string date)
        {
            TheInvoice.DateChange(x);
            txtOrderDate.ValueSet(TheInvoice.orderdate.ToString());
            txtOrderDate.Change();
        }
        private void ChangeOrderNumber(ContextRz x)
        {
            TheInvoice.NumberChange(x);
            lblOrderNumber.ValueSet(TheInvoice.ordernumber);
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
            Rz5.company c = (Rz5.company)TheInvoice.CompanyVar.RefGet(x);
            if (c == null)
                return a;
            a = x.SelectScalarArray("SELECT DISTINCT(DESCRIPTION) FROM companyaddress WHERE description > '' and base_company_uid = '" + c.unique_id + "' ORDER BY DESCRIPTION");
            a.Add("[local]");
            return a;
        }
        private ArrayList LoadAccountList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            Rz5.company c = (Rz5.company)TheInvoice.CompanyVar.RefGet(x);
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
                        if (!Tools.Strings.StrCmp(contactname, TheInvoice.ContactVar.RefGet(x).contactname))
                        {
                            x.TheLeader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txtBillingAdr.Value = TheInvoice.ContactVar.RefGet(x).BuildAddress();
                    }
                    else if (val.ToLower().StartsWith("address option"))
                    {
                        txtBillingAdr.Value = x.GetSetting(val);
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(x, TheInvoice.base_company_uid, val);
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
                        if (!Tools.Strings.StrCmp(contactname, TheInvoice.ContactVar.RefGet(x).contactname))
                        {
                            x.TheLeader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txtShippingAdr.Value = TheInvoice.ContactVar.RefGet(x).BuildAddress();
                    }
                    else if (val.ToLower().StartsWith("address option"))
                    {
                        txtShippingAdr.Value = x.GetSetting(val);
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(x, TheInvoice.base_company_uid, val);
                        if (a != null)
                            txtShippingAdr.Value = a.GetAddressString(x);
                    }
                    break;
            }
            txtShippingAdr.Change();
        }
        private void Action1(ContextRz x)
        {
            TheInvoice.Ship(x);
            Change();
        }
        private string GetStatus(ContextRz x)
        {
            if (TheInvoice.isvoid)
                return "Void";
            else if (TheInvoice.isclosed)
                return "Complete";
            else if (TheInvoice.onhold)
                return "Hold";
            else
                return "Open";
        }
        private void xCompany_CompanyChanged(ContextNM x, company c, ViewHandle v)
        {
            if (c == null)
                return;
            TheInvoice.CompanyVar.RefSet(x, c);
            TheInvoice.AbsorbCompany((ContextRz)x, c);
            TheInvoice.Update(x);
            LoadAccountList((ContextRz)x);
            cboTerms.ValueSet(TheInvoice.terms);
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
            TheInvoice.ContactVar.RefSet(x, c);
            TheInvoice.Update(x);
        }
        protected override void SaveData(Context x, SpotActArgs args, Dictionary<string, string> values)
        {
            if (TheInvoice == null)
                return;
            string s = "";
            values.TryGetValue("shipvia", out s);
            if (!Tools.Strings.StrExt(s))
                return;
            foreach (orddet_line l in TheInvoice.DetailsList((ContextRz)x))
            {
                if (!Tools.Strings.StrExt(l.shipvia_invoice))
                {
                    l.shipvia_invoice = s;
                    l.Update(x);
                }
            }
        }
        private void lvDetails_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (!Tools.Strings.StrExt(TheInvoice.base_company_uid))
            {
                x.TheLeader.Tell("You need to select a company for this order before adding new lines.");
                return;
            }
            TheInvoice.DetailAddWithChecks((ContextRz)x);
            TheInvoice.Update((ContextRz)x);
            TheView.ScriptsToRun.Add("window.close();");
        }
        private void lvDetails_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_line d = null;
            try { d = (orddet_line)item; }
            catch { }
            if (d == null)
                return;
            RzWeb.InvoiceLine q = new RzWeb.InvoiceLine((ContextRz)x, d);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvDetails_MenuActionClicked(Context x, ActArgs args, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            switch (args.ActionName.ToLower())
            {
                case "open":
                    x.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Invoice));
                    args.Handled = true;
                    break;
            }
        }
    }
    public class ListViewSpotDetails : ListViewSpotRz
    {
        public ListViewSpotDetails()
            : base("orddet_line")
        {
        }
    }
}

