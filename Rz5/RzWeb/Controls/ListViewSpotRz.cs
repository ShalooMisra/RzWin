using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using System.Data;

namespace Rz5.Web
{
    public delegate void ItemAddHandler(Context x, System.Web.UI.Page page, ViewHandle viewHandle);
    public class ListViewSpotRz : ListViewItem
    {
        public ListArgs TheArgs = null;
        public n_template CurrentTemplate;
        public event ItemAddHandler AddNewItem;
        public bool AllowExport = true;

        public ListViewSpotRz(String classId)
            : base(classId)
        {
        }
        public override string Caption
        {
            get
            {
                if (TheArgs != null)
                    return TheArgs.TheCaption;
                else
                    return base.Caption;
            }
        }
        public override ColumnSource GetColumnSource(Context x)
        {
            return new ColumnSourceTemplate(CurrentTemplate);
        }
        protected override CoreWeb.WebTable WebTableCreate()
        {
            CoreWeb.WebTableJq w = new CoreWeb.WebTableJq(Uid);
            w.FlattenRows = FlattenRows;
            w.UseInlineIcons = false;
            return w;
        }
        protected override void RenderToolsContents(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            String rowCaption = "";
            if (RowSource != null)
            {
                int count = RowSource.Count;
                if (count > 0)
                    rowCaption = "&nbsp;&nbsp;(" + Tools.Strings.PluralizePhrase("Result", count) + ")";
            }
            sb.Append("<div style=\"float: left\">" + Caption + rowCaption + "</div>");
            sb.Append("<div style=\"float: right\">");
            if (TheArgs.AddAllow)
            {
                string id = Tools.Strings.GetNewID();
                string add_cap = TheArgs.AddCaption;
                if (!Tools.Strings.StrExt(add_cap))
                    add_cap = "Add";
                sb.AppendLine("<input id=\"cmdAdd_" + id + "\" type=\"button\" style=\"font-size: x-small;\" value=\"" + add_cap + "\" onclick=\"" + ActionScript("'add'") + "\">");
                viewHandle.ScriptsToRun.Add("$('#cmdAdd_" + id + "').css('padding', '0px 6px 0px 6px').button();");
                viewHandle.ScriptsToRun.Add("$('#cmdAdd_" + id + "').css('top', -5);");
                viewHandle.ScriptsToRun.Add("$('#cmdAdd_" + id + "').css('width', 200);");
            }
            if (RowSource != null && RowSource.Count > 0 && AllowExport)
                sb.Append("<img src=\"Graphics/ExcelSmall.png\" title=\"Download this list\" alt=\"Download this list\" style=\"cursor: pointer; margin: 2px\" onclick=\"" + ActionScript("'download_list'") + "\"/>");
            if (AllowRefresh)
                sb.Append("<img src=\"Graphics/refresh16.png\" title=\"Refresh List\" alt=\"Refresh List\" style=\"cursor: pointer; margin: 2px;\" onclick=\"" + ActionScript("'refresh_list'") + "\"/>");  //margin-right: 18p;
            sb.Append("<img src=\"Graphics/Edit.png\" title=\"Edit this layout\" alt=\"Edit this layout\" style=\"cursor: pointer; margin: 2px; margin-right: 18px\" onclick=\"" + ActionScript("'edit_layout'") + "\"/>");
            sb.Append("</div>");
        }
        protected override void RenderTools(Context x, StringBuilder sb, ViewHandle viewHandle)
        {
            base.RenderTools(x, sb, viewHandle);
            //sb.Append("<div style=\"float: right\">");
            //if (TheArgs.AddAllow)
            //{
            //    string id = Tools.Strings.GetNewID();
            //    string add_cap = TheArgs.AddCaption;
            //    if (!Tools.Strings.StrExt(add_cap))
            //        add_cap = "Add";
            //    sb.AppendLine("<input id=\"cmdAdd_" + id + "\" type=\"button\" style=\"font-size: x-small;\" value=\"" + add_cap + "\" onclick=\"" + ActionScript("'add'") + "\">");
            //    viewHandle.ScriptsToRun.Add("$('#cmdAdd_" + id + "').css('padding', '0px 6px 0px 6px').button();");  //top, right, bottom, left
            //    viewHandle.ScriptsToRun.Add("$('#cmdAdd_" + id + "').css('top', -5);");
            //    viewHandle.ScriptsToRun.Add("$('#cmdAdd_" + id + "').css('width', 200);");
            //}

            //if (RowSource != null && RowSource.Count > 0 && AllowExport)
            //    sb.Append("<img src=\"Graphics/ExcelSmall.png\" title=\"Download this list\" alt=\"Download this list\" style=\"cursor: pointer; margin: 2px\" onclick=\"" + ActionScript("'download_list'") + "\"/>");

            //sb.Append("<img src=\"Graphics/Edit.png\" title=\"Edit this layout\" alt=\"Edit this layout\" style=\"cursor: pointer; margin: 2px; margin-right: 18px\" onclick=\"" + ActionScript("'edit_layout'") + "\"/>");

            //sb.Append("</div>");

        }
        public override void Act(Context x, SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            switch (args.ActionId)
            {
                case "add":
                    if (AddNewItem != null)
                        AddNewItem(x, args.SourcePage, args.SourceView);
                    break;
                case "edit_layout":
                    ((LeaderWebUserRz)x.Leader).TemplateEdit(xrz, CurrentTemplate);
                    if (TheArgs != null)
                    {
                        CurrentTemplate = n_template.GetByName(x, TheArgs.TheTemplate);
                        if (CurrentTemplate == null)
                            CurrentTemplate = n_template.Create(xrz, TheArgs.TheClass, TheArgs.TheTemplate);
                        CurrentTemplate.GatherColumns(xrz);
                        ColSource = new ColumnSourceTemplate(CurrentTemplate);

                        RefreshLV(xrz, args);
                    }
                    //if (TheArgs != null && RowSource != null && RowSource.Count > 0)
                    //    RowSource = new RowSourceTable(x.Select(TheArgs.RenderSql(x, CurrentTemplate)));
                    Change();
                    break;
                case "download_list":
                    DownloadList(xrz, args);
                    break;
                case "refresh_list":
                    RefreshLV(xrz, args);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        void DownloadList(ContextRz x, SpotActArgs args)
        {
            DataTable d = x.Select(TheArgs.RenderSqlWithoutSystem(x, CurrentTemplate));

            String file = (x.Leader.BilgePath(x) + "Export_" + Tools.Strings.FilterTrash(TheArgs.TheCaption) + "_" + Tools.Dates.GetNowPathHMS() + ".xlsx").Replace("__", "_");
            Tools.Excel.DataTableToExcel(file, d, CurrentTemplate.ColumnCaptions(x), CurrentTemplate.ColumnTypes(x));
            args.SourceView.FilesToDownload.Add(file);
        }
        void RefreshLV(ContextRz x, SpotActArgs args)
        {
            if (TheArgs == null)
                return;
            if (CurrentTemplate == null)
            {
                CurrentTemplate = n_template.GetByName(x, TheArgs.TheTemplate);
                if (CurrentTemplate == null)
                    CurrentTemplate = n_template.Create(x, TheArgs.TheClass, TheArgs.TheTemplate);
            }
            CurrentTemplate.GatherColumns(x);
            ColSource = new ColumnSourceTemplate(CurrentTemplate);
            RowSource = new RowSourceTable(x.Select(TheArgs.RenderSql(x, CurrentTemplate)));
            Change();
        }
        protected override List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> a, IItem item)
        {
            return ((ILeaderRz)((ContextRz)x).TheLeaderRz).FilterActsForWeb(x, a, (nObject)item);
        }
    }
}