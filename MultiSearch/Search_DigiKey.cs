using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_DigiKey : MultiSearch.Search
    {
        //Constructors
        public Search_DigiKey(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "digikey";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "DigiKey"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://www.digikey.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);

            if (SetTextBox("keywords", strPartNumber))
            {
                if (ClickElement("input", "", "", "", "", false, "/images/1201go.gif"))
                    IsAbleToSearch = true;
                else if (ClickElement("input", "", "", "", "", false, "/Images/GoButton.gif"))
                    IsAbleToSearch = true;
                else if (ClickElement("input", "", "go", "", "btnSearch", false, "/Web%20Export/hp/common/search_gobutton.jpg"))
                    IsAbleToSearch = true;
            }
        }
        public override void SetStatusIconTimer()
        {
            if (!HasSearched)
            {
                base.SetStatusIconTimer();
                return;
            }
            StatusIcon key = StatusIcon.Null;
            if (GetPageHTML(wb).ToLower().Contains("quantity available</a>"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Replace(" ","").Replace("\"","").Contains("value=addtoorder"))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains("no records match your search criteria"))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
    }
}

