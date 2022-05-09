using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Tie;
using NewMethod;

namespace Rz5.RzTie
{
    public partial class HookStatus : UserControl
    {
        Hook xHook;

        public HookStatus()
        {
            InitializeComponent();
        }

        public void CompleteLoad(Hook h)
        {
            xHook = h;
            gb.Text = h.HostName + ":" + h.HostPort.ToString();
            xHook.GotStatus += new TieEndStatusHandler(xHook_GotStatus);

        }

        void CompleteDispose()
        {
            try
            {
                xHook.GotStatus -= new TieEndStatusHandler(xHook_GotStatus);
            }
            catch { }
        }

        void xHook_GotStatus(TieEnd end, string s)
        {
            txtStatus.AddLine(s);
        }

        private void HookStatus_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        void DoResize()
        {
            try
            {
                gb.Top = 0;
                gb.Left = 0;
                gb.Width = this.ClientRectangle.Width;

                txtStatus.Left = 0;
                txtStatus.Top = gb.Bottom;
                txtStatus.Width = this.ClientRectangle.Width;
                txtStatus.Height = this.ClientRectangle.Height - txtStatus.Top;
            }
            catch { }
        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            TieMessage m = new TieMessage(((ContextRz)RzWin.Context).xHook.SessionID, txtServerMessage.Text, "root");
            ((ContextRz)RzWin.Context).xHook.Send(m);
            txtStatus.AddLine("[Sent " + txtServerMessage.Text + " message to the server]");
        }
    }
}
