using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using Core;
using System.Drawing;
using Tools.Database;

namespace CoreWeb.Controls
{
    public class ChartControl : Spot
    {
        public Report Report;
        public ChartType ChartType;
        public void Init(Report report, ChartType chartType)
        {
            Report = report;
            ChartType = chartType;
            Change();
        }

        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            if (Report == null)
                return;
            Chart chart = null;
            if (Report.Lines.Count <= 0)
            {
                if (Report.Sections.Count <= 0)
                {
                    sb.AppendLine("There is no information to display");
                    return;
                }
                else
                    chart = ChartFromSections();
            }
            else
                chart = ChartFromLines();
            StringBuilder chartJs = new StringBuilder();
            switch (ChartType)
            {
                case ChartType.Bar:
                    RenderBar(chartJs, TheScreen, chart, DivId, "Totals", "");  //"Spin('" + DivIdConvert(lv.Uid) + "');  Action(spotId, '" + Uid + "', 'slice', 'Totals.' + this.name);"
                    break;
                case ChartType.Pie:
                    if (chart.Series.Count == 1)
                        RenderPie(chartJs, chart, DivId, "Totals", "");  //"Spin('" + DivIdConvert(lv.Uid) + "');  Action(spotId, '" + Uid + "', 'slice', 'Totals.' + this.name);"
                    else
                    {
                        sb.AppendLine("<div style=\"width: 100%; height: 100%; overflow: scroll;\">");
                        foreach (ChartSeries s in chart.Series)
                        {
                            sb.AppendLine("<div style=\"width: 450px; height: 450px; border: thin solid #CCCCCC; margin: 4px; float: left\" id=\"chartDiv_" + s.Uid + "\"></div>");
                            RenderPie(chartJs, "chartDiv_" + s.Uid, "Totals", "", s);
                        }
                        sb.AppendLine("</div>");
                    }
                    break;
            }
            viewHandle.ScriptsToRun.Add(chartJs.ToString());
        }
        public Chart ChartFromLines()
        {
            Chart chart = new Chart(Report.Caption);
            int i = 0;
            foreach (ReportColumn c in Report.ColumnsList)
            {
                if (Report.ChartColumn(c))
                    chart.Series.Add(new ChartSeries(c.Caption, i, c.ValueUse));
                i++;
            }
            foreach (ReportLine l in Report.Lines)
            {
                String label = Tools.Strings.Left(l.Cells[0].Value.ToString(), 16);
                chart.XAxisLabels.Add(label);
                foreach (ChartSeries s in chart.Series)
                {
                    ChartPoint p = new ChartPoint("", Convert.ToDouble(l.Cells[s.SourceIndex].Value));
                    p.Caption = Convert.ToString(l.Cells[0].Value);
                    if (l.SummaryArgs != null)
                        p.LineId = l.Uid;
                    s.Points.Add(p);
                }
            }
            return chart;
        }
        public Chart ChartFromSections()
        {
            Chart chart = new Chart(Report.Caption);
            int i = 0;
            foreach (ReportTotal t in Report.SectionsList[0].Totals)
            {
                chart.Series.Add(new ChartSeries(t.Caption, i, t.ValueUse));
                i++;
            }
            foreach (ReportSection section in Report.SectionsList)
            {
                chart.XAxisLabels.Add(section.Caption);
                int index = 0;
                foreach (ChartSeries s in chart.Series)
                {
                    s.Points.Add(new ChartPoint("", Convert.ToDouble(section.Totals[index].Value)));
                    index++;
                }
            }
            return chart;
        }
        public static void RenderChartStart(StringBuilder sb, String id)
        {
            sb.AppendLine("     var chart_" + id + ";");
            sb.AppendLine("         chart_" + id + " = new Highcharts.Chart({");
        }
        public static void RenderChartEnd(StringBuilder sb, String id)
        {
            sb.AppendLine("         });");
            sb.AppendLine("$(\"text:contains('Highcharts.com')\").remove();");
        }
        public static void RenderPie(StringBuilder sb, Chart c, String targetDiv, String sectionId, String onClick, int width = 450, int height = 350)
        {
            RenderPie(sb, targetDiv, sectionId, onClick, c.Series[0], width, height);
        }
        public static void RenderPie(StringBuilder sb, String targetDiv, String sectionId, String onClick, ChartSeries series, int width = 450, int height = 350)
        {
            sb.AppendLine("$('#" + targetDiv + "').css('width', " + width.ToString() + ");");
            sb.AppendLine("$('#" + targetDiv + "').css('height', " + height.ToString() + ");");

            String id = Tools.Strings.GetNewID();
            RenderChartStart(sb, id);
            sb.AppendLine("             chart: {");
            sb.AppendLine("                 renderTo: '" + targetDiv + "',");
            sb.AppendLine("                 plotBackgroundColor: null,");
            sb.AppendLine("                 plotBorderWidth: null,");
            sb.AppendLine("                 plotShadow: false,");
            sb.AppendLine("                 spacingRight: 110,");
            sb.AppendLine("                 spacingLeft: 110,");
            sb.AppendLine("                 spacingTop: 5,");
            sb.AppendLine("                 spacingBottom: 5,");
            //sb.AppendLine("                 width: " + width.ToString() + ",");
            //sb.AppendLine("                 height: " + height.ToString() + "");
            sb.AppendLine("             },");
            sb.AppendLine("             title: {");
            sb.AppendLine("                 text: '" + series.Title.Replace("'", "") + "'");
            sb.AppendLine("             },");
            sb.AppendLine("             tooltip: {");
            sb.AppendLine("                 enabled: false");
            sb.AppendLine("             },");
            sb.AppendLine("             plotOptions: {");
            sb.AppendLine("                 pie: {");
            sb.AppendLine("                     allowPointSelect: true,");
            sb.AppendLine("                     cursor: 'pointer',");
            sb.AppendLine("                     dataLabels: {");
            sb.AppendLine("                         enabled: true,");
            sb.AppendLine("                         color: '#000000',");
            sb.AppendLine("                         connectorColor: '#000000',");
            sb.AppendLine("                         formatter: function () {");
            sb.AppendLine("                             return '<b>' + this.point.name + '</b><br/>' + this.point.y + '  (' + Math.round(this.percentage) + ' %)';");
            sb.AppendLine("                         }");
            sb.AppendLine("                     }");
            sb.AppendLine("                 }");
            sb.AppendLine("             },");
            sb.AppendLine("             series: [{");
            sb.AppendLine("                 type: 'pie',");
            sb.AppendLine("                 name: 'Category',");
            sb.AppendLine("                 data: [");
            int pointIndex = 0;
            foreach (ChartPoint p in series.Points)
            {
                if (p.Y > 0)
                {
                    if (pointIndex > 0)
                        sb.Append("                    , ");
                    sb.AppendLine("                    {");
                    sb.AppendLine("                      name: '" + p.Caption.Replace("'", "") + "',");
                    String color = Tools.Html.GetHTMLColor(p.Color);
                    if (color == "#000000")
                        color = ReportTargetHtml.SeriesColor(pointIndex);
                    sb.AppendLine("                      color: '" + color + "',");
                    sb.AppendLine("             	     y: " + p.Y.ToString() + ",");
                    sb.AppendLine("                      events: {");
                    sb.AppendLine("                          click: function() {");
                    sb.AppendLine("                                      " + onClick);
                    sb.AppendLine("                                 }");
                    sb.AppendLine("                      }");
                    sb.AppendLine("                    }");
                    pointIndex++;
                }
            }
            sb.AppendLine("              ]");
            sb.AppendLine("             }]");
            RenderChartEnd(sb, id);
        }
        public static void RenderBar(StringBuilder sb, Spot actionSpot, Chart c, String targetDiv, String sectionId, String onClick, int width = 600, int height = 400)
        {
            sb.AppendLine("$('#" + targetDiv + "').css('width', " + width.ToString() + ");");
            sb.AppendLine("$('#" + targetDiv + "').css('height', " + height.ToString() + ");");

            String id = Tools.Strings.GetNewID();
            RenderChartStart(sb, id);
            sb.AppendLine("	    chart: {");
            sb.AppendLine("            renderTo: '" + targetDiv + "',");
            sb.AppendLine("            zoomType: 'xy',");
            //sb.AppendLine("            width: " + width.ToString() + ",");
            //sb.AppendLine("            height: " + height.ToString() + "");
            sb.AppendLine("        },");
            sb.AppendLine("        title: {");
            sb.AppendLine("            text: '" + c.Title + "'");
            sb.AppendLine("        },");
            sb.AppendLine("        xAxis: [{");
            sb.AppendLine("            categories: [" + Tools.Data.GetIn(c.XAxisLabels) + "]");
            if (c.XAxisWidth > 200)
            {
                sb.AppendLine("            ,labels: {");
                sb.AppendLine("            rotation: -90,");
                sb.AppendLine("            align: 'right',");
                sb.AppendLine("            style: {");
                sb.AppendLine("            		font: 'normal 13px Verdana, sans-serif'");
                sb.AppendLine("            	}");
                sb.AppendLine("            }");
            }
            sb.AppendLine("        }],");
            sb.AppendLine("        yAxis: [");
            List<int> axisIndexes = new List<int>();
            Dictionary<ValueUse, AxisHandle> seriesTypes = new Dictionary<ValueUse, AxisHandle>();
            int seriesIndex = -1;
            foreach (ChartSeries s in c.Series)
            {
                if (seriesTypes.ContainsKey(s.ValueUse))
                {
                    AxisHandle h = seriesTypes[s.ValueUse];
                    h.Title += " / " + s.Title;
                    axisIndexes.Add(h.Index);
                    continue;
                }
                seriesIndex++;
                axisIndexes.Add(seriesIndex);
                seriesTypes.Add(s.ValueUse, new AxisHandle(s.ValueUse, seriesIndex, s.Title));
            }
            seriesIndex = 0;
            foreach (KeyValuePair<ValueUse, AxisHandle> kvp in seriesTypes)
            {
                if (seriesIndex > 0)
                    sb.Append(", ");
                sb.AppendLine("            {");
                sb.AppendLine("            labels: {");
                sb.AppendLine("                formatter: function() {");
                switch (kvp.Value.ValueUse)
                {
                    case ValueUse.UnitMoney:
                        sb.AppendLine("                    return '$' + CommaFormatted(Math.round(this.value*Math.pow(10,2))/Math.pow(10,2));");  //
                        break;
                    case ValueUse.TotalMoney:
                        sb.AppendLine("                    return '$' + CommaFormatted(Math.round(this.value));");
                        break;
                    case ValueUse.Quantity:
                        sb.AppendLine("                    return CommaFormatted(Math.round(this.value));");
                        break;
                    default:
                        sb.AppendLine("                    return this.value;");
                        break;
                }
                sb.AppendLine("                },");
                sb.AppendLine("                style: {");
                sb.AppendLine("                    color: '#3E576F'");
                sb.AppendLine("                }");
                sb.AppendLine("            },");
                sb.AppendLine("            title: {");
                sb.AppendLine("                text: '" + kvp.Value.Title + "',");
                sb.AppendLine("                style: {");
                sb.AppendLine("                    color: '#3E576F'");
                sb.AppendLine("                }");
                sb.AppendLine("            }");
                if (seriesIndex > 0)
                    sb.AppendLine("            , opposite: true");
                sb.AppendLine("        }");
                seriesIndex++;
            }
            sb.AppendLine("],");
            sb.AppendLine("        tooltip: {");
            sb.AppendLine("            formatter: function() {");
            sb.AppendLine("                return '' + this.x + ': ' + this.point.name;");
            sb.AppendLine("            }");
            sb.AppendLine("        },");
            sb.AppendLine("        legend: {");
            sb.AppendLine("            layout: 'vertical',");
            sb.AppendLine("            align: 'left',");
            sb.AppendLine("            x: 120,");
            sb.AppendLine("            verticalAlign: 'top',");
            sb.AppendLine("            y: 20,");  //was 100
            sb.AppendLine("            floating: true,");
            sb.AppendLine("            backgroundColor: '#FFFFFF'");
            sb.AppendLine("        },");
            sb.AppendLine("        series: [");
            seriesIndex = 0;
            foreach (ChartSeries s in c.Series)
            {
                if (seriesIndex > 0)
                    sb.Append(", ");
                sb.AppendLine("            {");
                sb.AppendLine("            name: '" + s.Title + "',");

                if( s.Color != Color.Black )
                    sb.AppendLine("            color: '" + Tools.Html.GetHTMLColor(s.Color) + "',");
                else
                    sb.AppendLine("            color: '" + ReportTargetHtml.SeriesColor(seriesIndex) + "',");
                
                sb.AppendLine("            type: 'column',");
                int axisNumber = axisIndexes[seriesIndex];
                if (axisNumber > 0)
                    sb.AppendLine("            yAxis: " + axisNumber.ToString() + ",");
                sb.Append("            data: [");    //49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4                
                int pointIndex = 0;
                foreach (ChartPoint p in s.Points)
                {
                    if (pointIndex > 0)
                        sb.Append(", ");
                    sb.AppendLine("                    {");
                    switch (s.ValueUse)
                    {
                        case ValueUse.UnitMoney:
                            sb.AppendLine("                      name: '$" + Tools.Number.MoneyFormat(p.Y) + "',");
                            break;
                        case ValueUse.TotalMoney:
                            sb.AppendLine("                      name: '$" + Tools.Number.LongFormat(p.Y) + "',");
                            break;
                        case ValueUse.Quantity:
                            sb.AppendLine("                      name: '" + Tools.Number.LongFormat(p.Y) + "',");
                            break;
                        default:
                            sb.AppendLine("                      name: '" + p.Caption.Replace("'", "") + "',");
                            break;
                    }

                    if( p.Color.ToArgb() != 0 )
                        sb.AppendLine("            color: '" + Tools.Html.GetHTMLColor(p.Color) + "',");
                    else
                        sb.AppendLine("            color: '" + ReportTargetHtml.SeriesColor(seriesIndex) + "',");
                    
                    sb.AppendLine("             	     y: " + p.Y.ToString() + ",");
                    sb.AppendLine("                      events: {");
                    sb.AppendLine("                          click: function() {");
                    if (Tools.Strings.StrExt(p.LineId))
                        sb.AppendLine("                                     RunReport(); " + actionSpot.ActionScript("'summary_line'", "'" + p.LineId + "'"));
                    sb.AppendLine("                                 }");
                    sb.AppendLine("                      }");
                    sb.AppendLine("                    }");
                    pointIndex++;
                }
                sb.Append("]");
                sb.AppendLine("        }");
                seriesIndex++;
            }
            sb.AppendLine("]");
            RenderChartEnd(sb, id);
        }
    }
    public class Chart
    {
        public String Title;
        public List<ChartSeries> Series;
        public List<String> XAxisLabels;

        public Chart(String title)
        {
            Title = title;
            Series = new List<ChartSeries>();
            XAxisLabels = new List<string>();
        }
        public int XAxisWidth
        {
            get
            {
                int ret = 0;
                foreach (String s in XAxisLabels)
                {
                    ret += s.Length;
                }
                return ret;
            }
        }
    }
    public class ChartSeries
    {
        public String Title;
        public List<ChartPoint> Points;
        public int SourceIndex = -1;
        public ValueUse ValueUse;
        public System.Drawing.Color Color = System.Drawing.Color.Black;

        public ChartSeries(String title)
            : this(title, -1, ValueUse.Any)
        {
        }
        public ChartSeries(String title, int sourceIndex, ValueUse use)
        {
            Title = title;
            SourceIndex = sourceIndex;
            Points = new List<ChartPoint>();
            ValueUse = use;
        }
        public String Uid
        {
            get
            {
                return Tools.Strings.FilterTrash(Title).ToLower();
            }
        }
    }
    public class ChartPoint
    {
        public String Caption;
        public Double X;
        public Double Y;
        public String LineId = "";
        public System.Drawing.Color Color;

        public ChartPoint(String caption, Double y, Color color)
            : this(caption, y)
        {
            Color = color;
        }
        public ChartPoint(String caption, Double y)
        {
            Caption = caption;
            X = 0;
            Y = y;
        }
    }
    public class AxisHandle
    {
        public ValueUse ValueUse;
        public int Index;
        public String Title;
        public AxisHandle(ValueUse use, int index, String title)
        {
            ValueUse = use;
            Index = index;
            Title = title;
        }
    }
    public enum ChartType
    {
        Bar,
        Pie
    }
}
