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
    public partial class ViewDetailVendRMA : ViewDetail
    {
        //Protected Override Variables
        protected ordhed CurrentOrder;
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.VendRMA;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_vendrma;
            }
        }
        protected Win.Controls.Packing packing;

        //Constructors
        public ViewDetailVendRMA()
        {
            InitializeComponent();
        }
        public override void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem, new ActSetupOrder(Enums.OrderType.VendRMA));
        }
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
            ordhed_vendrma s = (ordhed_vendrma)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.VendRMA);
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
                    if (Tools.Strings.StrExt(ln.shipvia_vendrma))
                    {
                        if (!Tools.Strings.StrExt(first_ship))
                            first_ship = ln.shipvia_vendrma;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_ship, ln.shipvia_vendrma))
                                ship_mixed = true;
                        }
                    }
                    //Account
                    if (Tools.Strings.StrExt(ln.shippingaccount_vendrma))
                    {
                        if (!Tools.Strings.StrExt(first_acnt))
                            first_acnt = ln.shippingaccount_vendrma;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_acnt, ln.shippingaccount_vendrma))
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
        public override void CompleteLoad()
        {
            base.CompleteLoad();
            CurrentOrder = (ordhed)RzWin.Context.QtO("ordhed_vendrma", "select * from ordhed_vendrma where unique_id = '" + CurrentDetail.orderid_vendrma + "'");
            ListArgs args = CurrentDetail.PacksVendRMAArgs(RzWin.Context);
            if (CurrentDetail.quantity_packed_vendrma >= CurrentDetail.quantity)
                args.AddAllow = false;
            packing = RzWin.Leader.PackingControlCreate();
            tabPacking.Controls.Add(packing);
            deductions.Init(CurrentDetail, Enums.OrderType.VendRMA, CurrentOrder);
            packing.Dock = DockStyle.Fill;
            packing.PackRefreshed += new EventHandler(packing_PackRefreshed);
            packing.Init(CurrentDetail.PacksVendRMAVar, args, CurrentDetail, true, true);
            PackLabelRefresh();
            LoadTracking();            
        }
        public override void CompleteSave()
        {
            base.CompleteSave();
            SaveTracking();
            deductions.Save();
        }
        protected override void CompleteLoad_ShipAccounts()
        {
            ctl_shippingaccount_vendrma.ClearList();
            if (CurrentDetail.VendRMAVar.RefGet(RzWin.Context) == null)
                return;
            bool added = false;
            if (CurrentDetail.VendRMAVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context) != null)
            {
                ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + CurrentDetail.VendRMAVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context).unique_id + "' ORDER BY ACCOUNTNUMBER");
                if (a != null && a.Count > 0)
                    added = true;
                ctl_shippingaccount_vendrma.AddFromArray(a);
            }
            if (added)
                ctl_shippingaccount_vendrma.AddIfNotBlank("________________________");
            ctl_shippingaccount_vendrma.AddIfNotBlank(RzWin.Logic.InternalUPS);
            ctl_shippingaccount_vendrma.AddIfNotBlank(RzWin.Logic.InternalFedex);
            ctl_shippingaccount_vendrma.AddIfNotBlank(RzWin.Logic.InternalDHL);
            ctl_shippingaccount_vendrma.AddIfNotBlank(RzWin.Logic.InternalOther);
            ctl_shippingaccount_vendrma.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
        }
        private void packing_PackRefreshed(object sender, EventArgs e)
        {
            PackRefresh();
        }
        public void DoShip()
        {
            ts.SelectedTab = tabPacking;
            if (!packing.lvPack.AllowAdd)
                return;
            packing.AddNew();
        }
        void PackRefresh()
        {
            CompleteSave();
            CurrentDetail.Update(RzWin.Context);
            PackLabelRefresh();
        }
        private void LoadTracking()
        {
            string track = CurrentDetail.tracking_vendrma;
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains(","))
                return;
            track = track.Replace(",", "\r\n");
            ctl_tracking_vendrma.SetValue_String(track);
        }
        private void SaveTracking()
        {
            string track = ctl_tracking_vendrma.GetValue_String();
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains("\r\n"))
                return;
            track = track.Replace("\r\n", ",");
            CurrentDetail.tracking_vendrma = track;
            CurrentDetail.Update(RzWin.Context);
        }
        void PackLabelRefresh()
        {
            lblPacked.Text = Tools.Number.LongFormat(CurrentDetail.quantity_packed_vendrma);
        }
    }
}
