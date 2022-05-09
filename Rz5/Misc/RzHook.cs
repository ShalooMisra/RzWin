using System;
using System.Collections;
using System.Text;
using System.Threading;

using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;

using System.Net;
using System.Net.Sockets;
using System.Xml;

using NewMethod;
using Tie;
using System.Collections.Generic;

namespace Rz5
{
    public delegate void GenericMessageHandler(TieMessage m);

    public class RzHook : Hook
    {
        public ContextRz Context;

        public RzHook(ContextRz context)
        {
            Context = context;
        }
        
        public event HookMessageHandler MessageArrived;
        public List<String> MessageFilter = null;

        public override void GotMessage(TieMessage m)
        {
            if (MessageFilter != null)
            {
                if (!MessageFilter.Contains(m.FunctionName))
                    return;
            }

            //StartStatusRelay();
            try
            {
                switch (m.FunctionName)
                {
                    case "run_version_update":
                        RunVersionUpdate();
                        break;
                    case "object_lock_check":
                        CheckLocalObjectLock(m);
                        break;
                    case "object_lock":
                        ShowLockMessage(m);
                        break;
                    case "object_close_request":
                        HandleCloseRequest(m);
                        break;
                    case "object_force_close":
                        HandleForceClose(m);
                        break;
                    case "object_close_complete":
                        ItemCloseComplete();
                        break;
                    case "object_close_cancel":
                        ItemCloseCanceled();
                        break;
                    case "chat_list_response":
                        HandleChatResponse(m);
                        break;
                    case "chat":
                        HandleChatMessage(m);
                        break;
                    //case "user_activity":
                    //    //lock (ActivityMonitors.SyncRoot)
                    //    //{
                    //    if (!MonitorActivity)
                    //        return;
                    //    //}
                    //    HandleActivity(Context, m);
                    //    break;
                    case "please_check_notes":
                        HandleNoteCheck();
                        break;
                    case "please_check_focus":
                        HandleNoteCheck();
                        break;

                    //case "are_you_on":
                    //    SendIAmOnReply(Tools.Xml.ReadXmlProp(m.ContentNode, "asker"));
                    //    break;
                    //case "i_am_on":
                    //    HandleIAmOnReply(Tools.Xml.ReadXmlProp(m.ContentNode, "responder"));
                    //    break;
                    case "client_list_response_by_user":
                        HandleByUserResponse(m);
                        break;
                    default:

                        if (MessageArrived != null)
                            MessageArrived(m);

                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                Context.TheLeader.Comment("Error: " + ex.Message);
            }
            //StopStatusRelay();
        }

        public void CloseOtherInstances(String objectId)
        {
            TieMessage m = new TieMessage(SessionID, "object_force_close", "<all>");
            m.ContentString = Tools.Xml.BuildXmlProp("object_id", objectId) + Tools.Xml.BuildXmlProp("except_session", SessionID);
            SendAsync(m);
        }

        public virtual void ItemCloseComplete()
        {

        }
        public virtual void ItemCloseCanceled()
        {

        }
        public override void GotConnected()
        {
            HandleConnectionChange(true);
            base.GotConnected();
        }

        public override void GotDisconnected()
        {
            HandleConnectionChange(false);
            base.GotDisconnected();
        }

        protected virtual void HandleConnectionChange(bool connected)
        {

        }

        public virtual void HandleCloseRequest(TieMessage m)
        {
        }

        public virtual void HandleForceClose(TieMessage m)
        {
        }

        public void SuggestNoteCheck(String strUserID)
        {

            TieMessage m = new TieMessage("<UserID=" + UserID + ", MachineID=" + MachineID + ">", "please_check_notes", "<UserID=" + strUserID + ", MachineID=>");
            m.ContentString = "";
            Send(m);
        }

        public void SuggestFocusCheck(String strUserID)
        {

            TieMessage m = new TieMessage("<UserID=" + UserID + ", MachineID=" + MachineID + ">", "please_check_focus", "<UserID=" + strUserID + ", MachineID=>");
            m.ContentString = "";
            Send(m);
        }

        public virtual void HandleNoteCheck()
        {
        }

        public virtual void CheckLocalObjectLock(TieMessage m)
        {
        }

        public virtual void ShowLockMessage(TieMessage m)
        {
        }

        ArrayList OnlineHandlers = new ArrayList();
        public void IsUserOnline(IUserOnlineHandler h, String strUserID)
        {
            if (!IsConnected())
                return;

            lock (OnlineHandlers.SyncRoot)
            {
                if( !OnlineHandlers.Contains(h) )
                    OnlineHandlers.Add(h);
            }

            TieMessage m = new TieMessage("<UserID=" + UserID + ", MachineID=" + MachineID + ">", "client_list_request_by_user", "");
            m.ContentString = Tools.Xml.BuildXmlProp("user_id", strUserID);
            Send(m);
        }
        private void TellUserTemp(string s, ContextNM x)
        {
            if (x != null)
                x.TheLeader.TellTemp(s);
        }
        //void SendIAmOnReply(String strTo)
        //{
        //    TieMessage m = new TieMessage("<UserID=" + Rz3App.xHook.UserID + ", MachineID=" + Rz3App.xHook.MachineID + ">", "i_am_on", "<UserID=" + strTo + ", MachineID=>");
        //    m.ContentString = Tools.Xml.BuildXmlProp("responder", Rz3App.xHook.UserID);
        //    Send(m);
        //}

        delegate void UserOnlineHandler(ArrayList a);
        void HandleByUserResponse(TieMessage m)
        {
            ArrayList a = ParseClientList(m);
            ArrayList hold = null;
            lock (OnlineHandlers.SyncRoot)
            {
                hold = new ArrayList(OnlineHandlers);
            }

            foreach (IUserOnlineHandler h in hold)
            {
                h.Invoke(new UserOnlineHandler(h.ActuallyHandleUserIsOnline), new object[] { a });
            }
        }

        public void RemoveOnlineHandler(IUserOnlineHandler h)
        {
            lock (OnlineHandlers.SyncRoot)
            {
                OnlineHandlers.Remove(h);
            }
        }

        public virtual String GetCurrentStatus()
        {
            return "";
        }


        public virtual void RunVersionUpdate()
        {
        }

        public static String GetTieServerName(ContextNM context)
        {
            String strTieServer = context.xUser.GetSetting(context, "tie_server_name");

            if (!Tools.Strings.StrExt(strTieServer))
                strTieServer = context.xUser.GetSetting(context, "chat_server_ip");

            if (!Tools.Strings.StrExt(strTieServer))
                strTieServer = n_set.GetSetting(context, "tie_server_name");

            return strTieServer;
        }

        public bool UseChatSound = false;
        public String ChatSoundFile = "";

        public SortedList ChatSessions = new SortedList();
        public ChatSession GetSessionByID(String strID)
        {
            return (ChatSession)ChatSessions[strID];
        }

        public void InitSoundSettings(ContextRz context)
        {
            UseChatSound = n_set.GetSetting_Boolean(context, "use_chat_sound");
            ChatSoundFile = n_set.GetSetting(context, "chat_sound");
        }

        public ChatSession AddChatSession(ClientConnection c)
        {
            ChatSession s = ChatSessionCreate();
            s.UniqueID = c.UserID + "|" + c.MachineID;
            s.xClient = c;
            ChatSessions.Add(s.UniqueID, s);
            return s;
        }

        public virtual ChatSession ChatSessionCreate()
        {
            return new ChatSession();
        }

        public void RemoveChatSession(String strID)
        {
            try
            {
                ChatSessions.Remove(strID);
            }
            catch { }
        }

        public bool ShowChatListDetails = false;
        public virtual void HandleChatResponse(TieMessage m)
        {
        }

        //ArrayList CachedClientList = null;


        public ArrayList ActivityMonitors = new ArrayList();
        public bool MonitorActivity = false;

        //public void AddActivityMonitor(IActivityMonitor monitor)
        //{
        //    lock (ActivityMonitors.SyncRoot)
        //    {
        //        ActivityMonitors.Add(monitor);
        //        MonitorActivity = true;
        //    }
        //}

        //public void RemoveActivityMonitor(IActivityMonitor monitor)
        //{
        //    lock (ActivityMonitors.SyncRoot)
        //    {
        //        ActivityMonitors.Remove(monitor);
        //        MonitorActivity = (ActivityMonitors.Count > 0);
        //    }
        //}

        //public void HandleActivity(ContextNM x, TieMessage m)
        //{  
        //    user_activity a = user_activity.GetByIDAndUser(x, Tools.Xml.ReadXmlProp(m.ContentNode, "ActivityID"), Tools.Xml.ReadXmlProp(m.ContentNode, "ActivityUserID"));
        //    if( a == null )
        //        return;

        //    HandleActivity(a);
        //}

        //public void HandleActivity(user_activity a)
        //{
        //    try
        //    {

        //        ArrayList monitors = new ArrayList();
        //        lock (ActivityMonitors.SyncRoot)
        //        {
        //            foreach (IActivityMonitor m in ActivityMonitors)
        //            {
        //                monitors.Add(m);
        //            }
        //        }

        //        if (monitors.Count == 0)
        //            return;

        //        foreach (IActivityMonitor m in monitors)
        //        {
        //            try
        //            {
        //                m.Invoke(new ActivityMonitorHandler(m.ActuallyHandleActivity), new object[] { a });
        //            }
        //            catch { }
        //        }
        //    }
        //    catch { }
        //}

        //public void ReCacheClientList()
        //{
            
        //}

        public static ArrayList ParseChatList(TieMessage m)
        {
            XmlNodeList l = m.ContentNode.SelectNodes("chat_user");
            ArrayList a = new ArrayList();
            foreach (XmlNode n in l)
            {
                try
                {
                    String s = n.InnerText;
                    String[] ary = Tools.Strings.Split(s, "|");
                    ClientConnection c = new ClientConnection((XmlNode)null);
                    c.MachineName = ary[0];
                    c.UserName = ary[1];
                    c.MachineID = ary[2];
                    c.UserID = ary[3];
                    a.Add(c);
                }
                catch { }
            }
            return a;
        }

        public virtual void HandleChatMessage(TieMessage m)
        {
        }




        public void ShowStatus(ContextRz context)
        {
            context.Reorg();

            //if (RzApp.xMainForm == null)
            //    return;

            //RzTie.HookStatus s = new RzTie.HookStatus();
            //RzApp.xMainForm.TabShow(s, "Hook Monitor");
            //s.CompleteLoad(this);
            //PersistenceCheck();
        }
    }

    public class ChatSession
    {
        public String UniqueID = "";
        public ClientConnection xClient;
        public String TrackingId = Tools.Strings.GetNewID();

        public virtual void Show()
        {
        }

        public virtual void Add(TieMessage m)
        {
        }
    }




    public interface IUserOnlineHandler
    {
        void ActuallyHandleUserIsOnline(ArrayList a);
        object Invoke(Delegate method, params object[] args);
    }

    public delegate void HookMessageHandler(TieMessage m);
}
