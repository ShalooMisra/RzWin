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

namespace RzService
{
    public class SelfCheckingProcess
    {
        //Duty
        Thread RunThread = null;
        Thread CheckThread = null;
        public int CheckInterval = 60 * 1000 * 15;
        public String Name = "Process";
        public RzHub xHub;

        public void Start()
        {
            StartRunning();
            StartChecking();
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        public void Stop()
        {
            StopChecking();
            StopRunning();
            KillCheckThread();
            KillRunThread();

        }
        
        public void StartChecking()
        {
            AddLog("Starting " + Name + " check...");
            KillCheckThread();
            
            CheckThread = new Thread(CheckingThreadStart);
            CheckThread.SetApartmentState(ApartmentState.STA);
            CheckThread.Start();

            AddLog(Name + " checking started.");
        }

        public void StopChecking()
        {
            AddLog("Stopping " + Name + " check...");
            KillCheckThread();
            AddLog(Name + " check stopped.");
        }

        public void StartRunning()
        {
            AddLog("Starting " + Name + " run...");
            KillRunThread();

            RunThread = new Thread(RunningThreadStart);
            RunThread.SetApartmentState(ApartmentState.STA);
            RunThread.Start();

            AddLog(Name + " checking started.");
        }

        public void StopRunning()
        {
            AddLog("Stopping " + Name + " run...");
            KillRunThread();
            AddLog(Name + " run stopped.");
        }

        void CheckingThreadStart()
        {
            while (1 > 0)
            {
                System.Threading.Thread.Sleep(CheckInterval);
                RunTheCheck();
            }
        }

        void RunTheCheck()
        {
            try
            {
                if (!CheckPasses())
                {
                    AddLog(Name + " check failed: restarting");
                    Restart();
                }
            }
            catch { }
        }

        public virtual bool CheckPasses()
        {
            return false;
        }

        void KillCheckThread()
        {
            try
            {
                if (CheckThread == null)
                    return;

                if (CheckThread.IsAlive)
                    CheckThread.Abort();

                CheckThread = null;
            }
            catch (Exception ex)
            {
                AddLog("Error in killing check thread for " + Name + ": " + ex.Message);
            }
        }

        void KillRunThread()
        {
            try
            {
                if (RunThread == null)
                    return;

                if (RunThread.IsAlive)
                    RunThread.Abort();

                RunThread = null;
            }
            catch (Exception ex)
            {
                AddLog("Error in killing run thread for " + Name + ": " + ex.Message);
            }
        }

        void RunningThreadStart()
        {
            AddLog("Running " + Name);
            try
            {
                RunTheProcess();
            }
            catch
            {

            }
        }

        public virtual void RunTheProcess()
        {
            AddLog("Override RunTheProcess.");
        }

        public void AddLog(String s)
        {
            RzHub.AddLog(s);
        }

    }


    public class SelfCheckingDuty : SelfCheckingProcess
    {
        public NewMethodx.nData xData;
        public SelfCheckingDuty() : base()
        {
            Name = "DutyMonitor";
        }

        public override bool CheckPasses()
        {
            if (!xData.CanConnect())
            {
                return false;
            }

            DateTime dtLast = xData.GetScalar_Date("select max(setting_value) from n_set where name = 'last_duty_run'");
            if (dtLast.Year < 1902)
                return false;

            TimeSpan t = System.DateTime.Now.Subtract(dtLast);
            if (t.TotalMinutes > 10)
            {
                return false;
            }
            return true;
        }

        public override void RunTheProcess()
        {
            AddLog("Running " + Name + "...");

            String s = "";
            //String strFile = Tools.Folder.ConditionFolderName(xHub.RzDllPath) + NewMethodx.nTools.GetHighestFileName(xHub.RzDllPath, xHub.RzDllName);
            String strFile = Tools.Folder.ConditionFolderName(xHub.RzDllPath) + xHub.RzDllName;

            AddLog("Trying file " + strFile);

            if (!File.Exists(strFile))
            {
                AddLog("File not found: " + strFile);
                return;
            }

            Assembly a = Assembly.LoadFrom(strFile);
            if (a == null)
            {
                AddLog("Assembly " + strFile + " is null");
                return;
            }

            Type t = null;
            foreach (Type tx in a.GetTypes())
            {
                if (tx.FullName == xHub.RzDllType)
                    t = tx;
            }

            if (t == null)
            {
                AddLog("Type " + xHub.RzDllType + " is null");
                return;
            }

            Object x = a.CreateInstance(xHub.RzDllType);
            if (x == null)
            {
                AddLog("Instance type " + xHub.RzDllType + " is null");
                return;
            }

            MethodInfo m = t.GetMethod("StartAndRunTheDutyMonitor");
            if (m == null)
            {
                AddLog("Method StartAndRunTheDutyMonitor is null");
                return;
            }

            object ret = m.Invoke(x, new object[] { xHub.RzDatabaseName, xHub.RzRecallDatabaseName, xHub.RzServerName, xHub.RzServerUserName, xHub.RzServerPassword });
            s = (String)ret;

            AddLog("Invoke complete: " + s);

            t = null;
            a = null;
            m = null;
            x = null;
        }
    }
}
