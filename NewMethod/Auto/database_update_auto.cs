using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("database_update", Importance = -1)]
    public partial class database_update_auto : NewMethod.nObject
    {
        static database_update_auto()
        {
            Item.AttributesCache(typeof(database_update_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "file_name":
                    file_nameAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute file_nameAttribute;

        [CoreVarVal("file_name", "String", TheFieldLength = 255, Caption="File Name", Importance = 1)]
        public VarString file_nameVar;

        public database_update_auto()
        {
            StaticInit();
            file_nameVar = new VarString(this, file_nameAttribute);
        }

        public override string ClassId
        { get { return "database_update"; } }

        public String file_name
        {
            get  { return (String)file_nameVar.Value; }
            set  { file_nameVar.Value = value; }
        }

    }
    public partial class database_update
    {
        public static database_update New(Context x)
        {  return (database_update)x.Item("database_update"); }

        public static database_update GetById(Context x, String uid)
        { return (database_update)x.GetById("database_update", uid); }

        public static database_update QtO(Context x, String sql)
        { return (database_update)x.QtO("database_update", sql); }
    }
}
