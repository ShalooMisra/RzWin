using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace MultiSearch
{
    public partial class Search_Farnell : MultiSearch.Search
    {
        //Constructors
        public Search_Farnell(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "farnell";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Override Functions
        public override void InitWebsite()
        {
            Navigate("http://uk.farnell.com", false);
            UserName_Name = "msglogin";
            Password_Name = "password";
            base.InitWebsite();
        }
        public override String ToString() 
        { return "Farnell"; }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickElement("input", "", "", "/atg/userprofiling/ProfileFormHandler.login", "submitlogin", true, "/images/en_UK/btn_login_flat.gif");
            //if (msData.IsAAT)
            //    Timer1.Start();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            if (SetTextBox("searchTerms", strPartNumber))
            {
                if (ClickElement("input", "Go", "", "/pf/search2/TextSearchFormHandler.search", "", true, "/images/en_UK/homepage/search.gif", "", ""))
                {
                    IsAbleToSearch = true;
                }
                else
                {
                    if (ClickElement("input", "", "", "/pf/search2/TextSearchFormHandler.search", "", true, "/images/en_UK/btn_go.gif", "Go", ""))
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
        //Control Events
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(LastPartSearched))
                return;
            RunSearch(LastPartSearched, false);
        }
    }
}
