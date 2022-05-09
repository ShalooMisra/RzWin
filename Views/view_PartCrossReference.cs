using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class view_PartCrossReference : nView
    {
        //Protected Variables
        protected ContextNM TheContext;
        protected PartCrossReferenceSearchOptions SearchOptions;
        protected PartCrossReferenceResults SearchResults;

        //Constructor
        public view_PartCrossReference()
        {
            InitializeComponent();
        }
        public bool CompleteLoad(PartCrossReferenceSearchOptions p)
        {
            return CompleteLoad(RzWin.Form.TheContextNM, p);
        }
        public bool CompleteLoad(ContextNM x, PartCrossReferenceSearchOptions p)
        {
            if (x == null)
                return false;
            if (p == null)
                return false;
            if (!Tools.Strings.StrExt(p.SQL_Table))
                return false;
            if (!Tools.Strings.StrExt(p.SQL_PartField))
                return false;
            TheContext = x;
            SearchOptions = p;
            DoResize();
            LoadLV();
            return true;
        }
        //Public Functions
        public virtual void DoResize()
        {
            try
            {
                SetBorder();
                lv.Top = pbTop.Bottom + 3;
                lv.Left = pbLeft.Right + 3;
                pOptions.Left = lv.Left;
                pOptions.Top = (pbBottom.Top - pOptions.Height) - 3;
                lv.Height = (pOptions.Top - lv.Top) - 3;
                ts.Top = lv.Top;
                ts.Left = lv.Right + 3;
                ts.Height = (pbBottom.Top - ts.Top) - 3;
                ts.Width = (pbRight.Left - ts.Left) - 3;
                cmdSearch.Top = (pOptions.Height - cmdSearch.Height) - 3;
            }
            catch { }
        }
        //Protected Virtual Functions
        protected virtual void AssymbleOptions()
        {
            if (SearchOptions == null)
                return;
            SearchOptions.search_Bid = chkBid.Checked;
            SearchOptions.search_Consign = chkConsign.Checked;
            SearchOptions.search_Excess = chkExcess.Checked;
            SearchOptions.search_Invoice = chkInvoice.Checked;
            SearchOptions.search_Purchase = chkPurchase.Checked;
            SearchOptions.search_Quote = chkQuotes.Checked;
            SearchOptions.search_Req = chkReq.Checked;
            SearchOptions.search_RMA = chkRMA.Checked;
            SearchOptions.search_Sales = chkSales.Checked;
            SearchOptions.search_Service = chkService.Checked;
            SearchOptions.search_Stock = chkStock.Checked;
            SearchOptions.search_vRMA = chkVRMA.Checked;
            //KT Master
            SearchOptions.search_Master = chkMaster.Checked;
            //KT Refactored from RzSensible

            if (chkLowestSalesPrice.Checked)
            {
                SearchOptions.search_LowestSalesPrice = true;
                SearchOptions.search_LowestSalesPricePercent = GetPercentValue(txtLowestSalesPrice.Text);
                SearchOptions.search_LowestSalesPriceComparison = lblLowSales.Text;
            }
            if (chkAvgSalesPrice.Checked)
            {
                SearchOptions.search_AvgSalesPrice = true;
                SearchOptions.search_AvgSalesPricePercent = GetPercentValue(txtAvgSalesPrice.Text);
                SearchOptions.search_AvgSalesPriceComparison = lblAvgSales.Text;
            }
            if (chkLowestPurchasePrice.Checked)
            {
                SearchOptions.search_LowestPurchasePrice = true;
                SearchOptions.search_LowestPurchasePricePercent = GetPercentValue(txtLowestPurchasePrice.Text);
                SearchOptions.search_LowestPurchasePriceComparison = lblLowPurchase.Text;
            }
            if (chkAvgPurchasePrice.Checked)
            {
                SearchOptions.search_AvgPurchasePrice = true;
                SearchOptions.search_AvgPurchasePricePercent = GetPercentValue(txtAvgPurchasePrice.Text);
                SearchOptions.search_AvgPurchasePriceComparison = lblAvgPurchase.Text;
            }




        }
        //Protected Virtual Functions
        protected virtual void ShowResults()
        {
            ts.TabPages.Clear();
            if (SearchResults == null)
                return;
            if (SearchResults.results_Stock != null)
                ShowNewTab("Stock", SearchResults.results_Stock);
            if (SearchResults.results_Consign != null)
                ShowNewTab("Consigned", SearchResults.results_Consign);
            if (SearchResults.results_Excess != null)
                ShowNewTab("Excess", SearchResults.results_Excess);
            //KT
            if (SearchResults.results_Master != null)
                ShowNewTab("Master", SearchResults.results_Master);
            if (SearchResults.results_Req != null)
                ShowNewTab("Reqs", SearchResults.results_Req);
            if (SearchResults.results_Bid != null)
                ShowNewTab("Bids", SearchResults.results_Bid);
            if (SearchResults.results_Quote != null)
                ShowNewTab("Quotes", SearchResults.results_Quote);
            if (SearchResults.results_Sales != null)
                ShowNewTab("Sales", SearchResults.results_Sales);
            if (SearchResults.results_Invoice != null)
                ShowNewTab("Invoices", SearchResults.results_Invoice);
            if (SearchResults.results_Purchase != null)
                ShowNewTab("Purchases", SearchResults.results_Purchase);
            if (SearchResults.results_RMA != null)
                ShowNewTab("RMAs", SearchResults.results_RMA);
            if (SearchResults.results_vRMA != null)
                ShowNewTab("Vendor RMAs", SearchResults.results_vRMA);
            if (SearchResults.results_Service != null)
                ShowNewTab("Service", SearchResults.results_Service);

            //KT Refactored from RzSensible
            if (((PartCrossReferenceResults)SearchResults).results_LowestSalesPrice != null)
                ShowNewTab("Lowest Sales", ((PartCrossReferenceResults)SearchResults).results_LowestSalesPrice);
            if (((PartCrossReferenceResults)SearchResults).results_AvgSalesPrice != null)
                ShowNewTab("Avg Sales", ((PartCrossReferenceResults)SearchResults).results_AvgSalesPrice);
            if (((PartCrossReferenceResults)SearchResults).results_LowestPurchasePrice != null)
                ShowNewTab("Lowest Purchase", ((PartCrossReferenceResults)SearchResults).results_LowestPurchasePrice);
            if (((PartCrossReferenceResults)SearchResults).results_AvgPurchasePrice != null)
                ShowNewTab("Avg Purchase", ((PartCrossReferenceResults)SearchResults).results_AvgPurchasePrice);




        }
        protected virtual void ShowNewTab(string caption, ListArgs args)
        {
            if (args == null)
                return;
            //TabPage p = new TabPage(caption);
            //p.Tag = args;
            //nList n = new nList();
            //p.Controls.Add(n);
            //n.Dock = DockStyle.Fill;
            //ts.TabPages.Add(p);
            //n.ShowTemplate(args);
            //if (args.TheLimit == 0)
            //    args.TheLimit = 200;
            //n.ShowData(args);


            //KT Refactored from RzSensible
            TabPage p = new TabPage(caption);
            p.Tag = args;
            CrossReferenceResult r = new CrossReferenceResult();
            p.Controls.Add(r);
            r.Dock = DockStyle.Fill;
            ts.TabPages.Add(p);
            r.lv.ShowTemplate(args);
            if (args.TheLimit == 0)
                args.TheLimit = 200;
            r.lv.ShowData(args);
            r.wb.ReloadWB();
            r.wb.Add(((ListArgs)args).TheHTMLData);
        }
        //Private Functions
        //KT Refactored from RzSensible
        private double GetPercentValue(string val)
        {
            val = val.Replace(" ", "").Replace("%", "").Trim();
            if (!Tools.Number.IsNumeric(val))
                return 0;
            try
            {
                double d = Convert.ToDouble(val);
                return d;
            }
            catch { }
            return 0;
        }
        private string GetNextComparisonValue(string val)
        {
            switch (val)
            {
                case ">=":
                    return "=";
                case "=":
                    return "<=";
                case "<=":
                    return ">=";
                default:
                    return ">=";
            }
        }


        //KT End Refactor Block
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();
            }
            catch { }
        }
        private void DoSearch()
        {
            SearchResults = null;
            SearchResults = ((RzLogic)TheContext.TheLogic).PartCrossReferenceArgsGet(TheContext, SearchOptions);
        }
        private bool LoadLV()
        {
            lv.Items.Clear();
            lv.SuspendLayout();
            try
            {
                DataTable dt = RzWin.Context.Select(SearchOptions.SQL_String);
                foreach (DataRow dr in dt.Rows)
                {
                    lv.Items.Add(dr[SearchOptions.SQL_FieldCalledAs].ToString());
                }


                lv.ResumeLayout();
                return true;
            }
            catch { }
            lv.ResumeLayout();
            return false;
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy)
                return;
            AssymbleOptions();
            bgw.RunWorkerAsync();
        }
        //Control Events
        private void view_PartCrossReference_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        //KT Refactored from RzSensible
        private void chkLowestSalesPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLowestSalesPrice.Checked)
                txtLowestSalesPrice.Enabled = true;
            else
            {
                txtLowestSalesPrice.Enabled = false;
                txtLowestSalesPrice.Text = "";
            }
        }
        private void chkAvgSalesPrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAvgSalesPrice.Checked)
                txtAvgSalesPrice.Enabled = true;
            else
            {
                txtAvgSalesPrice.Enabled = false;
                txtAvgSalesPrice.Text = "";
            }
        }
        private void chkLowestPurchasePrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLowestPurchasePrice.Checked)
                txtLowestPurchasePrice.Enabled = true;
            else
            {
                txtLowestPurchasePrice.Enabled = false;
                txtLowestPurchasePrice.Text = "";
            }
        }
        private void chkAvgPurchasePrice_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAvgPurchasePrice.Checked)
                txtAvgPurchasePrice.Enabled = true;
            else
            {
                txtAvgPurchasePrice.Enabled = false;
                txtAvgPurchasePrice.Text = "";
            }
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            Label l;
            if (sender is Label)
            {
                l = (Label)sender;
                switch (l.Name)
                {
                    case "lblLowSales":
                        lblLowSales.Text = GetNextComparisonValue(lblLowSales.Text);
                        break;
                    case "lblAvgSales":
                        lblAvgSales.Text = GetNextComparisonValue(lblAvgSales.Text);
                        break;
                    case "lblLowPurchase":
                        lblLowPurchase.Text = GetNextComparisonValue(lblLowPurchase.Text);
                        break;
                    case "lblAvgPurchase":
                        lblAvgPurchase.Text = GetNextComparisonValue(lblAvgPurchase.Text);
                        break;
                    default:
                        break;
                }
            }
        }





        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            DoSearch();
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowResults();
        }
    }
}
