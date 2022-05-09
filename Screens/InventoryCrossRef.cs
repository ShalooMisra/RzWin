using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NewMethod;
using Rz5;
using GoogleApis;

namespace Rz5
{
    public partial class InventoryCrossRef : UserControl
    {
        //Private Variables
        private ContextRz TheContext;
        private MatchArgs TheArgs;
        private ArrayList SelectedAgents = new ArrayList();
        private nList selectednList;
        private nList partsList;
        private List<orddet_quote> SelectedQuoteLines = new List<orddet_quote>();
        private List<orddet_line> SelectedSalesLines = new List<orddet_line>();
        private List<partrecord> SelectedMatchedPartrecords = new List<partrecord>();

        private bool CanViewAll = false;
        //Constructors
        public InventoryCrossRef()
        {
            InitializeComponent();
        }
        //Public Functions
        public void Init(ContextRz x)
        {
            TheContext = x;
            InitLVs();
            dtStart.SetValue(nTools.GetDate_ThisMonthStart());
            dtEnd.SetValue(DateTime.Now);
            dtPartsAddedAfterDate.SetValue(new DateTime(2005, 01, 01));
            //pAgents.Enabled = (TheContext.xSys).ThePermitLogic.CheckPermit(x, (Permissions.ThePermits).ViewAllAgentsInCrossRef, TheContext.xUser);
            pAgents.Enabled = true;
            CanViewAll = pAgents.Enabled;
            SelectedAgents.Add(TheContext.xUser.name);
            ShowAgents();
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                SetBorder();
                gbOptions.Top = pbTop.Bottom + 2;
                gbOptions.Left = pbLeft.Right + 2;
                gbOptions.Height = (pbBottom.Top - gbOptions.Top) - 2;
                ts.Top = gbOptions.Top;
                ts.Left = gbOptions.Right + 2;
                ts.Width = (pbRight.Left - ts.Left) - 2;
                ts.Height = gbOptions.Height;
            }
            catch { }
        }
        private void SetBorder()
        {
            try
            {
                pbTop.Top = 0;
                pbTop.Left = -5;
                pbTop.Height = 2;
                pbTop.Width = this.Width + 5;
                pbTop.BringToFront();

                pbBottom.Top = this.Height - 2;
                pbBottom.Left = -5;
                pbBottom.Height = 3;
                pbBottom.Width = this.Width + 5;
                pbBottom.BringToFront();

                pbLeft.Top = -5;
                pbLeft.Left = 0;
                pbLeft.Height = this.Height + 5;
                pbLeft.Width = 2;
                pbLeft.BringToFront();

                pbRight.Top = -5;
                pbRight.Left = this.Width - 2;
                pbRight.Height = this.Height + 5;
                pbRight.Width = 2;
                pbRight.BringToFront();

            }
            catch (Exception)
            { }
        }
        private void InitLVs()
        {
            try
            {
                lvQuotes.ShowTemplate("orddet_quote_match_template", "orddet_quote", TheContext.xUserRz.super_user);
                lvQuoteParts.ShowTemplate("partrecord_match_results", "partrecord", TheContext.xUserRz.super_user);
                lvSales.ShowTemplate("orddet_line_match_template", "orddet_line", TheContext.xUserRz.super_user);
                lvSalesParts.ShowTemplate("partrecord_match_results", "partrecord", TheContext.xUserRz.super_user);
                selectednList = lvQuotes;
                partsList = lvQuoteParts;
            }
            catch { }
        }
        private void GetSearchArgs()
        {
            try
            {
                if (TheContext == null)
                    return;
                if (TheArgs == null)
                    return;
                switch (TheArgs.Type)
                {
                    case SearchType.Quote:
                        TheArgs.TheQuoteArgs = BuildSearchArgs("orddet_quote");
                        break;
                    case SearchType.Sales:
                        TheArgs.TheSalesArgs = BuildSearchArgs("orddet_line");
                        break;
                    default:
                        TheArgs.TheQuoteArgs = BuildSearchArgs("orddet_quote");
                        TheArgs.TheSalesArgs = BuildSearchArgs("orddet_line");
                        break;
                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
            }
        }
        private void ShowResults()
        {
            if (TheArgs == null)
                return;
            if (TheArgs.TheQuoteArgs != null)
                lvQuotes.ShowData(TheArgs.TheQuoteArgs);
            if (TheArgs.TheSalesArgs != null)
                lvSales.ShowData(TheArgs.TheSalesArgs);
        }
        private void ShowParts(string part, nList lv)
        {
            if (lv == null)
                return;
            if (!Tools.Strings.StrExt(part))
                return;

            ListArgs a = new ListArgs(TheContext);
            a.TheClass = "partrecord";
            a.TheLimit = 200;
            a.TheOrder = "fullpartnumber";
            a.TheTable = "partrecord";
            a.TheTemplate = "partrecord_match_results";
            //string IncludeMaster;
            //if(chkMaster.Checked)
            //    IncludeMaster = "";
            //else
            //    IncludeMaster = " and quantity_available > 0";



            //string includeOffers = "";
            //if (!chkOffers.Checked)
            //    includeOffers = "";
            //else
            //    includeOffers = " and isnull(isoffer,0) = 1 ";
            //if (!chkOffers.Checked)
            //    includeOffers = " and isnull(isoffer,0) != 1 ";

            a.TheWhere = GetPartrecordResultSql(part);

            // a.TheWhere += GetPartsAddedSinceDateString();
            //KT This will also search alernate parts, but at great time cost.
            //a.TheWhere = "prefix = '" + p + "' and basenumberstripped = '" + b + "' or (alternatepartstripped = '"+p+b+"')";
            a.AddAllow = false;
            lv.ShowData(a);
        }

        private string GetPartrecordResultSql(string partNumber)
        {
            string ret = "";

            string p = "";
            string b = "";
            partNumber = PartObject.StripPart(partNumber);
            PartObject.ParsePartNumber(partNumber, ref p, ref b);
            int sqlLeftLength = p.Length + b.Length;
            string partrecordTrimmed = p + b;

            ArrayList stockTypes = new ArrayList();
            if (chkStock.Checked)
                stockTypes.Add("stock");
            if (chkConsign.Checked)
                stockTypes.Add("consign");
            if (chkExcess.Checked)
                stockTypes.Add("excess");
            if (chkOffers.Checked)
                stockTypes.Add("offers");
            //Strip common Suffixes from base stripped
            //b = StripCommonSuffixes(b);
            //Trim 2 digits off the base number where possible, so we can get matches to T&R suffixes, etc.
            //if (b.Length >= 4)
            //b = b.Substring(0, b.Length - 1);
            //I'll need to compare this trimmed part with an in-memory list of partrecords, else parts taht are stripped down to say LT1313CN won't be 'Like'  LT1013CNNOPBND
            //Wait, maybe I can know ahead of time the len that the final part is and use SQL to trim to same length.

            //BuildPartNumberMatchSqlString(partNumber);
            //Match Type


            if (rbExact.Checked)
                TheArgs.MatchType = "exact";
            else if (rbFuzzy.Checked)
                TheArgs.MatchType = "fuzzy";

            if (TheArgs.MatchType == "exact")
                ret += BuildExactMatchSqlString(partNumber);
            //ret += " prefix+basenumberstripped = '" + partNumber + "%'";
            else
            {
                ret += BuildFuzzyMatchSqlString(partNumber);
                //if (partrecordTrimmed.Length >= 5)
                //    partrecordTrimmed = partrecordTrimmed.Substring(0, 5);
                ////ret = "prefix = '" + p + "' and basenumberstripped = '" + b + "'";// + includeOffers;
                //ret += " CASE WHEN LEN(prefix+basenumberstripped) >= 5 THEN LEFT(prefix+basenumberstripped,5) ELSE (prefix+basenumberstripped) END like '" + partrecordTrimmed + "%'";

            }


            //Alternate Parts
            if (cbxAlternates.Checked)
            {
                if (TheArgs.MatchType == "exact")
                    ret += BuildExactMatchSqlString(partNumber, true);
                else
                    ret += BuildFuzzyMatchSqlString(partNumber, true);
            }

            //ret += " alternatepartstripped = '" + partNumber + "'";

            if (stockTypes.Count > 0)
                ret += " and (isnull(quantity, 0) - isnull(quantityallocated, 0) > 0) and stocktype in (" + Tools.Data.GetIn(stockTypes) + ") ";

            ret += GetPartsAddedSinceDateString();
            return ret;
        }


        private string BuildExactMatchSqlString(string partNumber, bool alternateParts = false)
        {
            //prefix+basenumberstripped = 'PCI9030AA60PIF' and (isnull(quantity, 0) - isnull(quantityallocated, 0) > 0) and stocktype in ('stock', 'consign', 'excess', 'offers')  and partrecord.date_created >=  '1/1/2005' 


            string ret = "";
            string strSearchColumn = GetPartrecordSearchColumn(alternateParts);
            ret += " " + strSearchColumn + " = '" + partNumber + "' ";


            return ret;
        }

        private string BuildFuzzyMatchSqlString(string partrecordTrimmed, bool alternateParts = false)
        {
            string ret = "";
            string strSearchColumn = GetPartrecordSearchColumn(alternateParts);


            if (partrecordTrimmed.Length >= 5)
                partrecordTrimmed = partrecordTrimmed.Substring(0, 5);
            //ret = "prefix = '" + p + "' and basenumberstripped = '" + b + "'";// + includeOffers;
            // ret += " CASE WHEN LEN('" + partrecordTrimmed + "') >= 5 THEN LEFT('" + partrecordTrimmed + "',5) ELSE ('" + partrecordTrimmed + "') END like " + strSearchColumn + "+'%' ";

            
            ret += " " + strSearchColumn + " LIKE '" + partrecordTrimmed + "%' ";

            return ret;
        }

        private string GetPartrecordSearchColumn(bool alternateParts)
        {
            if (alternateParts)
                return " alternatepartstripped ";
            return
                 " prefix+basenumberstripped ";
        }

        private string StripCommonSuffixes(string baseNumberStripped)
        {
            List<string> commonSuffixList = new List<string>()
            {
                "reel",
                "pbf",
                "nd",
                "tr",
                "mpbf",
                "rl",
                "nopb"



            };

            List<string> detectedSuffixes = new List<string>();
            if (baseNumberStripped.Length >= 9)//Only do this for parts that can afford to lose some characters.
            {
                foreach (string s in commonSuffixList)
                {
                    if (baseNumberStripped.ToLower().Contains(s))
                        detectedSuffixes.Add(s);
                }
            }
            string ret = baseNumberStripped.ToLower();
            foreach (string s in detectedSuffixes)
            {
                ret = ret.Replace(s, "");
            }
            return ret.ToUpper();
            //only check the last 6 digits for these codes.
        }

        //private ListArgs GetQuoteArgs()
        //{
        //    ListArgs a = new ListArgs(TheContext);
        //    a.TheClass = "orddet_quote";
        //    a.TheLimit = 200;
        //    a.TheOrder = "orddet_quote.fullpartnumber";
        //    a.TheTable = "orddet_quote";
        //    a.TheTemplate = "orddet_quote_match_template";
        //    a.AddAllow = false;           
        //    //control whether we only return results with Qty.  I.e. Offers don't always have.
        //    string forceQuantity = " and quantity_available > 0";

        //    string type = "";
        //    if (TheArgs.Stock)
        //    {
        //        if (Tools.Strings.StrExt(type))
        //            type += ",";
        //        type += "'stock'";
        //    }
        //    if (TheArgs.Consign)
        //    {
        //        if (Tools.Strings.StrExt(type))
        //            type += ",";
        //        type += "'consigned','consign'";
        //    }
        //    if (TheArgs.Excess)
        //    {
        //        if (Tools.Strings.StrExt(type))
        //            type += ",";
        //        type += "'excess'";
        //    }

        //    //KT
        //    if (TheArgs.Offers)
        //    {
        //        if (Tools.Strings.StrExt(type))
        //            type += ",";
        //        type += "'offers'";


        //    }


        //    //KT Alternate Search
        //    string PartType;
        //    string OnlyWithAlternateStripped;
        //    if (cbxAlternates.Checked)
        //    {
        //        PartType = "partrecord.alternatepartstripped";
        //        OnlyWithAlternateStripped = " and LEN(alternatepartstripped)>0";
        //    }
        //    else
        //    {
        //        PartType = "partrecord.prefix + partrecord.basenumberstripped";
        //        OnlyWithAlternateStripped = "";
        //    }

        //    string agents = "";
        //    string companyIDCritera = "";
        //    string pastHouseQuoteCriteria = "";
        //    if (Tools.Strings.StrExt(TheArgs.SelectedAgentsIn))
        //    {
        //        agents = " and orddet_quote.base_company_uid in (SELECT unique_id from company where agentname IN(" + TheArgs.SelectedAgentsIn + "))";
        //        //agents = " and orddet_quote.agentname = '" + TheContext.xUserRz.name + "'";
        //        //if (Tools.Strings.StrExt(type))

        //        //KT Need to look at company owner as opposed to order owner
        //        //agents = " and orddet_quote.agentname in (" + TheArgs.SelectedAgentsIn + ")";
        //        //if(!CanViewAll)
        //        //Master List of all companies to include for the ccurrent agent.


        //        //Quote lines for All Companies currently owned by Agent
        //        List<string> companiesCurrentlyOwnedByAgent = RzWin.Context.SelectScalarList("select distinct unique_id from company where agentname IN (" + TheArgs.SelectedAgentsIn + ")");
        //        if (companiesCurrentlyOwnedByAgent.Count > 0)
        //        {
        //            companyIDCritera = " orddet_quote.base_company_uid in (" + Tools.Data.GetIn(companiesCurrentlyOwnedByAgent) + ") ";
        //        }

        //        string houseUID = "17a7e95b7bcb47b0a2501d422f899100";
        //        //Quote IDs for companies now in house, but that have been quoted by the agent in the past.
        //        //List<string> quoteIdsForHouseCompaniesQuotedByCurrentUSers = RzWin.Context.SelectScalarList("select distinct unique_id from orddet_quote where agentname IN (" + TheArgs.SelectedAgentsIn + ") && orddet_quote.base_company_uid = '"+ houseUID + "'");
        //        List<string> quoteIdsForHouseCompaniesQuotedByCurrentUSers = RzWin.Context.SelectScalarList("select distinct unique_id from orddet_quote where orddet_quote.agentname IN (" + TheArgs.SelectedAgentsIn + ") and base_company_uid in (select distinct unique_id from company where base_mc_user_uid = '" + houseUID + "')");
        //        //select distinct unique_id from orddet_quote where orddet_quote.agentname IN ('jon kazle') and base_company_uid in (select distinct unique_id from company where base_mc_user_uid = '17a7e95b7bcb47b0a2501d422f899100')
        //        //List of all companies that the agent either owns, or is in house but the agent actually made a req for them in the past.
        //        if (quoteIdsForHouseCompaniesQuotedByCurrentUSers.Count > 0)
        //        {
        //            //If at least one, ensure distinct                  
        //            pastHouseQuoteCriteria = "  orddet_quote.unique_id IN (" + Tools.Data.GetIn(quoteIdsForHouseCompaniesQuotedByCurrentUSers) + ")";

        //        }

        //    }
        //    string companyAgentCriteria = "and ";
        //    if (!string.IsNullOrEmpty(companyIDCritera) || !string.IsNullOrEmpty(pastHouseQuoteCriteria))
        //    {
        //        companyAgentCriteria += " ( ";
        //        //if both present, we need an "Or" in there;
        //        if (!string.IsNullOrEmpty(companyIDCritera) && !string.IsNullOrEmpty(pastHouseQuoteCriteria))
        //            companyAgentCriteria += companyIDCritera + " OR " + pastHouseQuoteCriteria;
        //        else //only 1 present, go ahead an concatentate both (one will be string empty so fine).  No Or Needed.
        //            companyAgentCriteria += companyIDCritera + pastHouseQuoteCriteria;
        //        companyAgentCriteria += " ) ";
        //    }



        //    //KT Don't check for QTY available for Master Parts
        //    //if (type.Contains("'master'"))
        //    //    a.TheWhere = "orddet_quote.orderdate " + TheArgs.TheDates.GetBetweenSQL() + agents + " and orddet_quote.prefix + orddet_quote.basenumberstripped in (select " + PartType + " from partrecord where stocktype in (" + type + ")) and LEN(orddet_quote.prefix + orddet_quote.basenumberstripped) > 0" + OnlyWithAlternateStripped;
        //    //else
        //    a.TheWhere = " fullpartnumber NOT LIKE('%gcat%') and orddet_quote.orderdate " + TheArgs.TheDates.GetBetweenSQL() + agents + companyAgentCriteria + " and orddet_quote.prefix + orddet_quote.basenumberstripped in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString() + " and LEN(orddet_quote.prefix + orddet_quote.basenumberstripped) > 0 " + forceQuantity + " )" + OnlyWithAlternateStripped;

        //    a.TheOrder = "orddet_quote.orderdate DESC";
        //    return a;
        //}

        private ListArgs GetQuoteArgs()
        {
            ListArgs a = new ListArgs(TheContext);
            a.TheClass = "orddet_quote";
            a.TheLimit = 200;
            a.TheOrder = "orddet_quote.fullpartnumber";
            a.TheTable = "orddet_quote";
            a.TheTemplate = "orddet_quote_match_template";
            a.AddAllow = false;


            string type = "";
            if (TheArgs.Stock)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'stock'";
            }
            if (TheArgs.Consign)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'consigned','consign'";
            }
            if (TheArgs.Excess)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'excess'";
            }

            //KT
            if (TheArgs.Offers)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'offers'";


            }


            //KT Alternate Search
            string PartType;
            string OnlyWithAlternateStripped;
            if (cbxAlternates.Checked)
            {
                PartType = "partrecord.alternatepartstripped";
                OnlyWithAlternateStripped = " and LEN(alternatepartstripped) >0 ";
            }
            else
            {
                PartType = "partrecord.prefix + partrecord.basenumberstripped";
                OnlyWithAlternateStripped = "";
            }


            List<string> agentUidList = new List<string>();
            ArrayList agents = SelectedAgents;
            foreach (string s in agents)
            {
                n_user u = n_user.GetByName(RzWin.Context, s);
                if (u != null)
                    if (!agentUidList.Contains(u.unique_id))
                        agentUidList.Add(u.unique_id);

            }

            string selectedAgentIds = "";
            if (agentUidList.Count > 0)
                selectedAgentIds = " and orddet_quote.base_mc_user_uid in (" + Tools.Data.GetIn(agentUidList) + ")";
            a.TheWhere = " LEN(isnull(fullpartnumber, '')) > 0 and fullpartnumber NOT LIKE('%gcat%') and orddet_quote.orderdate " + TheArgs.TheDates.GetBetweenSQL() + selectedAgentIds + " and orddet_quote.prefix + orddet_quote.basenumberstripped in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString() + " and (quantity - quantityallocated) > 0 " + OnlyWithAlternateStripped + "  )";
            a.TheOrder = "orddet_quote.orderdate DESC";
            return a;
        }

        private ListArgs BuildSearchArgs(string tableName)
        {
            //Table Name
            string userIDColumn = "base_mc_user_uid";

            //Orddet_line specific
            string onlyActualSales = "";
            if (tableName == "orddet_line")
            {
                userIDColumn = "seller_uid";
                onlyActualSales = " and len(isnull(orderid_sales, '')) > 0 ";
            }


            ListArgs a = new ListArgs(TheContext);
            a.TheClass = tableName;
            a.TheLimit = 200;
            a.TheOrder = tableName + ".fullpartnumber";
            a.TheTable = tableName;
            a.TheTemplate = tableName + "_match_template";
            a.AddAllow = false;


            string type = "";
            if (TheArgs.Stock)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'stock'";
            }
            if (TheArgs.Consign)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'consigned','consign'";
            }
            if (TheArgs.Excess)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'excess'";
            }

            //KT
            if (TheArgs.Offers)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'offers'";


            }


            //KT Alternate Search
            string PartType;
            string OnlyWithAlternateStripped;
            if (cbxAlternates.Checked)
            {
                PartType = "partrecord.alternatepartstripped";
                OnlyWithAlternateStripped = " and LEN(alternatepartstripped) >0 ";
            }
            else
            {
                //PartType = "partrecord.prefix + partrecord.basenumberstripped";
                //PartType = " CASE WHEN LEN(partrecord.prefix + partrecord.basenumberstripped) >= 5 THEN LEFT(partrecord.prefix + partrecord.basenumberstripped, 5) ELSE (partrecord.prefix + partrecord.basenumberstripped) END ";
                PartType = "partrecord.fullpartnumber";
                OnlyWithAlternateStripped = "";
            }


            List<string> agentUidList = new List<string>();
            ArrayList agents = SelectedAgents;
            foreach (string s in agents)
            {
                n_user u = n_user.GetByName(RzWin.Context, s);
                if (u != null)
                    if (!agentUidList.Contains(u.unique_id))
                        agentUidList.Add(u.unique_id);

            }

            string selectedAgentIds = "";
            if (agentUidList.Count > 0)
                selectedAgentIds = " and " + tableName + "." + userIDColumn + " in (" + Tools.Data.GetIn(agentUidList) + ")";
            a.TheWhere = " LEN(isnull(fullpartnumber, '')) > 0 and fullpartnumber NOT LIKE('%gcat%') and " + tableName + ".date_created " + TheArgs.TheDates.GetBetweenSQL() + selectedAgentIds + onlyActualSales;
            //The Partrecord Stuff
            if (TheArgs.MatchType == "fuzzy")
                /*  a.TheWhere += " and CASE WHEN LEN(" + tableName + ".prefix + " + tableName + ".basenumberstripped) >= 5 THEN LEFT(" + tableName + ".prefix + " + tableName + ".basenumberstripped, 5) ELSE (" + tableName + ".prefix + " + tableName + ".basenumberstripped) END in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString() + " and */
                a.TheWhere += " and " + tableName + ".fullpartnumber in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString();
            else if (TheArgs.MatchType == "exact")
                //a.TheWhere += " and " + tableName + ".prefix + " + tableName + ".basenumberstripped in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString
                a.TheWhere += " and " + tableName + ".fullpartnumber in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString();

            //Only available QTY
            a.TheWhere += " and (quantity - quantityallocated) > 0 " + OnlyWithAlternateStripped + "  )";
            a.TheOrder = tableName + ".date_created DESC";
            return a;
        }


        private ListArgs GetSalesArgsFromPartSearch(SearchComparison compare = SearchComparison.Fuzzy)
        {
            //return RzWin.Context.TheLogicRz.SalesSearchArgsGet(RzWin.Context, compare, CrossRefParametersGet(compare));
            return null;
        }

        protected virtual PartSearchParameters CrossRefParametersGet(ContextRz x, String term, SearchComparison compare)
        {
            PartSearchParameters pars = new PartSearchParameters(term);
            pars.SearchTerm = term;
            pars.IncludeAllocated = true;
            pars.IncludeStock = chkStock.Checked;
            pars.IncludeConsign = chkConsign.Checked;
            pars.IncludeExcess = chkExcess.Checked;
            pars.IncludeOffers = chkOffers.Checked;
            pars.IncludeAlternatePart = true;
            pars.IncludeUserDefined = true;
            pars.UnlimitedResults = true;
            pars.TheComparison = compare;
            //if (optMfg.Checked)
            //    pars.TheTarget = PartSearchTarget.Manufacturer;
            //else if (optDescription.Checked)
            //    pars.TheTarget = PartSearchTarget.Description;
            //else
            pars.TheTarget = PartSearchTarget.Part;
            //KT Refactored from RzSensible - 4-23-2015
            //if (chkOnlyThisComp.Checked)
            //    pars.CompanyName = CompList.GetCompanyName();

            return pars;
        }


        private ListArgs GetSalesArgs()
        {
            ListArgs a = new ListArgs(TheContext);
            a.TheClass = "orddet_line";
            a.TheLimit = 200;
            a.TheOrder = "fullpartnumber";
            a.TheTable = "orddet_line";
            a.TheTemplate = "orddet_line_match_template";
            a.AddAllow = false;
            string type = "";
            if (TheArgs.Stock)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'stock'";
            }
            if (TheArgs.Consign)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'consigned','consign'";
            }
            if (TheArgs.Excess)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'excess'";
            }

            //control whether we only return results with Qty.  I.e. Offers don't always have.
            string forceQuantity = " and quantity_available > 0";

            //KT
            if (TheArgs.Offers)
            {
                if (Tools.Strings.StrExt(type))
                    type += ",";
                type += "'offers'";
            }

            //KT Alternate Search
            string PartType;
            string OnlyWithAlternateStripped;
            if (cbxAlternates.Checked)
            {
                PartType = "partrecord.alternatepartstripped";
                OnlyWithAlternateStripped = " and LEN(alternatepartstripped)>0";
            }
            else
            {
                PartType = "partrecord.prefix + partrecord.basenumberstripped";
                OnlyWithAlternateStripped = "";
            }



            string agents = "";
            if (Tools.Strings.StrExt(TheArgs.SelectedAgentsIn))
                //if (!CanViewAll)
                //agents = " and orddet_line.seller_name = '" + TheContext.xUserRz.name + "'";
                //else
                //agents = " and orddet_line.customer_uid in (SELECT unique_id from company where agentname IN(" + TheArgs.SelectedAgentsIn + ") OR agentname = 'house')";
                agents = " and orddet_line.customer_uid in (SELECT unique_id from company where agentname IN(" + TheArgs.SelectedAgentsIn + "))";

            //KT Need to look at company owner as opposed to order owner
            //agents = " and orddet_line.seller_name in (" + TheArgs.SelectedAgentsIn + ")";
            //if (!CanViewAll) 
            //    agents = " and orddet_line.seller_name = '" + TheContext.xUserRz.name + "'";

            //if(type)
            //if (Tools.Strings.StrExt(type))
            //KT Don't check for QTY available for Master Parts
            //if (type.Contains("'master'"))
            //    a.TheWhere = "orddet_line.orderdate_sales " + TheArgs.TheDates.GetBetweenSQL() + agents + " and len(isnull(orddet_line.orderid_sales, '')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped in (select " + PartType + " from partrecord where stocktype in (" + type + ")  and LEN(orddet_line.prefix + orddet_line.basenumberstripped) > 0" + forceQuantity+ OnlyWithAlternateStripped + ")";
            //else
            a.TheWhere = "fullpartnumber NOT LIKE('%gcat%') and orddet_line.orderdate_sales " + TheArgs.TheDates.GetBetweenSQL() + agents + " and len(isnull(orddet_line.orderid_sales, '')) > 0 and orddet_line.prefix + orddet_line.basenumberstripped in (select " + PartType + " from partrecord where stocktype in (" + type + ") " + GetPartsAddedSinceDateString() + " and LEN(orddet_line.prefix + orddet_line.basenumberstripped) > 0 " + forceQuantity + OnlyWithAlternateStripped + ")";
            a.TheOrder = "orddet_line.orderdate_sales DESC";
            return a;
        }

        private string GetPartsAddedSinceDateString()
        {
            string strPartsSinceDate = dtPartsAddedAfterDate.GetValue_Date().ToShortDateString();
            string ret = " and partrecord.date_created >=  '" + strPartsSinceDate + "' ";
            return ret;
        }

        private ArrayList GetSelectedAgents()
        {
            return frmChooseUser_Multiple.Choose(RzWin.Context.Logic.SalesPeople, "Choose Agents", SelectedAgents);
        }
        private void ShowAgents()
        {
            if (SelectedAgents.Count == 0)
                lblChooseAgents.Text = "<click to choose agent list>";
            else if (SelectedAgents.Count == 1)
                lblChooseAgents.Text = (String)SelectedAgents[0];
            else
                lblChooseAgents.Text = (String)SelectedAgents[0] + " +" + Convert.ToInt32(SelectedAgents.Count - 1).ToString();
        }
        //Buttons
        private void cmdView_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy)
                return;

            lvQuoteParts.Clear();
            TheArgs = new MatchArgs();
            TheArgs.TheQuoteArgs = null;
            TheArgs.TheSalesArgs = null;
            TheArgs.SelectedAgentsIn = Tools.Data.GetIn(SelectedAgents);
            TheArgs.TheDates = new Tools.Dates.DateRange(dtStart.GetValue_Date(), dtEnd.GetValue_Date());
            TheArgs.Stock = chkStock.Checked;
            TheArgs.Consign = chkConsign.Checked;
            TheArgs.Excess = chkExcess.Checked;
            //KT
            //TheArgs.Master = chkMaster.Checked;
            TheArgs.Offers = chkOffers.Checked;
            if (optBoth.Checked)
                TheArgs.Type = SearchType.Both;
            else if (optReqQuotes.Checked)
                TheArgs.Type = SearchType.Quote;
            else if (optSales.Checked)
                TheArgs.Type = SearchType.Sales;
            if (rbExact.Checked)
                TheArgs.MatchType = "exact";
            else if (rbFuzzy.Checked)
                TheArgs.MatchType = "fuzzy";

            bgw.RunWorkerAsync();
        }







        //Control Events
        private void InventoryCrossRef_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lvQuotes_ObjectClicked(object sender, ObjectClickArgs args)
        {
            try
            {
                orddet_quote q = (orddet_quote)lvQuotes.GetSelectedObject();
                if (q == null)
                    return;
                ShowParts(q.fullpartnumber, lvQuoteParts);
                selectednList = lvQuotes;
                partsList = lvQuoteParts;
            }
            catch { }
        }
        private void lvSales_ObjectClicked(object sender, ObjectClickArgs args)
        {
            try
            {
                orddet_line l = (orddet_line)lvSales.GetSelectedObject();
                if (l == null)
                    return;
                ShowParts(l.fullpartnumber, lvSalesParts);
                selectednList = lvSales;
                partsList = lvSalesParts;
            }
            catch { }
        }
        private void lvSales_AboutToThrow(Core.Context x, Core.ShowArgs args)
        {
            try
            {
                orddet_line l = (orddet_line)lvSales.GetSelectedObject();
                ordhed_sales s = ordhed_sales.GetById(RzWin.Context, l.orderid_sales);
                RzWin.Context.Show(s);
            }
            catch { }
            args.Handled = true;
        }
        private void lblChooseAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectedAgents = GetSelectedAgents();
            if (!RzWin.Context.xUser.SuperUser)
                SelectedAgents.Remove("Unclaimed");
            ShowAgents();
        }
        private void lblClearAgents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SelectedAgents = new ArrayList();
            ShowAgents();
        }
        //Background Workers
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            //ContextRz x = RzWin.Context;
            //DateTime rzStart = DateTime.Now;



            //x.Leader.StartPopStatus("Starting Cross Reference for selected Stocktypes and parameters ... ");
            //x.Leader.Comment("Starting Part Cross Reference: Rz Version: " + rzStart);
            GetSearchArgs();
            //DateTime rzEnd = DateTime.Now;
            //x.Leader.Comment("Rz Search completed at " + rzEnd);
            //var diffInSeconds = (rzEnd - rzStart).TotalSeconds;
            //x.Leader.Comment("Total Time for Rz Search: " + diffInSeconds + " seconds");

            ////Sensible DAL Version
            //DateTime dalStart = DateTime.Now;
            //x.Leader.Comment("Starting Part Cross Reference: DAL/LINQ Version: " + dalStart);
            //RunSearchDAL();
            //DateTime dalEnd = DateTime.Now;
            //x.Leader.Comment("DAL Search completed at " + dalEnd);
            //diffInSeconds = (dalEnd - dalStart).TotalSeconds;
            //x.Leader.Comment("Total Time for DAL Search: " + diffInSeconds + " seconds");


        }



        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowResults();
        }
        //Private Classes
        private class MatchArgs
        {
            public ListArgs TheQuoteArgs = null;
            public ListArgs TheSalesArgs = null;
            public Tools.Dates.DateRange TheDates = null;
            public bool Stock = false;
            public bool Consign = false;
            public bool Excess = false;
            //public bool Master = false;
            public bool Offers = false;
            public SearchType Type = SearchType.Both;
            public string SelectedAgentsIn = "";
            public string MatchType = "";
        }
        private enum SearchType
        {
            Both,
            Quote,
            Sales
        }

        private class XrefEmailObject
        {
            public company TheCompany { get; set; }
            public List<orddet> TheOrddets { get; set; }
            public List<orddet_line> TheOrddetLines { get; set; }
            public List<orddet_quote> TheOrddetQuotes { get; set; }
            public List<partrecord> TheMatchedPartrecords { get; set; }
            public List<string> ToList = new List<string>();
            public List<string> CCList = new List<string>();
            public n_user TheAgent { get; set; }
            public string TheFromAddress { get; set; }
            public string TheSubject { get; set; }
            public string TheGreeting { get; set; }
            public string TheBody { get; set; }
            public string TheClosure { get; set; }

        }


        private void CreateXrefObjectEmail(ContextRz x, XrefEmailObject xreo)
        {
            string body = xreo.TheGreeting;
            //Get Distinct List of agents
            List<n_user> agentList = new List<n_user>();
            body += "<b><p style=\"font-size:12px;\">" + xreo.TheCompany.companyname + ":</p></b>";
            body += GenerateEmailBodyFromMatches(x, xreo);
            body += xreo.TheClosure;

            string error = "";
            x.TheSysRz.TheEmailLogic.SendEmail(x, new List<string>() { "ktill@sensiblemicro.com" }, body, "Customer Email Xref Report", false, true, null, null, null, true, null, "xref@sensiblemicro.com", false,ref error);

        }


        private void CreateXrefSummaryEmail(ContextRz x, List<XrefEmailObject> xreoList)
        {
            string body = "Here is a summary of current stock that matches current reqs / sales. <br /><br />";
            //Get Distinct List of agents
            List<n_user> agentList = new List<n_user>();
            foreach (n_user u in xreoList.Select(s => s.TheAgent).ToList())
                if (!agentList.Any(a => a.name == u.name))
                    agentList.Add(u);
            //Build summary Section for each agent, then by company
            foreach (n_user u in agentList)
            {
                body += "*****************************";
                body += "<b><p style=\"font-size:16px;\">" + u.Name + ":</p></b>";
                List<XrefEmailObject> agentXreoList = xreoList.Where(w => w.TheAgent.unique_id == u.unique_id).ToList();
                foreach (XrefEmailObject xreo in agentXreoList)
                {
                    body += "<b><p style=\"font-size:12px;\">" + xreo.TheCompany.companyname + ":</p></b>";
                    body += GenerateEmailBodyFromLineItems(x, xreo);
                }
                body += "*****************************";
            }
            string error = "";
            x.TheSysRz.TheEmailLogic.SendEmail(x, new List<string>() { "ktill@sensiblemicro.com" }, body, "Summary Email Xref Report", false, true, null, null, null, true, null, "xref@sensiblemicro.com", false, ref error);
        }



        private XrefEmailObject CreateXrefObjectForCompany(ContextRz x, company c, List<orddet> oList)
        {


            XrefEmailObject xreo = new XrefEmailObject();
            xreo.TheCompany = c;
            xreo.TheAgent = n_user.GetById(x, c.base_mc_user_uid);
            xreo.TheOrddets = oList;
            xreo.ToList.Add(xreo.TheAgent.email_address);
            xreo.CCList.Add("systems@sensiblemicro.com");
            xreo.TheFromAddress = "rz_xref@sensiblemicro.com";
            xreo.TheSubject = "Component Opportunity Identified";
            xreo.TheOrddetQuotes = SelectedQuoteLines.Where(w => w.base_company_uid == c.unique_id).ToList();
            xreo.TheOrddetLines = SelectedSalesLines.Where(w => w.customer_uid == c.unique_id).ToList();
            xreo.TheMatchedPartrecords = SelectedMatchedPartrecords;
            xreo.TheGreeting = GenerateEmailGreeting(x, xreo, "list");
            //xreo.TheBody = GenerateEmailBodyFromLineItems(x, xreo);
            xreo.TheClosure = GenerateEmailClosure(x, xreo);
            return xreo;
        }



        private string GenerateEmailGreeting(ContextRz x, XrefEmailObject xreo, string type)
        {
            //Form the Greeting
            StringBuilder sbGreeting = new StringBuilder();


            //Handle Plurality
            int currentCount = 0;
            if (xreo.TheOrddetQuotes.Count > 0)
                currentCount = SelectedQuoteLines.Count;
            if (xreo.TheOrddetLines.Count > 0)
                currentCount = SelectedSalesLines.Count;
            string partPlural1 = "a part";
            string partPlural2 = "part";
            if (currentCount > 0)
            {
                partPlural1 = "some parts";
                partPlural2 = "parts";
            }

            //Build the Text
            sbGreeting.Append("Hey There, " + xreo.TheAgent.Name + " here from Sensible Micro.  I was looking through your account today, and came across " + partPlural1 + " that we've helped you out with in the past.  ");
            sbGreeting.Append("We've just received a new supplier list showing availability on the following " + partPlural2 + ", and we may be able to offer more aggressive lead time and pricing.");
            sbGreeting.Append("<br /><br />");
            return sbGreeting.ToString();

        }

        private string GenerateEmailClosure(ContextRz x, XrefEmailObject xreo)
        {
            StringBuilder sbClosure = new StringBuilder();
            //Form the closure
            sbClosure.Append("<br /><br />");
            sbClosure.Append("If you are still in need of these parts, please let me know.");
            sbClosure.Append("<br /><br />");
            sbClosure.Append("Thanks,");
            sbClosure.Append("<br /><br />");
            sbClosure.Append(xreo.TheAgent.Name);

            string email = (xreo.TheAgent.email_address);
            if (!string.IsNullOrEmpty(email))
            {
                sbClosure.Append("<br />");
                sbClosure.Append("e: <a href=\"mailto:" + email + "\">" + email + "</a>");
            }

            sbClosure.Append("<br />");
            sbClosure.Append("p: 877-992-1930");

            return sbClosure.ToString();
        }


        private string GenerateEmailBodyFromLineItems(ContextRz x, XrefEmailObject xreo)
        {

            string ret = "";




            if (xreo.TheOrddetQuotes.Count > 0)
            {
                ret += "<u><em>Reqs:</em></u><br />";
                foreach (orddet_quote q in xreo.TheOrddetQuotes)
                    ret += GenerateTextFromOrddet(q) + "<br />";
            }
            if (xreo.TheOrddetLines.Count > 0)
            {
                ret += "<em>Sales:</em><br />";
                foreach (orddet_line l in xreo.TheOrddetLines)
                    ret += GenerateTextFromOrddet(l) + "<br />";
            }

            return ret;
        }

        private string GenerateEmailBodyFromMatches(ContextRz x, XrefEmailObject xreo)
        {

            string ret = "";

            orddet customerPart = (orddet)selectednList.GetSelectedObject();




            if (xreo.TheMatchedPartrecords.Count > 0)
            {
                //if we've selected partnumber matches, then we've either picked a quote part, or a stock part



                ret += GenerateTextFromPartrecord(xreo) + "</li>";

            }


            return ret;
        }



        private List<partrecord> GetCurrentPartsList()
        {
            List<partrecord> ret = new List<partrecord>();

            //NOT The current List, it will only show for  1item, need to do a clean partrecord lookup for each quote.

            ArrayList partsListIDs = partsList.GetAllIDs();
            foreach (string s in partsListIDs)
            {
                partrecord p = partrecord.GetById(RzWin.Context, s);
                if (p != null)
                    ret.Add(p);
            }
            return ret;
        }


        private string GenerateTextFromPartrecord(XrefEmailObject xreo)
        {
            orddet o = (orddet)selectednList.GetSelectedObject();
            string selectedPart = o.fullpartnumber;
            //Get a list of distinct partrecords from the matches
            //use that list to get sum of each, add to collection of new partrecords
            List<string> distinctPartnumbers = xreo.TheMatchedPartrecords.Select(s => s.fullpartnumber).Distinct().ToList();
            //Carry a list of derived partrecords wtih qty summed
            List<partrecord> similarMatches = new List<partrecord>();
            List<partrecord> exactMatches = new List<partrecord>();
            foreach (string s in distinctPartnumbers)
            {
                //build a new partrecord with summed values
                partrecord p = new partrecord();
                p.fullpartnumber = s;
                //Get A list of manufacturers
                List<string> mfgList = new List<string>();
                mfgList = xreo.TheMatchedPartrecords.Where(w => w.fullpartnumber == s).Select(ss => ss.manufacturer).ToList();
                if (mfgList.Count == 0)
                    p.manufacturer = "Unknown";
                else
                    p.manufacturer = mfgList.First().Trim().ToUpper();
                //Sum the available qty from the list
                long matchedQty = xreo.TheMatchedPartrecords.Where(w => w.fullpartnumber == s).Sum(ss => ss.quantity - ss.quantityallocated);
                p.quantity_available = matchedQty;
                bool isExactMatch = p.fullpartnumber.ToUpper().Trim() == selectedPart.ToUpper().Trim();
                if (isExactMatch)
                    exactMatches.Add(p);
                else
                    similarMatches.Add(p);

            }


            string ret = "";

            if (exactMatches.Count > 0)
            {
                ret += "<br /><em>Exact Matches for customer part: <b>" + selectedPart.Trim().ToUpper() + "</b></em><br /><br />";
                foreach (partrecord p in exactMatches)
                {

                    ret += "<b>MPN: " + p.fullpartnumber.Trim().ToUpper() + "</b><br />  ";
                    ret += "Mfg: " + p.manufacturer + "<br />";
                    ret += "Our Qty: " + p.quantity_available + "<br /><br />";

                }
            }

            if (similarMatches.Count > 0)
            {
                ret += "<br />";
                ret += "<br /><em>Similar Matches for customer part: <b>" + selectedPart.Trim().ToUpper() + "</b></em><br /><br />";
                foreach (partrecord p in similarMatches)
                {

                    ret += "<b>MPN: " + p.fullpartnumber.Trim().ToUpper() + "</b><br />  ";
                    ret += "Mfg: " + p.manufacturer + "<br />";
                    ret += "Our Qty: " + p.quantity_available + "<br /><br />";

                }
            }




            return ret;
        }

        private string GenerateTextFromOrddet(orddet o)
        {
            string ret = "";
            string partrecordSql = "select * from partrecord where " + GetPartrecordResultSql(o.fullpartnumber);
            List<partrecord> pList = RzWin.Context.QtC("partrecord", partrecordSql).Cast<partrecord>().ToList();
            ret += "<b>MPN: " + o.fullpartnumber.ToUpper() + "</b><br />  ";
            if (!string.IsNullOrEmpty(o.internalpartnumber))
                ret += "Customer Internal: " + o.internalpartnumber.ToUpper() + "<br />  ";
            if (!string.IsNullOrEmpty(o.datecode))
                ret += "D/C Requested: " + o.datecode.ToUpper() + "<br />  ";
            ret += "Our Qty: " + pList.Sum(s => s.quantity).ToString() ?? "Confirming";
            return ret;
        }



        private string GetCompanyOwnerEmailAddress(ContextRz x, company c)
        {
            if (x.xUserRz.name.ToLower() == "kevin till")
                return "ktill@sensiblemicro.com";
            n_user u = n_user.GetById(x, c.base_mc_user_uid);
            if (u == null)
                throw new Exception("No user found assoicated with " + c.companyname);
            if (string.IsNullOrEmpty(u.email_address))
                throw new Exception("Invalid Email address for  " + u.name);
            if (!Tools.Email.IsEmailAddress(u.email_address))
                throw new Exception(u.email_address + " Is an invalid Email address for  " + u.name);
            return u.email_address;
        }



        private void GenerateEmail(bool summaryEmail, int limit = 0)
        {
            SelectedSalesLines.Clear();
            SelectedQuoteLines.Clear();


            //Context variable
            ContextRz x = RzWin.Context;


            //ref error variable for email method
            string error = "";

            //Email Subject
            string strSubject = "New Component Availability";

            //Email Body
            string strBody = "";


            //Get a list of current result IDS for Search All functionality.
            List<string> currentQuoteIds = new List<string>();
            if (lvQuotes.GetAllIDs().Count > 0)
            {
                currentQuoteIds.AddRange(lvQuotes.GetAllIDs().Cast<string>().ToList());

            }
            //Get a list of current result IDS for Search All functionality.
            List<string> currentSalesIds = new List<string>();
            if (lvSales.GetAllIDs().Count > 0)
            {
                currentSalesIds.AddRange(lvSales.GetAllIDs().Cast<string>().ToList());
            }

            //Create List to hold the main selection of objects
            List<orddet> oList = new List<orddet>();
            //Determine whether we want to search all current results, or just selection


            //Check to see if anything is selected. 
            //If single part selected, use the partnumber and qty from the pars
            //if Multiple Selected, ask user if they would like to summarize using the part number from the matched customer order
            //// if Yes, Sum the QTY and list the part as the number on their quote / sale
            ///  if No, Return list of all distinct selected partrecord part numbers, and their qty sums.
            //Get the selected objects
            int selectedObjectsCount = selectednList.GetSelectedObjects().Count;
            if (selectedObjectsCount > 0)
            {

                GetSelectedQuotes(x);
                GetSelectedSalesLines(x);
                GetSelectedMatches(x);
            }
            else
            {
                x.Leader.Error("You haven't selected any specific items.)");
                return;

            }

            oList.AddRange(SelectedQuoteLines);
            oList.AddRange(SelectedSalesLines);
            if (oList.Count == 0)
                return;

            //Build list of companies for reqs
            List<company> cList = new List<company>();
            foreach (orddet_quote q in SelectedQuoteLines)
            {
                company c = company.GetById(x, q.base_company_uid);
                if (!cList.Any(a => a.companyname == c.companyname))
                    cList.Add(c);

            }

            //Build list of companies for sales
            foreach (orddet_line l in SelectedSalesLines)
            {
                company c = company.GetById(x, l.customer_uid);
                if (!cList.Any(a => a.companyname == c.companyname))
                    cList.Add(c);

            }
            if (limit > 0)
                if (cList.Count > limit)
                {
                    x.Leader.Error("Currently emails are limited to " + limit.ToString() + " company at a time. Please selecte quotes for a single company and try again.");
                    return;
                }

            //Build list of XrefEmailObjects for the distinct company list     
            List<XrefEmailObject> xreoList = new List<XrefEmailObject>();
            foreach (company c in cList)
            {
                xreoList.Add(CreateXrefObjectForCompany(x, c, oList));
            }

            //Set summary email (all results consolidated into single email, separated by Agent, then Company 
            if (summaryEmail)
                CreateXrefSummaryEmail(x, xreoList);
            else
                foreach (XrefEmailObject xreo in xreoList)
                    CreateXrefObjectEmail(x, xreo);

            x.Leader.Tell("Your email is being crafted in the background, and should appear in your drafts shortly.");

        }

        private void GetSelectedMatches(ContextRz x)
        {

            List<partrecord> quoteMatches = new List<partrecord>();
            List<partrecord> saleMatches = new List<partrecord>();
            //Grab a list of the currently selected objects from lvQuoteParts and lvSaleParts
            if (lvQuoteParts.GetSelectedIDs().Count > 0)
            {
                quoteMatches = x.QtC("partrecord", "select * from partrecord where unique_id in (" + Tools.Data.GetIn(lvQuoteParts.GetSelectedIDs()) + ")").Cast<partrecord>().ToList();

            }
            if (lvSalesParts.GetSelectedIDs().Count > 0)
            {
                saleMatches = x.QtC("partrecord", "select * from partrecord where unique_id in (" + Tools.Data.GetIn(lvSalesParts.GetSelectedIDs()) + ")").Cast<partrecord>().ToList();

            }

            SelectedMatchedPartrecords = quoteMatches.Union(saleMatches).ToList();

        }
        private void GetSelectedSalesLines(ContextRz x)
        {
            if (lvSales.GetSelectedIDs().Count > 0)
            {
                SelectedSalesLines = x.QtC("orddet_line", "select * from orddet_line where unique_id in (" + Tools.Data.GetIn(lvSales.GetSelectedIDs()) + ")").Cast<orddet_line>().ToList();
                //foreach (orddet_line l in allSales)
                //{
                //    string part = l.fullpartnumber.Trim().ToLower();
                //    if (!SelectedLines.Any(a => a.fullpartnumber.Trim().ToLower() == part))
                //        SelectedLines.Add(l);


                //}
                //if (selectednList.Name.ToLower() == "lvsales")
                //    SelectedLines.AddRange(selectednList.GetSelectedObjects().Cast<orddet_line>().ToList());
                //oList = selectednList.GetSelectedObjects().Cast<orddet>().ToList();
            }
        }

        private void GetSelectedQuotes(ContextRz x)
        {

            if (lvQuotes.GetSelectedIDs().Count > 0)
            {
                SelectedQuoteLines = x.QtC("orddet_quote", "select * from orddet_quote where unique_id in (" + Tools.Data.GetIn(lvQuotes.GetSelectedIDs()) + ")").Cast<orddet_quote>().ToList();
                //foreach (orddet_quote q in SelectedQuotes)
                //{
                //    string part = q.fullpartnumber.Trim().ToLower();
                //    if (!SelectedQuotes.Any(a => a.fullpartnumber.Trim().ToLower() == part))
                //        SelectedQuotes.Add(q);


                //}
            }

        }

        private List<orddet> ConsolidateDuplicatedParts(object selectedOrddets)
        {
            object ret = new object();
            Type itemType = null;

            Type type = selectedOrddets.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                itemType = type.GetGenericArguments()[0];
            else
                return null;
            string typetest = selectedOrddets.GetType().ToString();
            switch (itemType.Name.ToLower())
            {
                case "orddet_quote":
                    {
                        List<orddet_quote> qList = (List<orddet_quote>)selectedOrddets;
                        ret = qList
             .GroupBy(l => l.fullpartnumber)
             .Select(cl => new orddet
             {
                 fullpartnumber = cl.Key,
                 manufacturer = cl.Max(m => m.manufacturer),
                 internalpartnumber = cl.Max(m => m.internalpartnumber),

             }).OrderBy(o => o.fullpartnumber).ToList();
                        break;
                    }
                case "orddet_line":
                    {
                        List<orddet_line> lineList = (List<orddet_line>)selectedOrddets;
                        ret = lineList
             .GroupBy(l => l.fullpartnumber)
             .Select(cl => new orddet
             {
                 fullpartnumber = cl.Key,
                 manufacturer = cl.Max(m => m.manufacturer),
                 internalpartnumber = cl.Max(m => m.internalpartnumber),

             }).OrderBy(o => o.fullpartnumber).ToList();
                        break;
                    }
            }




            return (List<orddet>)ret;

        }

        private void btnCustomerEmail_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateEmail(false, 1);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
                return;
            }
        }

        private void btnSummaryEmail_Click(object sender, EventArgs e)
        {
            try
            {
                GenerateEmail(true);
            }
            catch (Exception ex)
            {
                RzWin.Leader.Error(ex.Message);
                return;
            }
        }
    }
}
