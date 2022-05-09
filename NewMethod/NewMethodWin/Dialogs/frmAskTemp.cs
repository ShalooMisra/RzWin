using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmAskTemp : Form
    {
        public bool Answer = false;
        int sec = 0;
        public frmAskTemp()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String s)
        {
            lblCaption.Text = s;
            tmr.Start();
        }

        private void cmdYes_Click(object sender, EventArgs e)
        {
            Answer = true;
            this.Hide();
        }

        private void cmdNo_Click(object sender, EventArgs e)
        {
            Answer = false;
            this.Hide();
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            sec++;
            int left = 10 - sec;
            lblTime.Text = left.ToString();
            if (left == 0)
            {
                Answer = false;
                this.Hide();
            }
        }
    }
}