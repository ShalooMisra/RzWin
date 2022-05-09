using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ConnectionManagerCore;

namespace ConnectionManager
{
    public partial class ConnectionTest : Form
    {
        public ConnectionTest()
        {
            InitializeComponent();
            Init();

            this.cmdTryAgain.Enabled = false;
        }

        public void Init()
        {
            Tools.Style.StyleCurrent.IconFormDefault = this.Icon;

            if (bg.IsBusy)
                return;

            lblMessage.ForeColor = Color.Gray;
            lblMessage.Text = "Testing the connection...";
            lblReset.Enabled = false;

            bg.RunWorkerAsync();          
        }

        private void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!ToolsWin.Dialogs.AreYouSure.Ask(null, "delete the Rz connection settings and start over"))
                return;

            ToolsConnection.ConnectionFileDelete();
            ToolsConnection.ConnectionManagerRestart();
            this.Close();
        }

        private void cmdTryAgain_Click(object sender, EventArgs e)
        {
            this.lblExplanation.Text = "Testing the Rz connection...";
            Init();            
        }

        
        bool TestPassed = false;
        String TestMessage = "";

        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            String err = "";
            if (ToolsConnection.TestConnect(ref err))
            {
                TestPassed = true;
                
            }
            else
            {
                TestPassed = false;
                TestMessage = "Connection Failed; " + err;
            }  
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (TestPassed)
            {
                this.cmdTryAgain.Enabled = false;
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Connection OK; Close this screen and open Rz to continue";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = TestMessage;
                this.lblExplanation.Text = "Rz cannot connect to its information source.  Check this computer\'s network conne" +
                "ction and server availability and click \'Try Again\' to see if the connection has" +
                " been restored.";
                this.cmdTryAgain.Enabled = true;
            }
            lblReset.Enabled = true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
