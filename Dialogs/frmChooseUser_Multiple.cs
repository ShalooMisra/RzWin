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
    public partial class frmChooseUser_Multiple : Form
    {
        //Public Variables
        public ArrayList SelectedUserNames = new ArrayList();
        public Dictionary<string, string> SelectedUserIDs = new Dictionary<string, string>();
        //Private Variables
        private ContextNM TheContext;
        private ArrayList GetNames()
        {
            try
            {
                ArrayList a = new ArrayList();
                foreach (ListViewItem i in lv.CheckedItems)
                {
                    a.Add(i.Text);
                }
                return a;
            }
            catch
            {
                return new ArrayList();
            }
        }
        private Dictionary<string, string> GetIDs()
        {
            try
            {
                Dictionary<string, string> a = new Dictionary<string, string>();
                foreach (ListViewItem i in lv.CheckedItems)
                {
                    a.Add(i.Tag.ToString(), i.Text);
                }
                return a;
            }
            catch { return new Dictionary<string, string>(); }
        }
        private bool IDs = false;

        //Constructors
        public frmChooseUser_Multiple()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static ArrayList Choose(ArrayList choices, String caption, ArrayList def = null)
        {
            frmChooseUser_Multiple xForm = RzWin.Leader.GetChooseUserMultipleForm();
            xForm.CompleteLoad(choices, def);
            xForm.Text = caption;
            xForm.ShowDialog();
            ArrayList a = xForm.SelectedUserNames;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            return a;
        }
        public static Dictionary<string, string> Choose_IDs(ContextNM x, IWin32Window owner)
        {
            frmChooseUser_Multiple xForm = RzWin.Leader.GetChooseUserMultipleForm();
            xForm.CompleteLoad(x);
            xForm.ShowDialog(owner);
            Dictionary<string, string> a = xForm.SelectedUserIDs;
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
        public virtual void CompleteLoad(ArrayList a, ArrayList d)
        {
            lv.Columns.Remove(colContacts);
            columnHeader1.Width = lv.Width - 50;
            lv.Items.Clear();
            foreach (String s in a)
            {
                ListViewItem i = lv.Items.Add(Tools.Strings.ParseDelimit(s, "|", 1).Trim());
                if (d != null)
                    i.Checked = d.Contains(i.Text);
            }
        }
        public void CompleteLoad(ContextNM x)
        {
            CompleteLoad(x, null);
        }
        public void CompleteLoad(ContextNM x, ArrayList exclude_names)
        {
            IDs = true;
            TheContext = x;
            lv.Columns.Remove(colContacts);
            columnHeader1.Width = lv.Width - 50;
            lv.Items.Clear();
            string inn = "";
            if (exclude_names != null)
            {
                if (Tools.Strings.StrExt(Tools.Data.GetIn(exclude_names)))
                    inn = " and name not in (" + Tools.Data.GetIn(exclude_names) + ") ";
            }
            DataTable dt = RzWin.Context.Select("select unique_id,name from n_user where isnull(is_inactive,0) = 0 " + inn + " order by name");
            foreach (DataRow dr in dt.Rows)
            {
                ListViewItem i = lv.Items.Add(dr["name"].ToString());
                i.Tag = dr["unique_id"].ToString();
            }
        }
        //Private Functions
        private void CheckUnCheckAll()
        {
            try
            {
                foreach (ListViewItem xLst in lv.Items)
                {
                    xLst.Checked = chkAll.Checked;
                }
            }
            catch { }
        }
        //Control Events
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckUnCheckAll();
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedUserNames = new ArrayList();
            this.Hide();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (IDs)
            {             
                SelectedUserIDs = GetIDs();
                if (SelectedUserIDs.Count == 0)
                {
                    RzWin.Leader.Tell("Please select at least 1 user before continuing.");
                    return;
                }
            }
            else
            {                
                SelectedUserNames = GetNames();
                if (SelectedUserNames.Count == 0)
                {
                    RzWin.Leader.Tell("Please select at least 1 user before continuing.");
                    return;
                }
            }
            this.Hide();
        }
    }
}