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
using Rz5;
using Rz5.Web;
using System.Web.UI;

namespace RzWeb
{
    public class ManagePartImports : RzScreen
    {
        ListViewSpotImports lvImports;
        String RemoveDiv
        {
            get
            {
                return "cmdremove_" + Uid;
            }
        }
        String ImportDiv
        {
            get
            {
                return "pastimports_" + Uid;
            }
        }

        public ManagePartImports(ContextRz x)
            : base(x)
        {
            lvImports = (ListViewSpotImports)SpotAdd(new ListViewSpotImports());
            lvImports.SkipParentRender = true;
            lvImports.TheArgs = new ListArgs(x);
            lvImports.TheArgs.AddAllow = false;
            long l = 0;
            ImportInventory TheImportLogic = new ImportInventory();
            TheImportLogic.CalcPast(x, "list", ref l);
            //lvImports.TheArgs.TheCaption = "Past Imports";
            lvImports.TheArgs.TheClass = "partrecord";
            lvImports.TheArgs.TheLimit = -1;
            lvImports.TheArgs.TheOrder = "importid";
            lvImports.TheArgs.TheTable = "temp_past_stock_calc";
            lvImports.TheArgs.TheTemplate = "past_stock_calc_template";
            lvImports.TheArgs.TheWhere = "isnull(importid, '') > ''";
            lvImports.CurrentTemplate = n_template.GetByName(x, lvImports.TheArgs.TheTemplate);
            if (lvImports.CurrentTemplate == null)
                CreateImportLVTemplate(x);
            lvImports.CurrentTemplate.GatherColumns(x);
            lvImports.ColSource = new ColumnSourceTemplate(lvImports.CurrentTemplate);
            lvImports.RowSource = new RowSourceTable(x.Select(lvImports.TheArgs.RenderSql(x, lvImports.CurrentTemplate)));
            AdjustControls();
        }
        //Override Functions
        public override String Title(Context x)
        {
            return "Manage Imports";
        }
        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            string s = Tools.Html.ConvertToPostString(args.ActionParams.ToLower().Trim());
            s = Tools.Html.ConvertFromPostString(s);
            switch (args.ActionId.ToLower())
            {         
                case "remove":
                    RemoveSelectedImports((ContextRz)x, args.ActionParams);
                    break;
                default:
                    break;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("<div id=\"cmdremove_" + Uid + "\" style=\"position: absolute; top: 0px; left: 0px; font-size: small;\">");
            sb.AppendLine("<input id=\"cmdRemove\" type=\"button\" value=\"Remove Selected Import\" onclick=\"" + ActionScript("'remove'", lvImports.SelectedRowIdsScript) + "\">");
            sb.AppendLine("</div>");
            sb.AppendLine("<div id=\"pastimports_" + Uid + "\" class=\"jqborderstyle ui-corner_all rz-margin\" style=\"position: absolute; padding: 6px; width: 175px;\">");
            lvImports.Render(x, sb, screenHandle, viewHandle, session, page);
            sb.AppendLine("</div>");
            AddScripts(viewHandle);
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, RemoveDiv);
            PlaceDivBelowDiv(sb, ImportDiv, RemoveDiv);            
            RunDivToBottom(sb, ImportDiv);
            RunDivToRight(sb, ImportDiv);            
            sb.AppendLine("$('#" + RemoveDiv + "').css('left', 3);");
            sb.AppendLine("$('#" + RemoveDiv + "').css('width', $('#" + ImportDiv + "').width() + 15);");
            sb.AppendLine("$('#cmdRemove').css('width', $('#" + RemoveDiv + "').width());");
            sb.AppendLine(lvImports.Select + ".css('top', 5);");
            sb.AppendLine(lvImports.Select + ".css('left', 10);");
            sb.AppendLine(lvImports.Select + ".css('width', $('#" + ImportDiv + "').width() - 4);");
            sb.AppendLine(lvImports.Select + ".css('height', $('#" + ImportDiv + "').height() - 28);");
        }
        private void AddScripts(ViewHandle viewHandle)
        {
            viewHandle.ScriptsToRun.Add("$('#cmdRemove').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
        }
        private void AdjustControls()
        {
            lvImports.ExtraStyle = "; font-size: small";
        }
        private void CreateImportLVTemplate(ContextRz x)
        {
            n_template ret = (n_template)x.Item("n_template");
            ret.template_name = "past_stock_calc_template";
            ret.class_name = "";
            ret.use_gridlines = true;
            x.Insert(ret);
            lvImports.CurrentTemplate = ret;

            n_column c = new n_column();
            lvImports.CurrentTemplate.InitNewColumn(c);
            c.field_name = "importid";
            c.column_caption = "Import ID";
            c.data_type = (int)Tools.Database.FieldType.String;
            x.Insert(c);
            lvImports.CurrentTemplate.AbsorbColumn(x, c);

            c = new n_column();
            lvImports.CurrentTemplate.InitNewColumn(c);
            c.field_name = "vendor_name";
            c.column_caption = "Vendor Name";
            c.data_type = (int)Tools.Database.FieldType.String;
            x.Insert(c);
            lvImports.CurrentTemplate.AbsorbColumn(x, c);

            c = new n_column();
            lvImports.CurrentTemplate.InitNewColumn(c);
            c.field_name = "total_count";
            c.column_caption = "Total Count";
            c.column_alignment = 1;
            c.column_format = "{0:G}";
            c.data_type = (int)Tools.Database.FieldType.Int32;
            x.Insert(c);
            lvImports.CurrentTemplate.AbsorbColumn(x, c);
        }
        private void RemoveSelectedImports(ContextRz x, string ids)
        {
            string[] str = Tools.Strings.Split(ids, "|");
            foreach (string s in str)
            {
                string ss = Tools.Strings.ParseDelimit(s, "_dot_", 2).Trim();
                if (!Tools.Strings.StrExt(ss))
                    continue;
                string sss = x.SelectScalarString("select top 1 importid from temp_past_stock_calc where unique_id = '" + ss + "'");
                if (!Tools.Strings.StrExt(sss))
                    continue;
                RemoveImport(x, sss);
            }
            long l = 0;
            ImportInventory TheImportLogic = new ImportInventory();
            TheImportLogic.CalcPast(x, "list", ref l);
            lvImports.RowSource = new RowSourceTable(x.Select(lvImports.TheArgs.RenderSql(x, lvImports.CurrentTemplate)));
            lvImports.Change();
        }
        private void RemoveImport(ContextRz x, string import_id)
        {
            if (!x.TheLeaderRz.AreYouSure("you want to remove the import: " + import_id))
                return;
            try { x.Execute("delete from partrecord where importid = '" + x.Filter(import_id) + "'", false); }
            catch (Exception ee)
            { x.TheLeaderRz.Tell("There was an error removing this list: " + ee.Message); }
        }
    }
    public class ListViewSpotImports : ListViewSpotRz
    {
        public ListViewSpotImports()
            : base("partrecord")
        {
        }
    }
}
