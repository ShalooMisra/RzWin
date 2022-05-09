using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class PermitEditor : UserControl
    {
        //Public Variables
        public n_team TheTeam;
        public n_user TheUser;
        //Private Variables
        private ContextNM TheContext
        {
            get
            {
                return NMWin.ContextDefault;
            }
        }
        private bool IsTeam = false;

        //Constructors
        public PermitEditor()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(nObject o)
        {
            if (o is n_team)
            {
                TheTeam = (n_team)o;
                TheTeam.CachePermits(NMWin.ContextDefault);
                IsTeam = true;
            }
            else if (o is n_user)
            {
                TheUser = (n_user)o;
                TheUser.GatherPermits(NMWin.ContextDefault);
            }
            else
                return false;
            DoResize();
            LoadPermits();
            return true;
        }
        public void DoResize()
        {
            try
            {
                SetBorder();
                tv.Top = pbTop.Bottom;
                tv.Left = pbLeft.Right;
                tv.Width = pbRight.Left - tv.Left;
                tv.Height = pbBottom.Top - tv.Top;
            }
            catch { }
        }
        public void Apply()
        {
            if (IsTeam)
                TheTeam.RemoveAllPermits(NMWin.ContextDefault);
            else
                TheUser.RemoveAllPermits(NMWin.ContextDefault);
            ApplyPermits(NMWin.ContextDefault, tv.Nodes);
            if (IsTeam)
                UpdateTeamUsers();
        }
        //Private Functions
        private void ApplyPermits(ContextNM x, TreeNodeCollection col)
        {
            try
            {
                foreach (TreeNode t in col)
                {
                    string permit = t.Tag.ToString();
                    if (!Tools.Strings.StrExt(permit))
                        continue;
                    if (Tools.Strings.StrCmp(permit, Permissions.ThePermits.TeamTemplateEditor))
                    {
                        if (IsTeam)
                            TheTeam.AddPermit(x, permit, t.Checked);
                        else
                        {
                            TheUser.template_editor = t.Checked;
                            x.Update(TheUser);
                        }
                        continue;
                    }
                    if (Tools.Strings.StrCmp(permit, "sublist"))
                    {
                        ApplyPermits(x, t.Nodes);
                        continue;
                    }
                    else
                    {
                        if (IsTeam)
                        {
                            if (t.Checked)
                                TheTeam.AddPermit(x, permit);
                            else
                                TheTeam.RemovePermit(x, permit);
                        }
                        else
                        {
                            if (t.Checked)
                                TheUser.AddPermit(NMWin.ContextDefault, permit, true);
                            else
                                TheUser.RemovePermit(NMWin.ContextDefault, permit);
                        }
                    }
                }
            }
            catch { }
        }
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch (Exception)
            { }
        }
        private void LoadPermits()
        {
            tv.Nodes.Clear();
            tv.SuspendLayout();
            List<PermitNode> nodes = ((SysNewMethod)TheContext.xSys).ThePermitLogic.GetPermitNodeCollection(TheContext, TheTeam, TheUser, IsTeam);
            try
            {
                foreach (PermitNode p in nodes)
                {
                    TreeNode n = tv.Nodes.Add(p.PermitName);
                    n.Tag = p.PermitString;
                    n.Checked = p.HasPermit;
                    if (p.Nodes.Count > 0)
                        LoadSubPermits(n, p.Nodes);
                    //n.ExpandAll();
                }
            }
            catch { }
            tv.ResumeLayout();
        }
        private void LoadSubPermits(TreeNode n, List<PermitNode> nodes)
        {
            try
            {
                foreach (PermitNode p in nodes)
                {
                    TreeNode nn = n.Nodes.Add(p.PermitName);
                    nn.Tag = p.PermitString;
                    nn.Checked = p.HasPermit;
                    if (p.Nodes.Count > 0)
                        LoadSubPermits(nn, p.Nodes);
                    //nn.ExpandAll();
                }
            }
            catch { }
        }
        private void UpdateTeamUsers()
        {
            try
            {
                TheTeam.CachePermits(NMWin.ContextDefault);
                foreach (n_member m in TheTeam.AllMembers)
                {
                    n_user u = n_user.GetById(TheContext, m.the_n_user_uid);
                    if (u == null)
                        continue;
                    u.RemoveAllPermits(NMWin.ContextDefault);
                    foreach (DictionaryEntry d in TheTeam.AllPermits)
                    {
                        n_permit p = (n_permit)d.Value;
                        u.AddPermit(NMWin.ContextDefault, p.name, p.is_positive);
                    }
                }
            }
            catch { }
        }
        //Control Events
        private void PermitEditor_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
