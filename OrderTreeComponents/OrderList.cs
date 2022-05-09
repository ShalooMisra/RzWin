using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5.OrderTreeComponents
{
    public partial class OrderList : UserControl
    {
        public event EventHandler GotResize;
        
        dealheader xDeal;
        int OriginalHeight = 0;
        Enums.OrderType CurrentType = Enums.OrderType.Any;

        public int m_ExpandedHeight = 0;
        public int ExpandedHeight
        {
            get
            {
                return m_ExpandedHeight;
            }

            set
            {
                m_ExpandedHeight = value;
                if (chkShowOrders.Checked)
                    this.Height = m_ExpandedHeight;
            }
        }

        public OrderList()
        {
            InitializeComponent();
        }

        public void CompleteLoad(dealheader d)
        {
            xDeal = d;

            bRFQ.CompleteLoad(Enums.OrderType.RFQ, il.Images["ordhed_rfq"], nTools.ColorFromHex("1fae34"));
            bQuote.CompleteLoad(Enums.OrderType.Quote, il.Images["ordhed_quote"], nTools.ColorFromHex("66669A"));
            bSales.CompleteLoad(Enums.OrderType.Sales, il.Images["ordhed_sales"], nTools.ColorFromHex("fd9316"));
            bService.CompleteLoad(Enums.OrderType.Service, il.Images["ordhed_service"], nTools.ColorFromHex("03fdee"));
            bPurchase.CompleteLoad(Enums.OrderType.Purchase, il.Images["ordhed_purchase"], nTools.ColorFromHex("a0089b"));
            bInvoice.CompleteLoad(Enums.OrderType.Invoice, il.Images["ordhed_invoice"], nTools.ColorFromHex("0f0688"));
            bRMA.CompleteLoad(Enums.OrderType.RMA, il.Images["ordhed_rma"], nTools.ColorFromHex("f10531"));
            bVendRMA.CompleteLoad(Enums.OrderType.VendRMA, il.Images["ordhed_vendrma"], nTools.ColorFromHex("8a041d"));
            OriginalHeight = this.Height;
            CheckShow();
        }

        public void UpdateStats()
        {
            UpdateOne(bRFQ, "RFQs", Enums.OrderType.RFQ);
            UpdateOne(bService, "Service Orders", Enums.OrderType.Service);
            UpdateOne(bQuote, "Quotes", Enums.OrderType.Quote);
            UpdateOne(bSales, "Sales", Enums.OrderType.Sales);
            UpdateOne(bInvoice, "Invoices", Enums.OrderType.Invoice);
            UpdateOne(bPurchase, "Purchases", Enums.OrderType.Purchase);
            UpdateOne(bRMA, "RMAs", Enums.OrderType.RMA);
            UpdateOne(bVendRMA, "VendRMAs", Enums.OrderType.VendRMA);
        }

        public void UpdateOne(OrderButton b, String s, Enums.OrderType t)
        {
            b.SetText(s + " [" + Tools.Number.LongFormat(xDeal.CountOrders(t)) + "]");
        }

        private void chkShowOrders_CheckedChanged(object sender, EventArgs e)
        {
            CheckShow();

            if (GotResize != null)
                GotResize(null, null);
        }

        private void CheckShow()
        {
            if (chkShowOrders.Checked)
            {
                this.Height = m_ExpandedHeight;
            }
            else
            {
                this.Height = OriginalHeight;
            }
            chkShowOrders.Text = "Show Orders";
        }

        private void b_ButtonClicked(OrderButton b)
        {
            ShowOrders(b.TheType);
        }

        private void ShowOrders(Enums.OrderType t)
        {
            RzWin.Context.TheLeader.Error("reorg");
            //CurrentType = t;

            //if (!chkShowOrders.Checked)
            //    chkShowOrders.Checked = true;
            //lv.ShowTemplate("ORDERSEARCH-" + t.ToString(), "ordhed_" + t.ToString(), Rz3App.xUser.TemplateEditor);
            //lv.Clear();
            //lv.CurrentItems = xDeal.GetOrdersD(t);
            //lv.RefreshFromCollection();
        }

        public void RefreshByType(Enums.OrderType t)
        {
            UpdateStats();

            if (t == CurrentType)
                ShowOrders(t);
        }

        private void OrderList_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private void DoResize()
        {
            try
            {
                chkShowOrders.Left = this.ClientRectangle.Width - chkShowOrders.Width;

                if (chkShowOrders.Checked)
                {
                    lv.Visible = true;
                    lv.Left = 0;
                    lv.Width = this.ClientRectangle.Width;
                    lv.Height = this.ClientRectangle.Height - lv.Top;
                }
                else
                    lv.Visible = false;
            }
            catch { }

        }

        private void lv_AboutToThrow(object sender, ShowArgs args)
        {
            try
            {
                ordhed o = (ordhed)args.TheItems.FirstGet(RzWin.Context);
                //o.GatherDetails();
                RzWin.Context.Show(o);
                args.Handled = true;
            }
            catch { }
        }

    }
}
