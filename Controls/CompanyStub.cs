using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Tools;
using NewMethod;

namespace Rz5
{

    public partial class CompanyStub : UserControl, NewMethod.ListArgs.IGenericNotify, IEnableable
    {
        public event ContactEventHandler ChangeCompany;
        public event ContactEventHandler ShowCompany;
        public event ContactEventHandler ClearCompany;
        public event ContactEventHandler NewCompany;
        public event ContactEventHandler SearchCompany;
        public event ContactEventHandler CompanyChangeFinished;
        public event ContactEventHandler ClearCompanyFinished;

        public SysNewMethod xSys
        {
            get
            {
                return RzWin.Context.xSys;
            }
        }
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        public nObject CurrentObject;
        public String CompanyIDField = "";
        public String CompanyNameField = "";
        public String ContactIDField = "";
        public String ContactNameField = "";
        public Enums.CompanySelectionType CurrentSelectionType = Enums.CompanySelectionType.Both;
        public String CurrentSelectionCaption = "Company Selection...";

        public String CurrentCompanyName = "";
        public String CurrentCompanyID = "";

        public String CompanyID;
        public CompanyStub()
        {
            InitializeComponent();
        }

        public String Caption
        {
            get
            {
                return lblCaption.Text;
            }
            set
            {
                lblCaption.Text = value;
            }
        }

        public void SetCompany()
        {
            if (CurrentObject == null)
                return;

            SetCompany((String)CurrentObject.IGet(CompanyNameField), (String)CurrentObject.IGet(CompanyIDField), (String)CurrentObject.IGet(ContactNameField), (String)CurrentObject.IGet(ContactIDField));
        }

        public void OnlyShowViewClear()
        {
            lblLast.Visible = false;
            lblSearchCompany.Visible = false;
            lblNewCompany.Visible = false;
            lblSummary.Visible = false;
        }

        public virtual void SetCompany(String strCompanyName, String strCompanyID, String strContactName, String strContactID)
        {
            //should never get called in pluscontact mode
            SetCompany(strCompanyName, strCompanyID);
        }

        public void SetCompany(String strCompanyName, String strCompanyID)
        {
            CurrentCompanyName = strCompanyName;
            CurrentCompanyID = strCompanyID;

            if (Tools.Strings.StrExt(strCompanyName))
            {
                lblViewCompany.Visible = true;
                lblCompany.Text = strCompanyName;
            }
            else
            {
                lblViewCompany.Visible = false;
                lblCompany.Text = "<click to choose>";
            }

            if (CurrentObject != null)
            {

                //String oldName = CurrentObject.CompanyName;
                //CurrentObject.CompanyName = strCompanyName;
                //CurrentObject.CompanyID = strCompanyID;
                //if (oldName != strCompanyName)
                //{
                //    DoClearContact();
                //}
            }

            CompanyID = strCompanyID;
            UpdateState();

        }

        private void lblCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                mnu.Show(System.Windows.Forms.Cursor.Position);
                return;
            }
            if (ChangeCompany != null)
            {
                GenericEvent ge = new GenericEvent();
                ChangeCompany(ge);
                if (ge.Handled)
                    return;
            }

            ChangeTheCompany();
        }

        public void ChangeTheCompany()
        {
            ChangeTheCompany("", "");
        }

        public void ChangeTheCompany(String AbsoluteID, String AbsoluteName)
        {
            String strID = "";
            String strName = "";

            String strOldID;

            tip.RemoveAll();

            if (CurrentObject != null)
                strOldID = (String)CurrentObject.IGet(CompanyIDField);
            else
                strOldID = "";

            if (Tools.Strings.StrExt(AbsoluteID) && Tools.Strings.StrExt(AbsoluteName))
            {
                strID = AbsoluteID;
                strName = AbsoluteName;
            }
            else
            {
                frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, CurrentSelectionType, CurrentSelectionCaption);

                if (Tools.Strings.StrExt(strID) && Tools.Strings.StrExt(strName))
                {
                    RzWin.Leader.LastCompanyHandle = new CompanyHandle(strID, strName);
                    if (!RzWin.User.HasClipObject(strID))
                        RzWin.User.AddClipObject(RzWin.Context, company.GetById(RzWin.Context, strID));
                }
            }

            if (Tools.Strings.StrExt(strID))
            {
                //get rid of the contact first
                if (!Tools.Strings.StrCmp(strID, strOldID))
                    DoClearContact();

                SetCompanyInfo(strID, strName);
            }

            if (CompanyChangeFinished != null)
                CompanyChangeFinished(new GenericEvent());
        }

        public virtual void DoClearContact()
        {
            //this is only needed in the overriden pluscontact version
        }

        public void SetCompanyInfo(String strID, String strName)
        {
            CurrentCompanyName = strName;
            CurrentCompanyID = strID;

            if (CurrentObject != null)
            {
                CurrentObject.ISet_Conditional(CompanyIDField, strID);
                CurrentObject.ISet_Conditional(CompanyNameField, strName);
            }

            SetCompany(strName, strID);
        }

        private void lblViewCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GenericEvent ev;
            if (ShowCompany != null)
            {
                ev = new GenericEvent();
                ShowCompany(ev);
                if( ev.Handled )
                    return;
            }
            if (xSys != null)
            {
                RzWin.Context.Show(RzWin.Context.GetById("company", CompanyID));
            }
        }

        public void DoClearCompany()
        {
            CurrentCompanyName = "";
            CurrentCompanyID = "";
            if (CurrentObject != null)
            {
                CurrentObject.ISet(CompanyNameField, "");
                CurrentObject.ISet(CompanyIDField, "");
            }

            DoClearContact();
            lblCompany.Text = "<click to choose>";
            UpdateState();

            if (ClearCompanyFinished != null)
                ClearCompanyFinished(new GenericEvent());
        }

        public void UpdateState()
        {
            if (!ShowingCompany())
            {
                lblViewCompany.Visible = false;
                lblClearCompany.Visible = false;
                lblSummary.Visible = false;

            }
            else
            {
                lblViewCompany.Visible = true;
                lblClearCompany.Visible = true;
                lblSummary.Visible = true;
            }
        }

        public bool ShowingCompany()
        {
            return (Tools.Strings.StrExt(lblCompany.Text) && !Tools.Strings.StrCmp(lblCompany.Text, "<click to choose>"));
        }

        private void lblClearCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentCompanyName = "";
            CurrentCompanyID = "";
            if (ClearCompany != null)
            {
                GenericEvent ev = new GenericEvent();
                ClearCompany(ev);

                if (ev.Handled)
                    return;
            }

            DoClearCompany();
        }

        private void lblNewCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NewCompany != null)
            {
                GenericEvent ev = new GenericEvent();
                NewCompany(ev);
                if (ev.Handled)
                    return;
            }

            if (CurrentObject != null)
            {
                company c = company.AddNew(RzWin.Context, (Tools.Strings.StrCmp(lblCompany.Text, "<company>")) ? "" : lblCompany.Text.Trim(), "", "", "", "");
                if (c != null)
                {
                    DoClearCompany();
                    SetCompanyInfo(c.unique_id, c.companyname);
                    RzWin.Context.Show(c);
                }
            }
        }

        private void lblSearchCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchCompany != null)
            {
                GenericEvent ev = new GenericEvent();
                SearchCompany(ev);
                if (ev.Handled)
                    return;
            }

            if (CurrentObject != null)
            {
                company cm = company.GetById(RzWin.Context, (String)CurrentObject.IGet(CompanyIDField));
                RzWin.Context.TheSysRz.TheCompanyLogic.SearchFor(RzWin.Context, cm, this);
            }
            else
            {
                RzWin.Context.TheSysRz.TheCompanyLogic.SearchFor(RzWin.Context, null, this);
            }
        }

        public void Notify(Object n)
        {
            try
            {
                DoNotify((nObject)n);
            }
            catch (Exception)
            { }
        }

        public virtual void DoNotify(nObject o)
        {
            if (o == null)
                return;

            company cm;
            switch (o.ClassId.ToLower())
            {
                case "company":
                    cm = (company)o;

                    if (CurrentObject == null)
                    {
                        DoClearContact();
                        SetCompanyInfo(cm.unique_id, cm.companyname);
                        RzWin.Leader.LastCompanyHandle = new CompanyHandle(cm);
                    }
                    else
                    {
                        if (!Tools.Strings.StrCmp(cm.unique_id, (String)CurrentObject.IGet(CompanyIDField)))
                        {
                            DoClearContact();
                            SetCompanyInfo(cm.unique_id, cm.companyname);
                        }
                    }
                    break;
            }
        }

        public virtual void Clear()
        {
            DoClearCompany();
        }

        public String GetCompanyName()
        {
            return CurrentCompanyName;
        }

        public String GetCompanyID()
        {
            return CurrentCompanyID;
        }

        private void lblLast_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RzWin.Leader.LastCompanyHandle == null)
            {
                if (RzWin.Leader.LastContactHandle == null)
                    TheContext.TheLeader.TellTemp("No previously selected was found.");
                else
                {
                    if (ChangeCompany != null)
                    {
                        GenericEvent ev = new GenericEvent();
                        ChangeCompany(ev);
                        if (ev.Handled)
                            return;
                    }
                    ChangeTheCompany(RzWin.Leader.LastContactHandle.CompanyID, RzWin.Leader.LastContactHandle.CompanyName);
                }
            }
            else
            {
                if (ChangeCompany != null)
                {
                    GenericEvent ev = new GenericEvent();
                    ChangeCompany(ev);
                    if (ev.Handled)
                        return;
                }
                ChangeTheCompany(RzWin.Leader.LastCompanyHandle.ID, RzWin.Leader.LastCompanyHandle.Name);
            }
        }

        private void lblLast_MouseHover(object sender, EventArgs e)
        {
            if (RzWin.Leader.LastCompanyHandle != null)
                lblLast.Text = "last : " + RzWin.Leader.LastCompanyHandle.Name;
            else if (RzWin.Leader.LastContactHandle != null)
                lblLast.Text = "last : " + RzWin.Leader.LastContactHandle.CompanyName;
        }

        private void lblLast_MouseLeave(object sender, EventArgs e)
        {
            lblLast.Text = "last";
        }

        private void lblSummary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowCompanySummary();
        }

        private void ShowCompanySummary()
        {
            if( !Tools.Strings.StrExt(CurrentCompanyID) )
                return;

            lblSummary.Text = "...";
            Thread t = new Thread(new ThreadStart(ShowCompanySummaryThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void ShowCompanySummaryThread()
        {
            String s = CurrentCompanyID;
            String su = RzWin.Logic.GetCompanySummaryByID(RzWin.Context, s);

            if (this.InvokeRequired)
            {
                ShowCompanySummaryDelegate d = new ShowCompanySummaryDelegate(ShowCompanySummaryHandler);
                this.Invoke(d, new object[] { su });
            }
            else
            {
                ShowCompanySummaryHandler(su);
            }
        }

        public delegate void ShowCompanySummaryDelegate(String s);
        private void ShowCompanySummaryHandler(String s)
        {
            lblSummary.Text = "summary";
            tip.Show(s, lblSummary);
        }

        private void copyCompanyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String s = lblCompany.Text;
            if (Tools.Strings.StrCmp(s, "<click to choose>"))
                return;
            ToolsWin.Clipboard.SetClip(s);
        }

        public void DisableCompany()
        {
            lblCompany.Enabled = false;
            lblClearCompany.Enabled = false;
            lblLast.Enabled = false;
            lblSearchCompany.Enabled = false;
            lblNewCompany.Enabled = false;
        }
        public void EnableCompany()
        {
            lblCompany.Enabled = true;
            lblClearCompany.Enabled = true;
            lblLast.Enabled = true;
            lblSearchCompany.Enabled = true;
            lblNewCompany.Enabled = true;
        }

        protected bool DisabledIs = false;
        public void Enable(bool enabled)
        {
            try
            {
                DisabledIs = !enabled;
                if (DisabledIs)
                    this.Enabled = false;
                else
                    this.Enabled = true;
            }
            catch { }
        }
    }
}
