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
    public partial class Search_AARDistribution : MultiSearch.Search
    {
        public Search_AARDistribution(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "aardistribution";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "AARDistribution"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("https://www.aardistribution.com/index.cfm", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("searchCriteria", strPartNumber))
			{
                if (ClickElement("img", "", "", "", "", wait, "images/5.gif"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}