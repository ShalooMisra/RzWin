using System;
using System.Collections.Generic;
using System.Text;

using System.Xml;
using System.IO;
using System.Threading;

using NewMethodx;
using OthersCodex;
using Tie;

namespace Tie
{
    public class TieTack : Hook
    {
        public String TackName = "";
        public String RackAddress = "";
        public int RackPort = 0;

        public TieTack()
        {
            ApplicationName = "Tie";
            ApplicationVersion = 800;

            String s = Tools.Folder.GetTopLevelFolderName(Tools.FileSystem.GetAppPath());
            if (s == "Debug")
                TackName = "TestTieConnection";
            else
                TackName = TieTack.GetTackNameFromFolder(s);
        }

        public String LocalSettingsFile
        {
            get
            {
                return TieKnot.KnotRootPath + "tack_" + TackName + "\\s.dat";
            }
        }

        public override String GetFilesFolder()
        {
            String s = TieKnot.KnotRootPath + "tack_" + TackName + "\\files\\";
            if (!Directory.Exists(s))
                Directory.CreateDirectory(s);

            return s;
        }

        public String DutyFolder
        {
            get
            {
                return TieKnot.KnotRootPath + "tack_" + TackName + "\\Duties\\";
            }
        }

        public bool InitFromSettings()
        {
            return InitFromSettings(LocalSettingsFile);
        }

        public bool InitFromSettings(String strFile)
        {

            SetStatus("Initializing settings from " + strFile + "...");

            try
            {
                String xml = EncDec.Decrypt(Tools.Files.OpenFileAsString(strFile), SettingsPassword);
                XmlDocument d = new XmlDocument();
                d.LoadXml(xml);

                XmlNode n = d.SelectSingleNode("settings/setting");
                RackAddress = Tools.Xml.ReadXmlProp(n, "rack_address");
                RackPort = Tools.Xml.ReadXmlProp_Integer(n, "rack_port");
                Password = Tools.Xml.ReadXmlProp(n, "rack_password");
                SendEncrypted = Tools.Xml.ReadXmlProp_Boolean(n, "send_encrypted");

                Password = Tools.Xml.ReadXmlProp(n, "rack_password");
                
                Description = Tools.Xml.ReadXmlProp(n, "description");
                SiteCredentials = Tools.Xml.ReadXmlProp(n, "site_credentials");
                LicenseID = Tools.Xml.ReadXmlProp(n, "license_id");

                AllowRemoteView = Tools.Xml.ReadXmlProp_Boolean(n, "allow_remote_view");
                AllowFileView = Tools.Xml.ReadXmlProp_Boolean(n, "allow_file_view");
                AllowSQLView = Tools.Xml.ReadXmlProp_Boolean(n, "allow_sql_view");
                AllowClipView = Tools.Xml.ReadXmlProp_Boolean(n, "allow_clip_view");
                AllowCommandView = Tools.Xml.ReadXmlProp_Boolean(n, "allow_command_view");
                AllowUserView = Tools.Xml.ReadXmlProp_Boolean(n, "allow_user_view");

                HostName = RackAddress;
                HostPort = RackPort;
                return true;
            }
            catch(Exception ex)
            {
                RackAddress = "tie.newmethodsoftware.com";
                RackPort = 2950;
                Password = "tiepass";
                Description = "Default tie connection.";
                SendEncrypted = true;
                SetStatus("Init from settings failed : " + ex.Message);
                HostName = RackAddress;
                HostPort = RackPort;
                return false;
            }
        }

        public bool SaveSettings()
        {
            return SaveSettings(LocalSettingsFile);
        }

        public bool SaveSettings(String strFile)
        {
            try
            {
                StringBuilder sb = new StringBuilder("<?xml version=\"1.0\"?>\n");
                sb.Append("<settings><setting>\n");
                sb.Append(Tools.Xml.BuildXmlProp("rack_address", RackAddress));
                sb.Append(Tools.Xml.BuildXmlProp("rack_port", RackPort));
                sb.Append(Tools.Xml.BuildXmlProp("rack_password", Password));
                sb.Append(Tools.Xml.BuildXmlProp("send_encrypted", SendEncrypted));

                sb.Append(Tools.Xml.BuildXmlProp("description", Description));
                sb.Append(Tools.Xml.BuildXmlProp("license_id", LicenseID));
                sb.Append(Tools.Xml.BuildXmlProp("site_credentials", SiteCredentials));

                sb.Append(Tools.Xml.BuildXmlProp("allow_remote_view", AllowRemoteView));
                sb.Append(Tools.Xml.BuildXmlProp("allow_file_view", AllowFileView));
                sb.Append(Tools.Xml.BuildXmlProp("allow_sql_view", AllowSQLView));
                sb.Append(Tools.Xml.BuildXmlProp("allow_clip_view", AllowClipView));
                sb.Append(Tools.Xml.BuildXmlProp("allow_command_view", AllowCommandView));
                sb.Append(Tools.Xml.BuildXmlProp("allow_user_view", AllowUserView));

                sb.Append("</setting></settings>\n");
                Tools.Files.SaveFileAsString(strFile, EncDec.Encrypt(sb.ToString(), SettingsPassword));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetLastPing()
        {
            //drop the file that tells the service when the last connection was
            Tools.Files.SaveFileAsString(Tools.FileSystem.GetAppPath() + "last_ping.txt", LastPing.ToString());
        }

        public override void GotMessage(TieMessage m)
        {
            switch (m.FunctionName.ToLower())
            {
                case "run_latest_pin":
                    RunLatestPin();
                    StopPersistence();
                    Close();
                    ReadyToExit = true;
                    break;
                default:
                    base.GotMessage(m);
                    break;
            }
        }

        public bool RunLatestPin()
        {
            String s = Tools.FileSystem.GetAppPath() + Tools.Files.GetHighestFileName(Tools.FileSystem.GetAppPath(), "tiepin.exe");

            if (File.Exists(s))
            {
                //status = "Running " + s;
                try
                {
                    Tools.FileSystem.ShellSilently(s);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                //status = s + " was not found.";
                return false;
            }
        }

        //duties
        public void CheckDuties()
        {
            try
            {
                TimeSpan t = DateTime.Now.Subtract(LastDuties);
                if (t.TotalMinutes > 4)
                {
                    LastDuties = DateTime.Now;
                    PerformDuties(DutyFolder);
                }
            }
            catch { }
        }

        Dictionary<String, TieDuty> CurrentDuties = new Dictionary<String, TieDuty>();
        void PerformDuties(String strFolder)
        {
            List<TieDuty> remove = new List<TieDuty>();
            foreach (KeyValuePair<String, TieDuty> kvp in CurrentDuties)
            {
                TieDuty h = kvp.Value;
                if (h.IsDone)
                {
                    remove.Add(h);
                    if (!h.IsSuccessful)
                    {
                        NotifyProblem(h.Name + " Duty Failed " + TackName + " " + Description + "\r\n\r\n" + h.Status);
                        h.AddStatus(h.Name + " Duty Failed " + TackName + " " + Description);
                        h.SetNext(DateTime.Now.Add(TimeSpan.FromHours(2)));
                    }

                    h.Kill();
                }
                else
                {
                    TimeSpan t = DateTime.Now.Subtract(h.TimeStarted);
                    if (t.TotalHours > 20)
                    {
                        remove.Add(kvp.Value);
                        NotifyProblem(h.Name + " Duty Stalled " + TackName + " " + Description + "\r\n\r\n" + h.Status);
                        h.AddStatus(h.Name + " Duty Stalled " + TackName + " " + Description);
                        h.SetNext(DateTime.Now.Add(TimeSpan.FromHours(2)));
                        h.Kill();
                    }
                }
            }


            foreach (TieDuty h in remove)
            {
                CurrentDuties.Remove(h.Name.ToLower());
            }

            List<String> overdue = GetOverdueDutyFiles(strFolder);
            foreach (String s in overdue)
            {
                TieDuty h = new VaultManager(s);

                if (!h.Start())
                {
                    NotifyProblem(s + " Duty Failed To Start " + TackName + " " + Description + "\r\n\r\n" + Tools.Files.OpenFileAsString(s));
                    h.AddStatus(s + " Duty Failed To Start " + TackName + " " + Description);
                }
                else
                {
                    CurrentDuties.Add(h.Name.ToLower(), h);
                    h.TheThread = new Thread(new ParameterizedThreadStart(DutyOnThread));
                    h.TheThread.SetApartmentState(ApartmentState.STA);
                    h.TheThread.IsBackground = true;
                    h.TheThread.Start(h);
                }
            }
        }

        void DutyOnThread(Object x)
        {
            try
            {
                TieDuty h = (TieDuty)x;

                try
                {
                    h.AddStatus("Starting...");
                    h.Do();
                    h.AddStatus("Done.");
                }
                catch (Exception ex)
                {
                    h.AddStatus("RTE: " + ex.Message + "\r\n\r\n" + ex.StackTrace.ToString());
                    h.IsDone = true;
                    h.IsSuccessful = false;
                }
                //h.WriteLog();
            }
            catch { }
        }

        void NotifyProblem(String s)
        {
            
        }

        static List<String> GetOverdueDutyFiles(String strFolder)
        {
            try
            {
                if (!Directory.Exists(strFolder))
                    return new List<String>();

                List<String> ret = new List<String>();
                String[] files = Directory.GetFiles(strFolder);
                foreach (String s in files)
                {
                    DateTime d = ParseDutyDate(s);
                    if( d < DateTime.Now )
                        ret.Add(s);
                }
                return ret;
            }
            catch
            {
                return new List<String>();
            }
        }


        //static

        public static DateTime ParseDutyDate(String strFile)
        {
            try
            {
                String s = Path.GetFileNameWithoutExtension(strFile);
                s = Tools.Strings.ParseDelimit(s, "_next_run_", 2);
                String[] ary = Tools.Strings.Split(s, "_");
                return new DateTime(Int32.Parse(ary[0]), Int32.Parse(ary[1]), Int32.Parse(ary[2]), Int32.Parse(ary[3]), Int32.Parse(ary[4]), Int32.Parse(ary[5]));
            }
            catch { return Tools.Dates.GetNullDate(); }
        }


        public static String SettingsPassword = "recognin";

        public static bool TackFolderExists(String strTackName)
        {
            return Directory.Exists(GetTackFolderPath(strTackName));
        }

        public static String GetTackFolderPath(String strTackName)
        {
            return TieKnot.KnotRootPath + "tack_" + strTackName + "\\";
        }

        public static bool MakeTackFolderExist(String strTackName)
        {
            try
            {
                Directory.CreateDirectory(GetTackFolderPath(strTackName));
                return true;
            }
            catch { return false; }
        }

        public static void DeleteTackFolder(String s)
        {
            Directory.Move(TieKnot.KnotRootPath + GetTackFolderName(s), TieKnot.KnotRootPath + "deleted_" + Tools.Strings.GetNewID().Replace("-", "") + "_" + s);
        }

        public static void RenameTackFolder(String old, String newname)
        {
            Directory.Move(TieKnot.KnotRootPath + GetTackFolderName(old), TieKnot.KnotRootPath + GetTackFolderName(newname));
        }

        public static bool IsTackFolderName(String strFolder)
        {
            return strFolder.ToLower().StartsWith("tack_");
        }

        public static String GetTackNameFromFolder(String strFolder)
        {
            return Tools.Strings.Mid(strFolder, 6);
        }

        public static String GetTackFolderName(String strTackName)
        {
            return "Tack_" + strTackName;
        }
    }

    public abstract class TieDuty
    {
        public String Name = "";
        public Thread TheThread = null;
        public DateTime TimeStarted;
        public bool IsDone = false;
        public bool IsSuccessful = false;
        StringBuilder m_Status = new StringBuilder();
        public String SourceFile = "";
        public bool SourceFileIsXml
        {
            get
            {
                return SourceFile.Trim().StartsWith("<?xml");
            }
        }

        public int IdealHour = 22;  //10pm

        public TieDuty(String strFile)
        {
            SourceFile = strFile;

            if (SourceFileIsXml)
                Name = "Manual";
            else
                Name = Tools.Strings.ParseDelimit(Path.GetFileNameWithoutExtension(strFile), "_next_run_", 1);
        }


        public abstract bool InitFromXml(XmlNode n);

        public String Status
        {
            get
            {
                return m_Status.ToString();
            }
        }

        public static String LogFileName = "";
        public static void LogFileMakeExist()
        {
            LogFileName = Tools.FileSystem.GetAppPath() + "DutyLog.txt";
            if (!File.Exists(LogFileName))
                Tools.Files.SaveFileAsString(LogFileName, "Starting log " + DateTime.Now.ToString() + "\r\n");
        }
        public static void ReStartLogFile()
        {
            TieDuty.LogFileName = Tools.FileSystem.GetAppPath() + "DutyLog.txt";
            if (!Tools.Files.FileExists(TieDuty.LogFileName))
                return;
            Tools.Files.TryDeleteFile(TieDuty.LogFileName);
            TieDuty.LogFileName = "";
            LogFileMakeExist();
        }
        public void AddStatus(String s)
        {
            m_Status.AppendLine(s);
            try
            {
                if (LogFileName == "")
                    LogFileMakeExist();
                FileStream f = new FileStream(LogFileName, FileMode.Append, FileAccess.Write);
                StreamWriter w = new StreamWriter(f);
                w.WriteLine(DateTime.Now.ToString() + "  :  " + s);
                w.Close();
                w.Dispose();
                w = null;
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }
        }
        public bool Start()
        {
            if (!Parse())
                return false;
            TimeStarted = DateTime.Now;
            DateTime Next = DateTime.Now.Add(TimeSpan.FromDays(1));
            Next = new DateTime(Next.Year, Next.Month, Next.Day, IdealHour, 0, 0);
            AddStatus("Renaming to " + Next.ToString());
            return SetNext(Next);
        }

        public bool Parse()
        {
            try
            {
                XmlDocument d = new XmlDocument();
                String s = "";

                if( SourceFileIsXml )
                    s = SourceFile;
                else
                    s = Tools.Files.OpenFileAsString(SourceFile);
                
                if (!s.ToLower().StartsWith("<?xml"))
                    s = EncDec.Decrypt(s, "rec0gnin");

                d.LoadXml(s);
                XmlNode n = d.ChildNodes[1];
                XmlNode o = n.ChildNodes[0];  // d.SelectSingleNode("objects/object[0]");
                bool b = InitFromXml(o);
                d = null;
                return b;
            }
            catch (Exception ex)
            {
                AddStatus("Parse RTE: " + ex.Message);
                return false;
            }
        }

        public bool SetNext(DateTime Next)
        {
            try
            {
                if (File.Exists(SourceFile))
                {
                    File.Move(SourceFile, Tools.Folder.ConditionFolderName(Path.GetDirectoryName(SourceFile)) + Name + "_next_run_" + Next.Year.ToString() + "_" + Next.Month.ToString() + "_" + Next.Day.ToString() + "_" + Next.Hour.ToString() + "_" + Next.Minute.ToString() + "_" + Next.Second.ToString() + Path.GetExtension(SourceFile));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }

        public abstract void Do(ref bool success);

        public void Do()
        {
            bool success = true;
            Do(ref success);
            IsDone = true;
            IsSuccessful = success;
        }

        public void Kill()
        {
            try
            {
                if (TheThread != null)
                {
                    TheThread.Abort();
                    TheThread = null;
                    m_Status = null;
                }
            }
            catch { }
        }
    }
}
