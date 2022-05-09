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
    public partial class ViewDetailPurchase : ViewDetail
    {
        protected Win.Controls.Packing packing;
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.Purchase;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_purchase;
            }
        }

        //Constructors
        public ViewDetailPurchase()
        {
            InitializeComponent();
        }
        public override void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem, new Rz5.ActSetupOrder(Enums.OrderType.Purchase));
        }
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
            ordhed_purchase s = (ordhed_purchase)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Purchase);
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
                    if (Tools.Strings.StrExt(ln.shipvia_purchase))
                    {
                        if (!Tools.Strings.StrExt(first_ship))
                            first_ship = ln.shipvia_purchase;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_ship, ln.shipvia_purchase))
                                ship_mixed = true;
                        }
                    }
                    //Account
                    if (Tools.Strings.StrExt(ln.shippingaccount_purchase))
                    {
                        if (!Tools.Strings.StrExt(first_acnt))
                            first_acnt = ln.shippingaccount_purchase;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_acnt, ln.shippingaccount_purchase))
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
            ListArgs args = CurrentDetail.PacksInArgs(RzWin.Context);
            if (CurrentDetail.quantity_unpacked >= CurrentDetail.quantity)
                args.AddAllow = false;
            packing = RzWin.Leader.PackingControlCreate();
            tabPack.Controls.Add(packing);
            packing.Dock = DockStyle.Fill;
            packing.AfterAdd += new Win.Controls.AfterAddHandler(packing_AfterAdd);
            packing.PackRefreshed += new EventHandler(packing_PackRefreshed);
            packing.Init(CurrentDetail.PacksInVar, args, CurrentDetail, false, false);
            PackLabelRefresh();
            ctl_datecode_purchase.Visible = true;
            ctl_datecode.Visible = false;
            ctl_rohs_info.Visible = false;
            ctl_rohs_info_vendor.Visible = true;


            //KT - Similar to what I did with ViewDetailSales - this is setting a variable for this PO so I can set "include on PO" for deductions.
            //deductions.Init(CurrentDetail, Enums.OrderType.Purchase);
            ordhed_purchase s = (ordhed_purchase)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Purchase);
            deductions.Init(CurrentDetail, Enums.OrderType.Purchase, s);
            LoadTracking();
        }
        public override void CompleteSave()
        {

            //base.CompleteSave();
            //CurrentDetail.condition = ctl_condition.GetValue_String();
            //CurrentDetail.packaging = ctl_packaging.GetValue_String();
            //CompleteLoad_ShipAccounts();     
            base.CompleteSave();
            SaveTracking();
            deductions.Save();
            //SaveListAquisitionAgent();

        }

        

        protected void CompleteDispose()
        {
            packing.AfterAdd -= new Win.Controls.AfterAddHandler(packing_AfterAdd);
            packing.PackRefreshed -= new EventHandler(packing_PackRefreshed);
        }
        protected override void CompleteLoad_ShipAccounts()
        {
            //Clear the list
            ctl_shippingaccount_purchase.ClearList();

            //Include this order's current (possibly manual) ship address in otheraddresses
            Dictionary<string, string> otherShippingAddresses = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(CurrentDetail.shippingaccount_purchase))
                otherShippingAddresses.Add(CurrentDetail.shippingaccount_purchase, "Other");


            //If EMporium Partners PO, don't add their addresses, they will already be there.
            bool includeEmporium = (CurrentDetail.vendor_uid != "c75d3d332e0849ab8794fba5a8a921f6");


            //Load dictionarty from ShippingLogic           
            Dictionary<string, string> dict = SensibleDAL.ShippingLogic.LoadShippingAccountDictionary(CurrentDetail.vendor_uid, otherShippingAddresses, includeEmporium);

            ////The line might have a manual value that is not on the standard list, if so check and add it.
            //string currentShipAccount = CurrentDetail.shippingaccount_purchase;
            //if (!string.IsNullOrEmpty(currentShipAccount))
            //    dict.Add(currentShipAccount, "Other");

            if (dict != null)
                ctl_shippingaccount_purchase.AddFromDictionary(dict);




            ctl_shippingaccount_purchase.SetValue(CurrentDetail.shippingaccount_purchase);

            //if (CurrentDetail.PurchaseVar.RefGet(RzWin.Context) == null)
            //    return;
            //bool added = false;
            //if (CurrentDetail.PurchaseVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context) != null)
            //{
            //    string companyid = CurrentDetail.PurchaseVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context).unique_id;
            //    ArrayList a = RzWin.Context.TheSysRz.TheOrderLogic.GetCompanyShipAccounts(RzWin.Context, companyid, true, RzWin.Logic);
            //    if (a != null && a.Count > 0)
            //    {
            //        added = true;
            //        ctl_shippingaccount_purchase.AddFromArray(a);
            //    }

            //}
            //if (added)
            //    ctl_shippingaccount_purchase.AddIfNotBlank("________________________");
            //ctl_shippingaccount_purchase.AddIfNotBlank(RzWin.Logic.InternalUPS);
            //ctl_shippingaccount_purchase.AddIfNotBlank(RzWin.Logic.InternalFedex);
            //ctl_shippingaccount_purchase.AddIfNotBlank(RzWin.Logic.InternalDHL);
            //ctl_shippingaccount_purchase.AddIfNotBlank(RzWin.Logic.InternalOther);
            //ctl_shippingaccount_purchase.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
        }
        private void LoadTracking()
        {
            string track = CurrentDetail.tracking_purchase;
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains(","))
                return;
            track = track.Replace(",", "\r\n");
            ctl_tracking_purchase.SetValue_String(track);
        }
        private void SaveTracking()
        {
            string track = ctl_tracking_purchase.GetValue_String();
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains("\r\n"))
                return;
            track = track.Replace("\r\n", ",");
            CurrentDetail.tracking_purchase = track;
            CurrentDetail.Update(RzWin.Context);

        }
        private void PackRefresh()
        {
            CompleteSave();
            CurrentDetail.Update(RzWin.Context);
            //CompleteLoad();
        }
        private void PackLabelRefresh()
        {
            lblUnpacked.Text = Tools.Number.LongFormat(CurrentDetail.quantity_unpacked);
        }
        public void DoReceive(bool auto_receive = true)
        {
            ts.SelectedTab = tabPack;

            if (!packing.lvPack.AllowAdd)
                return;
            if (auto_receive)
                packing.AddNew();
            if (CurrentDetail.PacksInVar.m_TheItems.Count == 0)//Only add a pack when another doesn't exist.
                packing.AddNew();
        }
        //Private Functions
        protected virtual void QCEntry(pack thePack)
        {
            frmQC qc = new frmQC();
            if (!qc.CompleteLoad(RzWin.Context, thePack, CurrentDetail, "PO# " + CurrentDetail.ordernumber_purchase))
                return;
            qc.ShowDialog();
        }
        protected virtual void PackingAfterAdd(pack thePack)
        {
            ////KT - Removed 3-10-2014 - no longer need to fire this off when receiving a buy line
            ////we now have a more robust inspection system.
            //QCEntry(thePack);
            //orddet_line det = orddet_line.GetById(RzWin.Context, thePack.the_orddet_purchase_uid);
            //if (det == null)
            //return;
            // CurrentDetail = det;
            //CurrentDetail.Changed = true;
            //CurrentDetail.Update(RzWin.Context);
            //CompleteLoad();
            //RzWin.Leader.ViewsClose(CurrentDetail);
            //RzWin.Leader.CloseTabsByID(RzWin.Context, CurrentDetail.unique_id);
        }
        //Control Events
        private void packing_AfterAdd(pack thePack)
        {
            PackingAfterAdd(thePack);
        }
        private void packing_PackRefreshed(object sender, EventArgs e)
        {
            PackRefresh();
        }
    }
}
