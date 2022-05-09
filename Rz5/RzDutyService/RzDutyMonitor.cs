using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.IO;

namespace RzDutyService
{
    public partial class RzDutyMonitor : ServiceBase
    {
        public RzDutyMonitor()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            DutyLogClear();

            //taking this out so that the rzchecking 15 minutes can elapse first
            //otherwise rz is trying to start before sql server is available
            //StartRz();
            AddLog("Waiting to start Rz...");
            StartRzChecking();
        }

        protected override void OnStop()
        {
            StopRzChecking();
            StopRz();
        }

        Thread RzThread = null;
        public void StartRzChecking()
        {
            AddLog("Starting Rz check...");
            CheckKillRzThread();

            RzThread = new Thread(RzCheckingThreadStart);
            RzThread.SetApartmentState(ApartmentState.STA);
            RzThread.Start();

            AddLog("Rz checking started.");
        }
        public void StopRzChecking()
        {
            AddLog("Stopping Rz check...");
            CheckKillRzThread();
            AddLog("Rz check stopped.");
        }

        void RzCheckingThreadStart()
        {
            int wait = (60 * 1000) * 15;  //wait 15 minutes

            while (1 > 0)
            {
                System.Threading.Thread.Sleep(wait);
                RzCheck();
            }
        }

        void RzCheck()
        {
            try
            {
                //connect to the database

                //check the last duty time

                bool b = true;

                if (RzProcess == null)
                {
                    b = false;
                    AddLog("RzProcess is null");
                }
                else if (RzProcess.HasExited)
                {
                    b = false;
                    AddLog("RzProcess has exited");
                }

                if (!b)
                {
                    AddLog("Rz check failed: restarting");
                    RestartRz();
                }
            }
            catch { }
        }

        void RestartRz()
        {
            AddLog("Restarting Rz...");
            try
            {
                StopRz();
                StartRz();
            }
            catch (Exception ex)
            {
                AddLog("Restart error: " + ex.Message);
            }

            AddLog("Restart complete.");
        }

        String RzPathFind()
        {
            try
            {

                String app = "Rz4";

                String folder = "";

                String specific_file = Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "RzPath.txt";
                if (File.Exists(specific_file))
                    folder = Tools.Files.OpenFileAsString(specific_file);

                if (!Directory.Exists(folder))
                    folder = @"C:\Program Files\Recognin Technologies\Rz\";
                if (!Directory.Exists(folder))
                    folder = @"C:\Program Files (x86)\Recognin Technologies\Rz\";
                if (!Directory.Exists(folder))
                    folder = @"C:\Program Files\Recognin Technologies\Rz4\";
                if (!Directory.Exists(folder))
                    folder = @"C:\Program Files (x86)\Recognin Technologies\Rz4\";

                ////legacy exec option
                //if (!Directory.Exists(folder))
                //    folder = @"C:\Program Files\Recognin Technologies\Rz\exec\";
                //if (!Directory.Exists(folder))
                //    folder = @"C:\Program Files (x86)\Recognin Technologies\Rz\exec\";
                //if (!Directory.Exists(folder))
                //    folder = @"C:\Program Files\Recognin Technologies\Rz3\exec\";
                //if (!Directory.Exists(folder))
                //    folder = @"C:\Program Files (x86)\Recognin Technologies\Rz3\exec\";


                if (!Directory.Exists(folder))
                    return "";

                //if (folder.ToLower().EndsWith("\\exec\\"))
                //    folder = Tools.Folder.ConditionFolderName(Path.GetDirectoryName(folder));  //this used to be 'GetParentDirectory' in tools; is it the same?

                ArrayList a = Versions.GetVersions(app, app, folder, false);
                if (a.Count > 0)
                {
                    a.Reverse();
                    Version v = (Version)a[0];
                    return v.FolderPath + v.ExeName;
                }
                else
                    return "";
            }
            catch (Exception ex)
            {
                AddLog("Error in RzFindPath: " + ex.Message);
                return "";
            }
        }

        Process RzProcess = null;
        bool StartRz()
        {
            try
            {
                AddLog("Starting Rz...");

                String file = RzPathFind();
                if (!File.Exists(file))
                {
                    AddLog("RzPath '" + file + "' was not found");
                    return false;
                }

                AddLog("Using RzPath: " + file);

                StopRz();
                RzProcess = new Process();
                RzProcess.StartInfo = new ProcessStartInfo(file, "-duty_monitor_unattended");
                RzProcess.Start();

                AddLog("Rz started");
                return true;
            }
            catch (Exception ex)
            {
                AddLog("Start Rz Error: " + ex.Message);
                return false;
            }
        }

        void StopRz()
        {
            try
            {
                //stop Rz
                if (RzProcess != null)
                {
                    AddLog("Stopping the Rz process...");
                    try
                    {
                        RzProcess.Kill();
                        RzProcess.Dispose();                        
                    }
                    catch { }
                    RzProcess = null;
                    AddLog("Rz stopped.");
                }
            }
            catch (Exception ex)
            {
                AddLog("Rz stop error: " + ex.Message);
            }            
        }

        void CheckKillRzThread()
        {
            try
            {
                if (RzThread == null)
                    return;

                if (RzThread.IsAlive)
                    RzThread.Abort();

                RzThread = null;
            }
            catch (Exception ex)
            {
                AddLog("Error In CheckKillRzThread: " + ex.Message);
            }
        }

        void AddLog(String s)
        {
            try
            {
                String strFile = DutyLogFile;

                if (!File.Exists(strFile))
                {
                    FileStream st = File.Create(strFile);
                    st.Close();
                    st.Dispose();
                    st = null;
                }

                StreamWriter f = new StreamWriter(strFile, true);
                f.WriteLine(DateTime.Now.ToString() + " : " + s);
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }
        }

        void DutyLogClear()
        {
            String f = DutyLogFile;
            if (File.Exists(f))
            {
                try
                {
                    File.Delete(f);
                }
                catch { }
            }
        }

        String DutyLogFile
        {
            get
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "RzDutyLog.txt";
                return strFile;
            }
        }

    }
}
