using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmChooseContact_Multiple : Form
    {
        //Public Variables
        public ContextNM TheContext;
        public ArrayList SelectedContactNames = new ArrayList();
        public bool bContactEmail = false;

        //Constructors
        public frmChooseContact_Multiple()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static ArrayList Choose(company c, IWin32Window owner)
        {
            return Choose(c, owner, false);
        }
        public static ArrayList Choose(company c, IWin32Window owner, bool bEmail)
        {
            frmChooseContact_Multiple xForm = new frmChooseContact_Multiple();
            xForm.bContactEmail = bEmail;
            xForm.CompleteLoad(c, RzWin.Form.TheContextNM);
            xForm.ShowDialog(owner);
            ArrayList a = xForm.SelectedContactNames;
            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }
            return a;
        }
        //Public Functions
        public void CompleteLoad(company c)
        {
            CompleteLoad(c, RzWin.Form.TheContextNM);
        }
        public void CompleteLoad(company c, ContextNM x)
        {
            TheContext = x;
            lv.Items.Clear();
            if (c == null)
                return;
            DataTable dt = RzWin.Context.Select("select contactname, primaryemailaddress from companycontact where base_company_uid = '" + c.unique_id + "'");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem i = lv.Items.Add(dr["contactname"].ToString());
                i.SubItems.Add(dr["primaryemailaddress"].ToString());
                i.Checked = false;
            }
        }
        //Private Functions
        private ArrayList GetNames()
        {
            try
            {
                ArrayList a = new ArrayList();
                foreach (ListViewItem i in lv.CheckedItems)
                {
                    if(bContactEmail )
                        a.Add(i.SubItems[1].Text);
                    else
                        a.Add(i.Text);
                }
                return a;
            }
            catch
            {
                return new ArrayList();
            }
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedContactNames = new ArrayList();
            this.Hide();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedContactNames = GetNames();
            if (SelectedContactNames.Count == 0)
            {
                RzWin.Leader.Tell("Please select at least 1 contact before continuing.");
                return;
            }
            this.Hide();
        }
    }
}
