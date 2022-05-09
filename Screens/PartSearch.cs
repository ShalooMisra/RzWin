using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;
using NewMethod;
using SensibleDAL.dbml;

namespace Rz5.Win.Screens
{
    public partial class PartSearch : Rz5.Win.Screens.PartSearchBase, IPartSearch
    {
        public PartSearch()
        {
            InitializeComponent();
            throbPics.BackColor = Color.White;
            throbPics.Visible = false;
            pSummary.Height = 0;
            pCompanyOptions.Visible = false;
        }

        public virtual void Init()
        {
            //this can't happen in the constructor; there is stuff in the derived control constructor that expects the tabs to be in the tabstrip
            if (!Tools.Misc.IsDevelopmentMachine() && ts.TabPages.Contains(tabRzCommunity))
            {
                try { ts.TabPages.Remove(tabRzCommunity); }
                catch { }
            }

            CompList.Clear();
            CachePartNumbers();

            SearchParts("");
            SearchQuotes("");
            SearchSales("");
            SearchPurchase("");
            SearchPictures("");
            SearchRMA("");
            SearchShipped("");

            DefaultsApply();
            TabVisCheck();
            SummaryClear();
            SetPartFocus();
        }

        protected virtual void InitUn()
        {
            try
            {
                ilPics.Images.Clear();
                if (PicHandles != null)
                    PicHandles.Clear();
            }
            catch { }
        }

        void DefaultsApply()
        {
            PartSearchParameters pars = RzWin.Context.TheSysRz.ThePartLogic.PartSearchParametersDefaultGet(RzWin.Context);
        }

        private void CompList_CompanyChangeFinished(GenericEvent e)
        {
            try
            {
                pCompanyOptions.Visible = Tools.Strings.StrExt(CompList.GetCompanyID());
            }
            catch (Exception)
            {
            }
        }

        private void CompList_ContactChangeFinished(GenericEvent e)
        {
            try
            {
                pCompanyOptions.Visible = Tools.Strings.StrExt(CompList.GetCompanyID());
            }
            catch (Exception)
            {
            }
        }

        private void txtPartNumber_GetEnter(object sender, KeyPressEventArgs e)
        {
            Search();
        }

        public void Search()
        {
            try
            {
                string term = "%";
                //KT - wildcard search when no partnumber is present
                if (!string.IsNullOrEmpty(txtPartNumber.Text))
                {
                    term = Strings.SanitizeInput(txtPartNumber.Text);
                }
                if (string.IsNullOrEmpty(term))
                    throw new Exception("Invalid Search Term.");

                term = term.Trim().ToUpper();
                SetPartNumber(term);
                Search(term);

                CheckAddPartNumber(term);
                SavePartNumbers();
            }
            catch(Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
           
        }

        public virtual void Search(String term)
        {
            //if (RzWin.User.Name == "Kevin Till")
            //    if (RzWin.Context.Leader.AskYesNo("Want to try the LINQ search?"))
            //    {
            //        PartSearchParameters pp = ParametersGet(term);
            //        List<SensibleDAL.dbml.partrecord> pList = SearchPartsToList(term, pp);
            //        DataTable dt = Tools.Data.ListtoDataTable.ToDataTable(pList);
            //        ListArgs args = RzWin.Context.TheSysRz.ThePartLogic.PartSearchArgsGet(RzWin.Context, ParametersGet(term));
            //        Result_Parts.Init(dt, args);
            //        return;
            //    }




            if (ts.SelectedTab == tabParts)
                SearchParts(term);
            else if (ts.SelectedTab == tabQuotes)
                SearchQuotes(term);
            else if (ts.SelectedTab == tabSales)
                SearchSales(term);
            else if (ts.SelectedTab == tabPurchase)
                SearchPurchase(term);
            else if (ts.SelectedTab == tabPictures)
                SearchPictures(term);
            else if (ts.SelectedTab == tabRMA)
                SearchRMA(term);
            else if (ts.SelectedTab == tabShipped)
                SearchShipped(term);
            else if (ts.SelectedTab == tabRzCommunity)
                SearchRzCommunity(term);
        }

        public List<SensibleDAL.dbml.partrecord> SearchPartsToList(string term, PartSearchParameters pp)
        {
            List<SensibleDAL.dbml.partrecord> pList = new List<SensibleDAL.dbml.partrecord>();
            List<partrecord> ret = new List<partrecord>();
            Dictionary<string, string> dictParameters = new Dictionary<string, string>();
            dictParameters.Add("SearchTerm", term);
            dictParameters.Add("boolIncludeAllocated", pp.IncludeAllocated.ToString());
            dictParameters.Add("boolIncludeStock", pp.IncludeStock.ToString());
            dictParameters.Add("boolIncludeConsign", pp.IncludeConsign.ToString());
            dictParameters.Add("boolIncludeExcess", pp.IncludeExcess.ToString());
            dictParameters.Add("boolIncludeOffers", pp.IncludeOffers.ToString());
            dictParameters.Add("TheComparison", pp.TheComparison.ToString());
            pList = SensibleDAL.PartLogic.SearchPartsToList(dictParameters);


            return pList;
        }


        protected virtual PartSearchParameters ParametersGet(String term)
        {
            PartSearchParameters pars = new PartSearchParameters(term);
            pars.SearchTerm = term;
            pars.IncludeAllocated = true;
            pars.IncludeStock = IncludeStock;
            pars.IncludeConsign = IncludeConsign;
            pars.IncludeExcess = IncludeExcess;
            pars.IncludeMaster = IncludeMaster;
            pars.IncludeOffers = IncludeOffers;
            pars.IncludeAlternatePart = true;
            //pars.ReplaceVisual = true;
            pars.IncludeUserDefined = false;
            pars.UnlimitedResults = Result_Parts.UnlimitedResults;
            pars.TheComparison = SearchComparison;
            if (optMfg.Checked)
                pars.TheTarget = PartSearchTarget.Manufacturer;
            else if (optDescription.Checked)
                pars.TheTarget = PartSearchTarget.Description;
            else
                pars.TheTarget = PartSearchTarget.Part;
            //KT Refactored from RzSensible - 4-23-2015
            if (chkOnlyThisComp.Checked)
            {
                pars.CompanyID = CompList.GetCompanyID();
                pars.CompanyName = CompList.GetCompanyName();
            }


            return pars;
        }
        //KT Refactored from RzSensible - 4-23-2015
        private void lblExtraCriteria_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (ts.SelectedTab == tabParts)
                Result_Parts.RunExtraSearch();
        }

        protected String CurrentTerm = "";
        protected virtual void SearchParts(String term)
        {
            CurrentTerm = term;
            ListArgs args = RzWin.Context.TheSysRz.ThePartLogic.PartSearchArgsGet(RzWin.Context, ParametersGet(term));
            CurrentPartWhere = args.TheWhere;
            SummaryClear();

            Result_Parts.Init(args);
        }

        void SearchQuotes(String term)
        {
            Result_Quotes.Init(RzWin.Context.TheSysRz.TheQuoteLogic.QuoteSearchArgsGet(RzWin.Context, QuoteSearchType, SearchComparison, ParametersGet(term), true));
        }

        void SearchSales(String term)
        {
            Result_Sales.Init(RzWin.Context.TheLogicRz.SalesSearchArgsGet(RzWin.Context, SearchComparison, ParametersGet(term)));
        }

        void SearchPurchase(String term)
        {
            Result_Purchase.Init(RzWin.Context.TheLogicRz.PurchaseSearchArgsGet(RzWin.Context, SearchComparison, ParametersGet(term)));
        }

        void SearchRMA(String term)
        {
            Result_RMA.Init(RzWin.Context.TheLogicRz.RMASearchArgsGet(RzWin.Context, RMASearchType, SearchComparison, ParametersGet(term)));
        }

        List<PicHandle> PicHandles;
        void SearchPictures(String term)
        {
            lvPictures.Items.Clear();
            if (!Tools.Strings.StrExt(term))
                return;

            if (bgPics.IsBusy)
                return;

            ilPics.Images.Clear();

            throbPics.Visible = true;
            throbPics.BringToFront();
            throbPics.Left = (lvPictures.Width / 2) - (throbPics.Width / 2);
            throbPics.Top = (lvPictures.Height / 2) - (throbPics.Height / 2);
            throbPics.ShowThrobber();

            PicTerm = term;

            if (PicHandles == null)
                PicHandles = new List<PicHandle>();
            else
                PicHandles.Clear();

            bgPics.RunWorkerAsync();
        }

        void SearchShipped(String term)
        {
            lvShipped.Init(RzWin.Context.TheSysRz.ThePartLogic.ShippedSearchArgsGet(RzWin.Context, ParametersGet(term)));
        }

        private void SearchRzCommunity(String term)
        {
            lvRzCommunity.Items.Clear();
            lvRzCommunity.SuspendLayout();
            try
            {

            }
            catch { }
            lvRzCommunity.ResumeLayout();
        }

        private void cmdQuote_Click(object sender, EventArgs e)
        {
            QuoteClicked();
        }

        protected virtual void QuoteClicked()
        {
            RzWin.Leader.ShowNewReqInDeal(RzWin.Context, txtPartNumber.Text, false, DoThrowReq(), CompList.GetCompanyID(), CompList.GetContactID(), GetSelectedPart());
        }

        private void cmdBid_Click(object sender, EventArgs e)
        {
            BidClicked();
        }
        protected virtual bool DoThrowReq()
        {
            return false;
        }
        protected virtual void BidClicked()
        {
            RzWin.Leader.ShowNewReqInDeal(RzWin.Context, txtPartNumber.Text, true, DoThrowReq(), CompList.GetCompanyID(), CompList.GetContactID(), GetSelectedPart());
        }

        public virtual SearchComparison SearchComparison
        {
            get
            {
                if (optFuzzy.Checked)
                    return SearchComparison.Fuzzy;
                else if (optExact.Checked)
                    return SearchComparison.Exact;
                else
                    return SearchComparison.Normal;
            }
        }

        public bool IncludeStock
        {
            get
            {
                return chkStock.Checked;
            }
        }

        public bool IncludeExcess
        {
            get
            {
                return chkExcess.Checked;
            }
        }

        public bool IncludeConsign
        {
            get
            {
                return chkConsign.Checked;
            }
        }

        //KT Include Master Parts:
        public bool IncludeMaster
        {
            get
            {
                return chkMaster.Checked;
            }
        }

        //KT Include Master Parts:
        public bool IncludeOffers
        {
            get
            {
                return chkOffers.Checked;
            }
        }

        private void lblRecent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowRecentSearches();
        }

        public virtual void SetPartFocus()
        {
            txtPartNumber.Focus();
        }

        public override void SetPartNumber(String strPart)
        {
            txtPartNumber.Text = strPart;
            txtPartNumber.Focus();
            txtPartNumber.SelectAll();
        }

        public void SetTabShipped()
        {
            ts.SelectedTab = tabShipped;
        }

        public void PartSearch_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        bool MasterVisible = false;
        public virtual void DoResize()
        {
            try
            {
                ts.Width = this.ClientRectangle.Width - (ts.Left * 2);
                ts.Height = this.ClientRectangle.Height - (ts.Top + 4);

                TabResize();

                TotalsResize();
            }
            catch { }
        }

        void TotalsResize()
        {
            lblStock.Left = 0;
            lblConsign.Left = lblStock.Right + 250;
            lblExcess.Left = lblConsign.Right + 250;
        }

        protected void TabResize()
        {
            try
            {
                int width = ts.SelectedTab.ClientRectangle.Width;
                int height = ts.SelectedTab.ClientRectangle.Height;

                Result_Parts.Left = 0;
                Result_Parts.Width = width;
                Result_Parts.Top = 0;
                Result_Parts.Height = height - pSummary.Height;

                Result_Quotes.Left = 0;
                Result_Quotes.Width = width;
                Result_Quotes.Height = height - Result_Quotes.Top;

                Result_RMA.Left = 0;
                Result_RMA.Width = width;
                Result_RMA.Height = height - Result_RMA.Top;

                pSummary.Left = 0;
                pSummary.Width = width;
                pSummary.Top = height - pSummary.Height;

                lvPictures.Left = 0;
                lvPictures.Top = 0;
                lvPictures.Width = tabPictures.ClientRectangle.Width;
                lvPictures.Height = tabPictures.ClientRectangle.Height;

                cmdPictureSwitch.Left = tabPictures.ClientRectangle.Width - (cmdPictureSwitch.Width + 40);
            }
            catch { }
        }

        public virtual PartSearchTarget SearchTarget
        {
            get
            {
                if (optMfg.Checked)
                    return PartSearchTarget.Manufacturer;
                else if (optDescription.Checked)
                    return PartSearchTarget.BoxNum;
                else
                    return PartSearchTarget.Part;
            }
        }

        public virtual PartSearchParameters Parameters
        {
            get
            {
                PartSearchParameters p = new PartSearchParameters(txtPartNumber.Text);
                p.TheComparison = this.SearchComparison;
                p.TheTarget = this.SearchTarget;
                return p;
            }
        }


        public virtual Rz5.Enums.PartSearchType QuoteSearchType
        {
            get
            {
                if (optGivingQuotes.Checked)
                    return Rz5.Enums.PartSearchType.Quotes_Giving;
                else if (optReceivingBids.Checked)
                    return Rz5.Enums.PartSearchType.Quotes_Receiving;
                else
                    return Rz5.Enums.PartSearchType.Quotes_All;
            }
        }

        public virtual Rz5.Enums.PartSearchType RMASearchType
        {
            get
            {
                if (optVendorRMA.Checked)
                    return Rz5.Enums.PartSearchType.VendRMA;
                else
                    return Rz5.Enums.PartSearchType.RMA;
            }
        }

        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ts_Changed();
        }

        protected virtual void ts_Changed()
        {
            TabChanged();

            if (ts.SelectedTab == tabPictures)
                DoResize();
        }

        bool suppressTabChange = false;
        void TabChanged()
        {
            TabVisCheck();
            Search();
        }

        void TabVisCheck()
        {
            if (ts.SelectedTab == tabParts)
            {
                chkStock.Visible = true;
                chkExcess.Visible = true;
                chkConsign.Visible = true;
                pAllocated.Visible = Tools.Strings.StrExt(txtPartNumber.Text);
            }
            else
            {
                chkStock.Visible = false;
                chkExcess.Visible = false;
                chkConsign.Visible = false;
                pAllocated.Visible = false;
            }
        }

        public Rz5.partrecord GetSelectedPart()
        {
            partrecord p = (partrecord)Result_Parts.GetSelectedObject();
            if (p == null)
                return null;

            String entered = Tools.Strings.FilterTrash(txtPartNumber.Text);
            if (!Tools.Strings.StrExt(entered))
                return p;

            String pr = "";
            String b = "";
            PartObject.ParsePartNumber(entered, ref pr, ref b);

            if (Tools.Strings.StrExt(pr))
            {
                if (!p.prefix.StartsWith(pr))
                    return null;
            }

            if (Tools.Strings.StrExt(b))
            {
                if (!p.basenumber.StartsWith(b))
                    return null;
            }

            return p;
        }

        public event ShowHandler AboutToThrow;

        public void CompleteLoad() { Init(); }

        public void SetTab(Rz5.Enums.PartSearchType type) { }

        public void SetCompany(Rz5.company c)
        {
            if (c == null)
                return;
            CompList.SetCompany(c.companyname, c.unique_id);
            pCompanyOptions.Visible = Tools.Strings.StrExt(CompList.GetCompanyID());
        }

        public void SetContact(companycontact c)
        {
            CompList.Clear();
            if (c == null)
                return;
            Rz5.company co = c.TheCompanyVar.RefGet(RzWin.Context);
            if (co == null)
            {
                RzWin.Leader.Tell("There is no company record linked to '" + c.contactname + ".  Please link this contact to a company record before continuing.");
                return;
            }
            CompList.SetCompany(co.companyname, co.unique_id, c.contactname, c.unique_id);
            pCompanyOptions.Visible = Tools.Strings.StrExt(CompList.GetCompanyID());
        }
        public void RunSearch(bool x) { Search(); }
        public void FocusOnBox() { txtPartNumber.Focus(); }
        public void SetReminder(String s) { }

        private void cmdSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        void SummaryClear()
        {
            lblStock.Visible = false;
            lblConsign.Visible = false;
            lblExcess.Visible = false;

            lblStock.Text = "";
            lblConsign.Text = "";
            lblExcess.Text = "";

            pAllocated.Visible = false;
        }

        private void chkIncludeSerials_Click(object sender, EventArgs e)
        {
            IncludeSerialsRefresh();
        }

        void IncludeSerialsRefresh()
        {
            SearchParts("");
        }

        String CurrentPartWhere = "";

        private void Result_Parts_FinishedFill(object sender)
        {
            try
            {
                int i = Result_Parts.CurrentTemplate.GetColumnIndexByProperty("condition");
                if (i == -1)
                    return;
                Result_Parts.BackColorByString(Color.Yellow, i, "SUSPECT");
            }
            catch { }
        }

        //int Allocated = 0;
        //private void bgSummary_DoWork(object sender, DoWorkEventArgs e)
        //{            
        //    Stock = new SummaryTotal("STOCK", "'STOCK'", CurrentPartWhere);
        //    Consign = new SummaryTotal("CONSIGNED", "'CONSIGN', 'CONSIGNED'", CurrentPartWhere);
        //    Excess = new SummaryTotal("EXCESS", "'EXCESS'", CurrentPartWhere);

        //    if (Tools.Strings.StrExt(CurrentTerm))
        //        Allocated = RzWin.Context.SelectScalarInt32(RzWin.Context.TheSysRz.ThePartLogic.AllocatedCountSql(RzWin.Context, CurrentTerm));
        //    else
        //        Allocated = 0;
        //}

        //private void bgSummary_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    ConditionLabel(lblStock, Stock);
        //    ConditionLabel(lblConsign, Consign);
        //    ConditionLabel(lblExcess, Excess);

        //    TotalsResize();

        //    int total = Stock.Total + Consign.Total;
        //    if (total == 0 || Allocated == 0)
        //    {
        //        pAllocated.Visible = false;
        //        return;
        //    }

        //    lblTotal.Text = Tools.Number.LongFormat(total);
        //    lblAlloc.Text = Tools.Number.LongFormat(Allocated);
        //    lblAvail.Text = Tools.Number.LongFormat(total - Allocated);

        //    pAllocated.Visible = true;            
        //}



        void ConditionLabel(Label l, SummaryTotal t)
        {
            if (t.Total == 0)
            {
                l.Visible = false;
            }
            else
            {
                l.Visible = true;
                String text = t.Caption + ": " + Tools.Number.LongFormat(t.Total);

                if (t.SNA > 0)
                    text += "  SNA: " + Tools.Number.LongFormat(t.SNA);

                if (t.RDC > 0)
                    text += "  RDC: " + Tools.Number.LongFormat(t.RDC);

                if (t.BZE > 0)
                    text += "  BZE: " + Tools.Number.LongFormat(t.SNA);

                l.Text = text;

            }
        }

        SummaryTotal Stock;
        SummaryTotal Consign;
        SummaryTotal Excess;

        private void lvPictures_DoubleClick(object sender, EventArgs e)
        {
            PictureOpen();
        }

        partpicture PictureSelectedGet()
        {
            try
            {
                return (partpicture)lvPictures.SelectedItems[0].Tag;
            }
            catch { return null; }
        }

        String PicTerm = "";
        private void bgPics_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ListArgs args = RzWin.Context.TheLogicRz.AttachmentSearchArgsGet(RzWin.Context, SearchComparison, PicTerm);
                args.TheLimit = 100;

                //ArrayList pics = DataSql.QtC(RzWin.Context, "partpicture", args.RenderSql(RzWin.Context, true), RzWin.Logic.PictureData);
                //KT PAssing "true" to RenderSQL
                ArrayList pics = DataSql.QtC(RzWin.Context, "partpicture", args.RenderSql(RzWin.Context, true), RzWin.Logic.PictureData);


                foreach (partpicture p in pics)
                {
                    Image pic = p.GetImage(RzWin.Context, 128, 128);
                    if (pic != null)
                    {
                        PicHandle h = new PicHandle();
                        h.ThePicture = p;
                        h.TheImage = pic;
                        PicHandles.Add(h);
                    }
                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
        }

        private void bgPics_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowPics();
            throbPics.HideThrobber();
            throbPics.Visible = false;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            partpicture p = PictureSelectedGet();
            if (p == null)
                return;

            String file = p.SaveDataToTempFile(RzWin.Context);
            Tools.FileSystem.Shell(file);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PictureOpen();
        }

        void PictureOpen()
        {
            try
            {
                partpicture p = PictureSelectedGet();
                if (p == null)
                    return;

                frmPartPictureViewer v = new frmPartPictureViewer();
                v.CompleteLoad();
                v.LoadViewByExactPic(p);

                v.Show();
            }
            catch { }
        }

        private void emailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            partpicture p = PictureSelectedGet();
            if (p == null)
                return;

            String file = p.SaveDataToTempFile(RzWin.Context);

            String err = "";
            //ToolsOffice.OutlookOffice.SendOutlookMessage("", "", "", false, true, "", file, false, null, "", "", "", "", ref err);
            //context.TheSysRz.TheEmailLogic.SendOutlookEmail(strAddress, strHeader + strFooter, strSubject, false, true, "", AttachmentFileString, false, null, strBCC, strFromAddress, "", context.xUser.email_signature, true, ref err);

        }

        private void Result_Sales_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            RzWin.Context.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Sales));
        }

        private void Result_Purchase_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            RzWin.Context.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.Purchase));
        }

        private void Result_RMA_AboutToThrow(Context x, ShowArgs args)
        {
            args.Handled = true;
            if (optVendorRMA.Checked)
                RzWin.Context.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.VendRMA));
            else
                RzWin.Context.Show(new ShowArgsOrder(x, args.TheItems, Rz5.Enums.OrderType.RMA));
        }

        private void lblAlloc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ts.SelectedTab = tabSales;
            Search();
        }

        private void cmdMultiSearch_Click(object sender, EventArgs e)
        {
            ActArgs args = new ActArgs();
            RzWin.Context.TheSysRz.ThePartLogic.MultiSearchShow(RzWin.Context, txtPartNumber.Text);
        }

        protected void TabChangeNoSearch(TabPage t)
        {
            suppressTabChange = true;
            try
            {
                ts.SelectedTab = t;
            }
            catch { }
            suppressTabChange = false;
        }

        private void cmdQuotes_Click(object sender, EventArgs e)
        {
            String companyId = this.CompList.GetCompanyID();
            if (!Tools.Strings.StrExt(companyId))
                return;

            TabChangeNoSearch(tabQuotes);
            Result_Quotes.Init(RzWin.Context.TheSysRz.TheQuoteLogic.QuoteSearchArgsGetCompany(RzWin.Context, companyId, this.CompList.GetContactID()));
        }

        private void cmdSales_Click(object sender, EventArgs e)
        {
            String companyId = this.CompList.GetCompanyID();
            if (!Tools.Strings.StrExt(companyId))
                return;

            TabChangeNoSearch(tabSales);
            Result_Sales.Init(RzWin.Context.TheSysRz.TheSalesLogic.SalesSearchArgsGetCompany(RzWin.Context, companyId, this.CompList.GetContactID()));
        }

        private void cmdPurchases_Click(object sender, EventArgs e)
        {
            String companyId = this.CompList.GetCompanyID();
            if (!Tools.Strings.StrExt(companyId))
                return;

            TabChangeNoSearch(tabPurchase);
            Result_Purchase.Init(RzWin.Context.TheSysRz.TheSalesLogic.PurchaseSearchArgsGetCompany(RzWin.Context, companyId, this.CompList.GetContactID()));
        }

        private void CompList_ClearCompany(GenericEvent e)
        {
            pCompanyOptions.Visible = false;
        }

        private void CompList_ClearContact(GenericEvent e)
        {
            pCompanyOptions.Visible = Tools.Strings.StrExt(CompList.GetCompanyID());
        }

        private void mnuEmail_Click(object sender, EventArgs e)
        {
            //Email Community Selection
        }

        private void cmdPictureSwitch_Click(object sender, EventArgs e)
        {
            PictureViewSwitch();
        }

        bool pictureViewMode = true;
        void PictureViewSwitch()
        {
            pictureViewMode = !pictureViewMode;
            ShowPics();
        }

        void ShowPics()
        {
            lvPictures.Items.Clear();
            lvPictures.BeginUpdate();

            if (pictureViewMode)
            {
                lvPictures.View = View.Tile;

                try
                {
                    foreach (PicHandle h in PicHandles)
                    {
                        ListViewItem i = lvPictures.Items.Add(h.ThePicture.ToString());
                        ilPics.Images.Add(h.ThePicture.unique_id, h.TheImage);
                        i.ImageKey = h.ThePicture.unique_id;
                        i.Tag = h.ThePicture;
                    }
                }
                catch { }

            }
            else
            {
                lvPictures.View = View.Details;
                lvPictures.Columns.Clear();

                ColumnHeader hd = lvPictures.Columns.Add("Part #");
                hd.Width = 150;

                hd = lvPictures.Columns.Add("Order");
                hd.Width = 150;

                hd = lvPictures.Columns.Add("Date Created");
                hd.Width = 150;

                hd = lvPictures.Columns.Add("Description");
                hd.Width = lvPictures.Width - 650;



                try
                {
                    foreach (PicHandle h in PicHandles)
                    {
                        ListViewItem i = lvPictures.Items.Add(h.ThePicture.fullpartnumber);
                        i.SubItems.Add(h.ThePicture.order_caption);
                        i.SubItems.Add(h.ThePicture.date_created.ToShortDateString());
                        i.SubItems.Add(h.ThePicture.description);
                        i.Tag = h.ThePicture;
                    }
                }
                catch { }
            }

            lvPictures.EndUpdate();
        }
    }

    class PicHandle
    {
        public partpicture ThePicture;
        public Image TheImage;
    }

    class SummaryTotal
    {
        public String Caption;
        public int Total;
        public int SNA;
        public int RDC;
        public int BZE;


        public SummaryTotal(String caption, String vals, String where)
        {
            Caption = caption;
            if (Tools.Strings.HasString(where, "basenumberstripped like '%'"))
            {
                Total = 0;
                SNA = 0;
                RDC = 0;
                BZE = 0;
            }
            else
            {
                Total = RzWin.Context.SelectScalarInt32("select sum(isnull(quantity, 0)) from partrecord where ( " + where + " ) and isnull(stocktype, '') in ( " + vals + " )");
                SNA = RzWin.Context.SelectScalarInt32("select sum(isnull(quantity, 0)) from partrecord where ( " + where + " ) and isnull(stocktype, '') in ( " + vals + " ) and location = 'SNA'");
                RDC = RzWin.Context.SelectScalarInt32("select sum(isnull(quantity, 0)) from partrecord where ( " + where + " ) and isnull(stocktype, '') in ( " + vals + " ) and location = 'RDC'");
                BZE = RzWin.Context.SelectScalarInt32("select sum(isnull(quantity, 0)) from partrecord where ( " + where + " ) and isnull(stocktype, '') in ( " + vals + " ) and location = 'BZE'");
            }
        }
    }
}
