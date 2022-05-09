using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;
using Core;
using Rz5.Enums;

namespace Rz5.Win.Screens
{
    public partial class TestRzScreen : UserControl
    {
        public TestRzScreen()
        {
            InitializeComponent();
            lblResult.Text = "";

            //if (!DesignMode)
            //{
            //    if (RzWin.Context != null)
            //        Init();
            //}
        }

        public virtual void Init()
        {
            txtClass.Text = RzWin.Context.xUser.GetSetting(RzWin.Context, "auto_open_item_class");
            txtId.Text = RzWin.Context.xUser.GetSetting(RzWin.Context, "auto_open_item_id");
        }

        private void cmdSingleQuote_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.Sys.ProofLogic.QuoteCreate(RzWin.Context, 1));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdMultiQuote_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.Sys.ProofLogic.QuoteCreate(RzWin.Context, 4));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdQuote_Click(object sender, EventArgs e)
        {
           
        }

        private void cmdSalesOrder_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.SalesOrderToComplete(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdBatchDisplayTest_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.TheSysRz.ProofLogic.OrderBatchTest(RzWin.Context, 10, 5);
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdNewServiceOrder_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.ServiceOrderCreate(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdShippedInvoice_Click(object sender, EventArgs e)
        {
            ShippedInvoice();
        }

        protected void ShippedInvoice()
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.InvoiceShipped(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        protected void InterruptedShipment(StockType type = StockType.Stock)
        {
            RzWin.Context.TheLeader.FastForwardStart();

            ordhed_invoice invoice = null;
            if (type == StockType.Stock)
                invoice = RzWin.Context.TheSysRz.ProofLogic.InterruptedShipment(RzWin.Context, type);
            else
            {
                ordhed_sales sale = RzWin.Context.TheSysRz.ProofLogic.SalesOrder(RzWin.Context, type: Rz5.Enums.StockType.Consign, lines: 3);
                foreach (orddet_line l in sale.DetailsVar.RefsList(RzWin.Context))
                {
                    l.StockType = StockType.Consign;
                    l.lotnumber = "14";
                    l.Update(RzWin.Context);
                }

                invoice = sale.MakeInvoice(RzWin.Context, sale.DetailsVar.RefsList(RzWin.Context))[0];
                invoice.FakeFill(RzWin.Context);
                invoice.Ship(RzWin.Context, 2);
            }

            invoice = ordhed_invoice.GetById(RzWin.Context, invoice.unique_id);
            RzWin.Context.Show(invoice);
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        protected void InterruptedReceive()
        {
            RzWin.Context.TheLeader.FastForwardStart();
            ordhed_purchase interrupted = RzWin.Context.TheSysRz.ProofLogic.InterruptedReceive(RzWin.Context);

            //we know it was interrupted and that the values in memory conflict with the database, so re-load the order
            interrupted = ordhed_purchase.GetById(RzWin.Context, interrupted.unique_id);
            RzWin.Context.Show(interrupted);

            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdPutAwayPO_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.PurchasePutAway(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdSalesOrderToShip_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.SalesOrderToShip(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdOpenPO_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.PurchaseCreate(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdInvoiceToPack_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.InvoiceToPack(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdInvoiceToShip_Click(object sender, EventArgs e)
        {
            InvoiceToShip();
        }

        protected void InvoiceToShip()
        {try
            {
                RzWin.Context.TheLeader.FastForwardStart();
                RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.InvoiceToShip(RzWin.Context));
                RzWin.Context.TheLeader.FastForwardEnd();
            }
            catch(Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
           
        }

        private void cmdStockInvoiceToPack_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.InvoiceStock(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmRMAToRecieve_Click(object sender, EventArgs e)
        {
            OpenRMA();
        }

        protected void OpenRMA()
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.RMAToReceive(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        protected void RMAReceivedCredit()
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.RMAReceivedCredit(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdRMAReceived_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.RMAReceived(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdVendRMAReadyToShip_Click(object sender, EventArgs e)
        {
            OpenVRMA();
        }

        protected void OpenVRMA()
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.VendRMAToShip(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdShippedVRMA_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.VendRMAShipped(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

        private void cmdOrderProcess_Click(object sender, EventArgs e)
        {
            Core.ProveResult r = RzWin.Context.TheSysRz.ProofLogic.Prove(RzWin.Context);
            lblResult.Text = "Done: " + Tools.Dates.FormatHMS(r.Duration.TotalSeconds);
            if (r.Passed)           
                lblResult.ForeColor = Color.Green;
            else
                lblResult.ForeColor = Color.Red;
            Tools.FileSystem.PopText(r.ToString());
        }

        private void cmdOpen_Click(object sender, EventArgs e)
        {
            RzWin.Context.xUser.SetSetting(RzWin.Context, "auto_open_item_class", txtClass.Text);
            RzWin.Context.xUser.SetSetting(RzWin.Context, "auto_open_item_id", txtId.Text);

            AutoShow();
        }

        void AutoShow()
        {
            if (!Tools.Strings.StrExt(txtClass.Text) || !Tools.Strings.StrExt(txtId.Text))
                return;

            nObject x = (nObject)RzWin.Context.GetById(txtClass.Text, txtId.Text);
            if (x == null)
            {
                RzWin.Context.TheLeader.Error("Not found");
                return;
            }

            RzWin.Context.Show(x);
        }

        private void cmdX_Click(object sender, EventArgs e)
        {
            Reports.SalesReport r = new Reports.SalesReport(RzWin.Context);
            RzWin.Context.TheLeaderRz.ReportShow(RzWin.Context, r, false);
        }

        private void lblSmoothOrders_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //String numbers = RzWin.Context.TheLeader.AskForString("Numbers", "", true);
            //if (!Tools.Strings.StrExt(numbers))
            //    return;
            //String type = RzWin.Context.TheLeader.AskForString("Type");
            //if (!Tools.Strings.StrExt(type))
            //    return;

            if (!RzWin.Context.TheLeader.AreYouSure("smooth all of the order numbers"))
                return;

            foreach (Enums.OrderType t in ordhed.OrderTypes)
            {
                SmoothOrders(t);
            }

            RzWin.Context.TheLeader.Tell("Done");
        }

        void SmoothOrders(Enums.OrderType t)
        {
            ArrayList a = RzWin.Context.SelectScalarArray("select ordernumber, count(*), max(orderdate) from ordhed_" + t.ToString().ToLower() + " group by ordernumber having count(*) > 1 order by max(orderdate)");
            List<String> numbers = new List<string>();
            foreach (String s in a)
            {
                numbers.Add(s);
            }

            SmoothOrders(numbers, t.ToString().ToLower());
        }

        void SmoothOrders(List<String> numbers, String type)
        {
            foreach (String s in numbers)  //Tools.Strings.SplitLines(Tools.Strings.KillBlankLines(numbers))
            {
                NumberA(s, type);
            }
        }

        void NumberA(String number, String type)
        {
            ArrayList ids = RzWin.Context.SelectScalarArray("select unique_id from ordhed_" + type + " where ordernumber > '' and ordernumber = '" + number + "' order by orderdate");
            if (ids.Count == 0)
            {
                RzWin.Context.TheLeader.Tell("No results: " + number);
                return;
            }

            if (ids.Count == 1)
            {
                RzWin.Context.TheLeader.Tell("1 result: " + number);
                return;
            }


            for (int i = 1; i < ids.Count; i++)
            {
                String next = number + "-" + i.ToString();

                if (!Tools.Strings.StrExt(next))
                    return;

                RzWin.Context.Execute("update ordhed_" + type + " set ordernumber = '" + next + "' where unique_id = '" + ids[i] + "'");
                RzWin.Context.Execute("update orddet_line set ordernumber_" + type + " = '" + next + "' where orderid_" + type + " = '" + ids[i] + "'");
            }
        }

        private void cmdSaleToPack_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.FastForwardStart();
            RzWin.Context.Show(RzWin.Context.TheSysRz.ProofLogic.SalesOrderToComplete(RzWin.Context));
            RzWin.Context.TheLeader.FastForwardEnd();
        }

       
    }
}
