using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethodx;

namespace Tie
{
    public partial class EyeView : UserControl
    {
        public Eye CurrentEye;

        public EyeView()
        {
            InitializeComponent();
        }

        public void SetEye(Eye e)
        {
            try
            {
                CurrentEye = e;
                CurrentEye.ConnectionAdded += new ConnectionChangeHandler(CurrentEye_ConnectionAdded);
                CurrentEye.ConnectionUpdated += new ConnectionChangeHandler(CurrentEye_ConnectionUpdated);
                CurrentEye.ConnectionLost += new ConnectionChangeHandler(CurrentEye_ConnectionLost);
                CurrentEye.GotStatus += new EyeStatusHandler(CurrentEye_GotStatus);
                CurrentEye.CheckSiteCredentials = true;
                tmr.Start();
                ShowCaption();

                txtPort.Text = CurrentEye.EyePort.ToString();
            }
            catch { }
        }

        public void ShowCaption()
        {
            if (CurrentEye == null)
                lblCaption.Text = "No current server";
            else
                lblCaption.Text = "Port " + CurrentEye.EyePort.ToString() + " Encryption=" + CurrentEye.SendEncrypted.ToString();
        }

        void CurrentEye_GotStatus(string s)
        {
            SetStatus(s);
        }

        void CurrentEye_ConnectionAdded(ClientConnection c)
        {
            SetStatus("Got Connection: " + c.GetSummaryName());
            Invoke(new ConnectionChangeHandler(ActuallyAddConnection), new object[] { c });
        }

        void CurrentEye_ConnectionUpdated(ClientConnection c)
        {
            Invoke(new ConnectionChangeHandler(ActuallyUpdateConnection), new object[] { c });
        }

        void CurrentEye_ConnectionLost(ClientConnection c)
        {
            SetStatus("Lost Connection: " + c.GetSummaryName());
            Invoke(new ConnectionChangeHandler(ActuallyRemoveConnection), new object[] { c });
        }

        public void ReShowConnections()
        {
            lv.Items.Clear();
            foreach (ClientConnection c in CurrentEye.GetAllConnectedClients())
            {
                ActuallyAddConnection(c);
            }
        }

        void ActuallyAddConnection(ClientConnection c)
        {
            ListViewItem i = lv.Items.Add(c.MachineName);
            i.Tag = c;
            i.SubItems.Add(c.LastPing.ToString());
            i.SubItems.Add(c.Status);
            i.SubItems.Add(c.SessionID);
            i.SubItems.Add(c.EndAddress);
            i.SubItems.Add(c.ApplicationName);
            i.SubItems.Add(c.ApplicationVersion.ToString());
            i.SubItems.Add(c.UserName);
            i.SubItems.Add(c.SiteCredentials);
        }

        void ActuallyUpdateConnection(ClientConnection c)
        {
            ListViewItem i = GetItemBySession(c.SessionID);
            if (i == null)
                return;

            i.Text = c.MachineName;
            i.SubItems[1].Text = c.LastPing.ToString();
            i.SubItems[2].Text = c.Status.ToString();
            i.SubItems[3].Text = c.SessionID;
            i.SubItems[4].Text = c.EndAddress;
            i.SubItems[5].Text = c.ApplicationName;
            i.SubItems[6].Text = c.ApplicationVersion.ToString();
            i.SubItems[7].Text = c.UserName;
            i.SubItems[8].Text = c.SiteCredentials;

            if (c.IsConnected())
                i.ForeColor = Color.Blue;
            else
                i.ForeColor = Color.Gray;
        }

        void ActuallyRemoveConnection(ClientConnection c)
        {
            ListViewItem i = GetItemBySession(c.SessionID);
            if (i == null)
                return;

            lv.Items.Remove(i);
        }

        private ListViewItem GetItemBySession(String session)
        {
            foreach (ListViewItem i in lv.Items)
            {
                ClientConnection c = (ClientConnection)i.Tag;
                if (c.SessionID == session)
                    return i;
            }
            return null;
        }

        private void SetStatus(String s)
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

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            CurrentEye.EyePort = Int32.Parse(txtPort.Text);
            CurrentEye.StartListening();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            CurrentEye.StopListening(true);
        }

        private void cmdDropAll_Click(object sender, EventArgs e)
        {
            CurrentEye.DisconnectClients(true, false, true);
        }

        private void cmdCloseFast_Click(object sender, EventArgs e)
        {
            CurrentEye.StopListening(false);
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            CheckStatus();
        }

        private void CheckStatus()
        {
            try
            {
                //ArrayList a = CurrentEye.GetAllConnectedClients();
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Connections: " + CurrentEye.ConnectionCount.ToString());
                sb.AppendLine("Forced Closes: " + CurrentEye.ForcedCloses.ToString());
                sb.AppendLine("Accept Errors: " + CurrentEye.AcceptErrors.ToString());
                lblStatus.Text = sb.ToString();
            }
            catch
            {
                lblStatus.Text = "Error.";
            }
        }

        private void EyeView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {

                lv.Left = 0;
                lv.Width = this.ClientRectangle.Width;
                lv.Height = this.ClientRectangle.Height - lv.Top;

                //txtStatus.Top = 0;
                txtStatus.Width = this.ClientRectangle.Width - txtStatus.Left;
            }
            catch { }
        }

        public void CheckFlaky()
        {
            if (chkFlaky.Checked && CurrentEye.CurrentState == EyeState.Watching)
            {
                int i = Tools.Number.GetRandomInteger(1, 50);
                if (i > 48)
                {
                    SetStatus("Closing...");
                    CurrentEye.StopListening(false);
                    CurrentEye.StartListening();
                    lv.Items.Clear();  //this should already have happened
                }
                else if (i > 46)
                {
                    SetStatus("Closing w/ goodbye...");
                    CurrentEye.StopListening(true);
                    CurrentEye.StartListening();
                }
            }
        }

        private void mnuTrack_Click(object sender, EventArgs e)
        {
            ClientConnection c = GetSelectedConnection();
            if (c == null)
                return;
            c.TrackTraffic = !c.TrackTraffic;
        }

        private void mnuConnection_Opening(object sender, CancelEventArgs e)
        {
            ClientConnection c = GetSelectedConnection();
            if (c == null)
            {
                e.Cancel = true;
                return;
            }

            mnuTrack.Checked = c.TrackTraffic;
        }

        private ClientConnection GetSelectedConnection()
        {
            try
            {
                return (ClientConnection)lv.SelectedItems[0].Tag;
            }
            catch { return null; }
        }

        private void viewLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientConnection c = GetSelectedConnection();
            if (c == null)
                return;

            c.ShowTraffic();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ClientConnection c = GetSelectedConnection();
            if (c == null)
                return;

            frmClientConnection.ShowClientConnection(c);
        }

        private void mnuPermanentlyDrop_Click(object sender, EventArgs e)
        {
            ClientConnection c = GetSelectedConnection();
            if (c == null)
                return;

            if (MessageBox.Show("Are you sure?", "Sure?", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            c.SendOff(true, false, true, true);
        }
    }
}
