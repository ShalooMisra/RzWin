using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("calllog")]
    public partial class calllog_auto : NewMethod.nObject
    {
        static calllog_auto()
        {
            Item.AttributesCache(typeof(calllog_auto), AttributeCache);
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
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calldate":
                    calldateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "batchnumber":
                    batchnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "callcompanyname":
                    callcompanynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sessionid":
                    sessionidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "callresult":
                    callresultAttribute = (CoreVarValAttribute)attr;
                    break;
                case "callnotes":
                    callnotesAttribute = (CoreVarValAttribute)attr;
                    break;
                case "datecall":
                    datecallAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calltype":
                    calltypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "callorder":
                    callorderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "responsetype":
                    responsetypeAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute calldateAttribute;
        static CoreVarValAttribute batchnumberAttribute;
        static CoreVarValAttribute callcompanynameAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute sessionidAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute callresultAttribute;
        static CoreVarValAttribute callnotesAttribute;
        static CoreVarValAttribute datecallAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute calltypeAttribute;
        static CoreVarValAttribute callorderAttribute;
        static CoreVarValAttribute responsetypeAttribute;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 50, Caption="Base Companycontact Id", Importance = 2)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 3)]
        public VarString base_company_uidVar;

        [CoreVarVal("calldate", "String", TheFieldLength = 255, Caption="Call Date", Importance = 4)]
        public VarString calldateVar;

        [CoreVarVal("batchnumber", "String", TheFieldLength = 20, Caption="Batch Number", Importance = 5)]
        public VarString batchnumberVar;

        [CoreVarVal("callcompanyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 6)]
        public VarString callcompanynameVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Contact Name", Importance = 7)]
        public VarString contactnameVar;

        [CoreVarVal("sessionid", "String", TheFieldLength = 255, Caption="Session Id", Importance = 8)]
        public VarString sessionidVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption="Agent Name", Importance = 9)]
        public VarString agentnameVar;

        [CoreVarVal("callresult", "String", TheFieldLength = 255, Caption="Result", Importance = 10)]
        public VarString callresultVar;

        [CoreVarVal("callnotes", "String", TheFieldLength = 4096, Caption="Notes", Importance = 11)]
        public VarString callnotesVar;

        [CoreVarVal("datecall", "DateTime", Caption="Date Call", Importance = 12)]
        public VarDateTime datecallVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Part Number", Importance = 13)]
        public VarString fullpartnumberVar;

        [CoreVarVal("calltype", "String", TheFieldLength = 50, Caption="Call Type", Importance = 14)]
        public VarString calltypeVar;

        [CoreVarVal("callorder", "Int64", Caption="Call Order", Importance = 15)]
        public VarInt64 callorderVar;

        [CoreVarVal("responsetype", "String", TheFieldLength = 50, Caption="Response Type", Importance = 16)]
        public VarString responsetypeVar;

        public calllog_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            calldateVar = new VarString(this, calldateAttribute);
            batchnumberVar = new VarString(this, batchnumberAttribute);
            callcompanynameVar = new VarString(this, callcompanynameAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            sessionidVar = new VarString(this, sessionidAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            callresultVar = new VarString(this, callresultAttribute);
            callnotesVar = new VarString(this, callnotesAttribute);
            datecallVar = new VarDateTime(this, datecallAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            calltypeVar = new VarString(this, calltypeAttribute);
            callorderVar = new VarInt64(this, callorderAttribute);
            responsetypeVar = new VarString(this, responsetypeAttribute);
        }

        public override string ClassId
        { get { return "calllog"; } }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String base_companycontact_uid
        {
            get  { return (String)base_companycontact_uidVar.Value; }
            set  { base_companycontact_uidVar.Value = value; }
        }

        public String base_company_uid
        {
            get  { return (String)base_company_uidVar.Value; }
            set  { base_company_uidVar.Value = value; }
        }

        public String calldate
        {
            get  { return (String)calldateVar.Value; }
            set  { calldateVar.Value = value; }
        }

        public String batchnumber
        {
            get  { return (String)batchnumberVar.Value; }
            set  { batchnumberVar.Value = value; }
        }

        public String callcompanyname
        {
            get  { return (String)callcompanynameVar.Value; }
            set  { callcompanynameVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public String sessionid
        {
            get  { return (String)sessionidVar.Value; }
            set  { sessionidVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public String callresult
        {
            get  { return (String)callresultVar.Value; }
            set  { callresultVar.Value = value; }
        }

        public String callnotes
        {
            get  { return (String)callnotesVar.Value; }
            set  { callnotesVar.Value = value; }
        }

        public DateTime datecall
        {
            get  { return (DateTime)datecallVar.Value; }
            set  { datecallVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public String calltype
        {
            get  { return (String)calltypeVar.Value; }
            set  { calltypeVar.Value = value; }
        }

        public Int64 callorder
        {
            get  { return (Int64)callorderVar.Value; }
            set  { callorderVar.Value = value; }
        }

        public String responsetype
        {
            get  { return (String)responsetypeVar.Value; }
            set  { responsetypeVar.Value = value; }
        }

    }
    public partial class calllog
    {
        public static calllog New(Context x)
        {  return (calllog)x.Item("calllog"); }

        public static calllog GetById(Context x, String uid)
        { return (calllog)x.GetById("calllog", uid); }

        public static calllog QtO(Context x, String sql)
        { return (calllog)x.QtO("calllog", sql); }
    }
}
