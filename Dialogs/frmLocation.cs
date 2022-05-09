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
    public partial class frmLocation : Form
    {
        public static void GetLocationAndBox(partrecord xPart, ref String strLocation, ref String strBox, System.Windows.Forms.IWin32Window owner)
        {
            frmLocation xForm = new frmLocation();
            xForm.CompleteLoad(xPart);
            xForm.ShowDialog(owner);
            strLocation = xForm.SelectedLocation;
            strBox = xForm.SelectedBox;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
        }

        public String SelectedLocation = "";
        public String SelectedBox = "";

        public frmLocation()
        {
            InitializeComponent();
        }

        public void CompleteLoad(partrecord xPart)
        {
            lblPart.Text = "Part: " + xPart.fullpartnumber + "\r\nQty: " + Tools.Number.LongFormat(xPart.quantity) + "\r\nMfg: " + xPart.manufacturer + "\r\nD/C: " + xPart.datecode;
            ctlLocation.Focus();
            ctlLocation.SetValue(RzWin.Context.GetSetting("default_receive_location"));
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedLocation = ctlLocation.GetValue_String();
            SelectedBox = ctlBox.GetValue_String();
            this.Hide();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedLocation = "";
            SelectedBox = "";
            this.Hide();
        }
    }
}