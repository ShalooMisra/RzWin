using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_AvnetTime : MultiSearch.Search
    {
        //Constructors
        public Search_AvnetTime(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "avnettime";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "AvnetTime"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.avnettime.co.uk/Search.asp?Action=Logon&region=uk", false);

            UserName_Name = "T1";
            Password_Name = "T2";
            SecondPassword_Name = "";
            LoginTag = "input";
            LoginType = "image";
            LoginName = "LogBut";
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            if (SetTextBox("MatText", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", wait, "/images/table_but_submit_uk.gif"))
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

