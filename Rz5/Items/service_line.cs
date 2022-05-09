using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class service_line : service_line_auto
    {
        public VarRefSingle<service_line, ordhed_service> TheOrder;
        public VarRefSingle<service_line, orddet_line> TheLine;

        public override Var VarGetByName(string name)
        {
            switch (name.ToLower().Trim())
            {
                case "theorder":
                    return TheOrder;
                case "theline":
                    return TheLine;
                default:
                    return base.VarGetByName(name);
            }
        }

        //Constructor
        public service_line()
        {
            TheOrder = new VarRefSingle<service_line, ordhed_service>(this, new CoreVarRefSingleAttribute("TheOrder", "Rz4.service_line", "Rz4.ordhed_service", "ServiceLines", "the_service_order_uid"));
            TheLine = new VarRefSingle<service_line, orddet_line>(this, new CoreVarRefSingleAttribute("TheLine", "Rz4.service_line", "Rz4.orddet_line", "ServiceLines", "the_orddet_line_uid"));
        }

        public override void Updating(Context x)
        {
            CalculateAmounts();
            base.Updating(x);
        }

        public void CalculateAmounts()
        {
            total_cost = unit_cost * quantity;
        }

        public String PrintLine
        {
            get
            {
                if (quantity == 1)
                    return service_name + "  " + Tools.Number.MoneyFormat(total_cost);
                else
                    return service_name + "  " + Tools.Number.MoneyFormat(total_cost) + " (" + Tools.Number.LongFormat(quantity) + " @ " + Tools.Number.MoneyFormat(unit_cost) + ")";
            }
        }
    }
}
