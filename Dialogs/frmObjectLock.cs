using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class frmObjectLock : Form
    {
        public String ObjectCaption = "";
        public String ObjectID = "";
        public String MachineName = "";
        public String UserName = "";
        public String SessionID = "";
        public bool ItemHasFocus = false;

        public frmObjectLock()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            lblCaption.Text = "Warning on " + ObjectCaption;
            lblExplanation.Text = "The item " + ObjectCaption + " is apparently already open by " + UserName + " on the computer " + MachineName + ".";

            if( ItemHasFocus )
                lblExplanation.Text += "\r\n\r\nIt is apparently the main tab on the screen.";
            else
                lblExplanation.Text += "\r\n\r\nIt doesn't appear to be the main tab on the screen.";

            cmdCloseOther.Enabled = RzWin.User.SuperUser || RzWin.Context.CheckPermit("System:Far:Close");
        }

        private void cmdIgnore_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void cmdCloseOther_Click(object sender, EventArgs e)
        {
            RzWin.Logic.RequestObjectClose(((ContextRz)RzWin.Context), ObjectCaption, SessionID, ObjectID, RzWin.User.name, Environment.MachineName);
            this.Close();
            this.Dispose();
        }
    }
}