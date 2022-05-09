using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethodx;

namespace TiePin
{
    public partial class frmTackName : Form
    {
        public static String Enter(IWin32Window owner, String original)
        {
            frmTackName xForm = new frmTackName();
            xForm.SetText(original);
            xForm.ShowDialog(owner);
            String s = xForm.SelectedName;
            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }
            return s;
        }

        public String SelectedName = "";

        public frmTackName()
        {
            InitializeComponent();
        }

        public void SetText(String s)
        {
            txt.Text = s;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedName = "";
            this.Hide();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedName = txt.Text;
            this.Hide();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            cmdOK.Enabled = Tools.Strings.StrExt(txt.Text);
        }
    }
}