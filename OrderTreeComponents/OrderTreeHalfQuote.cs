using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.OrderTreeComponents
{
    public partial class OrderTreeHalfQuote : OrderTreeHalf
    {
        //Protected Variable
        protected DealHalfQuote TheHalfQuote
        {
            get
            {
                return (DealHalfQuote)TheHalf;
            }
        }

        //Constructors
        public OrderTreeHalfQuote()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override orddet DetailAdd()
        {
            orddet d = TheHalfQuote.QuoteAdd(RzWin.Context);
            if (d != null)
            {
                ReShow();
                FireObjectClicked(d);
            }
            return d;
        }
        public override bool QuoteClicked()
        {
            if (!base.QuoteClicked())
                return false;
            TheHalfQuote.FormalQuoteCreate(RzWin.Context);
            CompleteLoad(xDeal);
            return true;
        }
        public override void AddOneCompany(dealcompany c, string caption)
        {
            base.AddOneCompany(c, caption);
        }
        //Protected Override Functions
        protected override void StockAdd()
        {
            base.StockAdd();
            orddet_quote d = (orddet_quote)GetSelectedDetail();
            if (d == null)
                return;
            orddet_rfq b = d.AddStockBid(RzWin.Context);
            if (b == null)
                return;
            d.ShowDetail(RzWin.Context, b);
            FireObjectClicked(b);
        }
        protected override bool CreateSOClicked()
        {
            if (!base.CreateSOClicked())
                return false;
            TheHalfQuote.SalesOrderCreate(RzWin.Context);
            CompleteLoad(xDeal);
            return true;
        }
        protected override bool AddToSOClicked(orddet_rfq d)
        {
            if (!base.AddToSOClicked(d))
                return false;
            TheHalfQuote.AddToSalesOrder(RzWin.Context, d);
            return true;
        }
        protected override bool AddToFQSOClicked(orddet_quote q)
        {
            if (!base.AddToFQSOClicked(q))
                return false;
            ordhed o = frmChooseFQSO.ChooseFormalQuoteSalesOrder(RzWin.Context, q.base_company_uid);
            if (o == null)
                return false;
            RzWin.Form.TabCloseByID(o.unique_id);
            if (o is ordhed_quote)
                TheHalfQuote.AddQuoteToFormalQuote(RzWin.Context, (ordhed_quote)o, q);
            //KT 11-19-2015 - COmmentd out now that new procedure doesn't need this, and requires NewQuoteLineUID
            //else if (o is ordhed_sales)
            //    TheHalfQuote.AddQuoteToSalesOrder(RzWin.Context, (ordhed_sales)o, q);
            return true;
        }
        protected override void InitMenu()
        {
            mnuDuplicate.Visible = false;
            mnuCut.Visible = false;
            mnuPaste.Visible = false;
            mnuAddStock.Visible = false;
            mnuAddService.Visible = false;
            mnuCreateAllPOs.Visible = false;
            mnuAttachDetail.Visible = false;
            mnuAddToSO.Visible = false;
            mnuQuoteStats.Visible = false;
            mnuPrint.Visible = false;
            mnuAddToFQSO.Visible = false;
            dealcompany c = GetSelectedCompany();
            if (c != null)
            {
                mnuAccept.Visible = false;
                mnuDelete.Visible = false;
                mnuShow.Visible = false;
                mnuAddDetail.Visible = !LimitedMode;
                mnuQuote.Visible = true;
                mnuOrder.Visible = false;
                mnuAddDetail.Text = "New Req";
                mnuQuote.Text = "Create a Quote";
                mnuOrder.Visible = false;
                mnuAddStock.Visible = false;
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
                orddet d = GetSelectedDetail();
                if (d != null)
                {
                    //if (d is orddet_rfq)
                    //    mnuAddToSO.Visible = true;
                    mnuAddStock.Visible = true;
                    mnuAddStock.Text = "Inventory / Excess Bid";
                    mnuAddDetail.Visible = true;
                    mnuDelete.Visible = true;
                    mnuAttachDetail.Visible = false;
                    mnuAddDetail.Text = "Vendor Bid";
                    mnuDelete.Text = "Remove this line";
                    mnuAddStock.Visible = true;
                    mnuAddService.Visible = false;
                    mnuAttachDetail.Text = "Attach A Bid";
                    mnuShow.Visible = false;
                    mnuQuoteStats.Visible = true;
                    mnuAddToFQSO.Visible = true;
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
                            //mnuAddToSO.Visible = true;
                            mnuAccept.Visible = true;
                            if (b.is_accepted)
                                mnuAccept.Text = "Un-Accept";
                            else
                                mnuAccept.Text = "Accept";                           
                        }
                        else
                            mnuAccept.Visible = false;
                    }
                    else
                    {
                        mnuDelete.Visible = false;
                        mnuAccept.Visible = false;
                        mnuAddStock.Visible = false;
                        mnuCreateAllPOs.Visible = false;
                    }
                }
            }
        }
        //Public Functions
        public void CompleteLoad(dealheader d)
        {
            base.CompleteLoad(d, d.CustomerHalf, d.VendorHalf);

            cmdNew.Text = "New Req";
            cmdNew.ImageKey = "new_req";

            cmdImport.Text = "Import Reqs";
            cmdImport.ImageKey = "req_import";

            cmdImportReverse.Text = "Import Bids->Reqs";
            cmdImportReverse.ImageKey = "bid_on_req_import";

            ShowTree("Customers");

            cmdQuote.Visible = true;
            cmdCreateSO.Visible = true;
        }
        protected override void ShowImport(bool opp)
        {
            DealImport i = new DealImport();
            i.xTree = xTree;
            RzWin.Form.TabShow(i, "Import to " + xDeal.dealheader_name);
            i.InitReq(xDeal, opp);
        }
    }
}

