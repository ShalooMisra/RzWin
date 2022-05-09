using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5.Win.Controls
{
    public partial class Packing : UserControl
    {
        //Public Events
        public event EventHandler PackRefreshed;
        public event PackEventHandler BeforeAdd;
        public event AfterAddHandler AfterAdd;
        //Private Variables
        protected pack ThePack;
        protected orddet_line TheLine;
        protected IVarRefMany TheVar;
        protected bool RequireStock = false;
        protected bool IsPick = false;
        protected ListArgs TheArgs;
        private pack ThePack_delete;

        //Constructors
        public Packing()
        {
            InitializeComponent();
        }
        //Public Functions
        public virtual void Init(IVarRefMany var, ListArgs args, orddet_line line, bool require_stock, bool is_pick)
        {
            TheVar = var;
            TheLine = line;
            IsPick = is_pick;
            //KT 4-1-2016 - Hiding my split label for packs out (invoice ship, etc.) under assumption
            //that it's only really useful on receiving.
            if (IsPick == true)
                txtSplitAlert.Visible = false;
            TheArgs = args;
            //KT 12-8-2015 - Check if line is a GCAT before requiring Stock to receive.           
            if (line.fullpartnumber.Contains("GCAT"))
                require_stock = false;

            RequireStock = require_stock;
            lvPack.CurrentVar = var;
            lvPack.Init(args);

            //KT now we not allowing manual add, it's more automatic.
            lvPack.AllowAdd = false;

            TogglePackBox(IsPick);



            GetThePack();
            HandleControlVisibility();
            DoResize();
        }


        private void TogglePackBox(bool isPackOut)
        {
            if (isPackOut)
            {
                gbPack.Visible = false;
            }
            else if (RzWin.Context.TheSysRz.TheLineLogic.IsServiceLineEligibleForAutoReceive(RzWin.Context, TheLine))
            {
                gbPack.Visible = false;
            }
            else
                gbPack.Visible = true;

        }

        private void GetThePack()
        {
            ThePack = (pack)lvPack.CurrentItems.FirstGet(RzWin.Context);
            //if (ThePack == null)
            //    AddNew();
            //else PackShow(ThePack);
            if (ThePack != null)
                PackShow(ThePack);
            //if (ThePack == null)
            //{
            //    RzWin.Context.Leader.Error("Error, null pack.");
            //    return;
            //}


            //PackShow(ThePack, false);
        }

        public virtual void AddNew()
        {
            if (BeforeAdd != null)
            {
                if (!BeforeAdd())
                    return;
            }
            partrecord stock = null;
            if (RequireStock)
            {
                stock = (partrecord)TheLine.LinkedInventory(RzWin.Context);

                if (stock == null)
                    stock = RzWin.Leader.StockChoose(RzWin.Context, TheLine.fullpartnumber);  //this is where all of the info for a likely match needs to be passed in from the line to the picking screen

                if (stock == null)
                    return;

                if (stock.quantity == 0)
                {
                    RzWin.Context.TheLeader.Error(stock.ToString() + " has zero quantity");
                    return;
                }
            }
            pack p = (pack)TheVar.RefAddNewItem(RzWin.Context);
            if (stock != null)
            {
                p.ThePartSet(RzWin.Context, stock);
                if (stock.quantity < p.quantity)
                    p.quantity = Convert.ToInt32(stock.quantity);
                p.Update(RzWin.Context);
            }


            PackShow(p);

        }
        //Private Functions


        private void HandleControlVisibility()
        {
            //kt these were all in DoResize, better to keep these tasks separate
            //try
            //{

            //    lvPack.AllowAdd = false;
            //    if (IsPick)
            //    {
            //        ctl_PackMFG.Visible = false;
            //        ctl_PackDC.Visible = false;
            //        ctl_PackCondition.Visible = false;
            //    }
            //    else
            //    {
            //        ctl_PackMFG.Visible = true;
            //        ctl_PackDC.Visible = true;
            //        ctl_PackCondition.Visible = true;

            //    }
            //    if (ThePack == null)
            //    {
            //        gbPack.Visible = false;
            //        lvPack.AllowAdd = true;
            //    }
            //    else
            //    {

            //    }

            //}
            //catch { }
            if (ThePack == null)
            {
                gbPack.Visible = false;
                lvPack.AllowAdd = true;
            }
            else
            {
                gbPack.Visible = true;
                lvPack.AllowAdd = false;
            }
        }


        protected virtual void DoResize()
        {
            try
            {
                lvPack.Left = 0;
                lvPack.Top = 0;
                lvPack.Width = this.ClientRectangle.Width;
                lvPack.AllowAdd = false;
                if (IsPick)
                {
                    gbPack.Height = 60;
                    cmdPackOK.Top = 10;
                }
                else
                {

                    gbPack.Height = 172;
                    //cmdPackOK.Top = 40;
                }
                if (ThePack == null)
                {
                    lvPack.Height = this.ClientRectangle.Height;
                    lvPack.AllowAdd = true;
                }
                else
                {
                    lvPack.Height = this.ClientRectangle.Height - gbPack.Height;
                    gbPack.Left = 0;
                    gbPack.Top = lvPack.Bottom;
                    gbPack.Width = this.ClientRectangle.Width;
                }

                //else
                //{
                //    //IF Purchase / RMA, show gbPack for unpacking

                //    gbPack.Visible = true;
                //    lvPack.Height = this.ClientRectangle.Height - gbPack.Height;
                //    gbPack.Left = 0;
                //    gbPack.Top = lvPack.Bottom;
                //    gbPack.Width = this.ClientRectangle.Width;
                //    //Else hide gbPack
                //    gbPack.Visible = false;

                //}
            }
            catch { }
        }
        protected virtual void PackShow(pack p, bool thrown = false)
        {
            ctl_PackPackaging.LoadList();
            ThePack = p;
            ctl_PackCondition.LoadList();
            ctl_PackQuantity.SetValue(p.quantity);//If we auto-set this value, then 
            ctl_PackDC.SetValue(p.datecode);
            ctl_PackMFG.SetValue(p.manufacturer);
            ctl_PackCondition.SetValue(p.condition);
            ctl_PackBoxNum.SetValue(p.boxnum);
            ctl_PackLocation.SetValue(p.location);
            ctl_PackLotNum.SetValue(p.lot_code);
            ctl_PackPackaging.SetValue(p.packaging);
            TogglePackBox(IsPick);
            HandleControlVisibility();
            DoResize();
        }
        protected virtual bool PackSave()
        {
            string failMsg = "Missing value: ";

            if (ThePack == null)
                return false;
            ThePack.quantity = ctl_PackQuantity.GetValue_Integer();



            //Manufacturer
            string packMfg = ctl_PackMFG.GetValue_String();
            if (string.IsNullOrEmpty(packMfg))
            {
                RzWin.Context.Leader.Error(failMsg + "Manufacturer");
                return false;
            }
            else
                ThePack.manufacturer = packMfg;

            //Datecode
            string packDateCode = ctl_PackDC.GetValue_String();
            if (string.IsNullOrEmpty(packDateCode))
            {
                RzWin.Context.Leader.Error(failMsg + "Date Code");
                return false;
            }
            else
                ThePack.datecode = packDateCode;


            //Condition
            string packCondition = ctl_PackCondition.GetValue_String();
            if (string.IsNullOrEmpty(packCondition))
            {
                RzWin.Context.Leader.Error(failMsg + "Condition");
                return false;
            }
            else
                ThePack.condition = packCondition;

            //Packaging
            string packPackaging = ctl_PackPackaging.GetValue_String();
            if (string.IsNullOrEmpty(packPackaging))
            {
                RzWin.Context.Leader.Error(failMsg + "Packaging");
                return false;
            }
            else
                ThePack.packaging = packPackaging;

            //Location
            string packLocation = ctl_PackLocation.GetValue_String();
            if (string.IsNullOrEmpty(packLocation))
            {
                RzWin.Context.Leader.Error(failMsg + "Location");
                return false;
            }
            else
                ThePack.location = packLocation;


            //ThePack.datecode = ctl_PackDC.GetValue_String();
            //ThePack.condition = ctl_PackCondition.GetValue_String();
            //ThePack.packaging = ctl_PackPackaging.GetValue_String();
            //ThePack.location = ctl_PackLocation.GetValue_String();


            ThePack.boxnum = ctl_PackBoxNum.GetValue_String();
            ThePack.lot_code = ctl_PackLotNum.GetValue_String();
            ThePack.pack_complete = true;
            ThePack.Update(RzWin.Context);
            return true;
            //PackRefresh();//This Updates, Saves, and Loads the Line item
        }
        protected virtual void OKClicked()
        {
            if (PackSave())//This takes forever!!
            {
                CheckUpdateDetail();
                if (AfterAdd != null)
                {
                    AfterAdd(ThePack);
                }

                PackClose();
                //RzWin.Leader.CloseTabsByID(RzWin.Context, TheLine.unique_id);
                RzWin.Context.TheLeader.ViewsClose(TheLine);
            }



        }
        protected void PackClose()
        {
            ThePack = null;
            //PackRefresh();
            DoResize();
        }
        protected void PackRefresh()
        {
            if (PackRefreshed != null)
                PackRefreshed(null, null);
        }
        private void CheckUpdateDetail()
        {
            if (TheLine == null)
                return;
            CheckForLineSplit();
            RzWin.Context.TheLeaderRz.UpdateDetailFromPack(RzWin.Context, TheLine, ThePack);//Update the details values with Values from the Pack
        }
        private void CheckForLineSplit()
        {
            if (TheLine == null)
                return;
            if (ThePack == null)
                return;
            if (ThePack.quantity > TheLine.quantity)
                HandleOverReceive();
            else if (TheLine.quantity > ThePack.quantity)
                TheLine.Split(RzWin.Context, TheLine.quantity - ThePack.quantity);
        }
        private void HandleOverReceive()
        {
            if (TheLine == null)
                return;
            if (ThePack == null)
                return;
            int o_qty = TheLine.quantity;
            int qty = ThePack.quantity - o_qty;
            orddet_line l = (orddet_line)TheLine.Split(RzWin.Context, qty);
            l.quantity_unpacked = qty;
            l.unit_cost = 0;
            l.Update(RzWin.Context);
            TheLine.quantity = o_qty;
            TheLine.quantity_unpacked = o_qty;
            TheLine.Update(RzWin.Context);
            ThePack.quantity = o_qty;
            ThePack.Update(RzWin.Context);
            pack p = (pack)ThePack.CloneValues(RzWin.Context);
            if (Tools.Strings.StrExt(p.the_orddet_purchase_uid))
                p.the_orddet_purchase_uid = l.unique_id;
            else if (Tools.Strings.StrExt(p.the_orddet_rma_uid))
                p.the_orddet_rma_uid = l.unique_id;
            else if (Tools.Strings.StrExt(p.the_orddet_service_in_uid))
                p.the_orddet_service_in_uid = l.unique_id;
            p.quantity = qty;
            p.Insert(RzWin.Context);
            //l.PacksInVar.Add(RzWin.Context, p);
        }
        //ButtonsPackRefreshed
        private void cmdPackOK_Click(object sender, EventArgs e)
        {
            OKClicked();
        }
        //Control Events
        private void Packing_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvPack_AboutToAdd(object sender, Core.AddArgs args)
        {
            args.Handled = true;
            //KT 8-19-2015 - check sum of all pack QTY's and compare to total line QTY
            //if (!RzWin.Context.xUserRz.SuperUser)//Allow Super Users to bypass while testing
            if (!IsPick)
                if (CheckForExistingPack())
                    return;
            if (ThePack == null)//shoyuldn't be n
                AddNew();
            PackShow(ThePack);
        }

        //KT 8-19-2015 - check sum of all pack QTY's and compare to total linq QTY
        protected bool CheckForExistingPack()
        {
            int ExistingPackQTY = RzWin.Context.SelectScalarInt32("select SUM(quantity) from pack WHERE the_orddet_purchase_uid = '" + TheLine.unique_id + "'");
            if (ExistingPackQTY >= TheLine.quantity)
            {
                RzWin.Leader.Tell("It appears this item has already been received.  If you need to adjust the details, double-click the existing receive and make your changes before saving.");
                return true;
            }
            else
                return false;
        }

        private void lvPack_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            args.Handled = true;
            PackShow(ThePack);
        }
        private void lvPack_FinishedAction(object sender, ActArgs args)
        {
            if (Tools.Strings.StrCmp(args.ActionName, "delete"))
            {
                if (ThePack_delete != null)
                {
                    try { TheVar.RefsRemove(RzWin.Context, ThePack_delete); }
                    catch { }
                    try
                    {
                        CheckUpdateDetail();
                        TheLine.Update(RzWin.Context);
                    }
                    catch { }
                    lvPack.CurrentVar = TheVar;
                    lvPack.Init(TheArgs);
                }
            }
        }

      

       

        private void lvPack_AboutToAction(object sender, ActArgs args)
        {
            ThePack_delete = null;
            if (Tools.Strings.StrCmp(args.ActionName, "delete"))
            {
                try { ThePack_delete = (pack)lvPack.GetSelectedObject(); }
                catch { }
            }
        }
    }
    public delegate void AfterAddHandler(pack thePack);
    public delegate bool PackEventHandler();
}
