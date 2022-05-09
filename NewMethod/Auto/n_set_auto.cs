using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_set")]
    public partial class n_set_auto : NewMethod.nObject
    {
        static n_set_auto()
        {
            Item.AttributesCache(typeof(n_set_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "setting_value":
                    setting_valueAttribute = (CoreVarValAttribute)attr;
                    break;
                case "setting_key":
                    setting_keyAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute setting_valueAttribute;
        static CoreVarValAttribute setting_keyAttribute;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("setting_value", "Text", Caption="Setting Value", Importance = 2)]
        public VarText setting_valueVar;

        [CoreVarVal("setting_key", "String", TheFieldLength = 255, Caption="Setting Key", Importance = 3)]
        public VarString setting_keyVar;

        public n_set_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
            setting_valueVar = new VarText(this, setting_valueAttribute);
            setting_keyVar = new VarString(this, setting_keyAttribute);
        }

        public override string ClassId
        { get { return "n_set"; } }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String setting_value
        {
            get  { return (String)setting_valueVar.Value; }
            set  { setting_valueVar.Value = value; }
        }

        public String setting_key
        {
            get  { return (String)setting_keyVar.Value; }
            set  { setting_keyVar.Value = value; }
        }

    }
    public partial class n_set
    {
        public static n_set New(Context x)
        {  return (n_set)x.Item("n_set"); }

        public static n_set GetById(Context x, String uid)
        { return (n_set)x.GetById("n_set", uid); }

        public static n_set QtO(Context x, String sql)
        { return (n_set)x.QtO("n_set", sql); }

        public static n_set GetByName(Context x, String name, String extraSql = "")
        { return (n_set)x.GetByName("n_set", name, extraSql); }
    }
}
