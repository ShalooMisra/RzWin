using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Google : MultiSearch.Search
    {
        //Constructors
        public Search_Google(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "google";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "Google"; }
        public override void InitWebsite()
        {
            Navigate("http://www.google.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://www.google.com/search?hl=en&q=" + strPartNumber, false);
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
            if (GetPageText(wb).ToLower().Contains("- did not match any documents"))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("about 0 results<nobr>"))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("results<nobr>"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

