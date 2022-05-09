using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NewMethod;

namespace Rz5
{
    public class ServiceLogic : NewMethod.Logic
    {
        //public virtual void ChargeCustomerServiceCost(ContextRz x, ordhed_service s, double applyamount)
        //{
        //    x.Reorg();
        //    //try
        //    //{
        //    //    if (x == null)
        //    //        return;
        //    //    if (s == null)
        //    //        return;
        //    //    frmApplyServiceCharge f = new frmApplyServiceCharge();
        //    //    f.CompleteLoad(x, s);
        //    //    f.ShowDialog();
        //    //    ordhed_sales so = f.TheSalesOrder;
        //    //    ordhed_invoice inv = f.TheInvoice;
        //    //    bool applied = false;
        //    //    if (so != null)
        //    //    {
        //    //        applied = true;
        //    //        ApplyToOrder(x, so, applyamount);
        //    //    }
        //    //    if (inv != null)
        //    //    {
        //    //        applied = true;
        //    //        ApplyToOrder(x, inv, applyamount);
        //    //    }
        //    //    if (applied)
        //    //    {
        //    //        s.charge_service_to_customer = true;
        //    //        s.IUpdate();
        //    //        foreach (orddet_line l in s.DetailsList(x))
        //    //        {
        //    //            l.charge_service_to_customer = true;
        //    //            l.IUpdate();
        //    //        }
        //    //    }
        //    //}
        //    //catch { }
        //}

        //KT  - Refactored from RzSensible.ServiceLogic.cs 2-25-2015
        public void ChargeCustomerServiceCost(ContextRz x, Rz5.ordhed_service s, double applyamount)
        {
            try
            {
                if (x == null)
                    return;
                if (s == null)
                    return;
                bool canceled = false;

                double actual_charge = x.TheLeader.AskForDouble("How much will be charged to the Customer?", applyamount, "Service Charge", ref canceled);

                ordhed_sales sale = null;
                ordhed_invoice invoice = null;

                ((ILeaderRz)x.Leader).ApplyServiceCharge(x, (ordhed_service)s, ref sale, ref invoice);

                Rz5.ordhed_sales so = sale;
                Rz5.ordhed_invoice inv = invoice;
                bool applied = false;
                if (so != null)
                {
                    applied = true;
                    ApplyToOrder(x, so, actual_charge);
                }
                if (inv != null)
                {
                    applied = true;
                    ApplyToOrder(x, inv, actual_charge);
                }
                if (applied)
                {
                    ordhed_service ss = (ordhed_service)s;
                    ss.charge_service_to_customer = true;
                    ss.service_cost_balance = applyamount - actual_charge;
                    ss.Update(x);
                    bool assigned = false;
                    foreach (orddet_line l in s.DetailsList(x))
                    {
                        if (ss.service_cost_balance <= 0)
                            l.charge_service_to_customer = true;
                        else
                        {
                            l.service_cost = 0;
                            if (!assigned)
                            {
                                l.service_cost = ss.service_cost_balance;
                                assigned = true;
                            }
                        }
                        l.Update(x);
                    }
                }
            }
            catch { }
        }

        protected virtual void ApplyToOrder(ContextRz x, ordhed o, double tot)
        {
            if (x == null)
                return;
            if (o == null)
                return;
            if (tot <= 0)
                return;
            if (o is ordhed_sales)
                ApplyToSales(x, (ordhed_sales)o, tot);
            else if (o is ordhed_invoice)
                ApplyToInvoice(x, (ordhed_invoice)o, tot);
            else
                return;
        }
        protected void ApplyToSales(ContextRz x, ordhed_sales o, double tot)
        {
            try
            {
                if (x == null)
                    return;
                if (o == null)
                    return;
                if (tot <= 0)
                    return;
                bool add = false;
                if (o.credit_amount != 0)
                    add = x.TheLeader.AskYesNo("There is already an amount on this order [" + o.ToString() + "]. Do you want to add this to the existing amount?(YES) Or overwrite this with the service charge?(NO)");
                if (add)
                    o.credit_amount += tot;
                else
                    o.credit_amount = tot;
                o.credit_caption = "Service Charge";
                x.Update(o);
            }
            catch { }
        }
        protected void ApplyToInvoice(ContextRz x, ordhed_invoice o, double tot)
        {
            try
            {
                if (x == null)
                    return;
                if (o == null)
                    return;
                if (tot <= 0)
                    return;
                bool add = false;
                if (o.credit_amount != 0)
                    add = x.TheLeader.AskYesNo("There is already an amount on this order [" + o.ToString() + "]. Do you want to add this to the existing amount?(YES) Or overwrite this with the service charge?(NO)");
                if (add)
                    o.credit_amount += tot;
                else
                    o.credit_amount = tot;
                o.credit_caption = "Service Charge";
                x.Update(o);
            }
            catch { }
        }


        public void RemoveService(ContextRz x, service_line s, orddet_line l, ordhed_service o)
        {
            //KT 4-11-2016
          
            //KT Remove the Service Line Reference from the Service Order List View
            o.ServiceLines.RefsRemove(x, s);

            //Before deleting the service_line, use it to decrement line itme service_cost
            l.service_cost -= s.total_cost;
            l.Status = Enums.OrderLineStatus.Packing_For_Service;

            //KT now we are done, thus will remove the Service Line Item              
            s.TheLine.RefRemove(x);
            s.Delete(x);

            //KT Now that the ref is gone, line can be updated without cache re-saving the value
            l.Update(x);
        }
    }
}
