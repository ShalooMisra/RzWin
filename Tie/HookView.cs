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
    public delegate void SetStatusHandler(String s);
    
    public partial class HookView : UserControl
    {
        public Hook CurrentHook;

        public HookView()
        {
            InitializeComponent();            
        }

        public void SetHook(Hook h)
        {
            CurrentHook = h;
            lblCaption.Text = h.HostName + ":" + h.HostPort.ToString();

            xView.SetEnd(h);
            
            //CurrentHook.GotMessageEvent += new GotMessageHandler(CurrentHook_GotMessageEvent);
            CurrentHook.GotClients += new GotClientsHandler(CurrentHook_GotClients);
            tmr.Start();
        }

        public void CheckFlaky()
        {
            if (chkFlaky.Checked && CurrentHook.IsConnected())
            {
                int i = Tools.Number.GetRandomInteger(1, 30);
                if (i > 28)
                {
                    xView.SetStatus("Closing...");
                    CurrentHook.Close();
                }
                else if (i > 26)
                {
                    xView.SetStatus("Closing w/ goodbye...");
                    CurrentHook.GoodByeAndClose();
                }
            }
        }

        public void UpdateStatus()
        {
            lblStatus.Text = CurrentHook.ReConnectionCount.ToString() + " reconnect(s)" + "\r\n";
            lblClientCount.Text = Tools.Number.LongFormat(CurrentHook.ClientCount);
        }

        void CurrentHook_GotClients(ArrayList a)
        {
            if (InvokeRequired)
                Invoke(new ShowClientHandler(ShowClients), new Object[] { a });
            else
                ShowClients(a);
        }

        delegate void ShowClientHandler(ArrayList clients);
        private void ShowClients(ArrayList clients)
        {
            lv.Items.Clear();
            foreach (ClientConnection c in clients)
            {
                ListViewItem i = lv.Items.Add(c.GetSummaryName());
                i.Tag = c;
                c.IsStatic = true;
                c.xRootHook = CurrentHook;
            }
        }

        private void cmdDrop_Click(object sender, EventArgs e)
        {
            CurrentHook.GoodByeAndClose();
        }

        private void cmdDropQuick_Click(object sender, EventArgs e)
        {
            CurrentHook.Close();
        }

        private void cmdGetSessions_Click(object sender, EventArgs e)
        {
            CurrentHook.RequestClientList();
        }

        private void cmdStartPersistence_Click(object sender, EventArgs e)
        {
            CurrentHook.StartPersistence();
        }

        private void cmdStopPersistence_Click(object sender, EventArgs e)
        {
            CurrentHook.StopPersistence();
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            CurrentHook.ConnectWithPersistence();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            CheckFlaky();
            UpdateStatus();
        }

        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientConnection c = GetSelectedConnection();
            if (c == null)
                return;

            optClient.Text = c.GetSummaryName();
            optClient.Tag = c;
        }

        private ClientConnection GetSelectedConnection()
        {
            try
            {
                return (ClientConnection)lv.SelectedItems[0].Tag;
            }
            catch
            {
                return null;
            }
        }

        private void optServer_CheckedChanged(object sender, EventArgs e)
        {
            SetTarget();
        }

        private void optClient_CheckedChanged(object sender, EventArgs e)
        {
            SetTarget();
        }

        private void SetTarget()
        {
            if (optServer.Checked)
            {
                xView.TargetSession = "";
            }
            else
            {
                if (optClient.Tag == null)
                {
                    xView.TargetSession = "";
                }
                else
                {
                    ClientConnection c = (ClientConnection)optClient.Tag;
                    xView.TargetSession = c.SessionID;
                }
            }
        }

        private void xView_Load(object sender, EventArgs e)
        {

        }
    }
}
