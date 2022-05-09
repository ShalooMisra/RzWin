using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{   //.MakePO += new BidLineEventHandler
    public partial class BidLine : RzLine, Core.Display.IView, IBidLine
    {
        //Public Variables
        private orddet_rfq xCurrentBid = null;
        private company CurrentVendor = null;
        public orddet_rfq CurrentBid
        {
            get
            {
                return xCurrentBid;
            }
            set
            {
                xCurrentBid = value;
            }
        }
        //Public Events
        public event BidLineEventHandler MakePO;

        //Constructors
        public BidLine()
        {
            InitializeComponent();
            OriginalHeight = 200;
            //lnkViewBid.Visible = false;  //why is there a link to show the bid on the bid editing screen?
        }
        //Public Override Functions
        public override void DoResize()
        {
            try
            {
                //CommandLeft = lvBids.Right + 4;
                CommandLeft = pCommands.Parent.Right - 115;
                base.DoResize();
            }
            catch { }
        }
        public override void ReSetFocus()
        {
            if (CurrentBid.isinstock)
                ctl_quantitystocked.SetFocusSelectAll();
            else
                ctl_quantityordered.SetFocusSelectAll();
        }
        public override bool HideControlBox
        {
            get
            {
                return base.HideControlBox;
            }
            set
            {
                base.HideControlBox = value;
                //lblMakePO.Visible = !base.HideControlBox;
            }
        }
        //Public Functions

        public override void CompleteSave()
        {
            base.CompleteSave();           

            if (!string.IsNullOrEmpty(CurrentBid.fullpartnumber))  //Not sure if the check is necessary, bids should always be related to a req wtih a part number.   
            {
                if (Parent.Parent is OrderTree)
                {
                    OrderTree ot = (OrderTree)Parent.Parent;
                    ot.CompleteSave();

                    //Save MFG if OTHER, and ask user to confirm if adding to list.
                    if (CurrentBid.manufacturer == "OTHER" || string.IsNullOrEmpty(CurrentBid.manufacturer))
                    {
                        string lookupMFg = RzWin.Context.TheSysRz.ThePartLogic.GetManufacturerMatchString(RzWin.Context, CurrentBid.fullpartnumber.Trim().ToUpper());
                        if (!string.IsNullOrEmpty(lookupMFg))
                            CurrentBid.manufacturer = lookupMFg;
                    }
                        
                }
            }
            CurrentBid.Update(RzWin.Context);
        }




        public virtual void CompleteLoad(orddet_rfq b, Image i)
        {
            CurrentBid = b;
            CurrentObject = CurrentBid;
            NMWin.LoadFormValues(this, CurrentBid);
            orddet_quote q = orddet_quote.GetById(RzWin.Context, CurrentBid.the_orddet_quote_uid);
            ShowContact();
            if (CurrentBid.isinstock) //Stock Bid
            {

                ctl_unitprice.Caption = "Stock Cost";
                ctl_quantityordered.Caption = "Stock Bid Qty";
                SetColor(nTools.ColorFromHex("ce9c00"));

            }
            else //Vendor Bid
            {
                //Get the vendor for future checks.
                CurrentVendor = company.GetById(RzWin.Context, b.base_company_uid);
                if (CurrentVendor == null)
                    RzWin.Context.Error("Vendor Not detected. Please inform management or IT.");


                if (CurrentBid.ParentDetailGet(RzWin.Context) == null)
                    ctl_quantitystocked.Visible = false;
                else
                    ctl_quantitystocked.Visible = false;
                SetColor(Color.Green);
            }


            //Load MFG list
            RzWin.Sys.ThePartLogic.LoadManufacturerDropDown(RzWin.Context, ctl_manufacturer);
            ctl_manufacturer.SetValue(CurrentBid.manufacturer);

            ctl_target_price.zz_Text = q.target_price.ToString();
            ctl_target_price.Enabled = false;
            ctl_target_quantity.SetValue(q.target_quantity);
            ctl_target_quantity.Enabled = false;
            ctl_packaging.LoadList(true);
            ctl_condition.LoadList(true);
            ctl_rohs_info.LoadList(true);
            ctl_target_price.Caption = RzWin.Logic.TargetPriceCaption;
            //lblDate.Text = CurrentBid.orderdate.ToString();
            //lblMakePO.Visible = (MakePO != null);
            GetVendorAlerts();
            SetImage(i);
            DoResize();
        }





        private void GetVendorAlerts()
        {
            StringBuilder sb = new StringBuilder();
            string labelValue = "No alerts for vendor";
            bool alertText = false;

            if (CurrentVendor == null) //Null vendor, Set label to Stocktype
            {
                switch (CurrentBid.StockType)
                {
                    default:
                        sb.Append("No Stock / Consignment Alerts.");
                        break;
                }
            }
            else //Vendor Bid, check the vendor object
            {
                //Problem Vendor?
                if (CurrentVendor.problem_vendor)
                {
                    sb.Append("Problem Vendor" + Environment.NewLine);
                    alertText = true;
                }
                //Check Vendor Credits
                double balance = RzWin.Context.TheSysRz.TheCompanyLogic.GetVendorCredits(RzWin.Context, CurrentVendor);
                if (balance > 0)
                {
                    sb.Append(CurrentVendor.companyname + " has a Vedor Credit of " + Tools.Number.MoneyFormat_2_6(balance));
                    alertText = true;
                }

            }

            //Render the string:
            if (!string.IsNullOrEmpty(sb.ToString()))
                labelValue = sb.ToString();

            if (alertText)
            {
                lblVendorAlertList.BackColor = Color.Yellow;
                lblVendorAlertList.ForeColor = Color.Red;
            }
            lblVendorAlertList.Text = labelValue;
        }


        //Private Functions
        private void ShowContact()
        {
            lblVendor.Text = CurrentBid.companyname;
            lblContact.Text = CurrentBid.contactname;
        }
        //Buttons
        private void cmdPartSearch_Click(object sender, EventArgs e)
        {
            String part = ctl_fullpartnumber.GetValue_String();
            if (!Tools.Strings.StrExt(part))
                return;

            RzWin.Context.TheSysRz.ThePartLogic.PartSearchShow(RzWin.Context, new PartSearchShowArgs(part));
        }
        private void cmdMultiSearch_Click(object sender, EventArgs e)
        {
            String part = ctl_fullpartnumber.GetValue_String();
            if (!Tools.Strings.StrExt(part))
                return;
            RzWin.Form.ShowMultiSearch(part);
            RzWin.Form.Focus();
        }
        //Control Events
        private void lblViewCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(CurrentBid.CompanyObjectGet(RzWin.Context));
        }
        private void lblViewContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.Show(CurrentBid.ContactObjectGet(RzWin.Context));
        }
        private void lblMakePO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MakePO != null)
                MakePO(this);
        }
        private void lblChangeCompany_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentBid.SwitchCompany(RzWin.Context, this.ParentForm))
            {
                ShowContact();
                FireReloadRequest();
            }
        }
        private void lblFormalBid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentBid == null)
                return;
            ordhed_rfq o = (ordhed_rfq)CurrentBid.OrderObject(RzWin.Context);
            if (o == null)
            {
                o = (ordhed_rfq)ordhed.CreateNew(RzWin.Context, Enums.OrderType.RFQ);
                o.companyname = CurrentBid.companyname;
                o.base_company_uid = CurrentBid.base_company_uid;
                o.contactname = CurrentBid.contactname;
                o.base_companycontact_uid = CurrentBid.base_companycontact_uid;
                o.agentname = CurrentBid.agentname;
                o.base_mc_user_uid = CurrentBid.base_mc_user_uid;
                o.Update(RzWin.Context);

                CurrentBid.ordernumber = o.ordernumber;
                CurrentBid.base_ordhed_uid = o.unique_id;
                CurrentBid.Update(RzWin.Context);
                o.Details.RefsAdd(RzWin.Context, CurrentBid);
            }

            RzWin.Context.Show(o);
            FireCloseRequest(false);
        }
        private void lnkViewBid_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentBid != null)
                RzWin.Context.Show(CurrentBid);
        }

    }
    public interface IBidLine : InLine
    {
        orddet_rfq CurrentBid
        {
            get;
            set;
        }
        void CompleteLoad(orddet_rfq b, Image i);
        event BidLineEventHandler MakePO;
    }
    public delegate void BidLineEventHandler(IBidLine l);
}

