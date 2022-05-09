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
    public partial class frmChooseContact : Form
    {
        //accessor
        public static void ChooseContactID(ref String strContactID, ref String strContactName, String strCompanyID, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseContact xForm = new frmChooseContact();
            xForm.Text = strCaption;
            xForm.LoadContacts(strCompanyID);
            xForm.ShowDialog(owner);

            strContactID = xForm.SelectedID;
            strContactName = xForm.SelectedName;
        }

        public String SelectedID = "";
        public String SelectedName = "";

        public frmChooseContact()
        {
            InitializeComponent();
        }

        public void LoadContacts(String strCompanyID)
        {
            xList.LoadCompanyID(strCompanyID);
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            ClickOK();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            SelectedID = "";
            SelectedName = "";
            this.Close();
        }

        private void frmChooseContact_Load(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
            xList.SetListFocus();
        }

        private void frmChooseContact_Activated(object sender, EventArgs e)
        {
            xList.FocusOnBox();
            xList.DropDown();
        }

        private void xList_ContactClicked(object sender, CompanyEventArgs args)
        {
            if (Tools.Strings.StrExt(args.strID))
            {
                args.Handled = true;
                ClickOK();
            }
        }

        private void ClickOK()
        {
            SelectedID = xList.GetSelectedID();
            SelectedName = xList.GetSelectedName();
            if (Tools.Strings.StrExt(SelectedID))
                this.Hide();
            else
                RzWin.Context.Error("Please select a name before continuing.");
        }
    }
}