using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("mfg_link")]
    public partial class mfg_link_auto : NewMethod.nObject
    {
        static mfg_link_auto()
        {
            Item.AttributesCache(typeof(mfg_link_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_manufacturer_uid":
                    the_manufacturer_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_choice_uid":
                    the_n_choice_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_company_uid":
                    the_company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companyname":
                    companynameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "manufacturer":
                    manufacturerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "link_type":
                    link_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "companytype":
                    companytypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_authorized":
                    is_authorizedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_stocking":
                    is_stockingAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_manufacturer_uidAttribute;
        static CoreVarValAttribute the_n_choice_uidAttribute;
        static CoreVarValAttribute the_company_uidAttribute;
        static CoreVarValAttribute companynameAttribute;
        static CoreVarValAttribute manufacturerAttribute;
        static CoreVarValAttribute link_typeAttribute;
        static CoreVarValAttribute companytypeAttribute;
        static CoreVarValAttribute is_authorizedAttribute;
        static CoreVarValAttribute is_stockingAttribute;

        [CoreVarVal("the_manufacturer_uid", "String", TheFieldLength = 255, Caption="The Manufacturer Uid", Importance = 1)]
        public VarString the_manufacturer_uidVar;

        [CoreVarVal("the_n_choice_uid", "String", TheFieldLength = 255, Caption="The N Choice Uid", Importance = 2)]
        public VarString the_n_choice_uidVar;

        [CoreVarVal("the_company_uid", "String", TheFieldLength = 255, Caption="The Company Uid", Importance = 3)]
        public VarString the_company_uidVar;

        [CoreVarVal("companyname", "String", TheFieldLength = 255, Caption="Company Name", Importance = 4)]
        public VarString companynameVar;

        [CoreVarVal("manufacturer", "String", TheFieldLength = 255, Caption="Manufacturer", Importance = 5)]
        public VarString manufacturerVar;

        [CoreVarVal("link_type", "String", TheFieldLength = 255, Caption="Link Type", Importance = 6)]
        public VarString link_typeVar;

        [CoreVarVal("companytype", "String", TheFieldLength = 255, Caption="Companytype", Importance = 7)]
        public VarString companytypeVar;

        [CoreVarVal("is_authorized", "Boolean", Caption="Is Authorized", Importance = 8)]
        public VarBoolean is_authorizedVar;

        [CoreVarVal("is_stocking", "Boolean", Caption="Is Stocking", Importance = 9)]
        public VarBoolean is_stockingVar;

        public mfg_link_auto()
        {
            StaticInit();
            the_manufacturer_uidVar = new VarString(this, the_manufacturer_uidAttribute);
            the_n_choice_uidVar = new VarString(this, the_n_choice_uidAttribute);
            the_company_uidVar = new VarString(this, the_company_uidAttribute);
            companynameVar = new VarString(this, companynameAttribute);
            manufacturerVar = new VarString(this, manufacturerAttribute);
            link_typeVar = new VarString(this, link_typeAttribute);
            companytypeVar = new VarString(this, companytypeAttribute);
            is_authorizedVar = new VarBoolean(this, is_authorizedAttribute);
            is_stockingVar = new VarBoolean(this, is_stockingAttribute);
        }

        public override string ClassId
        { get { return "mfg_link"; } }

        public String the_manufacturer_uid
        {
            get  { return (String)the_manufacturer_uidVar.Value; }
            set  { the_manufacturer_uidVar.Value = value; }
        }

        public String the_n_choice_uid
        {
            get  { return (String)the_n_choice_uidVar.Value; }
            set  { the_n_choice_uidVar.Value = value; }
        }

        public String the_company_uid
        {
            get  { return (String)the_company_uidVar.Value; }
            set  { the_company_uidVar.Value = value; }
        }

        public String companyname
        {
            get  { return (String)companynameVar.Value; }
            set  { companynameVar.Value = value; }
        }

        public String manufacturer
        {
            get  { return (String)manufacturerVar.Value; }
            set  { manufacturerVar.Value = value; }
        }

        public String link_type
        {
            get  { return (String)link_typeVar.Value; }
            set  { link_typeVar.Value = value; }
        }

        public String companytype
        {
            get  { return (String)companytypeVar.Value; }
            set  { companytypeVar.Value = value; }
        }

        public Boolean is_authorized
        {
            get  { return (Boolean)is_authorizedVar.Value; }
            set  { is_authorizedVar.Value = value; }
        }

        public Boolean is_stocking
        {
            get  { return (Boolean)is_stockingVar.Value; }
            set  { is_stockingVar.Value = value; }
        }

    }
    public partial class mfg_link
    {
        public static mfg_link New(Context x)
        {  return (mfg_link)x.Item("mfg_link"); }

        public static mfg_link GetById(Context x, String uid)
        { return (mfg_link)x.GetById("mfg_link", uid); }

        public static mfg_link QtO(Context x, String sql)
        { return (mfg_link)x.QtO("mfg_link", sql); }
    }
}
