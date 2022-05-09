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
    public class FormalQuote : _Item
    {
        public ordhed_quote TheQuote
        {
            get
            {
                return (ordhed_quote)Item;
            }
        }
        ListViewSpotQuote lvDetails;
        LabelControl lblQuote;
        LabelControl lblOrderNumber;
        AnchorControl aChangeOrderNumber;
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
        ComboBoxControl cboBillingAdr;
        ComboBoxControl cboShippingAdr;
        ViewHandle TheView;
        TextControl txtWarranty;
        TextControl txtReference;
        DateControl dtExpires;

        public FormalQuote(ContextRz x, ordhed_quote q)
            : base(x, q)
        {
            TheQuote.CalculateAllAmounts(x);
            lblQuote = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblQuote", "", TheQuote.FriendlyOrderType)));
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", TheQuote.ordernumber)));
            aChangeOrderNumber = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChangeOrderNumber", "change", ActionScript("'change_ordernumber'"))));
            string status = GetStatus(x);
            lblStatus = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStatus", "", status)));
            lblTotalsCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblTotalsCap", "", "Totals")));
            lblSubTotalCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSubTotalCap", "", "Sub Total:")));
            lblSubTotal = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblSubTotal", "", x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheQuote.SubTotal(x)))));
            lblShipping = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblShipping", "", "Extra:")));
            txtShipping = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("shippingamount", "", TheQuote.shippingamount, x.TheSys.CurrencySymbol)));
            lblOrderTotalCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderTotalCap", "", "Total:")));
            lblOrderTotal = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderTotal", "", x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheQuote.ordertotal))));
            lblOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderDate", "", "Order Date")));
            txtOrderDate = (LabelControl)SpotAdd(ControlAdd(new LabelControl("txtOrderDate", "", TheQuote.orderdate.ToString())));
            aChangeDate = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChangeDate", "change date", ActionScript("'change_date'"))));
            ArrayList agents = GetAgentArray(x);
            agentSalesAgent = (AgentControl)SpotAdd(ControlAdd(new AgentControl("base_mc_user_uid|agentname", "Sales Agent", TheQuote.base_mc_user_uid, TheQuote.agentname, "base_mc_user_uid", "agentname", agents)));
            txtPhone = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryphone", "Phone", TheQuote.primaryphone)));
            txtFax = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryfax", "Fax", TheQuote.primaryfax)));
            txtEmail = (TextControl)SpotAdd(ControlAdd(new TextControl("primaryemailaddress", "Email", TheQuote.primaryemailaddress)));

            txtWarranty = (TextControl)SpotAdd(ControlAdd(new TextControl("warranty_period", "Warranty", TheQuote.warranty_period)));
            txtReference = (TextControl)SpotAdd(ControlAdd(new TextControl("orderreference", "Reference #", TheQuote.orderreference)));
            dtExpires = (DateControl)SpotAdd(ControlAdd(new DateControl("date_expires", "Valid Through", TheQuote.date_expires)));

            txtInternalComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comment", TheQuote.internalcomment)));
            txtPrintComment = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("printcomment", "Print Comment", TheQuote.printcomment)));
            xCompany = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("base_company_uid|companyname|base_companycontact_uid|contactname", "Customer", TheQuote.base_company_uid, TheQuote.companyname, "base_company_uid", "companyname", TheQuote.base_companycontact_uid, TheQuote.contactname, "base_companycontact_uid", "contactname")));
            xCompany.CompanyChanged += new CompanyChangedHandler(xCompany_CompanyChanged);
            xCompany.ContactChanged += new ContactChangedHandler(xCompany_ContactChanged);
            cboTerms = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("terms", "Terms", TheQuote.terms, GetChoiceList(x, "terms"), "", "terms")));
            cboShipVia = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shipvia", "Ship Via", TheQuote.shipvia, GetChoiceList(x, "shipvia"), "", "shipvia")));
            //Address Info
            txtBillingAdr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("billingaddress", "Billing Address", TheQuote.billingaddress)));
            txtShippingAdr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("shippingaddress", "Shipping Address", TheQuote.shippingaddress)));
            cboBillingAdr = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboBillingAdr", "", "", LoadAddressList(x))));
            cboBillingAdr.OnChange = ActionScript("'billing_changed'", "$('#" + cboBillingAdr.ControlId + "').val()");
            cboBillingAdr.IgnoreOnSave = true;
            cboShippingAdr = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("cboShippingAdr", "", "", LoadAddressList(x))));
            cboShippingAdr.OnChange = ActionScript("'shipping_changed'", "$('#" + cboShippingAdr.ControlId + "').val()");
            cboShippingAdr.IgnoreOnSave = true;
            lvDetails = (ListViewSpotQuote)SpotAdd(new ListViewSpotQuote());
            lvDetails.SkipParentRender = true;
            lvDetails.TheArgs = TheQuote.DetailArgsGet(Context);
            lvDetails.TheArgs.LiveItems = TheQuote.DetailsVar.RefsGetAsItems(Context);
            lvDetails.CurrentTemplate = n_template.GetByName(x, lvDetails.TheArgs.TheTemplate);
            if (lvDetails.CurrentTemplate == null)
                lvDetails.CurrentTemplate = n_template.Create(x, lvDetails.TheArgs.TheClass, lvDetails.TheArgs.TheTemplate);
            lvDetails.CurrentTemplate.GatherColumns(x);
            lvDetails.ColSource = new ColumnSourceTemplate(lvDetails.CurrentTemplate);
            lvDetails.RowSource = new RowSourceItem(lvDetails.TheArgs.LiveItems.AllGet(Context));
            lvDetails.ItemDoubleClicked += new ItemDoubleClickHandler(lvDetails_ItemDoubleClicked);
            lvDetails.AddNewItem += new ItemAddHandler(lvDetails_AddNewItem);
            AdjustControls();

        }
        public override String Title(Context x)
        {
            string s = "Formal Quote";
            if (TheQuote != null)
                s = TheQuote.ToString();
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            string s = "";
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"viewinvoice_" + Uid + "\" style=\"position: absolute; top: 0px;\">");
            sb.AppendLine("        <div id=\"ordernumber_info_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"padding: 6px; height: 2px; width: 350px;\">");
            lblQuote.Render(x, sb, screenHandle, viewHandle, session, page);
            lblOrderNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<a id=\"aChangeOrderNumber\" href=\"#\" style=\"position: absolute; top: 8px; text-decoration: none; font-size: xx-small;\" onclick=\"" + ActionScript("'change_ordernumber'", "''") + "\"><font color=\"#C0C0C0\">change</font></a>");
            lblStatus.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        </div>");
            s = " visibility: hidden; ";
            int count = TheQuote.DetailCountGet((ContextRz)x, Rz5.Enums.OrderLineStatus.Open);
            if (count > 0 && !TheQuote.isclosed)
                s = "";
            sb.AppendLine("        <div id=\"action1_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 4px; top: 0px; height: 60px; width: 125px; " + s + "\">");
            sb.AppendLine("<input id=\"cmdAction1\" type=\"button\" value=\"Sales Order\" onclick=\"" + ActionScript("'action1'") + "\">");
            Buttonize(viewHandle, "cmdAction1", "ordersmenu.png");
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
            sb.AppendLine(lblOrderNumber.PlaceRight(lblQuote, false, 10, 0));
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
            sb.AppendLine("$('#action1_" + Uid + "').css('left', $('#totals_box_" + Uid + "').position().left + 53);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('top', $('#ordernumber_info_" + Uid + "').position().top + $('#ordernumber_info_" + Uid + "').height() + 20);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', $('#ordernumber_info_" + Uid + "').width() + 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', 250);");
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
            sb.AppendLine(cboTerms.Select + ".css('top', " + xCompany.Select + ".position().top + " + xCompany.Select + ".height() + 5);");
            sb.AppendLine(txtFax.PlaceRight(txtPhone));
            sb.AppendLine(cboTerms.PlaceRight(txtFax));
            sb.AppendLine(txtEmail.PlaceBelow(txtPhone));

            sb.AppendLine(txtReference.PlaceBelow(txtEmail));
            sb.AppendLine(txtWarranty.PlaceBelow(txtEmail));
            sb.AppendLine(txtWarranty.PlaceRight(txtReference));

            sb.AppendLine(dtExpires.PlaceBelow(txtEmail));
            sb.AppendLine(dtExpires.PlaceRight(txtWarranty));
                
            sb.AppendLine(cboShipVia.PlaceBelow(txtPhone));
            sb.AppendLine(cboShipVia.PlaceRight(txtEmail));
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
        }
        private void UpdateControls(ContextRz x)
        {
            TheQuote.CalculateAllAmounts(x);
            lblSubTotal.ValueSet(x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheQuote.SubTotal(x)));
            lblOrderTotal.ValueSet(x.TheSys.CurrencySymbol + Tools.Number.MoneyFormat(TheQuote.ordertotal));
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
                    ChangeOrderDate((ContextRz)x, TheQuote.orderdate.ToString());
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
            lblQuote.AddPadding(GenAlign.Left, 20);
            if (TheQuote.isvoid)
                lblStatus.TextForeColor = Color.DarkGray;
            else if (TheQuote.isclosed)
                lblStatus.TextForeColor = Color.Blue;
            else if (TheQuote.onhold)
                lblStatus.TextForeColor = Color.Red;
            else
                lblStatus.TextForeColor = Color.Green;
            lblOrderNumber.AddPadding(GenAlign.Left, 20);
            lblQuote.AddPadding(GenAlign.Top, 1);
            lblOrderNumber.AddPadding(GenAlign.Top, 1);
            lblStatus.AddPadding(GenAlign.Top, 1);
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
            txtPhone.FixedWidth = 110;
            txtFax.CaptionFontSize = FontSize.XSmall;
            txtFax.TextFontSize = FontSize.XSmall;
            txtFax.FixedWidth = 110;
            txtEmail.CaptionFontSize = FontSize.XSmall;
            txtEmail.TextFontSize = FontSize.XSmall;
            txtEmail.FixedWidth = 230;

            txtWarranty.CaptionFontSize = FontSize.XSmall;
            txtWarranty.TextFontSize = FontSize.XSmall;
            txtWarranty.FixedWidth = 110;

            txtReference.CaptionFontSize = FontSize.XSmall;
            txtReference.TextFontSize = FontSize.XSmall;
            txtReference.FixedWidth = 110;

            dtExpires.CaptionFontSize = FontSize.XSmall;
            dtExpires.TextFontSize = FontSize.XSmall;
            dtExpires.FixedWidth = 100;

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
            txtBillingAdr.CaptionFontSize = FontSize.XSmall;
            txtBillingAdr.TextFontSize = FontSize.XSmall;
            txtBillingAdr.FixedWidth = 168;
            txtBillingAdr.Rows = 8;
            txtShippingAdr.CaptionFontSize = FontSize.XSmall;
            txtShippingAdr.TextFontSize = FontSize.XSmall;
            txtShippingAdr.FixedWidth = 168;
            txtShippingAdr.Rows = 8;
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
            aChangeDate.Render(x, sb, screenHandle, viewHandle, session, page);
            agentSalesAgent.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPhone.Render(x, sb, screenHandle, viewHandle, session, page);
            txtFax.Render(x, sb, screenHandle, viewHandle, session, page);
            txtEmail.Render(x, sb, screenHandle, viewHandle, session, page);
            txtWarranty.Render(x, sb, screenHandle, viewHandle, session, page);
            txtReference.Render(x, sb, screenHandle, viewHandle, session, page);
            dtExpires.Render(x, sb, screenHandle, viewHandle, session, page);
            cboTerms.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipVia.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private void ChangeOrderDate(ContextRz x, string date)
        {
            TheQuote.DateChange(x);
            txtOrderDate.ValueSet(TheQuote.orderdate.ToString());
            txtOrderDate.Change();
        }
        private void ChangeOrderNumber(ContextRz x)
        {
            TheQuote.NumberChange(x);
            lblOrderNumber.ValueSet(TheQuote.ordernumber);
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
        }
        private ArrayList LoadAddressList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            Rz5.company c = (Rz5.company)TheQuote.CompanyVar.RefGet(x);
            if (c == null)
                return a;
            a = x.SelectScalarArray("SELECT DISTINCT(DESCRIPTION) FROM companyaddress WHERE description > '' and base_company_uid = '" + c.unique_id + "' ORDER BY DESCRIPTION");
            a.Add("[local]");
            return a;
        }
        private ArrayList LoadAccountList(ContextRz x)
        {
            ArrayList a = new ArrayList();
            Rz5.company c = (Rz5.company)TheQuote.CompanyVar.RefGet(x);
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
                        if (!Tools.Strings.StrCmp(contactname, TheQuote.ContactVar.RefGet(x).contactname))
                        {
                            x.TheLeader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txtBillingAdr.Value = TheQuote.ContactVar.RefGet(x).BuildAddress();
                    }
                    else if (val.ToLower().StartsWith("address option"))
                    {
                        txtBillingAdr.Value = x.GetSetting(val);
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(x, TheQuote.base_company_uid, val);
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
                        if (!Tools.Strings.StrCmp(contactname, TheQuote.ContactVar.RefGet(x).contactname))
                        {
                            x.TheLeader.Tell("This doesn't appear to be the same contact that's assigned to this order.");
                            return;
                        }
                        txtShippingAdr.Value = TheQuote.ContactVar.RefGet(x).BuildAddress();
                    }
                    else if (val.ToLower().StartsWith("address option"))
                    {
                        txtShippingAdr.Value = x.GetSetting(val);
                    }
                    else
                    {
                        companyaddress a = companyaddress.GetByDescription(x, TheQuote.base_company_uid, val);
                        if (a != null)
                            txtShippingAdr.Value = a.GetAddressString(x);
                    }
                    break;
            }
            txtShippingAdr.Change();
        }
        private void Action1(ContextRz x)
        {
            if (TheQuote == null)
                return;
            ordhed_sales sale_result = TheQuote.SalesOrderCreate(x);
            if (sale_result != null)
                x.Show(new ShowArgsOrder(x, sale_result, Rz5.Enums.OrderType.Sales));
        }
        private string GetStatus(ContextRz x)
        {
            if (TheQuote.isvoid)
                return "Void";
            else if (TheQuote.isclosed)
                return "Complete";
            else if (TheQuote.onhold)
                return "Hold";
            else
                return "Open";
        }
        private void xCompany_CompanyChanged(ContextNM x, company c, ViewHandle v)
        {
            if (c == null)
                return;
            TheQuote.CompanyVar.RefSet(x, c);
            TheQuote.AbsorbCompany((ContextRz)x, c);
            TheQuote.Update(x);
            LoadAccountList((ContextRz)x);
            cboTerms.ValueSet(TheQuote.terms);
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
            TheQuote.ContactVar.RefSet(x, c);
            TheQuote.Update(x);
        }
        private void lvDetails_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            orddet_quote d = null;
            try { d = (orddet_quote)item; }
            catch { }
            if (d == null)
                return;
            RzWeb.FormalQuoteLine q = new RzWeb.FormalQuoteLine((ContextRz)x, d);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void lvDetails_AddNewItem(Context x, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (!Tools.Strings.StrExt(TheQuote.base_company_uid))
            {
                x.TheLeader.Tell("You need to select a company for this order before adding new lines.");
                return;
            }
            TheQuote.DetailAddWithChecks((ContextRz)x);
            TheQuote.Update((ContextRz)x);
            TheView.ScriptsToRun.Add("window.close();");
        }
    }
    public class ListViewSpotQuote : ListViewSpotRz
    {
        public ListViewSpotQuote()
            : base("orddet_quote")
        {
        }
    }
}

