using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class frmChooseCompanyContact : Form
    {

        //accessor
        public static void ChooseCompanyID(ref String strCompanyID, ref String strCompanyName, ref String strContactID, ref String strContactName, Enums.CompanySelectionType xType, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseCompanyContact xForm = new frmChooseCompanyContact();
            xForm.Text = strCaption;
            xForm.SetType(xType);
            xForm.ShowDialog(owner);

            strCompanyID = xForm.SelectedCompanyID;
            strCompanyName = xForm.SelectedCompanyName;
            strContactID = xForm.SelectedContactID;
            strContactName = xForm.SelectedContactName;
        }

        public String SelectedCompanyID = "";
        public String SelectedCompanyName = "";

        public String SelectedContactID = "";
        public String SelectedContactName = "";

        public frmChooseCompanyContact()
        {
            InitializeComponent();
        }

        public void SetType(Enums.CompanySelectionType xType)
        {
            xList.GetCompanyList().SetType(xType);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SelectedCompanyID = xList.GetCompanyList().GetSelectedID();
            SelectedCompanyName = xList.GetCompanyList().GetSelectedName();

            SelectedContactID = xList.GetContactList().GetSelectedID();
            SelectedContactName = xList.GetContactList().GetSelectedName();

            if (Tools.Strings.StrExt(SelectedCompanyID))
                this.Hide();
            else
                RzWin.Context.Error("Please select a company name before continuing.");
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedCompanyID = "";
            SelectedCompanyName = "";

            SelectedContactID = "";
            SelectedContactName = "";

            this.Close();
        }

        private void frmChooseCompanyContact_Load(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
            xList.GetCompanyList().SetListFocus();
        }
    }
}