using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class frmChooseGroup : Form
    {
        //Public Variables
        public String SelectedGroup;
        //Private Variables
        private n_user xu;
        private CoreClassHandle xc;

        //Constructors
        public frmChooseGroup()
        {
            InitializeComponent();
        }
        //Public Static Functions
        public static String Choose(String classId, n_user u)
        {
            CoreClassHandle c = RzWin.Context.Sys.CoreClassGet(classId);
            if (c == null)
                return "";

            frmChooseGroup xForm = new frmChooseGroup();
            xForm.CompleteLoad(u, c);
            xForm.ShowDialog();
            String g = xForm.SelectedGroup;
            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }
            return g;
        }
        //Public Functions
        public void CompleteLoad(n_user u, CoreClassHandle c)
        {
            xu = u;
            xc = c;
            LoadLV();

        }
        public void HighlightByName(String s)
        {
            foreach (ListViewItem i in lv.Items)
            {
                i.Selected = (i.Text == s);
            }
        }
        //Private Functions
        private void LoadLV()
        {
            ArrayList a = GetGroupNameArray();
            lv.Items.Clear();
            lv.BeginUpdate();
            try
            {
                foreach (String s in a)
                {
                    lv.Items.Add(s);
                }
            }
            catch { }
            lv.EndUpdate();
        }

        public ArrayList GetGroupNameArray()
        {
            String uw = "";
            if (xu != null)
            {
                if (!xu.SuperUser)
                {
                    String mt = "<none>";
                    if (Tools.Strings.StrExt(xu.main_n_team_uid))
                        mt = xu.main_n_team_uid;

                    uw = " and ( ( isnull(the_n_user_uid, '') = '' and isnull(the_n_team_uid, '') = '' ) or ( isnull(the_n_user_uid, '') = '" + xu.unique_id + "' ) or ( isnull(the_n_team_uid, '') = '" + mt + "' ))";
                }
            }

            return RzWin.Context.SelectScalarArray("select name from n_group where the_n_class_uid = '" + xc.Name + "' and isnull(name, '') > '' " + uw + " order by name");
        }

        private void ClickOK()
        {
            try
            {
                SelectedGroup = lv.SelectedItems[0].Text;
                this.Hide();
            }
            catch { }
        }

        private void DeleteSelectedGroup()
        {
            if (!Tools.Strings.StrExt(SelectedGroup))
                return;
            int comp = RzWin.Context.SelectScalarInt32("select count(*) from company where group_name like '%" + SelectedGroup + "%'");
            int cont = RzWin.Context.SelectScalarInt32("select count(*) from companycontact where group_name like '%" + SelectedGroup + "%'");
            if (comp <= 0 && cont <= 0)
            {
                if (RzWin.Leader.AskYesNo("Are you sure you want to delete the group: " + SelectedGroup + " ?"))
                    RzWin.Context.Execute("delete from n_group where name = '" + SelectedGroup + "'", false);
            }
            else
            {
                if (!RzWin.Leader.AskYesNo("Are you sure you want to delete the group: " + SelectedGroup + " ? It currently is linked to " + comp.ToString() + " companies, and " + cont.ToString() + " contacts in the system."))
                    return;
                RzWin.Context.Execute("delete from n_group where name = '" + SelectedGroup + "'", false);
                RzWin.Context.Execute("update company set group_name = '' where group_name like '%" + SelectedGroup + "%'");
                RzWin.Context.Execute("update companycontact set group_name = '' where group_name like '%" + SelectedGroup + "%'");
            }
            LoadLV();
        }

        //Buttons
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedGroup = "";
            this.Hide();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }
        //Control Events
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ClickOK();
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { SelectedGroup = lv.SelectedItems[0].Text; }
            catch { }
        }
        private void lv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            try { SelectedGroup = lv.SelectedItems[0].Text; }
            catch { }
        }

        bool HasGroupName(String g)
        {
            return RzWin.Context.StatementExists("select * from n_group where name = '" + RzWin.Context.Filter(g) + " and the_n_class_uid = '" + xc.Name + "'");
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = ctlName.GetValue_String().Replace(",", "").Trim();
            if (!Tools.Strings.StrExt(s))
            {
                RzWin.Leader.Tell("Please enter a name for the new group.");
                return;
            }
            if (HasGroupName(s))
            {
                RzWin.Leader.Tell("The group '" + s + "' already exists.");
                return;
            }

            RzWin.Context.Execute("insert into n_group (unique_id, the_n_class_uid, name, the_n_user_uid, the_n_team_uid ) values (cast(newid() as varchar(255)), '" + xc.Name + "', '" + RzWin.Context.Filter(s) + "', '', '')");

            CompleteLoad(xu, xc);
            ctlName.SetValue("");
            HighlightByName(s);
        }
        //Menus

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSelectedGroup();
        }
    }
}