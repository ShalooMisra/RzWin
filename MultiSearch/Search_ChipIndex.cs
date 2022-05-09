using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace MultiSearch
{
    public partial class Search_ChipIndex : MultiSearch.Search
    {
        public Search_ChipIndex(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            ShowLogin = true;
            WebsiteName = "chipindex";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString()
        {
            return "ChipIndex";
        }
        public override void InitWebsite()
        {
            base.InitWebsite();
            Navigate("http://www.chipindex.com/Default.aspx", true);
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            if( !SetTextBox("txtPartNo", ""))
                Navigate("http://www.chipindex.com/Default.aspx", true);

            base.RunSearch(strPartNumber, wait);
            if (SetTextBox("txtPartNo", strPartNumber))
            {
                if (ClickElement("input", "", "", "btnFind", "", wait, ""))
                    IsAbleToSearch = true;
                else
                    SetStatusIconTimer(StatusIcon.Error);
            }
            FinishedSearch();
        }
    }
}