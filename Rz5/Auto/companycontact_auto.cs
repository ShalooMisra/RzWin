using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("companycontact")]
    public partial class companycontact_auto : NewMethod.nObject
    {
        static companycontact_auto()
        {
            Item.AttributesCache(typeof(companycontact_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryphone":
                    primaryphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryfax":
                    primaryfaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryemailaddress":
                    primaryemailaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primarywebaddress":
                    primarywebaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactnotes":
                    contactnotesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contacttype":
                    contacttypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "maritalstatus":
                    maritalstatusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactgender":
                    contactgenderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "interests":
                    interestsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecreated":
                    datecreatedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datemodified":
                    datemodifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "modifiedby":
                    modifiedbyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "birthdate":
                    birthdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactmethod":
                    contactmethodAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacyid":
                    legacyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacysalesrepid":
                    legacysalesrepidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isdefaultpurchaser":
                    isdefaultpurchaserAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isdefaultsales":
                    isdefaultsalesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datehired":
                    datehiredAttribute = (CoreVarValAttribute)attr;
                    break;
                case "line1":
                    line1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "line2":
                    line2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "line3":
                    line3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "adrcity":
                    adrcityAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adrstate":
                    adrstateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adrzip":
                    adrzipAttribute = (CoreVarValAttribute)attr;
                    break;
                case "adrcountry":
                    adrcountryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "salutation":
                    salutationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "jobtype":
                    jobtypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "strippedphone":
                    strippedphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatephone":
                    alternatephoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatefax":
                    alternatefaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryphoneextension":
                    primaryphoneextensionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactfrequency":
                    contactfrequencyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isactive":
                    isactiveAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "distilledphone":
                    distilledphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "distilledfax":
                    distilledfaxAttribute = (CoreVarValAttribute)attr;
                    break;
                case "distilledcontact":
                    distilledcontactAttribute = (CoreVarValAttribute)attr;
                    break;
                case "prospectid":
                    prospectidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentinitials":
                    agentinitialsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isduplicate":
                    isduplicateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternateemail":
                    alternateemailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companynumber":
                    companynumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hasduplicates":
                    hasduplicatesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "needsreview":
                    needsreviewAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isverified":
                    isverifiedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isdistributor":
                    isdistributorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotemail":
                    donotemailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotpromote":
                    donotpromoteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "spam_graphic":
                    spam_graphicAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotmail":
                    donotmailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "bad_data":
                    bad_dataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isvendor":
                    isvendorAttribute = (CoreVarValAttribute)attr;
                    break;
                case "iscustomer":
                    iscustomerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_domain":
                    email_domainAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_qbimport":
                    is_qbimportAttribute = (CoreVarValAttribute)attr;
                    break;
                case "lastcalldate":
                    lastcalldateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "producttype":
                    producttypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "donotcall":
                    donotcallAttribute = (CoreVarValAttribute)attr;
                    break;
                case "strippedalternatephone":
                    strippedalternatephoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "source":
                    sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_names":
                    alternate_namesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_emails":
                    alternate_emailsAttribute = (CoreVarValAttribute)attr;
                    break;
                case "mrp_info":
                    mrp_infoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "group_name":
                    group_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_suffix":
                    email_suffixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_primary":
                    is_primaryAttribute = (CoreVarValAttribute)attr;
                    break;
                case "timezone":
                    timezoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_mailing_address":
                    alternate_mailing_addressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "credit_card":
                    credit_cardAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact_function":
                    contact_functionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "preferred_name":
                    preferred_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "first_name":
                    first_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "personality_type":
                    personality_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_contact_id":
                    hubspot_contact_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "send_company_shipping_email_alert":
                    send_company_shipping_email_alertAttribute = (CoreVarValAttribute)attr;
                    break;
                case "affiliate_id":
                    affiliate_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "affiliate_name":
                    affiliate_nameAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute primaryphoneAttribute;
        static CoreVarValAttribute primaryfaxAttribute;
        static CoreVarValAttribute primaryemailaddressAttribute;
        static CoreVarValAttribute primarywebaddressAttribute;
        static CoreVarValAttribute contactnotesAttribute;
        static CoreVarValAttribute contacttypeAttribute;
        static CoreVarValAttribute maritalstatusAttribute;
        static CoreVarValAttribute contactgenderAttribute;
        static CoreVarValAttribute interestsAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute birthdateAttribute;
        static CoreVarValAttribute contactmethodAttribute;
        static CoreVarValAttribute legacyidAttribute;
        static CoreVarValAttribute legacysalesrepidAttribute;
        static CoreVarValAttribute isdefaultpurchaserAttribute;
        static CoreVarValAttribute isdefaultsalesAttribute;
        static CoreVarValAttribute datehiredAttribute;
        static CoreVarValAttribute line1Attribute;
        static CoreVarValAttribute line2Attribute;
        static CoreVarValAttribute line3Attribute;
        static CoreVarValAttribute adrcityAttribute;
        static CoreVarValAttribute adrstateAttribute;
        static CoreVarValAttribute adrzipAttribute;
        static CoreVarValAttribute adrcountryAttribute;
        static CoreVarValAttribute salutationAttribute;
        static CoreVarValAttribute jobtypeAttribute;
        static CoreVarValAttribute strippedphoneAttribute;
        static CoreVarValAttribute alternatephoneAttribute;
        static CoreVarValAttribute alternatefaxAttribute;
        static CoreVarValAttribute primaryphoneextensionAttribute;
        static CoreVarValAttribute contactfrequencyAttribute;
        static CoreVarValAttribute isactiveAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute distilledphoneAttribute;
        static CoreVarValAttribute distilledfaxAttribute;
        static CoreVarValAttribute distilledcontactAttribute;
        static CoreVarValAttribute prospectidAttribute;
        static CoreVarValAttribute agentinitialsAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute isduplicateAttribute;
        static CoreVarValAttribute alternateemailAttribute;
        static CoreVarValAttribute companynumberAttribute;
        static CoreVarValAttribute hasduplicatesAttribute;
        static CoreVarValAttribute needsreviewAttribute;
        static CoreVarValAttribute isverifiedAttribute;
        static CoreVarValAttribute isdistributorAttribute;
        static CoreVarValAttribute donotemailAttribute;
        static CoreVarValAttribute donotpromoteAttribute;
        static CoreVarValAttribute spam_graphicAttribute;
        static CoreVarValAttribute donotmailAttribute;
        static CoreVarValAttribute bad_dataAttribute;
        static CoreVarValAttribute isvendorAttribute;
        static CoreVarValAttribute iscustomerAttribute;
        static CoreVarValAttribute email_domainAttribute;
        static CoreVarValAttribute is_qbimportAttribute;
        static CoreVarValAttribute lastcalldateAttribute;
        static CoreVarValAttribute producttypeAttribute;
        static CoreVarValAttribute donotcallAttribute;
        static CoreVarValAttribute strippedalternatephoneAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute sourceAttribute;
        static CoreVarValAttribute alternate_namesAttribute;
        static CoreVarValAttribute alternate_emailsAttribute;
        static CoreVarValAttribute mrp_infoAttribute;
        static CoreVarValAttribute group_nameAttribute;
        static CoreVarValAttribute email_suffixAttribute;
        static CoreVarValAttribute is_primaryAttribute;
        static CoreVarValAttribute timezoneAttribute;
        static CoreVarValAttribute alternate_mailing_addressAttribute;
        static CoreVarValAttribute credit_cardAttribute;
        static CoreVarValAttribute contact_functionAttribute;
        static CoreVarValAttribute preferred_nameAttribute;
        static CoreVarValAttribute first_nameAttribute;
        static CoreVarValAttribute personality_typeAttribute;
        static CoreVarValAttribute hubspot_contact_idAttribute;
        static CoreVarValAttribute send_company_shipping_email_alertAttribute;
        static CoreVarValAttribute affiliate_idAttribute;
        static CoreVarValAttribute affiliate_nameAttribute;



        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Name", Importance = 3)]
        public VarString contactnameVar;

        [CoreVarVal("primaryphone", "String", TheFieldLength = 50, Caption="Primary Phone", Importance = 4)]
        public VarString primaryphoneVar;

        [CoreVarVal("primaryfax", "String", TheFieldLength = 50, Caption="Primary Fax", Importance = 5)]
        public VarString primaryfaxVar;

        [CoreVarVal("primaryemailaddress", "String", TheFieldLength = 50, Caption="Primary Email", Importance = 6)]
        public VarString primaryemailaddressVar;

        [CoreVarVal("primarywebaddress", "String", TheFieldLength = 50, Caption="Primary Web Address", Importance = 7)]
        public VarString primarywebaddressVar;

        [CoreVarVal("contactnotes", "String", TheFieldLength = 4096, Caption="Notes", Importance = 8)]
        public VarString contactnotesVar;

        [CoreVarVal("contacttype", "String", TheFieldLength = 50, Caption="Type", Importance = 9)]
        public VarString contacttypeVar;

        [CoreVarVal("maritalstatus", "String", TheFieldLength = 50, Caption="Marital Status", Importance = 10)]
        public VarString maritalstatusVar;

        [CoreVarVal("contactgender", "String", TheFieldLength = 50, Caption="Gender", Importance = 11)]
        public VarString contactgenderVar;

        [CoreVarVal("interests", "String", TheFieldLength = 4096, Caption="Interests", Importance = 12)]
        public VarString interestsVar;

        [CoreVarVal("datecreated", "DateTime", Caption="Date Created", Importance = 13)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption="Date Modified", Importance = 14)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption="Modified By", Importance = 15)]
        public VarString modifiedbyVar;

        [CoreVarVal("birthdate", "DateTime", Caption="Birth Date", Importance = 16)]
        public VarDateTime birthdateVar;

        [CoreVarVal("contactmethod", "String", TheFieldLength = 50, Caption="Contact Method", Importance = 17)]
        public VarString contactmethodVar;

        [CoreVarVal("legacyid", "String", TheFieldLength = 50, Caption="Legacy Id", Importance = 18)]
        public VarString legacyidVar;

        [CoreVarVal("legacysalesrepid", "String", TheFieldLength = 50, Caption="Legacy Sales Rep Id", Importance = 19)]
        public VarString legacysalesrepidVar;

        [CoreVarVal("isdefaultpurchaser", "Boolean", Caption="Default Purchaser", Importance = 20)]
        public VarBoolean isdefaultpurchaserVar;

        [CoreVarVal("isdefaultsales", "Boolean", Caption="Is Default Sales Manager", Importance = 21)]
        public VarBoolean isdefaultsalesVar;

        [CoreVarVal("datehired", "DateTime", Caption="Date Hired", Importance = 22)]
        public VarDateTime datehiredVar;

        [CoreVarVal("line1", "String", TheFieldLength = 255, Caption="Line 1", Importance = 23)]
        public VarString line1Var;

        [CoreVarVal("line2", "String", TheFieldLength = 255, Caption="Line 2", Importance = 24)]
        public VarString line2Var;

        [CoreVarVal("line3", "String", TheFieldLength = 255, Caption="Line3", Importance = 25)]
        public VarString line3Var;

        [CoreVarVal("adrcity", "String", TheFieldLength = 255, Caption="City", Importance = 26)]
        public VarString adrcityVar;

        [CoreVarVal("adrstate", "String", TheFieldLength = 255, Caption="State", Importance = 27)]
        public VarString adrstateVar;

        [CoreVarVal("adrzip", "String", TheFieldLength = 255, Caption="Zip", Importance = 28)]
        public VarString adrzipVar;

        [CoreVarVal("adrcountry", "String", TheFieldLength = 255, Caption="Country", Importance = 29)]
        public VarString adrcountryVar;

        [CoreVarVal("salutation", "String", TheFieldLength = 50, Caption="Salutation", Importance = 30)]
        public VarString salutationVar;

        [CoreVarVal("jobtype", "String", TheFieldLength = 50, Caption="Job Type", Importance = 31)]
        public VarString jobtypeVar;

        [CoreVarVal("strippedphone", "String", TheFieldLength = 50, Caption="Stripped Phone", Importance = 32)]
        public VarString strippedphoneVar;

        [CoreVarVal("alternatephone", "String", TheFieldLength = 50, Caption="Alternate Phone", Importance = 33)]
        public VarString alternatephoneVar;

        [CoreVarVal("alternatefax", "String", TheFieldLength = 50, Caption="Alternate Fax", Importance = 34)]
        public VarString alternatefaxVar;

        [CoreVarVal("primaryphoneextension", "String", TheFieldLength = 10, Caption="Ext.", Importance = 35)]
        public VarString primaryphoneextensionVar;

        [CoreVarVal("contactfrequency", "Int64", Caption="Contact Frequency", Importance = 36)]
        public VarInt64 contactfrequencyVar;

        [CoreVarVal("isactive", "Boolean", Caption="Is Active", Importance = 37)]
        public VarBoolean isactiveVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption="Agent Name", Importance = 38)]
        public VarString agentnameVar;

        [CoreVarVal("distilledphone", "String", TheFieldLength = 50, Caption="Distilled Phone", Importance = 39)]
        public VarString distilledphoneVar;

        [CoreVarVal("distilledfax", "String", TheFieldLength = 50, Caption="Distilled Fax", Importance = 40)]
        public VarString distilledfaxVar;

        [CoreVarVal("distilledcontact", "String", TheFieldLength = 50, Caption="Distilled Contact", Importance = 41)]
        public VarString distilledcontactVar;

        [CoreVarVal("prospectid", "String", TheFieldLength = 50, Caption="Prospect Id", Importance = 42)]
        public VarString prospectidVar;

        [CoreVarVal("agentinitials", "String", TheFieldLength = 50, Caption="Agent Initials", Importance = 43)]
        public VarString agentinitialsVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 44)]
        public VarString companynameVar;

        [CoreVarVal("isduplicate", "Boolean", Caption="Is Duplicate", Importance = 45)]
        public VarBoolean isduplicateVar;

        [CoreVarVal("alternateemail", "String", TheFieldLength = 50, Caption="Alternate Email", Importance = 46)]
        public VarString alternateemailVar;

        [CoreVarVal("companynumber", "Int64", Caption="Company Number", Importance = 47)]
        public VarInt64 companynumberVar;

        [CoreVarVal("hasduplicates", "Boolean", Caption="Has Duplicates", Importance = 48)]
        public VarBoolean hasduplicatesVar;

        [CoreVarVal("needsreview", "Boolean", Caption="Needs Review", Importance = 49)]
        public VarBoolean needsreviewVar;

        [CoreVarVal("isverified", "Boolean", Caption="Is Verified", Importance = 50)]
        public VarBoolean isverifiedVar;

        [CoreVarVal("isdistributor", "Boolean", Caption="Is Distributor", Importance = 51)]
        public VarBoolean isdistributorVar;

        [CoreVarVal("donotemail", "Boolean", Caption="Do Not Email", Importance = 52)]
        public VarBoolean donotemailVar;

        [CoreVarVal("donotpromote", "Boolean", Caption="Do Not Promote", Importance = 53)]
        public VarBoolean donotpromoteVar;

        [CoreVarVal("spam_graphic", "Boolean", Caption="Spam Graphic", Importance = 54)]
        public VarBoolean spam_graphicVar;

        [CoreVarVal("donotmail", "Boolean", Caption="Do Not Surface Mail", Importance = 55)]
        public VarBoolean donotmailVar;

        [CoreVarVal("bad_data", "Boolean", Caption="Bad Contact Data", Importance = 56)]
        public VarBoolean bad_dataVar;

        [CoreVarVal("isvendor", "Boolean", Caption="Is Vendor", Importance = 57)]
        public VarBoolean isvendorVar;

        [CoreVarVal("iscustomer", "Boolean", Caption="Is Customer", Importance = 58)]
        public VarBoolean iscustomerVar;

        [CoreVarVal("email_domain", "String", TheFieldLength = 255, Caption="Email Domain", Importance = 59)]
        public VarString email_domainVar;

        [CoreVarVal("is_qbimport", "Boolean", Caption="Is Qb Import", Importance = 60)]
        public VarBoolean is_qbimportVar;

        [CoreVarVal("lastcalldate", "DateTime", Caption="Last Call Date", Importance = 61)]
        public VarDateTime lastcalldateVar;

        [CoreVarVal("producttype", "String", TheFieldLength = 255, Caption="Product Type", Importance = 62)]
        public VarString producttypeVar;

        [CoreVarVal("donotcall", "Boolean", Caption="Donotcall", Importance = 63)]
        public VarBoolean donotcallVar;

        [CoreVarVal("strippedalternatephone", "String", TheFieldLength = 255, Caption="Strippedalternatephone", Importance = 64)]
        public VarString strippedalternatephoneVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption="Abs Type", Importance = 65)]
        public VarString abs_typeVar;

        [CoreVarVal("source", "String", TheFieldLength = 255, Caption="Source", Importance = 66)]
        public VarString sourceVar;

        [CoreVarVal("alternate_names", "String", TheFieldLength = 4096, Caption="Alternate Names", Importance = 67)]
        public VarString alternate_namesVar;

        [CoreVarVal("alternate_emails", "String", TheFieldLength = 8000, Caption="Alternate Emails", Importance = 68)]
        public VarString alternate_emailsVar;

        [CoreVarVal("mrp_info", "String", TheFieldLength = 255, Caption="Mrp Info", Importance = 69)]
        public VarString mrp_infoVar;

        [CoreVarVal("group_name", "Text", Caption="Group Name", Importance = 70)]
        public VarText group_nameVar;

        [CoreVarVal("email_suffix", "String", TheFieldLength = 255, Caption="Email Suffix", Importance = 71)]
        public VarString email_suffixVar;

        [CoreVarVal("is_primary", "Boolean", Caption="Is Primary", Importance = 72)]
        public VarBoolean is_primaryVar;

        [CoreVarVal("timezone", "String", TheFieldLength = 255, Caption="Timezone", Importance = 73)]
        public VarString timezoneVar;

        [CoreVarVal("alternate_mailing_address", "String", TheFieldLength = 8000, Caption="Alternate Mailing Address", Importance = 74)]
        public VarString alternate_mailing_addressVar;

        [CoreVarVal("credit_card", "String", TheFieldLength = 255, Caption="Credit Card", Importance = 75)]
        public VarString credit_cardVar;

        [CoreVarVal("contact_function", "String", TheFieldLength = 255, Caption="Contact Function", Importance = 76)]
        public VarString contact_functionVar;

        [CoreVarVal("preferred_name", "String", TheFieldLength = 255, Caption="Preferred Name", Importance = 77)]
        public VarString preferred_nameVar;

        [CoreVarVal("first_name", "String", TheFieldLength = 255, Caption="First Name", Importance = 78)]
        public VarString first_nameVar;

        [CoreVarVal("personality_type", "String", TheFieldLength = 255, Caption = "Personality Type", Importance = 79)]
        public VarString personality_typeVar;

        [CoreVarVal("hubspot_contact_id", "Int64", Caption = "hubspot_contact_id", Importance = 80)]
        public VarInt64 hubspot_contact_idVar;

        [CoreVarVal("send_company_shipping_email_alert", "Boolean", Caption = "send_company_shipping_email_alert", Importance = 81)]
        public VarBoolean send_company_shipping_email_alertVar;

        [CoreVarVal("affiliate_id", "String", TheFieldLength = 255, Caption = "Affiliate ID", Importance = 82)]
        public VarString affiliate_idVar;

        [CoreVarVal("affiliate_name", "String", TheFieldLength = 50, Caption = "Affiliate Name", Importance = 27)]
        public VarString affiliate_nameVar;


        public companycontact_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            primaryphoneVar = new VarString(this, primaryphoneAttribute);
            primaryfaxVar = new VarString(this, primaryfaxAttribute);
            primaryemailaddressVar = new VarString(this, primaryemailaddressAttribute);
            primarywebaddressVar = new VarString(this, primarywebaddressAttribute);
            contactnotesVar = new VarString(this, contactnotesAttribute);
            contacttypeVar = new VarString(this, contacttypeAttribute);
            maritalstatusVar = new VarString(this, maritalstatusAttribute);
            contactgenderVar = new VarString(this, contactgenderAttribute);
            interestsVar = new VarString(this, interestsAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            birthdateVar = new VarDateTime(this, birthdateAttribute);
            contactmethodVar = new VarString(this, contactmethodAttribute);
            legacyidVar = new VarString(this, legacyidAttribute);
            legacysalesrepidVar = new VarString(this, legacysalesrepidAttribute);
            isdefaultpurchaserVar = new VarBoolean(this, isdefaultpurchaserAttribute);
            isdefaultsalesVar = new VarBoolean(this, isdefaultsalesAttribute);
            datehiredVar = new VarDateTime(this, datehiredAttribute);
            line1Var = new VarString(this, line1Attribute);
            line2Var = new VarString(this, line2Attribute);
            line3Var = new VarString(this, line3Attribute);
            adrcityVar = new VarString(this, adrcityAttribute);
            adrstateVar = new VarString(this, adrstateAttribute);
            adrzipVar = new VarString(this, adrzipAttribute);
            adrcountryVar = new VarString(this, adrcountryAttribute);
            salutationVar = new VarString(this, salutationAttribute);
            jobtypeVar = new VarString(this, jobtypeAttribute);
            strippedphoneVar = new VarString(this, strippedphoneAttribute);
            alternatephoneVar = new VarString(this, alternatephoneAttribute);
            alternatefaxVar = new VarString(this, alternatefaxAttribute);
            primaryphoneextensionVar = new VarString(this, primaryphoneextensionAttribute);
            contactfrequencyVar = new VarInt64(this, contactfrequencyAttribute);
            isactiveVar = new VarBoolean(this, isactiveAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            distilledphoneVar = new VarString(this, distilledphoneAttribute);
            distilledfaxVar = new VarString(this, distilledfaxAttribute);
            distilledcontactVar = new VarString(this, distilledcontactAttribute);
            prospectidVar = new VarString(this, prospectidAttribute);
            agentinitialsVar = new VarString(this, agentinitialsAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            isduplicateVar = new VarBoolean(this, isduplicateAttribute);
            alternateemailVar = new VarString(this, alternateemailAttribute);
            companynumberVar = new VarInt64(this, companynumberAttribute);
            hasduplicatesVar = new VarBoolean(this, hasduplicatesAttribute);
            needsreviewVar = new VarBoolean(this, needsreviewAttribute);
            isverifiedVar = new VarBoolean(this, isverifiedAttribute);
            isdistributorVar = new VarBoolean(this, isdistributorAttribute);
            donotemailVar = new VarBoolean(this, donotemailAttribute);
            donotpromoteVar = new VarBoolean(this, donotpromoteAttribute);
            spam_graphicVar = new VarBoolean(this, spam_graphicAttribute);
            donotmailVar = new VarBoolean(this, donotmailAttribute);
            bad_dataVar = new VarBoolean(this, bad_dataAttribute);
            isvendorVar = new VarBoolean(this, isvendorAttribute);
            iscustomerVar = new VarBoolean(this, iscustomerAttribute);
            email_domainVar = new VarString(this, email_domainAttribute);
            is_qbimportVar = new VarBoolean(this, is_qbimportAttribute);
            lastcalldateVar = new VarDateTime(this, lastcalldateAttribute);
            producttypeVar = new VarString(this, producttypeAttribute);
            donotcallVar = new VarBoolean(this, donotcallAttribute);
            strippedalternatephoneVar = new VarString(this, strippedalternatephoneAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            sourceVar = new VarString(this, sourceAttribute);
            alternate_namesVar = new VarString(this, alternate_namesAttribute);
            alternate_emailsVar = new VarString(this, alternate_emailsAttribute);
            mrp_infoVar = new VarString(this, mrp_infoAttribute);
            group_nameVar = new VarText(this, group_nameAttribute);
            email_suffixVar = new VarString(this, email_suffixAttribute);
            is_primaryVar = new VarBoolean(this, is_primaryAttribute);
            timezoneVar = new VarString(this, timezoneAttribute);
            alternate_mailing_addressVar = new VarString(this, alternate_mailing_addressAttribute);
            credit_cardVar = new VarString(this, credit_cardAttribute);
            contact_functionVar = new VarString(this, contact_functionAttribute);
            preferred_nameVar = new VarString(this, preferred_nameAttribute);
            first_nameVar = new VarString(this, first_nameAttribute);
            personality_typeVar = new VarString(this, personality_typeAttribute);
            hubspot_contact_idVar = new VarInt64(this, hubspot_contact_idAttribute);
            send_company_shipping_email_alertVar = new VarBoolean(this, send_company_shipping_email_alertAttribute);
            affiliate_idVar = new VarString(this, affiliate_idAttribute);
            affiliate_nameVar = new VarString(this, affiliate_nameAttribute);

        }

        public override string ClassId
        { get { return "companycontact"; } }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public String primaryphone
        {
            get  { return (String)primaryphoneVar.Value; }
            set  { primaryphoneVar.Value = value; }
        }

        public String primaryfax
        {
            get  { return (String)primaryfaxVar.Value; }
            set  { primaryfaxVar.Value = value; }
        }

        public String primaryemailaddress
        {
            get  { return (String)primaryemailaddressVar.Value; }
            set  { primaryemailaddressVar.Value = value; }
        }

        public String primarywebaddress
        {
            get  { return (String)primarywebaddressVar.Value; }
            set  { primarywebaddressVar.Value = value; }
        }

        public String contactnotes
        {
            get  { return (String)contactnotesVar.Value; }
            set  { contactnotesVar.Value = value; }
        }

        public String contacttype
        {
            get  { return (String)contacttypeVar.Value; }
            set  { contacttypeVar.Value = value; }
        }

        public String maritalstatus
        {
            get  { return (String)maritalstatusVar.Value; }
            set  { maritalstatusVar.Value = value; }
        }

        public String contactgender
        {
            get  { return (String)contactgenderVar.Value; }
            set  { contactgenderVar.Value = value; }
        }

        public String interests
        {
            get  { return (String)interestsVar.Value; }
            set  { interestsVar.Value = value; }
        }

        public DateTime datecreated
        {
            get  { return (DateTime)datecreatedVar.Value; }
            set  { datecreatedVar.Value = value; }
        }

        public DateTime datemodified
        {
            get  { return (DateTime)datemodifiedVar.Value; }
            set  { datemodifiedVar.Value = value; }
        }

        public String modifiedby
        {
            get  { return (String)modifiedbyVar.Value; }
            set  { modifiedbyVar.Value = value; }
        }

        public DateTime birthdate
        {
            get  { return (DateTime)birthdateVar.Value; }
            set  { birthdateVar.Value = value; }
        }

        public String contactmethod
        {
            get  { return (String)contactmethodVar.Value; }
            set  { contactmethodVar.Value = value; }
        }

        public String legacyid
        {
            get  { return (String)legacyidVar.Value; }
            set  { legacyidVar.Value = value; }
        }

        public String legacysalesrepid
        {
            get  { return (String)legacysalesrepidVar.Value; }
            set  { legacysalesrepidVar.Value = value; }
        }

        public Boolean isdefaultpurchaser
        {
            get  { return (Boolean)isdefaultpurchaserVar.Value; }
            set  { isdefaultpurchaserVar.Value = value; }
        }

        public Boolean isdefaultsales
        {
            get  { return (Boolean)isdefaultsalesVar.Value; }
            set  { isdefaultsalesVar.Value = value; }
        }

        public DateTime datehired
        {
            get  { return (DateTime)datehiredVar.Value; }
            set  { datehiredVar.Value = value; }
        }

        public String line1
        {
            get  { return (String)line1Var.Value; }
            set  { line1Var.Value = value; }
        }

        public String line2
        {
            get  { return (String)line2Var.Value; }
            set  { line2Var.Value = value; }
        }

        public String line3
        {
            get  { return (String)line3Var.Value; }
            set  { line3Var.Value = value; }
        }

        public String adrcity
        {
            get  { return (String)adrcityVar.Value; }
            set  { adrcityVar.Value = value; }
        }

        public String adrstate
        {
            get  { return (String)adrstateVar.Value; }
            set  { adrstateVar.Value = value; }
        }

        public String adrzip
        {
            get  { return (String)adrzipVar.Value; }
            set  { adrzipVar.Value = value; }
        }

        public String adrcountry
        {
            get  { return (String)adrcountryVar.Value; }
            set  { adrcountryVar.Value = value; }
        }

        public String salutation
        {
            get  { return (String)salutationVar.Value; }
            set  { salutationVar.Value = value; }
        }

        public String jobtype
        {
            get  { return (String)jobtypeVar.Value; }
            set  { jobtypeVar.Value = value; }
        }

        public String strippedphone
        {
            get  { return (String)strippedphoneVar.Value; }
            set  { strippedphoneVar.Value = value; }
        }

        public String alternatephone
        {
            get  { return (String)alternatephoneVar.Value; }
            set  { alternatephoneVar.Value = value; }
        }

        public String alternatefax
        {
            get  { return (String)alternatefaxVar.Value; }
            set  { alternatefaxVar.Value = value; }
        }

        public String primaryphoneextension
        {
            get  { return (String)primaryphoneextensionVar.Value; }
            set  { primaryphoneextensionVar.Value = value; }
        }

        public Int64 contactfrequency
        {
            get  { return (Int64)contactfrequencyVar.Value; }
            set  { contactfrequencyVar.Value = value; }
        }

        public Boolean isactive
        {
            get  { return (Boolean)isactiveVar.Value; }
            set  { isactiveVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public String distilledphone
        {
            get  { return (String)distilledphoneVar.Value; }
            set  { distilledphoneVar.Value = value; }
        }

        public String distilledfax
        {
            get  { return (String)distilledfaxVar.Value; }
            set  { distilledfaxVar.Value = value; }
        }

        public String distilledcontact
        {
            get  { return (String)distilledcontactVar.Value; }
            set  { distilledcontactVar.Value = value; }
        }

        public String prospectid
        {
            get  { return (String)prospectidVar.Value; }
            set  { prospectidVar.Value = value; }
        }

        public String agentinitials
        {
            get  { return (String)agentinitialsVar.Value; }
            set  { agentinitialsVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public Boolean isduplicate
        {
            get  { return (Boolean)isduplicateVar.Value; }
            set  { isduplicateVar.Value = value; }
        }

        public String alternateemail
        {
            get  { return (String)alternateemailVar.Value; }
            set  { alternateemailVar.Value = value; }
        }

        public Int64 companynumber
        {
            get  { return (Int64)companynumberVar.Value; }
            set  { companynumberVar.Value = value; }
        }

        public Boolean hasduplicates
        {
            get  { return (Boolean)hasduplicatesVar.Value; }
            set  { hasduplicatesVar.Value = value; }
        }

        public Boolean needsreview
        {
            get  { return (Boolean)needsreviewVar.Value; }
            set  { needsreviewVar.Value = value; }
        }

        public Boolean isverified
        {
            get  { return (Boolean)isverifiedVar.Value; }
            set  { isverifiedVar.Value = value; }
        }

        public Boolean isdistributor
        {
            get  { return (Boolean)isdistributorVar.Value; }
            set  { isdistributorVar.Value = value; }
        }

        public Boolean donotemail
        {
            get  { return (Boolean)donotemailVar.Value; }
            set  { donotemailVar.Value = value; }
        }

        public Boolean donotpromote
        {
            get  { return (Boolean)donotpromoteVar.Value; }
            set  { donotpromoteVar.Value = value; }
        }

        public Boolean spam_graphic
        {
            get  { return (Boolean)spam_graphicVar.Value; }
            set  { spam_graphicVar.Value = value; }
        }

        public Boolean donotmail
        {
            get  { return (Boolean)donotmailVar.Value; }
            set  { donotmailVar.Value = value; }
        }

        public Boolean bad_data
        {
            get  { return (Boolean)bad_dataVar.Value; }
            set  { bad_dataVar.Value = value; }
        }

        public Boolean isvendor
        {
            get  { return (Boolean)isvendorVar.Value; }
            set  { isvendorVar.Value = value; }
        }

        public Boolean iscustomer
        {
            get  { return (Boolean)iscustomerVar.Value; }
            set  { iscustomerVar.Value = value; }
        }

        public String email_domain
        {
            get  { return (String)email_domainVar.Value; }
            set  { email_domainVar.Value = value; }
        }

        public Boolean is_qbimport
        {
            get  { return (Boolean)is_qbimportVar.Value; }
            set  { is_qbimportVar.Value = value; }
        }

        public DateTime lastcalldate
        {
            get  { return (DateTime)lastcalldateVar.Value; }
            set  { lastcalldateVar.Value = value; }
        }

        public String producttype
        {
            get  { return (String)producttypeVar.Value; }
            set  { producttypeVar.Value = value; }
        }

        public Boolean donotcall
        {
            get  { return (Boolean)donotcallVar.Value; }
            set  { donotcallVar.Value = value; }
        }

        public String strippedalternatephone
        {
            get  { return (String)strippedalternatephoneVar.Value; }
            set  { strippedalternatephoneVar.Value = value; }
        }

        public String abs_type
        {
            get  { return (String)abs_typeVar.Value; }
            set  { abs_typeVar.Value = value; }
        }

        public String source
        {
            get  { return (String)sourceVar.Value; }
            set  { sourceVar.Value = value; }
        }

        public String alternate_names
        {
            get  { return (String)alternate_namesVar.Value; }
            set  { alternate_namesVar.Value = value; }
        }

        public String alternate_emails
        {
            get  { return (String)alternate_emailsVar.Value; }
            set  { alternate_emailsVar.Value = value; }
        }

        public String mrp_info
        {
            get  { return (String)mrp_infoVar.Value; }
            set  { mrp_infoVar.Value = value; }
        }

        public String group_name
        {
            get  { return (String)group_nameVar.Value; }
            set  { group_nameVar.Value = value; }
        }

        public String email_suffix
        {
            get  { return (String)email_suffixVar.Value; }
            set  { email_suffixVar.Value = value; }
        }

        public Boolean is_primary
        {
            get  { return (Boolean)is_primaryVar.Value; }
            set  { is_primaryVar.Value = value; }
        }

        public String timezone
        {
            get  { return (String)timezoneVar.Value; }
            set  { timezoneVar.Value = value; }
        }

        public String alternate_mailing_address
        {
            get  { return (String)alternate_mailing_addressVar.Value; }
            set  { alternate_mailing_addressVar.Value = value; }
        }

        public String credit_card
        {
            get  { return (String)credit_cardVar.Value; }
            set  { credit_cardVar.Value = value; }
        }

        public String contact_function
        {
            get  { return (String)contact_functionVar.Value; }
            set  { contact_functionVar.Value = value; }
        }

        public String preferred_name
        {
            get  { return (String)preferred_nameVar.Value; }
            set  { preferred_nameVar.Value = value; }
        }

        public String first_name
        {
            get  { return (String)first_nameVar.Value; }
            set  { first_nameVar.Value = value; }
        }

        public String personality_type
        {
            get { return (String)personality_typeVar.Value; }
            set { personality_typeVar.Value = value; }
        }

        public Int64 hubspot_contact_id
        {
            get { return (Int64)hubspot_contact_idVar.Value; }
            set { hubspot_contact_idVar.Value = value; }
        }

         public bool send_company_shipping_email_alert
        {
            get { return (bool)send_company_shipping_email_alertVar.Value; }
            set { send_company_shipping_email_alertVar.Value = value; }
        }

        public String affiliate_id
        {
            get { return (String)affiliate_idVar.Value; }
            set { affiliate_idVar.Value = value; }
        }

        public String affiliate_name
        {
            get { return (String)affiliate_nameVar.Value; }
            set { affiliate_nameVar.Value = value; }
        }


    }
    public partial class companycontact
    {
        public static companycontact New(Context x)
        {  return (companycontact)x.Item("companycontact"); }

        public static companycontact GetById(Context x, String uid)
        { return (companycontact)x.GetById("companycontact", uid); }

        public static companycontact QtO(Context x, String sql)
        { return (companycontact)x.QtO("companycontact", sql); }
    }
}
