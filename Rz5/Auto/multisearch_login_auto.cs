using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("multisearch_login")]
    public partial class multisearch_login_auto : NewMethod.nObject
    {
        static multisearch_login_auto()
        {
            Item.AttributesCache(typeof(multisearch_login_auto), AttributeCache);
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
                case "username":
                    usernameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "password":
                    passwordAttribute = (CoreVarValAttribute)attr;
                    break;
                case "extradata":
                    extradataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_companyinfo":
                    is_companyinfoAttribute = (CoreVarValAttribute)attr;
                    break;
                case "site_type":
                    site_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "auto_search":
                    auto_searchAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute websiteAttribute;
        static CoreVarValAttribute usernameAttribute;
        static CoreVarValAttribute passwordAttribute;
        static CoreVarValAttribute extradataAttribute;
        static CoreVarValAttribute is_companyinfoAttribute;
        static CoreVarValAttribute site_typeAttribute;
        static CoreVarValAttribute auto_searchAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("website", "String", TheFieldLength = 255, Caption="Website", Importance = 2)]
        public VarString websiteVar;

        [CoreVarVal("username", "String", TheFieldLength = 255, Caption="Username", Importance = 3)]
        public VarString usernameVar;

        [CoreVarVal("password", "String", TheFieldLength = 255, Caption="Password", Importance = 4)]
        public VarString passwordVar;

        [CoreVarVal("extradata", "String", TheFieldLength = 255, Caption="Extradata", Importance = 5)]
        public VarString extradataVar;

        [CoreVarVal("is_companyinfo", "Boolean", Caption="Is Company Info", Importance = 6)]
        public VarBoolean is_companyinfoVar;

        [CoreVarVal("site_type", "String", TheFieldLength = 255, Caption="Site Type", Importance = 7)]
        public VarString site_typeVar;

        [CoreVarVal("auto_search", "Boolean", Caption="Auto Search", Importance = 8)]
        public VarBoolean auto_searchVar;

        public multisearch_login_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            websiteVar = new VarString(this, websiteAttribute);
            usernameVar = new VarString(this, usernameAttribute);
            passwordVar = new VarString(this, passwordAttribute);
            extradataVar = new VarString(this, extradataAttribute);
            is_companyinfoVar = new VarBoolean(this, is_companyinfoAttribute);
            site_typeVar = new VarString(this, site_typeAttribute);
            auto_searchVar = new VarBoolean(this, auto_searchAttribute);
        }

        public override string ClassId
        { get { return "multisearch_login"; } }

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

        public String username
        {
            get  { return (String)usernameVar.Value; }
            set  { usernameVar.Value = value; }
        }

        public String password
        {
            get  { return (String)passwordVar.Value; }
            set  { passwordVar.Value = value; }
        }

        public String extradata
        {
            get  { return (String)extradataVar.Value; }
            set  { extradataVar.Value = value; }
        }

        public Boolean is_companyinfo
        {
            get  { return (Boolean)is_companyinfoVar.Value; }
            set  { is_companyinfoVar.Value = value; }
        }

        public String site_type
        {
            get  { return (String)site_typeVar.Value; }
            set  { site_typeVar.Value = value; }
        }

        public Boolean auto_search
        {
            get  { return (Boolean)auto_searchVar.Value; }
            set  { auto_searchVar.Value = value; }
        }

    }
    public partial class multisearch_login
    {
        public static multisearch_login New(Context x)
        {  return (multisearch_login)x.Item("multisearch_login"); }

        public static multisearch_login GetById(Context x, String uid)
        { return (multisearch_login)x.GetById("multisearch_login", uid); }

        public static multisearch_login QtO(Context x, String sql)
        { return (multisearch_login)x.QtO("multisearch_login", sql); }
    }
}
