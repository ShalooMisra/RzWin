using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_prop", Importance = -1)]
    public partial class n_prop_auto : NewMethod.nObject
    {
        static n_prop_auto()
        {
            Item.AttributesCache(typeof(n_prop_auto), AttributeCache);
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
                case "the_n_class_uid":
                    the_n_class_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "property_tag":
                    property_tagAttribute = (CoreVarValAttribute)attr;
                    break;
                case "property_length":
                    property_lengthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "property_order":
                    property_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "property_type":
                    property_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "property_use":
                    property_useAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_soft":
                    is_softAttribute = (CoreVarValAttribute)attr;
                    break;
                case "choice_type":
                    choice_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_name":
                    is_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_order":
                    is_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "icon_key":
                    icon_keyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "tag_line":
                    tag_lineAttribute = (CoreVarValAttribute)attr;
                    break;
                case "explanation":
                    explanationAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_enum":
                    is_enumAttribute = (CoreVarValAttribute)attr;
                    break;
                case "enum_datatype":
                    enum_datatypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vivid":
                    vividAttribute = (CoreVarValAttribute)attr;
                    break;
                case "aspect":
                    aspectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "order_index":
                    order_indexAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_calc":
                    is_calcAttribute = (CoreVarValAttribute)attr;
                    break;
                case "calc_call":
                    calc_callAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_choices_uidAttribute;
        static CoreVarValAttribute the_n_class_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute property_tagAttribute;
        static CoreVarValAttribute property_lengthAttribute;
        static CoreVarValAttribute property_orderAttribute;
        static CoreVarValAttribute property_typeAttribute;
        static CoreVarValAttribute property_useAttribute;
        static CoreVarValAttribute is_softAttribute;
        static CoreVarValAttribute choice_typeAttribute;
        static CoreVarValAttribute is_nameAttribute;
        static CoreVarValAttribute is_orderAttribute;
        static CoreVarValAttribute icon_keyAttribute;
        static CoreVarValAttribute tag_lineAttribute;
        static CoreVarValAttribute explanationAttribute;
        static CoreVarValAttribute is_enumAttribute;
        static CoreVarValAttribute enum_datatypeAttribute;
        static CoreVarValAttribute vividAttribute;
        static CoreVarValAttribute aspectAttribute;
        static CoreVarValAttribute order_indexAttribute;
        static CoreVarValAttribute is_calcAttribute;
        static CoreVarValAttribute calc_callAttribute;

        [CoreVarVal("the_n_choices_uid", "String", TheFieldLength = 255, Caption="The N Choices Uid", Importance = -2)]
        public VarString the_n_choices_uidVar;

        [CoreVarVal("the_n_class_uid", "String", Caption="The N Class Uid", Importance = -1)]
        public VarString the_n_class_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("property_tag", "String", TheFieldLength = 255, Caption="Property Tag", Importance = 2)]
        public VarString property_tagVar;

        [CoreVarVal("property_length", "Int32", Caption="Property Length", Importance = 3)]
        public VarInt32 property_lengthVar;

        [CoreVarVal("property_order", "Int32", Caption="Property Order", Importance = 4)]
        public VarInt32 property_orderVar;

        [CoreVarVal("property_type", "Int32", Caption="Property Type", Importance = 5)]
        public VarInt32 property_typeVar;

        [CoreVarVal("property_use", "Int32", Caption="Property Use", Importance = 6)]
        public VarInt32 property_useVar;

        [CoreVarVal("is_soft", "Boolean", Caption="Is Soft", Importance = 7)]
        public VarBoolean is_softVar;

        [CoreVarVal("choice_type", "Int32", Caption="Choice Type", Importance = 8)]
        public VarInt32 choice_typeVar;

        [CoreVarVal("is_name", "Boolean", Caption="Is Name", Importance = 9)]
        public VarBoolean is_nameVar;

        [CoreVarVal("is_order", "Boolean", Caption="Is Order", Importance = 10)]
        public VarBoolean is_orderVar;

        [CoreVarVal("icon_key", "String", TheFieldLength = 255, Caption="Icon Key", Importance = 11)]
        public VarString icon_keyVar;

        [CoreVarVal("tag_line", "String", TheFieldLength = 255, Caption="Tag Line", Importance = 12)]
        public VarString tag_lineVar;

        [CoreVarVal("explanation", "Text", Caption="Explanation", Importance = 13)]
        public VarText explanationVar;

        [CoreVarVal("is_enum", "Boolean", Caption="Is Enum", Importance = 14)]
        public VarBoolean is_enumVar;

        [CoreVarVal("enum_datatype", "String", TheFieldLength = 255, Caption="Enum Data Type", Importance = 15)]
        public VarString enum_datatypeVar;

        [CoreVarVal("vivid", "Int32", Caption="Vivid", Importance = 16)]
        public VarInt32 vividVar;

        [CoreVarVal("aspect", "String", TheFieldLength = 255, Caption="Aspect", Importance = 17)]
        public VarString aspectVar;

        [CoreVarVal("order_index", "Int32", Caption="Order Index", Importance = 18)]
        public VarInt32 order_indexVar;

        [CoreVarVal("is_calc", "Boolean", Caption="Is Calc", Importance = 19)]
        public VarBoolean is_calcVar;

        [CoreVarVal("calc_call", "String", TheFieldLength = 4096, Caption="Calc Call", Importance = 20)]
        public VarString calc_callVar;

        public n_prop_auto()
        {
            StaticInit();
            the_n_choices_uidVar = new VarString(this, the_n_choices_uidAttribute);
            the_n_class_uidVar = new VarString(this, the_n_class_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            property_tagVar = new VarString(this, property_tagAttribute);
            property_lengthVar = new VarInt32(this, property_lengthAttribute);
            property_orderVar = new VarInt32(this, property_orderAttribute);
            property_typeVar = new VarInt32(this, property_typeAttribute);
            property_useVar = new VarInt32(this, property_useAttribute);
            is_softVar = new VarBoolean(this, is_softAttribute);
            choice_typeVar = new VarInt32(this, choice_typeAttribute);
            is_nameVar = new VarBoolean(this, is_nameAttribute);
            is_orderVar = new VarBoolean(this, is_orderAttribute);
            icon_keyVar = new VarString(this, icon_keyAttribute);
            tag_lineVar = new VarString(this, tag_lineAttribute);
            explanationVar = new VarText(this, explanationAttribute);
            is_enumVar = new VarBoolean(this, is_enumAttribute);
            enum_datatypeVar = new VarString(this, enum_datatypeAttribute);
            vividVar = new VarInt32(this, vividAttribute);
            aspectVar = new VarString(this, aspectAttribute);
            order_indexVar = new VarInt32(this, order_indexAttribute);
            is_calcVar = new VarBoolean(this, is_calcAttribute);
            calc_callVar = new VarString(this, calc_callAttribute);
        }

        public override string ClassId
        { get { return "n_prop"; } }

        public String the_n_choices_uid
        {
            get  { return (String)the_n_choices_uidVar.Value; }
            set  { the_n_choices_uidVar.Value = value; }
        }

        public String the_n_class_uid
        {
            get  { return (String)the_n_class_uidVar.Value; }
            set  { the_n_class_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String property_tag
        {
            get  { return (String)property_tagVar.Value; }
            set  { property_tagVar.Value = value; }
        }

        public Int32 property_length
        {
            get  { return (Int32)property_lengthVar.Value; }
            set  { property_lengthVar.Value = value; }
        }

        public Int32 property_order
        {
            get  { return (Int32)property_orderVar.Value; }
            set  { property_orderVar.Value = value; }
        }

        public Int32 property_type
        {
            get  { return (Int32)property_typeVar.Value; }
            set  { property_typeVar.Value = value; }
        }

        public Int32 property_use
        {
            get  { return (Int32)property_useVar.Value; }
            set  { property_useVar.Value = value; }
        }

        public Boolean is_soft
        {
            get  { return (Boolean)is_softVar.Value; }
            set  { is_softVar.Value = value; }
        }

        public Int32 choice_type
        {
            get  { return (Int32)choice_typeVar.Value; }
            set  { choice_typeVar.Value = value; }
        }

        public Boolean is_name
        {
            get  { return (Boolean)is_nameVar.Value; }
            set  { is_nameVar.Value = value; }
        }

        public Boolean is_order
        {
            get  { return (Boolean)is_orderVar.Value; }
            set  { is_orderVar.Value = value; }
        }

        public String icon_key
        {
            get  { return (String)icon_keyVar.Value; }
            set  { icon_keyVar.Value = value; }
        }

        public String tag_line
        {
            get  { return (String)tag_lineVar.Value; }
            set  { tag_lineVar.Value = value; }
        }

        public String explanation
        {
            get  { return (String)explanationVar.Value; }
            set  { explanationVar.Value = value; }
        }

        public Boolean is_enum
        {
            get  { return (Boolean)is_enumVar.Value; }
            set  { is_enumVar.Value = value; }
        }

        public String enum_datatype
        {
            get  { return (String)enum_datatypeVar.Value; }
            set  { enum_datatypeVar.Value = value; }
        }

        public Int32 vivid
        {
            get  { return (Int32)vividVar.Value; }
            set  { vividVar.Value = value; }
        }

        public String aspect
        {
            get  { return (String)aspectVar.Value; }
            set  { aspectVar.Value = value; }
        }

        public Int32 order_index
        {
            get  { return (Int32)order_indexVar.Value; }
            set  { order_indexVar.Value = value; }
        }

        public Boolean is_calc
        {
            get  { return (Boolean)is_calcVar.Value; }
            set  { is_calcVar.Value = value; }
        }

        public String calc_call
        {
            get  { return (String)calc_callVar.Value; }
            set  { calc_callVar.Value = value; }
        }

    }
    public partial class n_prop
    {
        public static n_prop New(Context x)
        {  return (n_prop)x.Item("n_prop"); }

        public static n_prop GetById(Context x, String uid)
        { return (n_prop)x.GetById("n_prop", uid); }

        public static n_prop QtO(Context x, String sql)
        { return (n_prop)x.QtO("n_prop", sql); }

        public static n_prop GetByName(Context x, String name, String extraSql = "")
        { return (n_prop)x.GetByName("n_prop", name, extraSql); }
    }
}
