using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("companyaddress")]
    public partial class companyaddress_auto : NewMethod.nObject
    {
        static companyaddress_auto()
        {
            Item.AttributesCache(typeof(companyaddress_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
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
                case "defaultbilling":
                    defaultbillingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "defaultshipping":
                    defaultshippingAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute line1Attribute;
        static CoreVarValAttribute line2Attribute;
        static CoreVarValAttribute line3Attribute;
        static CoreVarValAttribute adrcityAttribute;
        static CoreVarValAttribute adrstateAttribute;
        static CoreVarValAttribute adrzipAttribute;
        static CoreVarValAttribute adrcountryAttribute;
        static CoreVarValAttribute defaultbillingAttribute;
        static CoreVarValAttribute defaultshippingAttribute;
        static CoreVarValAttribute companynameAttribute;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 50, Caption="Base Companycontact Id", Importance = 1)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 3)]
        public VarString descriptionVar;

        [CoreVarVal("line1", "String", TheFieldLength = 255, Caption="Line 1", Importance = 4)]
        public VarString line1Var;

        [CoreVarVal("line2", "String", TheFieldLength = 255, Caption="Line 2", Importance = 5)]
        public VarString line2Var;

        [CoreVarVal("line3", "String", TheFieldLength = 255, Caption="Line3", Importance = 6)]
        public VarString line3Var;

        [CoreVarVal("adrcity", "String", TheFieldLength = 255, Caption="City", Importance = 7)]
        public VarString adrcityVar;

        [CoreVarVal("adrstate", "String", TheFieldLength = 255, Caption="State", Importance = 8)]
        public VarString adrstateVar;

        [CoreVarVal("adrzip", "String", TheFieldLength = 255, Caption="Zip", Importance = 9)]
        public VarString adrzipVar;

        [CoreVarVal("adrcountry", "String", TheFieldLength = 255, Caption="Country", Importance = 10)]
        public VarString adrcountryVar;

        [CoreVarVal("defaultbilling", "Boolean", Caption="Default Billing", Importance = 11)]
        public VarBoolean defaultbillingVar;

        [CoreVarVal("defaultshipping", "Boolean", Caption="Default Shipping", Importance = 12)]
        public VarBoolean defaultshippingVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Companyname", Importance = 13)]
        public VarString companynameVar;

        public companyaddress_auto()
        {
            StaticInit();
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            line1Var = new VarString(this, line1Attribute);
            line2Var = new VarString(this, line2Attribute);
            line3Var = new VarString(this, line3Attribute);
            adrcityVar = new VarString(this, adrcityAttribute);
            adrstateVar = new VarString(this, adrstateAttribute);
            adrzipVar = new VarString(this, adrzipAttribute);
            adrcountryVar = new VarString(this, adrcountryAttribute);
            defaultbillingVar = new VarBoolean(this, defaultbillingAttribute);
            defaultshippingVar = new VarBoolean(this, defaultshippingAttribute);
            companynameVar = new VarString(this, companynameAttribute);
        }

        public override string ClassId
        { get { return "companyaddress"; } }

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

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
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

        public Boolean defaultbilling
        {
            get  { return (Boolean)defaultbillingVar.Value; }
            set  { defaultbillingVar.Value = value; }
        }

        public Boolean defaultshipping
        {
            get  { return (Boolean)defaultshippingVar.Value; }
            set  { defaultshippingVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

    }
    public partial class companyaddress
    {
        public static companyaddress New(Context x)
        {  return (companyaddress)x.Item("companyaddress"); }

        public static companyaddress GetById(Context x, String uid)
        { return (companyaddress)x.GetById("companyaddress", uid); }

        public static companyaddress QtO(Context x, String sql)
        { return (companyaddress)x.QtO("companyaddress", sql); }
    }
}
