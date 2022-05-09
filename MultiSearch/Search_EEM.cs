using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace MultiSearch
{
    public partial class Search_EEM : MultiSearch.Search
    {
        //Constructors
        public Search_EEM(IMSDataProvider d)
            : base(d)
        {
            msData = d;
            SavePageData = true;
            WebsiteName = "eem";
            InitializeComponent();
        }
        //Public Override Functions
        public override String ToString() { return "EEM"; }
        public override void InitWebsite()
        {
            Navigate("http://www.eem.com", false);
            IsInitialized = true;
        }
        public override void RunSearch(String strPartNumber, bool wait)
        {
            base.RunSearch(strPartNumber, wait);
            Navigate("http://www.eem.com/STkParameterSearch.asp?Part=" + strPartNumber + "&Searchtype=&Limit=", false);
        }
        public override void DocumentReallyComplete()
        {
            //this grabs the page
            base.DocumentReallyComplete();

            if (!this.IsAbleToSearch)
            {
                String s = this.GetPageText(wb);
                if (Tools.Strings.HasString(s, "You searched for"))
                {
                    Program.SetStatus("EEM is now able to search.");
                    IsAbleToSearch = true;
                }
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
            if (GetPageHTML(wb).ToLower().Contains(""))
                key = StatusIcon.Results;
            else if (GetPageHTML(wb).ToLower().Contains(""))
                key = StatusIcon.NoResults;
            else
                key = StatusIcon.Error;//?
            base.SetStatusIconTimer(key);
        }
        //Public Functions
	    public void ScanEach()
	    {
            HtmlDocument xDoc;
		    //loop through the links
		    try
		    {
                xDoc = wb.Document;
		    }
		    catch(Exception e)
		    {
			    Program.SetStatus("Error in ScanEach");
                return;
		    }

            HtmlElement body = xDoc.Body;

            HtmlElementCollection col = body.All;

		    IEnumerator en = col.GetEnumerator();

		    mshtml.IHTMLElement ele;
		    mshtml.IHTMLAnchorElement anc;
		    String strhref;
		    String strURL = "";
		    System.Object pNULL = null;
		    String str = strURL;
		    ArrayList ary = new ArrayList();


		    while( en.MoveNext() )
		    {
			    ele = (mshtml.IHTMLElement)(en.Current);

			    if( String.Compare( ele.tagName.ToLower(), "a") == 0 )
			    {
				    anc = (mshtml.IHTMLAnchorElement)(ele);
				    str = anc.href;

				    if( anc.href.ToLower().IndexOf("stkparamresults.asp?origpart=") >= 0 )
				    {	
					    ary.Add(str);
				    }
			    }

                if (Search.ShouldStopAutoSearching)
                {
                    Program.SetStatus("Stopping auto EEM scaneach.");
                    return;
                }
		    }

		    for( int i=0 ; i<ary.Count ; i++ )
		    {
			    str = (String)ary[i];
                Program.SetStatus("Searching " + str + "...");
			    Navigate(str, true);

                if (Search.ShouldStopAutoSearching)
                {
                    Program.SetStatus("Stopping auto EEM scaneach.");
                    return;
                }
		    }
	    }
    }
}

