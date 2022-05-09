using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmNewForm : Form
    {

        public static String GetAction(n_class c, IWin32Window owner)
        {
            frmNewForm f = new frmNewForm();
            f.CompleteLoad(c);
            f.ShowDialog(owner);
            String r = f.SelectedAction;

            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }

            return r;
        }

        public n_class CurrentClass;
        public String SelectedAction = "";
        
        public frmNewForm()
        {
            InitializeComponent();
        }

        public void CompleteLoad(n_class c)
        {
            CurrentClass = c;
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedAction = "";
            this.Hide();
        }

        private void cmdAutoDesign_Click(object sender, EventArgs e)
        {
            SelectedAction = "auto";
            this.Hide();
        }

        private void cmdBlankScreen_Click(object sender, EventArgs e)
        {
            SelectedAction = "blank";
            this.Hide();
        }

        private void cmdGenericList_Click(object sender, EventArgs e)
        {
            SelectedAction = "list";
            this.Hide();
        }
    }
}