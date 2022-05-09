using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using RzWeb.Controls;
using Rz5;
using Core;
using CoreWeb.Controls;

namespace RzWeb.Screens
{
    public class ChartScreen : Screen
    {
        ChartControl Chart;

        public ChartScreen(Rz5.Report report)
        {
            Chart = (ChartControl)SpotAdd(new ChartControl());
            Chart.Init(report, ChartType.Bar);
        }
        public override String Title(Context x)
        {
            return "Charts";
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.Append(Chart.Select + ".css('top', $('#headerDiv').outerHeight(true));");
            sb.AppendLine("$('#headerDiv').css('width', $(window).width() - ($('#headerDiv').outerWidth(true) - $('#headerDiv').width() ));");
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            sb.AppendLine("<div id=\"headerDiv\" style=\"position: absolute; left: 0px; top: 0px; height: 50px; margin: 4px; padding: 2px; border: thin solid #CCCCCC\" class=\"ui-corner-all\">");
            sb.AppendLine(Chart.Report.Caption);
            sb.AppendLine("</div>");
        }
    }
}
