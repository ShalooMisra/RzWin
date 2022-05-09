using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

using Core;
using CoreWeb;

namespace CoreWeb
{
    public class ActionPageBase : System.Web.UI.Page
    {
        Thread ActionThread;
        protected virtual void LoadHandle()
        {
            Response.Clear();
            Response.ContentType = "application/json";
            String sessionId = Session.SessionID;            
            String askId = Request["askId"];
            if (Tools.Strings.StrExt(askId))
            {
                AskResponseHandle(askId, Request, sessionId);
                return;
            }

            //find the requesting screen
            String screenId = Request["sid"];
            if (!Tools.Strings.StrExt(screenId))
            {
                Response.End();
                return;
            }

            AsyncScreenHandle h = AsyncScreenHandle.ActiveHandleGet(screenId);
            if (h == null)
            {
                Response.End();
                return;
            }            

            String spotId = Request["cid"];
            if (!Tools.Strings.StrExt(spotId))
            {
                Response.End();
                return;
            }

            Spot sh = h.Screen.SpotById(spotId);
            if (sh == null)
            {
                Response.End();
                return;
            }

            String vid = Request["vid"];
            if (!Tools.Strings.StrExt(vid))
            {
                Response.End();
                return;
            }

            ViewHandle vh = h.Screen.ViewGet(vid);
            if (vh == null)
            {
                Response.End();
                return;
            }

            SpotActArgs args = new SpotActArgs(Request, Page, vh);

            Context xx = h.TheContext.Clone();
            LeaderWebUser leader = AsyncLinkPageBase.LeaderFactory(sessionId, Session, vh, h);  //session should already be different than the view session
            leader.Request = Request;  //added 2012_02_26
            leader.ScreenHandle = h;   //added 2012_08_27 should already be part of the constructor
            leader.Page = Page;        //added 2013_03_27
            xx.TheLeader = leader;

            //this was showing the message on every single request
            //if (DidSessionTimeOut())
            //    xx.TheLeader.Tell("Your session has timed out. Please re-login.");

            leader.ActionReset = new ManualResetEvent(false);

            ActThreadHandle ath = new ActThreadHandle();
            ath.Context = xx;
            ath.ScreenHandle = h;
            ath.Spot = sh;
            ath.ViewHandle = vh;
            ath.Args = args;

            ActionThread = new Thread(new ParameterizedThreadStart(ActHandleAsync));
            ActionThread.SetApartmentState(ApartmentState.STA);
            ActionThread.Start(ath);

            leader.ActionReset.WaitOne();  //wait for the action to either finish or signal that it needs feedback

            //grab the actions and send them
            RespondAfterAction(leader, vh, h, sessionId);
        }
        private bool DidSessionTimeOut()
        {
            if (Session == null)
                return true;
            if (!Tools.Strings.StrExt(Session.SessionID))
                return true;
            if (Session["time_out"] == null)
                return true;
            if (!Tools.Strings.StrExt(Session["time_out"].ToString()))
                return true;
            return false;
        }
        void RespondAfterAction(LeaderWebUser leader, ViewHandle vh, AsyncScreenHandle h, String sessionId)
        {
            Response.Clear();
            Response.ContentType = "application/json";
            if (vh.ChangesToSend)
            {
                leader = AsyncLinkPageBase.LeaderFactory(sessionId, Session, vh, h);  //session should already be different than the view session
                String responseText = AsyncLinkPageBase.GenerateResponse(Server, Page, Session, vh, h, sessionId, leader);
                Response.AddHeader("Content-Length", responseText.Length.ToString());
                Response.Write(responseText);
            }
            else
            {
                Response.Write("{\"d\":[{\"id\":\"noop\"}]}");
            }

            try
            {
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", sessionId));
            }
            catch { }

            Response.End();
        }

        public static void ActHandleAsync(Object x)
        {
            ActThreadHandle ath = (ActThreadHandle)x;

            try
            {
                ath.Spot.Act(ath.Context, ath.Args);  //this is already async, just use the current thread
            }
            catch (Exception ex)
            {
                ath.Context.TheLeader.Error(ex.Message);
            }

            LeaderWebUser leader = (LeaderWebUser)ath.Context.Leader;
            leader.ActionReset.Set();
        }

        void AskResponseHandle(String askId, HttpRequest request, String sessionId)
        {
            if (!LeaderWebUser.WebThreads.ContainsKey(askId))
                return;
            WebThreadHandle h = null;
            lock (LeaderWebUser.WebThreads)
            {
                h = LeaderWebUser.WebThreads[askId];
                LeaderWebUser.WebThreads.Remove(askId);
            }

            //this was showing the message on every single request
            //if (DidSessionTimeOut())
            //    h.Leader.Tell("Your session has timed out. Please re-login.");

            h.Leader.ActionReset = new ManualResetEvent(false);

            h.TheRequest = request;
            h.TheEvent.Set();

            h.Leader.ActionReset.WaitOne();

            RespondAfterAction(h.Leader, h.Leader.TheViewHandle, h.Leader.ScreenHandle, sessionId);
        }

        //this is guaranteed now in the framework not to be null
        //protected virtual LeaderWebUser LeaderCreate(ViewHandle viewHandle)
        //{
        //    if (AsyncLinkPageBase.LeaderFactory == null)
        //        return new LeaderWebUser(Session, viewHandle);
        //    else
        //        return AsyncLinkPageBase.LeaderFactory(Session, viewHandle);
        //}
    }

    class ActThreadHandle
    {
        public Context Context;
        public AsyncScreenHandle ScreenHandle;
        public ViewHandle ViewHandle;
        public Spot Spot;
        public SpotActArgs Args;
    }
}
