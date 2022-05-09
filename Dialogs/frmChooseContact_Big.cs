using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using NewMethod;

namespace Rz5
{
    public partial class frmChooseContact_Big : Form
    {
        public static void ChooseContactID(ref String strContactID, ref String strContactName, String strCompanyID, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseContact_Big xForm = new frmChooseContact_Big();
            xForm.Text = strCaption;
            xForm.Init(strCompanyID);
            xForm.ShowDialog(owner);

            strContactID = xForm.SelectedID;
            strContactName = xForm.SelectedName;
            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }
        }

        public static companycontact Choose(ArrayList contacts, String caption)
        {
            frmChooseContact_Big xForm = new frmChooseContact_Big();
            xForm.Text = caption;
            xForm.Init(contacts);
            xForm.ShowDialog(null);

            companycontact ret = xForm.SelectedContact;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            return ret;
        }

        public String CompanyID = "";
        public String SelectedID = "";
        public String SelectedName = "";
        bool bInhibit = false;
        public companycontact SelectedContact;

        bool LiveMode = false;
        public frmChooseContact_Big()
        {
            InitializeComponent();
        }

        public void Init(String strCompanyID)
        {
            CompanyID = strCompanyID;
            ShowClipContacts();

            SetContact(RzWin.Context.Select("select contactname as caption, unique_id from companycontact where base_company_uid = '" + CompanyID + "' and isnull(contactname, '') > '' order by contactname"));

            txtEnter.Text = "";
            tv.ExpandAll();
        }

        public void Init(ArrayList contacts)
        {
            LiveMode = true;
            SelectedContact = null;
            cmdAdd.Enabled = false;
            HideClipContacts();
            SetContact(contacts);
            txtEnter.Text = "";
            tv.ExpandAll();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedID = "";
            SelectedName = "";
            SelectedContact = null;
            this.Close();
        }

        private void ClickOK()
        {
            if (LiveMode)
            {
                SelectedContact = GetSelectedContact();
                if (SelectedContact == null)
                {
                    RzWin.Context.Error("Please select a name before continuing.");
                    return;
                }
                this.Hide();
            }
            else
            {
                SelectedID = GetSelectedID();
                SelectedName = GetSelectedName();
                if (Tools.Strings.StrExt(SelectedID))
                {
                    this.Hide();
                }
                else
                {
                    RzWin.Context.Error("Please select a name before continuing.");
                }
            }
        }

        public void SetContact(DataTable d)
        {
            if (d == null)
                return;

            lbl.Text = "Contact:";
            bInhibit = true;
            foreach (DataRow r in d.Rows)
            {
                ListViewItem i = lst.Items.Add(nData.NullFilter_String(r["caption"]));
                i.Tag = nData.NullFilter_String(r["unique_id"]);
            }
            bInhibit = false;
        }

        public void SetContact(ArrayList contacts)
        {
            lbl.Text = "Contact:";
            bInhibit = true;
            lst.Items.Clear();
            foreach (companycontact x in contacts)
            {
                ListViewItem i = lst.Items.Add(x.contactname);
                i.Tag = x.unique_id;
            }
            bInhibit = false;            
        }

        public String GetSelectedID()
        {
            
            String s = "";
            try
            {
                s = (String)lst.SelectedItems[0].Tag;
            }
            catch (Exception)
            {
            }
            return s;
        }

        public companycontact GetSelectedContact()
        {
            try
            {
                return (companycontact)RzWin.Context.GetById("companycontact", GetSelectedID());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public String GetSelectedName()
        {
            try
            {
                return (String)lst.SelectedItems[0].Text;

            }
            catch (Exception)
            {
                return "";
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            bInhibit = true;
            lblContact.Text = GetSelectedName();
            bInhibit = false;
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

            HighlightContact(txtEnter.Text);
        }

        private void HighlightContact(String s)
        {
            try
            {
                lst.SelectedItems.Clear();
                foreach (ListViewItem i in lst.Items)
                {
                    if (i.Text.ToLower().StartsWith(s.ToLower()))
                    {
                        i.Selected = true;
                        i.EnsureVisible();
                        break;
                    }
                }
            }
            catch { }
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

        public void HideClipContacts()
        {
            tv.Nodes.Clear();
            tv.Enabled = false;
        }

        public void ShowClipContacts()
        {
            tv.BeginUpdate();
            tv.Nodes.Clear();

            try
            {
                TreeNode t = tv.Nodes.Add("Recent Contacts");
                t.ImageIndex = 0;
                t.SelectedImageIndex = 0;

                if (RzWin.User != null)
                {
                    if (RzWin.User.RootClip != null)
                    {
                        foreach (n_clip ch in RzWin.User.RootClip.AllClips)
                        {
                            ShowClipContactsNode(ch, t.Nodes);
                        }
                    }
                }
            }
            catch (Exception)
            { }

            tv.ExpandAll();
            tv.EndUpdate();
        }

        public void ShowClipContactsNode(n_clip c, TreeNodeCollection nodes)
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
                            ShowClipContactsNode(ch, f.Nodes);
                        }
                    }

                    //don't show empty folders;
                    if (f.Nodes.Count == 0)
                        nodes.Remove(f);

                    break;
                case NewMethod.Enums.ClipType.Instance:

                    if (Tools.Strings.StrCmp(c.link_class, "companycontact"))
                    {
                        TreeNode g = nodes.Add(c.name);
                        g.ImageIndex = 2;
                        g.SelectedImageIndex = 2;
                        g.Tag = c.GetInstanceHandle();
                    }
                    break;
            }
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetNodeContact(e.Node);
        }

        private bool SetNodeContact(TreeNode t)
        {
            try
            {
                if (t.Tag == null)
                    return false;

                nObjectHandle c = (nObjectHandle)t.Tag;
                companycontact co = companycontact.GetById(RzWin.Context, c.unique_id);

                if (co == null)
                    return false;

                if (!Tools.Strings.StrCmp(co.base_company_uid, CompanyID))
                    return false;

                lblContact.Text = co.contactname;
                HighlightContact(co.contactname);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void frmChooseContact_Big_KeyPress(object sender, KeyPressEventArgs e)
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

        private void frmChooseContact_Big_Activated(object sender, EventArgs e)
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

            companycontact c = (companycontact)RzWin.Context.QtO("companycontact", "select * from companycontact where base_company_uid = '" + CompanyID + "' and contactname = '" + RzWin.Context.Filter(txtEnter.Text) + "'");
            if (c != null)
            {
                lblContact.Text = c.contactname;
                HighlightContact(c.contactname);
                return;
            }

            company co = company.GetById(RzWin.Context, CompanyID);
            if (co == null)
                return;

            c = co.AddContact(RzWin.Context);
            c.contactname = txtEnter.Text;
            c.Update(RzWin.Context);

            SelectedName = c.contactname;
            SelectedID = c.unique_id;
            this.Hide();
            RzWin.Context.Show(c);
        }

        private void tv_DoubleClick(object sender, EventArgs e)
        {
            if (tv.SelectedNode == null)
                return;

            if (!SetNodeContact(tv.SelectedNode))
                return;

            ClickOK();
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
            //int s = lst.SelectedIndex;
            //if (m == -1 && s <= 0)
            //    return;
            //if (m == 1 && s >= (lst.Items.Count - 1))
            //    return;
            //lst.SelectedIndex = lst.SelectedIndex + m;
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
            lblContactSummary.Text = "";
        }

        private void PreviewThread(Object st)
        {
            String strID = "";
            String strQB = "";
            String strContact = "";
            String strContactName = "";

            strID = (String)st;
            strContactName = companycontact.TranslateIDToName(RzWin.Context, strID);

            try
            {
                if (!Tools.Strings.StrExt(strID))
                    return;

                DataTable d = RzWin.Context.Select("select primaryphone, primaryfax, primaryemailaddress, agentname from companycontact where unique_id = '" + strID + "'");
                if (!nTools.DataTableExists(d))
                    return;

                String strPhone = nData.NullFilter_String(d.Rows[0]["primaryphone"]);
                String strFax = nData.NullFilter_String(d.Rows[0]["primaryfax"]);
                String strEmail = nData.NullFilter_String(d.Rows[0]["primaryemailaddress"]);
                String strAgent = nData.NullFilter_String(d.Rows[0]["agentname"]);

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

                if (Tools.Strings.StrExt(strContact))
                    strContact += "  ";

                if (Tools.Strings.StrExt(strAgent))
                    strContact += "Agent: " + strAgent;

                if (this.InvokeRequired)
                {
                    ShowContactDetailsHandler h = new ShowContactDetailsHandler(ShowContactDetails);
                    this.Invoke(h, new Object[] { strID, strContactName, strContact });
                }
                else
                {
                    ShowContactDetails(strID, strContactName, strContact);
                }

            }
            catch (Exception)
            { }
        }

        public delegate void ShowContactDetailsHandler(String strID, String strContactName, String strContact);

        private void ShowContactDetails(String strID, String strContactName, String strContact)
        {
            gb.Text = strContactName;

            if (Tools.Strings.StrExt(strContact))
                lblContactSummary.Text = strContact;
            else
                lblContactSummary.Text = "";
        }
    }
}