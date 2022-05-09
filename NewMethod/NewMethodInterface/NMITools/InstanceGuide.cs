using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class InstanceGuide : UserControl
    {
        n_sys xSys
        {
            get
            {
                return n_sys.ContextDefault.xSys;
            }
        }
        public InstanceGuide()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            sl.CompleteLoad(xSys);
        }

        public void LoadTargets()
        {
            targets.CompleteLoad();
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            //n_data_target t = targets.GetSelectedTarget();
            //if (t == null)
            //{
            //    nStatus.TellUser("Please choose a data target before continuing.");
            //    return;
            //}

            //xSys.ShowInstanceByTarget(t);
        }
    }
}
