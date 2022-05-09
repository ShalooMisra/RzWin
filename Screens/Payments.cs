using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class Payments : UserControl, ICompleteLoad, IPaymentScreen  //, IChangeSubscriber
    {
        ordhed CurrentOrder;

        public Payments()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            //xSys.RegisterNotifyClass(this, "checkpayment");
            //xSys.RegisterNotifyClass(this, "ordhed");
            lv.ShowTemplate("payments_by_order", "checkpayment");
            DoResize();
        }

        public void ShowOrder(ordhed o)
        {
            CurrentOrder = o;
            gb.Text = CurrentOrder.ToString();
            lblCompany.Text = o.companyname;
            lblTerms.Text = o.terms;
            ShowTotals();
            ShowPayments();
        }

        public void ShowPayments()
        {
            //if (Tools.Misc.IsDevelopmentMachine())
            //    RzWin.Context.TheLeader.Error("Developer: LV refreshed from DB, need to reorg with VarRefs (not sure how yet)- Joel");
            ListArgs a = new ListArgs(RzWin.Context);
            a.AddAllow = true;
            a.AddCaption = "Add Payment";
            a.TheClass = "checkpayment";
            a.TheLimit = 200;
            a.TheOrder = "transdate desc";
            a.TheTable = "checkpayment";
            a.TheTemplate = "payments_by_order";
            string type = "";
            switch (CurrentOrder.OrderType)
            {
                case Enums.OrderType.Invoice:
                case Enums.OrderType.RMA:
                case Enums.OrderType.Service:
                    type = "Payment";
                    break;
                case Enums.OrderType.Purchase:
                case Enums.OrderType.VendRMA:
                    type = "Check";
                    break;
            }
            a.TheWhere = "base_ordhed_uid = '" + CurrentOrder.unique_id + "' and transtype = '" + type + "'";
            lv.ShowData(a);
        }

        public void ShowTotals()
        {
            if (CurrentOrder == null)
                return;           
            //lblTotal.Text = nTools.MoneyFormat(CurrentOrder.ordertotal);
            lblTotal.Text = nTools.MoneyFormat(CurrentOrder.ordertotal);
            lblPaid.Text = nTools.MoneyFormat(CurrentOrder.AmountPaid(RzWin.Context));
           
            //KT for some reason, outstandingamount is not getting updated, but ordertotal and amountpaid are, so just subtracting them
            //I guess because ordertotal (small o) is a property (table in SQL) and AmountPaid (capital A) is a method that actively runs
            //Yep, and looks like outstandign amount only gets set at the ordhed_invoice, so I could call it in payments.cs <Finished action>, before show totals?
            //lblBalance.Text = nTools.MoneyFormat_2_6(CurrentOrder.ordertotal - CurrentOrder.AmountPaid(RzWin.Context));

            //lblBalance.Text = nTools.MoneyFormat_2_6(CurrentOrder.ordertotal - CurrentOrder.AmountPaid(RzWin.Context));

            
            //lblBalance.Text = nTools.MoneyFormat_2_6(Math.Round(CurrentOrder.outstandingamount));
            //lblBalance.Text = nTools.MoneyFormat_2_6(CurrentOrder.outstandingamount);
            lblBalance.Text = nTools.MoneyFormat(CurrentOrder.outstandingamount);
        }

        private void lv_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            CurrentOrder.ShowNewPayment(RzWin.Context);
            ShowPayments();
        }

        private void Payments_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            gb.Left = 0;
            gb.Top = 0;
            gb.Width = this.ClientRectangle.Width;

            lv.Left = 0;
            lv.Top = gb.Bottom;
            lv.Width = this.ClientRectangle.Width;
            lv.Height = this.ClientRectangle.Height - lv.Top;
        }

        private void lv_NotifyRefresh(object sender)
        {
            ShowTotals();
        }

        private void lv_FinishedAction(object sender, ActArgs args)
        {
            if (args.Name == "Delete")
            {;
                //KT Recalculate the Order Totals
                CurrentOrder.GatherTransactions(RzWin.Context);//refresh the list of Payments
                CurrentOrder.CalculateAllAmounts(RzWin.Context);//Calculate list of payments.
                //Update the order (Also refreshes order screen,etc.)
                CurrentOrder.Update(RzWin.Context);               
            }
            ShowTotals();
        }




        //public void NotifyChangeHandler(String strClass, bool adds)
        //{
        //    try
        //    {
        //        switch (strClass.ToLower().Trim())
        //        {
        //            case "checkpayment":
        //                ShowPayments();
        //                ShowTotals();
        //                break;
        //            case "ordhed":
        //                ShowOrder(CurrentOrder);
        //                break;
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //}

        //public void NotifyChange(String strClass, bool adds)
        //{
        //    try
        //    {
        //        if (this.InvokeRequired)
        //        {
        //            HandleChangeNotification d = new HandleChangeNotification(NotifyChangeHandler);
        //            this.Invoke(d, new object[] { strClass, adds });
        //        }
        //        else
        //        {
        //            NotifyChangeHandler(strClass, adds);
        //        }
        //    }
        //    catch (Exception)
        //    { }
        //}



    }
}
