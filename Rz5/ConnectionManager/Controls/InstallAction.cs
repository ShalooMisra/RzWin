using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ConnectionManager
{
    public partial class InstallAction : ConnectionManagerPanel
    {
        //Contructors
        public InstallAction()
        {
            InitializeComponent();
            this.optDemo.Checked = true;
        }
        //Private Functions
        private bool IsOptionSelected()
        {
            if (this.optDemo.Checked || this.optClient.Checked || this.optServer.Checked)
                return true;
            else
                return false;
        }
        //Buttons
        protected override void cancelButton_Click(object sender, EventArgs e)
        {
            this.ParentForm.Dispose();
        }
        protected override void nextButton_Click(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            parent.Controls.Remove(this);

            if (this.optDemo.Checked)
            {
                SQLExpressInstall install = new SQLExpressInstall();
                parent.Controls.Add(install);

            }
            if (this.optClient.Checked)
            {
                ConnectionAdvanced server = new ConnectionAdvanced();
                parent.Controls.Add(server);
                //ConnectionSettingsBox settingsDialog = new ConnectionSettingsBox();
                //settingsDialog.Show();
            }
            //if (this.optServer.Checked)
            //{
            //    SQLExpressInstall install = new SQLExpressInstall();
            //    install.DefaultSQLInstance = true;
            //    parent.Controls.Add(install);
            //}
        }
        //Control Events
        //private void radioButton1_Click(object sender, EventArgs e)
        //{
        //    this.optDemo.Checked = true;
        //    this.optClient.Checked = false;
        //    this.optServer.Checked = false;
        //}
        //private void radioButton2_Click(object sender, EventArgs e)
        //{
        //    this.optDemo.Checked = false;
        //    this.optClient.Checked = true;
        //    this.optServer.Checked = false;
        //}
        //private void radioButton3_Click(object sender, EventArgs e)
        //{
        //    this.optDemo.Checked = false;
        //    this.optClient.Checked = false;
        //    this.optServer.Checked = true;
        //}
        //private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    MessageBox.Show("Rz INSTALLATION OPTIONS\r\n\r\nThe \"Quick Install\" option is designed for users who\r\n" +
        //                                                   "wish to install Rz and create a new database on their PC.\r\n" +
        //                                                   "Use this option if you're the only person in your office using Rz,\r\n" +
        //                                                   "or if this computer is going to be the Rz information server for the office.\r\n\r\n" +
        //                                                   "\"Paste connection settings\" is for users who\r\n" +
        //                                                   "have received the Rz connection settings from Recognin or an administrator\r\n" +
        //                                                   "as a block of text.  Just paste that block into the box and Rz will be correctly configured.\r\n\r\n" +
        //                                                   "\"Advanced configuration\" is for systems administrators\r\n" +
        //                                                   "and others who need to enter specific authentication and database\r\n" +
        //                                                   "information to connect to a server.", "Installation Options", MessageBoxButtons.OK);
        //}
    }
}
