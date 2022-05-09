using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Allied : MultiSearch.Search
    {
        //Constructors
        public Search_Allied(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "allied";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Allied"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.alliedelec.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("ctl00$txtSearch", strPartNumber))
            {
                if (ClickElement("input", "", "", "ctl00$btnSearch", "ctl00_btnSearch", false, "/Images/btn_search.png"))
                    IsAbleToSearch = true;
            }
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("no results found for"))
                key = StatusIcon.NoResults;            
            else if (GetPageHTML(wb).ToLower().Contains("results found for"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

