using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ToolsWin;
using NewMethod;
using Rz5;

namespace Rz5.Win.Dialogs
{
    public partial class OrderLineChooser : ToolsWin.Dialogs.OKCancel
    {
        public static List<SalesLineGroup> Choose(ContextNM context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections, Rz5.Enums.OrderType type, List<ordhed> orders, ref bool cancel)
        {
            OrderLineChooser c = RzWin.Leader.GetOrderLineChooserForm();
            c.Init(context, sale, sections, type, orders);
            c.ShowDialog();
            List<SalesLineGroup> ret = c.Result;
            cancel = c.Canceled;

            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch
            {}

            return ret;
        }

        public List<SalesLineGroup> Result = null;
        Rz5.ordhed_sales TheSale = null;
        Rz5.Enums.OrderType TheTargetType;
        public bool Canceled = false;

        List<ordhed> LinkedOrders;

        public OrderLineChooser()
        {
            InitializeComponent();
        }

        protected virtual SalesLineGroupTargetType GetTargetTypeHandle(bool has_invoices)
        {
            if(has_invoices)
                return SalesLineGroupTargetType.ExistingOrder;
            else
                return SalesLineGroupTargetType.NewOrder;
        }

        public void Init(ContextNM context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections, Rz5.Enums.OrderType type, List<ordhed> orders)
        {
            TheSale = sale;
            TheTargetType = type;
            LinkedOrders = orders;
            lvLines.Items.Clear();
            foreach (SalesLineGroup g in sections)
            {
                foreach (orddet_line s in g.TheLines)
                {
                    ListViewItem i = lvLines.Items.Add(s.fullpartnumber);
                    LineHandle h = new LineHandle(s, i);

                    //KT - This auto-assigns the TargetOrder to any related Invoices to lines on this order.  Not how Sensible Rolls
                    //List<ordhed> appropriate = AppropriateFind(s);
                    //if (appropriate.Count == 0)
                    //    h.TheTargetType = GetTargetTypeHandle(appropriate.Count > 0);
                    //else
                    //{
                    //    h.TheTargetType = GetTargetTypeHandle(appropriate.Count > 0);
                    //    h.TheTargetOrder = appropriate[0];
                    //}

                    h.TheTargetType = SalesLineGroupTargetType.NewOrder;
                    i.Tag = h;
                    i.SubItems.Add("");
                    i.SubItems.Add("");
                    i.SubItems.Add("");
                    i.SubItems.Add("");
                    i.SubItems.Add("");
                    i.Selected = true;
                    h.Show();
                }
            }
        }

        public override void OK()
        {
            Result = new List<SalesLineGroup>();
            Dictionary<String, SalesLineGroup> groups = new Dictionary<string, SalesLineGroup>();
            foreach (ListViewItem i in lvLines.Items)
            {
                if(!i.Selected)
                    continue;
                LineHandle h = (LineHandle)i.Tag;

                if (h.TheTargetType == SalesLineGroupTargetType.Unknown)
                {
                    RzWin.Context.TheLeader.Error("Please choose an option for each line");
                    return;
                }

                String key = "";

                if (TheTargetType == Rz5.Enums.OrderType.Purchase)
                    key = h.ToString() + h.TheSaleDetail.vendor_uid + h.TheSaleDetail.lotnumber;
                else
                    key = h.ToString();

                SalesLineGroup g = null;
                if (groups.ContainsKey(key))
                {
                    g = groups[key];
                }
                else
                {
                    g = new SalesLineGroup(company.GetById(RzWin.Context, h.TheSaleDetail.vendor_uid), companycontact.GetById(RzWin.Context, h.TheSaleDetail.vendor_contact_uid), TheSale);
                    if (h.TheSaleDetail.StockType == Rz5.Enums.StockType.Consign)
                    {
                        //g.ConsignmentCode = h.TheSaleDetail.lotnumber;
                        g.ConsignmentCode = h.TheSaleDetail.consignment_code;
                    }
                    g.TheTargetOrder = h.TheTargetOrder;
                    g.TheTargetType = h.TheTargetType;
                    groups.Add(key, g);
                    Result.Add(g);
                }

                g.TheLines.Add(h.TheSaleDetail);
            }

            Canceled = false;
            base.OK();
        }

        public override void Cancel()
        {
            //fixed this, it actually does cancel the process now
            //if (TheTargetType == Rz4.Enums.OrderType.Purchase)
            //{
            //    if (!RzWin.Leader.AreYouSure("cancel (this will not cancel the sales order complete process)"))
            //        return;
            //}
            //else
            //{
                if (!RzWin.Leader.AreYouSure("cancel"))
                    return;
            //}

            Result = null;
            Canceled = true;
            base.Cancel();
        }

        private void lvLines_MouseUp(object sender, MouseEventArgs e)
        {
            string breakPoint = "";
        }

        private void lvLines_Click(object sender, EventArgs e)
        {
            ListViewItem l = null;

            try
            {
                l = lvLines.SelectedItems[0];
                if (l == null)
                    return;
            }
            catch { }

            orddet_line d = ((LineHandle)l.Tag).TheSaleDetail;

            mnu.Items.Clear();

            ToolStripItem i;

            if (TheTargetType == Rz5.Enums.OrderType.Purchase)
                i = mnu.Items.Add("New Purchase Order");
            else
            {
                i = mnu.Items.Add("Edit Quantity");
                i.Click += new EventHandler(EditQty_Click);
                i = mnu.Items.Add("New Invoice");
            }
            i.Click += new EventHandler(NewOrder_Click);
            List<ordhed> appropriate = AppropriateFind(d);

            foreach (ordhed o in appropriate)
            {
                i = mnu.Items.Add(o.ToString());
                i.Tag = o;
                i.Click += new EventHandler(i_Click);
            }

            mnu.Show(Cursor.Position);
        }

        void i_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripItem i = (ToolStripItem)sender;
                ordhed o = (ordhed)i.Tag;
                ListViewItem l = lvLines.SelectedItems[0];
                LineHandle h = (LineHandle)l.Tag;
                h.TheTargetType = SalesLineGroupTargetType.ExistingOrder;
                h.TheTargetOrder = o;
                h.Show();
            }
            catch { }
        }

        List<ordhed> AppropriateFind(orddet_line d)
        {
            if (TheTargetType == Rz5.Enums.OrderType.Purchase)
                return d.AppropriateFindPurchase(LinkedOrders);
            else
                return d.AppropriateFindInvoice(LinkedOrders);
        }

        void NewOrder_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem l = lvLines.SelectedItems[0];
                LineHandle h = (LineHandle)l.Tag;
                h.TheTargetType = SalesLineGroupTargetType.NewOrder;
                h.TheTargetOrder = null;
                h.Show();
            }
            catch { }
        }

        void EditQty_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem l = lvLines.SelectedItems[0];
                LineHandle h = (LineHandle)l.Tag;
                if (h == null)
                    return;
                if (h.TheSaleDetail == null)
                    return;
                if (h.TheSaleDetail.quantity <= 1)
                    return;
                bool cancel = false;
                int q = RzWin.Context.TheLeader.AskForInt32("Please enter the new quantity below.", h.TheSaleDetail.quantity, "Quantity", ref cancel);
                if (cancel)
                    return;
                if (q <= 0)
                {
                    lvLines.Items.Remove(l);
                    return;
                }
                if (q > h.TheSaleDetail.quantity)
                    return;
                h.TheSaleDetail.Split(RzWin.Context, h.TheSaleDetail.quantity - q);
                h.Show();
            }
            catch { }
        }
        
    }

    class LineHandle
    {
        public orddet_line TheSaleDetail;
        public SalesLineGroupTargetType TheTargetType = SalesLineGroupTargetType.Unknown;
        public ordhed TheTargetOrder;
        ListViewItem TheItem;

        public LineHandle(orddet_line sale, ListViewItem i)
        {
            TheSaleDetail = sale;
            TheItem = i;
        }

        public override string ToString()
        {
            switch (TheTargetType)
            {
                case SalesLineGroupTargetType.NewOrder:
                    return "New Order";
                case SalesLineGroupTargetType.ExistingOrder:
                    return TheTargetOrder.ToString();
                default:
                    return "";
            }
        }

        public void Show()
        {
            //RzWin.Context.TheLeader.Error("reorg");

            TheItem.Text = TheSaleDetail.fullpartnumber;
            //TheItem.SubItems[1].Text = TheSaleDetail.release;
            TheItem.SubItems[1].Text = Tools.Number.LongFormat(TheSaleDetail.quantity);
            TheItem.SubItems[2].Text = TheSaleDetail.StockType.ToString();
            TheItem.SubItems[3].Text = TheSaleDetail.lotnumber;
            TheItem.SubItems[4].Text = TheSaleDetail.vendor_name;
            TheItem.SubItems[5].Text = ToString();
        }
    }
}
