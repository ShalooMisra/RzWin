using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using QBFC13Lib;

namespace Rz5
{
    public partial class frmAddInvItem : Form
    {
        //Public Variables
        public string SelectedPart = "";
        public bool PartExists = false;
        public bool IsCanceled = false;

        //Private Variables
        private ContextNM TheContext;
        private string OriginalPart = "";
        private orddet TheDetail;

        //Constructors
        public frmAddInvItem()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad(ContextNM x, String p, orddet xDet)
        {
            if (x == null)
                return false;
            TheContext = x;
            if (p == null)
                return false;
            //if (Rz3App.xLogic.IsBozz)
            //{
            //    if (!p.ToLower().StartsWith("rzpart-"))
            //        p = "RzPart-" + p;
            //}
            p = Tools.Strings.Left(p, 20);
            SelectedPart = p;
            OriginalPart = p;
            TheDetail = xDet;
            LoadScreen();
            return true;
        }
        //Private Functions
        private void LoadScreen()
        {
            lblPart.Text = SelectedPart;
            LoadLV();
        }
        private void LoadLV()
        {
            lv.SuspendLayout();
            try
            {
                ArrayList a = new ArrayList();
                if (RzWin.Context.TheSysRz.TheQuickBooksLogic.GeneralOption(RzWin.Context).Contains("InventoryOnly"))
                    a = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetInventoryCollection(RzWin.Context);
                else
                    a = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetNonInventoryCollection(RzWin.Context);
                foreach (partrecord p in a)
                {
                    ListViewItem xLst = lv.Items.Add(p.fullpartnumber);
                    xLst.SubItems.Add(p.quantity.ToString());
                    xLst.Tag = p;
                }
            }
            catch { }
            lv.ResumeLayout();
        }
        private void AddItem(string part)
        {
            if (RzWin.Context.TheSysRz.TheQuickBooksLogic.GeneralOption(RzWin.Context).Contains("InventoryOnly"))
                MakeInvPartExist(part);
            else
                MakeNonInvPartExist(part);
            if (TheDetail != null)
            {
                TheDetail.alternatepart_02 = part;
                TheDetail.Update(RzWin.Context);
            }
        }
        private void SelectItem()
        {
            if (lv.SelectedItems == null)
                return;
            if (lv.SelectedItems.Count <= 0)
                return;
            partrecord p = (partrecord)lv.SelectedItems[0].Tag;
            if (p == null)
                return;
            SelectedPart = p.fullpartnumber;
            PartExists = true;
            if (TheDetail != null)
            {
                TheDetail.alternatepart_02 = p.fullpartnumber;
                TheDetail.Update(RzWin.Context);
            }
        }
        private void MakeInvPartExist(string part)
        {
            try
            {
                RzWin.Leader.Comment("Sending " + part + " as an inventory part...");
                IMsgSetRequest requestSet = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(RzWin.Context, RzWin.Context.TheSysRz.TheQuickBooksLogic.sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemInventoryAdd StockAdd = requestSet.AppendItemInventoryAddRq();
                StockAdd.Name.SetValue(Tools.Strings.Left(part, 40));
                StockAdd.IncomeAccountRef.FullName.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomeAccount(RzWin.Context, null));
                StockAdd.AssetAccountRef.FullName.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.AssetAccount(RzWin.Context));
                RzWin.Leader.Comment("Using COGS account " + RzWin.Context.TheSysRz.TheQuickBooksLogic.COGSAccount(RzWin.Context, null));
                StockAdd.COGSAccountRef.FullName.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.COGSAccount(RzWin.Context, null));
                if (!RzWin.Context.TheSysRz.TheQuickBooksLogic.Connect(RzWin.Context))
                {
                    RzWin.Leader.Comment("Can't connect.");
                    return;
                }
                IMsgSetResponse responseSet = RzWin.Context.TheSysRz.TheQuickBooksLogic.sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                RzWin.Context.TheSysRz.TheQuickBooksLogic.Disconnect();
                if (response.StatusCode != 0)
                {
                    RzWin.Leader.Comment("There was an error exporting part number " + part + ": " + response.StatusMessage);
                    return;
                }
                RzWin.Leader.Comment("Exported part number " + part);
            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }
        }
        private void MakeNonInvPartExist(string part)
        {
            try
            {
                IMsgSetRequest requestSet = RzWin.Context.TheSysRz.TheQuickBooksLogic.GetLatestMsgSetRequest(RzWin.Context, RzWin.Context.TheSysRz.TheQuickBooksLogic.sessionManager);
                requestSet.Attributes.OnError = ENRqOnError.roeStop;
                IItemNonInventoryAdd NonStockAdd = requestSet.AppendItemNonInventoryAddRq();
                RzWin.Leader.Comment("Using '" + part + "' as the part number...");
                NonStockAdd.Name.SetValue(part);
                NonStockAdd.ORSalesPurchase.SalesAndPurchase.IncomeAccountRef.FullName.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.IncomeAccount(RzWin.Context, null));
                NonStockAdd.ORSalesPurchase.SalesAndPurchase.ExpenseAccountRef.FullName.SetValue(RzWin.Context.TheSysRz.TheQuickBooksLogic.ExpenseAccount(RzWin.Context, null));
                if (!RzWin.Context.TheSysRz.TheQuickBooksLogic.Connect(RzWin.Context))
                    return;
                IMsgSetResponse responseSet = RzWin.Context.TheSysRz.TheQuickBooksLogic.sessionManager.DoRequests(requestSet);
                IResponse response = responseSet.ResponseList.GetAt(0);
                RzWin.Context.TheSysRz.TheQuickBooksLogic.Disconnect();
                if (response.StatusCode != 0)
                {
                    RzWin.Leader.Comment("There was an error exporting part number " + part + ": " + response.StatusMessage);
                    return;
                }
                RzWin.Leader.Comment("Exported part number " + part);
            }
            catch (Exception ex)
            {
                RzWin.Context.Error(ex.Message);
            }
        }
        //Buttons
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            AddItem(OriginalPart);
            SelectedPart = OriginalPart;
            Close();
        }
        private void cmdSelect_Click(object sender, EventArgs e)
        {
            SelectItem();
            Close();
        }
        private void cmdCancel_Click(object sender, EventArgs e)
        {
            IsCanceled = true;
            Close();
        }
    }
}
