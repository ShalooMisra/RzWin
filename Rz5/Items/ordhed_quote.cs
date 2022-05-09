using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class ordhed_quote : ordhed_quote_auto
    {
        //Constructor
        public ordhed_quote()
        {
            OrderType = Enums.OrderType.Quote;
        }

        public dealheader GetDealHeader(ContextRz x)
        {
            TryCacheDeal(x);
            return xDeal;
        }

        public void BringCompletelyIntoDeal(ContextRz x, String strDeal)
        {
            ArrayList a = new ArrayList();
            if (Tools.Strings.StrExt(base_dealheader_uid))
                a = x.SelectScalarArray("select distinct(unique_id) from ordhed where base_dealheader_uid = '" + base_dealheader_uid + "'");
            else
                a.Add(unique_id);
            ArrayList b = x.SelectScalarArray("select distinct(orderid2) from ordlnk where orderid1 = '" + unique_id + "'");
            foreach (String s in b)
            {
                if (!a.Contains(s))
                    a.Add(s);
            }
            ordhed.RunSQLOnOrderTables(x, "update <order table> set base_dealheader_uid = '" + strDeal + "' where unique_id in ( " + nTools.GetIn(a) + " ) ");
            orddet.RunSQLOnDetailTables(x, "update <detail table> set base_dealheader_uid = '" + strDeal + "' where base_ordhed_uid in ( " + nTools.GetIn(a) + " ) ");
            base_dealheader_uid = strDeal;
            ReCacheDeal(x);
        }
        public bool AssignNewDealHeader(ContextRz context, String strType, String strOrder)
        {
            if (!Tools.Strings.StrExt(strType))
                return false;
            if (!Tools.Strings.StrExt(strOrder))
                return false;
            ordhed o = (ordhed)context.QtO("ordhed", "select * from " + MakeOrdhedName(strType) + " where ordertype = '" + strType + "' and ordernumber = '" + strOrder + "'");
            if (o == null)
                return false;
            return AssignNewDealHeader(context, o);
        }
        public bool AssignNewDealHeader(ContextRz context, ordhed order)
        {
            if (order == null)
                return false;
            dealheader dh = dealheader.New(context);
            dh.is_portal_generated = false;
            dh.agentname = order.agentname;
            dh.base_mc_user_uid = order.base_mc_user_uid;
            dh.start_date = DateTime.Now;
            dh.dealheader_name = order.agentname + " deal begun " + dh.start_date.ToString() + " for " + order.companyname;
            context.Insert(dh);
            order.base_dealheader_uid = dh.unique_id;
            order.TableName = MakeOrdhedName(order.ordertype);
            context.Update(order);
            return true;
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            switch (args.ActionName.ToLower())
            {
                case "makeso":
                case "newdocs_sales":
                case "newsalesorder":
                case "salesorder":
                    ordhed_sales s = SalesOrderCreate(xrz);
                    if (s != null)
                        args.TheContext.Show(s);
                    break;
                case "vieworderbatch":
                    ViewOrderBatch(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public virtual ordhed_sales SalesOrderCreate(ContextRz context)
        {
            return context.TheSysRz.TheQuoteLogic.SalesOrderCreate(context, this);

        }

        public List<orddet_quote> DetailsListQuote(ContextRz context)
        {
            List<orddet_quote> ret = new List<orddet_quote>();
            foreach (orddet_quote q in DetailsList(context))
            {
                ret.Add(q);
            }
            return ret;
        }

        public List<orddet_quote> DetailsListQuoteSelected(ContextRz context)
        {
            List<orddet_quote> ret = new List<orddet_quote>();
            foreach (orddet_quote q in DetailsList(context))
            {
                if (q.isselected)
                    ret.Add(q);
            }
            return ret;
        }



        public virtual ordhed_sales SalesOrderHeaderCreate(ContextRz x)
        {
            ordhed_sales xOrder = (ordhed_sales)ordhed.CreateNew(x, Enums.OrderType.Sales);
            xOrder.CompanyVar.RefSet(x, CompanyVar.RefGet(x));
            xOrder.ContactVar.RefSet(x, ContactVar.RefGet(x));
            company c = company.GetById(x, base_company_uid);
            
            if (ContactVar.RefGet(x) == null)
            {
                companycontact cc = companycontact.GetById(x, base_companycontact_uid);
                if (cc != null)
                    xOrder.ContactVar.RefSet(x, cc);
            }
            if (!Tools.Strings.StrExt(terms))
            {
                if (c != null)
                    terms = c.termsascustomer;
            }

            //Sales Orders Belong in Company Name, regardless of the quote.
            xOrder.agentname = c.agentname;
            xOrder.base_mc_user_uid = c.base_mc_user_uid;


            xOrder.shipvia = shipvia;
            xOrder.terms = terms;
            xOrder.orderbuyerid = orderbuyerid;
            xOrder.buyername = buyername;
            xOrder.legacycontact = legacycontact;
            xOrder.agentname = agentname;
            xOrder.base_mc_user_uid = base_mc_user_uid;



            xOrder.is_government = is_government;
            xOrder.billingname = billingname;
            xOrder.shippingname = shippingname;
            xOrder.primaryphone = primaryphone;
            xOrder.primaryfax = primaryfax;
            xOrder.primaryemailaddress = primaryemailaddress;
            xOrder.billingaddress = billingaddress;
            xOrder.shippingaddress = shippingaddress;
            xOrder.shippingaccount = shippingaccount;
            xOrder.internalcomment = internalcomment;
            xOrder.base_mc_user_uid = base_mc_user_uid;
            xOrder.orderbuyerid = orderbuyerid;
            xOrder.dockdate = dockdate;
            xOrder.requireddate = requireddate;
            xOrder.freightbilling = freightbilling;
            xOrder.packinginfo = packinginfo;
            xOrder.orderfob = orderfob;
            xOrder.validation_stage = Enums.SalesOrderValidationStage.PreValidation.ToString();
            xOrder.hubspot_deal_id = hubspot_deal_id;
            xOrder.orderreference = orderreference;

            x.Update(xOrder);


            return xOrder;
        }


        public override Enums.OrderType OrderType
        {
            get
            {
                return Enums.OrderType.Quote;
            }
            set
            {
                if (value != Enums.OrderType.Quote)
                    throw new Exception("Order Type Error");
            }
        }

        public override void Inserting(Context x)
        {
            base.Inserting(x);
            ordertype = "Quote";
        }

        //public override void GetNewOrderDetails(ContextRz x, ordhed xOrder, ArrayList lines, bool skip_link)
        //{
        //    if (xOrder.OrderType != Enums.OrderType.Sales || skip_link)
        //    {
        //        base.GetNewOrderDetails(x, xOrder, lines, skip_link);
        //        return;
        //    }

        //    xOrder.TryCacheDeal(Rz3App.xMainForm.TheContextNM);
        //    if (xOrder.xDeal == null)  //if it doesn't have a deal yet, just process it normally
        //    {
        //        base.GetNewOrderDetails(x, xOrder, lines, skip_link);
        //        return;
        //    }

        //    //only ask if there are any lines with more than one <accepted> bid
        //    bool might_use_bids = false;
        //    bool must_use_accepted = false;
        //    foreach (orddet d in lines)
        //    {
        //        if (d.Details != null)
        //        {
        //            int accepted = 0;
        //            if (d.Details.Count > 1)
        //            {
        //                foreach (orddet qbid in d.Details)
        //                {
        //                    if (qbid.is_accepted)
        //                        accepted++;
        //                }

        //                if( accepted > 1 )
        //                    might_use_bids = true;
        //                else if( accepted == 0 && d.Details.Count > 1 )
        //                    might_use_bids = true;

        //                if (accepted > 0)
        //                    must_use_accepted = true;
        //            }
        //        }
        //    }

        //    if (must_use_accepted)
        //    {
        //        orddet_quote.AppendSaleLinesFromQuoteArray(lines, xOrder, xOrder.xDeal);
        //    }
        //    else
        //    {
        //        if (might_use_bids)
        //        {
        //            if (context.TheLeader.AskYesNo("Do you want a separate line for each bid that has been received?\r\n\r\n[Clicking 'No' will simply create 1 sales order line per quote line, regardless of bids.]"))
        //            {
        //                //this needs to check for linked accepted rfqs the same way that the order batch does
        //                orddet_quote.AppendSaleLinesFromQuoteArray(lines, xOrder, xOrder.xDeal);
        //            }
        //            else
        //            {
        //                base.GetNewOrderDetails(x, xOrder, lines, skip_link);
        //            }
        //        }
        //        else
        //            base.GetNewOrderDetails(x, xOrder, lines, skip_link);
        //    }
        //}

        public dealheader xDeal;
        public virtual void TryCacheDeal(ContextRz x)
        {
            //company
            if (CompanyVar.RefGet(x) == null)
                return;
            if (xDeal != null)
                return;
            if (xDeal == null)
            {
                if (Tools.Strings.StrExt(base_dealheader_uid))
                {
                    xDeal = dealheader.GetById(x, base_dealheader_uid);
                    if (xDeal != null)
                        xDeal.Init(x);
                }
            }
        }
        public void ReCacheDeal(ContextRz x)
        {
            xDeal = null;
            TryCacheDeal(x);
        }
        public dealheader MakeDealExist(ContextRz x)
        {
            //company
            company xCompany = company.GetById(x, base_company_uid);
            if (xCompany == null)
            {
                x.TheLeader.Tell("Please choose a company before continuing.");
                return null;
            }
            //contact
            companycontact xContact = (companycontact)companycontact.GetById(x, base_companycontact_uid);
            if (xContact == null)
            {
                if (((SysRz5)x.xSys).TheCompanyLogic.DealContactRequired(xContact))
                {
                    x.TheLeader.Tell("Please choose a contact before continuing.");
                    return null;
                }
                xContact = companycontact.New(x);
            }
            dealheader d = null;
            if (xDeal != null)
                d = xDeal;
            if (d == null)
            {
                if (Tools.Strings.StrExt(base_dealheader_uid))
                {
                    d = dealheader.GetById(x, base_dealheader_uid);
                    if (d != null)
                    {
                        d.Init(x);
                    }
                }
            }
            bool created = false;
            if (d == null)
            {
                d = dealheader.MakeManualDeal(x, CompanyVar.RefGet(x), ContactVar.RefGet(x));
                this.base_dealheader_uid = d.unique_id;
                x.Update(d);
                foreach (orddet dx in DetailsList(x))
                {
                    orddet_old xd = (orddet_old)dx;
                    xd.base_dealheader_uid = d.unique_id;
                    x.Update(xd);
                }
                created = true;
            }

          
            //dealcompany c = d.MakeCompanyExist(xCompany.unique_id, xCompany.companyname, xContact.unique_id, xContact.contactname, ordhed.GetAsVendor(OrderDirection), ordhed.GetAsService(OrderType));
            //if (created)
            //    d.CacheAll();    //this re-caches everything so that the deal starts off with the order, the company, etc.
            xDeal = d;

            

            return xDeal;
            //return null;
        }

        private void ViewOrderBatch(ContextRz x)
        {
            TryCacheDeal(x);
            if (xDeal == null)
                x.TheLeader.TellTemp("This order isn't attached to an order batch");
            else
                x.Show(xDeal);
        }
        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            bool ret =  ((Rz5.PermitLogic)context.xSys.ThePermitLogic).CanBeViewedByFormalQuote((ContextRz)context, this, context.xUser);
            return ret;
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            bool ret = ((Rz5.PermitLogic)context.xSys.ThePermitLogic).CanBeEditedByFormalQuote((ContextRz)context, this, context.xUser);
            return ret;
        }
        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return ((Rz5.PermitLogic)context.xSys.ThePermitLogic).CanBeDeletedByFormalQuote((ContextRz)context, this, context.xUser);
        }

        //public override double CalcProfit(ContextRz context, bool ExcludeNoCost, bool IncludeUnSelected)
        //{
        //    Double dblHold = 0;
        //    foreach (orddet_old d in DetailsList(context))
        //    {
        //        if ((d.isselected && !Tools.Strings.StrCmp(d.status, "canceled")) || IncludeUnSelected)
        //        {
        //            if (ExcludeNoCost || d.unitcost > 0)
        //            {
        //                if (d.quantityfilled > 0)
        //                    dblHold += (d.unitprice - d.unitcost) * d.quantityfilled;
        //                else
        //                    dblHold += (d.unitprice - d.unitcost) * d.quantityordered;
        //            }
        //        }
        //    }
        //    return dblHold - (subtract_1 + subtract_2 + subtract_3);
        //}

    }
}
