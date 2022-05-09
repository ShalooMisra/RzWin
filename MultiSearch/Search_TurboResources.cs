using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_TurboResources : MultiSearch.Search
    {
        public Search_TurboResources(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "turboresources";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "TurboResources"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.turboresources.com/advanced_search.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("PartSearch", strPartNumber))
			{
                if (ClickElement("input", "", "", "search", "", wait, "images/go.gif", "Click here to search", ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}