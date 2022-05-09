using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class HomePanelNotes : HomePanel
    {
        public HomePanelNotes()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            SearchClickedFire();
        }

        public override HomePanelSearchArgs SearchArgs
        {
            get
            {
                return new HomePanelNotesArgs(txtSearch.Text, optOpen.Checked, optClosed.Checked);
            }
        }
    }
}
