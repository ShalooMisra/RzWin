using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Tools
{
    public static class Charts
    {
        public static String PieRender(String caption, List<ChartPoint> points)
        {
            String file = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + @"Temp\";
            if (!Directory.Exists(file))
                Directory.CreateDirectory(file);

            file += "TempChart.htm";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<html>");
            sb.AppendLine("  <head>");
            sb.AppendLine("    <script type=\"text/javascript\" src=\"http://www.google.com/jsapi\"></script>");
            sb.AppendLine("    <script type=\"text/javascript\">");
            sb.AppendLine("      google.load(\"visualization\", \"1\", {packages:[\"corechart\"]});");
            sb.AppendLine("      google.setOnLoadCallback(drawChart);");
            sb.AppendLine("      function drawChart() {");
            sb.AppendLine("        var data = new google.visualization.DataTable();");
            sb.AppendLine("        data.addColumn('string', 'Company');");
            sb.AppendLine("        data.addColumn('number', 'Sales');");

            sb.AppendLine("        data.addRows(" + points.Count.ToString() + ");");

            int i = 0;
            foreach (ChartPoint p in points)
            {
                sb.AppendLine("        data.setCell(" + i.ToString() + ", 0, '" + p.Name.Replace("'", "").Replace("\"", "") + "');");
                sb.AppendLine("        data.setCell(" + i.ToString() + ", 1, " + Math.Round(p.Value, 0).ToString() + ", '$" + Tools.Number.LongFormat(p.Value) + "');");
                i++;
            }

            int height = 500;  // (50 * rOnTime.Points.Count);

            sb.AppendLine("        var chart = new google.visualization.PieChart(document.getElementById('chart_div'));");
            sb.AppendLine("        chart.draw(data, {width: 800, height: " + height + ", min: 0, title: '" + caption + "'});");  //, titleTextStyle: {color: '#5c5c5c', font: 'Calibri'}

            sb.AppendLine("        var bar_chart = new google.visualization.BarChart(document.getElementById('bar_chart_div'));");
            sb.AppendLine("        bar_chart.draw(data, {width: 800, height: " + height + ", min: 0, title: '" + caption + "'});");  //, titleTextStyle: {color: '#5c5c5c', font: 'Calibri'}

            sb.AppendLine("      }");
            sb.AppendLine("    </script>");
            sb.AppendLine("  </head>");

            sb.AppendLine("  <body>");
            sb.AppendLine("    <div id=\"chart_div\"></div><br><div id=\"bar_chart_div\"></div>");
            sb.AppendLine("  </body>");
            sb.AppendLine("</html>");

            Tools.Files.SaveFileAsString(file, sb.ToString());
            return file;
        }
    }

    public class ChartPoint
    {
        public String Name = "";
        public Double Value = 0;
    }
}
