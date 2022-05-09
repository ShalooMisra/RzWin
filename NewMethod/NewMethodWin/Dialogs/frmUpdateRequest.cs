using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmUpdateRequest : Form
    {
        public static bool RequestVersionUpdate(System.Windows.Forms.IWin32Window owner)
        {
            frmUpdateRequest xForm = new frmUpdateRequest();
            xForm.CompleteLoad();
            xForm.ShowDialog(owner);
            bool b = xForm.AllowUpdate;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return b;
        }

        public bool AllowUpdate = true;
        private int Seconds = 0;
        public frmUpdateRequest()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            Seconds = 10;
            ShowTime();
            tmrCount.Start();
        }

        private void ShowTime()
        {
            lblTime.Text = "Closing in " + Seconds.ToString() + " seconds...";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            tmrCount.Stop();
            AllowUpdate = true;
            this.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            tmrCount.Stop();
            AllowUpdate = false;
            this.Hide();
        }

        private void tmrCount_Tick(object sender, EventArgs e)
        {
            Seconds--;
            if (Seconds <= 0)
            {
                tmrCount.Stop();
                AllowUpdate = true;
                this.Hide();
            }
            else
            {
                ShowTime();
            }
        }
    }
}