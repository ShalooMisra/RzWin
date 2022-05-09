using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tie;
using NewMethod;

namespace Rz5.Focus
{
    public partial class FocusChat : UserControl, IUserOnlineHandler
    {
        public String UserID = "";
        public String UserName = "";
        public ArrayList UserClients = new ArrayList();

        public FocusChat()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String strUserID, String strUserName)
        {
            UserID = strUserID;
            UserName = strUserName;
            cmdInit.Text = "Chat With " + UserName;
            cmdInit.Enabled = false;
            UserClients.Clear();
            if (((ContextRz)RzWin.Context).xHook != null)
                ((ContextRz)RzWin.Context).xHook.IsUserOnline(this, strUserID);
            DoResize();
        }

        void ReleaseHook(ContextRz context)
        {
            try
            {
                context.xHook.RemoveOnlineHandler(this);
            }
            catch { }
        }

        public void ActuallyHandleUserIsOnline(ArrayList a)
        {
            try
            {
                foreach (ClientConnection c in a)
                {
                    if (c.UserID == UserID)
                    {
                        UserClients.Add(c);
                    }
                }

                if( UserClients.Count > 0 )
                    cmdInit.Enabled = true;
            }
            catch { }
        }

        private void FocusChat_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                cmdInit.Left = 10;
                cmdInit.Top = (this.ClientRectangle.Height / 2) - (cmdInit.Height / 2);
            }
            catch { }
        }

        private void cmdInit_Click(object sender, EventArgs e)
        {
            if (UserClients.Count == 0)
                return;

            ClientConnection c = SelectClient();
            if (c == null)
                return;

            Win.ChatSessionWin s = (Win.ChatSessionWin)((ContextRz)RzWin.Context).xHook.GetSessionByID(c.UserID + "|" + c.MachineID);

            if (s != null)
            {
                s.Show();
                return;
            }

            s = (Win.ChatSessionWin)((ContextRz)RzWin.Context).xHook.AddChatSession(c);
            s.Show();
        }

        ClientConnection SelectClient()
        {
            try
            {
                return (ClientConnection)UserClients[0];
            }
            catch { return null; }
        }
    }
}
