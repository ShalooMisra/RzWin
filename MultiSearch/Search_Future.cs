using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Future : MultiSearch.Search
    {
        //Constructors
        public Search_Future(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "future";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Future"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.futureelectronics.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("keyword", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", false, "http://www.futureelectronics.com/images/button_blue_search.gif"))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("ucLeftNav:txtPartSearch", strPartNumber))
            {
                if (ClickElement("input", "", "", "ucLeftNav:imgBtnFind", "", false,""))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("ctl00$pageHeader$QuickSearch$txtSearch", strPartNumber))
            {
                if (ClickElement("a", "", "", "", "ctl00_pageHeader_QuickSearch_btnSearchByPartNumber", false, "", "", "javascript:__doPostBack('ctl00$pageHeader$QuickSearch$btnSearchByPartNumber','')"))
                    IsAbleToSearch = true;
            }
            else
                SetStatusIconTimer(StatusIcon.Error);
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("&nbsp;results found for"))
            {
                string h = Tools.Strings.ParseDelimit(GetPageHTML(wb).ToLower(), "<h3 class=results>", 2).Trim();
                h = Tools.Strings.ParseDelimit(h, "&nbsp;", 1).Trim();
                if (!Tools.Number.IsNumeric(h))
                    key = StatusIcon.Error;//?
                else
                {
                    int i = 0;
                    try { i = Convert.ToInt32(h); }
                    catch { }
                    if (i <= 0)
                        key = StatusIcon.NoResults;
                    else
                        key = StatusIcon.Results;
                }
            }
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

