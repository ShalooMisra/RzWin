using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("hubspot_engagement", Caption = "Hubspot Engagement", Importance = 84)]
    public partial class hubspot_engagement_auto : NewMethod.nObject
    {
        static hubspot_engagement_auto()
        {
            Item.AttributesCache(typeof(hubspot_engagement_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "hubspotID":
                    hubspotIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "type":
                    typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "subject":
                    subjectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "body":
                    bodyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "duration":
                    durationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "toNumber":
                    toNumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fromNumber":
                    fromNumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "date":
                    dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ownerName":
                    ownerNameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ownerID":
                    ownerIDAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ownerEmail":
                    ownerEmailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "status":
                    statusAttribute = (CoreVarValAttribute)attr;
                    break;
                case "call_disposition":
                    call_dispositionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "disposition_id":
                    disposition_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_name":
                    company_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hs_company_id":
                    hs_company_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hs_contact_id":
                    hs_contact_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hs_contact_first_name":
                    hs_contact_first_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "hs_contact_last_name":
                    hs_contact_last_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "html":
                    htmlAttribute = (CoreVarValAttribute)attr;
                    break;


            }
        }

        static CoreVarValAttribute hubspotIDAttribute;
        static CoreVarValAttribute typeAttribute;
        static CoreVarValAttribute subjectAttribute;
        static CoreVarValAttribute bodyAttribute;
        static CoreVarValAttribute durationAttribute;
        static CoreVarValAttribute toNumberAttribute;
        static CoreVarValAttribute dateAttribute;
        static CoreVarValAttribute ownerNameAttribute;
        static CoreVarValAttribute ownerIDAttribute;
        static CoreVarValAttribute ownerEmailAttribute;
        static CoreVarValAttribute statusAttribute;
        static CoreVarValAttribute call_dispositionAttribute;
        static CoreVarValAttribute disposition_idAttribute;
        static CoreVarValAttribute fromNumberAttribute;
        static CoreVarValAttribute company_nameAttribute;
        static CoreVarValAttribute hs_company_idAttribute;
        static CoreVarValAttribute hs_contact_idAttribute;
        static CoreVarValAttribute hs_contact_first_nameAttribute;
        static CoreVarValAttribute hs_contact_last_nameAttribute;
        static CoreVarValAttribute htmlAttribute;



        [CoreVarVal("hubspotID", "Int64", Caption = "hubspotID", Importance = 0)]
        public VarInt64 hubspotIDVar;

        [CoreVarVal("type", "String", Caption = "type", Importance = 3)]
        public VarString typeVar;

        [CoreVarVal("subject", "String", Caption = "subject", Importance = 4)]
        public VarString subjectVar;

        [CoreVarVal("body", "Text", Caption = "body", Importance = 5)]
        public VarText bodyVar;

        [CoreVarVal("duration", "Int64", Caption = "duration", Importance = 6)]
        public VarInt64 durationVar;

        [CoreVarVal("toNumber", "String", Caption = "toNumber", Importance = 7)]
        public VarString toNumberVar;

        [CoreVarVal("date", "DateTime", Caption = "date", Importance = 8)]
        public VarDateTime dateVar;

        [CoreVarVal("ownerName", "String", Caption = "ownerName", Importance = 9)]
        public VarString ownerNameVar;

        [CoreVarVal("ownerID", "String", Caption = "ownerID", Importance = 10)]
        public VarString ownerIDVar;

        [CoreVarVal("ownerEmail", "String", Caption = "ownerEmail", Importance = 11)]
        public VarString ownerEmailVar;

        [CoreVarVal("status", "String", Caption = "status", Importance = 12)]
        public VarString statusVar;

        [CoreVarVal("call_disposition", "String", Caption = "call_disposition", Importance = 13)]
        public VarString call_dispositionVar;

        [CoreVarVal("disposition_id", "String", Caption = "disposition_id", Importance = 13)]
        public VarString disposition_idVar;

        [CoreVarVal("fromNumber", "String", Caption = "fromNumber", Importance = 14)]
        public VarString fromNumberVar;

        [CoreVarVal("company_name", "String", Caption = "company_name", Importance = 15)]
        public VarString company_nameVar;

        [CoreVarVal("hs_company_id", "Int64", Caption = "hubspot company id", Importance = 16)]
        public VarInt64 hs_company_idVar;

        [CoreVarVal("hs_contact_id", "Int64", Caption = "hubspot contact id", Importance = 17)]
        public VarInt64 hs_contact_idVar;

        [CoreVarVal("hs_contact_first_name", "String", Caption = "hubspot contact First name", Importance = 18)]
        public VarString hs_contact_first_nameVar;

        [CoreVarVal("hs_contact_last_name", "String", Caption = "hubspot contact Last name", Importance = 18)]
        public VarString hs_contact_last_nameVar;

        [CoreVarVal("html", "String", Caption = "html", Importance = 18)]
        public VarString htmlVar;

        public hubspot_engagement_auto()
        {
            StaticInit();
            hubspotIDVar = new VarInt64(this, hubspotIDAttribute);
            typeVar = new VarString(this, typeAttribute);
            subjectVar = new VarString(this, subjectAttribute);
            bodyVar = new VarText(this, bodyAttribute);
            durationVar = new VarInt64(this, durationAttribute);
            toNumberVar = new VarString(this, toNumberAttribute);
            dateVar = new VarDateTime(this, dateAttribute);
            ownerNameVar = new VarString(this, ownerNameAttribute);
            ownerIDVar = new VarString(this, ownerIDAttribute);
            ownerEmailVar = new VarString(this, ownerEmailAttribute);
            statusVar = new VarString(this, statusAttribute);
            call_dispositionVar = new VarString(this, call_dispositionAttribute);
            disposition_idVar = new VarString(this, disposition_idAttribute);
            fromNumberVar = new VarString(this, fromNumberAttribute);
            company_nameVar = new VarString(this, company_nameAttribute);
            hs_company_idVar = new VarInt64(this, hs_company_idAttribute);
            hs_contact_idVar = new VarInt64(this, hs_contact_idAttribute);
            hs_contact_first_nameVar = new VarString(this, hs_contact_first_nameAttribute);
            hs_contact_last_nameVar = new VarString(this, hs_contact_last_nameAttribute);
            htmlVar = new VarString(this, htmlAttribute);

        }

        public override string ClassId
        { get { return "hubspot_engagement"; } }

        public Int64 hubspotID
        {
            get { return (Int64)hubspotIDVar.Value; }
            set { hubspotIDVar.Value = value; }
        }

        public String type
        {
            get { return (String)typeVar.Value; }
            set { typeVar.Value = value; }
        }

        public String subject
        {
            get { return (String)subjectVar.Value; }
            set { subjectVar.Value = value; }
        }

        public string body
        {
            get { return (string)bodyVar.Value; }
            set { bodyVar.Value = value; }
        }

        public Int64 duration
        {
            get { return (Int64)durationVar.Value; }
            set { durationVar.Value = value; }
        }

        public String toNumber
        {
            get { return (String)toNumberVar.Value; }
            set { toNumberVar.Value = value; }
        }

        public DateTime date
        {
            get { return (DateTime)dateVar.Value; }
            set { dateVar.Value = value; }
        }

        public string ownerName
        {
            get { return (string)ownerNameVar.Value; }
            set { ownerNameVar.Value = value; }
        }

        public string ownerID
        {
            get { return (string)ownerIDVar.Value; }
            set { ownerIDVar.Value = value; }
        }

        public string ownerEmail
        {
            get { return (string)ownerEmailVar.Value; }
            set { ownerEmailVar.Value = value; }
        }

        public string status
        {
            get { return (string)statusVar.Value; }
            set { statusVar.Value = value; }
        }

        public string call_disposition
        {
            get { return (string)call_dispositionVar.Value; }
            set { call_dispositionVar.Value = value; }
        }
        public string disposition_id
        {
            get { return (string)disposition_idVar.Value; }
            set { disposition_idVar.Value = value; }
        }

        public String fromNumber
        {
            get { return (String)fromNumberVar.Value; }
            set { fromNumberVar.Value = value; }
        }

        public String company_name
        {
            get { return (String)company_nameVar.Value; }
            set { company_nameVar.Value = value; }
        }

        public long hs_company_id
        {
            get { return (long)hs_company_idVar.Value; }
            set { hs_company_idVar.Value = value; }
        }

        public long hs_contact_id
        {
            get { return (long)hs_contact_idVar.Value; }
            set { hs_contact_idVar.Value = value; }
        }

        public string hs_contact_first_name
        {
            get { return (string)hs_contact_first_nameVar.Value; }
            set { hs_contact_first_nameVar.Value = value; }
        }

        public string hs_contact_last_name
        {
            get { return (string)hs_contact_last_nameVar.Value; }
            set { hs_contact_last_nameVar.Value = value; }
        }

        public string html
        {
            get { return (string)htmlVar.Value; }
            set { htmlVar.Value = value; }
        }
    }
    public partial class hubspot_engagement
    {
        public static hubspot_engagement New(Context x)
        { return (hubspot_engagement)x.Item("hubspot_engagement"); }

        public static hubspot_engagement GetById(Context x, String uid)
        { return (hubspot_engagement)x.GetById("hubspot_engagement", uid); }

        public static hubspot_engagement QtO(Context x, String sql)
        { return (hubspot_engagement)x.QtO("hubspot_engagement", sql); }

        public static hubspot_engagement GetByName(Context x, String name, String extraSql = "")
        { return (hubspot_engagement)x.GetByName("hubspot_engagement", name, extraSql); }
    }
}
