using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nWorkBench : UserControl
    {
        n_sys xSys;

        public nWorkBench()
        {
            InitializeComponent();
        }

        public void CompleteLoad(n_sys xs)
        {
            xSys = xs;
        }

        private void cmdImportDataSources_Click(object sender, EventArgs e)
        {
            nArray a = n_data_target.GetLocalDataConnections(xSys);
            foreach (n_data_target t in a.All)
            {
                t.xSys = xSys;
                t.unique_id = "";
                t.ISave();
            }
            nStatus.TellUser("Done.");
        }
    }
}
