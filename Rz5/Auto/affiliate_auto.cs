using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("affiliate")]
    public partial class affiliate_auto : NewMethod.nObject
    {
        static affiliate_auto()
        {
            Item.AttributesCache(typeof(affiliate_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "contact_uid":
                    contact_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "contact_name":
                    contact_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_uid":
                    company_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "company_name":
                    company_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "affiliate_id":
                    affiliate_idAttribute = (CoreVarValAttribute)attr;
                    break;
                case "affiliate_name":
                    affiliate_nameAttribute = (CoreVarValAttribute)attr;
                    break;

            }
        }


        static CoreVarValAttribute contact_uidAttribute;
        static CoreVarValAttribute contact_nameAttribute;
        static CoreVarValAttribute company_uidAttribute;
        static CoreVarValAttribute company_nameAttribute;
        static CoreVarValAttribute affiliate_idAttribute;
        static CoreVarValAttribute affiliate_nameAttribute;
        

       


        [CoreVarVal("contact_uid", "String", TheFieldLength = 50, Caption = "contact_uid", Importance = 1)]
        public VarString contact_uidVar;
        [CoreVarVal("contact_name", "String", TheFieldLength = 50, Caption = "contact_name", Importance = 2)]
        public VarString contact_nameVar;
        [CoreVarVal("company_uid", "String", TheFieldLength = 50, Caption = "company_uid", Importance = 3)]
        public VarString company_uidVar;
        [CoreVarVal("company_name", "String", TheFieldLength = 50, Caption = "company_name", Importance = 4)]
        public VarString company_nameVar;
        [CoreVarVal("affiliate_id", "String", TheFieldLength = 50, Caption = "affiliate_id", Importance = 5)]
        public VarString affiliate_idVar;
        [CoreVarVal("affiliate_name", "String", TheFieldLength = 50, Caption = "affiliate_name", Importance = 6)]
        public VarString affiliate_nameVar;

        public affiliate_auto()
        {
            StaticInit();
            contact_uidVar = new VarString(this, contact_uidAttribute);
            contact_nameVar = new VarString(this, contact_nameAttribute);
            company_uidVar = new VarString(this, company_uidAttribute);
            company_nameVar = new VarString(this, company_nameAttribute);
            affiliate_idVar = new VarString(this, affiliate_idAttribute);
            affiliate_nameVar = new VarString(this, affiliate_nameAttribute);

        }    


        public override string ClassId
        { get { return "affiliate"; } }

        public String contact_uid
        {
            get { return (String)contact_uidVar.Value; }
            set { contact_uidVar.Value = value; }
        }
        public String contact_name
        {
            get { return (String)contact_nameVar.Value; }
            set { contact_nameVar.Value = value; }
        }

        public String company_uid
        {
            get { return (String)company_uidVar.Value; }
            set { company_uidVar.Value = value; }
        }

        public String company_name
        {
            get { return (String)company_nameVar.Value; }
            set { company_nameVar.Value = value; }
        }

        public String affiliate_id
        {
            get { return (String)affiliate_idVar.Value; }
            set { affiliate_idVar.Value = value; }
        }


        public String affiliate_name
        {
            get { return (String)affiliate_nameVar.Value; }
            set { affiliate_nameVar.Value = value; }
        }
        

    }
    public partial class affiliate
    {
        public static affiliate New(Context x)
        { return (affiliate)x.Item(""); }

        public static affiliate GetById(Context x, String uid)
        { return (affiliate)x.GetById("affiliate", uid); }

        public static affiliate QtO(Context x, String sql)
        { return (affiliate)x.QtO("affiliate", sql); }
    }
}
