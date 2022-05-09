using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ViewTeam : nView
    {
        //Private Variables
        private n_team TheTeam
        {
            get
            {
                return (n_team)TheItem;
            }
        }

        //Constructors
        public ViewTeam()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            TheTeam.CachePermits(RzWin.Context);
            LoadLV();
            lblTeam.Text = TheTeam.name;
            LoadPermits();
        }
        //Private Functions
        private void LoadPermits()
        {
            RzWin.Context.Reorg();
            //chkAllowExport.Checked = TheTeam.HasPermit(Permissions.ThePermits.ExportListsToExcel);
            //chkViewAllOrders.Checked = TheTeam.HasPermit(Permissions.ThePermits.orders
            //chkViewAllComps.Checked = TheTeam.PermissionViewAllCompanies;
            //chkDeleteAllItems.Checked = TheTeam.PermissionDeleteAllItems;
            //chkAllowedToViewOrderLinks.Checked = TheTeam.PermissionViewOrderLinks;
        }
        private void Apply()
        {
            RzWin.Context.Reorg();
            //TheTeam.PermissionAllowedToExport = chkAllowExport.Checked;
            //TheTeam.PermissionViewAllOrders = chkViewAllOrders.Checked;
            //TheTeam.PermissionViewAllCompanies = chkViewAllComps.Checked;
            //TheTeam.PermissionDeleteAllItems = chkDeleteAllItems.Checked;
            //TheTeam.PermissionViewOrderLinks = chkAllowedToViewOrderLinks.Checked;
            //TheTeam.CachePermits(RzWin.Context);
            //RzWin.Context.Leader.Tell("Saved.");            
        }
        private void LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                TheTeam.FillTeamTree(RzWin.Context, TheTeam.ParentTeam, TheTeam.TeamTree);
                foreach (n_member m in TheTeam.AllMembers)
                {
                    ListViewItem xLst = lv.Items.Add(RzWin.Context.Sys.TranslateUserIDToName(m.the_n_user_uid));
                    xLst.Tag = m;
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        //Buttons
        private void cmdApply_Click(object sender, EventArgs e)
        {
            Apply();
        }
    }
}
