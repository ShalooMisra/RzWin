using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using NewMethod;

namespace Rz5
{
    public partial class ContactList : UserControl
    {
        private DataTable t;
        public event CompanyEvent ContactClicked;

        public ContactList()
        {
            InitializeComponent();
        }

        public void LoadCompanyID(String strID)
        {
            if (!Tools.Strings.StrExt(strID))
            {
                cbo.DataSource = null;
                return;
            }

            t = RzWin.Context.Select("select top 1 '' as contactname, '' as unique_id from companycontact union select contactname, unique_id from companycontact where base_company_uid = '" + strID + "' and contactname > '' order by contactname");
            cbo.DataSource = t;
            cbo.DisplayMember = "contactname";
            cbo.ValueMember = "unique_id";
        }

        private void ContactList_Resize(object sender, EventArgs e)
        {
            try
            {
                cbo.Left = 0;
                cbo.Width = this.ClientRectangle.Width;
            }
            catch (Exception)
            {
            }
        }

        public String GetSelectedID()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)cbo.SelectedValue;
                s = (String)v[1];

            }
            catch (Exception)
            {
                s = (String)cbo.SelectedValue;
            }
            return s;
        }

        public String GetSelectedName()
        {
            DataRowView v;
            String s;
            try
            {
                v = (DataRowView)cbo.SelectedValue;
                s = (String)v[0];

            }
            catch (Exception)
            {
                s = (String)cbo.Text;
            }
            return s;
        }

        public void SetListFocus()
        {
            cbo.Focus();
        }

        public void Clear()
        {
            cbo.Text = "";
        }

        public void DropDown()
        {
            int i = 1;
            System.IntPtr p = (System.IntPtr)i;
            SendMessage(cbo.Handle, CB_SHOWDROPDOWN, p, IntPtr.Zero);
        }

        public void FocusOnBox()
        {
            cbo.Focus();
        }

        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);

        private const int CB_SHOWDROPDOWN = 0x14F;

        private void cbo_SelectedValueChanged(object sender, EventArgs e)
        {
            String s = "";
            if (ContactClicked != null)
            {
                s = GetSelectedID();
                CompanyEventArgs args = new CompanyEventArgs(s);
                ContactClicked(this, args);

                if (args.Handled)
                    return;
            }
        }
    }
}
