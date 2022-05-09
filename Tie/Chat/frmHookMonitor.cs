using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using nmTie;

namespace NewMethod.Chat
{
    public partial class frmHookMonitor : Form
    {
        public nHook xHook;

        public frmHookMonitor()
        {
            InitializeComponent();
        }

        public void SetHook(nHook h)
        {
            xHook = h;
            xHook.GotStatus += new TieEnd.GotStatusHandler(xHook_GotStatus);
        }

        void xHook_GotStatus(string s)
        {
            SetStatus(s);
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
            catch (Exception)
            { }
        }
    }
}