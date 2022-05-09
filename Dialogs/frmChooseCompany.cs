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
    public partial class frmChooseCompany : Form
    {
        //accessor
        public static void ChooseCompanyID(ref String strCompanyID, ref String strCompanyName, Enums.CompanySelectionType xType, String strCaption, System.Windows.Forms.IWin32Window owner)
        {
            frmChooseCompany xForm = new frmChooseCompany();
            xForm.Text = strCaption;
            xForm.SetType(xType);
            xForm.ShowDialog(owner);

            strCompanyID = xForm.SelectedID;
            strCompanyName = xForm.SelectedName;
        }

        public String SelectedID = "";
        public String SelectedName = "";

        public frmChooseCompany()
        {
            InitializeComponent();
        }

        public void SetType(Enums.CompanySelectionType xType)
        {
            xList.SetType(xType);
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

        private void frmChooseCompany_Load(object sender, EventArgs e)
        {
            ToolsWin.Screens.SetOnMouse(this);
            xList.SetListFocus();
        }

        private void frmChooseCompany_Activated(object sender, EventArgs e)
        {
            xList.DropDown();
            xList.FocusOnBox();
        }

        private void xList_CompanyClicked(object sender, CompanyEventArgs args)
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