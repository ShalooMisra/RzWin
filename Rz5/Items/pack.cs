using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using NewMethod;
using Core;
using Rz5.Enums;

namespace Rz5
{
    public partial class pack : pack_auto
    {
        VarRefSingle<pack, orddet_line> LineIn;
        VarRefSingle<pack, orddet_line> LineInService;
        VarRefSingle<pack, orddet_line> LineRMA;
        VarRefSingle<pack, orddet_line> LineOut;
        VarRefSingle<pack, orddet_line> LineOutService;
        VarRefSingle<pack, orddet_line> LineVendRMA;

        //Constructor
        public pack()
        {
            LineIn = new VarRefSingle<pack, orddet_line>(this, new CoreVarRefSingleAttribute("LineIn", "Rz4.pack", "Rz4.orddet_line", "PacksIn", "the_orddet_purchase_uid"));
            LineInService = new VarRefSingle<pack, orddet_line>(this, new CoreVarRefSingleAttribute("LineInService", "Rz4.pack", "Rz4.orddet_line", "PacksInService", "the_orddet_service_in_uid"));
            LineRMA = new VarRefSingle<pack, orddet_line>(this, new CoreVarRefSingleAttribute("LineRMA", "Rz4.pack", "Rz4.orddet_line", "PacksRMA", "the_orddet_rma_uid"));
            LineOut = new VarRefSingle<pack, orddet_line>(this, new CoreVarRefSingleAttribute("LineOut", "Rz4.pack", "Rz4.orddet_line", "PacksOut", "the_orddet_invoice_uid"));
            LineOutService = new VarRefSingle<pack, orddet_line>(this, new CoreVarRefSingleAttribute("LineOutService", "Rz4.pack", "Rz4.orddet_line", "PacksOutService", "the_orddet_service_out_uid"));
            LineVendRMA = new VarRefSingle<pack, orddet_line>(this, new CoreVarRefSingleAttribute("LineVendRMA", "Rz4.pack", "Rz4.orddet_line", "PacksVendRMA", "the_orddet_vendrma_uid"));
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                case "viewinspection":
                    ViewInspection((ContextRz)args.TheContext);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override Var VarGetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "linein":
                    return LineIn;
                case "lineinservice":
                    return LineInService;
                case "linerma":
                    return LineRMA;
                case "lineout":
                    return LineOut;
                case "lineoutservice":
                    return LineOutService;
                case "linevendrma":
                    return LineVendRMA;
                default:
                    return base.VarGetByName(name);
            }
        }
        public void ViewInspection(ContextRz context)
        {
            orddet_line l = null;
            string order_number = "";
            if (Tools.Strings.StrExt(the_orddet_purchase_uid))
            {
                l = orddet_line.GetById(context, the_orddet_purchase_uid);
                order_number = "PO# " + l.ordernumber_purchase;
            }
            else if (Tools.Strings.StrExt(the_orddet_rma_uid))
            {
                l = orddet_line.GetById(context, the_orddet_rma_uid);
                order_number = "RMA# " + l.ordernumber_rma;
            }
            else if (Tools.Strings.StrExt(the_orddet_service_in_uid))
            {
                l = orddet_line.GetById(context, the_orddet_service_in_uid);
                order_number = "Service# " + l.ordernumber_service;
            }
            if (l == null)
                return;
            qualitycontrol q = (qualitycontrol)context.QtO("qualitycontrol", "select * from qualitycontrol where the_companycontact_uid = '" + unique_id + "' and the_orddet_uid = '" + l.unique_id + "'");
            context.TheLeaderRz.QCShow(context, this, l, order_number, q);
        }


        public override void Updating(Context x)
        {
            if (LineOut.Initialized && quantity > 0)
            {
                if (LineOut.RefGet(x).SalesHas)
                {
                    if (m_ThePart != null)
                    {
                        //This was re-allocating on every Update, on Pack, and deletion of pack.  Only Need to allocate if it hasn't happened before, so, only going to allocate if an allocation is missing:
                        if (m_ThePart.quantityallocated < quantity)
                            m_ThePart.Allocate((ContextRz)x, quantity, "Sales Order " + LineOut.RefGet(x).ordernumber_sales, LineOut.RefGet(x).unique_id);
                    }
                }
            }

            base.Updating(x);
        }

        public partrecord PutAwayInTrans(ContextRz x, orddet_line putAwayLine, OrderType type)
        {

            partrecord ret = partrecord.New(x);
            ret.fullpartnumber = this.fullpartnumber;

            String reference = "";
            bool converBuyLineToStock = false;
            //Handle Order Type Specific Stuff
            switch (type)
            {
                case OrderType.Purchase:
                    reference = "PO " + putAwayLine.ordernumber_purchase;
                    ret.condition = this.condition;
                    //On Successful Put Away, this will make the Line available to be shipped.
                    if (putAwayLine.Status == OrderLineStatus.PreInvoiced)
                        putAwayLine.Status = OrderLineStatus.Packing; 
                    break;
                case OrderType.RMA:
                    reference = "RMA " + putAwayLine.ordernumber_rma;

                    if (x.TheLeader.AskYesNo("Do you want to label these parts as Suspect?"))
                        ret.condition = "SUSPECT";
                    else
                        ret.condition = this.condition;


                    //If this was a buy line, and is being rma'd, and we have set "put into our stock", then need switch the stocktype from Buy to Stock for proper stock selling.
                    ordhed_rma theRma = ordhed_rma.GetById(x, putAwayLine.orderid_rma);

                    if (theRma != null)
                    {
                        ordrma rmaData = theRma.LinkedRMAGet(x);
                        if (rmaData == null)
                            throw new Exception("Please finishe the RMA Data Tab of the associated RMA.");
                        if (rmaData != null)
                            switch (putAwayLine.StockType)
                            {
                                case StockType.Buy:
                                    {
                                        if (string.IsNullOrEmpty(rmaData.planned_status))
                                        {
                                            //error string variable
                                            string errorMessage = "Please indicate the final status of these parts in the RMA Data tab of the RMA.";
                                            //Ask the user for the string
                                            rmaData.planned_status = x.Leader.AskForString(errorMessage);
                                            //if still no string, error.
                                            if (string.IsNullOrEmpty(rmaData.planned_status))
                                                throw new Exception("Please indicate the final status of these parts in the RMA Data tab of the RMA.");
                                            //Since we have a string updatge
                                            rmaData.Update(x);
                                        }

                                        if (rmaData.planned_status == "keep")
                                        {
                                            putAwayLine.StockType = StockType.Stock;
                                            putAwayLine.stocktype = StockType.Stock.ToString();
                                            ret.quantityallocated = 0;
                                            converBuyLineToStock = true;

                                        }
                                        break;
                                    }
                            }
                    }
                    break;
                case OrderType.Service:
                    {
                        reference = "Service " + putAwayLine.ordernumber_service;
                        if (putAwayLine.Status == Enums.OrderLineStatus.Out_For_Service)
                            putAwayLine.Status = Enums.OrderLineStatus.Received_From_Service;
                        break;
                    }
                default:
                    throw new NotImplementedException();
            }
            ret.datecode = this.datecode;
            ret.manufacturer = this.manufacturer;
            ret.companyname = putAwayLine.vendor_name;
            ret.base_company_uid = putAwayLine.vendor_uid;
            //ret.vendorname = putAwayLine.vendor_name; //KT Confirmed 5-30-2019 vendorname is NOT uses to hold the consignment_or any other vendor, companyname adn base_company_uid are the key.
            ret.lotnumber = putAwayLine.lotnumber;
            ret.consignment_code = putAwayLine.consignment_code;
            ret.quantity = this.quantity;
            ret.StockType = putAwayLine.StockType;
            ret.stocktype = putAwayLine.stocktype;
            ret.importid = putAwayLine.importid;
            ret.cost = putAwayLine.unit_cost;
            ret.packaging = this.packaging;
            ret.location = this.location;
            ret.boxnum = this.boxnum;
            ret.lotnumber = this.lot_code;
            ret.rohs_info = putAwayLine.rohs_info_vendor;
            ret.category = putAwayLine.category;
            ret.description = putAwayLine.description;
            ret.alternatepart = putAwayLine.alternatepart;
            ret.internalcomment = "Received " + DateTime.Now.ToString() + " on " + reference + "by " + x.xUser.Name;
            ret.buy_purchase_id = putAwayLine.orderid_purchase;
            ret.serial = this.serial;


            //added for better PO tracking 2013_07_11
            ret.the_purchase_uid = putAwayLine.orderid_purchase;
            ret.purchase_line_uid = putAwayLine.unique_id;
            ret.purchase_agent_uid = putAwayLine.buyer_uid;
            ret.purchase_agent_name = putAwayLine.buyer_name;

            //added for destructive testing
            if (Tools.Strings.StrCmp(condition, "destroy"))
            {
                ret.do_not_export = true;
                ret.quantityallocated = ret.quantityallocated;
                ret.quantity_available = 0;
            }

            if (putAwayLine.SalesHas)
                ret.buy_sales_id = putAwayLine.orderid_sales;

            //KT added for is_RMA_IHS           
            if (putAwayLine.is_RMA_IHS)
                ret.is_RMA_IHS = true;

            //KT 10-16-2015 - tracking stock buy vs. agent overbuy
            ret.the_ordhed_purchase_uid = putAwayLine.orderid_purchase;
            if (!Tools.Strings.StrExt(putAwayLine.orderid_sales)) // There is no sales order for this line  
            {
                ret.is_overbuy = x.Leader.AskYesNo("No sales order detected for this line.  Is this an 'Overbuy'?  (If this is a Sensible Stock purchase, click No)");
            }

            //Convert lines that started out as a buy, but are now stock due to circumstances (customer refused, RMA but no Vendor RMA, etc)
            if (putAwayLine.StockType == StockType.Buy)
            {
                if (string.IsNullOrEmpty(putAwayLine.orderid_sales) && !string.IsNullOrEmpty(putAwayLine.orderid_purchase))
                {
                    //THis line is set as Buy, but not associated with a sale, and was purchased from a vendor.  Convert to StockType Stock.
                    if (x.Leader.AskYesNo("This line is not on a sales order, but is designated as a BUY line.  Would you like to convert the partrecord to STOCK at this time?"))
                        ret.StockType = StockType.Stock;

                }
            }




            x.Insert(ret);
            x.Execute("update qualitycontrol set the_partrecord_uid = '" + ret.unique_id + "' where the_orddet_uid = '" + putAwayLine.unique_id + "' and the_companycontact_uid = '" + unique_id + "'");


            if (putAwayLine.SalesHas && !converBuyLineToStock)//Was runnign into issue where RMA wouldn't allocate on PutAway, causing "Only 0 are allocated" popups on Vendor RMA.              
                ret.Allocate(x, Convert.ToInt32(ret.quantity), "Sales Order " + putAwayLine.ordernumber_sales, putAwayLine.unique_id);



            putAwayLine.inventory_link_caption = ret.ToString();
            putAwayLine.inventory_link_uid = ret.unique_id;
            putAwayLine.receive_location = this.location;
            x.TheSysRz.TheLineLogic.UpdateLineFromPack(x, this, putAwayLine);


            putAwayLine.Update(x);


            //Updated ethe pack with the ID Of the line we just created (put away)
            the_partrecord_uid = ret.Uid;
            Update(x);

            return ret;
        }

        //public partrecord PutAwayRMA(ContextRz x, orddet_line rma_line, String reference)
        //{
        //    partrecord ret = partrecord.New(x);
        //    ret.fullpartnumber = this.fullpartnumber;
        //    ret.datecode = this.datecode;

        //    ret.manufacturer = this.manufacturer;
        //    ret.companyname = rma_line.vendor_name;
        //    ret.vendorname = rma_line.vendor_name;
        //    ret.lotnumber = rma_line.lotnumber;
        //    ret.consignment_code = rma_line.consignment_code;
        //    ret.quantity = this.quantity;
        //    ret.StockType = Enums.StockType.Stock;
        //    ret.cost = rma_line.unit_cost;
        //    ret.packaging = this.packaging;
        //    ret.location = this.location;
        //    ret.boxnum = this.boxnum;
        //    ret.lotnumber = this.lot_code;
        //    ret.rohs_info = rma_line.rohs_info_vendor;
        //    ret.category = rma_line.category;
        //    ret.description = rma_line.description;
        //    ret.alternatepart = rma_line.alternatepart;
        //    ret.internalcomment = "Received " + DateTime.Now.ToString() + " on " + reference;
        //    ret.buy_purchase_id = rma_line.orderid_purchase;
        //    if (rma_line.SalesHas)
        //        ret.buy_sales_id = rma_line.orderid_sales;
        //    x.Insert(ret);
        //    x.Execute("update qualitycontrol set the_partrecord_uid = '" + ret.unique_id + "' where the_orddet_uid = '" + rma_line.unique_id + "' and the_companycontact_uid = '" + unique_id + "'");
        //    rma_line.inventory_link_caption = ret.ToString();
        //    rma_line.inventory_link_uid = ret.unique_id;
        //    x.Update(rma_line);
        //    return ret;
        //}


        public partrecord m_ThePart = null;
        public partrecord ThePartGet(ContextRz context)
        {
            if (m_ThePart == null && Tools.Strings.StrExt(the_partrecord_uid))
                m_ThePart = partrecord.GetById(context, the_partrecord_uid);

            return m_ThePart;
        }

        public void PrepareInventoryForShipping(ContextRz context, orddet_line shipLine, OrderType type)
        {
            Update(context);
            context.TheLeader.Comment("Updated " + ToString());

            //has to refresh right from the database; cached copies cause problems here
            partrecord p = partrecord.GetById(context, the_partrecord_uid);
            if (p == null)
            {
                //should this be an error?
            }
            else
            {
                if (p.quantity > quantity)
                {
                    partrecord going = (partrecord)p.CloneValues(context);
                    going.quantity = quantity;
                    going.quantity_available = 0;
                    going.quantityallocated = quantity;
                    context.Insert(going);


                    //update the part that's staying
                    p.quantity -= quantity;
                    string reference = "";
                    switch (type)
                    {
                        case OrderType.Sales:
                            reference = "Sales Order ";
                            break;
                        case OrderType.VendRMA:
                            reference = "Vendor RMA ";
                            break;
                        case OrderType.Service:
                            reference = "Service Order ";
                            break;
                    }
                    reference += shipLine.OrderNumberGet(type);
                    p.AllocateUn(context, quantity, reference, the_orddet_invoice_uid);
                    //p.AllocateUn(context, quantity, shipLine.OrderNumberGet(type), unique_id);
                    context.Update(p);

                    //this calls Update() on this
                    m_ThePart = going;
                    this.the_partrecord_uid = going.unique_id;
                    this.Update(context);
                }
            }
        }

        public void ShipInTrans(ContextRz context, orddet_line shipLine, OrderType type)
        {
            Update(context);
            context.TheLeader.Comment("Updated " + ToString());
            //KT, ran into an issue with Invoice# 16284, which was just a lone GCAT line.  Here's it's trying to match it to the stock part so it can pull out of inventory.
            //I don't believe we do teh inventory thing anymore, rather when one adds a line, they are prompted "Is this a GCAT" and a special GCAT line gets created.
            //Checking for "GCAT" allowed me to properly ship this invoice, Sean looked it over and said the result was good.  See ticket# 1806
            if (!shipLine.fullpartnumber.Contains("GCAT") && shipLine.StockType != StockType.Service)
            {
                partrecord p = partrecord.GetById(context, the_partrecord_uid);
                if (p == null)
                {
                    if (type == OrderType.VendRMA)
                    {
                        //The partrecord could be null is we're vrma-ing via a 3rd part drop-ship (i.e. White Horse).
                        //IF no partrecord, and vendor is Emporium or White Horse, ask if this is Drop Ship VendRMA      
                        if (context.TheSysRz.TheLineLogic.IsDropShipServiceVendor(shipLine.service_vendor_uid))
                        {

                            //At this point we have an open PO with no packs / items in inventory
                            //This will either be scrapped on-site, or shipped to original vendor                           

                            List<string> selections = new List<string>() { "drop-ship", "scrapped" };
                            string choice = context.Leader.ChooseOneChoice(context, selections, "Resolve drop shop Vendor RMA");
                            shipLine.drop_ship = true;
                            if (string.IsNullOrEmpty(choice))
                                throw new Exception("You must choose a resolution for this drop-ship vendor RMA.");
                            switch (choice)
                            {
                                case "drop-ship":
                                    {

                                        shipLine.drop_ship_comments = "VRMA# " + shipLine.ordernumber_vendrma + " drop Shipped from test house to " + shipLine.vendor_name;
                                        string dropshipTracking = context.Leader.AskForString("Please enter the drop-ship tracking number if you have it.");
                                        if (string.IsNullOrEmpty(dropshipTracking))
                                            throw new Exception("You must provide a drop-ship tracking number.");
                                        shipLine.tracking_vendrma = dropshipTracking.Trim().ToUpper();
                                        break;

                                    }
                                case "scrapped":
                                    {
                                        shipLine.status = Rz5.Enums.OrderLineStatus.Scrapped.ToString();
                                        shipLine.status_caption = Rz5.Enums.OrderLineStatus.Scrapped.ToString();
                                        shipLine.drop_ship_comments = "VRMA# " + shipLine.ordernumber_vendrma + "  has been scrapped off-site.";
                                        break;
                                    }
                            }
                            context.Update(shipLine);
                            return;
                        }

                    }
                    else
                        throw new Exception("Missing inventory on " + shipLine.ToString());
                }
                if (p == null)
                    throw new Exception("Not a drop-ship and missing inventory on " + shipLine.ToString());
                if (p.quantity != quantity)//KT errors when part is put away before getting split, then trying to ship vendrma for qty that doesn't match.  Fixed partrecord split feature to handle.
                {
                    //if (p.quantity > quantity)//Qty in stock is greater than what we need, split that stock.
                    //    p = p.Split(context, p.quantity);//Then split the stock appropriately
                    //else
                    throw new Exception("Quantity mis-match on " + shipLine.ToString() + "(pack " + p.fullpartnumber.ToString() + ").  This means the QTY of the partrecord this line is associated with is different than the QTY associated with the Pack.  Check that you have the correct stock item allocated to this line, and that it is not already fully allocated. Once confirmed, you may need to delete the existing pack for this line item and try to ship the line again.  If that doesn't work, please notify IT for manual resolution.");
                }
                if (Tools.Strings.StrExt(shipLine.orderid_sales))
                    p.AllocateUn(context, quantity, "Sales Order " + shipLine.ordernumber_sales, shipLine.unique_id);
                p.ShippedHandle(context, type.ToString() + " " + shipLine.OrderNumberGet(type), false);
            }
        }

        public virtual void ThePartSet(ContextRz context, partrecord p)
        {
            if (p == null)
                the_partrecord_uid = "";
            else
            {
                the_partrecord_uid = p.unique_id;
                condition = p.condition;
                manufacturer = p.manufacturer;
                boxnum = p.boxnum;
                datecode = p.datecode;
                location = p.location;
                lot_code = p.lotnumber;
                packaging = p.packaging;
            }
            m_ThePart = p;
            context.TheDelta.Update(context, this);
        }

        public pack Split(ContextRz context, int q)
        {
            pack ret = (pack)this.CloneValues(context);
            ret.unique_id = "";
            ret.quantity = q - this.quantity;
            context.Insert(ret);

            //this.quantity -= q;

            return ret;
        }

        public void CancelShipment(ContextRz context)
        {
            if (!Tools.Strings.StrExt(the_partrecord_uid))  //no inventory link
                return;

            partrecord p = ThePartGet(context);
            if (p != null)  //not shipped yet
                return;

            DataTable d = context.Select("select top 1 * from shipped_stock where unique_id = '" + the_partrecord_uid + "'");
            if (!Tools.Data.DataTableExists(d))
            {
                context.TheLeader.Error(ToString() + " has an inventory link, but the linked info could not be found in inventory or the shipped log");
                return;
            }

            //transaction_needed
            p = partrecord.New(context);
            p.AbsorbRow(context, d.Rows[0]);
            p.internalcomment += "\r\nUn-shipped by " + context.xUser.name + " on " + DateTime.Now.ToString();
            try
            {
                context.Execute(p.InsertSql(context));
                context.Execute("delete from shipped_stock where unique_id = '" + p.unique_id + "'");
            }
            catch
            {
                context.TheLeader.Error("Un-shipping " + ToString() + " failed");
            }
        }
    }
}
