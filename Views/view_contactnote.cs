using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class view_contactnote : ViewPlusMenu
    {
        public contactnote CurrentNote;
        public view_contactnote()
        {
            InitializeComponent();
        }
        protected override void DoResize()
        {
            base.DoResize();

            try
            {
                ctl_notetext.Width = this.ClientRectangle.Width - (ctl_notetext.Left + 300);
                ctl_notetext.Height = this.ClientRectangle.Height - ctl_notetext.Top;
            }
            catch (Exception)
            { }
        }
        public override void CompleteLoad()
        {
            CurrentNote = (contactnote)GetCurrentObject();
            ctlAgent.CurrentIDField = "base_mc_user_uid";
            ctlAgent.CurrentNameField = "agentname";
            ctlAgent.CurrentObject = CurrentNote;
            ctlAgent.SetUserName();


            CheckPermissions();
            String s = "";
            if (Tools.Strings.StrExt(CurrentNote.base_company_uid))
            {
                ArrayList a = RzWin.Context.Data.ScalarArray("select distinct(contactname) from companycontact where base_company_uid = '" + CurrentNote.base_company_uid + "' and isnull(contactname, '') > '' order by contactname");
                int i = 0;
                foreach (String l in a)
                {
                    s += "|" + l;
                    i++;
                    if (i > 100)
                        break;
                }
            }
            ctl_contactname.SimpleList = s;
            if (RzWin.Context.TheSysRz.TheCompanyLogic.DisableContactNoteControls(CurrentNote))
                this.DisableControls();
            base.CompleteLoad();
            EnableSiteAuditDate();
        }
        public override void CompleteSave()
        {
            if (ctl_is_site_audit.zz_CheckValue == true)
            {
                ctl_site_audit_date.Visible = true;
                ctl_site_audit_date.Enabled = true;
            }

            base.CompleteSave();
        }

        public void CheckPermissions()
        {
            if (RzWin.Context.xUser.CheckPermit(RzWin.Context, "permit_CanChangeNoteDate", true) || RzWin.Context.xUser.IsDeveloper() == true || RzWin.Context.xUser.SuperUser)
                ctl_notedate.Enabled = true;
            if(RzWin.Context.xUser.MainTeam != null)
            {
                //if (RzWin.Context.xUser.MainTeam.name == "Mobile Sales" || RzWin.Context.xUser.MainTeam.name == "Sales Management" || RzWin.Context.xUser.Teams.AllByName.Contains("Mobile Sales"));
                if (RzWin.Context.xUser.Teams.AllByName.Contains("mobile sales"));
                    ctl_is_remote_visit.Enabled = true;
            }
        }

        private void ctl_is_site_audit_CheckChanged(object sender)
        {
            EnableSiteAuditDate();
        }


        //KT Show / Hide site audit date based on checkbox - Needs to happen after base_completeload.
        private void EnableSiteAuditDate()
        {
            if (ctl_is_site_audit.zz_CheckValue == true)
                ctl_site_audit_date.Enabled = true;
            else
            {
                ctl_site_audit_date.ClearDate();
                ctl_site_audit_date.Enabled = false;
            }
                
        }
    }
}

