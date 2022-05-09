using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_FindChips : MultiSearch.Search
    {
        //Constructors
        public Search_FindChips(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            WebsiteName = "findchips";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "FindChips"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.findchips.com/", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("part", strPartNumber))
            {
                if (ClickButton("", "", "FIND", "", true))
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
            if (GetPageHTML(wb).ToLower().Contains("class=yesmatch"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("class=nomatch"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

