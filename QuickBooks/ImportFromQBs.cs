using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ImportFromQBs : UserControl
    {
        //Private Variables
        //Constructors
        public ImportFromQBs()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad()
        {
            ctlQBDate.DoResize();
            chkRemoveOrders.Visible = false;
            if (Tools.Strings.HasString(RzWin.Context.TheData.TheKeySql.DatabaseName, "recent") || Tools.Strings.HasString(RzWin.Context.TheData.TheKeySql.DatabaseName, "test"))
                chkRemoveOrders.Visible = true;
        }
        //Private Functions
        private void RunImport(DoWorkEventArgs e)
        {
            QBArgs args = (QBArgs)e.Argument;
            switch (args.ImportType.ToLower().Trim())
            {
                case "company":
                    QBCompanyImport(RzWin.Context);
                    break;
                case "jcompany":
                    QBJustCompanyImport();
                    break;
                case "sales":
                    QBSalesImport(args.RemoveOrders, args.CutOffDate);
                    break;
                case "purchase":
                    QBPurchaseImport(args.RemoveOrders, args.CutOffDate);
                    break;
                case "invoice":
                    QBInvoiceImport(args.RemoveOrders, args.CutOffDate);
                    break;
                case "both":
                    QBPurchaseImport(args.RemoveOrders, args.CutOffDate);
                    QBInvoiceImport(args.RemoveOrders, args.CutOffDate);
                    break;
                case "allorders":
                    QBSalesImport(args.RemoveOrders, args.CutOffDate);
                    QBPurchaseImport(args.RemoveOrders, args.CutOffDate);
                    QBInvoiceImport(args.RemoveOrders, args.CutOffDate);
                    break;
                case "bills":
                    QBBillImport(args.RemoveOrders, args.CutOffDate);
                    break;
            }
        }
        private void QBBillImport(Boolean bRemove, DateTime date_cutoff)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("purchase");
                RzWin.Context.TheLeader.TellTemp("Starting Import.");
                RzWin.Leader.Comment("Gathering Bills From QBs");
                ArrayList purchases = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetBillCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("Bill Import Complete");
                RzWin.Context.TheLeader.TellTemp("Bill Import Complete");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Context.TheLeader.Tell("Error: " + ee.Message);
            }
        }
        private void QBPurchaseImport(Boolean bRemove, DateTime date_cutoff)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("purchase");
                RzWin.Context.TheLeader.TellTemp("Starting Import.");
                RzWin.Leader.Comment("Gathering Purchase Orders From QBs");
                ArrayList purchases = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetPurchaseOrderCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("PO Import Complete");
                RzWin.Context.TheLeader.TellTemp("PO Import Complete");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Context.TheLeader.Tell("Error: " + ee.Message);
            }
        }
        private void QBInvoiceImport(Boolean bRemove, DateTime date_cutoff)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("invoice");
                RzWin.Context.TheLeader.TellTemp("Starting Import.");
                RzWin.Leader.Comment("Gathering Invoices From QBs");
                ArrayList invoices = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetInvoiceOrderCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("Done.");
                RzWin.Context.TheLeader.TellTemp("Invoice Import Complete.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Context.TheLeader.Tell("Error: " + ee.Message);
            }
        }
        private void QBCompanyImport(ContextRz context)
        {
            try
            {
                RzWin.Leader.Comment("Gathering Company List From QBs");
                ArrayList comp = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetCompanyCollection(RzWin.Context);
                RzWin.Leader.Comment("Gathering Vendor List From QBs");
                ArrayList vend = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetVendorCollection(RzWin.Context);
                ArrayList all = MergeArrayLists(comp, vend);
                RzWin.Leader.Comment("Finished Merging Lists; Importing..");
                foreach (company c in all)
                {
                    company ex = company.FindACompany(RzWin.Context, c.companyname, c.primaryphone, c.primaryfax, c.primaryemailaddress);
                    if (ex != null)
                    {
                        RzWin.Leader.Comment("Updating information for company : " + ex.companyname);
                        UpdateCompanyInfo(ex, c);
                        continue;
                    }
                    RzWin.Leader.Comment("Adding company : " + c.companyname);
                    c.source = "QB Import" + DateTime.Now.ToString();
                    context.Update(c);
                    if (Tools.Strings.StrExt(c.primarycontact))
                    {
                        companycontact cc = (companycontact)context.QtO("companycontact", "select * from companycontact where base_company_uid = '" + c.unique_id + "' and contactname = '" + context.Filter(c.primarycontact) + "'");
                        if (cc == null)
                        {
                            cc = companycontact.New(context);
                            cc.base_company_uid = c.unique_id;
                            cc.base_mc_user_uid = c.base_mc_user_uid;
                            cc.companyname = c.companyname;
                            cc.contactname = c.primarycontact;
                            cc.primaryphone = c.primaryphone;
                            cc.primaryfax = c.primaryfax;
                            cc.primaryemailaddress = c.primaryemailaddress;
                            cc.is_qbimport = true;
                            context.Insert(cc);
                        }
                    }
                    if (c.QB_BillingAddress != null)
                    {
                        c.QB_BillingAddress.base_company_uid = c.unique_id;
                        context.Update(c.QB_BillingAddress);
                    }
                    if (c.QB_ShippingAddress != null)
                    {
                        c.QB_ShippingAddress.base_company_uid = c.unique_id;
                        context.Update(c.QB_ShippingAddress);
                    }
                }

                context.TheLeaderRz.CacheCompanies();
                //RzApp.CacheCompanies(RzWin.Context);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void QBJustCompanyImport()
        {
            try
            {
                RzWin.Leader.Comment("Gathering Company List From QBs");
                ArrayList comp = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetCompanyCollection(RzWin.Context);
                RzWin.Leader.Comment("Finished Merging Lists; Importing..");
                foreach (company c in comp)
                {
                    company ex = company.FindACompany(RzWin.Context, c.companyname, c.primaryphone, c.primaryfax, c.primaryemailaddress);
                    if (ex != null)
                    {
                        RzWin.Leader.Comment("Updating information for company : " + ex.companyname);
                        UpdateCompanyInfo(ex, c);
                        continue;
                    }
                    RzWin.Leader.Comment("Adding company : " + c.companyname);
                    c.source = "QB Import" + DateTime.Now.ToString();
                    c.Update(RzWin.Context);
                    if (Tools.Strings.StrExt(c.primarycontact))
                    {
                        companycontact cc = (companycontact)RzWin.Context.QtO("companycontact", "select * from companycontact where base_company_uid = '" + c.unique_id + "' and contactname = '" + c.primarycontact + "'");
                        if (cc == null)
                        {
                            cc = companycontact.New(RzWin.Context);
                            cc.base_company_uid = c.unique_id;
                            cc.base_mc_user_uid = c.base_mc_user_uid;
                            cc.companyname = c.companyname;
                            cc.contactname = c.primarycontact;
                            cc.primaryphone = c.primaryphone;
                            cc.primaryfax = c.primaryfax;
                            cc.primaryemailaddress = c.primaryemailaddress;
                            cc.is_qbimport = true;
                            cc.Insert(RzWin.Context);
                        }
                    }
                    if (c.QB_BillingAddress != null)
                    {
                        c.QB_BillingAddress.base_company_uid = c.unique_id;
                        c.QB_BillingAddress.Update(RzWin.Context);
                    }
                    if (c.QB_ShippingAddress != null)
                    {
                        c.QB_ShippingAddress.base_company_uid = c.unique_id;
                        c.QB_ShippingAddress.Update(RzWin.Context);
                    }
                }
                RzWin.Logic.CacheCompanies(RzWin.Context);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
            }
        }
        private void QBSalesImport(Boolean bRemove, DateTime date_cutoff)
        {
            try
            {
                if (bRemove)
                    RemoveRzOrders("sales");
                RzWin.Leader.Comment("Gathering Sales Orders From QBs");
                ArrayList sales = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetSalesOrderCollection(RzWin.Context, date_cutoff);
                RzWin.Leader.Comment("Done.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Leader.Tell("Error: " + ee.Message);
            }
        }
        private void ImportPayChargeToQBs()
        {
            try
            {
                QBPaymentChargeImport q = new QBPaymentChargeImport();
                q.CompleteLoad();
                RzWin.Form.TabShow(q, "QB Payment/Charges Import");
            }
            catch { }
        }
        private void RemoveRzOrders(String type)
        {
            if (!Tools.Strings.StrExt(type))
                return;

            String SQL = "delete from ordhed_" + type + " where ordertype = '" + type + "'";
            RzWin.Context.Execute(SQL);
            SQL = "delete from orddet_" + type + " where ordertype = '" + type + "'";
            RzWin.Context.Execute(SQL);
        }
        private ArrayList MergeArrayLists(ArrayList a, ArrayList b)
        {
            ArrayList z = new ArrayList();
            foreach (object o in a)
            {
                z.Add(o);
            }
            foreach (object o in b)
            {
                z.Add(o);
            }
            return z;
        }
        private void UpdateCompanyInfo(company a, company b)
        {
            try
            {
                if (a == null || b == null)
                    return;
                if (!Tools.Strings.StrExt(a.primarycontact))
                    a.primarycontact = b.primarycontact;
                if (!Tools.Strings.StrExt(a.primaryphone))
                    a.primaryphone = b.primaryphone;
                if (!Tools.Strings.StrExt(a.primaryfax))
                    a.primaryfax = b.primaryfax;
                if (!Tools.Strings.StrExt(a.primaryemailaddress))
                    a.primaryemailaddress = b.primaryemailaddress;
                if (!Tools.Strings.StrExt(a.termsascustomer))
                    a.termsascustomer = b.termsascustomer;
                if (!Tools.Strings.StrExt(a.termsasvendor))
                    a.termsasvendor = b.termsasvendor;
                if (a.creditascustomer <= 0)
                    a.creditascustomer = b.creditascustomer;
                if (a.creditasvendor <= 0)
                    a.creditasvendor = b.creditasvendor;
                if (!Tools.Strings.StrExt(a.notetext))
                    a.notetext = b.notetext;
                a.Update(RzWin.Context);
            }
            catch (Exception ee)
            {
                RzWin.Leader.Comment("Error: " + ee.Message);
                RzWin.Context.TheLeader.Tell("Error: " + ee.Message);
            }
        }
        //Buttons
        private void cmdImportAllOrders_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            QBArgs q = new QBArgs();
            q.ImportType = "allorders";
            q.RemoveOrders = chkRemoveOrders.Checked;
            q.CutOffDate = ctlQBDate.GetValue_Date();
            bgImport.RunWorkerAsync(q);
        }
        private void cmcQBCompanyImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            QBArgs q = new QBArgs();
            q.ImportType = "company";
            bgImport.RunWorkerAsync(q);
        }
        private void cmcQBPurchaseImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            QBArgs q = new QBArgs();
            q.ImportType = "purchase";
            q.RemoveOrders = chkRemoveOrders.Checked;
            q.CutOffDate = ctlQBDate.GetValue_Date();
            bgImport.RunWorkerAsync(q);
        }
        private void cmdQBInvoiceImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            QBArgs q = new QBArgs();
            q.ImportType = "invoice";
            q.RemoveOrders = chkRemoveOrders.Checked;
            q.CutOffDate = ctlQBDate.GetValue_Date();
            bgImport.RunWorkerAsync(q);
        }
        private void cmcQBSalesImport_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            QBArgs q = new QBArgs();
            q.ImportType = "sales";
            q.RemoveOrders = chkRemoveOrders.Checked;
            q.CutOffDate = ctlQBDate.GetValue_Date();
            bgImport.RunWorkerAsync(q);
        }
        private void cmdImportPayChargeToQBs_Click(object sender, EventArgs e)
        {
            ImportPayChargeToQBs();
        }
        private void cmdTestQB_Click(object sender, EventArgs e)
        {
            RzWin.Context.TheLeader.Tell((RzWin.Context.TheSysRz.TheQuickBooksLogic.CheckConnect(RzWin.Context) ? "Connection == True" : "Connection == False"));
        }
        private void cmdImportBills_Click(object sender, EventArgs e)
        {
            if (bgImport.IsBusy)
                return;
            RzWin.Leader.StartPopStatus();
            QBArgs q = new QBArgs();
            q.ImportType = "bills";
            q.RemoveOrders = chkRemoveOrders.Checked;
            q.CutOffDate = ctlQBDate.GetValue_Date();
            bgImport.RunWorkerAsync(q);
        }
        //Background Workers
        private void bgImport_DoWork(object sender, DoWorkEventArgs e)
        {
            RunImport(e);
        }
        private void bgImport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RzWin.Leader.StopPopStatus(true);
            RzWin.Context.TheLeader.Tell("Import Completed!");
        }
        //Private Classes
        private class QBArgs
        {
            public string ImportType = "";
            public bool RemoveOrders = false;
            public DateTime CutOffDate = Tools.Dates.GetNullDate();
        }
    }
}
