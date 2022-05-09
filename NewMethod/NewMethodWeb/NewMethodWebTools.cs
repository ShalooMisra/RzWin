using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Drawing;

using Core;
using CoreWeb;
using NewMethod;
using Tools.Database;

namespace NewMethodWeb
{
    public class WebTable
    {
        public int RowsOnPage = 15;

        public String ListRender(ContextNM x, System.Web.SessionState.HttpSessionState Session, ListArgs args, System.Web.UI.Page page, ref int count)
        {
            return ListRender(x, Session, args, page, ref count, args.UniqueID);
        }
        
        public virtual String ListRender(ContextNM x, System.Web.SessionState.HttpSessionState Session, ListArgs args, System.Web.UI.Page page, ref int count, String tableId)
        {
            if (!Tools.Strings.StrExt(args.TheTemplate))
                return "No template";
            n_template t = n_template.GetByName(x, args.TheTemplate);
            if (t == null)
                t = n_template.Create((ContextNM)x, args.TheClass, args.TheTemplate);
            t.GatherColumns((ContextNM)x);

            if( Tools.Strings.StrCmp(tableId, args.UniqueID ) )  //otherwise this is handled by the spot system
                ListArgsAdd(Session, args);

            if (args.LiveItems != null)
            {
                List<IItem> l = new List<IItem>();
                foreach (IItem i in args.LiveItems.AllGet(x))
                {
                    l.Add(i);
                }
                return ListRender(x, new RowSourceItem(l), args, page, t, ref count, tableId);
            }
            else
                return ListRenderData(x, args, page, t, ref count, tableId);
        }

        public static void ListArgsAdd(System.Web.SessionState.HttpSessionState Session, ListArgs args)
        {
            Session["ListArgs_" + args.UniqueID] = args;
        }

        protected ListArgs ListArgsGet(System.Web.SessionState.HttpSessionState Session, String id)
        {
            return (ListArgs)Session["ListArgs_" + id];
        }

        protected virtual void RenderRowStart(StringBuilder sb, RowHandle r, System.Web.UI.Page page, ListArgs args)
        {
            String style = "";

            Color fore = r.ForeColor;
            if (fore != Color.Black)
                style = " style=\"color: " + Tools.Html.GetHTMLColor(fore) + "\"";

            sb.Append("<tr" + style + ">");
            IconColumnRender(r, sb, page);
        }

        public virtual String ListRender(ContextNM context, RowSource rows, ListArgs args, System.Web.UI.Page page, n_template t, ref int count, String tableId)
        {
            count = rows.Count;
            StringBuilder sb = new StringBuilder();
            SummaryRender(args, sb, count, page);
            HeaderRender(args, sb, t, count, tableId);
            
            foreach (RowHandle r in rows)
            {
                RenderRow(context, r, args, page, t, sb);
            }
            FooterRender(args, sb, t.AllColumns.Count, count);
            sb.Append("</table>");
            if (count > RowsOnPage)
                SummaryRender(args, sb, count, page);
            return sb.ToString();
        }

        public virtual void RenderRow(ContextNM context, RowHandle r, ListArgs args, System.Web.UI.Page page, n_template t, StringBuilder sb)
        {
            RenderRowStart(sb, r, page, args);

            int i = 0;
            bool first = true;
            foreach (DictionaryEntry d in t.AllColumns)
            {
                n_column c = (n_column)d.Value;
                ColumnRenderStart(args, sb, c, r, page, first);
                first = false;
                try
                {
                    Object o = r.Value(c.field_name);
                    ValueRender(context, o, sb, c, r);
                }
                catch
                {
                    sb.Append("[Missing " + c.field_name + "]");
                }
                sb.Append("</td>");
                i++;
            }
            if (args.OptionsAllow)
                OptionFieldRender(args, page, sb, r.Uid);

            sb.Append("</tr>");
        }

        protected virtual String ListRenderData(ContextNM x, ListArgs args, System.Web.UI.Page page, n_template t, ref int count, String tableId)
        {
            DataTable dt = null;
            if (!args.HeaderOnly)
            {
                String sql = args.RenderSql((ContextNM)x, t);
                if (args.TheConnection != null)
                    dt = args.TheConnection.Select(sql);
                else
                    dt = args.TheContext.Select(sql);
            }            

            return ListRender(x, new RowSourceTable(dt), args, page, t, ref count, tableId);
        }

        public virtual String DownloadLinkRender(String id, String caption, System.Web.UI.Page page)
        {
            return "<a href=\"" + page.ResolveClientUrl("~/Download.aspx") + "?id=" + id + "\">" + caption + "</a>";        
        }
        
        protected virtual void SummaryRender(ListArgs args, StringBuilder sb, int line_count, System.Web.UI.Page page)
        {
            if (line_count > 0)
                sb.Append("<br>" + args.TheCaption + "&nbsp;&nbsp;&nbsp;&nbsp;" + Tools.Strings.PluralizePhrase("Line", line_count));
            if (line_count > 0 && args.SaveAllow && args.LiveItems == null)
                sb.Append("&nbsp;&nbsp;&nbsp;" + DownloadLinkRender(args.UniqueID, "Download This List", page));
            if (args.AddAllow)
            {
                String qs = "action=add&class=" + args.TheClass;
                if (args.AddQueryStringsHas)
                {
                    for (int i = 0; i < args.AddQueryStrings.Count || i < args.AddCaptions.Count; i++)
                    {
                        sb.Append("&nbsp;&nbsp;&nbsp;<a target=\"_blank\" href=\"" + page.ResolveClientUrl("~/Process.aspx") + "?" + args.AddQueryStrings[i].ToString() + "\">" + args.AddCaptions[i].ToString() + "</a>");
                    }
                    return;
                }
                sb.Append("&nbsp;&nbsp;&nbsp;<a target=\"_blank\" href=\"" + page.ResolveClientUrl("~/Process.aspx") + "?" + qs + "\">" + args.AddCaption + "</a>");
            }
        }
        public static bool DownloadSqlToCsv(ContextNM q, HttpServerUtility Server, HttpResponse Response, String sql, String id)
        {
            return DownloadSqlToCsv(q, Server, Response, sql, id, q.Data.Connection, "");
        }
        public static bool DownloadSqlToCsv(ContextNM q, HttpServerUtility Server, HttpResponse Response, String sql, String id, DataConnection xd, String heading)
        {
            String downloadfile = "";
            String downloadurl = "";
            downloadurl = "Downloads/" + id + ".csv";
            String folder = Server.MapPath("Downloads");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            downloadfile = nTools.ConditionFolderName(folder) + id + ".csv";
            if (File.Exists(downloadfile))
                File.Delete(downloadfile);
            long l = 0;
            if (heading == "")
                xd.ExportCSV(xd.Select(sql), downloadfile, ref l);
            else
                xd.ExportCSV(xd.Select(sql), downloadfile, ref l, false, heading);
            if (!File.Exists(downloadfile))
                return false;
            else
            {
                Response.Redirect(downloadurl);
                return true;
            }
        }

        protected virtual void ColumnDefRender(StringBuilder sb, n_column c, RowHandle r)
        {
            sb.Append("<td nowrap");           
            Color back = r.BackColor;
            if( back != Color.White )
                sb.Append(" bgcolor=\"" + Tools.Html.GetHTMLColor(back) + "\"");
            sb.Append(">");
        }

        public bool UseIconColumn = false;
        public bool UseInlineIcons = true;
        protected virtual void ColumnRenderStart(ListArgs args, StringBuilder sb, n_column c, RowHandle r, System.Web.UI.Page page, bool first)
        {
            ColumnDefRender(sb, c, r);

            if (first && UseInlineIcons)
            {
                IconRender(r, sb, page);
            }
        }

        protected virtual void IconRender(RowHandle r, StringBuilder sb, System.Web.UI.Page page)
        {
            string pic = r.IconKey;
            if (Tools.Strings.StrExt(pic))
                sb.Append("<img border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/" + pic + ".png") + "\" />&nbsp;&nbsp;");
        }

        protected virtual void IconColumnRender(RowHandle r, StringBuilder sb, System.Web.UI.Page page)
        {
            if (UseIconColumn)
            {
                sb.Append("<td nowrap class=\"webtablecell\">");
                IconRender(r, sb, page);
                sb.Append("</td>");
            }
        }

        protected virtual void ValueRender(ContextNM context, Object o, StringBuilder sb, n_column c, RowHandle r)
        {
            if (o == null)
                sb.Append("&nbsp;");
            else
            {
                String raw = Stylizer.RenderVal(o, c, context.Sys.CurrencySymbol);
                raw = raw.Replace("\n", "<br>").Replace("\r", "");
                sb.Append(raw + "&nbsp;");
            }
        }
        protected virtual void OptionFieldRender(ListArgs args, System.Web.UI.Page page, StringBuilder sb, String id)
        {
            sb.Append("<td nowrap>");
            sb.Append("<a href=\"" + page.ResolveClientUrl("~/Process.aspx") + "?action=show&class=" + args.TheClass + "&id=" + id + "\">Open</a>");
            sb.Append("</td>");
        }

        protected virtual void FooterRender(ListArgs args, StringBuilder sb, int field_count, int line_count)
        {

        }

        protected virtual void TableDefRenderStart(StringBuilder sb, String tableId)
        {
            sb.Append("<table id=\"" + tableId + "\" style=\"border-style: groove; border-width: thin\" border=\"1\" cellpadding=\"1\" cellspacing=\"1\" width=\"100%\"><tr>");
        }

        protected virtual void TableDefRenderEnd(StringBuilder sb)
        {
            sb.Append("</tr>");
        }

        protected virtual void RenderOptionColumn(StringBuilder sb)
        {
            sb.Append("<td nowrap>");
            sb.Append("<b>Options</b>");
            sb.Append("</td>");
        }

        protected virtual void HeaderRender(ListArgs args, StringBuilder sb, n_template t, int line_count, String tableId)
        {
            TableDefRenderStart(sb, tableId);

            int total_percent = 0;
            double scale_factor = 1;
            foreach (DictionaryEntry dx in t.AllColumns)
            {
                n_column c = (n_column)dx.Value;
                total_percent += c.column_width;
            }
            if (total_percent > 100)
                scale_factor = total_percent / 100;
            
            if (args.OptionsAllow)
                RenderOptionColumn(sb);

            if( UseIconColumn )
                HeaderRenderIconColumn(sb);

            foreach (DictionaryEntry dx in t.AllColumns)
            {
                n_column c = (n_column)dx.Value;

                RenderHeaderColumnStart(sb, c, scale_factor);
                sb.Append("<b>");
                sb.Append("&nbsp;" + c.column_caption);
                sb.Append("</b>");
                RenderHeaderColumnEnd(sb);
            }

            TableDefRenderEnd(sb);
        }

        protected virtual void HeaderRenderIconColumn(StringBuilder sb)
        {
            sb.Append("<td>&nbsp;</td>");
        }

        protected virtual void RenderHeaderColumnStart(StringBuilder sb, n_column c, Double scale_factor)
        {
            sb.Append("<td width=\"" + Math.Round(c.column_width * scale_factor, 0).ToString() + "%\" nowrap>");         
        }

        protected virtual void RenderHeaderColumnEnd(StringBuilder sb)
        {
            sb.Append("</td>");
        }
    }

    public class WebTableHighFive : WebTable
    {
        protected override void RenderRowStart(StringBuilder sb, RowHandle r, System.Web.UI.Page page, ListArgs args)
        {
            String style = "";
            Color fore = r.ForeColor;
            if (fore != Color.Black)
                style = " style=\"color: " + Tools.Html.GetHTMLColor(fore) + "\"";

            sb.Append("<tr class=\"HighFive\"" + style + ">");
            IconColumnRender(r, sb, page);
        }

        protected override void OptionFieldRender(ListArgs args, Page page, StringBuilder sb, string id)
        {
            sb.Append("<td nowrap>");
            sb.Append("<a href=\"" + page.ResolveClientUrl("~/Process.aspx") + "?action=show&class=" + args.TheClass + "&id=" + id + "\" target=\"_blank\"><img src=\"" + page.ResolveClientUrl("~/Graphics") + "/edit.gif\" title=\"Edit this entry\" alt=\"Edit this entry\" border=\"0\" height=\"20\" width=\"20\"></a>");
            sb.Append("</td>");
        }

        protected override void ColumnDefRender(StringBuilder sb, n_column c, RowHandle r)
        {
            //base.ColumnDefRender(sb, c, backcolor);
            Color back = r.BackColor;
            sb.Append("<td nowrap class=\"HighFive\"");
            if( back != Color.White )
                sb.Append(" bgcolor=\"" + Tools.Html.GetHTMLColor(back) + "\"");
            sb.Append(">");
        }

        protected override void TableDefRenderStart(StringBuilder sb, String tableId)
        {   
            sb.AppendLine("    <style type=\"text/css\">");
            sb.AppendLine("        .HighFive");
            sb.AppendLine("        {");
            sb.AppendLine("    border-left: 0;");
            sb.AppendLine("    border-right: 0;");
            sb.AppendLine("    border-top: 0;");
            sb.AppendLine("    border-bottom: thin solid #e3e3e6;");
            sb.AppendLine("        }");
            sb.AppendLine("     </style>");
            sb.Append("<table border=\"0\" cellpadding=\"3\" cellspacing=\"3\"><tr class=\"HighFive\">");
        }

        public override string DownloadLinkRender(string id, string caption, Page page)
        {
            //return base.DownloadLinkRender(id, caption, page);
            return "<a href=\"" + page.ResolveClientUrl("~/Download.aspx") + "?format=xls&id=" + id + "\"><img border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics") + "/Excel.jpg\" alt=\"Download as Excel\" title=\"Download as Excel\"></a>";  //<a href=\"Download.aspx?format=csv&id=" + id + "\"><img src=\"" + graphics_path + "csv.gif\" alt=\"Download as Csv\"></a>
        }

        protected override void RenderOptionColumn(StringBuilder sb)
        {
            sb.Append("<td nowrap>");
            sb.Append("&nbsp;");
            sb.Append("</td>");
        }

        protected override void RenderHeaderColumnStart(StringBuilder sb, n_column c, Double scale_factor)
        {
            sb.Append("<td class=\"HighFive\" nowrap>");
        }
    }

    //public class WebTableJq : WebTable
    //{
    //    protected override void RenderRowStart(StringBuilder sb, RowHandle r, System.Web.UI.Page page, ListArgs args)
    //    {
    //        String style = "";

    //        Color fore = r.ForeColor;
    //        if (fore != Color.Black)
    //            style = "color: " + Tools.Html.GetHTMLColor(fore);

    //        Color back = r.BackColor;
    //        if (back != System.Drawing.Color.White)
    //        {
    //            if (style != "")
    //                style += "; ";
    //            style += "background-color: " + Tools.Html.GetHTMLColor(back);
    //        }

    //        if( style != "" )
    //            style = " style=\"" + style + "\"";

    //        sb.Append("<tr class=\"webtablerow\" " + style + " id=\"" + args.UniqueID + "_dot_" + r.Uid + "\">");
    //        IconColumnRender(r, sb, page);
    //    }

    //    protected override void OptionFieldRender(ListArgs args, Page page, StringBuilder sb, string id)
    //    {
    //        //base.OptionFieldRender(args, page, sb, id, style);
    //    }

    //    protected override void ColumnDefRender(StringBuilder sb, n_column c, RowHandle r)
    //    {
    //        //base.ColumnDefRender(sb, c, backcolor);
    //        sb.Append("<td class=\"webtablecell\" nowrap");
    //        switch (c.data_type)
    //        {
    //            case (int)NewMethod.Enums.DataType.Integer:
    //            case (int)NewMethod.Enums.DataType.Long:
    //            case (int)NewMethod.Enums.DataType.Float:
    //                sb.Append(" align=\"right\"");
    //                break;
    //        }
    //        //this shouldn't be by cell, right?
    //        //Color back = r.BackColor;
    //        //if( back != Color.White )
    //        //    sb.Append(" bgcolor=\"" + Tools.Html.GetHTMLColor(back) + "\"");
    //        sb.Append(">");
    //    }

    //    protected override void SummaryRender(ListArgs args, StringBuilder sb, int line_count, Page page)
    //    {
    //        //base.SummaryRender(args, sb, line_count, page);
    //    }

    //    protected override void TableDefRenderStart(StringBuilder sb, String tableId)
    //    {
    //        sb.Append("<table id=\"" + tableId + "\" cellpadding=\"2\" cellspacing=\"0\" border=\"0\" class=\"display\" width=\"100%\"><thead><tr>");
    //    }

    //    protected override void HeaderRenderIconColumn(StringBuilder sb)
    //    {
    //        sb.Append("<th>&nbsp;</th>");
    //    }

    //    protected override void ValueRender(object o, StringBuilder sb, n_column c, RowHandle r)
    //    {
    //        //base.ValueRender(o, sb, c, forecolor);
    //        if (o == null)
    //            sb.Append("&nbsp;");
    //        else
    //        {
    //            Color fore = r.ForeColor;
    //            if( fore != Color.Black )
    //                sb.Append("<font color=\"" + Tools.Html.GetHTMLColor(fore) + "\">");
    //            String raw = Stylizer.RenderVal(o, c, "$");
    //            raw = raw.Replace("\n", "<br>").Replace("\r", "");
                
    //            sb.Append(raw);//the spaces mess up numeric sorting

    //            if (fore != Color.Black)
    //                sb.Append("</font>");
    //        }
    //    }

    //    protected override void RenderOptionColumn(StringBuilder sb)
    //    {
    //        //base.RenderOptionColumn(sb);
    //    }

    //    protected override void TableDefRenderEnd(StringBuilder sb)
    //    {
    //        sb.Append("</thead></tr>");
    //    }

    //    protected override void RenderHeaderColumnStart(StringBuilder sb, n_column c, Double scale_factor)
    //    {
    //        sb.Append("<th>");  //width=\"" + Math.Round(c.column_width * scale_factor, 0).ToString() + "%\"
    //    }

    //    protected override void RenderHeaderColumnEnd(StringBuilder sb)
    //    {
    //        sb.Append("</th>");
    //    }
    //}

    public class NewMethodWebTools
    {
        public static bool DownloadSqlToCsv(ContextNM q, HttpServerUtility Server, HttpResponse Response, String sql, String id)
        {
            return DownloadSqlToCsv(q, Server, Response, sql, id, q.Data.TheConnection, "");
        }

        public static bool DownloadSqlToCsv(ContextNM q, HttpServerUtility Server, HttpResponse Response, String sql, String id, DataConnection xd, String heading)
        {
            String downloadfile = "";
            String downloadurl = "";
            downloadurl = "Downloads/" + id + ".csv";
            String folder = Server.MapPath("Downloads");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            downloadfile = nTools.ConditionFolderName(folder) + id + ".csv";
            if (File.Exists(downloadfile))
                File.Delete(downloadfile);
            long l = 0;
            if (heading == "")
                xd.ExportCSV(xd.Select(sql), downloadfile, ref l, true);
            else
                xd.ExportCSV(xd.Select(sql), downloadfile, ref l, false, heading);
            if (!File.Exists(downloadfile))
                return false;
            else
            {
                Response.Redirect(downloadurl);
                return true;
            }
        }
    }
}
