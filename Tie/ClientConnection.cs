using System;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.Threading;
using System.IO;

using NewMethodx;

namespace Tie
{
    public class ClientConnection : TieEnd
    {
        public Eye xEye;
        public Hook xRootHook; //static remote connection

        public bool IsStatic = false;
        public bool StaticConnected = false;  //this is for non-live static local copies of connections

        public TieRefresh xRefresh = new TieRefresh();

        public DateTime ConnectionDate = Tools.Dates.NullDate;

        public override bool IsConnected(ref string s)
        {
            if (IsStatic)
                return StaticConnected;

            return base.IsConnected(ref s);
        }

        public override void AddRunningJob(TieJob j)
        {
            if (IsStatic)
                xRootHook.AddRunningJob(j);
            else
                base.AddRunningJob(j);
        }

        public TieEnd GetEnd()
        {
            if (IsStatic)
                return xRootHook;
            else
                return this;
        }

        public override bool ServerEnd
        {
            get
            {
                return true;
            }
        }

        public override String GetFilesFolder()
        {
            if (IsStatic)
            {
                return GetLocalFilesFolder();
            }
            else
                return GetLocalFilesFolder();
        }

        public ClientConnection(Socket s, Eye e)
        {
            TheSocket = s;
            xEye = e;
            Password = xEye.Password;
            IsStatic = false;
        }

        public ClientConnection(TieTack t)
        {
            xRootHook = t;
            IsStatic = true;
            StaticConnected = t.IsConnected();
        }

        public ClientConnection(XmlNode n)
        {
            if (n == null)
                return;

            AbsorbSummaryXml(n);
        }

        public override void GotHello(TieMessage m)
        {
            //grab the connection data from the hello message and apply it to the local copy of the connection
            String strSession = Tools.Xml.ReadXmlProp(m.ContentNode, "SessionID");
            ClientConnection c = xEye.GetConnectionBySessionID(strSession);
            if (c != null)
                xEye.RemoveConnection(c);

            this.AbsorbSummaryXml(m.ContentNode);

            if (IsManager)
                xEye.AddManagerConnection(this);

            xEye.FireConnectionUpdated(this);
            xRefresh.Refresh();

            //forward it around
            //xEye.ForwardToEveryone(m);
        }

        public override void ProcessMessage(TieMessage m)
        {
            if (Tools.Strings.StrExt(m.ToSession) && m.ToSession != "root")
            {
                //forward it
                m.UseEntireMessage = true;
                xEye.ForwardMessage(m, SiteCredentials);
            }
            else
            {
                m.FullyParse(Password);

                //check it for a function name
                if (!Tools.Strings.StrExt(m.FunctionName))  //most likely a decryption error, bad password, etc
                {
                    TieMessage r = new TieMessage(GetSessionFrom(), "message_unreadable", "");
                    r.ContentString = Tools.Xml.BuildXmlProp("error_description", "A message was received, but was not readable.  The most common cause of this is that the connection password between the client and server don't match.  Please make sure that the connection password is correct and try again.");
                    SendClear(r);
                }
                else
                    base.ProcessMessage(m);
            }
        }

        public override void GotMessage(TieMessage m)
        {
            switch (m.FunctionName)
            {
                case "goodbye":
                    SendOff(false, true, true, false);
                    break;
                case "client_list_request":
                    SendClientList();
                    break;
                case "chat_list_request":
                    SendChatList();
                    break;
                case "close_then_cause_fatal_error": //for testing :)
                    CloseThenCauseFatalError();
                    break;
                case "client_list_request_by_user":
                    SendClientListByUser(Tools.Xml.ReadXmlProp(m.ContentNode, "user_id"));
                    break;
            }
        }

        public override void GotPong()
        {
            base.GotPong();
            xEye.FireConnectionUpdated(this);
        }

        public bool SendClientListByUser(String strUserID)
        {
            ArrayList a = xEye.GetConnectionsByCriteria(strUserID, "");
            TieMessage m = new TieMessage(GetSessionFrom(), "client_list_response_by_user", "");

            StringBuilder sb = new StringBuilder();
            foreach (TieEnd x in a)
            {
                sb.Append("<connection>" + x.GetSummaryXml() + "</connection>");
            }
            m.ContentString = sb.ToString();
            return Send(m);
        }

        public bool SendClientList()
        {
            TieMessage m = new TieMessage(GetSessionFrom(), "client_list_response", "");

            ArrayList connections = xEye.GetAllConnectedClients(SiteCredentials);
            StringBuilder sb = new StringBuilder();
            foreach (TieEnd x in connections)
            {
                sb.Append("<connection>" + x.GetSummaryXml() + "</connection>");
            }
            m.ContentString = sb.ToString();
            return Send(m);
        }

        public void CloseThenCauseFatalError()
        {
            Thread t = new Thread(new ThreadStart(ActuallyCloseThenCauseFatalError));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        void ActuallyCloseThenCauseFatalError()
        {
            xEye.StopListening(false);
            xEye.DisconnectClients(false, false, true);

            int i = 1;
            int j = 5;
            i--;
            int k = j / i;
        }

        public bool SendChatList()
        {
            ArrayList r = new ArrayList();
            ArrayList a = xEye.GetAllConnectedClients(SiteCredentials);
            foreach (ClientConnection c in a)
            {
                if (Tools.Strings.StrExt(c.UserID))
                {
                    String s = c.MachineName + "|" + c.UserName + "|" + c.MachineID + "|" + c.UserID;
                    if (!r.Contains(s))
                        r.Add(s);
                }
            }

            TieMessage m = new TieMessage(GetSessionFrom(), "chat_list_response", "");
            StringBuilder sb = new StringBuilder();
            foreach (String s in r)
            {
                sb.Append(Tools.Xml.BuildXmlProp("chat_user", s));
            }
            m.ContentString = sb.ToString();
            return Send(m);
        }

        public void SendOff(bool notify_remote, bool notify_rest, bool remove, bool forever)
        {
            if (notify_remote)
            {
                String s = "goodbye";
                if (forever)
                    s += "_forever";

                TieMessage m = new TieMessage(GetSessionFrom(), s, "");
                Send(m);
            }

            Close();
            
            //if( notify_rest)
            //    SendOff();
    
            if( remove )
                xEye.RemoveConnection(this);

            KillThread();
        }

        public void UpdateKnot(bool open_new)
        {
            String s = "update_originals";
            if (open_new)
                s += "_run_latest";

            TieMessage m = new TieMessage(GetSessionFrom(), s, "");
            Send(m);
        }

        public void SendOff()
        {
            //notify everyone
            TieMessage m = new TieMessage(GetSessionFrom(), "other_client_lost", "");
            m.ContentString = SessionID;
            xEye.ForwardToEveryoneBut(m, this, SiteCredentials);
        }
    }
}
