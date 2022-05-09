using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Heilind : MultiSearch.Search
    {
        //Constructors
        public Search_Heilind(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "heilind";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Heilind"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.heilind.com/", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            //if( SetTextBox("search", strPartNumber) )
            if (SetTextBox("p", strPartNumber))
            {
                //if( ClickElement("input", "", "", "", "", wait, "/images/common/buttons/butpartsearch.gif") )
                if (ClickElement("input", "", " go ", "", "", wait, ""))
                {
                    IsAbleToSearch = true;
                }
                else
                {
                    if (ClickElement("input", "", "Search", "", "", wait, ""))
                        IsAbleToSearch = true;
                }
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
            if (GetPageHTML(wb).ToLower().Contains("no matches were found"))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("click on manufacturer part number to view part detail."))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

