using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace MultiSearch
{
    public partial class StatusScreen : UserControl
    {
        delegate void HandleStatus(String s);

        public StatusScreen()
        {
            InitializeComponent();
        }

        public void SetStatus(String NewStatus)
        {
            if (this.InvokeRequired)
            {
                HandleStatus d = new HandleStatus(SetStatusHandler);
                this.Invoke(d, new object[] { NewStatus });
            }
            else
            {
                SetStatusHandler(NewStatus);
            }
        }

        private void SetStatusHandler(String s)
        {
            String t = DateTime.Now.ToString("t");
            txtStatus.Text = t + " " + s + "\r\n" + Tools.Strings.Left(txtStatus.Text, 5000);
        }

        private void StatusScreen_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                txtStatus.Width = this.ClientRectangle.Width - txtStatus.Left;
                txtStatus.Top = 0;
                txtStatus.Height = this.ClientRectangle.Height;
            }
            catch (Exception)
            { }
        }

        private void cmdStockCheck_Click(object sender, EventArgs e)
        {
            Program.MainForm.CheckNextStock();
        }

        private void cmdRunEEM_Click(object sender, EventArgs e)
        {
            Program.MainForm.RunEEM(true);
        }

        private void chkIgnoreActivity_CheckedChanged(object sender, EventArgs e)
        {
            Program.IgnoreActivity = chkIgnoreActivity.Checked;
        }

        private void cmdBrokerforum_Click(object sender, EventArgs e)
        {
            Program.MainForm.RunBrokerForum(true);
        }
    }
}
