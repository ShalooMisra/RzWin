using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

using Core;

namespace Rz5
{
    public partial class ordlnk : ordlnk_auto
    {
        public OrderLinkVar Order1Var;
        public OrderLinkVar Order2Var;

        public override Var VarGetByName(string name)
        {
            switch (name.ToLower())
            {
                case "order1":
                    return Order1Var;
                case "order2":
                    return Order2Var;
                default:
                    return base.VarGetByName(name);
            }
        }

        //Constructor
        public ordlnk()
        {
            Order1Var = new OrderLinkVar(this, new CoreVarRefSingleAttribute("Order", "Rz4.ordlnk", "Rz4.ordhed", "LinksFrom", "orderid1"), 1);
            Order2Var = new OrderLinkVar(this, new CoreVarRefSingleAttribute("Order", "Rz4.ordlnk", "Rz4.ordhed", "LinksTo", "orderid2"), 2); //??
        }

        ~ordlnk()
        {
            Order1Var.Dispose();
            Order2Var.Dispose();
        }

        public override List<Var> VarsGetInitially()
        {
            List<Var> ret = base.VarsGetInitially();
            ret.Add(Order1Var);
            ret.Add(Order2Var);
            return ret;
        }

        public override string ToString()
        {
            return "Document link between " + ordertype1 + " doc " + ordernumber1 + " and " + ordertype2 + " doc " + ordernumber2;
        }
        //Public Functions
        public Enums.OrderType OrderType1
        {
            get
            {
                return RzLogic.ConvertOrderType(ordertype1);
            }

            set
            {
                ordertype1 = RzLogic.ConvertOrderType(value);
            }
        }
        public Enums.OrderType OrderType2
        {
            get
            {
                return RzLogic.ConvertOrderType(ordertype2);

            }

            set
            {
                ordertype2 = RzLogic.ConvertOrderType(value);
            }
        }
    }

    public class OrderLinkVar : VarRefSingle<ordlnk, ordhed>
    {
        ordlnk TheLink
        {
            get
            {
                return (ordlnk)Parent;
            }
        }

        int OrderIndex = 0;
        public OrderLinkVar(IItem parent, CoreVarRefSingleAttribute attr, int orderIndex)
            : base(parent, attr)
        {
            OrderIndex = orderIndex;
        }

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass q = base.QueryCreate(context);
            if (OrderIndex == 1)
            {
                if (!Tools.Strings.StrExt(TheLink.ordertype1))
                    return null;

                q.ClassId = "ordhed_" + TheLink.ordertype1.ToLower();
                q.TableMain = new QueryTable(q.ClassId);
                
                q.Where = new ExpressionBinaryOperator(new ExpressionFieldUid(), BinaryOperatorType.Equality, new ExpressionLiteralString(TheLink.orderid1));
            }
            else
            {
                if (!Tools.Strings.StrExt(TheLink.ordertype2))
                    return null;

                q.ClassId = "ordhed_" + TheLink.ordertype2.ToLower();
                q.TableMain = new QueryTable(q.ClassId);
                q.Where = new ExpressionBinaryOperator(new ExpressionFieldUid(), BinaryOperatorType.Equality, new ExpressionLiteralString(TheLink.orderid2));
            }

            return q;
        }

        public override void RefSet(Context x, ordhed value, bool includeReverse)
        {
            base.RefSet(x, value, includeReverse);

            if (OrderIndex == 1)
            {
                TheLink.orderid1 = value.unique_id;
                TheLink.ordertype1 = value.ordertype;
                TheLink.ordernumber1 = value.ordernumber;
            }
            else
            {
                TheLink.orderid2 = value.unique_id;
                TheLink.ordertype2 = value.ordertype;
                TheLink.ordernumber2 = value.ordernumber;
            }
            x.TheDelta.Update(x, TheLink);
        }
    }
}
