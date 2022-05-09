using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_OEMsTrade : MultiSearch.Search
    {
        //Constructors
        public Search_OEMsTrade(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            WebsiteName = "oemstrade";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "OEMsTrade"; }
        public override void InitWebsite()
        {
            Navigate("http://www.oemstrade.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            
            if( SetTextBox("searchText", strPartNumber) )
			{
				if( ClickButton("", "Go", "", "", wait) )
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
            if (GetPageHTML(wb).ToLower().Contains("http://www.oemstrade.com/images/status_yes.gif"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.NoResults;
            base.SetStatusIconTimer(key);
        }
    }
}

