using System;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;

using NewMethodx;

namespace Tie
{
    public class Eye
    {
        public event EyeStatusHandler GotStatus;
        public event EyeStatusHandler GotError;

        public void FireGotError(String error)
        {
            if (GotError != null)
                GotError(error);
        }

        public EyeState CurrentState = EyeState.Closed;
        public Object StateLock = new Object();
        public int EyePort = 2949;

        public String data = "";
        public ManualResetEvent allDone = new ManualResetEvent(false);
        public ArrayList AllConnections;
        public ArrayList ManagerConnections;

        Socket listener;
        Timer PingTimer;

        public int ConnectionCount = 0;
        public int AcceptErrors = 0;
        public int ForcedCloses = 0;

        public Thread ListenThread = null;
        ArrayList AcceptThreads;

        public String Password = "tie";
        public bool SendEncrypted = true;
        public bool CheckSiteCredentials = false;

        //Events
        public event ConnectionChangeHandler ConnectionUpdated;
        public void FireConnectionUpdated(ClientConnection c)
        {
            if (ConnectionUpdated != null)
                ConnectionUpdated(c);
        }

        public event ConnectionChangeHandler ConnectionAdded;
        public void FireConnectionAdded(ClientConnection c)
        {
            if (ConnectionAdded != null)
                ConnectionAdded(c);
        }

        public event ConnectionChangeHandler ConnectionLost;
        public void FireConnectionLost(ClientConnection c)
        {
            if (ConnectionLost != null)
                ConnectionLost(c);
        }

        public event EyeStateChangeHandler StateChanged;
        public void FireStateChanged()
        {
            if (StateChanged != null)
                StateChanged();
        }

        //Constructor
        public Eye()
        {
            AllConnections = new ArrayList();
            ManagerConnections = new ArrayList();
            ConnectionCount = 0;
        }

        public virtual void StartListening()
        {
            AllConnections = new ArrayList();
            ManagerConnections = new ArrayList();
            ConnectionCount = 0;

            AcceptThreads = new ArrayList();

            if (ListenThread != null)
            {
                try
                {
                    ListenThread.Abort();
                    ListenThread = null;
                }
                catch { }
            }

            ListenThread = new Thread(new ThreadStart(StartListeningOnThread));
            ListenThread.SetApartmentState(ApartmentState.STA);
            ListenThread.Start();
        }

        public void StartListeningOnThread()
        {
            Byte[] bytes = new Byte[TieEnd.BufferSize];
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Any;
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, EyePort);

            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                SetStatus("Listening...");

                SetState(EyeState.Watching);
                StartPingTimer();

                while (true)
                {
                    allDone.Reset();
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                FireGotError("Listen error: " + e.Message);
                SetStatus("Listen Error: " + e.Message);
            }
        }

        private void StartPingTimer()
        {
            PingTimer = new Timer(new TimerCallback(PingTick));
            PingTimer.Change(TieEnd.PingSeconds * 1000, TieEnd.PingSeconds * 1000);  //changed from TieEnd.PingSeconds * 2000, TieEnd.PingSeconds * 1000 on 2013/06/22
            SetStatus("Started ping timer...");
        }

        public void PingTick(Object x)
        {
            CheckPing();
        }

        public void CheckPing()
        {
            SetStatus("Checking ping...");
            lock (AllConnections.SyncRoot)
            {
                ArrayList remove = new ArrayList();
                foreach (ClientConnection c in AllConnections)
                {
                    String s = "";
                    if (c.IsConnected(ref s))
                        c.SendPing();
                    else
                    {
                        c.PingTrace = "Not connected: " + s;
                        SetStatus(c.GetSummaryName() + " is not connected: " + s);
                        remove.Add(c);
                    }
                }

                foreach (ClientConnection c in remove)
                {
                    SetStatus("Forcing remove on " + c.GetSummaryName());
                    c.SendOff(false, true, true, false);
                    ForcedCloses++;
                }
            }
        }

        private void StopPingTimer()
        {
            PingTimer.Change(0, 0);
            PingTimer.Dispose();
            PingTimer = null;
            SetStatus("Stopped ping timer.");
        }

        private void SetState(EyeState t)
        {
            lock (StateLock)
            {
                CurrentState = t;
            }
            FireStateChanged();
        }

        public bool WaitForState(EyeState state, int milliseconds)
        {
            for (int i = 0; i < milliseconds; i += 200)
            {
                bool b = false;
                lock (StateLock)
                {
                    b = (CurrentState == state);
                }
                if (b)
                    return true;

                Thread.Sleep(200);
            }
            return false;
        }

        public void DisconnectClients(bool notify_remote, bool notify_rest, bool remove)
        {
            SetStatus("Disconnecting clients...");

            if (AllConnections == null)
                return;
            try
            {
                ArrayList r = (ArrayList)AllConnections.Clone();
                foreach (ClientConnection c in r)
                {
                    try
                    {
                        c.SendOff(notify_remote, notify_rest, remove, false);
                    }
                    catch { }
                }
            }
            catch { }
        }

        public virtual void StopListening(bool notify)
        {
            try
            {
                StopPingTimer();
                SetStatus("Stopping...");

                //stop listening before notifying
                try
                {
                    ListenThread.Abort();
                    ListenThread = null;
                }
                catch { };

                listener.Close();
                listener = null;
                SetStatus("Stopped listening.");
                SetState(EyeState.Closed);
                
            }
            catch (Exception)
            { }

            if (notify)
                DisconnectClients(true, false, true);
            else
                DisconnectClients(false, false, true);
        }

        void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                allDone.Set();

                Socket listener = (Socket)ar.AsyncState;
                Socket handler = listener.EndAccept(ar);

                ClientConnection c = GetNewConnection(handler);
                c.LastPing = DateTime.Now;
                AddConnection(c);
                c.ReadLoopOnThread();
            }
            catch(Exception ex)
            {

                SetStatus("Accept error: " + ex.Message);
                AcceptErrors++;
                //listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
            }
        }

        public virtual ClientConnection GetNewConnection(Socket handler)
        {
            ClientConnection c = new ClientConnection(handler, this);
            c.SendEncrypted = SendEncrypted;
            c.Password = Password;

            try
            {
                IPEndPoint iep = (IPEndPoint)handler.RemoteEndPoint;
                c.RemoteIP = iep.Address.ToString();
            }
            catch{}

            return c;
        }

        public virtual void AddConnection(ClientConnection c)
        {
            SetStatus("New connection.");
            lock (AllConnections.SyncRoot)
            {
                AllConnections.Add(c);
                ConnectionCount++;
            }
            //c.GotStatus += new TieEndStatusHandler(c_GotStatus);

            NoteUpdateNeeded();
            c.ConnectionDate = DateTime.Now;
            FireConnectionAdded(c);
        }

        public virtual void AddManagerConnection(ClientConnection c)
        {
            SetStatus("New manager connection.");
            lock (ManagerConnections.SyncRoot)
            {
                ManagerConnections.Add(c);
            }
        }

        void c_GotStatus(TieEnd end, string s)
        {
            SetStatus(s + " <from> " + end.GetSummaryName());
        }

        public virtual void RemoveConnection(ClientConnection c)
        {
            try
            {
                lock (AllConnections.SyncRoot)
                {
                    AllConnections.Remove(c);
                    ConnectionCount--;
                }
            }
            catch
            { }

            if (c.IsManager)
            {
                try
                {
                    lock (ManagerConnections.SyncRoot)
                    {
                        ManagerConnections.Remove(c);
                    }
                }
                catch
                { }
            }

            c.GotStatus -= new TieEndStatusHandler(c_GotStatus);
            c.KillThread();
            NoteUpdateNeeded();
            FireConnectionLost(c);
        }

        Timer UpdateTimer = null;
        public void NoteUpdateNeeded()
        {
            if( UpdateTimer == null )
                UpdateTimer = new Timer(new TimerCallback(NoteUpdateTick));

            //this can't be lower than the time it takes to notify all the manager connections
            UpdateTimer.Change(3000, 3000);
        }

        public void NoteUpdateTick(Object x)
        {
            UpdateTimer.Change(-1, -1);
            foreach (ClientConnection c in ManagerConnections)
            {
                if( c.IsConnected() )
                    c.SendClientList();
            }
        }

        public bool HasConnectionBySession(String strSessionID)
        {
            return GetConnectionBySessionID(strSessionID) != null;
        }
        
        public ClientConnection GetConnectionByCriteria(String strCriteria)
        {
            ArrayList a = GetConnectionsByCriteria(strCriteria);
            if (a.Count == 0)
                return null;
            else
                return (ClientConnection)a[0];
        }

        public ArrayList GetConnectionsByCriteria(String strCriteria)
        {
            String s = strCriteria;
            if (s.StartsWith("<"))
                s = Tools.Strings.Mid(s, 2);

            if (s.EndsWith(">"))
                s = Tools.Strings.Left(s, s.Length - 1);

            String[] ary = Tools.Strings.Split(s, ",");

            String strUserID = "";
            String strMachineID = "";
            
            foreach (String l in ary)
            {
                String strName = Tools.Strings.ParseDelimit(l, "=", 1).Trim();
                String strVal = Tools.Strings.ParseDelimit(l, "=", 2).Trim();

                switch (strName.ToLower())
                {
                    case "userid":
                        strUserID = strVal;
                        break;
                    case "machineid":
                        strMachineID = strVal;
                        break;
                }
            }

            return GetConnectionsByCriteria(strUserID, strMachineID);
        }

        public ArrayList GetConnectionsByCriteria(String strUserID, String strMachineID)
        {
            if (AllConnections == null)
                return new ArrayList();

            ArrayList ret = new ArrayList();
            lock (AllConnections.SyncRoot)
            {
                foreach (ClientConnection c in AllConnections)
                {
                    bool b = true;

                    if (strUserID != "" && strUserID != c.UserID)
                        b = false;

                    if (b)
                    {
                        if (strMachineID != "" && strMachineID != c.MachineID)
                            b = false;
                    }

                    if (b)
                        ret.Add(c);
                }
            }
            return ret;
        }

        public ClientConnection GetConnectionBySessionID(String strSessionID)
        {
            if (AllConnections == null)
                return null;

            lock (AllConnections.SyncRoot)
            {
                foreach (ClientConnection c in AllConnections)
                {
                    if (Tools.Strings.StrCmp(c.SessionID, strSessionID))
                        return c;
                }
                return null;
            }
        }

        public bool ForwardToEveryone(TieMessage m, String strSiteCredentials)
        {
            return ForwardMessage(m, GetAllConnectedClients(strSiteCredentials));
        }

        public bool ForwardToEveryoneBut(TieMessage m, ClientConnection but, String strSiteCredentials)
        {
            ArrayList a = GetAllConnectedClients(strSiteCredentials);
            a.Remove(but);
            return ForwardMessage(m, a);
        }

        public event GotMessageHandler HubMessageReceived;
        public bool ForwardMessage(TieMessage m, String strSiteCredentials)
        {
            if (m.ToSession == "<all>")
            {
                return ForwardToEveryoneBut(m, GetConnectionBySessionID(m.FromSession), strSiteCredentials);
            }
            else if (m.ToSession == "<hub>")
            {
                if (HubMessageReceived != null)
                {
                    HubMessageReceived(m);
                    return true;
                }
                else
                    return false;
            }
            else
            {
                ClientConnection c = null;

                if (m.ToSession.StartsWith("<"))
                {
                    c = GetConnectionByCriteria(m.ToSession);
                }
                else
                    c = GetConnectionBySessionID(m.ToSession);

                if (c == null)
                {
                    SetStatus("Session not found.");
                    return false;
                }

                c.Send(m);
                return true;
            }
        }

        public bool ForwardMessage(TieMessage m, ArrayList to)
        {
            if (to.Count <= 0)
                return true;

            SetStatus("Forwarding " + m.FunctionName + " to " + to.Count.ToString() + "...");
            bool b = true;
            foreach (ClientConnection c in to)
            {
                //if (!c.Send(m))
                //    b = false;
                c.SendAsync(m);
            }
            return b;
        }

        public ArrayList GetAllConnectedClients()
        {
            return GetAllConnectedClients("");
        }

        public ArrayList GetAllConnectedClients(String strSiteCredentials)
        {
            lock (AllConnections.SyncRoot)
            {
                ArrayList ret = new ArrayList();
                foreach (ClientConnection c in AllConnections)
                {
                    if (!c.IsManager && !c.IsSystem && c.IsConnected())
                    {
                        if (CheckSiteCredentials)
                        {
                            if (c.SiteCredentials == strSiteCredentials)
                                ret.Add(c);
                        }
                        else
                            ret.Add(c);
                    }
                }
                return ret;
            }
        }

        public void SetStatus(String s)
        {
            if (GotStatus != null)
                GotStatus(s);
        }
    }

    public delegate void ConnectionChangeHandler(ClientConnection c);
    public delegate void EyeStatusHandler(String s);
    public delegate void EyeStateChangeHandler();

    public enum EyeState
    {
        Closed = 0,
        Watching = 1,
    }
}