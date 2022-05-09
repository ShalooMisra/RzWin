using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ViewDetailSales : ViewDetail
    {
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.Sales;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_sales;
            }
        }



        //Private Variables
        private bool LotsLoaded = false;

        ////KT
        //string ActiveTab = "";
        //Constructors
        public ViewDetailSales()
        {
            InitializeComponent();
        }

        public ViewDetailSales(string tabName)
        {
            InitializeComponent();
            SetActiveTab(tabName);

        }
        //Public Override Functions
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
            ordhed_sales s = (ordhed_sales)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Sales);
            if (s == null)
                return;
            try
            {
                bool ship_mixed = false;
                bool acnt_mixed = false;
                string first_ship = "";
                string first_acnt = "";
                List<orddet> l = s.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    //ShipVia
                    if (Tools.Strings.StrExt(ln.shipvia_invoice))
                    {
                        if (!Tools.Strings.StrExt(first_ship))
                            first_ship = ln.shipvia_invoice;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_ship, ln.shipvia_invoice))
                                ship_mixed = true;
                        }
                    }
                    //Account
                    if (Tools.Strings.StrExt(ln.shippingaccount_invoice))
                    {
                        if (!Tools.Strings.StrExt(first_acnt))
                            first_acnt = ln.shippingaccount_invoice;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_acnt, ln.shippingaccount_invoice))
                                acnt_mixed = true;
                        }
                    }
                }
                if (ship_mixed)
                    s.shipvia = "Mixed";
                else
                    s.shipvia = first_ship;
                if (acnt_mixed)
                    s.shippingaccount = "Mixed";
                else
                    s.shippingaccount = first_acnt;
                s.Update(RzWin.Context);
            }
            catch { }
        }
        public override void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem, new Rz5.ActSetupOrder(Enums.OrderType.Sales));
        }
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            CompleteLoad_ShipAccounts();
            ctl_country_of_origin.Visible = true;
            if (!LotsLoaded)
            {
                LotsLoad();
                LotsLoaded = true;
            }
            StockTypeLoad();
            VendorLoad();
            //KT - Here I would like to pass the sale object to the deduction screen so I can remove varrefs and facilitate refreshing of data when deduction is changed.
            //deductions.Init(CurrentDetail, Enums.OrderType.Sales);
            ordhed_sales s = (ordhed_sales)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Sales);
            deductions.Init(CurrentDetail, Enums.OrderType.Sales, s);
            LoadDateControls();


        }

        private void LoadDateControls()
        {
            bool editDates = RzWin.Context.TheSysRz.ThePermitLogic.CheckPermit(RzWin.Context, Permissions.ThePermits.CanChangeOrderDate, RzWin.Context.xUser);
            ctl_orderdate_sales.Enabled = editDates;
            ctl_projected_dock_date.Enabled = editDates;
        }

        protected override void CompleteLoad_ShipAccounts()
        {
            ctl_shippingaccount_invoice.ClearList();
            if (CurrentDetail.SalesVar.RefGet(RzWin.Context) == null)
                return;
            bool added = false;
            if (CurrentDetail.SalesVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context) != null)
            {
                ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + CurrentDetail.SalesVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context).unique_id + "' ORDER BY ACCOUNTNUMBER");
                if (a != null && a.Count > 0)
                    added = true;
                ctl_shippingaccount_invoice.AddFromArray(a);
            }
            if (added)
                ctl_shippingaccount_invoice.AddIfNotBlank("________________________");
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalUPS);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalFedex);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalDHL);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalOther);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
            ctl_shippingaccount_invoice.AddIfNotBlank("Pre-Pay & Add");
            ctl_shippingaccount_invoice.AddIfNotBlank("Pre-Pay & Don't Add");
        }
        ////KT Original Rz HandleConsignSave

        //KT Refactored from RzSensible
        protected virtual void HandleConsignSave()
        {
            CurrentDetail.StockType = Rz5.Enums.StockType.Consign;
            //CurrentDetail.lotnumber = Rz5.consignment_code.ParseCode(lblConsignCode.Text);
            //CurrentDetail.consignment_code = CurrentDetail.lotnumber;
            CurrentDetail.consignment_code = Rz5.consignment_code.ParseCode(ctl_ConsignmentCode.GetValue_String());
            //Rz5.consignment_code code = (consignment_code)RzWin.Context.QtO("consignment_code", "select * from consignment_code where code_name = '" + CurrentDetail.consignment_code + "' and vendor_uid = '" + CurrentDetail.vendor_uid + "'");  //Rz4.consignment_code.GetByName(Rz4Win.ContextDefaultRz.xSys, CurrentDetail.lotnumber);
            Rz5.consignment_code code = consignment_code.GetByName(RzWin.Context, CurrentDetail.consignment_code);
            if (code != null)
            {
                CurrentDetail.vendor_name = code.vendor_name;
                CurrentDetail.vendor_uid = code.vendor_uid;
                CurrentDetail.consignment_percent = code.payout_percent;
                CurrentDetail.unit_cost = code.CostCalc(CurrentDetail.unit_price);
                ctl_unit_cost.SetValue(CurrentDetail.unit_cost);
            }

        }

        public override void CompleteSave()
        {
            if (optStock.Checked)
            {
                CurrentDetail.StockType = Rz5.Enums.StockType.Stock;
                //CurrentDetail.lotnumber = Rz5.consignment_code.ParseCode(cboLotStock.Text);
                if (!Tools.Strings.StrExt(CurrentDetail.lotnumber))
                    CurrentDetail.lotnumber = "STOCK";
                //Why are we setting vendor to stock and losing the vendor_uid???
                //CurrentDetail.vendor_uid = "";
                //CurrentDetail.vendor_name = "STOCK";
            }
            else if (optConsign.Checked)
            {
                HandleConsignSave();
            }
            else if (optVendor.Checked)
            {
                CurrentDetail.StockType = Rz5.Enums.StockType.Buy;
                CurrentDetail.lotnumber = "BUY";
                CurrentDetail.needs_purchasing = true;
            }
            else if (CurrentDetail.StockType == Rz5.Enums.StockType.Service)
            {
                //Do nothing, just don't want it to fall into the below "else" so stocktype doesn't get wiped.
            }
            else
            {
                CurrentDetail.stocktype = "";
                CurrentDetail.lotnumber = "";
            }
            //CurrentDetail.consignment_code = CurrentDetail.lotnumber;
            CurrentDetail.consignment_code = CurrentDetail.consignment_code;


            deductions.Save();
            base.CompleteSave();
            RzWin.Context.TheSysRz.TheLineLogic.SaveInitialCustomerDock(CurrentDetail);
            //CurrentDetail.orderdate_sales = ctl_orderdate_sales.GetValue_Date();
        }



        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                //ctl_tracking_purchase.Width = pVendor.Width - (ctl_tracking_purchase.Left * 2);
                //ctl_tracking_purchase.Height = pVendor.Height - ctl_tracking_purchase.Top - 2;
                //ctl_internalcomment.Top = lblVendorCompany.Bottom;
                //KT manual Positioning
                ctl_internalcomment.Top = 450;
                ctl_internalcomment.Width = 500;
            }
            catch { }
        }
        //Private Functions
        protected virtual void LotsLoad()
        {
            //Refactored from Rz5 - This was the only line in the Sensible Override.  
            //It skipped the original stuff.  For now I have commented the original out, but may be useful someday. 
            //Would need to investigate what it does.
            ctl_LotStock.ClearList();
            //.Items.Clear();
            //cboLotStock.Items.Clear();
            //foreach (String lot in Rz5.consignment_code.CodesList(RzWin.Context))
            //{
            //    if (lot.Contains("[STOCK]"))
            //        cboLotStock.Items.Add(lot);
            //    else
            //        cboLotConsign.Items.Add(lot);
            //}
        }
        protected virtual void SetConsignmentInfo()
        {
            //Refactored from Rz5 - the below commented line was the original Rz code.  
            if (Tools.Strings.StrExt(CurrentDetail.vendor_uid))
                ctl_ConsignmentCode.SetValue(Rz5.consignment_code.RenderCode(RzWin.Context, CurrentDetail.consignment_code, CurrentDetail.vendor_uid));
            else
                ctl_ConsignmentCode.SetValue(Rz5.consignment_code.RenderCode(RzWin.Context, CurrentDetail.consignment_code));



            //KT Original Rz Code
            //cboLotConsign.Text = Rz5.consignment_code.RenderCode(RzWin.Context, CurrentDetail.lotnumber);
        }
        protected virtual string GetConsignmentInfo()
        {
            //return consignment_code.ParseCode(CurrentDetail.lotnumber);
            return consignment_code.ParseCode(CurrentDetail.consignment_code);
        }
        protected virtual void AllocationShow()
        {
            lblAllocated.Text = ((orddet_line)CurrentDetail).inventory_link_caption;
            lblViewAllocate.Visible = Tools.Strings.StrExt(lblAllocated.Text);
        }
        protected void StockTypeLoad()
        {
            pAllocation.Visible = false;
            if (CurrentDetail.StockType == Enums.StockType.Stock && CurrentDetail.needs_purchasing)
                CurrentDetail.StockType = Enums.StockType.Buy;
            switch (CurrentDetail.StockType)
            {
                case Rz5.Enums.StockType.Consign:
                    optConsign.Checked = true;
                    pVendor.Visible = false;
                    lblChooseVendor.Visible = false;
                    ctl_unit_cost.Enabled = RzWin.Context.xUser.SuperUser;
                    SetConsignmentInfo();
                    //Panels

                    ctl_ConsignmentCode.Visible = true;
                    ctl_LotStock.Visible = false;
                    pAllocation.Visible = true;

                    ctl_LotStock.Caption = Rz5.consignment_code.RenderCode(RzWin.Context, CurrentDetail.consignment_code);


                    //cboLotStock.Text = "";
                    //cboLotConsign.Visible = true;
                    //lblConsignCode.Visible = true;

                    break;
                case Rz5.Enums.StockType.Buy:

                    ctl_ConsignmentCode.SetValue("");
                    optVendor.Checked = true;
                    //lblChooseVendor.Visible = true;
                    lblChooseVendor.Visible = RzWin.Context.TheSysRz.ThePermitLogic.CheckPermit(RzWin.Context, Permissions.ThePermits.CanChangeLineVendor, RzWin.Context.xUser);


                    ctl_unit_cost.Enabled = true;

                    //Panels
                    ctl_LotStock.Visible = false;
                    ctl_ConsignmentCode.Visible = false;
                    pVendor.Visible = true;
                   
                    //cboLotStock.Text = "";

                    break;
                case Rz5.Enums.StockType.Stock:
                    optStock.Checked = true;
                    //cboLotStock.Text = Rz5.consignment_code.RenderCode(RzWin.Context, CurrentDetail.lotnumber);                   
                    lblChooseVendor.Visible = false;
                    ctl_unit_cost.Enabled = true;
                    pAllocation.Visible = true;

                    //Panels
                    ctl_ConsignmentCode.Visible = false;
                    ctl_LotStock.Visible = true;
                    pVendor.Visible = false;

                    //cboLotStock.Text = Rz5.consignment_code.RenderCode(RzWin.Context, CurrentDetail.consignment_code);
                    //cboLotConsign.Text = "";


                    break;
                default:
                    optStock.Checked = false;
                    optConsign.Checked = false;
                    optVendor.Checked = false;
                    ctl_ConsignmentCode.Visible = false;
                    ctl_LotStock.Visible = false;
                    pVendor.Visible = false;
                    lblChooseVendor.Visible = false;
                    break;
            }
        }
        private void VendorLoad()
        {
           
            lblVendorCompany.Text = CurrentDetail.vendor_name;
            lblVendorContact.Text = CurrentDetail.vendor_contact_name;
           
        }
        private void CostSet()
        {
            String code_name = Rz5.consignment_code.ParseCode(ctl_ConsignmentCode.GetValue_String());
            if (Tools.Strings.StrCmp(code_name, CurrentDetail.lotnumber))
                return;
            Double price = ctl_unit_price.GetValue_Double();
            if (price <= 0)
                return;
            Rz5.consignment_code code = Rz5.consignment_code.GetByName(RzWin.Context, code_name);
            if (code == null)
                return;
            try
            {
                ctl_unit_cost.SetValue(code.CostCalc(price));
                CurrentDetail.lotnumber = code_name;
            }
            catch { }
        }
        //Control Events

        //KT Refactored from Rz5
        private void lblConsignCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void lblConsignCode_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
        //KT End Refactor Block


        private void optStock_Click(object sender, EventArgs e)
        {
            CurrentDetail.StockType = Rz5.Enums.StockType.Stock;
            CurrentDetail.lotnumber = "";
            CurrentDetail.needs_purchasing = false;
            StockTypeLoad();
        }
        private void optConsign_Click(object sender, EventArgs e)
        {
            CurrentDetail.StockType = Rz5.Enums.StockType.Consign;
            CurrentDetail.lotnumber = "";
            CurrentDetail.needs_purchasing = false;
            StockTypeLoad();
        }
        private void optVendor_Click(object sender, EventArgs e)
        {
            CurrentDetail.StockType = Rz5.Enums.StockType.Buy;
            CurrentDetail.lotnumber = "";
            CurrentDetail.needs_purchasing = true;

            StockTypeLoad();
        }
        private void lblAllocate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CompleteSave();
            ((orddet_line)CurrentDetail).LinkAndAllocate(RzWin.Context);
            StockTypeLoad();
            AllocationShow();

            CompleteLoad();
        }
        private void lblViewAllocate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(((orddet_line)CurrentDetail).LinkedInventory(RzWin.Context));
        }


        public void SetActiveTab(string tabName)
        {

            switch (tabName)
            {
                case "tabDeductions":
                    ts.SelectedTab = tabDeductions;
                    break;

            }
        }

        private void lblChooseVendor_LinkClicked(object sender, EventArgs e)
        {
            
            String compname = "";
            String compid = "";
            String contname = "";
            String contid = "";
            string existingVendorName = CurrentDetail.vendor_name;
            Rz5.frmChooseCompany_Big.ChooseCompanyID(ref compid, ref compname, ref contid, ref contname, Rz5.Enums.CompanySelectionType.Both, "Vendor selection", this.ParentForm);
            if (!Tools.Strings.StrExt(compid))
                return;
            //Clear existing values on successful selection 
            CurrentDetail.vendor_uid = "";
            CurrentDetail.vendor_name = "";
            CurrentDetail.vendor_contact_uid = "";
            CurrentDetail.vendor_contact_name = "";

            //Udpate the vendor company
            company c = company.GetById(RzWin.Context, compid);
            if (c != null)
            {
                //This is very expensive call! IT updates the parent objects as well.
                //CurrentDetail.VendorVar.RefItemSet(RzWin.Context, c);
                CurrentDetail.VendorVar.RefSet(RzWin.Context, c);
            }
            //else
            //{
            //    CurrentDetail.vendor_uid = compid;
            //    CurrentDetail.vendor_name = compname;
            //}
            ////Update the vendor Contact
            companycontact cc = companycontact.GetById(RzWin.Context, contid);
            if (cc != null)

            {
                CurrentDetail.VendorContactVar.RefSet(RzWin.Context, cc);
                //CurrentDetail.vendor_contact_uid = contid;
                //CurrentDetail.vendor_contact_name = contname;
            }


            //If the new Vendor has not been vetted:
            if (!RzWin.Context.TheSysRz.TheCompanyLogic.CheckVetted(RzWin.Context, c))
                RzWin.Context.TheSysRz.TheCompanyLogic.SendCompanyNeedsVettingEmailAlert(RzWin.Context, company.GetById(RzWin.Context, CurrentDetail.customer_uid), CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Sales), c);

            //IF new vendor is Source TBD and there is existing flag for ReSourced, clear that flag.
            if (CurrentDetail.vendor_name == "Source TBD" && CurrentDetail.line_validation_status == SM_Enums.LineValidationStatus.ReSourced.ToString())
                CurrentDetail.line_validation_status = "";
            else if(existingVendorName == "Source TBD")
                CurrentDetail.line_validation_status = SM_Enums.LineValidationStatus.ReSourced.ToString();

            CurrentDetail.Update(RzWin.Context);


            ordhed_sales s = (ordhed_sales)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Sales);
            s.LoadMissingProperties(RzWin.Context);
            s.Update(RzWin.Context);


            VendorLoad();
        }

        //private void ResetLineValues(orddet_line l)
        //{
        //    //date_code
        //    //date_code_vendor
        //    //rohs
        //    //rohs_vendor
        //    //partnumber
        //    //qty
        //    //mfg
        //    //price
        //    //cost
        //    //lead time

        //    l.fullpartnumber = "";
        //    l.manufacturer = "";
        //    l.unit_cost = 0;
        //    l.unit_price = 0;
        //    l.quantity = 0;
        //    l.rohs_info = "";
        //    l.rohs_info_vendor = "";
        //    l.datecode = "";
        //    l.datecode_purchase = "";
        //    //l.


        //}
    }
}





