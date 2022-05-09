using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Newark : MultiSearch.Search
    {
        //Constructors
        public Search_Newark(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "newark";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "Newark"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.newark.com", false);
            UserName_Name = "msglogin";
            Password_Name = "password";
            base.InitWebsite();
        }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickElement("input", "", "login", "submitlogin", "", true, "/images/en_UK/btn_login_flat.gif");
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("searchTerms", strPartNumber))
			{
                if (ClickElement("input", "", "", "/pf/search/TextSearchFormHandler.search", "", true, "/images/en_US/btn_go.gif", "Go", ""))
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
            if (GetPageHTML(wb).ToLower().Contains(">0 </span>product results found for"))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("product results found for"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("minimum order quantity:"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

