using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_AmericanMicrosemi : MultiSearch.Search
    {
        //Constructors
        public Search_AmericanMicrosemi(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "americanmicrosemi";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "AmerMicro."; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.americanmicrosemi.com/products/search/", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("partnumber", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "http://www.americanmicrosemi.com/images/thanksgiving_search_button.jpg"))
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
            if (GetPageHTML(wb).ToLower().Contains("please contact our courteous sales department for your:"))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("request a quote"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

