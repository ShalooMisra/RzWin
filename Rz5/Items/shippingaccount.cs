using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;

namespace Rz5
{
    public partial class shippingaccount : shippingaccount_auto
    {
        public override string ToString()
        {
            return "Shipping Account " + description + "  [" + accountnumber + "]";
        }
    }
}
