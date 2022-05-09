using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tie;

namespace TiePin
{
    public partial class frmPin : Form
    {
        public frmPin()
        {
            InitializeComponent();
        }

        public void SetTack(TieTack t)
        {
            hv.SetHook(t);
            TieDuty.LogFileMakeExist();
            lblDutyLogFile.Text = TieDuty.LogFileName;
        }

        private void cmdTestBackUpPatch_Click(object sender, EventArgs e)
        {

            VaultManager v = new VaultManager("C:\\Eternal\\Code\\Tie\\TiePin\\bin\\Release\\tack_se\\Duties\\RzRescue.xml");
            v.Start();
            v.Do();

        }
    }
}