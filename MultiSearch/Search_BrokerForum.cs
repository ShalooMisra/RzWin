using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_BrokerForum : MultiSearch.Search
    {
        delegate void HandleShowCheckBoxes();

        public Search_BrokerForum(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            SavePageData = true;
            ShowLogin = true;
            ShowPostButtons = true;
            WebsiteName = "brokerforum";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "BrokerForum"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.brokerforum.com/", false);
            UserName_Name = "Session_Username";
            Password_Name = "Session_Password";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "image";
            LoginSrc = "/tbf/img/login-button-small-en.png";
        }
        public override void DocumentReallyComplete()
        {
            if (IsInitialized && !IsAbleToSearch)
            {
                int z;
                if (ClickLink("Trading Center", "", "", "", false, ""))
                    z = 0;
            }

            base.DocumentReallyComplete();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("MemberName", ""))
                Navigate("www.brokerforum.com/bf?/TRADINGCENTER/MENU", true);
            if (SetTextBox("SearchCriteria_originalFullPartNumber", strPartNumber))
			{
                if (ClickElement("input", "", "Search", "", "", wait,""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
        public override void NavToPost(String type)
        {
            switch (type.ToLower())
            {
                case "offers":
                    wb.Navigate("http://www.brokerforum.com/cgi/en/posting.addOemExcessOffers.prep");
                    break;
                case "rfqs":
                    wb.Navigate("http://www.brokerforum.com/cgi/en/posting.addRequirements.prep");
                    break;
            }
        }
        public override void CheckAllBoxes()
        {
            try
            {
                HtmlDocument xDoc = wb.Document;
                HtmlElement body = xDoc.Body;
                HtmlElementCollection col = body.All;
                IEnumerator en = col.GetEnumerator();
                mshtml.IHTMLInputElement inp;
                mshtml.IHTMLElement ele;
                mshtml.IHTMLOptionButtonElement c;
                while (en.MoveNext())
                {
                    ele = (mshtml.IHTMLElement)(en.Current);
                    if (String.Compare(ele.tagName.ToLower(), "input") == 0)
                    {
                        inp = (mshtml.IHTMLInputElement)(ele);
                        if (Tools.Strings.StrCmp(inp.type, "checkbox"))
                        {
                            if (Tools.Strings.HasString(inp.name.ToLower(), "ck"))
                            {
                                c = (mshtml.IHTMLOptionButtonElement)(ele);
                                c.@checked = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ee)
            { }
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).Replace("\"", "").ToLower().Contains("name=ck00"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).Replace("\"", "").ToLower().Contains("class=noitemsfoundtitle"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
        //Public Functions
        public bool GoToVendorSearch()
        {
            Navigate("www.brokerforum.com/bfparts2?/VENDOR_SEARCH/PREP", true);
            WaitForDone();
            return SetTextBox("MemberName", "");
        }
        public void SearchOneVendorNumber(String strVendor, String strNumber)
        {
            if (!SetTextBox("MemberName", strVendor))
            {
                Program.SetStatus("Couldn't set MemberName");
                return;
            }

            if (!SetTextBox("FullPartNo", strNumber))
            {
                Program.SetStatus("Couldn't set FullPartNo");
                return;
            }

            if (!ClickElement("input", "", "Search", "", "", false,""))
            {
                Program.SetStatus("Couldn't click 'Search'");
                return;
            }

            Program.SetStatus("Searching " + strVendor + " for " + strNumber);
            WaitForDone();

            while (ClickLink("next page", "", "", "", false, ""))
            {
                WaitForDone();
                if (Search.ShouldStopAutoSearching)
                {
                    Program.SetStatus("Stopping BF next page.");
                    return;
                }
                Program.SetStatus("Clicking next on BF...");
            }
        }
        public void ShowCheckBoxesThread()
        {
            HandleShowCheckBoxes d = new HandleShowCheckBoxes(ShowCheckBoxes);
            if (this.InvokeRequired)
                this.Invoke(d);
            else
                ShowCheckBoxes();
        }
        public void ShowCheckBoxes()
        {
            cmdCheckBoxes.Visible = true;
        }
    }
}

