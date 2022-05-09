using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tie;

namespace TieServerTest
{
    public partial class frmTest2 : Form
    {
        public frmTest2()
        {
            InitializeComponent();
        }

        private void cmdFTPTest_Click(object sender, EventArgs e)
        {
            VaultManager m = new VaultManager("RzRescue.xml_next_run_2010_7_18_1_0_0.txt");
            EternalFTPTarget target = new EternalFTPTarget(m);

            target.FtpFolder = "Prism";
            target.FtpSite = "warehouse.recognin.com";
            target.UserName = "recognin";
            target.UserPassword = "Rec0gnin";
            m.EternalFolder = "c:\\bilge\\eternaltest\\";
            
            target.Export();
        }
    }
}
