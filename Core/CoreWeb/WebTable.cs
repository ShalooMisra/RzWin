using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

using Core;

namespace CoreWeb
{
    public class WebTable
    {
        protected String TableId = "";
        public WebTable(String tableId)
        {
            TableId = tableId;
        }

        protected virtual void RenderRowStart(StringBuilder sb, RowHandle r, System.Web.UI.Page page, bool has_grid_color = true)
        {
            String style = "";
            Color fore = Color.Black;
            if (has_grid_color)
                fore = r.ForeColor;
            if (fore != Color.Black)
                style = " style=\"color: " + Tools.Html.GetHTMLColor(fore) + "\"";
            sb.Append("<tr" + style + ">");
            IconColumnRender(r, sb, page);
        }

        public virtual String ListRender(Context context, ColumnSource cols, RowSource rows, System.Web.UI.Page page, ref int count, String tableId, Spot spot)
        {
            count = 0;
            if (rows != null)
                count = rows.Count;
            StringBuilder sb = new StringBuilder();
            HeaderRender(sb, cols, rows, count, tableId);
            if (rows != null)
            {
                bool grid_color_checked = false;
                bool has_grid_color = false;
                foreach (RowHandle r in rows)
                {
                    if (!grid_color_checked)
                    {
                        grid_color_checked = true;
                        try { object o = r.Value("grid_color"); has_grid_color = true; }
                        catch { has_grid_color = false; }
                    }
                    RenderRow(context, cols, r, page, sb, spot, has_grid_color);
                }
                RenderLastRow(context, rows, cols, sb);
            }
            FooterRender(sb, cols.Count, count);
            sb.Append("</table>");
            //AfterRender(sb, count);
            return sb.ToString();
        }

        //protected virtual void AfterRender(StringBuilder sb, int count)
        //{

        //}

        public virtual void RenderRow(Context context, ColumnSource cols, RowHandle r, System.Web.UI.Page page, StringBuilder sb, Spot spot, bool has_grid_color = true)
        {
            RenderRowStart(sb, r, page, has_grid_color);
            int i = 0;
            bool first = true;
            foreach (ColumnHandle c in cols)
            {
                ColumnRenderStart(sb, c, r, page, first);
                first = false;
                try
                {
                    Object o = r.Value(c.Name);
                    if (c.DataType == Tools.Database.FieldType.SingleRef)
                    {
                        if (r is RowHandleItem)
                        {
                            RowHandleItem ri = (RowHandleItem)r;
                            IVarRefSingle var = null;
                            foreach (IVarRef vr in ((Item)ri.Item).VarRefsList)
                            {
                                if (Tools.Strings.StrCmp(vr.TheAttribute.Name, c.Name))
                                {
                                    var = (IVarRefSingle)vr;
                                    break;
                                }
                            }
                            IItem value = var.RefItemGet(context);
                            o = "";
                            if (value != null)
                                o = value.ToString();
                        }
                    }
                    ValueRender(spot, o, sb, c, r);
                }
                catch
                {
                    //sb.Append("[Missing " + c.Name + "]");
                }
                sb.Append("</td>");
                i++;
            }
            sb.Append("</tr>");
        }

        public virtual void RenderLastRow(Context context, RowSource rows, ColumnSource cols, StringBuilder sb)
        {

        }

        protected virtual void ColumnDefRender(StringBuilder sb, ColumnHandle c, RowHandle r)
        {
            sb.Append("<td nowrap");
            Color back = r.BackColor;
            if (back != Color.White)
                sb.Append(" bgcolor=\"" + Tools.Html.GetHTMLColor(back) + "\"");

            sb.Append(">");
        }

        public bool UseIconColumn = false;
        public bool UseInlineIcons = true;
        protected virtual void ColumnRenderStart(StringBuilder sb, ColumnHandle c, RowHandle r, System.Web.UI.Page page, bool first)
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

        protected virtual void ValueRender(Spot spot, Object o, StringBuilder sb, ColumnHandle c, RowHandle r)
        {
            if (o == null)
                sb.Append("&nbsp;");
            else
            {
                String raw = c.RenderVal(o);
                raw = raw.Replace("\n", "<br>").Replace("\r", "");
                sb.Append(raw + "&nbsp;");
            }
        }

        protected virtual void FooterRender(StringBuilder sb, int field_count, int line_count)
        {

        }

        protected virtual void TableDefRenderStart(StringBuilder sb, String tableId, int columnCount)
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

        protected virtual void HeaderRender(StringBuilder sb, ColumnSource cols, RowSource rows, int line_count, String tableId)
        {
            int columnCount = cols.Count;
            if (UseIconColumn)
                columnCount++;

            TableDefRenderStart(sb, tableId, columnCount);

            int total_percent = 0;
            double scale_factor = 1;
            foreach (ColumnHandle c in cols)
            {
                total_percent += c.WidthPercent;
            }
            if (total_percent > 100)
                scale_factor = total_percent / 100;

            if (UseIconColumn)
                HeaderRenderIconColumn(sb);

            foreach (ColumnHandle c in cols)
            {
                RenderHeaderColumnStart(sb, c, scale_factor);
                //sb.Append("<b>");
                sb.Append("&nbsp;" + c.Caption);
                //sb.Append("</b>");
                RenderHeaderColumnEnd(sb);
            }

            TableDefRenderEnd(sb);
        }

        protected virtual void HeaderRenderIconColumn(StringBuilder sb)
        {
            sb.Append("<td>&nbsp;</td>");
        }

        protected virtual void RenderHeaderColumnStart(StringBuilder sb, ColumnHandle c, Double scale_factor)
        {
            sb.Append("<td class=\"webtableheader\" width=\"" + Math.Round(c.WidthPercent * scale_factor, 0).ToString() + "%\" nowrap>");
        }

        protected virtual void RenderHeaderColumnEnd(StringBuilder sb)
        {
            sb.Append("</td>");
        }
    }

    public class WebTableJq : WebTable
    {
        public WebTableJq(String tableId)
            : base(tableId)
        {
        }
        public bool FlattenRows = false;
        protected override void ValueRender(Spot spot, Object o, StringBuilder sb, ColumnHandle c, RowHandle r)
        {
            if (o == null)
                sb.Append("&nbsp;");
            else
            {
                if (o is VarBlob)
                {
                    sb.Append("<a href=\"#\" onclick=\"" + spot.ActionScript("'open_blob'", "'" + r.Uid + "." + ((VarBlob)o).TheAttribute.Name + "'") + "\">Open " + ((VarBlob)o).TheAttribute.Name + "</a>");
                }
                else
                {
                    String raw = c.RenderVal(o);
                    raw = raw.Replace("\n", "<br>").Replace("\r", "");
                    if (FlattenRows)
                        raw = raw.Replace("<br>", " ");
                    sb.Append(raw + "&nbsp;");
                }
            }
        }
       
        protected override void RenderRowStart(StringBuilder sb, RowHandle r, System.Web.UI.Page page, bool has_grid_color = true)
        {
            String style = "";
            Color fore = Color.Black;
            if (has_grid_color)
                fore = r.ForeColor;
            if (fore != Color.Black)
                style = "color: " + Tools.Html.GetHTMLColor(fore);
            Color back = r.BackColor;
            if (back != System.Drawing.Color.White)
            {
                if (style != "")
                    style += "; ";
                style += "background-color: " + Tools.Html.GetHTMLColor(back);
            }
            if (style != "")
                style = " style=\"" + style + "\"";
            sb.Append("<tr class=\"webtablerow\" " + style + " id=\"" + TableId + "_dot_" + r.Uid + "\">");
            IconColumnRender(r, sb, page);
        }

        protected override void ColumnDefRender(StringBuilder sb, ColumnHandle c, RowHandle r)
        {
            sb.Append("<td class=\"webtablecell\" nowrap");
            switch (c.Alignment)
            {
                case ColumnAlignment.Right:
                    sb.Append(" align=\"right\"");
                    break;
                case ColumnAlignment.Center:
                    sb.Append(" align=\"center\"");
                    break;
            }
            sb.Append(">");
        }

        protected override void TableDefRenderStart(StringBuilder sb, String tableId, int columnCount)
        {
            sb.Append("<table id=\"" + tableId + "\" cellpadding=\"2\" cellspacing=\"0\" border=\"0\" class=\"display\" width=\"100%\"><colgroup>");

            for (int i = 0; i < columnCount; i++)
            {
                sb.Append("<col>");
            }

            sb.Append("</colgroup><thead><tr>");
        }

        protected override void HeaderRenderIconColumn(StringBuilder sb)
        {
            sb.Append("<th>&nbsp;</th>");
        }

        //this isn't the right way to color the row
        //protected override void ValueRender(object o, StringBuilder sb, n_column c, RowHandle r)
        //{
        //    //base.ValueRender(o, sb, c, forecolor);
        //    if (o == null)
        //        sb.Append("&nbsp;");
        //    else
        //    {
        //        Color fore = r.ForeColor;
        //        if (fore != Color.Black)
        //            sb.Append("<font color=\"" + Tools.Html.GetHTMLColor(fore) + "\">");
        //        String raw = Stylizer.RenderVal(o, c, "$");
        //        raw = raw.Replace("\n", "<br>").Replace("\r", "");

        //        sb.Append(raw);//the spaces mess up numeric sorting

        //        if (fore != Color.Black)
        //            sb.Append("</font>");
        //    }
        //}

        protected override void RenderOptionColumn(StringBuilder sb)
        {
            //base.RenderOptionColumn(sb);
        }

        protected override void TableDefRenderEnd(StringBuilder sb)
        {
            sb.Append("</thead></tr>");
        }

        protected override void RenderHeaderColumnStart(StringBuilder sb, ColumnHandle c, Double scale_factor)
        {
            sb.Append("<th>");  //width=\"" + Math.Round(c.column_width * scale_factor, 0).ToString() + "%\"
        }

        protected override void RenderHeaderColumnEnd(StringBuilder sb)
        {
            sb.Append("</th>");
        }
    }
}
