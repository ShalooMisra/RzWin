using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Rz5.Web;
using System.Web.UI;

namespace RzWeb
{
    public class OrderTransmit : RzScreen
    {
        ListViewSpotTransmitOrder lvTemplate;
        ContextRz TheContext;
        printheader TheTemplate;
        ordhed TheOrder;
        String TransmitDiv
        {
            get
            {
                return "ordertransmit_" + Uid;
            }
        }
        String ImageDiv
        {
            get
            {
                return "preview_" + Uid;
            }
        }
        System.Web.UI.Page ThePage;
        BoolControl chkConsolidate;
        LabelControl lblCap;
        ViewHandle TheViewHandle;
        bool ShownFirst = false;
        

        public OrderTransmit(ContextRz x, ordhed o)
            : base(x)
        {
            TheContext = x;
            TheOrder = o;
            chkConsolidate = (BoolControl)SpotAdd(ControlAdd(new BoolControl("chkConsolidate", "Consolidate Lines", true)));
            lblCap = (LabelControl)SpotAdd(ControlAdd(new LabelControl("lblCap", "Double-Click to Preview", "")));
            lvTemplate = (ListViewSpotTransmitOrder)SpotAdd(new ListViewSpotTransmitOrder());
            lvTemplate.SkipParentRender = true;
            lvTemplate.TheArgs = x.TheSysRz.TheOrderLogic.OrdHedPrintTemplateArgsGet(x, TheOrder, Rz5.Enums.TransmitType.PDF);
            lvTemplate.CurrentTemplate = n_template.GetByName(x, lvTemplate.TheArgs.TheTemplate);
            if (lvTemplate.CurrentTemplate == null)
                lvTemplate.CurrentTemplate = n_template.Create(x, lvTemplate.TheArgs.TheClass, lvTemplate.TheArgs.TheTemplate);
            lvTemplate.CurrentTemplate.GatherColumns(x);
            lvTemplate.ColSource = new ColumnSourceTemplate(lvTemplate.CurrentTemplate);
            lvTemplate.RowSource = new RowSourceTable(x.Select(lvTemplate.TheArgs.RenderSql(x, lvTemplate.CurrentTemplate)));
            lvTemplate.ItemDoubleClicked += new ItemDoubleClickHandler(lvTemplate_ItemDoubleClicked);
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "Transmit Order";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {
                case "print":
                    PrintOrder(xrz, args.ActionParams);
                    break;
                case "return_to_order":
                    xrz.Show(TheOrder);
                    args.SourceView.ScriptsToRun.Add("window.close();");
                    break;
                default:
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            ThePage = page;
            TheViewHandle = viewHandle;
            if (!ShownFirst)
            {
                ShowFirstForm((ContextRz)x);
                ShownFirst = true;
            }
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"ordertransmit_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 230px;\">");
            sb.AppendLine("<input id=\"cmdPrint\" type=\"button\" value=\"Print\" style=\"width: 225px;\" onclick=\"DoPrint();\">");

            chkConsolidate.Render(x, sb, screenHandle, viewHandle, session, page);
            lblCap.Render(x, sb, screenHandle, viewHandle, session, page);
            lvTemplate.Render(x, sb, screenHandle, viewHandle, session, page);

            sb.AppendLine("<div id=\"returnButtonDiv\" style=\"position: absolute\"><input id=\"returnButton\" style=\"font-size: xx-small; width: 225px; left: 5px;\" type=\"button\" value=\"Return to " + TheOrder.ToString() + "\" onclick=\"" + ActionScript("'return_to_order'") + "\" /></div>");
            Buttonize(viewHandle, "returnButton", "");

            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"preview_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 230px; overflow: scroll;\">");
            sb.AppendLine("<img id=\"image_" + Uid + "\" alt=\"Previewing...\" />");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, TransmitDiv);
            RunDivToBottom(sb, TransmitDiv);
            sb.AppendLine("$('#cmdPrint').css('top', 2);");
            sb.AppendLine("$('#cmdPrint').css('left', 2);");

            sb.AppendLine("$('#returnButtonDiv').css('top', $('#cmdPrint').height() + 12);");
            sb.AppendLine("$('#returnButtonDiv').css('left', 2);");

            sb.AppendLine(chkConsolidate.Select + ".css('top', ($('#returnButtonDiv').height() * 2) + 12);");
            sb.AppendLine(chkConsolidate.Select + ".css('left', 5);");

            sb.AppendLine(lblCap.PlaceBelow(chkConsolidate));
            sb.AppendLine(lblCap.Select + ".css('left', 5);");

            sb.AppendLine(lvTemplate.PlaceBelow(lblCap));
            sb.AppendLine(lvTemplate.Select + ".css('left', 5);");
            sb.AppendLine(lvTemplate.Select + ".css('width', $('#ordertransmit_" + Uid + "').width() - 2);");
            sb.AppendLine(lvTemplate.Select + ".css('height', $('#ordertransmit_" + Uid + "').height() - " + lvTemplate.Select + ".position().top);");
            sb.AppendLine("$('#preview_" + Uid + "').css('top', $('#" + TransmitDiv + "').position().top);");
            sb.AppendLine("$('#preview_" + Uid + "').css('left', $('#ordertransmit_" + Uid + "').position().left + $('#ordertransmit_" + Uid + "').width() + 20);");
            RunDivToBottom(sb, ImageDiv);
            RunDivToRight(sb, ImageDiv);
            sb.AppendLine("$('#image_" + Uid + "').css('top', 5);");
            sb.AppendLine("$('#image_" + Uid + "').css('left', 5);");
            sb.AppendLine("$('#image_" + Uid + "').css('width', 850);");
            sb.AppendLine("$('#image_" + Uid + "').css('height', 1100);");

            //sb.AppendLine(PlaceBelow("returnButton", lvTemplate.DivId));
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            //DoPrint
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function DoPrint() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'print'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#cmdPrint').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
        }
        private void AdjustControls()
        {
            lvTemplate.ExtraStyle = "; font-size: small";
            chkConsolidate.TextFontSize = FontSize.XXSmall;
        }
        private void PrintOrder(ContextRz x, String s)
        {
            if (TheOrder == null)
                return;
            if (TheTemplate == null)
            {
                x.TheLeader.Tell("No template has been selected for this printout.");
                return;
            }
            Dictionary<string, string> d = ParseValueString(s);
            string ss = "";
            d.TryGetValue("chkConsolidate", out ss);
            bool consolidate = false;
            if (Tools.Strings.StrCmp(ss, "Consolidate Lines"))
                consolidate = true;
            String strFolder = Tools.Folder.ConditionFolderName(ThePage.Server.MapPath("~/PDFs/"));
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);
            String fileNameOnly = TheOrder.ToString() + ".pdf";
            String file = strFolder + fileNameOnly;
            try
            {
                if (File.Exists(file))
                    File.Delete(file);
            }
            catch
            {
                fileNameOnly = TheOrder.ToString() + "_" + Tools.Strings.GetNewID() + ".pdf";
                file = strFolder + fileNameOnly;
            }
            string pfile = "";
            try
            {
                PrintSessionPdf pdf = new PrintSessionPdf(TheContext, TheTemplate, TheOrder);
                pfile = pdf.Print(consolidate, "", file);
            }
            catch { }
            x.TheLeader.FileShow(pfile);
        }
        private void ShowPreview(ContextRz x, ViewHandle viewHandle)
        {
            if (TheOrder == null)
                return; 
            if (TheTemplate == null)
                return;
            viewHandle.ScriptsToRun.Add("$('#image_" + Uid + "').attr('alt', 'Previewing...')");
            viewHandle.ScriptsToRun.Add("$('#image_" + Uid + "').attr('src', '')");
            //viewHandle.Flow();
            PrintSessionImages p = new PrintSessionImages(x, TheTemplate, TheOrder, 850, 1100);
            p.Print();
            String strFolder = Tools.Folder.ConditionFolderName(ThePage.Server.MapPath("~/PDFs/"));
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);
            string file = Tools.Strings.GetNewID() + ".jpg";
            strFolder += file;
            foreach (Image i in p.Images)
            {
                i.Save(strFolder, System.Drawing.Imaging.ImageFormat.Jpeg);
                break;
            }
            viewHandle.ScriptsToRun.Add("$('#image_" + Uid + "').attr('src', '" + ThePage.ResolveUrl("~/PDFs/" + file) + "')");
            //viewHandle.Flow();
        }
        private void ShowFirstForm(ContextRz x)
        {
            string id = x.SelectScalarString("select top 1 unique_id from printheader where " + lvTemplate.TheArgs.TheWhere + " order by " + lvTemplate.TheArgs.TheOrder);
            if (Tools.Strings.StrExt(id))
            {
                TheTemplate = printheader.GetById(x, id);
                ShowPreview((ContextRz)x, TheViewHandle);
            }
        }
        private void lvTemplate_ItemDoubleClicked(Context x, IItem item, System.Web.UI.Page page, ViewHandle viewHandle)
        {
            if (item == null)
                return;
            TheTemplate = (printheader)item;
            ShowPreview((ContextRz)x,  viewHandle);
        }
    }
    public class ListViewSpotTransmitOrder : ListViewSpotRz
    {
        public ListViewSpotTransmitOrder()
            : base("printheader")
        {
        }
    }
}
