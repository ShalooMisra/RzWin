using System;
using System.Collections;
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
    public partial class ViewDetailRMA : ViewDetail
    {
        protected Win.Controls.Packing packing;
        protected ordhed CurrentOrder;
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.RMA;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_rma;
            }
        }

        //Constructors
        public ViewDetailRMA()
        {
            InitializeComponent();
        }
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
            ordhed_rma s = (ordhed_rma)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.RMA);
            if (s == null)
                return;
            try
            {
                CurrentOrder = (ordhed)RzWin.Context.QtO("ordhed_rma", "select * from ordhed_rma where unique_id = '" + CurrentDetail.orderid_invoice + "'");
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
                    if (Tools.Strings.StrExt(ln.shipvia_rma))
                    {
                        if (!Tools.Strings.StrExt(first_ship))
                            first_ship = ln.shipvia_rma;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_ship, ln.shipvia_rma))
                                ship_mixed = true;
                        }
                    }
                    //Account
                    if (Tools.Strings.StrExt(ln.shippingaccount_rma))
                    {
                        if (!Tools.Strings.StrExt(first_acnt))
                            first_acnt = ln.shippingaccount_rma;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_acnt, ln.shippingaccount_rma))
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
        public override void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem, new Rz5.ActSetupOrder(Enums.OrderType.RMA));
        }
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            ListArgs args = CurrentDetail.PacksRMAArgs(RzWin.Context);
            if (CurrentDetail.quantity_unpacked_rma >= CurrentDetail.quantity)
                args.AddAllow = false;
            packing = RzWin.Leader.PackingControlCreate();
            tabPacking.Controls.Add(packing);
            packing.Dock = DockStyle.Fill;
            packing.AfterAdd += new Win.Controls.AfterAddHandler(packing_AfterAdd);
            packing.PackRefreshed += new EventHandler(packing_PackRefreshed);
            packing.Init(CurrentDetail.PacksRMAVar, args, CurrentDetail, false, false);
            PackLabelRefresh();
            LoadTracking();
            deductions.Init(CurrentDetail, Enums.OrderType.RMA, CurrentOrder);
        }
        public override void CompleteSave()
        {
            base.CompleteSave();
            SaveTracking();
            deductions.Save();
        }
        protected void CompleteDispose()
        {
            packing.AfterAdd -= new Win.Controls.AfterAddHandler(packing_AfterAdd);
            packing.PackRefreshed -= new EventHandler(packing_PackRefreshed);
        }
        public void DoReceive()
        {
            ts.SelectedTab = tabPacking;
            if (!packing.lvPack.AllowAdd)
                return;
            packing.AddNew();
        }
        protected override void CompleteLoad_ShipAccounts()
        {
            ctl_shippingaccount_rma.ClearList();
            if (CurrentDetail.RMAVar.RefGet(RzWin.Context) == null)
                return;
            bool added = false;
            if (CurrentDetail.RMAVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context) != null)
            {
                ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + CurrentDetail.RMAVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context).unique_id + "' ORDER BY ACCOUNTNUMBER");
                if (a != null && a.Count > 0)
                    added = true;
                ctl_shippingaccount_rma.AddFromArray(a);
            }
            if (added)
                ctl_shippingaccount_rma.AddIfNotBlank("________________________");
            ctl_shippingaccount_rma.AddIfNotBlank(RzWin.Logic.InternalUPS);
            ctl_shippingaccount_rma.AddIfNotBlank(RzWin.Logic.InternalFedex);
            ctl_shippingaccount_rma.AddIfNotBlank(RzWin.Logic.InternalDHL);
            ctl_shippingaccount_rma.AddIfNotBlank(RzWin.Logic.InternalOther);
            ctl_shippingaccount_rma.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
        }
        private void LoadTracking()
        {
            string track = CurrentDetail.tracking_rma;
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains(","))
                return;
            track = track.Replace(",", "\r\n");
            ctl_tracking_rma.SetValue_String(track);
        }
        private void SaveTracking()
        {
            string track = ctl_tracking_rma.GetValue_String();
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains("\r\n"))
                return;
            track = track.Replace("\r\n", ",");
            CurrentDetail.tracking_rma = track;
            CurrentDetail.Update(RzWin.Context);
        }
        void PackRefresh()
        {
            CompleteSave();
            CurrentDetail.Update(RzWin.Context);
            CompleteLoad();
        }
        void PackLabelRefresh()
        {
            lblUnpacked.Text = Tools.Number.LongFormat(CurrentDetail.quantity_unpacked_rma);
        }
        private void QCEntry(pack thePack)
        {
            frmQC qc = new frmQC();
            if (!qc.CompleteLoad(RzWin.Context, thePack, CurrentDetail, "RMA# " + CurrentDetail.ordernumber_rma))
                return; 
            qc.ShowDialog();
        }
        //Control Events
        private void packing_AfterAdd(pack thePack)
        {
            //KT This seems to be where the QC form is getting invoked.  Can suppress it for now as we are using a different QC method
            //QCEntry(thePack);
            //orddet_line det = orddet_line.GetById(RzWin.Context, thePack.the_orddet_rma_uid);
            //if (det == null)
            //    return;
            //CurrentDetail = det;
            //CurrentDetail.Changed = true;
            //CurrentDetail.Update(RzWin.Context);
            //CompleteLoad();
           
           ////KT - I'd like to clost this tab on OK
           // RzWin.Context.TheLeaderRz.
            
        }
        private void packing_PackRefreshed(object sender, EventArgs e)
        {
            PackRefresh();
        }
    }
}
