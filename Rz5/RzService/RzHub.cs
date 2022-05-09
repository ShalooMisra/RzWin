using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Threading;

using Tie;

namespace RzService
{
    public partial class RzHub : ServiceBase
    {
        Process EyeProcess = null;
        public int PortSetting = 2954;
        public String PasswordSetting = "rec0gnin";

        public RzHub()
        {
            InitializeComponent();

            this.EventLog.Log = "Application";

            this.CanHandlePowerEvent = false;
            this.CanHandleSessionChangeEvent = false;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            CompleteStart();
        }

        private void CompleteStart()
        {
            AddLog("");
            GetSettings();

            AddLog("Port=" + PortSetting.ToString());
            AddLog("Password=" + PasswordSetting);

            try
            {
                if (PortSetting > 0)
                {
                    StartTheHub();
                    StartHubChecking();
                }
                else
                    AddLog("Skipping the tie server.");
            }
            catch (Exception ex)
            {
                AddLog("Error in CompleteStart: " + ex.Message);
            }
        }

        void GetSettings()
        {
            AddLog("Getting settings...");
            try
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "RzServiceSettings.xml";
                if (!File.Exists(strFile))
                {
                    AddLog("No settings found.");
                    return;
                }

                System.Xml.XmlDocument d = new System.Xml.XmlDocument();
                d.Load(strFile);
                XmlNode xNode = d.SelectSingleNode("settings/setting[1]");
                PortSetting = Tools.Xml.ReadXmlProp_Integer(xNode, "listen_port");
                PasswordSetting = Tools.Xml.ReadXmlProp(xNode, "listen_password");
                d = null;
            }
            catch(Exception ex)
            {
                AddLog("Error parsing settings: " + ex.Message);
            }

            AddLog("Settings done.");
        }

        public static void AddLog(String s)
        {
            try
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "RzServiceLog.txt";
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

        protected override void OnStop()
        {
            CompleteStop();
            base.OnStop();
        }

        private void CompleteStop()
        {
            StopHubChecking();
            StopTheHub();
            AddLog("Closed");
        }

        //Hub
        Thread HubThread = null;
        public void StartHubChecking()
        {
            AddLog("Starting hub check...");
            CheckKillHubThread();

            HubThread = new Thread(HubCheckingThreadStart);
            HubThread.SetApartmentState(ApartmentState.STA);
            HubThread.Start();

            AddLog("Hub checking started.");
        }
        public void StopHubChecking()
        {
            AddLog("Stopping hub check...");
            CheckKillHubThread();
            AddLog("Hub check stopped.");
        }

        void HubCheckingThreadStart()
        {
            int wait = 60 * 1000;

            while (1 > 0)
            {
                System.Threading.Thread.Sleep(wait);
                HubCheck();
            }
        }

        void HubCheck()
        {
            try
            {
                Hook h = new Hook();
                String s = "";
                h.HostName = System.Environment.MachineName;
                h.HostPort = PortSetting;
                h.Password = PasswordSetting;
                h.UserID = "hubcheck";
                h.UserName = "system";
                h.MachineID = "hubcheckmachine";
                h.MachineName = "hubcheckmachine";

                bool b = h.Connect(ref s);

                if (b)
                    h.SendDisconnect();

                h.Close();
                h = null;

                if (!b)
                {
                    AddLog("Hub check failed: restarting");
                    RestartHub();
                }
            }
            catch { }
        }

        void RestartHub()
        {
            AddLog("Restarting the hub...");
            try
            {
                StopTheHub();
                StartTheHub();
            }
            catch (Exception ex)
            {
                AddLog("Restart error: " + ex.Message);
            }

            AddLog("Restart complete.");
        }

        void StartTheHub()
        {
            String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
            if (!strFile.EndsWith("\\"))
                strFile += "\\";
            strFile += "HubRoot.exe";

            if (!File.Exists(strFile))
            {
                AddLog("File not found: " + strFile);
                strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if (!strFile.EndsWith("\\"))
                    strFile += "\\";
                strFile += "Hubroot\\bin\\debug\\HubRoot.exe";

                if (!File.Exists(strFile))
                {
                    AddLog("Quitting: File not found: " + strFile);
                    return;
                }
            }

            String strArgs = " =" + PortSetting.ToString() + "=" + PasswordSetting;

            AddLog("Starting the hub...");
            AddLog("Filename=" + strFile);
            AddLog("Args=" + strArgs);

            EyeProcess = Process.Start(strFile, strArgs);
            AddLog("Hub started");
        }

        void StopTheHub()
        {
            AddLog("Stopping the hub...");

            try
            {
                //stop the eye and unload the appdomain
                if (EyeProcess != null)
                {
                    AddLog("Stopping the HubRoot process...");
                    EyeProcess.Kill();
                }
            }
            catch (Exception ex)
            {
                AddLog("Hub stop error: " + ex.Message);
            }

            AddLog("Hub stopped.");
        }

        void CheckKillHubThread()
        {
            try
            {
                if (HubThread == null)
                    return;

                if (HubThread.IsAlive)
                    HubThread.Abort();

                HubThread = null;
            }
            catch (Exception ex)
            {
                AddLog("Error In CheckKillHubThread: " + ex.Message);
            }
        }

        protected override void OnContinue()
        {
            CompleteStart();
            base.OnContinue();
        }

        protected override void OnPause()
        {
            CompleteStop();
            base.OnPause();
        }

        protected override void OnShutdown()
        {
            CompleteStop();
            base.OnShutdown();
        }
    }
}
