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
    public partial class MergeChooser : ToolsWin.Dialogs.OKCancel
    {
        public static void Choose(OrderLinkArgs args)
        {
            MergeChooser c = new MergeChooser();
            c.Init(args);
            c.ShowDialog();

            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch
            {
            }
        }

        OrderLinkArgs TheArgs;

        public MergeChooser()
        {
            InitializeComponent();
        }

        public void Init(OrderLinkArgs args)
        {
            base.Init();
            TheArgs = args;

            lblOrder.Text = "Merge with " + args.TheOriginalLine.ToString();

            foreach (ordhed o in args.TheOriginalLine.LinkedOrders(RzWin.Context))
            {
                if (o is ordhed_new)
                {
                    LinesShow((ordhed_new)o);
                }
            }
    
            oFinder.Visible = false;         
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

        List<String> lineIds = new List<String>();
        void LinesShow(ordhed_new order)
        {
            checkSuppress = true;
            try
            {
                foreach (orddet_line l in order.DetailsList(RzWin.Context))
                {
                    if (Tools.Strings.StrCmp(l.unique_id, TheArgs.TheOriginalLine.unique_id))
                        continue;

                    if (lineIds.Contains(l.unique_id))
                        continue;

                    ListViewItem i = lv.Items.Add(l.LineCodeGet(order.OrderType).ToString());

                    if (Tools.Strings.StrCmp(l.fullpartnumber, TheArgs.TheOriginalLine.fullpartnumber) && l.quantity == TheArgs.TheOriginalLine.quantity)
                        i.Font = new Font(i.Font, FontStyle.Bold);

                    i.SubItems.Add(l.fullpartnumber);
                    i.SubItems.Add(l.quantity.ToString());
                    i.SubItems.Add(l.StatusCaption);
                    i.SubItems.Add(l.ordernumber_sales);
                    i.SubItems.Add(l.ordernumber_invoice);
                    i.SubItems.Add(l.customer_name);
                    i.SubItems.Add(l.ordernumber_purchase);
                    i.SubItems.Add(l.vendor_name);

                    i.Tag = l;
                    lineIds.Add(l.unique_id);
                }
            }
            catch { }

            checkSuppress = false;
            CheckCheck();
        }


        bool checkSuppress = false;
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (checkSuppress)
                return;

            CheckCheck();
        }

        //int linkIndex = 3;
        void CheckCheck()
        {
            foreach (ListViewItem i in lv.Items)
            {
                if (i.Checked)
                {
                    i.ForeColor = Color.Blue;
                    //if (i.SubItems[linkIndex].Text == "")
                    //    i.SubItems[linkIndex].Text = ((orddet_line)i.Tag).quantity.ToString();
                }
                else
                {
                    i.ForeColor = Color.Gray;
                    //i.SubItems[linkIndex].Text = "";
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
                TheArgs.Lines.Add(new OrderLinkLine((orddet_line)i.Tag, ((orddet_line)i.Tag).quantity));
            }
            //TheArgs.TheOrderLinked = oFinder.OrderCurrent;

            base.OK();
        }

        private void lv_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                ListViewItem i = lv.Items[e.Index];
                orddet_line l = (orddet_line)i.Tag;
                //if (l.OrderHas(TheArgs.TheOrder.OrderType))
                //{
                //    RzWin.Context.TheLeader.Error(l.ToString() + " is already attached to " + Rz3App.GetFriendlyOrderType(TheArgs.TheOrder.OrderType) + " " + l.OrderNumberGet(TheArgs.TheOrder.OrderType));
                //    e.NewValue = CheckState.Unchecked;
                //    return;
                //}
            }
            catch { }

        }
    }
}
