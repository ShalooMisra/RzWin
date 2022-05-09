using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rz5.Web;
using Rz5;
using System.Web;
using Core;

namespace RzWeb.Screens
{
    public class NagScreen : RzScreen
    {
        bool CompletelyDisable;
        String Message;

        public NagScreen(ContextRz context, bool completelyDisable, String message)
            : base(context)
        {
            CompletelyDisable = completelyDisable;
            Message = message;
            if (completelyDisable)
                Spots.Remove(menu);
        }
        public override String Title(Context x)
        {
            return "Expiration Alert";
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);

            if (!CompletelyDisable)
                PlaceDivBelowMenu(sb, "reminderDiv");
            else
                sb.AppendLine("$('#reminderDiv').css('top', 150);");
            PlaceDivCenterX(sb, "reminderDiv");
        }
        public override void RenderContents(Core.Context x, StringBuilder sb, CoreWeb.Screen screenHandle, CoreWeb.ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            sb.AppendLine("<div id=\"reminderDiv\" class=\"ui-corner-all\" style=\"position: absolute; border: thin solid #CCCCCC; margin: 10px; padding: 8px;\"><center>");
            sb.Append("<font color=\"red\"><span style=\"font-size: larger\">RzWeb Expiration Alert</span><br />" + HttpUtility.HtmlEncode(Message) + "</font>");
            sb.AppendLine("<br /><br /><input id=\"manageButton\" type=\"button\" value=\"RzWeb Account Management\" onclick=\"" + ActionScript("'manage_account'", "''") + "\" />");
            sb.AppendLine("</center></div>");
        }
        public override void Act(Core.Context x, CoreWeb.SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "manage_account":
                    RzWebApp.ManageRzWebAccount((ContextRz)x);
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
    }
}
