using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Rz5.Web;

namespace RzWeb
{
    public class ExportInventory : RzScreen
    {
        String ExportDiv
        {
            get
            {
                return "invexport_" + Uid;
            }
        }
        String OptionsDiv
        {
            get
            {
                return "exportoptions_" + Uid;
            }
        }
        System.Web.UI.Page ThePage;
        ListViewSpotExport lvExports;
        exporttemplate TheTemplate;
        TextControl txtName;
        BoolControl chkStock;
        BoolControl chkConsign;
        BoolControl chkExcess;
        Dictionary<string, string> dExcess = new Dictionary<string, string>();
        Dictionary<string, string> dConsign = new Dictionary<string, string>();
        ArrayList aExcess = new ArrayList();
        ArrayList aConsign = new ArrayList();

        public ExportInventory(ContextRz x)
            : base(x)
        {
            txtName = (TextControl)SpotAdd(ControlAdd(new TextControl("exportname", "Export Name", "")));
            chkStock = (BoolControl)SpotAdd(ControlAdd(new BoolControl("exportstock", "Export Stock", false)));
            chkConsign = (BoolControl)SpotAdd(ControlAdd(new BoolControl("exportconsigned", "Export Consign", false)));
            chkExcess = (BoolControl)SpotAdd(ControlAdd(new BoolControl("exportexcess", "Export Excess", false)));
            lvExports = (ListViewSpotExport)SpotAdd(new ListViewSpotExport());
            lvExports.SkipParentRender = true;
            lvExports.TheArgs = new ListArgs(x);
            lvExports.TheArgs.AddAllow = true;
            lvExports.TheArgs.AddCaption = "Add New Template";
            lvExports.TheArgs.TheCaption = "Export Templates";
            lvExports.TheArgs.TheClass = "exporttemplate";
            lvExports.TheArgs.TheLimit = 200;
            lvExports.TheArgs.TheOrder = "exportname";
            lvExports.TheArgs.TheTable = "exporttemplate";
            lvExports.TheArgs.TheTemplate = "exportinvtemplateview";
            lvExports.CurrentTemplate = n_template.GetByName(x, lvExports.TheArgs.TheTemplate);
            if (lvExports.CurrentTemplate == null)
                lvExports.CurrentTemplate = n_template.Create(x, lvExports.TheArgs.TheClass, lvExports.TheArgs.TheTemplate);
            lvExports.CurrentTemplate.GatherColumns(x);
            lvExports.ColSource = new ColumnSourceTemplate(lvExports.CurrentTemplate);
            lvExports.RowSource = new RowSourceTable(x.Select(lvExports.TheArgs.RenderSql(x, lvExports.CurrentTemplate)));
            lvExports.ItemDoubleClicked += new ItemDoubleClickHandler(lvExports_ItemDoubleClicked);
            lvExports.AddNewItem += new ItemAddHandler(lvExports_AddNewItem);
            AdjustControls();
        }
        //Override Functions
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {        
                case "tabShow":
                    break;
                case "export":
                    ExportTemplate((ContextRz)x, args.ActionParams);
                    break;
                case"save":
                    SaveTemplate((ContextRz)x, args.ActionParams);
                    break;
                default:
                    break;
            }
            args.SourceView.ScriptsToRun.Add("DoResize();");
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            ThePage = page;
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"invexport_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 175px;\">");
            lvExports.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"cmdrun_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; width: 358px; font-size: small;\">");
            sb.AppendLine("<input id=\"cmdRun\" type=\"button\" value=\"Run\" onclick=\"" + ActionScript("'export'", lvExports.SelectedRowIdsScript) + "\" style=\"width: 358px;\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"exportoptions_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 350px;\">");
            txtName.Render(x, sb, screenHandle, viewHandle, session, page);
            chkStock.Render(x, sb, screenHandle, viewHandle, session, page);
            chkConsign.Render(x, sb, screenHandle, viewHandle, session, page);
            chkExcess.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("        <div id=\"exporttabs_" + Uid + "\" style=\"position: absolute; left: 2px; top: 80px; width: 350px;\">");
            sb.AppendLine("            <ul id=\"tabExports_" + Uid + "\">");
            sb.AppendLine("                <li><a href=\"#tabExcess\" style=\"font-size: xx-small\">Excess</a></li>");
            sb.AppendLine("                <li><a href=\"#tabConsign\" style=\"font-size: xx-small\">Consign</a></li>");
            sb.AppendLine("            </ul>");
            sb.AppendLine("            <div style=\"position: relative; overflow: scroll;\" id=\"tabExcess\">");
            sb.AppendLine(RenderExcess((ContextRz)x, viewHandle, session, page));
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div style=\"position: relative; overflow: scroll;\" id=\"tabConsign\">");
            sb.AppendLine(RenderConsign((ContextRz)x, viewHandle, session, page));
            sb.AppendLine("            </div>");
            sb.AppendLine("         </div>");
            sb.AppendLine("<div id=\"cmdsave_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; width: 358px; font-size: small;\">");
            sb.AppendLine("<input id=\"cmdSave\" type=\"button\" value=\"Save\" onclick=\"SaveTemplate()\" style=\"width: 358px;\">");
            sb.AppendLine("</div>");
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        public override String Title(Context x)
        {
            return "Inventory Export";
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, ExportDiv);
            PlaceDivBelowMenu(sb, OptionsDiv);
            RunDivToBottom(sb, ExportDiv);
            RunDivToBottom(sb, OptionsDiv);
            PlaceDivRightEdge(sb, OptionsDiv);
            sb.AppendLine("$('#" + ExportDiv + "').css('width', $('#" + OptionsDiv + "').position().left - $('#" + ExportDiv + "').position().left - 15);");
            sb.AppendLine(txtName.Select + ".css('top', 5);");
            sb.AppendLine(txtName.Select + ".css('left', 5);");
            sb.AppendLine(chkStock.Select + ".css('left', 5);");
            sb.AppendLine(chkStock.PlaceBelow(txtName));
            sb.AppendLine(chkConsign.PlaceBelow(txtName));
            sb.AppendLine(chkConsign.PlaceRight(chkStock));
            sb.AppendLine(chkExcess.PlaceBelow(txtName));
            sb.AppendLine(chkExcess.PlaceRight(chkConsign));
            sb.AppendLine("$('#" + txtName.ControlId + "').css('width', 345);");
            sb.AppendLine("$('#cmdrun_" + Uid + "').css('left', 2);");
            sb.AppendLine("$('#cmdrun_" + Uid + "').css('top', $('#" + ExportDiv + "').height() - $('#cmdrun_" + Uid + "').height() + 9);");
            sb.AppendLine("$('#cmdRun').css('width', $('#" + ExportDiv + "').width() );");
            sb.AppendLine(lvExports.Select + ".css('top', 10);");
            sb.AppendLine(lvExports.Select + ".css('left', 10);");
            sb.AppendLine(lvExports.Select + ".css('width', $('#" + ExportDiv + "').width());");
            sb.AppendLine(lvExports.Select + ".css('height', $('#cmdrun_" + Uid + "').position().top - " + lvExports.Select + ".position().top);");            
            sb.AppendLine("$('#cmdsave_" + Uid + "').css('left', 2);");
            sb.AppendLine("$('#cmdsave_" + Uid + "').css('top', $('#" + ExportDiv + "').height() - $('#cmdsave_" + Uid + "').height() + 9);");
            sb.AppendLine("$('#exporttabs_" + Uid + "').css('height', $('#cmdsave_" + Uid + "').position().top - $('#exporttabs_" + Uid + "').position().top - 10);");
            sb.AppendLine("$('#tabExcess').css('height', $('#exporttabs_" + Uid + "').height() - 65);");
            sb.AppendLine("$('#tabConsign').css('height', $('#exporttabs_" + Uid + "').height() - 65);");
            BoolControl prev = null;
            foreach (BoolControl b in aExcess)
            {
                sb.AppendLine(b.Select + ".css('width', 1000);");
                if (prev == null)
                {
                    sb.AppendLine(b.Select + ".css('top', 10);");
                    prev = b;
                    continue;
                }
                sb.AppendLine(b.PlaceBelow(prev));
                prev = b;
            }
            prev = null;
            foreach (BoolControl b in aConsign)
            {
                sb.AppendLine(b.Select + ".css('width', 1000);");
                if (prev == null)
                {
                    sb.AppendLine(b.Select + ".css('top', 10);");
                    prev = b;
                    continue;
                }
                sb.AppendLine(b.PlaceBelow(prev));
                prev = b;
            }
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("function SaveTemplate() {");
            sb.AppendLine("var data = \"\";");
            foreach (CoreWeb.Control c in Controls)
            {
                sb.AppendLine(c.ValueAddScript("data"));
            }
            sb.AppendLine(ActionScript("'save'", "data"));
            sb.AppendLine("}");
            viewHandle.Definitions.Add(sb.ToString());
            viewHandle.ScriptsToRun.Add("$('#cmdSave').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
            viewHandle.ScriptsToRun.Add("$('#cmdRun').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
            viewHandle.ScriptsToRun.Add("$('#exporttabs_" + Uid + "').tabs({ select: function(event, ui) { " + ActionScript("'tabShow'") + " } });");
        }
        private void AdjustControls()
        {
            lvExports.ExtraStyle = "; font-size: small";
        }
        private void LoadExport()
        {
            if (TheTemplate == null)
                return;
            txtName.ValueSet(TheTemplate.exportname);
            chkStock.ValueSet(TheTemplate.exportstock);
            chkConsign.ValueSet(TheTemplate.exportconsigned);
            chkExcess.ValueSet(TheTemplate.exportexcess);
            txtName.Change();
            chkStock.Change();
            chkConsign.Change();
            chkExcess.Change();
            string[] str = Tools.Strings.Split(TheTemplate.exportonly, "|~|");
            foreach (string s in str)
            {
                foreach (BoolControl b in aExcess)
                {
                    if (!Tools.Strings.StrCmp(b.Caption, s))
                        continue;
                    b.ValueSet(true);
                    b.Change();
                }
            }
            str = Tools.Strings.Split(TheTemplate.exportonly_consign, "|~|");
            foreach (string s in str)
            {
                foreach (BoolControl b in aConsign)
                {
                    if (!Tools.Strings.StrCmp(b.Caption, s))
                        continue;
                    b.ValueSet(true);
                    b.Change();
                }
            }
        }
        private void SaveTemplate(ContextRz x, string s)
        {
            if (TheTemplate == null)
            {
                x.TheLeader.Tell("No template has been loaded to save.");
                return;
            }
            Dictionary<string, string> d = ParseValueString(s);
            string ss = "";
            d.TryGetValue("exportname", out ss);
            TheTemplate.exportname = ss;
            ss = "";
            d.TryGetValue("exportstock", out ss);
            TheTemplate.exportstock = !Tools.Strings.StrCmp("undefined", ss);
            ss = "";
            d.TryGetValue("exportconsigned", out ss);
            TheTemplate.exportconsigned = !Tools.Strings.StrCmp("undefined", ss);
            ss = "";
            d.TryGetValue("exportexcess", out ss);
            TheTemplate.exportexcess = !Tools.Strings.StrCmp("undefined", ss);
            TheTemplate.donotexport = "";
            TheTemplate.exportonly = "";
            TheTemplate.donotexport_consign = "";
            TheTemplate.exportonly_consign = "";
            TheTemplate.donotexport_offers = "";
            TheTemplate.exportonly_offers = "";
            List<string> l = new List<string>();
            List<string> lExcess = new List<string>();
            List<string> lConsign = new List<string>();
            string list = "";
            if (TheTemplate.exportexcess)
            {
                foreach(KeyValuePair<string,string> kvp in d)
                {
                    if (!kvp.Key.StartsWith("bool_excess_"))
                        continue;
                    if (Tools.Strings.StrCmp(kvp.Value, "undefined"))
                        continue;
                    if (Tools.Strings.StrExt(list))
                        list += "|~|";
                    list += kvp.Value;
                    lExcess.Add(kvp.Value);
                }
                TheTemplate.exportonly = list;
            }
            list = "";
            if (TheTemplate.exportconsigned)
            {
                foreach (KeyValuePair<string, string> kvp in d)
                {
                    if (!kvp.Key.StartsWith("bool_consign_"))
                        continue;
                    if (Tools.Strings.StrCmp(kvp.Value, "undefined"))
                        continue;
                    if (Tools.Strings.StrExt(list))
                        list += "|~|";
                    list += kvp.Value;
                    lConsign.Add(kvp.Value);
                }
                TheTemplate.exportonly_consign = list;
            }
            TheTemplate.exportwhere = TheTemplate.GetExportWhere(x, lExcess, l, lConsign, l);
            TheTemplate.fieldstring = "fullpartnumber,sum(quantity - quantityallocated) as quantity,manufacturer,datecode,condition";// GetColumnList(true);
            TheTemplate.exportcaptions = "Part Number,Qty,MFG,D/C,Cond"; //GetColumnList(false);
            string group = " group by fullpartnumber,quantity,manufacturer,datecode,condition";
            if (Tools.Strings.StrExt(TheTemplate.fieldstring))
                TheTemplate.exportstring = "select " + TheTemplate.fieldstring + " from partrecord " + (Tools.Strings.StrExt(TheTemplate.exportwhere) ? " where " + TheTemplate.exportwhere : "") + group;            
            TheTemplate.Update(x);
            lvExports.RowSource = new RowSourceTable(x.Select(lvExports.TheArgs.RenderSql(x, lvExports.CurrentTemplate)));
            lvExports.Change();
        }
        private void ExportTemplate(ContextRz x, string ids)
        {
            exporttemplate t = null;
            string[] str = Tools.Strings.Split(ids, "|");
            foreach (string s in str)
            {
                string ss = Tools.Strings.ParseDelimit(s, "_dot_", 2).Trim();
                if (!Tools.Strings.StrExt(ss))
                    continue;
                t = exporttemplate.GetById(x, ss);
                break;
            }
            if (t == null)
            {
                x.TheLeader.Tell("This template does not exist.");
                return;
            }
            String strFolder = Tools.Folder.ConditionFolderName(ThePage.Server.MapPath("~/Exports/"));
            if (!Directory.Exists(strFolder))
                Directory.CreateDirectory(strFolder);
            string file_name = t.exportname;
            if (!Tools.Strings.StrExt(file_name))
                file_name = Tools.Strings.GetNewID();
            String fileNameOnly = file_name + ".csv";
            String file = strFolder + fileNameOnly;
            if (Tools.Files.FileExists(file))
                Tools.Files.TryDeleteFile(file);
            t.exportfile = file;
            t.ExportTemplate(x, false);
            x.TheLeader.FileShow(file);
        }
        private string RenderExcess(ContextRz x, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = x.Select("select distinct(isnull(importid,'')) as importid from partrecord where stocktype in ('oem', 'excess') order by importid");
            if (dt == null)
                return "";
            foreach (DataRow dr in dt.Rows)
            {
                if (!Tools.Strings.StrExt(dr[0].ToString()))
                    continue;
                string id = Tools.Strings.GetNewID();
                BoolControl bc = (BoolControl)SpotAdd(ControlAdd(new BoolControl("bool_excess_" + id, dr[0].ToString(), false)));
                bc.TextFontSize = FontSize.XSmall;
                bc.Render(x, sb, TheScreen, viewHandle, session, page);
                dExcess.Add(id, dr[0].ToString());
                aExcess.Add(bc);
            }
            return sb.ToString();
        }
        private string RenderConsign(ContextRz x, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            StringBuilder sb = new StringBuilder();
            DataTable dt = x.Select("select distinct(isnull(importid,'')) as importid from partrecord where stocktype in ('consign', 'consigned') order by importid");
            if (dt == null)
                return "";
            foreach (DataRow dr in dt.Rows)
            {
                if (!Tools.Strings.StrExt(dr[0].ToString()))
                    continue;
                string id = Tools.Strings.GetNewID();
                BoolControl bc = (BoolControl)SpotAdd(ControlAdd(new BoolControl("bool_consign_" + id, dr[0].ToString(), false)));
                bc.TextFontSize = FontSize.XSmall;
                bc.Render(x, sb, TheScreen, viewHandle, session, page);
                dConsign.Add(id, dr[0].ToString());
                aConsign.Add(bc);
            }
            return sb.ToString();
        }
        private void lvExports_ItemDoubleClicked(Context x, IItem item, Page page, ViewHandle viewHandle)
        {
            TheTemplate = (exporttemplate)item;
            LoadExport();
        }
        private void lvExports_AddNewItem(Context x, Page page, ViewHandle viewHandle)
        {
            TheTemplate = exporttemplate.NewTemplate((ContextRz)x);
            lvExports.RowSource = new RowSourceTable(x.Select(lvExports.TheArgs.RenderSql(x, lvExports.CurrentTemplate)));
            lvExports.Change();
            LoadExport();
        }
    }
    public class ListViewSpotExport : ListViewSpotRz
    {
        public ListViewSpotExport()
            : base("exporttemplate")
        {
        }
    }
}

     