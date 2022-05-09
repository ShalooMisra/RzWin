using Newtonsoft.Json;
using SensibleDAL.dbml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SensibleDAL
{
    public class SiliconExpertLogic
    {

        public enum SearchType
        {
            List = 0,
            Detail = 1
        }

        static public string UserName = "<redacted>";
        static public string Password = "<redacted>";



        public static HttpWebRequest Authenticate()
        {
            //Had to add this after getting "" errors when authenticatin g
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            return (HttpWebRequest)WebRequest.Create("https://app.siliconexpert.com/ProductAPI/search/authenticateUser?login=" + UserName + "&apiKey=" + Password);
        }

        public static bool HasValidXmlResults(string results)
        {
            string ret;
            StringReader rdr = new StringReader(results);
            XmlReader reader = XmlReader.Create(rdr);
            reader.ReadToFollowing("Success");
            ret = reader.ReadElementContentAsBoolean("Success", reader.NamespaceURI).ToString().ToLower();
            if (ret == "true")
                return true;
            else
                return false;

        }


        public DataSet GetListPartSearchDataSetXML(string part, bool fuzzy = false, int limit = 3)
        {
            //Clean the string
            part = part.Replace(" ", "").Trim();

            //Check for potential comma-separated list
            string[] splitStr = part.Split(',');

            //Convert the array into List<string>
            List<string> partList = new List<string>(splitStr);
            if (partList.Count() > limit)
            {
                //tools.HandleResult("fail", "Please limit your searches to " + limit + " parts or less per search.");
                //throw new Exception("Please limit your searches to "+ limit + " parts or less.");
                return null;
            }



            //Pass to main search function
            return GetListPartSearchDataSetXML(partList, fuzzy);
        }


        public static DataSet GetListPartSearchDataSetXML(List<string> partList, bool beginWith = false, string systemName = "Portal")
        {
            SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "SE List Search Started for Part Numbers: " + string.Join(",", partList), false, systemName);



            string searchMode = "beginwith";
            if (!beginWith)
                searchMode = "exact";


            DataSet ret = new DataSet();
            HttpWebRequest request = Authenticate();
            request.ContentType = "application/json; charset=utf-8";
            CookieContainer cookieContainer = request.CookieContainer = new CookieContainer();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //Part Detail Search url
                //Example:  https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=[{"partNumber":"bav99wt"},{"partNumber":"bav99"}]&mode=beginwith&pageNumber=1&fmt=xml

                //Parts limited to 50 per search.
                string partArray = SiliconExpertLogic.GeneratePartListSearchArrayString(partList.Take(50).ToList());
                string searchUrl = "https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=" + partArray + "&mode=" + searchMode + "&pageNumber=1&fmt=xml";
                //string searchUrl;
                //if (fuzzy)//Begin With            
                //    searchUrl = "https://app.siliconexpert.com/ProductAPI/search/partsearch?partNumber=" + part + "&mode=beginwith";
                //else//Exact Match            
                //    searchUrl = "https://app.siliconexpert.com/ProductAPI/search/partsearch?partNumber=" + part + "&mode=exact";//exact is default anyway
                ////searchUrl = "https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=" + part + "&mode=exact";//exact is default anyway


                request = (HttpWebRequest)WebRequest.Create(searchUrl);
                request.CookieContainer = cookieContainer;
            }
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {

                //Read Results
                Stream dataStream = response.GetResponseStream();
                string results = new StreamReader(dataStream, Encoding.UTF8).ReadToEnd();

                //Close, which also closes the dataStream object, so make sure that's read 1st.


                if (HasValidXmlResults(results))
                {

                    StringReader rdr = new StringReader(results);
                    XmlReader reader = XmlReader.Create(rdr);

                    //Convert Into Dataset & return           
                    ret.ReadXml(reader);
                }
            }
            string strSearchParts;
            if (partList.Count == 1)
                strSearchParts = partList[0];
            else
                strSearchParts = string.Join(",", partList);

            if (ret.Tables.Count > 1)
            {
                if (ret.Tables["PartDto"] != null)
                {
                    SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "SE List Search Completed for Part Numbers: " + strSearchParts,true, systemName);

                }

                return ret;
            }
            else
            {

                SystemLogic.Logs.LogEvent(SM_Enums.LogType.Information, "No tables found for Part Numbers: " + strSearchParts, true,systemName);
                return null;
            }

        }

        public static bool IsEnabled()
        {
            using (RzDataContext rdc = new RzDataContext())
                return rdc.system_managements.Where(w => w.system_name == "silicon_expert").Select(s => s.is_enabled ?? false).FirstOrDefault();
                
        }

        public class SiliconExpertMfgMatch
        {
            public string searchPart { get; set; }
            public string matchedPart { get; set; }
            public string matchedMfg { get; set; }
        }

        public static List<SiliconExpertMfgMatch> GetSiliconMfgMatchList(string searchPart)
        {
            List<SiliconExpertMfgMatch> ret = new List<SiliconExpertMfgMatch>();
            if (searchPart.Length >= 6)
                searchPart = searchPart.Substring(0, searchPart.Length - 2);//Take 2 off the end for better matching
            DataSet dsPartSearch = SiliconExpertLogic.GetListPartSearchDataSetXML(new List<string>() { searchPart }, true, "Rz");
            if (dsPartSearch == null)
                return ret;

            DataTable dtSiliconExpertMfgMatches = dsPartSearch.Tables["PartDto"];
            //Throw exception on null DataTable
            if (dtSiliconExpertMfgMatches == null)
                throw new Exception("Null PartDto table for " + searchPart);

            foreach (DataRow row in dtSiliconExpertMfgMatches.Rows)
            {
                SiliconExpertMfgMatch match = new SiliconExpertMfgMatch();
                match.searchPart = searchPart.Trim().ToUpper();
                match.matchedPart = row.Field<string>("PartNumber").Trim().ToUpper();
                match.matchedMfg = row.Field<string>("Manufacturer").Trim().ToUpper();
                ret.Add(match);
            }
            return ret;
        }



        public static async Task<DataSet> GetPnMfgDataSetSinglePart(partrecord p, bool exact)
        {

            //Using a list of Tuples here, since my Key and Values can be same.  I.e. company may need AT91SAM from Atmel and Intel, 
            //or need more than 1 part for a MFG, therefore neither value is guaranteed to be a unique dictionary key
            string username = "sensible_micro_production";
            string password = "14716281421";
            List<DataSet> dsList = new List<DataSet>();
            string mode = "exact";
            if (!exact)
                mode = "fuzzy";

            using (HttpClient client = new HttpClient())
            {

                //Set to allowe JSON Response
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header, force JSON
                                                                                                                 //Authenticate  
                HttpResponseMessage httpClienAuthtResponse = await client.GetAsync("https://app.siliconexpert.com/ProductAPI/search/authenticateUser?login=" + username + "&apiKey=" + password);

                //Get endpoint uri based on searchType  
                //https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=[{"partNumber":"bav99wt","manufacturer":"Nexperia"}]
                string endpointUrl = "https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=[{\"partNumber\":\"" + p.fullpartnumber.Trim() + "\",\"manufacturer\":\"" + p.manufacturer.Trim() + "a\"}]&fmt=json&mode=" + mode;

                //Retreive response                 
                DataSet ds = await GetPartSearchDataSetJSON(client, endpointUrl, 1);

                string status = ds.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Code")).FirstOrDefault();
                string statusMessage = ds.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Message")).FirstOrDefault();
                //code= 0 : success
                //code= 6 : wrong page number
                if (status != "0")
                {
                    Console.WriteLine("Silicon returned status: " + statusMessage + " for endpoint url: " + endpointUrl);
                    return null;
                }


                if (ds != null)
                    return ds;
                return null;

            }

        }
        public static async Task<List<DataSet>> GetPnMfgDataSetJSON(List<Tuple<string, string>> listPnMfg, bool exact)
        {

            //Using a list of Tuples here, since my Key and Values can be same.  I.e. company may need AT91SAM from Atmel and Intel, 
            //or need more than 1 part for a MFG, therefore neither value is guaranteed to be a unique dictionary key
            string username = "sensible_micro_production";
            string password = "14716281421";
            List<DataSet> dsList = new List<DataSet>();
            using (HttpClient client = new HttpClient())
            {

                //Set to allowe JSON Response
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header, force JSON
                                                                                                                 //Authenticate  
                HttpResponseMessage httpClienAuthtResponse = await client.GetAsync("https://app.siliconexpert.com/ProductAPI/search/authenticateUser?login=" + username + "&apiKey=" + password);

                //Get endpoint uri based on searchType
                //Split pars list into grops of 10, to attempt to avoif max url lenght. Iterate over each list for results.
                int partSearchIncrement = 10;
                int skipRange = 0;

                //1st search 
                List<Tuple<string, string>> searchList = listPnMfg.Skip(skipRange).Take(partSearchIncrement).Select(s => new Tuple<string, string>(s.Item1, s.Item2)).Distinct().ToList();
                string endpointUrl = GetEndpointUrl(searchList, exact);

                //Retreive response                 
                DataSet ds = await GetPartSearchDataSetJSON(client, endpointUrl, 1);

                string status = ds.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Code")).FirstOrDefault();
                string statusMessage = ds.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Message")).FirstOrDefault();
                //code= 0 : success
                //code= 6 : wrong page number
                if (status != "0")
                {
                    Console.WriteLine("Silicon returned status: " + statusMessage + " for endpoint url: " + endpointUrl);
                    return null;
                }

                int dataSetIndex = 0;
                if (ds != null)
                    dsList.Add(ds);
                while (status == "0")// Do this repeatedly until we've exhausted our list of parts.
                {
                    Console.WriteLine("Processing List Search DataSet " + dataSetIndex);
                    skipRange += partSearchIncrement;
                    if (skipRange >= listPnMfg.Count)//If there's less items than the skip range, don't skip any?
                        break;
                    //Skip the number of records we've successfully retrieved                        
                    List<Tuple<string, string>> newSearchList = listPnMfg.Skip(skipRange).Take(partSearchIncrement).Select(s => new Tuple<string, string>(s.Item1, s.Item2)).Distinct().ToList();
                    if (newSearchList != null && newSearchList.Count > 0)
                    {

                        endpointUrl = GetEndpointUrl(newSearchList, exact);
                        DataSet tempDS = await GetPartSearchDataSetJSON(client, endpointUrl, 1);
                        status = tempDS.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Code")).FirstOrDefault();
                        dsList.Add(tempDS);
                        dataSetIndex++;
                    }
                    else
                        continue;
                }

            }
            return dsList;
        }
        public static async Task<List<DataSet>> GetDataSetJSON(List<string> searchList, SearchType searchType, bool exact = false)
        {

            string username = "sensible_micro_production";
            string password = "14716281421";
            List<DataSet> dsList = new List<DataSet>();
            //Instantiate the client
            using (HttpClient client = new HttpClient())
            {

                //Set to allowe JSON Response
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header, force JSON
                                                                                                                 //Authenticate  
                HttpResponseMessage httpClienAuthtResponse = await client.GetAsync("https://app.siliconexpert.com/ProductAPI/search/authenticateUser?login=" + username + "&apiKey=" + password);

                //Get endpoint uri based on searchType
                //Split pars list into grops of 10, to attempt to avoif max url lenght. Iterate over each list for results.
                int partSearchIncrement = 10;
                int skipRange = 0;

                //1st search 
                string endpointUrl = GetEndpointUrl(searchList.Skip(skipRange).Take(partSearchIncrement).ToList(), searchType, exact);

                //Retreive response                 
                DataSet ds = await GetPartSearchDataSetJSON(client, endpointUrl, 1);




                string status = ds.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Code")).FirstOrDefault();
                string statusMessage = ds.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Message")).FirstOrDefault();
                //code= 0 : success
                //code= 6 : wrong page number
                if (status != "0")
                {
                    Console.WriteLine("Silicon returned status: " + statusMessage + " for endpoint url: " + endpointUrl);
                    return null;
                }

                int dataSetIndex = 0;


                if (ds != null)
                    dsList.Add(ds);

                while (status == "0")// Do this repeatedly until we've exhausted our list of parts.
                {

                    Console.WriteLine("Processing " + searchType + " DataSet " + dataSetIndex);
                    skipRange += partSearchIncrement;
                    if (skipRange >= searchList.Count)//If there's less items than the skip range, don't skip any?
                        break;
                    //Skip the number of records we've successfully retrieved                        
                    List<string> newSearchList = searchList.Skip(skipRange).Take(partSearchIncrement).ToList();
                    if (newSearchList != null && newSearchList.Count > 0)
                    {

                        endpointUrl = GetEndpointUrl(newSearchList, searchType, exact);
                        DataSet tempDS = await GetPartSearchDataSetJSON(client, endpointUrl, 1);
                        status = tempDS.Tables["Status"].AsEnumerable().Select(s => s.Field<string>("Code")).FirstOrDefault();
                        dataSetIndex++;
                        dsList.Add(tempDS);
                    }
                    else
                        continue;
                }

            }
            return dsList;
        }
        public static async Task<DataSet> GetPartSearchDataSetJSON(HttpClient client, string url, int pageNumber)
        {

            DataSet ret = null;
            url = url + "&pageNumber=" + pageNumber;
            HttpResponseMessage httpClientResponse = await client.GetAsync(url);
            //Force HTTPClient to fail if error response
            httpClientResponse.EnsureSuccessStatusCode();
            //Get the body into a string
            string responseBody = await httpClientResponse.Content.ReadAsStringAsync();
            //Read the json onto a DataSet           
            ret = ReadDataFromJson(responseBody);
            return ret;
        }

        private static string GetEndpointUrl(List<string> searchList, SearchType searchType, bool exact = false)
        {
            string mode = "beginwith";
            if (exact)
                mode = "exact";
            string ret = "";
            if (searchType == SearchType.List)
            { //Get Part Number array
                //string arrPartNumberList = GeneratePartListSearchArrayString(searchList.Take(50).ToList());
                string arrPartNumberList = GeneratePartListSearchArrayString(searchList.ToList());
                ret = "https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=" + arrPartNumberList + "&mode=" + mode;
            }
            else if (searchType == SearchType.Detail)
            {
                //Generate ComID Array                      string arrSearchList = GeneratePartListSearchArrayString(searchList.Take(50).ToList());
                string arrComIDList = string.Join(",", searchList);
                ret = "https://app.siliconexpert.com/ProductAPI/search/partDetail?comIds=" + arrComIDList;

            }

            return ret;
        }
        private static string GetEndpointUrl(List<Tuple<string, string>> dictPnMfg, bool exact)
        {
            string mode = "beginwith";
            if (exact)
                mode = "exact";
            string ret = "";
            //Get Part Number array
            //string arrPartNumberList = GeneratePartListSearchArrayString(searchList.Take(50).ToList());
            string arrPartNumberList = GeneratePartListSearchArrayString(dictPnMfg);
            ret = "https://app.siliconexpert.com/ProductAPI/search/listPartSearch?partNumber=" + arrPartNumberList + "&mode=" + mode;


            return ret;
        }



        private static DataSet ReadDataFromJson(string jsonString, XmlReadMode mode = XmlReadMode.Auto)
        {
            //KT since sometimes, things like History.DataSheet can come over like a single datasheet object, or an array of datasheets.
            //This method helps to handle 

            //// Note:Json convertor needs a json with one node as root
            jsonString = "{ \"rootNode\": {" + jsonString.Trim().TrimStart('{').TrimEnd('}') + @"} }";
            //// Now it is secure that we have always a Json with one node as root 
            var xd = JsonConvert.DeserializeXmlNode(jsonString);

            //// DataSet is able to read from XML and return a proper DataSet
            var result = new DataSet();
            result.ReadXml(new XmlNodeReader(xd), mode);
            return result;
        }
        private static string GeneratePartListSearchArrayString(List<Tuple<string, string>> listPnMfg)
        {

            //https://app.siliconexpert.com/SearchService/search/listPartSearch?partNumber=[{"partNumber":"bav99wt","manufacturer":"Nexperia"},{"partNumber":"bav99","manufacturer":"Vishay"}]&fmt=xml
            string ret = "[";
            foreach (Tuple<string, string> t in listPnMfg)
            {
                string part = t.Item1.ToUpper().Trim();
                string mfg = t.Item2.ToUpper().Trim();
                ret += "{\"partNumber\":\"" + Tools.Strings.FilterTrash(part) + "\",\"manufacturer\":\"" + Tools.Strings.FilterTrash(mfg) + "\"}";
                //string requiredForSomething = dictionary.Last().Value;
                if (t != listPnMfg.Last())
                    ret += ",";


            }
            ret += "]";
            return ret;
        }

        public static string GeneratePartListSearchArrayString(List<string> partList)
        {
            //[{"partNumber":"bav99wt"},{"partNumber":"bav99"}]
            string ret = "[";
            foreach (string s in partList)
            {
                //"#" tags can mess up SI query.  Just removing it breaks "beginwith", therfore, best to trum string after hash.
                string part = s;
                int hashIdx = s.IndexOf("#");
                if (hashIdx > 0)
                    part = s.Substring(0, hashIdx);
                //Similarly - & in parts are bad news.  Not valid Pn either, so remove them and everythign after.
                string[] splitPart = part.Split('&');
                part = splitPart[0];

                ret += "{\"partNumber\":\"" + part + "\"}";
                if (s != partList.Last())
                    ret += ",";
            }
            ret += "]";
            return ret;
        }


        [Serializable]
        public class PartRiskSummaryObject
        {

            //Company Data
            public string companyName { get; set; }
            public string companyId { get; set; }

            //Identifiers
            public string comID { get; set; }
            public int dtoID { get; set; }

            //SummaryData
            public string partNumber { get; set; }
            public string manufacturer { get; set; }
            public string eCCN { get; set; }
            public string partDescription { get; set; }
            public string LastCheckDate { get; set; } //can be either date or number like 90 (i.e. 90 days???)

            //Lifecycle
            public string estimatedYearsToEOL { get; set; }
            public string estimatedEOLDate { get; set; }
            public string partLifecycleStage { get; set; }
            public string lifeCycleRiskGrade { get; set; }
            public string overallRisk { get; set; }

            //PCN
            public string hasObsolescenceNotice { get; set; }
            public string hasNRNDNotice { get; set; }

            //RiskData           
            public string seGrade { get; set; } //Likliness of counterfeit

            //ProductImage
            public string ProductImageSmall { get; set; }
            public string ProductImageLarge { get; set; }

            //PricingData
            public string MinimumPrice { get; set; } //: Minimum Price according to SiliconExpert Resources.
            public string AveragePrice { get; set; } //: Average Price according to SiliconExpert Resources.
            public string MinLeadtime { get; set; } //: Minimum Lead Time according to SiliconExpert Resources.
            public string Maxleadtime { get; set; } //: Maximum Lead Time according to SiliconExpert Resources.
            public string LastUpdatedate { get; set; } //: Is the last updated date of component/EEE price.







        }



        public static List<PartRiskSummaryObject> GeneratePartRiskSummary(List<DataSet> dsList)
        {
            return GeneratePartRiskSummary(null, null, dsList);
        }

        public static List<PartRiskSummaryObject> GeneratePartRiskSummary(string company_id, string company_name, List<DataSet> dsList)
        {
            //Instantiate the Spreadsheet object


            List<PartRiskSummaryObject> listPrso = new List<PartRiskSummaryObject>();

            //ResultsDto table holds teh ResxultDto_ID, which is the foreign key to all other tables (some tabels call it ResultDto_id, other calli it <Table>_id i.e. ParametricData_Id
            //Dictionary to carry the comID and Dto_ID

            foreach (DataSet ds in dsList)
            {
                if (ds.Tables["ResultDto"] == null)
                    return null;


                //Keep this inside the foreach loop, else each dataset will keep adding to the dictionary, 
                Dictionary<string, int> dictComID_DtoID = new Dictionary<string, int>();

                foreach (DataRow dr in ds.Tables["ResultDto"].AsEnumerable())
                {

                    string comID = dr.Field<string>("RequestedComID");
                    int Dto_ID = dr.Field<int>("ResultDto_Id");
                    if (!dictComID_DtoID.ContainsKey(comID))
                        dictComID_DtoID.Add(comID, Dto_ID);
                }

                foreach (KeyValuePair<string, int> kvp in dictComID_DtoID)
                {

                    //Keys
                    string comID = kvp.Key;
                    int dtoID = kvp.Value;

                    //Part Risk Summary Object
                    PartRiskSummaryObject prso = new PartRiskSummaryObject();


                    //Variables
                    prso.comID = comID;
                    prso.dtoID = dtoID;
                    prso.hasObsolescenceNotice = "No";
                    prso.hasNRNDNotice = "No";
                    prso.seGrade = "";


                    //company
                    if (!string.IsNullOrEmpty(company_id) || !string.IsNullOrEmpty(company_name))
                    {
                        prso.companyId = company_id ?? "";
                        prso.companyName = company_name ?? "";
                    }

                    //SummaryData
                    if (ds.Tables["SummaryData"] != null)
                    {
                        DataRow rowSummaryData = ds.Tables["SummaryData"].AsEnumerable().Where(w => w.Field<int>("ResultDto_Id") == dtoID).FirstOrDefault();
                        if (rowSummaryData != null)
                        {
                            prso.partNumber = rowSummaryData.Field<string>("PartNumber");
                            prso.manufacturer = rowSummaryData.Field<string>("Manufacturer");
                            prso.eCCN = rowSummaryData.Field<string>("ECCN");
                            prso.partDescription = rowSummaryData.Field<string>("PartDescription");
                            prso.LastCheckDate = rowSummaryData.Field<string>("LastCheckDate");


                        }
                    }

                    //LifeCycleData
                    if (ds.Tables["LifeCycleData"] != null)
                    {
                        DataRow rowLifeCycleData = ds.Tables["LifeCycleData"].AsEnumerable().Where(w => w.Field<int>("ResultDto_Id") == dtoID).FirstOrDefault();
                        if (rowLifeCycleData != null)
                        {
                            prso.estimatedYearsToEOL = rowLifeCycleData.Field<string>("EstimatedYearsToEOL");
                            prso.estimatedEOLDate = rowLifeCycleData.Field<string>("EstimatedEOLDate");
                            prso.partLifecycleStage = rowLifeCycleData.Field<string>("PartLifecycleStage");
                            prso.lifeCycleRiskGrade = rowLifeCycleData.Field<string>("LifeCycleRiskGrade");
                            prso.overallRisk = rowLifeCycleData.Field<string>("OverallRisk");
                        }
                    }

                    //PCNDto
                    //Since can be many results in PCN, separate table (PCNData) holds the foreign key to the ResultDtoID, required for association.
                    if (ds.Tables["PCNData"] != null)
                    {
                        //API Note:  PCNDAtaID seems to map to a "Group" of rows, while the PCNDetials_ID maps to individual rows.  The latter echoes the former, thus we don't really need PCNDataId
                        int pcnDetailsID = ds.Tables["PCNDetails"].AsEnumerable().Where(w => w.Field<int>("ResultDto_Id") == dtoID).Select(s => s.Field<int>("PCNDetails_Id")).FirstOrDefault();
                        if (pcnDetailsID > 0)
                        {
                            DataTable dtPCNData = ds.Tables["PCNDto"].AsEnumerable().Where(w => w.Field<int?>("PCNDetails_Id") == pcnDetailsID).CopyToDataTable();
                            if (dtPCNData != null)
                            {

                                //if TypeOfChange.COntains ("obsolescence")                    
                                List<string> typesOfChange = dtPCNData.AsEnumerable().Select(s => s.Field<string>("TypeOfChange").ToLower()).ToList();
                                if (typesOfChange.Contains("obsolescence"))
                                    prso.hasObsolescenceNotice = "Yes";
                                if (typesOfChange.Contains("not recommended for new design"))
                                    prso.hasNRNDNotice = "Yes";
                            }
                        }
                    }


                    //SummaryData
                    if (ds.Tables["ProductImage"] != null)
                    {
                        DataTable dtProductImage = null;
                        if (ds.Tables["ProductImage"].AsEnumerable().Where(w => w.Field<int?>("ResultDto_Id") == dtoID).Any())
                            dtProductImage = ds.Tables["ProductImage"].AsEnumerable().Where(w => w.Field<int?>("ResultDto_Id") == dtoID).CopyToDataTable();
                        if (dtProductImage != null)
                        {
                            //Looks like they have 1 large and 1 small per part MAX, so don't need list.
                            string smallImageUrl = dtProductImage.AsEnumerable().Select(s => s.Field<string>("ProductImageSmall").ToLower()).FirstOrDefault();
                            string largeImageUrl = dtProductImage.AsEnumerable().Select(s => s.Field<string>("ProductImageLarge").ToLower()).FirstOrDefault();
                            prso.ProductImageLarge = largeImageUrl;
                            prso.ProductImageSmall = smallImageUrl;
                        }

                    }

                    //RiskData
                    if (ds.Tables["RiskData"] != null)
                    {
                        DataRow rowRiskData = ds.Tables["RiskData"].AsEnumerable().Where(w => w.Field<int>("ResultDto_Id") == dtoID).FirstOrDefault();
                        if (rowRiskData != null)
                        {
                            prso.seGrade = rowRiskData.Field<string>("SEGrade");
                        }
                    }


                    //PricingData
                    if (ds.Tables["PricingData"] != null)
                    {
                        DataRow rowPricingData = ds.Tables["PricingData"].AsEnumerable().Where(w => w.Field<int>("ResultDto_Id") == dtoID).FirstOrDefault();
                        if (rowPricingData != null)
                        {

                            prso.MinimumPrice = rowPricingData.Field<string>("MinimumPrice");
                            prso.AveragePrice = rowPricingData.Field<string>("AveragePrice");
                            prso.MinLeadtime = rowPricingData.Field<string>("MinLeadtime");
                            prso.Maxleadtime = rowPricingData.Field<string>("Maxleadtime");
                            prso.LastUpdatedate = rowPricingData.Field<string>("LastUpdatedate");
                        }
                    }


                    //Add to list
                    listPrso.Add(prso);
                }
            }
            return listPrso;
        }


        public static async Task<DataTable> GetTopCustomerPartRiskAnalysis(int companyCount)
        {
            string outPutStatusMsg = "";

            if (companyCount > 21)
                throw new Exception("This system does not currently support more thatn 20 companies at a time.");
            try
            {

                //Get a Dictionary<company, Dictionary<string,string> Partnumbers, Mfg
                Dictionary<company, List<Tuple<string, string>>> dictCompanyAndPnMfg = new Dictionary<company, List<Tuple<string, string>>>();
                //Get A dictionary of Total Sales by Company
                Dictionary<string, double> invoiceCompanyTotals = new Dictionary<string, double>();
                //Instantiate the DataTable outside the loop
                DataTable DTResults = new DataTable();
                using (RzDataContext rdc = new RzDataContext())
                {
                    int yearsAgo = 1;
                    //test: 'TRW Automotive (College Road UK)' = "b910c97222004b27a21a4b98fce45fd2"
                    //test: 'KeyTronic Corporation [WA]'  = "215BA5DD-DA05-4B60-B045-4A3052B2EC8B" //LOTS Of lines. 
                    //invoiceCompanyTotals = rdc.ordhed_invoices.Where(w => w.base_company_uid == "215BA5DD-DA05-4B60-B045-4A3052B2EC8B" && (w.base_company_uid ?? "").Length > 0 && w.orderdate >= DateTime.Now.AddYears(-yearsAgo)).GroupBy(x => x.base_company_uid).Select(g => new
                    invoiceCompanyTotals = rdc.ordhed_invoices.Where(w => (w.base_company_uid ?? "").Length > 0 && w.orderdate >= DateTime.Now.AddYears(-yearsAgo)).GroupBy(x => x.base_company_uid).Select(g => new
                    {
                        company_id = g.Key,
                        total_sales = g.Sum(x => x.ordertotal > 0 ? x.ordertotal : 0) ?? 0
                    }).OrderByDescending(o => o.total_sales).Take(companyCount).ToDictionary(d => d.company_id, d => d.total_sales);
                    outPutStatusMsg += OutputStatus("Running Part Risk Analysis for the following (" + invoiceCompanyTotals.Keys.Count + ") companies:");
                    outPutStatusMsg += OutputStatus(Environment.NewLine);


                    List<company> companyList = rdc.companies.Where(w => invoiceCompanyTotals.Keys.ToList().Contains(w.unique_id)).ToList();
                    foreach (company c in companyList)
                    {
                        outPutStatusMsg += OutputStatus(c.companyname);
                    }

                    foreach (KeyValuePair<string, double> kvp in invoiceCompanyTotals)
                    {
                        string companyID = kvp.Key;
                        if (!string.IsNullOrEmpty(companyID))
                        {
                            company c = rdc.companies.Where(w => w.unique_id == companyID).FirstOrDefault();
                            if (c != null)
                            {
                                double totalInvoiced = kvp.Value;
                                outPutStatusMsg += OutputStatus("Processing: " + c.companyname + "  " + totalInvoiced.ToString("C"));

                                List<Tuple<string, string>> tupLinePnMfgCombined = new List<Tuple<string, string>>();

                                List<Tuple<string, string>> tupLinePnMfg = rdc.orddet_lines
                                    .Where(w => w.customer_uid == companyID
                                    && w.date_created >= DateTime.Today.AddYears(-yearsAgo)
                                    && w.fullpartnumber.Length > 0
                                    && w.fullpartnumber != null
                                    && !w.fullpartnumber.ToLower().Contains("gcat"))
                                     .Select(t => new Tuple<string, string>(t.fullpartnumber.Trim().ToUpper(), t.manufacturer.Trim().ToUpper()))
                                    .ToList();
                                outPutStatusMsg += OutputStatus("Total Sales Lines: " + tupLinePnMfg.Count);
                                //loop and add only unique combinations
                                foreach (Tuple<string, string> tup in tupLinePnMfg)
                                {
                                    if (!tupLinePnMfgCombined.Contains(tup))
                                        tupLinePnMfgCombined.Add(tup);
                                }
                                outPutStatusMsg += OutputStatus("Unique Pn/Mfg combinations count: " + tupLinePnMfgCombined.Count);

                                List<Tuple<string, string>> tupQuotePnMfg = rdc.orddet_quotes
                                    .Where(w => w.base_company_uid == companyID
                                    && w.date_created >= DateTime.Today.AddYears(-yearsAgo)
                                    && w.fullpartnumber.Length > 0 && w.fullpartnumber != null
                                    && !w.fullpartnumber.ToLower().Contains("gcat"))
                                    .Select(t => new Tuple<string, string>(t.fullpartnumber.Trim().ToUpper(), t.manufacturer.Trim().ToUpper()))
                                    .ToList();
                                outPutStatusMsg += OutputStatus("Total Req Lines: " + tupQuotePnMfg.Count);
                                //loop and add only unique combinations
                                foreach (Tuple<string, string> tup in tupQuotePnMfg)
                                {
                                    if (!tupLinePnMfgCombined.Contains(tup))
                                        tupLinePnMfgCombined.Add(tup);
                                }
                                outPutStatusMsg += OutputStatus("Unique Pn/Mfg combinations count: " + tupLinePnMfgCombined.Count);


                                //List<Tuple<string, string>> tupLinePnMfgCombined = tup.Union(dictQuotePnMfg).ToDictionary(d => d.Key, d => d.Value);
                                outPutStatusMsg += OutputStatus("Total unique combined Lines: " + tupLinePnMfgCombined.Count);
                                if (tupLinePnMfgCombined.Count <= 0 || tupLinePnMfgCombined == null)
                                {
                                    outPutStatusMsg += OutputStatus("No parts found for " + c.companyname);
                                    continue;
                                }

                                if (!dictCompanyAndPnMfg.ContainsKey(c))
                                    dictCompanyAndPnMfg.Add(c, tupLinePnMfgCombined);
                            }

                        }
                    }
                    if (dictCompanyAndPnMfg.Count <= 0)
                    {
                        outPutStatusMsg += OutputStatus("No companies with parts found to search.  Nothing to do.  Ending.");
                        return null;
                    }
                    int totalParts = dictCompanyAndPnMfg.Values.Sum(x => x.Count);
                    outPutStatusMsg += OutputStatus("Dictionary has " + totalParts + " distinct part numbers.");
                    outPutStatusMsg += OutputStatus(Environment.NewLine);


                    //Start Time to Monitor time Taken
                    DateTime start = DateTime.Now;
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    decimal elapsedSeconds = sw.ElapsedMilliseconds / 1000;
                    outPutStatusMsg += OutputStatus("API Query Start: " + start.ToShortDateString() + "_" + start.ToLongTimeString());
                    outPutStatusMsg += OutputStatus(Environment.NewLine);

                    //Loop through the Dictionary
                    foreach (KeyValuePair<company, List<Tuple<string, string>>> kvp in dictCompanyAndPnMfg)
                    {
                        company comp = kvp.Key;
                        outPutStatusMsg += OutputStatus("Line count: " + kvp.Value.Count);
                        outPutStatusMsg += OutputStatus("Performing initial List search for " + comp.companyname + ".....");
                        //Do a part search for the ComIDs
                        List<DataSet> dsPartSearch = await GetPnMfgDataSetJSON(kvp.Value, false);
                        if (dsPartSearch == null)
                            continue;

                        if (dsPartSearch[0].Tables["PartDto"] == null)
                            continue;
                        outPutStatusMsg += OutputStatus("List search returned " + dsPartSearch.Count.ToString() + " DataSets earch with a max of 10 parts per dataset (to keep api url short).");
                        //Get The ComId list for the returned parts
                        List<string> listComIds = new List<string>();
                        foreach (DataSet ds in dsPartSearch)
                        {
                            if (ds.Tables["PartDto"] != null)
                            {
                                List<string> comIdList = ds.Tables["PartDto"].AsEnumerable().Select(s => s.Field<string>("ComID").Trim()).ToList();
                                if (comIdList != null && comIdList.Count > 0)
                                    listComIds.AddRange(comIdList);
                            }

                        }
                        listComIds = listComIds.Distinct().ToList();
                        if (listComIds == null)
                            continue;
                        outPutStatusMsg += OutputStatus("Total ComIds found for all DataSets: " + listComIds.Count);
                        outPutStatusMsg += OutputStatus("List search complete.... ");


                        outPutStatusMsg += OutputStatus("Beginning Detail search for " + comp.companyname + " ...");
                        List<DataSet> siDetailDataSetList = await SiliconExpertLogic.GetDataSetJSON(listComIds, SiliconExpertLogic.SearchType.Detail);
                        if (siDetailDataSetList == null)
                            continue;
                        outPutStatusMsg += OutputStatus("Detail search complete.");
                        outPutStatusMsg += OutputStatus("Generating Part Risk Summary Report for " + comp.companyname + ".");
                        List<SiliconExpertLogic.PartRiskSummaryObject> listPrso = SiliconExpertLogic.GeneratePartRiskSummary(comp.unique_id, comp.companyname, siDetailDataSetList);
                        outPutStatusMsg += OutputStatus("Risk Summary Report complete.  " + listPrso.Count + " results.");
                        //Build the DataTable
                        outPutStatusMsg += OutputStatus("Generating resulting DataTable ...");
                        DataTable tempDT = Tools.Lists.ToDataTable<SiliconExpertLogic.PartRiskSummaryObject>(listPrso);
                        if (tempDT == null)
                        {
                            outPutStatusMsg += OutputStatus("Error generating PartRiskSummaryObject DataTable.  Temp table was Null.");
                            continue;
                        }
                        DTResults.Merge(tempDT);
                        outPutStatusMsg += OutputStatus(tempDT.Rows.Count + " rows added to the results DataTable.");
                        outPutStatusMsg += OutputStatus(DateTime.Now.ToString() + "  " + comp.companyname + " complete. ");
                        outPutStatusMsg += OutputStatus("Elapsed time: " + GetElapsedTime(sw).ToString() + " seconds.");
                        outPutStatusMsg += OutputStatus(Environment.NewLine);

                    }
                    sw.Stop();
                    outPutStatusMsg += OutputStatus(DateTime.Now.ToString() + "  API Query Complete.");
                    outPutStatusMsg += OutputStatus("Total Elapsed Time: " + GetElapsedTime(sw).ToString() + " seconds.");


                }
                if (DTResults.Rows.Count > 0)
                {
                    outPutStatusMsg += OutputStatus("Saving Results to Database: ");
                    SiliconExpertLogic.SavePartRiskSummaryDatatableToDataBase(DTResults);
                    outPutStatusMsg += OutputStatus("Success:  " + DTResults.Rows.Count + " rows added to database.");
                }


                return DTResults;
            }
            catch (Exception ex)
            {
                outPutStatusMsg += OutputStatus("Error: " + ex.Message);
                //writer.Close();
                //ostrm.Close();
                return null;
            }

        }
        private static string OutputStatus(string msg)
        {
            Console.WriteLine(msg);
            return msg;
        }

        private static decimal GetElapsedTime(Stopwatch sw)
        {
            decimal dec = sw.ElapsedMilliseconds / 1000;
            dec = Math.Round(dec, 2);
            return dec;

        }


        private static string GetSavePath(string fileName, string extension)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Csv_Exports\\";

            if (!Directory.Exists(path))  // if it doesn't exist, create
                Directory.CreateDirectory(path);
            path = path + fileName + "_export." + extension;
            return path;
        }



        public static void SavePartRiskSummaryDatatableToDataBase(DataTable dTResults)
        {
            using (RzDataContext rdc = new RzDataContext())
            {
                int batchID = (rdc.part_risk_summaries.Max(s => s.batch_id) ?? 0) + 1;
                foreach (DataRow row in dTResults.Rows)
                {
                    part_risk_summary prs = new part_risk_summary();
                    rdc.part_risk_summaries.InsertOnSubmit(prs);
                    prs.unique_id = Guid.NewGuid().ToString();
                    prs.date_created = DateTime.Now;
                    prs.date_modified = DateTime.Now;
                    prs.icon_index = 0;
                    prs.grid_color = 0;
                    prs.batch_id = batchID;
                    prs.companyName = row["companyName"].ToString();
                    prs.companyId = row["companyId"].ToString();
                    prs.comID = row["comID"].ToString();
                    prs.dtoID = row["dtoID"].ToString();
                    prs.partNumber = row["partNumber"].ToString();
                    prs.manufacturer = row["manufacturer"].ToString();
                    prs.eCCN = row["eCCN"].ToString();
                    prs.partDescription = row["partDescription"].ToString();
                    prs.LastCheckDate = row["LastCheckDate"].ToString();
                    prs.estimatedYearsToEOL = row["estimatedYearsToEOL"].ToString();
                    prs.estimatedEOLDate = row["estimatedEOLDate"].ToString();
                    prs.partLifecycleStage = row["partLifecycleStage"].ToString();
                    prs.lifeCycleRiskGrade = row["lifeCycleRiskGrade"].ToString();
                    prs.overallRisk = row["overallRisk"].ToString();
                    prs.hasObsolescenceNotice = row["hasObsolescenceNotice"].ToString();
                    prs.hasNRNDNotice = row["hasNRNDNotice"].ToString();

                    prs.ProductImageSmall = row["ProductImageSmall"].ToString();
                    prs.ProductImageLarge = row["ProductImageLarge"].ToString();
                    //Risk Data
                    prs.seGrade = row["seGrade"].ToString();
                    //Pricing Data
                    prs.MinimumPrice = row["MinimumPrice"].ToString();
                    prs.AveragePrice = row["AveragePrice"].ToString();
                    prs.MinLeadtime = row["MinLeadtime"].ToString();
                    prs.Maxleadtime = row["Maxleadtime"].ToString();
                    prs.LastUpdatedate = row["LastUpdatedate"].ToString();



                }

                rdc.SubmitChanges();
            }
        }


        //public static async Task<List<string>> GetComIdsForPNAndMfg(Dictionary<string, string> dictPnMfg)
        //{
        //    DataTable ret = new DataTable();
        //    string outPutStatusMsg = "";
        //    //Get a list of the partNumbers for a list search
        //    List<string> listPartNumbers = dictPnMfg.Keys.Distinct().ToList();
        //    //Perform List Search on the part Numbers (Free) which will return PartNumber, MFG, and ComIDs
        //    List<DataSet> dsListPartSearch = await SiliconExpertLogic.GetPartSearchDataSetJSON(listPartNumbers, SiliconExpertLogic.SearchType.List, true);
        //    if (dsListPartSearch == null)
        //        return null;

        //    if (dsListPartSearch[0].Tables["PartDto"] == null)
        //        return null;

        //    ret = dsListPartSearch[0].Tables["PartDto"].Clone();

        //    outPutStatusMsg += OutputStatus("List search returned " + dsListPartSearch.Count.ToString() + " DataSets earch with a max of 10 parts per dataset (to keep api url short).");

        //    //Loop through the Dictionary, identify Comids from the dataset that match the pn/mfg comb
        //    List<string> listComIds = new List<string>();
        //    foreach (KeyValuePair<string, string> kvp in dictPnMfg)
        //    {
        //        string strPN = kvp.Key;
        //        string strMfg = kvp.Value;

        //        //The result could be in any of the datasets, therefore loop
        //        foreach (DataSet ds in dsListPartSearch)
        //        {
        //            foreach (DataRow row in ds.Tables["PartDto"].Rows)
        //            {
        //                string rowPn = row.Field<string>("PartNumber");
        //                string rowMfg = row.Field<string>("Manufacturer");
        //                string rowComID = row.Field<string>("ComID");
        //                if (rowPn == strPN && rowMfg == strMfg)
        //                {
        //                    listComIds.Add(rowComID);
        //                }
        //            }
        //        }
        //    }
        //    return listComIds;
        //}

        //private static void MergeDataTables(DataSet ds, DataSet tempDS)
        //{
        //    string currentTableName = "";
        //    try
        //    {


        //        foreach (DataTable table in tempDS.Tables)
        //        {
        //            currentTableName = table.TableName;
        //            if (ds.Tables.Contains(currentTableName))
        //            {
        //                if (table.Columns.Count == ds.Tables[currentTableName].Columns.Count)//Sometimes, we get different columns for same tables, i.e. PackageData, sometimes only returns 2 columns.  If columns don't match, merge will fail.
        //                    ds.Tables[currentTableName].Merge(table);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string message = ex.Message + ": " + currentTableName;
        //    }
        //}



    }
}
