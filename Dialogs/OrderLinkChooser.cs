using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rz5.Win.Dialogs
{
    public partial class OrderLinkChooser : ToolsWin.Dialogs.OKCancel
    {
        OrderLinkArgs TheArgs;

        public OrderLinkChooser()
        {
            InitializeComponent();
        }

        public void Init(OrderLinkArgs args)
        {
            base.Init();
            TheArgs = args;

            if (args.TheOrder == null)
                lblOrder.Text = "Merge";
            else
                lblOrder.Text = "Link To " + args.TheOrder.ToString();
    
            oFinder.Visible = false;

            lv.Items.Clear();

            if( args.TheLinkType != Enums.OrderType.Any)
            {
                optSales.Visible = false;
                optPurchase.Visible = false;
                optService.Visible = false;
                optInvoice.Visible = false;
                optRMA.Visible = false;
                optVendRMA.Visible = false;

                switch (args.TheLinkType)
                {
                    case Enums.OrderType.Sales:
                        optSales.Visible = true;
                        optSales.Checked = true;
                        break;
                    case Enums.OrderType.Purchase:
                        optPurchase.Visible = true;
                        optPurchase.Checked = true;
                        break;
                    case Enums.OrderType.Service:
                        optService.Visible = true;
                        optService.Checked = true;
                        break;
                    case Enums.OrderType.Invoice:
                        optInvoice.Visible = true;
                        optInvoice.Checked = true;
                        break;
                    case Enums.OrderType.RMA:
                        optRMA.Visible = true;
                        optRMA.Checked = true;
                        break;
                    case Enums.OrderType.VendRMA:
                        optVendRMA.Visible = true;
                        optVendRMA.Checked = true;
                        break;
                    case Enums.OrderType.Any:
                        break;
                }
            }
        }

        private void optSales_CheckedChanged(object sender, EventArgs e)
        {
            oFinder.Visible = true;
            oFinder.Init(Enums.OrderType.Sales);
        }

        private void optPurchase_CheckedChanged(object sender, EventArgs e)
        {
            oFinder.Visible = true;
            oFinder.Init(Enums.OrderType.Purchase);
        }

        private void optService_CheckedChanged(object sender, EventArgs e)
        {
            oFinder.Visible = true;
            oFinder.Init(Enums.OrderType.Service);
        }

        private void optInvoice_CheckedChanged(object sender, EventArgs e)
        {
            oFinder.Visible = true;
            oFinder.Init(Enums.OrderType.Invoice);
        }

        private void optRMA_CheckedChanged(object sender, EventArgs e)
        {
            oFinder.Visible = true;
            oFinder.Init(Enums.OrderType.RMA);
        }

        private void optVendRMA_CheckedChanged(object sender, EventArgs e)
        {
            oFinder.Visible = true;
            oFinder.Init(Enums.OrderType.VendRMA);
        }

        private void oFinder_OrderFound(object sender, EventArgs e)
        {
            LinesShow(oFinder.OrderCurrent);
        }

        void LinesShow(ordhed_new order)
        {
            checkSuppress = true;
            try
            {
                lv.Items.Clear();
                foreach (orddet_line l in order.DetailsList(RzWin.Context))
                {
                    ItemAdd(order, l);
                }
            }
            catch { }

            checkSuppress = false;
            CheckCheck();
        }

        protected virtual ListViewItem ItemAdd(ordhed_new order, orddet_line l)
        {
            ListViewItem i = lv.Items.Add(l.LineCodeGet(order.OrderType).ToString());
            i.SubItems.Add(l.fullpartnumber);
            i.SubItems.Add(l.quantity.ToString());
            i.SubItems.Add("");
            i.SubItems.Add(l.status_caption);
            i.SubItems.Add(l.customer_name);
            i.SubItems.Add(l.vendor_name);
            i.Tag = l;
            return i;
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            orddet_line l = null;
            ListViewItem item = null;

            try
            {
                item = lv.SelectedItems[0];
                l = (orddet_line)item.Tag;
            }
            catch{}

            if( l == null )
                return;

            bool canceled = false;
            int i = RzWin.Context.TheLeader.AskForInt32("Link quantity", l.quantity, "Quantity", ref canceled);
            if (i <= 0)
                return;

            if (i > l.quantity)
            {
                RzWin.Context.TheLeader.Error("Enter a quantity of " + l.quantity.ToString() + " or lower");
                return;
            }

            item.SubItems[linkIndex].Text = i.ToString();
        }

        bool checkSuppress = false;
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (checkSuppress)
                return;

            CheckCheck();
        }

        int linkIndex = 3;
        void CheckCheck()
        {
            foreach (ListViewItem i in lv.Items)
            {
                if (i.Checked)
                {
                    i.ForeColor = Color.Blue;
                    if (i.SubItems[linkIndex].Text == "")
                        i.SubItems[linkIndex].Text = ((orddet_line)i.Tag).quantity.ToString();
                }
                else
                {
                    i.ForeColor = Color.Gray;
                    i.SubItems[linkIndex].Text = "";
                }
            }

            cmdOK.Enabled = (lv.CheckedItems.Count > 0);
        }

        public override void Cancel()
        {
            TheArgs.TheOrderLinked = null;
            TheArgs.Lines.Clear();
            base.Cancel();
        }

        public override void OK()
        {
            if (lv.CheckedItems.Count == 0)
                return;

            TheArgs.Lines.Clear();
            foreach (ListViewItem i in lv.CheckedItems)
            {
                TheArgs.Lines.Add(new OrderLinkLine((orddet_line)i.Tag, Int32.Parse(i.SubItems[linkIndex].Text)));
            }
            TheArgs.TheOrderLinked = oFinder.OrderCurrent;

            base.OK();
        }

        private void lv_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                ListViewItem i = lv.Items[e.Index];
                orddet_line l = (orddet_line)i.Tag;
                if (l.OrderHas(TheArgs.TheOrder.OrderType))
                {
                    RzWin.Context.TheLeader.Error(l.ToString() + " is already attached to " + RzLogic.GetFriendlyOrderType(TheArgs.TheOrder.OrderType) + " " + l.OrderNumberGet(TheArgs.TheOrder.OrderType));
                    e.NewValue = CheckState.Unchecked;
                    return;
                }
            }
            catch { }

        }
    }
}
