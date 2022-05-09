using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_EBV : MultiSearch.Search
    {
        //Constructors
        public Search_EBV(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "ebv";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "EBV"; }
        public override void InitWebsite()
        {
            Navigate("http://www.ebv.com/en/", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            SetTextBox("tx_indexedsearch[sword]", strPartNumber);
            ClickElement("input", "", "", "", "", true, "fileadmin/templates/images/search/searchstart.jpg", "Start Search", "");
            IsAbleToSearch = true;
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("the price shown is valid only for values starting at"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("no results found"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

