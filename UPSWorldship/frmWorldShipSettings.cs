using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmWorldShipSettings : Form
    {
        //Constructors
        public frmWorldShipSettings()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            ctlXMLPath.SetValue(UPSWorldship.XMLPath(RzWin.Context));
        }
        //Buttons
        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            //upworldship_xmlpath
            DialogResult dr = xFolder.ShowDialog();
            if (dr == DialogResult.Cancel)
                return;
            ctlXMLPath.SetValue(xFolder.SelectedPath);
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            UPSWorldship.XMLPathSet(RzWin.Context, ctlXMLPath.GetValue_String());
            UPSWorldship.UseWorldShipSet(RzWin.Context, ctlUseWorldship.GetValue_Boolean());
            this.Close();
        }
    }
}
