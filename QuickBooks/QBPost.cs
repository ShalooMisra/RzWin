using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class QBPost : UserControl
    {
        Enums.OrderType CurrentType;
        DateTime Cutoff = Tools.Dates.GetNullDate();
        ArrayList Orders;
        ContextNM TheContext;
        private int CopyColumn = -1;
        private int StatusColumn = -1;

        private ListViewItem CurrentItem = null;
        private QBOrderHandle CurrentHandle = null;
        int sortColumn = -1;
        ArrayList CurrentHandles;

        public QBPost()
        {
            InitializeComponent();
            throb.BackColor = throb.Parent.BackColor;
        }

        public void CompleteLoad(Enums.OrderType t)
        {
            CompleteLoad(t, RzWin.Form.TheContextNM);
        }
        public void CompleteLoad(Enums.OrderType t, ContextNM x)
        {
            TheContext = x;
            RzWin.Context.TheSysRz.TheQuickBooksLogic.GotStatus += new QBStatusHandler(QBInterface_GotStatus);
            dtCutoff.SetValue(DateTime.Parse("01/01/2011"));
            CurrentType = t;
            gb.Text = t.ToString();
            ConfigureHeaders();
            FillList();
        }
        void QBInterface_GotStatus(string s)
        {
            if (InvokeRequired)
            {
                SetStatusDelegate d = new SetStatusDelegate(ActualSetStatus);
                Invoke(d, new object[] { s });
            }
            else
                ActualSetStatus(s);
        }
        void ActualSetStatus(String s)
        {
            if (CurrentItem != null && CurrentHandle != null)
            {
                CurrentHandle.Status = s;
                UpdateItem(CurrentItem);
                lv.Refresh();
            }
        }
        private void ConfigureHeaders()
        {
            lv.Items.Clear();
            lv.Columns.Clear();

            lv.Columns.Add("Order#", gw(10));
            lv.Columns.Add("Date", gw(10));

            String strCompanyCaption = "";

            switch(CurrentType)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RMA:
                    strCompanyCaption = "Customer";
                    break;
                default:
                    strCompanyCaption = "Vendor";
                    break;
            }

            lv.Columns.Add(strCompanyCaption, gw(10));
            lv.Columns.Add("Terms", gw(5));
            lv.Columns.Add("Amount", gw(10), HorizontalAlignment.Right);

            switch(CurrentType)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                    lv.Columns.Add("Tracking", gw(10));
                    lv.Columns.Add("Copies", gw(5));
                    lv.Columns.Add("Comment", gw(15));
                    lv.Columns.Add("Status", gw(25));
                    CopyColumn = 5;
                    StatusColumn = 7;
                    chkNotifyCustomer.Visible = true;
                    break;
                case Enums.OrderType.RMA:
                case Enums.OrderType.Purchase:                    
                    lv.Columns.Add("Received", gw(10));
                    lv.Columns.Add("Inv Date", gw(5));
                    lv.Columns.Add("Inv #", gw(5));
                    lv.Columns.Add("Status", gw(50));
                    CopyColumn = -1;
                    StatusColumn = 8;
                    chkNotifyCustomer.Checked = false;
                    chkNotifyCustomer.Visible = false;
                    break;
                case Enums.OrderType.VendRMA:
                    lv.Columns.Add("Shipped", gw(10));
                    lv.Columns.Add("Status", gw(50));
                    CopyColumn = -1;
                    StatusColumn = 8;
                    chkNotifyCustomer.Checked = false;
                    chkNotifyCustomer.Visible = false;
                    break;
            }
        }
        private int gw(int x)
        {
            return Convert.ToInt32(Convert.ToDouble(lv.Width) * (Convert.ToDouble(x) / 100.0));
        }
        bool inhibit = false;
        private void FillList()
        {
            lv.Items.Clear();
            Orders = new ArrayList();

            lv.BeginUpdate();

            inhibit = true;
            try
            {

                DataTable d = RzWin.Context.Select(GetSQL());

                if (Tools.Data.DataTableExists(d))
                {
                    if (d.Rows.Count > 1000)
                    {
                        if (!RzWin.Leader.AskYesNo("There are " + Tools.Number.LongFormat(d.Rows.Count) + " documents to show.  Do you want to show them all?"))
                            d = null;
                    }
                }

                if (Tools.Data.DataTableExists(d))
                {
                    foreach (DataRow r in d.Rows)
                    {
                        QBOrderHandle h = new QBOrderHandle(CurrentType, nData.NullFilter_String(r["unique_id"]), nData.NullFilter_String(r["ordernumber"]), nData.NullFilter_Date(r["orderdate"]), nData.NullFilter_String(r["companyname"]), nData.NullFilter_String(r["trackingnumber"]), nData.NullFilter_String(r["terms"]), nData.NullFilter_Double(r["ordertotal"]), nData.NullFilter_Double(r["charged_amount"]), nData.NullFilter_Date(r[RzWin.Logic.QBInvoiceDateField]), nData.NullFilter_String(r[RzWin.Logic.QBInvoiceNumberField]), RzLogic.ConvertOrderType(nData.NullFilter_String(r["ordertype"])), nData.NullFilter_String(r["internalcomment"]));
                        Orders.Add(h);

                        ListViewItem i = lv.Items.Add("");
                        i.Checked = true;
                        i.Tag = h;
                        h.MyItem = i;

                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("");
                        i.SubItems.Add("");

                        switch (CurrentType)
                        {
                            case Enums.OrderType.Quote:
                            case Enums.OrderType.Sales:
                            case Enums.OrderType.Invoice:
                                i.SubItems.Add("");
                                i.SubItems.Add("");
                                i.SubItems.Add("");
                                break;
                            case Enums.OrderType.Purchase:
                            case Enums.OrderType.RMA:       
                                i.SubItems.Add("");
                                i.SubItems.Add("");
                                i.SubItems.Add("");
                                break;
                            case Enums.OrderType.VendRMA:
                                break;
                        }

                        UpdateItem(i);
                    }
                }
            }
            catch (Exception)
            {}

            inhibit = false;
            lv.EndUpdate();
            ShowTotals();
        }
        private void ShowTotals()
        {
            try
            {
                lblCount.Text = Tools.Number.LongFormat(lv.Items.Count) + " Documents";
                lblChecked.Text = Tools.Number.LongFormat(lv.CheckedItems.Count) + " Selected";
            }
            catch (Exception)
            { }
        }
        private void UpdateItem(ListViewItem i)
        {
            try
            {
                QBOrderHandle h = (QBOrderHandle)i.Tag;

                i.SubItems[0].Text = h.OrderNumber;
                i.SubItems[1].Text = h.OrderDate.Year.ToString() + "-" + Tools.Strings.Right("0" + h.OrderDate.Month.ToString(), 2) + "-" + Tools.Strings.Right("0" + h.OrderDate.Day.ToString(), 2);
                i.SubItems[2].Text = h.CompanyName;

                switch (CurrentType)
                {
                    case Enums.OrderType.Quote:
                    case Enums.OrderType.Sales:
                    case Enums.OrderType.Invoice:
                        String yn = "";
                        if (nTools.IsTermsCreditCard(h.Terms))
                        {
                            if (h.TotalCharged > 0)
                                yn = " (Y)";
                            else
                                yn = " (N)";
                        }

                        i.SubItems[3].Text = h.Terms + yn;
                        i.SubItems[4].Text = nTools.MoneyFormat(h.TotalAmount);
                        i.SubItems[5].Text = h.TrackingNumber;
                        i.SubItems[6].Text = h.Copies.ToString();
                        i.SubItems[7].Text = h.InternalComment;
                        i.SubItems[8].Text = h.Status;
                        break;
                    case Enums.OrderType.Purchase:
                    case Enums.OrderType.RMA:
                        i.SubItems[3].Text = h.Terms;
                        i.SubItems[4].Text = nTools.MoneyFormat(h.TotalAmount);
                        i.SubItems[5].Text = h.Received;
                        i.SubItems[6].Text = nTools.DateFormat(h.InvoiceDate);
                        i.SubItems[7].Text = h.InvoiceNumber;
                        i.SubItems[8].Text = h.Status;
                        break;
                    case Enums.OrderType.VendRMA:
                        i.SubItems[3].Text = h.Terms;
                        i.SubItems[4].Text = nTools.MoneyFormat(h.TotalAmount);
                        i.SubItems[5].Text = h.Received;
                        i.SubItems[6].Text = h.Status;
                        break;
                }
            }
            catch (Exception)
            { }
        }
        protected virtual string GetSelectSQL(String strIn)
        {
            return "select unique_id, ordernumber, orderdate, companyname, trackingnumber, terms, charged_amount, ordertotal, ordertype, internalcomment from ordhed where isnull(isvoid, 0) = 0 and isnull(onhold, 0) = 0 and ordertype in( " + strIn + " ) ";
        }
        private string GetSQL()
        {
            String strIn = "'" + CurrentType.ToString() + "'";
            if( CurrentType == Enums.OrderType.Purchase )
                strIn = "'purchase', 'service'";
            String strSQL = GetSelectSQL(strIn);           
            if (chkUnsent.Checked)
                strSQL += " and isnull(senttoqb, 0) = 0 ";
            if (Tools.Dates.DateExists(dtCutoff.GetValue_Date()))
                strSQL += " and orderdate >= cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(nTools.GetStartDate(dtCutoff.GetValue_Date(), Tools.CubeInterval.Day)) + "' as datetime) ";
            strSQL += " order by orderdate desc";
            return strSQL;
        }
        private void QBPost_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        public void DoResize()
        {
            try
            {
                gb.Top = 0;
                gb.Left = 0;
                gb.Height = this.ClientRectangle.Height;

                lv.Left = gb.Right;
                lv.Top = 0;
                lv.Width = this.ClientRectangle.Width - lv.Left;
                lv.Height = this.ClientRectangle.Height;
            }
            catch (Exception)
            { }
        }
        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            FillList();
        }
        private void cmdCheckAll_Click(object sender, EventArgs e)
        {
            CheckAll(true);
        }
        private void cmdCheckNone_Click(object sender, EventArgs e)
        {
            CheckAll(false);
        }
        private void CheckAll(bool b)
        {
            lv.BeginUpdate();
            foreach (ListViewItem i in lv.Items)
            {
                i.Checked = b;
            }
            lv.EndUpdate();
        }
        private void lv_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (inhibit)
                return;
            ShowTotals();
        }
        private void mnu_Opening(object sender, CancelEventArgs e)
        {
            switch (CurrentType)
            {
                case Enums.OrderType.Quote:
                case Enums.OrderType.Sales:
                case Enums.OrderType.Invoice:
                    mnuCopies.Visible = true;
                    break;
                default:
                    mnuCopies.Visible = false;
                    break;
            }

            switch (CurrentType)
            {
                case Enums.OrderType.Purchase:
                    mnuSendCustomer.Visible = true;
                    break;
                default:
                    mnuSendCustomer.Visible = false;
                    break;
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetCopies(1);
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SetCopies(2);
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SetCopies(3);
        }
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SetCopies(4);
        }
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SetCopies(5);
        }
        private void mnuEnterCopies_Click(object sender, EventArgs e)
        {
            SetCopies(-1);
        }
        private void SetCopies(int c)
        {
            ListViewItem i = null;
            QBOrderHandle h = null;

            try
            {
                i = lv.SelectedItems[0];
                if (i == null)
                    return;

                h = (QBOrderHandle)i.Tag;
                if (h == null)
                    return;
            }
            catch (Exception)
            { }

            if (c <= 0)
            {
                String s = RzWin.Leader.AskForString("Copies:", "2", "Copies");
                if (!Tools.Number.IsNumeric(s))
                    return;

                c = Convert.ToInt32(s);
                if (c <= 0)
                    return;
            }

            try
            {
                h.Copies = c;
                UpdateItem(i);
            }
            catch (Exception)
            {
            }
        }
        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowSelectedOrder();
        }
        private void ShowSelectedOrder()
        {
            QBOrderHandle h = GetSelectedHandle();
            if (h == null)
                return;

            ordhed o = ordhed.GetById(RzWin.Context, h.OrderID, h.type);
            if (o == null)
            {
                TheContext.TheLeader.TellTemp("This order could not be retreived from the database.");
                return;
            }

            TheContext.Show(o);
        }
        private QBOrderHandle GetSelectedHandle()
        {
            ListViewItem i = null;
            QBOrderHandle h = null;
            try
            {
                i = lv.SelectedItems[0];
                if (i == null)
                    return null;

                h = (QBOrderHandle)i.Tag;
                if (h == null)
                    return null;

                return h;

            }
            catch (Exception)
            { }
            return null;
        }
        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ordhed o = GetSelectedOrder();
            if (o == null)
                return;

            if (o.CompanyVar.RefGet(RzWin.Context) == null)
            {
                TheContext.TheLeader.TellTemp("The company for this order could not be retreived from the database.");
                return;
            }

            TheContext.Show(o.CompanyVar.RefGet(RzWin.Context));
        }
        private ordhed GetSelectedOrder()
        {
            QBOrderHandle h = GetSelectedHandle();
            if (h == null)
                return null;

            ordhed o = ordhed.GetById(RzWin.Context, h.OrderID, h.type);
            if (o == null)
            {
                TheContext.TheLeader.TellTemp("This order could not be retreived from the database.");
                return null;
            }
            return o;
        }
        private void mnuSendOrder_Click(object sender, EventArgs e)
        {
            ordhed o = GetSelectedOrder();
            if (o == null)
                return;

            SetCurrent();
            if (RzWin.Context.TheSysRz.TheQuickBooksLogic.SendOrder(RzWin.Context, (ordhed_new)o))
                CurrentItem.ForeColor = System.Drawing.Color.Blue;
            else
                CurrentItem.ForeColor = System.Drawing.Color.Red;
        }
        private void SetCurrent()
        {
            CurrentItem = null;
            CurrentHandle = null;
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                if (i == null)
                    return;

                QBOrderHandle h = (QBOrderHandle)i.Tag;
                if (h == null)
                    return;

                CurrentHandle = h;
                CurrentItem = i;
            }
            catch (Exception)
            { }
        }
        private void mnuSendCompany_Click(object sender, EventArgs e)
        {
            ordhed o = GetSelectedOrder();
            if (o == null)
                return;

            if( o.CompanyVar.RefGet(RzWin.Context) == null )
                return;

            SetCurrent();
            RzWin.Context.TheSysRz.TheQuickBooksLogic.MakeCompanyExist(RzWin.Context, o);
        }
        private void cmdSendCustomer_Click(object sender, EventArgs e)
        {
            ordhed o = GetSelectedOrder();
            if (o == null)
                return;

            ordhed sale = o.GetRelatedSale(RzWin.Context);
            if (sale == null)
            {
                TheContext.TheLeader.TellTemp("The related sales order for this document could not be located.");
                return;
            }

            if (sale.CompanyVar.RefGet(RzWin.Context) == null)
                return;

            SetCurrent();
            RzWin.Context.TheSysRz.TheQuickBooksLogic.MakeCompanyExist(RzWin.Context, sale);
        }
        private void cmdPost_Click(object sender, EventArgs e)
        {
            if (bg.IsBusy)
                return;

            PostSelected();
        }
        ContextRz contextEvent;
        Leader leaderEvent;
        private void PostSelected()
        {
            bool b = RzWin.Context.TheSysRz.TheQuickBooksLogic.Connect(RzWin.Context);
            RzWin.Context.TheSysRz.TheQuickBooksLogic.Disconnect();

            if( !b )
                return;

            CurrentHandles = new ArrayList();

            contextEvent = (ContextRz)RzWin.Context.Clone();
            leaderEvent = new Leader();
            contextEvent.TheLeader = leaderEvent;
            leaderEvent.StatusSet += new StatusSetHandler(ev_StatusSet);
            
            foreach (ListViewItem i in lv.CheckedItems)
            {
                CurrentItem = i;
                CurrentHandle = (QBOrderHandle)i.Tag;

                ordhed o = ordhed.GetById(TheContext, CurrentHandle.OrderID);
                if (o == null)
                {
                    CurrentHandle.Status = "This order couldn't be retreived from the database.";
                    CurrentItem.ForeColor = System.Drawing.Color.Red;
                    UpdateItem(CurrentItem);
                }
                else
                {
                    if (!o.ShouldSendToQB(contextEvent))
                    {
                        //already sent
                        i.ForeColor = System.Drawing.Color.Blue;
                        CurrentHandle.Status = o.ToString() + " has already been sent to Quickbooks.";
                        UpdateItem(i);
                    }
                    else
                    {
                        CurrentItem.ForeColor = System.Drawing.Color.Green;
                        CurrentHandles.Add((QBOrderHandle)i.Tag);
                    }
                }
            }

            throb.ShowThrobber();
            bg.RunWorkerAsync();
        }
        void ev_StatusSet(string s, Color c)
        {
            //CurrentHandle.Status = s;
        }
        private void cmdInvoices_Click(object sender, EventArgs e)
        {
            CompleteLoad(Enums.OrderType.Invoice);
        }
        private void cmdPurchases_Click(object sender, EventArgs e)
        {
            CompleteLoad(Enums.OrderType.Purchase);
        }
        private void cmdRMAs_Click(object sender, EventArgs e)
        {
            CompleteLoad(Enums.OrderType.RMA);
        }
        private void cmdVendorRMAs_Click(object sender, EventArgs e)
        {
            CompleteLoad(Enums.OrderType.VendRMA);
        }
        private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column != sortColumn)
            {
                // Set the sort column to the new column.
                sortColumn = e.Column;
                // Set the sort order to ascending by default.
                lv.Sorting = SortOrder.Ascending;
            }
            else
            {
                // Determine what the last sort order was and change it.
                if (lv.Sorting == SortOrder.Ascending)
                    lv.Sorting = SortOrder.Descending;
                else
                    lv.Sorting = SortOrder.Ascending;
            }

            lv.ListViewItemSorter = new NewMethod.ListViewItemComparer(e.Column, lv.Sorting, (Int32)FieldType.String);
            lv.Sort();
        }
        private void lv_DoubleClick(object sender, EventArgs e)
        {
            ShowSelectedOrder();
        }
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            DoChecked("print");
        }
        private void DoChecked(String strCommand)
        {
            ArrayList a = GetCheckedOrders();
            if (a.Count <= 0)
            {
                TheContext.TheLeader.TellTemp("Please select (by checking the box) at least 1 order before continuing.");
                return;
            }
            if (!RzWin.Leader.AreYouSure(strCommand + " " + Tools.Number.LongFormat(a.Count) + " orders"))
                return;
            ActArgs args = new ActArgs(TheContext, strCommand);
            args.TheItems = new ItemsInstance();
            foreach (nObject o in a)
            {
                args.TheItems.Add(TheContext, o);
            }
            ((SysRz5)TheContext.xSys).TheOrderLogic.ActInstance((ContextRz)TheContext, args);
        }
        public ArrayList GetCheckedOrders()
        {
            ArrayList a = new ArrayList();
            foreach (ListViewItem i in lv.CheckedItems)
            {
                QBOrderHandle h = (QBOrderHandle)i.Tag;
                if (h != null)
                {
                    ordhed o = ordhed.GetById(RzWin.Context, h.OrderID, h.type);
                    if (o != null)
                    {
                        o.TempCopyCount = h.Copies;
                        a.Add(o);
                    }
                }
            }
            return a;
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                foreach (QBOrderHandle h in CurrentHandles)
                {
                    ordhed o = ordhed.GetById(TheContext, h.OrderID);
                    if (o != null)
                    {
                        CurrentHandle = h;
                        CurrentHandle.Passed = RzWin.Context.TheSysRz.TheQuickBooksLogic.SendOrder(contextEvent, (ordhed_new)o);
                        bg.ReportProgress(0);
                    }
                }
            }
            catch { }
        }
        private void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throb.HideThrobber();
            leaderEvent.StatusSet -= new StatusSetHandler(ev_StatusSet);
            leaderEvent = null;
        }
        private void bg_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                if (CurrentHandle.Passed)
                    CurrentHandle.MyItem.ForeColor = Color.Blue;
                else
                    CurrentHandle.MyItem.ForeColor = Color.Red;

                UpdateItem(CurrentHandle.MyItem);
            }
            catch (Exception)
            { }
        }
        private void cmdDate_Click(object sender, EventArgs e)
        {
            String s = RzWin.Leader.AskForString("Cutoff Date", nTools.DateFormat(System.DateTime.Now), "Cutoff Date");
            if (!Tools.Dates.IsDate(s))
                return;
            dtCutoff.SetValue(DateTime.Parse(s));
        }
    }

    public class QBOrderHandle
    {
        public String OrderID = "";
        public DateTime OrderDate;
        public String CompanyName = "";
        public String TrackingNumber = "";
        public int Copies = 1;
        public String Status = "";
        public String OrderNumber = "";
        public String Terms = "";
        public Double TotalAmount = 0;
        public String Received = "";
        public double TotalCharged = 0;
        public DateTime InvoiceDate;
        public String InvoiceNumber = "";
        public bool Passed = false;
        public ListViewItem MyItem;
        public Enums.OrderType type;
        public String InternalComment;

        public QBOrderHandle(Enums.OrderType ot, String oid, String ordernumber, DateTime d, String strCompany, String strTracking, String strTerms, Double dblTotal, Double dblCharged, DateTime dtInvoice, String strInvoiceNumber, Enums.OrderType actual_order_type, String strComment)
        {
            OrderID = oid;
            OrderNumber = ordernumber;
            OrderDate = d;
            CompanyName = strCompany;
            TrackingNumber = strTracking;
            Terms = strTerms;
            TotalAmount = dblTotal;
            TotalCharged = dblCharged;
            InvoiceDate = dtInvoice;
            InvoiceNumber = strInvoiceNumber;
            type = actual_order_type;
            InternalComment = strComment;

            int ordered = 0;
            int filled = 0;

            switch(ot)
            {
                case Enums.OrderType.Invoice:
                    if( nTools.IsTermsCreditCard(strTerms) )
                    {
                        if (TotalCharged > 0)
                            strTerms += " ( Y )";
                        else
                            strTerms += " ( N )";
                    }
                    break;
                case Enums.OrderType.Purchase:
                    
                    ordered = RzWin.Context.SelectScalarInt32("select sum(quantity) from orddet_line where orderid_purchase = '" + OrderID + "' and isnull(was_received, 0) = 0");
                    filled = RzWin.Context.SelectScalarInt32("select sum(quantity) from orddet_line where orderid_purchase = '" + OrderID + "' and isnull(was_received, 0) = 1");

                    if( filled == 0 )
                        Received = "N";
                    else if( ordered > 0 )
                        Received = "P";
                    else if( ordered == 0 )
                        Received = "C";
                    else
                        Received = "O";
   
                    break;

                case Enums.OrderType.RMA:
                    ordered = RzWin.Context.SelectScalarInt32("select sum(quantity) from orddet_line where orderid_rma = '" + OrderID + "' and isnull(was_rma_received, 0) = 0");
                    filled = RzWin.Context.SelectScalarInt32("select sum(quantity) from orddet_line where orderid_rma = '" + OrderID + "' and isnull(was_rma_received, 0) = 1");

                    if( filled == 0 )
                        Received = "N";
                    else if( ordered > 0 )
                        Received = "P";
                    else if( ordered == 0 )
                        Received = "C";
                    else
                        Received = "O";
   
                    break;

                case Enums.OrderType.VendRMA:
                    ordered = RzWin.Context.SelectScalarInt32("select sum(quantity) from orddet_line where orderid_vendrma = '" + OrderID + "' and isnull(was_vendrma_shipped, 0) = 0");
                    filled = RzWin.Context.SelectScalarInt32("select sum(quantity) from orddet_line where orderid_vendrma = '" + OrderID + "' and isnull(was_vendrma_shipped, 0) = 1");

                    if( filled == 0 )
                        Received = "N";
                    else if( ordered > 0 )
                        Received = "P";
                    else if( ordered == 0 )
                        Received = "C";
                    else
                        Received = "O";
   
                    break;

                    //DataTable dt = Rz3App.RzWin.Context.Select("select sum(quantityordered), sum(quantityfilled) from orddet where base_ordhed_uid = '" + OrderID + "'");
                    //DataRow r = dt.Rows[0];
                    //long ordered = nData.NullFilter_Long(r[0]);
                    //long filled = nData.NullFilter_Long(r[1]);

                    //if( filled == 0 )
                    //    Received = "N";
                    //else if( filled < ordered )
                    //    Received = "P";
                    //else if( filled == ordered )
                    //    Received = "C";
                    //else
                    //    Received = "O";
   
                    //break;
            }
        }
    }
}
