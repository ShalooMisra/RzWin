using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;

namespace CoreWeb
{
    public class CorePageScreen : CorePage
    {
        AsyncScreenHandle m_ScreenHandle = null;

        protected AsyncScreenHandle ScreenHandle
        {
            get
            {
                if (m_ScreenHandle != null)
                    return m_ScreenHandle;

                String sid = (String)Request["screenId"];
                if (Tools.Strings.StrExt(sid))
                    m_ScreenHandle = AsyncScreenHandle.ActiveHandleGet(sid);

                return m_ScreenHandle;
            }
        }

        Screen m_TheScreen;
        protected virtual Screen TheScreen
        {
            get
            {
                try
                {
                    if (m_TheScreen != null)
                        return m_TheScreen;

                    AsyncScreenHandle screenHandle = ScreenHandle;
                    if (screenHandle != null)
                        m_TheScreen = screenHandle.Screen;

                    if (m_TheScreen == null)
                    {
                        if( viewHandle != null )
                            m_TheScreen = viewHandle.TheScreen;
                    }

                    return m_TheScreen;
                }
                catch
                {
                    return null;
                }

            }
        }

        protected String viewId = Tools.Strings.GetNewID();  //uniquely identifies the actual browser tab
        ViewHandle m_viewHandle = null;
        protected ViewHandle viewHandle
        {
            get
            {
                if (m_viewHandle != null)
                    return m_viewHandle;
                
                String vid = (String)Request["v"];

                if (Tools.Strings.StrExt(vid))
                {
                    viewId = vid;
                    m_viewHandle = ViewHandle.WaitingHandleGet(viewId);
                }

                return m_viewHandle;
            }
        }
        
        protected virtual void LoadHandle()
        {
            String cid = Request["cid"];
            if (Tools.Strings.StrExt(cid))
            {
                TheScreen.RequestHandle((Context)Session["TheContext"], Request, Response, cid);
            }
            else
            {
                try
                {
                    ScriptsInclude();
                }
                catch { }
            }
        }

        public virtual String ScreenRender()
        {
            Context x = (Context)Session["TheContext"];
            if (x == null)
            {
                Response.Clear();
                Response.Redirect("/");
                Response.End();
                return "";
            }

            Context xx = x.Clone();
            xx.TheLeader = LeaderCreate(Session.SessionID, ScreenHandle);

            if (viewHandle == null)
                m_viewHandle = ViewHandleCreate();

            TheScreen.ViewAdd(xx, viewHandle);

            StringBuilder sb = new StringBuilder();
            TheScreen.Render(xx, sb, TheScreen, viewHandle, Session, this);

            viewHandle.InitialRender = false;

            //TheScreen.ChangeClear(xx);
            return sb.ToString();
        }

        protected LeaderWebUser LeaderCreate(String sessionId, AsyncScreenHandle screenHandle)
        {
            if (AsyncLinkPageBase.LeaderFactory == null)
                return new LeaderWebUser(Session, viewHandle, screenHandle);
            else
                return AsyncLinkPageBase.LeaderFactory(sessionId, Session, viewHandle, screenHandle);
        }

        protected virtual ViewHandle ViewHandleCreate()
        {
            return new ViewHandle(viewId, TheScreen, Session.SessionID);
        }

        public virtual String DefinitionsRender()
        {
            if (TheScreen == null)
                return "";

            StringBuilder sb = new StringBuilder();
            foreach (String s in viewHandle.Definitions)
            {
                sb.AppendLine(s);
            }
            viewHandle.Definitions.Clear();

            String tools = TheScreen.ScriptToolsRender(Page, viewHandle);
            if (tools != "")
                sb.AppendLine(tools);

            return sb.ToString();
        }

        //public String PageId()
        //{
        //    if (TheScreen == null)
        //        return "";

        //    return TheScreen.CurrentPageId;
        //}

        public String ScreenId()
        {
            if (TheScreen == null)
                return "";

            return TheScreen.Uid;
        }

        protected virtual void ScriptsInclude()
        {
            Page.ClientScript.RegisterClientScriptInclude("JQuery", "//ajax.googleapis.com/ajax/libs/jquery/1.7.0/jquery.min.js");
            Page.ClientScript.RegisterClientScriptInclude("JQuery.UI", JqPath + "/js/jquery-ui-1.8.7.custom.min.js");
            Page.ClientScript.RegisterClientScriptInclude("JQuery.DataTables", JqPath + "/DataTables/js/jquery.dataTables.js");
            Page.ClientScript.RegisterClientScriptInclude("JQuery.DataTables.SortingExtensions", JqPath + "/DataTables/js/DataTablesSortingExtensions.js");
            Page.ClientScript.RegisterClientScriptInclude("JQuery.UI.TimePicker", JqPath + "/jquery-ui-timepicker-addon.js");

            //Page.ClientScript.RegisterClientScriptInclude("JQuery.EventDrag", "Scripts/jquery.event.drag-1.4.js");
            //Page.ClientScript.RegisterClientScriptInclude("JQuery.ColResize", "Scripts/jquery.kiketable.colsizable-1.1.js");

            //colResizable-1.3.min.js
            Page.ClientScript.RegisterClientScriptInclude("Core.Actions", Page.ResolveClientUrl("~/Scripts") + "/Core.js?skipcache=" + SkipCache);
            Page.ClientScript.RegisterClientScriptInclude("Core.Resize", Page.ResolveClientUrl("~/Scripts") + "/CoreResize.js?skipcache=" + SkipCache);
            Page.ClientScript.RegisterClientScriptInclude("Core.Tables", Page.ResolveClientUrl("~/Scripts") + "/CoreTable.js?skipcache=" + SkipCache);
            Page.ClientScript.RegisterClientScriptInclude("Core.Menu", Page.ResolveClientUrl("~/Scripts") + "/CoreMenu.js?skipcache=" + SkipCache);
            
            //temporarily took this out; it causes a lot of javascript errors and makes other debugging difficult
            //Page.ClientScript.RegisterClientScriptInclude("jquery.zclip", Page.ResolveClientUrl("~/Scripts") + "/jquery.zclip.js");

            if (TheScreen != null)
                TheScreen.ClientScriptsInclude(Page);
        }

        public String ScriptsRender()
        {
            if (TheScreen == null)
                return "";

            StringBuilder sb = new StringBuilder();
            foreach (String s in viewHandle.ScriptsToRun)
            {
                //this is handled by the viewHandle.InitalRender flag
                //if (Tools.Strings.StrCmp(s, "DoResize();"))
                //{
                //    //skip;
                //}
                //else
                    sb.AppendLine(s);
            }

            sb.AppendLine("MenuInit();");

            viewHandle.ScriptsToRun.Clear();
            viewHandle.LastChangeCheck = DateTime.Now;
            //sb.AppendLine("viewId = '" + viewId + "';");
            return sb.ToString();
        }

        public String ResizeRender()
        {
            if (TheScreen == null)
                return "";
            StringBuilder sb = new StringBuilder();
            TheScreen.ResizeRenderAll(sb, this);
            sb.AppendLine("ResizeTables();");
            return sb.ToString();
        }

        public String SkipCache
        {
            get
            {
                return Tools.Dates.GetNowPathHMS() + "_" + DateTime.Now.Millisecond.ToString();
            }
        }

        protected virtual String ScriptInit()
        {
            return "viewId = \"" + viewId + "\";\r\nspotId = \"" + ScreenId() + "\";";
        }

        protected virtual String CssRender()
        {
            return TheScreen.CssRender();
        }

        public String SupportHtmlRender()
        {
            StringBuilder sb = new StringBuilder();//max-height: 300px;
            sb.AppendLine("    <div style=\"display: none; position: absolute; overflow: auto; width: 260px; padding: 2px; z-index: 0; background-color: #FFFFFF; border-style: solid; border-width: thin; border-color: #808080; " + GetCoreContextMenuDivFontSize() + "\"");//808080
            sb.AppendLine("    id=\"CoreContextMenuDiv\">");
            sb.AppendLine("        <table width=\"240px\" cellspacing=\"2\" cellpadding=\"2\" border=\"0\" id=\"CoreContextMenuDivTable\">");
            sb.AppendLine("            <tbody>");
            sb.AppendLine("            </tbody>");
            sb.AppendLine("        </table>");
            sb.AppendLine("    </div>");

            sb.AppendLine("    <div style=\"display: none; position: absolute; padding: 2px;\" id=\"CoreWaitingDiv\">");
            sb.AppendLine("    <img border=\"0\" alt=\"Waiting\" src=\"" + ResolveClientUrl("~/Jq/images/ui-anim_basic_16x16.gif") + "\"/>");
            sb.AppendLine("    </div>");

            sb.AppendLine(TheScreen.SupportHtmlRender());

            return sb.ToString();
        }
        public virtual string GetCoreContextMenuDivFontSize()
        {
            return "";
        }
        public String Title()
        {
            if (TheScreen == null)
                return "";

            return TheScreen.Title((Context)Session["TheContext"]);
        }

        public String FavIcon()
        {
            if (TheScreen == null)
                return "";

            return TheScreen.FavIcon;
        }
    }
}
