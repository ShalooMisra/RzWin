using System;
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
    public partial class ViewDetail : ViewPlusMenu
    {
        //Public Variables
        public orddet_line CurrentDetail
        {
            get
            {
                return (orddet_line)GetCurrentObject();
            }
            set
            {
                SetCurrentObject(value);
            }
        }
        //Private Variables
        private bool IsLoading = false;

        //Protected Virtual Variables
        protected virtual Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.Any;
            }
        }
        protected virtual string OrderNumber
        {
            get
            {
                return "";
            }
        }

        //Constructors
        public ViewDetail()
        {
            InitializeComponent();
            throb1.BackColor = Color.White;
            txtOrderNumber.BackColor = Color.White;
            Rz5.PartPictureViewer.PictureAdded += new Rz5.PictureAddedHandler(PartPictureViewer_PictureAdded);
            Rz5.PartPictureViewer.PictureRemoved += new Rz5.PictureRemovedHandler(PartPictureViewer_PictureRemoved);
        }
        //Public Override Functions
        protected virtual void CompleteLoad_ShipAccounts()
        {

        }
        public override void CompleteLoad()
        {
            //if (CurrentDetail == null)
            //    return false;
            IsLoading = true;
            base.CompleteLoad();
            IsLoading = false;
            CheckAttachmentTab();
            if (xActions.IsDisabled())
                xActions.Enabled = true;
            else
                xActions.EnableDelete = CurrentDetail.CanBeDeletedBy(RzWin.Context);
            //ctl_country_of_origin.Visible = false;

            RzWin.Sys.ThePartLogic.LoadManufacturerDropDown(RzWin.Context, ctl_manufacturer);
            ctl_manufacturer.SetValue(CurrentDetail.manufacturer);

            CompleteLoad_Header();
            CompleteLoad_Status();
            CompleteLoad_ShipAccounts();
            CheckPermissions();
            sc1.CompleteLoad(RzWin.Context, CurrentDetail);
            ac1.CompleteLoad(CurrentDetail);
            ctl_harmonized_tarriff_schedule.SetValue(CurrentDetail.harmonized_tariff_schedule);

        }



        public override void CompleteSave()
        {           
            CheckForPartDetailChange();


            base.CompleteSave();

            //Save MFG if OTHER, and ask user to confirm if adding to list.
            //RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context, CurrentDetail.fullpartnumber.Trim().ToUpper());
            CheckUpdateShipping();           
            CurrentDetail.harmonized_tariff_schedule = ctl_harmonized_tarriff_schedule.GetValue_String().Trim().ToUpper();
            CurrentDetail.Update(RzWin.Context);
        }

        private void CheckForPartDetailChange()
        {
            string currentPart = CurrentDetail.fullpartnumber.Trim().ToUpper();
            string newPart = ctl_fullpartnumber.zz_Text.Trim().ToUpper();

            string currentMfg = CurrentDetail.manufacturer.Trim().ToUpper();
            string newMfg = ctl_manufacturer.GetValue_String().Trim().ToUpper();

            string QbListID = CurrentDetail.qb_line_ListID;
            if (!string.IsNullOrEmpty(QbListID))
                if (currentPart != newPart)
                    SendQuickbooksPartChangeAlert("part", currentPart, newPart);
                else if (currentMfg != newMfg)
                    SendQuickbooksPartChangeAlert("mfg", currentMfg, newMfg);
        }

        private void SendQuickbooksPartChangeAlert(string type, string oldItem, string newItem)
        {
            string noun = "";
            string currentPart = "";// CurrentDetail.fullpartnumber.Trim().ToUpper();
            string newPart = "";// ctl_fullpartnumber.zz_Text.Trim().ToUpper();
            string currentMfg = "";// CurrentDetail.manufacturer.Trim().ToUpper();
            string newMfg = "";//ctl_manufacturer.GetValue_String().Trim().ToUpper();
            string body = "";
            switch (type)
            {
                case "part":
                    {
                        noun = "Part Number";
                        body += "New Part Numbner: " + newItem + "<br />";
                        body += "Old Part Number: " + oldItem + "<br />";
                        break;
                    }
                case "mfg":
                    {
                        noun = "Manufacturer";
                        body += "New MFG: " + newItem + "<br />";
                        body += "Old MFG: " + oldItem + "<br />";                        
                        break;
                    }
            }


            string subject = "Alert: "+noun+" Change detected After Quickbooks Sync:" + currentPart;
            string salesOrder = CurrentDetail.ordernumber_sales ?? "N/A";
            string purchaseOrder = CurrentDetail.ordernumber_purchase ?? "N/A";
            string CustomerName = CurrentDetail.customer_name ?? "N/A";
            string VendorName = CurrentDetail.vendor_name ?? "N/A";
         
            body += "Customer: " + CustomerName + "<br />";
            body += "Sale: " + salesOrder + "<br />";
            body += "Vendor: " + VendorName + "<br />";
            body += "PO: " + purchaseOrder + "<br />";
            //string[] cc = new string[] { "ktill@sensiblemicro.com" };
            SensibleDAL.SystemLogic.Email.SendMail("rz@sensiblemicro.com", "sm_validation@sensiblemicro.com", subject, body,null);

        }



        

        protected virtual void CompleteLoad_Header()
        {
            lblOrderType.Text = OrderType.ToString();
            txtOrderNumber.Text = OrderNumber;
            if (CurrentDetail == null)
                return;
            ordhed_invoice i = (ordhed_invoice)CurrentDetail.OrderObjectGet(RzWin.Context, Rz5.Enums.OrderType.Invoice);
            if (i == null)
                return;

        }
        protected virtual void CompleteLoad_Status()
        {
            lblStatus.Visible = true;
            if (CurrentDetail.isvoid)
            {
                lblStatus.Text = "VOID";
                lblStatus.BackColor = Color.Gainsboro;
                lblStatus.ForeColor = Color.DarkGray;
                lblOrderType.ForeColor = System.Drawing.Color.Gray;
            }
            if (CurrentDetail.Status == Enums.OrderLineStatus.Hold)
            {
                lblStatus.Text = "HOLD";
                lblStatus.BackColor = Color.MistyRose;
                lblStatus.ForeColor = Color.Red;
            }
            if (CurrentDetail.Status == Enums.OrderLineStatus.Open)
            {
                lblStatus.Text = "OPEN";
                lblStatus.BackColor = Color.LightGreen;
                lblStatus.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblStatus.Text = CurrentDetail.Status.ToString().ToUpper();
                lblStatus.BackColor = Color.LightBlue;
                lblStatus.ForeColor = Color.DarkBlue;
            }
        }
        protected virtual void CheckUpdateShipping()
        {

        }
        //Private Functions
        private void CheckAttachmentTab()
        {
            try
            {
                Int64 i = CurrentDetail.PictureCount(RzWin.Context);
                tabAttachments.Text = "Attachments(" + i.ToString() + ")";
            }
            catch { }
        }
        private void ShowAttachments()
        {
            picview.DoResize();    //picview
            picview.CompleteLoad();
            picview.LoadViewBy(CurrentDetail);
            picview.Caption = "Pictures for " + CurrentDetail.ToString();
        }
        //Control Events
        private void PartPictureViewer_PictureAdded()
        {
            CheckAttachmentTab();
        }
        private void PartPictureViewer_PictureRemoved()
        {
            CheckAttachmentTab();
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ts.SelectedTab == tabAttachments)
                ShowAttachments();
        }
        private void ViewDetail_Resize(object sender, EventArgs e)
        {
            DoResize();
        }


        private void CheckPermissions()
        {

            if (RzWin.Context.xUser.SuperUser || RzWin.Context.CheckPermit(Permissions.ThePermits.CanEditLineItems) || CurrentDetail.seller_uid == RzWin.Context.xUser.unique_id)
            {
                ctl_fullpartnumber.Enabled = true;
                ctl_manufacturer.Enabled = true;
                ctl_datecode.Enabled = true;

            }


        }


    }
}

//seller_uid
//seller_name





