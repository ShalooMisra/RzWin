using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Avnet : MultiSearch.Search
    {
        //Constructors
        public Search_Avnet(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "avnet";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString(){return "Avnet";}
        public override void InitWebsite()
		{
			Navigate("http://www.em.avnet.com/", false);
            UserName_Name = "uid";
            Password_Name = "pwd";
            base.InitWebsite(); 
		}
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickLink("", "", "&lid=BannerLogin", "", true, "javascript:document.BannerLogin.submit();");
        }
        public override void RunSearch(String strPartNumber, bool wait)
		{
			base.RunSearch(strPartNumber, wait);
            if (SetTextBox("fldPartSearch", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "/images/common/headers/hdr_go_btn.gif"))
                    IsAbleToSearch = true;
            }
            else if (SetTextBox("term", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "/wcsstore/emstore/images/button-search.gif"))
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
            if (GetPageHTML(wb).ToLower().Contains("no results were found."))
                key = StatusIcon.NoResults;
            else if (GetPageHTML(wb).ToLower().Contains("total results:"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

