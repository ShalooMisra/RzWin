using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class view_ordhit : ViewPlusMenu
    {
        ordhit CurrentHit
        {
            get
            {
                return (ordhit)GetCurrentObject();
            }
        }

        public view_ordhit()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            base.CompleteLoad();
        }
        public override void CompleteSave()
        {
            base.CompleteSave();
        }
        //Private Functions
        private Boolean InvoicePaid(ordhed o)
        {
            if (o == null)
                return false;
            ordhed inv = null;
            if (o.OrderType.Equals(Enums.OrderType.Purchase))
            {
                String id = RzWin.Context.Data.SelectScalarString("select max(orderid2) from ordlnk where orderid1 in (select max(orderid2) from ordlnk where orderid1 = '" + o.unique_id + "' and ordertype1 = 'purchase' and ordertype2 = 'sales') and ordertype1 = 'sales' and ordertype2 = 'invoice'");
                if (!Tools.Strings.StrExt(id))
                    return false;
                inv = ordhed.GetById(RzWin.Context, id);
            }
            else if (o.OrderType.Equals(Enums.OrderType.Invoice))
                inv = o;
            if (o.OrderType.Equals(Enums.OrderType.RMA))
            {
                String id = RzWin.Context.Data.SelectScalarString("select orderid2 from ordlnk where orderid1 = '" + o.unique_id + "' and ordertype1 = 'rma' and ordertype2 = 'invoice'");
                if (!Tools.Strings.StrExt(id))
                    return false;
                inv = ordhed.GetById(RzWin.Context, id);
            }
            if (o.OrderType.Equals(Enums.OrderType.VendRMA))
            {
                String id = RzWin.Context.Data.SelectScalarString("select max(orderid2) from ordlnk where orderid1 in (select max(orderid2) from ordlnk where orderid1 in (select max(orderid2) from ordlnk where orderid1 = '" + o.unique_id + "' and ordertype1 = 'vendrma' and ordertype2 = 'purchase') and ordertype1 = 'purchase' and ordertype2 = 'sales') and ordertype1 = 'sales' and ordertype2 = 'invoice'");
                if (!Tools.Strings.StrExt(id))
                    return false;
                inv = ordhed.GetById(RzWin.Context, id);
            }
            if (inv == null)
                return false;
            Double pay = RzWin.Context.Data.SelectScalarDouble("select sum(transamount) from checkpayment where base_ordhed_uid = '" + inv.unique_id + "' and transtype = 'Payment'");
            if (pay >= inv.ordertotal)
                return true;
            return false;
        }
    }
}

