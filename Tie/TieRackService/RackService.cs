using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Reflection;

using Tie;

namespace TieRackService
{
    public partial class RackService : ServiceBase
    {
        public Eye ServerEye;

        public RackService()
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
            CompleteStart();
            base.OnStart(args);
        }

        int PortSetting = 2954;
        String PasswordSetting = "rec0gnin";

        private void CompleteStart()
        {
            //GetSettings();

            try
            {
                ServerEye = new Eye();
                ServerEye.EyePort = PortSetting;
                ServerEye.Password = PasswordSetting;
                ServerEye.SendEncrypted = true;
                ServerEye.StartListening();
                AddLog("Listening on port " + ServerEye.EyePort.ToString() + "...");
            }
            catch(Exception ex)
            {
                AddLog("Error in CompleteStart: " + ex.Message);
            }
        }

        void AddLog(String s)
        {
            try
            {
                String strFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location.ToString().Trim());
                if( !strFile.EndsWith("\\") )
                    strFile += "\\";
                strFile += "RackServiceLog.txt";
                if( !File.Exists(strFile) )
                    File.Create(strFile);

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
            try
            {
                ServerEye.StopListening(true);
                ServerEye.DisconnectClients(false, false, true);
                ServerEye = null;
            }
            catch { }
            AddLog("Closed");
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
