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
    public partial class Search_ECCO : MultiSearch.Search
    {
        public Search_ECCO(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "ecco";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "ECCO"; 
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.eccochicago.com/ecco/parts_search/index.asp", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("PartNumber", strPartNumber))
			{
                if (ClickElement("input", "", "Submit", "Submit", "", wait, "/ecco/images/bt_go.gif"))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}