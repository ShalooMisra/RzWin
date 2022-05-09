using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5.OrderTreeComponents
{
    public partial class OrderTreeHalfBid : OrderTreeHalf
    {
        //Protected Variables
        protected DealHalfBid TheHalfBid
        {
            get
            {
                return (DealHalfBid)TheHalf;
            }
        }

        //Constructors
        public OrderTreeHalfBid()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override bool QuoteClicked()
        {
            try
            {
                dealcompany c = (dealcompany)tv.SelectedNode.Tag;
                if (c == null)
                    return false;

                return TheHalfBid.FormalBidCreate(RzWin.Context, c.the_company_uid, c.the_companycontact_uid);
            }
            catch { return false; }
        }
        //Protected Override Functions
        protected override void InitMenu()
        {
            mnuAddStock.Visible = false;
            mnuAddService.Visible = false;
            mnuCreateAllPOs.Visible = false;
            mnuAttachDetail.Visible = false;
            mnuAddToSO.Visible = false;
            mnuQuoteStats.Visible = false;
            dealcompany c = GetSelectedCompany();
            if (c != null)
            {
                mnuAccept.Visible = false;
                mnuDelete.Visible = true;
                mnuDelete.Text = "Remove " + c.Caption;
                mnuShow.Visible = false;
                mnuAddDetail.Visible = !LimitedMode;
                mnuQuote.Visible = true;
                mnuOrder.Visible = true;
                mnuAddDetail.Text = "Receive Bid";
                mnuQuote.Text = "Create A Formal Bid";
                mnuOrder.Text = "Create a PO";
                mnuViewCompany.Visible = true;
                mnuViewCompany.Text = "View " + c.companyname;
                if (Tools.Strings.StrExt(c.contactname))
                {
                    mnuViewContact.Visible = true;
                    mnuViewContact.Text = "View " + c.contactname;
                }
                else
                    mnuViewContact.Visible = false;
            }
            else
            {
                mnuAccept.Visible = false;
                mnuQuote.Visible = false;
                mnuOrder.Visible = false;
                mnuViewCompany.Visible = false;
                mnuViewContact.Visible = false;
                orddet_old d = GetSelectedDetail();
                if (d != null)
                {
                    mnuAddDetail.Visible = true;
                    mnuDelete.Visible = true;
                    mnuAttachDetail.Visible = true;
                    mnuAddDetail.Text = "Add A Quote";
                    mnuDelete.Text = "Remove this line";
                    mnuAttachDetail.Text = "Attach A Quote";
                    mnuShow.Visible = true;
                    if (d.isselected)
                        mnuShow.Text = "Hide";
                    else
                        mnuShow.Text = "Show";
                    mnuAccept.Visible = true;
                    if (d.is_accepted)
                        mnuAccept.Text = "Un-Accept";
                    else
                        mnuAccept.Text = "Accept";
                }
                else
                {
                    mnuShow.Visible = false;
                    mnuAddDetail.Visible = false;
                    OrderTreeNodeHandle h = GetSelectedHandle();
                    if (h != null)
                    {
                        mnuAddStock.Visible = false;
                        mnuDelete.Visible = true;
                        mnuDelete.Text = "Remove this link";
                        if (h.xDetail.OrderType == Enums.OrderType.RFQ)
                        {
                            orddet_rfq b = (orddet_rfq)h.xDetail;
                            if (b.IsBid)
                            {
                                if (b.isinstock)
                                    mnuAccept.Visible = false;
                                else
                                {
                                    mnuAccept.Visible = true;
                                    if (b.is_accepted)
                                        mnuAccept.Text = "Un-Accept";
                                    else
                                        mnuAccept.Text = "Accept";
                                }
                            }
                            else
                                mnuAccept.Visible = false;
                        }
                        else
                            mnuAccept.Visible = false;
                    }
                    else
                    {
                        mnuDelete.Visible = false;
                        mnuAccept.Visible = false;
                        mnuAddStock.Visible = false;
                        mnuCreateAllPOs.Visible = true;
                    }
                }
            }
        }
        //Public Functions
        public void CompleteLoad(dealheader d)
        {
            base.CompleteLoad(d, d.VendorHalf, d.CustomerHalf);

            cmdNew.Visible = true;
            cmdNew.Text = "Inventory / Excess Bid";
            cmdNew.ImageKey = "new_bid";

            cmdImport.Visible = true;
            cmdImport.Text = "Import Stock Bids";
            cmdImport.ImageKey = "bid_import";

            cmdImportReverse.Visible = false;
            cmdImportReverse.Text = "Import Reqs->Bids";
            cmdImportReverse.ImageKey = "req_on_bid_import";

            cmdQuote.Visible = false;
            cmdXL.Visible = false;

            ShowTree("Vendors");
        }

        protected override void ShowImport(bool opp)
        {
            DealImport i = new DealImport();
            i.xTree = xTree;
            RzWin.Form.TabShow(i, "Import to " + xDeal.dealheader_name);

            company comp = null;
            companycontact cont = null;
            if (!RzWin.Leader.ChooseCompany(RzWin.Context, ref comp, ref cont))
                return;

            i.InitBid(xDeal, comp);
        }
    }
}
