using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using CoreWin;

namespace Rz5
{
    public partial class frmSendQBCompany : Form    //, CoreWin.IStatusView
    {
        public company CurrentCompany;
        public Enums.CompanySelectionType CompanyType;
        public String SelectedName = "";
        public bool CompanyExists = false;
        public companyaddress billing;
        public companyaddress shipping;
        public String Address1 = "";
        public String Address2 = "";

        //no need for the session manager, since it is static

        public frmSendQBCompany()
        {
            InitializeComponent();
        }

        //public void CompleteLoad(company c, Enums.CompanySelectionType t)
        //{         

        //    CurrentCompany = c;
        //    //I don't want to load companytype based on any signals already in Rz
        //    //I want the user to set the companytype.
        //    CompanyType = t;
        //    LoadBillingData();
        //    LoadShippingData(t);
        //    LoadUI();           
        //    CheckExists();
        //}
        public void CompleteLoad(company c, Enums.CompanySelectionType t)
        {

            CurrentCompany = c;
            SetCompanyTypeRadio(t);
            GetCompanyType();
            //I don't want to load companytype based on any signals already in Rz
            //I want the user to set the companytype.            
            LoadBillingData();
            LoadShippingData();
            LoadUI();
            CheckExists();
            //if (CompanyExists)
            //    SetCompanyTypeRadio();
        }

        //private void SetCompanyTypeRadio()
        //{
        //    switch (CurrentCompany.qb_company_type.ToLower())
        //    {

        //        case "customer":
        //            {
        //                rbCustomer.Checked = true;
        //                rbVendor.Checked = false;
        //                break;
        //            }
        //        case "vendor":
        //            {
        //                rbCustomer.Checked = false;
        //                rbVendor.Checked = true;
        //                break;
        //            }

        //    }
        //}

        private void SetCompanyTypeRadio(Enums.CompanySelectionType t)
        {
            switch (t)
            {

                case Enums.CompanySelectionType.Customer:
                    {
                        rbCustomer.Checked = true;
                        rbVendor.Checked = false;
                        break;
                    }
                case Enums.CompanySelectionType.Vendor:
                    {
                        rbCustomer.Checked = false;
                        rbVendor.Checked = true;
                        break;
                    }

            }
        }

        private void LoadUI()
        {
            cmdSend.Enabled = false;
            cmdUpdateCompany.Enabled = false;
            lblExplain.Text = "The company " + CurrentCompany.companyname + " needs to be sent to QuickBooks.";
            txtCompanyName.Text = CurrentCompany.companyname;

            if (CompanyType != 0)//No Type
                if (CompanyType == Enums.CompanySelectionType.Customer)
                {
                    lblType.Text = "As A Customer";
                    lblType.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblType.Text = "As A Vendor";
                    lblType.ForeColor = System.Drawing.Color.Blue;
                }
        }

        private void LoadShippingData()
        {
            //if (CompanyType == Enums.CompanySelectionType.Customer)
            //{
            shippingdata.Enabled = true;
            shipping = CurrentCompany.GetPrimaryShippingAddress(RzWin.Context);
            if (shipping == null)
            {
                shipping = CurrentCompany.AddAddress(RzWin.Context);
                shipping.description = "QB Entered Shipping";
            }

            if (!Tools.Strings.StrExt(shipping.line1))
                shipping.line1 = "Shipping Address Line 1 (required)";

            if (!Tools.Strings.StrExt(billing.adrstate))
                shipping.adrstate = "Shipping State (required)";

            shippingdata.CompleteLoad(CurrentCompany, shipping);
            //}
            //else
            //{
            //    shippingdata.Enabled = false;
            //}
        }

        private void LoadBillingData()
        {
            billing = CurrentCompany.GetPrimaryBillingAddress(RzWin.Context);
            if (billing == null)
            {
                billing = CurrentCompany.AddAddress(RzWin.Context);
                billing.description = "QB Entered Billing";
            }

            if (!Tools.Strings.StrExt(billing.line1))
                billing.line1 = "Billing Address Line 1 (required)";

            if (!Tools.Strings.StrExt(billing.adrstate))
                billing.adrstate = "Billing State (required)";

            billingdata.CompleteLoad(CurrentCompany, billing);
        }

        public void LoadAddresses(String strAddress1, String strAddress2)
        {
            Address1 = strAddress1;
            Address2 = strAddress2;
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            SelectedName = txtCompanyName.Text;
            this.Hide();
        }

        public void SetStatusByIndex(Object sender, StatusArgs args)
        {
            SetStatus(args.status);
        }

        public void SetStatus(String s)
        {
            try
            {
                txtStatus.Text = s + "\r\n" + Tools.Strings.Left(txtStatus.Text, 2000);
                txtStatus.Refresh();
            }
            catch (Exception)
            { }
        }

        public void SetProgressByIndex(Object sender, ProgressArgs args)
        {
        }

        public void SetActivityByIndex(Object sender, ActivityArgs args)
        {
        }

        public void AddLine()
        {
        }

        public void RemoveLine()
        {
        }

        private void cmdCheckIt_Click(object sender, EventArgs e)
        {
            CheckExists();
        }

        private void CheckExists()
        {
            lblExists.ForeColor = System.Drawing.Color.Indigo;
            lblExists.Text = "Checking...";
            lblExists.Refresh();
            bg.RunWorkerAsync();

        }

        private void cmdSend_Click(object sender, EventArgs e)
        {
            bool b = false;
            //RzWin.Context.TheLeader.StartPopStatus("QB Interface...");
            GetCompanyType();

            if (!CompanyExists)
            {


                switch (CompanyType)
                {

                    case Enums.CompanySelectionType.Customer:
                        b = RzWin.Context.TheSysRz.TheQuickBooksLogic.SendCustomerDirectly(RzWin.Context, CurrentCompany, billingdata.CurrentAddress, shippingdata.CurrentAddress, txtCompanyName.Text);
                        break;
                    case Enums.CompanySelectionType.Vendor:
                        b = RzWin.Context.TheSysRz.TheQuickBooksLogic.SendVendorDirectly(RzWin.Context, CurrentCompany, billingdata.CurrentAddress, shippingdata.CurrentAddress, txtCompanyName.Text);
                        break;
                    default:
                        {
                            RzWin.Leader.Tell("You mush designate the company type.  (Customer or Vendor)");
                            RzWin.Context.TheLeader.StopPopStatus(false);
                            return;
                        }

                }
                if (b)
                {
                    CurrentCompany.qb_name = txtCompanyName.Text.Replace(" (V)", "").Trim();
                    CurrentCompany.Update(RzWin.Context);
                }
            }
            else
            {
                RzWin.Context.TheSysRz.TheQuickBooksLogic.SearchQBCustomerByName(RzWin.Context, CurrentCompany); 
            }
            CheckExists();
            //RzWin.Context.TheLeader.StopPopStatus();
        }


        private void cmdUpdateCompany_Click(object sender, EventArgs e)
        {
            bool b = false;
            //CheckExists();
            //RzWin.Context.TheLeader.StartPopStatus("QB Interface...");
            if (CompanyExists)
            {
                GetCompanyType();
                switch (CompanyType)
                {

                    case Enums.CompanySelectionType.Customer:
                        b = RzWin.Context.TheSysRz.TheQuickBooksLogic.UpdateCustomerInfo(RzWin.Context, CurrentCompany, billingdata.CurrentAddress, shippingdata.CurrentAddress, txtCompanyName.Text);
                        break;
                    case Enums.CompanySelectionType.Vendor:
                        //b = RzWin.Context.TheSysRz.TheQuickBooksLogic.SendVendorDirectly(RzWin.Context, CurrentCompany, billingdata.CurrentAddress, shippingdata.CurrentAddress, txtCompanyName.Text);
                        b = RzWin.Context.TheSysRz.TheQuickBooksLogic.UpdateVendorInfo(RzWin.Context, CurrentCompany, billingdata.CurrentAddress, shippingdata.CurrentAddress, txtCompanyName.Text, false);

                        break;
                    default:
                        {
                            RzWin.Leader.Tell("You mush designate the company type.  (Customer or Vendor)");
                            RzWin.Context.TheLeader.StopPopStatus(false);
                            return;
                        }

                }
                if (b)
                {
                    //CurrentCompany.qb_name = txtCompanyName.Text.Replace(" (V)", "").Trim();
                    //CurrentCompany.Update(RzWin.Context);
                    UpdateCompanyAddressData();
                    RzWin.Leader.Tell("Successfully updated the company information");
                }
                //CheckExists();
                //RzWin.Context.TheLeader.StopPopStatus();
            }
        }


        private void GetCompanyType()
        {
            //if the current company has a qb_company type, then it's an existing relationship, use that,
            //else it's an add, so get it fromt he user controls.

            if (!string.IsNullOrEmpty(CurrentCompany.qb_company_type))
            {
                switch (CurrentCompany.qb_company_type)
                {
                    case "customer":
                        {
                            CompanyType = Enums.CompanySelectionType.Customer;
                            break;
                        }
                    case "vendor":
                        {
                            CompanyType = Enums.CompanySelectionType.Vendor;
                            break;
                        }
                }
            }
            if (CompanyType == 0)//Still no company type detected, derive it from user controls
            {
                if (rbCustomer.Checked)
                    CompanyType = Enums.CompanySelectionType.Customer;
                else if (rbVendor.Checked)
                    CompanyType = Enums.CompanySelectionType.Vendor;
                else
                    CompanyType = 0;//No Company Selected
            }
        }


        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //CompanyExists = RzWin.Context.TheSysRz.TheQuickBooksLogic.CompanyExists(RzWin.Context, txtCompanyName.Text, CompanyType);
            //CompanyExists = RzWin.Context.TheSysRz.TheQuickBooksLogic.CompanyExists(RzWin.Context, CurrentCompany, CompanyType);
            GetCompanyType();
            CompanyExists = RzWin.Context.TheSysRz.TheQuickBooksLogic.CompanyExists(RzWin.Context, CurrentCompany, CompanyType);
            RzWin.Context.TheSysRz.TheQuickBooksLogic.Disconnect();
            //if (!CompanyExists)//We couldn't find this company in Quickbooks, would you like to Search 
            //if (RzWin.Context.Leader.AskYesNo("We couldn't find this company in Quickbooks, would you like to Search Quickbooks?"))
            //CompanyExists = RzWin.Context.TheSysRz.TheQuickBooksLogic.SearchQbCompanyByName(RzWin.Context, txtCompanyName.Text) != null;

            
        }

        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //chkExists.Checked = CompanyExists;
            UpdateCompanyAddressData();
            if (CompanyExists)
            {
                lblExists.ForeColor = System.Drawing.Color.Green;
                lblExists.Text = "Exists In QuickBooks";
                cmdSend.Enabled = false;
                cmdUpdateCompany.Enabled = true;
                System.Threading.Thread.Sleep(500);
                //cmdClose_Click(null, null);
            }
            else
            {
                lblExists.ForeColor = System.Drawing.Color.Red;
                lblExists.Text = "<Not In QuickBooks>";
                cmdSend.Enabled = true;
                cmdUpdateCompany.Enabled = false;
            }
            Cursor.Current = Cursors.WaitCursor;
        }

        private void UpdateCompanyAddressData()
        {
            billingdata.UpdateAddressData();
            shippingdata.UpdateAddressData();
        }

        private void lblAddresses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.FileSystem.PopText("\r\n" + Address1 + "\r\n\r\n" + Address2);
        }

        private void frmSendQBCompany_FormClosing(object sender, FormClosingEventArgs e)
        {
            RzWin.Context.TheSysRz.TheQuickBooksLogic.Disconnect();
        }
    }
}