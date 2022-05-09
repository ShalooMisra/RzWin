using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod.Chat
{
    public partial class ChatSettings : UserControl, ICompleteLoad
    {
        n_sys xSys;

        public ChatSettings()
        {
            InitializeComponent();
        }

        public void CompleteLoad(n_sys xs)
        {
            chkUseChat.Checked = xs.xUser.GetSetting_Boolean("use_chat_hook");
            chkUseChatSound.Checked = xs.xUser.GetSetting_Boolean("use_chat_sound");
            txtChatServer.Text = xs.xUser.GetSetting("chat_server_ip");
            txtChatSound.Text = xs.xUser.GetSetting("chat_sound");
            xSys = xs;
        }

        private void chkUseChat_CheckedChanged(object sender, EventArgs e)
        {
            if( xSys == null )
                return;

            xSys.xUser.SetSetting_Boolean("use_chat_hook", chkUseChat.Checked);
        }

        private void txtChatServer_TextChanged(object sender, EventArgs e)
        {
            if (xSys == null) return;
            xSys.xUser.SetSetting("chat_server_ip", txtChatServer.Text);
        }

        private void cmdReInit_Click(object sender, EventArgs e)
        {
            if (xSys.xUser == null || ChatHook.TheChatHook == null)
            {
                nStatus.TellUserTemp("Please restart the application to apply this change.");
                return;
            }

            ChatHook.TheChatHook.ServerDetail = txtChatServer.Text;
            ChatHook.StartChatHook(xSys, xSys.xUser);
            ChatHook.InitSoundSettings();
        }

        private void chkUseChatSound_CheckedChanged(object sender, EventArgs e)
        {
            if (xSys == null)
                return;

            xSys.xUser.SetSetting_Boolean("use_chat_sound", chkUseChatSound.Checked);
        }

        private void txtChatSound_TextChanged(object sender, EventArgs e)
        {
            if (xSys == null) return;
            xSys.xUser.SetSetting("chat_sound", txtChatSound.Text);
        }

        private void cmdBrowseSound_Click(object sender, EventArgs e)
        {
            String s = nTools.ChooseAFile(this.ParentForm);
            if (nTools.StrExt(s))
                txtChatSound.Text = s;
        }

        private void cmdPlay_Click(object sender, EventArgs e)
        {
            nSound.PlaySound(txtChatSound.Text);
        }
    }
}
