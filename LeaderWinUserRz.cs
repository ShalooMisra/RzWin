using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;
using System.Windows.Forms;
using System.IO;


using Core;
using Core.Display;
using CoreWin;
using NewMethod;
using Rz5.Win.Screens;
using Rz5.Win.Controls;
using ToolsWin;
using Tools;
using Tools.Database;
using System.Text;
using RzInterfaceWin.Screens;
using System.Drawing;
using System.Resources;
using RzInterfaceWin;
using Rz5.Win;
//KT Until Refactor Complete, this is needed for Sensible Custom forms
using RzSensible;
using Rz5.Enums;
using RzInterfaceWin.Dialogs;

namespace Rz5
{
    public class LeaderWinUserRz : NewMethod.Win.LeaderWinUserNM, ILeaderRz
    {
        public frmChooseCompany_Big CompanyForm;
        public CompanyHandle LastCompanyHandle;
        public ContactHandle LastContactHandle;

        //Public Variables
        public frmRecogniz TheRzForm
        {
            get
            {
                return (frmRecogniz)TheMainForm;
            }
        }
        //Constructors
        public LeaderWinUserRz()
        {

        }
        public LeaderWinUserRz(MainForm f) : base(f)
        {

        }
        //Public Override Functions
        public virtual void UpdateDetailFromPack(ContextRz x, orddet_line l, pack p)
        {
            l.manufacturer = p.manufacturer;
            l.datecode = p.datecode;
            l.packaging = p.packaging;
            l.lotnumber = p.lot_code;
            l.condition = p.condition;

            //l.quantity_packed = p.quantity;
            //l.quantity_unpacked = p.quantity;
            l.Update(RzWin.Context);
        }



        public virtual string GetOrddetFieldsExtra(ContextRz x, string strFields)
        {
            return strFields;
        }
        public override bool Show(Context x, ShowArgs args)
        {

            switch (args.TheItems.FirstGet(x).ClassId.ToLower())
            {
                case "usernote":
                    usernote n = (usernote)args.TheItems.FirstGet(x);
                    ShowInWindow((ContextRz)x, n);
                    args.Handled = true;
                    return true;
            }
            TheMainForm.Show(args);
            ////return base.Show(x, v, item);
            //foreach (IItem i in args.TheItems.AllGet(x))
            //{
            //    ((ContextRz)x).Show((nObject)i);
            //}
            return true;
        }



        public System.Windows.Forms.Form ShowInWindow(ContextRz q, usernote n)
        {
            view_usernote u = GetUserNoteView();
            u.Init(n);
            u.CompleteLoad();
            FormExternal xForm = new FormExternal();
            xForm.ShowControlNormally(u, "Note from " + n.createdbyname, RzWin.Form.Icon);
            return xForm;
        }
        public virtual view_usernote GetUserNoteView()
        {
            return new view_usernote();
        }



        public bool IsWeb()
        {
            return false;
        }
        public void CloseTabsByID(ContextRz x, ArrayList ids)
        {
            if (ids == null)
                return;
            if (ids.Count <= 0)
                return;
            foreach (string s in ids)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                CloseTabsByID(x, s);
            }
        }
        public account ShowQBAccountImportAssist(string acnt, string ref_num, double amnt, DateTime date)
        {
            frmQBAccountImportAssist f = new frmQBAccountImportAssist();
            f.CompleteLoad(acnt, ref_num, amnt, date);
            f.ShowDialog();
            return f.TheAccount;
        }
        public void CloseTabsByID(ContextRz x, String id)
        {
            TheMainForm.TabCloseByID(id);
        }
        public void AddCompanyOptions(ContextRz x, CompanyLogic l, ActHandle h)
        {
            h.AddSubSeparator();
            h.SubActs.Add(new ActHandle(new Act("Re-Cache Company Names", new ActHandler(l.CompanyNamesReCache))));
        }
        public void QCShow(ContextRz x, pack p, orddet_line l, string order_number, qualitycontrol q)
        {
            frmQC qc = new frmQC();
            if (!qc.CompleteLoad(x, p, l, order_number, q))
                return;
            qc.ShowDialog();
        }
        public void ReceivePO(ContextRz context, List<orddet_line> lines)
        {


            try
            {
                orddet_line d = lines[0];
                if (d == null)
                    return;
                ViewDetailPurchase p = new ViewDetailPurchase();
                //p= (ViewDetailPurchase)TheMainForm.TabCheckShow(d.unique_id);
                p = (ViewDetailPurchase)TheMainForm.TabCheckShow(d.unique_id) ?? (ViewDetailPurchase)ViewCreate(context, new ShowArgsOrder(context, d, Enums.OrderType.Purchase));
                //if (p == null)
                //    p = (ViewDetailPurchase)ViewCreate(context, new ShowArgsOrder(context, d, Enums.OrderType.Purchase));
                p.SetCurrentObject(d);
                p.CompleteLoad();
                TheMainForm.TabShow(p, p.GetCaption(), d.unique_id);//pass the unique_id, and caption so it can be identified in the tabstrip so it can be closed, etc.
                p.DoReceive(false);

            }
            catch { }
        }
        public void ReceiveService(ContextRz context, List<orddet_line> lines)
        {

            orddet_line d = lines[0];
            if (d == null)
                return;

            if (context.TheSysRz.TheLineLogic.IsServiceLineEligibleForAutoReceive(context, d))
            {
                d.FakeUnPackService(context);
            }
            else
            {
                ViewDetailService s = new ViewDetailService();
                s = (ViewDetailService)TheMainForm.TabCheckShow(d.unique_id) ?? (ViewDetailService)ViewCreate(context, new ShowArgsOrder(context, d, Enums.OrderType.Service));
                s.SetCurrentObject(d);
                s.CompleteLoad();
                TheMainForm.TabShow(s, s.GetCaption(), d.unique_id);//pass the unique_id, and caption so it can be identified in the tabstrip so it can be closed, etc.
                s.DoReceive();
            }

        }



        public void ReceiveRMA(ContextRz context, List<orddet_line> lines)
        {
            orddet_line d = lines[0];
            if (d == null)
                return;


            ViewDetailRMA v = new ViewDetailRMA();
            //p= (ViewDetailPurchase)TheMainForm.TabCheckShow(d.unique_id);
            v = (ViewDetailRMA)TheMainForm.TabCheckShow(d.unique_id) ?? (ViewDetailRMA)ViewCreate(context, new ShowArgsOrder(context, d, Enums.OrderType.RMA));
            v.SetCurrentObject(d);
            v.CompleteLoad();
            TheMainForm.TabShow(v, v.GetCaption(), d.unique_id);//pass the unique_id, and caption so it can be identified in the tabstrip so it can be closed, etc.

            v.DoReceive();
        }

        public void ShipVRMA(ContextRz context, List<orddet_line> lines)
        {
            try
            {
                orddet_line d = lines[0];
                if (d == null)
                    return;
                //ViewDetailVendRMA v = (ViewDetailVendRMA)context.TheLeader.ViewCreate(context, new ShowArgsOrder(context, d, Enums.OrderType.VendRMA));
                //v.SetCurrentObject(d);
                //v.CompleteLoad();
                //TheMainForm.TabShow(v);
                //v.DoShip();
                d.FakePackVendRMA(context);
            }
            catch { }
        }
        public void ShipService(ContextRz context, List<orddet_line> lines)
        {
            orddet_line d = lines[0];

            if (d == null)
                return;
            if (string.IsNullOrEmpty(d.service_vendor_uid))
            {
                RzWin.Leader.Error("Please choose a service vendor.");
                return;
            }

            int existingServiceLineCount = d.ServiceLines.CountGet(context);

            if (existingServiceLineCount == 0)//No services found on the arbitrary d (lines[0]) object.
            {
                ordhed_sales s = (ordhed_sales)lines[0].SalesVar.RefGet(context); // Get the service order, loop and look for service lines
                foreach (orddet_line l in s.DetailsList(context))
                {
                    int lineCount = l.ServiceLines.CountGet(context);
                    if (lineCount > 0)
                    {
                        existingServiceLineCount += lineCount;
                    }
                }
            }
            if (existingServiceLineCount == 0)//No services found on the arbitrary d (lines[0]) object.
            {
                RzWin.Leader.Error("Unable to find any services on this order.  Please make sure to add some before shipping.");
                return;
            }




            //Check if drop ship service vendor / GCAT for auto-ship  
            if (context.TheSysRz.TheLineLogic.IsServiceLineEligibleForAutoShip(context, d))
            {
                if (d.PacksOutServiceVar.CountGet(context) == 0)
                    d.FakePackService(context);
                //Get the pack, set complete.
                pack p = (pack)d.PacksOutServiceVar.m_TheItems.FirstGet(context);
                p.pack_complete = true;
                p.Update(context);
                //Update the line
                d.Status = Enums.OrderLineStatus.Packing_For_Service;
                d.quantity_packed_service = d.quantity;
                d.Update(context);
            }

            else
            {
                ViewDetailService v = (ViewDetailService)context.TheLeader.ViewCreate(context, new ShowArgsOrder(context, d, Enums.OrderType.Service));
                v.SetCurrentObject(d);
                v.CompleteLoad();
                TheMainForm.TabShow(v);
                v.DoShip();
            }

        }


        public void ShipInvoice(ContextRz context, List<orddet_line> lines)
        {
            if (lines == null)
                return;
            if (lines.Count > 1 && AllowBulkShip())
            {
                BulkShipInvoice(context, lines);
                return;
            }
            orddet_line d = lines[0];
            if (d == null)
                return;



            //CHeck for exisitng packs, mark them pack_complete, else, fakepack and mark pack_complete
            if (d.PacksOutVar.RefsCount(RzWin.Context) > 0)
            {
                foreach (pack pp in d.PacksOutVar.RefsGetAsItems(RzWin.Context).AllGet(RzWin.Context))
                {
                    pp.pack_complete = true;
                    pp.quantity = d.quantity;
                    pp.Update(RzWin.Context);
                    //This little bit is only for failed past packs.
                    if (d.quantity_packed != d.quantity)
                    {
                        d.quantity_packed = d.quantity;
                        d.Update(RzWin.Context);
                    }
                }

            }
            else
                d.FakePackInvoice(context);

        }
        public void BulkShipInvoice(ContextRz context, List<orddet_line> lines)
        {
            if (!context.TheLeader.AreYouSure("you want to pack all selected lines? This will apply the total quantity to the packs and will not allow for quantity editing."))
                return;
            ordhed_invoice o = null;
            try { o = (ordhed_invoice)lines[0].OrderObjectGet(context, Enums.OrderType.Invoice); }
            catch { }
            foreach (orddet_line l in lines)
            {
                partrecord stock = (partrecord)l.LinkedInventory(RzWin.Context);
                if (stock == null)
                    stock = context.TheLeaderRz.StockChoose(context, l.fullpartnumber);
                if (stock == null)
                    continue;
                if (stock.quantity == 0)
                {
                    context.TheLeader.Error("Linked stock item on Line# " + l.linecode_invoice.ToString() + " for item: " + stock.ToString() + " has zero quantity");
                    continue;
                }
                pack p = l.PacksOutVar.RefAddNew(context);
                p.ThePartSet(context, stock);
                if (stock.quantity < p.quantity)
                    p.quantity = Convert.ToInt32(stock.quantity);
                p.Update(RzWin.Context);
            }
            if (o != null)
                o.Update(context);
        }
        public List<ActHandle> FilterActsForWeb(Context x, List<ActHandle> h, nObject o) { return null; }
        public virtual bool AllowBulkShip()
        {
            return true;
        }
        public virtual void AddPanelOptions(ContextRz x, PanelLogic l, ActHandle h)
        {
            h.SubActs.Add(new ActHandle(new Act("Check For Updates", new ActHandler(l.UpdateCheck))));

            if (x.xUser.SuperUser)
                h.SubActs.Add(new ActHandle(new Act("Take Screen Shot", new ActHandler(l.TakeScreenShot))));

            ActHandle ah = new ActHandle(new Act("Scans", null));
            h.SubActs.Add(ah);
            ah.SubActs.Add(new ActHandle(new Act("BrokerForum Bids", new ActHandler(l.ScanBrokerForumBids))));
            ah.SubActs.Add(new ActHandle(new Act("BrokerForum RFQs", new ActHandler(l.ScanBrokerForumRFQs))));
            if (x.xSys.Recall && x.xUser.SuperUser)
            {
                ActHandle restore = new ActHandle(new Act("Restore"));
                h.SubActs.Add(restore);
                restore.SubActs.Add(new ActHandle(new Act("Order", new ActHandler(x.Sys.ThePanelLogic.RestoreOrder))));
                //restore.SubActs.Add(new ActHandle(new Act("Order Line", new ActHandler(x.Sys.ThePanelLogic.RestoreOrderLine))));
                restore.SubActs.Add(new ActHandle(new Act("Company", new ActHandler(x.Sys.ThePanelLogic.RestoreCompany))));
                //restore.SubActs.Add(new ActHandle(new Act("Contact", new ActHandler(x.Sys.ThePanelLogic.RestoreContact))));
                //if (((ContextRz)x).xUser.IsDeveloper())
                //    restore.SubActs.Add(new ActHandle(new Act("Item", new ActHandler(x.Sys.ThePanelLogic.RestoreItem))));
            }
            if (x.xUser.SuperUser)
            {
                h.SubActs.Add(new ActHandle(new Act("Database Manager", new ActHandler(l.DatabaseManagerShow))));
                h.SubActs.Add(new ActHandle(new Act("QuickBooks Settings", new ActHandler(l.QuickBooksSettingsShow))));
                h.SubActs.Add(new ActHandle(new Act("Phone Monitor", new ActHandler(l.PhoneMonitorShow))));
                h.SubActs.Add(new ActHandle(new Act("Duty Monitor", new ActHandler(l.DutyMonitorShow))));
                if (((ContextRz)x).xUser.IsDeveloper() || ((ContextRz)x).TheData.ServerName.ToLower().Contains("test"))
                    h.SubActs.Add(new ActHandle(new Act("Test Options", new ActHandler(l.TestOptionsShow))));
                h.SubActs.Add(new ActHandle(new Act("Credit Card Numbers", new ActHandler(l.CreditCardNumbersShow))));
            }

            //this is the safest way; we can't have that option in the panel, even just for us.  2 clicks would delete everything
            if (((ContextRz)x).xUser.IsDeveloper() && n_set.GetSetting_Boolean((ContextRz)x, "needs_rz4_conversion"))
                h.SubActs.Add(new ActHandle(new Act("Convert To Rz5", new ActHandler(ConvertToRz4Show))));
        }
        public nObject ChooseObjectFromCollection(ContextRz x, ArrayList objects)
        {
            return frmChooseObject.ChooseFromCollection(objects);
        }
        public void BFContactEmailScannerShow(ContextRz context) { }
        public void NCContactEmailScannerShow(ContextRz context) { }
        public DateTime ChooseDate(DateTime def, string cap)
        {
            return frmChooseDate.ChooseDate(def, cap, null);
        }
        public void ConvertToRz4Show(Context x, ActArgs args)
        {
            TheMainForm.TabShow(new ConvertToRz4(), "Convert To Rz5");
        }
        public void SandboxShow(Context x, ActArgs args)
        {
            TheMainForm.TabShow(GetSandbox(), "SandBox");
        }


        public void CheckRegisterShow(ContextRz context, account a)
        {
            ViewCheckRegister v = new ViewCheckRegister();
            v.Init(a);
            TheMainForm.TabShow(v, a.ToString());
        }
        public virtual SandBox GetSandbox()
        {
            return new SandBox();
        }
        public override bool Follow(Context context, Stop stop)
        {
            //if (stop is StopStockType)
            //{
            //    StopStockType st = (StopStockType)stop;
            //    st.Answer(ordhed.AskForStockType("What type of purchase is this?"));
            //    return !st.TheTrail.CanceledIs;
            //}
            //else if (stop is StopStockCreate)
            //{
            //    StopStockCreate stc = (StopStockCreate)stop;
            //    stc.Answer((ContextRz)context, stc.TheDetail.CreateLinkedPartRecord((ContextNM)context, stc.TheOrderTrail.TheStockType, true, stc.TheOrder.unique_id, ""));
            //    return !stc.TheTrail.CanceledIs;
            //}
            //else 

            //if (stop is StopOrderTransmitShow)
            //{
            //    ordhed transmit_order = ((TrailOrderTransmit)stop.TheTrail).TheOrder;
            //    switch (((TrailOrderTransmit)stop.TheTrail).TheType)
            //    {
            //        case Enums.TransmitType.Email:
            //            RzWin.Leader.ShowTransmitOrder(RzWin.Context, transmit_order, Enums.TransmitType.Email);
            //            if (transmit_order.OrderType == Enums.OrderType.Quote)
            //                ((SysRz4)((ContextRz)context).xSys).TheQuoteLogic.CreateFollowUpReminder((ContextRz)context, transmit_order);
            //            break;
            //        case Enums.TransmitType.PDF:
            //            transmit_order.PrintPDF((ContextRz)context);
            //            break;
            //        case Enums.TransmitType.Print:
            //            transmit_order.Print((ContextRz)context);
            //            break;
            //        case Enums.TransmitType.Fax:
            //            transmit_order.Fax((ContextRz)context);
            //            break;
            //    }
            //    return !stop.TheTrail.CanceledIs;
            //}
            //else
            return base.Follow(context, stop);
        }

        public virtual string ChooseIndustrySection(ContextRz x)
        {
            return frmChooseIndustry.ChooseIndustrySection(x);
        }

        public List<SalesLineGroup> ChooseOrderLines(ContextRz context, Rz5.ordhed_sales sale, List<SalesLineGroup> sections, Rz5.Enums.OrderType t, List<ordhed> existing, ref bool cancel)
        {
            return Win.Dialogs.OrderLineChooser.Choose(context, sale, sections, t, existing, ref cancel);
        }

        private bool CompanyHasTermsConditions(ContextRz x, company c)
        {

            bool ret = false;
            company_terms_conditions ct = c.GetExistingCompanyTC(x);
            if (ct == null)
                return false;
            if (ct.has_dc_restriction) ret = true;           
            if(ct.has_packaging_restriction) ret = true;
            if (ct.has_rohs_restriction) ret = true;
            if (ct.has_broker_restriction) ret = true;
            if (ct.has_coo_restriction) ret = true;
            if (ct.has_testing_restriction) ret = true;
            if (ct.requires_traceability) ret = true;
            if (!string.IsNullOrEmpty(ct.has_packaging_restriction_detail)) ret = true;
            if(!string.IsNullOrEmpty(ct.has_dc_restriction_detail)) ret = true;
            if(!string.IsNullOrEmpty(ct.has_testing_restriction_detail)) ret = true;
            return ret;

        }

        public bool ConfirmCustomerTermsConditions(ContextRz x, company c)
        {
            //Load the terms into the validation form for user confirmation.
            bool ret = false;
            if (!CompanyHasTermsConditions(x, c))
                return true;
            company_terms_conditions ct = c.GetExistingCompanyTC(x);
            frmCustomerTermsValidation f = new frmCustomerTermsValidation(ct);
            f.StartPosition = FormStartPosition.CenterScreen;
            var result = f.ShowDialog();
            if (result == DialogResult.OK)
                ret = true;            
            return ret;

        }

        public void ResolveTBDVendor(ContextRz x, orddet_line l)
        {
            frmTBDResolution f = new frmTBDResolution();
            f.CompleteLoad(x, l);
            var result = f.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    x.Leader.Tell("OK");
            //}
            //else
            //    x.Leader.Tell(result.ToString());          

        }


        public virtual void RunPartCrossReference(ContextRz context, ListView.SelectedListViewItemCollection lv)
        {
            if (lv == null)
                return;
            if (lv.Count <= 0)
                return;
            PartCrossReferenceSearchOptions p = new PartCrossReferenceSearchOptions();
            p.SQL_Table = "partrecord";
            p.SQL_PartField = "prefix+basenumberstripped";
            string in_where = "";
            foreach (ListViewItem l in lv)
            {
                if (Tools.Strings.StrExt(in_where))
                    in_where += ",'" + l.Text + "'";
                else
                    in_where += "'" + l.Text + "'";
            }
            if (!Tools.Strings.StrExt(in_where))
                return;
            p.SQL_Where = "importid in (" + in_where + ")";
            p.SQL_KeyFieldValue = lv[0].Text;
            view_PartCrossReference v = (view_PartCrossReference)context.TheLeader.ViewCreate(context, new ShowArgs("PartCrossReference"));
            if (!v.CompleteLoad(p))
                return;
            RzWin.Form.TabShow(v, "Part CrossReference");
        }
        public void ShowAccountingReport(ContextRz context, AccountingReport r)
        {
            ViewAccountingReport v = new ViewAccountingReport();
            TheMainForm.TabShow(v, r.ReportTitle);
            v.Init(r);
        }
        public void ExportInventory(ContextRz x)
        {
            ExportInventory export = GetExportInventory(x);
            export.CompleteLoad();
            RzWin.Form.TabShow(export, "Export Inventory");
        }
        public RzHook HookCreate(ContextRz context)
        {
            return new Win.RzHookWin(context);
        }
        public void PartSearchShow(ContextRz x, ActArgs args)
        {
            if (args is PartSearchShowArgs)
                args.Result("PartSearchScreen", PartSearchShowControl(x, (PartSearchShowArgs)args));
            else
                args.Result("PartSearchScreen", PartSearchShowControl(x, new PartSearchShowArgs()));
        }
        public IPartSearch PartSearchShowControl(ContextRz x, PartSearchShowArgs args)
        {
            IPartSearch p = null;

            if (args.UseExisting)
                p = (IPartSearch)TheRzForm.TabCheckShow("partsearch");

            if (p == null)
            {
                p = PartSearchCreate();
                p.CompleteLoad();
                TheRzForm.TabShow((UserControl)p, "Part Search", "partsearch");
            }

            if (Tools.Strings.StrExt(args.PartNumber))
                p.SetPartNumber(args.PartNumber);

            if (args.SearchType != Enums.PartSearchType.None)
                p.SetTab(args.SearchType);

            if (Tools.Strings.StrExt(args.CompanyId))
            {
                p.SetCompany(company.GetById(x, args.CompanyId));

                if (Tools.Strings.StrExt(args.ContactId))
                    p.SetContact(companycontact.GetById(x, args.ContactId));
            }

            if (args.RunSearch)
                p.RunSearch(true);

            p.FocusOnBox();

            return p;
        }
        public void PeopleSearchShow(ContextRz x, ActArgs args)
        {
            if (args is PeopleSearchShowArgs)
                args.Result("PeopleSearchScreen", PeopleSearchShowControl(x, (PeopleSearchShowArgs)args));
            else
                args.Result("PeopleSearchScreen", PeopleSearchShowControl(x, new PeopleSearchShowArgs()));
        }
        public IPeopleSearch PeopleSearchShowControl(ContextRz x, PeopleSearchShowArgs args)
        {
            IPeopleSearch p = null;

            if (args.UseExisting)
                p = (IPeopleSearch)TheRzForm.TabCheckShow("peoplesearch");

            if (p == null)
            {
                p = PeopleSearchCreate();
                TheRzForm.TabShow((UserControl)p, "People Search", "peoplesearch");
                p.CompleteLoad();
            }

            return p;
        }
        public bool AllChoicesShow(ContextRz x)
        {
            //Currently just for Web
            return false;
        }
        public bool AddNewChoiceList(ContextRz x)
        {
            //Currently just for Web
            return false;
        }
        public bool ContactReminderShow(ContextRz x)
        {
            TheRzForm.ShowContactReminderScreen();
            return true;
        }
        public virtual company CompanyNewShow(ContextRz x)
        {
            company c = company.AddNew_Prompt(x);
            if (c != null)
                x.Show(c);
            return c;
        }
        public virtual string NewCompanyNameGet(ContextRz context, string strName)
        {
            frmNewCompany xForm = new frmNewCompany();
            xForm.CompleteLoad(strName);
            xForm.ShowDialog(null);
            return xForm.SelectedName;
        }
        public bool HomeScreenShow(ContextRz x)
        {
            TheRzForm.ShowHomeScreen();
            return true;
        }
        public RMASelectionResult RMASelectionGet(ContextRz context, RMASelectionArgs args)
        {
            return Win.Dialogs.RMASelection.Select(args);
        }
        public void ShippingScreenShow(ContextRz x, ActArgs args)
        {
            if (args is ShippingScreenShowArgs)
                args.Result("OrderSearchScreen", ShippingScreenShowControl(x, (ShippingScreenShowArgs)args));
            else
                args.Result("OrderSearchScreen", ShippingScreenShowControl(x, new ShippingScreenShowArgs()));
        }
        public IShippingScreen ShippingScreenShowControl(ContextRz x, ShippingScreenShowArgs args)
        {
            IShippingScreen s = ShippingScreenCreate();
            TabPage t = TheRzForm.TabShow((UserControl)s, "Ship");
            s.Init(args.DueToday);
            return s;
        }
        public virtual IShippingScreen ShippingScreenCreate()
        {
            return new Win.Screens.Shipping();
        }


        public virtual void ProfitReportShow(ContextRz x)
        {
            Report r = x.TheSysRz.TheProfitLogic.ProfitReportCreate((ContextRz)x);
            ((ContextRz)x).TheLeaderRz.ReportShow(x, r, true);
        }
        protected virtual System.Windows.Forms.UserControl ProfitReportScreenCreate()
        {
            return new ProfitReportScreen();
        }
        public void OrderSearchShow(ContextRz x, ActArgs args)
        {
            if (args is OrderSearchShowArgs)
                args.Result("OrderSearchScreen", OrderSearchShowControl(x, (OrderSearchShowArgs)args));
            else
                args.Result("OrderSearchScreen", OrderSearchShowControl(x, new OrderSearchShowArgs()));
        }
        public OrderSearch OrderSearchShowControl(ContextRz x, OrderSearchShowArgs args)
        {
            if (args.UseExisting)
            {
                OrderSearch s = (OrderSearch)TheRzForm.TabCheckShow("ordersearch");
                if (s != null)
                    return s;
            }

            OrderSearch p = OrderSearchCreate();
            TheRzForm.TabShow(p, "Order Search", "ordersearch");
            p.CompleteLoad();
            p.Search(args);
            return p;
        }
        public bool OrderLinksShow(ContextRz x, string order_id)
        {
            ordhed o = ordhed.GetById(x, order_id);
            if (o == null)
                return false;
            OrderMap m = new OrderMap();
            RzWin.Form.TabShow(m, "Order Map");
            m.CompleteLoad(o, true);
            return true;
        }
        public bool PaymentsShow(ContextRz x, string order_id)
        {
            TheRzForm.PaymentsShow(order_id);
            return true;
        }
        public virtual void ImportCompanies(ContextRz x, ActArgs args)
        {
            CompanyImport c = new CompanyImport();
            c.CompleteLoad();
            RzWin.Form.TabShow(c, "Import Companies");
        }
        public virtual void ImportContacts(ContextRz x, ActArgs args)
        {
            ContactImport c = new ContactImport();
            c.CompleteLoad();
            RzWin.Form.TabShow(c, "Import Contacts");
        }
        public bool AssignAgentShow(ContextRz x, ArrayList comps)
        {
            try
            {
                //Here I need to differentiate between a user that can assign to any account, between a user that can only assign to House.
                NewMethod.n_user u;
                //SortedList assignUserList = new SortedList();
                //assignUserList.Add("17a7e95b7bcb47b0a2501d422f899100", "House");

                if (x.xUser.SuperUser)
                    u = NewMethod.n_user.Choose(RzWin.Context, true);
                else
                {
                    ArrayList assignUserList = new ArrayList();
                    assignUserList.Add("House");
                    assignUserList.Add(x.xUser.Name);
                    foreach (DictionaryEntry d in x.xUser.CaptainUsers.AllByName)//For All The Users this user is a captain of(if not a caption, this will just be empty)
                    {
                        assignUserList.Add(d.Value.ToString());
                    }

                    u = NewMethod.n_user.Choose(x, assignUserList, false);
                }



                if (u == null)
                    return false;
                foreach (company c in comps)
                {
                    c.base_mc_user_uid = u.unique_id;
                    c.agentname = u.name;
                    c.Update(RzWin.Context);
                    if (x.TheLogicRz.ContactsFollowCompanies)
                        c.AssignContacts(RzWin.Context, u);
                }
                return true;
            }
            catch { }
            return false;
        }
        public bool SetCompanyType(ContextRz x, ArrayList comps)
        {
            try
            {
                if (comps == null)
                    return false;
                if (comps.Count <= 0)
                    return false;
                string choice = frmChooseOneChoice.Choose(x.xSys, "companytype", "Choose A Company Type");
                if (!Tools.Strings.StrExt(choice))
                    return false;
                if (!RzWin.Leader.AreYouSure("set the company type to '" + choice + "' on " + comps.Count.ToString() + " companies"))
                    return false;
                foreach (company c in comps)
                {
                    c.companytype = choice;
                    x.Update(c);
                }
                return true;
            }
            catch { }
            return false;
        }

        public bool ViewChangeHistory(ContextRz x, nObject o)
        {
            if (x == null)
                return false;
            if (o == null)
                return false;
            ItemTag tag = new ItemTag(o);
            NewMethod.ViewChangeHistory vc = new NewMethod.ViewChangeHistory();
            TabPage t = ((LeaderWinUser)x.TheLeaderRz).TheMainForm.TabShow(vc, o.ToString());
            vc.CompleteLoad(x, tag);
            return true;
        }
        public void UserPanelShow(ContextRz x)
        {
            TheRzForm.ShowUserPanel();
        }
        public bool UserManagerShow(ContextRz x)
        {
            TheRzForm.ShowUserManager();
            return true;
        }
        public bool CompanyInfoShow(ContextRz x)
        {
            TheRzForm.ShowCompanyInfo();
            return true;
        }
        public bool ReqSourcingManagerShow(ContextRz x)
        {
            TheRzForm.ReqSourcingManagerShow();
            return true;
        }
        public bool ReqQuotingManagerShow(ContextRz x)
        {
            TheRzForm.ReqQuotingManagerShow();
            return true;
        }
        public string GetReceiveQuantityString_QC(ContextRz q, partrecord p, ordhed o, orddet d, long qDefault)
        {
            frmReceive xForm = ReceiveFormCreate();
            xForm.CurrentPart = p;
            xForm.CurrentOrder = o;
            xForm.CurrentDetail = d;
            xForm.CompleteLoad(q);
            xForm.SetQuantity(qDefault);
            xForm.ShowDialog();
            String ret = xForm.EnteredQuantity;
            try
            {
                xForm.Close();
            }
            catch { }
            try
            {
                xForm.Dispose();
                xForm = null;
            }
            catch { }
            return ret;
        }

        public string ChooseManufacturer(ContextRz x, string partNumber, bool addMfgToChoiceList = false)
        {

            //i.CompleteLoad(RzWin.Context);
            frmChooseManufacturer f = new frmChooseManufacturer(partNumber, addMfgToChoiceList);
            var result = f.ShowDialog();

            if (f.DialogResult == DialogResult.OK)
                return f.SelectedManufacturer;

            return "OTHER";
        }


        protected virtual frmReceive ReceiveFormCreate()
        {
            return new frmReceive();
        }
        public bool SetCompanyGroup(ContextRz x, ArrayList cs, bool undo, String strClass, String strGroup)
        {
            try
            {
                if (!Tools.Strings.StrExt(strGroup))
                    strGroup = frmChooseGroup.Choose(strClass, x.xUserRz);
                String strCaption = "";
                if (!Tools.Strings.StrExt(strGroup))
                    return false;
                String ids = nTools.GetIDString(cs);
                String strSQL = "";
                if (undo)
                {
                    strSQL = "update " + strClass + " set group_name = replace(isnull(cast(group_name as varchar(8000)), ''), '," + RzWin.Context.Filter(strGroup) + ",', '') where unique_id in (" + ids + ") and isnull(cast(group_name as varchar(8000)), '') like '%," + RzWin.Context.Filter(strGroup) + ",%'";
                    strCaption = "Un-Grouping...";
                }
                else
                {
                    strSQL = "update " + strClass + " set group_name = isnull(cast(group_name as varchar(8000)), '') + '," + RzWin.Context.Filter(strGroup) + ",' where unique_id in (" + ids + ") and isnull(cast(group_name as varchar(8000)), '') not like '%," + RzWin.Context.Filter(strGroup) + ",%'";
                    strCaption = "Grouping...";
                }
                RzWin.Leader.Comment(strCaption);
                x.Execute(strSQL);
                //x.xSys.NotifyClassChange(strClass, false);
                RzWin.Leader.Comment("Done.");
                return true;
            }
            catch
            { }
            return false;
        }
        public override IView ViewCreate(Context x, ShowArgs args)
        {
            switch (args.ClassId.ToLower())
            {
                case "emailtemplate":
                    RzWin.Form.ShowGenericTabControl_CompleteLoad(new EmailTemplates(), "Email Templates");
                    return null;
                case "n_team":
                    return new ViewEditPermissions();
                case "partcrossreference":
                    return new view_PartCrossReference();
                case "partrecord":
                    return new view_partrecord();
                case "company":
                    return new view_company();
                case "companycontact":
                    return new view_companycontact();
                case "ordhed_service":
                    return new ViewHeaderService();
                case "ordhed_rfq":
                    return new ViewHeaderRFQ();
                case "ordhed_quote":
                    return new ViewHeaderQuote();
                case "ordhed_sales":
                    return new ViewHeaderSales();
                case "ordhed_purchase":
                    ordhed_purchase p = (ordhed_purchase)args.TheItems.FirstGet(x);
                    if (p != null && p.is_bill)
                        return new ViewBill();
                    else
                        return new ViewHeaderPurchase();
                case "creditmemo_hed":
                    return new ViewCreditMemo();
                case "ordhed_invoice":
                    return new ViewHeaderInvoice();
                case "ordhed_rma":
                    return new ViewHeaderRMA();
                case "ordhed_vendrma":
                    return new ViewHeaderVendRMA();
                case "orddet_line":
                    if (args is Rz5.ShowArgsOrder)
                    {
                        Rz5.ShowArgsOrder vao = (Rz5.ShowArgsOrder)args;
                        switch (vao.TheOrderType)
                        {
                            case Rz5.Enums.OrderType.Sales:
                                return new ViewDetailSales();
                            case Rz5.Enums.OrderType.Purchase:
                                return new ViewDetailPurchase();
                            case Rz5.Enums.OrderType.Service:
                                return new ViewDetailService();
                            case Rz5.Enums.OrderType.Invoice:
                                return new ViewDetailInvoice();
                            case Rz5.Enums.OrderType.RMA:
                                return new ViewDetailRMA();
                            case Rz5.Enums.OrderType.VendRMA:
                                return new ViewDetailVendRMA();
                            case Rz5.Enums.OrderType.RFQ:
                                return new ViewDetailRFQ();
                        }
                        if (vao.TabName != null)
                            return new ViewDetailSales(vao.TabName);
                        else
                            return base.ViewCreate(x, args);

                    }
                    else
                        return base.ViewCreate(x, args);
                case "companyaddress":
                    return new view_companyaddress();
                case "contactnote":
                    return new view_contactnote();
                case "shippingaccount":
                    return new view_shippingaccount();
                case "calllog":
                    return new view_calllog();
                case "checkpayment":
                    return new view_checkpayment();
                case "ordhit":
                    return new view_ordhit();
                case "addresshandler":
                    return new view_addresshandler();
                case "dealheader":
                    return new OrderTree();
                case "n_user":
                    return new view_n_user();
                case "phonecall":
                    return new Views.view_phonecall();
                case "qualitycontrol":
                    return new view_qualitycontrol();
                case "qualitycontrol_sensible":
                    return (IView)new RzSensible.view_qualitycontrol();
                case "calendarentry":
                    return new Views.view_calendarentry();
                case "orddet_quote":
                    return new view_orddet_quote();
                case "orddet_rfq":
                    return (IView)new view_orddet_rfq();
                case "account":
                    return new RzInterfaceWin.Views.Account();
                case "consignment_code":
                    return new Views.ViewConsignmentCode();
                default:
                    return base.ViewCreate(x, args);
            }
        }
        public override void ShowHtml(Context x, string caption, string html)
        {
            base.ShowHtml(x, caption, html);
            //removed 2013_03_28: the base already handles this; having the below active showed it twice
            //if (TheRzForm != null)
            //    TheRzForm.ShowHTML(html, caption);
        }
        Login xLogin = null;
        public LoginInfo LoginInfoAskOnThread(ContextRz context, bool closeOnAccept, LoginInfo xLoginInfo = null)
        {
            xLogin = LoginFormGet();

            if (xLoginInfo == null)
                xLoginInfo = new LoginInfo();
            if (!Tools.Strings.StrExt(Tools.OperatingSystem.GetCrumb("hide_login_name")))
                xLoginInfo.strUser = Tools.OperatingSystem.GetCrumb("last_login_name");

            xLogin.CompleteLoad(xLoginInfo, true, false);
            xLogin.CheckFocus();
            xLogin.CloseOnAccept = closeOnAccept;
            xLogin.ShowDialog();

            return xLoginInfo;
        }
        //public String LoginCompanyID = "";
        public bool ShowWelcome = false;
        public System.Threading.Thread LoginThread;
        public void PopLogin(ContextRz context)
        {
            xLoginInfo = null;
            context.TheLeader.CommentEllipse("Showing the login screen");

            ShowWelcome = (context.SelectScalarInt64("select count(*) from n_user where name not like 'recognin%'") == 0);
            //LoginCompanyID = context.RzWin.Context.SelectScalarString("select setting_value from n_set where name = 'company_identifier'");

            context.Leader.Comment("Popping login...");
            //throw up the login form on a different thread.
            LoginThread = new System.Threading.Thread(new System.Threading.ThreadStart(PopLoginThread));
            LoginThread.SetApartmentState(System.Threading.ApartmentState.STA);
            LoginThread.Start();
        }

        public LoginInfo xLoginInfo;
        public void PopLoginThread()
        {
            try
            {
                xLoginInfo = new LoginInfo();

                //check for the command line arguments
                //xLoginInfo.IsReady
                if (Tools.Strings.HasString(Environment.CommandLine, "username="))
                {
                    RzWin.Leader.Comment("Login-Environment.CommandLine HasString username=");
                    String strCommandUser = Tools.Strings.ParseDelimit(Environment.CommandLine, "username=", 2).Trim();
                    String strCommandPassword = Tools.Strings.ParseDelimit(strCommandUser, "password=", 2).Trim();
                    strCommandUser = Tools.Strings.ParseDelimit(strCommandUser, "password=", 1).Trim();
                    strCommandPassword = Tools.Strings.ParseDelimit(strCommandPassword, " ", 1).Trim();

                    xLoginInfo.strUser = strCommandUser;
                    xLoginInfo.strPassword = strCommandPassword;
                    xLoginInfo.IsReady = true;
                    return;
                }

                RzWin.Leader.Comment("Loading login form");
                if (NMWin.Sys.isDesignMode())
                    xLoginInfo.strUser = "kevint";
                else if (!Tools.Strings.StrExt(Tools.OperatingSystem.GetCrumb("hide_login_name")))
                    xLoginInfo.strUser = Tools.OperatingSystem.GetCrumb("last_login_name");




                xLogin = LoginFormGet();
                xLogin.CompleteLoad(xLoginInfo, true, ShowWelcome);
                RzWin.Leader.Comment("Showing login form...");
                xLogin.Show();
                xLogin.CheckFocus();

                if (Environment.CommandLine.Contains("redacted"))
                    xLogin.AdminLogin();
                else
                    System.Windows.Forms.Application.Run(xLogin);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Comment("Error in PopLoginThread: " + ex.Message);
                RzWin.Leader.Tell("Error in PopLoginThread: " + ex.Message);
                return;
            }
        }

        public bool CheckLogin()
        {
            xLogin.CloseOnAccept = true;
            LoginThread.Join();
            return true;
        }

        public void CloseLogin()
        {
            try
            {
                if (xLogin != null)
                {
                    xLogin.CloseAndDispose();
                    xLogin = null;
                }
            }
            catch (Exception)
            {
            }
        }

        public virtual Login LoginFormGet()
        {
            return new Login();
        }

        //public virtual StartupRzWin StartupCreate(ContextRz context)
        //{
        //    return new StartupRzWin(context, null);
        //}

        public void UpdateCheck(ContextRz x)
        {
            TheRzForm.ShowVersionUpdate();
        }

        public void LiveSupportRequest(ContextRz context)
        {
            String strExe = "RzSupport.exe";
            //if (Rz3App.xLogic.IsCTG)
            //    strExe = "MikeSupport.exe";
            String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + strExe;
            if (!System.IO.File.Exists(strFile))
            {
                context.TheLeader.CommentEllipse("Downloading the support utility");
                if (!Tools.Files.DownloadInternetFile("http://www.recognin.com/" + strExe, Tools.FileSystem.GetAppPath() + strExe + ".tmp"))
                {
                    context.TheLeader.Error("The support utility could not be located.");
                    return;
                }
                nTools.BinCpy(Tools.FileSystem.GetAppPath() + strExe + ".tmp", strFile);
            }
            if (!System.IO.File.Exists(strFile))
            {
                context.TheLeader.Error("The support utility could not be located.");
                return;
            }
            Tools.FileSystem.Shell(strFile);
        }

        public void DatabaseManagerShow(ContextRz context)
        {
            TheRzForm.ShowGenericTabControl_CompleteLoad(new DatabaseManager(), "Database Manager");
        }

        public void QuickBooksSettingsShow(ContextRz context)
        {
            TheRzForm.ShowGenericTabControl_CompleteLoad(GetQuickBench(), "Quickbooks Interface Settings");
        }

        public virtual QuickBench GetQuickBench()
        {
            return new QuickBench();
        }

        public void EmailBlasterShow(ContextRz context)
        {
            EmailBlaster b = EmailBlasterCreate();
            TheRzForm.TabShow(b, "Email Blaster");
            b.CompleteLoad();
        }

        public virtual EmailBlaster EmailBlasterCreate()
        {
            return new EmailBlaster();
        }
        public virtual QBPost QBPostCreate()
        {
            return new QBPost();
        }
        public void PostQBShow(ContextRz context, Enums.OrderType type)
        {
            QBPost p = QBPostCreate();
            TabPage t = TheRzForm.TabShow(p, "Quickbooks Posting : " + type.ToString());
            p.CompleteLoad(type);
        }

        public virtual void ImportShow(ContextRz context)
        {
            IImportInventoryScreen i = ImportInventoryScreenCreate();
            RzWin.Form.TabShow((UserControl)i, "Import");
            i.CompleteLoad(Enums.StockType.Excess);
        }

        public virtual void ManageImportsShow(ContextRz context)
        {
            ImportShow(context);  //same as import
        }

        public virtual IImportInventoryScreen ImportInventoryScreenCreate()
        {
            return new ImportInventoryScreen();
        }

        public virtual void PaymentScreenShow(ContextRz context)
        {
            ArAp arap = PaymentScreenCreate(context);
            TheRzForm.TabShow(arap, "AR/AP");
            arap.CompleteLoad();
        }

        public virtual ArAp PaymentScreenCreate(ContextRz context)
        {
            return new ArAp();
        }

        public virtual UserControl TranslateUserScreen(ContextRz x, String screen_id)
        {
            switch (screen_id.ToLower().Trim())
            {
                //2011_05_31  this is not a feature anymore, right?
                //case "faxserver":
                //    frmPhoneFaxMonitor xForm = (frmPhoneFaxMonitor)RzWin.Context.TheSysRz.TheToolsLogic.PhoneMonitorFormCreate();
                //    xForm.StartFax();
                //    xForm.Show();
                //    xForm.WindowState = FormWindowState.Minimized;
                //    return null;
                case "chatserver":
                    //frmRzTieServer.CheckStartTieServer(x, true);
                    return null;
                case "arap":
                    ArAp ar = PaymentScreenCreate(x);
                    ar.CompleteLoad();
                    return ar;
                case "dutymonitor":
                    DutyMonitor d = new DutyMonitor();
                    d.CompleteLoad();
                    return d;
                case "emailblaster":
                    EmailBlaster e = ((LeaderWinUserRz)x.TheLeader).EmailBlasterCreate();
                    e.CompleteLoad();
                    return e;
                case "homescreen":
                    HomeScreen h = GetHomeScreen();
                    h.CompleteLoad(x.xUser, null);
                    return h;
                case "multisearch":
                    return MultiSearchCreate();
                case "ordersearch":
                    OrderSearch p = OrderSearchCreate();
                    p.CompleteLoad();
                    return p;
                case "partsearch":
                    return (UserControl)PartSearchCreate();
                case "peoplesearch":
                    return (UserControl)PeopleSearchCreate();
                case "shippingscreen":
                    return (UserControl)ShippingScreenCreate();
            }
            return null;
        }

        public virtual IPartSearch PartSearchCreate()
        {
            return new Win.Screens.PartSearch();
        }

        public virtual IPeopleSearch PeopleSearchCreate()
        {
            return new PeopleSearch();
        }

        public virtual OrderSearch OrderSearchCreate()
        {
            return new OrderSearch();
        }

        public virtual UserControl MultiSearchCreate()
        {
            MultiSearch.MultiSearchScreen s = new MultiSearch.MultiSearchScreen();
            MultiSearch.MSData d = new MultiSearch.MSData();
            s.CompleteLoad(d);
            return s;
        }
        public void MultiSearchShow(ContextRz x, String partToSearch)
        {
            RzWin.Form.ShowMultiSearch(partToSearch);
        }


        public void OEMProductsShow(ContextRz x)
        {
            RzWin.Form.OEMProductsShow();
        }



        public void PhoneMonitorShow(ContextRz x)
        {
            PhoneMonitorFormCreate().Show();
        }

        public void DutyMonitorShow(ContextRz x)
        {
            TheRzForm.ShowDutyMonitor();
        }

        public virtual Form PhoneMonitorFormCreate()
        {
            return new frmPhoneFaxMonitor();
        }

        public void ToolsShow(ContextRz x)
        {

        }

        public void ToolsSqlShow(ContextRz x)
        {
            nQuery b = new nQuery();
            b.CompleteLoad();
            TheRzForm.TabShow(b, "SQL Query");
        }

        public void ToolsTextShow(ContextRz x)
        {
            TheRzForm.TabShow(new nText(), "Text Editor");
        }

        public void DataTableDevelop(ContextRz x)
        {
            nDataView v = new nDataView();
            TheRzForm.ShowGenericTabControl_CompleteLoad(v, "Data Table");
            v.SetNoClass();
        }

        public void DataTablesListShow(ContextRz x)
        {
            n_data_target t = frmDataSources.Choose(null, x.xSys);
            if (t == null)
                return;

            DataConnectionSqlServer d = (DataConnectionSqlServer)t.GetAsDataConnection();
            String err = "";
            if (!d.ConnectPossible(ref err))
            {
                RzWin.Leader.Tell("Can't connect: " + err);
                return;
            }

            NewMethod.Original.Controls.nTables tables = new NewMethod.Original.Controls.nTables();
            TheRzForm.TabShow(tables, "Tables");
            tables.xData = d;
        }

        public void DataSourcesList(ContextRz x)
        {
            frmDataSources xForm = new frmDataSources();
            xForm.Show(TheRzForm);
            xForm.CompleteLoad(x.xSys);
        }

        public void UserApply(ContextRz x)
        {
            TheRzForm.UserApply();
        }

        public void ChatWithSomeone(ContextRz x)
        {
            TheRzForm.ChatWithSomeone();
        }

        public virtual void SandboxShow(ContextRz x)
        {
            TheRzForm.TabShow(new SandBox(), "Sandbox");
        }

        public void InspectionReportShow(ContextRz x, qualitycontrol report)
        {
            view_qualitycontrol inspectionview = (view_qualitycontrol)ViewCreate(x, new ShowArgs("qualitycontrol"));  // new view_qualitycontrol();
            inspectionview.Init(report);
            //inspectionview.SetCurrentObject(xPart.QCObject);
            //if (xDetail != null)
            //{
            //    inspectionview.CurrentDetail = xDetail;
            //    inspectionview.CurrentOrder = xDetail.GetOrderObject();
            //}
            //inspectionview.CurrentPart = xPart;
            inspectionview.CompleteLoad();
            TheRzForm.TabShow(inspectionview, "Inspection for " + report.fullpartnumber);
        }

        public void TestOptionsShow(ContextRz x)
        {
            TheRzForm.TestScreenShow();
        }

        public virtual IReqLine GetReqLine()
        {
            return new ReqLine();
        }
        public virtual IBidLine GetBidLine() //BidLine
        {
            return new BidLine();
        }

        public void DataFieldsDevelop(ContextRz x)
        {
            TheRzForm.TabShow(new nToolsView(), "Data Fields");
        }

        public void DataTableSizesManage(ContextRz context)
        {
            TheRzForm.DataTableSizesManage();
        }

        public void OrderLinksWorkBenchShow(ContextRz x, ActArgs args)
        {
            TheRzForm.OrderLinkWorkbenchShow();
        }

        public virtual void OrderLinkChoose(ContextRz x, OrderLinkArgs args)
        {
            Win.Dialogs.OrderLinkChooser c = new Win.Dialogs.OrderLinkChooser();
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

        public void RestoreCompany(ContextRz context)
        {
            TheRzForm.CompanyRestoreShow();
        }

        public void RestoreContact(ContextRz context)
        {
            TheRzForm.ContactRestoreShow();
        }

        public void CreditCardNumbersShow(ContextRz context)
        {
            TheRzForm.CreditCardNumbersShow();
        }

        public virtual void ReportShow(ContextRz context, Core.Report r, bool autoCalculate)
        {
            Rz5.Win.Views.ViewReport v = GetViewReportScreen(context);
            TheRzForm.TabShow(v, r.Title);
            v.Init(r);

            if (autoCalculate)
                v.RefreshReport();
        }
        public virtual Win.Views.ViewReport GetViewReportScreen(ContextRz x)
        {
            return new Win.Views.ViewReport();
        }
        public void ReportShow(ContextRz context, Core.Report r, ReportArgs args)
        {
            Rz5.Win.Views.ViewReport v = GetViewReportScreen(context);
            TheRzForm.TabShow(v, r.Title);
            v.Init(r, args);
            v.RefreshReport();
        }

        public virtual Win.Controls.ReportCriteriaControl CriteriaControlCreate(ReportCriteria c)
        {
            if (c is ReportCriteriaDateRange)
                return new ReportCriteriaControlDateRange();
            else if (c is ReportCriteriaAgent)
                return new ReportCriteriaControlAgent();
            else if (c is ReportCriteriaAgentMany)
                return new ReportCriteriaControlAgentMany();
            else if (c is ReportCriteriaCompany)
                return new ReportCriteriaControlCompany();
            else if (c is ReportCriteriaBoolean)
                return new ReportCriteriaControlBoolean();
            else if (c is ReportCriteriaRadio)
                return new ReportCriteriaControlRadio();
            else if (c is ReportCriteriaString)
                return new ReportCriteriaControlString();
            return null;
        }

        public String QBCreateCompany(ContextRz x, Enums.CompanySelectionType type, company c, String address1, String address2)
        {
            //context.TheLeader.Comment(v.companyname + " does not exist as a vendor.");
            //return "";

            String companyName = "";
            ShowAddQBCompany(c, ref companyName, type, address1, address2);
            return companyName;
        }

        public bool ShowAddQBCompany(company c, ref string strCompanyName, CompanySelectionType t, String strAddress1, String strAddress2)
        {
            frmSendQBCompany xForm = new frmSendQBCompany();
            //xForm.CompleteLoad(c, t);
            xForm.CompleteLoad(c, t);
            if (Tools.Strings.StrExt(strAddress1) || Tools.Strings.StrExt(strAddress2))
                xForm.LoadAddresses(strAddress1, strAddress2);
            xForm.ShowDialog();
            strCompanyName = xForm.SelectedName;
            bool b = xForm.CompanyExists;
            xForm.Close();
            xForm.Dispose();
            xForm = null;
            return b;
        }

        public void QBCreateTerms(ContextRz context, String terms)
        {
            int dueDays = 0;
            Double discountPercent = 0;
            int discountDays = 0;
            bool cancelled = false;
            frmQBTerms.Ask(null, terms, ref cancelled, ref dueDays, ref discountPercent, ref discountDays);
            if (cancelled)
                throw new Exception("Cancelled terms addition on " + terms);

            context.TheSysRz.TheQuickBooksLogic.CreateTerms(context, terms, dueDays, discountPercent, discountDays);
        }

        public void PartSearchShow(ContextRz x, String partToSearch)
        {
            PartSearchShowControl(x, new PartSearchShowArgs(partToSearch, true));
        }

        public void OrderSearchShow(ContextRz x, Enums.OrderType typeToSearch, String partToSearch)
        {
            OrderSearchShowControl(x, new OrderSearchShowArgs(typeToSearch, partToSearch));
        }

        public virtual Rz5.Win.Controls.Packing PackingControlCreate()
        {
            return new Rz5.Win.Controls.Packing();
        }

        public virtual Win.Dialogs.OrderLineChooser GetOrderLineChooserForm()
        {
            return new Win.Dialogs.OrderLineChooser();
        }

        public virtual frmOrderNumberEditor GetOrderNumberEditor(ContextRz x)
        {
            return new frmOrderNumberEditor();
        }

        public virtual ViewTask TaskViewCreate(usernote task)
        {
            return new ViewTask();
        }


        public void ShowTransmitOrder(ContextRz context, ordhed xOrder, printheader xLayout)
        {
            PrintPreview p = ShowTransmitOrder(context, xOrder, Enums.TransmitType.Print);
            if (p == null)
                return;
            p.SelectTemplateByID(xLayout.unique_id);
            p.ShowPrintPreview();
        }
        public PrintPreview ShowTransmitOrder(ContextRz context, ordhed xOrder, Enums.TransmitType ty)
        {
            //if (Rz3App.xLogic.IsAAT && xOrder.OrderType == Enums.OrderType.RMA)
            //    xOrder.AskRestockingFee(context);
            TransmitParameters tp = new TransmitParameters(ty);
            return ShowTransmitOrder(xOrder, tp);
        }
        public PrintPreview ShowTransmitOrder(ordhed xOrder, TransmitParameters tp)
        {
            ArrayList a = new ArrayList();
            a.Add(xOrder);
            return ShowTransmitOrders(a, tp);
        }

        public void ShowTransmitOrders(ContextRz context, List<ordhed> a, Enums.TransmitType ty)
        {
            ShowTransmitOrdersReturnControl(context, a, ty);
        }

        public PrintPreview ShowTransmitOrdersReturnControl(ContextRz context, List<ordhed> a, Enums.TransmitType ty)
        {
            TransmitParameters tp = new TransmitParameters(ty);
            ArrayList ret = new ArrayList();
            foreach (ordhed h in a)
            {
                ret.Add(h);
            }
            return ShowTransmitOrders(ret, tp);
        }
        public virtual PrintPreview GetPrintPreview()
        {
            return new PrintPreview();
        }
        public PrintPreview ShowTransmitOrders(ArrayList a, TransmitParameters tp)
        {
            PrintPreview p = GetPrintPreview();
            String strCaption = "";
            if (a.Count == 1)
            {
                ordhed xOrder = (ordhed)a[0];
                strCaption = "Transmit " + xOrder.ToString();
            }
            else
            {
                strCaption = "Transmit " + Tools.Number.LongFormat(a.Count) + " Orders";
            }
            TheMainForm.TabShow(p, strCaption);
            p.CompleteLoad(a, tp);
            return p;
        }

        public virtual view_qualitycontrol GetQCView(ContextNM context)
        {
            return new view_qualitycontrol();
        }

        public virtual UserPanel GetUserPanel()
        {
            return new UserPanel();
        }

        public virtual OrderTreeComponents.OrderTreeHalfQuote GetOrderTreeHalfQuote()
        {
            return new OrderTreeComponents.OrderTreeHalfQuote();
        }
        public virtual OrderTreeComponents.OrderTreeHalfBid GetOrderTreeHalfBid()
        {
            return new OrderTreeComponents.OrderTreeHalfBid();
        }

        public OrderMap ShowOrderMap(ordhed xOrder)
        {
            OrderMap m = new OrderMap();
            TheMainForm.TabShow(m, "Order Map");
            m.CompleteLoad(xOrder, false);
            return m;
        }

        public emailtemplate AskForEmailTemplate(nObject xObject)
        {
            frmChooseEmailTemplate xForm = new frmChooseEmailTemplate();
            xForm.CompleteLoad(xObject);
            xForm.ShowDialog();
            return xForm.SelectedTemplate;
        }

        public override String AskForStringFromArray(String prompt, String default_value, List<String> a)
        {
            bool canceled = false;
            return RzInterfaceWin.Dialogs.frmAskForStringFromArray.AskForStringFromArray(prompt, default_value, a, ref canceled);
        }


        public override nSearch GetSearch(String strClass, String strExtra)
        {
            switch (strClass.ToLower())
            {
                case "partrecord":
                    return new search_soft();
                case "orddet":
                    return new search_orddet();
            }
            //nSearch s = GetSoftSearch(strClass, strExtra);
            //if (s != null)
            //    return s;
            return null;
        }

        public virtual PhoneReport GetPhoneReport()
        {
            return new PhoneReport();
        }


        public virtual HomeScreen GetHomeScreen()
        {
            return new HomeScreen();
        }

        public void AfterThrow(Context x, Item i)
        {
            RzWin.User.AddClipObject((ContextNM)x, (nObject)i);
            switch (i.ClassId.ToLower().Trim())
            {
                case "company":
                    LastCompanyHandle = new CompanyHandle((company)i);
                    break;
                case "companycontact":
                    LastContactHandle = new ContactHandle((companycontact)i);
                    break;
            }
        }

        public void CacheCompanies()
        {
            if (CompanyForm == null)
            {
                CompanyForm = new frmChooseCompany_Big();
                CompanyForm.ShowClipCompanies();
            }
            CompanyForm.SetCompany();
        }

        public OrderTree GetDealByCompanyContact(ContextNM context, String strCompanyID, String strContactID, bool as_vendor)
        {
            if (as_vendor)
                return null;

            foreach (DisplayHandle h in context.TheLeader.DisplayHandlesList)
            {
                if (h.TheItem != null && h.TheDisplayObject != null)
                {
                    if (h.TheItem is dealheader && h.TheDisplayObject is OrderTree)
                    {
                        dealheader dh = (dealheader)h.TheItem;

                        if (Tools.Strings.StrCmp(strCompanyID, dh.customer_uid))
                            return (OrderTree)h.TheDisplayObject;
                    }
                }
            }

            return null;
        }
        public virtual StockEvaluator GetStockEvaluator()
        {
            return new StockEvaluator();
        }
        public void StockEvaluatorReport(dealheader d)
        {
            try
            {
                StockEvaluator ev = GetStockEvaluator();
                TheMainForm.TabShow(ev, "Stock Evaluator");
                ev.Init();
                ev.CompleteStructure();
                ArrayList a = new ArrayList();
                a.Add("OrderBatch: " + d.dealheader_name + " [" + d.unique_id + "]");
                ev.SetListNames(a);
            }
            catch (Exception ee)
            {
                string temp = ee.Message;
            }
        }

        public void ShowDealItem(ContextRz context, dealheader deal, orddet detail)
        {
            ShowArgs t = new ShowArgs(context, deal);
            context.Show(t);
            if (t.ViewUsed != null)
            {
                OrderTree ot = (OrderTree)t.ViewUsed;
                ot.ShowObjectByID(detail.unique_id);
            }
        }

        public void ShowNewReqInDeal(ContextRz context, String strPart, bool as_vendor, bool throw_req, String company_id, String contact_id, partrecord selected_part)
        {
            strPart = strPart.ToUpper().Trim();
            company xCompany = company.GetById(context, company_id);
            if (xCompany == null)
            {
                context.TheLeader.Tell("Please choose a company before continuing.");
                return;
            }
            companycontact xContact = companycontact.GetById(context, contact_id);
            if (xContact == null)
            {
                if (((SysRz5)context.xSys).TheCompanyLogic.DealContactRequired(xContact) && !as_vendor)
                {
                    context.TheLeader.Tell("Please choose a contact before continuing.");
                    return;
                }
                xContact = companycontact.New(context);
            }

            OrderTree ot = GetDealByCompanyContact(context, xCompany.unique_id, xContact.unique_id, as_vendor);

            dealheader xDeal = null;

            if (ot == null)
            {
                if (as_vendor)
                    xDeal = dealheader.MakeManualDeal(context, null, null);
                else
                    xDeal = dealheader.MakeManualDeal(context, xCompany, xContact);
            }
            else
            {
                xDeal = ot.xDeal;
            }

            AddNewReqInDeal(context, xDeal, selected_part, strPart, xCompany, xContact, throw_req, as_vendor, ot);
        }

        public void AddNewReqInDeal(ContextRz context, dealheader xDeal, partrecord p, String strPart, company xCompany, companycontact xContact, bool throw_req, bool as_vendor, OrderTree use_ot)
        {
            orddet_old det = null;
            if (as_vendor)
            {
                det = xDeal.VendorHalf.BidAdd(context, xCompany, xContact);
                det.currency_name = xCompany.DefaultCurrency(context);
                if (p == null)
                    det.fullpartnumber = strPart;
                else
                {
                    det.fullpartnumber = p.fullpartnumber;
                    det.manufacturer = p.manufacturer;
                    det.condition = p.condition;
                    det.description = p.description;
                    det.LinkedPart = p;
                }
                det.Update(context);
            }
            else
            {
                det = xDeal.CustomerHalf.QuoteAdd(context);
                det.currency_name = xCompany.DefaultCurrency(context);
                if (p == null)
                    det.fullpartnumber = strPart;
                else
                {
                    orddet_quote detq = (orddet_quote)det;
                    detq.fullpartnumber = p.fullpartnumber;
                    detq.target_manufacturer = p.manufacturer;
                    detq.manufacturer = p.manufacturer;
                    detq.target_condition = p.condition;
                    detq.condition = p.condition;
                    detq.description = p.description;
                    detq.location = p.location;
                    detq.boxnum = p.boxnum;
                    det.LinkedPart = p;
                    xDeal.ApplyLinkedPart(detq, p);
                }
                det.Update(context);
            }
            if (throw_req)
                context.Show(det);
            else if (use_ot == null)
            {
                context.Show(xDeal);
                OrderTree ot = GetDealByCompanyContact(context, xDeal.customer_uid, xDeal.contact_uid, false);
                if (ot != null)
                    ot.ShowObjectByID(det.unique_id);
            }
            else
            {
                use_ot.CompleteLoad();
                use_ot.ShowObjectByID(det.unique_id);
                try
                {
                    if (context.TheLeader is LeaderWinUserRz)
                    {
                        LeaderWinUserRz lwurz = (LeaderWinUserRz)context.TheLeader;
                        if (lwurz.TheMainForm != null)
                            lwurz.TheMainForm.TabSelectedSet((TabPageCore)use_ot.Parent);
                    }
                }
                catch { }
            }
        }

        public virtual partrecord StockChoose(ContextRz context, String part)
        {
            Win.Dialogs.StockChooser chooser = new Win.Dialogs.StockChooser();
            chooser.Init(part);
            chooser.ShowDialog();
            partrecord ret = chooser.Result;

            try
            {
                chooser.Close();
                chooser.Dispose();
                chooser = null;
            }
            catch { }

            return ret;
        }

        public void SearchForCompany(company cm, NewMethod.ListArgs.IGenericNotify notify)
        {
            PeopleSearchShowArgs args = new PeopleSearchShowArgs();
            RzWin.Context.TheSysRz.TheCompanyLogic.PeopleSearchShow(RzWin.Context, args);
            Rz5.Win.Screens.IPeopleSearch s = (Rz5.Win.Screens.IPeopleSearch)args.InfoFirst;
            if (s == null)
                return;

            s.SetNotifySelection(notify);
            s.SetTwo();
            if (cm != null)
            {
                s.SetCompanyName(cm.companyname);
                s.DoSearch();
                s.SearchCompanyID(cm.unique_id);
            }
        }

        public void FindDuplicateCompanies(ContextRz context, companycontact contact)
        {
            ActArgs args = new ActArgs();
            context.TheSysRz.TheCompanyLogic.PeopleSearchShow(context, args);
            Rz5.Win.Screens.IPeopleSearch p = (Rz5.Win.Screens.IPeopleSearch)args.InfoFirst;
            if (p == null)
                return;

            TheMainForm.TabShow((UserControl)p, "Duplicates of " + contact.contactname);

            String strWhere = " LTRIM(RTRIM( replace(contactname, 'DUPE', ''))) = '" + context.TheData.Filter(nTools.Replace(contact.contactname, "dupe", "").Trim()) + "'";

            if (nTools.IsEmailAddress(contact.primaryemailaddress))
                strWhere += " or primaryemailaddress = '" + contact.primaryemailaddress + "'";

            p.SwitchContact();
            p.SearchContactsByWhere(strWhere);
        }

        public virtual MultiSearch.Search GetExtraSearch(MultiSearch.IMSDataProvider d)
        {
            return null;
        }

        public DateTime AskPostpone(ContextRz x, DateTime date)
        {
            frmPostpone xForm = new frmPostpone();
            xForm.TheDate = date;
            ToolsWin.Screens.SetOnMouse(xForm);
            xForm.ShowDialog(null);

            DateTime ret = xForm.TheDate;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            try
            {
                if (ret != date)
                    return ret;
            }
            catch (Exception)
            {
            }
            return Tools.Dates.NullDate;
        }

        public void DisplayFocusItem(ContextRz context, focus_item fi)
        {
            IFocusControl x = FocusAsControl(context, fi);
            if (x == null)
                return;

            x.LimitControls();
            Focus.FocusItemHandle u = new Focus.FocusItemHandle();
            u.SetWidth((Control)x);
            u.HideLines();
            u.CompleteLoad(fi, x);

            FormExternal xForm = new FormExternal();
            xForm.ShowControlNormally(u, fi.name, TheMainForm.Icon);
            u.CloseRequest += new CloseHandler(xForm.s_CloseRequest);

            if (x is nView)
            {
                try
                {
                    nView s = (nView)x;
                    s.CloseRequest += new CloseHandler(xForm.s_CloseRequest);
                }
                catch { }
            }

            //switch (ItemType)
            //{
            //    case FocusItemType.UserNote:
            //        this.is_done = true;
            //        this.is_viewed = true;
            //        this.ISave();
            //        break;
            //}
        }

        public virtual IFocusControl FocusAsControl(ContextRz context, focus_item fi, bool limited_controls = false)
        {
            IFocusControl f = null;
            switch (fi.ItemType)
            {
                case FocusItemType.UserNote:
                    usernote u = usernote.GetById(context, fi.extra_info);
                    if (u == null)
                        return null;

                    view_usernote vu = new view_usernote();
                    vu.Init(u);
                    vu.CompleteLoad();
                    f = vu;
                    break;
                //case FocusItemType.ContactConsolidation:
                //    ContactMergeScreen cs = new ContactMergeScreen();
                //    ArrayList a = nTools.SplitArray(extra_info, "|");
                //    cs.CompleteLoad(xSys.QtC("companycontact", "select * from companycontact where unique_id in (" + nTools.GetIn(a) + ") order by contactname"));
                //    f = cs;
                //    break;
                case FocusItemType.AdvanceShipmentNotification:
                    Focus.AdvanceShipmentNotification x = new Focus.AdvanceShipmentNotification();
                    x.CompleteLoad(fi);
                    f = x;
                    break;
                case FocusItemType.ShipmentConfirmation:
                    Focus.ShipmentConfirmation xsc = new Focus.ShipmentConfirmation();
                    xsc.CompleteLoad(fi);
                    f = xsc;
                    break;
            }

            if (f == null)
                return f;

            if (limited_controls)
                f.LimitControls();
            return f;

        }

        public company ChooseCompany(ContextRz context)
        {
            String strID = "";
            String strName = "";
            //frmChooseCompany.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Choose", owner);
            frmChooseCompany_Big.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Choose");
            return company.GetById(context, strID);
        }
        public company ChooseCompany(ContextRz context, String companyname, String companyemailaddress, String contactname, String companyphone, String companyfax, bool inhibitshow)
        {
            String strID = "";
            //frmChooseCompany.ChooseCompanyID(ref strID, ref strName, Enums.CompanySelectionType.Both, "Choose", owner);
            frmChooseCompany_Big.ChooseCompanyID(ref strID, ref companyname, companyemailaddress, contactname, companyphone, companyfax, Enums.CompanySelectionType.Both, "Choose", null, inhibitshow);
            return company.GetById(context, strID);
        }

        //public companycontact ChooseCompanyContact(ContextRz context, string companyid)
        //{
        //    string contactID = "";
        //    string contactName = "";
        //    frmChooseContact.ChooseContactID(ref contactID, ref contactName, companyid, "Please Select a Contact for this order:", null);           
        //    //frmChooseCompany_Big.ChooseCompanyID(ref strID, ref companyname, companyemailaddress, contactname, companyphone, companyfax, Enums.CompanySelectionType.Both, "Choose", null, inhibitshow);
        //    return companycontact.GetById(context, contactID);
        //}

        public void PicturesShowOrderDetail(ContextRz context, orddet d)
        {
            PartPictureViewer PPV = new PartPictureViewer();
            TheMainForm.TabShow(PPV, "Pictures for " + d.ToString());
            PPV.DoResize();
            PPV.CompleteLoad();
            PPV.LoadViewBy(d);
            PPV.Caption = "Pictures for " + this.ToString();
        }

        public companycontact AddNewContact(ContextNM x, String strCompanyID, String strCompanyName)
        {
            company co = company.GetById(x, strCompanyID);
            if (co == null)
                return null;
            frmNewContact xForm = new frmNewContact();
            xForm.CompleteLoad(strCompanyID);
            xForm.ShowDialog();
            String strName = xForm.SelectedName;
            if (!Tools.Strings.StrExt(strName))
                return null;
            companycontact c = co.AddContact(RzWin.Context);
            c.contactname = strName;
            c.base_company_uid = strCompanyID;
            c.companyname = strCompanyName;
            x.Update(c);
            return c;
        }

        public void ImportFromQB(ContextRz x)
        {
            ImportFromQBs qb = new ImportFromQBs();
            qb.CompleteLoad();
            TheMainForm.TabShow(qb, "Import from Quickbooks");
        }


        public void ShowBlastMessage(blast_emailtemplate xTemplate, blast_emailserver xServer, blast_adrdet message)
        {
            nEmailMessage m = message.GetAsEmailMessage(RzWin.Context, xTemplate, xServer);
            nEmailMessageView mv = new nEmailMessageView();
            TheMainForm.TabShow(mv, "Email Message");
            mv.CompleteLoad(m);
        }

        public virtual IPaymentScreen GetPaymentScreen(Context x)
        {
            return new Rz5.Payments();
        }

        public virtual bool ChooseCompany(ContextRz x, ref company comp, ref companycontact cont)
        {
            //the company has to be known first.
            String strCaption = "";
            String strCompanyID = "";
            String strCompanyName = "";
            String strContactID = "";
            String strContactName = "";
            strCaption = "Please choose a company";

            frmChooseCompany_Big.ChooseCompanyID(ref strCompanyID, ref strCompanyName, ref strContactID, ref strContactName, Rz5.Enums.CompanySelectionType.Both, strCaption, null);
            if (!Tools.Strings.StrExt(strCompanyID))
                return false;
            companycontact ct = null;
            if (((SysRz5)x.xSys).TheCompanyLogic.IsContactBadAccount(x, strContactID, ref ct))
            {
                string name = "This contact";
                if (ct != null)
                    name = ct.ToString();
                x.TheLeader.Error(name + " is marked as a bad account and cannot be used.");
                comp = null;
                cont = null;
                return false;
            }
            comp = company.GetById(x, strCompanyID);
            cont = companycontact.GetById(x, strContactID);

            //this is not the right place for this
            //if (comp.problem_vendor && Tools.Strings.StrCmp(Caption, "vendor"))
            //    context.TheLeader.Tell("Please Note: the vendor: " + comp.companyname + " has been flagged as a problem vendor");
            return true;
        }

        public virtual Rz5.frmLabelLines GetLabelLinesForm()
        {
            return new Rz5.frmLabelLines();
        }

        public virtual frmNewChatSession GetNewChatSessionForm()
        {
            return new frmNewChatSession();
        }

        public virtual frmChatSession GetChatSessionForm()
        {
            return new frmChatSession();
        }
        public virtual frmChooseUser_Multiple GetChooseUserMultipleForm()
        {
            return new frmChooseUser_Multiple();
        }

        public virtual ExportInventory GetExportInventory(Context x)
        {
            return new ExportInventory();
        }
        public virtual void ExportInventory(Context x, ActArgs args)
        {
            //if (!Rz3App.xUser.CheckPermit("Inventory:Exports:CustomExport"))
            //{
            //    RzWin.Leader.ShowNoRight();
            //    return;
            //}
            ExportInventory export = GetExportInventory(x);
            export.CompleteLoad();
            TheMainForm.TabShow(export, "Export Inventory");
        }

        public System.Windows.Forms.Form ShowNoteInWindow(ContextRz q)
        {
            q.Reorg();
            return null;
            //view_usernote u = new view_usernote();
            //u.Init(this);
            //u.CompleteLoad();
            //FormExternal xForm = new FormExternal();
            //xForm.ShowControlNormally(u, "Note from " + this.createdbyname, RzWin.Form.Icon);
            //return xForm;
        }

        public void ScanBrokerForumBids(ContextRz context)
        {
            Scan_BF_RFQs bf = new Scan_BF_RFQs();
            bf.CompleteLoad();
            TheMainForm.TabShow(bf, "BrokerForum Bids");
        }
        public void ScanBrokerForumRFQs(ContextRz context)
        {
            Scan_BF_RFQs bf = new Scan_BF_RFQs(true);
            bf.CompleteLoad();
            TheMainForm.TabShow(bf, "BrokerForum RFQs");
        }

        public void ShowHelp(ContextRz context)
        {
            //www.recognin.com/HowToGuide/
            //above folder holds the original word doc for editing
            BrowserPlain b = new BrowserPlain();
            b.ShowControls = false;
            RzWin.Form.TabShow(b, "Help");
            b.Navigate("http://www.recognin.com/How%20To%20Guide.pdf");
        }

        public virtual void RunNextVersion(ContextRz context)
        {
            String s = Tools.FileSystem.GetAppPath() + "Peak.exe";
            Tools.FileSystem.Shell(s, "username=" + context.xUser.login_name + " password=" + context.xUser.login_password);
            CloseProgram();
        }

        public MakeOrderArgs AskForMakeOrderArgs(Enums.OrderType orderType)
        {
            MakeOrderArgs oargs = new MakeOrderArgs(orderType);
            Win.Dialogs.OrderSelection.Select(oargs);
            return oargs;
        }

        public Enums.StockType AskForStockType(String strCaption)
        {
            frmStockType xForm = new frmStockType();
            xForm.SetCaption(strCaption);
            xForm.ShowDialog();
            return xForm.SelectedType;
        }

        public void ShowContactGroups(ContextNM x)
        {
            GroupManager m = new GroupManager();
            RzWin.Form.TabShow(m, "Groups [Contact]");
            m.CompleteLoad("companycontact");
        }

        private void SendCompanyContactEMail(company company)
        {
            try
            {
                frmEmailSelection xEmail = new frmEmailSelection();
                xEmail.CompleteLoad(company);
                xEmail.ShowDialog();
            }
            catch { }
        }

        public void ShowCompanySettings()
        {
            frmOwnerSettings xForm = new frmOwnerSettings();
            xForm.CompleteLoad();
            xForm.ShowDialog();
        }

        public company AskForCompany(ContextRz context, String name)
        {
            return frmChooseCompany_Big.ChooseCompany(name);
        }

        public DepotConnection ChooseDepotConnection()
        {
            return frmDepot.Choose();
        }

        public bool SetCompanyGroup(ContextNM x, ArrayList cs, bool undo, String strClass, String strGroup)
        {
            String group = frmChooseGroup.Choose(strClass, (n_user)x.xUser);
            if (!Tools.Strings.StrExt(group))
                return false;

            foreach (Item i in cs)
            {
                String g = (String)i.ValGet("group_name");
                String k = "," + group + ",";
                if (undo)
                {
                    if (Tools.Strings.HasString(g, k))
                    {
                        g = Tools.Strings.Replace(g, k, ",");
                        i.ValSet("group_name", g);
                        i.Update(x);
                    }
                }
                else
                {
                    if (!Tools.Strings.HasString(g, k))
                    {
                        g += k;
                        g = g.Replace(",,", ",");
                        i.ValSet("group_name", g);
                        i.Update(x);
                    }
                }
            }

            return true;
        }

        public RMASelectionResult ChooseVendorRMA(RMASelectionArgs args)
        {
            return Win.Dialogs.VendRMASelection.Select(args);
        }

        public void ShowPartCrossReference(Context x, PartCrossReferenceSearchOptions options)
        {
            view_PartCrossReference v = (view_PartCrossReference)ViewCreate(x, new ShowArgs("PartCrossReference"));
            if (!v.CompleteLoad(options))
                return;
            TheMainForm.TabShow(v, "Part Cross-Reference");
        }

        public void AskForLineCancelArgs(ContextRz context, OrderLineCancelArgs args)
        {
            Win.Dialogs.OrderLineCancel.Choose(args);
        }

        //public company ChooseCompany(ContextRz context, String companyname, String companyemailaddress, String contactname, String companyphone, String companyfax, bool inhibitshow) { throw new NotImplementedException(); }

        public ArrayList ChooseFromArray(ContextRz x, ArrayList choices, String caption)
        {
            return frmChooseMultipleChoices.ChooseFromArray(choices, caption);
        }

        //public bool SendOutlookMessage(string ToAddress, string BodyText, string SubjectString, bool boolTextOnly, bool boolUserEdit, string CCString, string strAttachFile, bool boolForceSilent, ArrayList colCC, string strBCC, string strReplyAddress, string strOtherAttachment, string strSignature, bool bDeliverNow, ref string error)
        //{
        //    return RzWin.Context.TheSysRz.TheEmailLogic.SendOutlookEmail(ToAddress, BodyText, SubjectString, boolTextOnly, boolUserEdit, CCString, strAttachFile, boolForceSilent, colCC, strBCC, strReplyAddress, strOtherAttachment, strSignature, bDeliverNow, ref error);
        //    //return ToolsOffice.OutlookOffice.SendOutlookMessage();
        //}
        //public bool SendOutlookMessage(ContextRz x, string ToAddress, string BodyText, string SubjectString, bool boolTextOnly, bool boolUserEdit, string CCString, string BCCSTring, string strAttachFile, bool isDraft,string strSignature, string strFromAddress , ref string error)
        //{
        //    return RzWin.Context.TheSysRz.TheEmailLogic.SendEmail(x, new List<string>() { ToAddress }, BodyText, SubjectString, boolTextOnly, boolUserEdit, new List<string>() { CCString }, new List<string>() { BCCSTring }, new List<string>() { strAttachFile }, isDraft, strSignature, strFromAddress, ref error);

        //}




        public String AskForSalesOrderIdToAdd()
        {
            frmAddToSO a = new frmAddToSO();
            a.CompleteLoad();
            a.ShowDialog();
            string ret = a.GetID();
            try
            {
                a.Close();
                a.Dispose();
                a = null;
            }
            catch { }
            return ret;
        }

        public void AskForOrder(ref String type, ref String order)
        {
            frmOrderSelection.Choose(ref type, ref order);
        }

        public String ChooseGroup(n_user u)
        {
            return frmChooseGroup.Choose("company", u);
        }

        public void UserAccountsShow(ContextRz context)
        {
        }

        public virtual void ReportsShow(ContextRz context)
        {
            context.TheLeader.Tell("This Button!  It does Nothing!!!!");
        }

        public void PhoneReportShow(ContextRz context)
        {
            PhoneReport r = GetPhoneReport();
            TheMainForm.TabShow(r, "Phone Report");
            r.CompleteLoad();
        }

        public void ChatHistoryShow(ContextRz context)
        {
            DateTime start = frmChooseDate.ChooseDate(DateTime.Now, "Start Date", TheMainForm);
            if (!Tools.Dates.DateExists(start))
                return;

            DateTime end = frmChooseDate.ChooseDate(start, "End Date", TheMainForm);
            if (!Tools.Dates.DateExists(end))
                return;

            Tools.Dates.DateRange r = new Tools.Dates.DateRange(start, end);

            String strSQL = "select * from chat_message where ( sender = '" + context.Filter(context.xUser.name) + "' or recipient = '" + context.Filter(context.xUser.name) + "' ) and " + r.GetSQL("date_created") + " order by date_created";
            ArrayList a = context.QtC("chat_message", strSQL);
            if (a.Count == 0)
            {
                context.TheLeader.Tell("No chat activity was found for this date range.");
                return;
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<table border=\"1\"><tr><td>Date</td><td>From</td><td>To</td><td>Chat</td></tr>");

            foreach (chat_message m in a)
            {

                String strColor = "green";
                if (m.sender == context.xUser.Name)
                    strColor = "blue";

                sb.AppendLine("<tr><td><font color=\"" + strColor + "\">" + nTools.DateFormat_ShortDateTime(m.date_created) + "</font></td><td><font color=\"" + strColor + "\">" + m.sender + "</font></td><td><font color=\"" + strColor + "\">" + m.recipient + "</font></td><td><font color=\"" + strColor + "\">" + m.chat_text + "</font></td></tr>");
            }

            sb.AppendLine("</table>");

            TheMainForm.ShowHTML(sb.ToString(), "Chats between " + r.Caption);
        }

        public void ConsolidateCompanies(ContextRz context, ArrayList companies)
        {
            CompanyMergeScreen s = new CompanyMergeScreen();
            TheMainForm.TabShow(s, "Company Merge");
            s.CompleteLoad(companies);
        }

        public void ConsolidateContacts(ContextRz context, ArrayList contacts)
        {

            CompanyLogic.ConsolidateContacts(context, contacts);
        }


        public void PrintBarcodeLabel(ContextRz context, orddet_line line, string strLabel = "outgoing_line_item")
        {
            ArrayList colObjects = new ArrayList();
            long l = line.quantity;
            ArrayList a = frmLabelLines.EnterLines(line);
            if (a == null)
                return;
            if (a.Count == 0)
                return;
            foreach (String s in a)
            {
                String strq = Tools.Strings.ParseDelimit(s, ":", 1).Trim();
                String strdc = Tools.Strings.ParseDelimit(s, ":", 2).Trim();
                String strser = "";
                String strex = "";
                if (Tools.Strings.CharCount(s, ':') > 1)
                    strser = Tools.Strings.ParseDelimit(s, ":", 3).Trim();
                if (Tools.Strings.CharCount(s, ':') > 2)
                    strex = Tools.Strings.ParseDelimit(s, ":", 4).Trim();
                if (Tools.Number.IsNumeric(strq))
                {
                    orddet_line x = (orddet_line)line.CloneValues(context);
                    x.unique_id = "<none>";
                    x.quantity = Int32.Parse(strq);
                    x.datecode = strdc;
                    colObjects = new ArrayList();
                    colObjects.Add(x);
                    colObjects.Add(line.OrderObjectGet(context, Enums.OrderType.Sales));
                    colObjects.Add(context.xUser);
                    //bool uppercase = false;
                    //String strLabel = "";
                    //strLabel = "outgoing_line_item";
                    Boolean bBarcode = false;
                    Tools.Dymo.PrintDymoLabel(context, strLabel, colObjects, null, bBarcode);
                }
            }
        }

        public void MergeChoose(ContextRz context, OrderLinkArgs args)
        {
            Win.Dialogs.MergeChooser.Choose(args);
        }


        public void SearchForCompany(ContextRz context, company cm, NewMethod.ListArgs.IGenericNotify notify)
        {
            PeopleSearchShowArgs args = new PeopleSearchShowArgs();
            context.TheSysRz.TheCompanyLogic.PeopleSearchShow(context, args);
            Rz5.Win.Screens.IPeopleSearch s = (Rz5.Win.Screens.PeopleSearch)args.InfoFirst;
            if (s == null)
                return;

            s.SetNotifySelection(notify);
            if (nTools.IsIn(context.xUser.name, "Denise Gilchrist|Lauren"))
                s.SetTwo();
            else
                s.SwitchCompany();
            if (cm != null)
            {
                s.SetCompanyName(cm.companyname);
                s.DoSearch();
            }
        }

        public void AccountsShow(ContextRz context)
        {
            ChartOfAccounts coa = (ChartOfAccounts)TheMainForm.TabCheckShow("chartofaccounts");
            if (coa == null)
            {
                coa = new ChartOfAccounts();
                TheMainForm.TabShow(coa, "Chart Of Accounts");
            }
            coa.Init();
        }

        public void CurrenciesShow(ContextRz context)
        {
            TheRzForm.TabShow(new Currencies(), "Currency Manager");
        }

        public void JournalEntryShow(ContextRz context)
        {
            TheRzForm.TabShow(new RzInterfaceWin.Screens.JournalEntry(), "Journal Entry");
        }
        public void PostOrdersShow(ContextRz context)
        {
            RzInterfaceWin.PostOrders p = new RzInterfaceWin.PostOrders();
            TheRzForm.TabShow(p, "Post Orders");
            p.Init();
        }

        public void ReceivePaymentsShow(ContextRz context, company customer)
        {
            ProcessPayments screen = new RzInterfaceWin.Screens.ProcessPayments();
            TheRzForm.TabShow(screen, "Receive Payments");
            screen.Init(PaymentType.Customer, customer);

        }

        public void PayBillsShow(ContextRz context, company vendor)
        {
            ProcessPayments screen = new RzInterfaceWin.Screens.ProcessPayments();
            TheRzForm.TabShow(screen, "Pay Bills");
            screen.Init(PaymentType.Vendor, vendor);
        }

        public Image CurrencyImage(String name)
        {
            ResourceManager rm = RzInterfaceWin.Properties.Resources.ResourceManager;
            return (Bitmap)rm.GetObject(name);
        }
        public void ShowPrintCheck(ContextRz x, List<payment_out> l, account a = null)
        {
            frmPrintChecks p = new frmPrintChecks();
            p.Init(l, a);
            p.ShowDialog();
            if (p.Canceled)
                return;
            //have print args?
        }
        public void DepositsShow(ContextRz context)
        {
            Deposits deposits = new Deposits();
            TheRzForm.TabShow(deposits, "Make Deposit");
            deposits.Init();
        }
        public void ReconcileBankShow(ContextRz context)
        {
            frmBeginReconciliation b = new frmBeginReconciliation();
            b.Init();
            b.ShowDialog();
            if (b.Canceled)
                return;
            ReconcileAccount r = new ReconcileAccount();
            TheRzForm.TabShow(r, "Reconcile Account - " + b.Args.Account.name);
            r.Init(b.Args);
        }
        public void ReconcileCCShow(ContextRz context)
        {
            frmBeginReconciliationCC b = new frmBeginReconciliationCC();
            b.Init();
            b.ShowDialog();
            if (b.Canceled)
                return;
            ReconcileAccountCC r = new ReconcileAccountCC();
            TheRzForm.TabShow(r, "Reconcile Credit Card - " + b.Args.Account.name);
            r.Init(b.Args);
        }
        public void EditBudgetShow(ContextRz context)
        {
            budget b = null;
            string id = context.SelectScalarString("select top 1 unique_id from budget");
            if (!Tools.Strings.StrExt(id))
            {
                frmNewBudget nb = new frmNewBudget();
                nb.ShowDialog();
                if (nb.Canceled)
                    return;
                b = nb.Budget;
            }
            else
                b = budget.GetById(context, id);
            if (b == null)
                return;
            BudgetEditor r = new BudgetEditor();
            TheRzForm.TabShow(r, "Budget - " + b.budget_name);
            r.Init(b);
        }
        public account AskForNewAccount(ContextRz context, string parent_id)
        {
            return frmAskNewAccount.AskNewAccount(context, parent_id);

        }
        public string GetAccountReportLink(string account_id, string text, AccountingReportAction a)
        {
            if (!Tools.Strings.StrExt(account_id))
                return text;
            account_id = account_id.Replace("notanid_", "").Trim();
            return "<a style=\"text-decoration: none; color: black;\" href=\"showaccountreport_" + account_id + "\">" + text + "</a>";
        }
        //KT - ChooseCompanyCredits
        //public List<companycredits> ChooseCompanyCredits(ContextRz x, string companyid, string orderid, string ordernumber)
        public List<companycredit> ChooseCompanyCredit(ContextRz x, company company, ordhed ordhed)
        {

            frmChooseCompanyCredit f = new frmChooseCompanyCredit();
            f.Init(x, company, ordhed);  //pass in the context since that's what you'll use for the list            
            f.ShowDialog();
            List<companycredit> ret = f.GetSelectedCredits();
            f.Close();
            f.Dispose();
            return ret;

        }
        //KT Show Bin Swapper
        public void ShowBinSwapper(Context x, ActArgs a)
        {
            frmBinSwapper xSwap = new frmBinSwapper();
            if (xSwap.CompleteLoad())
                xSwap.ShowDialog();
        }

        public void ShowOEMProductForm(Context x, AddArgs args)
        {
            frmOEMProduct op = new frmOEMProduct();
            op.Show();
        }



        //KT **All Mehtods Below = Refactored from RzSensible.LeaderWinUserRzSensible - 2-25-2015
        public void ApplyServiceCharge(ContextRz context, ordhed_service service, ref ordhed_sales sale, ref ordhed_invoice invoice)
        {
            frmApplyServiceCharge f = new frmApplyServiceCharge();
            f.CompleteLoad(context, service);

            sale = (ordhed_sales)f.TheSalesOrder;
            invoice = (ordhed_invoice)f.TheInvoice;

            try
            {
                f.Close();
                f.Dispose();
                f = null;
            }
            catch { }
        }

        public ArrayList EnterLabelLines(orddet_line line)
        {
            return frmLabelLines.EnterLines(line);
        }
        public void InspectionReportShowLegacy(Rz5.ContextRz x, Rz5.qualitycontrol report)
        {
            ViewQualityControl inspectionview = new ViewQualityControl();
            inspectionview.Init(report);
            inspectionview.CompleteLoad();
            RzWin.Form.TabShow(inspectionview, "Inspection for " + report.fullpartnumber);
        }
        public void ShowUserInfoChanges()
        {
            Rz5.Reports.UserInfoChanges c = new Rz5.Reports.UserInfoChanges();
            RzWin.Form.TabShow(c, "User Info Changes");
            c.CompleteStructure();
            c.Init();
        }
        public String VerifyCompanyName(String name)
        {
            Rz5.frmNewCompany xForm = new Rz5.frmNewCompany();
            xForm.CompleteLoad(name);
            xForm.ShowDialog(null);
            String ret = xForm.SelectedName;

            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            return ret;
        }

        public ordhed ChooseFQSO(ContextRz x, string company_id, string ordhedType)
        {
            frmChooseFQSO xForm = new frmChooseFQSO();
            xForm.CompleteLoad(x, company_id, ordhedType);
            xForm.ShowDialog(null);
            ordhed ret = xForm.TheOrder;
            try
            {
                xForm.Close();
                xForm.Dispose();
                xForm = null;
            }
            catch { }

            return ret;
        }

        public void ValidationFormShow(ContextRz x, validation_form v)
        {

            view_validation_form vf = new view_validation_form(x, v);
            vf.StartPosition = FormStartPosition.CenterScreen;
            //vf.Location = new Point(0, 0);
            vf.TopMost = true;
            //vf.ShowDialog();
            vf.Show();

        }

        public void GetDockDateChecker(ContextRz x, orddet_line l)
        {

            frmDockDateChecker f = new frmDockDateChecker(x, l);
            if (f.CompleteLoad())
                f.ShowDialog();

        }

        public void ShowOrderTestOptions(ContextRz x, ordhed o)
        {

            frmOrderTestOptions f = new frmOrderTestOptions(x, o);
            f.ShowDialog();

        }

        public void ManageHubspot(ContextRz x, object o)
        {
            try
            {
                frmManageHubspot f = new frmManageHubspot();
                f.CompleteLoad(x, o);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                x.Leader.Error(ex);
            }


        }




        public void RzPublishShow(ContextRz x)
        {
            //base.TasksShow();
            if (x.xSys.isDesignMode())
            {
                if (!x.xUser.IsDeveloper())
                    return;
                Upload u = new Upload();
                TheRzForm.TabShow(u, "Uploads");
                u.Init();
                //frmOrderTestOptions f = new frmOrderTestOptions(x, o);
                //f.ShowDialog();
            }


        }



    }
}