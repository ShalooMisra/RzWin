using SensibleDAL.dbml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensibleDAL
{
    public class PartLogic
    {

        public static void ParsePartNumber(String strPart, ref String strPrefix, ref String strBase)
        {
            if (!Tools.Strings.StrExt(strPart))
            {
                strPrefix = "";
                strBase = "";
                return;
            }
            //Try to detect the length of the prefix
            int prefixLength = strPart.Length + 1;
            for (int i = 0; i < 10; i++)
            {
                //So, we are basically looking for the numbers 1-10 to see if they exist it the string
                int j = strPart.IndexOf(i.ToString());//The method returns -1 if the character or string is not found in this instance.
                if (j >= 0 && j < prefixLength)//IF j is greater thatn zero and less than prefix length, set this as teh new prefix length.  We keep trimming to smaller and smaller prefix lengths.
                    prefixLength = j;
            }
            //If the length of the prefix matches the length of the part, then there is no prefix:
            if (prefixLength == (strPart.Length + 1))
            {
                strPrefix = StripPart(strPart);
                strBase = "";
                return;
            }
            //If the length of the prefix equals zero, then there is no prefix:            
            if (prefixLength == 0)
            {
                strPrefix = "";
                strBase = strPart;
                return;
            }
            strPrefix = StripPart(Tools.Strings.Left(strPart, prefixLength));
            strBase = strPart.Substring(prefixLength);
        }

        public static String StripPart(String s)
        {
            return s.Replace("-", "").Replace("\\", "").Replace("/", "").Replace(".", "").Replace("_", "").Replace(" ", "").Replace("#", "").Replace("(", "").Replace(")", "").Replace("+", "").Replace("+", "[").Replace("+", "]").Replace(",","");
        }



        public static DataTable GetXrefQuoteLineMatches(DateTime quoteStartDate, DateTime quoteEndDate, Dictionary<string, string> dictAgents, List<string> stockTypes, bool includeHouse = false)
        {
            //Return a list of quote lines that match stock parts.

            string strStart = "Start time: " + DateTime.Now.ToString();
            Console.WriteLine(strStart);
            //Quote Lines created between the dates


            //Currently Selected Agent Ids
            List<string> includedAgentIds = dictAgents.Keys.ToList();
            //Owned companies for selected userS
            List<string> includedCompanyIDs = new List<string>();
            //Combined List agend and sometimes house
            List<orddet_quote> quoteList = new List<orddet_quote>();
            //Date Range
            //DateTime quoteStartDate = new DateTime(2019, 01, 01);
            // DateTime quoteEndDate = DateTime.Now;
            //boolean to include House Accounts
            //bool includeHouseAccounts = false;


            //Get the selected UserIds:
            string houseID = "17a7e95b7bcb47b0a2501d422f899100";
            //string joeID = "24172ac97b0f4d9688ae9945bc64d395";
            //string collinID = "049f839b82314b949715961b7e11e26b";
            //string andyID = "8fb46d6b2f2a4f85b5d031757e27201d";
            //string jonID = "437b726dd3a04c1db2be9a057b79156a";
            ////Add selected userIDS to list
            //includedAgentIds.AddRange(new List<string>() { jonID });
            //includedAgentIds.AddRange(new List<string>() { jonID });
            List<orddet_quote> matchedQuoteList = new List<orddet_quote>();
            using (RzDataContext rdc = new RzDataContext())
            {
                //Get the Unique ids for the agents
                //includedAgentIds = rdc.n_users.Where(w => agentNames.Contains(w.name)).Select(s => s.unique_id).ToList();

                //Get the companies owned by these user ids          
                var companyIdQuery = rdc.companies.Where(w => includedAgentIds.Contains(w.base_mc_user_uid)).Select(s => s.unique_id).ToList();
                if (!companyIdQuery.Any())
                    return null;

                //If include house, add house accounts to the companyID List
                if (includeHouse)
                {
                    //add distinct companyIds to the companyIdList
                    var houseCompanyIds = rdc.companies.Where(w => w.base_mc_user_uid == houseID).Select(s => s.unique_id);
                    if (houseCompanyIds.Any())
                        foreach (string s in houseCompanyIds)
                            if (!includedCompanyIDs.Contains(s))
                                includedCompanyIDs.Add(s);

                }


                //Get a list of all quotes belonging to this list of companies 
                quoteList = rdc.orddet_quotes.Where(w => (w.fullpartnumber ?? "").Length > 0 && companyIdQuery.Contains(w.base_company_uid) && !w.fullpartnumber.Trim().ToLower().Contains("gcat") && w.date_created.Value >= quoteStartDate && w.date_created.Value <= quoteEndDate).ToList();
                //List<partrecord> partMatchList = GetXrefPartRecordMatches(quoteList);

                foreach (orddet_quote q in quoteList)
                {
                    List<partrecord> pList = GetXrefPartRecordMatch(q);
                    if (pList != null && pList.Count > 0)
                        if (!matchedQuoteList.Contains(q))
                            matchedQuoteList.Add(q);
                }
            }

            //Roll the results into a DataTable
            DataTable dt = new DataTable();
            dt = Tools.Data.ListtoDataTable.ToDataTable(matchedQuoteList);


            string strEnd = "End time: " + DateTime.Now.ToString();
            Console.WriteLine(strEnd);
            return dt;

        }

        public static List<partrecord> GetXrefPartRecordMatches(List<orddet_quote> quote_lines)
        {
            List<partrecord> ret = new List<partrecord>();
            foreach (orddet_quote q in quote_lines)
            {
                List<partrecord> prMatches = GetXrefPartRecordMatch(q);
                if (prMatches != null)
                    if (prMatches.Count > 0)
                    {
                        foreach (partrecord p in prMatches)
                            if (!ret.Contains(p))
                                ret.Add(p);
                    }

            }
            return ret;
        }


        public static List<partrecord> GetXrefPartRecordMatch(orddet_quote quote_line)
        {
            //In Memory list for partrecords matching selection criteris
            List<partrecord> ret = new List<partrecord>();
            List<string> optimalSearchStrings = new List<string>();


            //Get the best matching string combination available for the quote line
            string partSearchTerm = GetOptimalPartSearchString(quote_line);
            //strip common suffixes	
            string partSearchTermCleaned = StripCommonSuffixes(partSearchTerm);
            //List to hold the partrecordMatches
            List<partrecord> matchedPartRecords = new List<partrecord>();
            //List of partrecord StockTypes
            List<string> includedStockTypes = new List<string>() { "stock", "excess", "consign", "offer" };
            //Date parts created after	
            DateTime partrecordCreatedAfterDate = new DateTime(2016, 01, 01);
            //Get a list of all partrecords imported after selected date, and matching selected stocktype
            using (RzDataContext rdc = new RzDataContext())
            {
                ret = rdc.partrecords.Where(w => (w.fullpartnumber != null & w.fullpartnumber.Length > 0)
              && !w.fullpartnumber.ToLower().Contains("gcat")
              && w.date_created >= partrecordCreatedAfterDate
              && (w.prefix + w.basenumberstripped).Contains(partSearchTermCleaned)
              && includedStockTypes.Contains(w.stocktype.ToLower())).ToList();
            }


            return ret;
        }


        private static string GetOptimalPartSearchString(orddet_quote q)
        {
            //Comparison preference: 1) prefix+base, 2) part_number_stripped 3) fullPartnumber
            string partSearchTerm = q.fullpartnumber;
            string prefix = q.prefix;
            string baseStripped = q.basenumberstripped;
            string fullStripped = q.part_number_stripped;
            //Check for prefix_base	
            if (!string.IsNullOrEmpty(prefix) && !string.IsNullOrEmpty(baseStripped))
                partSearchTerm = prefix + baseStripped;
            //Check for part_number_stripped	
            else if (!string.IsNullOrEmpty(q.part_number_stripped))
                partSearchTerm = q.part_number_stripped;

            if (partSearchTerm.Length > 6)
                partSearchTerm = partSearchTerm.Substring(0, (partSearchTerm.Length - 1));
            return partSearchTerm;

        }

        // Define other methods and classes here
        private static string StripCommonSuffixes(string baseNumberStripped)
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


        public class InventoryCrossReferenceObject
        {
            public string partSearchTerm { get; set; }
            public string partSearchTermCleaned { get; set; }
            public List<partrecord> partrecordMatches { get; set; }
        }



        //Old Code

        public static List<partrecord> SearchPartsToList(Dictionary<string, string> dictParameters)
        {
            List<partrecord> ret = new List<partrecord>();
            string term = dictParameters["SearchTerm"];
            bool IncludeAllocated = Convert.ToBoolean(dictParameters["boolIncludeAllocated"]);
            bool IncludeStock = Convert.ToBoolean(dictParameters["boolIncludeStock"]);
            bool IncludeConsign = Convert.ToBoolean(dictParameters["boolIncludeConsign"]);
            bool IncludeExcess = Convert.ToBoolean(dictParameters["boolIncludeExcess"]);
            bool IncludeOffers = Convert.ToBoolean(dictParameters["boolIncludeOffers"]);
            string TheComparison = dictParameters["TheComparison"];

            List<string> stocktypesToInclude = new List<string>();
            if (IncludeStock)
                stocktypesToInclude.Add("stock");
            if (IncludeConsign)
                stocktypesToInclude.Add("consign");
            if (IncludeExcess)
                stocktypesToInclude.Add("excess");
            if (IncludeOffers)
                stocktypesToInclude.Add("offers");



            using (RzDataContext rdc = new RzDataContext())
            {
                var query = rdc.partrecords.Where(w => w.fullpartnumber.Contains(term) && stocktypesToInclude.Contains(w.stocktype.ToLower()));
                if (query.Any())
                {
                    if (!IncludeAllocated)
                        query = query.Where(w => w.quantity > w.quantityallocated);
                }


                foreach (partrecord p in query)
                    ret.Add(p);
            }



            return ret;
        }


        //Get best list of matches for a part.
        public static List<partrecord> GetRzPartMatchList(string partSearchString)
        {
            List<partrecord> ret = new List<partrecord>();

            List<string> includedStockTypes = new List<string>() { "stock", "consign", "excess" };
            using (RzDataContext rdc = new RzDataContext())
            {

                //ret = rdc.partrecords.Where(w => w.fullpartnumber.Trim().ToUpper() == partSearchString && (includedStockTypes.Contains(w.stocktype))).ToList();
                // ret = rdc.partrecords.Where(w => partList.Contains(w.fullpartnumber.Trim().ToUpper()) && (includedStockTypes.Contains(w.stocktype.ToLower()))).ToList();
                List<string> partList = partSearchString.Split(',').ToList(); // can be multiple parts here, need to check and split ot list.
                foreach (string s in partList)
                {
                    string prefix = "";
                    string baseNumber = "";
                    ParsePartNumber(s, ref prefix, ref baseNumber);
                    prefix = StripPart(prefix);
                    baseNumber = StripPart(baseNumber);                   

                    //paradigm
                    //" ( prefix like 'MT%' and basenumberstripped like '41K256M16HA125:E%' )"
                    //" alternatepartstripped like 'MT%41K256M16HA125:E%' "
                    //List<partrecord> matchesByStockType = rdc.partrecords.Where(w => w.fullpartnumber.Trim().ToUpper() == s && (includedStockTypes.Contains(w.stocktype.ToLower()))).ToList();
                    //List<partrecord> matchesByStockType = rdc.partrecords.Where(w => ((w.prefix.Contains(prefix) && w.basenumberstripped.Contains(baseNumber)) || (w.alternatepart.Contains(s))) && (includedStockTypes.Contains(w.stocktype.ToLower()))).ToList();

                    List<partrecord> matchesByStockType = rdc.partrecords.Where(w => ((w.prefix.Contains(prefix) && w.basenumberstripped.Contains(baseNumber)) || (w.alternatepart.Contains(s))) && (includedStockTypes.Contains(w.stocktype.ToLower()))).ToList();
                    if (matchesByStockType != null && matchesByStockType.Count > 0)
                        ret.AddRange(matchesByStockType);

                    //Offers in the last n (6) months.
                    List<partrecord> matchedRecentOffers = rdc.partrecords.Where(w => w.date_created >= DateTime.Today.AddMonths(-6) && w.stocktype == "Offers" && (w.prefix.Contains(prefix) && w.basenumberstripped.Contains(baseNumber))).ToList();
                    if (matchedRecentOffers.Count > 0)
                        ret.AddRange(matchedRecentOffers);
                }



            }

            return ret;
        }
    }
}
