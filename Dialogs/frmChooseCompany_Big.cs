using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using NewMethod;

namespace Rz5
{
    public partial class frmChooseCompany_Big : Form
    {
        public static void ChooseCompanyID(ref String strCompanyID, ref String strCompanyName, Enums.CompanySelectionType xType, String strCaption)
        {
            RzWin.Leader.CompanyForm.bContactChoice = false;
            RzWin.Leader.CompanyForm.Text = strCaption;
            RzWin.Leader.CompanyForm.Init();
            RzWin.Leader.CompanyForm.ShowDialog(); //(owner)

            strCompanyID = RzWin.Leader.CompanyForm.SelectedID;
            strCompanyName = RzWin.Leader.CompanyForm.SelectedName;
        }

        public static void ChooseCompanyID(ref String strCompanyID, ref String strCompanyName, String CompanyEmailAddress, String ContactName, String CompanyPhone, String CompanyFax, Enums.CompanySelectionType xType, String strCaption, System.Windows.Forms.IWin32Window owner, bool inhibitshow)
        {
            try
            {
                RzWin.Leader.CompanyForm.bContactChoice = false;
                RzWin.Leader.CompanyForm.Text = strCaption;
                RzWin.Leader.CompanyForm.CompanyName = strCompanyName;
                RzWin.Leader.CompanyForm.CompanyEmailAddress = CompanyEmailAddress;
                RzWin.Leader.CompanyForm.ContactName = ContactName;
                RzWin.Leader.CompanyForm.CompanyPhone = CompanyPhone;
                RzWin.Leader.CompanyForm.CompanyFax = CompanyFax;
                RzWin.Leader.CompanyForm.Init();
                RzWin.Leader.CompanyForm.InhibitShowCompany = inhibitshow;
                RzWin.Leader.CompanyForm.ShowDialog(owner);

                strCompanyID = RzWin.Leader.CompanyForm.SelectedID;
                strCompanyName = RzWin.Leader.CompanyForm.SelectedName;
            }
            catch { }
        }


        public static void ChooseCompanyID(ref String strCompanyID, ref String strCompanyName, ref String strContactID, ref String strContactName, Enums.CompanySelectionType xType, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            RzWin.Leader.CompanyForm.SelectedID = "";
            RzWin.Leader.CompanyForm.SelectedName = "";
            RzWin.Leader.CompanyForm.SelectedContactID = "";
            RzWin.Leader.CompanyForm.SelectedContactName = "";

            RzWin.Leader.CompanyForm.bContactChoice = true;
            RzWin.Leader.CompanyForm.Text = strCaption;
            RzWin.Leader.CompanyForm.Init();
            RzWin.Leader.CompanyForm.ShowDialog(owner);

            strCompanyID = (RzWin.Leader.CompanyForm.SelectedID == null) ? "" : RzWin.Leader.CompanyForm.SelectedID;
            strCompanyName = (RzWin.Leader.CompanyForm.SelectedName == null) ? "" : RzWin.Leader.CompanyForm.SelectedName;
            strContactID = (RzWin.Leader.CompanyForm.SelectedContactID == null) ? "" : RzWin.Leader.CompanyForm.SelectedContactID;
            strContactName = (RzWin.Leader.CompanyForm.SelectedContactName == null) ? "" : RzWin.Leader.CompanyForm.SelectedContactName;
        }

        public static company ChooseCompany(String caption)
        {
            String strCompanyId = "";
            String strCompanyName = "";
            ChooseCompanyID(ref strCompanyId, ref strCompanyName, Enums.CompanySelectionType.Both, caption);
            return company.GetById(RzWin.Context, strCompanyId);
        }

        public String SelectedID = "";
        public String SelectedName = "";
        public String SelectedContactID = "";
        public String SelectedContactName = "";

        public String CompanyName = "";
        public String CompanyEmailAddress = "";
        public String ContactName = "";
        public String CompanyPhone = "";
        public String CompanyFax = "";
        public bool InhibitShowCompany = false;

        bool bInhibit = false;
        bool bContactChoice = false;
        DateTime LastReload;
        String LastCompanySelected = "";
        String LastContactSelected = "";
        DataTable tContacts;
        String ContactNameToShow = "";

        public frmChooseCompany_Big()
        {
            InitializeComponent();
            LastReload = Tools.Dates.GetNullDate();
            //Rz3App.xSys.RegisterNotifyClass(this, "n_clip");
        }

        public void Init()
        {
            InhibitShowCompany = false;
            if (RzWin.User.LastClipAddition > LastReload)
                ShowClipCompanies();
            txtEnter.Text = LastCompanySelected;
            if (Tools.Strings.StrExt(CompanyName))
                txtEnter.Text = CompanyName;
            tv.ExpandAll();
            if (bContactChoice)
            {
                lblContacts.Visible = true;
                cboContacts.Visible = true;
                cboContacts.BringToFront();
            }
            else
            {
                lblContacts.Visible = true;
                cboContacts.Visible = false;
                lblContacts.BringToFront();
                if (Tools.Strings.StrExt(txtEnter.Text))
                    StartPreview();
                    
            }
            ClearContact();
            //SetDefaults();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedID = "";
            SelectedName = "";
            SelectedContactID = "";
            SelectedContactName = "";
            this.Close();
        }

        private void SetDefaults()
        {
            try
            {
                //if (SelectedID.Length > 0)
                //{
                //    SelectedID = "";
                //    Int32 i = lst.Items.IndexOf(SelectedID);
                //    lst.ClearSelected();
                //    lst.SetSelected(0, true);
                //}
                //if (SelectedContactID.Length > 0 && bContactChoice)
                //{
                //    SelectedContactID = "";
                //}
            }
            catch (Exception)
            { }
        }

        private void ClickOK()
        {
            SelectedID = GetSelectedID();
            SelectedName = GetSelectedName();
            if (Tools.Strings.StrExt(SelectedID))
            {
                LastCompanySelected = SelectedName;
                LastContactSelected = cboContacts.Text;
                if (LastContactSelected == "System.Data.DataRowView")
                    LastContactSelected = "";

                this.Hide();
            }
            else
            {
                RzWin.Context.Error("Please select a name before continuing.");
            }
            if (bContactChoice)
            {
                SelectedContactID = GetSelectedContactID();
                SelectedContactName = GetSelectedContactName();
            }
        }

        public void SetCustomer()
        {
            lbl.Text = "Customer:";
            bInhibit = true;
            optCustomer.Checked = true;
            lst.DataSource = RzWin.Logic.CustomerList;
            lst.DisplayMember = "caption";
            lst.ValueMember = "unique_id";
            bInhibit = false;
        }

        public void SetVendor()
        {
            lbl.Text = "Vendor:";
            bInhibit = true;
            optVendor.Checked = true;
            lst.DataSource = RzWin.Logic.VendorList;
            lst.DisplayMember = "caption";
            lst.ValueMember = "unique_id";
            bInhibit = false;
        }

        public void SetCompany()
        {
            lbl.Text = "Company:";
            bInhibit = true;
            optCompany.Checked = true;
            lst.DataSource = RzWin.Logic.CompanyList;
            lst.DisplayMember = "caption";
            lst.ValueMember = "unique_id";
            bInhibit = false;
        }

        public void SetType(Enums.CompanySelectionType xType)
        {
            switch (xType)
            {
                case Enums.CompanySelectionType.Both:
                    SetCompany();
                    return;
                case Enums.CompanySelectionType.Customer:
                    SetCustomer();
                    break;
                case Enums.CompanySelectionType.Vendor:
                    SetVendor();
                    return;
            }
        }

        private void opt_CheckedChanged(object sender, EventArgs e)
        {
            if (bInhibit)
                return;

            if (optCompany.Checked)
                SetCompany();
            else if (optCustomer.Checked)
                SetCustomer();
            else if (optVendor.Checked)
                SetVendor();
        }

        public String GetSelectedID()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)lst.SelectedValue;
                s = (String)v[1];

            }
            catch (Exception)
            {
                s = (String)lst.SelectedValue;
            }
            return s;
        }

        public String GetSelectedName()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)lst.SelectedValue;
                s = (String)v[0];

            }
            catch (Exception)
            {
                s = (String)lst.Text;
            }
            return s;
        }

        public String GetSelectedContactID()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)cboContacts.SelectedItem;
                s = (String)v[1];

            }
            catch (Exception)
            {
                s = (String)cboContacts.SelectedItem;
            }
            return s;
        }

        public String GetSelectedContactName()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)cboContacts.SelectedItem;
                s = (String)v[0];

            }
            catch (Exception)
            {
                s = (String)cboContacts.SelectedItem;
            }
            return s;
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            bInhibit = true;
            lblCompany.Text = GetSelectedName();
            bInhibit = false;
            ContactNameToShow = "";
            StartPreview();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void txtEnter_TextChanged(object sender, EventArgs e)
        {
            if (bInhibit)
                return;

            HighlightCompany(txtEnter.Text);
            StartPreview();
        }

        private void HighlightCompany(String s)
        {
            try
            {
                int i = lst.FindString(s);
                if (i == -1)
                    return;

                lst.SelectedIndex = i;
            }
            catch (Exception)
            { }
        }

        private void txtEnter_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    ClickOK();
                    e.Handled = true;
                    break;
                case '\n':
                    ClickOK();
                    e.Handled = true;
                    break;
            }
        }

        public void ShowClipCompanies()
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();

            try
            {
                TreeNode t = tv.Nodes.Add("Recent Companies");
                t.ImageIndex = 0;
                t.SelectedImageIndex = 0;

                if (RzWin.User != null)
                {
                    if (RzWin.User.RootClip != null)
                    {
                        foreach (n_clip ch in RzWin.User.RootClip.AllClips)
                        {
                            ShowClipCompaniesNode(ch, t.Nodes);
                        }
                    }
                }
            }
            catch (Exception)
            { }

            tv.ExpandAll();
            tv.EndUpdate();
            LastReload = System.DateTime.Now;
        }

        public void ShowClipCompaniesNode(n_clip c, TreeNodeCollection nodes)
        {
            switch (c.ClipType)
            {
                case NewMethod.Enums.ClipType.Folder:
                    TreeNode f = nodes.Add(c.name);
                    f.ImageIndex = 1;
                    f.SelectedImageIndex = 1;

                    if (c.AllClips != null)
                    {
                        foreach (n_clip ch in c.AllClips)
                        {
                            ShowClipCompaniesNode(ch, f.Nodes);
                        }
                    }

                    //don't show empty folders;
                    if (f.Nodes.Count == 0)
                        nodes.Remove(f);

                    break;
                case NewMethod.Enums.ClipType.Instance:

                    if (Tools.Strings.StrCmp(c.link_class, "company"))
                    {
                        TreeNode g = nodes.Add(c.name);
                        g.ImageIndex = 2;
                        g.SelectedImageIndex = 2;
                        g.Tag = c.GetInstanceHandle();
                    }
                    break;
            }
        }

        //public void NotifyChangeHandler(String strClass, bool adds)
        //{
        //    switch (strClass.ToLower().Trim())
        //    {
        //        case "n_clip":
        //            ShowClipCompanies_Delayed();
        //            break;
        //    }
        //}

        //public void NotifyChange(String strClass, bool adds)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        HandleChangeNotification d = new HandleChangeNotification(NotifyChangeHandler);
        //        this.Invoke(d, new object[] { strClass, adds });
        //    }
        //    else
        //    {
        //        NotifyChangeHandler(strClass, adds);
        //    }
        //}

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetNodeCompany(e.Node);
            StartPreview();
        }

        private bool SetNodeCompany(TreeNode t)
        {
            try
            {
                if (t.Tag == null)
                    return false;

                nObjectHandle c = (nObjectHandle)t.Tag;
                String s = company.TranslateIDToName(RzWin.Context, c.unique_id);
                if (!Tools.Strings.StrExt(s))
                    return false;
                lblCompany.Text = s;
                HighlightCompany(s);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void frmChooseCompany_Big_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                    ClickOK();
                    e.Handled = true;
                    break;
                case '\n':
                    ClickOK();
                    e.Handled = true;
                    break;
            }
        }

        private void frmChooseCompany_Big_Activated(object sender, EventArgs e)
        {
            try
            {
                txtEnter.Focus();
                txtEnter.SelectAll();
            }
            catch (Exception)
            { }
        }

        private void cmdAdd_Click(object sender, EventArgs e)
        {
            //get this off of the modal stack
            this.Hide();
            company c = company.AddNew(RzWin.Context, txtEnter.Text);

            if (c == null)
            {
                SelectedID = "";
                SelectedName = "";
            }
            else
            {
                SelectedID = c.unique_id;
                SelectedName = c.companyname;
                c.primaryemailaddress = CompanyEmailAddress;
                c.primarycontact = ContactName;
                c.primaryphone = CompanyPhone;
                c.primaryfax = CompanyFax;
                LastCompanySelected = SelectedName;
                c.Update(RzWin.Context);
                try
                {
                    if( !InhibitShowCompany )
                        RzWin.Context.Show(c);
                }
                catch (Exception)
                { }
            }
        }

        private void tv_DoubleClick(object sender, EventArgs e)
        {
            if (tv.SelectedNode == null)
                return;

            if (!SetNodeCompany(tv.SelectedNode))
                return;

            ClickOK();
        }

        private void StartPreview()
        {
            tmrPreview.Stop();
            tmrPreview.Start();
        }

        private void tmrPreview_Tick(object sender, EventArgs e)
        {
            tmrPreview.Stop();

            //clear
            ClearContact();

            String strID = GetSelectedID();

            if (!Tools.Strings.StrExt(strID))
                return;

            String strName = GetSelectedName();

            Thread t = new Thread(new ParameterizedThreadStart(PreviewThread));
            t.SetApartmentState(ApartmentState.STA);
            t.Start(strID);
        }

        private void ClearContact()
        {
            gb.Text = "";
            lblQB.Text = "";
            lblContact.Text = "";
            lblContacts.Text = "";
            //cboContacts.Items.Clear();
            cboContacts.DataSource = null;
            cboContacts.Text = "";
        }

        private void PreviewThread(Object st)
        {
            String strID = "";
            String strCompany = "";
            String strQB = "";
            String strContact = "";
            String strContacts = "";

            strID = (String)st;
            strCompany = company.TranslateIDToName(RzWin.Context, strID);

            try
            {
                if (!Tools.Strings.StrExt(strID))
                    return;

                DataTable d = RzWin.Context.Select("select qb_name, primaryphone, primaryfax, primaryemailaddress from company where unique_id = '" + strID + "'");
                if (!nTools.DataTableExists(d))
                    return;

                //if (!bContactChoice)
                //{
                ArrayList a = RzWin.Context.SelectScalarArray("select distinct(contactname) from companycontact where base_company_uid = '" + strID + "' and isnull(contactname, '') > '' order by contactname");
                    strContacts = "";
                    foreach (String s in a)
                    {
                        if (Tools.Strings.StrExt(strContacts))
                            strContacts += ", ";
                        strContacts += s;
                    }
                    if (Tools.Strings.StrExt(strContacts))
                    {
                        strContacts = "Contacts: " + strContacts;
                    }
                    else
                    {
                        strContacts = "<no contacts>";
                    }
                //}
                //else
                //{
                    tContacts = RzWin.Context.Select("select top 1 '' as contactname, '' as unique_id from companycontact union select contactname, unique_id from companycontact where base_company_uid = '" + strID + "' and contactname > '' order by contactname");
                //}
                strQB = nData.NullFilter_String(d.Rows[0]["qb_name"]);

                String strPhone = nData.NullFilter_String(d.Rows[0]["primaryphone"]);
                String strFax = nData.NullFilter_String(d.Rows[0]["primaryfax"]);
                String strEmail = nData.NullFilter_String(d.Rows[0]["primaryemailaddress"]);

                strContact = "";
                if (Tools.Strings.StrExt(strPhone))
                    strContact += "Phone: " + strPhone;

                if (Tools.Strings.StrExt(strContact))
                    strContact += "  ";

                if (Tools.Strings.StrExt(strFax))
                    strContact += "Fax: " + strFax;

                if (Tools.Strings.StrExt(strContact))
                    strContact += "  ";

                if (Tools.Strings.StrExt(strEmail))
                    strContact += "Email: " + strEmail;

                if (this.InvokeRequired)
                {
                    ShowCompanyDetailsHandler h = new ShowCompanyDetailsHandler(ShowCompanyDetails);
                    this.Invoke(h, new Object[] { strID, strCompany, strQB, strContact, strContacts });
                }
                else
                {
                    ShowCompanyDetails(strID, strCompany, strQB, strContact, strContacts);
                }

            }
            catch (Exception)
            { }
        }

        public delegate void ShowCompanyDetailsHandler(String strID, String strCompany, String strQB, String strContact, String strContacts);

        private void ShowCompanyDetails(String strID, String strCompany, String strQB, String strContact, String strContacts)
        {
            gb.Text = strCompany;

            //if (!bContactChoice)
            //{
                if (Tools.Strings.StrExt(strContact))
                    lblContact.Text = strContact;
                else
                    lblContact.Text = "";
            //}
            //else
            //{
                if (!(tContacts == null))
                {
                    cboContacts.DataSource = tContacts;
                    cboContacts.DisplayMember = "contactname";
                    cboContacts.ValueMember = "unique_id";

                    if (Tools.Strings.StrExt(ContactNameToShow))
                    {
                        cboContacts.Text = ContactNameToShow;
                    }
                    else
                    {
                        if (cboContacts.Text == "" && Tools.Strings.StrExt(LastContactSelected) && cboContacts.Items.Contains(LastContactSelected))
                            cboContacts.Text = LastContactSelected;
                    }
                }
            //}
            if (Tools.Strings.StrExt(strQB))
                lblQB.Text = "QB Name: " + strQB;
            else
                lblQB.Text = "<no QB name>";

            lblContacts.Text = strContacts;

            //i thought this was a good idea but the requesting company never paid for this round and everyone else complained about the contact auto-drop
            //if (cboContacts.Visible)
            //    cboContacts.DroppedDown = true;
        }

        private void lst_DoubleClick(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void txtEnter_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        e.Handled = true;
                        MoveList(-1);
                        return;
                    case Keys.Down:
                        e.Handled = true;
                        MoveList(1);
                        return;
                }
            }
            catch (Exception)
            { }
        }

        private void MoveList(int m)
        {
            int s = lst.SelectedIndex;
            if (m == -1 && s <= 0)
                return;

            if (m == 1 && s >= (lst.Items.Count - 1))
                return;

            lst.SelectedIndex = lst.SelectedIndex + m;
        }

        private void lblNewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            company c = company.GetById(RzWin.Context, GetSelectedID());
            if (c == null)
            {
                RzWin.Leader.Tell("Please choose a company first.");
                return;
            }
            
            String s = RzWin.Leader.AskForString("New contact name", cboContacts.Text, "New contact name");
            if (!Tools.Strings.StrExt(s))
                return;

            ContactNameToShow = s;

            companycontact co = c.AddContact(RzWin.Context);
            co.contactname = s;
            co.Update(RzWin.Context);
            PreviewThread(c.unique_id);
        }
    }
}