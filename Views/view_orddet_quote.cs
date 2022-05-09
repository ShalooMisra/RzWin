using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class view_orddet_quote : ViewPlusMenu
    {
        //Public Variables
        public orddet_quote CurrentDetail
        {
            get
            {
                return (orddet_quote)GetCurrentObject();
            }
        }
        //Protected Variables
        protected IReqLine xLine;

        //Constructors
        public view_orddet_quote()
        {
            InitializeComponent();
            lstBids.AsyncMode = false;
            if (RzWin.Context != null)
            {
                xLine = ((LeaderWinUserRz)RzWin.Context.TheLeader).GetReqLine();
                xLine.CommandsVisible = false;
                Controls.Add((Control)xLine);
                xLine.Left = 0;
                xLine.Top = 0;
                xLine.HeightInit();
            }
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            //if (Rz3App.xLogic.IsAAT)
            //    ChangeEditStringsToCaps();

            oth.HideOptions();
            oth.LimitedMode = true;
            dl.il = il;
            CurrentDetail.TryCacheDeal(RzWin.Context);
            ShowDealAndBids();
            if (CurrentDetail.xDeal != null)
            {
                if (lstBids.GetCount() > CurrentDetail.xDeal.VendorHalf.Details.Count)
                {
                    if (RzWin.User.IsDeveloper())
                        RzWin.Leader.Tell("Fixing bids");
                    //fix the deal ids
                    RzWin.Context.Execute("update orddet_rfq set base_dealheader_uid = '" + CurrentDetail.base_dealheader_uid + "' where the_orddet_quote_uid = '" + CurrentDetail.unique_id + "'");
                    //show the deal again
                    CurrentDetail.xDeal.Init(RzWin.Context);
                    ShowDeal();
                }
            }
            dl.ArrangeControls();
            xLine.IsExpanded = true;
            xLine.CommandsVisible = false;
            xLine.CompleteLoad(CurrentDetail, null, false);
            SetPic();
            DoResize();
            base.CompleteLoad();
        }
        public override void CompleteSave()
        {

            xLine.CompleteSave();

            orddet_quote q = null;
            if (xLine.CurrentObject is orddet_quote)
                q = (orddet_quote)xLine.CurrentObject;
            if (RzWin.Context.TheSysRz.TheOrderLogic.CheckQuoteBeforeSave(RzWin.Context, q))
            {

                //Get the dealheader
                //If No HubID, Create Hubspot Deal
                dealheader d = q.GetDealHeader(RzWin.Context);
                if (d == null)
                    return;

                //Create or update the deal
                if (d.hubspot_deal_id == 0)
                {
                   
                }




            }
            try
            {
                foreach (KeyValuePair<String, nLineHandle> kvp in dl.DisplayedObjects)
                {
                    try
                    {
                        kvp.Value.xLine.CompleteSave();
                    }
                    catch { }
                }
            }
            catch { }
            SetPic();


            base.CompleteSave();

        }
        public override void HandleCommand(string strCommand)
        {
            switch (strCommand.ToLower().Replace(" ", ""))
            {
                case "choosestock":
                    ReceiveStockBid();
                    break;
                case "salesorder":

                    if (!ReadyToSell())
                        return;
                    //CurrentDetail.MakeDealExist(TheContext);
                    CurrentDetail.MakeHeaderExist((ContextRz)RzWin.Context);
                    ArrayList a = new ArrayList();
                    a.Add(CurrentDetail);

                    ordhed_quote q = (ordhed_quote)CurrentDetail.OrderObject((ContextRz)RzWin.Context);
                    ordhed_sales ret = q.SalesOrderCreate((ContextRz)RzWin.Context);
                    RzWin.Context.Show(ret);

                    break;
                case "re-orderso":
                    MessageBox.Show("reorg");
                    //if (!ReadyToSell())
                    //    return;
                    //ArrayList ax = new ArrayList();
                    //ax.Add(CurrentDetail);
                    //CurrentDetail.Show(((ordhed_quote)CurrentDetail.OrderObject).MakeSalesOrder(Rz3App.xMainForm.TheContextNM, ax, true));
                    break;
                case "save":
                    base.HandleCommand(strCommand);
                    SaveAllObjects(false);
                    CompleteLoad();
                    break;
                case "saveandexit":
                    if (RzWin.Logic.ShowReqStatus)
                    {
                        //nStatus.StopLogFile();
                        //RzWin.Leader.StopPopStatus();
                        //nStatus.StartLogFile(Tools.Folder.ConditionFolderName(Tools.FileSystem.GetAppPath()) + "req.txt");
                        RzWin.Leader.StartPopStatus("Save and exiting...");
                    }
                    SaveAllObjects(false);
                    base.HandleCommand(strCommand);
                    SaveAllObjects(true);

                    if (CurrentDetail != null)
                    {
                        if (((orddet_quote)CurrentDetail).CheckQuoteBeforeSave(RzWin.Context))
                            CurrentDetail.Update(RzWin.Context);
                    }
                    break;
                case "vieworderbatch":
                    CompleteSave();
                    if (CurrentDetail.xDeal == null)
                    {
                        CurrentDetail.HandleAction(new ActArgs(RzWin.Form.TheContextNM, "vieworderbatch"));
                        return;
                    }
                    else
                    {
                        dealheader xdeal = dealheader.GetById(RzWin.Context, CurrentDetail.base_dealheader_uid);
                        xdeal.Init(RzWin.Context);
                        RzWin.Context.Show(xdeal);
                        SendCloseRequest();
                    }
                    break;
                default:
                    base.HandleCommand(strCommand);
                    return;
            }
        }
        public override void FinishedAction(ActArgs args)
        {
            base.FinishedAction(args);

            switch (args.ActionName.ToLower())
            {
                case "receivebid":
                    ShowDeal();
                    if (CurrentDetail.BidJustAdded != null)
                        dl.ShowObject(CurrentDetail.BidJustAdded);
                    DoResize();
                    break;
                case "formalquote":
                    xLine.ShowHeaderInfo();
                    break;
            }
        }
        //Protected Override Functions
        protected override void InitUn()
        {
            try
            {
                Controls.Remove((Control)xLine);
                xLine.Dispose();
                xLine = null;
            }
            catch { }

            base.InitUn();

        }
        protected override void DoResize()
        {
            base.DoResize();

            try
            {
                lstBids.Left = 0;
                lstBids.Width = this.ClientRectangle.Width - xActions.Width;
                lstBids.Height = (this.ClientRectangle.Height - (lstBids.Top + dl.Height)) / 2;

                oth.Top = lstBids.Bottom;
                oth.Left = 0;
                oth.Width = this.ClientRectangle.Width - xActions.Width;
                oth.Height = lstBids.Height; // this.ClientRectangle.Height - (oth.Top + dl.Height);

                dl.Left = 0;
                dl.Top = oth.Bottom;
                dl.Width = this.ClientRectangle.Width - xActions.Width;

                xLine.Width = this.ClientRectangle.Width - (xActions.Width + xLine.Left);

                //xLine.DoResize();
            }
            catch { }
        }
        protected override List<Control> ControlsToIgnore
        {
            get
            {
                List<Control> ret = base.ControlsToIgnore;
                if (ret == null)
                    ret = new List<Control>();
                ret.Add(dl);
                ret.Add((Control)xLine);
                return ret;
            }
        }
        //Public Functions
        public void ShowDeal()
        {
            if (CurrentDetail.xDeal == null)
                return;
            oth.RestrictParentID = CurrentDetail.unique_id;
            oth.CompleteLoad(CurrentDetail.xDeal);
        }
        //Private Functions
        private void ShowDealAndBids()
        {
            ShowDeal();
            lstBids.AsyncMode = false;
            lstBids.Init(CurrentDetail.BidArgsGet(RzWin.Context));
        }
        private void SetPic()
        {
            Image qi = null;
            if (CurrentDetail.IsQuoted)
                qi = il.Images["quote"];
            else
                qi = il.Images["req"];
            xLine.SetImage(qi);
        }
        private void ChangeEditStringsToCaps()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    SetAllCaps(c);
                }
            }
            catch (Exception ee)
            { }
        }
        private void SetAllCaps(Control c)
        {
            try
            {
                if (c == null)
                    return;
                nEdit_String str = null;
                try { str = (nEdit_String)c; }
                catch { }
                if (str == null)
                {
                    foreach (Control cc in c.Controls)
                    {
                        SetAllCaps(cc);
                    }
                    return;
                }
                str.AllCaps = true;
            }
            catch (Exception ee)
            { }
        }
        private bool ReadyToSell()
        {
            if (CurrentDetail.quantityordered <= 0)
            {
                RzWin.Context.TheLeader.TellTemp("Please enter a quote quantity before continuing.");
                return false;
            }

            if (CurrentDetail.unitprice <= 0)
            {
                RzWin.Context.TheLeader.TellTemp("Please enter a quote price before continuing.");
                return false;
            }

            return true;
        }
        private void SaveAllObjects(bool close)
        {
            if (dl == null)
                return;
            if (dl.DisplayedObjects == null)
                return;

            try
            {

                RzWin.Leader.Comment("Saving all objects ( close=" + close.ToString() + " )");

                ArrayList al = new ArrayList();
                foreach (KeyValuePair<String, nLineHandle> k in dl.DisplayedObjects)
                {
                    al.Add(k.Value.xLine);
                }

                foreach (nLine l in al)
                {
                    RzWin.Leader.Comment("Saving " + l.CurrentObject.ToString());

                    if (close)
                        dl.DisplayedObjects.Remove(l.CurrentObject.unique_id);

                    l.CompleteSave();

                    if (close)
                    {
                        try
                        {
                            orddet_old d = (orddet_old)l.CurrentObject;
                            d.RefreshNodes(RzWin.Context);
                        }
                        catch { }

                        dl.Remove(l);

                        try
                        {
                            l.Dispose();
                        }
                        catch { }
                    }
                }

                dl.ArrangeControls();
                DoResize();
            }
            catch { }
        }
        private void ReceiveStockBid()
        {
            //CurrentDetail.MakeDealExist();
            //if (CurrentDetail.xDeal == null)
            //    return;

            //ExtraSearch_partrecord ps = new ExtraSearch_partrecord();
            //ps.PartNumber = CurrentDetail.fullpartnumber;

            //partrecord p = (partrecord)frmChooseFromClipboard.Choose(Rz3App.xSys, "partrecord", Rz3App.xUser.unique_id, "", this.ParentForm, ps);
            //if (p == null)
            //    return;

            //ShowDeal();

            //dealcompany sc = CurrentDetail.xDeal.MakeCompanyExist("", "Stock", "", "", true, false);

            //orddet x = sc.AddStock(CurrentDetail.xDeal, (orddet_quote)CurrentDetail, p, sc);
            //dl.ShowObject(x);
            //ShowDeal();
            //DoResize();
        }
        //Control Events
        private void oth_ObjectClicked(nObject x, String strExtra)
        {
            String msg = "";
            if (!dl.ShowObject(x, ref msg))
            {
                if (RzWin.User.IsDeveloper())
                    RzWin.Leader.Tell("clicked: " + msg);
            }
            DoResize();
        }
        private void dl_GotResize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void dl_SavedObject(object sender, EventArgs e)
        {
            xLine.UpdateCostAndProfit();
        }
        private void dl_MakePO(IBidLine l)
        {
            try
            {
                orddet_rfq r = l.CurrentBid;
                r.MakePO(RzWin.Context);

                //dealcompany c = CurrentDetail.xDeal.MakeCompanyExist(r.base_company_uid, r.companyname, r.base_companycontact_uid, r.contactname, true, false);

                //oth.CreateOrder(true, c);
            }
            catch { }
        }
        private void dl_ReloadRequest(object sender, EventArgs e)
        {
            ShowDeal();
        }
        private void lstBids_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            String msg = "";
            nObject x = (nObject)args.TheItems.FirstGet(RzWin.Context);
            if (!dl.ShowObject(x, ref msg))
            {
                if (RzWin.User.IsDeveloper())
                    RzWin.Leader.Tell("clicked: " + msg);
            }
            DoResize();
        }
    }
}

