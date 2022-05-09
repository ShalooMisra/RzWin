using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class QuotesViewSimple : QuotesView
    {
        public String TemplateName = "simple_quotes";

        public QuotesViewSimple()
        {
            InitializeComponent();
        }

        public override void Init()
        {
 	         base.Init();
             Result_Quotes.ShowTemplate(TemplateName, "orddet", RzWin.Context.xUser.TemplateEditor); 
        }

        public override void Clear()
        {
            base.Clear();
            Result_Quotes.Clear();
        }

        public override NewMethod.nObject SelectedObjectGet()
        {
            return Result_Quotes.GetSelectedObject();
        }

        public override void RunSearch(string strPart, bool boolVisual, SearchComparison comparison)
        {
            MessageBox.Show("reorg");

            //String strWhere = "";
            //String strOrder = "";
            //String strClass = "";
            //switch (SearchType)
            //{
            //    case Enums.PartSearchType.Quotes_All:
            //    case Enums.PartSearchType.Quotes_Merged:
            //        PartSearch_Original.GetSearchSQL_OrdDet_Static(strPart, ref strClass, ref strWhere, ref strOrder, "'quote', 'rfq'", boolVisual, comparison);
            //        break;
            //    case Enums.PartSearchType.Quotes_Giving:
            //        PartSearch_Original.GetSearchSQL_OrdDet_Static(strPart, ref strClass, ref strWhere, ref strOrder, "'quote', 'quote'", boolVisual, comparison);
            //        break;
            //    case Enums.PartSearchType.Quotes_Receiving:
            //        PartSearch_Original.GetSearchSQL_OrdDet_Static(strPart, ref strClass, ref strWhere, ref strOrder, "'rfq', 'rfq'", boolVisual, comparison);
            //        break;
            //}

            //strOrder = "orderdate desc";
            //Result_Quotes.ShowData("orddet", strWhere, strOrder, SysNewMethod.ListLimitDefault);
        }

        public override void RunSearchByCompany(string companyid, string contactid)
        {
            if (!Tools.Strings.StrExt(companyid) && !Tools.Strings.StrExt(contactid))
            {
                Result_Quotes.Clear();
                return;
            }

            base.RunSearchByCompany(companyid, contactid);
            String strWhere = " ordertype in ('quote', 'rfq' ) ";

            if (Tools.Strings.StrExt(companyid))
                strWhere += " and base_company_uid = '" + companyid + "' ";

            if( Tools.Strings.StrExt(contactid) )
                strWhere += " and base_companycontact_uid = '" + contactid + "' ";

            Result_Quotes.ShowData("orddet", strWhere, "orderdate desc", SysNewMethod.ListLimitDefault);
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                Result_Quotes.Left = 0;
                Result_Quotes.Top = gbQuotes.Bottom;
                Result_Quotes.Width = this.ClientRectangle.Width;
                Result_Quotes.Height = this.ClientRectangle.Height - Result_Quotes.Top;
            }
            catch { }
        }

        private void Result_Quotes_AboutToThrow(object sender, ShowArgs args)
        {

        }
    }
}
