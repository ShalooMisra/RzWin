using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using nmTie;

namespace NewMethod.Chat
{
    public partial class frmChatSession : Form
    {
        public ChatSession xSession;

        public frmChatSession()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            this.Text = "Chat Session with " + xSession.xClient.strUserName + " on " + xSession.xClient.strMachineName;
            wb.ReloadWB();
        }

        private void frmChatSession_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChatHook.RemoveSession(xSession.UniqueID);
        }

        public void BringBack()
        {
            if (InvokeRequired)
                Invoke(new BringBackHandler(ActuallyBringBack));
            else
                ActuallyBringBack();
        }

        [DllImport("User32")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        delegate void BringBackHandler();
        public void ActuallyBringBack()
        {
            try
            {
                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;

                SetForegroundWindow(this.Handle);                
            }
            catch { }
        }

        delegate void SetEnabledHandler(bool enabled);
        public void SetEnabled(bool enabled)
        {
            if (InvokeRequired)
                Invoke(new SetEnabledHandler(ActuallySetEnabled), new object[] { enabled });
            else
                ActuallySetEnabled(enabled);
        }

        void ActuallySetEnabled(bool enabled)
        {
            if (enabled)
            {
                AddText("Re-Connected", Color.Green);
                cmdSend.Enabled = true;
            }
            else
            {
                AddText("Disconnected", Color.Red);
                cmdSend.Enabled = false;
            }
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            Send();
        }

        public void Send()
        {
            if (!nTools.StrExt(txtSend.Text))
                return;

            AddText(txtSend.Text, Color.Gray);

            TieMessage m = new TieMessage(ChatHook.TheChatHook.MyConnection);
            m.ToID = xSession.xClient.strConnectionID;
            m.FunctionName = "chat";
            m.Content = "<chat><n_user_uid>" + ChatHook.ChatUser.unique_id + "</n_user_uid>" + "<user_name>" + ChatHook.ChatUser.name + "</user_name><id>" + ChatHook.TheChatHook.MyConnection.UniqueID + "</id><machine>" + Environment.MachineName + "</machine><chat_text>" + txtSend.Text + "</chat_text></chat>";
            ChatHook.TheChatHook.MyConnection.Send(m);

            txtSend.Text = "";
        }

        public void Add(ChatMessage m)
        {
            if (InvokeRequired)
                Invoke(new ChatMessageAddHandler(ActuallyAdd), new object[] { m });
            else
                ActuallyAdd(m);
        }

        delegate void ChatMessageAddHandler(ChatMessage m);
        public void ActuallyAdd(ChatMessage m)
        {
            AddText(m.ChatText, Color.Blue);
        }

        public void AddText(String strText, Color color)
        {
            wb.Add("<br><hr><font color=\"" + color.Name + "\">" + nTools.ConvertTextToHTML(strText) + "</font><br>");
            wb.ScrollToBottom();
        }
    }
}