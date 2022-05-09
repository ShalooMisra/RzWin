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
    public class RFQLine : _Item
    {
        public orddet_rfq TheLine
        {
            get
            {
                return (orddet_rfq)Item;
            }
        }
        LabelControl lblOrderNumber;
        AnchorControl aViewOrder;
        LabelControl lblStatus;
        TextControl txtPart;
        Int64Control txtQuantity;
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
        TextAreaControl txtComments;
        AnchorControl aOrderBatch;
        dealheader TheDeal;
        ViewHandle TheView;
        TextControl txtLeadTime;
        TextControl cboWarranty;
        //ComboBoxControl cboWarranty;

        public RFQLine(ContextRz context, orddet_rfq line, dealheader deal = null)
            : base(context, line)
        {



            TheDeal = deal;
            lblOrderNumber = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblOrderNumber", "", "RFQ " + line.ordernumber + " Line Item")));
            string name = "";
            if (line.OrderObject(context) != null)
                name = "Click To View Order";
            aViewOrder = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aViewOrder", name, "ShowOrder()")));
            string status = GetStatus();
            lblStatus = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStatus", "", status)));
            txtPart = (TextControl)SpotAdd(ControlAdd(new TextControl("fullpartnumber", "Part #", line.fullpartnumber)));
            txtQuantity = (Int64Control)SpotAdd(ControlAdd(new Int64Control("quantityordered", "Bid Quantity", line.quantityordered)));
            txtUnitPrice = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("unitprice", "Bid Price", line.unitprice)));
            txtMFG = (TextControl)SpotAdd(ControlAdd(new TextControl("manufacturer", "Manufacturer", line.manufacturer)));
            txtDC = (TextControl)SpotAdd(ControlAdd(new TextControl("datecode", ((ContextRz)context).DateCodeCaption, line.datecode)));
            cboCondition = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("condition", "Condition", line.condition, GetChoiceList(context, "condition"), "", "condition")));
            cboPackage = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("packaging", "Packaging", line.packaging, GetChoiceList(context, "packaging"), "", "packaging")));
            cboCategory = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("category", "Category", line.category, GetChoiceList(context, "category"), "", "category")));            
            txtDescription = (TextControl)SpotAdd(ControlAdd(new TextControl("description", "Description", line.description)));
            txtAltPart = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatepart", "Alternate Part #", line.alternatepart)));
            txtCustPart = (TextControl)SpotAdd(ControlAdd(new TextControl("internalpartnumber", "Customer Part #", line.internalpartnumber)));
            ArrayList a = new ArrayList();
            a.Add("Y");
            a.Add("N");
            a.Add("U");
            cboROHS = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("rohs_info", "RoHS Info", line.rohs_info, a)));

            //cboWarranty = (ComboBoxControl)SpotAdd(ControlAdd(new ComboBoxControl("warranty_period", "Warranty", line.warranty_period, new ArrayList(n_choices.ChoiceListGet(context, "warranty")))));
            cboWarranty = (TextControl)SpotAdd(ControlAdd(new TextControl("warranty_period", "Warranty", line.warranty_period)));
            txtLeadTime = (TextControl)SpotAdd(ControlAdd(new TextControl("leadtime", "Lead Time", line.leadtime)));


            txtComments = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("internalcomment", "Internal Comments", line.internalcomment)));
            string cap = "";
            if (TheDeal != null)
                cap = "Return to Order Batch " + TheDeal.dealheader_name;
            aOrderBatch = (AnchorControl)SpotAdd(ControlAdd(new AnchorControl("aOrderBatch", cap, "ShowBatch()")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "RFQ Line";
            if (TheLine != null)
                s = "RFQ " + TheLine.ordernumber + " Line";
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            TheView = viewHandle;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"viewrfq_" + Uid + "\" style=\"position: absolute; top: 0px;\">");
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
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function ShowBatch() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                if (!c.IgnoreOnSave)
                    sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine(ActionScript("'show_deal'"));
            sb.AppendLine("}");
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
            sb.AppendLine("$('#viewrfq_" + Uid + "').css('top', $('#rz_menu').height() + $('#rz_menu').position().top + 10);");
            sb.AppendLine("$('#viewrfq_" + Uid + "').css('height', $(window).height() - $('#viewrfq_" + Uid + "').position().top - 70);");
            sb.AppendLine("$('#viewrfq_" + Uid + "').css('width', " + xActions.Select + ".position().left - $('#viewrfq_" + Uid + "').position().left - 15);");
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
            sb.AppendLine(txtUnitPrice.PlaceBelow(lblOrderNumber));
            sb.AppendLine(txtUnitPrice.PlaceRight(txtQuantity));
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
            sb.AppendLine(txtAltPart.Select + ".css('left', 5);");
            sb.AppendLine(txtAltPart.PlaceBelow(txtDescription));
            sb.AppendLine(txtCustPart.PlaceBelow(txtDescription));
            sb.AppendLine(txtCustPart.PlaceRight(txtAltPart));
            sb.AppendLine(cboROHS.PlaceBelow(txtDescription));
            sb.AppendLine(cboROHS.PlaceRight(txtCustPart));
            sb.AppendLine(cboWarranty.PlaceBelow(txtDescription));
            sb.AppendLine(cboWarranty.PlaceRight(cboROHS));
            sb.AppendLine(txtLeadTime.PlaceBelow(txtDescription));
            sb.AppendLine(txtLeadTime.PlaceRight(cboWarranty));

            sb.AppendLine(txtComments.Select + ".css('left', 5);");
            sb.AppendLine(txtComments.PlaceBelow(cboROHS, false, 2, 0));
            sb.AppendLine(aOrderBatch.Select + ".css('left', 5);");
            sb.AppendLine(aOrderBatch.PlaceBelow(txtComments, false, 2, 0));
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "show_deal":
                    ShowDeal((ContextRz)x);
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
            txtUnitPrice.CaptionFontSize = FontSize.XXSmall;
            txtUnitPrice.TextFontSize = FontSize.XXSmall;
            txtUnitPrice.FixedWidth = 147;
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

            cboWarranty.CaptionFontSize = FontSize.XXSmall;
            cboWarranty.TextFontSize = FontSize.XXSmall;
            cboWarranty.FixedWidth = 100;
            //cboWarranty.FixedWidth = 50;

            txtLeadTime.CaptionFontSize = FontSize.XXSmall;
            txtLeadTime.TextFontSize = FontSize.XXSmall;
            txtLeadTime.FixedWidth = 100;

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
            cboWarranty.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLeadTime.Render(x, sb, screenHandle, viewHandle, session, page);
            txtComments.Render(x, sb, screenHandle, viewHandle, session, page);
            aOrderBatch.Render(x, sb, screenHandle, viewHandle, session, page);
        }
        private void ShowDeal(ContextRz x)
        {
            RzWeb.OrderBatch q = new RzWeb.OrderBatch((ContextRz)x, TheDeal);
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
        private void ShowOrder(ContextRz x)
        {
            RFQ q = new RzWeb.RFQ((ContextRz)x, (ordhed_rfq)TheLine.GetOrderObject(x));
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(x, q));
            TheView.ScriptsToRun.Add("window.open('View.aspx?screenId=" + q.Uid + "');window.close();");
        }
    }
}

 
