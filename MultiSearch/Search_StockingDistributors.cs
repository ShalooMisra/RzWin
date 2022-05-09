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
    public partial class Search_StockingDistributors : MultiSearch.Search
    {
        public Search_StockingDistributors(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = false;
            WebsiteName = "stockingdistributors";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "StockingDistributors"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.stockingdistributors.com/", false);
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("search", strPartNumber))
			{
                if (ClickElement("input", "", "", "", "", wait, "images/btnSearch.jpg"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}
