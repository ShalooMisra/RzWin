using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_OnlineComponents : MultiSearch.Search
    {
        //Constructors
        public Search_OnlineComponents(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "onlinecomponents";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "OnlineComponents"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.onlinecomponents.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("Part_Number", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "images/search_button2.gif"))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("searchText", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "/images/btn_search_red.png"))
                    IsAbleToSearch = true;
                else if (ClickElement("input", "", "", "", "", wait, "/images/redGo_OnBlue.gif"))
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
            if (GetPageHTML(wb).ToLower().Contains("items that match your search criteria."))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Replace(" ","").Replace("\"","").Trim().Contains("value=sendrequest"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("returned no results"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

