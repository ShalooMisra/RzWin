using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("partsearch")]
    public partial class partsearch_auto : NewMethod.nObject
    {
        static partsearch_auto()
        {
            Item.AttributesCache(typeof(partsearch_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "base_n_user_uid":
                    base_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "fullpartnumber":
                    fullpartnumberAttribute = (CoreVarValAttribute)attr;
                    break;
                case "searchdate":
                    searchdateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "base_mc_user_uid":
                    base_mc_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute base_n_user_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute fullpartnumberAttribute;
        static CoreVarValAttribute searchdateAttribute;
        static CoreVarValAttribute base_mc_user_uidAttribute;

        [CoreVarVal("base_n_user_uid", "String", TheFieldLength = 255, Caption="Base N User Uid", Importance = 1)]
        public VarString base_n_user_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 2)]
        public VarString nameVar;

        [CoreVarVal("fullpartnumber", "String", TheFieldLength = 255, Caption="Fullpartnumber", Importance = 3)]
        public VarString fullpartnumberVar;

        [CoreVarVal("searchdate", "DateTime", Caption="Search Date", Importance = 4)]
        public VarDateTime searchdateVar;

        [CoreVarVal("base_mc_user_uid", "String", TheFieldLength = 255, Caption="Base Mc User Uid", Importance = 5)]
        public VarString base_mc_user_uidVar;

        public partsearch_auto()
        {
            StaticInit();
            base_n_user_uidVar = new VarString(this, base_n_user_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            fullpartnumberVar = new VarString(this, fullpartnumberAttribute);
            searchdateVar = new VarDateTime(this, searchdateAttribute);
            base_mc_user_uidVar = new VarString(this, base_mc_user_uidAttribute);
        }

        public override string ClassId
        { get { return "partsearch"; } }

        public String base_n_user_uid
        {
            get  { return (String)base_n_user_uidVar.Value; }
            set  { base_n_user_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String fullpartnumber
        {
            get  { return (String)fullpartnumberVar.Value; }
            set  { fullpartnumberVar.Value = value; }
        }

        public DateTime searchdate
        {
            get  { return (DateTime)searchdateVar.Value; }
            set  { searchdateVar.Value = value; }
        }

        public String base_mc_user_uid
        {
            get  { return (String)base_mc_user_uidVar.Value; }
            set  { base_mc_user_uidVar.Value = value; }
        }

    }
    public partial class partsearch
    {
        public static partsearch New(Context x)
        {  return (partsearch)x.Item("partsearch"); }

        public static partsearch GetById(Context x, String uid)
        { return (partsearch)x.GetById("partsearch", uid); }

        public static partsearch QtO(Context x, String sql)
        { return (partsearch)x.QtO("partsearch", sql); }

        public static partsearch GetByName(Context x, String name, String extraSql = "")
        { return (partsearch)x.GetByName("partsearch", name, extraSql); }
    }
}
