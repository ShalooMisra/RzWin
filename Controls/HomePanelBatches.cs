using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace Rz5
{
    public partial class HomePanelBatches : HomePanel
    {
        public HomePanelBatches()
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
                return new HomePanelBatchesArgs(txtSearch.Text, optOpen.Checked, optClosed.Checked, ddlOppStage.GetValue().ToString());
            }
        }

        private void HomePanelBatches_Load(object sender, EventArgs e)
        {
            ddlOppStage.LoadList(true);
            ddlOppStage.SetValue("All");
            
            
        }

       
        
    }
}
