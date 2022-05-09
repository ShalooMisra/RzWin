using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using Tie;

namespace Rz5
{
    public partial class frmNewChatSession : Form
    {
        Rz5.Win.RzHookWin xHook;

        public frmNewChatSession()
        {
            InitializeComponent();
            this.Icon = RzWin.Form.Icon;
        }
        //Public Functions
        protected virtual string FilterUserName(ClientConnection c)
        {
            if (c == null)
                return "";
            return c.UserName;
        }
        public void CompleteLoad(ArrayList clients, Rz5.Win.RzHookWin h)
        {
            xHook = h;
            lv.Items.Clear();
            foreach (ClientConnection c in clients)
            {
                c.UserName = FilterUserName(c);
                ListViewItem i = lv.Items.Add(c.UserName);
                i.SubItems.Add("Workstation '" + c.MachineName + "'");
                i.Tag = c;
            }
            lv.Sorting = SortOrder.Ascending;
            lv.Sort();
        }
        //Private Functions
        //private ArrayList FilterClientList(ArrayList list)
        //{
        //    try
        //    {
        //        Dictionary<String, ChatClient> dHold = new Dictionary<string, ChatClient>();
        //        for (int i = list.Count - 1; i >= 0; i-- )
        //        {
        //            ChatClient c = (ChatClient)list[i];
        //            try { dHold.Add(c.strUserID + "_" + c.strMachineName, c); }
        //            catch { }
        //        }
        //        ArrayList build = new ArrayList();
        //        foreach (KeyValuePair<String, ChatClient> kvp in dHold)
        //        {
        //            build.Add(kvp.Value);
        //        }
        //        return build;
        //    }
        //    catch (Exception ee)
        //    { return list; }
        //}
        private void StartSelectedSession()
        {
            ClientConnection c = GetSelectedClient();
            if (c == null)
                return;

            Win.ChatSessionWin s = (Win.ChatSessionWin)((ContextRz)RzWin.Context).xHook.GetSessionByID(c.UserID + "|" + c.MachineID);

            if (s == null)
            {
                s = (Win.ChatSessionWin)((ContextRz)RzWin.Context).xHook.AddChatSession(c);
            }

            xHook.ChatScreenMakeExist(s, false);
            Win.RzHookWin.TheChatScreen.xSession = s;
            Win.RzHookWin.TheChatScreen.InitRe();
        }
        private ClientConnection GetSelectedClient()
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
        //Control Events
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }

        void OK()
        {
            StartSelectedSession();
            this.Hide();
        }
    }
}