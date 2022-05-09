using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Threading;
using Tools;

namespace Tie
{
    public delegate void JobStatusHandler(TieJob job);
    public delegate void JobStatusChangeHandler();
    public delegate void JobLogAddedHandler(TieJob job, String log, JobLogType type);

    public delegate void JobGotStatusHandler(TieJob j, String status);
    public delegate void JobGotProgressHandler(TieJob j, int progress);

    public enum JobLogType
    {
        Neutral = 0,
        Positive = 1,
        Negative = 2,
        Info = 3
    }

    public class TieJob
    {
        public event JobStatusHandler JobFinished;
        public event JobLogAddedHandler JobLogAdded;
        public event GotMessageHandler GotMessageEvent;

        public event JobGotStatusHandler GotStatus;
        public event JobGotProgressHandler GotProgress;


        public String UniqueID = Tools.Strings.GetNewID();
        public String Name = "";
        public bool Completed = false;
        public bool Success = false;
        public bool Cancelled = false;
        public String ResultStatus = "";
        public StringBuilder JobLog = new StringBuilder();
        public DateTime StartTime;
        public int Timeout = 20;
        public String TargetSession = "";
        public bool Started = false;

        public Thread xThread;
        public TieEnd xEnd;

        public ITieStatus StatusTarget;

        public TieJob(TieEnd e)
        {
            xEnd = e; //this is needed so that messages can have the right fromsessionid
        }

        public void FireJobFinishedEvent()
        {
            if (JobFinished != null)
                JobFinished(this);
        }

        public bool Overdue
        {
            get
            {
                TimeSpan t = DateTime.Now.Subtract(StartTime);
                return t.TotalSeconds > Timeout;
            }
        }

        public virtual void Cancel()
        {
            Cancelled = true;
            Success = false;
            Completed = true;
            AddLog("Cancelling...");
            KillThread();
        }

        public void KillThread()
        {
            try
            {
                if (xThread != null)
                {
                    xThread.Abort();
                    xThread = null;
                }

            }
            catch { }
        }

        public void DoOnOwnThread()
        {
            KillThread();
            xThread = new Thread(new ThreadStart(DoOnThread));
            xThread.SetApartmentState(ApartmentState.STA);
            xThread.Start();
        }

        public void DoOnThread()
        {
            Do();  //can you make a threadstart to an overridden function and have it run the override?
        }

        public virtual void BeforeDo()
        {
            StartTime = DateTime.Now;
            Cancelled = false;
            Completed = false;
            Started = true;
            AddLog("Starting " + Name + "...");
        }

        public int ElapsedSeconds
        {
            get
            {
                if (!Tools.Dates.DateExists(StartTime))
                    return 0;

                TimeSpan t = DateTime.Now.Subtract(StartTime);
                return Convert.ToInt32(t.TotalSeconds);
            }
        }

        public virtual void AfterDo()
        {
            AddLog("Done.");

            if (Success)
                AddPositive(Name + " completed in " + Tools.Dates.FormatHMS(ElapsedSeconds));
            else
                AddNegative(Name + " failed: " + ResultStatus);

            //notify the other end
            TieMessage m = new TieMessage(xEnd.GetSessionFrom(), "job_done", TargetSession);
            Send(m);

            Completed = true;
            FireJobFinishedEvent();
        }

        public void SendGenericError(String s)
        {
            TieMessage m = new TieMessage(xEnd.GetSessionFrom(), "generic_error", TargetSession);
            m.ContentString = Tools.Xml.BuildXmlProp("error_message", s);
            Send(m);
            AddNegative("Send error message: " + s);
        }

        public virtual void AfterRunningDo()
        {
            AddLog("Done.");

            //notify the other end
            TieMessage m = new TieMessage(xEnd.GetSessionFrom(), "job_done", TargetSession);
            Send(m);

            Completed = true;

            xEnd.ClearCompletedRunningJobs();
        }

        public virtual void Do()
        {
            BeforeDo();

            AddLog("Test 1...");
            Thread.Sleep(1000);

            AddLog("Test 2...");
            Thread.Sleep(1000);

            AddLog("Test 3...");
            Thread.Sleep(1000);

            AddLog("Test 4...");
            Thread.Sleep(1000);

            ResultStatus = "All set.";
            Success = true;

            AfterDo();
        }

        public void AddLog(String strLog)
        {
            AddLog(strLog, JobLogType.Neutral);
        }

        public void AddLog(String strLog, JobLogType type)
        {
            JobLog.AppendLine(DateTime.Now.ToString() + " : " + strLog);
            if (JobLogAdded != null)
                JobLogAdded(this, strLog, type);
        }

        public virtual void GotMessage(TieMessage m)
        {
            switch (m.FunctionName.ToLower().Trim())
            {
                case "job_done":
                    Completed = true;
                    xEnd.ClearCompletedRunningJobs();
                    break;
                case "generic_error":
                    String error = Tools.Xml.ReadXmlProp(m.ContentNode, "error_message");
                    AddNegative("Generic Error: " + error);
                    Success = false;
                    Completed = true;
                    AfterDo();
                    break;
                case "status_message":
                    String strMessage = Tools.Xml.ReadXmlProp(m.ContentNode, "message_text");
                    if (GotStatus != null)
                        GotStatus(this, strMessage);
                    break;
                case "progress_message":
                    int i = Tools.Xml.ReadXmlProp_Integer(m.ContentNode, "progress_value");
                    if (GotProgress != null)
                        GotProgress(this, i);
                    break;
                default:
                    AddLog("Got Message: " + m.FunctionName);
                    break;
            }
        }

        public bool Send(TieMessage m)
        {
            m.JobID = UniqueID;
            m.ToSession = TargetSession;
            return xEnd.Send(m);
        }

        public TieMessage GetReply(TieMessage m)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "", m.FromSession);
            return reply;
        }

        public TieMessage GetReply()
        {
            return new TieMessage(xEnd.GetSessionFrom(), "", TargetSession);
        }

        public void FireGotMessageEvent(TieMessage m)
        {
            if (GotMessageEvent != null)
                GotMessageEvent(m);
        }

        public String TranslateFileName(String s)
        {
            s = Tools.Files.TranslateFileName(s);
            s = s.Replace("|desktop_wallpaper|", GetDesktopWallpaperFile());
            s = s.Replace("|tie_files|", xEnd.GetFilesFolder());
            return s;
        }


        static String GetDesktopWallpaperFile()
        {
            try
            {
                //HKEY_CURRENT_USER\Control Panel\Desktop\Wallpaper
                Microsoft.Win32.RegistryKey ckey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);
                String s = ckey.GetValue("Wallpaper").ToString();
                if (!File.Exists(s))
                    return "";
                return s;
            }
            catch { return ""; }
        }

        public void AddPositive(String s)
        {
            AddLog(s, JobLogType.Positive);
            if (StatusTarget != null)
                StatusTarget.AddPositive(s);
        }

        public void AddNegative(String s)
        {
            AddLog(s, JobLogType.Negative);
            if (StatusTarget != null)
                StatusTarget.AddNegative(s);
        }

        public void AddNeutral(String s)
        {
            AddLog(s, JobLogType.Neutral);
            if (StatusTarget != null)
                StatusTarget.AddNeutral(s);
        }

        public void AddInfo(String s)
        {
            AddLog(s, JobLogType.Info);
            if (StatusTarget != null)
                StatusTarget.AddInfo(s);
        }

        public TieMessage GetNewMessage(String strFunction)
        {
            TieMessage t = new TieMessage(xEnd.GetSessionFrom(), strFunction, TargetSession);
            t.JobID = this.UniqueID;
            return t;
        }

        public bool SimpleReply(String strFunction, String strContentName, String strContentValue)
        {
            TieMessage reply = GetReply();
            reply.FunctionName = strFunction;
            reply.ContentString = Tools.Xml.BuildXmlProp(strContentName, strContentValue);
            return Send(reply);
        }

        public void SendStatus(String s)
        {
            SimpleReply("status_message", "message_text", s);
        }

        public void SendProgress(int progress)
        {
            SimpleReply("progress_message", "progress_value", progress.ToString());
        }
    }
}
