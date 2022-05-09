using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethodx;

namespace Tie
{
    public partial class frmNewChatSession : Form
    {
        public frmNewChatSession()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(ArrayList clients)
        {
            clients = FilterClientList(clients);
            lv.Items.Clear();
            foreach (ChatClient c in clients)
            {
                ListViewItem i = lv.Items.Add(c.strUserName);
                i.SubItems.Add(c.strMachineName);
                i.Tag = c;
            }
        }
        //Private Functions
        private ArrayList FilterClientList(ArrayList list)
        {
            try
            {
                Dictionary<String, ChatClient> dHold = new Dictionary<string, ChatClient>();
                for (int i = list.Count - 1; i >= 0; i-- )
                {
                    ChatClient c = (ChatClient)list[i];
                    try { dHold.Add(c.strUserID + "_" + c.strMachineName, c); }
                    catch { }
                }
                ArrayList build = new ArrayList();
                foreach (KeyValuePair<String, ChatClient> kvp in dHold)
                {
                    build.Add(kvp.Value);
                }
                return build;
            }
            catch (Exception ee)
            { return list; }
        }
        private void StartSelectedSession()
        {
            ChatClient c = GetSelectedClient();
            if (c == null)
                return;

            ChatSession s = ChatHook.GetSessionByID(c.GetID());

            if (s != null)
            {
                s.Show();
                return;
            }

            s = ChatHook.AddSession(c);
            s.Show();
        }
        private ChatClient GetSelectedClient()
        {
            try
            {
                return (ChatClient)lv.SelectedItems[0].Tag;
            }
            catch
            {
                return null;
            }
        }
        //Control Events
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            StartSelectedSession();
            this.Hide();
        }
    }
}