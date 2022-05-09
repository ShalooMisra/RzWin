using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MultiSearch
{
    public partial class Search_GovLiquidation_Mfg : MultiSearch.Search
    {
        //Constructors
        public Search_GovLiquidation_Mfg(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            WebsiteName = "govliquidation_mfg";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() 
        { 
            return "GovLiquidation <Mfg>"; 
        }
        public override void InitWebsite()
        {
            Navigate("http://web.govliquidation.com/auction/search#AdvancedSearch", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://web.govliquidation.com/auction/search#AdvancedSearch", true);
            String strField = "NSN";
            String res = "";
            if (!Rz5.PartObject.IsNSN(strPartNumber, ref res))
                strField = "words";
            if (SetTextBox("company", strPartNumber.Replace("-", "")))
            {
                if (ClickElement("input", "", "GO", "btnSubmit", "btnSubmit", wait, ""))
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
            if (GetPageHTML(wb).ToLower().Contains("name=btnaddtowatchlist"))
                key = StatusIcon.Results;
            else
                key = StatusIcon.NoResults;
            base.SetStatusIconTimer(key);
        }
    }
}

