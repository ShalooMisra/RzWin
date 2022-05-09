using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Powell : MultiSearch.Search
    {
        //Constructors
        public Search_Powell(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "powell";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "Powell";
        }
        public override void InitWebsite()
        {
            Navigate("http://www.powell.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            if (SetTextBox("KeyWord", strPartNumber))
            {
                if (ClickElement("img", " FIND ", "", "", "", wait, "images/search_button.gif"))
                    IsAbleToSearch = true;
            }
            else
            {
                SetStatusIconTimer(StatusIcon.Error);
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
            if (GetPageHTML(wb).ToLower().Contains("showing 1"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("enter additional part numbers in the comments field."))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

