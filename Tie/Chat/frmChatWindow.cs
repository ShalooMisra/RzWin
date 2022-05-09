using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Collections;
using System.Xml;

namespace NewMethod.Chat
{
    public partial class frmChatWindow : Form
    {
        private Recognin.Communications.Chat.ChatNode _connection;
        private Recognin.Common.Session _session;
        private static Recognin.Common.Resolver _resolver = null;

        public delegate void GetSessions(Recognin.Common.Defines.EventArgs.NotificationEventArgs e);
        public delegate void AddListItem(Recognin.Common.Defines.EventArgs.NotificationEventArgs e);
        public delegate void DataTransfer(Recognin.Common.Defines.EventArgs.NotificationEventArgs e);

        public frmChatWindow(Recognin.Communications.Chat.ChatNode node, Recognin.Common.Session session)
        {
            InitializeComponent();
            _connection = node;
            _session = session;
            _resolver = new Recognin.Common.Resolver();
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(_resolver.LoadHandler);
        }

        public void _connection_Notification(object sender, ref Recognin.Common.Defines.EventArgs.NotificationEventArgs e)
        {
            //Check if the message is intended for this session...

            if ((e.SessionData != null) && (e.SessionData.SessionId != _session.SessionId))
                return;

            if (e.Message.MessageType == Recognin.Common.Defines.Enums.MessageTypeEnum.CHAT)
            {  //Add the message to the chat window...
                this.BeginInvoke(new AddListItem(SetChatText), new Object[] { e });
            }
            if (e.Message.MessageType == Recognin.Common.Defines.Enums.MessageTypeEnum.CONNECTIONCHANGE)
            {
            }

            if (e.Message.MessageType == Recognin.Common.Defines.Enums.MessageTypeEnum.DATATRANSFER)
            {
                this.BeginInvoke(new AddListItem(SetChatText), new Object[] { e });
                //Dont receive the file if you sent it...
                if (e.Message.SenderId != _connection.NodeId)
                    this.BeginInvoke(new DataTransfer(_dataTransfer), new Object[] { e });
            }

            if (e.Message.MessageType == Recognin.Common.Defines.Enums.MessageTypeEnum.SHUTDOWN)
            {
            }

        }

        void SetChatText(Recognin.Common.Defines.EventArgs.NotificationEventArgs e)
        {

            if (rtbMessages.Text != "")
                rtbMessages.AppendText("\n");
            rtbMessages.AppendText(e.Message.TimeStamp.ToLongTimeString() + " <" + _connection.GetConnectionDataFromId(e.Message.SenderId).Username + "> " + e.Message.TextMessage);
            rtbMessages.ScrollToCaret();

        }


        public void _dataTransfer(Recognin.Common.Defines.EventArgs.NotificationEventArgs e)
        {
            //List<string> _sessions = _mController.GetSessions();
            Recognin.Common.SessionMessage data = e.Message;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = Convert.ToString(data.GetProperty("Filename"));
            Recognin.Common.SessionMessage dm = new Recognin.Common.SessionMessage(_session.SessionId);
            dm.SenderId = _connection.NodeId;
            dm.TextMessage = sfd.FileName +" has been received.";
            dm.MessageType = Recognin.Common.Defines.Enums.MessageTypeEnum.CHAT;
            _connection.SendMessage(_session, dm);
                
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                byte[] buff = Convert.FromBase64String(Convert.ToString(data.GetProperty("File")));
                Recognin.Common.FileUtils.SaveFile(buff, sfd.FileName);
            }
        }

        private void frmRemoting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender != btnEndChat)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void btnSendData_Click(object sender, EventArgs e)
        {
            //Recognin.Common.DataModel dm = new Recognin.Common.DataModel("test");
            //dm.SetProperty("Message", tbChat.Text);
            if (_connection != null)
            {
                _connection.Chat(_session, tbChat.Text);
            }

            tbChat.Text = "";
            tbChat.Focus();
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Recognin.Common.SessionMessage dm = new Recognin.Common.SessionMessage(_session.SessionId);
                dm.SenderId = _connection.NodeId;
                dm.TextMessage = tbChat.Text;
                dm.MessageType = Recognin.Common.Defines.Enums.MessageTypeEnum.DATATRANSFER;
                //dm.SetProperty("Type", Recognin.Common.Defines.Enums.MessageTypeEnum.DATATRANSFER);
                byte[] buff = new byte[0];
                Recognin.Common.FileUtils.LoadFile(ofd.FileName, ref buff);
                string file = Convert.ToBase64String(buff);

                dm.SetProperty("Filename", Recognin.Common.FileUtils.GetFileInfo(ofd.FileName).Name);
                dm.TextMessage = "Sending file " + Recognin.Common.FileUtils.GetFileInfo(ofd.FileName).Name;
                dm.SetProperty("File", file);
                _connection.SendMessage(_session, dm);
            }
        }


        private void frmChatWindow_Load(object sender, EventArgs e)
        {
            tbChat.Focus();
        }

        private void btnEndChat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}