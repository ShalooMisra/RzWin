using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using Tools;
using NewMethod;

namespace Rz5
{
   
    public partial class CompanyStub_PlusContact : CompanyStub
    {
        public event ContactEventHandler ChangeContact;
        public event ContactEventHandler ShowContact;
        public event ContactEventHandler ClearContact;
        public event ContactEventHandler NewContact;
        public event ContactEventHandler SearchContact;
        public event ContactEventHandler ContactChangeFinished;
        public ContextNM TheContext
        {
            get
            {
                return RzWin.Context;
            }
        }
        public String ContactID;
        public String ContactName;
        public String CurrentContactSelectionCaption = "Contact Selection...";
        
        public CompanyStub_PlusContact()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
        }

        private void lblContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ChangeContact != null)
            {
                GenericEvent ev = new GenericEvent();
                ChangeContact(ev);

                if( ev.Handled )
                    return;
            }

            DoChangeContact();
        }

        public void DoChangeContact()
        {
            DoChangeContact("", "");
        }

        public void DoChangeContact(String AbsoluteID, String AbsoluteName)
        {
            String strID = "";
            String strName = "";

            tipContact.RemoveAll();

            if ( CurrentObject != null && Tools.Strings.StrExt((String)CurrentObject.IGet(CompanyIDField)))
            {
                if (Tools.Strings.StrExt(AbsoluteID) && Tools.Strings.StrExt(AbsoluteName))
                {
                    strID = AbsoluteID;
                    strName = AbsoluteName;
                }
                else
                {
                    frmChooseContact_Big.ChooseContactID(ref strID, ref strName, (String)CurrentObject.IGet(CompanyIDField), CurrentContactSelectionCaption, this.ParentForm);
                    if (Tools.Strings.StrExt(strID) && Tools.Strings.StrExt(strName))
                    {
                        RzWin.Leader.LastContactHandle = new ContactHandle(strID, strName, (String)CurrentObject.IGet(CompanyIDField), (String)CurrentObject.IGet(CompanyNameField));
                        if (!RzWin.User.HasClipObject(strID))
                            RzWin.User.AddClipObject(RzWin.Context, companycontact.GetById(RzWin.Context, strID));
                    }
                }

                if (Tools.Strings.StrExt(strID))
                {
                    CurrentObject.ISet_Conditional(ContactIDField, strID);
                    CurrentObject.ISet_Conditional(ContactNameField, strName);
                    SetCompany((String)CurrentObject.IGet(CompanyNameField), (String)CurrentObject.IGet(CompanyIDField), (String)CurrentObject.IGet(ContactNameField), (String)CurrentObject.IGet(ContactIDField));
                }
                return;
            }
            else
            {
                String strContactID = "";
                String strContactName = "";

                strID = GetCompanyID();
                if (Tools.Strings.StrExt(strID))
                {
                    strID = "";
                    if (Tools.Strings.StrExt(AbsoluteID) && Tools.Strings.StrExt(AbsoluteName))
                    {
                        strContactID = AbsoluteID;
                        strContactName = AbsoluteName;
                    }
                    else
                    {
                        frmChooseContact_Big.ChooseContactID(ref strContactID, ref strContactName, GetCompanyID(), CurrentContactSelectionCaption, this.ParentForm);
                        if (Tools.Strings.StrExt(strContactID) && Tools.Strings.StrExt(strContactName))
                        {
                            RzWin.Leader.LastContactHandle = new ContactHandle(strContactID, strContactName, GetCompanyID(), GetCompanyName());
                            if (!RzWin.User.HasClipObject(strContactID))
                                RzWin.User.AddClipObject(RzWin.Context, companycontact.GetById(RzWin.Context, strContactID));
                        }
                    }
                }
                else
                {
                    frmChooseCompanyContact.ChooseCompanyID(ref strID, ref strName, ref  strContactID, ref strContactName, CurrentSelectionType, CurrentSelectionCaption, this.ParentForm);
                    if (Tools.Strings.StrExt(strID) && Tools.Strings.StrExt(strName) && Tools.Strings.StrExt(strContactID) && Tools.Strings.StrExt(strContactName))
                    {
                        RzWin.Leader.LastContactHandle = new ContactHandle(strContactID, strContactName, strID, strName);
                        if (!RzWin.User.HasClipObject(strContactID))
                            RzWin.User.AddClipObject(RzWin.Context, companycontact.GetById(RzWin.Context, strContactID));
                    }
                }

                if (Tools.Strings.StrExt(strID))
                {
                    SetCompany(strName, strID, strContactName, strContactID);
                    if (CurrentObject != null)
                    {
                        CurrentObject.ISet_Conditional(CompanyIDField, strID);
                        CurrentObject.ISet_Conditional(CompanyNameField, strName);
                    }
                }
                else if (Tools.Strings.StrExt(strContactID))
                {
                    SetContactInfo(strContactID, strContactName);
                }
            }
        }

        public void SetContactInfo(String strContactID, String strContactName)
        {
            if (CurrentObject != null)
                SetCompany((String)CurrentObject.IGet(CompanyNameField), (String)CurrentObject.IGet(CompanyIDField), (String)CurrentObject.IGet(ContactNameField), (String)CurrentObject.IGet(ContactIDField));
            else
                SetCompany(GetCompanyName(), GetCompanyID(), strContactName, strContactID);

            if (ContactChangeFinished != null)
                ContactChangeFinished(new GenericEvent());
        }

        public override void SetCompany(String strCompanyName, String strCompanyID, String strContactName, String strContactID)
        {
            base.SetCompany(strCompanyName, strCompanyID);

            if (Tools.Strings.StrExt(strContactName))
            {
                lblContact.Text = strContactName;
            }
            else
            {
                DoClearContact();
            }
            
            ContactID = strContactID;
            ContactName = strContactName;

            if (CurrentObject != null)
            {
                CurrentObject.ISet_Conditional(ContactNameField, strContactName);
                CurrentObject.ISet_Conditional(ContactIDField, strContactID);
            }
            
            UpdateState();
        }

        private void lblViewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Do_ViewContact_LinkClicked();
        }
        private void Do_ViewContact_LinkClicked()
        {
            Do_ViewContact_LinkClicked(RzWin.Form.TheContextNM);
        }
        private void Do_ViewContact_LinkClicked(ContextNM x)
        {
            GenericEvent ev;
            if (ShowContact != null)
            {
                ev = new GenericEvent();
                ShowContact(ev);
                if (ev.Handled)
                {
                    UpdateState();
                    return;
                }
            }

            if (CurrentObject != null)
            {
                if (xSys == null)
                {
                    x.TheLeader.TellTemp("The System for this company stub is not set.");
                    return;
                }

                companycontact c = companycontact.GetById(RzWin.Context, (String)CurrentObject.IGet(ContactIDField));
                if (c != null)
                    RzWin.Context.Show(c);
            }
            else
            {
                if (xSys != null)
                {
                    RzWin.Context.Show(RzWin.Context.GetById("companycontact", ContactID));
                }
                else
                { }
            }
        }

        public override void DoClearContact()
        {
            if (CurrentObject != null)
            {
                CurrentObject.ISet(ContactNameField, "");
                CurrentObject.ISet(ContactIDField, "");
            }

            lblContact.Text = "<click to choose>";
            ContactName = "";
            ContactID = "";
            if( !DisabledIs )
                ContactEnable();
            UpdateState();

            //try
            //{
            //    if (ContactChangeFinished != null)
            //        ContactChangeFinished(new GenericEvent());
            //}
            //catch (Exception)
            //{ }
        }

        public void UpdateState()
        {
            if (!ShowingContact())
            {
                lblViewContact.Visible = false;
                lblClearContact.Visible = false;
                lblSummaryContact.Visible = false;
            }
            else
            {
                lblViewContact.Visible = true;
                lblClearContact.Visible = true;
                lblSummaryContact.Visible = true;
            }
        }

        public void ContactEnable()
        {
            lblContact.Enabled = true;
        }

        public void ContactDisable()
        {
            lblContact.Enabled = false;
        }

        public bool ShowingContact()
        {
            return (Tools.Strings.StrExt(lblContact.Text) && !Tools.Strings.StrCmp(lblContact.Text, "<click to choose>"));
        }

        private void lblClearContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ClearContact != null)
            {
                GenericEvent ev = new GenericEvent();
                ClearContact(ev);

                if (ev.Handled)
                    return;
            }

            DoClearContact();
        }

        private void lblNewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (NewContact != null)
            {
                GenericEvent ev = new GenericEvent();
                NewContact(ev);
                if (ev.Handled)
                    return;
            }

            if (CurrentObject != null)
            {
                DoNewContact();
            }
        }

        private void DoNewContact()
        {
            if (Tools.Strings.StrExt((String)CurrentObject.IGet(CompanyIDField)))
            {
                companycontact c = RzWin.Leader.AddNewContact(RzWin.Context, (String)CurrentObject.IGet(CompanyIDField), (String)CurrentObject.IGet(CompanyNameField));
                if (c != null)
                {
                    SetContactInfo(c.unique_id, c.contactname);
                    RzWin.Context.Show(c);
                }
            }
            else
            {
                RzWin.Context.Error("Please select a company before adding a new contact.");
            }
        }

        private void lblSearchContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SearchContact != null)
            {
                GenericEvent ev = new GenericEvent();
                SearchContact(ev);
                if (ev.Handled)
                    return;
            }
            
            company cm = null;
            if (CurrentObject != null)
            {
                cm = company.GetById(RzWin.Context, (String)CurrentObject.IGet(CompanyIDField));
            }
            else
            {
                cm = company.GetByName(RzWin.Context, GetCompanyName());
            }
            RzWin.Leader.SearchForCompany(cm, this);

        }

        public override void DoNotify(nObject o)
        {
            companycontact c;

            switch (o.ClassId.ToLower())
            {
                case "companycontact":
                    c = (companycontact)o;

                    if (!Tools.Strings.StrExt(c.base_company_uid))
                    {
                        if(RzWin.Leader.AskYesNo(c.ToString() + " is not linked to a company.  Do you want to link this contact now?") )
                            RzWin.Context.Show(c);
 
                        return;
                    }

                    SetCompanyInfo(c.base_company_uid, c.companyname);
                    SetContactInfo(c.unique_id, c.contactname);
                    RzWin.Leader.LastContactHandle = new ContactHandle(c);
                    break;
                default:
                    base.DoNotify(o);
                    break;
            }            
        }

        public override void Clear()
        {
            base.Clear();
            DoClearContact();
        }

        public String GetContactName()
        {
            return ContactName;
        }

        public String GetContactID()
        {
            return ContactID;
        }

        private void lblLastContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (RzWin.Leader.LastContactHandle == null)
            {
                TheContext.TheLeader.TellTemp("The last selected contact could not be found.");
            }
            else
            {
                ChangeTheCompany(RzWin.Leader.LastContactHandle.CompanyID, RzWin.Leader.LastContactHandle.CompanyName);
                DoChangeContact(RzWin.Leader.LastContactHandle.ID, RzWin.Leader.LastContactHandle.Name);
            }
        }

        private void lblLastContact_MouseHover(object sender, EventArgs e)
        {
            if (RzWin.Leader.LastContactHandle != null)
            {
                lblLastContact.Text = "last : " + RzWin.Leader.LastContactHandle.Name;
            }
        }

        private void lblLastContact_MouseLeave(object sender, EventArgs e)
        {
            lblLastContact.Text = "last";
        }

        private void lblSummaryContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowContactSummary();
        }

        public String GetCurrentContactID()
        {
            if (CurrentObject != null)
                return (String)CurrentObject.IGet(ContactIDField);
            else
                return ContactID;
        }

        private void ShowContactSummary()
        {
            if (!Tools.Strings.StrExt(GetCurrentContactID()))
                return;

            lblSummaryContact.Text = "...";
            Thread t = new Thread(new ThreadStart(ShowContactSummaryThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void ShowContactSummaryThread()
        {
            String s = GetCurrentContactID();
            String su = RzWin.Logic.GetContactSummaryByID(RzWin.Context, s);

            if (this.InvokeRequired)
            {
                ShowContactSummaryDelegate d = new ShowContactSummaryDelegate(ShowContactSummaryHandler);
                this.Invoke(d, new object[] { su });
            }
            else
            {
                ShowContactSummaryHandler(su);
            }
        }

        public delegate void ShowContactSummaryDelegate(String s);
        private void ShowContactSummaryHandler(String s)
        {
            lblSummaryContact.Text = "summary";
            tipContact.Show(s, lblSummaryContact);
        }

    }

    public delegate void ContactEventHandler(GenericEvent e);
}

