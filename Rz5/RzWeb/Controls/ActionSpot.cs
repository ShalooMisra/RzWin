using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using System.Web.UI;

namespace Rz5.Web
{
    public class ActionSpot : Spot
    {
        public ActSetup TheSetup;
        private ContextRz TheContext;
        private nObject TheItem;

        public ActionSpot(ContextRz x, nObject i)
        {
            TheContext = x;
            TheItem = i;
        }
        public override string InnerDivId
        {
            get
            {
                return "xActions_" + Uid;
            }
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);//border: thin solid #C0C0C0
            sb.AppendLine("        <div id=\"" + InnerDivId + "\" style=\"border-style: solid; border-color: #C0C0C0; border-width: thin; width: 161px; overflow: hidden; font-size: large;\">");
            sb.AppendLine("            <div id=\"mnuOptions_" + Uid + "\" style=\"border-style: none none solid none; border-width: thin; border-color: #C0C0C0; \">");
            //passes all of the actions up to the _Item screen
            sb.AppendLine("                    <a href=\"#\" onclick=\"ItemSave(false)\"><img style=\"padding: 4px;\" alt=\"save\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_save.jpg") + "\"/></a>");
            sb.AppendLine("                    <a href=\"#\" onclick=\"ItemSave(true)\"><img style=\"padding: 4px;\" alt=\"save\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_saveexit.jpg") + "\"/></a>");
            //sb.AppendLine("                    <a href=\"#\" onclick=\"Action('" + TheScreen.Uid + "', '" + TheScreen.Uid + "', 'note', 'n')\"><img style=\"padding: 4px;\" alt=\"save\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_notes.jpg") + "\"/></a>");
            sb.AppendLine("            </div>");
            sb.AppendLine("            <div id=\"mnuActions_" + Uid + "\" style=\"overflow: scroll;\">");
            sb.AppendLine("                <table border=\"0\" width=\"100%\" cellspacing=\"0\">");
            sb.AppendLine(WriteActions(page));
            sb.AppendLine("                </table>");
            sb.AppendLine("            </div>");
            if (TheContext.xUserRz.super_user || TheContext.xUserRz.IsDeveloper())
            {
                sb.AppendLine("            <div id=\"buttonDelete_" + Uid + "\" style=\"position: absolute;\">");
                sb.AppendLine("               <input type=\"button\" id=\"deleteButton\" value=\"Delete\" style=\"font-size: x-small; width: 161px;\" onclick=\"" + ActionScript("'delete'") + "\">");
                Buttonize(viewHandle, "deleteButton", "Cancel.png");
                sb.AppendLine("            </div>");
            }
            sb.AppendLine("        </div>");
        }
        protected override void ResizeRender(StringBuilder sb, Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#buttonDelete_" + Uid + "').css('top', $('#" + InnerDivId + "').height() - $('#buttonDelete_" + Uid + "').height());");
            if (TheContext.xUserRz.super_user || TheContext.xUserRz.IsDeveloper())
                sb.AppendLine("$('#mnuActions_" + Uid + "').css('height', $('#buttonDelete_" + Uid + "').position().top - $('#mnuActions_" + Uid + "').position().top);");
            else
                sb.AppendLine("$('#mnuActions_" + Uid + "').css('height', $('#" + InnerDivId + "').height() - $('#mnuActions_" + Uid + "').position().top);");
        }
        private string WriteActions(System.Web.UI.Page page)
        {
            ActSetup actSetup = new ActSetup(TheItem);
            if (TheSetup != null)
                actSetup = TheSetup;
            if (actSetup.TheItems == null)
            {
                actSetup.TheItems = new ItemsInstance();
                actSetup.TheItems.Add(TheContext, TheItem);
            }
            if(actSetup.Handles.Count <=0)
                TheContext.TheSys.ActsListInstance(TheContext, actSetup); 
            StringBuilder sb = new StringBuilder();
            actSetup.Handles = ((Rz5.Web.LeaderWebUserRz)TheContext.TheLeaderRz).FilterActsForWeb(TheContext, actSetup.Handles, TheItem);
            foreach (ActHandle a in actSetup.Handles)
            {
                if (Tools.Strings.StrCmp(a.Name, "delete"))
                    continue;
                if (a is ActHandleSeparator)
                {
                    sb.AppendLine("<tr><td width=\"100%\" colspan=\"2\"><hr></td></tr>");
                    continue;
                }
                sb.AppendLine("                  <tr>");
                sb.AppendLine("                    <td width=\"3%\"><img alt=\"link\" border=\"0\" src=\"" + page.ResolveClientUrl("~/Graphics/action_link.jpg") + "\" width=\"15\" height=\"15\"></td>");
                sb.AppendLine("                    <td width=\"97%\"><font size=\"2\" face=\"Calibri\" color=\"#0000FF\"><b><a href=\"#\" onclick=\"" + ActionScript("'ExecuteAction'", "'" + a.Name + "'") + "\">" + a.Caption + "</a></b></font></td>");
                sb.AppendLine("                  </tr>");
            }
            return sb.ToString();
        }
        public override void Act(Context x, SpotActArgs args)
        {
            switch (args.ActionId.ToLower())
            {
                case "delete":
                    if (x.Leader.AreYouSure("delete " + TheItem.ToString()))
                    {
                        x.Delete(TheItem);
                        args.SourceView.ScriptsToRun.Add("window.close();");                    
                    }
                    break;
                case "executeaction":
                    ActArgs a = new ActArgs();
                    a.TheContext = x;
                    a.TheItems = new ItemsInstance(x, TheItem);
                    a.Name = args.ActionParams;
                    TheItem.HandleAction(a);
                    if (!a.Handled)
                    {
                        Context xx = x.Clone();
                        String cid = xx.TheDelta.StartChangeCache();
                        a.TheContext = xx;
                        x.TheSys.ActInstanceBeforeAfter(xx, a);
                        xx.TheDelta.EndChangeCache(x, cid);
                    }
                    break;
                default:
                    base.Act(x, args);
                    break;
            }
        }
    }
}
