using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;

using NewMethodx;

namespace Tie
{
    public delegate void GotSessionTextHandler(Job_Command job, String text);

    public class Job_Command : TieJob
    {
        public event GotSessionTextHandler GotSessionText;

        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        Process xProcess;
        StreamReader OutStream;
        StreamWriter InStream;
        Thread ReadThread;
        Queue ReadQueue;
        Timer ReadTimer;

        public String OriginalName = "";
        public String NewName = "";
        public String ActionType = "";

        public String ControllingSession = "";

        public Job_Command(TieEnd e)
            : base(e)
        {
            Name = "Command";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();
                StartSession();
            }
            catch (Exception)
            { }
        }

        private void StartSession()
        {
            OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "command_session_request", TargetSession);
            OriginalMessage.JobID = this.UniqueID;

            AddLog("Sending " + ActionType + " request...");
            Send(OriginalMessage);
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                switch (m.FunctionName)
                {
                    case "command_session_request":

                        ControllingSession = m.FromSession;

                        if (xProcess != null)
                        {
                            CloseProcess();
                        }

                        xProcess = new Process();
                        xProcess.StartInfo.RedirectStandardOutput = true;
                        xProcess.StartInfo.RedirectStandardInput = true;
                        xProcess.StartInfo.CreateNoWindow = true;
                        xProcess.StartInfo.UseShellExecute = false;
                        xProcess.StartInfo.FileName = "cmd.exe";
                        xProcess.Start();

                        OutStream = xProcess.StandardOutput;
                        InStream = xProcess.StandardInput;
                        InStream.AutoFlush = true;

                        //xProcess.WaitForInputIdle();

                        ReadQueue = new Queue();
                        ReadTimer = new Timer(new TimerCallback(ReadTime));
                        //ReadTimer.Change(500, 500);

                        ReadThread = new Thread(new ThreadStart(ReadOnThread));
                        ReadThread.SetApartmentState(ApartmentState.STA);
                        ReadThread.Start();

                        break;
                    case "add_command":
                        AddCommand(m);
                        break;
                    case "close_session":
                        CloseProcess();
                        TieMessage reply = GetReply(m);
                        reply.FunctionName = "session_closed";
                        Send(reply);
                        break;
                    case "session_closed":
                        if (GotSessionText != null)
                        {
                            GotSessionText(this, "The session was unexpectedly closed.  To continue, please reopen the session.");
                            AddNegative("The session was unexpectedly closed.  To continue, please reopen the session.");
                        }
                        break;
                    case "session_status":
                        String s = Tools.Xml.ReadXmlProp(m.ContentNode, "session_text");
                        if (GotSessionText != null)
                            GotSessionText(this, s);
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("File Action Error: " + ex.Message);
            }
        }

        void AddRead(String s)
        {
            lock (ReadQueue.SyncRoot)
            {
                ReadQueue.Enqueue(s);
            }
            ReadTimer.Change(500, 500); //bump back the timer
        }

        void ReadTime(Object x)
        {
            ArrayList a = new ArrayList();
            lock (ReadQueue.SyncRoot)
            {
                ReadTimer.Change(-1, -1);
                while (ReadQueue.Count > 0)
                {
                    a.Add(ReadQueue.Dequeue());
                }
            }

            StringBuilder sb = new StringBuilder();
            foreach (String s in a)
            {
                sb.Append(s);
            }

            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "session_status", TargetSession);
            reply.ContentString = Tools.Xml.BuildXmlProp("session_text", sb.ToString());
            reply.JobID = this.UniqueID;
            reply.ToSession = ControllingSession;
            xEnd.Send(reply);
        }

        void ReadOnThread()
        {
            while (true)
            {
                char[] b = new char[1];
                Array.Clear(b, 0, 1);
                OutStream.ReadBlock(b, 0, 1);
                String s = new String(b);
                AddRead(s);

                if (OutStream.EndOfStream)
                {
                    //this happens when an error occurrs, for some reason
                    TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "session_closed", TargetSession);
                    reply.JobID = this.UniqueID;
                    reply.ToSession = ControllingSession;
                    xEnd.Send(reply);
                    return;
                }
            }
        }

        public void RequestClose()
        {
            Send(GetNewMessage("close_session"));
        }

        public void SendCommand(String strCommand)
        {
            TieMessage m = GetNewMessage("add_command");
            m.ContentString = Tools.Xml.BuildXmlProp("command_text", strCommand);
            Send(m);
        }

        private void CloseProcess()
        {
            try
            {
                ReadThread.Abort();
                ReadThread = null;
            }
            catch { }

            try
            {
                ReadTimer.Change(-1, -1);
                ReadTimer.Dispose();
                ReadTimer = null;
            }
            catch { }

            try
            {
                lock (ReadQueue.SyncRoot)
                {
                    ReadQueue.Clear();
                }
            }
            catch { }

            try
            {
                xProcess.Kill();
                xProcess.Close();
                xProcess.Dispose();
                xProcess = null;
            }
            catch { }


        }

        private void AddCommand(TieMessage m)
        {
            TieMessage reply = GetReply(m);
            String s = Tools.Xml.ReadXmlProp(m.ContentNode, "command_text");

            if (Tools.Strings.StrExt(s))
                InStream.WriteLine(s);
        }
    }
}



//output = "";
//System.Diagnostics.Process x = new System.Diagnostics.Process();
//x.StartInfo.FileName = strFilePath;
//x.StartInfo.Arguments = strArguments;
//x.StartInfo.RedirectStandardOutput = true;
//x.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
//x.StartInfo.UseShellExecute = false;
////if (NoWindow)
////{
//x.StartInfo.CreateNoWindow = true;
////}
//x.Start();

//string str;
//while ((str = x.StandardOutput.ReadLine()) != null)
//{
//    if (Tools.Strings.StrExt(strIgnore))
//    {
//        if( !Tools.Strings.HasString(str, strIgnore) )
//            output += str + "\r\n";
//    }
//    else
//        output += str + "\r\n";
