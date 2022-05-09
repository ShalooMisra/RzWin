using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethodx;

namespace Tie
{
    public partial class EndView : UserControl
    {
        public TieEnd CurrentEnd;
        
        int echo = 0;

        String m_TargetSession = "";
        public String TargetSession
        {
            get
            {
                return m_TargetSession;
            }

            set
            {

                m_TargetSession = value;
                if( Tools.Strings.StrExt(m_TargetSession) )
                    lblTargetSession.Text = "Target: " + value;
                else
                    lblTargetSession.Text = "Target: <server>";
            }
        }

        public EndView()
        {
            InitializeComponent();
        }

        public void SetEnd(TieEnd e)
        {
            CurrentEnd = e;
            UpdateStatus();

            CurrentEnd.GotStatus += new TieEndStatusHandler(CurrentEnd_GotStatus);
            CurrentEnd.JobStatusChanged += new JobStatusChangeHandler(CurrentEnd_JobStatusChanged);
            CurrentEnd.JobLogAdded += new JobLogAddedHandler(CurrentEnd_JobLogAdded);
            CurrentEnd.JobFinished += new JobStatusHandler(CurrentEnd_JobFinished);
            
            tmr.Start();
        }

        void CurrentEnd_GotStatus(TieEnd end, string s)
        {
            SetStatus(s);
        }

        public void SetStatus(String s)
        {
            if (InvokeRequired)
                Invoke(new SetStatusHandler(ActuallySetStatus), new object[] { s });
            else
                ActuallySetStatus(s);
        }

        private void ActuallySetStatus(String s)
        {
            try
            {
                txtStatus.AppendText(s + "\n");
                txtStatus.ScrollToCaret();
            }
            catch { }
        }

        void CurrentEnd_JobStatusChanged()
        {
            ShowJobs();
        }

        public void ShowJobs()
        {
            if (InvokeRequired)
                Invoke(new ShowJobsHandler(ActuallyShowJobs));
            else
                ActuallyShowJobs();
        }

        delegate void ShowJobsHandler();
        public void ActuallyShowJobs()
        {
            lvToDo.Items.Clear();
            Object[] ary;
            lock(CurrentEnd.JobsDone.SyncRoot)
            {
                 ary = CurrentEnd.JobsToDo.ToArray();
            }
            for (int i = 0; i < ary.Length; i++)
            {
                TieJob j = (TieJob)ary[i];
                ListViewItem x = lvToDo.Items.Add(j.Name);
            }

            lvDone.Items.Clear();
            lock(CurrentEnd.JobsDone.SyncRoot)
            {
                ary = CurrentEnd.JobsDone.ToArray();
            }
            for (int i = 0; i < ary.Length; i++)
            {
                TieJob j = (TieJob)ary[i];
                ListViewItem x = lvDone.Items.Add(j.Name);
                x.SubItems.Add(j.ResultStatus);
                if (j.Success)
                    x.ForeColor = Color.Green;
                else
                    x.ForeColor = Color.Red;
            }

            lvRunning.Items.Clear();
            //lock(CurrentEnd.RunningJobs)
            //{
                foreach (KeyValuePair<String, TieJob> k in CurrentEnd.RunningJobs)
                {
                    ListViewItem x = lvRunning.Items.Add(k.Value.Name);
                    if (k.Value.Completed)
                        x.ForeColor = Color.Blue;
                    else
                        x.ForeColor = Color.Green;
                }
            //}

            ActuallyShowCurrentJobLog();
        }

        void CurrentEnd_JobLogAdded(TieJob job, string log, JobLogType type)
        {
            if (InvokeRequired)
                Invoke(new ShowJobsHandler(ActuallyShowCurrentJobLog));
            else
                ActuallyShowCurrentJobLog();
        }

        private void ActuallyShowCurrentJobLog()
        {
            if (CurrentEnd.CurrentJob == null)
                lblCurrent.Text = "<no current job>";
            else
                lblCurrent.Text = CurrentEnd.CurrentJob.Name + "\r\n\r\n" + CurrentEnd.CurrentJob.JobLog.ToString();
        }

        private void lblCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentEnd.CheckJobs();
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            mnuJobs.Show(Cursor.Position);
        }

        private void mnuTestJob_Click(object sender, EventArgs e)
        {
            TieJob j = new TieJob(CurrentEnd);
            j.Name = "Test Job";
            CurrentEnd.AddJob(j);
        }

        private void mnuEchoJob_Click(object sender, EventArgs e)
        {
            SendEchoRequest();
        }

        private void SendEchoRequest()
        {
            Job_EchoTest j = new Job_EchoTest(CurrentEnd);
            j.TargetSession = TargetSession;
            CurrentEnd.AddJob(j);
        }

        private void chkTrack_CheckedChanged(object sender, EventArgs e)
        {
            CurrentEnd.TrackTraffic = chkTrack.Checked;
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentEnd.ClearDone();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void lblLogs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentEnd.ShowTraffic();
        }

        private void chkAutoCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutoCheck.Checked)
                tmrJobs.Start();
            else
                tmrJobs.Stop();
        }

        private void tmrJobs_Tick(object sender, EventArgs e)
        {
            CurrentEnd.CheckJobs();

            if (chkAutoEcho.Checked)
            {
                echo++;
                if (echo > 120)
                {
                    if (CurrentEnd.IsConnected())
                    {
                        SendEchoRequest();
                    }
                    echo = 0;
                }

            }
        }

        private void mnuIPConfig_Click(object sender, EventArgs e)
        {
            Job_DosCommand j = new Job_DosCommand(CurrentEnd);
            j.Name = "Dos: ipconfig";
            j.CommandName = "ipconfig";
            CurrentEnd.AddJob(j);
        }

        void CurrentEnd_JobFinished(TieJob job)
        {
            if (InvokeRequired)
                Invoke(new JobUpdateHandler(ActuallyShowLastJob), new object[] { job });
            else
                ActuallyShowLastJob(job);

        }
        delegate void JobUpdateHandler(TieJob job);
        private void ActuallyShowLastJob(TieJob job)
        {
            lblLast.Text = job.Name + "\r\n\r\n" + Tools.Strings.KillBlankLines(job.ResultStatus);
            if (job.Success)
                lblLast.ForeColor = Color.Blue;
            else
                lblLast.ForeColor = Color.Black;
        }

        private void mnuVNCMike_Click(object sender, EventArgs e)
        {
            OpenVNC("mike.recognin.com");
        }

        private void mnuVNCJoel_Click(object sender, EventArgs e)
        {
            OpenVNC("joel.wektortech.com");
        }

        private void OpenVNC(String to)
        {
            Job_OpenVNC j = new Job_OpenVNC(CurrentEnd);
            j.TargetSession = m_TargetSession;
            j.Name = "Open VNC to " + to;
            j.VNCAddress = to;
            CurrentEnd.AddJob(j);
        }

        private void mnuVNCOther_Click(object sender, EventArgs e)
        {
        }

        public void UpdateStatus()
        {
            if (CurrentEnd == null)
            {
                picStatus.BackColor = Color.Gray;
                lblStatus.Text = "<no data>";
                return;
            }

            if (CurrentEnd.IsConnected())
                picStatus.BackColor = Color.Green;
            else
                picStatus.BackColor = Color.Red;

            lblStatus.Text = CurrentEnd.GetSummaryName() + "\r\n" + CurrentEnd.StreamErrors.ToString() + " stream error(s)  Using Encryption=" + CurrentEnd.SendEncrypted.ToString() + "  Password= " + CurrentEnd.Password;
        }

        private void lblAddRunning_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Job_Files j = new Job_Files(CurrentEnd);
            //j.TargetSession = TargetSession;
            //CurrentEnd.AddRunningJob(j);
            //j.Show();
            //j.Do();
        }

        private void mnuUpdateOriginals_Click(object sender, EventArgs e)
        {
            Job_UpdateOriginals j = new Job_UpdateOriginals(CurrentEnd);
            j.TargetSession = m_TargetSession;
            CurrentEnd.AddJob(j);
        }
    }
}
