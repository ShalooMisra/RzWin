using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class nTeams : UserControl, ICompleteLoad
    {
        //Public Events
        public event ShowHandler AboutToThrow;
        //Public Variables
        SysNewMethod xSys
        {
            get
            {
                return NMWin.ContextDefault.xSys;
            }
        }
        //Private Variables
        private bool ChangesMade = false;
        private n_team CurrentTeam;
        private n_user CurrentUser;
        private bool inhibit_resize = false;

        //Constructors
        public nTeams()
        {
            InitializeComponent();
            lstUsers.AllowDrag = true;
        }
        //Public Functions
        public void CompleteLoad()
        {
            LoadUsers();
            LoadTeams();
            //DoResize();
        }
        public void DoResize()
        {
            if (inhibit_resize)
                return;

            inhibit_resize = true;

            try
            {
                sc.Top = 0;
                sc.Left = 0;
                sc.Width = this.ClientRectangle.Width;
                sc.Height = this.ClientRectangle.Height;

                tv.Left = 0;
                tv.Top = 0;
                tv.Height = sc.Panel2.ClientRectangle.Height - cmdNewTeam.Height;

                if (gbPermissions.Visible)
                {
                    tv.Width = sc.Panel2.ClientRectangle.Width - gbPermissions.Width;
                    gbPermissions.Top = 0;
                    gbPermissions.Left = tv.Right;
                    gbPermissions.Height = sc.Panel2.ClientRectangle.Height;

                    tvPermit.Height = gbPermissions.Height - (tvPermit.Top + cmdPaste.Height);
                    cmdPaste.Top = tvPermit.Bottom;
                    cmdListPermissions.Top = tvPermit.Bottom;
                    cmdRemoveAll.Top = tvPermit.Bottom;
                }
                else
                {
                    tv.Width = sc.Panel2.ClientRectangle.Width;
                }

                cmdNewTeam.Left = 0;
                cmdNewTeam.Top = tv.Bottom;
                cmdNewTeam.Width = tv.Width;
            }
            catch (Exception)
            { }

            inhibit_resize = false;
        }
        public void LoadTeams(TreeNodeCollection nodes, n_team parent)
        {
            nArray l;
            if (parent == null)
                l = xSys.TeamTree;
            else
                l = parent.TeamTree;

            TreeNode n;
            if (l != null)
            {
                foreach (n_team t in l.All)
                {
                    n = nodes.Add(t.name);
                    n.Tag = t;
                    n.ImageIndex = 1;
                    n.SelectedImageIndex = 1;
                    LoadMembers(n.Nodes, t.unique_id);
                    LoadTeams(n.Nodes, t);
                }
            }
        }
        public n_team GetSelectedTeam()
        {
            TreeNode n = tv.SelectedNode;
            if (n == null)
                return null;

            try
            {
                return (n_team)n.Tag;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public nList GetUserList()
        {
            return lstUsers;
        }
        //Private Functions
        private void LoadUsers()
        {
            lstUsers.ShowTemplate("all_users", "n_user");
            int boolSQLShowInactive = 0;
            if (cbx_show_inactive.zz_CheckValue == true)
                boolSQLShowInactive = 1;
            lstUsers.ShowData("n_user", "is_inactive = "+ boolSQLShowInactive, "name", -1);
        }
        private void LoadTeams()
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();
            LoadTeams(tv.Nodes, null);
            tv.ExpandAll();
            tv.EndUpdate();
        }
        private void LoadMembers(TreeNodeCollection nodes, String strTeamID)
        {
            ArrayList l = NMWin.ContextDefault.QtC("n_member", "select * from n_member where the_n_team_uid = '" + strTeamID + "'");
            
            TreeNode n;
            n_user u;

            foreach (n_member m in l)
            {
                u = n_user.GetById(NMWin.ContextDefault, m.the_n_user_uid);
                if( u != null )
                {
                    n = nodes.Add(u.name);
                    n.Tag = m;

                    if (m.is_captain)
                    {
                        n.ImageIndex = 3;
                        n.SelectedImageIndex = 3;
                    }
                    else
                    {
                        n.ImageIndex = 0;
                        n.SelectedImageIndex = 0;
                    }
                }
            }
        }
        private n_team GetTeamByCoords(Point p)
        {
            TreeNode n = tv.GetNodeAt(p);
            if (n == null)
                return null;

            try
            {
                return (n_team)n.Tag;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private n_member GetSelectedMember()
        {
            TreeNode n = tv.SelectedNode;
            if (n == null)
                return null;

            try
            {
                return (n_member)n.Tag;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void ShowTeamPermissions(n_team t)
        {
            ViewEditPermissions v = new ViewEditPermissions();
            v.CompleteLoad(t);
            NMWin.MainForm.TabShow(v, "Permissions");
            //CurrentUser = null;
            //CurrentTeam = null;  //so that the checks and un-checks don't set anything
            //ShowPermissionTree();
            //if (tvPermit.Nodes.Count == 0)
            //    LoadPermissionTree();
            //else
            //    ClearPermissionTree();
            //ArrayList a = t.GetPermitArray(true);
            //LoadPermitArray(a, true);
            //a = t.GetPermitArray(false);
            //LoadPermitArray(a, false);
            //CurrentTeam = t;  //so that they do
        }
        private void ShowUserPermissions(n_user u)
        {
            if (u.super_user)
            {
                NMWin.Leader.Tell("This user is a super-user, permissions do not apply to super-users.");
                return;
            }
            ViewEditPermissions v = new ViewEditPermissions();
            v.CompleteLoad(u);
            NMWin.MainForm.TabShow(v, "Permissions");
            //CurrentTeam = null;
            //CurrentUser = null;  //so that the checks and un-checks don't set anything
            //ShowPermissionTree();
            //if (tvPermit.Nodes.Count == 0)
            //    LoadPermissionTree();
            //else
            //    ClearPermissionTree();
            //ArrayList a = u.GetPermitArray(true);
            //LoadPermitArray(a, true);
            //a = u.GetPermitArray(false);
            //LoadPermitArray(a, false);
            //CurrentUser = u;  //so that they do
        }
        private void LoadPermitArray(ArrayList a, bool positive)
        {
            LoadPermitArray(a, tvPermit.Nodes, positive);
        }
        private void LoadPermitArray(ArrayList a, TreeNodeCollection nodes, bool positive)
        {
            foreach (TreeNode n in nodes)
            {
                try
                {
                    String s = (String)n.Tag;
                    if (Tools.Strings.StrExt(s))
                    {
                        if (nTools.IsInArray(a, s))
                        {
                            if (positive)
                            {
                                n.Checked = true;
                                n.ForeColor = Color.Green;
                            }
                            else
                            {
                                n.Checked = false;
                                n.ForeColor = Color.Red;
                            }
                        }
                    }
                }
                catch
                { }
                LoadPermitArray(a, n.Nodes, positive);
            }
        }
        private void ShowPermissionTree()
        {
            gbPermissions.Visible = true;
            DoResize();
        }
        private void ClearPermissionTree()
        {
            CurrentTeam = null;
            foreach (TreeNode n in tvPermit.Nodes)
            {
                ClearChecks(n);
            }
        }
        private void ClearChecks(TreeNode n)
        {
            n.Checked = false;
            n.ForeColor = Color.Blue;
            foreach (TreeNode m in n.Nodes)
            {
                ClearChecks(m);
            }
        }
        private void LoadPermissionTree()
        {
            tvPermit.Nodes.Clear();
            NMWin.Leader.Comment("Filling permission tree...");
            tvPermit.BeginUpdate();
            try
            {
                ArrayList a = NMWin.Data.GetScalarArray("select distinct(name) from n_permit order by name");

                ArrayList a1 = new ArrayList();
                foreach (String s in a)
                {
                    String s1 = Tools.Strings.ParseDelimit(s, ":", 1);
                    if (Tools.Strings.StrExt(s1))
                    {
                        if (!nTools.IsInArray(a1, s1))
                            a1.Add(s1);
                    }
                }

                ArrayList a2 = new ArrayList();
                foreach (String s in a)
                {
                    String s2 = Tools.Strings.ParseDelimit(s, ":", 2);
                    if (Tools.Strings.StrExt(s2))
                    {
                        if (!nTools.IsInArray(a2, s2))
                        {
                            a2.Add(s2);
                        }
                    }
                }

                foreach (String i1 in a1)
                {
                    AddNode(i1, tvPermit.Nodes, a2, a);
                }
                tv.ExpandAll();
            }
            catch
            {

            }
            tvPermit.EndUpdate();
        }
        private void AddNode(String strName, TreeNodeCollection nodes, ArrayList splits, ArrayList all)
        {
            TreeNode n = nodes.Add(strName);
            n.ForeColor = Color.Gray;
            foreach (String s in splits)
            {
                bool b = false;
                foreach (String x in all)
                {
                    if (x.ToLower().StartsWith(strName.ToLower() + ":" + s.ToLower() + ":"))
                    {
                        b = true;
                        break;
                    }
                }

                if (b)
                {
                    TreeNode m = n.Nodes.Add(s);
                    m.ForeColor = Color.Gray;
                    foreach (String l in all)
                    {
                        if (l.ToLower().StartsWith(strName.ToLower() + ":" + s.ToLower() + ":"))
                        {
                            TreeNode o = m.Nodes.Add(l);
                            o.Tag = l;
                            o.ForeColor = Color.Blue;
                        }
                    }
                    m.ExpandAll();
                }
            }
            n.ExpandAll();
        }
        private void CreateNewTeam()
        {
            n_team t = GetSelectedTeam();
            String s = NMWin.Leader.AskForString("What is the name of this team?", "Team_1", false, "Team Name");
            if (!Tools.Strings.StrExt(s))
                return;
            if (t != null)
            {
                n_team ex = n_team.GetByName(NMWin.ContextDefault, s, " the_n_team_uid = '" + t.unique_id + "'");
                if (ex != null)
                {
                    NMWin.Leader.Tell("The team name '" + s + "' is already in use.");
                    return;
                }
            }
            n_team n = n_team.New(NMWin.ContextDefault);
            n.name = s;
            if (t != null)
                n.the_n_team_uid = t.unique_id;
            NMWin.ContextDefault.Insert(n);
            n.TeamTree = new nArray();
            if (t != null)
            {
                n.FillTeamTree(NMWin.ContextDefault, t, null);
                t.AbsorbTeam(n);
            }
            xSys.AbsorbTeam(n);
            CompleteLoad();
        }
        private void ShowTeam()
        {
            if (tv.SelectedNode.Tag is n_team)
            {                
                n_team t = (n_team)tv.SelectedNode.Tag;
                ShowTeamPermissions(t);
            }
        }
        private void UpdateUserPermits(n_team t, n_user u)
        {
            try
            {
                if (t == null)
                    return;
                if (u == null)
                    return;
                u.RemoveAllPermits(NMWin.ContextDefault);
                foreach (DictionaryEntry d in t.AllPermits)
                {
                    n_permit p = (n_permit)d.Value;
                    u.AddPermit(NMWin.ContextDefault, p.name, p.is_positive);
                }
            }
            catch { }
        }
        //Buttons
        private void cmdNewTeam_Click(object sender, EventArgs e)
        {
            CreateNewTeam();
        }
        private void cmdRemoveAll_Click(object sender, EventArgs e)
        {
            if (CurrentTeam == null && CurrentUser == null)
            {
                NMWin.Leader.Tell("Please load the permissions for a specific user or team first.");
                return;
            }

            ArrayList a = NMWin.Data.GetScalarArray("select distinct(name) from n_permit where name > '' order by name");

            String strCaption = "";
            if (CurrentTeam != null)
                strCaption = CurrentTeam.ToString();
            else
                strCaption = CurrentUser.ToString();

            if (!NMWin.Leader.AreYouSure("remove " + Tools.Number.LongFormat(a.Count) + " " + nTools.Pluralize("permission", a.Count) + " from " + strCaption))
                return;

            foreach (String p in a)
            {
                if (CurrentTeam != null)
                    CurrentTeam.AddPermit(NMWin.ContextDefault, p, false);
                else if (CurrentUser != null)
                    CurrentUser.AddPermit(NMWin.ContextDefault, p, false);
            }

            if (CurrentTeam != null)
                ShowTeamPermissions(CurrentTeam);
            else if (CurrentUser != null)
                ShowUserPermissions(CurrentUser);
        }
        private void cmdListPermissions_Click(object sender, EventArgs e)
        {
            if (CurrentTeam == null)
                return;
            ArrayList a = CurrentTeam.GetPermitArrayWithPositiveNegative(NMWin.ContextDefault);
            StringBuilder sb = new StringBuilder();
            foreach (String s in a)
            {
                sb.AppendLine(s);
            }
            Tools.FileSystem.PopText(sb.ToString());
        }
        private void cmdPaste_Click(object sender, EventArgs e)
        {
            if (CurrentTeam == null && CurrentUser == null)
            {
                NMWin.Leader.Tell("Please load the permissions for a specific user or team first.");
                return;
            }

            String s = NMWin.Leader.AskForString("Permissions:", "", true, "Permissions");
            String[] b = nTools.SplitLines(s);
            //a = Tools.Strings.KillBlankLines(a);

            ArrayList a = new ArrayList();
            foreach (String sx in b)
            {
                if( Tools.Strings.StrExt(sx) )
                    a.Add(sx);
            }

            String strCaption = "";
            if (CurrentTeam != null)
                strCaption = CurrentTeam.ToString();
            else
                strCaption = CurrentUser.ToString();

            if (!NMWin.Leader.AreYouSure("add " + Tools.Number.LongFormat(a.Count) + " " + nTools.Pluralize("permission", a.Count) + " to " + strCaption))
                return;

            foreach (String l in a)
            {
                bool pos = true;
                String p = l;
                if (l.ToLower().EndsWith(" negative"))
                {
                    p = p.Replace(" negative", "");
                    pos = false;
                }

                if (CurrentTeam != null)
                    CurrentTeam.AddPermit(NMWin.ContextDefault, p, pos);
                else if (CurrentUser != null)
                    CurrentUser.AddPermit(NMWin.ContextDefault, p, pos);
            }

            if (CurrentTeam != null)
                ShowTeamPermissions(CurrentTeam);
            else if (CurrentUser != null)
                ShowUserPermissions(CurrentUser);
        }
        //Control Events
        private void nTeams_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                tv.SelectedNode = tv.GetNodeAt(e.X, e.Y);
            }
            catch
            {}
        }
        private void tv_DragDrop(object sender, DragEventArgs e)
        {
            ArrayList a = (ArrayList)e.Data.GetData(System.Type.GetType("System.Collections.ArrayList"));
            n_member m;
            n_team t = GetTeamByCoords(tv.PointToClient(new Point(e.X, e.Y)));
            if (t == null)
                return;
            foreach (n_user u in a)
            {
                m = n_member.QtO(NMWin.ContextDefault, "select * from n_member where the_n_team_uid = '" + t.unique_id + "' and the_n_user_uid = '" + u.unique_id + "'");
                if (m == null)
                {
                    m = n_member.New(NMWin.ContextDefault);
                    m.the_n_user_uid = u.unique_id;
                    m.the_n_team_uid = t.unique_id;
                    NMWin.ContextDefault.Insert(m);
                }
                if (Tools.Strings.StrCmp(t.name, "sales"))
                {
                    u.main_n_team_uid = t.unique_id;
                    NMWin.ContextDefault.Update(m);
                }
                UpdateUserPermits(t, u);
            }
            LoadTeams();
        }
        private void tv_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }
        private void tv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowTeam();
        }
        private void tvPermit_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (CurrentTeam == null && CurrentUser == null)
                    return;

                String s = (String)e.Node.Tag;
                if (Tools.Strings.StrExt(s))
                {
                    if (e.Node.Checked)
                    {
                        CurrentTeam.AddPermit(NMWin.ContextDefault, s);
                        NMWin.Leader.Comment("Added " + s + " permission to " + CurrentTeam.ToString());
                        e.Node.ForeColor = Color.Green;
                    }
                    else
                    {
                        CurrentTeam.ClearPermit(NMWin.ContextDefault, s);
                        NMWin.Leader.Comment("Cleared " + s + " permission from " + CurrentTeam.ToString());
                        e.Node.ForeColor = Color.Blue;
                    }
                }
            }
            catch
            { }
        }
        private void tvPermit_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                tvPermit.SelectedNode = tvPermit.GetNodeAt(e.X, e.Y);
            }
            catch
            { }
        }
        private void lstUsers_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;

            String s = NMWin.Leader.AskForString("What is the user's full name?", "Test User", "Full Name");
            if (!Tools.Strings.StrExt(s))
                return;

            //String su = "";
            //if (xSys.xData.TableExists("mc_user"))
            //    su = xSys.xData.GetScalar_String("select max(unique_id) from mc_user where full_name = '" + xSys.xData.SyntaxFilter(s) + "'");

            //if (Tools.Strings.StrExt(su))
            //{
            //    if (!context.TheLeader.AskYesNo(s + " appears to already exist in the version 12 database.  Is this the same user?"))
            //        su = "";
            //}

            ChangesMade = true;
            n_user u = n_user.AddNewUser(NMWin.ContextDefault, s);  //, su

            if (u != null)
            {
                if (AboutToThrow != null)
                {
                    AboutToThrow(NMWin.ContextDefault, new ShowArgs(NMWin.ContextDefault, u));
                }
                LoadUsers();
            }
        }
        private void lstUsers_AboutToThrow(object sender, ShowArgs args)
        {
            ChangesMade = true;
        }
        private void sc_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (inhibit_resize)
                return;

            DoResize();
        }
        //Menus
        private void mnuNewTeam_Click(object sender, EventArgs e)
        {
            CreateNewTeam();
        }
        private void mnuAddCaptain_Click(object sender, EventArgs e)
        {
            n_member m = GetSelectedMember();
            if (m == null)
                return;

            m.is_captain = true;
            NMWin.ContextDefault.Update(m);
            LoadTeams();
        }
        private void mnuRemoveCaptain_Click(object sender, EventArgs e)
        {
            n_member m = GetSelectedMember();
            if (m == null)
                return;

            m.is_captain = false;
            NMWin.ContextDefault.Update(m);
            LoadTeams();
        }
        private void mnuTeam_Opening(object sender, CancelEventArgs e)
        {
            n_member m = GetSelectedMember();
            if (m == null)
            {
                mnuNewTeam.Visible = true;
                mnuAddCaptain.Visible = false;
                mnuRemoveCaptain.Visible = false;

                mnuDeleteMember.Visible = false;
                mnuDeleteTeam.Visible = true;
                sepMember.Visible = false;
                sepTeam.Visible = true;
            }
            else
            {
                mnuNewTeam.Visible = false;
                mnuAddCaptain.Visible = true;
                mnuRemoveCaptain.Visible = true;

                mnuDeleteMember.Visible = true;
                mnuDeleteTeam.Visible = false;
                sepMember.Visible = true;
                sepTeam.Visible = false;

                if (m.is_captain)
                {
                    mnuAddCaptain.Visible = false;
                    mnuRemoveCaptain.Visible = true;
                }
                else
                {
                    mnuAddCaptain.Visible = true;
                    mnuRemoveCaptain.Visible = false;
                }
            }
        }
        private void mnuDeleteTeam_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            if (!NMWin.Leader.AreYouSure("delete '" + t.name + "'"))
                return;

            NMWin.ContextDefault.Delete(t);

            if (t.ParentTeam == null)
                xSys.RemoveTeam(t);
            else
                t.ParentTeam.RemoveTeam(t);

            LoadTeams();
        }
        private void mnuDeleteMember_Click(object sender, EventArgs e)
        {
            n_member m = GetSelectedMember();
            if (m == null)
                return;

            n_user u = n_user.GetById(NMWin.ContextDefault, m.the_n_user_uid);
            if (u == null)
                return;

            n_team t = n_team.GetById(NMWin.ContextDefault, m.the_n_team_uid);

            if (!NMWin.Leader.AreYouSure("remove " + u.name + " from " + t.name))
                return;

            NMWin.ContextDefault.Delete(m);
            LoadTeams();
        }
        private void mnuAddMainStatus_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            if (t.is_main)
                return;

            t.is_main = true;
            NMWin.ContextDefault.Update(t);
        }
        private void mnuRemoveMainStatus_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            if (!t.is_main)
                return;

            t.is_main = false;
            NMWin.ContextDefault.Update(t);
        }
        private void mnuRemoveAllPermissions_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            if (!NMWin.Leader.AreYouSure("remove all permissions from " + t.ToString()))
                return;

            t.RemoveAllPermits(NMWin.ContextDefault);
            ShowTeamPermissions(t);
        }
        private void mnuEditPermissions_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t != null)
            {
                ShowTeamPermissions(t);
                return;
            }
            n_member m = GetSelectedMember();
            if (m != null)
            {
                n_user u = (n_user)xSys.Users.GetByID(m.the_n_user_uid);
                if (u != null)
                {
                    ShowUserPermissions(u);
                }
            }
        }
        private void mnuCopy_Click(object sender, EventArgs e)
        {
            try
            {
                String s = (String)tvPermit.SelectedNode.Tag;
                if (Tools.Strings.StrExt(s))
                    ToolsWin.Clipboard.SetClip(s);
            }
            catch
            {
            }
        }
        private void mnuRemove_Click(object sender, EventArgs e)
        {
            if (CurrentTeam != null)
            {
                try
                {
                    String s = (String)tvPermit.SelectedNode.Tag;
                    if (Tools.Strings.StrExt(s))
                    {
                        tvPermit.SelectedNode.Checked = false;
                        tvPermit.SelectedNode.ForeColor = Color.Red;
                        CurrentTeam.RemovePermit(NMWin.ContextDefault, s);
                    }
                }
                catch
                {
                }
            }
        }
        private void mnuRemoveNegative_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            if (!NMWin.Leader.AreYouSure("remove negative permissions for " + t.ToString()))
                return;

            t.RemoveNegativePermits(NMWin.ContextDefault);
            ShowTeamPermissions(t);
        }

        private void lstUsers_AboutToThrow(Context x, ShowArgs args)
        {

        }

        private void cbx_show_inactive_CheckChanged(object sender)
        {
            //Reload the LV
            LoadUsers();
        }
    }
}
