using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("phonecall")]
    public partial class phonecall_auto : NewMethod.nObject
    {
        static phonecall_auto()
        {
            Item.AttributesCache(typeof(phonecall_auto), AttributeCache);
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
                case "alldata":
                    alldataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "callextension":
                    callextensionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "username":
                    usernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calldate":
                    calldateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duration":
                    durationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "phonenumber":
                    phonenumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "direction":
                    directionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "phoneline":
                    phonelineAttribute = (CoreVarValAttribute)attr;
                    break;
                case "timestarted":
                    timestartedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "holdtime":
                    holdtimeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "transferextension":
                    transferextensionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "main_mc_team_uid":
                    main_mc_team_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_1":
                    alternate_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_2":
                    alternate_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_3":
                    alternate_3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_4":
                    alternate_4Attribute = (CoreVarValAttribute)attr;
                    break;
                case "alternate_5":
                    alternate_5Attribute = (CoreVarValAttribute)attr;
                    break;
                case "strippedphone":
                    strippedphoneAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stats_message":
                    stats_messageAttribute = (CoreVarValAttribute)attr;
                    break;
                case "stats_count":
                    stats_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company":
                    companyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact":
                    contactAttribute = (CoreVarValAttribute)attr;
                    break;
                case "abs_type":
                    abs_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "customer_type":
                    customer_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "from_call_list":
                    from_call_listAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_customer":
                    is_customerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_prospect":
                    is_prospectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_agent_prospect":
                    is_agent_prospectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_agent_customer":
                    is_agent_customerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "recording_count":
                    recording_countAttribute = (CoreVarValAttribute)attr;
                    break;
                case "recording_file":
                    recording_fileAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_international":
                    is_internationalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email":
                    emailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_domain":
                    email_domainAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_suffix":
                    email_suffixAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_priority_defense":
                    is_priority_defenseAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hubspot_engagement_id":
                    hubspot_engagement_idAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute alldataAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute callextensionAttribute;
        static CoreVarValAttribute usernameAttribute;
        static CoreVarValAttribute calldateAttribute;
        static CoreVarValAttribute durationAttribute;
        static CoreVarValAttribute phonenumberAttribute;
        static CoreVarValAttribute directionAttribute;
        static CoreVarValAttribute phonelineAttribute;
        static CoreVarValAttribute timestartedAttribute;
        static CoreVarValAttribute holdtimeAttribute;
        static CoreVarValAttribute transferextensionAttribute;
        static CoreVarValAttribute main_mc_team_uidAttribute;
        static CoreVarValAttribute alternate_1Attribute;
        static CoreVarValAttribute alternate_2Attribute;
        static CoreVarValAttribute alternate_3Attribute;
        static CoreVarValAttribute alternate_4Attribute;
        static CoreVarValAttribute alternate_5Attribute;
        static CoreVarValAttribute strippedphoneAttribute;
        static CoreVarValAttribute stats_messageAttribute;
        static CoreVarValAttribute stats_countAttribute;
        static CoreVarValAttribute companyAttribute;
        static CoreVarValAttribute contactAttribute;
        static CoreVarValAttribute abs_typeAttribute;
        static CoreVarValAttribute customer_typeAttribute;
        static CoreVarValAttribute from_call_listAttribute;
        static CoreVarValAttribute is_customerAttribute;
        static CoreVarValAttribute is_prospectAttribute;
        static CoreVarValAttribute is_agent_prospectAttribute;
        static CoreVarValAttribute is_agent_customerAttribute;
        static CoreVarValAttribute recording_countAttribute;
        static CoreVarValAttribute recording_fileAttribute;
        static CoreVarValAttribute is_internationalAttribute;
        static CoreVarValAttribute emailAttribute;
        static CoreVarValAttribute email_domainAttribute;
        static CoreVarValAttribute email_suffixAttribute;
        static CoreVarValAttribute is_priority_defenseAttribute;
        static CoreVarValAttribute hubspot_engagement_idAttribute;
        

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("alldata", "String", TheFieldLength = 8000, Caption="All Data", Importance = 3)]
        public VarString alldataVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 4)]
        public VarString companynameVar;

        [CoreVarVal("callextension", "String", TheFieldLength = 10, Caption="Extension", Importance = 5)]
        public VarString callextensionVar;

        [CoreVarVal("username", "String", TheFieldLength = 50, Caption="User Name", Importance = 6)]
        public VarString usernameVar;

        [CoreVarVal("calldate", "DateTime", Caption="Call Date", Importance = 7)]
        public VarDateTime calldateVar;

        [CoreVarVal("duration", "Int64", Caption="Duaration", Importance = 8)]
        public VarInt64 durationVar;

        [CoreVarVal("phonenumber", "String", TheFieldLength = 255, Caption="Phone Number", Importance = 9)]
        public VarString phonenumberVar;

        [CoreVarVal("direction", "String", TheFieldLength = 4, Caption="Direction", Importance = 10)]
        public VarString directionVar;

        [CoreVarVal("phoneline", "String", TheFieldLength = 255, Caption="Phone Line", Importance = 11)]
        public VarString phonelineVar;

        [CoreVarVal("timestarted", "String", TheFieldLength = 50, Caption="Time Started", Importance = 12)]
        public VarString timestartedVar;

        [CoreVarVal("holdtime", "String", TheFieldLength = 50, Caption="Hold Time", Importance = 13)]
        public VarString holdtimeVar;

        [CoreVarVal("transferextension", "String", TheFieldLength = 50, Caption="Transfer Extension", Importance = 14)]
        public VarString transferextensionVar;

        [CoreVarVal("main_mc_team_uid", "String", TheFieldLength = 255, Caption="Main Mc Team Uid", Importance = 15)]
        public VarString main_mc_team_uidVar;

        [CoreVarVal("alternate_1", "String", TheFieldLength = 255, Caption="Alternate 1", Importance = 16)]
        public VarString alternate_1Var;

        [CoreVarVal("alternate_2", "String", TheFieldLength = 255, Caption="Alternate 2", Importance = 17)]
        public VarString alternate_2Var;

        [CoreVarVal("alternate_3", "String", TheFieldLength = 255, Caption="Alternate 3", Importance = 18)]
        public VarString alternate_3Var;

        [CoreVarVal("alternate_4", "String", TheFieldLength = 255, Caption="Alternate 4", Importance = 19)]
        public VarString alternate_4Var;

        [CoreVarVal("alternate_5", "String", TheFieldLength = 255, Caption="Alternate 5", Importance = 20)]
        public VarString alternate_5Var;

        [CoreVarVal("strippedphone", "String", TheFieldLength = 255, Caption="Strippedphone", Importance = 21)]
        public VarString strippedphoneVar;

        [CoreVarVal("stats_message", "String", TheFieldLength = 8000, Caption="Stats Message", Importance = 22)]
        public VarString stats_messageVar;

        [CoreVarVal("stats_count", "Int64", Caption="Stats Count", Importance = 23)]
        public VarInt64 stats_countVar;

        [CoreVarVal("company", "String", TheFieldLength = 255, Caption="Company", Importance = 24)]
        public VarString companyVar;

        [CoreVarVal("contact", "String", TheFieldLength = 255, Caption="Contact", Importance = 25)]
        public VarString contactVar;

        [CoreVarVal("abs_type", "String", TheFieldLength = 255, Caption="Abs Type", Importance = 26)]
        public VarString abs_typeVar;

        [CoreVarVal("customer_type", "String", TheFieldLength = 255, Caption="Customer Type", Importance = 27)]
        public VarString customer_typeVar;

        [CoreVarVal("from_call_list", "Boolean", Caption="From Call List", Importance = 28)]
        public VarBoolean from_call_listVar;

        [CoreVarVal("is_customer", "Boolean", Caption="Is Customer", Importance = 29)]
        public VarBoolean is_customerVar;

        [CoreVarVal("is_prospect", "Boolean", Caption="Is Prospect", Importance = 30)]
        public VarBoolean is_prospectVar;

        [CoreVarVal("is_agent_prospect", "Boolean", Caption="Is Agent Prospect", Importance = 31)]
        public VarBoolean is_agent_prospectVar;

        [CoreVarVal("is_agent_customer", "Boolean", Caption="Is Agent Customer", Importance = 32)]
        public VarBoolean is_agent_customerVar;

        [CoreVarVal("recording_count", "Int32", Caption="Recording Count", Importance = 33)]
        public VarInt32 recording_countVar;

        [CoreVarVal("recording_file", "String", TheFieldLength = 8000, Caption="Recording File", Importance = 34)]
        public VarString recording_fileVar;

        [CoreVarVal("is_international", "Boolean", Caption="Is International", Importance = 35)]
        public VarBoolean is_internationalVar;

        [CoreVarVal("email", "String", TheFieldLength = 255, Caption="Email", Importance = 36)]
        public VarString emailVar;

        [CoreVarVal("email_domain", "String", TheFieldLength = 255, Caption="Email Domain", Importance = 37)]
        public VarString email_domainVar;

        [CoreVarVal("email_suffix", "String", TheFieldLength = 255, Caption="Email Suffix", Importance = 38)]
        public VarString email_suffixVar;

        [CoreVarVal("is_priority_defense", "Boolean", Caption="Is Priority Defense", Importance = 39)]
        public VarBoolean is_priority_defenseVar;

        [CoreVarVal("hubspot_engagement_id", "String", TheFieldLength = 255, Caption = "Huspot Engagement ID", Importance = 40)]
        public VarString hubspot_engagement_idVar;

        

        public phonecall_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            alldataVar = new VarString(this, alldataAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            callextensionVar = new VarString(this, callextensionAttribute);
            usernameVar = new VarString(this, usernameAttribute);
            calldateVar = new VarDateTime(this, calldateAttribute);
            durationVar = new VarInt64(this, durationAttribute);
            phonenumberVar = new VarString(this, phonenumberAttribute);
            directionVar = new VarString(this, directionAttribute);
            phonelineVar = new VarString(this, phonelineAttribute);
            timestartedVar = new VarString(this, timestartedAttribute);
            holdtimeVar = new VarString(this, holdtimeAttribute);
            transferextensionVar = new VarString(this, transferextensionAttribute);
            main_mc_team_uidVar = new VarString(this, main_mc_team_uidAttribute);
            alternate_1Var = new VarString(this, alternate_1Attribute);
            alternate_2Var = new VarString(this, alternate_2Attribute);
            alternate_3Var = new VarString(this, alternate_3Attribute);
            alternate_4Var = new VarString(this, alternate_4Attribute);
            alternate_5Var = new VarString(this, alternate_5Attribute);
            strippedphoneVar = new VarString(this, strippedphoneAttribute);
            stats_messageVar = new VarString(this, stats_messageAttribute);
            stats_countVar = new VarInt64(this, stats_countAttribute);
            companyVar = new VarString(this, companyAttribute);
            contactVar = new VarString(this, contactAttribute);
            abs_typeVar = new VarString(this, abs_typeAttribute);
            customer_typeVar = new VarString(this, customer_typeAttribute);
            from_call_listVar = new VarBoolean(this, from_call_listAttribute);
            is_customerVar = new VarBoolean(this, is_customerAttribute);
            is_prospectVar = new VarBoolean(this, is_prospectAttribute);
            is_agent_prospectVar = new VarBoolean(this, is_agent_prospectAttribute);
            is_agent_customerVar = new VarBoolean(this, is_agent_customerAttribute);
            recording_countVar = new VarInt32(this, recording_countAttribute);
            recording_fileVar = new VarString(this, recording_fileAttribute);
            is_internationalVar = new VarBoolean(this, is_internationalAttribute);
            emailVar = new VarString(this, emailAttribute);
            email_domainVar = new VarString(this, email_domainAttribute);
            email_suffixVar = new VarString(this, email_suffixAttribute);
            is_priority_defenseVar = new VarBoolean(this, is_priority_defenseAttribute);
            hubspot_engagement_idVar = new VarString(this, hubspot_engagement_idAttribute);
            
        }

        public override string ClassId
        { get { return "phonecall"; } }

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

        public String alldata
        {
            get  { return (String)alldataVar.Value; }
            set  { alldataVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String callextension
        {
            get  { return (String)callextensionVar.Value; }
            set  { callextensionVar.Value = value; }
        }

        public String username
        {
            get  { return (String)usernameVar.Value; }
            set  { usernameVar.Value = value; }
        }

        public DateTime calldate
        {
            get  { return (DateTime)calldateVar.Value; }
            set  { calldateVar.Value = value; }
        }

        public Int64 duration
        {
            get  { return (Int64)durationVar.Value; }
            set  { durationVar.Value = value; }
        }

        public String phonenumber
        {
            get  { return (String)phonenumberVar.Value; }
            set  { phonenumberVar.Value = value; }
        }

        public String direction
        {
            get  { return (String)directionVar.Value; }
            set  { directionVar.Value = value; }
        }

        public String phoneline
        {
            get  { return (String)phonelineVar.Value; }
            set  { phonelineVar.Value = value; }
        }

        public String timestarted
        {
            get  { return (String)timestartedVar.Value; }
            set  { timestartedVar.Value = value; }
        }

        public String holdtime
        {
            get  { return (String)holdtimeVar.Value; }
            set  { holdtimeVar.Value = value; }
        }

        public String transferextension
        {
            get  { return (String)transferextensionVar.Value; }
            set  { transferextensionVar.Value = value; }
        }

        public String main_mc_team_uid
        {
            get  { return (String)main_mc_team_uidVar.Value; }
            set  { main_mc_team_uidVar.Value = value; }
        }

        public String alternate_1
        {
            get  { return (String)alternate_1Var.Value; }
            set  { alternate_1Var.Value = value; }
        }

        public String alternate_2
        {
            get  { return (String)alternate_2Var.Value; }
            set  { alternate_2Var.Value = value; }
        }

        public String alternate_3
        {
            get  { return (String)alternate_3Var.Value; }
            set  { alternate_3Var.Value = value; }
        }

        public String alternate_4
        {
            get  { return (String)alternate_4Var.Value; }
            set  { alternate_4Var.Value = value; }
        }

        public String alternate_5
        {
            get  { return (String)alternate_5Var.Value; }
            set  { alternate_5Var.Value = value; }
        }

        public String strippedphone
        {
            get  { return (String)strippedphoneVar.Value; }
            set  { strippedphoneVar.Value = value; }
        }

        public String stats_message
        {
            get  { return (String)stats_messageVar.Value; }
            set  { stats_messageVar.Value = value; }
        }

        public Int64 stats_count
        {
            get  { return (Int64)stats_countVar.Value; }
            set  { stats_countVar.Value = value; }
        }

        public String company
        {
            get  { return (String)companyVar.Value; }
            set  { companyVar.Value = value; }
        }

        public String contact
        {
            get  { return (String)contactVar.Value; }
            set  { contactVar.Value = value; }
        }

        public String abs_type
        {
            get  { return (String)abs_typeVar.Value; }
            set  { abs_typeVar.Value = value; }
        }

        public String customer_type
        {
            get  { return (String)customer_typeVar.Value; }
            set  { customer_typeVar.Value = value; }
        }

        public Boolean from_call_list
        {
            get  { return (Boolean)from_call_listVar.Value; }
            set  { from_call_listVar.Value = value; }
        }

        public Boolean is_customer
        {
            get  { return (Boolean)is_customerVar.Value; }
            set  { is_customerVar.Value = value; }
        }

        public Boolean is_prospect
        {
            get  { return (Boolean)is_prospectVar.Value; }
            set  { is_prospectVar.Value = value; }
        }

        public Boolean is_agent_prospect
        {
            get  { return (Boolean)is_agent_prospectVar.Value; }
            set  { is_agent_prospectVar.Value = value; }
        }

        public Boolean is_agent_customer
        {
            get  { return (Boolean)is_agent_customerVar.Value; }
            set  { is_agent_customerVar.Value = value; }
        }

        public Int32 recording_count
        {
            get  { return (Int32)recording_countVar.Value; }
            set  { recording_countVar.Value = value; }
        }

        public String recording_file
        {
            get  { return (String)recording_fileVar.Value; }
            set  { recording_fileVar.Value = value; }
        }

        public Boolean is_international
        {
            get  { return (Boolean)is_internationalVar.Value; }
            set  { is_internationalVar.Value = value; }
        }

        public String email
        {
            get  { return (String)emailVar.Value; }
            set  { emailVar.Value = value; }
        }

        public String email_domain
        {
            get  { return (String)email_domainVar.Value; }
            set  { email_domainVar.Value = value; }
        }

        public String email_suffix
        {
            get  { return (String)email_suffixVar.Value; }
            set  { email_suffixVar.Value = value; }
        }

        public Boolean is_priority_defense
        {
            get  { return (Boolean)is_priority_defenseVar.Value; }
            set  { is_priority_defenseVar.Value = value; }
        }

        public string hubspot_engagement_id
        {
            get { return (string)hubspot_engagement_idVar.Value; }
            set { hubspot_engagement_idVar.Value = value; }
        }


        


    }
    public partial class phonecall
    {
        public static phonecall New(Context x)
        {  return (phonecall)x.Item("phonecall"); }

        public static phonecall GetById(Context x, String uid)
        { return (phonecall)x.GetById("phonecall", uid); }

        public static phonecall QtO(Context x, String sql)
        { return (phonecall)x.QtO("phonecall", sql); }
    }
}
