using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Xml;
using System.IO;


using NewMethod;
using Tie;

namespace Rz5
{
    public partial class frmChatSession : Form
    {
        //Private Static Extern
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr hwnd, bool bInvert);
        //[DllImport("User32")]
        //private static extern int SetForegroundWindow(IntPtr hwnd);
        public SortedList Sessions;
        //Private Delegates
        
        //private delegate void BringBackHandler();
        //this caused non-active chat sessions to pop in front of active ones
        //public void ActuallyBringBack()
        //{
        //    try
        //    {
        //        if (Rz3App.xLogic.IsPhoenix)
        //        {

        //        }
        //        else
        //        {
        //            if (this.WindowState == FormWindowState.Minimized)
        //                this.WindowState = FormWindowState.Normal;
        //            SetForegroundWindow(this.Handle);
        //        }
        //    }
        //    catch { }
        //}

        //Public Variables        
        public Win.ChatSessionWin xSession;
        public String ChatSound = "";
        //Private Variables
        private System.Media.SoundPlayer ThePlayer;
        public void PlayChatSound()
        {
            try
            {
                if (Tools.Strings.StrExt(ChatSound))
                {
                    if (ThePlayer == null)
                    {
                        ThePlayer = new System.Media.SoundPlayer();
                        ThePlayer.SoundLocation = ChatSound;
                    }
                    ThePlayer.Play();
                }
            }
            catch { }
        }
        //Constructors
        public frmChatSession()
        {
            InitializeComponent();
            Icon = RzWin.Form.Icon;
        }
        //Public Functions        
        public void CompleteLoad()
        {
            ChatSound = Tools.Folder.ConditionFolderName(nTools.GetAppParentPath()) + "Sounds\\ChatSound.wav";
            if (!File.Exists(ChatSound))
                ChatSound = "";                    
            //wb.ReloadWB();
            DoResize();
        }
        public void InitRe()
        {
            if (InvokeRequired)
                Invoke(new GenericHandler(InitReActually));
            else
                InitReActually();
        }
        delegate void GenericHandler();
        void InitReActually()
        {
            try
            {
                ListUpdate();
                xSessionShow();
                DoResize();
            }
            catch { }
        }
        ToolsWin.BrowserPlain currentBrowser = null;
        void xSessionShow()
        {
            if (xSession == null)
            {
                HideBrowsers();
                this.Text = "";
                return;
            }

            if (xSession.xClient == null)
            {
                HideBrowsers();
                this.Text = "(null client)";
                return;
            }

            if (xSession.TheBrowser == null)
            {
                HideBrowsers();
                this.Text = "(null browser)";
                return;
            }

            this.Text = "Chat Session with " + xSession.xClient.UserName + " on " + xSession.xClient.MachineName;

            if (currentBrowser != xSession.TheBrowser)
            {
                //pBrowser.Controls.Clear();
                HideBrowsers();
                //wb.ReloadWB();
                
                //xSession.TheBrowser.Dock = DockStyle.Fill;
                currentBrowser = xSession.TheBrowser;
                
                               
                //xSession.TheBrowser.Add(currentHtml);
                //wb.ScrollToBottom();
            }

            if( currentBrowser != null )
                currentBrowser.Visible = true;
    
            xSession.Viewed = true;
            cmdSend.Enabled = xSession.Enabled;
        }
        void ListUpdate()
        {
            lvSessions.BeginUpdate();

            try
            {
                //List<ListViewItem> items = new List<ListViewItem>();
                List<Rz5.Win.ChatSessionWin> sessions = new List<Win.ChatSessionWin>();
                List<ListViewItem> remove = new List<ListViewItem>();
                foreach (ListViewItem i in lvSessions.Items)
                {
                    Rz5.Win.ChatSessionWin s = (Rz5.Win.ChatSessionWin)i.Tag;
                    if (s.Enabled == false)
                        remove.Add(i);
                    else
                        sessions.Add(s);
                }

                foreach(ListViewItem i in remove)
                {
                    lvSessions.Items.Remove(i);
                    i.Tag = null;                    
                }

                foreach (DictionaryEntry d in Sessions)
                {
                    Rz5.Win.ChatSessionWin s = (Rz5.Win.ChatSessionWin)d.Value;
                    if (!sessions.Contains(s))
                    {
                        ListViewItem i = lvSessions.Items.Add(s.xClient.UserName);
                        i.SubItems.Add(s.xClient.MachineName);
                        i.Tag = s;                        
                    }

                    s.BrowserMakeExist();
                    if (s.TheBrowser.Parent == null)
                    {
                        pBrowser.Controls.Add(s.TheBrowser);
                        s.TheBrowser.Visible = false;
                        xSession.TheBrowser.Dock = DockStyle.Fill;
                    }
                }

                foreach (ListViewItem i in lvSessions.Items)
                {
                    Rz5.Win.ChatSessionWin s = (Rz5.Win.ChatSessionWin)i.Tag;
                    if (s.Viewed)
                        i.BackColor = Color.White;
                    else
                        i.BackColor = Color.LightGreen;

                    if (s == xSession)
                        i.BackColor = Color.LightBlue;
                }
            }
            catch{}

            lvSessions.EndUpdate();
        }
        protected virtual void SendExtra(StringBuilder sb)
        {

        }
        public void Send()
        {
            if (!Tools.Strings.StrExt(txtSend.Text))
                return;
            xSession.AddText(txtSend.Text, Color.Gray);
            xSessionShow();
            TieMessage m = new TieMessage("<UserID=" + ((ContextRz)RzWin.Context).xHook.UserID + ", MachineID=" + ((ContextRz)RzWin.Context).xHook.MachineID + ">", "chat", "<UserID=" + xSession.xClient.UserID + ", MachineID=" + xSession.xClient.MachineID + ">");
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("chat_text", txtSend.Text));
            sb.Append(Tools.Xml.BuildXmlProp("FromUserID", ((ContextRz)RzWin.Context).xHook.UserID));
            sb.Append(Tools.Xml.BuildXmlProp("FromUserName", ((ContextRz)RzWin.Context).xHook.UserName));
            sb.Append(Tools.Xml.BuildXmlProp("FromMachineID", ((ContextRz)RzWin.Context).xHook.MachineID));
            sb.Append(Tools.Xml.BuildXmlProp("FromMachineName", ((ContextRz)RzWin.Context).xHook.MachineName));
            m.ContentString = sb.ToString();
            ((ContextRz)RzWin.Context).xHook.Send(m);
            SendExtra(sb);
            chat_message sm = chat_message.New(RzWin.Context);
            sm.the_n_user_uid = RzWin.User.unique_id;
            sm.sender = RzWin.Context.xUser.name;
            sm.recipient = xSession.xClient.UserName;
            sm.chat_text = txtSend.Text;
            sm.sender_machine = Environment.MachineName;
            sm.session_uid = xSession.UniqueID;
            sm.chat_date_utc = DateTime.UtcNow;
            sm.Insert(RzWin.Context);  //used to be async
            txtSend.Text = "";
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                lvSessions.Left = 0;
                lvSessions.Top = 0;
                lvSessions.Height = (this.ClientRectangle.Height - cmdChatWithSomeone.Height);

                cmdChatWithSomeone.Left = 0;
                cmdChatWithSomeone.Top = lvSessions.Bottom;
                cmdChatWithSomeone.Width = lvSessions.Width;

                txtSend.Left = lvSessions.Right;
                txtSend.Top = this.ClientRectangle.Height - txtSend.Height;
                txtSend.Width = this.ClientRectangle.Width - (txtSend.Left + cmdSend.Width);

                cmdSend.Left = txtSend.Right;
                cmdSend.Top = txtSend.Top;
                cmdSend.Height = txtSend.Height;

                pBrowser.Left = lvSessions.Right;
                pBrowser.Top = 0;
                pBrowser.Width = this.ClientRectangle.Width - pBrowser.Left;
                pBrowser.Height = this.ClientRectangle.Height - txtSend.Height;

                if (currentBrowser != null)
                    currentBrowser.Dock = DockStyle.Fill;
            }
            catch { }
        }
        void HideBrowsers()
        {
            foreach (Control c in pBrowser.Controls)
            {
                try
                {
                    c.Visible = false;
                }
                catch { }
            }
        }
        //Buttons
        private void cmdSend_Click(object sender, EventArgs e)
        {
            //if (ToolsWin.Keyboard.GetShiftKey())
            //{
            //    wb.Add("<br>Test");
            //    wb.ScrollToBottom();
            //}
            //else
                Send();
        }
        //Control Events
        private void frmChatSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!RzWin.Context.TheLeaderRz.AreYouSure("you want to close this chat window"))
            {
                e.Cancel = true;
                return;
            }
            ((ContextRz)RzWin.Context).xHook.RemoveChatSession(xSession.UniqueID);
        }
        private void frmChatSession_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                case '\n':
                    if (!ToolsWin.Keyboard.GetControlKey())
                    {
                        e.Handled = true;
                        Send();
                    }
                    break; 
            }
        }
        private void lvSessions_Click(object sender, EventArgs e)
        {
            try
            {
                xSession = (Win.ChatSessionWin)lvSessions.SelectedItems[0].Tag;
                InitRe();
            }
            catch { }
        }
        private void cmdChatWithSomeone_Click(object sender, EventArgs e)
        {
            RzWin.Form.ChatWithSomeone();
        }
    }
}