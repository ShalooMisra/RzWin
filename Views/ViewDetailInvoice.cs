using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class ViewDetailInvoice : ViewDetail
    {
        protected Win.Controls.Packing packing;
        protected ordhed CurrentOrder;
        //Protected Override Variables
        protected override Rz5.Enums.OrderType OrderType
        {
            get
            {
                return Rz5.Enums.OrderType.Invoice;
            }
        }
        protected override string OrderNumber
        {
            get
            {
                if (CurrentDetail == null)
                    return "";
                return CurrentDetail.ordernumber_invoice;
            }
        }

        //Constructors
        public ViewDetailInvoice()
        {
            InitializeComponent();
        }
        public override void InitActions()
        {
            if (TheItem != null)
                xActions.CompleteLoad((nObject)TheItem, new ActSetupOrder(Enums.OrderType.Invoice));
        }
        public override void CompleteLoad()
        {



            base.CompleteLoad();
            ctl_country_of_origin.Visible = true;
            CurrentOrder = (ordhed)RzWin.Context.QtO("ordhed_invoice", "select * from ordhed_invoice where unique_id= '"+CurrentDetail.orderid_invoice+"'");
            packing = RzWin.Leader.PackingControlCreate();
            tabPacking.Controls.Add(packing);
            packing.Dock = DockStyle.Fill;
            packing.PackRefreshed += new EventHandler(packing_PackRefreshed);
            packing.AfterAdd += new Win.Controls.AfterAddHandler(packing_AfterAdd);
            packing.Init(CurrentDetail.PacksOutVar, CurrentDetail.PacksOutArgs(RzWin.Context), CurrentDetail, true, true);
            PackLabelRefresh();
            deductions.Init(CurrentDetail, Enums.OrderType.Invoice, CurrentOrder);
            LoadTracking();
        }
        protected void CompleteDispose()
        {
            packing.PackRefreshed -= new EventHandler(packing_PackRefreshed);
        }
        private void LoadTracking()
        {
            string track = CurrentDetail.tracking_invoice;
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains(","))
                return;
            track = track.Replace(",", "\r\n");
            ctl_tracking_invoice.SetValue_String(track);
        }
        private void SaveTracking()
        {
            string track = ctl_tracking_invoice.GetValue_String();
            if (!Tools.Strings.StrExt(track))
                return;
            if (!track.Contains("\r\n"))
                return;
            track = track.Replace("\r\n", ",");
            CurrentDetail.tracking_invoice = track;
            CurrentDetail.Update(RzWin.Context);
        }
        protected override void CheckUpdateShipping()
        {
            if (CurrentDetail == null)
                return;
            ordhed_invoice s = (ordhed_invoice)CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Invoice);
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
                    if (Tools.Strings.StrExt(ln.shipvia_invoice))
                    {
                        if (!Tools.Strings.StrExt(first_ship))
                            first_ship = ln.shipvia_invoice;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_ship, ln.shipvia_invoice))
                                ship_mixed = true;
                        }
                    }
                    //Account
                    if (Tools.Strings.StrExt(ln.shippingaccount_invoice))
                    {
                        if (!Tools.Strings.StrExt(first_acnt))
                            first_acnt = ln.shippingaccount_invoice;
                        else
                        {
                            if (!Tools.Strings.StrCmp(first_acnt, ln.shippingaccount_invoice))
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
        protected override void CompleteLoad_ShipAccounts()
        {
            ctl_shippingaccount_invoice.ClearList();
            if (CurrentDetail.InvoiceVar.RefGet(RzWin.Context) == null)
                return;
            bool added = false;
            if (CurrentDetail.InvoiceVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context) != null)
            {
                ArrayList a = RzWin.Context.SelectScalarArray("SELECT DISTINCT(ACCOUNTNUMBER) FROM shippingaccount WHERE accountnumber > '' and base_company_uid = '" + CurrentDetail.InvoiceVar.RefGet(RzWin.Context).CompanyVar.RefGet(RzWin.Context).unique_id + "' ORDER BY ACCOUNTNUMBER");
                if (a != null && a.Count > 0)
                    added = true;
                ctl_shippingaccount_invoice.AddFromArray(a);
            }
            if (added)
                ctl_shippingaccount_invoice.AddIfNotBlank("________________________");
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalUPS);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalFedex);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalDHL);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Logic.InternalOther);
            ctl_shippingaccount_invoice.AddIfNotBlank(RzWin.Context.GetSetting("dhl_account"));
        }

        //KT Refactored from RzSensible
        protected override void CompleteLoad_Header()
        {
            base.CompleteLoad_Header();
            if (CurrentDetail == null)
                return;
            ordhed_invoice i = (ordhed_invoice)CurrentDetail.OrderObjectGet(RzWin.Context, Rz5.Enums.OrderType.Invoice);
            if (i == null)
                return;
            if (!((Rz5.CompanyLogic)((SysRz5)RzWin.Context.xSys).TheCompanyLogic).IsCompanyFinancialsVerified(i.CompanyVar.RefGet(RzWin.Context), i))
                ts.TabPages.Remove(tabPacking);
        }

        public override void CompleteSave()
        {
            ctl_shippingaccount_invoice.ClearList();
            company c = CurrentDetail.OrderObjectGet(RzWin.Context, Enums.OrderType.Invoice).CompanyVar.RefGet(RzWin.Context);
            if (c != null)
                CompleteLoad_ShipAccounts();
            deductions.Save();
            base.CompleteSave();
            SaveTracking();
           
        }

        protected virtual void QCEntry(pack thePack)
        {
            //override
        }
        public void DoShip()
        {
            ts.SelectedTab = tabPacking;
            if (!packing.lvPack.AllowAdd)
                return;
            if (CurrentDetail.PacksOutVar.m_TheItems.Count == 0)//Only add a pack when another doesn't exist.
                packing.AddNew();
        }
        void PackRefresh()
        {
            CompleteSave();
            CurrentDetail.Update(RzWin.Context);
            PackLabelRefresh();
        }
        void PackLabelRefresh()
        {
            lblPacked.Text = Tools.Number.LongFormat(CurrentDetail.quantity_packed);
        }
        private void packing_PackRefreshed(object sender, EventArgs e)
        {
            PackRefresh();
        }
        private void packing_AfterAdd(pack thePack)
        {
            QCEntry(thePack);
        }

        private void ctl_description_Load(object sender, EventArgs e)
        {

        }
    }
}