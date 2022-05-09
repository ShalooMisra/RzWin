using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("contactnote")]
    public partial class contactnote_auto : NewMethod.nObject
    {
        static contactnote_auto()
        {
            Item.AttributesCache(typeof(contactnote_auto), AttributeCache);
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
                case "batchnumber":
                    batchnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notetext":
                    notetextAttribute = (CoreVarValAttribute)attr;
                    break;
                case "noteagent":
                    noteagentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notetype":
                    notetypeAttribute = (CoreVarValAttribute)attr;
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
                case "legacyagentname":
                    legacyagentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacycompanyid":
                    legacycompanyidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "notedate":
                    notedateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isaccounting":
                    isaccountingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "legacynumber":
                    legacynumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_remote_visit":
                    is_remote_visitAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_site_audit":
                    is_site_auditAttribute = (CoreVarValAttribute)attr;
                    break;
                case "site_audit_date":
                    site_audit_dateAttribute = (CoreVarValAttribute)attr;
                    break;


                    
            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute batchnumberAttribute;
        static CoreVarValAttribute notetextAttribute;
        static CoreVarValAttribute noteagentAttribute;
        static CoreVarValAttribute notetypeAttribute;
        static CoreVarValAttribute datecreatedAttribute;
        static CoreVarValAttribute datemodifiedAttribute;
        static CoreVarValAttribute modifiedbyAttribute;
        static CoreVarValAttribute legacyagentnameAttribute;
        static CoreVarValAttribute legacycompanyidAttribute;
        static CoreVarValAttribute notedateAttribute;
        static CoreVarValAttribute isaccountingAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute legacynumberAttribute;
        static CoreVarValAttribute is_remote_visitAttribute;
        static CoreVarValAttribute is_site_auditAttribute;
        static CoreVarValAttribute site_audit_dateAttribute;
        
        
        

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 50, Caption="Base Companycontact Id", Importance = 2)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 3)]
        public VarString base_company_uidVar;

        [CoreVarVal("batchnumber", "String", TheFieldLength = 20, Caption="Batch Number", Importance = 4)]
        public VarString batchnumberVar;

        [CoreVarVal("notetext", "String", TheFieldLength = 8000, Caption="Note", Importance = 5)]
        public VarString notetextVar;

        [CoreVarVal("noteagent", "String", TheFieldLength = 255, Caption="Agent Id", Importance = 6)]
        public VarString noteagentVar;

        [CoreVarVal("notetype", "Int64", Caption="Type", Importance = 7)]
        public VarInt64 notetypeVar;

        [CoreVarVal("datecreated", "DateTime", Caption="Date Created", Importance = 8)]
        public VarDateTime datecreatedVar;

        [CoreVarVal("datemodified", "DateTime", Caption="Date Modified", Importance = 9)]
        public VarDateTime datemodifiedVar;

        [CoreVarVal("modifiedby", "String", TheFieldLength = 50, Caption="Modified By", Importance = 10)]
        public VarString modifiedbyVar;

        [CoreVarVal("legacyagentname", "String", TheFieldLength = 50, Importance = 11)]
        public VarString legacyagentnameVar;

        [CoreVarVal("legacycompanyid", "String", TheFieldLength = 50, Importance = 12)]
        public VarString legacycompanyidVar;

        [CoreVarVal("notedate", "DateTime", Caption="Note Date", Importance = 13)]
        public VarDateTime notedateVar;

        [CoreVarVal("isaccounting", "Boolean", Caption="Is Accounting", Importance = 14)]
        public VarBoolean isaccountingVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 15)]
        public VarString companynameVar;

        [CoreVarVal("agentname", "String", TheFieldLength = 50, Caption="Agent Name", Importance = 16)]
        public VarString agentnameVar;

        [CoreVarVal("contactname", "String", TheFieldLength = 255, Caption="Contact Name", Importance = 17)]
        public VarString contactnameVar;

        [CoreVarVal("legacynumber", "Int64", Caption="Legacy Number", Importance = 18)]
        public VarInt64 legacynumberVar;

        [CoreVarVal("is_remote_visit", "Boolean", Caption = "Is Remote Visit", Importance = 19)]
        public VarBoolean is_remote_visitVar;

        [CoreVarVal("is_site_audit", "Boolean", Caption = "Is Site Audit", Importance = 20)]
        public VarBoolean is_site_auditVar;

        [CoreVarVal("site_audit_date", "DateTime", Caption = "Site Audit Date", Importance = 13)]
        public VarDateTime site_audit_dateVar;
        


        public contactnote_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            batchnumberVar = new VarString(this, batchnumberAttribute);
            notetextVar = new VarString(this, notetextAttribute);
            noteagentVar = new VarString(this, noteagentAttribute);
            notetypeVar = new VarInt64(this, notetypeAttribute);
            datecreatedVar = new VarDateTime(this, datecreatedAttribute);
            datemodifiedVar = new VarDateTime(this, datemodifiedAttribute);
            modifiedbyVar = new VarString(this, modifiedbyAttribute);
            legacyagentnameVar = new VarString(this, legacyagentnameAttribute);
            legacycompanyidVar = new VarString(this, legacycompanyidAttribute);
            notedateVar = new VarDateTime(this, notedateAttribute);
            isaccountingVar = new VarBoolean(this, isaccountingAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            legacynumberVar = new VarInt64(this, legacynumberAttribute);
            is_remote_visitVar = new VarBoolean(this, is_remote_visitAttribute);
            is_site_auditVar = new VarBoolean(this, is_site_auditAttribute);
            site_audit_dateVar = new VarDateTime(this, site_audit_dateAttribute);

            
            
            
        }

        public override string ClassId
        { get { return "contactnote"; } }

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

        public String batchnumber
        {
            get  { return (String)batchnumberVar.Value; }
            set  { batchnumberVar.Value = value; }
        }

        public String notetext
        {
            get  { return (String)notetextVar.Value; }
            set  { notetextVar.Value = value; }
        }

        public String noteagent
        {
            get  { return (String)noteagentVar.Value; }
            set  { noteagentVar.Value = value; }
        }

        public Int64 notetype
        {
            get  { return (Int64)notetypeVar.Value; }
            set  { notetypeVar.Value = value; }
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

        public String legacyagentname
        {
            get  { return (String)legacyagentnameVar.Value; }
            set  { legacyagentnameVar.Value = value; }
        }

        public String legacycompanyid
        {
            get  { return (String)legacycompanyidVar.Value; }
            set  { legacycompanyidVar.Value = value; }
        }

        public DateTime notedate
        {
            get  { return (DateTime)notedateVar.Value; }
            set  { notedateVar.Value = value; }
        }

        public Boolean isaccounting
        {
            get  { return (Boolean)isaccountingVar.Value; }
            set  { isaccountingVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public String contactname
        {
            get  { return (String)contactnameVar.Value; }
            set  { contactnameVar.Value = value; }
        }

        public Int64 legacynumber
        {
            get  { return (Int64)legacynumberVar.Value; }
            set  { legacynumberVar.Value = value; }
        }

        public Boolean is_remote_visit
        {
            get { return (Boolean)is_remote_visitVar.Value; }
            set { is_remote_visitVar.Value = value; }
        }

        public Boolean is_site_audit
        {
            get { return (Boolean)is_site_auditVar.Value; }
            set { is_site_auditVar.Value = value; }
        }

        public DateTime site_audit_date
        {
            get { return (DateTime)site_audit_dateVar.Value; }
            set { site_audit_dateVar.Value = value; }
        }


        

    }
    public partial class contactnote
    {
        public static contactnote New(Context x)
        {  return (contactnote)x.Item("contactnote"); }

        public static contactnote GetById(Context x, String uid)
        { return (contactnote)x.GetById("contactnote", uid); }

        public static contactnote QtO(Context x, String sql)
        { return (contactnote)x.QtO("contactnote", sql); }
    }
}
