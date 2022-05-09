using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_class", Importance = -1)]
    public partial class n_class_auto : NewMethod.nObject
    {
        static n_class_auto()
        {
            Item.AttributesCache(typeof(n_class_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_sys_uid":
                    the_n_sys_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "class_name":
                    class_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "needs_update":
                    needs_updateAttribute = (CoreVarValAttribute)attr;
                    break;
                case "class_tag":
                    class_tagAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_expanded":
                    is_expandedAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_soft":
                    is_softAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_abstract":
                    is_abstractAttribute = (CoreVarValAttribute)attr;
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
                case "plural_tag":
                    plural_tagAttribute = (CoreVarValAttribute)attr;
                    break;
                case "plural_line":
                    plural_lineAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_sys_uidAttribute;
        static CoreVarValAttribute class_nameAttribute;
        static CoreVarValAttribute needs_updateAttribute;
        static CoreVarValAttribute class_tagAttribute;
        static CoreVarValAttribute is_expandedAttribute;
        static CoreVarValAttribute is_softAttribute;
        static CoreVarValAttribute is_abstractAttribute;
        static CoreVarValAttribute icon_keyAttribute;
        static CoreVarValAttribute tag_lineAttribute;
        static CoreVarValAttribute explanationAttribute;
        static CoreVarValAttribute vividAttribute;
        static CoreVarValAttribute aspectAttribute;
        static CoreVarValAttribute plural_tagAttribute;
        static CoreVarValAttribute plural_lineAttribute;

        [CoreVarVal("the_n_sys_uid", "String", Caption="The N Sys Uid", Importance = -1)]
        public VarString the_n_sys_uidVar;

        [CoreVarVal("class_name", "String", TheFieldLength = 255, Caption="Class Name", Importance = 1)]
        public VarString class_nameVar;

        [CoreVarVal("needs_update", "Boolean", Caption="Needs Update", Importance = 2)]
        public VarBoolean needs_updateVar;

        [CoreVarVal("class_tag", "String", TheFieldLength = 255, Caption="Class Tag", Importance = 3)]
        public VarString class_tagVar;

        [CoreVarVal("is_expanded", "Boolean", Caption="Is Expanded", Importance = 4)]
        public VarBoolean is_expandedVar;

        [CoreVarVal("is_soft", "Boolean", Caption="Is Soft", Importance = 5)]
        public VarBoolean is_softVar;

        [CoreVarVal("is_abstract", "Boolean", Caption="Is Abstract", Importance = 6)]
        public VarBoolean is_abstractVar;

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

        [CoreVarVal("plural_tag", "String", TheFieldLength = 255, Caption="Plural Tag", Importance = 12)]
        public VarString plural_tagVar;

        [CoreVarVal("plural_line", "String", TheFieldLength = 255, Caption="Plural Line", Importance = 13)]
        public VarString plural_lineVar;

        public n_class_auto()
        {
            StaticInit();
            the_n_sys_uidVar = new VarString(this, the_n_sys_uidAttribute);
            class_nameVar = new VarString(this, class_nameAttribute);
            needs_updateVar = new VarBoolean(this, needs_updateAttribute);
            class_tagVar = new VarString(this, class_tagAttribute);
            is_expandedVar = new VarBoolean(this, is_expandedAttribute);
            is_softVar = new VarBoolean(this, is_softAttribute);
            is_abstractVar = new VarBoolean(this, is_abstractAttribute);
            icon_keyVar = new VarString(this, icon_keyAttribute);
            tag_lineVar = new VarString(this, tag_lineAttribute);
            explanationVar = new VarText(this, explanationAttribute);
            vividVar = new VarInt32(this, vividAttribute);
            aspectVar = new VarString(this, aspectAttribute);
            plural_tagVar = new VarString(this, plural_tagAttribute);
            plural_lineVar = new VarString(this, plural_lineAttribute);
        }

        public override string ClassId
        { get { return "n_class"; } }

        public String the_n_sys_uid
        {
            get  { return (String)the_n_sys_uidVar.Value; }
            set  { the_n_sys_uidVar.Value = value; }
        }

        public String class_name
        {
            get  { return (String)class_nameVar.Value; }
            set  { class_nameVar.Value = value; }
        }

        public Boolean needs_update
        {
            get  { return (Boolean)needs_updateVar.Value; }
            set  { needs_updateVar.Value = value; }
        }

        public String class_tag
        {
            get  { return (String)class_tagVar.Value; }
            set  { class_tagVar.Value = value; }
        }

        public Boolean is_expanded
        {
            get  { return (Boolean)is_expandedVar.Value; }
            set  { is_expandedVar.Value = value; }
        }

        public Boolean is_soft
        {
            get  { return (Boolean)is_softVar.Value; }
            set  { is_softVar.Value = value; }
        }

        public Boolean is_abstract
        {
            get  { return (Boolean)is_abstractVar.Value; }
            set  { is_abstractVar.Value = value; }
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

        public String plural_tag
        {
            get  { return (String)plural_tagVar.Value; }
            set  { plural_tagVar.Value = value; }
        }

        public String plural_line
        {
            get  { return (String)plural_lineVar.Value; }
            set  { plural_lineVar.Value = value; }
        }

    }
    public partial class n_class
    {
        public static n_class New(Context x)
        {  return (n_class)x.Item("n_class"); }

        public static n_class GetById(Context x, String uid)
        { return (n_class)x.GetById("n_class", uid); }

        public static n_class QtO(Context x, String sql)
        { return (n_class)x.QtO("n_class", sql); }
    }
}
