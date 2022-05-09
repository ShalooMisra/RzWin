using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class frmPermit : Form
    {
        public n_user TheUser;
        public string ThePermit;

        private bool bInhibit = false;

        public frmPermit()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void CompleteLoad(n_user u, string strPermit)
        {
            TheUser = u;
            ThePermit = strPermit;

            if (TheUser.PermitOptimistic())
            {
                lblUser.Text = TheUser.name + " <Permit Optimistic>";
                chkUser.Text = "Dis-Allow permission to " + ThePermit;
            }
            else
            {
                lblUser.Text = TheUser.name + " <Permit Pessimistic>";
                chkUser.Text = "Allow permission to " + ThePermit;
            }

            lblPermit.Text = strPermit;
            LoadTree();

            chkUser.Checked = TheUser.HasExplicitPermit(ThePermit);

            ShowPermit();

            cmdBlockUser.Text = "Block " + TheUser.Name;
            cmdAllowUser.Text = "Allow " + TheUser.Name;

            SetTeam();
            cmdAllowUser.Focus();
        }

        private void SetTeam()
        {
            if (TheUser.PermitTeam == null)
            {
                cmdBlockTeam.Enabled = false;
                cmdAllowTeam.Enabled = false;
            }
            else
            {
                cmdBlockTeam.Enabled = true;
                cmdBlockTeam.Text = "Block " + TheUser.PermitTeam.name;

                cmdAllowTeam.Enabled = true;
                cmdAllowTeam.Text = "Allow " + TheUser.PermitTeam.name;
            }
        }

        private void LoadTree()
        {
            //ok, we need an array for each team the user is on,
            //representing the branch structure back to the root team

            bInhibit = true;
            tv.BeginUpdate();
            tv.Nodes.Clear();

            Stack s;
            TreeNode n;
            TreeNodeCollection c;
            n_team ht;
            foreach (n_team t in TheUser.Teams.All)
            {
                s = new Stack();
                s.Push(t);

                ht = t;
                while (ht != null)
                {
                    s.Push(ht.ParentTeam);
                    ht = ht.ParentTeam;
                }

                //now s has the whole team stack for that sub-team
                c = tv.Nodes;
                while( s.Count > 0 )
                {
                    ht = (n_team)s.Pop();
                    if (ht != null)
                    {
                        n = c.Add(t.name);
                        n.Tag = t;

                        if (ht.HasPermit(ThePermit))
                        {
                            n.Checked = true;
                            n.ForeColor = Color.Green;
                        }
                        else if (ht.HasBlock(ThePermit))
                        {
                            n.Checked = false;
                            n.ForeColor = Color.Red;
                        }
                        else
                        {
                            n.Checked = false;
                            n.ForeColor = Color.Blue;
                        }
                        c = n.Nodes;
                    }
                }
            }

            tv.ExpandAll();
            tv.EndUpdate();
            bInhibit = false;
        }

        private void SetUserPermit(bool on)
        {
            //if (TheUser.PermitOptimistic())
            //{
            //    if (on)
            //    {
            //        //make sure it isn't there as a negative
            //        TheUser.RemovePermit(ThePermit);
            //    }
            //    else
            //    {
            //        //make sure it is there as a negative
            //        TheUser.AddPermit(ThePermit, false);
            //    }
            //}
            //else
            //{
                if (on)
                {
                    //make sure it is there as a positive
                    TheUser.AddPermit(NMWin.ContextDefault, ThePermit, true);
                }
                else
                {
                    //make sure it is there as a negative
                    TheUser.RemovePermit(NMWin.ContextDefault, ThePermit);
                }
            //}
            ShowPermit();
        }

        private void SetTeamPermit(ContextNM x, n_team t, bool on)
        {
            n_permit p;

            if (on)
            {
                p = t.AddPermit(x, ThePermit);
            }
            else
            {
                p = t.RemovePermit(x, ThePermit);
            }
            TheUser.AbsorbActivePermit(p);
        }

        private void ShowPermit()
        {
            if (TheUser.HasPermit(ThePermit))
            {
                lblPermit.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblPermit.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void chkUser_CheckedChanged(object sender, EventArgs e)
        {
            SetUserPermit(chkUser.Checked);
        }

        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                tv.SelectedNode = tv.GetNodeAt(new Point(e.X, e.Y));
            }
            catch
            { }
        }

        private void mnuSetTeam_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            TheUser.PermitTeam = t;
            SetTeam();
        }

        private n_team GetSelectedTeam()
        {
            try
            {
                nObject o = (nObject)tv.SelectedNode.Tag;
                
                switch (o.ClassId.ToLower())
                {
                case "n_team":
                    return (n_team)o;
                }            
            }
            catch
            {}
            return null;
        }

        private void cmdBlockTeam_Click(object sender, EventArgs e)
        {
            if (TheUser.PermitTeam == null)
                return;

            SetTeamPermit(NMWin.ContextDefault, TheUser.PermitTeam, false);
            this.Close();
        }

        private void tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (bInhibit)
                return;

            if (e.Node.Tag == null)
                return;

            nObject o;

            try
            {
                o = (nObject)e.Node.Tag;
            }
            catch (Exception)
            {
                return;
            }

            switch (o.ClassId.ToLower())
            {
                case "n_user":
                    SetUserPermit(e.Node.Checked);
                    break;
                case "n_team":

                    if (e.Node.Checked)
                    {
                        e.Node.ForeColor = Color.Green;
                        SetTeamPermit(NMWin.ContextDefault, (n_team)o, true);
                    }
                    else
                    {
                        e.Node.ForeColor = Color.Red;
                        SetTeamPermit(NMWin.ContextDefault, (n_team)o, false);
                    }
                    break;
            }

            if (chkFastSelect.Checked)
                this.Close();
            else
                ShowPermit();
        }

        private void mnuBlockTeam_Click(object sender, EventArgs e)
        {
            n_team t = GetSelectedTeam();
            if (t == null)
                return;

            bInhibit = true;
            tv.SelectedNode.Checked = false;
            bInhibit = false;

            SetTeamPermit(NMWin.ContextDefault, t, false);
        }

        private void cmdAllowUser_Click(object sender, EventArgs e)
        {
            SetUserPermit(true);
            this.Close();
        }

        private void cmdAllowTeam_Click(object sender, EventArgs e)
        {
            if (TheUser.PermitTeam == null)
                return;

            SetTeamPermit(NMWin.ContextDefault, TheUser.PermitTeam, true);
            this.Close();
        }
    }
}