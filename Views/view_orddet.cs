using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class view_orddet : ViewPlusMenu  //, IChangeSubscriber
    {
        public orddet_old CurrentDetail
        {
            get
            {
                return (orddet_old)TheItem;
            }
        }
        bool AlwaysOldInfo = false;
        
        public view_orddet()
        {
            InitializeComponent();
        }
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            
            /*
            
            
            cStub.EnableCompany();
            ctl_unitcost.zz_Enabled = true;
            ts.TabPages.Remove(tabProcurement);
            if (CurrentDetail == null)
                return false;
            if (Rz3App.xLogic.IsAtometron)
                ctl_line_paid.Visible = true;
            if (Rz3App.xLogic.IsAAT)
            {
                MessageBox.Show("reorg");
                //ChangeEditStringsToCaps();
                //ReDoTabOrder();
                //ctl_has_cofc.Visible = true;
                //ts.TabPages.Add(tabProcurement);
                //lvProcurement.ShowTemplate("formal_quotedet_prochistory", "nsn_history", Rz3App.xUser.TemplateEditor);
                //lvProcurement.ShowData("nsn_history", "the_req_uid = '" + CurrentDetail.req_uid + "'", "award_date", 200);
            }
            if (Rz3App.xLogic.IsFoundation)
                ctl_is_accepted.Visible = true;
            ts.TabPages.Remove(tabBids);
            cStub.CurrentObject = CurrentDetail;
            cStub.CompanyIDField = "vendor_company_uid";
            cStub.CompanyNameField = "vendorname";
            cStub.SetCompany();
            agent.CurrentObject = CurrentDetail;
            agent.CurrentIDField = "base_mc_user_uid";
            agent.CurrentNameField = "agentname";
            agent.SetUserName();
            buyer.CurrentObject = CurrentDetail;
            buyer.CurrentIDField = "buyerid";
            buyer.CurrentNameField = "buyername";
            buyer.SetUserName();
            ctl_isverified.Enabled = Rz3App.xUser.SuperUser;
            ctl_hasbeenpicked.Enabled = Rz3App.xUser.SuperUser;
            if (Rz3App.xLogic.EnforceInventory && !Rz3App.xUser.SuperUser)
                ctl_quantityfilled.Enabled = false;
            else
                ctl_quantityfilled.Enabled = true;
            CompleteLoad_LinkedPart();
            ctl_is_service.Visible = (CurrentDetail.OrderType == Enums.OrderType.Quote || CurrentDetail.OrderType == Enums.OrderType.Sales || CurrentDetail.OrderType == Enums.OrderType.Invoice);
            switch (CurrentDetail.OrderType)
            {
                case Enums.OrderType.Quote:
                    if (Rz3App.xLogic.IsAAT)
                        cmdQQ.Visible = true;
                    cmdMarkUp.Visible = true;
                    break;
                case Enums.OrderType.RFQ:
                    this.DisableControls(new object[]{ ctl_fullpartnumber, ctl_quantityordered, ctl_datecode, ctl_manufacturer, ctl_alternatepart, ctl_description, ctl_unitprice }); //xStockLink
                    ctl_unitprice.SetCaption("Target Price");
                    ctl_quantityordered.SetCaption("Qty. Requested");
                    ctl_unitcost.SetCaption("Sale Price");
                    cStub.Caption = "Customer";
                    buyer.Visible = false;
                    cmdQuotes.Text = "Quotes";
                    break;
                default:
                    switch(CurrentDetail.OrderDirection)
                    {
                        case Enums.OrderDirection.Outgoing:
                            ctl_unitprice.SetCaption("Sale Price");
                            ctl_unitcost.SetCaption("Cost");
                            cStub.Caption = "Vendor";
                            buyer.Visible = true;
                            buyer.Caption = "Buyer";
                            cmdQuotes.Text = "Bids";
                            break;
                        case Enums.OrderDirection.Incoming:
                            ctl_unitprice.SetCaption("Purchase Price");
                            ctl_unitcost.SetCaption("Sale Price");
                            cStub.Caption = "Customer";
                            buyer.Visible = false;
                            cmdQuotes.Text = "Quotes";
                            break;
                    }
                    break;
            }
            CurrentDetail.xSys.RegisterNotifyClass(this, "partrecord");
            if( Tools.Strings.StrExt(CurrentDetail.original_vendor_name) )
                lblOriginalVendor.Text = "Original Vendor: " + CurrentDetail.original_vendor_name;
            else
                lblOriginalVendor.Text = "";
            DoVisible();
            if (CurrentDetail.quantityfilled > 0 && !Rz3App.xUser.SuperUser && CurrentDetail.OrderType != Enums.OrderType.Purchase && CurrentDetail.OrderType != Enums.OrderType.Sales)
            {
                if( !Rz3App.xUser.CheckPermit("Orders:Edit:EditFilledOrderLines", true) )
                    this.DisableControls(new object[]{ PPV });
            }
            if(Rz3App.xLogic.IsNasco)
            {
                CheckNascoBlock();
            }
            LoadQC();

            SetInspection();
            ctl_invoice_date.Visible = CurrentDetail.OrderType == Enums.OrderType.Sales;
            if (Rz3App.xLogic.IsAAT)
            {
                CheckOtherTab();
                CheckPictureTab();
            }
            if (Rz3App.xLogic.IsPhoenix)
            {
                ctl_internalpartnumber.Caption = "Customer Part Number";
            }
            ctl_shipvia.LoadList();
            if (Rz3App.xLogic.IsPrism && CurrentDetail.OrderType == Enums.OrderType.Quote)
            {
                if (nData.NullFilter_Boolean(Rz3App.xUser.IGet("sales_assistant")))
                    this.Enabled = false;
            }
             * 
             * */

            
        }


        void SetInspection()
        {
            //if (Rz3App.xLogic.IsMerit && !AlwaysOldInfo)
            //{
            //    lblOldInfo.Visible = true;
            //    inspectionview.Visible = false;
            //    vf.Visible = true;
            //    vf.Dock = DockStyle.Fill;
            //    n_front xf = CurrentDetail.GetFront("Merit Inspection");
            //    if (xf != null)
            //    {
            //        vf.SetCurrentObject(xf);
            //        vf.CompleteStructure();
            //        vf.CompleteLoad();
            //    }
            //}
            //else
            //{
            //    lblOldInfo.Visible = false;
            //    inspectionview.Visible = true;
            //    vf.Visible = false;
            //}
        }

        private void LoadQC()
        {
            qualitycontrol q = qualitycontrol.New(RzWin.Context);
            lvQualityControl.ShowTemplate("view_detail_quality_control", "qualitycontrol", RzWin.User.TemplateEditor);
            lvQualityControl.ShowData("qualitycontrol", "the_orddet_uid = '" + CurrentDetail.unique_id + "'", "date_created", 200);
        }

        public virtual void DoVisible()
        {
            MessageBox.Show("reorg");

            /*
            switch(CurrentDetail.OrderType)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.VendRMA:
                    if(Tools.Strings.StrExt(CurrentDetail.vendor_company_uid))
                    {
                        //show vendor
                        cStub.Visible = true;
                        buyer.Visible = true;
                        lblStock.Visible = false;
                        lblOriginalVendor.Visible = false;
                        lblChooseVendor.Visible = false;
                        lblChooseVendorContact.Visible = true;
                        lblChooseVendorContact.BringToFront();
                        ctl_vendorcontactname.Visible = true;
                    }
                    else
                    {
                        //show 'stock'
                        cStub.Visible = false;
                        buyer.Visible = Rz3App.xLogic.IsSelect;
                        lblStock.Visible = true;
                        lblOriginalVendor.Visible = true;
                        lblChooseVendor.Visible = true;
                        lblChooseVendorContact.Visible = false;
                        ctl_vendorcontactname.Visible = false;
                    }
                    break;
            }
             * */
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                //xStockLink.Left = 0;
                //ts.Left = xStockLink.Right;

            }
            catch(Exception)
            {
                base.DoResize();
            }
        }
        private void CompleteLoad_LinkedPart()
        {
            partrecord p = null;
            try
            {
                p = CurrentDetail.LinkedPart;
            }
            catch(Exception)
            {
            }
            //xStockLink.CompleteLoad(p, CurrentDetail);
            ctl_unitcost.Enabled = true;
            //disable the cost for non-super users

            //gone!
            //if(p != null && Rz3App.xLogic.IsCTG && !Rz3App.xUser.SuperUser)
            //{
            //    Enums.StockType original = CurrentDetail.OriginalStockType;
            //    if(p.StockType != Enums.StockType.Buy || ( original != Enums.StockType.Any && CurrentDetail.OriginalStockType != Enums.StockType.Buy ))
            //    {
            //        ctl_unitcost.Enabled = false;
            //    }
            //}
        }

        public override void CompleteSave()
        {
            MessageBox.Show("reorg");
            

            /*

            if( Rz3App.xLogic.IsAAT )
                ctl_fullpartnumber.SetValue(ctl_fullpartnumber.GetValue_String().Trim());
            if( !base.CompleteSave() )
                return false;
            if( Tools.Strings.StrExt(CurrentDetail.base_dealdetail_uid) )
                Rz3App.RzWin.Context.Execute("update dealdetail set fullpartnumber = '" + Rz3App.RzWin.Context.Filter(CurrentDetail.fullpartnumber) + "' where unique_id = '" + CurrentDetail.base_dealdetail_uid + "' and isnull(fullpartnumber, '') = ''");
            //switch(ts.SelectedIndex)
            //{
            //    case 3:
            //        inspectionview.CompleteSave();
            //        break;
            //}

            if( !Rz3App.xLogic.IsMerit )
                CheckStockCost();

            return true;
             * 
             * */
        }
        private void CheckStockCost()
        {
            System.Windows.Forms.MessageBox.Show("reorg");

            /*
            if( CurrentDetail.unitcost <= 0 )
                return;
            if( CurrentDetail.OrderType != Enums.OrderType.Sales && CurrentDetail.OrderType != Enums.OrderType.Invoice )
                return;
            partrecord p = CurrentDetail.LinkedPart;
            if( p == null )
                return;
            switch(p.StockType)
            {
                case Enums.StockType.Stock:
                    if(p.cost > 0)
                    {
                        if(CurrentDetail.unitcost < p.cost)
                        {
                            if(Rz3App.xUser.SuperUser)
                            {
                                RzWin.Leader.Tell("The assigned stock value of this part is " + nTools.MoneyFormat_2_6(p.cost) + ".  Since your account has super-user permissions, the cost of this line item will not automatically be changed to match.");
                            }
                            else
                            {
                                RzWin.Leader.Tell("The assigned stock value of this part is " + nTools.MoneyFormat_2_6(p.cost) + "; the cost of this line item will be set to match.");
                                CurrentDetail.unitcost = p.cost;
                                ctl_unitcost.SetValue(p.cost);
                            }
                        }
                    }
                    break;
            }
             * */
        }
        private void cmdQuotes_Click(object sender, EventArgs e)
        {
            SearchQuotes();
        }
        public void SearchQuotes()
        {
            MessageBox.Show("reorg");
            /*
            Enums.QuoteType t;
            //this seems backwards but it isn't
            if( CurrentDetail.OrderDirection == Enums.OrderDirection.Outgoing )
                t = Enums.QuoteType.Receiving;
            else
                t = Enums.QuoteType.GivingOut;
            nObject n = quote.Choose(CurrentDetail.xSys, CurrentDetail.fullpartnumber, t, this.ParentForm);
            if( n == null )
                return;
            switch(n.ClassName.ToLower())
            {
                case "quote":
                    quote q = (quote)n;
                    cStub.SetCompanyInfo(q.base_company_uid, q.companyname);
                    CurrentDetail.vendorcontactid = q.base_companycontact_uid;
                    CurrentDetail.vendorcontactname = q.contactname;
                    ctl_unitcost.SetValue(q.quoteprice);
                    break;
                case "orddet_rfq":
                    orddet_rfq r = (orddet_rfq)n;
                    cStub.SetCompanyInfo(r.base_company_uid, r.companyname);
                    CurrentDetail.vendorcontactid = r.base_companycontact_uid;
                    CurrentDetail.vendorcontactname = r.contactname;
                    ctl_unitcost.SetValue(r.unitprice);
                    break;
            }
            DoVisible();
             * */
        }
        public void SendToVendorBids()
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            try
            {
                if (CurrentDetail == null)
                    return;
                if (NoVendorBidAssigned())
                    return;
                quote q = new quote(Rz3App.xSys);
                q.QuoteType = Enums.QuoteType.Receiving;
                q.fullpartnumber = CurrentDetail.fullpartnumber;
                q.prefix = CurrentDetail.prefix;
                q.basenumber = CurrentDetail.basenumber;
                q.basenumberstripped = CurrentDetail.basenumberstripped;
                q.quotequantity = CurrentDetail.quantityordered;
                q.base_company_uid = CurrentDetail.vendor_company_uid;
                q.base_companycontact_uid = CurrentDetail.vendorcontactid;
                q.companyname = CurrentDetail.vendorname;
                q.contactname = CurrentDetail.vendorcontactname;
                q.quoteprice = CurrentDetail.unitcost;
                q.ISave();
                CurrentDetail.vendor_company_uid = "";
                CurrentDetail.vendorcontactid = "";
                CurrentDetail.vendorcontactname = "";
                CurrentDetail.vendorid = "";
                CurrentDetail.vendorname = "";
                CurrentDetail.unitcost = 0;
                CurrentDetail.ISave();
                CompleteLoad();
            }
            catch { }
             * 
             * */
        }

        private bool NoVendorBidAssigned()
        {
            RzWin.Context.TheLeader.Error("reorg");
            return false;

            //if (!Tools.Strings.StrExt(CurrentDetail.vendor_company_uid))
            //    return true;
            //if (CurrentDetail.unitcost <= 0)
            //    return true;
            //return false;
        }
        private void xFlash_ButtonClick(object sender, FlashClickArgs args)
        {
            switch(args.strButton.ToLower().Trim())
            {
                case "link":
                    CurrentDetail.LinkStockItem(this.ParentForm);
                    CompleteLoad();
                    break;
            }
        }
        private void ctl_manufacturer_Load(object sender, EventArgs e)
        {
        }
        public override void FinishedAction(ActArgs args)
        {
            switch(args.ActionName.ToLower().Trim())
            {
                case "linkstock":
                case "viewstock":
                case "viewpart":
                    CompleteLoad_LinkedPart();
                    break;
                default:
                    base.FinishedAction(args);
                    break;
            }
        }
        private void cStub_ChangeCompany(GenericEvent e)
        {
            ClearContact();
        }
        private void ClearContact()
        {
            MessageBox.Show("reorg");
            //CurrentDetail.vendorcontactid = "";
            //CurrentDetail.vendorcontactname = "";
            //ctl_vendorcontactname.SetValue("");
        }
        private void ChangeEditStringsToCaps()
        {
            try
            {
                foreach(Control c in Controls)
                {
                    SetAllCaps(c);
                }
            }
            catch
            {
            }
        }
        private void SetAllCaps(Control c)
        {
            try
            {
                if( c == null )
                    return;
                nEdit_String str = null;
                try
                {
                    if( c is nEdit_String )
                        str = (nEdit_String)c;
                }
                catch
                {
                }
                if(str == null)
                {
                    foreach(Control cc in c.Controls)
                    {
                        SetAllCaps(cc);
                    }
                    return;
                }
                str.AllCaps = true;
            }
            catch(Exception ee)
            {
            }
        }
        private void NotifyChangeHandler(String strClass, bool adds)
        {
            switch(strClass.ToLower())
            {
                case "partrecord":
                    CompleteLoad_LinkedPart();
                    break;
            }
        }
        //public void NotifyChange(String strClass, bool adds)
        //{
        //    try
        //    {
        //        if(this.InvokeRequired)
        //        {
        //            HandleChangeNotification d = new HandleChangeNotification(NotifyChangeHandler);
        //            this.Invoke(d, new object[]{ strClass, adds });
        //        }
        //        else
        //        {
        //            NotifyChangeHandler(strClass, adds);
        //        }
        //    }
        //    catch(Exception)
        //    {
        //    }
        //}
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            DoResize();
            switch(ts.SelectedIndex)
            {
                case 2:
                    ShowPartPictures();
                    break;
            //    case 3:
            //        ShowInspection();
            //        break;
            }
        }
        private void ShowPartPictures()
        {
            PPV.Top = 0;
            PPV.Left = 0;
            PPV.Width = pagePictures.ClientRectangle.Width;
            PPV.Height = pagePictures.ClientRectangle.Height;
            PPV.DoResize();
            PPV.CompleteLoad();
            PPV.LoadViewBy(CurrentDetail);
            PPV.Caption = "Pictures for " + CurrentDetail.ToString();
        }
        private void DoSearch()
        {
            try
            {
                if( !Tools.Strings.StrExt(ctl_fullpartnumber.GetValue_String()) )
                    return;
                if( optPartSearch.Checked )
                     RzWin.Context.TheSysRz.ThePartLogic.PartSearchShow(RzWin.Context, new PartSearchShowArgs(ctl_fullpartnumber.GetValue_String()));
                else if( optMultiSearch.Checked )
                    RzWin.Form.ShowMultiSearch(ctl_fullpartnumber.GetValue_String());
            }
            catch(Exception)
            {
            }
        }
        private void cmdPartSearch_Click(object sender, EventArgs e)
        {
            DoSearch();
        }
        private void cmdMarkUp_Click(object sender, EventArgs e)
        {
            DoMarkUp();
        }
        private void DoMarkUp()
        {
            try
            {
                if(ctl_quantityordered.GetValue_Long() <= 0)
                {
                    RzWin.Leader.Tell("You need a quantity to markup first.");
                    return;
                }
                if((Double)ctl_unitcost.GetValue() <= 0)
                {
                    RzWin.Leader.Tell("You need a cost to markup from.");
                    return;
                }
                String markup = RzWin.User.GetSetting(RzWin.Context, "price_markup");
                if (!Tools.Strings.StrExt(markup))
                    markup = RzWin.Context.GetSetting("price_markup");
                if (!Tools.Strings.StrExt(markup))
                    markup = "35";
                markup = markup.Replace("%", "");
                markup = RzWin.Leader.AskForString("Please enter the mark-up percentage.", markup);
                markup = markup.Replace("%", "");
                if (!Tools.Number.IsNumeric(markup))
                    return;
                Double mark = (Double.Parse(markup) / 100);
                Double qty = (Double)ctl_quantityordered.GetValue_Long();
                Double cost = (Double)ctl_unitcost.GetValue();
                cost = qty * cost;
                qty = cost * mark;
                cost = (cost + qty) / (Double)ctl_quantityordered.GetValue_Long();
                ctl_unitprice.SetValue(cost);
                CompleteSave();
            }
            catch(Exception)
            {
            }
        }
        private void SetMarkUpPercent()
        {
            try
            {
                //cmdMarkUp.Text = "25%";

                //String markup = Rz3App.GetSetting("price_markup");
                
                //if( !Tools.Strings.StrExt(markup) )
                //    markup = Rz3App.xUser.GetSetting("price_markup");
    
                //if( !Tools.Strings.StrExt(markup) )
                //    return;
                //markup = markup.Replace("%", "");
                //if( !Tools.Number.IsNumeric(markup) )
                //    return;
                //cmdMarkUp.Text = markup.Trim() + "%";
            }
            catch(Exception)
            {
            }
        }
        private void lblChooseVendor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cStub.ChangeTheCompany();
            DoVisible();
        }
        private void cStub_ClearCompany(GenericEvent e)
        {
            ClearContact();
        }
        private void cStub_ClearCompanyFinished(GenericEvent e)
        {
            DoVisible();
        }
        private void lvBids_AboutToAdd(object sender, AddArgs args)
        {
            RzWin.Context.TheLeader.Error("reorg");

            /*

            try
            {
                args.Handled = true;
                quote vbid = new quote(Rz3App.xSys);
                vbid.fullpartnumber = CurrentDetail.fullpartnumber;
                string prefix = "";
                string basen = "";
                PartObject.ParsePartNumber(vbid.fullpartnumber, ref prefix, ref basen);
                vbid.prefix = prefix;
                vbid.basenumber = basen;
                vbid.basenumberstripped = PartObject.StripPart(basen);
                vbid.QuoteType = Enums.QuoteType.Receiving;
                vbid.quotequantity = CurrentDetail.quantityordered;
                vbid.ISave();
                Rz3App.Show(vbid);
            }
            catch(Exception)
            {
            }
             * 
             * */
        }
        private void lblChooseVendorContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RzWin.Context.TheLeader.Error("reorg");

            //if( CurrentDetail == null )
            //    return;
            //String id = cStub.GetCompanyID();
            //if( !Tools.Strings.StrExt(id) )
            //    return;
            //String strContactID = "";
            //String strContactName = "";
            //frmChooseContact.ChooseContactID(ref strContactID, ref strContactName, id, "Select A Contact", this.ParentForm);
            //if( strContactID.Length <= 0 )
            //    return;
            //CurrentDetail.vendorcontactid = strContactID;
            //CurrentDetail.vendorcontactname = strContactName;
            //CurrentDetail.ISave();
            //ctl_vendorcontactname.SetValue(strContactName);
        }
        private void ReDoTabOrder()
        {
            try
            {
                ctl_fullpartnumber.TabIndex = 0;
                ctl_manufacturer.TabIndex = 1;
                ctl_datecode.TabIndex = 3;
                ctl_quantityordered.TabIndex = 4;
                ctl_quantityfilled.TabIndex = 5;
                ctl_unitprice.TabIndex = 6;
                ctl_description.TabIndex = 7;
                ctl_unitcost.TabIndex = 8;
                ctl_unit_of_measure.TabIndex = 18;
                ctl_quantitycancelled.TabIndex = 29;
            }
            catch(Exception)
            {
            }
        }
        private void ctl_description_KeyUp(object sender, KeyEventArgs e)
        {
        }
        private void lvProcurement_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        //private void CheckNascoBlock()
        //{
        //    RzWin.Context.TheLeader.Error("reorg");

        //    /*

        //    try
        //    {
        //        if(CurrentDetail.OrderObject.OrderType == Enums.OrderType.Purchase || CurrentDetail.OrderObject.OrderType == Enums.OrderType.Sales)
        //        {
        //            if(CurrentDetail.OrderObject.credit_check_approved)
        //            {
        //                if(Rz3App.xUser.IsTeamMember("ORDER APPROVAL"))
        //                {
        //                    ctl_unitcost.Enabled = true;
        //                    ctl_unitprice.Enabled = true;
        //                    cStub.Enabled = true;
        //                    lblChooseVendor.Enabled = true;
        //                    lblChooseVendorContact.Enabled = true;
        //                    ctl_vendorcontactname.Enabled = true;
        //                    ctl_quantityfilled.Enabled = true;
        //                }
        //                else
        //                {
        //                    ctl_unitcost.Enabled = false;
        //                    ctl_unitprice.Enabled = false;
        //                    cStub.Enabled = false;
        //                    lblChooseVendor.Enabled = false;
        //                    lblChooseVendorContact.Enabled = false;
        //                    ctl_vendorcontactname.Enabled = false;
        //                    if (CurrentDetail.OrderType == Enums.OrderType.Sales)
        //                        ctl_quantityfilled.Enabled = false;
        //                }
        //            }
        //            else
        //            {
        //                ctl_quantityfilled.Enabled = true;
        //                ctl_unitcost.Enabled = true;
        //                ctl_unitprice.Enabled = true;
        //                cStub.Enabled = true;
        //                lblChooseVendor.Enabled = true;
        //                lblChooseVendorContact.Enabled = true;
        //                ctl_vendorcontactname.Enabled = true;
        //            }
        //        }
        //    }
        //    catch
        //    {
        //    }
        //     * 
        //     * */
        //}
        private void lvQualityControl_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
        }
        private void cmdQQ_Click(object sender, EventArgs e)
        {
            DoQuickQuote();
        }
        private void DoQuickQuote()
        {
            if( CurrentDetail == null )
                return;
            if( !Tools.Strings.StrExt(CurrentDetail.datecode) )
                CurrentDetail.datecode = "N/A";
            if( !Tools.Strings.StrExt(CurrentDetail.manufacturer) )
                CurrentDetail.manufacturer = "N/A";
            ctl_manufacturer.SetValue(CurrentDetail.manufacturer);
            ctl_datecode.SetValue(CurrentDetail.datecode);
            DoMarkUp();
            CompleteSave();
        }
        private void xStockLink_BreakLinkRequest(object sender, EventArgs e)
        {
            HandleCommand("breaklink");
        }
        private void xStockLink_SearchLinkRequest(object sender, EventArgs e)
        {
            HandleCommand("linkstock");
        }
        private void cmdMultiSearchAltPart_Click(object sender, EventArgs e)
        {
            String part = ctl_alternatepart.GetValue_String();
            if( !Tools.Strings.StrExt(part) )
                return;
            RzWin.Form.ShowMultiSearch(part);
        }
        private void cmdSendToVendorBids_Click(object sender, EventArgs e)
        {
            SendToVendorBids();
        }
        private void CheckOtherTab()
        {
            try
            {
                int i = 0;
                if (Tools.Strings.StrExt(ctl_alternatepart_01.GetValue_String()))
                    i++;
                if (Tools.Strings.StrExt(ctl_alternatepart_03.GetValue_String()))
                    i++;
                if (Tools.Strings.StrExt(ctl_alternatepart_04.GetValue_String()))
                    i++;
                if (i > 0)
                    pageOther.Text = "Other(" + i.ToString() + ")";
            }
            catch { }
        }
        private void CheckPictureTab()
        {
            try
            {
                long i = RzWin.Context.SelectScalarInt64("select count(*) from partpicture where the_orddet_uid = '" + CurrentDetail.unique_id + "'");
                if (i > 0)
                    pagePictures.Text = "Attachments (" + i.ToString() + ")";
            }
            catch { }
        }
        public void BlockAllChanges()
        {
            try
            {
                //xStockLink.Enabled = false;
                foreach (TabPage tp in ts.TabPages)
                {
                    foreach (Control c in tp.Controls)
                    {
                        c.Enabled = false;
                    }
                }
            }
            catch { }
        }

        private void lblOldInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AlwaysOldInfo = true;
            SetInspection();
        }

        private void ctl_fullpartnumber_DataChanged(GenericEvent e)
        {
            PartNumberChanged();
        }

        public virtual void PartNumberChanged()
        {

        }

        private void cmdViewInspection_Click(object sender, EventArgs e)
        {

        }

        private void xStockLink_Load(object sender, EventArgs e)
        {

        }

    }
}