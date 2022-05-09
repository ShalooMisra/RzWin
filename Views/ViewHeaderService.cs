using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Core;

namespace Rz5
{
    public partial class ViewHeaderService : ViewHeader
    {

        //Private Variables
        protected ordhed_service CurrentOrderService
        {
            get
            {
                return (ordhed_service)CurrentOrder;
            }
        }
        protected Rz5.service_line TheServiceLine = null;

        //Constructors
        public ViewHeaderService()
        {
            InitializeComponent();
        }

        //Public Override Functions
        public override void CompleteLoad()
        {
            lvServices.Init(CurrentOrderService.ServicesArgsGet(RzWin.Context));
            ctlServiceName.LoadList(true);
            base.CompleteLoad();
        }

        public override void CompleteSave()
        {           
            ServiceSave();

            
            base.CompleteSave();
        }



        public override void HandleCommand(string strCommand)
        {
            switch (strCommand.ToLower())
            {
                case "delete":
                    {
                        orddet_line l = null;
                        if (RzWin.Leader.AskYesNo("Are you sure you want to delete " + CurrentOrder.OrderType + " Order: " + CurrentOrder.ordernumber + "?"))
                        {

                            if (CurrentOrderService.ServiceLines.RefsList(RzWin.Context).Count > 0)
                                foreach (service_line s in CurrentOrderService.ServiceLines.RefsList(RzWin.Context))
                                {
                                    //l = s.TheLine.RefGet(RzWin.Context);
                                    l = s.TheLine.RefGet(RzWin.Context);
                                    if (l == null)
                                        l = (orddet_line)details.GetFirstObject();
                                    if (l != null)
                                        if (l.unique_id == s.the_orddet_line_uid)
                                            RzWin.Context.TheSysRz.TheServiceLogic.RemoveService(RzWin.Context, s, l, CurrentOrderService);
                                        else
                                        {
                                            RzWin.Leader.Tell("ID Mismatch, service_line, orddet_line");
                                            return;
                                        }

                                }
                            CurrentOrderService.Delete(RzWin.Context);
                            SendCloseRequest();

                        }

                    }
                    break;
                default:
                    base.HandleCommand(strCommand);
                    break;
            }
        }






        //Protected Override Functions
        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                lvServices.Dock = DockStyle.None;
                if (TheServiceLine == null)
                {
                    lvServices.Dock = DockStyle.Fill;
                    gbService.Visible = false;
                }
                else
                {
                    lvServices.Left = 0;
                    lvServices.Top = 0;
                    lvServices.Width = tabServices.ClientRectangle.Width - 2;
                    gbService.Visible = true;
                    gbService.Left = 0;
                    gbService.Top = (tabServices.ClientRectangle.Height - gbService.Height) - 2;
                    gbService.Width = tabServices.ClientRectangle.Width - 2;
                    lvServices.Height = (gbService.Top - lvServices.Top) - 2;
                }
            }
            catch { }
        }
        protected override void CompleteLoad_Shipping()
        {
            base.CompleteLoad_Shipping();
            string track = "";
            lvShipVia.Items.Clear();
            lvAccount.Items.Clear();
            lvShipVia.SuspendLayout();
            lvAccount.SuspendLayout();
            try
            {
                List<orddet> l = CurrentOrderService.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_service_out.Replace("\r\n", ",");
                    if (Tools.Strings.StrExt(track))
                        track += ",";
                    track += ln.tracking_service_in.Replace("\r\n", ",");
                    ListViewItem xLst = lvShipVia.Items.Add(ln.linecode_service.ToString());
                    xLst.SubItems.Add(ln.shipvia_service_out);
                    xLst = lvAccount.Items.Add(ln.linecode_service.ToString());
                    xLst.SubItems.Add(ln.shippingaccount_service_out);
                }
            }
            catch { }
            lvShipVia.ResumeLayout();
            lvAccount.ResumeLayout();
            ctl_trackingnumber.SetValue(track);
        }
        protected override void SetShipVia()
        {
            IsLoading = true;
            try
            {
                CurrentOrderService.shipvia = ctl_shipvia.GetValue_String();
                CurrentOrderService.Update(RzWin.Context);
                List<orddet> l = CurrentOrderService.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shipvia_service_out = ctl_shipvia.GetValue_String();
                    ln.Update(RzWin.Context);
                }
                CompleteLoad_Shipping();
            }
            catch { }
            IsLoading = false;
        }
        protected override void SetShipAccounts()
        {
            IsLoading = true;
            try
            {
                CurrentOrderService.shippingaccount = ctl_shippingaccount.GetValue_String();
                CurrentOrderService.Update(RzWin.Context);
                List<orddet> l = CurrentOrderService.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    ln.shippingaccount_service_out = ctl_shippingaccount.GetValue_String();
                    ln.Update(RzWin.Context);
                }
            }
            catch { }
            CompleteLoad_Shipping();
            IsLoading = false;
        }
        protected override void CompleteLoad_Status()
        {
            base.CompleteLoad_Status();

            int pa = CurrentOrderService.DetailsListShippableComplete(RzWin.Context).Count;
            bool allServiceLinesComplete = GetCompletedServiceLines();
            //int pap = CurrentOrderService.DetailsListShippablePartial(RzWin.Context).Count;
            //if (pa > 0 || pap > 0)
            //In order to ship, since svc order can have many lines, and Rz associates all services with the 1st line, not the others, we need only ensure at least one service exists.
            //int serviceLineCount= CurrentOrderService.GetServiceLineCount(RzWin.Context);
            //if (CountLinesOutForService() != CurrentOrderService.DetailsCount(RzWin.Context))
            if (pa > 0 && allServiceLinesComplete)
            {
                gbAction1.Visible = true;
                cmdAction1.Enabled = true;
                cmdAction1.ImageKey = "Ship.png";
            }
            else
            {

                gbAction1.Visible = false;
            }

            pa = CurrentOrderService.DetailsListPutAwayableComplete(RzWin.Context).Count;
            int pap = CurrentOrderService.DetailsListPutAwayablePartial(RzWin.Context).Count;
            if (pa > 0 || pap > 0)
            {
                gbAction2.Visible = true;
                cmdAction2.Enabled = true;
                cmdAction2.ImageKey = "PutAway.png";

                String s = "";
                if (pa > 0)
                    s = Tools.Strings.PluralizePhrase("Complete Line", pa);

                if (pap > 0)
                {
                    if (s != "")
                        s += "\r\n";
                    s += Tools.Strings.PluralizePhrase("Partial Line", pap);
                }

                lblLineStatus2.Text = s;
            }
            else
            {
                gbAction2.Visible = false;
            }

         
           
        }

        private bool GetCompletedServiceLines()
        {
            List<service_line> sLines = CurrentOrderService.ServiceLines.RefsList(RzWin.Context);
            if (sLines.Count == 0)
                return false;

            foreach (service_line sl in sLines)
            {                
                if (sl.unit_cost <= 0)
                    return false;
                if (string.IsNullOrEmpty(sl.service_name))
                    return false;
                if (sl.quantity <= 0)
                    return false;
            }
            return true;
        }

        private int CountLinesOutForService()
        {
            int ret = 0;
            foreach (orddet_line l in CurrentOrderService.DetailsList(RzWin.Context))
            {
                if (l.Status == Enums.OrderLineStatus.Out_For_Service)
                    ret++;

            }
            return ret;
        }



        protected override void CompleteLoad_Totals()
        {
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " 0.00";
            if (CurrentOrderService == null)
                return;
            CurrentOrderService.CalculateAllAmounts(RzWin.Context);
            lblSubTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentOrderService.sub_total);
            lblCharges.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentOrderService.Expenses);
            lblTotal.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentOrderService.ordertotal);

            //KT12-3-2015
            lblCreditAmount.Text = RzWin.Context.Sys.CurrencySymbol + " " + Tools.Number.MoneyFormat(CurrentOrderService.creditamount);
        }
        protected override void Action1()
        {
            base.Action1();
            CurrentOrderService.Ship(RzWin.Context);
            if (RzWin.Context.xSys.Recall)
                RzWin.Context.xSys.RecallActionLog(CurrentOrderService, "Service Order Shipped", RzWin.Context.xUser);


        }
        protected override void Action2()
        {
            base.Action2();
            CurrentOrderService.PutAway(RzWin.Context);
            if (RzWin.Context.xSys.Recall)
                RzWin.Context.xSys.RecallActionLog(CurrentOrderService, "Service Order Put Away", RzWin.Context.xUser);
            CheckClosePurchaseOrdersFromServiceOrder(RzWin.Context);


        }

        public void CheckClosePurchaseOrdersFromServiceOrder(ContextRz context)
        {
            //For this line, check it's parent PO.  Then check if all lines closable. If so, close.
            List<ordhed_purchase> poList = new List<ordhed_purchase>();
            foreach (orddet_line l in CurrentOrderService.DetailsList(RzWin.Context))
            {
                if (!string.IsNullOrEmpty(l.orderid_purchase))
                {
                    ordhed_purchase po = ordhed_purchase.GetById(context, l.orderid_purchase);
                    if (po == null)
                        return;
                    if (!poList.Contains(po))
                    {
                        poList.Add(po);
                    }
                }

            }
            foreach (ordhed_purchase p in poList)
            {
                if (!p.isclosed)//If more than one line on same po, 1st line will close, second line would reopen
                {
                    context.TheLeader.ViewsClose(p);
                    p.Close(context, CloseType.DropShipServiceReceive);

                    context.Show(p);//After trying the stuff below, this is the only way I can make sure the user sees teh completed PO.
                    //context.TheDelta.Update(context, p);  //This, also doesn't refresh.  Maddening.
                    //If I don't show, then if the user has any related orders, they keep thi po isclosed = false until I close them all.
                    //Note that it's also correct in order search, just not on load if any related orders open.


                    //this context.Update is required, else when you open the PO, it won't show closed unless you close / reopen Rz even though isClosed = true here, 
                    //it would be false when user opens the PO until maybe close / reopen of rz.
                    //context.Update(p);                    
                    //ViewHeaderPurchase vp = new ViewHeaderPurchase();
                    //vp.SetCurrentObject(p);                   
                    //vp.CompleteSaveAndUpdate();


                }
            }
        }




        //Private Functions
        protected virtual void ServiceLoad(Rz5.service_line l)
        {
            TheServiceLine = l;
            DoResize();
            ctlServiceName.SetValue(l.service_name);
            ctlServiceQuantity.SetValue(l.quantity);
            ctlServiceCost.SetValue(l.unit_cost);
            ctl_service_notes.SetValue_String(l.service_notes);
            ctl_harmonized_code.SetValue(l.harmonized_code);
            //ctl_hts_code.SetValue(l.hts_code);
            ServiceCaptionShow();
        }
        protected virtual bool ServiceSave()
        {
            if (TheServiceLine == null)
                return false;
            string service_name = ctlServiceName.GetValue_String();
            if (string.IsNullOrEmpty(service_name))
            {
                RzWin.Context.Leader.Error("You must provide a 'Service Name' in order to save this seThis line is linked to a partrecord via inventory_link_uidrvice line.");
                return false;
            }

            TheServiceLine.service_name = service_name;
            TheServiceLine.quantity = ctlServiceQuantity.GetValue_Integer();
            TheServiceLine.unit_cost = ctlServiceCost.GetValue_Double();
            TheServiceLine.service_notes = ctl_service_notes.GetValue_String();
            TheServiceLine.harmonized_code = ctl_harmonized_code.GetValue_String();
            //TheServiceLine.hts_code = ctl_hts_code.GetValue_String();
            TheServiceLine.Update(RzWin.Context);


            try
            {
                CurrentOrderService.ServiceDetailsAssign(RzWin.Context);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error Updating Service Cost: " + ex.ToString());
            }           
            //SetOrddetLineStatus(RzWin.Context);
            lvServices.Init(CurrentOrderService.ServicesArgsGet(RzWin.Context));

            
            return true;
        }

        //internal void SetOrddetLineStatus(ContextRz x)
        //{
        //    if (CurrentOrderService.GetServiceLineCount(x) > 0)
        //        foreach (orddet_line l in CurrentOrderService.DetailsList(x))
        //        {
        //            l.Status = Enums.OrderLineStatus.Packing_For_Service;
        //            l.Update(x);
        //        }
        //    else
        //        foreach (orddet_line l in CurrentOrderService.DetailsList(x))
        //        {
        //            l.Status = Enums.OrderLineStatus.Hold;
        //            l.Update(x);
        //        }
        //}
        protected virtual void SetPrintComments()
        {

            //KT 11-16-2016 - I think this was just to append to print comment, however it CONTINUALLY appends.  Think better to separate the two.
            //string s = "";
            //if (Tools.Strings.StrExt(CurrentOrderService.printcomment))
            //    s = "\r\n";
            //CurrentOrderService.printcomment += s + TheServiceLine.service_name;
            //CurrentOrderService.Update(RzWin.Context);
            //ctl_printcomment.SetValue_String(CurrentOrderService.printcomment);
        }
        protected void ServiceClose()
        {
            TheServiceLine = null;
            DoResize();
        }
        private void ServiceCaptionShow()
        {
            lblServiceTotal.Text = Tools.Number.MoneyFormat(ctlServiceQuantity.GetValue_Integer() * ctlServiceCost.GetValue_Double());
        }
        protected virtual void SaveService()
        {
            ServiceSave();
            ServiceClose();
        }
        //Buttons
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveService();
        }
        //Control Events
        private void lvServices_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            ServiceLoad((Rz5.service_line)args.TheItems.FirstGet(RzWin.Context));
        }
        private void lvServices_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            ServiceLoad(CurrentOrderService.ServiceLines.RefAddNew(RzWin.Context));

        }

        private void lvServices_AboutToAction(object sender, Core.ActArgs args)
        {
            args.Handled = true;
            orddet_line l = null;
            switch (args.ActionName)
            {
                case "delete":
                    {
                        ContextRz xrz = (ContextRz)args.TheContext;
                        service_line s = (service_line)lvServices.GetSelectedObject();
                        l = s.TheLine.RefGet(xrz);
                        if (l == null)
                            l = (orddet_line)details.GetFirstObject();
                        if (s.the_orddet_line_uid == l.unique_id)
                            xrz.TheSysRz.TheServiceLogic.RemoveService(xrz, s, l, CurrentOrderService);
                        else
                            RzWin.Leader.Tell("ID Mismatch - Service, orddeet_line");
                    }
                    break;
                default:
                    break;
            }

        }

     




        private void tsDetails_TabIndexChanged(object sender, EventArgs e)
        {
            if (tsDetails.SelectedTab == tabServices)
                DoResize();
        }
        private void ctlServiceQuantity_DataChanged(Tools.GenericEvent e)
        {
            ServiceCaptionShow();
        }
        private void ctlServiceCost_DataChanged(Tools.GenericEvent e)
        {
            ServiceCaptionShow();
        }

        private void ViewHeaderService_Load(object sender, EventArgs e)
        {

        }

        private void ViewHeaderService_Load_1(object sender, EventArgs e)
        {

        }
    }
}
