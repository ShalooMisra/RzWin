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
    public class PartMaster : _Item
    {
        public part_master TheMaster
        {
            get
            {
                return (part_master)Item;
            }
        }
        RzWeb.ChoicesControl cboMFG;
        TextAreaControl txtDescr;

        RzWeb.ChoicesControl cboCategory;
        TextControl txtAlternatePart;

        String PartDiv
        {
            get
            {
                return "part_record_" + Uid;
            }
        }

        public PartMaster(ContextRz x, part_master c)
            : base(x, c)
        {
            cboMFG = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("manufacturer", "Manufacturer", TheMaster.manufacturer, GetChoiceList(x, "manufacturer"), "", "manufacturer")));
            txtDescr = (TextAreaControl)SpotAdd(ControlAdd(new TextAreaControl("description", "Description", TheMaster.description)));
            cboCategory = (RzWeb.ChoicesControl)SpotAdd(ControlAdd(new RzWeb.ChoicesControl("category", "Category", TheMaster.category, GetChoiceList(x, "category"), "", "category")));
            txtAlternatePart = (TextControl)SpotAdd(ControlAdd(new TextControl("alternatepart", "Alternate Part", TheMaster.alternatepart)));
            AdjustControls();
        }
        public override String Title(Context x)
        {
            string s = "Master";
            if (TheMaster != null)
                s = " [" + TheMaster.part_number + "]";
            return s;
        }
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"part_record_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; height: 250px; width: 590px;\">");
            sb.AppendLine("<strong>" + HttpUtility.HtmlEncode(TheMaster.part_number) + "</strong><br />");
            cboMFG.Render(x, sb, screenHandle, viewHandle, session, page);
            txtDescr.Render(x, sb, screenHandle, viewHandle, session, page);
            cboCategory.Render(x, sb, screenHandle, viewHandle, session, page);
            txtAlternatePart.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            //viewHandle.ScriptsToRun.Add("$('#tabHeader_" + Uid + "').tabs({ select: function(event, ui) { " + ActionScript("'tab_clicked'") + " } });");
        }
        protected override void ResizeRender(System.Text.StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, PartDiv);
            RunDivToBottom(sb, PartDiv);
            sb.AppendLine("$('#" + PartDiv + "').css('width', " + xActions.Select + ".position().left - $('#" + PartDiv + "').position().left - 20);");
            sb.AppendLine(cboMFG.Select + ".css('top', 40).css('left', 20);");
            sb.AppendLine(txtDescr.Select + ".css('top', 80).css('left', 20);");
            sb.AppendLine(cboCategory.Select + ".css('top', 160).css('left', 20);");
            sb.AppendLine(txtAlternatePart.Select + ".css('top', 200).css('left', 20);");
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
            cboMFG.CaptionFontSize = FontSize.Small;
            cboMFG.TextFontSize = FontSize.Small;
            cboMFG.FixedWidth = 190;

            txtDescr.CaptionFontSize = FontSize.Small;
            txtDescr.TextFontSize = FontSize.Small;
            txtDescr.FixedWidth = 300;

            cboCategory.CaptionFontSize = FontSize.Small;
            cboCategory.TextFontSize = FontSize.Small;
            cboCategory.FixedWidth = 190;

            txtAlternatePart.CaptionFontSize = FontSize.Small;
            txtAlternatePart.TextFontSize = FontSize.Small;
            txtAlternatePart.FixedWidth = 190;
        }
    }
}
