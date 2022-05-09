using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using System.Drawing.Printing;

namespace Rz5
{
    public partial class OrderMap : UserControl
    {
        //Public Variables
        public bool DealMode = false;
        //Private Variables
        private OrderMapObject z_OrderMap;
        private ordhed TheOrder = null;

        private dealheader xDeal;
        private String RunningIDs = "";
        private ArrayList AllOrderHandles;
        private ArrayList AdjustedLinks;

        //Constructors
        public OrderMap()
        {
            InitializeComponent();            
        }
        //Public Functions
        public void CompleteLoad(ordhed o, bool include_void)
        {
            TheOrder = o;
            chkIncludeVoid.Checked = include_void;
            DoResize();
            ClearOrders();

            if (!Tools.Strings.StrExt(o.unique_id))
                return;
            z_OrderMap = RzWin.Context.Sys.TheOrderLogic.OrderMapObjectCreate(RzWin.Context);
            z_OrderMap.CompleteLoad(RzWin.Context, o, pContents.ClientRectangle.Width, include_void);            
            pic.Image = new Bitmap(pic.ClientRectangle.Width, pic.ClientRectangle.Height);
            ShowOrders((ArrayList)z_OrderMap.ary[0], 0, 0, pContents.ClientRectangle.Height, 0, 0, false);
            int left = 10;
            foreach (OrderHandle h in z_OrderMap.all_handles)
            {
                if (!h.ShownInChart)
                {
                    OrderHandle hd = null;
                    ordhed hed = (ordhed)RzWin.Context.GetById("ordhed", h.strID); //this isn't doing anything with the specific order types
                    OrderStub s = null;
                    if (hed != null)
                    {
                        s = AddOrderStub(hed, out hd);
                    }
                    else
                    {
                        s = new OrderStub();
                        pContents.Controls.Add(s);
                        s.BringToFront();
                        z_OrderMap.Maps.Add(s);
                        s.CompleteLoad(h);
                    }
                    s.Left = left;
                    s.Top = 10;
                    left += s.Width + 10;
                }
            }
            lvOrders.Items.Clear();
            foreach (OrderHandle h in z_OrderMap.lvHandles)
            {
                ListViewItem i = lvOrders.Items.Add(h.strNumber);
                i.Tag = h.strID;
                i.SubItems.Add(h.type.ToString());
                i.SubItems.Add(h.strOrderDate);
                i.SubItems.Add(h.strCompany);
            }
        }
        public void CompleteLoadFromDeal(dealheader d)
        {
            xDeal = d;
            DealMode = true;
            ClearOrders();
            ArrayList a = new ArrayList();
            ArrayList ids = new ArrayList();
            for (int i = 0; i < 8; i++)
            {
                Enums.OrderType t = Enums.OrderType.Any;
                switch (i)
                {
                    case 0:
                        t = Enums.OrderType.RFQ;
                        break;
                    case 1:
                        t = Enums.OrderType.Quote;
                        break;
                    case 2:
                        t = Enums.OrderType.Purchase;
                        break;
                    case 3:
                        t = Enums.OrderType.Service;
                        break;
                    case 4:
                        t = Enums.OrderType.Sales;
                        break;
                    case 5:
                        t = Enums.OrderType.Invoice;
                        break;
                    case 6:
                        t = Enums.OrderType.RMA;
                        break;
                    case 7:
                        t = Enums.OrderType.VendRMA;
                        break;
                }
                if (t != Enums.OrderType.Any)
                {
                    Dictionary<String, nObject>dy = xDeal.GetOrdersD(t);
                    if (dy.Count > 0)
                    {
                        a.Add(dy);
                        foreach (KeyValuePair<String, nObject> kvp in dy)
                        {
                            ids.Add(((ordhed)kvp.Value).unique_id);
                        }
                    }
                }
            }
            if (a.Count == 0)
                return;
            int cols = a.Count;
            int colwidth = pContents.ClientRectangle.Width / cols;
            Dictionary<String, OrderHandle> handles = new Dictionary<String, OrderHandle>();
            int j = 0;
            foreach (Dictionary<String, nObject> dx in a)
            {
                ShowOrderColumn(dx, handles, j * colwidth, (j + 1) * colwidth);
                j++;
            }
            pic.Image = new Bitmap(pic.ClientRectangle.Width, pic.ClientRectangle.Height);
            Graphics g = Graphics.FromImage(pic.Image);
            Pen p = new Pen(Brushes.Blue, 4);
            ArrayList links = RzWin.Context.QtC("ordlnk", "select * from ordlnk where orderid1 in (" + nTools.GetIn(ids) + ") ");
            foreach (ordlnk l in links)
            {
                try
                {
                    OrderHandle start = handles[l.orderid1];
                    OrderHandle end = handles[l.orderid2];

                    if (start != null && end != null)
                    {
                        g.DrawLine(p, start.GetPoint(), end.GetPoint());
                    }
                }
                catch { }
            }
            g.Dispose();
            g = null;
            p.Dispose();
            p = null;
        }
        public void ShowOrders(ArrayList a, int index, int StartY, int EndY, int lx, int ly, bool nolines)
        {
            if (z_OrderMap == null)
                return;
            //figure out the spacing
            int height = EndY - StartY;
            int spacing = height / a.Count;
            //start at the top, and draw them down
            int i = 0;
            foreach (OrderHandle h in a)
            {
                OrderStub s = new OrderStub();
                pContents.Controls.Add(s);
                h.ShownInChart = true;
                s.BringToFront();
                z_OrderMap.Maps.Add(s);
                //center it
                int cw = (z_OrderMap.ColumnWidth * index) + (z_OrderMap.ColumnWidth / 2);
                s.Left = cw - (s.Width / 2);
                int ch = (StartY + (i * spacing)) + (spacing / 2);
                s.Top = ch - (s.Height / 2);
                s.CompleteLoad(h);
                //draw the line
                if (lx > 0 && ly > 0 && (!nolines))
                {
                    //if (h.type != Enums.OrderType.VendRMA)
                    //{
                    Graphics g = Graphics.FromImage(pic.Image);
                    Pen p = new Pen(Brushes.Blue, 4);
                    g.DrawLine(p, new Point(lx, ly), new Point(s.Left + (s.Width / 2), s.Top + (s.Height / 2)));
                    //}
                }
                if (index < (z_OrderMap.ary.Count - 1))    //if it isn't the last array
                {
                    ArrayList NextCollection = new ArrayList();
                    switch (h.type)
                    {
                        case Enums.OrderType.Sales:
                            if (z_OrderMap.PurchaseIndex > -1)
                                NextCollection.Add(z_OrderMap.ary[z_OrderMap.PurchaseIndex]);
                            if (z_OrderMap.InvoiceIndex > -1)
                                NextCollection.Add(z_OrderMap.ary[z_OrderMap.InvoiceIndex]);
                            break;
                        case Enums.OrderType.Purchase:
                            if (z_OrderMap.VendRMAIndex > -1)
                                NextCollection.Add(z_OrderMap.ary[z_OrderMap.VendRMAIndex]);
                            break;
                        case Enums.OrderType.Invoice:
                            if (z_OrderMap.RMAIndex > -1)
                                NextCollection.Add(z_OrderMap.ary[z_OrderMap.RMAIndex]);
                            break;
                        default:
                            NextCollection.Add((ArrayList)z_OrderMap.ary[index + 1]);
                            break;
                    }
                    //get an array of the linked orders from the next level
                    ArrayList hold = new ArrayList();
                    foreach (ArrayList next in NextCollection)
                    {
                        foreach (OrderHandle oh in next)
                        {
                            String sid = h.strID + "*" + oh.strID;
                            String sc = (String)z_OrderMap.Links[sid];
                            if (sc != null)
                                hold.Add(oh);
                        }
                    }
                    if (hold.Count > 0)
                    {
                        int sy = StartY + (i * spacing);
                        int sty = StartY + ((i + 1) * spacing);
                        ShowOrders(hold, index + 1, sy, sty, s.Left + (s.Width / 2), s.Top + (s.Height / 2), (h.type == Enums.OrderType.VendRMA));
                    }
                }
                i++;
            }
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                pOptions.Left = 0;
                pOptions.Top = 0;
                pOptions.Width = lvOrders.Width;

                lvOrders.Left = 0;
                lvOrders.Top = pOptions.Bottom;

                //if (lblBreakUp.Visible)
                //{
                //    lvOrders.Height = this.ClientRectangle.Height - lblBreakUp.Height;
                //    lblBreakUp.Top = this.ClientRectangle.Height - lblBreakUp.Height;
                //    lblBreakUp.Left = 0;
                //}
                //else
                    lvOrders.Height = (this.ClientRectangle.Height - pOptions.Height);

                pContents.Left = lvOrders.Right;
                pContents.Top = 0;
                pContents.Width = this.ClientRectangle.Width - pContents.Width;
                pContents.Height = this.ClientRectangle.Height;
                //lnkPrint.Top = pContents.Top;
                //lnkPrint.Left = (pContents.Width - lnkPrint.Width) - 2;

                //tv.Top = 0;
                //tv.Left = 0;
                //tv.Width = this.Width;
                //tv.Height = this.Height;

            }
            catch { }
        }
        private void ShowOrderColumn(Dictionary<String, nObject> d, Dictionary<String, OrderHandle> handles, int start, int end)
        {
            if (d.Count == 0)
                return;

            int rowheight = pContents.ClientRectangle.Height / d.Count;
            int rowstart = 0;
            int halfrow = rowheight / 2;

            foreach(KeyValuePair<String, nObject>k in d)
            {
                OrderHandle h = null;
                ordhed o = (ordhed)k.Value;
                OrderStub s = AddOrderStub(o, out h);

                h.CenterX = (start + (end - start) / 2);
                h.CenterY = (rowstart + halfrow);

                s.Left = h.CenterX - (s.Width / 2);
                s.Top = h.CenterY - (s.Height / 2);
                rowstart += rowheight;

                handles.Add(o.unique_id, h);
            }            
        }
        private OrderStub AddOrderStub(ordhed o, out OrderHandle reth)
        {
            if (z_OrderMap == null)
            {
                reth = null;
                return null;
            }
            OrderStub s = new OrderStub();
            pContents.Controls.Add(s);
            s.BringToFront();
            z_OrderMap.Maps.Add(s);

            OrderHandle h = new OrderHandle(o.unique_id, o.ordernumber, o.OrderType, o.companyname, o.base_company_uid, o.agentname, nTools.DateFormat(o.orderdate) + " " + nTools.TimeFormat(o.orderdate), o.isvoid, o.is_authorized);
            h.Incomplete = (o.OrderType == Enums.OrderType.Purchase && !o.is_received);

            s.CompleteLoad(h);
            reth = h;
            return s;
        }
        private void RenderOrderTree(String id, TreeNode n)
        {
            if (!Tools.Strings.StrExt(id))
                return;
            ArrayList a = null;
            if (!Tools.Strings.StrExt(RunningIDs))
                a = RzWin.Context.SelectScalarArray("select orderid2 from ordlnk where orderid1 = '" + id + "'");
            else
                a = RzWin.Context.SelectScalarArray("select orderid2 from ordlnk where orderid1 = '" + id + "' and orderid2 not in (" + RunningIDs + ")");
            if (a == null)
                return;
            if (a.Count <= 0)
                return;
            String inn = nTools.GetIn(a);
            a = RzWin.Context.QtC("ordhed", "select * from ordhed where unique_id in (" + inn + ")");
            if (a == null)
                return;
            if (a.Count <= 0)
                return;
            foreach (ordhed o in a)
            {
                if (o == null)
                    continue;
                TreeNode tn = n.Nodes.Add("[" + o.orderdate.ToShortDateString() + "]" + o.ToString() + " - " + o.companyname);
                ColorNode(o.OrderType, tn);
                if (Tools.Strings.StrExt(RunningIDs))
                    RunningIDs += ",'" + o.unique_id + "'";
                else
                    RunningIDs = "'" + o.unique_id + "'";
                RenderOrderTree(o.unique_id, tn);
            }
        }
        private void ColorNode(Enums.OrderType ot, TreeNode n)
        {
            switch (ot)
            {
                case Enums.OrderType.Quote:
                    n.ForeColor = Color.Blue;
                    break;
                case Enums.OrderType.Sales:
                    n.ForeColor = Color.Red;
                    break;
                case Enums.OrderType.Purchase:
                    n.ForeColor = Color.Green;
                    break;
                case Enums.OrderType.Invoice:
                    n.ForeColor = Color.Gold;
                    break;
                case Enums.OrderType.RMA:
                    n.ForeColor = Color.Purple;
                    break;
                case Enums.OrderType.VendRMA:
                    n.ForeColor = Color.Brown;
                    break;
                default:
                    n.ForeColor = Color.Black;
                    break;
            }
        }
        private void ClearOrders()
        {
            if (z_OrderMap == null)
                return;
            if (z_OrderMap.Maps == null)
                z_OrderMap.Maps = new ArrayList();
            //i don't think this is doing anything
            foreach (Control m in z_OrderMap.Maps)
            {
                Controls.Remove(m);
            }
            z_OrderMap.Maps = new ArrayList();

            //the controls are actually in pContents
            pContents.Controls.Clear();
        }
        //Control Events
        private void OrderMap_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvOrders_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                String s = (String)lvOrders.SelectedItems[0].Tag;
                ordhed o = ordhed.GetById(RzWin.Context, s);
                if (o != null)
                    RzWin.Context.Show(o);
            }
            catch { }
        }
        private void lblBreakUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (z_OrderMap == null)
                return;
            if (z_OrderMap.FinalIDCollection == null)
                return;

            if (z_OrderMap.FinalIDCollection.Count == 0)
                return;

            if (!RzWin.Leader.AreYouSure("break the deal links on these " + Tools.Number.LongFormat(z_OrderMap.FinalIDCollection.Count) + " orders"))
                return;

            ordhed.BreakUpDealsByOrderID(RzWin.Context, z_OrderMap.FinalIDCollection);
            RzWin.Leader.Tell("Done.");
        }
        //private void lnkPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    tv.Nodes.Clear();
        //    RunningIDs = "";
        //    if (z_OrderMap == null)
        //        return;
        //    if (z_OrderMap.ary == null)
        //        return;
        //    if (z_OrderMap.aLinks == null)
        //        return;
        //    if (z_OrderMap.ary.Count <= 0)
        //        return;
        //    if (z_OrderMap.aLinks.Count <= 0)
        //        return;
        //    PrintHelper print = new PrintHelper();
        //    ArrayList a = z_OrderMap.GetBaseOrders();
        //    foreach (OrderHandle o in a)
        //    {
        //        ordhed oh = ordhed.GetByID(Rz3App.xSys, o.strID);
        //        if (oh == null)
        //            continue;
        //        TreeNode n = tv.Nodes.Add("[" + oh.orderdate.ToShortDateString() + "]" + oh.ToString() + " - " + oh.companyname);
        //        ColorNode(oh.OrderType, n);
        //        if (Tools.Strings.StrExt(RunningIDs))
        //            RunningIDs += ",'" + oh.unique_id + "'";
        //        else
        //            RunningIDs = "'" + oh.unique_id + "'";
        //        RenderOrderTree(o.strID, n);
        //    }
        //    tv.ExpandAll();
        //    //print.PrintPreviewTree(tv, "Order Links");
        //    print.PrintTree(tv, "Order Links");
        //}

        private void chkIncludeVoid_Click(object sender, EventArgs e)
        {
            CompleteLoad(TheOrder, chkIncludeVoid.Checked);
        }
    }


}