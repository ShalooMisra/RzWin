using NewMethod;
using Rz5;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RzInterfaceWin.Dialogs
{
    public partial class frmTBDResolution : Form
    {
        string currentPartNumber { get; set; }
        string currentManufacturer { get; set; }
        orddet_line currentLineItem { get; set; }
        company newVendor;
        companycontact newVendorContact;
        public string newPartNumber { get; set; }
        public string newManfacturer { get; set; }
        public int newQuantity { get; set; }
        public string newDateCode { get; set; }
        public double newUnitPrice { get; set; }
        public double newUnitCost { get; set; }
        public string newLeadTime { get; set; }
        public string tbdNotes { get; set; }

        public frmTBDResolution()
        {
            InitializeComponent();
        }




        public void CompleteLoad(ContextRz context, orddet_line l)
        {
            optVendor.Checked = true;
            if (l == null)
                throw new Exception("Line item not detected.");

            //Load main Variables
            currentLineItem = l;
            currentPartNumber = l.fullpartnumber.Trim().ToUpper();
            currentManufacturer = l.manufacturer.Trim().ToUpper();

            //Load form Controls
            LoadControls();
        }

        private void LoadControls()
        {
            RzWin.Sys.ThePartLogic.LoadManufacturerDropDown(RzWin.Context, ctl_manufacturer);
            ctl_manufacturer.SetValue(currentLineItem.manufacturer);

            ctl_partNumber.SetValue(currentPartNumber);
            ctl_manufacturer.SetValue(currentManufacturer);
            gbTBDResoluton.Text = currentLineItem.customer_name + " | " + currentLineItem.ordernumber_sales + " | " + currentLineItem.fullpartnumber.Trim().ToUpper();
            ctl_lead_time.LoadList("delivery");


            //MFG Lookup
            ////Save MFG if OTHER, and ask user to confirm if adding to list.
            //string lookupMFg = "";
            //string selectedTargetMfg = ctl_target_manufacturer.GetValue_String().Trim().ToUpper();
            //if (selectedTargetMfg == "OTHER" || string.IsNullOrEmpty(selectedTargetMfg))
            //{
            //    lookupMFg = RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context, CurrentReq.fullpartnumber.Trim().ToUpper());
            //    if (!string.IsNullOrEmpty(lookupMFg))
            //        selectedTargetMfg = lookupMFg;
            //}
            //CurrentReq.target_manufacturer = selectedTargetMfg;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                if (!ProcessFormValues())
                {
                    //RzWin.Leader.Error("Please provide all necessary line information.");
                    return;
                }

                //Split Line if QTY less than existing QTY
                orddet_line dupeLine = null;
                if (newQuantity < currentLineItem.quantity)
                {
                    if (RzWin.Leader.AskYesNo("Your QTY Of " + newQuantity + " is less than the inital quantity of " + currentLineItem.quantity + ".  If you proceed this line will be split accordingly.  Proceed?"))
                    {
                        dupeLine = currentLineItem.Duplicate(RzWin.Context, Rz5.Enums.OrderType.Sales);
                        dupeLine.stocktype = currentLineItem.stocktype;
                        dupeLine.StockType = currentLineItem.StockType;

                        currentLineItem.quantity -= newQuantity;
                        currentLineItem.Update(RzWin.Context);
                    }
                }

                if (dupeLine != null)
                    DoResourceTasks(dupeLine);
                else
                    DoResourceTasks(currentLineItem);


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }


        }

        private void DoResourceTasks(orddet_line line)
        {
            UpdateLineValues(line);
            SendTBDResolvedAlerts(line);

        }

        private void SendTBDResolvedAlerts(orddet_line line)
        {
            if (line.stocktype == "stock" || line.stocktype == "consign")
                SendStockCheckAlert(line);
        }

        private void SendStockCheckAlert(orddet_line line)
        {
            string subject = "Rz Stock Check Request: " + line.fullpartnumber + " | QTY: " + line.quantity;
            string body = "Please confirm stock for " + line.seller_name + " Sale#  " + line.ordernumber_sales + " LineNumber: " + line.linecode_sales + " QTY: " + line.quantity + " ";
            List<string> cc = new List<string>();
            n_user u = n_user.GetById(RzWin.Context, line.seller_uid);
            if (u != null)
                cc.Add(u.email_address);

            if (cc.Count > 0)
                SensibleDAL.SystemLogic.Email.SendMail(SensibleDAL.SystemLogic.Email.EmailGroupAddress.RzAlert, "sm_shipping@sensiblemicro.com", subject, body, cc.ToArray());
            else
                SensibleDAL.SystemLogic.Email.SendMail(SensibleDAL.SystemLogic.Email.EmailGroupAddress.RzAlert, "sm_shipping@sensiblemicro.com", subject, body);
        }

        private void UpdateLineValues(orddet_line l)
        {
            //Not doing refSet, don't think it's much faster.
            //l.vendor_name = newVendor.companyname;
            //l.vendor_uid = newVendor.unique_id;
            l.VendorVar.RefSet(RzWin.Context, newVendor);
            l.vendor_contact_name = newVendorContact.Name;
            l.vendor_contact_uid = newVendor.unique_id;
            l.fullpartnumber = newPartNumber;
            l.manufacturer = newManfacturer;
            l.quantity = newQuantity;
            l.datecode = newDateCode;
            l.unit_cost = newUnitCost;
            l.unit_price = newUnitPrice;
            l.internalcomment += Environment.NewLine + "TBD Resolution Notes:" + Environment.NewLine + tbdNotes;

            //Once TBD Info set, Set the Re-Sourced line_validation_status.
            l.line_validation_status = SM_Enums.LineValidationStatus.ReSourced.ToString();
            //Set TBD Cleared Date.
            l.tbd_cleared_date = DateTime.Now;

            //Update the amounts on the line item.
            l.CalculateAmounts(RzWin.Context);
            l.Update(RzWin.Context);
        }

        private bool ConfirmTBDLogics()
        {
            List<string> missingLogics = SalesLogic.GetRequiredBuyLineLogics(RzWin.Context, currentLineItem);
            if (missingLogics.Count > 0)
            {
                string message = "There are issues with your selected Vendor which cannot allow this TBD to be resolved with this Vendor:" + Environment.NewLine;
                foreach (string s in missingLogics)
                {
                    message += s + Environment.NewLine;
                }

                RzWin.Leader.Error(message);
                return false;
            }
            return true;
        }

        protected bool ProcessFormValues()
        {
            //Gather, sanitize, and validate form values


            //Vendor
            newVendor = company.GetById(RzWin.Context, ctlChooseVendor.CompanyID);
            if (newVendor == null)
            {
                RzWin.Leader.Error("Please choose a new Vendor");
                return false;
            }

            //Vendor Contact        
            newVendorContact = companycontact.GetById(RzWin.Context, ctlChooseVendor.ContactID);
            if (newVendorContact == null)
            {
                RzWin.Leader.Error("Please choose a new Vendor Contact");
                return false;
            }

            ///Confirm all logics before commit / update
            if (!ConfirmTBDLogics())
                return false;


            //Part Number
            newPartNumber = Tools.Strings.SanitizeInput(ctl_partNumber.GetValue_String());
            if (string.IsNullOrEmpty(newPartNumber))
            {
                RzWin.Leader.Error("Please provide the new Part Number");
                return false;
            }

            //Manufacturer
            newManfacturer = Tools.Strings.SanitizeInput(ctl_manufacturer.GetValue_String());
            if (string.IsNullOrEmpty(newManfacturer))
            {
                RzWin.Leader.Error("Please provide the new Manufacturer");
                return false;

            }

            //Lead Time
            newLeadTime = Tools.Strings.SanitizeInput(ctl_lead_time.GetValue_String());
            if (string.IsNullOrEmpty(newLeadTime))
            {
                RzWin.Leader.Error("Please provide the new Lead Time");
                return false;

            }

            //Quantity
            newQuantity = ctl_Quantity.GetValue_Integer();
            if (newQuantity <= 0)
            {
                RzWin.Leader.Error("Please provide the new Quantity");
                return false;

            }


            //Date Code
            newDateCode = Tools.Strings.SanitizeInput(ctl_DateCode.GetValue_String());
            if (string.IsNullOrEmpty(newDateCode))
            {
                RzWin.Leader.Error("Please provide the new Date Code");
                return false;

            }

            //Unit Cost
            newUnitCost = ctl_unit_cost.GetValue_Double();
            if (newUnitCost <= 0)
            {
                RzWin.Leader.Error("Please provide the new Lead Time");
                return false;
            }

            ////Unit Price
            newUnitPrice = currentLineItem.unit_price;
            //newUnitPrice = ctl_unit_price.GetValue_Double();
            //if (newUnitPrice <= 0)
            //{
            //    RzWin.Leader.Error("Please provide the new Lead Time");
            //    return false;

            //}


            //Lead Time
            newLeadTime = Tools.Strings.SanitizeInput(ctl_lead_time.GetValue_String());
            if (string.IsNullOrEmpty(newLeadTime))
            {
                RzWin.Leader.Error("Please provide the new Lead Time");
                return false;

            }


            //Memo / Notes
            tbdNotes = Tools.Strings.SanitizeInput(ctl_tbd_notes.GetValue_String());
            if (string.IsNullOrEmpty(tbdNotes))
            {
                RzWin.Leader.Error("Please provide notes");
                return false;

            }




            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctlChooseVendor_ChangeCompany(Tools.GenericEvent e)
        {
            //if (!string.IsNullOrEmpty(ctlChooseVendor.CompanyID))
            //    newVendor = company.GetById(RzWin.Context, ctlChooseVendor.CompanyID);  

        }

        private void ctlChooseVendor_ChangeContact(Tools.GenericEvent e)
        {
            //if (!string.IsNullOrEmpty(ctlChooseVendor.ContactID))
            //    newVendorContact = companycontact.GetById(RzWin.Context, ctlChooseVendor.ContactID);
        }

        private void opt_CheckedChanged(object sender, EventArgs e)
        {

            if (optVendor.Checked)
            {
                optStock.Checked = false;
                optConsign.Checked = false;
                optVendor.Checked = true;
                ctlChooseVendor.Visible = true;
                lblAllocate.Visible = false;
            }
            else if (optStock.Checked)
            {
                optStock.Checked = true;
                optConsign.Checked = false;
                optVendor.Checked = false;
                ctlChooseVendor.Visible = false;
                lblAllocate.Visible = true;
                lblAllocate.Left = 8;
            }
            else if (optConsign.Checked)
            {
                optStock.Checked = false;
                optConsign.Checked = true;
                optVendor.Checked = false;
                ctlChooseVendor.Visible = false;
                lblAllocate.Visible = true;
                lblAllocate.Left = 8;
            }
            
        }

        protected virtual void AllocationShow()
        {
            //lblAllocated.Text = ((orddet_line)CurrentDetail).inventory_link_caption;
            //lblViewAllocate.Visible = Tools.Strings.StrExt(lblAllocated.Text);
        }

        private void lblAllocate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            bool newAllocation = ((orddet_line)currentLineItem).LinkAndAllocate(RzWin.Context);
            if(newAllocation)
            {
                ctl_partNumber.SetValue(currentLineItem.fullpartnumber);
                ctl_manufacturer.SetValue(currentLineItem.manufacturer);                
            }
            
        }
    }
}
