using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("shippingaccount")]
    public partial class shippingaccount_auto : NewMethod.nObject
    {
        static shippingaccount_auto()
        {
            Item.AttributesCache(typeof(shippingaccount_auto), AttributeCache);
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
                case "accountnumber":
                    accountnumberAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute accountnumberAttribute;

        [CoreVarVal("base_companycontact_uid", "String", TheFieldLength = 50, Caption="Base Companycontact Id", Importance = 1)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("base_company_uid", "String", TheFieldLength = 50, Caption="Base Company Id", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("description", "String", TheFieldLength = 50, Caption="Description", Importance = 3)]
        public VarString descriptionVar;

        [CoreVarVal("accountnumber", "String", TheFieldLength = 50, Caption="Number:", Importance = 4)]
        public VarString accountnumberVar;

        public shippingaccount_auto()
        {
            StaticInit();
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            accountnumberVar = new VarString(this, accountnumberAttribute);
        }

        public override string ClassId
        { get { return "shippingaccount"; } }

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

        public String accountnumber
        {
            get  { return (String)accountnumberVar.Value; }
            set  { accountnumberVar.Value = value; }
        }

    }
    public partial class shippingaccount
    {
        public static shippingaccount New(Context x)
        {  return (shippingaccount)x.Item("shippingaccount"); }

        public static shippingaccount GetById(Context x, String uid)
        { return (shippingaccount)x.GetById("shippingaccount", uid); }

        public static shippingaccount QtO(Context x, String sql)
        { return (shippingaccount)x.QtO("shippingaccount", sql); }
    }
}
