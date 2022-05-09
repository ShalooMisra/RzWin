using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class QuotesView : UserControl
    {
        public QuotesView()
        {
            InitializeComponent();
        }

        public virtual void Init()
        {

        }

        public void AllSet()
        {
            optAllQuotes.Checked = true;
        }

        private void QuotesView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                gbQuotes.Width = this.ClientRectangle.Width - gbQuotes.Left;
            }
            catch { }
        }

        public virtual Enums.PartSearchType SearchType
        {
            get
            {
                if (optGivingQuotes.Checked)
                    return Enums.PartSearchType.Quotes_Giving;
                else if (optReceivingBids.Checked)
                    return Enums.PartSearchType.Quotes_Receiving;
                else
                    return Enums.PartSearchType.Quotes_All;
            }
        }

        private void optQuotes_CheckedChanged(object sender, EventArgs e)
        {
            CheckQuotes();
        }
 
        public virtual void CheckQuotes()
        {
            Clear();
        }

        public virtual void Clear()
        {

        }

        public virtual void RunSearch(String strPart, bool boolVisual, SearchComparison comparison)
        {

        }

        public void GetSearchSQL_Quote(String strPart, SearchComparison comparison, ref String strTable, ref String strWhere, ref String strOrder, String strType, bool replacevisual)
        {
            strTable = "quote";
            strOrder = "quote.datecreated desc";
            StringBuilder sb = new StringBuilder();
            //bool fuzzy = Tools.Strings.StrCmp(strMatchType, "fuzzy");
            //bool exact = Tools.Strings.StrCmp(strMatchType, "exact");
            sb.AppendLine(" quotetype in ( " + strType + " ) ");
            PartSearchParameters pars = new PartSearchParameters(strPart);
            pars.TheComparison = comparison;
            pars.ReplaceVisual = replacevisual;
            ArrayList a = PartObject.GetSearchPermutations(RzWin.Context, pars);
            if (a.Count > 0)
            {
                sb.AppendLine(" and ( ");
                sb.Append(PartObject.BuildWhere(a));
                sb.AppendLine(" ) ");
            }
            strWhere = sb.ToString();
        }

        public virtual void RunSearchByCompany(String companyid, String contactid)
        {

        }

        public virtual nObject SelectedObjectGet()
        {
            return null;
        }

        public event CompanySetHandler OnCompanySet;
        public virtual void FireSetCompany(String strCompanyName, String strCompanyID, String strContactName, String strContactID)
        {
            if (OnCompanySet != null)
                OnCompanySet(strCompanyName, strCompanyID, strContactName, strContactID);
        }
    }

    public delegate void CompanySetHandler(String strCompanyName, String strCompanyID, String strContactName, String strContactID);
}
