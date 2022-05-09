using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("blast_adrdet")]
    public partial class blast_adrdet_auto : NewMethod.nObject
    {
        static blast_adrdet_auto()
        {
            Item.AttributesCache(typeof(blast_adrdet_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_company_uid":
                    the_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_blast_adrhed_uid":
                    the_blast_adrhed_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "list_name":
                    list_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_adr":
                    email_adrAttribute = (CoreVarValAttribute)attr;
                    break;
                case "domain_name":
                    domain_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agent_name":
                    agent_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact_name":
                    contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_name":
                    company_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agent_email":
                    agent_emailAttribute = (CoreVarValAttribute)attr;
                    break;
                case "website_login":
                    website_loginAttribute = (CoreVarValAttribute)attr;
                    break;
                case "website_id":
                    website_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "was_sent":
                    was_sentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sent_date":
                    sent_dateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "website_password":
                    website_passwordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact_first_name":
                    contact_first_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "reply_to_address":
                    reply_to_addressAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_company_uidAttribute;
        static CoreVarValAttribute the_blast_adrhed_uidAttribute;
        static CoreVarValAttribute list_nameAttribute;
        static CoreVarValAttribute email_adrAttribute;
        static CoreVarValAttribute domain_nameAttribute;
        static CoreVarValAttribute agent_nameAttribute;
        static CoreVarValAttribute contact_nameAttribute;
        static CoreVarValAttribute company_nameAttribute;
        static CoreVarValAttribute agent_emailAttribute;
        static CoreVarValAttribute website_loginAttribute;
        static CoreVarValAttribute website_idAttribute;
        static CoreVarValAttribute was_sentAttribute;
        static CoreVarValAttribute sent_dateAttribute;
        static CoreVarValAttribute website_passwordAttribute;
        static CoreVarValAttribute contact_first_nameAttribute;
        static CoreVarValAttribute reply_to_addressAttribute;

        [CoreVarVal("the_company_uid", "String", TheFieldLength = 255, Caption="The Company Uid", Importance = 1)]
        public VarString the_company_uidVar;

        [CoreVarVal("the_blast_adrhed_uid", "String", TheFieldLength = 255, Caption="The Blast Adrhed Uid", Importance = 2)]
        public VarString the_blast_adrhed_uidVar;

        [CoreVarVal("list_name", "String", TheFieldLength = 255, Caption="List Name", Importance = 3)]
        public VarString list_nameVar;

        [CoreVarVal("email_adr", "String", TheFieldLength = 255, Caption="Email Address", Importance = 4)]
        public VarString email_adrVar;

        [CoreVarVal("domain_name", "String", TheFieldLength = 255, Caption="Domain Name", Importance = 5)]
        public VarString domain_nameVar;

        [CoreVarVal("agent_name", "String", TheFieldLength = 255, Caption="Agent Name", Importance = 6)]
        public VarString agent_nameVar;

        [CoreVarVal("contact_name", "String", TheFieldLength = 255, Caption="Contact Name", Importance = 7)]
        public VarString contact_nameVar;

        [CoreVarVal("company_name", "String", TheFieldLength = 255, Caption="Company Name", Importance = 8)]
        public VarString company_nameVar;

        [CoreVarVal("agent_email", "String", TheFieldLength = 255, Caption="Agent Email", Importance = 9)]
        public VarString agent_emailVar;

        [CoreVarVal("website_login", "String", TheFieldLength = 255, Caption="Website Login", Importance = 10)]
        public VarString website_loginVar;

        [CoreVarVal("website_id", "Int32", Caption="Website Id", Importance = 11)]
        public VarInt32 website_idVar;

        [CoreVarVal("was_sent", "Boolean", Caption="Was Sent", Importance = 12)]
        public VarBoolean was_sentVar;

        [CoreVarVal("sent_date", "DateTime", Caption="Sent Date", Importance = 13)]
        public VarDateTime sent_dateVar;

        [CoreVarVal("website_password", "String", TheFieldLength = 255, Caption="Website Password", Importance = 14)]
        public VarString website_passwordVar;

        [CoreVarVal("contact_first_name", "String", TheFieldLength = 255, Caption="Contact First Name", Importance = 15)]
        public VarString contact_first_nameVar;

        [CoreVarVal("reply_to_address", "String", TheFieldLength = 255, Caption="Reply To Address", Importance = 16)]
        public VarString reply_to_addressVar;

        public blast_adrdet_auto()
        {
            StaticInit();
            the_company_uidVar = new VarString(this, the_company_uidAttribute);
            the_blast_adrhed_uidVar = new VarString(this, the_blast_adrhed_uidAttribute);
            list_nameVar = new VarString(this, list_nameAttribute);
            email_adrVar = new VarString(this, email_adrAttribute);
            domain_nameVar = new VarString(this, domain_nameAttribute);
            agent_nameVar = new VarString(this, agent_nameAttribute);
            contact_nameVar = new VarString(this, contact_nameAttribute);
            company_nameVar = new VarString(this, company_nameAttribute);
            agent_emailVar = new VarString(this, agent_emailAttribute);
            website_loginVar = new VarString(this, website_loginAttribute);
            website_idVar = new VarInt32(this, website_idAttribute);
            was_sentVar = new VarBoolean(this, was_sentAttribute);
            sent_dateVar = new VarDateTime(this, sent_dateAttribute);
            website_passwordVar = new VarString(this, website_passwordAttribute);
            contact_first_nameVar = new VarString(this, contact_first_nameAttribute);
            reply_to_addressVar = new VarString(this, reply_to_addressAttribute);
        }

        public override string ClassId
        { get { return "blast_adrdet"; } }

        public String the_company_uid
        {
            get  { return (String)the_company_uidVar.Value; }
            set  { the_company_uidVar.Value = value; }
        }

        public String the_blast_adrhed_uid
        {
            get  { return (String)the_blast_adrhed_uidVar.Value; }
            set  { the_blast_adrhed_uidVar.Value = value; }
        }

        public String list_name
        {
            get  { return (String)list_nameVar.Value; }
            set  { list_nameVar.Value = value; }
        }

        public String email_adr
        {
            get  { return (String)email_adrVar.Value; }
            set  { email_adrVar.Value = value; }
        }

        public String domain_name
        {
            get  { return (String)domain_nameVar.Value; }
            set  { domain_nameVar.Value = value; }
        }

        public String agent_name
        {
            get  { return (String)agent_nameVar.Value; }
            set  { agent_nameVar.Value = value; }
        }

        public String contact_name
        {
            get  { return (String)contact_nameVar.Value; }
            set  { contact_nameVar.Value = value; }
        }

        public String company_name
        {
            get  { return (String)company_nameVar.Value; }
            set  { company_nameVar.Value = value; }
        }

        public String agent_email
        {
            get  { return (String)agent_emailVar.Value; }
            set  { agent_emailVar.Value = value; }
        }

        public String website_login
        {
            get  { return (String)website_loginVar.Value; }
            set  { website_loginVar.Value = value; }
        }

        public Int32 website_id
        {
            get  { return (Int32)website_idVar.Value; }
            set  { website_idVar.Value = value; }
        }

        public Boolean was_sent
        {
            get  { return (Boolean)was_sentVar.Value; }
            set  { was_sentVar.Value = value; }
        }

        public DateTime sent_date
        {
            get  { return (DateTime)sent_dateVar.Value; }
            set  { sent_dateVar.Value = value; }
        }

        public String website_password
        {
            get  { return (String)website_passwordVar.Value; }
            set  { website_passwordVar.Value = value; }
        }

        public String contact_first_name
        {
            get  { return (String)contact_first_nameVar.Value; }
            set  { contact_first_nameVar.Value = value; }
        }

        public String reply_to_address
        {
            get  { return (String)reply_to_addressVar.Value; }
            set  { reply_to_addressVar.Value = value; }
        }

    }
    public partial class blast_adrdet
    {
        public static blast_adrdet New(Context x)
        {  return (blast_adrdet)x.Item("blast_adrdet"); }

        public static blast_adrdet GetById(Context x, String uid)
        { return (blast_adrdet)x.GetById("blast_adrdet", uid); }

        public static blast_adrdet QtO(Context x, String sql)
        { return (blast_adrdet)x.QtO("blast_adrdet", sql); }
    }
}
