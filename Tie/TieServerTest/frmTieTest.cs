using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethodx;
using Tie;

namespace TieServerTest
{
    public partial class frmTieTest : Form
    {
        Eye CurrentEye;
        ArrayList AllClients = new ArrayList();
        TieKnot CurrentKnot = new TieKnot();

        public frmTieTest()
        {
            InitializeComponent();
            tmr.Start();
        }

        public void RunTest()
        {
            CurrentEye = new Eye();
            CurrentEye.EyePort = 2950;
            CurrentEye.Password = "tiepass";
            CurrentEye.SendEncrypted = true;
            eye.SetEye(CurrentEye);
            CurrentEye.StartListening();
            SetLocalServer();
            DoResize();
        }

        public void ConnectClients(String strIP)
        {
            String s = "";

            Hook h = new Hook();
            h.IsManager = chkManager.Checked;
            h.HostName = strIP;
            h.HostPort = 2947;
            h1.SetHook(h);
            h.ConnectWithPersistence(ref s);

            //h = new Hook();
            //h.HostName = strIP;
            //h.HostPort = 2947;
            //h2.SetHook(h);
            //h.ConnectWithPersistence(ref s);
        }

        private void lblLocal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetLocalServer();
        }

        private void SetLocalServer()
        {
            SetServer(Environment.MachineName);
        }

        private void lblMike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetServer("mike.recognin.com");
        }

        private void SetServer(String s)
        {
            txtServer.Text = s;
        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.StrExt(txtServer.Text))
                ConnectClients(txtServer.Text);
        }

        private void cmdAddClients_Click(object sender, EventArgs e)
        {
            AddClients(Convert.ToInt32(num.Value));
        }

        private void AddClients(int c)
        {
            lvClients.BeginUpdate();
            try
            {
                for (int i = 0; i < c; i++)
                {
                    String s = "";

                    Hook h = new Hook();
                    h.HostName = txtServer.Text;
                    h.HostPort = 2947;
                    h.ApplicationVersion = i + 4;

                    ListViewItem x = lvClients.Items.Add(h.SessionID);
                    x.SubItems.Add(h.ApplicationVersion.ToString());
                    x.SubItems.Add(h.ReConnectionCount.ToString());
                    x.SubItems.Add("");
                    x.ForeColor = Color.Gray;
                    x.Tag = h;

                    h.ConnectWithPersistence(ref s);
                }
            }
            catch { }
            lvClients.EndUpdate();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            RefreshClients();
            eye.CheckFlaky();
            h1.CheckFlaky();
            //h2.CheckFlaky();
        }

        private void RefreshClients()
        {
            lvClients.BeginUpdate();
            try
            {
                foreach (ListViewItem i in lvClients.Items)
                {
                    Hook h = (Hook)i.Tag;
                    i.SubItems[2].Text = h.ReConnectionCount.ToString(); 
                    if (h.IsConnected())
                    {
                        i.ForeColor = Color.Blue;
                        i.SubItems[3].Text = "";
                    }
                    else
                    {
                        i.SubItems[3].Text = h.Status;
                        i.ForeColor = Color.Red;
                    }
                }
            }
            catch { }
            lvClients.EndUpdate();
        }

        private void frmTieTest_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                h1.Left = 0;
                h1.Top = this.ClientRectangle.Height - h1.Height;
                h1.Width = this.ClientRectangle.Width - lvClients.Width;
                //h2.Left = h1.Right;
                //h2.Top = h1.Top;

                gb.Left = 0;
                gb.Top = h1.Top - gb.Height;

                lvClients.Top = 0;
                lvClients.Width = this.ClientRectangle.Width - lvClients.Left;
                lvClients.Height = this.ClientRectangle.Height;

                eye.Left = 0;
                eye.Top = 0;
                eye.Height = this.ClientRectangle.Height - (gb.Height + h1.Height);
            }
            catch { }
        }

        private void cmdKnot_Click(object sender, EventArgs e)
        {
            ShowCurrentKnot();
            CurrentKnot.CheckPins();
        }

        private void cmdPersistentKnot_Click(object sender, EventArgs e)
        {
            ShowCurrentKnot();
            CurrentKnot.CheckPinsPersistently();
        }

        private void cmdCheckKnotUpdate_Click(object sender, EventArgs e)
        {
            ShowCurrentKnot();
            CurrentKnot.CheckForUpdates();
        }

        frmKnot KnotViewer = null;

        public void ShowCurrentKnot()
        {
            if (KnotViewer == null)
            {
                KnotViewer = new frmKnot();
                KnotViewer.Show();
                KnotViewer.SetKnot(CurrentKnot);
            }
        }

        private void eye_Load(object sender, EventArgs e)
        {

        }
    }
}