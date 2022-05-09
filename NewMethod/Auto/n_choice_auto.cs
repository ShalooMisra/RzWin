using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_choice")]
    public partial class n_choice_auto : NewMethod.nObject
    {
        static n_choice_auto()
        {
            Item.AttributesCache(typeof(n_choice_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_choices_uid":
                    the_n_choices_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_choices_order":
                    the_n_choices_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "description":
                    descriptionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "test_text":
                    test_textAttribute = (CoreVarValAttribute)attr;
                    break;
                case "test_text2":
                    test_text2Attribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_choices_uidAttribute;
        static CoreVarValAttribute the_n_choices_orderAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute descriptionAttribute;
        static CoreVarValAttribute test_textAttribute;
        static CoreVarValAttribute test_text2Attribute;

        [CoreVarVal("the_n_choices_uid", "String", Caption="The N Choices Uid")]
        public VarString the_n_choices_uidVar;

        [CoreVarVal("the_n_choices_order", "Int64", Caption="The N Choices Order", Importance = 1)]
        public VarInt64 the_n_choices_orderVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 2)]
        public VarString nameVar;

        [CoreVarVal("description", "String", TheFieldLength = 255, Caption="Description", Importance = 3)]
        public VarString descriptionVar;

        [CoreVarVal("test_text", "String", Caption="test_text", Importance = 4)]
        public VarString test_textVar;

        [CoreVarVal("test_text2", "String", Caption="test_text2", Importance = 5)]
        public VarString test_text2Var;

        public n_choice_auto()
        {
            StaticInit();
            the_n_choices_uidVar = new VarString(this, the_n_choices_uidAttribute);
            the_n_choices_orderVar = new VarInt64(this, the_n_choices_orderAttribute);
            nameVar = new VarString(this, nameAttribute);
            descriptionVar = new VarString(this, descriptionAttribute);
            test_textVar = new VarString(this, test_textAttribute);
            test_text2Var = new VarString(this, test_text2Attribute);
        }

        public override string ClassId
        { get { return "n_choice"; } }

        public String the_n_choices_uid
        {
            get  { return (String)the_n_choices_uidVar.Value; }
            set  { the_n_choices_uidVar.Value = value; }
        }

        public Int64 the_n_choices_order
        {
            get  { return (Int64)the_n_choices_orderVar.Value; }
            set  { the_n_choices_orderVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String description
        {
            get  { return (String)descriptionVar.Value; }
            set  { descriptionVar.Value = value; }
        }

        public String test_text
        {
            get  { return (String)test_textVar.Value; }
            set  { test_textVar.Value = value; }
        }

        public String test_text2
        {
            get  { return (String)test_text2Var.Value; }
            set  { test_text2Var.Value = value; }
        }

    }
    public partial class n_choice
    {
        public static n_choice New(Context x)
        {  return (n_choice)x.Item("n_choice"); }

        public static n_choice GetById(Context x, String uid)
        { return (n_choice)x.GetById("n_choice", uid); }

        public static n_choice QtO(Context x, String sql)
        { return (n_choice)x.QtO("n_choice", sql); }

        public static n_choice GetByName(Context x, String name, String extraSql = "")
        { return (n_choice)x.GetByName("n_choice", name, extraSql); }
    }
}
