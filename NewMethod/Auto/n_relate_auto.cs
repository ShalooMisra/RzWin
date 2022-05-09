using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_relate", Importance = -1)]
    public partial class n_relate_auto : NewMethod.nObject
    {
        static n_relate_auto()
        {
            Item.AttributesCache(typeof(n_relate_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "right_n_class_uid":
                    right_n_class_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "left_n_class_uid":
                    left_n_class_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_order":
                    is_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "relate_type":
                    relate_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_legacy":
                    is_legacyAttribute = (CoreVarValAttribute)attr;
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
                case "vivid":
                    vividAttribute = (CoreVarValAttribute)attr;
                    break;
                case "aspect":
                    aspectAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute right_n_class_uidAttribute;
        static CoreVarValAttribute left_n_class_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute is_orderAttribute;
        static CoreVarValAttribute relate_typeAttribute;
        static CoreVarValAttribute is_legacyAttribute;
        static CoreVarValAttribute icon_keyAttribute;
        static CoreVarValAttribute tag_lineAttribute;
        static CoreVarValAttribute explanationAttribute;
        static CoreVarValAttribute vividAttribute;
        static CoreVarValAttribute aspectAttribute;

        [CoreVarVal("right_n_class_uid", "String", TheFieldLength = 255, Caption="Right N Class Uid", Importance = -2)]
        public VarString right_n_class_uidVar;

        [CoreVarVal("left_n_class_uid", "String", Caption="Left N Class Uid", Importance = -1)]
        public VarString left_n_class_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("is_order", "Boolean", Caption="Is Order", Importance = 2)]
        public VarBoolean is_orderVar;

        [CoreVarVal("relate_type", "Int32", Caption="Relate Type", Importance = 3)]
        public VarInt32 relate_typeVar;

        [CoreVarVal("is_legacy", "Boolean", Caption="Is Legacy", Importance = 4)]
        public VarBoolean is_legacyVar;

        [CoreVarVal("icon_key", "String", TheFieldLength = 255, Caption="Icon Key", Importance = 7)]
        public VarString icon_keyVar;

        [CoreVarVal("tag_line", "String", TheFieldLength = 255, Caption="Tag Line", Importance = 8)]
        public VarString tag_lineVar;

        [CoreVarVal("explanation", "Text", Caption="Explanation", Importance = 9)]
        public VarText explanationVar;

        [CoreVarVal("vivid", "Int32", Caption="Vivid", Importance = 10)]
        public VarInt32 vividVar;

        [CoreVarVal("aspect", "String", TheFieldLength = 255, Caption="Aspect", Importance = 11)]
        public VarString aspectVar;

        public n_relate_auto()
        {
            StaticInit();
            right_n_class_uidVar = new VarString(this, right_n_class_uidAttribute);
            left_n_class_uidVar = new VarString(this, left_n_class_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            is_orderVar = new VarBoolean(this, is_orderAttribute);
            relate_typeVar = new VarInt32(this, relate_typeAttribute);
            is_legacyVar = new VarBoolean(this, is_legacyAttribute);
            icon_keyVar = new VarString(this, icon_keyAttribute);
            tag_lineVar = new VarString(this, tag_lineAttribute);
            explanationVar = new VarText(this, explanationAttribute);
            vividVar = new VarInt32(this, vividAttribute);
            aspectVar = new VarString(this, aspectAttribute);
        }

        public override string ClassId
        { get { return "n_relate"; } }

        public String right_n_class_uid
        {
            get  { return (String)right_n_class_uidVar.Value; }
            set  { right_n_class_uidVar.Value = value; }
        }

        public String left_n_class_uid
        {
            get  { return (String)left_n_class_uidVar.Value; }
            set  { left_n_class_uidVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public Boolean is_order
        {
            get  { return (Boolean)is_orderVar.Value; }
            set  { is_orderVar.Value = value; }
        }

        public Int32 relate_type
        {
            get  { return (Int32)relate_typeVar.Value; }
            set  { relate_typeVar.Value = value; }
        }

        public Boolean is_legacy
        {
            get  { return (Boolean)is_legacyVar.Value; }
            set  { is_legacyVar.Value = value; }
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

    }
    public partial class n_relate
    {
        public static n_relate New(Context x)
        {  return (n_relate)x.Item("n_relate"); }

        public static n_relate GetById(Context x, String uid)
        { return (n_relate)x.GetById("n_relate", uid); }

        public static n_relate QtO(Context x, String sql)
        { return (n_relate)x.QtO("n_relate", sql); }

        public static n_relate GetByName(Context x, String name, String extraSql = "")
        { return (n_relate)x.GetByName("n_relate", name, extraSql); }
    }
}
