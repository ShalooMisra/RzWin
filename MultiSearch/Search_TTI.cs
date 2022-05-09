using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace MultiSearch 
{
    public partial class Search_TTI : MultiSearch.Search
    {
        //Constructors
        public Search_TTI(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "tti";
            ShowLogin = true;
            InitializeComponent();
        }
        //Public Override Functions
        public override void InitWebsite()
        {
            //Navigate("https://www.ttiinc.com/apps/loginForm.do?TYPE=100663297&REALMOID=06-98d0049d-3346-4c40-8d0c-dbf6caee6540&GUID=&SMAUTHREASON=0&METHOD=GET&SMAGENTNAME=-SM-Iw65ts8o1o%2fmUfXwwqMfFqeTscTqfq3%2fYjYSsc4vika6J5jGfFct9qO8FKygDg3R&TARGET=-SM-http%3a%2f%2fwww%2ettiinc%2ecom%2fpage%2fsmLogin%2ehtml", false);
            Navigate("https://www.ttiinc.com/page/login", false);
            IsInitialized = true;
            UserName_Name = "email";
            Password_Name = "password";
            base.InitWebsite();
        }
        public override String ToString() 
        { return "TTI"; }
        public override void EnterLoginInfo()
        {
            base.EnterLoginInfo();
            ClickButton("", "Sign In", "", "", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            if (SetTextBox("searchTerms", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "/docs/IO/8807/img8807.gif"))
                {
                    IsAbleToSearch = true;
                    return;
                }
                if (ClickElement("input", "", "", "", "Image1", wait, ""))
                {
                    IsAbleToSearch = true;
                    return;
                }
                if (ClickElement("input", "", "", "", "product-submit", true, "/docs/IO/9094/img9094.gif"))
                {
                    IsAbleToSearch = true;
                    return;
                }
                //if (msData.IsAAT)
                //    Timer1.Enabled = true;
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
            if (GetPageHTML(wb).ToLower().Contains("parts that meet your search criteria."))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("<strong>no parts found.</strong>"))
                key = StatusIcon.NoResults;
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
