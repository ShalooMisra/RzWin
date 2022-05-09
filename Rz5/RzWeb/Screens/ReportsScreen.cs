using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreWeb;
using Rz5;
using Core;
using Rz5.Web;

namespace RzWeb.Screens
{
    public class ReportsScreen : RzMenuScreen
    {
        public ReportsScreen(ContextRz context)
            : base(context)
        {

        }
        public override String Title(Context x)
        {
            return "Rz Reports";
        }
        protected override void InitSections(ContextRz context)
        {
            MenuSection s = new MenuSection("Sales and Profit");
            s.Contents.Add(new ActHandle(new Act("Profit", new ActHandler(context.Sys.TheProfitLogic.ProfitReportShow))));
            if (context.xUserRz.super_user)
                s.Contents.Add(new ActHandle(new Act("Sales Report", new ActHandler(context.Sys.TheProfitLogic.SalesLineReportShow))));
            s.Contents.Add(new ActHandle(new Act("Sales Forecast", new ActHandler(context.Sys.TheProfitLogic.SalesForecastShow))));
            s.Contents.Add(new ActHandle(new Act("Top Customers", new ActHandler(TopCustomersShow))));
            Sections.Add(s);

            s = new MenuSection("Inventory");
            s.Contents.Add(new ActHandle(new Act("Stock Value", new ActHandler(StockValueShow))));
            s.Contents.Add(new ActHandle(new Act("Inventory Allocation", new ActHandler(InventoryAllocationShow))));
            s.Contents.Add(new ActHandle(new Act("Incoming Inventory", new ActHandler(IncomingInventoryShow))));            
            Sections.Add(s);

            s = new MenuSection("Purchasing");
            s.Contents.Add(new ActHandle(new Act("Purchasing Detail", new ActHandler(PurchasingDetailShow))));
            s.Contents.Add(new ActHandle(new Act("Supplier Evaluation", new ActHandler(SupplierEvaluationShow))));
            s.Contents.Add(new ActHandle(new Act("Top Vendors", new ActHandler(TopVendorsShow))));
            Sections.Add(s);
        }
        public virtual void TopCustomersShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.TopCustomers(xrz), true);
        }
        public virtual void TopVendorsShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.TopVendors(xrz), true);
        }
        public virtual void StockValueShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new StockValueReport(xrz), true);
        }        
        public virtual void IncomingInventoryShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.IncomingInventory(xrz), true);
        }
        public virtual void InventoryAllocationShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.InventoryAllocation(xrz), true);
        }
        public virtual void PurchasingDetailShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.PurchaseReport(xrz), true);
        }
        public virtual void SupplierEvaluationShow(Context x, ActArgs args)
        {
            ContextRz xrz = (ContextRz)x;
            ((ILeaderRz)x.Leader).ReportShow(xrz, new Rz5.Reports.SupplierEvaluation(xrz), true);
        }
    }
}
