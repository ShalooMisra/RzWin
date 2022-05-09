using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmChooseFromDictionary : Form
    {
        public String ResultString = "";

        //Constructors
        public frmChooseFromDictionary()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static String Choose(Dictionary<String, String> d, String strCaption, bool AllowManualEntry, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseFromDictionary xForm = new frmChooseFromDictionary();
            xForm.CompleteLoad(d, AllowManualEntry);
            xForm.Text = strCaption;
            xForm.ShowDialog(owner);
            String s = xForm.ResultString;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return s;
        }
        //Public Functions
        public void CompleteLoad(Dictionary<String, String> d, bool AllowManualEntry)
        {
            txtSel.Enabled = AllowManualEntry;
            lv.BeginUpdate();
            foreach (KeyValuePair<String, String> kvp in d)
            {
                ListViewItem xLst = lv.Items.Add(kvp.Value.ToString());
                xLst.Tag = kvp.Key;                
            }
            lv.EndUpdate();
        }
        //Buttons
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Tools.Strings.StrExt(txtID.Text))
                    return;
                ResultString = txtID.Text;
                this.Hide();
            }
            catch (Exception)
            { }
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            ResultString = "";
            this.Hide();
        }
        //Control Events
        private void lv_Click(object sender, EventArgs e)
        {
            try
            {
                txtSel.Text = lv.SelectedItems[0].Text;
                txtID.Text = lv.SelectedItems[0].Tag.ToString();
            }
            catch (Exception)
            { }
        }
    }
}