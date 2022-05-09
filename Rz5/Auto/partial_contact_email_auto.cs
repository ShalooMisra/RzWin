using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("partial_contact_email")]
    public partial class partial_contact_email_auto : NewMethod.nObject
    {
        static partial_contact_email_auto()
        {
            Item.AttributesCache(typeof(partial_contact_email_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "primaryemailaddress":
                    primaryemailaddressAttribute = (CoreVarValAttribute)attr;
                    break;
                case "source":
                    sourceAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_domain":
                    email_domainAttribute = (CoreVarValAttribute)attr;
                    break;
                case "email_suffix":
                    email_suffixAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute primaryemailaddressAttribute;
        static CoreVarValAttribute sourceAttribute;
        static CoreVarValAttribute email_domainAttribute;
        static CoreVarValAttribute email_suffixAttribute;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 1)]
        public VarString companynameVar;

        [CoreVarVal("primaryemailaddress", "String", TheFieldLength = 255, Caption="Primaryemailaddress", Importance = 2)]
        public VarString primaryemailaddressVar;

        [CoreVarVal("source", "String", TheFieldLength = 255, Caption="Source", Importance = 3)]
        public VarString sourceVar;

        [CoreVarVal("email_domain", "String", TheFieldLength = 255, Caption="Email Domain", Importance = 4)]
        public VarString email_domainVar;

        [CoreVarVal("email_suffix", "String", TheFieldLength = 255, Caption="Email Suffix", Importance = 5)]
        public VarString email_suffixVar;

        public partial_contact_email_auto()
        {
            StaticInit();
            companynameVar = new VarString(this, companynameAttribute);
            primaryemailaddressVar = new VarString(this, primaryemailaddressAttribute);
            sourceVar = new VarString(this, sourceAttribute);
            email_domainVar = new VarString(this, email_domainAttribute);
            email_suffixVar = new VarString(this, email_suffixAttribute);
        }

        public override string ClassId
        { get { return "partial_contact_email"; } }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String primaryemailaddress
        {
            get  { return (String)primaryemailaddressVar.Value; }
            set  { primaryemailaddressVar.Value = value; }
        }

        public String source
        {
            get  { return (String)sourceVar.Value; }
            set  { sourceVar.Value = value; }
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

    }
    public partial class partial_contact_email
    {
        public static partial_contact_email New(Context x)
        {  return (partial_contact_email)x.Item("partial_contact_email"); }

        public static partial_contact_email GetById(Context x, String uid)
        { return (partial_contact_email)x.GetById("partial_contact_email", uid); }

        public static partial_contact_email QtO(Context x, String sql)
        { return (partial_contact_email)x.QtO("partial_contact_email", sql); }
    }
}
