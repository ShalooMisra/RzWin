using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz5.Web;
using Rz5;
using Core;

namespace RzWeb.Screens
{
    public class StartScreen : RzScreen
    {
        public StartScreen(ContextRz context)
            : base(context)
        {

        }
        public override void RenderContents(Core.Context x, StringBuilder sb, CoreWeb.Screen screenHandle, CoreWeb.ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            sb.AppendLine("<div id=\"startDiv\" style=\"position: absolute\">");

                sb.AppendLine("<center><img src=\"Graphics/Start.png\"/><br/><font color=\"green\"><font style=\"font-size: larger\">Welcome to RzWeb.</font><br/>Below are some links to help you get started.</font></center><br />");

                sb.AppendLine("<div id=\"importPartsDiv\" style=\"height: 64px; width: 300px; border: thin solid #CCCCCC; margin: 4px; padding: 4px\" class=\"ui-corner-all\">");
                sb.AppendLine("<table border=\"0\"><tr><td><img style=\"cursor: pointer\" src=\"Graphics/ImportParts.png\" style=\"cursor: pointer\" onclick=\"" + ActionScript("'import_parts'", "''") + "\"/></td>");
                sb.AppendLine("<td><span><a href=\"#\" style=\"text-decoration: none; color: #6b6b6b; font-size: larger\" onclick=\"" + ActionScript("'import_parts'", "''") + "\">Click here to import a list of <b>stock, consignment, or excess</b></a></span></td></tr></table>");
                sb.AppendLine("</div>");

                sb.AppendLine("<br />");

                sb.AppendLine("<div id=\"importCompaniesDiv\" style=\"height: 64px; width: 300px; border: thin solid #CCCCCC; margin: 4px; padding: 4px\" class=\"ui-corner-all\">");
                sb.AppendLine("<table border=\"0\"><tr><td><img style=\"cursor: pointer\" src=\"Graphics/ImportCompanies.png\" style=\"cursor: pointer\" onclick=\"" + ActionScript("'import_companies'", "''") + "\"/></td>");
                sb.AppendLine("<td><span><a href=\"#\" style=\"text-decoration: none; color: #6b6b6b; font-size: larger\" onclick=\"" + ActionScript("'import_companies'", "''") + "\">Click here to import a list of <b>companies and contacts</b></a></span></td></tr></table>");
                sb.AppendLine("</div>");

            sb.AppendLine("</div>");

            sb.AppendLine("<div id=\"noShowDiv\" style=\"position: absolute; border: thin solid #CCCCCC; margin: 4px; padding: 4px; width: 190px;\" class=\"ui-corner-all\">");
            sb.AppendLine("<img src=\"Graphics/Cancel.png\" width=\"16px\" height=\"16px\" style=\"cursor: pointer\" onclick=\"" + ActionScript("'cancel'", "''") + "\"/>");
            sb.AppendLine("<font color=\"#CCCCCC\" size=\"x-small\"><a href=\"#\" style=\"text-decoration: none; color: #6b6b6b;\" onclick=\"" + ActionScript("'cancel'", "''") + "\">Don't&nbsp;show&nbsp;this&nbsp;at&nbsp;startup</a></font>");
            sb.AppendLine("</div>");
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            PlaceDivBelowMenu(sb, "startDiv");
            PlaceDivCenterX(sb, "startDiv");

            PlaceDivAtBottom(sb, "noShowDiv");
            PlaceDivRightEdge(sb, "noShowDiv");
        }
        public override void Act(Core.Context x, CoreWeb.SpotActArgs args)
        {
            ContextRz xrz = (ContextRz)x;

            switch (args.ActionId)
            {
                case "import_parts":
                    xrz.Leader.ImportShow(xrz);
                    break;
                case "import_companies":
                    xrz.Leader.ImportCompanies(xrz, new Core.ActArgs());
                    break;
                case "cancel":
                    xrz.xUser.SetSetting_Boolean(xrz, "no_start_screen", true);
                    xrz.TheLeaderRz.PartSearchShow(xrz, new Core.ActArgs());
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
        public override string Title(Context x)
        {
            return "RzWeb Start";
        }
    }
}
