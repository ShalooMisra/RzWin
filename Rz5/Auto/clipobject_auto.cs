using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("clipobject")]
    public partial class clipobject_auto : NewMethod.nObject
    {
        static clipobject_auto()
        {
            Item.AttributesCache(typeof(clipobject_auto), AttributeCache);
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
                case "objectid":
                    objectidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objectclassid":
                    objectclassidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objectcaption":
                    objectcaptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "objectnamecaption":
                    objectnamecaptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "alternatedata":
                    alternatedataAttribute = (CoreVarValAttribute)attr;
                    break;
                case "isglobal":
                    isglobalAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_mc_user_uidAttribute;
        static CoreVarValAttribute objectidAttribute;
        static CoreVarValAttribute objectclassidAttribute;
        static CoreVarValAttribute objectcaptionAttribute;
        static CoreVarValAttribute objectnamecaptionAttribute;
        static CoreVarValAttribute alternatedataAttribute;
        static CoreVarValAttribute isglobalAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 50, Caption="User Id", Importance = 1)]
        public VarString base_mc_user_uidVar;

        [CoreVarVal("objectid", "String", TheFieldLength = 50, Caption="Object Id", Importance = 2)]
        public VarString objectidVar;

        [CoreVarVal("objectclassid", "String", TheFieldLength = 50, Caption="Object Class", Importance = 3)]
        public VarString objectclassidVar;

        [CoreVarVal("objectcaption", "String", TheFieldLength = 50, Caption="Caption", Importance = 4)]
        public VarString objectcaptionVar;

        [CoreVarVal("objectnamecaption", "String", TheFieldLength = 50, Caption="Object Name Caption", Importance = 5)]
        public VarString objectnamecaptionVar;

        [CoreVarVal("alternatedata", "String", TheFieldLength = 50, Caption="Alternate", Importance = 6)]
        public VarString alternatedataVar;

        [CoreVarVal("isglobal", "Boolean", Caption="Is Global", Importance = 7)]
        public VarBoolean isglobalVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Part Number", Importance = 8)]
        public VarString fullpartnumberVar;

        public clipobject_auto()
        {
            StaticInit();
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
            objectidVar = new VarString(this, objectidAttribute);
            objectclassidVar = new VarString(this, objectclassidAttribute);
            objectcaptionVar = new VarString(this, objectcaptionAttribute);
            objectnamecaptionVar = new VarString(this, objectnamecaptionAttribute);
            alternatedataVar = new VarString(this, alternatedataAttribute);
            isglobalVar = new VarBoolean(this, isglobalAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
        }

        public override string ClassId
        { get { return "clipobject"; } }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

        public String objectid
        {
            get  { return (String)objectidVar.Value; }
            set  { objectidVar.Value = value; }
        }

        public String objectclassid
        {
            get  { return (String)objectclassidVar.Value; }
            set  { objectclassidVar.Value = value; }
        }

        public String objectcaption
        {
            get  { return (String)objectcaptionVar.Value; }
            set  { objectcaptionVar.Value = value; }
        }

        public String objectnamecaption
        {
            get  { return (String)objectnamecaptionVar.Value; }
            set  { objectnamecaptionVar.Value = value; }
        }

        public String alternatedata
        {
            get  { return (String)alternatedataVar.Value; }
            set  { alternatedataVar.Value = value; }
        }

        public Boolean isglobal
        {
            get  { return (Boolean)isglobalVar.Value; }
            set  { isglobalVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

    }
    public partial class clipobject
    {
        public static clipobject New(Context x)
        {  return (clipobject)x.Item("clipobject"); }

        public static clipobject GetById(Context x, String uid)
        { return (clipobject)x.GetById("clipobject", uid); }

        public static clipobject QtO(Context x, String sql)
        { return (clipobject)x.QtO("clipobject", sql); }
    }
}
