using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HubspotApis
{
    public class HubspotApi
    {


        //Common Classes
        public class Associations
        {
            public List<long> associatedCompanyIds { get; set; }
            public List<long> associatedVids { get; set; }
            public List<long> associatedDealIds { get; set; }
        }



        //These are useful for GET classes, but for posting, need to use Dictionary<string, Object>
        public class Property
        {
            //public string property { get; set; } //needed for contact creation
            public string name { get; set; } //needed for engagement creation
            public string value { get; set; }
        }


        public class PropertyValues
        {
            public string value { get; set; }
            public long timestamp { get; set; }
            public string source { get; set; }
            public string sourceId { get; set; }
            public List<Version> versions { get; set; }
        }



        public class Version
        {
            public string name { get; set; }
            public string value { get; set; }
            public long timestamp { get; set; }
            public string source { get; set; }
            public List<object> sourceVid { get; set; }
        }



        //End Common Classes

        //Owner
        public class Owner
        {
            public long portalId { get; set; }
            public long ownerId { get; set; }
            public string type { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public long createdAt { get; set; }
            public long updatedAt { get; set; }
            public List<Property> properties { get; set; }
            public bool hasContactsAccess { get; set; }
            //Custom Properties
            public string ownerName { get; set; }
        }


        //End Owner


        //Engagement


        public class EngagementRoot
        {
            public List<Engagement> engagements { get; set; }
            public bool hasMore { get; set; }
            public int offset { get; set; }
            public long total { get; set; }
        }


        public class Engagement
        {
            public EngagementDetail engagement { get; set; }
            public EngagementAssociations associations { get; set; }
            public Metadata metadata { get; set; }
            public List<long> attachments { get; set; }
            public List<object> scheduledTasks { get; set; }

        }


        public class EngagementAssociations
        {
            public List<long> contactIds { get; set; }
            public List<long> companyIds { get; set; }
            public List<string> dealIds { get; set; }
            public List<string> ownerIds { get; set; }
            public List<string> workflowIds { get; set; }
            public List<string> ticketIds { get; set; }


        }



        public class EngagementDetail
        {
            public long id { get; set; }
            public long portalId { get; set; }
            public bool active { get; set; }
            public object createdAt { get; set; }
            public object lastUpdated { get; set; }
            public long ownerId { get; set; }
            public string type { get; set; }
            public string uid { get; set; }
            public object timestamp { get; set; }
            //Custom Properties     
            public string ownerName { get; set; }
            public string companyName { get; set; }
            public string contactName { get; set; }
        }


        public class From
        {
            public string raw { get; set; }
            public string email { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }

        public class To
        {
            public string raw { get; set; }
            public string email { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
        }



        public class Metadata
        {
            public string toNumber { get; set; }
            public string fromNumber { get; set; }
            public string status { get; set; }
            public string externalId { get; set; }
            public long durationMilliseconds { get; set; }
            public string externalAccountId { get; set; }
            public string recordingUrl { get; set; }
            public string body { get; set; }
            public string disposition { get; set; }
            public From from { get; set; }
            public List<To> to { get; set; }
            public List<object> cc { get; set; }
            public List<object> bcc { get; set; }
            public string subject { get; set; }
            public string html { get; set; }
            public string text { get; set; }
            public string trackerKey { get; set; }
            public string messageId { get; set; }
            public string threadId { get; set; }
            public string loggedFrom { get; set; }
        }

        //End Engagement


        //Company      
        public class Company
        {

            [JsonProperty("portalId")]
            public long portalId { get; set; }
            [JsonProperty("companyId")]
            public long companyId { get; set; }
            [JsonProperty("isDeleted")]
            public bool isDeleted { get; set; }
            [JsonProperty("properties")]
            public Dictionary<string, PropertyValues> Properties { get; set; }
            [JsonProperty("additionalDomains")]
            public List<object> additionalDomains { get; set; }
            [JsonProperty("stateChanges")]
            public List<object> stateChanges { get; set; }
            [JsonProperty("mergeAudits")]
            public List<object> mergeAudits { get; set; }
        }

        public class Offset
        {
            [JsonProperty("companyId")]
            public long companyId { get; set; }
            [JsonProperty("isPrimary")]
            public bool isPrimary { get; set; }
        }
        //End Company






        public class FormSubmission
        {
            [JsonProperty("conversion-id")]
            public string conversionId { get; set; }
            [JsonProperty("timestamp")]
            public long timestamp { get; set; }
            [JsonProperty("form-id ")]
            public string formId { get; set; }
            [JsonProperty("portal-id")]
            public long portalId { get; set; }
            [JsonProperty("page-url")]
            public string pageUrl { get; set; }
            [JsonProperty("title")]
            public string title { get; set; }
            [JsonProperty("form-type")]
            public string formType { get; set; }
            [JsonProperty("meta-data")]
            public List<object> metaData { get; set; }
        }

        public class ListMembership
        {
            [JsonProperty("static-list-id")]
            public long staticListId { get; set; }
            [JsonProperty("internal-list-id")]
            public long internalListId { get; set; }
            [JsonProperty("timestamp")]
            public object timestamp { get; set; }
            [JsonProperty("vid")]
            public long vid { get; set; }
            [JsonProperty("is-member")]
            public bool isMember { get; set; }
        }



        public class Identity
        {
            [JsonProperty("type")]
            public string type { get; set; }
            [JsonProperty("value")]
            public string value { get; set; }
            [JsonProperty("timestamp")]
            public object timestamp { get; set; }
            [JsonProperty("is-primary")]
            public bool? isPrimary { get; set; }
        }



        public class IdentityProfile
        {
            [JsonProperty("vid")]
            public long vid { get; set; }
            [JsonProperty("saved-at-timestamp")]
            public long savedAtTimestamp { get; set; }
            [JsonProperty("deleted-changed-timestamp")]
            public long deletedChangedTimestamp { get; set; }
            [JsonProperty("identities")]
            public List<Identity> identities { get; set; }
        }

        //Contact


        //public class ContactProperties
        //{
        //    public string property { get; set; }
        //    public string value { get; set; }
        //}

        //public class Contact
        //{
        //    public List<Property> properties { get; set; }
        //}
        public class Contact
        {
            [JsonProperty("vid")]
            public long vid { get; set; }
            [JsonProperty("canonical-vid")]
            public long canonicalVid { get; set; }
            [JsonProperty("merged-vids")]
            public List<object> mergedVids { get; set; }
            [JsonProperty("portal-id")]
            public long portalId { get; set; }
            [JsonProperty("is-contact")]
            public bool isContact { get; set; }
            [JsonProperty("profile-token")]
            public string profileToken { get; set; }
            [JsonProperty("profile-url")]
            public string profileUrl { get; set; }
            //[JsonProperty("properties")]
            //public Dictionary<string, ContactProperty> Properties { get; set; } // Icouldn't use the exisign Property class, because it needs to be "property, value" instead of name, value


            [JsonProperty("properties")]
            //[JsonExtensionData]
            public Dictionary<string, PropertyValues> Properties { get; set; }

            [JsonProperty("form-submissions")]
            public List<FormSubmission> formSubmissions { get; set; }
            [JsonProperty("list-memberships")]
            public List<ListMembership> listMemberships { get; set; }
            [JsonProperty("identity-profiles")]
            public List<IdentityProfile> identityProfiles { get; set; }
            [JsonProperty("merge-audits")]
            public List<object> mergeAudits { get; set; }
            [JsonProperty("associated-company")]
            public Company associatedCompany { get; set; }

            public Contact UpdateContact(Dictionary<string, string> dictProps, long contactID)
            {

                dynamic d = new ExpandoObject();


                List<ContactProperty> props = new List<ContactProperty>();
                foreach (KeyValuePair<string, string> kvp in dictProps)
                {
                    props.Add(new ContactProperty { property = kvp.Key, value = kvp.Value });
                }

                d.properties = props;
                //Udpate Properties
                ////api.hubapi.com/contacts/v1/contact/vid/2340324/profile?hapikey=demo
                string url = @"https://api.hubapi.com/contacts/v1/contact/vid/" + contactID + "/profile?" + AppendAuthorization();
                Post(d, url);
                //return Updated Deal           
                Contact c = JsonConvert.DeserializeObject<Contact>(responseDetails);
                return c;
            }
        }

        public class ContactProperty
        {
            public string property { get; set; }
            public string value { get; set; }
        }
        //End Contact


        //Deal      
        public class Deal
        {
            public long portalId { get; set; }
            public long dealId { get; set; }
            public bool isDeleted { get; set; }
            public Associations associations { get; set; }
            [JsonProperty("properties")]
            //[JsonExtensionData]
            public Dictionary<string, PropertyValues> properties { get; set; }
            //public List<Property> properties { get; set; }
            public List<object> imports { get; set; }
            public List<object> stateChanges { get; set; }

            public static List<Deal> GetDealsUpdatedSince(DateTime fromDate, int minutesAgo)
            {
                List<Deal> ret = new List<Deal>();


                return ret;
            }
        }



        public class DealList
        {
            public List<Deal> deals { get; set; }
            public bool hasMore { get; set; }
            public long offset { get; set; }
        }
        //End Deal



        //Pipeline
        public class DealStage
        {
            public bool active { get; set; }
            public bool closedWon { get; set; }
            public int displayOrder { get; set; }
            public string label { get; set; }
            public double probability { get; set; }
            public string stageId { get; set; }

            public static Dictionary<string, string> CurrentDealStages = Deals.GetCurrentDealStages().Select(s => new { s.label, s.stageId }).ToDictionary(d => d.label, d => d.stageId);

            public static string rfq_received = "814ab36e-d1ed-48d4-9f30-105c4900733c";
            public static string formal_quote_created = "2267768a-a7c8-4d12-a80e-21e3462efefa";
            public static string sale_won = "9cd6365b-1f57-4685-aa0f-41e1a4ca2a15";
            public static string sale_lost = "e97cd1b9-b203-4cd1-9b3f-f6dc266dc285";

            public string GetDealStageID(string pipeline, string dealName)
            {
                return CurrentDealStages.Select(s => s.Value.ToString()).FirstOrDefault();
            }

            public string GetDealStageName(string pipeline, string dealId)
            {
                return CurrentDealStages.Where(w => w.Value.ToLower() == dealId.ToLower()).Select(s => s.Key.ToString()).FirstOrDefault();
            }
        }

        public class Pipeline
        {
            public bool active { get; set; }
            public int displayOrder { get; set; }
            public string label { get; set; }
            public string pipelineId { get; set; }
            public List<DealStage> stages { get; set; }

            public static Dictionary<string, string> CurrentPipelines = Deals.GetAllPipelines().Select(s => new { s.label, s.pipelineId }).ToDictionary(d => d.label, d => d.pipelineId);
            public static string sales_pipeline = "default";

            public string GetPipelineID(string pipelineName)
            {
                string ret = CurrentPipelines.Where(w => w.Key == pipelineName.ToLower()).Select(s => s.Value.ToString()).FirstOrDefault();
                return ret;
            }
            public string GetPipelineName(string pipelineId)
            {
                string ret = CurrentPipelines.Where(w => w.Value == pipelineId).Select(s => s.Key.ToString()).FirstOrDefault();
                return ret;
            }
        }

        public class PipelineName
        {
            private PipelineName(string value) { Value = value; }

            public string Value { get; set; }

            public static PipelineName Quote { get { return new PipelineName("bb901f63-4781-471c-b955-2d0f8c0ea029"); } }
            public static PipelineName Sales { get { return new PipelineName("default"); } }

        }






        //End Pipeline



        //HubDB

        public class HubDB
        {
            [JsonProperty("objects")]
            public List<HubDBTable> Tables { get; set; }
            [JsonProperty("total")]
            public long Total { get; set; }
            [JsonProperty("limit")]
            public int Limit { get; set; }
            [JsonProperty("offset")]
            public int Offset { get; set; }
            [JsonProperty("message")]
            public object Message { get; set; }
            [JsonProperty("totalCount")]
            public long TotalCount { get; set; }
        }
        public class HubDBTable
        {
            [JsonProperty("id")]
            public long Id { get; set; }
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("portalId")]
            public long PortalId { get; set; }
            [JsonProperty("createdAt")]
            public long CreatedAt { get; set; }
            [JsonProperty("publishedAt")]
            public long PublishedAt { get; set; }
            [JsonProperty("updatedAt")]
            public long UpdatedAt { get; set; }
            [JsonProperty("columns")]
            public List<Column> Columns { get; set; }
            [JsonProperty("updated")]
            public long Updated { get; set; }
            [JsonProperty("cosObjectType")]
            public string CosObjectType { get; set; }
            [JsonProperty("deleted")]
            public bool Deleted { get; set; }
            [JsonProperty("label")]
            public string Label { get; set; }
            [JsonProperty("cdnPurgeEmbargoTime")]
            public object CdnPurgeEmbargoTime { get; set; }
            [JsonProperty("rowCount")]
            public long RowCount { get; set; }
            [JsonProperty("createdBy")]
            public CreatedBy CreatedBy { get; set; }
            [JsonProperty("updatedBy")]
            public UpdatedBy UpdatedBy { get; set; }
            [JsonProperty("useForPages")]
            public bool UseForPages { get; set; }
            [JsonProperty("allowChildTables")]
            public bool AllowChildTables { get; set; }
            [JsonProperty("enableChildTablePages")]
            public bool EnableChildTablePages { get; set; }
            [JsonProperty("dynamicMetaTags")]
            public Dictionary<string, string> DynamicMetaTags { get; set; }
            [JsonProperty("columnCount")]
            public long ColumnCount { get; set; }
            [JsonProperty("allowPublicApiAccess")]
            public bool AllowPublicApiAccess { get; set; }
        }
        public class Column
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("label")]
            public string Label { get; set; }
            [JsonProperty("id")]
            public long Id { get; set; }
            [JsonProperty("deleted")]
            public bool Deleted { get; set; }
            [JsonProperty("foreignIdsByName")]
            public Dictionary<string, string> ForeignIdsByName { get; set; }
            [JsonProperty("foreignIdsById")]
            public Dictionary<string, string> ForeignIdsById { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
        }
        public class CreatedBy
        {
            [JsonProperty("id")]
            public long Id { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
        }
        public class UpdatedBy
        {
            [JsonProperty("id")]
            public long Id { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
        }




        //Table Rows
        public class HubDbRows
        {
            [JsonProperty("objects")]
            public List<HubDbRow> Rows { get; set; }
            [JsonProperty("total")]
            public long Total { get; set; }
            [JsonProperty("limit")]
            public int Limit { get; set; }
            [JsonProperty("offset")]
            public int Offset { get; set; }
            [JsonProperty("message")]
            public object Message { get; set; }
            [JsonProperty("totalCount")]
            public long TotalCount { get; set; }
        }
        public class HubDbRow
        {
            [JsonProperty("id")]
            public long Id { get; set; }
            [JsonProperty("createdAt")]
            public long CreatedAt { get; set; }
            [JsonProperty("path")]
            public object Path { get; set; }
            [JsonProperty("name")]
            public object Name { get; set; }
            [JsonProperty("values")]
            public Values values { get; set; }
            [JsonProperty("isSoftEditable")]
            public bool IsSoftEditable { get; set; }
            [JsonProperty("childTableId")]
            public long ChildTableId { get; set; }
        }

        public class Values
        {
            [JsonProperty("2")]
            public string two { get; set; }
            [JsonProperty("3")]
            public string three { get; set; }
            [JsonProperty("4")]
            public object four { get; set; }
            [JsonProperty("5")]
            public string five { get; set; }
            [JsonProperty("6")]
            public object six { get; set; }
            [JsonProperty("7")]
            public string seven { get; set; }
            [JsonProperty("8")]
            public string eight { get; set; }
            [JsonProperty("9")]
            public string nine { get; set; }
            [JsonProperty("10")]
            public string ten { get; set; }
            [JsonProperty("11")]
            public string eleven { get; set; }
        }

        public class HubDbGraphic
        {
            [JsonProperty("url")]
            public string Url { get; set; }
            [JsonProperty("width")]
            public int Width { get; set; }
            [JsonProperty("height")]
            public int Height { get; set; }
            [JsonProperty("type")]
            public string Type { get; set; }
        }



        //End HubDB

        //Custom Classes

        public class HubResponseError
        {
            public string status { get; set; }
            public string message { get; set; }
            public string correlationId { get; set; }
            public string requestId { get; set; }
        }


        public class HubPhoneCall
        {
            public string toNumber { get; set; }
            public long timestamp { get; set; }
            public string fromNumber { get; set; }
            public string status { get; set; }
            public string externalId { get; set; }
            public long durationMilliseconds { get; set; }
            public string ownerEmailAddress { get; set; }
            public string externalAccountId { get; set; }
            public string contactEmailAddress { get; set; }
            public string companyWebAddress { get; set; }
            public string body { get; set; }

            public static class Disposition
            {
                public static string NoAnswer = "73a0d17f-1163-4015-bdd5-ec830791da20";
                public static string Busy = "9d9162e7-6cf3-4944-bf63-4dff82258764";
                public static string WrongNumber = "17b47fee-58de-441e-a44c-c6300d46f273";
                public static string LeftLiveMessage = "a4c4c377-d246-4b32-a13b-75a56a4cd0ff";
                public static string LeftVoicemail = "b2cf5968-551e-4856-9783-52b3da59a7d0";
                public static string Connected = "f240bbac-87c9-4f6e-bf70-924b57d47db7";
            }

            public static string GetDispositionName(string dispID)
            {
                switch (dispID)
                {
                    case "73a0d17f-1163-4015-bdd5-ec830791da20":
                        return "NoAnswer";
                    case "9d9162e7-6cf3-4944-bf63-4dff82258764":
                        return "Busy";
                    case "17b47fee-58de-441e-a44c-c6300d46f273":
                        return "WrongNumber";
                    case "a4c4c377-d246-4b32-a13b-75a56a4cd0ff":
                        return "LeftLiveMessage";
                    case "b2cf5968-551e-4856-9783-52b3da59a7d0":
                        return "LeftVoicemail";
                    case "f240bbac-87c9-4f6e-bf70-924b57d47db7":
                        return "Connected";
                    default:
                        return null;

                }
            }
        }



        public class CurrentUsage
        {
            public string name { get; set; }
            public long usageLimit { get; set; }
            public long currentUsage { get; set; }
            public long collectedAt { get; set; }
            public string fetchStatus { get; set; }
            public long resetsAt { get; set; }
        }

        public class Api
        {
            public static CurrentUsage GetCurrentDailyUsage()
            {


                string url = @"https://api.hubapi.com/integrations/v1/limit/daily?" + AppendAuthorization();
                GetHubspotResponse(url);
                if (string.IsNullOrEmpty(responseString))
                    throw new Exception("Invalid ResponseString in GetCurrentDailyUsage");
                List<CurrentUsage> cuList = JsonConvert.DeserializeObject<List<CurrentUsage>>(responseString);
                CurrentUsage cu = cuList[0];
                return cu;



            }


            //Unix TimeStamp Conversions
            private static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
            {
                return UnixEpoch.AddMilliseconds(unixTimeStamp);
            }
            public static long GetCurrentUnixTimestampMillis()
            {
                return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
            }
            public static DateTime DateTimeESTFromUnixTimestampMillis(long millis)
            {
                DateTime dtUTC = UnixEpoch.AddMilliseconds(millis);
                var easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime dtEST = TimeZoneInfo.ConvertTimeFromUtc(dtUTC, easternZone);
                return dtEST;
            }
            public long GetCurrentUnixTimestampSeconds()
            {
                return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
            }
            public DateTime DateTimeFromUnixTimestampSeconds(long seconds)
            {
                return UnixEpoch.AddSeconds(seconds);
            }





        }


        public class Engagements
        {

            public static string GetEngagementParams(Dictionary<string, string> urlParameters)
            {
                return null;
            }

            public static EngagementRoot GetRecentEngagements(long sinceDate, int offset, int limit = 100)
            {
                //example:https://api.hubapi.com/engagements/v1/engagements/recent/modified?hapikey=demo&count=2&since=1483246800000           
                //GET /engagements/v1/engagements/associated/:objectType/:objectId/paged
                //Has a max Value of 100, so have to iterate
                //EngagementRoot ret = new EngagementRoot();
                DateTime nonUnixDate = DateTimeFromUnixTimestampMillis(sinceDate);



                string url = baseUrl + @"engagements/v1/engagements/recent/created";
                url += "?" + AppendAuthorization();
                //url += @"&count=100";
                //long unixDate = ConvertDateTimeToUnixTimestampMillis(sinceDate);
                url += @"&since=" + sinceDate;
                if (limit > 0)
                    url += @"&count=" + limit;
                if (offset > 0)
                    url += @"&offset=" + offset;
                GetHubspotResponse(url);
                if (string.IsNullOrEmpty(responseString))
                    return null;
                return GetEngagementRootObject();
            }

            public static Engagement GetEngagementById(long hubspotID)
            {
                //throw new NotImplementedException();
                //UNTESTED 
                //https://api.hubapi.com/engagements/v1/engagements/51484873?hapikey=demo
                Engagement ret = new Engagement();
                string url = baseUrl + @"engagements/v1/engagements/" + hubspotID;
                url += "?" + AppendAuthorization();
                GetHubspotResponse(url);
                if (ResponseError != null)
                {
                    //if (ResponseError.status == "error")
                    return null;
                }

                if (string.IsNullOrEmpty(responseString))
                    return null;
                //JResults = GetArray(responseString);
                //if (JResults == null)
                //    return null;

                JObject o = GetJObjectFromJSON(responseString);
                Engagement eng = o.ToObject<Engagement>();//JsonConvert.DeserializeObject<Engagement>(responseString);
                if (eng != null)
                    return eng;

                return null;

            }



            public static EngagementRoot GetAllEngagements(int offSet = 0, int limit = 0)
            {
                //EngagementRoot ret = new EngagementRoot();
                string url = baseUrl + @"engagements/v1/engagements/paged";
                url += "?" + AppendAuthorization();
                if (limit > 0)
                    url += @"&limit=" + limit;
                url += @"&offset=" + offSet;
                GetHubspotResponse(url);
                if (string.IsNullOrEmpty(responseString))
                    return null;
                return GetEngagementRootObject();

            }



            private static EngagementRoot GetEngagementRootObject()
            {
                //hopefully these will help handle null values, because for some reason respnseString may come back as "", which can't convert to int32
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                EngagementRoot ret = JsonConvert.DeserializeObject<EngagementRoot>(responseString, settings);

                ret.engagements = new List<Engagement>();
                JResults = GetArray(responseString);
                if (JResults != null)
                {
                    foreach (JObject o in JResults.Children())
                    {
                        try
                        {
                            Engagement eng = o.ToObject<Engagement>();
                            ret.engagements.Add(eng);
                        }
                        catch (Exception ex)
                        {
                            string error = ex.Message;
                        }


                    }
                }

                return ret;
            }







            public static Engagement CreateHubspotEngagement(string engagementType, string notes, Contact hubContact)
            {
                Engagement ret = null;
                switch (engagementType)
                {


                    default:
                        {
                            ret = CreateHubspotEngagement_Note("quote_requested", "Quote requested for " + notes, hubContact);
                            break;
                        }


                }

                return ret;
            }



            public static Engagement CreateHubspotEngagement(string engagementType, Dictionary<string, string> engagementProperties, Contact hubspotContact)
            {
                Engagement ret = null;
                switch (engagementType)
                {
                    case "task":
                        {
                            ret = CreateHubspotEngagement_Task(engagementProperties, hubspotContact);
                            break;
                        }

                }

                return ret;

            }



            private static Engagement CreateHubspotEngagement_Task(string type, string notes, Contact hubContact)
            {
                if (hubContact == null)
                    return null;

                //Rz - Consider setting the hubspot dealId on the phonecall record on success.
                string url = @"https://api.hubapi.com/engagements/v1/engagements?" + AppendAuthorization();
                dynamic d = new ExpandoObject();
                Engagement e = new Engagement();
                List<long> contactIDs = new List<long>();
                contactIDs.Add(hubContact.vid);
                //Associations
                d.associations = new EngagementAssociations();
                d.associations.contactIds = contactIDs;


                //Engagement Data
                d.engagement = new Dictionary<string, string>();
                d.engagement.Add("active", "true");
                string ownerID = null;
                if (hubContact.Properties.ContainsKey("hubspot_owner_id"))
                {
                    ownerID = hubContact.Properties["hubspot_owner_id"].value;
                    if (!string.IsNullOrEmpty(ownerID))
                        d.engagement.Add("ownerId", ownerID);
                }
                d.engagement.Add("type", "TASK");
                d.engagement.Add("timestamp", GetCurrentUnixTimestampMillis().ToString());

                //metadata:
                d.metadata = new Dictionary<string, string>();
                d.metadata.Add("body", notes ?? "");
                d.metadata.Add("subject", "Quote Requested");
                d.metadata.Add("status", "NOT_STARTED");
                d.metadata.Add("forObjectType", "CONTACT");

                Post(d, url);

                e = JsonConvert.DeserializeObject<Engagement>(responseDetails);
                return e;
            }


            private static Engagement CreateHubspotEngagement_Task(Dictionary<string, string> engagementProperties, Contact hubContact)
            {
                if (hubContact == null)
                    return null;
                string taskType = engagementProperties["taskType"];
                if (string.IsNullOrEmpty(taskType))
                    return null;

                switch (taskType)
                {
                    case "portalQuote":
                        {
                            return CreateQuoteEngagement(engagementProperties, hubContact);

                        }

                    default:
                        return null;
                }



            }

            private static Engagement CreateQuoteEngagement(Dictionary<string, string> engagementProperties, Contact hubContact)
            {
                //Rz - Consider setting the hubspot dealId on the phonecall record on success.
                //Vriables
                string url = @"https://api.hubapi.com/engagements/v1/engagements?" + AppendAuthorization();
                dynamic d = new ExpandoObject();
                Engagement e = new Engagement();
                List<long> contactIDs = new List<long>();

                string partNumber = engagementProperties["partNumber"] ?? "Not Provided";
                string custEmail = engagementProperties["custEmail"] ?? "Not Provided";
                string custPhone = engagementProperties["custPhone"] ?? "Not Provided";
                string targetPrice = engagementProperties["targetPrice"] ?? "Not Provided";
                string quoteQty = engagementProperties["quoteQty"] ?? "Not Provided";
                string quoteNotes = engagementProperties["quoteNotes"] ?? "Not Provided";

                StringBuilder body = new StringBuilder();
                body.Append(@"<b>Part Number: </b>" + partNumber);
                body.Append(@"<br />");
                body.Append(@"<b>Email: </b>" + custEmail);
                body.Append(@"<br />");
                body.Append(@"<b>Phone: </b>" + custPhone);
                body.Append(@"<br />");
                body.Append(@"<b>Target Price: </b>" + targetPrice);
                body.Append(@"<br />");
                body.Append(@"<b>Qty: </b>" + quoteQty);
                body.Append(@"<br />");
                body.Append(@"<b>Notes: </b>" + quoteNotes);
                body.Append(@"<br />");


                contactIDs.Add(hubContact.vid);
                //Associations
                d.associations = new EngagementAssociations();
                d.associations.contactIds = contactIDs;

                //Engagement Data
                d.engagement = new Dictionary<string, string>();
                d.engagement.Add("active", "true");
                string ownerID = null;
                if (hubContact.Properties.ContainsKey("hubspot_owner_id"))
                {
                    ownerID = hubContact.Properties["hubspot_owner_id"].value;
                    if (!string.IsNullOrEmpty(ownerID))
                        d.engagement.Add("ownerId", ownerID);
                }
                d.engagement.Add("type", "TASK");
                d.engagement.Add("timestamp", GetCurrentUnixTimestampMillis().ToString());

                //metadata:
                d.metadata = new Dictionary<string, string>();
                d.metadata.Add("body", body.ToString() ?? "");
                d.metadata.Add("subject", "Quote Requested");
                d.metadata.Add("status", "NOT_STARTED");
                d.metadata.Add("forObjectType", "CONTACT");

                Post(d, url);

                e = JsonConvert.DeserializeObject<Engagement>(responseDetails);
                return e;
            }


            public static Engagement CreateHubspotEngagement_Note(string type, string notes, Contact hubContact)
            {
                // Engagement ret = null;


                //Rz - Consider setting the hubspot dealId on the phonecall record on success.
                string url = @"https://api.hubapi.com/engagements/v1/engagements?" + AppendAuthorization();
                dynamic d = new ExpandoObject();
                Engagement e = new Engagement();

                //List<int> companyIDs = new List<int>();
                List<long> contactIDs = new List<long>();
                //Company comp = null;
                Contact cont = hubContact;

                //Owner o = GetOwnerByEmail()
                //string ownerID = cont.Properties.Where(w => w.Key == "hubspot_owner_id").Select(s => s.Value).ToString();
                string ownerID = cont.Properties["hubspot_owner_id"].value;
                if (string.IsNullOrEmpty(ownerID))
                    return null;
                //ownerID = o.ownerId.ToString();

                //if (!string.IsNullOrEmpty(hp.companyWebAddress))
                //    comp = GetCompaniesByDomain(hp.companyWebAddress).FirstOrDefault();

                //if (!string.IsNullOrEmpty(hp.contactEmailAddress))
                //    cont = GetContactByEmail(hp.contactEmailAddress);

                //Associations

                d.associations = new EngagementAssociations();
                //if (comp != null)
                //{
                //    companyIDs.Add(comp.companyId);
                //    d.associations.companyIds = companyIDs;
                //}

                if (cont != null)
                {
                    d.associations.contactIds = contactIDs;
                    contactIDs.Add(cont.vid);
                }

                d.engagement = new Dictionary<string, string>();
                d.engagement.Add("active", "true");
                d.engagement.Add("ownerId", ownerID);
                d.engagement.Add("type", "NOTE");
                d.engagement.Add("timestamp", GetCurrentUnixTimestampMillis().ToString());


                //metadata:
                d.metadata = new Dictionary<string, string>();
                d.metadata.Add("body", notes ?? "");


                Post(d, url);

                e = JsonConvert.DeserializeObject<Engagement>(responseDetails);
                return e;

                // Post(d, url);

                //return ret;
            }


            public static void DeleteHubspotEngagements(List<long> hubIdsToDelete)
            {
                foreach (long i in hubIdsToDelete)
                    DeleteHubspotEngagement(i);
            }

            private static void DeleteHubspotEngagement(long i)
            {
                DeleteEngagement(i);
            }

            public static Engagement CreateHubspotCall(HubPhoneCall hp)
            {
                //Rz - Consider setting the hubspot dealId on the phonecall record on success.
                string url = @"https://api.hubapi.com/engagements/v1/engagements?" + AppendAuthorization();
                dynamic d = new ExpandoObject();
                Engagement e = new Engagement();

                List<long> companyIDs = new List<long>();
                List<long> contactIDs = new List<long>();
                Company comp = null;
                Contact cont = null;

                Owner o = Owners.GetOwnerByEmail(hp.ownerEmailAddress);
                string ownerID = null;
                if (o != null)
                    ownerID = o.ownerId.ToString();

                if (!string.IsNullOrEmpty(hp.companyWebAddress))
                    comp = Companies.GetCompaniesByDomain(hp.companyWebAddress).FirstOrDefault();

                if (!string.IsNullOrEmpty(hp.contactEmailAddress))
                    cont = Contacts.GetContactByEmail(hp.contactEmailAddress);

                //Associations

                d.associations = new EngagementAssociations();
                if (comp != null)
                {
                    companyIDs.Add(comp.companyId);
                    d.associations.companyIds = companyIDs;
                }

                if (cont != null)
                {
                    d.associations.contactIds = contactIDs;
                    contactIDs.Add(cont.vid);
                }

                d.engagement = new Dictionary<string, string>();
                d.engagement.Add("active", "true");
                d.engagement.Add("ownerId", ownerID ?? "");
                d.engagement.Add("type", "CALL");
                d.engagement.Add("timestamp", hp.timestamp.ToString());


                //metadata:
                d.metadata = new Dictionary<string, string>();
                d.metadata.Add("toNumber", hp.toNumber ?? "");
                d.metadata.Add("fromNumber", hp.fromNumber ?? "");
                d.metadata.Add("status", hp.status ?? "");
                d.metadata.Add("externalId", hp.externalId ?? "");
                d.metadata.Add("durationMilliseconds", (hp.durationMilliseconds * 1000).ToString() ?? "");
                d.metadata.Add("externalAccountId", hp.externalAccountId ?? "");
                //d.metadata.Add("disposition", HubPhoneCall.Disposition.Connected);
                d.metadata.Add("body", hp.body ?? "");

                Post(d, url);

                e = JsonConvert.DeserializeObject<Engagement>(responseDetails);
                return e;
            }




            public static void DeleteEngagement(long hubID)
            {
                //DELETE /engagements/v1/engagements/:engagementId
                //api.hubapi.com/engagements/v1/engagements/74?hapikey=demo
                string url = baseUrl + "engagements/v1/engagements/" + hubID + "?" + AppendAuthorization();
                try
                {

                    using (var httpClient = new HttpClient())
                    {
                        HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                        if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                            return;
                        responseString = response.ToString();
                        //responseDetails = response.Content.ReadAsStringAsync().Result;
                        //JObject jo = JObject.Parse(responseDetails);
                        //responseString += responseString + Environment.NewLine + jo.ToString();

                    }
                }
                catch (Exception ex)
                {

                }

            }



            public static string GetEngagementsUrl(Dictionary<string, string> urlParameters)
            {
                string ret = baseUrl + "engagements/v1/engagements/associated/";
                if (urlParameters.ContainsKey("vid"))
                    ret += "COMPANY/" + urlParameters["vid"].Trim() + "/";
                return ret;
            }

            public static string EngagementAppendCompany(string companyID)
            {
                return "COMPANY/" + companyID + "/";
            }
            //End Engagement Methods



        }

        public class HubDBs
        {
            //HubDB Methods
            public static HubDB GetHubDbObject()
            {
                string url = @"https://api.hubapi.com/hubdb/api/v2/tables?" + AppendAuthorization();
                GetHubspotResponse(url);
                HubDB hubDB = JsonConvert.DeserializeObject<HubDB>(responseString);
                return hubDB;
            }

            public static List<HubDBTable> GetAllHubDBTables()
            {
                List<HubDBTable> ret = new List<HubDBTable>();

                HubDB db = GetHubDbObject();

                foreach (HubDBTable t in db.Tables)
                {
                    ret.Add(t);
                }
                return ret;
            }

            public static HubDbRows GetHubDBTableRows(string tableID)
            {

                string url = @"https://api.hubapi.com/hubdb/api/v2/tables/" + tableID + "/rows?portalId=1878634";
                GetHubspotResponse(url);
                //Hubspot Rows contain "Values".  Values are a Dictionary of KeyValuePairs<string,string> 
                //where they "Key" is the column number, and the "Value" is the column's "Data",
                //i.e. <"2","158762"> would be column 2, adword is 158762
                HubDbRows rows = JsonConvert.DeserializeObject<HubDbRows>(responseString);
                return rows;
            }

            public static string BuildHubDBRowString(string rowValuesJson)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("{");
                sb.Append("\"values\": ");
                sb.Append(rowValuesJson);
                //close the parent request
                sb.Append("}");
                string s = sb.ToString();
                return s;
            }


            //end HubDb Methods

        }






        public class Companies
        {
            //Company Methods
            public static List<Company> GetCompaniesByDomain(string domain)
            {
                //Example POST URL:
                //https://api.hubapi.com/companies/v2/domains/hubspot.com/companies?hapikey=demo
                //https://api.hubapi.com/companies/v2/domains/TRW.COM/companies?hapikey=56650273-6f78-4b25-9280-a47f25c423c8
                List<Company> cList = new List<Company>();
                domain = CheckStringForDomain(domain);
                if (string.IsNullOrEmpty(domain))
                    return null;
                //throw new Exception("Domain not found for company.");

                string url = @"https://api.hubapi.com/companies/v2/domains/" + domain + "/companies?" + AppendAuthorization();
                string data = "{\"limit\": 2,\"requestOptions\": {\"properties\":[\"domain\", \"hubspot_owner_id\",\"createdate\",\"name\",\"hs_lastmodifieddate\",\"zip\",\"country\",\"notes_last_updated\",\"website\",\"address\",\"city\",\"state\",\"timezone\",\"description\",\"industry\",\"numberofemployees\",\"numberofemployees\",\"first_contact_createdate\",\"total_revenue\",\"lifecyclestage\"]},\"offset\": {\"isPrimary\":true,\"companyId\":0}}";
                //JObject o = JObject.Parse(data);

                Post(data, url);
                string status = responseDetails;
                string error = ResponseError.message;
                if (string.IsNullOrEmpty(error))//success
                { // get JSON result objects into a list          
                    dynamic json = JToken.Parse(responseDetails);
                    foreach (JToken result in json["results"])
                    {
                        // JToken.ToObject is a helper method that uses JsonSerializer internally
                        Company c = result.ToObject<Company>();
                        cList.Add(c);
                    }

                }

                return cList;
            }

            public static Company GetCompanyByID(long id)
            {
                if (id == 0)
                    return null;
                Company c = new Company();
                string url = @"https://api.hubapi.com/companies/v2/companies/" + id.ToString();
                url += "?" + AppendAuthorization();
                GetHubspotResponse(url);
                if (ResponseError != null)
                {
                    return null;
                }

                c = JsonConvert.DeserializeObject<Company>(responseString);
                return c;

            }



            //End Company Methods
        }

        public class Contacts
        {
            //Contact Methods    
            public class ContactSource
            {
                public static string PortalQuote = "PortalQuote";
                public static string PortalRegister = "PortalRegister";
                public static string RzDealCreated = "RzDealCreated"; // can be portal OR rz

            }



            public static string GetContactUrl(Dictionary<string, string> urlParameters)
            {
                //Example GET URL:
                //https://api.hubapi.com/contacts/v1/contact/email/testingapis@hubspot.com/profile?hapikey=demo
                string ret = baseUrl + "contacts/v1/contact/email/" + urlParameters["email"].Trim() + "/profile";
                return ret;
            }




            public static Contact GetContactByEmail(string email, bool paged = true, int limit = 100)
            {
                Contact c = null;
                //if (string.IsNullOrEmpty(email))            
                Dictionary<string, string> parameters = new Dictionary<string, string>() { { "email", email } };
                GetHubspotResponse("contact", true, parameters, limit);
                if (ResponseError != null)
                    return null;
                c = JsonConvert.DeserializeObject<Contact>(responseString);
                //Since most of the properties won't match up with the names of my classes (hyphens are not allowed in C#), I may need to manually map
                return c;
            }

            public static Contact GetContactByID(long id)
            {

                //https://api.hubapi.com/contacts/v1/contact/vid/3234574/profile?hapikey=demo            
                Contact c = new Contact();
                string url = @"https://api.hubapi.com/contacts/v1/contact/vid/" + id.ToString() + "/profile";
                url += "?" + AppendAuthorization();
                GetHubspotResponse(url);
                c = JsonConvert.DeserializeObject<Contact>(responseString);
                return c;
            }

            //public static Contact CreateHubspotContact(string customerEmail, string firstName = null, string lastName = null, ContactSource source = null)
            //{
            //    //This is consumed by Portal Search
            //    Contact ret = new Contact();
            //    string url = @"https://api.hubapi.com/contacts/v1/contact/?" + AppendAuthorization();

            //    dynamic d = new ExpandoObject();
            //    //Properties
            //    d.properties = new List<ContactProperty>();
            //    d.properties.Add(new ContactProperty { property = "email", value = customerEmail });
            //    if (!string.IsNullOrEmpty(firstName))
            //        d.properties.Add(new ContactProperty { property = "firstName", value = firstName });
            //    if (!string.IsNullOrEmpty(lastName))
            //        d.properties.Add(new ContactProperty { property = "lastName", value = lastName });
            //    Post(d, url);
            //    if (responseDetails.Contains("error"))
            //        ret = null;
            //    else
            //        ret = JsonConvert.DeserializeObject<Contact>(responseDetails);
            //    return ret;
            //}


            public static Contact CreateHubspotContact(Dictionary<string, string> properties, string contactSource)
            {
                //This is consumed By Rz
                dynamic d = new ExpandoObject();


                //Properties
                List<ContactProperty> contactProps = new List<ContactProperty>();
                contactProps.Add(new ContactProperty { property = "contact_source", value = contactSource });
                foreach (KeyValuePair<string, string> kvp in properties)
                {
                    contactProps.Add(new ContactProperty { property = kvp.Key, value = kvp.Value });
                }

                d.properties = contactProps;
                //Post
                PostContact(d);
                //Return Object
                Contact ret = JsonConvert.DeserializeObject<Contact>(responseDetails);
                return ret;
            }

            public static void PostContact(object o)
            {
                //https://api.hubapi.com/contacts/v1/contact/?hapikey=demo
                string url = @"https://api.hubapi.com/contacts/v1/contact/?" + AppendAuthorization();
                string jsonBody = GetObjectString(o);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                    responseString = response.ToString();
                    responseDetails = response.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(responseDetails);
                    responseString += responseString + Environment.NewLine + jo.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        Contact c = JsonConvert.DeserializeObject<Contact>(responseDetails);
                        responseString = "Contact with vid " + c.vid + " succcessfully created.";
                    }



                }
            }

            //End Contact Methods
        }

        public class Owners
        {
            //Owner Methods


            public static string GetOwnerUrl(Dictionary<string, string> urlParameters)
            {
                string ret = baseUrl + "owners/v2/owners/";
                return ret;
            }

            public static string GetOwnerParameters(Dictionary<string, string> urlParameters)
            {
                return @"&email=" + urlParameters["email"];
            }


            public static List<Owner> GetOwnersByEmail(Dictionary<string, string> parameters, bool paged = true, int limit = 100)
            {
                //Example URL: http://api.hubapi.com/owners/v2/owners?hapikey=demo
                List<Owner> oList = new List<Owner>();
                GetHubspotResponse("owner", true, parameters, limit);

                // results = GetArray(responseString);
                JResults = GetArray(responseString);
                if (JResults == null)
                    return null;
                foreach (JObject jo in JResults)
                {
                    Owner o = jo.ToObject<Owner>();
                    oList.Add(o);

                }

                return oList;
            }



            public static Owner GetOwnerByEmail(string email)
            {

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                parameters.Add("email", email);

                Owner ret = null;
                List<Owner> oList = GetOwnersByEmail(parameters);
                if (oList.Count == 0)
                {
                    return null;
                }

                if (oList.Count > 1)
                {

                }
                ret = oList[0];
                return ret;
            }

            public static Owner GetOwnerByID(long ownerID)
            {
                string url = @"http://api.hubapi.com/owners/v2/owners/" + ownerID + "?" + AppendAuthorization();
                GetHubspotResponse(url);
                Owner o = JsonConvert.DeserializeObject<Owner>(responseDetails);
                if (o != null)
                    return o;
                return null;

            }



            public static List<Owner> GetAllOwners()
            {
                //Example URL: http://api.hubapi.com/owners/v2/owners?hapikey=demo
                List<Owner> oList = new List<Owner>();

                string url = @"http://api.hubapi.com/owners/v2/owners" + "?" + AppendAuthorization();

                GetHubspotResponse(url);
                oList = JsonConvert.DeserializeObject<List<Owner>>(responseDetails);
                return oList;
            }

            public static List<Owner> GetOwners(List<long> ownerIdList)
            {
                //Use list to get owner objects list      
                List<Owner> ret = new List<Owner>();
                foreach (long i in ownerIdList)
                {
                    if (!ret.Select(s => s.ownerId).ToList().Contains(i))
                    {
                        Owner o = GetOwnerByID(i);
                        if (!string.IsNullOrEmpty(o.email))
                            ret.Add(o);
                    }

                }

                return ret;
            }

            public static Owner GetOwnerOfHubspotCompany(List<long> associatedCompanyIds)
            {
                //Get any related companies in a list, usually only 1 for a deal anyway but ...
                List<Company> hsCompanies = new List<Company>();
                foreach (long i in associatedCompanyIds)
                {
                    Company c = Companies.GetCompanyByID(i);
                    if (c != null && !hsCompanies.Any(s => s.companyId == c.companyId))
                        hsCompanies.Add(c);
                }
                if (hsCompanies.Count == 0)
                    return null;
                //For not just use the 1st company
                Company cc = hsCompanies[0];
                long ownerID = cc.Properties.Where(w => w.Key == "hubspot_owner_id").Select(s => Convert.ToInt64(s.Value.value)).FirstOrDefault();
                if (ownerID == 0)
                    return null;
                return GetOwnerByID(ownerID);
            }

            public static Owner GetOwnerOfHubspotCompany(object associatedCompanyIds)
            {
                throw new NotImplementedException();
            }




            //End Owner Methods
        }


        public class Deals
        {
            //Deal Methods

            public static string GetDealUrl(Dictionary<string, string> urlParameters)
            {

                //https://api.hubapi.com/deals/v1/deal/associated/contact/1002325/paged?hapikey=demo&includeAssociations=true&limit=10&properties=dealname       
                string ret = baseUrl + "deals/v1/deal/associated/";
                if (urlParameters.ContainsKey("companyID"))
                    ret += "company/" + urlParameters["ownerID"].Trim();
                if (urlParameters.ContainsKey("contactID"))
                    ret += "contact/" + urlParameters["contactID"].Trim(); ;
                return ret;


            }

            public static string GetDealParameters(Dictionary<string, string> urlParameters)
            {
                return "&includeAssociations=true&limit=10&properties=dealname";
            }


            public static List<Deal> GetAllDeals(int limit = 0)
            {

                //https://api.hubapi.com/deals/v1/deal/paged?hapikey=56650273-6f78-4b25-9280-a47f25c423c8&properties=dealname&properties=amount
                string url = "https://api.hubapi.com/deals/v1/deal/paged?" + AppendAuthorization() + "&includeAssociations=true&properties=dealname&properties=amount&properties=part_number&properties=manufacturer&properties=dealstage&properties=quote_quantity&properties=target_price&properties=createdate&properties=pipeline";
                if (limit > 0)
                    url += "&limit=10";

                GetHubspotResponse(url);
                DealList dSource = new DealList();
                List<Deal> dList = new List<Deal>();


                JObject jObj = JObject.Parse(responseString);
                dSource = JsonConvert.DeserializeObject<DealList>(responseString);
                foreach (Deal d in dSource.deals)
                {
                    dList.Add(d);
                }
                return dList;
            }


            public static Deal GetDealByID(long i)
            {
                Deal ret = new Deal();
                string url = @"https://api.hubapi.com/deals/v1/deal/" + i.ToString() + "?" + AppendAuthorization();
                GetHubspotResponse(url);
                ret = JsonConvert.DeserializeObject<Deal>(responseString);
                if(ret != null)
                    if (ret.dealId == 0)
                        return null;
                return ret;
            }

            public static List<Deal> GetAssociatedDeals(string assType, string id)
            {

                Dictionary<string, string> parameters = new Dictionary<string, string>();
                switch (assType.ToLower())
                {
                    case ("contact"):
                        parameters.Add("contactID", id);
                        break;
                    case ("company"):
                        parameters.Add("companyID", id);
                        break;
                }

                GetHubspotResponse("deal", true, parameters, 2);
                JResults = GetArray(responseString);
                if (JResults == null)
                    return null;
                List<Deal> dList = new List<Deal>();
                foreach (string s in JResults.Children())
                {
                    Deal d = GetDealByID(Convert.ToInt64(s));
                    dList.Add(d);


                }
                return dList;
            }


            //Pipeline / Deal Stages
            public static List<DealStage> GetCurrentDealStages()
            {

                List<Pipeline> pList = GetAllPipelines();
                List<DealStage> sList = new List<DealStage>();
                foreach (Pipeline p in pList)
                {
                    sList.AddRange(p.stages);
                }
                return sList;
            }

            public static DealStage GetDealStage(string pipelineID, string stageID)
            {
                DealStage s = null;
                Pipeline p = GetPipelineData(pipelineID);
                if (p != null)
                {
                    s = p.stages.Where(w => w.stageId == stageID).FirstOrDefault();
                    if (s == null)
                        return null;
                    //throw new Exception("No pipeline found with ID: " + pipelineID);
                }

                return s;
            }

            public static void UpdateDealStage(long dealId, string newDealStageID)
            {
                Dictionary<string, string> props = new Dictionary<string, string>();

                //sale_won = "9cd6365b-1f57-4685-aa0f-41e1a4ca2a15";
                //sale_lost = "e97cd1b9-b203-4cd1-9b3f-f6dc266dc285";
                List<string> closeStageIds = new List<string>() { "9cd6365b-1f57-4685-aa0f-41e1a4ca2a15", "e97cd1b9-b203-4cd1-9b3f-f6dc266dc285" };

                if(closeStageIds.Contains(newDealStageID)) //If the new stage is sale won or sale lost, set close date as today.
                {
                    long closeDate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(DateTime.Now);
                    props.Add("closedate", closeDate.ToString());                   
                }
                props.Add("dealstage", newDealStageID);
                UpdateDeal(dealId, props);
            }

            public static string GetDealStageNameFromDealStageID(string stageID)
            {
                if (stageID == HubspotApi.DealStage.rfq_received)
                    return "rfq_received";
                else if (stageID == HubspotApi.DealStage.formal_quote_created)
                    return "formal_quote_created";
                else if (stageID == HubspotApi.DealStage.sale_won)
                    return "sale_won";
                else if (stageID == HubspotApi.DealStage.sale_lost)
                    return "sale_lost";
                return "<unknown>";


            }



            public static string GetDealStageIDFromDealStageName(string stageName)
            {
                if (stageName == "rfq_received" || stageName == "Identify")
                    return HubspotApi.DealStage.rfq_received;
                else if (stageName == "formal_quote_created" || stageName == "Quoting")
                    return HubspotApi.DealStage.formal_quote_created;
                else if (stageName == "sale_won")
                    return HubspotApi.DealStage.sale_won;
                else if (stageName == "sale_lost")
                    return HubspotApi.DealStage.sale_lost;
                return "<unknown>";


            }

            public static Pipeline GetPipelineData(string pipelineID)
            {
                //https://api.hubapi.com/deals/v1/pipelines/default?hapikey=56650273-6f78-4b25-9280-a47f25c423c8 --default sales pipeline example url
                string url = baseUrl + "/deals/v1/pipelines/" + pipelineID + "?" + AppendAuthorization();
                GetHubspotResponse(url);
                Pipeline p = JsonConvert.DeserializeObject<Pipeline>(responseString);
                if (p == null)
                    return null;
                //throw new Exception("No pipeline found with ID: " + pipelineID);
                return p;
            }



            public static List<Pipeline> GetAllPipelines()
            {
                //https://api.hubapi.com/deals/v1/pipelines?hapikey=demo
                //https://api.hubapi.com/deals/v1/pipelines?hapikey=56650273-6f78-4b25-9280-a47f25c423c8
                List<Pipeline> ret = new List<Pipeline>();
                string url = "https://api.hubapi.com/deals/v1/pipelines" + "?" + AppendAuthorization();
                GetHubspotResponse(url);
                ret = JsonConvert.DeserializeObject<List<Pipeline>>(responseString);
                return ret;
            }


            public static Deal CreateDealObjectTest(string dealName = null)
            {
                string url = @"https://api.hubapi.com/deals/v1/deal?" + AppendAuthorization();
                if (dealName == null)
                    dealName = "Deal Created by Hubspot API";
                List<long> CompanyIDs = new List<long>() { 124286060 };
                List<long> ContactIDs = new List<long>() { 1009151 };
                dynamic d = new ExpandoObject();
                //Associations
                d.associations = new Associations();
                d.associations.associatedCompanyIds = CompanyIDs;
                d.associations.associatedVids = ContactIDs;
                //Properties
                d.properties = new List<Property>();
                d.properties.Add(new Property { name = "dealname", value = dealName });
                d.properties.Add(new Property { name = "hubspot_owner_id", value = "7209703" });
                d.properties.Add(new Property { name = "pipeline", value = "default" });
                d.properties.Add(new Property { name = "dealstage", value = "814ab36e-d1ed-48d4-9f30-105c4900733c" });
                d.properties.Add(new Property { name = "createdate", value = "1509979230000" });
                d.properties.Add(new Property { name = "part_number", value = "ABC123PARTNUMBER" });
                d.properties.Add(new Property { name = "manufacturer", value = "INTEL" });
                d.properties.Add(new Property { name = "target_price", value = "1.50" });
                d.properties.Add(new Property { name = "description", value = "Created for company Sensible Micro, contact Kevin Till" });
                d.properties.Add(new Property { name = "amount", value = "60000" });
                d.properties.Add(new Property { name = "dealtype", value = "newbusiness" });
                //PostDeal(d);
                Post(d, url);

                Deal deal = JsonConvert.DeserializeObject<Deal>(responseDetails);
                return deal;
            }


            public static bool DeleteDeal(long dealID)
            {
                Deal d = GetDealByID(dealID);
                if (d.dealId == 0)
                    return false;
                //throw new Exception("Cannot delete, deal not found with id: " + dealID);
                string url = baseUrl + "deals/v1/deal/" + dealID.ToString() + "?" + AppendAuthorization();
                Delete(url);
                d = GetDealByID(dealID);
                if (d.dealId == 0)
                    return true;
                else
                    return false;
            }

            public static HubspotApi.Deal SetDealLost(long hubspotID, string reason, bool aged = false)
            {
                long closeDate = HubspotApi.ConvertDateTimeToUnixTimestampMillis(DateTime.Now);
                Dictionary<string, string> props = new Dictionary<string, string>() {

                        {"dealstage",HubspotApi.DealStage.sale_lost },
                        {"closed_lost_reason",reason },
                        {"closedate", closeDate.ToString()},

                    };

                //if this is closed due to aging, set that custom property for reporting purposes
                if (aged)
                    props.Add("closed_aged", "true");
                if (reason.ToLower() == "rma")
                    props.Add("closed_rma", "true");
                return HubspotApi.Deals.UpdateDeal(hubspotID, props);

            }

            public static Associations CreateDealAssociations(string contactEmail)
            {
                Associations ass = new HubspotApi.Associations(); //Associate with Owner, Company, and Contact       

                //Get the Hubspot Contact (If Any)
                Contact hsContact = Contacts.GetContactByEmail(contactEmail);
                if (hsContact == null)
                {
                    Dictionary<string, string> contactProps = new Dictionary<string, string>();
                    contactProps.Add("email", contactEmail);
                    //Create the contact if it doesn't exist                    
                    //hsContact = HubspotApi.Contacts.CreateHubspotContact(contactProps, HubspotApi.Contacts.ContactSource.DealCraeted);

                }
                //Confirm that a contact was created
                if (hsContact == null)
                    return null;



                //Add the contact association:
                ass.associatedVids = new List<long>() { Convert.ToInt64(hsContact.vid) };
                //Need to convert this as sometimes, there will be "" results, which isn't an int.  Need to force null or empty to = 0
                //int companyID = Convert.ToInt32();
                string strCompanyID = hsContact.Properties.Where(w => w.Key == "associatedcompanyid").Select(s => s.Value.value).FirstOrDefault();
                long companyID;
                bool isNumeric = long.TryParse(strCompanyID, out companyID);
                if (isNumeric)
                    if (companyID > 0)
                        //Add the company association
                        ass.associatedCompanyIds = new List<long>() { companyID };


                return ass;
            }

            public static Deal CreateDeal(Associations ass, Dictionary<string, string> properties)
            {

                //Make sure we always entere here from SensibleDAL.HubspotData so we can query Rz datgabase for dealType
                dynamic d = new ExpandoObject();


                d.associations = ass;
                //Properties
                List<Property> props = new List<Property>();
                foreach (KeyValuePair<string, string> kvp in properties)
                {
                    props.Add(new Property { name = kvp.Key, value = kvp.Value });
                }
                //if (!props.Any(a => a.name == "pipeline"))
                //    props.Add(new Property { name = "pipeline", value = "bb901f63-4781-471c-b955-2d0f8c0ea029" });
                //if (!props.Any(a => a.name == "dealstage"))
                //    props.Add(new Property { name = "dealstage", value = "eb6e035b-ba94-44b5-a18b-2450cb5a690f" });
                //if (!props.Any(a => a.name == "hubspot_owner_id"))
                //    props.Add(new Property { name = "hubspot_owner_id", value = "7209703" });

                //BusinessType


                d.properties = props;
                //Post
                PostDeal(d);
                //Return Object
                Deal deal = JsonConvert.DeserializeObject<Deal>(responseDetails);
                return deal;
            }


            public static Deal UpdateDeal(long dealID, Dictionary<string, string> updatedProps, Associations ass = null)
            {
                dynamic d = new ExpandoObject();


                d.associations = ass;
                //Properties
                List<Property> props = new List<Property>();
                foreach (KeyValuePair<string, string> kvp in updatedProps)
                {
                    props.Add(new Property { name = kvp.Key, value = kvp.Value });
                }

                d.properties = props;
                //Udpate Properties
                string url = @"https://api.hubapi.com/deals/v1/deal/" + dealID + "?" + AppendAuthorization();
                Put(d, url);
                //return Updated Deal           
                Deal deal = JsonConvert.DeserializeObject<Deal>(responseDetails);
                return deal;
            }



            private static void UpdateHubspotAssociations(HubspotApi.Deal deal, dynamic d, Associations ass)
            {
                string url = "";
                if (ass.associatedCompanyIds == null) //If no Company, dissasociate with any current?
                {
                    foreach (long i in deal.associations.associatedCompanyIds)
                        DisassociateCompany(d, deal.dealId, i);
                }
                else //Associate with Company
                {
                    foreach (long i in ass.associatedCompanyIds)
                    {
                        url = @"https://api.hubapi.com/deals/v1/deal/" + deal.dealId + "/associations/COMPANY?id=" + i + "&" + AppendAuthorization();
                        Put(d, url);
                    }

                }
                //Update Contact Associations          
                if (ass.associatedVids == null) //If no Contact, dissasociate with any current?
                {
                    foreach (long i in deal.associations.associatedVids)
                        DisassociateContact(d, deal.dealId, i);
                }
                else //Associate with Contact
                {
                    foreach (long i in ass.associatedVids)
                    {
                        url = @"https://api.hubapi.com/deals/v1/deal/" + deal.dealId + "/associations/CONTACT?id=" + i + "&" + AppendAuthorization();
                        Put(d, url);

                    }

                }
            }

            private static void DisassociateContact(ExpandoObject d, long dealID, long i)
            {
                string url = @"https://api.hubapi.com/deals/v1/deal/" + dealID + "/associations/CONTACT?id=" + i + "&" + AppendAuthorization();
                Delete(url);

                //Put(d, url);
            }

            private static void DisassociateCompany(ExpandoObject d, long dealID, long i)
            {
                string url = @"https://api.hubapi.com/deals/v1/deal/" + dealID + "/associations/COMPANY?id=" + i + "&" + AppendAuthorization();
                Delete(url);
                //Put(d, url);
            }



            public static List<Deal> GetDealsModifiedSince(DateTime estDate)
            {
                List<Deal> ret = new List<Deal>();
                //Example URL: https://api.hubapi.com/deals/v1/deal/recent/modified?hapikey=56650273-6f78-4b25-9280-a47f25c423c8&paged=True&limit=100&since=1572373389000           

                long unixMinutesAgo = ConvertDateTimeToUnixTimestampMillis(estDate);

                string url = @"https://api.hubapi.com/deals/v1/deal/recent/modified?" + AppendAuthorization() + "&paged=True&limit=100&since=" + unixMinutesAgo;
                GetHubspotResponse(url);

                // results = GetArray(responseString);
                JResults = GetArray(responseString);
                if (JResults == null)
                    return null;
                foreach (JObject jo in JResults)
                {
                    Deal d = jo.ToObject<Deal>();
                    ret.Add(d);

                }

                return ret;
            }



            public static List<HubspotApi.Deal> GetDealsModifiedSinceMinutes(int minutesAgo)
            {
                List<Deal> ret = new List<Deal>();

                long unixNow = GetCurrentUnixTimestampMillis();
                DateTime estNow = HubspotApi.Api.DateTimeESTFromUnixTimestampMillis(unixNow);
                DateTime sinceDateTime = estNow.AddMinutes(-minutesAgo);

                ret = HubspotApi.Deals.GetDealsModifiedSince(sinceDateTime);
                return ret;
            }




            public static void PostDeal(object o)
            {
                string url = @"https://api.hubapi.com/deals/v1/deal?" + AppendAuthorization();
                string jsonBody = GetObjectString(o);

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                    responseString = response.ToString();
                    responseDetails = response.Content.ReadAsStringAsync().Result;
                    JObject jo = JObject.Parse(responseDetails);
                    responseString += responseString + Environment.NewLine + jo.ToString();
                    if (response.IsSuccessStatusCode)
                    {
                        Deal d = JsonConvert.DeserializeObject<Deal>(responseDetails);
                        responseString = "Deal with ID " + d.dealId + " succcessfully created.";
                    }



                }
            }

            //End Deals
        }

        public static class Forms
        {
            public static bool Post_To_HubSpot_FormsAPI(HttpContext x, long intPortalID, string strFormGUID, Dictionary<string, string> dictFormValues, string strIpAddress, string strPageTitle, string strPageURL, ref string strMessage, bool testOnly = false)
            {

                // Build Endpoint URL
                //string strEndpointURL = string.Format("https://forms.hubspot.com/uploads/form/v2/{0}/{1}", intPortalID, strFormGUID);
                string strEndpointURL = string.Format("https://api.hsforms.com/submissions/v3/integration/submit/{0}/{1}", intPortalID, strFormGUID);
                //Open the bracket
                string strPostData = "{ \n";
                //Add the fields as a JSON array of objects
                string strFormPropertiesJsonArray = GenerateHubspotFormPropertiesArray(dictFormValues);
                // Setup HS Context Object 
                string strHubSpotContextJSON = GenerateHsContext(x, strIpAddress, strIpAddress, strPageTitle);
                //Append HS Context JSON
                strPostData += strFormPropertiesJsonArray + strHubSpotContextJSON;
                //Close the bracket
                strPostData += "} \n";
                //if (testOnly)
                //    return false;
                try
                {
                    Post(strPostData, strEndpointURL);

                    //string error = ResponseError.message;
                    if (ResponseError != null)
                    {
                        strMessage = ResponseError.message;
                        return false;
                    }

                    strMessage = responseDetails;
                    return true; //POST Succeeded
                }
                catch (Exception ex)
                {
                    // POST Request Failed
                    strMessage = ex.Message;
                    return false;
                }


            }

            private static string GenerateHubspotFormPropertiesArray(Dictionary<string, string> dictFormValues)
            {
                // Create string with post data, ensure "fields" is lower case, and we open and close with []
                string json = "\"fields\": [";
                foreach (KeyValuePair<string, string> kvp in dictFormValues)
                {
                    json += "{\"name\": \"" + kvp.Key + "\", \"value\": \"" + kvp.Value + "\" }";
                    if (kvp.Value != dictFormValues.Values.Last())
                        json += ",";
                }
                json += "], \n";

                return json;
            }

            private static string GenerateHsContext(HttpContext x, string strIpAddress, string strPageURL, string strPageTitle)
            {
                string json = "\"hs_context\": ";
                Dictionary<string, string> dictHsContextProperties = new Dictionary<string, string>();
                // Tracking Code Variables
                //Jsut for debugging, this was in code, not sure if returns value.  Not passing to form
                string hubspotTrackingCookie = "";
                if (x.Request.Cookies["hubspotutk"] != null)
                    hubspotTrackingCookie = x.Request.Cookies["hubspotutk"].Value;
                if (!string.IsNullOrEmpty(hubspotTrackingCookie))
                    dictHsContextProperties.Add("hutk", hubspotTrackingCookie);
                string hubspotCookieOptOut = "";
                if (x.Request.Cookies["__hs_opt_out"] != null)
                    hubspotCookieOptOut = x.Request.Cookies["__hs_opt_out"].Value;
                //dictFormValues.Add("sm_cookie_opt_out", hubspotCookieOptOut);                               
                dictHsContextProperties.Add("ipAddress", strIpAddress);
                dictHsContextProperties.Add("pageUrl", strPageURL);
                dictHsContextProperties.Add("pageName", strPageTitle);
                //json += GenerateJsonStringArrayFromDictionary(dictHsContextProperties);
                json += JsonConvert.SerializeObject(dictHsContextProperties, Formatting.Indented);
                json += " \n";


                return json;
            }

            //private static string GenerateJsonStringArrayFromDictionary(Dictionary<string, string> dictProperties)
            //{
            //    string json = "";
            //    foreach (KeyValuePair<string, string> kvp in dictProperties)
            //    {
            //        json += "{\" name \": \"" + kvp.Key + "\", \"value\": \"" + kvp.Value + "\" }";
            //        if (kvp.Value != dictProperties.Values.Last())
            //            json += ",";
            //    }

            //    return json;
            //}

            private static bool GetPostResult(HttpWebResponse objResponse, string postType, out string postResult)
            {
                switch (postType)
                {
                    case "form":
                        return getFormPostResult(objResponse, out postResult);
                }
                postResult = "Unknown post type.";
                return false;
            }

            private static bool getFormPostResult(HttpWebResponse objResponse, out string postResult)
            {
                //204 when the form submission is successful.
                //302 when the form submission is successful and a redirectUrl is included or set in the form settings.
                //404 when the Form GUID is not found for the provided Hub ID.
                //500 when an internal server error occurs.

                string prefix = "Hubspot reports that: ";

                HttpStatusCode code = objResponse.StatusCode;
                if (code == null)
                {
                    postResult = prefix += "The response code was null.";
                    return false;
                }


                //switch(code.ToString())
                //{
                //    case "204":
                //        return ret += "The form submission is successful";
                //    case "302":
                //        return ret += "The form submission is successful and a redirectUrl is included or set in the form settings";
                //    case "404":
                //        return ret += "The Form GUID is not found for the provided Hub ID";
                //    case "500":
                //        return ret += "An internal error has occured";
                //}
                if (code == HttpStatusCode.OK)
                {
                    postResult = prefix += "The form post was successful.";
                    return true;
                }

                postResult = prefix += "An unknown response code was received. " + code.ToString();
                return false;
            }
        }

        public class SensibleLogic
        {


            public class Quoting
            {

            }

            public class Automation
            {

            }
        }


        //Common Variables
        public static string responseString = "";
        public static string responseDetails = "";
        public static HubResponseError ResponseError = null;

        static JArray JResults = new JArray();
        static string hapiKey = "<redacted>";
        static string baseUrl = "https://api.hubapi.com/";
        static string testUrl = "https://api.hubapi.com/engagements/v1/engagements/associated/COMPANY/92432786/paged?" + AppendAuthorization() + "&limit=20";



        //API Common Methods
        private static string CheckStringForDomain(string domain)
        {
            if (domain.Contains("@"))
            {
                string[] splitString = domain.Split('@');
                domain = splitString[1];
            }

            return domain;
        }

        private static string GetObjectString(object o)
        {
            return JsonConvert.SerializeObject(o);
        }

        private static JObject GetJObjectFromJSON(string responseString)
        {
            JObject o = JObject.Parse(responseString);
            return o;
        }

        private static JArray GetArray(string result)
        {
            JArray ret = null;

            if (!string.IsNullOrEmpty(result))
            {
                var token = JToken.Parse(result);
                if (token is JArray)
                {
                    return (JArray)token;
                }
                else if (token is JObject)
                {
                    JObject o = (JObject)token;
                    //if (!string.IsNullOrEmpty(key))
                    ret = (JArray)o["results"];
                    //else
                    //    ret = new JArray(o);
                }
            }
            return ret;
        }



        //Date Tools

        //Unix TimeStamp Conversions
        private static DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(UnixEpoch.AddMilliseconds(unixTimeStamp), easternZone);
            return easternTime;
        }
        public static long GetCurrentUnixTimestampMillis()
        {
            //return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
            return ConvertDateTimeToUnixTimestampMillis(DateTime.Now);
        }
        public static long ConvertDateTimeToUnixTimestampMillis(DateTime date)
        {
            //return (long)(date - UnixEpoch).TotalMilliseconds;
            //long net46Ret = ((DateTimeOffset)date).ToUnixTimeSeconds();
            //long utcRet = (long)(date - UnixEpoch).TotalMilliseconds;
            //long etcRet = (long)(date - UnixEpoch).TotalMilliseconds;
            //var dtfoo = new DateTime(2010, 10, 20);
            DateTimeOffset dtOffSet = new DateTimeOffset(date);
            long  ret = dtOffSet.ToUnixTimeMilliseconds();
            return ret;


        }

        public static DateTime DateTimeFromUnixTimestampMillis(long millis, bool utcToEst = true)
        {
            DateTime date = UnixEpoch.AddMilliseconds(millis);
            if (utcToEst)
                date = ConvertUTCtoEST(date);
            return date;
        }
        //public static long GetCurrentUnixTimestampSeconds()
        //{
        //    return (long)(DateTime.UtcNow - UnixEpoch).TotalSeconds;
        //}
        //public static DateTime DateTimeFromUnixTimestampSeconds(long seconds)
        //{
        //    return UnixEpoch.AddSeconds(seconds);
        //}

        public static DateTime ConvertUTCtoEST(DateTime utc)
        {

            TimeZoneInfo easternZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime easternTime = TimeZoneInfo.ConvertTimeFromUtc(utc, easternZone);
            return easternTime;
        }

        private void getAllProperties(JToken children)
        {
            foreach (JToken child in children.Children())
            {
                var property = child as JProperty;
                if (property != null)
                {
                    Console.WriteLine(property.Name + " " + property.Value);//print all of the values
                }
                getAllProperties(child);
            }
        }

        private static string GetUrl(string type, bool paged, Dictionary<string, string> urlParameters, int limit)
        {
            string ret = "";
            switch (type.ToLower())
            {
                case "engagement":
                    {
                        ret = Engagements.GetEngagementsUrl(urlParameters);
                        break;
                    }
                case "owner":
                    {
                        ret = Owners.GetOwnerUrl(urlParameters);
                        break;
                    }
                case "deal":
                    {
                        ret = Deals.GetDealUrl(urlParameters);
                        break;
                    }
                case "contact":
                    {
                        ret = Contacts.GetContactUrl(urlParameters);
                        break;
                    }
            }

            if (string.IsNullOrEmpty(ret))
                return null;
            if (paged)
                ret += "paged/";
            ret += "?" + AppendAuthorization();
            ret += ProcessQueryStringParameters(type, urlParameters);
            if (limit > 0)
                ret += AppendLimit(limit);
            return ret;
        }


        private static string ProcessQueryStringParameters(string type, Dictionary<string, string> urlParameters)
        {
            string ret = "";
            if (urlParameters != null)
                ret += GetUrlParameters(type, urlParameters);
            return ret;
        }

        private static string AppendLimit(int limit)
        {
            return "&limit=" + limit;
        }

        private static string GetUrlParameters(string type, Dictionary<string, string> urlParameters)
        {
            string ret = "";
            switch (type.ToLower())
            {
                case "engagement":
                    {
                        ret = Engagements.GetEngagementParams(urlParameters);
                        break;
                    }
                case "owner":
                    {
                        ret = Owners.GetOwnerParameters(urlParameters);
                        break;
                    }
                case "deal":
                    {
                        ret = Deals.GetDealParameters(urlParameters);
                        break;
                    }
            }

            if (string.IsNullOrEmpty(ret))
                return null;

            return ret;
        }



        public static string AppendAuthorization()
        {
            return "hapikey=" + hapiKey;
        }

        //API Calls
        public static void Post(object o, string url)
        {
            string json = GetObjectString(o);
            Post(json, url);
        }


        public static void Post(string json, string url)
        {
            try
            {

                using (var httpClient = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    //HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                    Task<HttpResponseMessage> response = httpClient.PostAsync(url, content);
                    var result = response.Result;

                    //This will be the returned object in string format.
                    responseDetails = result.Content.ReadAsStringAsync().Result;
                    if (response.Exception != null)
                        responseString = response.Exception.Data.ToString() ?? "API Exception but no data.";
                    else
                        responseString = response.Status.ToString();

                }
            }
            catch (Exception ex)
            {

            }

        }


        private static void Put(dynamic d, string url)
        {
            string json = GetObjectString(d);
            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PutAsync(url, content).Result;
                responseString = response.ToString();
                responseDetails = response.Content.ReadAsStringAsync().Result;
                if (!string.IsNullOrEmpty(responseDetails))
                {
                    JObject jo = JObject.Parse(responseDetails);
                    responseString += responseString + Environment.NewLine + jo.ToString();
                }
            }
        }
        private static bool Delete(string url)
        {
            //string url;
            using (var httpClient = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:1565/");
                HttpResponseMessage response = httpClient.DeleteAsync(url).Result;
                responseString = response.ToString();
                if (response.IsSuccessStatusCode)
                {
                    Console.Write("Success");
                    return true;
                }
            }
            return false;
        }

        //Response STring
        private static void GetHubspotResponse(string type, bool paged, Dictionary<string, string> parameters, int limit)
        {
            string url = GetUrl(type, false, parameters, limit); //Paged needs to be false, else =
            GetHubspotResponse(url);
        }
        private static void GetHubspotResponse(string url)
        {
            //HubspotResponse resp = null;
            ResponseError = null;
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
                var response = httpClient.GetAsync(new Uri(url)).Result;
                using (HttpContent content = response.Content)
                {

                    // ... Read the string.
                    Task<string> result = content.ReadAsStringAsync();
                    responseString = result.Result;
                    responseDetails = response.Content.ReadAsStringAsync().Result;
                    if (response.StatusCode == HttpStatusCode.OK)
                        return;//Successful retrevial

                    if (result.Result == "[]")
                        ResponseError = new HubResponseError() { status = "error", message = "No Values found" };
                    else if (response.StatusCode == HttpStatusCode.GatewayTimeout)
                        ResponseError = new HubResponseError() { status = "error", message = "Gateway Timeout" };
                    else if (response.StatusCode.ToString() == "429")
                        ResponseError = new HubResponseError() { status = "error", message = "Daily limit of queries reached." };
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                        ResponseError = new HubResponseError() { status = "error", message = "Engagement NotFound: " + url };
                    //else if (response.StatusCode != HttpStatusCode.OK)
                    //    ResponseError = JsonConvert.DeserializeObject<HubResponseError>(responseString);
                    

                }
            }
        }




    }
}



