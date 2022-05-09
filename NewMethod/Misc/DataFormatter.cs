using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace NewMethod
{
    public class DataFormatter
    {
        public List<String> Formats;
        public List<String> Alignments;
        protected List<DataFormatterField> Fields;
        public int Border = 1;
        public int CellPadding = 1;
        public int CellSpacing = 1;
        public bool BoldCaptions = true;
        public String LineColor = "";
        public bool WrapText = false;

        public String Write(DataTable d)
        {
            StringBuilder sb = new StringBuilder();
            if (!Tools.Data.DataTableExists(d))
                return "<font color=red>No Data</font><br>";
            sb.Append("<table border=\"" + Border.ToString() + "\" cellpadding=\"" + CellPadding.ToString() + "\" cellspacing=\"" + CellSpacing.ToString() + "\"><tr>");

            if (Fields == null)
            {
                Fields = new List<DataFormatterField>();
                int ix = 0;
                foreach (DataColumn c in d.Columns)
                {
                    Fields.Add(new DataFormatterField(ix, c.Caption));
                    ix++;
                }
            }

            foreach (DataFormatterField f in Fields)
            {
                sb.Append("<td nowrap>");
                if( BoldCaptions )
                    sb.Append("<b>");
                sb.Append(f.Caption);
                if( BoldCaptions )
                    sb.Append("</b>");
               sb.Append("</td>");
            }
            sb.Append("</tr>");
            foreach (DataRow r in d.Rows)
            {
                String linecolor = CalcColor(r);
                sb.Append("<tr>");
                int i = 0;
                foreach (DataFormatterField f in Fields)
                {
                    String salign = "";
                    if (Alignments != null)
                    {
                        try
                        {
                            salign = Alignments[i];
                        }
                        catch
                        {
                        }
                    }
                    else
                        salign = f.Alignment;

                    String wraptext = "";
                    if (!WrapText)
                        wraptext = " nowrap";

                    if (salign == "")
                        sb.Append("<td" + wraptext + ">");
                    else
                        sb.Append("<td" + wraptext + " align=\"" + salign + "\">");

                    String sformat = "";
                    if (Formats != null)
                    {
                        try
                        {
                            sformat = Formats[i];
                        }
                        catch
                        {
                        }
                    }
                    else
                        sformat = f.Format;
                    Object o = null;
                    if (f.Index > -1)
                        o = r[f.Index];
                    else
                        o = r[f.Name];

                    if (o == null || o == System.DBNull.Value)
                        sb.Append("&nbsp;");
                    else
                    {
                        if (Tools.Strings.StrExt(linecolor))
                            sb.Append("<font color=\"" + linecolor + "\">");
                        if (sformat == "")
                        {
                            String raw = "";

                            if (o.GetType().Name == "DateTime")
                            {
                                raw = nTools.DateFormat((DateTime)o);
                            }
                            else if (o.GetType().Name == "Boolean")
                            {
                                raw = nTools.YesBlankFilter((Boolean)o);
                            }
                            else
                            {
                                raw = o.ToString();
                            }

                            if (WrapText)
                                raw = raw.Replace("\n", "<br>").Replace("\r", "");
                            else
                                raw = raw.Replace("\n", "&nbsp;").Replace("\r", "");

                            sb.Append(raw + "&nbsp;");
                        }
                        else
                            sb.Append(String.Format(sformat, o) + "&nbsp;");
                        if (Tools.Strings.StrExt(linecolor))
                            sb.Append("</font>");
                    }
                    sb.Append("</td>");
                    i++;
                }
                sb.Append("</tr>");
            }
            sb.Append("</table><br>");
            return sb.ToString();
        }

        public virtual String CalcColor(DataRow r)
        {
            return LineColor;
        }

        protected class DataFormatterField
        {
            public String Name = "";
            public int Index = -1;
            public String Caption = "";
            public String Alignment = "";
            public String Format = "";

            public DataFormatterField(String name, String caption, String alignment, String format)
            {
                Name = name;
                Caption = caption;
                Alignment = alignment;
                Format = format;
            }

            public DataFormatterField(String name, String caption) : this(name, caption, "", "")
            {

            }

            public DataFormatterField(int index, String caption)
            {
                Index = index;
                Caption = caption;
            }
        }
    }
}
