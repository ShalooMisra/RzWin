using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Drawing;

using Tie;
using NewMethod;
using Rz5;

namespace Rz5.Win
{
    public class RzHookWin : RzHook
    {
        public RzHookWin(ContextRz context)
            : base(context)
        {

        }                        

        public frmPhoneFaxMonitor xFaxForm = null;

        public override void GotMessage(TieMessage m)
        {
            //StartStatusRelay();
            try
            {
                switch (m.FunctionName)
                {
                    case "req_send":
                    case "quote_send":
                    case "remove_req":
                        HandlePrismMessage(m);
                        break;
                    case "fax_request":
                        if (xFaxForm == null)
                            return;
                        xFaxForm.FaxByID(Tools.Xml.ReadXmlProp(m.ContentNode, "fax_id"));
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch
            {
            }
        }

        public override void HandleChatResponse(TieMessage m)
        {
            if (RzWin.Form == null)  //received during startup
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyHandleChatResponse), new object[] { m });
            else
                ActuallyHandleChatResponse(m);
        }

        //ArrayList CachedClientList = null;
        public void ActuallyHandleChatResponse(TieMessage m)
        {
            ArrayList a = ParseChatList(m);

            if (ShowChatListDetails)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("User Name,User ID,Machine Name,Machine ID");
                foreach (ClientConnection c in a)
                {
                    sb.AppendLine(c.UserName + "," + c.UserID + "," + c.MachineName + "," + c.MachineID);
                }
                Tools.FileSystem.PopText(sb.ToString());
                ShowChatListDetails = false;
            }
            else
            {
                //CachedClientList = new ArrayList(a);
                frmNewChatSession xForm = RzWin.Leader.GetNewChatSessionForm();
                xForm.CompleteLoad(a, this);
                xForm.Show();
            }
        }

        public override void ShowLockMessage(TieMessage m)
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.SuppressOpenWarnings)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyShowLockMessage), new object[] { m });
            else
                ActuallyShowLockMessage(m);
        }
        public void ActuallyShowLockMessage(TieMessage m)
        {
            frmObjectLock xForm = new frmObjectLock();

            xForm.ObjectCaption = Tools.Xml.ReadXmlProp(m.ContentNode, "object_caption");
            xForm.ItemHasFocus = Tools.Xml.ReadXmlProp_Boolean(m.ContentNode, "lock_status");
            xForm.MachineName = Tools.Xml.ReadXmlProp(m.ContentNode, "lock_machine");
            xForm.UserName = Tools.Xml.ReadXmlProp(m.ContentNode, "lock_user");
            xForm.SessionID = Tools.Xml.ReadXmlProp(m.ContentNode, "lock_session");
            xForm.ObjectID = Tools.Xml.ReadXmlProp(m.ContentNode, "object_id");

            xForm.CompleteLoad();
            xForm.Show();
            xForm.BringToFront();
        }


        public override void CheckLocalObjectLock(TieMessage m)
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyCheckLocalObjectLock), new object[] { m });
            else
                ActuallyCheckLocalObjectLock(m);
        }

        public void ActuallyCheckLocalObjectLock(TieMessage m)
        {
            String strRequester = Tools.Xml.ReadXmlProp(m.ContentNode, "requesting_session");
            if (strRequester == this.SessionID)
                return;

            String strID = Tools.Xml.ReadXmlProp(m.ContentNode, "object_id");
            bool focus = false;

            if (RzWin.Form.IsObjectOpen(strID, ref focus))
            {

                String strFriendlyName = Tools.Xml.ReadXmlProp(m.ContentNode, "object_caption");

                TieMessage mr = new TieMessage(this.SessionID, "object_lock", strRequester);
                mr.ContentString = Tools.Xml.BuildXmlProp("object_caption", strFriendlyName) + Tools.Xml.BuildXmlProp("lock_status", focus) + Tools.Xml.BuildXmlProp("lock_machine", Environment.MachineName) + Tools.Xml.BuildXmlProp("lock_user", RzWin.User.name) + Tools.Xml.BuildXmlProp("lock_session", SessionID) + Tools.Xml.BuildXmlProp("object_id", strID);
                Send(mr);
                SetStatus("Notified session " + strRequester + " of object lock on " + strFriendlyName + " [" + strID + "]");
            }
        }

        public override void HandleCloseRequest(TieMessage m)
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyHandleCloseRequest), new object[] { m });
            else
                ActuallyHandleCloseRequest(m);
        }

        public void ActuallyHandleCloseRequest(TieMessage m)
        {
            String strID = Tools.Xml.ReadXmlProp(m.ContentNode, "object_id");
            String strCaption = Tools.Xml.ReadXmlProp(m.ContentNode, "object_caption");
            String strRequestSession = Tools.Xml.ReadXmlProp(m.ContentNode, "requesting_session");
            String strRequestUser = Tools.Xml.ReadXmlProp(m.ContentNode, "requesting_user");
            String strRequestMachine = Tools.Xml.ReadXmlProp(m.ContentNode, "requesting_machine");

            TieMessage reply = new TieMessage(SessionID, "", strRequestSession);

            RzWin.Form.TabCloseByID(strID);
            reply.FunctionName = "object_close_complete";

            Send(reply);
        }

        public override void HandleForceClose(TieMessage m)
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyHandleForceClose), new object[] { m });
            else
                ActuallyHandleForceClose(m);
        }

        public void ActuallyHandleForceClose(TieMessage m)
        {
            String objectId = Tools.Xml.ReadXmlProp(m.ContentNode, "object_id");
            String exceptSession = Tools.Xml.ReadXmlProp(m.ContentNode, "except_session");

            if (Tools.Strings.StrCmp(SessionID, exceptSession))
                return;

            RzWin.Form.TabCloseByID(objectId);
        }

        delegate void NoteCheckHandler();
        public override void HandleNoteCheck()
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new NoteCheckHandler(ActuallyHandleNoteCheck));
            else
                ActuallyHandleNoteCheck();
        }

        public void ActuallyHandleNoteCheck()
        {
            try
            {
                RzWin.Form.CheckNotes();
            }
            catch { }
        }

        delegate void VersionUpdateHandler();
        public override void RunVersionUpdate()
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new VersionUpdateHandler(ActuallyRunVersionUpdate));
            else
                ActuallyRunVersionUpdate();
        }

        public void ActuallyRunVersionUpdate()
        {
            //Rz3App.xMainForm.RunVersionUpdate();
        }

        public override String GetCurrentStatus()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<currentstatus>");

            //version stuff
            FileVersionInfo fvi = Tools.Misc.GetFileVersionInfo(Tools.ToolsNM.AssemblyNM);
            sb.Append("<version>" + Tools.Misc.GetVersionString(Tools.ToolsNM.AssemblyNM) + "</version>");
            sb.Append("<product_major_version>" + fvi.ProductMajorPart.ToString() + "</product_major_version>");
            sb.Append("<product_minor_version>" + fvi.ProductMinorPart.ToString() + "</product_minor_version>");
            sb.Append("<product_build_version>" + fvi.ProductBuildPart.ToString() + "</product_build_version>");
            sb.Append("<product_private_version>" + fvi.ProductPrivatePart.ToString() + "</product_private_version>");
            sb.Append("<original_command_line>" + Environment.CommandLine + "</original_command_line>");

            //user stuff
            sb.Append("<user>" + RzWin.User.name + "</user>");

            sb.Append("<current_tab></current_tab>");   //where was this ? " + GetCurrentTab() + "

            //tabs
            //ArrayList a = GetOpenTabs();
            sb.Append("<open_tabs>");
            //foreach (String s in a)
            //{
            //    sb.Append("<open_tab>" + s + "</open_tab>");
            //}
            sb.Append("</open_tabs>");
            sb.Append("</currentstatus>");
            return sb.ToString();
        }

        public override void ItemCloseComplete()
        {
            if (RzWin.Context == null)
                return;

            RzWin.Context.TheLeader.TellTemp("Item close complete.");
        }

        public override void ItemCloseCanceled()
        {
            if (RzWin.Context == null)
                return;

            RzWin.Context.TheLeader.TellTemp("The item close request was cancelled by the user.");
        }

        public void HandlePrismMessage(TieMessage m)
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyHandlePrismMessage), new object[] { m });
            else
                ActuallyHandlePrismMessage(m);
        }

        public void ActuallyHandlePrismMessage(TieMessage m)
        {
            String req_id = Tools.Xml.ReadXmlProp(m.ContentNode, "req_id");
            if (!Tools.Strings.StrExt(req_id))
                return;
            switch (m.FunctionName.ToLower())
            {
                case "req_send":
                    if (SendPrismReq != null)
                        SendPrismReq(req_id);
                    break;
                case "quote_send":
                    if (SendPrismQuote != null)
                        SendPrismQuote(req_id);
                    break;
                case "remove_req":
                    if (RemovePrismReq != null)
                        RemovePrismReq(req_id);
                    break;
            }
        }

        public event PrismQuoteSendHandler SendPrismQuote;
        public event PrismQuoteSendHandler SendPrismReq;
        public event PrismQuoteSendHandler RemovePrismReq;

        public override ChatSession ChatSessionCreate()
        {
            //return base.ChatSessionCreate();
            return new ChatSessionWin();
        }

        public override void HandleChatMessage(TieMessage m)
        {
            if (RzWin.Form == null)
                return;

            if (RzWin.Form.InvokeRequired)
                RzWin.Form.Invoke(new GenericMessageHandler(ActuallyHandleChatMessage), new object[] { m });
            else
                ActuallyHandleChatMessage(m);
        }


        public void ActuallyHandleChatMessage(TieMessage m)
        {
            String strFromUserID = Tools.Xml.ReadXmlProp(m.ContentNode, "FromUserID");
            String strFromUserName = Tools.Xml.ReadXmlProp(m.ContentNode, "FromUserName");
            String strFromMachineID = Tools.Xml.ReadXmlProp(m.ContentNode, "FromMachineID");
            String strFromMachineName = Tools.Xml.ReadXmlProp(m.ContentNode, "FromMachineName");

            ChatSessionWin session = (ChatSessionWin)GetSessionByID(strFromUserID + "|" + strFromMachineID);
            if (session == null)
            {
                ClientConnection c = new ClientConnection((XmlNode)null);
                c.UserID = strFromUserID;
                c.UserName = strFromUserName;
                c.MachineID = strFromMachineID;
                c.MachineName = strFromMachineName;

                session = (ChatSessionWin)AddChatSession(c);
            }

            ChatScreenMakeExist(session, false);
            session.Add(m);

            if (UseChatSound)
                ToolsWin.Sounds.PlaySound(ChatSoundFile);

            RzWin.Form.FlashChat();

            //ReCacheClientList();
        }

        public static frmChatSession TheChatScreen = null;
        public void ChatScreenMakeExist(ChatSession s, bool initRe)
        {
            if (TheChatScreen == null)
                ChatScreenShow(s);
            else if (!TheChatScreen.Visible)
                ChatScreenShow(s);

            if (initRe)
                TheChatScreen.InitRe();
        }

        void ChatScreenShow(ChatSession s)
        {
            if (RzWin.Context == null)
                return;

            try
            {
                if (TheChatScreen != null)
                {
                    TheChatScreen.Close();
                    TheChatScreen.Dispose();
                    TheChatScreen = null;
                }
            }
            catch { }

            TheChatScreen = RzWin.Leader.GetChatSessionForm();
            TheChatScreen.Sessions = ChatSessions;
            TheChatScreen.xSession = (ChatSessionWin)s;
            TheChatScreen.Show();
            TheChatScreen.CompleteLoad();
            TheChatScreen.InitRe();
        }


        delegate void ConnectionChangeHandler(bool connected);
        public void HandleConnectionChange(bool connected)
        {
            if (RzWin.Form == null)
                return;

            try
            {
                if (RzWin.Form.InvokeRequired)
                    RzWin.Form.Invoke(new ConnectionChangeHandler(ActuallyHandleConnectionChange), new object[] { connected });
                else
                    ActuallyHandleConnectionChange(connected);
            }
            catch { }
        }

        public void ActuallyHandleConnectionChange(bool connected)
        {
            if (RzWin.Form == null)
                return;

            RzWin.Form.TieConnectionChanged(connected);
        }
    }

    public class ChatSessionWin : ChatSession
    {
        public ToolsWin.BrowserPlain TheBrowser = null;

        ~ChatSessionWin()
        {
            try
            {
                //2011_11_10 all this was missing?
                if (TheBrowser != null)
                {
                    try
                    {
                        TheBrowser.Parent.Controls.Remove(TheBrowser);
                    }
                    catch { }

                    try
                    {
                        TheBrowser.Dispose();
                    }
                    catch { }

                    TheBrowser = null;
                }
            }
            catch { }
        }

        public override void Add(TieMessage m)
        {
            if (Rz5.Win.RzHookWin.TheChatScreen.InvokeRequired)
                Rz5.Win.RzHookWin.TheChatScreen.Invoke(new GenericMessageHandler(ActuallyAdd), new object[] { m });
            else
                ActuallyAdd(m);
        }

        public void ActuallyAdd(TieMessage m)
        {
            try
            {
                BrowserMakeExist();

                String s = Tools.Xml.ReadXmlProp(m.ContentNode, "chat_text");
                AddText(nTools.DateFormat_ShortDateTime(DateTime.Now) + "  " + s, Color.Blue);
                frmChatSession.FlashWindow(Rz5.Win.RzHookWin.TheChatScreen.Handle, false);
                Rz5.Win.RzHookWin.TheChatScreen.PlayChatSound();
                Viewed = false;
                Rz5.Win.RzHookWin.TheChatScreen.InitRe();
            }
            catch { }
        }

        public void BrowserMakeExist()
        {
            if (TheBrowser != null && TheBrowser.IsDisposed)
            {
                TheBrowser = null;               
            }

            if (TheBrowser == null)
            {
                TheBrowser = new ToolsWin.BrowserPlain();
                TheBrowser.ReloadWB();
            }
        }

        public bool Viewed = false;
        //public StringBuilder chatHtml = new StringBuilder();
        public void AddText(String strText, Color color)
        {
            if (!Tools.Strings.StrExt(strText))
                return;

            //chatHtml.AppendLine("<br><hr><font color=\"" + color.Name + "\">" + nTools.ConvertTextToHTML(strText) + "</font><br>");
            TheBrowser.Add("<br><hr><font color=\"" + color.Name + "\">" + nTools.ConvertTextToHTML(strText) + "</font><br>");
            TheBrowser.ScrollToBottom();
        }

        public bool Enabled = true;
        public void Enable()
        {
            Enabled = true;
            Rz5.Win.RzHookWin.TheChatScreen.InitRe();

            //if (xForm != null)
            //    xForm.SetEnabled(true);
        }

        public void Disable()
        {
            Enabled = false;
            Rz5.Win.RzHookWin.TheChatScreen.InitRe();
            //if (xForm != null)
            //    xForm.SetEnabled(false);
        }
    }

}
