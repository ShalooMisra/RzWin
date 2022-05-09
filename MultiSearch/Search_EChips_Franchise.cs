using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_EChips_Franchise : MultiSearch.Search
    {
        //Constructors
        public Search_EChips_Franchise(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "echips_franchise";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "EChips <F>"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.echipsonline.com/logon.asp", false);
            UserName_Name = "userName";
            Password_Name = "passWord";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "submit";
            LoginValue = "Logon";
            base.InitWebsite();
        }
        public override void DocumentReallyComplete()
        {
            if (IsInitialized && !IsAbleToSearch)
            {
                int z;
                if (ClickElement("IMG", "", "", "", "", false, "/media/images/ico-search-0.gif"))
                    z = 0;
            }
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            Navigate("http://www.echipsonline.com/searchfranchise.asp", true);

            bool y = false;
            SetCheckBox("searchFranchise"); 
            if (SetTextBox("PartNum", strPartNumber))
            {
				if( !ClickElement("input", "", "", "Submit2", "Submit1", wait, "") )
                    SetStatusIconTimer(StatusIcon.Error);
                else
                {
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
            if (GetPageHTML(wb).ToLower().Contains("X"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("X"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

