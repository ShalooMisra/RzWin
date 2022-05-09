using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class profit_deduction : profit_deduction_auto
    {
        VarRefSingle<profit_deduction, orddet_line> TheLine;

        //[CoreVarRefSingle("Purchase", "profit_deduction", "ordhed_purchase", "Deductions", "purchase_order_uid")]
        VarRefSingle<profit_deduction, ordhed_purchase> PurchaseVar;

        //[CoreVarRefSingle("Sales", "profit_deduction", "ordhed_sales", "Deductions", "sales_order_uid")]
        VarRefSingle<profit_deduction, ordhed_sales> SalesVar;

        

        //Constructor
        public profit_deduction()
            : base()
        {
            TheLine = new VarRefSingle<profit_deduction, orddet_line>(this, new CoreVarRefSingleAttribute("TheLine", "Rz4.profit_deduction", "Rz4.orddet_line", "Deductions", "the_orddet_line_uid"));
            PurchaseVar = new VarRefSingle<profit_deduction, ordhed_purchase>(this, new CoreVarRefSingleAttribute("Purchase", "profit_deduction", "ordhed_purchase", "Deductions", "purchase_order_uid"));
            SalesVar = new VarRefSingle<profit_deduction, ordhed_sales>(this, new CoreVarRefSingleAttribute("Sales", "profit_deduction", "ordhed_sales", "Deductions", "sales_order_uid"));
        }

        public override Var VarGetByName(string name)
        {
            switch (name)
            {
                case "TheLine":
                    return TheLine;
                case "Purchase":
                    return PurchaseVar;
                case "Sales":
                    return SalesVar;
                default:
                    return base.VarGetByName(name);                
            }

        }
    }
}
