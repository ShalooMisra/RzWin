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
    public partial class Search_PriceLynx : MultiSearch.Search
    {
        //Constructors
        public Search_PriceLynx(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "pricelynx";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "PriceLynx";
        }
        public override void InitWebsite()
        {
            Navigate("http://www.pricelynx.net/", false);
            base.InitWebsite();
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("multiref", strPartNumber))
            {
                if (ClickButton("", "Search", "btnSearch", "", wait))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("parts matched your search for"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("no pricing available for"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}
