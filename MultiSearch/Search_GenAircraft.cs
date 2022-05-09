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
    public partial class Search_GenAircraft : MultiSearch.Search
    {
        public Search_GenAircraft(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "genaircraft";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "GenAircraft"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.gen-aircraft-hardware.com/newSearch.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("ProductNumber", strPartNumber))
			{
                if (ClickElement("input", "", "Search", "submit", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}