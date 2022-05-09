using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class validation_form : validation_form_auto
    {
        public static validation_form GetByOrderID(ContextRz x, ordhed_sales s)
        {
            validation_form ret = null;
            ret = (validation_form)x.QtO("validation_form", "select * from validation_form where orderid_sales = '" +s.unique_id + "'");
            return ret;
        }
        public static validation_form ValidationFormCreate(ContextRz x, ordhed_sales s)
        {
            validation_form ret = null;
            ret = new validation_form();
            ret.orderid_sales = s.unique_id;
            ret.ordernumber_sales = s.ordernumber;
            ret.prevalidation_complete = false;
            ret.Insert(x);
            return ret;
        }

        public void fixOrderNumber(validation_form v, ordhed_sales s)
        {
            if (v.ordernumber_sales != s.ordernumber)
                v.ordernumber_sales = s.ordernumber;
        }


    }

}
