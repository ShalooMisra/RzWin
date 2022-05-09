using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Tools;
using Core;
using Core.Display;
using NewMethod;

namespace Rz5
{
    public partial class ordhed_old : ordhed_old_auto
    {
        public VarRefOrderLinesOld DetailsVar;

        public ordhed_old()
        {
            DetailsVar = new VarRefOrderLinesOld(this);
        }

        public override void HandleAction(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;

            switch (args.ActionName.ToLower().Trim())
            {
                case "close":
                case "markclosed":
                    Close(xrz);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override bool Void(ContextRz context)
        {
            if (!base.Void(context))
                return false;
            isvoid = true;
            foreach (orddet d in DetailsList(context))
            {
                d.isvoid = true;
                d.Update(context);
            } 
            context.Update(this);
            return true;
        }

        public override IVarRefOrderLines Details
        {
            get
            {
                return DetailsVar;
            }
        }

        public override double SubTotal(ContextRz context)
        {
            Double dbl = 0;
            foreach (orddet_old x in DetailsList(context))
            {
                dbl += x.totalprice;
            }
            return dbl;
        }

        public override int GetNextLineCode(ContextRz context)
        {
            int winner = 0;
            foreach (orddet_old d in DetailsList(context))
            {
                if (d.linecode > winner)
                    winner = Convert.ToInt32(d.linecode);
            }
            return winner + 1;
        }

        public override void ApplyNewCurrency(ContextRz context, currency newCurrency)
        {
            base.ApplyNewCurrency(context, newCurrency);

            foreach (orddet_old o in DetailsVar.RefsList(context))
            {
                o.ApplyNewCurrency(context, newCurrency);
            }
        }

        public override orddet GetNewDetail(ContextRz context)
        {
            orddet_old xDetail = (orddet_old)context.Item(OrddetName);

            //this has to happen this way; ISave gives the detail an id, and InsertDetail adds it to the list with the ID
            //what can't happen is for the detail to have a base_ordhed_uid; otherwise if the order has to cache its details it will
            //cache the blank detail from the database because of the ID, then not accept the actual new instance of the detail being added

            //the status needs to be set first so that BeforeSave can override it
            //actually stuff like the status and isselected should be moved to BeforeSave anyway;
            //they're related to the creation of the detail, not specifically creating the detail for a header
            xDetail.status = Enums.OrderLineStatus.Open.ToString();
            context.Insert(xDetail);
            InsertDetail(context, xDetail);

            xDetail.base_ordhed_uid = unique_id;
            xDetail.ordernumber = ordernumber;
            xDetail.ordertype = ordertype;
            xDetail.linecode = GetNextLineCode(context);
            xDetail.isselected = true;

            xDetail.base_company_uid = base_company_uid;
            xDetail.base_companycontact_uid = base_companycontact_uid;
            xDetail.companyname = companyname;
            xDetail.contactname = contactname;

            //if (OrderType == Rz4.Enums.OrderType.Purchase && Rz3App.xLogic.IsMerit)
            //    xDetail.shipdate = orderdate;
            //else
            //    xDetail.shipdate = dockdate;

            xDetail.requireddate = requireddate;

            //if (Rz3App.xLogic.IsPhoenix)
            //{
            //    company c = CompanyObject;
            //    if (c != null)
            //    {
            //        xDetail.warranty_period = nData.NullFilter_String(c.IGet("warranty_period"));
            //    }
            //}

            //UpdateOneDetailInfo(xDetail);

            xDetail.currency_name = currency_name;
            xDetail.exchange_rate = exchange_rate;

            context.Update(xDetail);

            return xDetail;
        }

        public override void CalculateAllAmounts(ContextRz context)
        {
            base.CalculateAllAmounts(context);
            Double dblSub = SubTotal(context);
            ordertotal = SubTotal(context) + shippingamount + handlingamount + taxamount;
            grossamount = ordertotal;
            totalvalue = ordertotal;

            costamount = CostAmount(context);
            profitamount = Tools.Number.CommonSensibleRounding(ordertotal - costamount);
            profitamount -= (subtract_1 + subtract_2 + subtract_3);

            Double exchanged = 0;
            foreach (orddet_old x in DetailsList(context))
            {
                exchanged += x.totalprice_exchanged;
            }
            ordertotal_exchanged = exchanged;
        }

        public virtual Double CostAmount(ContextRz context)
        {
            Double ret = 0;
            foreach (orddet_old d in DetailsList(context))
            {
                ret += Number.CommonSensibleRounding(d.quantityordered * d.unitcost);
            }
            return ret;
        }

        public override List<orddet> DetailsListSummed(ContextRz context)
        {
            return orddet_old.DetailsSum(context, DetailsList(context));
        }

        public override int PictureCount(ContextRz context, bool countLines = true, String extraWhere = "")
        {
            List<string> orddet_quote_ids = new List<string>();
            foreach(orddet_quote q in this.DetailsList(context))
            {
                if (!orddet_quote_ids.Contains(q.unique_id))
                    orddet_quote_ids.Add(q.unique_id);
            }
            
            String search = "select count(*) from partpicture where the_ordhed_uid = '"+this.unique_id+"' OR the_orddet_uid IN("+Data.GetIn(orddet_quote_ids)+")";
            return context.Logic.PictureData.GetScalar_Integer(search);
        
        }

        public void Close(ContextRz context)
        {
            if (!context.xUser.CheckPermit(context, "Order:Edit:Can Close " + nTools.NiceFormat(ordertype)))
            {
                context.TheLeader.ShowNoRight();
                return;
            }
            if (!context.TheLeader.AreYouSure("close " + ToString()))
                return;
            isclosed = true;
            context.Update(this);
        }
    }

    public class VarRefOrderLinesOld : VarRefMany<ordhed, orddet_old>, IVarRefOrderLines
    {
        public ordhed TheOrder;

        public VarRefOrderLinesOld(ordhed o)
            : base(o, new CoreVarRefManyAttribute("Details", "Rz4.ordhed", "Rz4.orddet_old", "TheOrder", "base_ordhed_uid"))
        {
            TheOrder = o;
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = new QueryClass("orddet_" + TheOrder.OrderType.ToString().ToLower());
            q.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(TheOrder.unique_id));
            q.OrderBy.Add(new QueryOrder(new QueryField("linecode")));
            return q;
        }

        public override IItem RefCreate(Context x)
        {
            return x.Item(DetailClass);
        }

        public String DetailClass
        {
            get
            {
                return "orddet_" + TheOrder.OrderType.ToString().ToLower();
            }
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);

            foreach (orddet_old l in items.AllGet(x))
            {
                l.base_ordhed_uid = TheOrder.unique_id;
                l.ordernumber = TheOrder.ordernumber;
                l.orderdate = TheOrder.orderdate;

                l.CompanyRefSet((ContextRz)x, TheOrder.CompanyVar.RefGet(x), TheOrder.OrderType);
                l.ContactRefSet((ContextRz)x, TheOrder.ContactVar.RefGet(x), TheOrder.OrderType);
                l.AgentRefSet((ContextRz)x, TheOrder.AgentVar.RefGet(x), TheOrder.OrderType);
                l.linecode = TheOrder.GetNextLineCode((ContextRz)x);
            }
        }
    }
}
