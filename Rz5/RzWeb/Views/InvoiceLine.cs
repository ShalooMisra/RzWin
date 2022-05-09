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
    public class InvoiceLine : Line
    {
        public orddet_line TheLine
        {
            get
            {
                return (orddet_line)Item;
            }
        }
        ContextRz TheContext;
        LabelControl lblOrderNumber;
        AnchorControl aViewOrder;
        LabelControl lblStatus;
        TextControl txtPart;
        Int32Control txtQuantity;
        LabelControl lblPacked;
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
        PackControl xPack;
        LabelControl lblShipDateActual;
        ViewHandle TheView;

        public InvoiceLine(ContextRz context, orddet_line line)
            : base(context, line)
        {
            xActions.TheSetup = new ActSetupOrder(Rz5.Enums.OrderType.Invoice);
            TheContext = context;
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", "Invoice " + line.ordernumber_invoice + " Line Item")));
            string name = "";
            if (line.OrderObjectGet(context, Rz5.Enums.OrderType.Invoice) != null)
                name = "Click To View Order";
            aViewOrder = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewOrder", name, "ShowOrder()")));
            string status = GetStatus();
            lblStatus = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStatus", "", status)));
            txtPart = (TextControl)SpotAdd(ControlAdd(new TextControl("fullpartnumber", "Part #", line.fullpartnumber)));
            txtQuantity = (Int32Control)SpotAdd(ControlAdd(new Int32Control("quantity", "Quantity", line.quantity)));
            lblPacked = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblPacked", "Packed", Tools.Number.LongFormat(line.quantity_packed))));
            txtUnitPrice = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("unit_price", "Unit Price", line.unit_price)));
            txtMFG = (TextControl)SpotAdd(ControlAdd(new TextControl("manufacturer", "Manufacturer", line.manufacturer)));
            txtDC = (TextControl)SpotAdd(ControlAdd(new TextControl("datecode", ((ContextRz)TheContext).DateCodeCaption, line.datecode)));
            cboCondition = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("condition", "Condition", line.condition, GetChoiceList(context, "condition"), "", "condition")));
            cboPackage = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("packaging", "Packaging", line.packaging, GetChoiceList(context, "packaging"), "", "packaging")));
            cboCategory = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("category", "Category", line.category, GetChoiceList(context, "category"), "", "category")));            
            txtDescription = (TextControl)SpotAdd(ControlAdd(new TextControl("description", "Description", line.description)));
            txtAltPart = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatepart", "Alternate Part #", line.alternatepart)));
            txtCustPart = (TextControl)SpotAdd(ControlAdd(new TextControl("internal_customer", "Customer Part #", line.internal_customer)));
            status = "";
            if (Tools.Dates.DateExists(line.ship_date_actual))
                status = "Actual Ship Date: " + line.ship_date_actual.ToShortDateString();
            lblShipDateActual = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblShipDateActual", "", status)));
            ArrayList a = new ArrayList();
            a.Add("Y");
            a.Add("N");
            a.Add("U");
            cboROHS = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("rohs_info", "RoHS Info", line.rohs_info, a)));
            cboShipVia = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("shipvia_invoice", "Ship Via", line.shipvia_invoice, GetChoiceList(context, "shipvia"), "", "shipvia")));
            cboShipAccount = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("shippingaccount_invoice", "Shipping Account", line.shippingaccount_invoice, GetShippingAccounts(context))));            
            txtTracking = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("tracking_invoice", "Tracking Numbers", line.tracking_invoice)));
            txtComments = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comments", line.internalcomment)));
            xPack = (PackControl)SpotAdd(ControlAdd(new PackControl("xPack", "", context, this, line.PacksOutVar, line, true, true, Rz5.Enums.OrderType.Invoice)));
            xPack.PackRefreshed += new EventHandler(xPack_PackRefreshed);
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Invoice Line";
            if (TheLine != null)
                s = "Invoice " + TheLine.ordernumber_invoice + " Line";
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"viewinvoice_" + Uid + "\" style=\"position: absolute; top: 0px;\">");
            //tabs
            sb.AppendLine("        <div id=\"tabHeader_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabHeaderNav\">");
            sb.AppendLine("                <li><a href=\"#tabInfo\" style=\"font-size: xx-small\">Info</a></li>");
            sb.AppendLine("                <li><a href=\"#tabPacking\" style=\"font-size: xx-small\">Packing</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabInfo\">");
            RenderInfoTab(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabPacking\">");
            xPack.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ShowOrder() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine(ActionScript("'show_order'"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
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
            sb.AppendLine(lblPacked.PlaceBelow(lblOrderNumber));
            sb.AppendLine(lblPacked.PlaceRight(txtQuantity));
            sb.AppendLine(txtUnitPrice.PlaceBelow(lblOrderNumber));
            sb.AppendLine(txtMFG.Select + ".css('left', 5);");
            sb.AppendLine(txtMFG.PlaceBelow(txtPart));
            sb.AppendLine(txtDC.PlaceBelow(txtPart));
            sb.AppendLine(txtDC.PlaceRight(txtMFG));
            sb.AppendLine(cboCondition.PlaceBelow(txtPart));
            sb.AppendLine(cboCondition.PlaceRight(txtDC));
            sb.AppendLine(txtUnitPrice.PlaceRight(cboCondition));
            sb.AppendLine(cboPackage.PlaceBelow(txtPart));
            sb.AppendLine(cboPackage.PlaceRight(cboCondition));
            sb.AppendLine(cboCategory.Select + ".css('left', 5);");
            sb.AppendLine(cboCategory.PlaceBelow(txtMFG));
            sb.AppendLine(txtDescription.PlaceBelow(txtMFG));
            sb.AppendLine(txtDescription.PlaceRight(cboCategory));
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
            sb.AppendLine(txtComments.Select + ".css('left', 5);");
            sb.AppendLine(txtComments.PlaceBelow(cboShipVia, false, 2, 0));
            sb.AppendLine(lblShipDateActual.PlaceBelow(txtTracking));
            sb.AppendLine(lblShipDateActual.PlaceRight(cboShipAccount, false, 7, 0));
            sb.AppendLine(xPack.Select + ".css('left', 0);");
            sb.AppendLine(xPack.Select + ".css('top', 0);");
            sb.AppendLine(xPack.Select + ".css('width', $('#tabHeader_" + Uid + "').width());");
            sb.AppendLine(xPack.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - 37);");
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "show_order":
                    ShowOrder((ContextRz)x);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
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
            lblPacked.CaptionFontSize = FontSize.XXSmall;
            lblPacked.TextFontSize = FontSize.XXSmall;
            lblPacked.FixedWidth = 147;
            lblShipDateActual.CaptionFontSize = FontSize.XXSmall;
            lblShipDateActual.TextFontSize = FontSize.Small;
            lblShipDateActual.FixedWidth = 147;
            txtUnitPrice.CaptionFontSize = FontSize.XXSmall;
            txtUnitPrice.TextFontSize = FontSize.XXSmall;
            txtUnitPrice.FixedWidth = 128;
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
            txtDescription.FixedWidth = 428;
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
            cboShipAccount.FixedWidth = 150;
            txtTracking.CaptionFontSize = FontSize.XXSmall;
            txtTracking.TextFontSize = FontSize.XXSmall;
            txtTracking.FixedWidth = 220;
            txtTracking.Rows = 1;
            txtComments.CaptionFontSize = FontSize.XXSmall;
            txtComments.TextFontSize = FontSize.XXSmall;
            txtComments.FixedWidth = 585;
            txtComments.Rows = 8;
        }
        private void RenderInfoTab(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            lblOrderNumber.Render(x, sb, screenHandle, viewHandle, session, page);
            aViewOrder.Render(x, sb, screenHandle, viewHandle, session, page);
            lblStatus.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPart.Render(x, sb, screenHandle, viewHandle, session, page);
            txtQuantity.Render(x, sb, screenHandle, viewHandle, session, page);
            lblPacked.Render(x, sb, screenHandle, viewHandle, session, page);
            txtUnitPrice.Render(x, sb, screenHandle, viewHandle, session, page);
            txtMFG.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDC.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCondition.Render(x, sb, screenHandle, viewHandle, session, page);
            cboPackage.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCategory.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescription.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAltPart.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCustPart.Render(x, sb, screenHandle, viewHandle, session, page);
            cboROHS.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipVia.Render(x, sb, screenHandle, viewHandle, session, page);
            cboShipAccount.Render(x, sb, screenHandle, viewHandle, session, page);
            txtTracking.Render(x, sb, screenHandle, viewHandle, session, page);
            txtComments.Render(x, sb, screenHandle, viewHandle, session, page);
            lblShipDateActual.Render(x, sb, screenHandle, viewHandle, session, page);
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
        private void xPack_PackRefreshed(object sender, EventArgs e)
        {
            TheLine.Update(TheContext);
            lblPacked.ValueSet(TheLine.quantity_packed);
            lblPacked.Change();
        }
        private void ShowOrder(ContextRz x)
        {
            RzWeb.Invoice q = new RzWeb.Invoice((ContextRz)x, (ordhed_invoice)TheLine.OrderObjectGet(x, Rz5.Enums.OrderType.Invoice));
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}
