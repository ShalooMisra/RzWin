using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class ViewEditPermissions : nView
    {
        //Private Variables
        private ContextNM TheContext
        {
            get
            {
                return NMWin.ContextDefault;
            }
        }
        public n_team TheTeam
        {
            get
            {
                return pe.TheTeam;
            }
        }
        public n_user TheUser
        {
            get
            {
                return pe.TheUser;
            }
        }
        private bool IsTeam = false;

        //Constructors
        public ViewEditPermissions()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public void CompleteLoad(nObject o)
        {
            base.CompleteLoad();
            pe.CompleteLoad(o);
            if (o is n_team)
            {
                lblTeamUser.Text = TheTeam.name;
                TheTeam.CachePermits(NMWin.ContextDefault);
                IsTeam = true;
            }
            else if (o is n_user)
            {
                lblTeamUser.Text = TheUser.name;
                IsTeam = false;
            }
            else
                throw new Exception("Not team or user");

            DoResize();
            LoadLV();
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                pe.Top = lv.Top;
                if (IsTeam)
                {
                    pe.Left = 249;
                    pe.Width = 410;
                }
                else
                {
                    pe.Left = 13;
                    pe.Width = 646;
                }
            }
            catch { }
        }
        //Private Functions
        private void LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                TheTeam.FillTeamTree(NMWin.ContextDefault, TheTeam.ParentTeam, TheTeam.TeamTree);
                foreach (n_member m in TheTeam.AllMembers)
                {
                    ListViewItem xLst = lv.Items.Add(NMWin.ContextDefault.xSys.TranslateUserIDToName(m.the_n_user_uid));
                    xLst.Tag = m;
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        //Buttons
        private void cmdApply_Click(object sender, EventArgs e)
        {
           pe.Apply();
        }
        //Control Events
        private void ViewEditPermissions_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
