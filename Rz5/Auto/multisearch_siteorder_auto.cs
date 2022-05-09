using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("multisearch_siteorder")]
    public partial class multisearch_siteorder_auto : NewMethod.nObject
    {
        static multisearch_siteorder_auto()
        {
            Item.AttributesCache(typeof(multisearch_siteorder_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "website":
                    websiteAttribute = (CoreVarValAttribute)attr;
                    break;
                case "loadorder":
                    loadorderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "site_type":
                    site_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_hidden":
                    is_hiddenAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute websiteAttribute;
        static CoreVarValAttribute loadorderAttribute;
        static CoreVarValAttribute site_typeAttribute;
        static CoreVarValAttribute is_hiddenAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("website", "String", TheFieldLength = 255, Caption="Website", Importance = 2)]
        public VarString websiteVar;

        [CoreVarVal("loadorder", "Int64", Caption="Load Order", Importance = 3)]
        public VarInt64 loadorderVar;

        [CoreVarVal("site_type", "String", TheFieldLength = 255, Caption="Site Type", Importance = 4)]
        public VarString site_typeVar;

        [CoreVarVal("is_hidden", "Boolean", Caption="Is Hidden", Importance = 5)]
        public VarBoolean is_hiddenVar;

        public multisearch_siteorder_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            websiteVar = new VarString(this, websiteAttribute);
            loadorderVar = new VarInt64(this, loadorderAttribute);
            site_typeVar = new VarString(this, site_typeAttribute);
            is_hiddenVar = new VarBoolean(this, is_hiddenAttribute);
        }

        public override string ClassId
        { get { return "multisearch_siteorder"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String website
        {
            get  { return (String)websiteVar.Value; }
            set  { websiteVar.Value = value; }
        }

        public Int64 loadorder
        {
            get  { return (Int64)loadorderVar.Value; }
            set  { loadorderVar.Value = value; }
        }

        public String site_type
        {
            get  { return (String)site_typeVar.Value; }
            set  { site_typeVar.Value = value; }
        }

        public Boolean is_hidden
        {
            get  { return (Boolean)is_hiddenVar.Value; }
            set  { is_hiddenVar.Value = value; }
        }

    }
    public partial class multisearch_siteorder
    {
        public static multisearch_siteorder New(Context x)
        {  return (multisearch_siteorder)x.Item("multisearch_siteorder"); }

        public static multisearch_siteorder GetById(Context x, String uid)
        { return (multisearch_siteorder)x.GetById("multisearch_siteorder", uid); }

        public static multisearch_siteorder QtO(Context x, String sql)
        { return (multisearch_siteorder)x.QtO("multisearch_siteorder", sql); }
    }
}
