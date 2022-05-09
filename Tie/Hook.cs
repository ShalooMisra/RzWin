using System;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.IO;

using NewMethodx;

namespace Tie
{
    public delegate void GotClientsHandler(ArrayList a);

    public class Hook : TieEnd
    {
        public String HostName = "";
        public int HostPort = 0;
        public int ReConnectionCount = 0;
        public bool WasConnected = false;
        public bool ReadyToExit = false;
        public int ClientCount = 0;
        public int UnreadableMessages = 0;

        public event GotClientsHandler GotClients;

        Timer PersistenceTimer;

        public Hook()
        {
            InitReading();
            SessionID = Tools.Strings.GetNewID();
            MachineName = Environment.MachineName;
            MachineID = MakeMachineIDExist();
            EndAddress = Tools.Network.GetLocalIP();
            ApplicationName = "None";
            ApplicationVersion = 1;
            Password = "tie";
            SendEncrypted = true;
        }

        public String MakeMachineIDExist()
        {
            String f = TieKnot.KnotRootPath + "machine_id.txt";
            if (File.Exists(f))
                return Tools.Files.OpenFileAsString(f);

            String s = Tools.Strings.GetNewID();
            Tools.Files.SaveFileAsString(f, s);
            return s;
        }

        public bool ConnectWithPersistence()
        {
            String s = "";
            return ConnectWithPersistence(ref s);
        }

        public bool ConnectWithPersistence(ref String s)
        {
            if (!Connect(ref s))
                return false;

            StartPersistence();
            return true;
        }

        public void StartPersistence()
        {
            SetStatus("Starting persistence...");
            PersistenceTimer = new Timer(new TimerCallback(PersistenceCheck));
            PersistenceTimer.Change(TieEnd.PingSeconds * 1000, TieEnd.PingSeconds * 1000);
        }

        public void StopPersistence()
        {
            SetStatus("Stopping persistence...");
            if (PersistenceTimer == null)
                return;
            
            PersistenceTimer.Change(0, 0);
            PersistenceTimer.Dispose();
            PersistenceTimer = null;
        }

        public void PersistenceCheck()
        {
            PersistenceCheck(null);
        }

        public void PersistenceCheck(Object x)
        {
            String s = "";
            if (IsConnected(ref s))
            {
                TimeSpan t = DateTime.Now.Subtract(LastPing);
                SetStatus("Persistently connected: " + t.TotalSeconds.ToString());
                return;
            }

            if (WasConnected)
            {
                GotDisconnected();
                WasConnected = false;
            }

            SetStatus("Re-Connecting [" + s + "]...");
            if (Connect(ref s))
            {
                ReConnectionCount++;
                SetStatus("ReConnected.");
            }
            else
                SetStatus("Still not connected");
        }

        public bool Connect()
        {
            String s = "";
            return Connect(ref s);
        }

        public bool Connect(ref String s)
        {
            try
            {

                EndPoint ep = null;
                SetStatus("Connecting...");

                if( Tools.Strings.CharCount(HostName, '.') == 3 && Tools.Number.IsNumeric(HostName.Replace(".", "")))
                {
                    ep = new IPEndPoint(IPAddress.Parse(HostName), HostPort);
                }
                else
                {
                    IPHostEntry IPHost;
                    IPHost = Dns.GetHostEntry(HostName);

                    string[] aliases = IPHost.Aliases;
                    IPAddress[] addr = IPHost.AddressList;

                    IPAddress UseThisAddress = null;
                    if( IPHost.AddressList.Length == 1 )
                        UseThisAddress = addr[0];
                    else
                    {
                        foreach (IPAddress ip in IPHost.AddressList)
                        {
                            if (ip.AddressFamily == AddressFamily.InterNetwork)
                            {
                                UseThisAddress = ip;
                                break;
                            }
                        }
                    }

                    if( UseThisAddress == null )
                        UseThisAddress = addr[0];

                    ep = new IPEndPoint(UseThisAddress, HostPort);
                }

                //get rid of the socket here
                if (TheSocket != null)
                {
                    try
                    {
                        TheSocket.Shutdown(SocketShutdown.Both);
                        TheSocket.Close();
                        TheSocket = null;
                    }
                    catch { }
                }

                TheSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                TheSocket.Connect(ep);
                if (TheSocket.Connected)
                {
                    Status = "Connected";
                    LastPing = DateTime.Now;
                    WasConnected = true;
                    UnreadableMessages = 0;
                    SendHello();
                    GotConnected();

                    //ContinueReading();

                    ReadLoopOnThread();

                    return true;
                }
                else
                {
                    SetStatus("<no connection>");
                    s = "<no connection>";
                    return false;
                }
            }
            catch (Exception ex)
            {
                Status = "Not Connected: " + ex.Message;
                SetStatus("Connect Error: " + ex.Message);
                s = ex.Message;
                return false;
            }
        }

        public void RequestClientList()
        {
            SetStatus("Requesting client list...");
            TieMessage m = new TieMessage(GetSessionFrom(), "client_list_request", "");
            Send(m);
        }

        public void RequestChatList()
        {
            SetStatus("Requesting chat list...");
            TieMessage m = new TieMessage(GetSessionFrom(), "chat_list_request", "");
            Send(m);
        }

        public void SendHello()
        {
            SetStatus("Sending hello...");
            TieMessage m = new TieMessage(GetSessionFrom(), "hello", "");
            m.ContentString = GetSummaryXml();
            Send(m);
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                switch (m.FunctionName)
                {
                    case "goodbye":
                        Close();
                        break;
                    case "goodbye_forever":
                        SetStatus("Closing permanently");
                        StopPersistence();
                        Close();
                        ReadyToExit = true;
                        break;
                    case "other_client_lost":
                        AnotherClientLost(m.ContentString);
                        break;
                    case "client_list_response":
                        GotClientListMessage(m);
                        break;
                    case "chat_list_response":
                        GotChatList(ParseChatList(m.ContentNode));
                        break;
                    case "message_unreadable":
                        GotMessageUnreadable(Tools.Xml.ReadXmlProp(m.ContentNode, "error_description"));
                        break;
                }
            }
            catch { }
        }

        public virtual void GotMessageUnreadable(String desc)
        {
            UnreadableMessages++;
            SetStatus("Message unreadable: " + desc);
        }

        public virtual void GotClientListMessage(TieMessage m)
        {
            ArrayList a = new ArrayList();
            //the response
            try
            {
                a = ParseClientList(m);
            }
            catch { }

            ClientCount = a.Count;
            GotClientList(a);
        }

        public ArrayList ParseClientList(TieMessage m)
        {
            ArrayList a = new ArrayList();
            //everything's already in Content
            XmlNodeList l = m.ContentNode.SelectNodes("connection");
            foreach (XmlNode x in l)
            {
                ClientConnection c = new ClientConnection(x);
                a.Add(c);
            }
            return a;
        }

        public virtual ArrayList ParseChatList(XmlNode n)
        {
            ArrayList r = new ArrayList();
            XmlNodeList l = n.SelectNodes("chat_user");
            foreach (XmlNode ln in l)
            {
                r.Add(ln.InnerText);
            }
            return r;
        }

        public virtual void GotChatList(ArrayList a)
        {

        }

        public virtual void GotClientList(ArrayList clients)
        {
            if (GotClients != null)
                GotClients(clients);
        }

        public override void Close()
        {
            //StopPersistence();
            base.Close();
            GotDisconnected();
        }

        public virtual void GotConnected()
        {
            SetStatus("Connected.");
        }

        public virtual void GotDisconnected()
        {
            SetStatus("Disconnected.");
        }

        public virtual void AnotherClientLost(String strLostSessionID)
        {

        }
    }
}
