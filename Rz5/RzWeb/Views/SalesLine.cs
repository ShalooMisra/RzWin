using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using Core;
using CoreWeb;
using Rz5;
using Rz5.Web;
using NewMethod;

namespace RzWeb
{
    public class SalesLine : Line
    {
        public orddet_line TheLine
        {
            get
            {
                return (orddet_line)Item;
            }
        }
        LabelControl lblOrderNumber;
        AnchorControl aViewOrder;
        LabelControl lblStatus;
        TextControl txtPart;
        Int32Control txtQuantity;
        MoneyControl txtUnitCost;
        MoneyControl txtUnitPrice;
        TextControl txtMFG;
        TextControl txtDC;
        RzWeb.ChoicesControl cboCondition;
        RzWeb.ChoicesControl cboPackage;
        RzWeb.ChoicesControl cboCategory;
        TextControl txtDescription;
        TextControl txtAltPart;
        TextControl txtCustPart;
        ComboBoxControl cboROHS;
        RzWeb.ChoicesControl cboShipVia;
        ComboBoxControl cboShipAccount;
        TextAreaControl txtTracking;
        TextAreaControl txtComments;
        LabelControl lblMaterialFrom;
        RadioButtonControl optStockType;
        AnchorControl aChooseVendor; 
        AnchorControl aChooseBid;
        ComboBoxControl cboStockLot;
        ComboBoxControl cboConsignLot;
        LabelControl lblVendorName;
        LabelControl lblVendorContact;
        DateControl txtShipDateDue;
        AnchorControl aLinkStock;
        ViewHandle TheView;
        System.Web.SessionState.HttpSessionState TheSession;
        System.Web.UI.Page ThePage;

        public SalesLine(ContextRz context, orddet_line line)
            : base(context, line)
        {
            xActions.TheSetup = new ActSetupOrder(Rz5.Enums.OrderType.Sales);
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", "Sales " + line.ordernumber_sales + " Line Item")));
            string name = "";
            if (line.OrderObjectGet(context, Rz5.Enums.OrderType.Sales) != null)
                name = "Click To View Order";
            aViewOrder = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewOrder", name, "ShowOrder()")));
            string status = GetStatus();
            lblStatus = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStatus", "", status)));
            txtPart = (TextControl)SpotAdd(ControlAdd(new TextControl("fullpartnumber", "Part #", line.fullpartnumber)));
            txtQuantity = (Int32Control)SpotAdd(ControlAdd(new Int32Control("quantity", "Quantity", line.quantity)));
            txtUnitCost = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("unit_cost", "Unit Cost", line.unit_cost)));
            txtUnitPrice = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("unit_price", "Unit Price", line.unit_price)));
            txtMFG = (TextControl)SpotAdd(ControlAdd(new TextControl("manufacturer", "Manufacturer", line.manufacturer)));
            txtDC = (TextControl)SpotAdd(ControlAdd(new TextControl("datecode", ((ContextRz)context).DateCodeCaption, line.datecode)));
            cboCondition = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("condition", "Condition", line.condition, GetChoiceList(context, "condition"), "", "condition")));
            cboPackage = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("packaging", "Packaging", line.packaging, GetChoiceList(context, "packaging"), "", "packaging")));
            cboCategory = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("category", "Category", line.category, GetChoiceList(context, "category"), "", "category")));
            txtDescription = (TextControl)SpotAdd(ControlAdd(new TextControl("description", "Description", line.description)));
            txtAltPart = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatepart", "Alternate Part #", line.alternatepart)));
            txtCustPart = (TextControl)SpotAdd(ControlAdd(new TextControl("internal_customer", "Customer Part #", line.internal_customer)));
            txtShipDateDue = (DateControl)SpotAdd(ControlAdd(new DateControl("ship_date_due", "Ship Date Due", line.ship_date_due)));
            ArrayList a = new ArrayList();
            a.Add("Y");
            a.Add("N");
            a.Add("U");
            cboROHS = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("rohs_info", "RoHS Info", line.rohs_info, a)));
            cboShipVia = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shipvia_invoice", "Ship Via", line.shipvia_invoice, GetChoiceList(context, "shipvia"), "", "shipvia")));
            cboShipAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("shippingaccount_invoice", "Shipping Account", line.shippingaccount_invoice, GetShippingAccounts(context))));
            txtTracking = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("tracking_invoice", "Tracking Numbers", line.tracking_invoice)));
            txtComments = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comments", line.internalcomment)));
            lblMaterialFrom = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblMaterialFrom", "", "The material is coming from:")));
            string s = "";
            if (line.StockType == Rz5.Enums.StockType.Stock)
                s = Rz5.consignment_code.RenderCode(context, line.lotnumber);
            cboStockLot = (ComboBoxControlPart)SpotAdd(ControlAdd(new ComboBoxControlPart("lotnumber", "Lot #", s, GetLotCodes(context, true))));
            if (line.StockType != Rz5.Enums.StockType.Stock)
                cboStockLot.Visible = false;
            s = "";
            if (line.StockType == Rz5.Enums.StockType.Consign)
                s = Rz5.consignment_code.RenderCode(context, line.lotnumber);
            cboConsignLot = (ComboBoxControlPart)SpotAdd(ControlAdd(new ComboBoxControlPart("lotnumber", "Lot #", s, GetLotCodes(context, false))));
            if (line.StockType != Rz5.Enums.StockType.Consign)
                cboConsignLot.Visible = false;
            aChooseVendor = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChooseVendor", "choose a vendor", ActionScript("'choose_company'", "'na'"))));
            aChooseBid = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aChooseBid", "choose a bid", ActionScript("'choose_bid'", "'na'"))));
            string action = "allocate";
            string caption = "allocate inventory";
            if (Tools.Strings.StrExt(TheLine.inventory_link_uid))
            {
                Rz5.partrecord p = Rz5.partrecord.GetById(context, TheLine.inventory_link_uid);
                if (p == null)
                {
                    TheLine.inventory_link_uid = "";
                    TheLine.Update(context);
                }
                else
                {
                    action = "view_stock";
                    caption = "view allocation";
                }
            }
            aLinkStock = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aLinkStock", caption, ActionScript("'" + action + "'", "'na'"))));            
            lblVendorName = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblVendorName", "", TheLine.vendor_name)));
            lblVendorContact = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblVendorContact", "", TheLine.vendor_contact_name)));
            if (line.StockType != Rz5.Enums.StockType.Buy)
            {
                aChooseVendor.Visible = false;
                lblVendorName.Visible = false;
                lblVendorContact.Visible = false;
            }
            if (Tools.Strings.StrCmp(line.stocktype, "undefined") || !Tools.Strings.StrExt(line.stocktype))
                line.stocktype = "Buy";
            optStockType = (RadioButtonControl)SpotAdd(ControlAdd(new RadioButtonControl("stocktype", "", line.stocktype.ToLower(), GetStockTypeOptions())));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Sales Line";
            if (TheLine != null)
                s = "Sales " + TheLine.ordernumber_sales + " Line";
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            TheSession = session;
            ThePage = page;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"viewinvoice_" + Uid + "\" style=\"position: absolute; top: 0px;\">");
            //tabs
            sb.AppendLine("        <div id=\"tabHeader_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabHeaderNav\">");
            sb.AppendLine("                <li><a href=\"#tabInfo\" style=\"font-size: xx-small\">Info</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabInfo\">");
            RenderInfoTab(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sbb = new StringBuilder();
            sbb.AppendLine("function ParseLot(lotNumb)");
            sbb.AppendLine("{");
            sbb.AppendLine("    var s = lotNumb.split(\":\");");
            sbb.AppendLine("    return s[0].trim();");
            sbb.AppendLine("}");
            sbb.AppendLine("function GetLotValue()");
            sbb.AppendLine("{");
            sbb.AppendLine("        if($('#" + optStockType.ControlId + "_stock:checked').val() == 'stock')");
            sbb.AppendLine("        {");
            sbb.AppendLine("            return ParseLot($('#" + cboStockLot.ControlId + "').val());");
            sbb.AppendLine("        }");
            sbb.AppendLine("        if($('#" + optStockType.ControlId + "_consign:checked').val() == 'consign')");
            sbb.AppendLine("        {");
            sbb.AppendLine("            return ParseLot($('#" + cboConsignLot.ControlId + "').val());");
            sbb.AppendLine("        }");
            sbb.AppendLine("        return \"\";");
            sbb.AppendLine("}");
            sbb.AppendLine("function ShowOrder() {");
            sbb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sbb.AppendLine(c.ValueAddScript("data"));
            }
            sbb.AppendLine(ActionScript("'save'", "data"));
            sbb.AppendLine(ActionScript("'show_order'"));
            sbb.AppendLine("}");
            viewHandle.Definitions.Add(sbb.ToString());
            viewHandle.ScriptsToRun.Add("$('#tabHeader_" + Uid + "').tabs( { select: function(event, ui) { " + ActionScript("'tabShow'", "ui.panel.id") + " } });");
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('top', $('#rz_menu').height() + $('#rz_menu').position().top + 10);");
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('height', $(window).height() - $('#viewinvoice_" + Uid + "').position().top - 70);");
            sb.AppendLine("$('#viewinvoice_" + Uid + "').css('width', " + xActions.Select + ".position().left - $('#viewinvoice_" + Uid + "').position().left - 15);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('top', 0);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', 600);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', 373);");
            lblOrderNumber.TextFontSize = FontSize.Large;
            sb.AppendLine(lblOrderNumber.Select + ".css('top', 5);");
            sb.AppendLine(lblOrderNumber.Select + ".css('left', 5);");
            sb.AppendLine(aViewOrder.Select + ".css('top', 12);");
            sb.AppendLine(aViewOrder.PlaceRight(lblOrderNumber, false, 14, 0));
            sb.AppendLine(lblStatus.Select + ".css('top', 5);");
            sb.AppendLine(lblStatus.Select + ".css('left', $('#tabHeader_" + Uid + "').width() - " + lblStatus.Select + ".width() - 5);");
            sb.AppendLine(txtPart.PlaceBelow(lblOrderNumber));
            sb.AppendLine(txtPart.Select + ".css('left', 5);");
            sb.AppendLine(txtQuantity.PlaceBelow(lblOrderNumber));
            sb.AppendLine(txtQuantity.PlaceRight(txtPart));
            sb.AppendLine(txtUnitCost.PlaceBelow(lblOrderNumber));
            sb.AppendLine(txtUnitCost.PlaceRight(txtQuantity));
            sb.AppendLine(txtUnitPrice.PlaceBelow(lblOrderNumber));
            sb.AppendLine(txtUnitPrice.PlaceRight(txtUnitCost));
            sb.AppendLine(txtMFG.Select + ".css('left', 5);");
            sb.AppendLine(txtMFG.PlaceBelow(txtPart));
            sb.AppendLine(txtDC.PlaceBelow(txtPart));
            sb.AppendLine(txtDC.PlaceRight(txtMFG));
            sb.AppendLine(cboCondition.PlaceBelow(txtPart));
            sb.AppendLine(cboCondition.PlaceRight(txtDC));
            sb.AppendLine(cboPackage.PlaceBelow(txtPart));
            sb.AppendLine(cboPackage.PlaceRight(cboCondition));
            sb.AppendLine(cboCategory.Select + ".css('left', 5);");
            sb.AppendLine(cboCategory.PlaceBelow(txtMFG));
            sb.AppendLine(txtDescription.PlaceBelow(txtMFG));
            sb.AppendLine(txtDescription.PlaceRight(cboCategory));
            sb.AppendLine(txtShipDateDue.PlaceBelow(txtMFG));
            sb.AppendLine(txtShipDateDue.PlaceRight(txtDescription));          
            sb.AppendLine(txtAltPart.Select + ".css('left', 5);");
            sb.AppendLine(txtAltPart.PlaceBelow(txtDescription));
            sb.AppendLine(txtCustPart.PlaceBelow(txtDescription));
            sb.AppendLine(txtCustPart.PlaceRight(txtAltPart));
            sb.AppendLine(cboROHS.PlaceBelow(txtDescription));
            sb.AppendLine(cboROHS.PlaceRight(txtCustPart));
            sb.AppendLine(cboShipVia.Select + ".css('left', 5);");
            sb.AppendLine(cboShipVia.PlaceBelow(txtAltPart));
            sb.AppendLine(cboShipAccount.PlaceBelow(txtAltPart));
            sb.AppendLine(cboShipAccount.PlaceRight(cboShipVia));
            sb.AppendLine(txtTracking.PlaceBelow(txtDescription));
            sb.AppendLine(txtTracking.PlaceRight(cboROHS));
            sb.AppendLine(lblMaterialFrom.PlaceBelow(cboShipVia, false, 5, 0));
            sb.AppendLine(lblMaterialFrom.Select + ".css('left', 10);");
            sb.AppendLine(optStockType.PlaceBelow(lblMaterialFrom));
            sb.AppendLine(optStockType.Select + ".css('left', 10);");
            sb.AppendLine(cboStockLot.PlaceBelow(optStockType));
            sb.AppendLine(cboStockLot.Select + ".css('left', 20);");
            sb.AppendLine(cboConsignLot.PlaceBelow(optStockType));
            sb.AppendLine(cboConsignLot.PlaceRight(cboStockLot, false, 4, 0));
            sb.AppendLine(aChooseVendor.PlaceBelow(lblMaterialFrom, false, 10, 0));
            sb.AppendLine(aChooseVendor.PlaceRight(optStockType));
            sb.AppendLine(aChooseBid.PlaceBelow(aChooseVendor, false, 0, 2));
            sb.AppendLine(aChooseBid.PlaceRight(optStockType));
            sb.AppendLine(aLinkStock.PlaceBelow(optStockType, false, 0, 4));
            sb.AppendLine(aLinkStock.Select + ".css('left', 60);");
            sb.AppendLine(aLinkStock.Select + ".css('z-index', 1000);");
            sb.AppendLine(lblVendorName.PlaceBelow(lblMaterialFrom));
            sb.AppendLine(lblVendorName.PlaceRight(aChooseVendor, false, 50, 0));
            sb.AppendLine(lblVendorContact.PlaceBelow(lblVendorName));
            sb.AppendLine(lblVendorContact.PlaceRight(aChooseVendor, false, 50, 0));
            sb.AppendLine(txtComments.Select + ".css('left', 5);");
            sb.AppendLine(txtComments.PlaceBelow(cboStockLot, false, 2, 0));
            sb.AppendLine(aChooseBid.Select + ".css('z-index', 1000);");            
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId.ToLower ())
            {
                case "choose_bid":
                    ChooseBid((ContextRz)x);
                    break;
                case "choose_company":
                    ChooseCompany((ContextRz)x);
                    ChooseContact((ContextRz)x);
                    break;
                case "view_stock":
                    ViewStockLink((ContextRz)x);
                    break;
                case "allocate":
                    AllocateStock((ContextRz)x);
                    break;
                case "show_order":
                    ShowOrder((ContextRz)x);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        protected override void SaveData(Context x, SpotActArgs args, Dictionary<string, string> values)
        {
            if (TheLine.StockType == Rz5.Enums.StockType.Buy && !TheLine.needs_purchasing)
            {
                TheLine.StockType = Rz5.Enums.StockType.Buy;
                TheLine.lotnumber = "BUY";
                TheLine.needs_purchasing = true;
            }
        }
        private string GetStatus()
        {
            if (TheLine.isvoid)
                return "Void";
            if (TheLine.Status == Rz5.Enums.OrderLineStatus.Hold)
                return "Hold";
            if (TheLine.Status == Rz5.Enums.OrderLineStatus.Open)
                return "Open";
            else
                return Tools.Strings.NiceFormat(TheLine.Status.ToString());
        }
        private void AdjustControls()
        {
            lblOrderNumber.TextFontSize = FontSize.Large;
            aViewOrder.TextFontSize = FontSize.XSmall;
            lblStatus.TextFontSize = FontSize.Large;
            if (TheLine.isvoid)
                lblStatus.TextForeColor = Color.DarkGray;
            if (TheLine.Status == Rz5.Enums.OrderLineStatus.Hold)
                lblStatus.TextForeColor = Color.Red;
            if (TheLine.Status == Rz5.Enums.OrderLineStatus.Open)
                lblStatus.TextForeColor = Color.DarkGreen;
            else
                lblStatus.TextForeColor = Color.DarkBlue;
            txtPart.CaptionFontSize = FontSize.XXSmall;
            txtPart.TextFontSize = FontSize.XXSmall;
            txtPart.FixedWidth = 147;
            txtQuantity.CaptionFontSize = FontSize.XXSmall;
            txtQuantity.TextFontSize = FontSize.XXSmall;
            txtQuantity.FixedWidth = 147;
            txtUnitCost.CaptionFontSize = FontSize.XXSmall;
            txtUnitCost.TextFontSize = FontSize.XXSmall;
            txtUnitCost.FixedWidth = 135;
            txtUnitPrice.CaptionFontSize = FontSize.XXSmall;
            txtUnitPrice.TextFontSize = FontSize.XXSmall;
            txtUnitPrice.FixedWidth = 130;
            txtMFG.CaptionFontSize = FontSize.XXSmall;
            txtMFG.TextFontSize = FontSize.XXSmall;
            txtMFG.FixedWidth = 147;
            txtDC.CaptionFontSize = FontSize.XXSmall;
            txtDC.TextFontSize = FontSize.XXSmall;
            txtDC.FixedWidth = 147;
            cboCondition.CaptionFontSize = FontSize.XXSmall;
            cboCondition.TextFontSize = FontSize.XXSmall;
            cboCondition.FixedWidth = 142;
            cboPackage.CaptionFontSize = FontSize.XXSmall;
            cboPackage.TextFontSize = FontSize.XXSmall;
            cboPackage.FixedWidth = 135;
            cboCategory.CaptionFontSize = FontSize.XXSmall;
            cboCategory.TextFontSize = FontSize.XXSmall;
            cboCategory.FixedWidth = 155;
            txtDescription.CaptionFontSize = FontSize.XXSmall;
            txtDescription.TextFontSize = FontSize.XXSmall;
            txtDescription.FixedWidth = 290;
            txtShipDateDue.CaptionFontSize = FontSize.XXSmall;
            txtShipDateDue.TextFontSize = FontSize.XXSmall;
            txtShipDateDue.FixedWidth = 130;
            txtAltPart.CaptionFontSize = FontSize.XXSmall;
            txtAltPart.TextFontSize = FontSize.XXSmall;
            txtAltPart.FixedWidth = 147;
            txtCustPart.CaptionFontSize = FontSize.XXSmall;
            txtCustPart.TextFontSize = FontSize.XXSmall;
            txtCustPart.FixedWidth = 147;
            cboROHS.CaptionFontSize = FontSize.XXSmall;
            cboROHS.TextFontSize = FontSize.XXSmall;
            cboROHS.FixedWidth = 50;
            cboShipVia.CaptionFontSize = FontSize.XXSmall;
            cboShipVia.TextFontSize = FontSize.XXSmall;
            cboShipVia.FixedWidth = 155;
            cboShipAccount.CaptionFontSize = FontSize.XXSmall;
            cboShipAccount.TextFontSize = FontSize.XXSmall;
            cboShipAccount.FixedWidth = 142;
            txtTracking.CaptionFontSize = FontSize.XXSmall;
            txtTracking.TextFontSize = FontSize.XXSmall;
            txtTracking.FixedWidth = 220;
            txtComments.CaptionFontSize = FontSize.XXSmall;
            txtComments.TextFontSize = FontSize.XXSmall;
            txtComments.FixedWidth = 585;
            txtComments.Rows = 2;
            lblMaterialFrom.TextFontSize = FontSize.XXSmall;
            aChooseVendor.TextFontSize = FontSize.XXSmall;
            aChooseBid.TextFontSize = FontSize.XXSmall;
            aLinkStock.TextFontSize = FontSize.XXSmall;
            cboStockLot.FixedWidth = 130;
            cboStockLot.CaptionFontSize = FontSize.XXSmall;
            cboStockLot.TextFontSize = FontSize.XXSmall;
            cboConsignLot.FixedWidth = 130;
            cboConsignLot.CaptionFontSize = FontSize.XXSmall;
            cboConsignLot.TextFontSize = FontSize.XXSmall;
            lblVendorName.TextFontSize = FontSize.XXSmall;
            lblVendorContact.TextFontSize = FontSize.XXSmall;
        }
        private void RenderInfoTab(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            lblOrderNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            aViewOrder.Render(x, sb, screenHandle, viewHandle, session, page);
            lblStatus.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPart.Render(x, sb, screenHandle, viewHandle, session, page);
            txtQuantity.Render(x, sb, screenHandle, viewHandle, session, page);
            txtUnitCost.Render(x, sb, screenHandle, viewHandle, session, page);
            txtUnitPrice.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMFG.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDC.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCondition.Render(x, sb, screenHandle, viewHandle, session, page);
            cboPackage.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCategory.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescription.Render(x, sb, screenHandle, viewHandle, session, page);
            txtShipDateDue.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAltPart.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCustPart.Render(x, sb, screenHandle, viewHandle, session, page);
            cboROHS.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipVia.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            txtTracking.Render(x, sb, screenHandle, viewHandle, session, page);
            txtComments.Render(x, sb, screenHandle, viewHandle, session, page);
            lblMaterialFrom.Render(x, sb, screenHandle, viewHandle, session, page);
            switch (TheLine.StockType)
            {
                case Rz5.Enums.StockType.Stock:
                    cboStockLot.Visible = true;
                    cboConsignLot.Visible = false;
                    aChooseVendor.Visible = false;
                    aChooseBid.Visible = false;
                    lblVendorName.Visible = false;
                    lblVendorContact.Visible = false;
                    aLinkStock.Visible = true;
                    break;
                case Rz5.Enums.StockType.Consign:
                    cboStockLot.Visible = false;
                    cboConsignLot.Visible = true;
                    aChooseVendor.Visible = false;
                    aChooseBid.Visible = false;
                    lblVendorName.Visible = false;
                    lblVendorContact.Visible = false;
                    aLinkStock.Visible = true;
                    break;
                default:
                    cboStockLot.Visible = false;
                    cboConsignLot.Visible = false;
                    aChooseVendor.Visible = true;
                    aChooseBid.Visible = true;
                    lblVendorName.Visible = true;
                    lblVendorContact.Visible = true;
                    aLinkStock.Visible = false;
                    break;
            }
            optStockType.Render(x, sb, screenHandle, viewHandle, session, page);
            aChooseVendor.Render(x, sb, screenHandle, viewHandle, session, page);
            aChooseBid.Render(x, sb, screenHandle, viewHandle, session, page);
            aLinkStock.Render(x, sb, screenHandle, viewHandle, session, page);
            cboStockLot.Render(x, sb, screenHandle, viewHandle, session, page);
            cboConsignLot.Render(x, sb, screenHandle, viewHandle, session, page);
            lblVendorName.Render(x, sb, screenHandle, viewHandle, session, page);
            lblVendorContact.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private ArrayList GetShippingAccounts(ContextRz x)
        {
            ArrayList a = new ArrayList();
            if (TheLine.SalesVar.RefGet(x) == null)
                return a;
            bool added = false;
            if (TheLine.SalesVar.RefGet(x).CompanyVar.RefGet(x) != null)
            {
                ArrayList aa = x.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + TheLine.SalesVar.RefGet(x).CompanyVar.RefGet(x).unique_id + "' ORDER BY ACCOUNTNUMBER");
                if (aa != null && aa.Count > 0)
                    added = true;
                foreach (string s in aa)
                {
                    if (Tools.Strings.StrExt(s))
                        a.Add(s);
                }
            }
            if (added)
                a.Add("________________________");
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
        private ArrayList GetLotCodes(ContextRz x, bool is_stock)
        {
            ArrayList stock = new ArrayList();
            ArrayList consign = new ArrayList();
            foreach (String lot in Rz5.consignment_code.CodesList(x))
            {
                if (lot.Contains("[STOCK]"))
                    stock.Add(lot);
                else
                    consign.Add(lot);
            }
            if (is_stock)
                return stock;
            else
                return consign;
        }
        private RadioControlConfig GetStockTypeOptions()
        {
            RadioControlConfig c = new RadioControlConfig();
            //Stock
            RadioControlConfig r = new RadioControlConfig();
            r.Caption = "Stock";
            r.Value = "stock";
            r.FontSize = FontSize.XSmall;
            r.OnClick = "ShowDiv('" + cboStockLot.InnerDivId + "'); ShowDiv('" + aLinkStock.InnerDivId + "'); HideDiv('" + cboConsignLot.InnerDivId + "'); HideDiv('" + lblVendorName.InnerDivId + "'); HideDiv('" + lblVendorContact.InnerDivId + "'); HideDiv('" + aChooseVendor.InnerDivId + "'); HideDiv('" + aChooseBid.InnerDivId + "');";
            r.Bold = true;
            c.AllOptions.Add(r);
            //Consign
            r = new RadioControlConfig();
            r.Caption = "Consignment";
            r.Value = "consign";
            r.FontSize = FontSize.XSmall;
            r.OnClick = "ShowDiv('" + cboConsignLot.InnerDivId + "'); ShowDiv('" + aLinkStock.InnerDivId + "'); HideDiv('" + cboStockLot.InnerDivId + "'); HideDiv('" + lblVendorName.InnerDivId + "'); HideDiv('" + lblVendorContact.InnerDivId + "'); HideDiv('" + aChooseVendor.InnerDivId + "'); HideDiv('" + aChooseBid.InnerDivId + "');";
            r.Bold = true;
            c.AllOptions.Add(r);
            //Excess
            r = new RadioControlConfig();
            r.Caption = "Vendor";
            r.Value = "buy";
            r.FontSize = FontSize.XSmall;
            r.OnClick = "HideDiv('" + cboStockLot.InnerDivId + "'); HideDiv('" + aLinkStock.InnerDivId + "'); HideDiv('" + cboConsignLot.InnerDivId + "'); ShowDiv('" + lblVendorName.InnerDivId + "'); ShowDiv('" + lblVendorContact.InnerDivId + "'); ShowDiv('" + aChooseVendor.InnerDivId + "'); ShowDiv('" + aChooseBid.InnerDivId + "');";
            r.Bold = true;
            c.AllOptions.Add(r);
            return c;
        }
        private void ChooseCompany(ContextRz x)
        {           
            Rz5.company c = ((LeaderWebUserRz)x.TheLeader).AskForCompany((Rz5.ContextRz)x, "Please choose a company below:", TheLine.vendor_uid);
            if (c == null)
                return;
            aChooseVendor.Visible = true;
            lblVendorName.Visible = true;
            lblVendorContact.Visible = true;
            TheLine.vendor_uid = c.unique_id;
            TheLine.vendor_name = c.companyname;
            lblVendorName.ValueSet(TheLine.vendor_name);
            lblVendorName.Change();
            TheLine.VendorVar.RefSet(x, c);
            TheLine.Update(x);
        }
        private void ChooseContact(ContextRz x)
        {
            Rz5.companycontact c = ((LeaderWebUserRz)x.TheLeader).AskForContact((Rz5.ContextRz)x, "Please choose a contact below:", TheLine.vendor_contact_uid, TheLine.vendor_uid);
            if (c == null)
                return;
            TheLine.vendor_contact_uid = c.unique_id;
            TheLine.vendor_contact_name = c.contactname;
            lblVendorContact.ValueSet(TheLine.vendor_contact_name);
            lblVendorContact.Change();
            TheLine.VendorContactVar.RefSet(x, c);
            TheLine.Update(x);
        }
        private void ChooseBid(ContextRz x)
        {
            orddet_rfq b = ((Rz5.Web.LeaderWebUserRz)x.TheLeader).AskForVendorBid((Rz5.ContextRz)x, "Please choose a bid below:", TheLine.fullpartnumber, TheScreen, TheView, TheSession, ThePage);
            if (b == null)
                return;
            aChooseBid.Visible = true;
            aChooseVendor.Visible = true;
            lblVendorName.Visible = true;
            lblVendorContact.Visible = true;
            TheLine.vendor_uid = b.base_company_uid;
            TheLine.vendor_name = b.companyname;
            TheLine.vendor_contact_uid = b.base_companycontact_uid;
            TheLine.vendor_contact_name = b.contactname;
            if (Tools.Strings.StrExt(b.manufacturer))
                TheLine.manufacturer = b.manufacturer;
            if (Tools.Strings.StrExt(b.datecode))
                TheLine.datecode = b.datecode;
            if (Tools.Strings.StrExt(b.packaging))
                TheLine.packaging = b.packaging;
            if (Tools.Strings.StrExt(b.condition))
                TheLine.condition = b.condition;
            TheLine.unit_cost = b.unitprice;
            UpdateControls();
        }
        private void AllocateStock(ContextRz x)
        {
            Rz5.partrecord p = ((LeaderWebUserRz)x.TheLeader).AskForInventoryItem((Rz5.ContextRz)x, "Please choose a stock item below:", TheLine.fullpartnumber, TheScreen, TheView, TheSession, ThePage);
            if (p == null)
                return;
            if ((p.quantity - p.quantityallocated) < TheLine.quantity)
            {
                x.TheLeader.Error("This item does not have enough free quantity to allocate");
                return;
            }
            TheLine.inventory_link_uid = p.unique_id;
            TheLine.inventory_link_caption = p.ToString();
            TheLine.stocktype = p.stocktype;
            TheLine.lotnumber = p.lotnumber;
            if (x.TheLeader.AskYesNo("Would you like to apply this selected parts information onto this line item?(D/C,Mfg,Cond,Pkg,Loc)"))
            {  
                if (Tools.Strings.StrExt(p.datecode))
                    TheLine.datecode = p.datecode;
                if (Tools.Strings.StrExt(p.manufacturer))
                    TheLine.manufacturer = p.manufacturer;
                if (Tools.Strings.StrExt(p.condition))
                    TheLine.condition = p.condition;
                if (Tools.Strings.StrExt(p.packaging))
                    TheLine.packaging = p.packaging;
                if (Tools.Strings.StrExt(p.location))
                    TheLine.receive_location = p.location;
            }
            if (p.StockType == Rz5.Enums.StockType.Consign)
            {
                if (!Tools.Strings.StrExt(p.base_company_uid))
                {
                    x.TheLeader.Error("This consignment item " + p.ToString() + " is not linked to a supplier and cannot be attached to an order until this is set.");
                    return;
                }
                TheLine.vendor_name = p.companyname;
                TheLine.vendor_uid = p.base_company_uid;
                TheLine.vendor_contact_name = p.companycontactname;
                TheLine.vendor_contact_uid = p.base_companycontact_uid;
                TheLine.lotnumber = p.consignment_code;
                TheLine.consignment_code = p.consignment_code;
            }
            x.Update(TheLine);
            p.Allocate(x, TheLine.quantity, "Sales Order " + TheLine.ordernumber_sales, TheLine.unique_id);
            UpdateControls();
        }
        private void ViewStockLink(ContextRz x)
        {
            Rz5.partrecord p = Rz5.partrecord.GetById(x, TheLine.inventory_link_uid);
            if (p == null)
            {
                x.TheLeader.Tell("This inventory part could not be found.");
                TheLine.inventory_link_uid = "";
                TheLine.Update(x);
                return; 
            }
            x.Show(p);
        }
        private void UpdateControls()
        {
            txtDC.ValueSet(TheLine.datecode);
            txtMFG.ValueSet(TheLine.manufacturer);
            cboCondition.ValueSet(TheLine.condition);
            cboPackage.ValueSet(TheLine.packaging);
            lblVendorName.ValueSet(TheLine.vendor_name);         
            lblVendorContact.ValueSet(TheLine.vendor_contact_name);       
            txtUnitCost.ValueSet(TheLine.unit_cost);                                    
            txtDC.Change();
            txtMFG.Change();
            cboCondition.Change();
            cboPackage.Change();
            lblVendorName.Change();
            lblVendorContact.Change();
            txtUnitCost.Change();
        }
        private void ShowOrder(ContextRz x)
        {
            RzWeb.Sales q = new RzWeb.Sales((ContextRz)x, (ordhed_sales)TheLine.OrderObjectGet(x, Rz5.Enums.OrderType.Sales));
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
    public class ComboBoxControlPart : ComboBoxControl
    {
        public ComboBoxControlPart(String name, String caption, String value, ArrayList choices, String on_change = "", bool skip_parent_render = true)
            : base(name, caption, value, choices, on_change, skip_parent_render)
        {

        }
        public override string ValueAddScript(string varName)
        {
            return varName + " += '|" + Name + ":' + ConvertToPostString(GetLotValue());";
        }
    }
}