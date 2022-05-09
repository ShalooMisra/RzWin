using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

using Core;
using CoreWeb;

namespace CoreWeb
{
    public class AsyncLinkPageBase : System.Web.UI.Page
    {
        protected virtual void LoadHandle()
        {
            Response.Clear();
            Response.ContentType = "application/json";

            String sessionId = "";
            try
            {                
                lock (RequestSessionIds)
                {
                    sessionId = RequestSessionIds[Request];
                }
            }
            catch { }

            if (sessionId == "")
                sessionId = Tools.Strings.GetNewID();

            try
            {
                //find the requesting screen
                String sid = Request["sid"];
                if (!Tools.Strings.StrExt(sid))
                {
                    Stop();
                    return;
                }

                //find the requesting view
                String vid = Request["vid"];
                if (!Tools.Strings.StrExt(vid))
                {
                    Stop();
                    return;
                }

                AsyncScreenHandle h = AsyncScreenHandle.ActiveHandleGet(sid);
                if (h == null)
                {
                    Stop();
                    return;
                }

                ViewHandle vh = h.Screen.ViewGet(vid);
                if (vh == null)
                {
                    Stop();
                    return;
                }

                //if (vh.Waiting) //then this view is already blocked in the async loop
                //{
                //    //release it
                //    vh.Flow();
                //}

                while (!vh.ChangesToSend)
                {
                    try
                    {
                        vh.Wait();
                    }
                    catch { }
                }

                Leader leader = LeaderCreate(sessionId, vh, h);  //session should already be different than the view session
                String responseText = GenerateResponse(Server, Page, Session, vh, h, sessionId, leader);

                Response.AddHeader("Content-Length", responseText.Length.ToString());
                Response.Write(responseText);

                if (Tools.Strings.StrExt(sessionId))
                    Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", sessionId));

                //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", h.Screen.SessionId));
            }
            catch {

            }
            Response.End();

            //Response.Write("{\"d\":[{\"id\":\"dialog\", \"url\":\"TestDialog.aspx\"}, {},{}]}");  
        }

        public static String GenerateResponse(HttpServerUtility server, System.Web.UI.Page page, System.Web.SessionState.HttpSessionState session, ViewHandle vh, AsyncScreenHandle h, String sessionId, Leader leader)
        {
            lock (vh.FilesToDownload)
            {
                foreach (String file in vh.FilesToDownload)
                {
                    vh.ScriptsToRun.Add(DownloadFileScript(server, page, file));
                }
                vh.FilesToDownload.Clear();
            }

            StringBuilder json = new StringBuilder();
            json.Append("{\"d\":[");
            int i = 0;

            List<Spot> changed = new List<Spot>();
            DateTime preStamp = DateTime.Now;
            h.Screen.ChangedSpots(changed, vh.LastChangeCheck);
            vh.LastChangeCheck = preStamp;

            while (changed.Count > 0)  //changes in 1 control can change others
            {
                lock (h.Screen.ChangeLock)
                {
                    foreach (Spot c in changed)
                    {
                        if (i > 0)
                            json.Append(", ");

                        String topCss = "";
                        if (!c.RelativeY)
                            topCss = ", {\"key\":\"top\", \"value\":\"" + c.Location.Y.ToString() + "px\"}";

                        String css = "[{\"key\":\"background-color\", \"value\":\"" + Tools.Html.GetHTMLColor(c.BackColor) + "\"}" + topCss + ", {\"key\":\"left\", \"value\":\"" + c.Location.X.ToString() + "px\"}]";

                        Context xx = h.TheContext.Clone();
                        xx.TheLeader = leader;

                        String definitionResult = "";
                        try
                        {
                            definitionResult = c.RenderDefinitionString(xx, page);
                        }
                        catch (Exception ex)
                        {
                            xx.TheLeader.Error(ex.Message);
                        }

                        String contentResult = "";
                        try
                        {
                            lock (c.ChangeLock)
                            {
                                contentResult = c.RenderContentsString(xx, h.Screen, vh, session, page);
                            }
                        }
                        catch (Exception ex)
                        {
                            xx.TheLeader.Error(ex.Message);
                        }

                        json.Append("{\"id\":\"refresh\", \"div\":\"" + c.DivId + "\", \"parentdiv\": \"" + c.DivIdParent + "\", \"definitionhtml\": \"" + EncodeForJson(definitionResult) + "\", \"html\":\"" + EncodeForJson(contentResult) + "\", \"css\":" + css + "}");
                        //c.Changed = false;
                        i++;
                    }
                }

                changed = new List<Spot>();
                preStamp = DateTime.Now;
                h.Screen.ChangedSpots(changed, vh.LastChangeCheck);
                vh.LastChangeCheck = preStamp;
            }

            lock (vh.ScriptsToRun)
            {
                foreach (String script in vh.ScriptsToRun)
                {
                    if (i > 0)
                        json.Append(", ");

                    json.Append("{\"id\":\"script\", \"src\":\"" + EncodeForJson(script) + "\"}");
                    i++;
                }
                vh.ScriptsToRun.Clear();
            }

            lock (vh.ElementsToReplace)
            {
                foreach (ElementReplace er in vh.ElementsToReplace)
                {
                    if (i > 0)
                        json.Append(", ");

                    json.Append("{\"id\":\"replace\", \"elementid\": \"" + er.Id + "\", \"html\":\"" + EncodeForJson(er.Content) + "\"}");
                    i++;
                }

                vh.ElementsToReplace.Clear();
            }

            lock (vh.ControlsToRemove)
            {
                foreach (String control in vh.ControlsToRemove)
                {
                    if (i > 0)
                        json.Append(", ");

                    json.Append("{\"id\":\"remove\", \"div\":\"" + control + "\"}");
                    i++;
                }

                vh.ControlsToRemove.Clear();
            }

            if (vh.Canceled)
            {
                if (i > 0)
                    json.Append(", ");

                json.Append("{\"id\":\"stop\"}");
                i++;
            }

            json.Append("]}");

            return json.ToString();
        }

        public static Dictionary<HttpRequest, String> RequestSessionIds = new Dictionary<HttpRequest, string>();

        //String EncodeForJson(String s)
        //{
        //    //if (s.Contains("\\"))
        //    //{
        //    //    ;
        //    //}

        //    return s.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("\r", "\\r").Replace("\n", "\\n");
        //}

        static String DownloadFileScript(HttpServerUtility server, System.Web.UI.Page page, String file)
        {
            if (!File.Exists(file))
                return "";

            String exportFolder = Tools.Folder.ConditionFolderName(server.MapPath("~/Exports"));
            if (!Directory.Exists(exportFolder))
                Directory.CreateDirectory(exportFolder);

            String fn = Path.GetFileName(file);
            String dest = exportFolder + fn;

            if (!Tools.Strings.StrCmp(file, dest))
            {
                if (File.Exists(dest))
                    File.Delete(dest);

                File.Copy(file, dest);
            }

            return("window.open('" + page.ResolveClientUrl("~/Exports/" + fn) + "');");
        }

        public static string EncodeForJson(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in s)
            {
                switch (c)
                {
                    case '\"':
                        sb.Append("\\\"");
                        break;
                    case '\\':
                        sb.Append("\\\\");
                        break;
                    case '\b':
                        sb.Append("\\b");
                        break;
                    case '\f':
                        sb.Append("\\f");
                        break;
                    case '\n':
                        sb.Append("\\n");
                        break;
                    case '\r':
                        sb.Append("\\r");
                        break;
                    case '\t':
                        sb.Append("\\t");
                        break;
                    default:
                        int i = (int)c;
                        if (i < 32 || i > 127)
                        {
                            sb.AppendFormat("\\u{0:X04}", i);
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                }
            }
            return sb.ToString();
        }

        void Stop()
        {
            Response.Write("{\"d\":[{\"id\":\"stop\"}]}");
            Response.End();
        }

        void NoOp()
        {
            Response.Write("{\"d\":[{\"id\":\"noop\"}]}");
            Response.End();
        }

        //changed from an override to this handler so that it can be set once and not have to be set here and in actionpagebase and anywhere else
        //i think this makes sense because there wouldn't ever be a reason to make a different leader here than in actionpagebase for the same project
        //this way it can be set once in Global.aspx.cs
        LeaderWebUser LeaderCreate(String sessionId, ViewHandle viewHandle, AsyncScreenHandle screenHandle)
        {
            if (LeaderFactory == null)
                return new LeaderWebUser(Session, viewHandle, screenHandle);
            else
                return LeaderFactory(sessionId, Session, viewHandle, screenHandle);
        }

        public static LeaderFactory LeaderFactory;
    }

    public delegate LeaderWebUser LeaderFactory(String sessionId, System.Web.SessionState.HttpSessionState session, ViewHandle viewHandle, AsyncScreenHandle screenHandle);

    public class AsyncScreenHandle
    {
        static Dictionary<String, AsyncScreenHandle> ActiveHandles = new Dictionary<string, AsyncScreenHandle>();

        public static AsyncScreenHandle ActiveHandleGet(String id)
        {
            lock (ActiveHandles)
            {
                if (!ActiveHandles.ContainsKey(id))
                    return null;

                return ActiveHandles[id];
            }
        }

        public static void ActiveHandleAdd(AsyncScreenHandle h)
        {
            lock (ActiveHandles)
            {
                if (ActiveHandles.ContainsKey(h.Screen.Uid))
                    ActiveHandles.Remove(h.Screen.Uid);

                ActiveHandles.Add(h.Screen.Uid, h);
            }
        }

        public static void ActiveHandleRemove(AsyncScreenHandle h)
        {
            lock (ActiveHandles)
            {
                ActiveHandles.Remove(h.Screen.Uid);
            }
        }

        public static List<AsyncScreenHandle> ActiveHandlesList()
        {
            List<AsyncScreenHandle> ret = new List<AsyncScreenHandle>();

            lock (ActiveHandles)
            {
                foreach (KeyValuePair<String, AsyncScreenHandle> k in ActiveHandles)
                {
                    ret.Add(k.Value);
                }
            }

            return ret;
        }

        public Context TheContext;
        public Screen Screen;
        public AsyncScreenHandle(Context x, Screen s)
        {
            TheContext = x;
            Screen = s;
        }
    }
}
