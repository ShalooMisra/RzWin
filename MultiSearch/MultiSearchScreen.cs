using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using NewMethod;
using Rz5;

namespace MultiSearch
{
    public partial class MultiSearchScreen : UserControl
    {
        //Private Delegate
        private delegate void HandleNewTab(TabPage p);
        private delegate void HandleLoadRecentParts();
        private delegate void SearchFinishedHandler();
        //Public Variables
        public ArrayList AllSearches;
        public bool LoggedIn = false;
        public DateTime LastSearch;
        public ArrayList SearchThreads;
        public Search CurrentSearch;
        public Thread CurrentSearchThread;
        public Int32 SearchIndex;
        public bool EEMing = false;
        public bool BFing = false;
        public String ConnectionString = "";
        public String UserID = "";
        public String UserName = "";
        public String ServerName = "";
        public String ContactID = "";
        //Private Variables
        private bool bMoved = false;
        private multisearch_login xLogin;
        private Stack PartNumbers = new Stack();
        private Stack colPartNumbers = new Stack();
        private IMSDataProvider msData;

        //Constructors
        public MultiSearchScreen()
        {
            StopAutoSearching();
            InitializeComponent();
            DoResize();
        }
        //Public Functions
        public void CompleteLoad(IMSDataProvider d)
        {
            msData = d;
            if (!msData.IsStandAlone)
                RzWin.Context.Execute("create table multisearch_log(unique_id varchar(255), search_date datetime, partnumber varchar(255), site_name varchar(255), user_id varchar(255), user_name varchar(255))", true);
            LoadSearches();
            PartNumbers = msData.CachePartNumbers();
            LoadRecentPartsThread();
        }
        public void DoRunSearch()
        {
            try
            {
                StopAutoSearching();
                LoggedIn = true;
                RunSearch();
            }
            catch (Exception)
            { }
        }
        public void SavePartNumbers()
        {
            if (colPartNumbers == null)
                return;
            String strPart;
            String strDate;
            foreach (String x in colPartNumbers)
            {
                if (Tools.Strings.HasString(x, "><"))
                {
                    strPart = Tools.Strings.ParseDelimit(x, "><", 1).Trim();
                    strDate = Tools.Strings.ParseDelimit(x, "><", 2).Trim();
                    RzWin.Context.Execute("insert into multisearch_log(user_id, partnumber, search_date) values ('" + RzWin.User.unique_id + "', '" + RzWin.Context.Filter(strPart) + "', '" + strDate + "')");
                    PartNumbers.Push(x.Replace("><", "<>"));
                }
            }
            colPartNumbers = new Stack();
        }
        public void LoadRecentPartsThread()
        {
            HandleLoadRecentParts d = new HandleLoadRecentParts(LoadRecentParts);
            if (this.InvokeRequired)
                this.Invoke(d);
            else
                LoadRecentParts();
        }
        public void LoadRecentParts()
        {
            txtPartNumber.Items.Clear();
            if (colPartNumbers != null)
            {
                foreach (String s in colPartNumbers)
                {
                    String j = Tools.Strings.ParseDelimit(s, "<", 1).Replace(">", "").Trim();
                    try { txtPartNumber.Items.Add(j); }
                    catch { }
                }
            }
            foreach (String s in PartNumbers)
            {
                String j = Tools.Strings.ParseDelimit(s, "<", 1).Replace(">", "").Trim();
                try { txtPartNumber.Items.Add(j); }
                catch { }
            }
        }
        public void LoadSearches()
        {
            try
            {
                AllSearches = new ArrayList();
                SearchThreads = new ArrayList();
                SearchIndex = 0;
                Program.SkipData = true;
                ts.TabPages.Clear();
                ts.SuspendLayout();
                ts.Visible = false;
                try
                {
                    //if (msData.IsAAT)
                    //    ts.Multiline = false;
                    //if (msData.IsNasco)
                    //{
                    //    AddSearch((Search)new Search_BrokerForum(msData));
                    //    AddSearch((Search)new Search_NetComponents(msData));
                    //    AddSearch((Search)new Search_OEMsTrade(msData));
                    //    AddSearch((Search)new Search_Arrow(msData));
                    //    AddSearch((Search)new Search_Avnet(msData));
                    //    AddSearch((Search)new Search_FindChips(msData));
                    //    AddSearch((Search)new Search_StockingDistributors(msData));
                    //    AddSearch(GetGenericSearch("AllDataSheet.com", "www.alldatasheet.com", "sSearchword", "Search", "", false));
                    //    AddSearch(GetGenericSearch("Analog", "www.analog.com", "queryText", "", "home/home_go.gif|/header/go.gif", false));
                    //    AddSearch(GetGenericSearch("DigChip", "www.digchip.com/datasheets/search.php", "pn", "Search", "", true));
                    //    AddSearch(GetGenericSearch("Max-IC", "www.max-ic.com", "q", "Search", "", true));
                    //    AddSearch(GetGenericSearch("Nasco", "www.nasstock.com/partSearch.htm", "FullPartNo", "Search", "", true));
                    //    AddSearch(GetGenericSearch("DataSheet4U", "www.datasheet4u.com", "sWord", " Search ", "", false));
                    //    AddSearch(GetGenericSearch("ChipDocs", "www.chipdocs.com", "keyword", "Search Datasheets", "", true));
                    //    AddSearch((Search)new Search_ClickOnStock(msData));
                    //    AddSearch((Search)new Search_SourceESB(msData));
                    //    AddSearch((Search)new Search_PartsBase(msData));
                    //    AddSearch((Search)new Search_Spoerle(msData));
                    //    AddSearch((Search)new Search_TTI(msData));
                    //    AddSearch((Search)new Search_Octopart(msData));
                    //    AddSearch((Search)new Search_Sascoholz(msData));
                    //    AddSearch((Search)new Search_SupplyView(msData));
                    //}
                    //else
                    //{
                        if (!LoadUserSearches())
                        {
                            AddSearch((Search)new Search_BrokerForum(msData));
                            AddSearch((Search)new Search_NetComponents(msData));
                            AddSearch((Search)new Search_ChipSource(msData));
                            AddSearch((Search)new Search_SourceESB(msData));
                            AddSearch((Search)new Search_Avnet(msData));
                            AddSearch((Search)new Search_FindChips(msData));
                            AddSearch((Search)new Search_OEMsTrade(msData));
                            AddSearch((Search)new Search_PartsBase(msData));
                            AddSearch((Search)new Search_EEM(msData));
                            AddSearch((Search)new Search_Google(msData));
                            AddSearch((Search)new Search_EBV(msData));
                            AddSearch((Search)new Search_Spoerle(msData));
                            AddSearch((Search)new Search_TTI(msData));
                            AddSearch((Search)new Search_Microdis(msData));
                            AddSearch((Search)new Search_ICSource(msData));
                            if (msData.IsForte)
                            {
                                AddSearch((Search)new Shipping_FedEx(msData));
                                AddSearch((Search)new Shipping_UPS(msData));
                            }
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_EChips(msData));
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_EChips_Franchise(msData));
                            AddSearch((Search)new Search_GovLiquidation(msData));
                            AddSearch((Search)new Search_Arrow(msData));
                            AddSearch(msData.GetILSSearch(msData));
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_PartMiner(msData));
                            AddSearch((Search)new Search_Newark(msData));
                            AddSearch((Search)new Search_Powell(msData));
                            AddSearch((Search)new Search_OnlineComponents(msData));
                            AddSearch((Search)new Search_Allied(msData));
                            AddSearch((Search)new Search_Mouser(msData));
                            AddSearch((Search)new Search_Future(msData));
                            AddSearch((Search)new Search_DigiKey(msData));
                            AddSearch((Search)new Search_Heilind(msData));
                            AddSearch((Search)new Search_ICBin(msData));
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_HongKong(msData));
                            AddSearch((Search)new Search_Farnell(msData));
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_AmericanMicrosemi(msData));
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_BrokerBin(msData));
                            if (msData.IsForte)
                            {
                                AddSearch((Search)new Shipping_FedEx(msData));
                                AddSearch((Search)new Shipping_UPS(msData));
                            }
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_TelecomFinders(msData));
                            if (!msData.IsCTG)
                                AddSearch((Search)new Search_PriceLynx(msData));
                            //if (msData.IsAAT)
                            //{
                            //    AddSearch((Search)new Search_Honeywell(msData));
                            //    AddSearch((Search)new Search_ERAI(msData));
                            //    AddSearch((Search)new Search_Satair(msData));
                            //    AddSearch((Search)new Search_Synnex(msData));
                            //    AddSearch((Search)new Search_APLS(msData));
                            //    AddSearch((Search)new Search_ChinaICMart(msData));
                            //    AddSearch((Search)new Search_SMWeb(msData));
                            //    AddSearch((Search)new Search_TelExplorer(msData));
                            //    AddSearch((Search)new Search_BrokerNet(msData));
                            //    AddSearch((Search)new Search_Octopart(msData));
                            //    AddSearch((Search)new Search_Wencor(msData));
                            //    AddSearch((Search)new Search_Oneaero(msData));
                            //}
                            //if (msData.IsPipeline)
                            //    AddSearch((Search)new Search_StockingDistributors(msData));
                            //if (msData.IsArrowtronics)
                            //{
                            //    AddSearch((Search)new Search_PartsLogistics(msData));
                            //    AddSearch((Search)new Search_Parthunter(msData));
                            //}
                        }
                    //}
                    Search extra = msData.GetExtraSearch(msData);
                    if (extra != null)
                        AddSearch(extra);
                }
                catch { }
                ts.Visible = true;
                ts.ResumeLayout();
                ts.PerformLayout();
                SetCurrentSearch(0);
                tmrStatus.Start();
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell("Error loading searches: " + ex.Message);
            }
            DoResize();
            //just init the first site
            Search s = CurrentSearch;
            Thread t = new Thread(new ParameterizedThreadStart(InitWebsiteThread));
            t.Start(new SearchRequest(s, ""));
        }
        public void RunSearch()
        {
            try
            {
                if (txtPartNumber.Text.Length < 3)
                    return;
                if (CurrentSearch == null)
                    return;
                ArrayList searches;
                if (chkSearchAll.GetValue_Boolean())
                {
                    searches = new ArrayList();
                    searches.Add(CurrentSearch);
                    foreach (Search s in AllSearches)
                    {
                        if (!searches.Contains(s))
                            searches.Add(s);
                    }
                    foreach (Search s in searches)
                    {
                        if (!s.IsInitialized)
                            s.InitWebsite();
                        RunSearchThread(new SearchRequest(s, txtPartNumber.Text));
                    }
                }
                else
                {
                    KillSearchThread();
                    msData.SavePartSearch(ts.SelectedTab.Text, txtPartNumber.Text);
                    CurrentSearch.BeforeSearch(txtPartNumber.Text);
                    RunSearchThread(new SearchRequest(CurrentSearch, txtPartNumber.Text));
                }
            }
            catch { }
        }
        public void CancelSearches()
        {
            try
            {
                if (CurrentSearch != null)
                    CurrentSearch.Cancelled = true;
            }
            catch
            {

            }
        }
        public void KillSearchThread()
        {
            try
            {
                if (CurrentSearchThread != null)
                {
                    CurrentSearchThread.Abort();
                    CurrentSearchThread = null;
                }
            }
            catch { }
        }
        public Search GetSearchByName(String name)
        {
            foreach (Search s in AllSearches)
            {
                if (Tools.Strings.StrCmp(s.WebsiteName, name))
                    return s;
            }
            return null;

        }
        public void BFTest()
        {
            try
            {
                Search_BrokerForum b = (Search_BrokerForum)GetSearchByName("BrokerForum");
                if (!b.GoToVendorSearch())
                {
                    Program.SetStatus("Unable to go to the vendor search");
                    return;
                }

                b.SearchOneVendorNumber("4sta8500", "111");
            }
            catch (Exception)
            { }
        }
        public void RunEEM(bool ignoretime)
        {
            try
            {
                if (EEMing)
                {
                    Program.SetStatus("EEM is already running.");
                    return;
                }

                TimeSpan t = System.DateTime.Now.Subtract(LastSearch);

                if (t.Hours > 1 || ignoretime)
                {
                    Search.ShouldStopAutoSearching = false;
                    Thread th = new Thread(new ThreadStart(RunEEMThread));
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            catch (Exception)
            { }
        }
        public void StopAutoSearching()
        {
            if (Program.IgnoreActivity)
                return;
            try
            {
                LastSearch = System.DateTime.Now;
                Search.ShouldStopAutoSearching = true;
                lblLast.Text = LastSearch.ToString("t");
            }
            catch { }
        }
        public void CheckNextStock()
        {
            try
            {
                Search s = GetNextStockSearch();
                if (s == null)
                {
                    Program.SetStatus("No tabs are ready to search.");
                    return;
                }

                //do the search
                Thread t = new Thread(new ParameterizedThreadStart(RunSearchThread));
                t.SetApartmentState(ApartmentState.STA);
                t.Start(new SearchRequest(s, "2460199", true));

                //RunSearchThread(new SearchRequest(s, "2460199", true));
            }
            catch (Exception)
            { }
        }
        public void RunBrokerForum(bool ignoretime)
        {
            try
            {
                if (BFing)
                {
                    Program.SetStatus("BrokerForum is already running.");
                    return;
                }

                TimeSpan t = System.DateTime.Now.Subtract(LastSearch);

                if (t.Hours > 1 || ignoretime)
                {
                    Search.ShouldStopAutoSearching = false;
                    Thread th = new Thread(new ThreadStart(RunBFThread));
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            catch (Exception)
            { }
        }
        public void SetPartNumber(String strPart)
        {
            txtPartNumber.Text = strPart;
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                ts.Left = 0;
                ts.Width = this.ClientRectangle.Width;
                ts.Height = this.ClientRectangle.Height - ts.Top;
            }
            catch (Exception)
            { }
        }
        private Search GetGenericSearch(String strCaption, String strSite, String strTextBox, String strSearchButton, String strButtonImage, bool bNavFirst)
        {
            Search_Generic s = new Search_Generic(msData);
            s.CompleteLoad(strCaption, strSite, strTextBox, strSearchButton, strButtonImage, bNavFirst);
            return s;
        }
        private Search GetSearchFromString(String sIn)
        {
            switch (sIn.ToLower())
            {
                case "brokerforum":
                    return (Search)new Search_BrokerForum(msData);
                case "netcomponents":
                    return (Search)new Search_NetComponents(msData);
                case "chipsource":
                    return (Search)new Search_ChipSource(msData);
                case "sourceesb":
                    return (Search)new Search_SourceESB(msData);
                case "avnet":
                    return (Search)new Search_Avnet(msData);
                case "findchips":
                    return (Search)new Search_FindChips(msData);
                case "oemstrade":
                    return (Search)new Search_OEMsTrade(msData);
                case "partsbase":
                    return (Search)new Search_PartsBase(msData);
                case "eem":
                    return (Search)new Search_EEM(msData);
                case "google":
                    return (Search)new Search_Google(msData);
                case "ebv":
                    return (Search)new Search_EBV(msData);
                case "spoerle":
                    return (Search)new Search_Spoerle(msData);
                case "tti":
                    return (Search)new Search_TTI(msData);
                case "microdis":
                    return (Search)new Search_Microdis(msData);
                case "icsource":
                    return (Search)new Search_ICSource(msData);
                case "echips":
                    return (Search)new Search_EChips(msData);
                case "echips_franchise":
                    return (Search)new Search_EChips_Franchise(msData);
                case "govliquidation":
                    return (Search)new Search_GovLiquidation(msData);
                case "govliquidation_mfg":
                    return (Search)new Search_GovLiquidation_Mfg(msData);
                case "arrow":
                    return (Search)new Search_Arrow(msData);
                case "ils":
                    return msData.GetILSSearch(msData);
                case "partminer":
                    return (Search)new Search_PartMiner(msData);
                case "newark":
                    return (Search)new Search_Newark(msData);
                case "powell":
                    return (Search)new Search_Powell(msData);
                case "onlinecomponents":
                    return (Search)new Search_OnlineComponents(msData);
                case "allied":
                    return (Search)new Search_Allied(msData);
                case "mouser":
                    return (Search)new Search_Mouser(msData);
                case "future":
                    return (Search)new Search_Future(msData);
                case "digikey":
                    return (Search)new Search_DigiKey(msData);
                case "heilind":
                    return (Search)new Search_Heilind(msData);
                case "hongkong":
                    return (Search)new Search_HongKong(msData);
                //case "avnettime":
                //    return (Search)new Search_AvnetTime();
                case "farnell":
                    return (Search)new Search_Farnell(msData);
                case "americanmicrosemi":
                    return (Search)new Search_AmericanMicrosemi(msData);
                case "honeywell":
                    return (Search)new Search_Honeywell(msData);
                case "erai":
                    return (Search)new Search_ERAI(msData);
                case "satair":
                    return (Search)new Search_Satair(msData);
                case "synnex":
                    return (Search)new Search_Synnex(msData);
                case "apls":
                    return (Search)new Search_APLS(msData);
                //case "dibbs":
                //    return (Search)new Search_Dibbs();
                case "chinaicmart":
                    return (Search)new Search_ChinaICMart(msData);
                case "smweb":
                    return (Search)new Search_SMWeb(msData);
                case "telexplorer":
                    return (Search)new Search_TelExplorer(msData);
                case "brokernet":
                    return (Search)new Search_BrokerNet(msData);
                case "brokerbin":
                    return (Search)new Search_BrokerBin(msData);
                case "icbin":
                    return (Search)new Search_ICBin(msData);
                case "telecomfinders":
                    return (Search)new Search_TelecomFinders(msData);
                case "octopart":
                    return (Search)new Search_Octopart(msData);
                case "pricelynx":
                    return (Search)new Search_PriceLynx(msData);
                case "stockingdistributors":
                    return (Search)new Search_StockingDistributors(msData);
                case "parthunter":
                    return (Search)new Search_Parthunter(msData);
                case "partslogistics":
                    return (Search)new Search_PartsLogistics(msData);
                case "clickonstock":
                    return (Search)new Search_ClickOnStock(msData);
                case "wencor":
                    return (Search)new Search_Wencor(msData);
                case "oneaero":
                    return (Search)new Search_Oneaero(msData);
                case "hawker":
                    return (Search)new Search_Hawker(msData);
                case "ups":
                    return (Search)new Shipping_UPS(msData);
                case "fedex":
                    return (Search)new Shipping_FedEx(msData);
                default:
                    return null;
            }
        }
        private DataTable GetUserSites(Boolean with_uid)
        {
            return RzWin.Context.Select("select " + (String)(with_uid ? "unique_id,is_hidden, " : "") + "website from multisearch_siteorder where the_n_user_uid = '" + RzWin.User.unique_id + "' " + (String)(with_uid ? "" : " and isnull(is_hidden,0) = 0 ") + " order by loadorder");
        }
        private Boolean LoadUserSearches()
        {
            try
            {
                ts.TabPages.Clear();
                Dictionary<string, multisearch_siteorder> d = msData.GetUserSites();
                if (d == null)
                    return false;
                if (d.Count <= 0)
                    return false;
                foreach (KeyValuePair<string, multisearch_siteorder> kvp in d)
                {
                    if (kvp.Value == null)
                        continue;
                    multisearch_siteorder m = (multisearch_siteorder)kvp.Value;
                    if (m.is_hidden)
                        continue;
                    AddSearch(GetSearchFromString(kvp.Value.website));
                }
                return true;
            }
            catch 
            { return false; }
        }
        private void MoveListViewItem(ListView LV, Boolean bUp)
        {
            try
            {
                String strHold;
                String strName;
                String strTag;
                Int32 iIndex;
                if (LV.SelectedItems.Count > 1 || LV.SelectedItems.Count <= 0)
                    return;
                iIndex = LV.SelectedItems[0].Index;
                if (bUp)
                {
                    if (iIndex == 0)
                    {
                        LV.Refresh();
                        LV.Focus();
                        return;
                    }
                    for (int i = 0; i < LV.Items[iIndex].SubItems.Count; i++)
                    {
                        strHold = LV.Items[iIndex - 1].SubItems[i].Text;
                        strName = LV.Items[iIndex - 1].SubItems[i].Name;
                        strTag = LV.Items[iIndex - 1].Tag.ToString();
                        LV.Items[iIndex - 1].SubItems[i].Text = LV.Items[iIndex].SubItems[i].Text;
                        LV.Items[iIndex - 1].SubItems[i].Name = LV.Items[iIndex].SubItems[i].Name;
                        LV.Items[iIndex - 1].Tag = LV.Items[iIndex].Tag.ToString();
                        LV.Items[iIndex].SubItems[i].Text = strHold;
                        LV.Items[iIndex].SubItems[i].Name = strName;
                        LV.Items[iIndex].Tag = strTag;
                        LV.Items[iIndex].Selected = false;
                    }
                    LV.Items[iIndex - 1].Selected = true;
                }
                else
                {
                    if (iIndex == LV.Items.Count - 1)
                    {
                        LV.Refresh();
                        LV.Focus();
                        return;
                    }
                    for (int i = 0; i < LV.Items[iIndex].SubItems.Count; i++)
                    {
                        strHold = LV.Items[iIndex + 1].SubItems[i].Text;
                        strName = LV.Items[iIndex + 1].SubItems[i].Name;
                        strTag = LV.Items[iIndex + 1].Tag.ToString();
                        LV.Items[iIndex + 1].SubItems[i].Text = LV.Items[iIndex].SubItems[i].Text;
                        LV.Items[iIndex + 1].SubItems[i].Name = LV.Items[iIndex].SubItems[i].Name;
                        LV.Items[iIndex + 1].Tag = LV.Items[iIndex].Tag.ToString();
                        LV.Items[iIndex].SubItems[i].Text = strHold;
                        LV.Items[iIndex].SubItems[i].Name = strName;
                        LV.Items[iIndex].Tag = strTag;
                        LV.Items[iIndex].Selected = false;
                    }
                    LV.Items[iIndex + 1].Selected = true;
                }
                LV.Refresh();
                LV.Focus();
            }
            catch (Exception ee)
            { }
        }
        private void ReWriteOrder()
        {
            msData.ReWriteOrder(lvSiteOrder);
        }
        private void SetCurrentSearch(int index)
        {
            try
            {
                Search s;
                for (int i = 0; i < AllSearches.Count; i++)
                {
                    s = (Search)AllSearches[i];

                    if (i == ts.SelectedIndex)
                    {
                        CurrentSearch = s;
                        return;
                    }
                }
            }
            catch (Exception)
            { }
        }
        private void AddSearch(Search s)
        {
            if (s == null)
                return;
            try
            {
                SearchIndex++;
                AllSearches.Add(s);
                TabPage p;
                p = new TabPage(s.ToString());
                p.Tag = s.WebsiteName;
                s.Dock = DockStyle.Fill;
                p.Controls.Add(s);
                ts.TabPages.Add(p);
                s.MyTab = p;
                s.AutoSearchCheck();
                s.SetStatusIconTimer();
            }
            catch { }
        }
        private void AddStatusTab()
        {
            try
            {
                TabPage p = new TabPage("Status");
                p.ImageKey = "ready";
                Program.xStatus = new StatusScreen();
                Program.xStatus.Dock = DockStyle.Fill;
                p.Controls.Add(Program.xStatus);
                ts.TabPages.Add(p);
            }
            catch { }
        }
        private void InitWebsiteThread(Object x)
        {
            try
            {
                SearchRequest r = (SearchRequest)x;
                r.xSearch.InitWebsite();
            }
            catch { }
        }
        private void NewTabHandler(TabPage p)
        {
            try
            {
                ts.TabPages.Add(p);
            }
            catch { }
        }
        private void CheckAddPartNumber(String strPart)
        {
            if (colPartNumbers == null)
                return;
            foreach (String st in colPartNumbers)
            {
                if (Tools.Strings.HasString(st, strPart))
                    return;
            }
            foreach (String st in PartNumbers)
            {
                if (Tools.Strings.HasString(st, strPart))
                    return;
            }
            colPartNumbers.Push(strPart + " >< " + DateTime.Now.ToString());
            LoadRecentPartsThread();
        }
        private void RunSearchThread(Object x)
        {
            try
            {
                SearchRequest r = (SearchRequest)x;
                if (r.xSearch == null)
                    return;

                if (r.boolCheck)
                {
                    if (Tools.Strings.StrCmp(r.xSearch.ToString(), "ils"))
                        r.xSearch.RunSearch(r.strPart + "-", false);
                    else
                        r.xSearch.RunSearch(r.strPart, false);

                    r.xSearch.WaitForDone();
                    r.xSearch.WaitForDone();
                    r.xSearch.CheckStockDate();
                    r.xSearch.LastStockCheck = System.DateTime.Now;
                }
                else
                {
                    r.xSearch.RunSearch(r.strPart, false);
                }
                //SaveSearchHit(txtPartNumber.Text, GetSelectedCaption());
                CheckAddPartNumber(r.strPart);
                SavePartNumbers();

                Invoke(new SearchFinishedHandler(SearchFinished));

            }
            catch (Exception)
            { }
        }
        private void SearchFinished()
        {
            CurrentSearch.AfterSearch();
        }
        private void SetTabStatus()
        {
            try
            {
                Int32 c = -1;
                foreach (Search s in AllSearches)
                {
                    if (s.IsBusy)
                    {
                        c = s.BWIndex;
                        if (c > 0)
                        {
                            if (s.MyTab.ImageIndex != c)
                                s.MyTab.ImageIndex = c;
                        }
                    }
                    else
                    {
                        c = s.ColorIndex;
                        if (c > 0)
                        {
                            if (s.MyTab.ImageIndex != c)
                                s.MyTab.ImageIndex = c;
                        }
                    }
                }
            }
            catch (Exception)
            { }
            //try
            //{
            //    foreach (Search s in AllSearches)
            //    {
            //        if (s.IsBusy)
            //            s.MyTab.ImageIndex = 1;
            //        else
            //            s.SetStatusIcon();
            //    }
            //}
            //catch { }
        }
        private void LoadPart()
        {
            try
            {

                String s = Tools.Files.OpenFileAsString(Tools.OperatingSystem.GetAppPathFile("multisearch.txt"));

                if (s.Length > 2)
                {
                    try
                    {
                        String[] ary = s.Split("|".ToCharArray());
                        s = ary[0];

                        if (s.Length > 2)
                        {
                            txtPartNumber.Text = s;
                            if (CurrentSearch != null)
                            {
                                if (CurrentSearch.IsAbleToSearch)
                                {
                                    RunSearch();
                                }
                            }
                            this.SetTopLevel(true);
                        }

                        //user id
                        UserID = ary[1];
                        //user name
                        UserName = ary[2];
                        //server name
                        ServerName = ary[3];

                        //BrokerSearchControl.Search.ServerName = ServerName;
                        //BrokerSearchControl.Search.userid = UserID;

                        //ContactID
                        if (ary.Length >= 5)
                        {
                            ContactID = ary[4];
                        }
                        else
                        {
                            ContactID = "";
                        }

                        //if (ContactID.Length > 0)
                        //{
                        //    LoadCompetition();
                        //}

                        //if (Tools.Strings.StrCmp(ServerName, "laptop06"))
                        //{

                        //    ConnectionString = String.Concat("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;UserId=sa;Password=rec0gnin;Initial Catalog=Rz3CTG;Data Source=laptop06");
                        //}
                        //else
                        //{
                        //    ConnectionString = String.Concat("Provider=SQLOLEDB.1;Persist Security Info=False;User ID=sa;Password=ctgsql13;Initial Catalog=Rz3;Data Source=caamano");
                        //}

                    }
                    catch (Exception ex)
                    {
                        UserID = "";
                        UserName = "";
                        ServerName = "";
                        ContactID = "";
                    }
                }
                else
                {
                    UserID = "test";
                    UserName = "test";
                    ServerName = "laptop06";
                    ContactID = "test";

                    ConnectionString = String.Concat("Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;UserId=sa;Password=rec0gnin;Initial Catalog=Rz3CTG;Data Source=laptop06");

                }
                Program.userid = UserID;
                if (System.IO.File.Exists(Tools.OperatingSystem.GetAppPathFile("multisearch.txt")))
                    System.IO.File.Delete(Tools.OperatingSystem.GetAppPathFile("multisearch.txt"));
            }
            catch (Exception)
            { }
        }
        private void ShowSettings()
        {
            if (gbSettings.Visible)
            {
                gbSettings.Visible = false;
                pic.Visible = false;
                if (bMoved)
                {
                    bMoved = false;
                    LoadSearches();
                }
            }
            else
            {
                optUser.Text = msData.UserName + " Info";
                gbSettings.Top = (this.ClientRectangle.Height / 2) - (gbSettings.Height / 2);
                gbSettings.Left = (this.ClientRectangle.Width / 2) - (gbSettings.Width / 2);
                gbSettings.Visible = true;

                //pic.SetStyle(ControlStyles.Opaque, false);
                pic.BackColor = Color.FromArgb(120, 255, 255, 255);
                pic.Visible = true;
                pic.Left = 0;
                pic.Top = 0;
                pic.Height = this.ClientRectangle.Height;
                pic.Width = this.ClientRectangle.Width;
                pic.BringToFront();
                gbSettings.BringToFront();

                LoadSiteSettings(0);
                SelectFirstSite();
            }
        }
        private void SelectFirstSite()
        {
            lvSiteOrder.SelectedItems.Clear();
            if (lvSiteOrder.Items.Count <= 0)
                return;
            lvSiteOrder.Items[0].Selected = true;
            LoadSelectedSiteInfo();
        }
        private void LoadSiteSettings(Int32 times)
        {
            try
            {
                Dictionary<string, multisearch_siteorder> dt = msData.GetUserSites();
                if (dt == null)
                {
                    if (times > 2)
                        return;
                    times++;
                    msData.LoadDefaultSites();
                    LoadSiteSettings(times);
                    return;
                }
                if (dt.Count <= 0)
                {
                    if (times > 2)
                        return;
                    times++;
                    msData.LoadDefaultSites();
                    LoadSiteSettings(times);
                    return;
                }
                Int32 i = 1;
                lvSiteOrder.Items.Clear();
                foreach (KeyValuePair<string, multisearch_siteorder> kvp in dt)
                {
                    ListViewItem xLst = lvSiteOrder.Items.Add(i.ToString(), 0);
                    xLst.Checked = (kvp.Value.is_hidden == false);
                    xLst.SubItems.Add(kvp.Value.website);
                    xLst.Name = kvp.Value.unique_id;
                    xLst.Tag = kvp.Value.unique_id;
                    i++;
                }
            }
            catch { }
        }
        private void RunBFThread()
        {
            try
            {
                int count = 0;
                BFing = true;
                Search_BrokerForum s;
                DataTable t;
                try
                {
                    s = (Search_BrokerForum)GetSearchByName("BrokerForum");
                    if (s == null)
                    {
                        BFing = false;
                        Program.SetStatus("The BF search couldn't be found.");
                        return;
                    }

                    if (!s.IsAbleToSearch)
                    {
                        if (s.GoToVendorSearch())
                        {
                            s.IsAbleToSearch = true;
                            Program.SetStatus("BrokerForum is now able to search");
                        }
                    }

                    if (!s.IsAbleToSearch)
                    {
                        Program.SetStatus("The BF search isn't able to search");
                        BFing = false;
                        return;
                    }

                    t = Program.xData.Select("select top 1 * from brokerforum_companies order by lastsearch");
                    if (t == null)
                    {
                        BFing = false;
                        Program.SetStatus("The BF search table couldn't be found.");
                        return;
                    }

                    if (t.Rows.Count <= 0)
                    {
                        BFing = false;
                        Program.SetStatus("The BF search table had no records.");
                        return;
                    }

                    DataRow r = t.Rows[0];

                    BFing = true;

                    int x = (int)r["last1"];
                    int y = (int)r["last2"];
                    int z = (int)r["last3"];

                    for (int l1 = x; l1 < 10; l1++)
                    {
                        for (int l2 = x; l2 < 10; l2++)
                        {
                            for (int l3 = x; l3 < 10; l3++)
                            {
                                String sn = l1.ToString() + l2.ToString() + l3.ToString();
                                s.SearchOneVendorNumber((String)r["companykey"], sn);

                                Program.xData.Execute("update brokerforum_companies set lastsearch = getdate(), last1 = " + l1.ToString() + ", last2 = " + l2.ToString() + ", last3 = " + l3.ToString() + " where companykey = '" + (String)r["companykey"] + "' ");

                                if (Search.ShouldStopAutoSearching)
                                {
                                    Program.SetStatus("Stopping BF Search.");
                                    BFing = false;
                                    return;
                                }

                                count++;
                                if (count > 5)
                                {
                                    Program.SetStatus("Stopping at 5 BF searches.");
                                    BFing = false;
                                    return;
                                }
                            }
                        }
                    }
                    Program.xData.Execute("update brokerforum_companies set lastsearch = getdate(), last1 = 0, last2 = 0, last3 = 0 ");
                }
                catch (Exception)
                {
                }

                BFing = false;
            }
            catch (Exception)
            { }
        }
        private Search GetNextStockSearch()
        {
            try
            {
                Search winner;
                DateTime d;

                d = System.DateTime.Now.Add(new TimeSpan(24, 0, 0));
                winner = null;

                foreach (Search s in AllSearches)
                {
                    if (s.DoCheckStockDate)
                    {
                        if (!s.IsAbleToSearch && !s.TriedForceSearch)
                        {
                            Program.SetStatus("Trying to search " + s.ToString() + "...");
                            s.RunSearch("test123", true);
                            s.WaitForDone();
                            s.TriedForceSearch = true;
                        }

                        if (s.IsAbleToSearch)
                        {
                            if (s.LastStockCheck < d)
                            {
                                winner = s;
                                d = s.LastStockCheck;
                            }
                        }
                    }
                }
                return winner;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private void RunEEMThread()
        {
            try
            {

                EEMing = true;
                Search_EEM s;
                DataTable t;
                try
                {
                    s = (Search_EEM)GetSearchByName("EEM");
                    if (s == null)
                    {
                        EEMing = false;
                        Program.SetStatus("The EEM search couldn't be found.");
                        return;
                    }

                    if (!s.IsAbleToSearch)
                    {
                        s.RunSearch("tst123", true);
                        EEMing = false;
                        s.WaitForDone();
                    }

                    if (!s.IsAbleToSearch)
                    {
                        Program.SetStatus("The EEM search isn't able to search");
                        EEMing = false;
                        return;
                    }

                    t = Program.xData.Select("select top 100 * from eem_search_keys order by last_search");
                    if (t == null)
                    {
                        EEMing = false;
                        Program.SetStatus("The EEM search couldn't be found.");
                        return;
                    }

                    EEMing = true;

                    String strPart;
                    String strID;
                    foreach (DataRow r in t.Rows)
                    {
                        strPart = (String)r["search_key"];
                        strID = (String)r["unique_id"];

                        Program.SetStatus("EEM Searching for " + strPart);
                        s.RunSearch(strPart, true);
                        s.WaitForDone();
                        Program.SetStatus("Scanning each EEM result...");
                        s.ScanEach();

                        //mark it as updated
                        Program.xData.Execute("update eem_search_keys set last_search = getdate() where unique_id = '" + strID + "'");

                        if (Search.ShouldStopAutoSearching)
                        {
                            Program.SetStatus("Stopping auto EEM search.");
                            EEMing = false;
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Program.SetStatus("Error in RunEEMThread: " + ex.Message);
                }

                EEMing = false;
            }
            catch (Exception)
            { }
        }
        private void ClearSiteInfo()
        {
            gbSite.Text = "Selected Website";
            ctl_username.SetValue("");
            ctl_password.SetValue("");
            ctl_extradata.SetValue("");
        }
        private void LoadSelectedSiteInfo()
        {
            try
            {
                if (lvSiteOrder.SelectedItems.Count <= 0)
                    return;
                multisearch_login login = null;
                switch (optUser.Checked)
                {
                    case true:
                        login = msData.GetLoginByName(false, lvSiteOrder.SelectedItems[0].SubItems[1].Text); //(multisearch_login)Rz3App.xSys.QtO("multisearch_login", "select * from multisearch_login where is_companyinfo = 0 and the_n_user_uid = '" + Rz3App.xUser.unique_id + "' and website = '" + lvSiteOrder.SelectedItems[0].SubItems[1].Text + "'");
                        break;
                    case false:
                        login = msData.GetLoginByName(true, lvSiteOrder.SelectedItems[0].SubItems[1].Text); //(multisearch_login)Rz3App.xSys.QtO("multisearch_login", "select * from multisearch_login where is_companyinfo = 1 and website = '" + lvSiteOrder.SelectedItems[0].SubItems[1].Text + "'");
                        break;
                }
                ClearSiteInfo();
                gbSite.Text = lvSiteOrder.SelectedItems[0].SubItems[1].Text;
                xLogin = login;
                SetLoginInfo();
            }
            catch (Exception ee)
            { }
        }
        private void SetLoginInfo()
        {
            if (xLogin == null)
                return;
            ctl_username.SetValue(xLogin.username);
            ctl_password.SetValue(xLogin.password);
            ctl_extradata.SetValue(xLogin.extradata);
            ctl_auto_search.SetValue(xLogin.auto_search);
        }
        private void DeleteLogin()
        {
            if (!RzWin.User.SuperUser && optCompany.Checked)
            {
                RzWin.Leader.Tell("Sorry but only superusers can delete company login information.");
                return;
            }
            if (xLogin == null)
                return;
            if (RzWin.Leader.AskYesNo("Are you sure you want to delete the login information for the website " + xLogin.website))
            {
                xLogin.Delete(RzWin.Context);
                LoadSelectedSiteInfo();
            }
        }
        //Buttons
        private void cmdSearch_Click(object sender, EventArgs e)
        {
            DoRunSearch();
        }
        private void cmdP_Click(object sender, EventArgs e)
        {
            //nTools.SaveClipboardToPicture("c:\\temp_gimp.bmp");
        }
        private void cmdStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentSearch == null)
                    return;

                //do the search
                Thread t = new Thread(new ParameterizedThreadStart(RunSearchThread));
                t.SetApartmentState(ApartmentState.STA);
                t.Start(new SearchRequest(CurrentSearch, "2460199", true));
            }
            catch (Exception)
            { }
        }
        private void cmdSettings_Click(object sender, EventArgs e)
        {
            ShowSettings();
        }
        private void cmdClose_Click(object sender, EventArgs e)
        {
            ShowSettings();
            LoadSearches();
        }
        private void cmdMoveUp_Click(object sender, EventArgs e)
        {
            bMoved = true;
            MoveListViewItem(lvSiteOrder, true);
            ReWriteOrder();
        }
        private void cmdMoveDown_Click(object sender, EventArgs e)
        {
            bMoved = true;
            MoveListViewItem(lvSiteOrder, false);
            ReWriteOrder();
        }
        private void cmdSaveLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!msData.SuperUser && optCompany.Checked)
                {
                    RzWin.Leader.Tell("Sorry but only superusers can save new company login information.");
                    return;
                }
                if (xLogin == null)
                {
                    xLogin = multisearch_login.New(RzWin.Context);
                    xLogin.is_companyinfo = optCompany.Checked;
                    if (!xLogin.is_companyinfo)
                        xLogin.the_n_user_uid = msData.UserID;

                    xLogin.website = gbSite.Text.ToLower().Trim();
                }
                xLogin.username = ctl_username.GetValue_String();
                xLogin.password = ctl_password.GetValue_String();
                xLogin.extradata = ctl_extradata.GetValue_String();
                xLogin.auto_search = ctl_auto_search.GetValue_Boolean();
                msData.SaveLogin(xLogin);
                Search s = GetSearchByName(xLogin.website);
                s.CheckEnableLogin();
                RzWin.Leader.Tell("Saved.");
            }
            catch (Exception ee)
            {
                RzWin.Leader.Tell("Error saving: " + ee.Message);
            }
        }
        private void cmdReload_Click(object sender, EventArgs e)
        {
            msData.LoadDefaultSites();
            bMoved = true;
            ShowSettings();
        }
        private void cmdDelete_Click(object sender, EventArgs e)
        {
            DeleteLogin();
        }
        //Control Events
        private void frmMultiSearch_Activated(object sender, EventArgs e)
        {
            try
            {
                LoadPart();
                StopAutoSearching();
            }
            catch (Exception)
            { }
        }
        private void frmMultiSearch_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void frmMultiSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            StopAutoSearching();
        }
        private void frmMultiSearch_MouseMove(object sender, MouseEventArgs e)
        {
            StopAutoSearching();
        }
        private void frmMultiSearch_Deactivate(object sender, EventArgs e)
        {
            StopAutoSearching();
        }
        private void ts_Click(object sender, EventArgs e)
        {
            SetCurrentSearch(ts.SelectedIndex);
        }
        private void ts_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (Convert.ToInt32(e.KeyChar))
            {
                case 10:
                    RunSearch();
                    e.Handled = true;
                    break;
                case 13:
                    RunSearch();
                    e.Handled = true;
                    break;
            }
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabChanged();


        }

        protected virtual void TabChanged()
        {
            //get the current search
            SetCurrentSearch(ts.SelectedIndex);

            if (!CurrentSearch.IsInitialized)
            {
                CurrentSearchInit();
            }
        }

        protected virtual void CurrentSearchInit()
        {
            CurrentSearch.InitWebsite();
            CurrentSearch.EnterLoginInfo();
        }

        private void ts_zz_TabMoved(TabPage p)
        {
            timer1.Stop();
            timer1.Interval = 10000;
            timer1.Start();
        }
        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            try
            {
                SetTabStatus();
                TimeSpan t = System.DateTime.Now.Subtract(LastSearch);
                lblTime.Text = t.Hours.ToString() + ":" + t.Minutes.ToString() + ":" + t.Seconds.ToString();
            }
            catch (Exception)
            { }
        }
        private void tmrStock_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Program.SkipData)
                    return;

                TimeSpan t = System.DateTime.Now.Subtract(LastSearch);
                if (t.Hours > 0)
                {
                    CheckNextStock();
                    StopAutoSearching();
                }
            }
            catch (Exception)
            { }
        }
        private void tmrEEM_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Program.SkipData)
                    return;

                RunEEM(false);
            }
            catch (Exception)
            { }
        }
        private void tmrBrokerForum_Tick(object sender, EventArgs e)
        {
            try
            {
                if (Program.SkipData)
                    return;

                RunBrokerForum(false);
            }
            catch (Exception)
            { }
        }
        private void txtPartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (Convert.ToInt32(e.KeyChar))
            {
                case 10:
                    RunSearch();
                    e.Handled = true;
                    break;
                case 13:
                    RunSearch();
                    e.Handled = true;
                    break;
            }
            char[] c = e.KeyChar.ToString().ToUpper().ToCharArray();
            e.KeyChar = c[0];
        }
        private void txtPartNumber_TextChanged(object sender, EventArgs e)
        {
            StopAutoSearching();
        }
        private void lblVersion_Click(object sender, EventArgs e)
        {

        }
        private void lvSiteOrder_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            LoadSelectedSiteInfo();
        }
        private void optUser_CheckedChanged(object sender, EventArgs e)
        {
            LoadSelectedSiteInfo();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            msData.ReWriteOrder(ts);            
        }
        private void lvSiteOrder_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag == null)
                return;
            string id = e.Item.Tag.ToString();
            if (!Tools.Strings.StrExt(id))
                return;
            msData.UpdateHiddenSite((e.Item.Checked == false), id);
        }
        private void chkCheckAll_CheckChanged(object sender)
        {
            try
            {
                foreach (ListViewItem xLst in lvSiteOrder.Items)
                {
                    xLst.Checked = chkCheckAll.zz_CheckValue;
                }
            }
            catch { }
        }
    }
    public class SearchRequest
    {
        public Search xSearch;
        public String strPart;
        public bool boolCheck;

        public SearchRequest(Search s, String p)
        {
            xSearch = s;
            strPart = p;
            boolCheck = false;
        }
        public SearchRequest(Search s, String p, bool b)
        {
            xSearch = s;
            strPart = p;
            boolCheck = b;
        }
    }
    public class MSData : IMSDataProvider
    {
        public bool IsForte
        {
            get
            {
                return RzWin.Logic.IsForte;
            }
        }
        public bool IsStandAlone
        {
            get { return false; }
        }
        //public bool IsAAT
        //{
        //    get
        //    {
        //        return Rz3App.xLogic.IsAAT;
        //    }
        //}
        //public bool IsNasco
        //{
        //    get
        //    {
        //        return Rz3App.xLogic.IsNasco;
        //    }
        //}
        //public bool IsVoxx
        //{
        //    get
        //    {
        //        return Rz3App.xLogic.IsVoxx;
        //    }
        //}
        public bool IsCTG
        {
            get
            {
                if (RzWin.Context != null)
                {
                    if (RzWin.Context.xSys != null)
                    {
                        return Tools.Strings.StrCmp(RzWin.Context.GetSetting("company_identifier"), "ctg");
                    }
                }
                return false;
            }
        }
        //public bool IsPipeline
        //{
        //    get
        //    {
        //        return Rz3App.xLogic.IsPipeline;
        //    }
        //}
        //public bool IsArrowtronics
        //{
        //    get
        //    {
        //        return Rz3App.xLogic.IsArrowtronics;
        //    }
        //}
        //public bool IsConcord
        //{
        //    get
        //    {
        //        return Rz3App.xLogic.IsConcord;
        //    }
        //}
        public string UserName
        {
            get
            {
                return RzWin.User.name;
            }
        }
        public string UserID
        {
            get
            {
                return RzWin.User.unique_id;
            }
        }
        public bool SuperUser
        {
            get
            {
                return RzWin.User.super_user;
            }
        }

        public Dictionary<string, multisearch_siteorder> GetUserSites()
        {
            Dictionary<string, multisearch_siteorder> d = new Dictionary<string, multisearch_siteorder>();
            ArrayList a = RzWin.Context.QtC("multisearch_siteorder", "select * from multisearch_siteorder where the_n_user_uid = '" + RzWin.User.unique_id + "' order by loadorder");
            foreach (multisearch_siteorder m in a)
            {
                try { d.Add(m.unique_id, m); }
                catch { }
            }
            return d;
        }
        public void SavePartSearch(string site, string partnumber)
        {
            RzWin.Context.Execute("insert into multisearch_log(unique_id, search_date, partnumber, site_name, user_id, user_name) values ('" + Tools.Strings.GetNewID() + "', getdate(), '" + RzWin.Context.Filter(partnumber) + "', '" + RzWin.Context.Filter(site) + "', '" + RzWin.Context.Filter(RzWin.User.unique_id) + "', '" + RzWin.Context.Filter(RzWin.User.name) + "')");
        }
        public Stack CachePartNumbers()
        {
            Stack PartNumbers = new Stack();
            ArrayList a = RzWin.Context.SelectScalarArray("select top 30 partnumber + ' <> ' + cast(search_date as varchar(255)) from multisearch_log where user_id = '" + RzWin.User.unique_id + "' order by search_date desc");
            for (int i = a.Count - 1; i >= 0; i--)
            {
                PartNumbers.Push(a[i]);
            }
            return PartNumbers;
        }
        public Search GetExtraSearch(IMSDataProvider d)
        {
            return RzWin.Leader.GetExtraSearch(d);
        }
        public MultiSearch.Search GetILSSearch(MultiSearch.IMSDataProvider d)
        {
            return new Search_ILS(d);  //ctg doesn't have a custom one anymore
        }
        //public void LoadNascoDefaultSites()
        //{
        //    try
        //    {
        //        Rz3App.RzWin.Context.Execute("delete from multisearch_siteorder where the_n_user_uid = '" + Rz3App.xUser.unique_id + "'");
        //        multisearch_siteorder m;
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "BrokerForum";
        //        m.loadorder = 1;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "NetComponents";
        //        m.loadorder = 2;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "ChipSource";
        //        m.loadorder = 3;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "ICSource";
        //        m.loadorder = 4;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "OEMsTrade";
        //        m.loadorder = 5;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "Arrow";
        //        m.loadorder = 6;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "Avnet";
        //        m.loadorder = 7;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "FindChips";
        //        m.loadorder = 8;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "EEM";
        //        m.loadorder = 9;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "StockingDistributors";
        //        m.loadorder = 10;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "AllDataSheet.com";
        //        m.loadorder = 11;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "Analog";
        //        m.loadorder = 12;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "DigChip";
        //        m.loadorder = 13;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "Max-IC";
        //        m.loadorder = 14;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "Nasco";
        //        m.loadorder = 15;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "DataSheet4U";
        //        m.loadorder = 16;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "ChipDocs";
        //        m.loadorder = 17;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //        m = new multisearch_siteorder(Rz3App.xSys);
        //        m.website = "ClickOnStock";
        //        m.loadorder = 18;
        //        m.the_n_user_uid = Rz3App.xUser.unique_id;
        //        m.Insert(RzWin.Context);
        //    }
        //    catch (Exception e)
        //    { }
        //}
        public void LoadDefaultSites()
        {
            try
            {
                //if (IsNasco)
                //{
                //    LoadNascoDefaultSites();
                //    return;
                //}
                RzWin.Context.Execute("delete from multisearch_siteorder where the_n_user_uid = '" + RzWin.User.unique_id + "'");
                multisearch_siteorder m;
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "BrokerForum";
                m.loadorder = 1;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "NetComponents";
                m.loadorder = 2;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "ChipSource";
                m.loadorder = 3;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "SourceESB";
                m.loadorder = 4;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Avnet";
                m.loadorder = 5;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "FindChips";
                m.loadorder = 6;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "OEMsTrade";
                m.loadorder = 7;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "PartsBase";
                m.loadorder = 8;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "EEM";
                m.loadorder = 9;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Google";
                m.loadorder = 10;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "EBV";
                m.loadorder = 11;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Spoerle";
                m.loadorder = 12;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "TTI";
                m.loadorder = 13;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Microdis";
                m.loadorder = 14;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "ICSource";
                m.loadorder = 15;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "EChips";
                m.loadorder = 16;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "EChips_Franchise";
                m.loadorder = 17;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "GovLiquidation";
                m.loadorder = 18;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "GovLiquidation_Mfg";
                m.loadorder = 19;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Arrow";
                m.loadorder = 20;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "ILS";
                m.loadorder = 21;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "PartMiner";
                m.loadorder = 22;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Newark";
                m.loadorder = 23;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Powell";
                m.loadorder = 24;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "OnlineComponents";
                m.loadorder = 25;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Allied";
                m.loadorder = 26;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Mouser";
                m.loadorder = 27;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Future";
                m.loadorder = 28;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "DigiKey";
                m.loadorder = 29;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Heilind";
                m.loadorder = 30;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "HongKong";
                m.loadorder = 31;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "AvnetTime";
                m.loadorder = 32;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "Farnell";
                m.loadorder = 33;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "AmericanMicrosemi";
                m.loadorder = 34;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "BrokerBin";
                m.loadorder = 35;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "TelecomFinders";
                m.loadorder = 36;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "PriceLynx";
                m.loadorder = 37;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                m = multisearch_siteorder.New(RzWin.Context);
                m.website = "ICBin";
                m.loadorder = 38;
                m.the_n_user_uid = RzWin.User.unique_id;
                m.Insert(RzWin.Context);
                if (IsForte)
                {
                    m = multisearch_siteorder.New(RzWin.Context);
                    m.website = "UPS";
                    m.loadorder = 39;
                    m.the_n_user_uid = RzWin.User.unique_id;
                    m.Insert(RzWin.Context);
                    m = multisearch_siteorder.New(RzWin.Context);
                    m.website = "FedEx";
                    m.loadorder = 40;
                    m.the_n_user_uid = RzWin.User.unique_id;
                    m.Insert(RzWin.Context);
                }
            }
            catch (Exception e)
            { }
        }
        public multisearch_siteorder GetSiteByID(string id)
        {
            return multisearch_siteorder.GetById(RzWin.Context, id);
        }
        public multisearch_siteorder GetSiteByName(string name)
        {
            return multisearch_siteorder.GetByName(RzWin.Context, name);
        }
        public multisearch_login GetLoginByName(bool company, string name)
        {
            if(!company)
                return (multisearch_login)RzWin.Context.QtO("multisearch_login", "select * from multisearch_login where the_n_user_uid = '" + UserID + "' and website = '" + name.ToLower() + "' and isnull(is_companyinfo, 0) = '0'");
            else
                return (multisearch_login)RzWin.Context.QtO("multisearch_login", "select * from multisearch_login where is_companyinfo = 1 and website = '" + name.ToLower() + "'");
        }
        public void ReWriteOrder(ListView l)
        {
            multisearch_siteorder cp;
            Int32 i = 1;
            foreach (ListViewItem lvi in l.Items)
            {
                cp = GetSiteByID(lvi.Name);
                if (cp == null)
                {
                    RzWin.Leader.Tell("Failed multisearch_siteorder Loading (" + lvi.Name + ")");
                    continue;
                }
                cp.loadorder = i;
                lvi.Text = i.ToString();
                cp.Update(RzWin.Context);
                i++;
            }
        }
        public void ReWriteOrder(TabControl ts)
        {
            multisearch_siteorder cp;
            Int32 i = 1;
            foreach (TabPage tp in ts.TabPages)
            {
                cp = multisearch_siteorder.GetByName(RzWin.Context, tp.Tag.ToString());
                if (cp == null)
                {
                    RzWin.Leader.Tell("Failed multisearch_siteorder Loading (" + tp.Text + ")");
                    continue;
                }
                cp.loadorder = i;
                cp.Update(RzWin.Context);
                i++;
            }
        }
        public void UpdateHiddenSite(bool hidden, string id)
        {
            if (!Tools.Strings.StrExt(id))
                return;
            multisearch_siteorder s = multisearch_siteorder.GetById(RzWin.Context, id);
            if (s == null)
                return;
            s.is_hidden = hidden;
            s.Update(RzWin.Context);
        }
        public bool HasAutoSearch(string website, bool company)
        {
            if (RzWin.Context.Data.StatementExists("select * from multisearch_login where the_n_user_uid = '" + RzWin.User.unique_id + "' and website = '" + website.ToLower() + "' and isnull(is_companyinfo, 0) = '0' and isnull(auto_search, 0) = 1"))
                return true;
            else if (RzWin.Context.Data.StatementExists("select * from multisearch_login where website = '" + website.ToLower() + "' and isnull(is_companyinfo, 0) = '1' and isnull(auto_search, 0) = 1"))
                return true;
            else
                return false;
        }
        public void SaveLogin(multisearch_login l)
        {
            if (l == null)
                return;
            l.Update(RzWin.Context);
        }
    }
    public interface IMSDataProvider
    {
        bool IsForte
        {
            get;
        }
        bool IsStandAlone
        {
            get;
        }
        //bool IsAAT
        //{
        //    get;
        //}
        //bool IsNasco
        //{
        //    get;
        //}
        //bool IsVoxx
        //{
        //    get;
        //}
        bool IsCTG
        {
            get;
        }
        //bool IsPipeline
        //{
        //    get;
        //}
        //bool IsArrowtronics
        //{
        //    get;
        //}
        //bool IsConcord
        //{
        //    get;
        //}
        string UserName
        {
            get;
        }
        string UserID
        {
            get;
        }
        bool SuperUser
        {
            get;
        }

        Dictionary<string, multisearch_siteorder> GetUserSites();
        void SavePartSearch(string site, string partnumber);
        Stack CachePartNumbers();
        Search GetExtraSearch(IMSDataProvider d);
        Search GetILSSearch(MultiSearch.IMSDataProvider d);
        void LoadDefaultSites();
        //void LoadNascoDefaultSites();
        multisearch_siteorder GetSiteByID(string id);
        multisearch_siteorder GetSiteByName(string name);
        multisearch_login GetLoginByName(bool company, string name);
        void ReWriteOrder(ListView l);
        void ReWriteOrder(TabControl ts);
        void UpdateHiddenSite(bool hidden, string id);
        bool HasAutoSearch(string website, bool company);
        void SaveLogin(multisearch_login l);
    }
}