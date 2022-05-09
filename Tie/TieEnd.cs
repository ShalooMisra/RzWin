using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Xml;
using System.IO;
using System.Windows.Forms;

using NewMethodx;
using OthersCodex;
using System.Diagnostics;

namespace Tie
{
    public interface ITieStatus
    {
        void AddPositive(String s);
        void AddNegative(String s);
        void AddNeutral(String s);
        void AddInfo(String s);
        void KeyUpdated(String key, String action);
        void ShowControl(UserControl c, String strCaption, String strName);
    }

    public delegate void TieEndStatusHandler(TieEnd end, String s);
    public delegate void GotMessageHandler(TieMessage m);

    public class TieEnd
    {
        public static int BufferSize = 1024;
        public static int PingSeconds = 10;

        public static String m_LocalFilesFolder = "";
        public static String GetLocalFilesFolder()
        {
            if( !Tools.Strings.StrExt(m_LocalFilesFolder) )
            {
                //if (nTools.IsDevelopmentMachinePlain())
                //    m_LocalFilesFolder = "c:\\eternal\\data\\tierack\\files\\";
                //else
                    m_LocalFilesFolder = Tools.FileSystem.GetAppPath() + "files\\";

                if (!Directory.Exists(m_LocalFilesFolder))
                    Directory.CreateDirectory(m_LocalFilesFolder);
            }

            return m_LocalFilesFolder;
        }

        public static String m_LocalTempFolder = "";
        public static String LocalTempFolder
        {
            get
            {
                if (!Tools.Strings.StrExt(m_LocalTempFolder))
                {
                    //if (nTools.IsDevelopmentMachinePlain())
                    //    m_LocalTempFolder = "c:\\eternal\\data\\tierack\\temp\\";
                    //else
                        m_LocalTempFolder = Tools.FileSystem.GetAppPath() + "temp\\";

                    if (!Directory.Exists(m_LocalTempFolder))
                        Directory.CreateDirectory(m_LocalTempFolder);
                }
                return m_LocalTempFolder;
            }
        }

        public static bool CheckLocalTempFolder()
        {
            if (!Directory.Exists(LocalTempFolder))
            {
                try
                {
                    Directory.CreateDirectory(LocalTempFolder);
                    return true;
                }
                catch
                {
                    return false;
                }

            }
            else
                return true;
        }

        public event TieEndStatusHandler GotStatus;
        public event GotMessageHandler GotMessageEvent;
        public void FireGotMessageEvent(TieMessage m)
        {
            try
            {
                if (GotMessageEvent != null)
                    GotMessageEvent(m);
            }
            catch { }
        }

        public Socket TheSocket = null;

        public Byte[] byte_buffer;
        public StringBuilder read_buffer;

        public String Status = "";
        public DateTime LastPing = new DateTime();
        public DateTime LastPingSent = new DateTime();
        public int PingCount = 0;
        public String PingTrace = "";
        public DateTime LastDuties = new DateTime();

        public ManualResetEvent allDone = null;
        public Thread xThread;

        public bool TrackTraffic = false;
        public StringBuilder SendLog = new StringBuilder();
        public StringBuilder ReceiveLog = new StringBuilder();
        public int StreamErrors = 0;

        public bool Sending = false;

        public String Password = "";
        public bool SendEncrypted = false;
        public bool IsManager = false;

        public bool AllowRemoteView = true;
        public bool AllowFileView = true;
        public bool AllowSQLView = true;
        public bool AllowClipView = true;
        public bool AllowCommandView = true;
        public bool AllowUserView = true;
        public bool AllowRegistryView = true;

        public bool IsSystem
        {
            get
            {
                return Tools.Strings.StrCmp(UserName, "system");
            }
        }

        public virtual bool ServerEnd
        {
            get
            {
                return false;
            }
        }

        //context stuff
        public String ApplicationName = "";
        public int ApplicationVersion = 0;
        public String MachineName = "";
        public String MachineID = "";
        public String SessionID = "";
        public String EndAddress = "";
        public String UserID = "";
        public String UserName = "";
        public int UTCOffset = 0;
        public String Description = "";
        public String SiteCredentials = "";
        public String LicenseID = "";
        public String RemoteIP = "";

        public void Clear()
        {
            try
            {
                read_buffer = new StringBuilder();
                ClearBytes();
            }
            catch { }
        }

        public void ClearBytes()
        {
            Array.Clear(byte_buffer, 0, byte_buffer.Length);
        }

        public virtual void SetStatus(String s)
        {
            Debug.WriteLine(s);

            if (GotStatus != null)
                GotStatus(this, s);
        }

        public void InitReading()
        {
            byte_buffer = new Byte[BufferSize];
            read_buffer = new StringBuilder();
        }

        public void ContinueReading()
        {
            TheSocket.BeginReceive(byte_buffer, 0, TieEnd.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), this);
        }

        public void ReadLoopOnThread()
        {
            
            KillThread();
            InitReading();
            
            //c.xThread = new Thread(new ParameterizedThreadStart(ReadOnThread));
            xThread = new Thread(new ThreadStart(ReadLoop));
            xThread.SetApartmentState(ApartmentState.STA);
            xThread.Start();
            //c.xThread.Start(c);
            //ReadOnThread(c);
        }

        public void ReadLoop()
        {
            try
            {
                SetStatus("Entering read loop...");
                allDone = new ManualResetEvent(false);
                while (true)
                {
                    allDone.Reset();

                    if (allDone == null)
                        break;

                    ClearBytes();
                    TheSocket.BeginReceive(byte_buffer, 0, TieEnd.BufferSize, SocketFlags.None, new AsyncCallback(ReadCallback), this);
                    
                    allDone.WaitOne();

                    if (allDone == null)
                        break;
                }
            }
            catch(Exception ex)
            {
                SetStatus("ReadLoop Error: " + ex.Message);
            }
            SetStatus("Leaving read loop...");
            allDone = null;
        }

        public void KillThread()
        {
            if (xThread == null)
                return;

            try
            {
                xThread.Abort();
                xThread = null;
            }
            catch { }
        }

        public void ReadCallback(IAsyncResult ar)
        {
            TieEnd c = (TieEnd)ar.AsyncState;
            try
            {
                int bytesRead = c.TheSocket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    String r = Encoding.ASCII.GetString(c.byte_buffer, 0, bytesRead);
                    c.ClearBytes();

                    c.read_buffer.Append(r);

                    if (TrackTraffic)
                        ReceiveLog.Append(r);

                    ArrayList commands = new ArrayList();
                    int err = 0;
                    String remaining = ParseCommands(c.read_buffer.ToString(), commands, ref err);
                    StreamErrors += err;
                    c.read_buffer = new StringBuilder(remaining); 

                    foreach(String content in commands)
                    {
                        switch(content)
                        {
                            case "ping":
                                Debug.WriteLine("Got ping");
                                c.GotPing();
                                break;
                            case "pong":
                                Debug.WriteLine("Got pong");
                                c.GotPong();
                                break;
                            default:
                                Debug.WriteLine("Got " + content);
                                LastPing = DateTime.Now;
                                TieMessage xMessage = new TieMessage(content);
                                FireGotMessageEvent(xMessage);
                                c.ProcessMessage(xMessage);
                                break;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                SetStatus("ReadCallback Error: " + ex.Message);
                c.ClearBytes();
            }

            try
            {
                allDone.Set();
            }
            catch { }
        }

        public bool IsCurrentJobID(String strID)
        {
            if (CurrentJob == null)
                return false;

            if (!Tools.Strings.StrExt(strID))
                return false;

            if (CurrentJob.UniqueID == strID)
                return true;
            else
                return false;
        }

        public virtual void GotHello(TieMessage m)
        {
            SetStatus("Got Hello: " + m.XMLData);
        }

        public virtual void ProcessMessage(TieMessage m)
        {
            try
            {
                if (!m.FullyParsed)
                    m.FullyParse(Password);

                if (m.IsHello)
                    GotHello(m);
                else
                {
                    if (IsCurrentJobID(m.JobID))
                        CurrentJob.GotMessage(m);
                    else
                    {
                        TieJob j = GetRunningJob(m.JobID);
                        if (j != null)
                        {
                            j.GotMessage(m);
                            return;
                        }

                        j = GetJobRequestHandlerByFunction(m.FunctionName);
                        if (j == null)
                            GotMessage(m);
                        else
                        {
                            j.TargetSession = m.FromSession;
                            j.UniqueID = m.JobID;
                            AddRunningJob(j);
                            j.GotMessage(m);
                        }
                    }
                }
            }
            catch { }

            //SetStatus("Got Message: " + m.XMLData); what was i thinking?
        }

        public Dictionary<String, TieJob> RunningJobs = new Dictionary<string,TieJob>();

        public TieJob GetRunningJob(String strJobID)
        {
            TieJob j = null;
            lock (RunningJobs)
            {
                try
                {
                    j = RunningJobs[strJobID];
                }
                catch { }
            }
            return j;
        }

        public virtual void AddRunningJob(TieJob j)
        {
            lock (RunningJobs)
            {
                RunningJobs.Add(j.UniqueID, j);
            }

            if (JobStatusChanged != null)
                JobStatusChanged();
        }


        public virtual void RemoveRunningJob(TieJob j)
        {
            lock (RunningJobs)
            {
                RunningJobs.Remove(j.UniqueID);
            }

            if (JobStatusChanged != null)
                JobStatusChanged();
        }

        public void ClearCompletedRunningJobs()
        {
            lock (RunningJobs)
            {
                ArrayList r = new ArrayList();
                foreach (KeyValuePair<String, TieJob> k in RunningJobs)
                {
                    if (k.Value.Completed)
                        r.Add(k.Value.UniqueID);
                }

                foreach (String s in r)
                {
                    RunningJobs.Remove(s);
                }

                if (r.Count > 0)
                {
                    if (JobStatusChanged != null)
                        JobStatusChanged();
                }
            }
        }

        public virtual void GotMessage(TieMessage m)
        {
            //SetStatus("Got Message: " + m.XMLData);
        }

        public void SendPing()
        {
            //Send("ping");
            if (!Sending)
            {
                PingCount++;
                PingTrace = "Sent ping " + PingCount.ToString();
                LastPingSent = DateTime.Now;

                SendAsync("ping");

                //this never was live; i think it has to be async or then 1 delayed send will delay all pings to the other connections
                //if (Send("ping"))
                //{
                //    PingCount++;
                //    PingTrace = "Sent ping " + PingCount.ToString();
                //    LastPingSent = DateTime.Now;
                //}
                //else
                //{
                //    PingTrace = "Ping send failed";
                //}
            }
            else
            {
                PingTrace = "Skipped ping";
                SetStatus("Got Virtual Pong");
                LastPing = DateTime.Now;
            }
        }

        public virtual void GotPing()
        {
            SetStatus("Got Ping");
            Status = "Got Ping";
            LastPing = DateTime.Now;
            Send("pong");
        }

        public virtual void GotPong()
        {
            SetStatus("Got Pong");
            LastPing = DateTime.Now;
        }

        public bool Send(TieMessage m)
        {
            if( SendEncrypted )
                return Send(m.GetWrappedXml(Password));
            else
                return Send(m.GetWrappedXml());
        }

        public bool SendClear(TieMessage m)
        {
            return Send(m.GetWrappedXml());
        }

        public bool Send(String data)
        {
            if (Send(Encoding.ASCII.GetBytes(data)))
            {
                if (TrackTraffic)
                    SendLog.Append(data);

                return true;
            }
            else
                return false;
        }

        public bool Send(Byte[] byteData)
        {
            try
            {
                lock (TheSocket)
                {
                    Sending = true;
                    try
                    {
                        TheSocket.Send(byteData, 0, byteData.Length, SocketFlags.None);
                    }
                    catch
                    {
                        Sending = false;
                        return false;
                    }
                    Sending = false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void SendAsync(TieMessage m)
        {
            if( SendEncrypted )
                SendAsync(m.GetWrappedXml(Password));
            else
                SendAsync(m.GetWrappedXml());
        }

        public void SendAsync(String data)
        {
            try
            {
                //SetStatus("Async sending " + data);
                Byte[] byteData = Encoding.ASCII.GetBytes(data);
                lock (TheSocket)
                {
                    TheSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(SendCallback), this);
                }
                if (TrackTraffic)
                    SendLog.Append(data);
            }
            catch (Exception ex)
            {
                SetStatus("Send async error: " + ex.Message);
            }
        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                TieEnd te = (TieEnd)ar.AsyncState;
                int bytesSent = te.TheSocket.EndSend(ar);
            }
            catch (Exception e)
            {
                PingTrace = "Error in SendCallback: " + e.Message;
                SetStatus("Error in SendCallback: " + e.Message);
            }
        }

        public virtual TieJob GetJobRequestHandlerByFunction(String strFunction)
        {
            switch (strFunction)
            {
                case "echo_request":
                    return new Job_EchoTest(this);
                case "dos_command_request":
                    return new Job_DosCommand(this);
                case "open_vnc_request":
                    return new Job_OpenVNC(this);
                case "drives_request":
                case "files_request":
                case "registry_section_request":
                    return new Job_Files(this);
                case "send_file":
                case "transfer_file":
                    return new Job_TxFile(this);
                case "update_originals_request":
                    return new Job_UpdateOriginals(this);
                case "file_action_request":
                case "registry_action_request":
                    return new Job_FileAction(this);
                case "open_sql_request":
                    return new Job_SQL(this);
                case "clipboard_request":
                    return new Job_Clipboard(this);
                case "command_session_request":
                    return new Job_Command(this);
                case "stream_request":
                    return new Job_Stream(this);
                case "eternal_check_request":
                    return new Job_EternalCheck(this);
                default:
                    return null;
            }
        }

        public String GetSessionFrom()
        {
            if (ServerEnd)
                return "root";
            else
                return SessionID;
        }

        public bool SendDisconnect()
        {
            return Send(new TieMessage(GetSessionFrom(), "goodbye", ""));
        }

        public virtual void Close()
        {
            try
            {
                SetStatus("Closing...");
                TheSocket.Shutdown(SocketShutdown.Both);
                TheSocket.Close();
                try
                {
                    allDone.Set();
                    allDone.Close();
                    allDone = null;
                }
                catch { }
                SetStatus("Closed.");
            }
            catch (Exception)
            { }

            try
            {
                if (xThread != null)
                {
                    xThread.Abort();
                    xThread = null;
                }
            }
            catch
            {}
        }

        public virtual void GoodByeAndClose()
        {
            try
            {
                SendGoodbye();
            }
            catch { }

            Close();
        }

        public void SendGoodbye()
        {
            Send(new TieMessage(GetSessionFrom(), "goodbye", ""));
            Close();
        }

        public static String ParseCommands(String strAll, ArrayList commands, ref int errors)
        {
            //has to handle pingdsfhsakjdfhaslkfh<begin_message>asjkdhadkjhqkh<end_message>aldj<begin_message>lodjhqld<end_message><begin_message><end_message>34987kj<begin_message>kljhkhlh...
            String ret = StripPings(strAll, commands);

            if (ret == "")
                return "";
            
            //break it up by <begin_message>
            int i = ret.IndexOf("<begin_message>");
            if (i == -1) //has no beginning
            {
                errors++;
                return "";
            }

            int j = ret.IndexOf("<end_message>");

            if (j > -1 && j < i)
            {
                //missed a partial message
                errors++;
                ret = ret.Substring(j + 13);
                i = strAll.IndexOf("<begin_message>");
                if (i == -1) //has no beginning
                    return "";

                j = ret.IndexOf("<end_message>");
            }

            while (j > -1)
            {
                String m = ret.Substring(15 + i, j - (15 + i));
                commands.Add(m);
                if (ret.Length > (j + 13))
                    ret = ret.Substring(j + 13);
                else
                    ret = "";

                if (ret == "")
                    return "";

                ret = StripPings(ret, commands);

                if (ret == "")
                    return "";

                i = ret.IndexOf("<begin_message>");
                if (i == -1) //has no beginning
                {
                    errors++;
                    return "";
                }

                j = ret.IndexOf("<end_message>");

                if (j > -1 && j < i)
                {
                    //missed a partial message
                    ret = ret.Substring(j + 13);
                    i = ret.IndexOf("<begin_message>");
                    if (i == -1) //has no beginning
                    {
                        errors++;
                        return "";
                    }

                    j = ret.IndexOf("<end_message>");
                }
            }
            return ret;
        }

        public static String StripPings(String strAll, ArrayList commands)
        {
            String strRet = strAll;
            while(strRet.StartsWith("ping") || strRet.StartsWith("pong"))
            {
                commands.Add(strRet.Substring(0, 4));
                strRet = strRet.Substring(4);
            }
            return strRet;
        }

        public virtual String GetSummaryName()
        {
            return MachineName + " [ " + ApplicationName + " " + ApplicationVersion.ToString() + " ] Session: " + SessionID;
        }

        public virtual String GetSummaryXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("SessionID", SessionID));
            sb.Append(Tools.Xml.BuildXmlProp("ApplicationName", ApplicationName));
            sb.Append(Tools.Xml.BuildXmlProp("ApplicationVersion", ApplicationVersion.ToString()));
            sb.Append(Tools.Xml.BuildXmlProp("MachineName", MachineName));
            sb.Append(Tools.Xml.BuildXmlProp("MachineID", MachineID));
            sb.Append(Tools.Xml.BuildXmlProp("UserName", UserName));
            sb.Append(Tools.Xml.BuildXmlProp("UserID", UserID));
            sb.Append(Tools.Xml.BuildXmlProp("EndAddress", EndAddress));
            sb.Append(Tools.Xml.BuildXmlProp("UTCOffset", GetUTCOffset()));
            sb.Append(Tools.Xml.BuildXmlProp("IsManager", IsManager));
            sb.Append(Tools.Xml.BuildXmlProp("Description", Description));
            sb.Append(Tools.Xml.BuildXmlProp("SiteCredentials", SiteCredentials));
            sb.Append(Tools.Xml.BuildXmlProp("LicenseID", LicenseID));
            sb.Append(Tools.Xml.BuildXmlProp("RemoteIP", RemoteIP));

            sb.Append(Tools.Xml.BuildXmlProp("AllowRemoteView", AllowRemoteView));
            sb.Append(Tools.Xml.BuildXmlProp("AllowFileView", AllowFileView));
            sb.Append(Tools.Xml.BuildXmlProp("AllowSQLView", AllowSQLView));
            sb.Append(Tools.Xml.BuildXmlProp("AllowClipView", AllowClipView));
            sb.Append(Tools.Xml.BuildXmlProp("AllowCommandView", AllowCommandView));
            sb.Append(Tools.Xml.BuildXmlProp("AllowUserView", AllowUserView));

            //sb.Append(Tools.Xml.BuildXmlProp("", ));

            return sb.ToString();
        }

        public int GetUTCOffset()
        {
            TimeSpan t = DateTime.UtcNow.Subtract(DateTime.Now);
            return Convert.ToInt32(t.TotalHours);
        }

        public void AbsorbSummaryXml(XmlNode n)
        {
            SessionID = Tools.Xml.ReadXmlProp(n, "SessionID");
            ApplicationName = Tools.Xml.ReadXmlProp(n, "ApplicationName");
            try
            {
                ApplicationVersion = Int32.Parse(Tools.Xml.ReadXmlProp(n, "ApplicationVersion"));
            }
            catch { }

            MachineName = Tools.Xml.ReadXmlProp(n, "MachineName");
            MachineID = Tools.Xml.ReadXmlProp(n, "MachineID");
            EndAddress = Tools.Xml.ReadXmlProp(n, "EndAddress");
            UserName = Tools.Xml.ReadXmlProp(n, "UserName");
            UserID = Tools.Xml.ReadXmlProp(n, "UserID");
            UTCOffset = Tools.Xml.ReadXmlProp_Integer(n, "UTCOffset");
            IsManager = Tools.Xml.ReadXmlProp_Boolean(n, "IsManager");
            Description = Tools.Xml.ReadXmlProp(n, "Description");
            SiteCredentials = Tools.Xml.ReadXmlProp(n, "SiteCredentials");
            LicenseID = Tools.Xml.ReadXmlProp(n, "LicenseID");
            
            String rip = Tools.Xml.ReadXmlProp(n, "RemoteIP");
            if (Tools.Strings.StrExt(rip))
                RemoteIP = rip;

            AllowRemoteView = Tools.Xml.ReadXmlProp_Boolean(n, "AllowRemoteView", true);
            AllowFileView = Tools.Xml.ReadXmlProp_Boolean(n, "AllowFileView", true);
            AllowSQLView = Tools.Xml.ReadXmlProp_Boolean(n, "AllowSQLView", true);
            AllowClipView = Tools.Xml.ReadXmlProp_Boolean(n, "AllowClipView", true);
            AllowCommandView = Tools.Xml.ReadXmlProp_Boolean(n, "AllowCommandView", true);
            AllowUserView = Tools.Xml.ReadXmlProp_Boolean(n, "AllowUserView", true);
        }

        public bool IsConnected()
        {
            String s = "";
            return IsConnected(ref s);
        }

        public virtual bool IsConnected(ref String s)
        {
            if (TheSocket == null)
            {
                s = "Socket is null";
                return false;
            }

            if (!TheSocket.Connected)
            {
                s = "The socket knows its not connected";
                return false;
            }

            TimeSpan t = DateTime.Now.Subtract(LastPing);
            if (t.TotalSeconds > (TieEnd.PingSeconds * 2))
            {
                s = "Lag limit passed: " + t.TotalSeconds.ToString();
                return false;
            }

            return true;
        }

        //job stuff
        public Queue JobsToDo = new Queue();
        public TieJob CurrentJob = null;
        public Queue JobsDone = new Queue();

        public void CheckJobs()
        {
            if (CurrentJob == null)
            {
                if (JobsToDo.Count <= 0)
                    return;

                lock (JobsToDo.SyncRoot)
                {
                    CurrentJob = (TieJob)JobsToDo.Dequeue();
                }

                CurrentJob.JobFinished += new JobStatusHandler(CurrentJob_JobFinished);
                CurrentJob.JobLogAdded += new JobLogAddedHandler(CurrentJob_JobLogAdded);
                CurrentJob.DoOnOwnThread();

                if (JobStarted != null)
                    JobStarted(CurrentJob);

                if (JobStatusChanged != null)
                    JobStatusChanged();
            }
            else
            {
                if (CurrentJob.Completed)
                {
                    FinishCurrentJob(false);
                    CheckJobs();
                }
                else //check for timeout
                {
                    if (CurrentJob.Overdue)
                    {
                        TieJob j = FinishCurrentJob(true);
                        CheckJobs();
                    }
                }
            }
        }

        void CurrentJob_JobLogAdded(TieJob job, String log, JobLogType type)
        {
            if (JobLogAdded != null)
                JobLogAdded(job, log, type);
        }

        void CurrentJob_JobFinished(TieJob job)
        {
            FinishCurrentJob(false);
        }

        public TieJob FinishCurrentJob(bool force_cancel)
        {
            TieJob j = CurrentJob;
            CurrentJob = null;

            lock (JobsDone.SyncRoot)
            {
                JobsDone.Enqueue(j);
            }

            j.JobFinished -= new JobStatusHandler(CurrentJob_JobFinished);
            j.JobLogAdded -= new JobLogAddedHandler(CurrentJob_JobLogAdded);

            if (force_cancel)
            {
                j.Cancel();
                j.ResultStatus = "Timed Out.";
                j.Success = false;
            

            }

            if (JobFinished != null)
               JobFinished(j);

            if (JobStatusChanged != null)
                JobStatusChanged();

            return j;
        }

        public void AddJob(TieJob j)
        {
            lock (JobsToDo.SyncRoot)
            {
                JobsToDo.Enqueue(j);
            }
            
            if (JobStatusChanged != null)
                JobStatusChanged();
        }

        public void ClearDone()
        {
            JobsDone.Clear();

            if (JobStatusChanged != null)
                JobStatusChanged();
        }

        public void ShowTraffic()
        {
            Tools.FileSystem.PopText("Send:\r\n\r\n" + SendLog.ToString());
            System.Threading.Thread.Sleep(1000);
            Tools.FileSystem.PopText("Receive:\r\n\r\n" + ReceiveLog.ToString());
        }

        public virtual String GetFilesFolder()
        {
            return TieEnd.GetLocalFilesFolder();
        }

        public event JobStatusHandler JobStarted;
        public event JobStatusHandler JobFinished;
        public event JobStatusChangeHandler JobStatusChanged;
        public event JobLogAddedHandler JobLogAdded;

    }
}
