using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tools.Database;

namespace NewMethod
{
    public partial class view_data_target : NewMethod.nView
    {
        public bool m_DisconnectedMode = false;
        public bool DisconnectedMode
        {
            get
            {
                return m_DisconnectedMode;
            }

            set
            {
                m_DisconnectedMode = value;
                DoResize();
            }

        }

        public view_data_target()
        {
            InitializeComponent();
            throb.BackColor = Color.White;
        }

        public n_data_target CurrentTarget
        {
            get
            {
                return (n_data_target)GetCurrentObject();
            }
        }

        private void lblApply_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompleteSave();
        }

        private void view_data_target_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                lblApply.Visible = !m_DisconnectedMode;
            }
            catch { }
        }

        private void lblTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throb.ShowThrobber();
            bgTest.RunWorkerAsync();
        }

        private void bgTest_DoWork(object sender, DoWorkEventArgs e)
        {
            SetStatus("Connecting...");
            String s = "";
            DataConnection d = CurrentTarget.GetAsDataConnection();
            try
            {
                d.ConnectPossible();
                SetStatus("Connected.");
            }
            catch (Exception ee)
            {
                SetStatus("Connection failed: " + ee.Message);
            }
        }

        void SetStatus(String s)
        {
            if (InvokeRequired)
                Invoke(new SetStatusDelegate(ActuallySetStatus), new object[] { s });
            else
                ActuallySetStatus(s);

        }

        void ActuallySetStatus(String s)
        {
            txtStatus.Text += s + "\r\n";
            txtStatus.ScrollToCaret();
        }

        private void bgTest_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
        }

        private void bgCreate_DoWork(object sender, DoWorkEventArgs e)
        {
            SetStatus("Connecting...");
            DataConnection d = CurrentTarget.GetAsDataConnection();
            try
            {
                d.MasterConnection.ConnectPossible();
                SetStatus("Connected - Creating...");
                Tools.Database.Key k = d.GetDatabaseKey(CurrentTarget.database_name);
                //k.FolderPath = n_data_target.dDataPath;
                try
                {
                    d.MasterConnection.DatabaseCreate(k);
                    SetStatus(CurrentTarget.database_name + " created.");
                }
                catch
                {
                    SetStatus("Database create failed.");
                }
            }
            catch (Exception ee)
            {
                SetStatus("Connection failed: " + ee.Message);   
            }
        }

        private void lblCreateDatabase_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            throb.ShowThrobber();
            bgCreate.RunWorkerAsync();
        }

        private void bgCreate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
        }
    }
}

