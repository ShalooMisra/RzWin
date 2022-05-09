using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseStringFromArray : Form
    {
        //Public Variables
        public string SelectedValue = "";

        //Constructors
        public frmChooseStringFromArray()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static string ChooseStringFromArray(ArrayList a, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseStringFromArray xForm = new frmChooseStringFromArray();
            xForm.CompleteLoad(a, strCaption);
            xForm.ShowDialog(owner);
            return xForm.SelectedValue;
        }
        //Public Functions
        public void CompleteLoad(ArrayList a, String strCaption)
        {
            lblCaption.Text = strCaption;
            LoadLV(a);
        }
        //Private Functions
        private void OK()
        {
            SelectedValue = "";
            try { SelectedValue = lv.SelectedItems[0].Text; }
            catch { }
            Close();
        }
        private void Cancel()
        {
            SelectedValue = "";
            Close();
        }
        private void LoadLV(ArrayList a)
        {
            lv.SuspendLayout();
            lv.Items.Clear();
            try
            {
                foreach (string s in a)
                {
                    lv.Items.Add(s);
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        //Buttons
        private void cmdOK_Click(object sender, EventArgs e)
        {
            OK();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
