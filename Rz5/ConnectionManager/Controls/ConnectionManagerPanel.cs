using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ConnectionManager
{
    public partial class ConnectionManagerPanel : UserControl
    {
        //Constructors
        public ConnectionManagerPanel()
        {
            InitializeComponent();
        }
        //Protected Virtual Functions
        protected virtual void EnableNextButton(bool enabled)
        {
            this.nextButton.Enabled = enabled;
        }
        //Buttons
        protected virtual void cancelButton_Click(object sender, EventArgs e)
        {

        }
        protected virtual void nextButton_Click(object sender, EventArgs e)
        {

        }
        //Control Events
        private void lblRequstLiveSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:mike@recognin.com");
            }
            catch { }
        }
        private void lblRecogninDotCom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.FileSystem.Shell("http://www.recognin.com");
        }
    }
}
