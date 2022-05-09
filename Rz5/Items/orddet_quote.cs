using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class orddet_quote : orddet_quote_auto
    {
        public orddet_quote MyReq = null;

        public override Enums.OrderType OrderType
        {
            get
            {
                return Enums.OrderType.Quote;
            }
            set
            {
                if (value != Enums.OrderType.Quote)
                    throw new Exception("Invalid order type");
                base.OrderType = value;
            }
        }

        protected override void ParentDetailAbsorb(ContextRz context, orddet parent)
        {
            base.ParentDetailAbsorb(context, parent);
            if (parent == null)
                the_orddet_rfq_uid = "";
            else
                the_orddet_rfq_uid = parent.unique_id;
        }

        protected override void ParentDetailCache(ContextRz context)
        {
            base.ParentDetailCache(context);
            if (Tools.Strings.StrExt(the_orddet_rfq_uid))
                m_ParentDetail = orddet_rfq.GetById(context, the_orddet_rfq_uid);
        }

        ArrayList m_ServiceDetails;
        public ArrayList ServiceDetailsGet(ContextRz context)
        {
            if (m_ServiceDetails == null)
                CacheServiceDetails(context);
            return m_ServiceDetails;
        }

        public void ServiceDetailsSet(ArrayList value)
        {
            m_ServiceDetails = value;
        }

        //Constructor
        public orddet_quote()
        {
            OrderType = Enums.OrderType.Quote;
        }
        public override void Init(ContextRz x)
        {
            base.Init(x);
            ServiceDetailsSet(new ArrayList());
            CacheOptions(x);
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            List<orddet_quote> details = new List<orddet_quote>();
            foreach (IItem i in args.TheItems.AllGet(xrz))
            {
                details.Add((orddet_quote)i);
            }
            switch (args.ActionName.ToLower())
            {
                case "void":
                    VoidLine(xrz);
                    break;
                case "unvoid":
                    VoidLine(xrz, true);
                    break;
                case "addanote":
                    AddQuoteNote(xrz);
                    break;
                case "emailvendorgroup":
                    List<orddet> d = new List<orddet>();
                    foreach (orddet_quote q in details)
                    {
                        d.Add(q);
                    }
                    EmailVendorGroup(xrz, d);
                    break;
                case "receivebidshow":
                    args.TheContext.Show(ReceiveBid(xrz));
                    break;
                case "receivebid":
                    ReceiveBid(xrz);
                    break;
                case "formalquote":
                    FormalQuoteShow(xrz);
                    args.Handled = true;
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        public void FormalQuoteShow(ContextRz context)
        {
            MakeDealExist(context);
            context.Show(MakeHeaderExist(context));
        }
        public orddet BidJustAdded = null;
        public orddet_rfq ReceiveBid(ContextRz context)
        {
            MakeDealExist(context);
            if (xDeal == null)
                return null;

            xDeal.Init(context);
            orddet_rfq ret = (orddet_rfq)xDeal.BidReceive(context, this);
            BidJustAdded = ret;
            return ret;
        }
        public void VoidLine(ContextRz x, bool unvoid = false)
        {
            if (!unvoid)
            {
                if (!x.TheLeader.AreYouSure("you want to void this quote line"))
                    return;
            }
            if (unvoid)
                this.isvoid = false;
            else
                this.isvoid = true;
            this.Update(x);
        }
        public bool UpdateQuoteStats(ContextRz x)
        {
            try
            {
                if (!Tools.Strings.StrExt(unique_id))
                    return false;
                DataTable dt = x.TheSysRz.TheQuoteLogic.GetQuoteStats(x, unique_id);
                if (dt == null)
                    return false;
                if (dt.Rows.Count <= 0)
                    return false;
                foreach (DataRow dr in dt.Rows)
                {
                    stock_matches = Tools.Data.NullFilterInt(dr["stock_matches"]);
                    excess_matches = Tools.Data.NullFilterInt(dr["excess_matches"]);
                    consign_matches = Tools.Data.NullFilterInt(dr["consign_matches"]);
                    sale_matches = Tools.Data.NullFilterInt(dr["sale_matches"]);
                    //sale_average = nData.NullFilter_Float(dr["sale_average"]);
                    //sale_min = nData.NullFilter_Float(dr["sale_average"]);
                    sale_max = nData.NullFilter_Float(dr["sale_max"]);
                    //sale_earliest = nData.NullFilter_DateTime(dr["sale_earliest"]);
                    sale_latest = nData.NullFilter_DateTime(dr["sale_latest"]);

                    //purchase_matches = Tools.Data.NullFilterInt(dr["purchase_matches"]);
                    //purchase_average = nData.NullFilter_Float(dr["purchase_average"]);
                    //purchase_min = nData.NullFilter_Float(dr["purchase_min"]);
                    //purchase_max = nData.NullFilter_Float(dr["purchase_max"]);
                    //purchase_earliest = nData.NullFilter_DateTime(dr["purchase_earliest"]);
                    //purchase_latest = nData.NullFilter_DateTime(dr["purchase_latest"]);
                    quote_matches = Tools.Data.NullFilterInt(dr["quote_matches"]);
                    //double quote_total_price = nData.NullFilter_Float(dr["quote_total_price"]);
                    //quote_average = quote_total_price / (double)quote_matches;
                    //quote_min = nData.NullFilter_Float(dr["quote_min"]);
                    quote_max = nData.NullFilter_Float(dr["quote_max"]);
                    //quote_earliest = nData.NullFilter_DateTime(dr["quote_earliest"]);
                    quote_latest = nData.NullFilter_DateTime(dr["quote_latest"]);
                    x.Update(this);
                }
                return true;
            }
            catch { }
            return false;
        }
        public static void EmailVendorGroup(ContextNM context, List<orddet> details)
        {
            emailtemplate t = emailtemplate.GetByName((ContextRz)context, "PrimaryVendorRFQ");
            if (t == null)
            {
                context.TheLeader.Tell("Please create an email template for a quote line named 'PrimaryVendorRFQ'");
                return;
            }
            String group = context.TheLeader.AskForString("Group", "PrimaryVendors", false, "Group");
            if (!Tools.Strings.StrExt(group))
                return;
            ArrayList addresses = context.SelectScalarArray("select distinct(primaryemailaddress) from company where group_name like '%," + context.Filter(group) + ",%' and " + Tools.Email.IsEmailAddressSql("primaryemailaddress") + " order by primaryemailaddress");
            if (addresses.Count == 0)
            {
                context.TheLeader.Tell("No addresses were found for this group.");
                return;
            }
            ordhed_quote header = new ordhed_quote();
            header.unique_id = "<notanid>";
            //header.AllDetails = new Dictionary<string, nObject>();
            //foreach (orddet d in details)
            //{
            //    header.AllDetails.Add(d.unique_id, d);
            //}
            header.DetailsVar = new VarRefOrderLinesOld(header);
            foreach (orddet d in details)
            {
                header.DetailsVar.RefsAdd(context, d, false);
            }
            foreach (String add in addresses)
            {
                t.SendOrderEmail((ContextRz)context, header, add, new ArrayList(details.ToArray()));
            }
        }
        void AddQuoteNote(ContextRz context)
        {
            String s = context.TheLeader.AskForString("Note", "", true, "Note");
            if (!Tools.Strings.StrExt(s))
                return;

            last_note = s;
            context.Update(this);

            usernote n = usernote.New(context);
            n.displaydate = DateTime.Now;
            context.Insert(n);
            n.shouldpopup = false;
            n.CreateObjectLink(context, this, "Quote");
            n.notetext = s;
            context.Update(n);
        }
        public ListArgs OptionArgs(ContextRz context)
        {
            ListArgs args = new ListArgs(context);
            args.TheClass = "orddet_quote";
            args.TheTable = "orddet_quote";
            args.TheTemplate = "quote_options";
            args.TheWhere = "option_orddet_quote_uid = '" + this.unique_id + "'";
            args.TheOrder = "date_created";    // "linecode";
            args.TheLimit = 100;
            args.AddAllow = false;
            return args;
        }
        public Dictionary<String, Item> AllOptions;
        public void CacheOptions(ContextRz context)
        {
            AllOptions = context.TheData.QtD(context, "orddet_quote", "select * from orddet_quote where option_orddet_quote_uid = '" + unique_id + "' order by linecode");
        }
        public void AddOneOption(ContextRz x, int quantity, Double price, String mfg, String dc, String cond, String del)
        {
            if (AllOptions == null)
                CacheOptions(x);
            orddet_quote q = orddet_quote.New(x);
            q.fullpartnumber = fullpartnumber;
            q.target_condition = target_condition;
            q.target_datecode = target_datecode;
            q.target_delivery = target_delivery;
            q.target_manufacturer = target_manufacturer;
            q.target_price = target_price;
            q.target_quantity = target_quantity;
            q.manufacturer = mfg;
            q.datecode = dc;
            q.delivery = del;
            q.condition = cond;
            q.option_orddet_quote_uid = this.unique_id;
            q.linecode = GetNextOptionLineCode();
            x.Insert(q);
            EditOneOption(x, q);
            AllOptions.Add(q.unique_id, q);
        }
        private void EditOneOption(ContextNM x, orddet_quote q)
        {
            x.Reorg();
            //if (q == null)
            //    return;
            //frmEditQuoteOption e = new frmEditQuoteOption();
            //if (!e.CompleteLoad(x, q))
            //    return;
            //e.ShowDialog();
        }
        public int GetNextOptionLineCode()
        {
            return 1;
            try
            {
                int h = 0;
                foreach (KeyValuePair<String, Item> k in AllOptions)
                {
                    orddet_quote oq = (orddet_quote)k.Value;
                    if (oq.linecode > h)
                        h = Convert.ToInt32(oq.linecode);
                }
                return h + 1;
            }
            catch
            {
                return 1;
            }

        }

        public override void Inserting(Context x)
        {
            OrderType = Enums.OrderType.Quote;
            ((ContextRz)x).TheSysRz.TheQuoteLogic.CheckPriorityFlag((ContextRz)x, this);
            base.Inserting(x);


        }



        public override void Updating(Context x)
        {
            int xx = 2 * 5;

            if (unitprice > 0 && quantityordered > 0)
            {
                if (!Tools.Dates.DateExists(last_quote_date))
                {
                    last_quote_date = DateTime.Now;
                    last_quote_total = quantityordered * unitprice;
                }
                else
                {
                    if ((quantityordered * unitprice) != last_quote_total)
                    {
                        last_quote_date = DateTime.Now;
                        last_quote_total = quantityordered * unitprice;
                    }
                }
            }

            if (quantityordered > 0 && unitprice > 0)
                type_caption = "Quote";
            else
                type_caption = "Req";


            base.Updating(x);
        }

        protected override int GridColorCalc(Context x)
        {
            return Color.Blue.ToArgb();
        }

        public virtual String GetTreeCaption(ContextRz context, bool show_company)
        {
            return context.TheSysRz.TheReqLogic.GetQuoteTreeCaption(this, show_company);
        }
        public override void CacheDetails(ContextRz context)
        {
            DetailsSet(context.QtC("orddet_rfq", "select * from orddet_rfq where the_orddet_quote_uid = '" + this.unique_id + "' order by fullpartnumber, orderdate"));
        }
        //public override nObject Clone(ContextRz context)
        //{
        //    nObject n = base.CloneValues(context);
        //    foreach (CoreVarValAttribute p in context.TheSys.VarVals("orddet_old"))  //orddet_old isn't officially a base because of the NMI
        //    {
        //        n.ISet(p.Name, this.IGet(p.Name));
        //    }
        //    return n;
        //}
        public void CacheServiceDetails(ContextRz context)
        {
            ServiceDetailsSet(context.QtC("orddet_service", "select * from orddet_service where the_orddet_quote_uid = '" + this.unique_id + "' order by fullpartnumber, orderdate"));
        }
        public override void RefreshNodes(ContextRz context)
        {
            if (MyNodes == null)
                return;

            base.RefreshNodes(context);

            foreach (TreeNode n in MyNodes)
            {
                if (isselected)
                {
                    if (IsQuoted)
                        n.ImageKey = "quote_enabled";
                    else
                        n.ImageKey = "req_enabled";

                    n.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    if (IsQuoted)
                        n.ImageKey = "quote_disabled";
                    else
                        n.ImageKey = "req_disabled";

                    n.ForeColor = System.Drawing.Color.Gray;
                }

                n.SelectedImageKey = n.ImageKey;
            }
        }
        //Public Functions
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeViewedByQuote((ContextRz)context, this, context.xUser);
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return ((ContextRz)context).TheSysRz.ThePermitLogicRz.CanBeEditedByQuote((ContextRz)context, this, context.xUser);
        }
        public virtual bool IsQuoted
        {
            get
            {
                //KT 8-25-2015 - Added a condition to check for GCAT in the part to allow quoting them at zero price.
                //if (((unitprice > 0) && (quantityordered > 0)) || fullpartnumber.Contains("GCAT") || StockType == Enums.StockType.Service)
                if (((unitprice > 0) && (quantityordered > 0)))
                    return true;
                //if ((fullpartnumber.Contains("GCAT") && StockType == Enums.StockType.Service))
                if (StockType == Enums.StockType.Service)
                    //Gotta be stocktype service, not just the name, else if user puts gcat anywhere in part number, 
                    //it will be considrered quoted, and won't allow setting GCAT service
                    return true;
                else
                    return false;
                //{
                //    if (AllOptions == null)
                //        return false;
                //    else
                //        return AllOptions.Count > 0;
                //}
            }
        }
        public List<orddet_rfq> GetSplitBids(ContextRz context)
        {
            List<orddet_rfq> ret = new List<orddet_rfq>();

            if (DetailsGet(context) == null)
                return ret;

            if (DetailsGet(context).Count == 0)
                return ret;

            int i = CountAcceptedBids(context);
            if (i == 0)
            {
                //ArrayList r = new ArrayList();

                //if (CountBids() > 1)
                //    return r;

                foreach (orddet_rfq x in DetailsGet(context))
                {
                    if (x.isselected)
                        ret.Add(x);
                }
                return ret;
            }

            //ArrayList a = new ArrayList();
            foreach (orddet_rfq x in DetailsGet(context))
            {
                if (x.is_accepted && x.isselected)
                    ret.Add(x);
            }
            return ret;
        }

        public List<orddet_rfq> GetAcceptedBids(ContextRz context)
        {
            List<orddet_rfq> ret = new List<orddet_rfq>();

            if (DetailsGet(context) == null)
                return ret;

            if (DetailsGet(context).Count == 0)
                return ret;

            foreach (orddet_rfq x in DetailsGet(context))
            {
                if (x.is_accepted && x.isselected)
                    ret.Add(x);
            }
            return ret;
        }


        public int CountAcceptedBids(ContextRz context)
        {
            return CountBids(context, true);
        }
        public int CountBids(ContextRz context)
        {
            return CountBids(context, false);
        }
        public int CountBids(ContextRz context, bool acpt)
        {
            int i = 0;
            foreach (orddet_rfq x in DetailsGet(context))
            {
                if ((x.is_accepted || !acpt) && x.isselected && !x.isinstock)
                    i++;
            }
            return i;
        }
        public static Color QuoteColor
        {
            get
            {
                return nTools.ColorFromHex("66669A");
            }
        }
        public override void AddDetail(ContextRz x, orddet_old d)
        {
            base.AddDetail(x, d);
        }
        public override void DetailAbsorb(ContextRz x, orddet_old d)
        {
            base.DetailAbsorb(x, d);
            ((orddet_rfq)d).the_orddet_quote_uid = this.unique_id;

            //d.fullpartnumber = fullpartnumber;
            //d.alternatepart = alternatepart;
            //d.internalpartnumber = internalpartnumber;
            //d.manufacturer = manufacturer;
            //d.datecode = datecode;
            //d.condition = condition;

            //dealdetail.CheckDealLinksDetail(x, this, d);

            d.base_dealdetail_uid = base_dealdetail_uid;

            d.ParentDetailSet(x, this);
            x.Update(d);

            AddDetailDirectly(d);
        }
        public bool IsUniqueQuote
        {
            get
            {
                //2011_07_01
                //if (AllOptions == null)
                //    return true;

                //if (AllOptions.Count == 0)
                //    return true;

                //if (quantityordered == 0 || unitprice == 0)
                //    return false;

                //foreach (KeyValuePair<String, nObject> k in AllOptions)
                //{
                //    orddet_quote qo = (orddet_quote)k.Value;
                //    if (qo.quantityordered == quantityordered && qo.unitprice == unitprice)
                //        return false;
                //}

                return true;
            }
        }

        public override string ToString()
        {
            if (IsQuoted)
                return "Quote for " + fullpartnumber;
            else
                return "Req for " + fullpartnumber;
        }
        public bool WasSold(ContextRz context)
        {
            String strSQL = "select max(ordernumber) from orddet_line where isnull(was_shipped, 0) = 1 and orderdate_invoice >= cast('" + Tools.Dates.DateFormatWithTimeRegardlessOfWindowsSettings(orderdate) + "' as datetime) and part_number_stripped = '" + context.Filter(Tools.Strings.FilterTrash(fullpartnumber)) + "' and companyname = '" + context.Filter(companyname) + "' and contactname = '" + context.Filter(contactname) + "'";
            String strInvoiceNumber = context.SelectScalarString(strSQL);
            return Tools.Strings.StrExt(strInvoiceNumber);
        }
        public orddet_rfq AddStockBid(ContextNM x)
        {
            partrecord p = ((ContextRz)x).Leader.StockChoose((ContextRz)x, fullpartnumber);
            if (p == null)
                return null;
            return ((SysRz5)x.xSys).TheQuoteLogic.AddStockBid((ContextRz)x, this, p);
        }
        public orddet_rfq AddBid(ContextRz x)
        {
            orddet_rfq b = orddet_rfq.New(x);
            b.the_orddet_quote_uid = unique_id;
            b.DetailAbsorb(x, this);
            b.base_dealheader_uid = base_dealheader_uid;
            b.isselected = true;
            x.Insert(b);
            BidAbsorb(x, b);
            return b;
        }
        public virtual void BidAbsorb(ContextRz context, orddet_rfq b)
        {
            b.the_orddet_quote_uid = this.unique_id;
            b.base_dealdetail_uid = base_dealdetail_uid;
            b.ParentDetailSet(context, this);
            b.internalcomment = "Customer Target: $" + Tools.Number.MoneyFormat_2_6(this.target_price);
            context.Update(b);
            AddDetailDirectly(b);
            context.Update(this);
        }
        public static void AppendSaleLinesFromQuoteArray(ArrayList a, ordhed h, dealheader xDeal)
        {
            //int i = 0;
            //foreach (orddet_quote ql in a)
            //{
            //    if (ql.isselected && ql.IsQuoted)
            //    {
            //        //this can be called from a cached spot like the order tree, or a non-cached spot like
            //        //from a formal quote->create sales order, so we need to check
            //        if (ql.Details == null)
            //            ql.CacheDetails();

            //        ArrayList bids = ql.GetSplitBids();
            //        if (bids.Count > 0)
            //        {
            //            foreach (orddet_rfq rq in bids)
            //            {
            //                i++;
            //                orddet_sales sl = (orddet_sales)h.GetNewDetail(ql);
            //                sl.linecode = i;
            //                sl.base_ordhed_uid = h.unique_id;
            //                sl.vendor_company_uid = rq.base_company_uid;
            //                sl.vendorname = rq.companyname;
            //                sl.vendorcontactid = rq.base_companycontact_uid;
            //                sl.vendorcontactname = rq.contactname;
            //                sl.unitcost = rq.unitprice;
            //                if (rq.isinstock)
            //                    sl.quantityordered = rq.quantitystocked;
            //                else
            //                    sl.quantityordered = rq.quantityordered - rq.quantitystocked;
            //                sl.ISave();

            //                //make the dealdetail link formal
            //                dealdetail.CheckDealLinksDetail(xDeal, ql, sl, ql.base_dealdetail_uid);

            //                //make the inventory line exist
            //                //this will always be a 'buy' line

            //                if (!Tools.Strings.StrExt(rq.stockid))
            //                    rq.CreateLinkedPartRecord(Enums.StockType.Buy, false, rq.base_ordhed_uid, h.unique_id);

            //                sl.stockid = rq.stockid;
            //                sl.ISave();

            //                //link the sales order to the PO
            //                if (Tools.Strings.StrExt(rq.last_purchase_id))
            //                    ordhed.MakeLinkObject(Rz3App.xSys, h.unique_id, h.ordertype, h.ordernumber, rq.last_purchase_id, "purchase", rq.last_purchase_number);
            //            }
            //        }
            //        else
            //        {
            //            i++;
            //            orddet_sales sl = (orddet_sales)h.GetNewDetail(ql);
            //            sl.linecode = i;
            //            sl.base_ordhed_uid = h.unique_id;
            //            sl.ISave();

            //            if (ql.ParentDetail == null)
            //            {
            //                //make the dealdetail link formal
            //                dealdetail.CheckDealLinksDetail(xDeal, ql, sl, ql.base_dealdetail_uid);

            //                //inventory line
            //                if (!Tools.Strings.StrExt(ql.stockid))
            //                {
            //                    ql.CreateLinkedPartRecord(Enums.StockType.Buy, false, "", h.unique_id);
            //                }

            //                sl.stockid = ql.stockid;
            //            }
            //            else   //has a parent, needs to use the parent's stock id, link to the parent's order, etc
            //            {

            //                orddet_rfq thebid = (orddet_rfq)ql.ParentDetail;
            //                ql.unitcost = thebid.unitprice;
            //                sl.unitcost = thebid.unitprice;

            //                //link the sales order to the PO
            //                if (Tools.Strings.StrExt(thebid.last_purchase_id))
            //                    ordhed.MakeLinkObject(Rz3App.xSys, h.unique_id, h.ordertype, h.ordernumber, thebid.last_purchase_id, "purchase", thebid.last_purchase_number);

            //                String sid = thebid.GetBestStockID();
            //                if (Tools.Strings.StrExt(sid))
            //                {
            //                    sl.stockid = sid;
            //                }
            //                else  //it hasn't been actually purchased yet.  create it, and then GetBestStockID will return it for the PO line
            //                {
            //                    ql.CreateLinkedPartRecord(Enums.StockType.Stock, false, "", h.unique_id);
            //                    sl.stockid = ql.stockid;
            //                }
            //            }
            //            sl.ISave();
            //        }

            //        ql.last_sales_id = h.unique_id;
            //        ql.last_sales_number = h.ordernumber;
            //        ql.ISave();

            //        //needs to link to the last quote
            //        if (Tools.Strings.StrExt(ql.base_ordhed_uid))
            //        {
            //            ordhed.MakeLinkObject(Rz3App.xSys, ql.base_ordhed_uid, "quote", ql.ordernumber, h.unique_id, "sales", h.ordernumber);
            //        }
            //    }
            //}
        }
        public bool CheckQuoteBeforeSave(ContextRz context)
        {
            return context.TheSysRz.TheOrderLogic.CheckQuoteBeforeSave(context, this);
        }
        public ListArgs BidArgsGet(ContextNM context)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheTemplate = "q_bids";
            ret.TheClass = "orddet_rfq";
            ret.TheWhere = "the_orddet_quote_uid = '" + unique_id + "'";
            ret.TheOrder = "orderdate desc";
            ret.TheCaption = "Bids On " + this.ToString();

            //need to add a handler in the interfaces for this first
            //ret.AddAllow = true;
            //ret.AddCaption = "Receive A Bid";

            ret.AddAllow = false;

            return ret;
        }
    }
}
