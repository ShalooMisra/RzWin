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
    public class PartRecord : _Item
    {
        public partrecord ThePart
        {
            get
            {
                return (partrecord)Item;
            }
        }
        LabelControl lblStockType;
        TextControl txtPart;
        TextControl txtAltPart;
        Int64Control txtQty;
        MoneyControl txtPrice;
        MoneyControl txtCost;
        TextControl txtSerial;
        Int64Control txtQtyAll;
        RzWeb.ChoicesControl cboMFG;
        TextControl txtDC;
        Int64Control txtPPK;
        RzWeb.ChoicesControl cboCond;
        RzWeb.ChoicesControl cboPkg;
        TextControl txtLoc;
        TextControl txtBox;
        TextControl txtSource;
        TextAreaControl txtDescr;
        CompanyContactControl xVendor;
        Attachments xAttachments;
        bool AttachmentsLoaded = false;
        String PartDiv
        {
            get
            {
                return "part_record_" + Uid;
            }
        }

        public PartRecord(ContextRz x, partrecord c)
            : base(x, c)
        {
            lblStockType = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblStockType", "", ThePart.StockType.ToString())));
            txtPart = (TextControl)SpotAdd(ControlAdd(new TextControl("fullpartnumber", "Part Number", ThePart.fullpartnumber)));
            txtAltPart = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatepart", "Alternate Part", ThePart.alternatepart)));
            txtQty = (Int64Control)SpotAdd(ControlAdd(new Int64Control("quantity", "Quantity", ThePart.quantity)));
            txtPrice = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("price", "Price", ThePart.price)));
            txtCost = (MoneyControl)SpotAdd(ControlAdd(new MoneyControl("cost", "Cost", ThePart.cost)));
            txtSerial = (TextControl)SpotAdd(ControlAdd(new TextControl("serial", "Serial #", ThePart.serial)));
            txtQtyAll = (Int64Control)SpotAdd(ControlAdd(new Int64Control("quantityallocated", "Quantity Allocated", ThePart.quantityallocated)));
            txtQtyAll.DisableEdit = true;
            txtSource = (TextControl)SpotAdd(ControlAdd(new TextControl("importid", "Source", ThePart.importid)));
            txtSource.DisableEdit = true;
            cboMFG = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("manufacturer", "Manufacturer", ThePart.manufacturer, GetChoiceList(x, "manufacturer"), "", "manufacturer")));
            txtDC = (TextControl)SpotAdd(ControlAdd(new TextControl("datecode", ((ContextRz)x).DateCodeCaption, ThePart.datecode)));
            txtPPK = (Int64Control)SpotAdd(ControlAdd(new Int64Control("partsperpack", "Parts Per Pack", ThePart.partsperpack)));
            cboCond = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("condition", "Condition", ThePart.condition, GetChoiceList(x, "condition"), "", "condition")));
            cboPkg = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("packaging", "Packaging", ThePart.packaging, GetChoiceList(x, "packaging"), "", "packaging")));
            txtLoc = (TextControl)SpotAdd(ControlAdd(new TextControl("location", "Location", ThePart.location)));
            txtBox = (TextControl)SpotAdd(ControlAdd(new TextControl("boxnum", "Box Number", ThePart.boxnum)));            
            txtDescr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("description", "Description", ThePart.description)));
            xVendor = (CompanyContactControl)SpotAdd(ControlAdd(new CompanyContactControl("base_company_uid|companyname|base_companycontact_uid|companycontactname", "Vendor Info", ThePart.base_company_uid, ThePart.companyname, "base_company_uid", "companyname", ThePart.base_companycontact_uid, ThePart.companycontactname, "base_companycontact_uid", "companycontactname")));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Part";
            if (ThePart != null)
                s = "Part [" + ThePart.fullpartnumber + "]";
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"part_record_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            sb.AppendLine("<div id=\"stock_type" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 20px; width: 75px;\">");
            lblStockType.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            txtPart.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <div id=\"tabHeader_" + Uid + "\" style=\"position: absolute;\">");
            sb.AppendLine("            <ul id=\"tabHeaderNav\">");
            sb.AppendLine("                <li><a href=\"#tabGeneral\" style=\"font-size: x-small\">General</a></li>");
            sb.AppendLine("                <li><a href=\"#tabAttachments\" style=\"font-size: x-small\">Attachments</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabGeneral\">");
            txtAltPart.Render(x, sb, screenHandle, viewHandle, session, page);
            txtQty.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPrice.Render(x, sb, screenHandle, viewHandle, session, page);
            txtCost.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSerial.Render(x, sb, screenHandle, viewHandle, session, page);
            txtQtyAll.Render(x, sb, screenHandle, viewHandle, session, page);
            cboMFG.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDC.Render(x, sb, screenHandle, viewHandle, session, page);
            txtPPK.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCond.Render(x, sb, screenHandle, viewHandle, session, page);
            cboPkg.Render(x, sb, screenHandle, viewHandle, session, page);
            txtLoc.Render(x, sb, screenHandle, viewHandle, session, page);
            txtBox.Render(x, sb, screenHandle, viewHandle, session, page);
            txtSource.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescr.Render(x, sb, screenHandle, viewHandle, session, page);
            xVendor.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative;\" id=\"tabAttachments\">");
            if (!AttachmentsLoaded)
            {
                xAttachments = (Attachments)SpotAdd(ControlAdd(new Attachments("xAttachments", "Attachments", x, screenHandle, ThePart)));
                AttachmentsLoaded = true;
            }
            xAttachments.Render(x, sb, screenHandle, viewHandle, session, page);            
            sb.AppendLine("            </div>");
            sb.AppendLine("        </div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#tabHeader_" + Uid + "').tabs({ select: function(event, ui) { " + ActionScript("'tab_clicked'") + " } });");
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, PartDiv);
            RunDivToBottom(sb, PartDiv);
            sb.AppendLine("$('#" + PartDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + PartDiv + "').position().left - 20);");
            sb.AppendLine(lblStockType.Select + ".css('left', 10);");
            sb.AppendLine(lblStockType.Select + ".css('top', 5);");
            sb.AppendLine(txtPart.Select + ".css('top', 5);");
            sb.AppendLine(txtPart.Select + ".css('left', $('#stock_type" + Uid + "').width() + $('#stock_type" + Uid + "').position().left + 40);");
            PlaceDivBelowDiv(sb, "tabHeader_" + Uid, "stock_type" + Uid);
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('width', $('#" + PartDiv + "').width() - $('#tabHeader_" + Uid + "').position().left);");
            sb.AppendLine("$('#tabHeader_" + Uid + "').css('height', $('#" + PartDiv + "').height() - $('#tabHeader_" + Uid + "').position().top);");
            sb.AppendLine(txtAltPart.Select + ".css('left', 10);");
            sb.AppendLine(txtAltPart.Select + ".css('top', 10);");
            sb.AppendLine(txtQty.Select + ".css('left', 10);");
            sb.AppendLine(txtQty.PlaceBelow(txtAltPart));
            sb.AppendLine(txtPrice.PlaceBelow(txtAltPart));
            sb.AppendLine(txtPrice.PlaceRight(txtQty));
            sb.AppendLine(txtCost.PlaceBelow(txtAltPart));
            sb.AppendLine(txtCost.PlaceRight(txtPrice));

            sb.AppendLine(txtSerial.PlaceRight(txtCost));
            sb.AppendLine(txtSerial.PlaceBelow(txtAltPart));

            sb.AppendLine(txtQtyAll.Select + ".css('left', 10);");
            sb.AppendLine(txtQtyAll.PlaceBelow(txtQty));
            sb.AppendLine(cboMFG.PlaceBelow(txtQty));
            sb.AppendLine(cboMFG.PlaceRight(txtQtyAll));
            sb.AppendLine(txtDC.PlaceBelow(txtQty));
            sb.AppendLine(txtDC.PlaceRight(cboMFG));
            sb.AppendLine(txtPPK.Select + ".css('left', 10);");
            sb.AppendLine(txtPPK.PlaceBelow(txtQtyAll));
            sb.AppendLine(cboCond.PlaceBelow(txtQtyAll));
            sb.AppendLine(cboCond.PlaceRight(txtPPK));
            sb.AppendLine(cboPkg.PlaceBelow(txtQtyAll));
            sb.AppendLine(cboPkg.PlaceRight(cboCond));
            sb.AppendLine(txtLoc.Select + ".css('left', 10);");
            sb.AppendLine(txtLoc.PlaceBelow(txtPPK));
            sb.AppendLine(txtBox.PlaceBelow(txtPPK));
            sb.AppendLine(txtBox.PlaceRight(txtLoc));
            sb.AppendLine(txtSource.Select + ".css('left', 10);");
            sb.AppendLine(txtSource.PlaceBelow(txtLoc));
            sb.AppendLine(xVendor.PlaceBelow(txtPPK));
            sb.AppendLine(xVendor.PlaceRight(txtLoc, false, 196, 0));
            sb.AppendLine(txtDescr.Select + ".css('left', 10);");
            sb.AppendLine(txtDescr.PlaceBelow(txtLoc, false, 47, 0));
            sb.AppendLine("$('#" + txtDescr.ControlId + "').css('width', $('#tabHeader_" + Uid + "').width() - $('#" + txtDescr.ControlId + "').position().left - 23);");
            sb.AppendLine("$('#" + txtDescr.ControlId + "').css('height', $('#tabHeader_" + Uid + "').height() - " + txtDescr.Select + ".position().top - 56);");
            sb.AppendLine(xAttachments.Select + ".css('width', $('#tabHeader_" + Uid + "').width() - " + xAttachments.Select + ".position().left);");
            sb.AppendLine(xAttachments.Select + ".css('height', $('#tabHeader_" + Uid + "').height() - " + xAttachments.Select + ".position().top - 28);");            
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId)
            {
                case "tab_clicked":
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        private void AdjustControls()
        {
            txtPart.CaptionFontSize = FontSize.Small;
            txtPart.TextFontSize = FontSize.Small;
            txtPart.FixedWidth = 475;
            txtAltPart.CaptionFontSize = FontSize.Small;
            txtAltPart.TextFontSize = FontSize.Small;
            txtAltPart.FixedWidth = 585;   
         
            txtQty.CaptionFontSize = FontSize.Small;
            txtQty.TextFontSize = FontSize.Small;
            txtQty.FixedWidth = 96;
            txtPrice.CaptionFontSize = FontSize.Small;
            txtPrice.TextFontSize = FontSize.Small;
            txtPrice.FixedWidth = 85;
            txtCost.CaptionFontSize = FontSize.Small;
            txtCost.TextFontSize = FontSize.Small;
            txtCost.FixedWidth = 85;

            txtSerial.CaptionFontSize = FontSize.Small;
            txtSerial.TextFontSize = FontSize.Small;
            txtSerial.FixedWidth = 285;

            txtQtyAll.CaptionFontSize = FontSize.Small;
            txtQtyAll.TextFontSize = FontSize.Small;
            txtQtyAll.FixedWidth = 196;
            cboMFG.CaptionFontSize = FontSize.Small;
            cboMFG.TextFontSize = FontSize.Small;
            cboMFG.FixedWidth = 190;
            txtDC.CaptionFontSize = FontSize.Small;
            txtDC.TextFontSize = FontSize.Small;
            txtDC.FixedWidth = 185;
            txtPPK.CaptionFontSize = FontSize.Small;
            txtPPK.TextFontSize = FontSize.Small;
            txtPPK.FixedWidth = 196;
            cboCond.CaptionFontSize = FontSize.Small;
            cboCond.TextFontSize = FontSize.Small;
            cboCond.FixedWidth = 190;
            cboPkg.CaptionFontSize = FontSize.Small;
            cboPkg.TextFontSize = FontSize.Small;
            cboPkg.FixedWidth = 190;
            txtLoc.CaptionFontSize = FontSize.Small;
            txtLoc.TextFontSize = FontSize.Small;
            txtLoc.FixedWidth = 196;
            txtBox.CaptionFontSize = FontSize.Small;
            txtBox.TextFontSize = FontSize.Small;
            txtBox.FixedWidth = 185;
            txtSource.CaptionFontSize = FontSize.Small;
            txtSource.TextFontSize = FontSize.Small;
            txtSource.FixedWidth = 390;
            txtDescr.CaptionFontSize = FontSize.Small;
            txtDescr.TextFontSize = FontSize.Small;
            xVendor.TextFontSize = FontSize.Small;
            lblStockType.TextBold = true;
            if (ThePart != null)
            {
                switch (ThePart.StockType)
                {
                    case Rz5.Enums.StockType.Stock:
                        lblStockType.TextForeColor = Color.Blue;
                        break;
                    case Rz5.Enums.StockType.Excess:
                        lblStockType.TextForeColor = Color.Red;
                        break;
                    case Rz5.Enums.StockType.Consign:
                        lblStockType.TextForeColor = Color.Green;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
