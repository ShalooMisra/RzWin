using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class validation_tracking : validation_tracking_auto
    {
        
    
        //Constructor
        public validation_tracking()
        {
        }


        public static validation_tracking GetMostRecentByOrderID(ContextRz x, ordhed_sales s)
        {
            validation_tracking ret = null;
            string sql = "select * from validation_tracking where orderid_sales = '" + s.unique_id + "' and date_created = (SELECT MAX(date_created) FROM validation_tracking where orderid_sales = '" + s.unique_id + "')";
            ret = (validation_tracking)x.QtO("validation_tracking",sql);



            return ret;
        }
    }
}
