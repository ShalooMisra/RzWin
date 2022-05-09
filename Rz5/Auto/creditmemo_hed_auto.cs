using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("creditmemo_hed", Caption="Creditmemo Hed", Importance = 87)]
    public partial class creditmemo_hed_auto : NewMethod.nObject
    {
        static creditmemo_hed_auto()
        {
            Item.AttributesCache(typeof(creditmemo_hed_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "posted_credit":
                    posted_creditAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_company_uid":
                    base_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contactname":
                    contactnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_companycontact_uid":
                    base_companycontact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "orderdate":
                    orderdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordernumber":
                    ordernumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "agentname":
                    agentnameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "ordertotal":
                    ordertotalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "type":
                    typeAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute posted_creditAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute base_company_uidAttribute;
        static CoreVarValAttribute contactnameAttribute;
        static CoreVarValAttribute base_companycontact_uidAttribute;
        static CoreVarValAttribute orderdateAttribute;
        static CoreVarValAttribute ordernumberAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute agentnameAttribute;
        static CoreVarValAttribute ordertotalAttribute;
        static CoreVarValAttribute typeAttribute;

        [CoreVarVal("posted_credit", "Boolean", Transactional = true, Caption="Posted Credit", Importance = 8)]
        public VarBoolean posted_creditVar;

        [CoreVarVal("companyname", "String", Caption="Companyname", Importance = 1)]
        public VarString companynameVar;

        [CoreVarVal("base_company_uid", "String", Caption="Base Company Uid", Importance = 2)]
        public VarString base_company_uidVar;

        [CoreVarVal("contactname", "String", Caption="Contactname", Importance = 3)]
        public VarString contactnameVar;

        [CoreVarVal("base_companycontact_uid", "String", Caption="Base Companycontact Uid", Importance = 4)]
        public VarString base_companycontact_uidVar;

        [CoreVarVal("orderdate", "DateTime", Caption="Orderdate", Importance = 5)]
        public VarDateTime orderdateVar;

        [CoreVarVal("ordernumber", "String", Caption="Ordernumber", Importance = 6)]
        public VarString ordernumberVar;

        [CoreVarVal("base_mc_user_uid", "String", Caption="Base Mc User Uid", Importance = 7)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("agentname", "String", Caption="Agentname", Importance = 8)]
        public VarString agentnameVar;

        [CoreVarVal("ordertotal", "Double", Caption="Ordertotal", Importance = 9)]
        public VarDouble ordertotalVar;

        [CoreVarVal("type", "String", Caption="Type", Importance = 12)]
        public VarString typeVar;

        public creditmemo_hed_auto()
        {
            StaticInit();
            posted_creditVar = new VarBoolean(this, posted_creditAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            base_company_uidVar = new VarString(this, base_company_uidAttribute);
            contactnameVar = new VarString(this, contactnameAttribute);
            base_companycontact_uidVar = new VarString(this, base_companycontact_uidAttribute);
            orderdateVar = new VarDateTime(this, orderdateAttribute);
            ordernumberVar = new VarString(this, ordernumberAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            agentnameVar = new VarString(this, agentnameAttribute);
            ordertotalVar = new VarDouble(this, ordertotalAttribute);
            typeVar = new VarString(this, typeAttribute);
        }

        public override string ClassId
        { get { return "creditmemo_hed"; } }

        public Boolean posted_credit
        {
            get  { return (Boolean)posted_creditVar.Value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
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

        public String base_companycontact_uid
        {
            get  { return (String)base_companycontact_uidVar.Value; }
            set  { base_companycontact_uidVar.Value = value; }
        }

        public DateTime orderdate
        {
            get  { return (DateTime)orderdateVar.Value; }
            set  { orderdateVar.Value = value; }
        }

        public String ordernumber
        {
            get  { return (String)ordernumberVar.Value; }
            set  { ordernumberVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String agentname
        {
            get  { return (String)agentnameVar.Value; }
            set  { agentnameVar.Value = value; }
        }

        public Double ordertotal
        {
            get  { return (Double)ordertotalVar.Value; }
            set  { ordertotalVar.Value = value; }
        }

        public String type
        {
            get  { return (String)typeVar.Value; }
            set  { typeVar.Value = value; }
        }

    }
    public partial class creditmemo_hed
    {
        public static creditmemo_hed New(Context x)
        {  return (creditmemo_hed)x.Item("creditmemo_hed"); }

        public static creditmemo_hed GetById(Context x, String uid)
        { return (creditmemo_hed)x.GetById("creditmemo_hed", uid); }

        public static creditmemo_hed QtO(Context x, String sql)
        { return (creditmemo_hed)x.QtO("creditmemo_hed", sql); }
    }
}
