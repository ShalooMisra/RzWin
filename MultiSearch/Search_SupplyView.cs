using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace MultiSearch
{
    public partial class Search_SupplyView : MultiSearch.Search
    {
        //Constructors
        public Search_SupplyView(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "supplyview";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        {
            return "SupplyView"; 
        }
        public override void InitWebsite()
        {
            DoEnableLogin(true);
            Navigate("http://www.supplyview.com/member-br.php3", false);
            UserName_Name = "lognm";
            Password_Name = "pw";
            LoginTag = "input";
            LoginType = "submit";
            LoginValue = "Login";
            LoginName = "B1";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("MemberName", ""))
                Navigate("www.brokerforum.com/bf?/TRADINGCENTER/MENU", true);
            if (SetTextBox("SearchCriteria_originalFullPartNumber", strPartNumber))
			{
                if (ClickElement("input", "", "Search", "", "", wait,""))
                {
                    IsAbleToSearch = true;
                }
                else
                    SetStatusIconTimer(StatusIcon.Error);
			}
            FinishedSearch();
        }
    }
}
