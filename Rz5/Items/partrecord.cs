using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Core;
using NewMethod;
using Tools.Database;

namespace Rz5
{
    public partial class partrecord : partrecord_auto, IPartObject
    {


        private qualitycontrol m_QCObject;
        public qualitycontrol QCObjectGet(ContextRz context)
        {
            if (m_QCObject != null)
                return m_QCObject;

            m_QCObject = (qualitycontrol)context.QtO("qualitycontrol", "select * from qualitycontrol where the_partrecord_uid = '" + unique_id + "'");
            if (m_QCObject == null)
            {
                m_QCObject = qualitycontrol.New(context);
                m_QCObject.the_partrecord_uid = this.unique_id;
                m_QCObject.fullpartnumber = fullpartnumber;
                m_QCObject.alternatepart = alternatepart;
                context.Insert(m_QCObject);
            }
            return m_QCObject;
        }

        public void QCObjectSet(ContextRz context, qualitycontrol value)
        {
            m_QCObject = value;
        }

        public static partrecord Choose(ContextRz context, String strPartNumber)
        {
            return context.Logic.ChoosePart(strPartNumber);
            //if (p == null)
            //    return null;

            //offer o = null;
            //try
            //{
            //    return (partrecord)xForm.GetPartSearch().SelectedObject;
            //}
            //catch (Exception)
            //{
            //    try
            //    {
            //        o = (offer)xForm.GetPartSearch().SelectedObject;
            //        if (o != null)
            //        {
            //            if (!context.TheLeader.AskYesNo("You have chosen to link to an availability or offer. This offer will need to be converted into an excess item in order to be linked. Ok to continue?"))
            //                return null;
            //            return offer.ConvertToPartRecord(o, Enums.StockType.Excess);
            //        }
            //    }
            //    catch (Exception) { }
            //    return null;
            //}
        }


        //Public Virtual Functions

        //Public Override Functions
        private void ShowQCDetails(ContextRz context)
        {
            string id = context.SelectScalarString("select unique_id from qualitycontrol where the_partrecord_uid = '" + unique_id + "'");
            if (!Tools.Strings.StrExt(id))
            {
                if (!context.TheLeader.AskYesNo("No QC information is associated with this order.  Do you want to add a new QC record?"))
                    return;
                qualitycontrol qc = qualitycontrol.New(context);
                qc.the_partrecord_uid = unique_id;
                context.Insert(qc);
            }
            qualitycontrol CurrentQC = qualitycontrol.GetById(context, id);
            if (CurrentQC == null)
                return;
            ordhed CurrentOrder = new ordhed();
            orddet CurrentDetail = new orddet();
            context.TheLeaderRz.GetReceiveQuantityString_QC(context, this, CurrentOrder, CurrentDetail, 0);
        }
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            if (Tools.Strings.StrCmp(args.ActionName, "req"))
                args.Name = "newreq";
            if (Tools.Strings.StrCmp(args.ActionName, "quote"))
                args.Name = "givequote";
            if (Tools.Strings.StrCmp(args.ActionName, "converttobid") || Tools.Strings.StrCmp(args.ActionName, "getquote") || Tools.Strings.StrCmp(args.ActionName, "receivebid"))
                args.Name = "receivequote";
            switch (args.ActionName.ToLower())
            {
                case "givequote":
                    GiveQuote(xrz);
                    break;
                case "receivequote":
                    ReceiveBid(xrz);
                    break;
                case "showqcdetails":
                    ShowQCDetails(xrz);
                    break;
                case "scancofc":
                    Do_ScanCofC();
                    break;
                case "formalquote":
                    GiveAFormalQuote(xrz);
                    break;
                case "emailrfq":
                    EmailRFQ();
                    break;
                case "binbarcode":
                case "printbinlabel":
                    PrintBinLabel(xrz);
                    break;
                case "viewcompany":
                    ShowCompany(xrz);
                    break;
                case "printlabel":
                    PrintLabel();
                    break;
                case "printpartlabel":
                    PrintPartLabel();
                    break;
                case "calcaveragecost":
                    CalcAverageCost(xrz, true);
                    break;
                case "checkallocation":
                    CheckAllocation(xrz);
                    break;
                case "emailvendor":
                    EmailVendor(xrz);
                    break;
                case "setstock":
                    SetStockType(xrz, "Stock");
                    break;
                case "setbuy":
                    SetStockType(xrz, "Buy");
                    break;
                case "setconsign":
                    SetStockType(xrz, "Consign");
                    break;
                case "sendforservice":
                    SendForService(xrz);
                    break;
                case "hotpart":
                    xrz.Logic.NewHotPart(xrz, null, null, this.fullpartnumber);
                    break;
                case "split":
                    //KT - 4-26-2016  - Found this to be null, causing it not to function.
                    //Split(null);
                    Split(xrz);
                    break;
                case "viewpurchase":
                    ViewBuyPurchase(xrz);
                    break;
                case "viewsale":
                    ViewBuySale(xrz);
                    break;
                case "viewlinkedorders":
                    ViewLinkedOrders();
                    break;
                //case "companydetails":
                //    ShowCompanyDetails(xrz);
                //    break;
                case "rfq":
                    ShowNewRFQ((ContextRz)args.TheContext);
                    break;
                case "un-ship":
                    UnShip((ContextRz)args.TheContext, true);
                    break;
                default:
                    base.HandleAction(args);
                    return;
            }

            args.Handled = true;
        }

        public override void Updating(Context x)
        {
            ContextRz xrz = (ContextRz)x;

            PartObject.ParsePartNumber(this);
            String u = PartObject.StripPart(this.userdata_01);
            if (!Tools.Strings.StrCmp(u, userdata_01))
                userdata_01 = u;

            //this is already being done in ParsePartNumber
            //alternatepartstripped = Tools.Strings.FilterTrash(alternatepart);

            grid_color = GridColorCalc(x);
            if (StockType == Enums.StockType.Buy)
            {
                if (!Tools.Dates.DateExists(buy_date))
                    buy_date = System.DateTime.Now;
            }

            if (quantity == 0)
                ad_quantity = 0;

            quantity_available = quantity - quantityallocated;
            if (quantity_available < 0)
                quantity_available = 0;

            if (xrz.Logic.UpperCaseEverything)
            {
                fullpartnumber = fullpartnumber.ToUpper();
                manufacturer = manufacturer.ToUpper();
                description = description.ToUpper();
                datecode = datecode.ToUpper();
            }

            base.Updating(x);
        }
        public override String ToString()
        {
            return "Part " + this.fullpartnumber + " (" + nTools.NiceFormat(this.stocktype) + ")";
        }
        protected override int GridColorCalc(Context x)
        {
            //if (Tools.Strings.StrCmp(condition, "SUSPECT"))
            //    return 4;
            if (quantityallocated > 0)
            {
                if (quantityallocated == quantity)
                    return Color.Gray.ToArgb();
                else
                    return Color.Purple.ToArgb();
            }
            else
                return CalcColorByType(StockType, isarchivereq);
        }
        public static int CalcColorByType(Enums.StockType type)
        {
            return CalcColorByType(type, false);
        }
        public static int CalcColorByType(Enums.StockType type, bool telecom)
        {
            //if (Rz3App.xLogic.IsPMT)
            //{
            //    if (telecom)
            //        return System.Drawing.Color.SteelBlue.ToArgb();
            //    else
            //    {
            //        switch (type)
            //        {
            //            case Enums.StockType.Stock:
            //                return 2;
            //            case Enums.StockType.Consign:
            //                return 3;
            //            case Enums.StockType.Excess:
            //                return 0;
            //            case Enums.StockType.Buy:
            //                return System.Drawing.Color.Gray.ToArgb();
            //            default:
            //                return Color.Black.ToArgb();
            //        }
            //    }
            //}
            //else
            //{
            switch (type)
            {
                case Enums.StockType.Stock:
                    return System.Drawing.Color.Blue.ToArgb();
                case Enums.StockType.Consign:
                    return System.Drawing.Color.Green.ToArgb();
                case Enums.StockType.Excess:
                    return System.Drawing.Color.Red.ToArgb();
                case Enums.StockType.Buy:
                    return System.Drawing.Color.Gray.ToArgb();
                //KT
                case Enums.StockType.Master:
                    return System.Drawing.Color.DarkOrange.ToArgb();
                case Enums.StockType.Offers:
                    return System.Drawing.Color.Purple.ToArgb();
                default:
                    return Color.Black.ToArgb();
            }
            //}
        }
        public override String GetExtraClassInfo()
        {
            return stocktype;
        }
        public override String GetClipHTML(ContextNM x)
        {
            String s = GetClipHeader(x);

            s += PartObject.GetClipLine_Part(this);
            return s;
        }
        //Public Functions
        public String CompanyName
        {
            get { return companyname; }
            set { companyname = value; }
        }
        public String CompanyID
        {
            get { return base_company_uid; }
            set { base_company_uid = value; }
        }
        public String ContactName
        {
            get { return companycontactname; }
            set { companycontactname = value; }
        }
        public String ContactID
        {
            get { return base_companycontact_uid; }
            set { base_companycontact_uid = value; }
        }
        public company GetCompanyObject(ContextRz context)
        {
            return (company)context.GetById("company", base_company_uid);
        }
        public companycontact GetContactObject(ContextRz context)
        {
            return (companycontact)context.GetById("companycontact", base_companycontact_uid);
        }
        public void ViewBuyPurchase(ContextRz context)
        {
            ordhed_purchase o = ordhed_purchase.GetById(context, buy_purchase_id);
            if (o == null)
            {
                context.TheLeader.Tell("This item doesn't appear to be linked to a specific purchase order.");
                return;
            }
            context.Show(o);
        }

        public void ShowNewRFQ(ContextRz context)
        {
            ordhed h = ordhed.CreateNew(context, Enums.OrderType.RFQ);
            h.CompanyVar.RefSet(context, GetCompanyObject(context));
            context.Update(h);

            orddet_rfq d = (orddet_rfq)h.AddLineItem(context, fullpartnumber, quantity, 0);
            d.fullpartnumber = fullpartnumber;
            d.manufacturer = manufacturer;
            d.datecode = datecode;
            d.condition = condition;
            d.quantityordered = 0;
            d.unitprice = 0;
            d.target_price = 0;
            d.target_quantity = Convert.ToInt32(quantity);
            //d.stockid = "";
            context.Update(d);

            context.Show(h);
        }

        public void ViewBuySale(ContextRz context)
        {
            ordhed o = ordhed.GetById(context, buy_sales_id);
            if (o == null)
            {
                context.TheLeader.Tell("This item doesn't appear to be linked to a specific sales order.");
                return;
            }
            context.Show(o);
        }
        //public override void ShowCompanyDetails(ContextRz context)
        //{
        //    try
        //    {
        //        String showtext = "";
        //        if (!Tools.Strings.StrExt(base_company_uid))
        //            showtext = "There is no linked company.";
        //        else
        //        {
        //            company c = company.GetById(context, base_company_uid);
        //            if (c == null)
        //                showtext = "This company was not found in the system.";
        //            else
        //            {
        //                showtext = c.companyname + "\r\n";
        //                companyaddress ca = companyaddress.GetByDescription(context, c.unique_id, "Billing");
        //                if (ca != null)
        //                {
        //                    if (Tools.Strings.StrExt(ca.line1) && !Tools.Strings.StrCmp(c.companyname, ca.line1))
        //                        showtext += ca.line1 + "\r\n";
        //                    if (Tools.Strings.StrExt(ca.line2) && !Tools.Strings.StrCmp(c.companyname, ca.line2))
        //                        showtext += ca.line2 + "\r\n";
        //                    if (Tools.Strings.StrExt(ca.line3) && !Tools.Strings.StrCmp(c.companyname, ca.line3))
        //                        showtext += ca.line3 + "\r\n";
        //                    String csz = "";
        //                    if (Tools.Strings.StrExt(ca.adrcity))
        //                        csz += ca.adrcity;
        //                    if (Tools.Strings.StrExt(ca.adrstate))
        //                    {
        //                        if (Tools.Strings.StrExt(csz))
        //                            csz += ", " + ca.adrstate;
        //                        else
        //                            csz += ca.adrstate;
        //                    }
        //                    if (Tools.Strings.StrExt(ca.adrzip))
        //                    {
        //                        if (Tools.Strings.StrExt(csz))
        //                            csz += " " + ca.adrzip;
        //                        else
        //                            csz += ca.adrzip;
        //                    }
        //                    if (Tools.Strings.StrExt(csz))
        //                        showtext += csz + "\r\n";
        //                }
        //                if (Tools.Strings.StrExt(c.primaryphone))
        //                    showtext += "Phone: " + c.primaryphone + "\r\n";
        //                if (Tools.Strings.StrExt(c.primaryfax))
        //                    showtext += "Fax: " + c.primaryfax + "\r\n";
        //                if (Tools.Strings.StrExt(c.primaryemailaddress))
        //                    showtext += "Email: " + c.primaryemailaddress + "\r\n";
        //            }
        //        }
        //        context.TheLeader.AskForString("", showtext, true, "Company Summary");
        //    }
        //    catch (Exception)
        //    { }
        //}
        public void Split(ContextRz context)
        {

            if (quantity < 2)
            {
                context.TheLeader.Tell("An inventory line needs to have a quantity of at least 2 for splitting.");
                return;
            }

            string s = context.TheLeader.AskForString("Please enter the entire quantity list that you want to split into, separated by semicolons ( 21; 32; 43; etc).", "", false, "Quantities");
            if (!Tools.Strings.StrExt(s))
                return;

            s = s.Replace("\r\n", ";");
            String[] ary = Tools.Strings.Split(s, ";");
            ArrayList qtys = new ArrayList();
            foreach (String q in ary)
            {
                if (Tools.Number.IsNumeric(q.Trim()))
                {
                    try
                    {
                        Int64 l = Convert.ToInt64(q.Trim());
                        qtys.Add(l);
                    }
                    catch (Exception)
                    { }
                }
            }


            long total = 0;
            foreach (Int64 l in qtys)
            {
                total += l;
            }
            /*
            KT - I don't like asking user to do the math up front.  
            I would rather derive the remainder qty based of what user asked to split.
            */
            //if (qtys.Count < 2)
            //    return;
            //if (total != quantity)
            //{
            //    context.TheLeader.Tell("Please enter a list of quantities that adds up to " + Tools.Number.LongFormat(quantity) + ".");
            //    return;
            //}           
            if (!context.TheLeader.AreYouSure("split " + this.ToString() + " into " + Tools.Number.LongFormat(qtys.Count) + " separate lines"))
                return;


            context.TheLeader.StartPopStatus();
            context.TheLeader.Comment("Splitting " + this.ToString() + "...");
            //int i = 0;
            //foreach (Int64 l in qtys)
            //{
            //    if (i == 0)
            //    {
            //        //nothing; each split will also subtract the quantity here
            //        //this.quantity = l;
            //        //ISave();
            //        //context.TheLeader.Comment("Saved " + GetFriendlyName() + " with a quantity of " + Tools.Number.LongFormat(quantity));
            //    }
            //    else
            //    {
            //        Split(context, l);
            //    }

            //    i++;
            //}
            foreach (Int64 l in qtys)
            {
                {
                    Split(context, l);
                }

            }
            context.TheLeader.Comment("Done.");
            context.TheLeader.StopPopStatus(true);
        }

        public partrecord Split(ContextRz context, Int64 splitQuantity)
        {
            partrecord p = (partrecord)this.CloneValues(context);
            p.quantity = splitQuantity;

            //KT 4-26-2016
            p.quantityallocated = splitQuantity;
            context.TheDelta.Insert(context, p);

            quantity -= splitQuantity;
            //KT 4-26-2016
            quantityallocated -= splitQuantity;
            context.TheDelta.Update(context, this);

            context.TheLeader.Comment("Split " + p.ToString() + " with a quantity of " + Tools.Number.LongFormat(p.quantity));
            return p;
        }

        private void GiveQuote(ContextRz context)
        {
            context.Reorg();
            //company comp = null;
            //companycontact cont = null;
            //if (!ChooseCompany(SysRz4.Context, "Customer", ref comp, ref cont))
            //    return;
            //string comp_id = "";
            //string cont_id = "";
            //if (comp == null)
            //    return;
            //comp_id = comp.unique_id;
            //if (cont != null)
            //    cont_id = cont.unique_id;
            ////needs to hit the leader
            //dealheader.ShowNewReqInDeal(context, fullpartnumber, false, DoThrowReq(), comp_id, cont_id, this);
        }
        private void ReceiveBid(ContextRz context)
        {
            context.Reorg();
            //company comp = null;
            //companycontact cont = null;
            //if (!ChooseCompany(SysRz4.Context, "Vendor", ref comp, ref cont))
            //    return;
            //string comp_id = "";
            //string cont_id = "";
            //if (comp == null)
            //    return;
            //comp_id = comp.unique_id;
            //if (cont != null)
            //    cont_id = cont.unique_id;
            //dealheader.ShowNewReqInDeal(SysRz4.Context, fullpartnumber, true, DoThrowReq(), comp_id, cont_id, this);
        }
        protected virtual bool DoThrowReq()
        {
            return false;
        }
        private bool ChooseCompany(ContextNM x, string Caption, ref company comp, ref companycontact cont)
        {
            x.Reorg();
            return false;
            //String strCaption = "";
            //String strCompanyID = "";
            //String strCompanyName = "";
            //String strContactID = "";
            //String strContactName = "";
            //strCaption = "Please choose a " + Caption;
            //frmChooseCompany_Big.ChooseCompanyID(ref strCompanyID, ref strCompanyName, ref strContactID, ref strContactName, Rz4.Enums.CompanySelectionType.Both, strCaption, null);
            //if (!Tools.Strings.StrExt(strCompanyID))
            //    return false;
            //companycontact ct = null;
            //if (((SysRz4)xSys).TheCompanyLogic.IsContactBadAccount(x, strContactID, ref ct))
            //{
            //    x.TheLeader.Error(ct.ToString() + " is marked as a bad account and cannot be used.");
            //    comp = null;
            //    cont = null;
            //    return false;                                   
            //}
            //comp = company.GetByID(x.xSys, strCompanyID);
            //cont = companycontact.GetByID(x.xSys, strContactID);
            //if (comp.problem_vendor && Tools.Strings.StrCmp(Caption, "vendor"))
            //    context.TheLeader.Tell("Please Note: the vendor: " + comp.companyname + " has been flagged as a problem vendor");
            //return true;
        }

        public void GiveAFormalQuote(ContextNM context)
        {
            MessageBox.Show("reorg");
            //ordhed o = ordhed.CreateNew(context, Enums.OrderType.Quote);
            //o.ISave();
            //orddet d = o.LineCreate();
            //d.AbsorbPartRecord(this);
            //d.ISave();
            //Rz3App.context.Show(o);
        }

        public void Do_ScanCofC()
        {
            MessageBox.Show("reorg");
            //DocumentScanner s = new DocumentScanner();
            //Rz3App.xMainForm.TabShow(s, "C of C's On " + GetFriendlyName());
            //s.CompleteLoad(this);
        }

        public void EmailRFQ()
        {
            throw new NotImplementedException("Partrecord.EmailRFQ");
        }
        public void PrintBinLabel(ContextRz x)
        {
            ArrayList colObjects = new ArrayList();
            colObjects.Add(this);
            colObjects.Add(x.xUser);
            Tools.Dymo.PrintDymoLabel(x, "stock", colObjects);
        }
        public void ShowCompany(ContextRz context)
        {
            company c = this.GetCompanyObject(context);
            if (c != null)
                context.Show(c);
        }
        public void PrintLabel()
        {
            //if (!Rz3App.xLogic.IsAAT)
            //{
            //    throw new NotImplementedException("Partrecord.PrintLabel");
            //    return;
            //}
            //PrintBarcodeLabel(Rz3App.xMainForm);
        }
        public bool PrintBarcodeLabel(System.Windows.Forms.IWin32Window owner)
        {
            MessageBox.Show("reorg");
            //orddet d = new orddet(xSys);
            //d.unique_id = "<none>";
            //d.quantityfilled = quantity;
            //d.datecode = datecode;
            //d.condition = condition;
            //d.manufacturer = manufacturer;
            //d.companyname = Rz3App.OwnerSettings.CompanyName;
            //d.fullpartnumber = fullpartnumber;
            //ArrayList colObjects = new ArrayList();
            //colObjects.Add(d);
            //colObjects.Add(Rz3App.xUser);
            //if (!nTools.PrintDymoLabel(xSys, "outgoing_line_item", colObjects))
            //    return false;
            return true;
        }
        public void PrintPartLabel()
        {
            throw new NotImplementedException("Partrecord.PrintPartLabel");
        }
        public void CalcAverageCost(ContextRz context, bool show)
        {
            this.averagecost = context.SelectScalarDouble("select round(avg(unitprice), 4) from " + ordhed.MakeOrddetName(Enums.OrderType.Purchase) + " where unitprice > 0 and ordertype = 'PURCHASE' and (fullpartnumber = '" + context.Filter(fullpartnumber) + "' or stockid = '" + context.Filter(unique_id) + "')");
            context.Update(this);

            if (show)
                context.TheLeader.Tell("The average cost for part '" + fullpartnumber + "' is " + averagecost.ToString());
        }
        public void CheckAllocation(ContextRz context)
        {
            long l = GetAllocation(context);
            context.TheLeader.Tell("The part '" + fullpartnumber + "' has an allocated quantity of " + l.ToString() + ".");
        }
        public long GetAllocation(ContextRz context)
        {
            return context.SelectScalarInt64("select sum(quantityordered - quantityfilled) from orddet od inner join ordhed oh on oh.unique_id = od.base_ordhed_uid where oh.isvoid = 0 and oh.isclosed = 0 and od.stockid = '" + unique_id + "'");
        }

        public bool EmailVendor(ContextRz context)
        {
            emailtemplate t = context.TheLeaderRz.AskForEmailTemplate(this);
            if (t == null)
                return false;

            String strAddress = GetEmailAddress(context);
            return t.SendGeneralEmail(context, this, strAddress);
        }
        public String GetEmailAddress(ContextRz context)
        {
            //String strAddress = companyemailaddress;

            String strAddress = "";

            if (!Tools.Strings.StrExt(strAddress))
                strAddress = company.GetEmailByID(context, base_company_uid);

            if (!Tools.Strings.StrExt(strAddress))
                strAddress = companycontact.GetEmailByID(context, base_companycontact_uid);

            return strAddress;
        }
        protected virtual long GetSplitBuyConsignQty(long q)
        {
            return q;
        }
        public partrecord SplitBuy(ContextRz context, long q, String strPurchaseID, String strSalesID, String strSalesCaption)
        {
            partrecord p = (partrecord)CloneValues(context);

            switch (p.StockType)
            {
                case Enums.StockType.Excess: //for excess, it needs to be purchased
                    p.quantity = 0;
                    break;
                case Enums.StockType.Consign:    //for consigned, its already here, and the PO line needs to be auto-filled, except for phoenix
                    //if (Rz3App.xLogic.IsPhoenix)
                    //    p.quantity = 0;
                    //else
                    //    p.quantity = q;
                    p.quantity = GetSplitBuyConsignQty(q);
                    break;
                default:  //for stock, its already here.
                    p.quantity = q;
                    break;
            }

            p.SetBuy();
            p.buy_date = System.DateTime.Now;
            p.buy_purchase_id = strPurchaseID;
            p.sales_caption = strSalesCaption;
            p.buy_sales_id = strSalesID;
            p.original_stocktype = stocktype;
            p.original_unique_id = unique_id;
            context.Insert(p);
            quantity -= q;
            context.Update(this);
            return p;
        }
        public void SetBuy()
        {
            SetBuy("", "");
        }
        public void SetBuy(String strSalesID, String strSalesCaption)
        {
            switch (StockType)
            {
                case Enums.StockType.Excess: //for excess, it needs to be purchased
                case Enums.StockType.Offers:
                    quantity = 0;
                    break;
            }

            buy_sales_id = strSalesID;
            sales_caption = strSalesCaption;
            buy_date = DateTime.Now;
            original_stocktype = stocktype;
            StockType = Enums.StockType.Buy;
        }
        public void ViewLinkedOrders()
        {
            MessageBox.Show("reorg");
            //nList l = new nList();
            //xSys.ThrowObjectList("orddet", "stockid = '" + unique_id + "' or original_stock_id = '" + unique_id + "'", "orderdate", "orddet_general", -1, "Linked Orders");
        }
        public Enums.StockType StockType
        {
            get
            {
                return PartObject.ConvertStockType(stocktype);
            }

            set
            {
                stocktype = value.ToString();
            }
        }
        public void AbsorbOrderDetail(orddet xDetail)
        {
            MessageBox.Show("reorg");

            //fullpartnumber = xDetail.fullpartnumber;
            //quantity = xDetail.quantityordered;
            //packaging = xDetail.packaging;
            //condition = xDetail.condition;
            //manufacturer = xDetail.manufacturer;
            //datecode = xDetail.datecode;
            //partsetup = xDetail.partsetup;
            //partsperpack = xDetail.partsperpack;
            //location = xDetail.location;
            //description = xDetail.description;
            //buytype = xDetail.buytype;
            //lotnumber = xDetail.lotnumber;
            //category = xDetail.category;
            //boxnum = xDetail.boxnum;
            //alternatepart = xDetail.alternatepart;
            ////cost = xDetail.unitcost;
            //userdata_02 = xDetail.alternatepart_02;
            //mfg_certifications = xDetail.mfg_certifications;

            //if (Tools.Strings.StrCmp(xDetail.ordertype, "PURCHASE") || Tools.Strings.StrCmp(xDetail.ordertype, "RMA") || Tools.Strings.StrCmp(xDetail.ordertype, "RFQ"))
            //{
            //    cost = xDetail.unitprice;
            //    companyname = xDetail.companyname;
            //}
            //else if (Tools.Strings.StrCmp(xDetail.ordertype, "QUOTE") || Tools.Strings.StrCmp(xDetail.ordertype, "SALES"))
            //{
            //    price = xDetail.unitprice;
            //    cost = xDetail.unitcost;
            //}
        }

        public String Whatever()
        {
            return Tools.Strings.GetNewID();
        }

        public virtual void SendForService(ContextRz context)
        {
            ordhed_service s = null;

            MakeOrderArgs oargs = context.TheLeaderRz.AskForMakeOrderArgs(Enums.OrderType.Service);

            if (oargs.Canceled)
                return;

            if (oargs.UseOrder != null)
            {
                try
                {
                    s = (ordhed_service)oargs.UseOrder;
                }
                catch { }
            }

            if (s == null)
            {
                s = (ordhed_service)ordhed.CreateNew(context, Enums.OrderType.Service);
                context.Update(s);
            }

            orddet_line d = s.DetailsVar.RefAddNew(context);

            //2012_11_21 removed; RefAddNew already inserts
            //context.Insert(d);
            d.fullpartnumber = this.fullpartnumber;
            d.manufacturer = this.manufacturer;
            d.description = this.description;
            d.internalcomment = "Pull from location: " + this.location;
            d.quantity = Convert.ToInt32(this.quantity);
            context.Update(d);
            context.Show(s);
        }

        //Private Functions
        private void SetStockType(ContextRz context, String strType)
        {
            stocktype = strType;
            context.Update(this);
        }


        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return context.xSys.ThePermitLogic.CheckPermit(context, Permissions.ThePermits.EditInventoryLineItems, context.xUser);
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return context.xSys.ThePermitLogic.CheckPermit(context, Permissions.ThePermits.DeleteInventoryLineItems, context.xUser);
            //return context.xUser.SuperUser || context.xUser.CheckPermit(context, "Inventory:Delete:CanDeleteInventory", true);
        }

        public static bool ShippedTableCheckedAlready = false;
        public static void ShippedTableCheck(ContextRz context)
        {
            if (ShippedTableCheckedAlready)
                return;

            ShippedTableCheckedAlready = true;
            DataSql.StructureCheckClass(context, context.TheSys.CoreClassGet("partrecord"), "shipped_stock");
        }

        public virtual void ShippedHandle(ContextRz context, String reference, bool confirm)
        {
            this.internalcomment += (" Shipped " + Tools.Dates.DateFormat(DateTime.Now) + " - " + reference);
            ShippedHandle(context);
        }

        public void ShippedHandle(ContextRz context)
        {
            ShippedTableCheck(context);
            this.dateconfirmed = DateTime.Now;
            //string original_partrecordUID = '';
            context.Delete(this);
            this.MoveTo(context, "shipped_stock");

            context.TheLeader.Comment("Moved " + ToString() + " to the Shipped Archive");
        }

        //public void Allocate(ContextRz context, int qty, String reference, String id)
        //{

        //    if (qty <= 0)
        //    {
        //        context.TheLeader.Error("Cannot allocate a non-positive quantity");
        //        return;
        //    }
        //    List<Allocation> allocs = Allocations;
        //    foreach (Allocation a in allocs)
        //    {
        //        //KT - removed the check for reference on 8-5-2014:  Reason: Since Sales Order numbers change, there was not "match" thus ax was always null, causign the AllocateUN to not remove the allocated notes.
        //        //if (Tools.Strings.StrCmp(a.Reference, reference))
        //        //{
        //        if (Tools.Strings.StrExt(id) && Tools.Strings.StrExt(a.ID))
        //        {
        //            if (Tools.Strings.StrCmp(a.ID, id))
        //            {
        //                if (a.Quantity != qty)
        //                {
        //                    //KT 10-14-2019 //The commented code below was preventing ship.  When the alloc qty matched the parameter qty, we were Unallocating, which doesn't make sense to me.  Now I am unallocating if the QTYS don't match.  
        //                    //We can properly Allocate. 

        //                    if (context.Leader.AskYesNo("Quantity mismatch between the quantity to ship, and the quantity allocated.  Would you like to delete the allocation?"))
        //                        AllocateUn(context, a.Quantity, a.Reference, a.ID);

        //                    return;
        //                }
        //                //if (a.Quantity == qty)
        //                //{
        //                //    //KT 4-20-2016 - This return is causing allocation to not get set.
        //                //    if (context.Leader.AskYesNo("Quantity mismatch between the quantity to ship, and the quantity allocated.  Would you like to delete the allocation?"))
        //                //        AllocateUn(context, a.Quantity, a.Reference, a.ID);

        //                //    return;
        //                //}
        //                //else
        //                //    AllocateUn(context, a.Quantity, a.Reference, a.ID);
        //            }
        //        }
        //        else
        //        {
        //            if (a.Quantity == qty)
        //                return;
        //            else
        //                AllocateUn(context, a.Quantity, a.Reference, a.ID);
        //        }
        //        //}


        //    }
        //    allocs = Allocations;
        //    allocs.Add(new Allocation(reference, qty, DateTime.Now, id));
        //    quantityallocated += qty;
        //    allocated_notes = Allocation.Join(allocs);
        //    try
        //    {
        //        context.Update(this);
        //    }
        //    catch
        //    { }
        //    //}
        //}
        public void Allocate(ContextRz x, int allocQty, String reference, String id)
        {
            //This is problematic, since it operates in the context of the actual partrecord, I can't use this method to update say a newly created partreco
            if (allocQty <= 0)
            {
                x.TheLeader.Error("Cannot allocate a non-positive quantity");
                return;
            }
            if (allocQty > this.quantity)
            {
                throw new Exception("Not enought stock quantity to allocation.  Current stock qty: " + this.quantity);
            }
            this.allocated_notes = reference;
            //this.quantity += allocQty;
            this.quantityallocated += allocQty;
            this.Update(x);
        }

        public bool AllocateUn(ContextRz x, long allocQty, String reference, String id)
        {
            //IF already no allocation, then don't allocate into the negative.
            if (this.quantityallocated == 0)
                return true;
            //does the part have enough quantity to un-allocate?
            if(allocQty > quantityallocated)
            {
                x.Leader.Error("Cannot un-allocate qty: " + allocQty + ", the partrecod only has qty: " + quantityallocated + " curretnly allocated.");
                return false;
            }
               
            this.allocated_notes = "";
            this.quantityallocated-=allocQty;
            //this.quantity -= allocQty;
            this.Update(x);
            return true;
        }
        //public bool AllocateUn(ContextRz context, long allocQty, String reference, String lineID, bool silent)
        //{
        //    //Confirm valid QTY to allocate.
        //    if (allocQty <= 0)
        //    {
        //        if (!silent)
        //            context.TheLeader.Error("Cannot un-allocate a non-positive quantity");
        //        return false;
        //    }
        //    //Confirm we have enoght qty to allocate.
        //    if (allocQty > quantityallocated)
        //    {
        //        if (!silent)
        //            context.TheLeader.Error("Only " + Tools.Number.LongFormat(quantityallocated) + " are allocated.  Can't un-allocate a greater quantity than the existing allocation qty.");
        //        return false;
        //    }
        //    //Allocations are just a string value, need to be matched then separated
        //    Allocation ax = null;
        //    //The below lsit "alls" is a list of the existing allocations found on a partrecord
        //    List<Allocation> alls = Allocations;
        //    foreach (Allocation a in alls)
        //    {
        //        //KT - removed the check for reference on 8-5-2014:  Reason: Since Sales Order numbers change, there was not "match" thus ax was always null, causign the AllocateUN to not remove the allocated notes.
        //        //if (Tools.Strings.StrCmp(a.Reference, reference))
        //        //{
        //        //Check to see if the allocation is the one for this line item.
        //        if (Tools.Strings.StrExt(lineID) && Tools.Strings.StrExt(a.ID))
        //        {
        //            if (Tools.Strings.StrCmp(a.ID, lineID))
        //            {
        //                ax = a;
        //                break;
        //            }
        //        }
        //        //else
        //        //{
        //        //    ax = a;
        //        //    break;
        //        //}
        //        //}
        //    }
        //    if (ax == null)//No Allocation Found.
        //    {
        //        if (!silent)
        //            //KT changed the below to be more informational
        //            //context.TheLeader.Error("This item is not allocated on " + reference);
        //            context.TheLeader.Error(fullpartnumber + " is not allocated on " + reference);
        //        return false;
        //    }
        //    //if (ax.Quantity != allocQty)
        //    //{
        //    //    if (!silent)
        //    //        context.TheLeader.Error("This item is allocated on " + reference + " for " + Tools.Number.LongFormat(ax.Quantity));
        //    //    return false;
        //    //}
        //    quantityallocated -= allocQty;
        //    alls.Remove(ax);
        //    allocated_notes = Allocation.Join(alls);
        //    context.Update(this);
        //    return true;
        //}

        public List<Allocation> Allocations
        {
            get
            {
                return Allocation.Split(allocated_notes);
            }
        }

        public virtual void UnShip(ContextRz context, bool notify)
        {
            if (context.Connection.StatementExists("select unique_id from partrecord where unique_id = '" + context.Filter(unique_id) + "'"))
                throw new Exception("This part's unique identifier is already in inventory");

            if (notify)
            {
                if (!context.Leader.AreYouSure("un-ship " + ToString()))
                    return;
            }

            TableName = "partrecord";
            internalcomment += "\r\nUn-Shipped by " + context.xUser.name + " on " + DateTime.Now.ToString();
            InsertWithExistingId(context);
            context.Execute("delete from shipped_stock where unique_id = '" + unique_id + "'");

            if (notify)
                context.Leader.Tell("Done");
        }

        static List<String> CheckedAlready = new List<string>();
        public static void TableCheck(ContextRz context, String tableName, String dateField, String referenceField, String userField)
        {
            if (CheckedAlready.Contains(tableName.ToLower()))
                return;

            CheckedAlready.Add(tableName.ToLower());
            DataSql.StructureCheckClass(context, context.Sys.CoreClassGet("partrecord"), tableName);
            DataSql.FieldMaintenance(context, context.Connection, context.Sys.CoreClassGet("partrecord"), tableName);

            context.Data.FieldMakeExist(tableName, new Field(dateField, FieldType.DateTime));
            context.Data.FieldMakeExist(tableName, new Field(referenceField, FieldType.String, 8000));
            context.Data.FieldMakeExist(tableName, new Field(userField, FieldType.String, 8000));
        }

        public static void BulkMove(ContextRz x, String tableName, String dateField, String referenceField, String userField, String reference, String where, bool confirm = true, bool copyOnly = false)
        {
            int countBefore = x.TheData.TheConnection.ScalarInt32("select count(*) from partrecord where " + where);

            if (confirm && !copyOnly)
            {
                if (!x.TheLeader.AreYouSure("mark " + Tools.Strings.PluralizePhrase("line", countBefore) + " as " + Tools.Strings.NiceFormat(Tools.Strings.ParseDelimit(tableName, "_", 1))))
                    return;
            }

            TableCheck(x, tableName, dateField, referenceField, userField);

            StringBuilder fields = new StringBuilder();
            fields.Append(", unique_id");
            StringBuilder values = new StringBuilder();
            values.Append(", unique_id");

            CoreClassHandle c = x.Sys.CoreClassGet("partrecord");
            if (c == null)
                throw new Exception("Partrecord class not found");

            foreach (CoreVarAttribute p in c.VarValsGet())
            {
                List<Field> pFields = new List<Field>();
                p.FieldsAppend(pFields);
                foreach (Field f in pFields)
                {
                    fields.Append(", " + f.Name);
                    values.Append(", " + f.Name);
                }
            }

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("insert into " + tableName + " ( " + dateField + ", " + referenceField + ", " + userField + fields.ToString() + " ) select getdate(), '" + x.Filter(reference) + "', '" + x.Filter(x.xUser.name) + "'" + values.ToString() + " from partrecord where " + where);
            if (!copyOnly)
                sql.AppendLine("delete from partrecord where " + where);
            x.TheData.TheConnection.ExecuteTransaction(sql.ToString());

            if (copyOnly)
            {
                if (confirm)
                    x.TheLeader.Tell("Done: copied to " + Tools.Strings.NiceFormat(tableName));  //" + Tools.Strings.PluralizePhrase("line", countBefore) + "  2012_08_15 took out line count because the insert itself could be in a transaction
            }
            else
            {
                int countAfter = x.TheData.TheConnection.ScalarInt32("select count(*) from partrecord where " + where);
                if (countAfter > 0)
                    throw new Exception("Parts remaining after move process");

                if (confirm)
                    x.TheLeader.Tell("Done: moved to " + Tools.Strings.NiceFormat(tableName));  //" + Tools.Strings.PluralizePhrase("line", countBefore) + "  2012_08_15 took out line count because the insert itself could be in a transaction
            }
        }

        public account IncomeAccount
        {
            set
            {
                income_account_uid = value.Uid;
                income_account_name = value.name;
            }
        }

        public account AssetAccount
        {
            set
            {
                asset_account_uid = value.Uid;
                asset_account_name = value.name;
            }
        }

        public account COGSAccount
        {
            set
            {
                cogs_account_uid = value.Uid;
                cogs_account_name = value.name;
            }
        }

        public void QuantityAdjustment(ContextRz context)
        {
            int newQuantity = context.Leader.AskForInt32("New quantity", Convert.ToInt32(quantity), "New quantity");
            if (newQuantity == quantity)
                return;

            QuantityAdjustment(context, newQuantity);
        }

        public void QuantityAdjustment(ContextRz context, int newQuantity)
        {
            account accountToUse = null;

            if (newQuantity > quantity)
            {
                accountToUse = context.TheSysRz.TheAccountLogic.ChooseAnAccount(context, "Income account for the additional value", new AccountCriteria(AccountCategory.Income));
            }
            else
            {
                accountToUse = context.TheSysRz.TheAccountLogic.ChooseAnAccount(context, "Expense account for the lost value", new AccountCriteria(AccountCategory.Expense));
            }

            if (accountToUse == null)
                return;

            QuantityAdjustment(context, newQuantity, accountToUse);
        }

        public void QuantityAdjustment(ContextRz context, int newQuantity, account deltaAccount)
        {
            account assetAccount = context.Accounts.GetAccount(context, asset_account_uid);
            if (assetAccount == null)
                throw new Exception("An inventory item must have an asset account before an adjustment can be made");

            bool increasedValue = false;
            String sign = "";
            int quantityDelta = Math.Abs(newQuantity - Convert.ToInt32(quantity));
            Double valueDelta = quantityDelta * cost;

            if (newQuantity > quantity)
            {
                increasedValue = true;
                sign = "+";
            }
            else
            {
                increasedValue = false;
                sign = "-";
            }

            JournalEntry entry = new JournalEntry("Inventory adjustment");
            entry.Add(context, assetAccount, increasedValue ? valueDelta : 0, increasedValue ? 0 : valueDelta);  //asset accounts increase on the debit side
            entry.Add(context, deltaAccount, increasedValue ? 0 : valueDelta, increasedValue ? valueDelta : 0);  //income or equity accounts increase on the credit side            
            entry.Sql.Add("update partrecord set quantity = quantity " + sign + " " + quantityDelta.ToString() + " where unique_id = '" + unique_id + "'");
            entry.Post(context);

            if (increasedValue)
                quantity += quantityDelta;
            else
                quantity -= quantityDelta;
        }
    }

    public class PartSearchParameters
    {
        public string AgentID = "";
        public String SearchTerm = "";
        public bool ReplaceVisual = false;
        public bool IncludeStock = false;
        public bool IncludeConsign = false;
        public bool IncludeExcess = false;
        public bool IncludeAllocated = false;
        //KT Include Master
        public bool IncludeMaster = false;
        public bool IncludeOffers = false;
        public SearchComparison TheComparison;
        public PartSearchTarget TheTarget;
        public bool IncludeAlternatePart = false;
        public bool IncludeAllAlternates = false;
        public bool IncludeInternalPart = false;
        public bool IncludeUserDefined = false;
        public bool Simple = false;
        public String TableName = "";
        public bool IncludeZeroQuantity = true;
        public bool UnlimitedResults = false;
        public string CompanyName = "";
        public string CompanyID = "";
        public bool ShippedStock = false;

        public PartSearchParameters(String part)
        {
            SearchTerm = part;
        }

        public PartSearchParameters(PartSearchParameters pars)
        {
            SearchTerm = pars.SearchTerm;
            ReplaceVisual = pars.ReplaceVisual;
            IncludeStock = pars.IncludeStock;
            IncludeConsign = pars.IncludeConsign;
            IncludeExcess = pars.IncludeExcess;
            IncludeAllocated = pars.IncludeAllocated;
            TheComparison = pars.TheComparison;
            TheTarget = pars.TheTarget;
            IncludeAlternatePart = pars.IncludeAlternatePart;
            IncludeAllAlternates = pars.IncludeAllAlternates;
            IncludeInternalPart = pars.IncludeInternalPart;
            IncludeUserDefined = pars.IncludeUserDefined;
            Simple = pars.Simple;
            TableName = pars.TableName;
        }
    }

    public enum PartSearchTarget
    {
        All = 0,
        Part = 1,
        Manufacturer = 2,
        DateCode = 3,
        Description = 4,
        Location = 5,
        BoxNum = 6,
        Serial = 7,
    }

    public class Allocation
    {
        public String ID;
        public String Reference;
        public int Quantity;
        DateTime TheDate;

        public Allocation(String all)
        {
            Reference = Tools.Strings.ParseDelimit(all, ":", 1).Replace("[", "").Trim();
            try
            {
                Quantity = Int32.Parse(Tools.Strings.ParseDelimit(all, ":", 2).Replace("]", "").Trim());
            }
            catch { }

            try
            {
                TheDate = DateTime.Parse(Tools.Strings.ParseDelimit(all, ":", 3).Replace("]", "").Trim());
            }
            catch { TheDate = DateTime.Now; }

            try
            {
                ID = Tools.Strings.ParseDelimit(all, ":", 4).Replace("]", "").Trim();
            }
            catch { }
        }

        public Allocation(String reference, int quantity, DateTime date, String id)
        {
            Reference = reference;
            Quantity = quantity;
            TheDate = date;
            ID = id;

        }

        public override string ToString()
        {
            return "[" + Reference.Replace(":", "").Replace("[", "").Replace("]", "").Trim() + " : " + Quantity.ToString() + " : " + Tools.Dates.DateFormat(TheDate) + " : " + ID + "]";
        }

        public static List<Allocation> Split(String allocations)
        {
            List<Allocation> ret = new List<Allocation>();
            List<String> lines = Tools.Strings.SplitLinesList(allocations);
            foreach (String l in lines)
            {
                if (l.StartsWith("[") && l.EndsWith("]") && l.Contains(":"))
                {
                    ret.Add(new Allocation(l));
                }
            }

            return ret;
        }

        public static String Join(List<Allocation> allocations)
        {
            StringBuilder sb = new StringBuilder();
            bool first = true;
            foreach (Allocation a in allocations)
            {
                if (!first)
                    sb.Append("\r\n");

                sb.Append(a.ToString());

                first = false;
            }
            return sb.ToString();
        }
    }
}
