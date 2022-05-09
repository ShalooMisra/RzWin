using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ViewDetailService : ViewDetail
    {
        protected Win.Controls.Packing unpacking;
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.Service;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_service;
            }
        }
        //Private Variables
        private service_line TheServiceLine = null;

        //Constructors
        public ViewDetailService()
        {
            InitializeComponent();
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            base.CompleteLoad();



            ts.TabPages.Remove(tabServices);//now on header screen
            lvServices.Init(CurrentDetail.ServicesArgsGet(RzWin.Context));
            bool isDropShipServiceVendor = RzWin.Context.TheSysRz.TheLineLogic.IsDropShipServiceVendor(CurrentDetail.service_vendor_uid);

            packing.Init(CurrentDetail.PacksOutServiceVar, CurrentDetail.PacksOutServiceArgs(RzWin.Context), CurrentDetail, !isDropShipServiceVendor, true);
            unpacking = RzWin.Leader.PackingControlCreate();
            tabUnPacking.Controls.Add(unpacking);
            unpacking.Dock = DockStyle.Fill;
            unpacking.Init(CurrentDetail.PacksInServiceVar, CurrentDetail.PacksInServiceArgs(RzWin.Context), CurrentDetail, false, false);
            PackLabelRefresh();


            //KT Refactored from RzSensible 10-12-2015
            try { unpacking.AfterAdd += new Rz5.Win.Controls.AfterAddHandler(unpacking_AfterAdd); }
            catch { }
        }
        public override void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem, new Rz5.ActSetupOrder(Enums.OrderType.Service));
        }
        //Protected Override Functions
        protected override void DoResize()
        {
            base.DoResize();
            try
            {
                lvServices.Left = 0;
                lvServices.Top = 0;
                lvServices.Width = tabServices.ClientRectangle.Width;
                if (TheServiceLine == null)
                {
                    lvServices.Height = tabServices.ClientRectangle.Height;
                    gbService.Visible = false;
                }
                else
                {
                    lvServices.Height = tabServices.ClientRectangle.Height - gbService.Height;
                    gbService.Visible = true;
                    gbService.Left = 0;
                    gbService.Top = lvServices.Bottom;
                    gbService.Width = tabServices.ClientRectangle.Width;
                }
            }
            catch { }
        }
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
            ordhed_service s = (ordhed_service)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Service);
            if (s == null)
                return;
            try
            {
                bool ship_mixed = false;
                bool acnt_mixed = false;
                string first_ship = "";
                string first_acnt = "";
                List<orddet> l = s.DetailsList(RzWin.Context);
                foreach (orddet d in l)
                {
                    if (!(d is orddet_line))
                        continue;
                    orddet_line ln = (orddet_line)d;
                    //ShipVia
                    if (Tools.Strings.StrExt(ln.shipvia_service_out))
                    {
                        if (!Tools.Strings.StrExt(first_ship))
                            first_ship = ln.shipvia_service_out;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_ship, ln.shipvia_service_out))
                                ship_mixed = true;
                        }
                    }
                    //Account
                    if (Tools.Strings.StrExt(ln.shippingaccount_service_out))
                    {
                        if (!Tools.Strings.StrExt(first_acnt))
                            first_acnt = ln.shippingaccount_service_out;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_acnt, ln.shippingaccount_service_out))
                                acnt_mixed = true;
                        }
                    }
                }
                if (ship_mixed)
                    s.shipvia = "Mixed";
                else
                    s.shipvia = first_ship;
                if (acnt_mixed)
                    s.shippingaccount = "Mixed";
                else
                    s.shippingaccount = first_acnt;
                s.Update(RzWin.Context);
            }
            catch { }
        }
        //Protected Functions
        //KT Refactored from RzSensible 10-12-2015
        protected void CompleteDispose()
        {
            try { unpacking.AfterAdd -= new Rz5.Win.Controls.AfterAddHandler(unpacking_AfterAdd); }
            catch { }
        }


        //Public Functions
        public void DoShip()
        {

            ts.SelectedTab = tabPacking;
            if (!packing.lvPack.AllowAdd)
                return;
            packing.AddNew();
        }
        public void DoReceive()
        {
            ts.SelectedTab = tabUnPacking;
            if (!unpacking.lvPack.AllowAdd)
                return;
            unpacking.AddNew();
        }
        //Private Functions
        //KT Refactored from RzSensible 10-12-2015
        //private void QCEntry(pack thePack)
        //{
        //    frmQC qc = new frmQC();
        //    if (!qc.CompleteLoad(RzWin.Context, thePack, CurrentDetail, "Service# " + CurrentDetail.ordernumber_service))
        //        return;
        //    qc.ShowDialog();
        //}
        //KT Refactored from RzSensible 10-12-2015
        private void unpacking_AfterAdd(pack thePack)
        {
            //QCEntry(thePack);
            orddet_line det = orddet_line.GetById(RzWin.Context, CurrentDetail.unique_id);
            if (det == null)
                return;
            CurrentDetail = det;
            //CurrentDetail.SetChanged(true);
            //CurrentDetail.Update(RzWin.Context);
            CompleteLoad();
        }

        private void PackRefresh()
        {
            CompleteSave();
            CurrentDetail.Update(RzWin.Context);
            PackLabelRefresh();
        }
        private void PackLabelRefresh()
        {
            lblPacked.Text = Tools.Number.LongFormat(CurrentDetail.quantity_packed_service);
            lblUnPacked.Text = Tools.Number.LongFormat(CurrentDetail.quantity_unpacked_service);
        }
        private void ServiceSave()
        {
            if (TheServiceLine == null)
                return;
            TheServiceLine.service_name = ctlServiceName.GetValue_String();
            TheServiceLine.quantity = ctlServiceQuantity.GetValue_Integer();
            TheServiceLine.unit_cost = ctlServiceCost.GetValue_Double();
            TheServiceLine.Update(RzWin.Context);
        }
        private void ServiceClose()
        {
            TheServiceLine = null;
            DoResize();
        }
        private void ServiceLoad(service_line l)
        {
            TheServiceLine = l;
            DoResize();
            ctlServiceName.SetValue(l.service_name);
            ctlServiceQuantity.SetValue(l.quantity);
            ctlServiceCost.SetValue(l.unit_cost);
        }
        //Buttons
        private void cmdSave_Click(object sender, EventArgs e)
        {
            ServiceSave();
            ServiceClose();
        }
        //Control Events
        private void lvServices_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            ServiceLoad((service_line)args.TheItems.FirstGet(RzWin.Context));
        }
        private void lvServices_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            service_line sl = CurrentDetail.ServiceLines.RefAddNew(RzWin.Context);
            if (sl == null)
                return;
            ServiceLoad(sl);
            ordhed oh = CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Service);
            if (!(oh is ordhed_service))
                return;
            ordhed_service s = (ordhed_service)oh;
            s.ServiceLines.RefsAdd(RzWin.Context, sl);
        }
        private void packing_PackRefreshed(object sender, EventArgs e)
        {
            PackRefresh();
        }


    }
}
