using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Core;

using NewMethod;
using Tools.Database;
using Rz5.Enums;

namespace Rz5
{
    public class ProofLogicRz : ProofLogic
    {
        public override void Prove(Context x, ProveResult result)
        {
            //base.Prove(x, result);
            ContextRz context = (ContextRz)x;
            long stockPiecesBefore = context.TheSysRz.ThePartLogic.TotalStockCount(context);
            //ContextRz cHold = (ContextRz)context.Clone();
            context.TheLeader.FastForwardStart();
            ordhed_vendrma vrma = VendRMAShipped(context);
            result.Items.Add("VRMA", vrma);
            context.TheLeader.ViewsCloseAll();
            context.TheLeader.FastForwardEnd();
            //cHold = null;

            //These are the ordheds that were just created for the prove process.  NOT The static templates that we compare to.
            List<ordhed_new> test_orders = vrma.LinkedOrdersGet(context);
            foreach (ordhed_new n in test_orders)
            {
                ordhed_new matching = (ordhed_new)context.GetById("ordhed_" + n.OrderType.ToString().ToLower(), n.unique_id);
                if (matching == null)
                {
                    result.Passed = false;
                    result.Log(n.ToString() + " was not found in the database");
                }
                else
                {
                    String res = "";
                    if (!n.Compare(context, matching, ref res))
                    {
                        result.Log("Comparing " + n.ToString() + " failed");
                        result.Passed = false;
                        result.Log(res);
                    }
                    else
                        result.Log("Comparing " + n.ToString() + " succeeded");
                }
            }
            long stockPiecesAfter = context.TheSysRz.ThePartLogic.TotalStockCount(context);
            if (stockPiecesAfter != stockPiecesBefore)
            {
                result.Passed = false;
                result.Log("Stock quantity mis-match: " + Tools.Number.LongFormat(stockPiecesBefore) + " before, " + Tools.Number.LongFormat(stockPiecesAfter) + " after");
            }
        }

        //public override Item TestItem(Context x, CoreClassHandle h)
        //{
        //    Item ret = base.TestItem(x, h);

        //    switch (ret.ClassId)
        //    {
        //        case "orddet_quote":
        //            ((orddet_quote)ret).OrderType = Enums.OrderType.Quote;
        //            break;
        //        case "orddet_rfq"
        //    }

        //    return ret;
        //}

        public virtual ordhed_quote QuoteCreate(ContextRz context, int lines)
        {
            ordhed_quote ret = QuoteHeaderCreate(context);
            company c = CustomerMakeExist(context);
            companycontact cont = ContactMakeExist(context, c);
            ret.AbsorbCompanyAndContact(context, c, cont);

            for (int i = 0; i < lines; i++)
            {
                QuoteLineMakeExist(context, ret, i + 1);
            }

            //ret.IUpdate();
            context.TheDelta.Update(context, ret);
            return ret;
        }
        protected virtual orddet_quote QuoteLineMakeExist(ContextRz context, ordhed_quote q, int i)
        {
            orddet_quote det = (orddet_quote)q.DetailsVar.RefAddNew(context);
            det.fullpartnumber = "TESTPART123";
            det.quantityordered = i;
            det.unitprice = i * 5.1;
            det.unitcost = i * 2.2;
            det.manufacturer = "MFG1";
            det.datecode = "99+";
            context.TheDelta.Update(context, det);
            return det;
        }
        protected virtual orddet_line ServiceLineMakeExist(ContextRz context, ordhed_service s, int i)
        {
            orddet_line det = (orddet_line)s.DetailsVar.RefAddNew(context);
            det.fullpartnumber = "TESTPART123";
            det.quantity = i;
            //det.unitprice = i * 5.1;
            //det.unitcost = i * 2.2;
            det.manufacturer = "MFG1";
            det.datecode = "99+";
            det.shipvia_invoice = "UPS Ground";
            det.shippingaccount_invoice = "123456";
            context.TheDelta.Update(context, det);
            return det;
        }
        public virtual ordhed_service ServiceOrderCreate(ContextRz context)
        {
            ordhed_service ret = ServiceHeaderCreate(context);
            company c = VendorMakeExist(context, 1);
            companycontact cont = ContactMakeExist(context, c);
            ret.AbsorbCompanyAndContact(context, c, cont);

            //for (int i = 0; i < lines; i++)
            //{
            ServiceLineMakeExist(context, ret, 5);
            //}

            //ret.IUpdate();
            context.TheDelta.Update(context, ret);
            return ret;
        }
        public virtual ordhed_sales SalesOrderToComplete(ContextRz context, int lines = 1)
        {
            return SalesOrderMultiVendor(context, lines);
        }
        public virtual ordhed_sales SalesOrderMultiVendor(ContextRz context, int vendors)
        {
            ordhed_sales ret = SalesOrderCreate(context);
            company c = CustomerMakeExist(context);
            companycontact cont = ContactMakeExist(context, c);
            ret.AbsorbCompanyAndContact(context, c, cont);

            ret.orderreference = "PO " + DateTime.Now;
            ret.shipvia = "UPS Red";
            ret.terms = "COD";
            ret.shippingaccount = "123456";
            ret.primaryphone = "123456789";
            ret.primaryemailaddress = "test@compugbl.com";
            //KT
            ret.validation_stage = Enums.SalesOrderValidationStage.ValidationComplete.ToString();


            for (int v = 1; v <= vendors; v++)
            {
                SalesOrderLineMakeExistVendor(context, ret, v);
            }
            companyaddress a = c.AddressGet(context, "Billing");
            if (a != null)
                ret.billingaddress = a.GetAddressString(context);
            a = c.AddressGet(context, "Shipping");
            if (a != null)
                ret.shippingaddress = a.GetAddressString(context);
            ExtraAmountsAdd(ret);
            context.TheDelta.Update(context, ret);
            return ret;
        }

        public ordhed_sales CompletedFlipSale(ContextRz context)
        {
            ordhed_sales ret = SalesOrderMultiVendor(context, 1);
            ret.CompleteSalesOrder(context);
            return ret;
        }

        public ordhed_sales MultiCurrencySale(ContextRz context)
        {
            ordhed_sales sale = SalesOrderMultiVendor(context, 2);
            sale.CompleteSalesOrder(context);

            //even after this the lines show USD as the price currency

            sale.ApplyNewCurrency(context, context.Accounts.GetCurrency(context, "EUR"));
            sale.Update(context);

            foreach (orddet_line l in sale.DetailsVar.RefsList(context))
            {
                l.Update(context);
            }

            return sale;
        }

        public ordhed_invoice MultiCurrencyInvoice(ContextRz context)
        {
            ordhed_sales sale = MultiCurrencySale(context);

            //close the po tabs
            ArrayList ids = new ArrayList();
            foreach (orddet_line l in sale.DetailsVar.RefsList(context))
            {
                if (Tools.Strings.StrExt(l.orderid_purchase) && !ids.Contains(l.orderid_purchase))
                {
                    ids.Add(l.orderid_purchase);
                }
            }

            context.Leader.CloseTabsByID(context, ids);

            foreach (orddet_line l in sale.DetailsVar.RefsList(context))
            {
                l.Update(context);
            }

            ordhed_purchase po = (ordhed_purchase)ordhed_purchase.GetById(context, (String)ids[0]);
            po.ApplyNewCurrency(context, context.Accounts.GetCurrency(context, "EUR"));
            po.Update(context);

            foreach (orddet_line l in po.DetailsVar.RefsList(context))
            {
                l.Update(context);
            }

            foreach (String pid in ids)
            {
                ordhed_purchase p = (ordhed_purchase)ordhed_purchase.GetById(context, pid);
                FakeFillAndReceivePO(context, p);
            }

            //change the rate
            currency c = context.Accounts.GetCurrency(context, "EUR");
            Double originalRate = c.exchange_rate;
            c.exchange_rate += 0.1;
            c.Update(context);

            sale = ordhed_sales.GetById(context, sale.unique_id);  //refresh from the database

            ordhed_invoice ret = sale.MakeInvoiceWithChecks(context)[0];
            ret.SetShipping(10);
            ret.SetHandling(20);
            ret.SetTax(30);
            ret.Update(context);

            //switch it back
            c.exchange_rate = originalRate;
            c.Update(context);

            return ret;
        }

        protected virtual void FakeFillAndReceivePO(ContextRz context, ordhed_purchase p)
        {
            foreach (orddet_line l in p.DetailsVar.RefsList(context))
            {
                l.FakeUnPackPurchase(context);
                l.Update(context);
            }

            p.PutAway(context);
            p.Update(context);
        }

        public ordhed_sales SalesOrderStock(ContextRz context)
        {
            return SalesOrder(context, Enums.StockType.Stock);
        }

        public ordhed_sales SalesOrderConsign(ContextRz context)
        {
            return SalesOrder(context, Enums.StockType.Consign);
        }

        public virtual ordhed_sales SalesOrder(ContextRz context, Enums.StockType type, int lines = 1)
        {
            ordhed_sales ret = SalesOrderCreate(context);
            company c = CustomerMakeExist(context);
            companycontact cont = ContactMakeExist(context, c);
            ret.AbsorbCompanyAndContact(context, c, cont);

            ret.orderreference = "PO " + DateTime.Now;
            ret.shipvia = "UPS Red";
            ret.terms = "COD";
            ret.shippingaccount = "123456";
            ret.primaryphone = "123456789";
            ret.primaryemailaddress = "test@compugbl.com";

            for (int v = 1; v <= lines; v++)
            {
                SalesOrderLineMakeExist(context, ret, v * 2, type);
            }

            ret.billingaddress = c.AddressGet(context, "Billing").GetAddressString(context);
            ret.shippingaddress = c.AddressGet(context, "Shipping").GetAddressString(context);

            ExtraAmountsAdd(ret);
            context.TheDelta.Update(context, ret);
            return ret;
        }
        protected virtual ordhed_service ServiceHeaderCreate(ContextRz context)
        {
            ordhed_service ret = (ordhed_service)ordhed.CreateNew(context, Enums.OrderType.Service);
            ret.agentname = context.xUser.name;
            ret.base_mc_user_uid = context.xUser.unique_id;
            context.TheDelta.Update(context, ret);
            return ret;
        }
        protected virtual ordhed_quote QuoteHeaderCreate(ContextRz context)
        {
            return (ordhed_quote)ordhed.CreateNew(context, Enums.OrderType.Quote);
        }
        protected virtual ordhed_sales SalesOrderCreate(ContextRz context)
        {
            ordhed_sales ret = (ordhed_sales)ordhed.CreateNew(context, Enums.OrderType.Sales);
            ret.UserObjectSet((n_user)context.xUser);
            context.TheDelta.Update(context, ret);
            return ret;
        }
        public virtual ordhed_sales SalesOrderStock(ContextRz context, int lines, String customerName)
        {
            ordhed_sales ret = SalesOrderCreate(context);

            company c = CustomerMakeExist(context, customerName: customerName);

            companycontact cont = c.ContactGetByName(context, "Maggie Simpson");
            if (cont == null)
            {
                cont = c.ContactAdd(context);
                cont.contactname = "Maggie Simpson";
                context.Update(cont);
            }

            ret.AbsorbCompanyAndContact(context, c, cont);

            ret.orderreference = "PO " + DateTime.Now;
            ret.shipvia = "UPS Red";
            ret.terms = "COD";
            ret.shippingaccount = "123456";
            ret.primaryphone = "123456789";
            ret.primaryemailaddress = "test@compugbl.com";

            for (int v = 1; v <= lines; v++)
            {
                SalesOrderLineMakeExistStock(context, ret, v);
            }

            ret.billingaddress = c.AddressGet(context, "Billing").GetAddressString(context);
            ret.shippingaddress = c.AddressGet(context, "Shipping").GetAddressString(context);

            ExtraAmountsAdd(ret);

            //ret.GatherDetails();
            //ret.IUpdate();
            context.TheDelta.Update(context, ret);

            return ret;
        }
        protected virtual void ExtraAmountsAdd(ordhed_sales sale)
        {
            sale.shippingamount = 10;
            sale.handlingamount = 20;
            sale.taxamount = 30;
        }
        public virtual orddet_line SalesOrderLineMakeExistVendor(ContextRz context, ordhed_sales order, int v)
        {
            if (v == 0)
                v = 1;

            orddet_line det = (orddet_line)order.DetailsVar.RefAddNew(context);
            det.fullpartnumber = "TESTPART123";
            det.shipvia_invoice = "UPS Ground";
            det.shippingaccount_invoice = "123456";
            det.quantity = v;  // + 1 removed so we can have quantity 1 tests
            det.unit_price = v;
            det.ship_date_due = DateTime.Now.AddDays(2);
            //dock dates
            context.TheSysRz.TheLineLogic.SetInitialLineDockDates(det, DateTime.Now.AddDays(3));           

            det.receive_date_due = DateTime.Now.AddDays(1);
            //Kt
            det.quote_line_uid = "testquotelineuid";
            det.quoted_partnumber = det.fullpartnumber;
            //det.status = Enums.OrderLineStatus.Open.ToString();

            company vend = VendorMakeExist(context, v);
            det.unit_cost = .25 * v;
            det.manufacturer = "MFG1";
            det.datecode = "99+";
            det.StockType = Enums.StockType.Buy;
            det.needs_purchasing = true;
            det.VendorVar.RefSet(context, vend);
            return det;
        }

        protected virtual orddet_line SalesOrderLineMakeExist(ContextRz context, ordhed_sales order, int saleQuantity, Enums.StockType type)
        {
            orddet_line det = (orddet_line)order.DetailsVar.RefAddNew(context);
            det.fullpartnumber = "TESTPART123";
            det.quantity = saleQuantity;
            det.unit_price = saleQuantity;
            det.unit_cost = .25 * saleQuantity;
            det.manufacturer = "MFG1";
            det.datecode = "99+";
            det.shipvia_invoice = "UPS Ground";
            det.StockType = type;
            det.ship_date_due = DateTime.Now.AddDays(2);

            context.TheSysRz.TheLineLogic.SetInitialLineDockDates(det, DateTime.Now.AddDays(3));
           

            det.receive_date_due = DateTime.Now.AddDays(1);
            det.Update(context);
            return det;
        }

        public virtual orddet_line SalesOrderLineMakeExistStock(ContextRz context, ordhed_sales order, int v)
        {
            return SalesOrderLineMakeExist(context, order, v, Enums.StockType.Stock);
        }

        public virtual company VendorMakeExist(ContextRz context)
        {
            company ret = company.GetByName(context, "Test Vendor");
            if (ret == null)
            {
                ret = company.New(context);
                ret.companyname = "Test Vendor";
                ret.companytype = "Vendor";
                context.TheDelta.Insert(context, ret);
                //ret.ISave();
            }
            return ret;
        }
        public virtual company CustomerMakeExist(ContextRz context, String customerName = "")
        {
            if (!Tools.Strings.StrExt(customerName))
                customerName = "Test Customer";

            ContextRz contextNow = (ContextRz)context.Clone();
            company ret = company.GetByName(context, customerName);
            if (ret == null)
            {
                ret = company.New(context);
                ret.companyname = customerName;
                ret.companytype = "Customer";
                ret.Insert(context);
            }

            companyaddress billing = ret.AddressGet(context, "Billing");
            if (billing == null)
            {
                billing = ret.AddAddress(contextNow);
                billing.description = "Billing";
                billing.line1 = "742 Evergreen Terrace";
                billing.adrcity = "Springfield";
                billing.adrstate = "UX";
                billing.adrzip = "12345";
                billing.adrcountry = "USA";
                billing.defaultbilling = true;
                billing.Update(contextNow);
            }

            companyaddress shipping = ret.AddressGet(context, "Shipping");
            if (shipping == null)
            {
                shipping = ret.AddAddress(contextNow);
                shipping.description = "Shipping";
                shipping.line1 = "123 Fake St.";
                shipping.adrcity = "Springfield";
                shipping.adrstate = "UZ";
                shipping.adrzip = "54321";
                shipping.adrcountry = "USA";
                shipping.Update(contextNow);
            }

            return ret;
        }
        public virtual companycontact ContactMakeExist(ContextRz context, company c)
        {
            companycontact cont = c.ContactGetByName(context, "Maggie Simpson");
            if (cont == null)
            {
                cont = c.ContactAdd(context);
                cont.contactname = "Maggie Simpson";
                cont.abs_type = "OEM";
                cont.Update(context);


            }
            return cont;
        }
        public virtual company VendorMakeExist(ContextRz context, int index)
        {
            company ret = company.GetByName(context, "Test Vendor " + index.ToString());
            if (ret != null)
                return ret;

            ret = company.New(context);
            ret.companyname = "Test Vendor " + index.ToString();
            ret.companytype = "Vendor";
            ret.Insert(context);

            return ret;
        }
        public virtual void OrderBatchTest(ContextNM context, int rounds, int width)
        {
            //ArrayList ids = context.SelectScalarArray("select top 1000 unique_id from dealheader");
            //for(int r = 0 ; r < rounds ; r++)
            //{
            //    List<dealheader> shown = new List<dealheader>();
            //    for (int w = 0; w < width; w++)
            //    {
            //        dealheader h = dealheader.GetByID(context.xSys, (String)ids[Tools.Number.GetRandomInteger(0, ids.Count - 1)]);
            //        if (h != null)
            //        {
            //            shown.Add(h);
            //            context.Show(h);
            //            System.Windows.Forms.Application.DoEvents();
            //            System.Windows.Forms.Application.DoEvents();
            //            System.Windows.Forms.Application.DoEvents();
            //            System.Windows.Forms.Application.DoEvents();
            //            System.Windows.Forms.Application.DoEvents();

            //            foreach (DisplayHandle handle in context.TheLeader.DisplayHandlesList)
            //            {
            //                if (handle.TheItem != null && handle.TheDisplayObject != null)
            //                {
            //                    try
            //                    {
            //                        if (handle.TheItem.Uid == h.unique_id)
            //                        {
            //                            OrderTree tree = (OrderTree)handle.TheDisplayObject;
            //                            //tree.ShowStuff(5);
            //                        }
            //                    }
            //                    catch { }
            //                }
            //            }                    
            //        }
            //    }

            //    foreach (dealheader h in shown)
            //    {
            //        context.TheLeader.ViewsClose(h);
            //        System.Windows.Forms.Application.DoEvents();
            //        System.Windows.Forms.Application.DoEvents();
            //        System.Windows.Forms.Application.DoEvents();
            //        System.Windows.Forms.Application.DoEvents();

            //    }
            //}
        }
        public virtual ordhed_sales SalesOrderToShip(ContextRz context, int lines = 1)
        {


            ordhed_sales sale = SalesOrderToComplete(context, lines);
            List<orddet_line> linesList = new List<orddet_line>();
            foreach (orddet od in sale.DetailsVar.RefsList(context))
            {
                linesList.Add((orddet_line)od);
            }
            SalesOrderCompleteResult res = sale.CompleteSalesOrder(context, linesList);
            //KT Override Validation Stage to Validation Complete for Proof Purposes    
            
            sale.validation_stage = Enums.SalesOrderValidationStage.ValidationComplete.ToString();

            foreach (ordhed_purchase p in res.POs)
            {

                foreach (orddet_line l in p.DetailsList(context))
                {
                    //p.shipvia = l.shipvia_purchase; //THis will update the header with the value supplied by the user for Proof purposes.
                    //p.shippingaccount = l.shipvia_purchase;
                    l.FakeUnPackPurchase(context);
                    context.TheDelta.Update(context, l);
                }
                p.PutAway(context);


            }
            return sale;
        }
        public ordhed_sales SalesOrderStockToShip(ContextRz context, int lines = 2)
        {
            ordhed_sales sale = SalesOrderStock(context, lines, "");
            SalesOrderCompleteResult res = sale.CompleteSalesOrder(context);
            return sale;
        }
        public ordhed_invoice Invoice(ContextRz context, int lines = 1, StockType type = StockType.Stock)
        {
            ordhed_sales s = SalesOrderToShip(context, lines);

            if (type == StockType.Consign)
            {
                foreach (orddet_line l in s.DetailsVar.RefsList(context))
                {
                    l.StockType = StockType.Consign;
                    l.lotnumber = "14";
                    l.Update(context);
                }
            }

            List<ordhed_invoice> invoices = s.MakeInvoiceWithChecks(context);

            if (invoices == null)
                return null;

            if (invoices.Count > 0)
                return invoices[0];
            else
                return null;
        }

        public ordhed_invoice InvoiceStock(ContextRz context)
        {
            return SalesOrderStockToShip(context).MakeInvoiceWithChecks(context)[0];
        }
        public ordhed_invoice InvoicePacked(ContextRz context, int lines = 1, StockType type = StockType.Stock)
        {
            ordhed_invoice ret = Invoice(context, lines: lines, type: type);
            ret.FakeFill(context);
            return ret;
        }
        public ordhed_invoice InvoiceToPack(ContextRz context)
        {
            return Invoice(context);
        }
        public ordhed_invoice InvoiceToShip(ContextRz context)
        {
            return InvoicePacked(context);
        }
        public ordhed_invoice InvoiceShipped(ContextRz context)
        {
            try
            {
                ordhed_invoice ret = InvoicePacked(context);
                ret.Ship(context);
                return ret;
            }
            catch (Exception ex)
            {
                context.Leader.Tell(ex.Message);
                return null;
            }

        }

        public ordhed_invoice InterruptedShipment(ContextRz context, StockType type = StockType.Stock)
        {
            ordhed_invoice ret = InvoicePacked(context, lines: 3, type: type);
            ret.Ship(context, 2);
            return ret;
        }

        public ordhed_purchase InterruptedReceive(ContextRz context)
        {
            ordhed_purchase ret = PurchaseCreate(context, 3);
            ret.FakeFill(context);
            ret.PutAway(context, 2);
            return ret;
        }

        public ordhed_rma RMAToReceive(ContextRz context)
        {
            ordhed_invoice i = InvoiceShipped(context);
            return i.ProofRMACreate(context);
        }

        public virtual ordhed_rma RMAReceived(ContextRz context)
        {
            ordhed_rma ret = RMAToReceive(context);
            ret.FakeFill(context);
            ret.PutAway(context);
            return ret;
        }

        public virtual ordhed_rma RMAReceivedCredit(ContextRz context)
        {
            ordhed_rma temp = RMAToReceive(context);
            temp.action_taken = "CREDIT";
            temp.Update(context);
            temp = ordhed_rma.GetById(context, temp.unique_id);  //clear all caching
            temp.FakeFill(context);
            temp.PutAway(context);

            context.Leader.CloseTabsByID(context, temp.unique_id);

            ordhed_rma ret = ordhed_rma.GetById(context, temp.unique_id);
            ret.Update(context);
            return ret;
        }

        public ordhed_vendrma VendRMAToShip(ContextRz context)
        {
            ordhed_rma r = RMAReceived(context);
            List<ordhed_new> pos = r.LinkedOrdersGet(context, Enums.OrderType.Purchase);
            foreach (ordhed_new n in pos)
            {
                return ((ordhed_purchase)n).VendRMACreate(context);
            }
            return null;
        }
        public ordhed_vendrma VendRMAShipped(ContextRz context)
        {
            ordhed_vendrma ret = VendRMAToShip(context);
            ret.FakeFill(context);
            ret.Ship(context);
            return ret;
        }
        public virtual ordhed_purchase PurchasePutAway(ContextRz context)
        {
            ordhed_purchase ret = PurchaseCreate(context);
            ret.FakeFill(context);
            ret.PutAway(context);
            return ret;
        }

        public virtual ordhed_purchase PurchasePutAwayPartial(ContextRz context)
        {
            ordhed_purchase ret = PurchaseCreate(context);
            ret.FakeFillPartial(context);
            ret.PutAway(context);
            return ret;
        }

        public virtual ordhed_purchase PurchaseCreate(ContextRz context, int lines = 1)
        {
            ordhed_purchase ret = (ordhed_purchase)ordhed.CreateNew(context, Enums.OrderType.Purchase);
            ret.UserObjectSet((n_user)context.xUser);
            //ret.ISave();
            ret.Update(context);

            company c = VendorMakeExist(context);
            companycontact cont = ContactMakeExist(context, c);
            ret.AbsorbCompanyAndContact(context, c, cont);

            ret.orderreference = "Test " + DateTime.Now;
            ret.shipvia = "UPS Red";
            ret.terms = "COD";
            ret.shippingaccount = "123456";
            ret.primaryphone = "123456789";
            ret.primaryemailaddress = "test@compugbl.com";
            ret.shippingamount = 30.9;
            ret.handlingamount = 20.8;
            ret.taxamount = 10.7;

            for (int l = 1; l <= lines; l++)
            {
                orddet_line det = PurchaseDetailCreate(context, ret);
                det.fullpartnumber = "TESTPART123-" + l.ToString();
                det.shipvia_invoice = "UPS Ground";
                det.shippingaccount_invoice = "123456";
                det.quantity = 2 * l;
                det.unit_cost = 75.4 * l;
                det.Update(context);
            }

            return ret;
        }
        public virtual orddet_line PurchaseDetailCreate(ContextRz context, ordhed_purchase p)
        {
            orddet_line det = (orddet_line)p.DetailsVar.RefAddNew(context);
            det.fullpartnumber = "TESTPART123";
            det.shipvia_invoice = "UPS Ground";
            det.shippingaccount_invoice = "123456";
            det.quantity = 2;
            det.unit_cost = 2.4;
            det.StockType = Enums.StockType.Stock;
            det.Update(context);
            return det;
        }

        public virtual void TestNewVersion(ContextRz context)
        {


        }

        public virtual partrecord TestStockCreate(ContextRz context, String part, int quantity, String condition, Enums.StockType type = Enums.StockType.Stock)
        {
            partrecord p = partrecord.New(context);
            p.fullpartnumber = part;
            p.condition = condition;

            if (type == Enums.StockType.Stock)
                p.quantity = 0;
            else
                p.quantity = quantity;

            p.StockType = type;
            context.TheDelta.Insert(context, p);

            if (type == Enums.StockType.Stock)
            {
                p.AssetAccount = context.Accounts.GetAccount(context, "Inventory Asset");
                p.cost = quantity * 11.11;
                p.Update(context);
                p.QuantityAdjustment(context, quantity, context.Accounts.GetAccount(context, "Opening Balance Equity"));
            }

            return p;
        }

        public void SetAllDemonstrationInfoFlags(DataConnectionSqlServer connection)
        {
            foreach (String table in TablesContaingDemonstrationInfo)
            {
                connection.FieldMakeExist(table, new Tools.Database.Field("temp_rzweb_demo_data", Tools.Database.FieldType.Boolean));
                connection.Execute("update " + table + " set temp_rzweb_demo_data = 1");
            }
        }

        public void ClearDemonstrationInfo(ContextRz context)
        {
            foreach (String table in TablesContaingDemonstrationInfo)
            {
                context.Execute("delete from " + table + " where isnull(temp_rzweb_demo_data, 0) = 1");
            }
            context.SetSettingBoolean("rzweb_demonstration_info_cleared", true);
        }

        public List<String> TablesContaingDemonstrationInfo
        {
            get
            {
                List<String> ret = new List<String>();
                ret.Add("n_user");
                ret.Add("ordhed_quote");
                ret.Add("ordhed_rfq");
                ret.Add("ordhed_sales");
                ret.Add("ordhed_service");
                ret.Add("ordhed_purchase");
                ret.Add("ordhed_invoice");
                ret.Add("ordhed_rma");
                ret.Add("ordhed_vendrma");
                ret.Add("orddet_quote");
                ret.Add("orddet_rfq");
                ret.Add("orddet_line");
                ret.Add("company");
                ret.Add("companycontact");
                ret.Add("partrecord");
                return ret;
            }
        }

        public void AddExampleAccounts(ContextRz context, bool allowProduction = false)
        {
            if (!allowProduction)
            {
                if (!DefinitelyTestDatabase(context.TheData.DatabaseName))
                    throw new Exception("Account testing can only be run in a test environment");
            }

            context.Execute("truncate table account");
            AddAssetExampleAccounts(context);
            AddLiabilityAndEquityExampleAccounts(context);
            AddIncomeExampleAccounts(context);
            AddCOGSExampleAccounts(context);
            AddExpenseExampleAccounts(context);
        }

        account AddAccount(ContextRz context, String name, int number, AccountType type, Double balance, account parentAccount = null, bool builtIn = false, bool hidden = false)
        {
            account a = null;
            if (parentAccount == null)
            {
                a = account.New(context);
                a.Insert(context);
            }
            else
            {
                a = account.New(context);
                a.Insert(context);
                a.parent_id = parentAccount.unique_id;
                a.parent_name = parentAccount.full_name;
            }
            a.name = name;
            a.number = number;
            a.Type = type;
            a.balance = balance;
            a.built_in = builtIn;
            a.is_hidden = hidden;
            a.Update(context);
            return a;
        }

        private void AddAssetExampleAccounts(ContextRz x)
        {
            AddAccount(x, "Checking", 10100, AccountType.Bank, 45998.69);
            AddAccount(x, "Savings", 10300, AccountType.Bank, 17910.19);
            AddAccount(x, "Petty Cash", 10400, AccountType.Bank, 500);
            AddAccount(x, "Accounts Receivable", 11000, AccountType.AccountsReceivable, 501000, builtIn: true);
            AddAccount(x, "Undeposited Funds", 12000, AccountType.OtherCurrentAssets, 96010.43, builtIn: true);
            AddAccount(x, "Inventory Asset", 12100, AccountType.OtherCurrentAssets, 30733.38, builtIn: true);
            AddAccount(x, "Vendor Credit Balances", 12900, AccountType.OtherCurrentAssets, 0, builtIn: true);
            AddAccount(x, "Employee Advances", 12800, AccountType.OtherCurrentAssets, 832);
            AddAccount(x, "Pre-Paid Insurance", 13100, AccountType.OtherCurrentAssets, 4050);
            AddAccount(x, "Retainage Receivable", 13400, AccountType.OtherCurrentAssets, 3703.02);
            AddAccount(x, "Furniture and Equipment", 15000, AccountType.FixedAssets, 34326);
            AddAccount(x, "Vehicles", 15100, AccountType.FixedAssets, 78936.91);
            AddAccount(x, "Buildings and Improvements", 15200, AccountType.FixedAssets, 325000);
            AddAccount(x, "Construction Equipment", 15300, AccountType.FixedAssets, 15300);
            AddAccount(x, "Land", 16900, AccountType.FixedAssets, 90000);
            AddAccount(x, "Accumulated Depreciation", 17000, AccountType.FixedAssets, -110344.60);
            AddAccount(x, "Security Deposits", 18700, AccountType.OtherAssets, 1220);
        }

        private void AddLiabilityAndEquityExampleAccounts(ContextRz x)
        {
            AddAccount(x, "Accounts Payable", 20000, AccountType.AccountsPayable, 26736.92, builtIn: true);
            AddAccount(x, "MasterCard", 20500, AccountType.CreditCard, 94.2);
            AddAccount(x, "AMEX", 20600, AccountType.CreditCard, 382.62);
            AddAccount(x, "Advance Customer Payments", 13000, AccountType.OtherCurrentLiabilities, 0, builtIn: true);
            account a = AddAccount(x, "Payroll Liabilities", 24000, AccountType.OtherCurrentLiabilities, 0);
            AddAccount(x, "Federal Withholding", 24010, AccountType.OtherCurrentLiabilities, 1457, a);
            AddAccount(x, "FICA Payable", 24020, AccountType.OtherCurrentLiabilities, 2264.07, a);
            AddAccount(x, "FUTA Payable", 24040, AccountType.OtherCurrentLiabilities, 100, a);
            AddAccount(x, "State Withholding", 24050, AccountType.OtherCurrentLiabilities, 308.79, a);
            AddAccount(x, "SUTA Payable", 24060, AccountType.OtherCurrentLiabilities, 110, a);
            AddAccount(x, "State Disability Payable", 24070, AccountType.OtherCurrentLiabilities, 48.13, a);
            AddAccount(x, "Worker's Compensation", 24080, AccountType.OtherCurrentLiabilities, 1480.42, a);
            AddAccount(x, "Emp. Health Ins Payable", 24100, AccountType.OtherCurrentLiabilities, 150, a);
            AddAccount(x, "Sales Tax Payable", 25500, AccountType.OtherCurrentLiabilities, 957.63);
            AddAccount(x, "Loan - Vehicles (Van)", 23000, AccountType.LongTermLiabilities, 10501.47);
            AddAccount(x, "Loan - Vehicles (Utility Truck)", 23100, AccountType.LongTermLiabilities, 19936.91);
            AddAccount(x, "Loan - Vehicles (Pickup Truck)", 23200, AccountType.LongTermLiabilities, 22641);
            AddAccount(x, "Loan - Construction Equipment", 28100, AccountType.LongTermLiabilities, 13911.32);
            AddAccount(x, "Loan - Furniture/Office Equip", 28200, AccountType.LongTermLiabilities, 21000);
            AddAccount(x, "Note Payable", 28700, AccountType.LongTermLiabilities, 2693.21);
            AddAccount(x, "Mortgage - Office Building", 28900, AccountType.LongTermLiabilities, 296283);
            AddAccount(x, "Opening Balance Equity", 30000, AccountType.Equity, 38773.75, builtIn: true);
            AddAccount(x, "Capital Stock", 30100, AccountType.Equity, 500);
            AddAccount(x, "Retained Earnings", 32000, AccountType.Equity, 61756.76, builtIn: true);
        }
        private void AddIncomeExampleAccounts(ContextRz x)
        {
            AddAccount(x, "Sales", 40100, AccountType.Income, 0, builtIn: true);
            AddAccount(x, "Income Summary", 0, AccountType.Income, 0, builtIn: true, hidden: true);
            account a = AddAccount(x, "Construction Income", 40105, AccountType.Income, 0);
            AddAccount(x, "Design Income", 40110, AccountType.Income, 36729.25, a);
            AddAccount(x, "Labor Income", 40130, AccountType.Income, 708307.92, a);
            AddAccount(x, "Materials Income", 40140, AccountType.Income, 119920.67, a);
            AddAccount(x, "Subcontracted Labor Income", 40150, AccountType.Income, 84190.35, a);
            AddAccount(x, "Less Discounts Given", 40199, AccountType.Income, -48.35, a);

            a = AddAccount(x, "Reimbursement Income", 40500, AccountType.Income, 0);
            AddAccount(x, "Permit Reimbursement Income", 40520, AccountType.Income, 1223.75, a);
            AddAccount(x, "Reimbursement Freight & Delivery", 40530, AccountType.Income, 896.05, a);

            AddAccount(x, "Other Income", 70100, AccountType.OtherIncome, 146.80);
            AddAccount(x, "Interest Income", 70200, AccountType.OtherIncome, 229.16);
            AddAccount(x, "Outgoing Shipping", 70400, AccountType.OtherIncome, 0);
            AddAccount(x, "Outgoing Handling", 70500, AccountType.OtherIncome, 0);
            AddAccount(x, "Outgoing Tax", 70600, AccountType.OtherIncome, 0);
            AddAccount(x, "Sales Returns", 70700, AccountType.OtherIncome, 0);
        }

        public void RemoveNonRzExampleAccounts(ContextRz x)
        {
            List<String> nonRz = new List<string>();
            nonRz.Add("Construction Income");
            nonRz.Add("Design Income");
            nonRz.Add("Labor Income");
            nonRz.Add("Materials Income");
            nonRz.Add("Subcontracted Labor Income");
            nonRz.Add("Reimbursement Income");
            nonRz.Add("Permit Reimbursement Income");
            nonRz.Add("Reimbursement Freight & Delivery");
            nonRz.Add("Job Materials");
            nonRz.Add("Freight & Delivery");
            nonRz.Add("Capital Stock");
            nonRz.Add("Mortgage - Office Building");
            nonRz.Add("Note Payable");
            nonRz.Add("Loan - Vehicles (Van)");
            nonRz.Add("Loan - Vehicles (Utility Truck)");
            nonRz.Add("Loan - Vehicles (Pickup Truck)");
            nonRz.Add("Loan - Construction Equipment");
            nonRz.Add("Loan - Furniture/Office Equip");
            nonRz.Add("MasterCard");
            nonRz.Add("AMEX");
            nonRz.Add("Less Discounts Given");
            nonRz.Add("Construction Equipment");
            x.Execute("delete from account where name in (" + Tools.Data.GetIn(nonRz) + ")");
        }

        private void AddCOGSExampleAccounts(ContextRz x)
        {
            AddAccount(x, "Cost of Goods Sold", 50100, AccountType.CostOfGoodsSold, 14766.19);
            account a = AddAccount(x, "Job Expenses", 54000, AccountType.CostOfGoodsSold, 0);
            AddAccount(x, "Equipment Rental", 54200, AccountType.CostOfGoodsSold, 1850.00, a);
            AddAccount(x, "Job Materials", 54300, AccountType.CostOfGoodsSold, 98935.90, a);
            AddAccount(x, "Permits and Licenses", 54400, AccountType.CostOfGoodsSold, 700.00, a);
            AddAccount(x, "Subcontractors", 54500, AccountType.CostOfGoodsSold, 63217.95, a);
            AddAccount(x, "Freight & Delivery", 54520, AccountType.CostOfGoodsSold, 797.10, a);
            AddAccount(x, "Less Discounts Taken", 54599, AccountType.CostOfGoodsSold, -201.81, a);
        }
        private void AddExpenseExampleAccounts(ContextRz x)
        {
            account a = AddAccount(x, "Automobile", 60100, AccountType.Expense, 0);
            AddAccount(x, "Fuel", 60110, AccountType.Expense, 1588.70, a);
            AddAccount(x, "Insurance", 60120, AccountType.Expense, 2850.24, a);
            AddAccount(x, "Repairs and Maintenance", 60130, AccountType.Expense, 2406.00, a);
            AddAccount(x, "Bank Service Charges", 60600, AccountType.Expense, 125.00);
            a = AddAccount(x, "Insurance", 62100, AccountType.Expense, 0);
            AddAccount(x, "Disability Insurance", 62110, AccountType.Expense, 582.06, a);
            AddAccount(x, "Liability Insurance", 62120, AccountType.Expense, 5885.96, a);
            AddAccount(x, "Work Comp", 62130, AccountType.Expense, 13923.18, a);
            a = AddAccount(x, "Interest Expense", 62400, AccountType.Expense, 0);
            AddAccount(x, "Loan Interest", 62420, AccountType.Expense, 1995.65, a);
            a = AddAccount(x, "Payroll Expenses", 62700, AccountType.Expense, 0);
            AddAccount(x, "Gross Wages", 62710, AccountType.Expense, 111996.25, a);
            AddAccount(x, "Payroll Taxes", 62720, AccountType.Expense, 8567.72, a);
            AddAccount(x, "FUTA Expense", 62730, AccountType.Expense, 268.00, a);
            AddAccount(x, "SUTA Expense", 62740, AccountType.Expense, 1233.50, a);
            AddAccount(x, "Postage", 63100, AccountType.Expense, 104.20);
            a = AddAccount(x, "Professional Fees", 63600, AccountType.Expense, 0);
            AddAccount(x, "Accounting", 63610, AccountType.Expense, 250.00, a);
            a = AddAccount(x, "Repairs", 64200, AccountType.Expense, 0);
            AddAccount(x, "Building Repairs", 64210, AccountType.Expense, 175.00, a);
            AddAccount(x, "Computer Repairs", 64220, AccountType.Expense, 0, a);
            AddAccount(x, "Equipment Repairs", 64230, AccountType.Expense, 1350.00, a);
            AddAccount(x, "Tools and Machinery", 64800, AccountType.Expense, 2820.68);
            a = AddAccount(x, "Utilities", 65100, AccountType.Expense, 0);
            AddAccount(x, "Gas and Electric", 65110, AccountType.Expense, 1164.16, a);
            AddAccount(x, "Telephone", 65120, AccountType.Expense, 841.15, a);
            AddAccount(x, "Water", 65130, AccountType.Expense, 264.00, a);
            AddAccount(x, "Incoming Shipping", 65140, AccountType.Expense, 0);
            AddAccount(x, "Incoming Handling", 65150, AccountType.Expense, 0);
            AddAccount(x, "Incoming Tax", 65160, AccountType.Expense, 0);
            AddAccount(x, "Other Expenses", 80100, AccountType.OtherExpense, 50);

            AddAccount(x, "Services", 66000, AccountType.Expense, 0, builtIn: true);
            AddAccount(x, "Supplies", 67000, AccountType.Expense, 0, builtIn: true);
            AddAccount(x, "Third Party Service", 68000, AccountType.Expense, 0, builtIn: true);
            AddAccount(x, "Reconciliation Discrepancies", 69000, AccountType.Expense, 0, builtIn: true);
        }

        public void ClearBalancesAndJournal(ContextRz context)
        {
            if (!DefinitelyTestDatabase(context.TheData.DatabaseName))
                throw new Exception("Account testing can only be run in a test environment");

            context.Execute("update account set balance = 0");
            context.Execute("truncate table journal");
        }

        public bool DefinitelyTestDatabase(String name)
        {
            if (name.ToLower().EndsWith("_test"))
                return true;

            if (Tools.Strings.StrCmp(name, "Rz3_PhoenixCA_Recent"))
                return true;

            return false;
        }

        public void FullAccountProcess(ContextRz context)
        {
            ResetAccounts(context);
            OwnerInvestment(context);
            AssetPurchase(context);
            AssetPurchaseWithLoan(context);
            InitialInventoryImport(context, 10);
        }

        public void ResetAccounts(ContextRz context)
        {
            if (!DefinitelyTestDatabase(context.TheData.DatabaseName))
                throw new Exception("Account testing can only be run in a test environment");

            AddExampleAccounts(context);
            ClearBalancesAndJournal(context);
            context.Accounts.InitAccounts(context);
            context.Execute("truncate table partrecord");
            context.Execute("truncate table shipped_stock");
        }

        public void OwnerInvestment(ContextRz context)
        {
            JournalEntry entry = new JournalEntry("Owner Investment");
            entry.Add(context, context.Accounts.GetAccount(context, "Checking"), 500000, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Savings"), 500000, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Petty Cash"), 500, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Opening Balance Equity"), 0, 1000500);
            entry.Post(context);
        }

        public void AssetPurchase(ContextRz context)
        {
            JournalEntry entry = new JournalEntry("Buying a car");
            entry.Add(context, context.Accounts.GetAccount(context, "Vehicles"), 4200, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Checking"), 0, 4200);
            entry.Post(context);
        }

        public void AssetPurchaseWithLoan(ContextRz context)
        {
            JournalEntry entry = new JournalEntry("Buying a van");
            entry.Add(context, context.Accounts.GetAccount(context, "Vehicles"), 5000, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Savings"), 0, 1000);
            entry.Add(context, context.Accounts.GetAccount(context, "Loan - Vehicles (Van)"), 0, 4000);
            entry.Post(context);
        }

        public void NotePayable(ContextRz context)
        {
            JournalEntry entry = new JournalEntry("Note Payable - Any Bank");
            entry.Add(context, context.Accounts.GetAccount(context, "Checking"), 500, 0);
            entry.Add(context, context.Accounts.GetAccount(context, "Note Payable"), 0, 500);
            entry.Post(context);
        }

        public void InitialInventoryImport(ContextRz context, int items)
        {
            for (int i = 1; i <= items; i++)
            {
                TestStockCreate(context, "TST" + Tools.Number.GetRandomInteger(1000, 9999).ToString(), i, "NEW", Enums.StockType.Stock);
            }
        }
    }

    //public class TestResult
    //{
    //    public bool Passed = true;
    //    public TimeSpan Duration;
    //    DateTime StartTime;
    //    DateTime EndTime;
    //    StringBuilder LogString = new StringBuilder();
    //    public Dictionary<String, IItem> Items = new Dictionary<string, IItem>();

    //    public void Start()
    //    {
    //        StartTime = DateTime.Now;           
    //    }
    //    public void End()
    //    {
    //        EndTime = DateTime.Now;
    //        Duration = EndTime.Subtract(StartTime);
    //    }
    //    public void Log(String s)
    //    {
    //        LogString.AppendLine(s);
    //    }
    //    public override string ToString()
    //    {
    //        return LogString.ToString();
    //    }
    //}
}
