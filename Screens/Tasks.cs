using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5.Win.Screens
{
    public partial class Tasks : UserControl
    {
        //usernote FolderMain = null;
        //TreeNodeCollection NodesMain = null;

        public Tasks()
        {
            InitializeComponent();
        }
        ScreenMode TheScreenMode = ScreenMode.Search;
        public virtual void Init()
        {
            string name = "";
            cmdActivity.Visible = ((SysRz5)RzWin.Context.xSys).TheUserLogicRz.GetTaskUserName(ref name);
            if (TheTaskView == null)
            {
                TheTaskView = RzWin.Leader.TaskViewCreate(null);
                TaskViewHeight = TheTaskView.Height;
                sp.Panel2.Controls.Add(TheTaskView);
                TheTaskView.Dock = DockStyle.Fill;
                TheTaskView.CloseRequest += new ToolsWin.CloseHandler(TheTaskView_CloseRequest);
                ctl_task_type.LoadList();
                ctl_task_size.LoadList();
                ctl_current_status.LoadList();
                lblUpdateAll.Visible = RzWin.Context.xUser.IsDeveloper();
            }
            cmdPriorities.Enabled = false;
            ctlFrom.DoClearUser();
            ctlTo.DoClearUser();
            TaskSearchParameters pars = new TaskSearchParameters();
            lv.ShowTemplate(usernote.TaskSearchArgsGet(RzWin.Context, pars));
            ForSet((n_user)RzWin.Context.xSys.Users.GetByName(name));
            DoResize();
        }
        protected void TheTaskView_CloseRequest(object sender, ToolsWin.CloseArgs args)
        {
            EditMode = false;
            DoResize();
        }
        void InitUn()
        {
            try
            {
                if (TheTaskView != null)
                {
                    TheTaskView.CloseRequest -= new ToolsWin.CloseHandler(TheTaskView_CloseRequest);
                    sp.Panel2.Controls.Remove(TheTaskView);
                }
            }
            catch { }
        }
        //void InitFolders()
        //{
        //    FolderMain = null;
        //    NodesMain = null;
        //    tv.Nodes.Clear();
        //    tv.BeginUpdate();

        //    try
        //    {
        //        usernote n = usernote.FolderRootMakeExist(RzWin.Context, RzWin.Context.xUser);
        //        if (n != null)
        //        {
        //            FolderMain = n;
        //            NodesMain = tv.Nodes;
        //            foreach (usernote nn in n.FoldersGet(RzWin.Context))
        //            {
        //                InitFolder(tv.Nodes, nn);
        //            }
        //        }
        //    }
        //    catch { }

        //    tv.ExpandAll();
        //    tv.EndUpdate();
        //}

        //void InitFolder(TreeNodeCollection nodes, usernote n)
        //{
        //    TreeNode x = NodeAdd(nodes, n);

        //    foreach (usernote nn in n.FoldersGet(RzWin.Context))
        //    {
        //        InitFolder(x.Nodes, nn);
        //    }
        //}

        //TreeNode NodeAdd(TreeNodeCollection nodes, usernote n)
        //{
        //    TreeNode x = nodes.Add(n.subjectstring);
        //    x.Tag = n;
        //    return x;
        //}

        //private void cmdNewFolder_Click(object sender, EventArgs e)
        //{
        //    FolderAdd(FolderMain, NodesMain);
        //}

        //void FolderAdd(usernote folder, TreeNodeCollection nodes)
        //{
        //    usernote n = folder.FolderAdd(RzWin.Context);
        //    if( n == null )
        //        return;

        //    NodeAdd(nodes, n);
        //}
        void FolderShow(usernote n)
        {
            TheScreenMode = ScreenMode.Folder;
            DoResize();
            vf.Init(n);
        }
        String ById = "";
        String ForId = "";
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            TaskSearchParameters pars = SearchParametersGet();

            if (!pars.Valid)
                return;

            lv.Init(usernote.TaskSearchArgsGet(RzWin.Context, pars));
        }
        protected virtual TaskSearchParameters SearchParametersGet()
        {
            TaskSearchParameters pars = new TaskSearchParameters();
            pars.SearchTerm = txtSearch.Text;
            pars.ByUserId = ById;
            pars.ForUserId = ForId;

            pars.TagAddIfExists("Type", ctl_task_type.GetValue_String());
            pars.TagAddIfExists("Size", ctl_task_size.GetValue_String());
            pars.TagAddIfExists("Status", ctl_current_status.GetValue_String());

            return pars;
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            cmdSearch.Enabled = Tools.Strings.StrExt(txtSearch.Text);
        }
        //private void cmdRefresh_Click(object sender, EventArgs e)
        //{
        //    InitFolders();
        //}
        private void Tasks_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        protected void DoResize()
        {
            try
            {
                sp.Left = 0;
                sp.Top = 0;
                sp.Height = this.ClientRectangle.Height;
                sp.Width = this.ClientRectangle.Width;

                sp.Panel2Collapsed = !EditMode;

                //cmdNewFolder.Top = height - cmdNewFolder.Height;
                //cmdRefresh.Top = cmdNewFolder.Top - cmdRefresh.Height;

                //tv.Top = gbPriorities.Height;
                //tv.Height = height - (tv.Top + cmdNewFolder.Height + cmdRefresh.Height);

                //gbPriorities.Top = 0;
                //gbPriorities.Left = 0;

                pSearch.Left = 0;
                pSearch.Width = sp.Panel1.ClientRectangle.Width;

                if (TheScreenMode == ScreenMode.Search)
                {
                    vf.Visible = false;

                    pSearch.Visible = true;
                    lv.Visible = true;
                    lv.Left = 0;
                    lv.Width = sp.Panel1.ClientRectangle.Width - lv.Left;
                    lv.Height = sp.Panel1.ClientRectangle.Height - lv.Top;
                }
                else
                {
                    pSearch.Visible = false;
                    lv.Visible = false;
                    
                    vf.Visible = true;
                    vf.Top = 0;
                    vf.Left = 0;
                    vf.Width = sp.Panel1.ClientRectangle.Width - vf.Left;
                    vf.Height = sp.Panel1.ClientRectangle.Height - vf.Top;
                }
            }
            catch { }
        }
        //private void tv_MouseDown(object sender, MouseEventArgs e)
        //{
        //    try
        //    {
        //        TreeViewHitTestInfo info = tv.HitTest(e.X, e.Y);
        //        if (info.Node == null)
        //            return;

        //        usernote n = (usernote)info.Node.Tag;
        //        if (n == null)
        //            return;
        //        tv.SelectedNode = info.Node;
        //        FolderShow(n);
        //    }
        //    catch { }
        //}

        //private void newSubFolderToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        usernote n = SelectedFolderGet();
        //        if (n == null)
        //            return;

        //        usernote f = n.FolderAdd(RzWin.Context);
        //        InitFolders();
        //        FolderShow(f);
        //    }
        //    catch { }
        //}

        //usernote SelectedFolderGet()
        //{
        //    try
        //    {
        //        return (usernote)tv.SelectedNode.Tag;
        //    }
        //    catch { return null; }
        //}
        private void lv_AboutToThrow(object sender, ShowArgs args)
        {
            TaskShow((usernote)args.TheItems.FirstGet(RzWin.Context));
            args.Handled = true;
        }
        protected int TaskViewHeight = 0;
        void TaskShow(usernote n)
        {
            if (n == null)
                return;

            EditMode = true;
            TheTaskView.Init(n);
            TheTaskView.CompleteLoad();
            DoResize();
            sp.SplitterDistance = this.ClientRectangle.Height - (TaskViewHeight + 10);
        }
        //private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    usernote n = SelectedFolderGet();
        //    if (n != null)
        //    {
        //        if (!RzWin.Context.TheLeader.AreYouSure("delete " + n.ToString()))
        //            return;

        //        n.Delete(RzWin.Context);
        //        TheScreenMode = ScreenMode.Search;
        //        DoResize();
        //        InitFolders();
        //    }
        //}
        private void vf_CloseRequest(object sender, EventArgs e)
        {
            TheScreenMode = ScreenMode.Search;
            DoResize();
        }
        bool EditMode = false;
        protected ViewTask TheTaskView = null;
        private void vf_AboutToThrow(object sender, ShowArgs args)
        {
            TaskShow((usernote)args.TheItems.FirstGet(RzWin.Context));
            args.Handled = true;
        }
        //private void ctlUser_ChangeUser(Tools.GenericEvent e)
        //{
        //    NewMethod.n_user u = frmChooseUser.ChooseUser(RzWin.Context.xSys, Rz3App.xMainForm);
        //    if (u == null)
        //        return;

        //    ctlUser.SetUserName(u.name);

        //    if (Tools.Strings.StrCmp(u.name, RzWin.Context.xUser.name))
        //        FolderShow(usernote.FolderPriorityMakeExist(RzWin.Context, u));
        //    else
        //        FolderShow(usernote.FolderPriorityMakeExistFromTo(RzWin.Context, RzWin.Context.xUser, u));
        //}
        private void sp_SplitterMoved(object sender, SplitterEventArgs e)
        {
            DoResize();
        }
        private void cmdPriorities_Click(object sender, EventArgs e)
        {
            if (PriorityUser == null)
                return;

            usernote f = usernote.FolderRootMakeExist(RzWin.Context, PriorityUser);
            if (f == null)
                return;

            FolderShow(f);
        }
        private void ctlFrom_ClearUser(Tools.GenericEvent e)
        {
            ById = "";
            ctlFrom.DoClearUser();
        }
        private void ctlFrom_ChangeUser(Tools.GenericEvent e)
        {
            NewMethod.n_user u = RzWin.Leader.AskForUser();
            if (u == null)
            {
                ById = "";
                ctlFrom.DoClearUser();
                return;
            }

            ById = u.unique_id;
            ctlFrom.SetUserName(u.Name);
        }
        NewMethod.n_user PriorityUser = null;
        private void ctlTo_ChangeUser(Tools.GenericEvent e)
        {
            ForSet(frmChooseUser.ChooseUser());
        }
        protected void ForSet(NewMethod.n_user u)
        {
            if (u == null)
            {
                ForClear();
                return;
            }

            ForId = u.unique_id;
            ctlTo.SetUserName(u.Name);
            cmdPriorities.Enabled = true;
            cmdActivity.Enabled = true;
            PriorityUser = u;
        }
        protected void ForClear()
        {
            ForId = "";
            ctlTo.DoClearUser();
            cmdPriorities.Enabled = false;
            cmdActivity.Enabled = false;
            PriorityUser = null;
        }
        private void ctlTo_ClearUser(Tools.GenericEvent e)
        {
            ForClear();
        }
        private void lblUpdateAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Reorg();
            //n_sys.UpdateAllByClass(RzWin.Context, "usernote");
        }
        private void cmdActivity_Click(object sender, EventArgs e)
        {
            RzWin.Form.ShowHTML(task_event.Report(RzWin.Context, PriorityUser), "Activity for " + PriorityUser.name);
        }
    }

    enum ScreenMode
    {
        Search = 0,
        Folder = 1,
    }
}
