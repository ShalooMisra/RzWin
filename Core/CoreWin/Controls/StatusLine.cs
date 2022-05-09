using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace CoreWin
{
    public partial class nStatusLine : UserControl
    {

        delegate void HandleSetStatus(String status);
        delegate void HandleSetProgress(int progress);

        public nStatusLine()
        {
            InitializeComponent();
        }

        private void nStatusLine_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                pb.Left = 0;
                pb.Top = 0;
                pb.Width = this.ClientRectangle.Width;
                lblStatus.Left = 0;
                lblStatus.Width = this.ClientRectangle.Width - lblElapsed.Width;
                lblElapsed.Left = this.ClientRectangle.Width - lblElapsed.Width;

            }
            catch
            {

            }
        }

        public void SetStatusHandler(String status)
        {
            lblStatus.Text = status;
        }

        public void SetStatus(String status)
        {
            if (lblStatus.InvokeRequired)
            {
                HandleSetStatus d = new HandleSetStatus(SetStatusHandler);
                this.Invoke(d, new object[] { status });
            }
            else
            {
                SetStatusHandler(status);
            }
        }

        public void SetProgressHandler(int progress)
        {
            try
            {
                pb.Value = progress;
            }
            catch { }
        }

        public void SetProgress(int progress)
        {
            if (pb.InvokeRequired)
            {
                HandleSetProgress d = new HandleSetProgress(SetProgressHandler);
                this.Invoke(d, new object[] { progress });
            }
            else
            {
                SetProgressHandler(progress);
            }
        }
    }
}
