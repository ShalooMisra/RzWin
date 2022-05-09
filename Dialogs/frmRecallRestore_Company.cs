using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Tools.Database;
using Core;

namespace Rz5
{
    public partial class frmRecallRestore_Company : Form
    {
        //Private Variables
        private ArrayList SelectedCompanies;
        private ContextNM TheContext;
        private DataConnectionSqlServer TheRecallData;
        private DataConnectionSqlServer TheRzData;

        //Constructors
        public frmRecallRestore_Company()
        {
            InitializeComponent();
        }
        //Public Functions
        public static ArrayList AskRecallRestore_Company(ContextNM x, DataConnectionSqlServer rz, DataConnectionSqlServer recall)
        {
            frmRecallRestore_Company f = new frmRecallRestore_Company();
            if (!f.CompleteLoad(x, rz, recall))
                return null;
            f.ShowDialog();
            return f.SelectedCompanies;
        }
        //Public Functions
        public bool CompleteLoad(ContextNM x, DataConnectionSqlServer rz, DataConnectionSqlServer recall)
        {
            if (x == null)
                return false;
            if (rz == null)
                return false;
            if (recall == null)
                return false;
            if (!rz.ConnectPossible())
                return false;
            if (!recall.ConnectPossible())
                return false;
            TheContext = x;
            TheRzData = rz;
            TheRecallData = recall;
            LoadLV();
            return true;
        }
        //Private Functions
        private void LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                string insert = "";
                if (Tools.Strings.StrExt(txtSearch.GetValue_String()))
                    insert = "companyname like '" + txtSearch.GetValue_String() + "%' and ";
                //KT - 11-13-2014 - Noticed Recall was only pulling a single company, seemingly because recall_type was explicitly called as "3".  In my tests, companies I deleted were recall_type 1, but there are also a lot of 2's
                //Rz Code
                ArrayList a = DataSql.QtC(RzWin.Context, "company", "select * from company where " + insert + " recall_type = 3 order by companyname", TheRecallData);
                //KT Code
                //ArrayList a = DataSql.QtC(RzWin.Context, "company", "select * from company where " + insert + " recall_type = 1 order by companyname", TheRecallData);
                if (a != null)
                {
                    foreach (company c in a)
                    {
                        ListViewItem l = lv.Items.Add(c.companyname);
                        l.Tag = c;
                    }
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void Cancel()
        {
            SelectedCompanies = null;
        }
        private void Select()
        {
            SelectedCompanies = new ArrayList();
            foreach (ListViewItem l in lv.CheckedItems)
            {
                SelectedCompanies.Add(l.Tag);
            }
            if (SelectedCompanies.Count <= 0)
                SelectedCompanies = null;
        }
        private void CheckUnCheckAll(bool c)
        {
            foreach (ListViewItem l in lv.Items)
            {
                l.Checked = c;
            }
        }
        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Cancel();
            Close();
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            Select();
            Close();
        }
        //Control Events
        private void chkCheckUnCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckUnCheckAll(chkCheckUnCheckAll.Checked);
        }
        private void txtSearch_zz_GotKeyUp(object sender, KeyEventArgs e)
        {
            LoadLV();
        }
    }
}
