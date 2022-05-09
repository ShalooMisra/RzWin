using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class GroupManager : UserControl
    {
        CoreClassHandle classHandle;
        n_group CurrentGroup;

        public GroupManager()
        {
            InitializeComponent();
        }

        public void CompleteLoad(String className)
        {
            NMWin.ContextDefault.TheSys.CoreClassGet(className);
            lv.ShowTemplate("groups_by_class", "n_group", true);

            if (classHandle != null)
            {
                lv.ShowData("n_group", "the_n_class_uid = '" + classHandle.Name + "'", "name");  //this was the class id; needs to be converted
                lblRemove.Visible = false;  // Tools.Strings.StrExt(xSys.GetGroupFieldName(classHandle.Name));
                lblClass.Text = classHandle.TheAttribute.Caption;
            }
            else
            {
                lblClass.Text = "<class not found>";
            }


            LoadGroup(null);
            
        }

        private void lv_AboutToAdd(object sender, AddArgs args)
        {
            NMWin.ContextDefault.Reorg();
            //args.Handled = true;
            //String s = NMWin.Leader.AskForString("New group name:", "new group 1", "New group name");
            //if (!Tools.Strings.StrExt(s))
            //    return;

            //if (xClass.HasGroupName(s))
            //{
            //    nStatus.TellUser("Class " + xClass.GetFriendlyName() + " already has a group named '" + s + "'");
            //    return;
            //}

            //n_group g = xClass.AddGroupName(s);
            //lv.ReDoSearch();

            //LoadGroup(g);
        }

        private void LoadGroup(n_group g)
        {
            NMWin.ContextDefault.Reorg();
            //CurrentGroup = g;

            //if (g == null)
            //{
            //    gbg.Visible = false;
            //    return;
            //}
            //else
            //{
            //    gbg.Visible = true;
            //    gbg.Text = "Group: " + g.name;

            //    ctlName.SetValue(g.name);

            //    if (Tools.Strings.StrExt(g.the_n_team_uid))
            //    {
            //        n_team t = n_team.GetByID(xSys, g.the_n_team_uid);
            //        if (t == null)
            //            lblPermit.Text = "<all>";
            //        else
            //            lblPermit.Text = "Team: " + t.name;

            //    }
            //    else if (Tools.Strings.StrExt(g.the_n_user_uid))
            //    {
            //        n_user u = n_user.GetByID(xSys, g.the_n_user_uid);
            //        if (u == null)
            //            lblPermit.Text = "<all>";
            //        else
            //            lblPermit.Text = "Agent: " + u.name;
            //    }
            //    else
            //    {
            //        lblPermit.Text = "<all>";
            //    }
            //}
        }

        private void cmdApply_Click(object sender, EventArgs e)
        {
            SaveGroup();
        }

        private void SaveGroup()
        {
            NMWin.ContextDefault.Reorg();
            //if (CurrentGroup == null)
            //    return;

            //CurrentGroup.name = ctlName.GetValue_String();

            //CurrentGroup.ISave();
            //lv.ReDoSearch();
            //LoadGroup(CurrentGroup);
        }

        private void lv_ObjectClicked(object sender, ObjectClickArgs args)
        {
            try
            {
                n_group g = (n_group)lv.GetSelectedObject();
                if (g == null)
                    return;

                LoadGroup(g);
            }
            catch { }
        }

        private void lblSetTeam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NMWin.ContextDefault.Reorg();
            //try
            //{
            //    n_team t = (n_team)frmChooseObject.ChooseFromSQL(this.ParentForm, xSys, "n_team", "", "name");
            //    if( t == null )
            //        return;

            //    CurrentGroup.the_n_team_uid = t.unique_id;
            //    CurrentGroup.the_n_user_uid = "";
            //    SaveGroup();
            //    LoadGroup(CurrentGroup);
            //}
            //catch{}
        }

        private void lblSetUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NMWin.ContextDefault.Reorg();
            //try
            //{
            //    String strName = "";
            //    String strID = "";
            //    frmChooseUser.ChooseUserName(xSys, ref strID, ref strName, this.ParentForm, null, false);
            //    if( !Tools.Strings.StrExt(strID) )
            //        return;

            //    CurrentGroup.the_n_user_uid = strID;
            //    CurrentGroup.the_n_team_uid = "";
            //    SaveGroup();
            //    LoadGroup(CurrentGroup);
            //}
            //catch{}
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentGroup == null)
                return;

            CurrentGroup.the_n_user_uid = "";
            CurrentGroup.the_n_team_uid = "";
            SaveGroup();
            LoadGroup(CurrentGroup);
        }

        private void GroupManager_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            lv.Left = 0;
            lv.Height = this.ClientRectangle.Height - lv.Top;

            gbg.Top = 0;
            gbg.Height = this.ClientRectangle.Height;
            gbg.Width = this.ClientRectangle.Width - gbg.Width;
        }

        private void lblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NMWin.ContextDefault.Reorg();
            //if (CurrentGroup == null)
            //    return;

            //String strField = xSys.GetGroupFieldName(xClass.class_name);
            //if (!Tools.Strings.StrExt(strField))
            //{
            //    nStatus.TellUser("No link found.");
            //    return;
            //}

            //if (!nStatus.AreYouSure("permanently remove the group '" + CurrentGroup.name + "'"))
            //    return;

            //nStatus.StartPopStatus("Counting...");

            //String strWhere = strField + " like '%," + xSys.xData.SyntaxFilter(CurrentGroup.name) + ",%'";

            //long l = xSys.xData.GetScalar_Long("select count(*) from " + xClass.class_name + " where " + strWhere);
            //if (l == 0)
            //{
            //    nStatus.SetStatus("No items appear to be in group '" + CurrentGroup.name + "'");
            //    nStatus.SetStatus("Done.");
            //}
            //else
            //{
            //    if (!nStatus.AreYouSure("remove " + Tools.Number.LongFormat(l) + " from group '" + CurrentGroup.name + "'"))
            //        return;

            //    String strSQL = "update " + xClass.class_name + " set " + strField + " = replace(" + strField + ", '," + xSys.xData.SyntaxFilter(CurrentGroup.name) + ",', '') where " + strWhere;
            //    nStatus.SetStatus("Deleting...");

            //    xSys.xData.Execute(strSQL, ref l);
            //    nStatus.SetStatus("Done: " + Tools.Number.LongFormat(l) + " items removed from group '" + CurrentGroup.name + "'");
            //}
            //CurrentGroup.IDelete();
            //nStatus.StopPopStatus(true);

            //CompleteLoad(xSys, xClass.class_name);            
        }
    }
}
