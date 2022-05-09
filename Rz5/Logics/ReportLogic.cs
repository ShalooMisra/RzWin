using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public class ReportLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup acts)
        {
            ContextRz xrz = (ContextRz)x;
            if (!xrz.xUser.SuperUser)
            {
                if (!xrz.TheSysRz.ThePermitLogic.CheckPermit(xrz, Permissions.ThePermits.ViewReports, ((ContextRz)x).xUser))
                    return;
            }
            //This line initiates the main level (Reports) and established ActHanles below it (h)
            ActHandle h = new ActHandle(new Act("Reports", new ActHandler(ReportsShow)));
            acts.Add(h);
            //Here we instantiate the Profit choice on reports dropdown, and assign a new eventhandler that references ProfitLogic (ProfitReportShow).  Unlike the other handlers, this doesn't exist in ReportLogic.cs so it's referenced via "xrz.Sys.TheProfitLogic.ProfitReportShow"
            ActHandle profitReport = new ActHandle(new Act("Profit", new ActHandler(xrz.Sys.TheProfitLogic.ProfitReportShow)));
            //This adds the intantiated report to the list "SubActs" - rendering it int he view
            h.SubActs.Add(profitReport);
            ActHandle ah = null;
            //if (xrz.TheLeaderRz.IsWeb())
            //{
            //    ah = new ActHandle(new Act("Sales Report", new ActHandler(SalesLineReportShow)));
            //    h.SubActs.Add(ah);
            //}
            //KT Removing the isWeb check
            ah = new ActHandle(new Act("Sales Report", new ActHandler(SalesLineReportShow)));
            h.SubActs.Add(ah);
            //End KT

            ah = new ActHandle(new Act("Sales Forecast", new ActHandler(SalesForecastShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Top Customers", new ActHandler(TopCustomersShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Inventory Value", new ActHandler(StockValueShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Inventory Allocation", new ActHandler(InventoryAllocationShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Incoming Inventory", new ActHandler(IncomingInventoryShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Purchasing Detail", new ActHandler(PurchasingDetailShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Supplier Evaluation", new ActHandler(SupplierEvaluationShow)));
            h.SubActs.Add(ah);
            ah = new ActHandle(new Act("Top Vendors", new ActHandler(TopVendorsShow)));
            h.SubActs.Add(ah);
            //KT Here I attempt to add customer Invoice Report to the reports list
            ah = new ActHandle(new Act("Customer Invoice Report", new ActHandler(CustomerInvoiceReportShow)));
            h.SubActs.Add(ah);


        }
        protected void SalesLineReportShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.SalesLineReport(xrz), true);
        }
        protected void InventoryAllocationShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.InventoryAllocation(xrz), true);
        }
        protected void IncomingInventoryShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.IncomingInventory(xrz), true);
        }
        protected void SalesForecastShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.SalesForecast(xrz), true);
        }
        protected void TopCustomersShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.TopCustomers(xrz), true);
        }
        protected void TopVendorsShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.TopVendors(xrz), true);
        }
        protected void StockValueShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new StockValueReport(xrz), true);
        }
        protected void PurchasingDetailShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.PurchaseReport(xrz), true);
        }
        protected void SupplierEvaluationShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.SupplierEvaluation(xrz), true);
        }
        //KT - This is the handler for the CUstomer Invoice Report - Working, now just need to point it to the actual Customer Invoice Report
        protected void CustomerInvoiceReportShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.CustomerInvoiceReport(xrz), false);
        }



        public void ReportsShow(Context x, ActArgs args)
        {
            ((ContextRz)x).TheLeaderRz.ReportsShow((ContextRz)x);
        }
    }
}