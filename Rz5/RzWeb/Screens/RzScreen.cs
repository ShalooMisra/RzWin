using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;

using Core;
using CoreWeb;
using NewMethod;
using Rz5;
using Tools.Database;

namespace Rz5.Web
{
    public class RzScreen : Screen
    {
        public RzMenuSpot menu;

        public RzScreen(Context x)
        {
            menu = ((LeaderWebUserRz)x.Leader).MenuCreate((ContextRz)x, this);
            menu.LeftAbs = 0;
            menu.TopAbs = 0;
            menu.TheScreen = this;
            menu.ParentSpot = this;
            menu.RelativeY = false;
            Spots.Add(menu);
        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#rz_menu').css('width', $(window).width());");
        }
        protected String PlaceBelowMenu(Spot spot)
        {
            return spot.PlaceBelow("rz_menu", "rz_menu");
        }
        protected void PlaceDivBelowMenu(StringBuilder sb, String div)
        {
            sb.AppendLine("PlaceDivBelow('" + div + "', 'rz_menu');");
        }
        protected void PlaceDivBelowDiv(StringBuilder sb, String moveDiv, String targetDiv)
        {
            sb.AppendLine("PlaceDivBelow('" + moveDiv + "', '" + targetDiv + "');");
        }
        public ArrayList GetChoiceList(ContextRz x, string listname)
        {
            ArrayList a = new ArrayList();
            n_choices ch = n_choices.GetByName(x, listname);
            if (ch == null)
            {
                ch = n_choices.New(x);
                ch.name = listname;
                ch.Insert(x);
                if (x.xSys.AllChoices != null)
                    x.xSys.AllChoices.Add(ch);
            }
            ch.CacheChoiceList(x);
            foreach (n_choice c in ch.AllChoices)
            {
                a.Add(c.name);
            }
            return a;
        }
        public override void ClientScriptsInclude(System.Web.UI.Page page)
        {
            base.ClientScriptsInclude(page);
            page.ClientScript.RegisterClientScriptInclude("rzscript", "Scripts/Rz.js");
        }
    }
    public class RzMenuSpot : Spot
    {
        public RzScreen TheRzScreen
        {
            get
            {
                return (RzScreen)TheScreen;
            }
        }
        public RzMenuSpot(ContextRz context)
        {

        }
        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            base.ResizeRender(sb, page);
            sb.AppendLine("$('#refreshDiv').css('left', 4);");
            sb.AppendLine("$('#logOutDiv').css('left', $(window).width() - ($('#logOutDiv').width() + 4));");
        }
        public override void RenderContents(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            RenderMenu(x, sb, screenHandle, viewHandle, session, page);
        }
        protected virtual void RenderMenu(Context x, System.Text.StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, System.Web.SessionState.HttpSessionState session, System.Web.UI.Page page)
        {
            sb.AppendLine("<div id=\"rz_menu\" style=\"position:absolute; padding: 4px; border-bottom-width: thin; border-bottom-style: solid; border-bottom-color: #CCCCCC\">");
            sb.AppendLine("<div id=\"refreshDiv\" style=\"position: absolute; top: 4px; font-size: smaller\">");//Refresh
            sb.AppendLine("<input id=\"refresh_" + Uid + "\" style=\"font-size: xx-small;\" type=\"button\" value=\"\" onclick=\"" + ActionScript("'reload'") + "\" title=\"Refresh Page\"></div>");
            sb.AppendLine("<center>");
            RenderButtons((ContextRz)x, sb, viewHandle);
            sb.AppendLine("</center>");
            sb.AppendLine("<div id=\"logOutDiv\" style=\"position: absolute; top: 4px; font-size: smaller\">");
            sb.AppendLine("<font color=\"#C0C0C0\">" + ((ContextRz)x).xUserRz.name + "</font>&nbsp;&nbsp;");
            sb.AppendLine("<input id=\"logout_" + Uid + "\" style=\"font-size: xx-small; width: 50px;\" type=\"button\" value=\"Log Out\" onclientclick=\"window.location = 'Default.aspx'\" onclick=\"" + ActionScript("'logout'", "''") + "\">");
            if (((ContextRz)x).xUserRz.super_user)
                sb.AppendLine("<br><a href=\"#\" style=\"text-decoration: none; float: right; font-size: small; margin-top: 20px;\" onclick=\"" + ActionScript("'userpanel'", "''") + "\"><font color=\"#C0C0C0\">Control Panel</font></a></div>");
            sb.AppendLine("</div>");
            viewHandle.ScriptsToRun.Add("$('#refresh_" + Uid + "').css('width', 35).css('height', 30).css('background-image', \"url('Graphics/refresh16.png')\").css('background-repeat', 'no-repeat').css('background-position', 'center 5px').css('padding', '1px 1px 1px 1px').button();");//center 2
            viewHandle.ScriptsToRun.Add("$('#logout_" + Uid + "').button();");
            viewHandle.ScriptsToRun.Add("$(\".extra_button\").css('background-image', \"url('Graphics/ExtraButton.png')\").css('background-repeat', 'no-repeat').css('background-position', 'center 2px').css('padding', '1px 1px 1px 1px').button();");
        }
        protected virtual void RenderButtons(ContextRz xrz, StringBuilder sb, ViewHandle viewHandle)
        {
            ActSetup set = new ActSetup();
            xrz.TheSys.ActsListStatic(xrz, set);
            foreach (ActHandle h in set.Handles)
            {
                if (((LeaderWebUserRz)xrz.TheLeaderRz).IsApprovedMenuItem(xrz, h.Caption.ToLower()))
                {
                    if (Tools.Strings.StrCmp(h.Caption.ToLower(), "panel") && !IsMainAccount(xrz))
                        continue;
                    RenderButton(xrz, sb, viewHandle, h);
                }
            }
        }
        private bool IsMainAccount(ContextRz x)
        {
            if (Tools.Strings.StrCmp(x.TheData.DatabaseName, "RzRecognin"))
                return true;
            string id = x.GetSetting("rzweb_id");
            if (!Tools.Strings.StrExt(id))
                return false;
            DataConnectionSqlServer data = new DataConnectionSqlServer(x.TheData.ServerName, "RzRecognin", x.TheData.UserName, x.TheData.UserPassword);
            string email = data.ScalarString("select primaryemailaddress from company where unique_id = '" + id + "'");
            return Tools.Strings.StrCmp(x.xUserRz.login_name, email);
        }
        protected void RenderButton(ContextRz xrz, StringBuilder sb, ViewHandle viewHandle, ActHandle h)
        {
            sb.Append("<input id=\"menuButton" + h.Name.ToLower() + "\" type=\"button\" style=\"font-size: smaller\" onclick=\"" + ActionScript("'" + h.Name.ToLower() + "'", "''") + "\" value=\"" + h.Caption + "\">");
            Buttonize(viewHandle, "menuButton" + h.Name.ToLower(), h.Name.Replace("/", "").ToLower() + "menu.png");
            if (h.SubActs != null && h.SubActs.Count > 0)
            {
                sb.Append("</a><input type=\"button\" style=\"width: 20px; height: 20px; margin-top: -25px\" class=\"extra_button\" id=\"extra_" + h.Name + "\">&nbsp;&nbsp;&nbsp;&nbsp;");
                viewHandle.ScriptsToRun.Add("$(\"#extra_" + h.Name + "\").click(function () { var point = $(this).offset(); var datarray = [];  datarray.push({name: 'ids', value: '" + h.Name + "'});  MenuShowWithParameters('" + Uid + "', point.left, point.top, datarray); });");
            }
        }
        protected void RenderButton(Context x, StringBuilder sb, ViewHandle viewHandle, String buttonId, String actionId, String caption, String image)
        {
            sb.Append("<input id=\"menuButton" + buttonId + "\" type=\"button\" style=\"font-size: smaller\" onclick=\"" + ActionScript("'" + actionId + "'", "''") + "\" value=\"" + caption + "\">");
            Buttonize(viewHandle, "menuButton" + buttonId, image);
        }
        public override void ActsList(Context x, List<string> ids, List<ActHandle> acts, HttpRequest request)
        {
            base.ActsList(x, ids, acts, request);

            ActSetup set = new ActSetup();
            x.TheSys.ActsListStatic((ContextNM)x, set);
            foreach (ActHandle h in set.Handles)
            {
                if (h.Name == ids[0])
                {
                    List<ActHandle> a = FilterActsForWeb(x, h.Name, h.SubActs);
                    acts.AddRange(a);
                }
            }
        }
        private List<ActHandle> FilterActsForWeb(Context x, String name, List<ActHandle> h)
        {
            List<ActHandle> act = new List<ActHandle>();
            switch (name.ToLower().Trim())
            {
                case "home":
                    List<ActHandle> l = new List<ActHandle>();
                    l.Add(new ActHandle(new Act("New Order Batch", new ActHandler(BatchNewShow))));
                    return l;
                case "parts":
                    foreach (ActHandle a in h)
                    {
                        if (a is ActHandleSeparator)
                            continue;
                        switch (a.Name.ToLower().Trim())
                        {
                            case "multisearch":
                                break;
                            default:
                                if (!act.Contains(a))
                                    act.Add(a);
                                break;
                        }
                    }
                    break;
                case "panel":
                    if (((LeaderWebUserRz)((ContextRz)x).TheLeaderRz).DemoInfoCleared((ContextRz)x))
                        return new List<ActHandle>();
                    return h;
                default:
                    return h;
            }
            return act;
        }
        public override void Act(Context x, SpotActArgs args)
        {
            if (Tools.Strings.StrCmp(args.ActionId, "logout"))
            {
                args.SourceView.ScriptsToRun.Add("window.location = 'LogOut.aspx'");
                //args.SourceView.Flow();
                return;
            }
            if (Tools.Strings.StrCmp(args.ActionId, "reload"))
            {
                args.SourceView.ScriptsToRun.Add("window.location.reload();");
                //args.SourceView.Flow();
                return;
            }
            if (Tools.Strings.StrCmp(args.ActionId, "userpanel"))
            {
                ((ContextRz)x).TheSysRz.ThePanelLogic.PanelShow((ContextRz)x);
                return;
            }
            ActSetup set = new ActSetup();
            x.TheSys.ActsListStatic((ContextNM)x, set);
            foreach (ActHandle h in set.Handles)
            {
                if (ActCheck(x, args, h))
                    return;
            }
            base.Act(x, args);
        }
        bool ActCheck(Context x, SpotActArgs args, ActHandle h)
        {
            if (h.TheAct != null && h.Name != null && Tools.Strings.StrCmp(Tools.Strings.FilterTrash(args.ActionId), Tools.Strings.FilterTrash(h.Name)))
            {
                if (h.TheAct.Handler != null)
                {
                    h.TheAct.Handler(x, new ActArgs(x, h.Name));
                    return true;
                }
            }
            else
            {
                foreach (ActHandle hh in h.SubActs)
                {
                    if (ActCheck(x, args, hh))
                        return true;
                }
            }

            return false;
        }
        public void BatchNewShow(Context x, ActArgs args)
        {
            if (((ContextRz)x).CheckPermit("MainForm.mnuNewOrderTree_Click"))
            {
                dealheader d = dealheader.MakeManualDeal((ContextRz)x, null, null);
                x.Show(d);
                args.Result(true);
                return;
            }
            else
            {
                x.TheLeader.ShowNoRight();
                args.Result(false);
            }
        }
    }
}
