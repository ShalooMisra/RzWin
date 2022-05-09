using System;
using System.Collections;
using System.Text;
using System.Threading;

using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

using System.Xml;

using NewMethod;
using NewMethod.Chat;
using nmTie;

namespace NewMethod.Chat
{
    public class ChatHook : nHook
    {
        public static n_sys ChatSys;
        public static n_user ChatUser;
        public static ChatHook TheChatHook;
        public static frmNewChatSession NewSessionForm;
        public static ArrayList SessionThreads = new ArrayList();

        public static bool UseChatSound = false;
        public static String ChatSoundFile = "";

        public static SortedList ChatSessions = new SortedList();
        public static ChatSession GetSessionByID(String strID)
        {
            return (ChatSession)ChatSessions[strID];
        }

        public static void InitSoundSettings()
        {
            if (ChatSys == null)
                return;

            ChatHook.UseChatSound = ChatSys.xUser.GetSetting_Boolean("use_chat_sound");
            ChatHook.ChatSoundFile = ChatSys.xUser.GetSetting("chat_sound");
        }

        public static ChatSession AddSession(ChatClient c)
        {
            ChatSession s = new ChatSession();
            s.UniqueID = c.GetID();
            s.xClient = c;
            ChatSessions.Add(s.UniqueID, s);
            return s;
        }

        public static void RemoveSession(String strID)
        {
            try
            {
                ChatSessions.Remove(strID);
            }
            catch { }
        }

        public static void StartChatHook(n_sys sys, n_user u)
        {
            ChatSys = sys;
            ChatUser = u;

            if (TheChatHook != null)
            {
                TheChatHook.Disconnect();
                TheChatHook = null;
            }

            TheChatHook = new ChatHook("Chat");
            InitSoundSettings();
            TheChatHook.StartHookThread(ConnectTarget.Custom, ChatSys.xUser.GetSetting("chat_server_ip"));
        }

        public static void DisconnectChatHook()
        {
            if (TheChatHook != null)
            {
                TheChatHook.Disconnect();
                TheChatHook = null;
            }
        }

        public ChatHook(String strApp)
            : base(strApp, 1)
        {

        }

        public override TieConnection GetNewConnection(Socket handler)
        {
            ChatConnection c = new ChatConnection(handler);
            c.TheUser = ChatUser;
            return (TieConnection)c;
        }

        public override void GotGenericMessage(TieMessage m)
        {
            try
            {
                switch (m.FunctionName)
                {
                    case "client_list":
                        ShowNewChatSession(m);
                        break;
                    case "chat":
                        ShowChatMessage(m);
                        break;
                    case "disconnect":
                        CheckDisconnect(m);
                        break;
                    default:
                        base.GotGenericMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                nStatus.SetStatus("Error: " + ex.Message);
            }
        }

        public void ShowNewChatSession(TieMessage m)
        {
            String s = m.Content;
            ArrayList clients = new ArrayList();

            XmlDocument d = new XmlDocument();
            d.LoadXml("<?xml version=\"1.0\"?><connections>" + m.Content + "</connections>");
            XmlNodeList l = d.SelectNodes("connections/connection");
            foreach (XmlNode n in l)
            {
                ChatClient c = new ChatClient(n);
                clients.Add(c);
            }

            NewSessionForm = new frmNewChatSession();
            NewSessionForm.CompleteLoad(clients);
            NewSessionForm.ShowDialog();
            NewSessionForm.Close();
            NewSessionForm.Dispose();
            NewSessionForm = null;
        }

        private void ShowChatMessage(TieMessage m)
        {
            String s = m.Content;
            ArrayList clients = new ArrayList();

            XmlDocument d = new XmlDocument();
            d.LoadXml("<?xml version=\"1.0\"?><chats>" + m.Content + "</chats>");
            XmlNode n = d.SelectSingleNode("chats/chat[1]");
            ChatMessage cm = new ChatMessage(n);
            ChatSession session = GetSessionByID(cm.xClient.GetID());
            if (session == null)
            {
                session = ChatHook.AddSession(cm.xClient);
            }
            else
            {
                //make sure it has the right return session
                session.xClient.strConnectionID = cm.xClient.strConnectionID;

            }
            session.Show();
            session.Add(cm);

            if (ChatHook.UseChatSound)
                nSound.PlaySound(ChatHook.ChatSoundFile);

        }

        public override void GotHello(TieMessage m)
        {
            //enable the session
            ChatClient c = new ChatClient(m);
            ChatSession s = GetSessionByID(c.GetID());
            if (s != null)
            {
                s.xClient.strConnectionID = c.strConnectionID;
                s.Enable();
            }
        }

        public void CheckDisconnect(TieMessage m)
        {
            //disable the session
            ChatClient c = new ChatClient(m);
            ChatSession s = GetSessionByID(c.GetID());
            if (s != null)
                s.Disable();
        }

        public override void GotDisconnected()
        {
            //disable all of the sessions
            foreach (DictionaryEntry d in ChatSessions)
            {
                ChatSession s = (ChatSession)d.Value;
                s.Disable();
            }
        }
    }

    public class ChatClient
    {
        public String strUserID = "";
        public String strUserName = "";
        public String strMachineName = "";
        public String strConnectionID = "";

        public ChatClient()
        {

        }

        public ChatClient(XmlNode n)
        {
            AbsorbNode(n);
        }

        private void AbsorbNode(XmlNode n)
        {
            foreach (XmlNode c in n.ChildNodes)
            {
                switch (c.Name.ToLower())
                {
                    case "n_user_uid":
                        strUserID = c.InnerText;
                        break;
                    case "user_name":
                        strUserName = c.InnerText;
                        break;
                    case "id": //connection id
                    case "uniqueid":
                        strConnectionID = c.InnerText;
                        break;
                    case "machine":
                    case "machine_name":
                        strMachineName = c.InnerText;
                        break;
                }
            }
        }

        public ChatClient(TieMessage m)
        {
            XmlDocument d = new XmlDocument();
            d.LoadXml("<?xml version=\"1.0\"?><things><thing>" + m.Content + "</thing></things>");
            XmlNode n = d.SelectSingleNode("things/thing[1]");
            AbsorbNode(n);
        }

        public String GetID()
        {
            return strUserID + "|" + strMachineName;
        }
    }

    public class ChatMessage
    {
        public ChatClient xClient;
        public String ChatText = "";

        public ChatMessage(XmlNode n)
        {
            xClient = new ChatClient(n);

            foreach (XmlNode c in n.ChildNodes)
            {
                switch (c.Name.ToLower())
                {
                    case "chat_text":
                        ChatText = c.InnerText;
                        break;
                }
            }
        }
    }

    public class ChatSession
    {
        public String UniqueID = "";
        public ChatClient xClient;
        public frmChatSession xForm;

        public void Show()
        {
            if (xForm == null)
            {
                Thread t = new Thread(new ThreadStart(ActuallyShow));
                t.SetApartmentState(ApartmentState.STA);
                ChatHook.SessionThreads.Add(t);
                t.Start();
                Thread.Sleep(1500); //wait for the chat window to finish creating...
            }
            else
                xForm.BringBack();
        }

        public void Add(ChatMessage m)
        {
            if (xForm != null)
            {
                xForm.Add(m);
            }
        }

        public void ActuallyShow()
        {
            xForm = new frmChatSession();
            xForm.xSession = this;
            xForm.CompleteLoad();
            xForm.Show();
            Application.Run(xForm);
        }

        public void Enable()
        {
            if (xForm != null)
                xForm.SetEnabled(true);
        }

        public void Disable()
        {
            if (xForm != null)
                xForm.SetEnabled(false);
        }
    }
}
