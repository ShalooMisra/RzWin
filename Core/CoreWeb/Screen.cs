using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Core;
using System.Web.SessionState;

namespace CoreWeb
{
    public class Screen : Spot
    {
        public const int LayoutTheta = 4;
        Dictionary<String, ViewHandle> Views = new Dictionary<String, ViewHandle>();

        public virtual void ViewAdd(Context x, ViewHandle h)
        {
            lock (Views)
            {
                Views.Add(h.Uid, h);
            }

            ViewsChanged();
        }

        public ViewHandle ViewGet(String id)
        {
            lock (Views)
            {
                if (!Views.ContainsKey(id))
                    return null;

                return Views[id];
            }
        }

        public List<ViewHandle> ViewsList()
        {
            List<ViewHandle> ret = new List<ViewHandle>();
            lock (Views)
            {
                foreach (KeyValuePair<String, ViewHandle> k in Views)
                {
                    ret.Add(k.Value);
                }
            }
            return ret;
        }

        public void ViewRemove(ViewHandle v)
        {
            lock (Views)
            {
                Views.Remove(v.Uid);
            }
        }

        public bool Shared = false;
        public List<String> SharedWith = new List<string>();
        //public bool AllowBrowserScroll = false;

        public Screen()
        {
            HideOverflow = false;
            TheScreen = this;
            WidthAbs = 100;
            HeightAbs = 100;
        }
      
        //public void Flow()
        //{
        //    lock (Views)
        //    {
        //        foreach (ViewHandle h in ViewsList())
        //        {
        //            h.Flow();
        //        }
        //    }
        //}

        //public void FlowIfChanged()
        //{
        //    lock (Views)
        //    {
        //        foreach (ViewHandle h in ViewsList())
        //        {
        //            if (h.ChangesToSend)
        //                h.Flow();
        //        }
        //    }
        //}

        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            sb.AppendLine("                    $('#" + Spot.DivIdConvert(Uid) + "').css('width', $(window).width());");  // - 10

            //if( AllowBrowserScroll )
                sb.AppendLine("                    $('#" + Spot.DivIdConvert(Uid) + "').css('height', $(window).height());");  // seems to bottom out just below the actual bottom, triggering the scrollbars  - 10

            base.ResizeRender(sb, page);
        }

        //size testing
        //public override string BorderRender()
        //{
        //    return "border-style: solid; border-color: Blue; border-width: thick";
        //}

        public override string PositionRender()
        {
            //return base.PositionRender();
            return "position: absolute; left: 0px; top: 0px; overflow: hidden";
        }

        public virtual String ScriptToolsRender(System.Web.UI.Page page, ViewHandle viewHandle)
        {
            return "";
        }

        //public List<String> CurrentClientList = new List<String>();
        //public void ClientsCheck()
        //{
        //    List<String> previousList = new List<String>();
        //    List<String> currentList = new List<String>();

        //    lock (CurrentClientList)
        //    {
        //        foreach (String c in CurrentClientList)
        //        {
        //            previousList.Add(c);
        //        }

        //        CurrentClientList.Clear();

        //        lock (Views)
        //        {
        //            foreach (ManualResetHandle h in Views)
        //            {
        //                if (!CurrentClientList.Contains(h.SessionId))
        //                {
        //                    CurrentClientList.Add(h.SessionId);
        //                    currentList.Add(h.SessionId);
        //                }
        //            }
        //        }
        //    }

        //    foreach (String c in currentList)
        //    {
        //        if (!previousList.Contains(c))
        //        {
        //            ViewsChanged();
        //            return;
        //        }

        //        previousList.Remove(c);
        //    }

        //    if( previousList.Count > 0 )
        //        ViewsChanged();
        //}

        protected virtual void ViewsChanged()
        {

        }

        public virtual void ClientScriptsInclude(System.Web.UI.Page page)
        {
        }

        public virtual Spot SpotAdd(Spot s)
        {
            Spots.Add(s);
            s.ParentSpot = this;
            s.TheScreen = this;
            return s;
        }

        public void Redirect(Context context, ViewHandle vh, Screen screen)
        {
            AsyncScreenHandle.ActiveHandleAdd(new AsyncScreenHandle(context, screen));
            vh.ScriptsToRun.Add("Redirect('View.aspx?screenId=" + screen.Uid + "');");
        }

        public virtual String CssRender()
        {
            return "";
        }

        public virtual void RequestHandle(Context x, System.Web.HttpRequest request, System.Web.HttpResponse response, String cid)
        {
            Spot s = SpotFindRecurse(cid);
            if (s != null)
                s.RequestHandle(x, request, response);
        }

        public virtual String Title(Context x)
        {
            return "";
        }

        public String FavIcon
        {
            get
            {
                return "<link rel=\"icon\" type=\"image/png\" href=\"Graphics/" + FavIconFile + "\">";
            }
        }

        protected virtual String FavIconFile
        {
            get
            {
                return "";
            }
        }

        public void CloseWindows()
        {
            foreach (ViewHandle v in ViewsList())
            {
                v.ScriptsToRun.Add("window.close();");
                //v.Flow();
            }
        }

        public virtual String SupportHtmlRender()
        {
            return "";
        }
    }

    public class DialogScreen : Screen
    {
        public ViewHandle ParentView;
        public WebThreadHandleDialog ThreadHandle;

        public DialogScreen()
        {
        }

        public override string PositionRender()
        {
            //return base.PositionRender();
            return "";
        }

        protected override void ResizeRender(StringBuilder sb, System.Web.UI.Page page)
        {
            //base.ResizeRender(sb, page);
        }

        public virtual String AfterHtml
        {
            get
            {
                return "";
            }
        }

        protected virtual int DialogHeight
        {
            get
            {
                return 200;
            }
        }

        protected virtual int DialogWidth
        {
            get
            {
                return 200;
            }
        }

        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("<script type=\"text/javascript\">");
            sb.AppendLine("$('#dialog_div').dialog({ height: " + DialogHeight.ToString() + ", width: " + DialogWidth.ToString() + " }); ");
            sb.Append("</script>");
        }
    }

    public class ElementReplace
    {
        public String Id;
        public String Content;

        public ElementReplace(String id, String content)
        {
            Id = id;
            Content = content;
        }
    }

    public class ViewHandle
    {
        static Dictionary<String, ViewHandle> WaitingHandles = new Dictionary<string, ViewHandle>();
        public static String WaitingHandleAdd(ViewHandle h)
        {
            lock (WaitingHandles)
            {
                WaitingHandles.Add(h.Uid, h);
                return h.Uid;
            }
        }

        public static ViewHandle WaitingHandleGet(String id)
        {
            lock (WaitingHandles)
            {
                if (!WaitingHandles.ContainsKey(id))
                    return null;

                ViewHandle ret = WaitingHandles[id];
                WaitingHandles.Remove(id);
                return ret;
            }
        }

        public String Uid;
        public Screen TheScreen;
        public String SessionId;        
        ManualResetEvent TheEvent;

        public List<String> ControlsToRemove = new List<string>();
        public List<String> ScriptsToRun = new List<String>();
        public List<ElementReplace> ElementsToReplace = new List<ElementReplace>();
        public List<String> Definitions = new List<String>();
        public List<String> FilesToDownload = new List<String>();

        public DateTime LastChangeCheck = Tools.Dates.NullDate;
        public bool InitialRender = true;

        public ViewHandle(String viewId, Screen screen, String sessionId)
        {
            Uid = viewId;
            TheScreen = screen;
            SessionId = sessionId;
            TheEvent = new ManualResetEvent(false);
        }

        public virtual bool ChangesToSend
        {
            get
            {
                return TheScreen.ChangeDate > LastChangeCheck  || TheScreen.ContainsChangesDate > LastChangeCheck || ControlsToRemove.Count > 0 || ScriptsToRun.Count > 0 || ElementsToReplace.Count > 0 || FilesToDownload.Count > 0;
            }
        }

        public bool Waiting = false;

        //public void Flow()
        //{
        //    //Waiting = false;
        //    //TheEvent.Set();            
        //}

        public void Wait()
        {
            Waiting = true;
            TheEvent.Reset();
            TheEvent.WaitOne();
        }

        public bool Canceled = false;
        public void Cancel()
        {
            Canceled = true;
            //Flow();
        }

        public void Redirect(String url)
        {
            ScriptsToRun.Add("Redirect('" + url + "');");
            Cancel();
        }
    }

    public class DialogTest : DialogScreen
    {
        public override void RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, HttpSessionState session, System.Web.UI.Page page)
        {
            base.RenderContents(x, sb, screenHandle, viewHandle, session, page);
            sb.Append("Modal dialog test: <a href=\"javascript:void();\" onclick=\"" + ActionScript("'dialog_test'", "''") + "\">click here</a><br /><br /><a href=\"javascript:void();\" onclick=\"" + ActionScript("'dialog_test'", "''") + "\">click here</a>");
        }

        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);

            switch (args.ActionId)
            {
                case "dialog_test":
                    x.Leader.Tell("Test succeeded");
                    return;
            }
        }
    }

    public class OKCancel : DialogScreen
    {
        public OKCancel()
        {

        }

        public override void  RenderContents(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, HttpSessionState session, System.Web.UI.Page page)
        {
 	        base.RenderContents(x, sb, screenHandle, viewHandle, session, page);

            RenderBody(x, sb, screenHandle, viewHandle, session, page);

            sb.Append("<br><br><input id=\"cancel_" + Uid + "\" type=\"button\" value=\"Cancel\" onclick=\"" + ActionScriptPlusControls("'cancel'", "''") + "\">&nbsp;&nbsp;&nbsp;&nbsp;<input id=\"ok_" + Uid + "\" type=\"button\" value=\"OK\" onclick=\"$('#ok_" + Uid + "').hide(); $('#cancel_" + Uid + "').hide(); $('#spin_" + Uid + "').show();" + ActionScriptPlusControls("'ok'", "''") + "\">");
            sb.Append("<div id=\"spin_" + Uid + "\" style=\"padding: 4px; display: none;\"><img border=\"0\" src=\"Jq/images/ui-anim_basic_16x16.gif\"/></div>");
            sb.Append("<script type=\"text/javascript\">");
                        
            sb.Append("buttonize('ok_" + Uid + "', 'greencheck.png'); buttonize('cancel_" + Uid + "', 'redxmid.png');");
            //sb.AppendLine("$('#dialog_div').dialog({ height: " + DialogHeight.ToString() + ", width: " + DialogWidth.ToString() + " }); ");

            sb.Append("</script>");
            //$('#" + id + "').focus().select();
        }

        protected String ClickOKScript()
        {
            return "$('#ok_" + Uid + "').click();";
        }

        protected String ResetScript
        {
            get
            {
                return "$('#ok_" + Uid + "').show(); $('#cancel_" + Uid + "').show(); $('#spin_" + Uid + "').hide();";
            }
        }

        public virtual void RenderBody(Context x, StringBuilder sb, Screen screenHandle, ViewHandle viewHandle, HttpSessionState session, System.Web.UI.Page page)
        {

        }

        public override void Act(Context x, SpotActArgs args)
        {
            base.Act(x, args);
            switch (args.ActionId)
            {
                case "ok":
                    OK(x, args);
                    break;
                case "cancel":
                    Cancel(x, args);
                    break;
            }
        }

        protected virtual void OK(Context x, SpotActArgs args)
        {
            foreach(ViewHandle v in ViewsList())
            {
                v.ScriptsToRun.Add("Reply('" + ThreadHandle.Uid + "', [{name: 'result', value: ''}]);");
            }
        }

        protected virtual void Cancel(Context x, SpotActArgs args)
        {
            foreach(ViewHandle v in ViewsList())
            {
                v.ScriptsToRun.Add("Reply('" + ThreadHandle.Uid + "', [{name: 'result', value: ''}]);");
            }
        }
    }
}
