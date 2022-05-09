using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_choices")]
    public partial class n_choices_auto : NewMethod.nObject
    {
        static n_choices_auto()
        {
            Item.AttributesCache(typeof(n_choices_auto), AttributeCache);
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
            }
        }

        static CoreVarValAttribute nameAttribute;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        public n_choices_auto()
        {
            StaticInit();
            nameVar = new VarString(this, nameAttribute);
        }

        public override string ClassId
        { get { return "n_choices"; } }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

    }
    public partial class n_choices
    {
        public static n_choices New(Context x)
        {  return (n_choices)x.Item("n_choices"); }

        public static n_choices GetById(Context x, String uid)
        { return (n_choices)x.GetById("n_choices", uid); }

        public static n_choices QtO(Context x, String sql)
        { return (n_choices)x.QtO("n_choices", sql); }

        public static n_choices GetByName(Context x, String name, String extraSql = "")
        { return (n_choices)x.GetByName("n_choices", name, extraSql); }
    }
}
