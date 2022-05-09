using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace NewMethod
{
    public partial class SystemDerivationGuide : UserControl
    {
        n_sys TheSys;
        n_sys CreatedSystem = null;

        public SystemDerivationGuide()
        {
            InitializeComponent();
        }

        public void CompleteLoad(n_sys xs)
        {
            TheSys = xs;
            sl.CompleteLoad(xs);
        }

        public void LoadTargets()
        {
            targets.CompleteLoad();
        }

        private void ctlName_DataChanged(GenericEvent e)
        {
            ShowDerive();
        }

        void ShowDerive()
        {
            if( nData.IsValidDBObjectName(ctlName.GetValue_String()) )
            {
                cmdDerive.Text = "Derive " + ctlName.GetValue_String();
                cmdDerive.Enabled = true;
            }
            else
            {
                cmdDerive.Text = "Derive";
                cmdDerive.Enabled = false;
            }
        }

        private void cmdDerive_Click(object sender, EventArgs e)
        {
            n_data_target dt = targets.GetSelectedTarget();
            if (dt == null)
            {
                nStatus.TellUser("Please select a data target before continuing.");
                return;
            }

            nData d = new nData(dt);

            String s = "";
            if (!d.CanConnect(ref s))
            {
                nStatus.TellUser("This data source couldn't be contacted (" + s + ").");
                return;
            }

            String strName = ctlName.GetValue_String();
            if( d.StatementExists("select * from n_sys where system_name = '" + d.SyntaxFilter(strName) + "'") )
            {
                nStatus.TellUser("A system by this name already appears to exist.");
                return;
            }

            n_sys xs = TheSys.DeriveASystem(strName, d, sl.xStatusTarget);
            if (xs != null)
            {
                CreatedSystem = xs;
                cmdDerive.Visible = false;
                cmdOpenSystem.Visible = true;
                cmdOpenSystem.Text = "Open " + CreatedSystem.system_name;
            }            
        }

        private void cmdOpenSystem_Click(object sender, EventArgs e)
        {
            TheSys.ShowObject(CreatedSystem, n_sys.SoftStructureForm);
        }
    }
}
