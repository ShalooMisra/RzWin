using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_ILS : MultiSearch.Search
    {
        //Constructors
        public Search_ILS(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            DoCheckStockDate = true;
            ShowLogin = true;
            WebsiteName = "ils";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        { 
            return "ILS"; 
        }
        public override void InitWebsite()
        {
            try
            {
                Navigate("http://www.ilsmart.com/", false);
            }
            catch (Exception ex)
            {
                ;
            }
            
            UserName_Name = "username";
            Password_Name = "password";
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickElement("input", "", "ENTER", "enter", "", true, "images/btn_log_in_white.gif");
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            //if (ClickElement("img", "", "", "", "", wait, "/images/buttons/btnNewSearch80x20.gif"))
            //    WaitForDone();
            if (SetTextBox("oPartSearchPanelControl:rptrEnterNumbers:_ctl1:txtPartNumber", strPartNumber))
			{
                if (ClickElement("input", "", "", "oPartSearchPanelControl:cmdSearch", "", wait, "", "", ""))
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

