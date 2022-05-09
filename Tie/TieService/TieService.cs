using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.Text;

using Tie;

namespace TieService
{
    public partial class TieService : ServiceBase
    {
        public TieKnot TheKnot;

        public TieService()
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

        private void CompleteStart()
        {
            TheKnot = new TieKnot();
            TheKnot.CheckPinsPersistently();
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
                TheKnot.StopPersistence();
                TheKnot = null;
            }
            catch { }  
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
