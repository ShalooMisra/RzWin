using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_Spoerle : MultiSearch.Search
    {
        //Constructors
        public Search_Spoerle(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "spoerle";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "Spoerle"; }
        public override void InitWebsite()
        {
            Navigate("http://www.spoerle.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("part-search", strPartNumber))
			{
                if (!ClickElement("input", "", "", "", "", wait, "images/en/buttons/bf_suche_starten.gif"))
                {
                    if (!ClickElement("input", "", "", "", "Image1", wait, ""))
                    {
                        if (ClickElement("a", "", "", "", "", wait, "", "", "javascript:partsearchValidate();"))
                            IsAbleToSearch = true;
                    }
                }
                else
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
            if (GetPageHTML(wb).ToLower().Contains("/images/en/buttons/bf_add_cart.gif"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("sorry, we were unable to find the parts that you requested. please modify your search and try again."))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

