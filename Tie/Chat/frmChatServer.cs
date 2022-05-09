using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Threading;

namespace NewMethod.Chat
{
    public partial class frmChatServer : Form
    {
        public static frmChatServer TheChatServerForm;

        public static void CheckStartChatServer(n_sys xs)
        {
            if (frmChatServer.TheChatServerForm != null)
                return;

            frmChatServer.TheChatServerForm = new frmChatServer();
            frmChatServer.TheChatServerForm.xSys = xs;
            frmChatServer.TheChatServerForm.StartListening();
            frmChatServer.TheChatServerForm.Show();
        }

        public ChatEye xChat;
        public Thread ChatThread;
        public n_sys xSys;
        bool bShowing = false;

        public frmChatServer()
        {
            InitializeComponent();
        }

        public void StartListening()
        {
            StopListening();

            xChat = new ChatEye();
            xChat.xSys = xSys;
            xChat.GotLiveConnection += new GotLiveConnectionHandler(xChat_GotLiveConnection);
            xChat.LostLiveConnection += new LostLiveConnectionHandler(xChat_LostLiveConnection);

            ChatThread = new Thread(new ThreadStart(ActuallyListen));
            ChatThread.SetApartmentState(ApartmentState.STA);
            ChatThread.Start();
        }

        public void StopListening()
        {
            SetStatus("Stopping...");
            if (xChat != null)
            {
                xChat.GotLiveConnection -= new GotLiveConnectionHandler(xChat_GotLiveConnection);
                xChat.LostLiveConnection -= new LostLiveConnectionHandler(xChat_LostLiveConnection);
                xChat.StopListening();
                xChat.DisconnectClients();
                xChat.AllConnections.Clear();
                xChat = null;
            }

            if (ChatThread != null)
            {
                try
                {
                    ChatThread.Abort();
                    ChatThread = null;
                }
                catch { }
            }
            ShowConnections();
            SetStatus("Stopped.");
        }

        void xChat_LostLiveConnection(ChatConnection c)
        {
            SetStatus("Lost Connection " + c.UniqueID);
            ShowConnections();
        }

        void xChat_GotLiveConnection(ChatConnection c)
        {
            SetStatus("Got Connection " + c.UniqueID);
            ShowConnections();
        }

        public void ActuallyListen()
        {
            SetStatus("Listening...");
            xChat.StartListening(nmTie.ConnectTarget.LocalServer);            
        }

        private void ShowConnections()
        {
            bool bExists = true;

            if (bShowing)
                return;

            bShowing = true;

            try
            {

                if (xChat == null)
                    bExists = false;
                else
                {
                    if (xChat.AllConnections == null)
                        bExists = false;
                }

                if (bExists)
                {
                    lock (xChat.AllConnections.SyncRoot)
                    {
                        if (InvokeRequired)
                            Invoke(new ShowConnectionsHandler(ActuallyShowConnections));
                        else
                            ActuallyShowConnections();
                    }
                }
                else
                {
                    if (InvokeRequired)
                        Invoke(new ShowConnectionsHandler(ActuallyShowConnections));
                    else
                        ActuallyShowConnections();
                }
            }
            catch { }

            bShowing = false;  
        }

        delegate void ShowConnectionsHandler();
        private void ActuallyShowConnections()
        {
            lv.Items.Clear();

            if (xChat == null)
                return;

            if (xChat.AllConnections == null)
                return;

            lv.BeginUpdate();
            try
            {
                foreach (ChatConnection c in xChat.AllConnections)
                {
                    ListViewItem i = lv.Items.Add(c.TheUser.name);
                    i.SubItems.Add(c.MachineName);
                    i.SubItems.Add(nTools.DateFormat_ShortDateTime(c.LastPing));
                    i.SubItems.Add(c.Status);
                    c.MyItem = i;
                    i.Tag = c;
                }
            }
            catch { }
            lv.EndUpdate();
        }

        private void SetStatus(String s)
        {
            if (InvokeRequired)
                Invoke(new SetStatusDelegate(ActuallySetStatus), new object[] { s });
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

        private void cmdClose_Click(object sender, EventArgs e)
        {
            StopListening();
        }

        private void cmdReOpen_Click(object sender, EventArgs e)
        {
            StartListening();
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            ShowConnections();
        }
    }
}