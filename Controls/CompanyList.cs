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
    public partial class CompanyList : UserControl
    {
        public event CompanyEvent CompanyClicked;

        private bool bInhibit = false;

        public CompanyList()
        {
            InitializeComponent();
        }

        private void CompanyList_Resize(object sender, EventArgs e)
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

        public void SetCustomer()
        {
            lbl.Text = "Customer:";
            bInhibit = true;
            optCustomer.Checked = true;
            cbo.DataSource = RzWin.Logic.CustomerList;
            cbo.DisplayMember = "caption";
            cbo.ValueMember = "unique_id";
            bInhibit = false;
        }

        public void SetVendor()
        {
            lbl.Text = "Vendor:";
            bInhibit = true;
            optVendor.Checked = true;
            cbo.DataSource = RzWin.Logic.VendorList;
            cbo.DisplayMember = "caption";
            cbo.ValueMember = "unique_id";
            bInhibit = false;
        }

        public void SetCompany()
        {
            lbl.Text = "Company:";
            bInhibit = true;
            optCompany.Checked = true;
            cbo.DataSource = RzWin.Logic.CompanyList;
            cbo.DisplayMember = "caption";
            cbo.ValueMember = "unique_id";
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

        public void SetListFocus()
        {
            cbo.Focus();
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

        private void cbo_SelectedValueChanged(object sender, EventArgs e)
        {
            String s = "";
            if (CompanyClicked != null)
            {
                s = GetSelectedID();
                CompanyEventArgs args = new CompanyEventArgs(s);
                CompanyClicked(this, args);

                if (args.Handled)
                    return;
            }
        }

        private void cbo_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        public void Clear()
        {
            cbo.Text = "";
        }

        public void FocusOnBox()
        {
            cbo.Focus();
        }

        public void DropDown()
        {
            int i = 1;
            System.IntPtr p = (System.IntPtr)i;
            SendMessage(cbo.Handle, CB_SHOWDROPDOWN, p, IntPtr.Zero);
        }

        [DllImport("User32.dll")]
        static extern int SendMessage(IntPtr hWnd, int uMsg, IntPtr wParam, IntPtr lParam);

        private const int CB_SHOWDROPDOWN = 0x14F;

    }

    public class CompanyEventArgs
    {
        public String strID;
        public bool Handled = false;

        public CompanyEventArgs(String sid)
        {
            strID = sid;
        }
    }

    public delegate void CompanyEvent(Object sender, CompanyEventArgs args);
}
