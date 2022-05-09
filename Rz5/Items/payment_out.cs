using System;
using System.Collections.Generic;
using System.Text;

using Core;

namespace Rz5
{
    public partial class payment_out : payment_out_auto, IPayment
    {
        public payment_out()
        {

        }

        public void SetCompany(company comp)
        {
            vendor_uid = comp.unique_id;
            vendor_name = comp.companyname;
        }
    }
}
