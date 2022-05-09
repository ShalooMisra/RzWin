using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_action", Importance = -1)]
    public partial class n_action_auto : NewMethod.nObject
    {
        static n_action_auto()
        {
            Item.AttributesCache(typeof(n_action_auto), AttributeCache);
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
                case "the_n_class_uid":
                    the_n_class_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
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
                case "action_key":
                    action_keyAttribute = (CoreVarValAttribute)attr;
                    break;
                case "the_n_class_order":
                    the_n_class_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_developer":
                    only_developerAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_super":
                    only_superAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_extra":
                    only_extraAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_view":
                    is_viewAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_contextmenu":
                    only_contextmenuAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_screen":
                    only_screenAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_single":
                    only_singleAttribute = (CoreVarValAttribute)attr;
                    break;
                case "only_multiple":
                    only_multipleAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cust_specific":
                    cust_specificAttribute = (CoreVarValAttribute)attr;
                    break;
                case "cust_list_csv":
                    cust_list_csvAttribute = (CoreVarValAttribute)attr;
                    break;
                case "call_function":
                    call_functionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "vivid":
                    vividAttribute = (CoreVarValAttribute)attr;
                    break;
                case "aspect":
                    aspectAttribute = (CoreVarValAttribute)attr;
                    break;
                case "rendered_code":
                    rendered_codeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "include_handler":
                    include_handlerAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_sys_uidAttribute;
        static CoreVarValAttribute the_n_class_uidAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute icon_keyAttribute;
        static CoreVarValAttribute tag_lineAttribute;
        static CoreVarValAttribute explanationAttribute;
        static CoreVarValAttribute action_keyAttribute;
        static CoreVarValAttribute the_n_class_orderAttribute;
        static CoreVarValAttribute only_developerAttribute;
        static CoreVarValAttribute only_superAttribute;
        static CoreVarValAttribute only_extraAttribute;
        static CoreVarValAttribute is_viewAttribute;
        static CoreVarValAttribute only_contextmenuAttribute;
        static CoreVarValAttribute only_screenAttribute;
        static CoreVarValAttribute only_singleAttribute;
        static CoreVarValAttribute only_multipleAttribute;
        static CoreVarValAttribute cust_specificAttribute;
        static CoreVarValAttribute cust_list_csvAttribute;
        static CoreVarValAttribute call_functionAttribute;
        static CoreVarValAttribute vividAttribute;
        static CoreVarValAttribute aspectAttribute;
        static CoreVarValAttribute rendered_codeAttribute;
        static CoreVarValAttribute include_handlerAttribute;

        [CoreVarVal("the_n_sys_uid", "String", TheFieldLength = 255, Caption="The N Sys Uid", Importance = -2)]
        public VarString the_n_sys_uidVar;

        [CoreVarVal("the_n_class_uid", "String", Caption="The N Class Uid", Importance = -1)]
        public VarString the_n_class_uidVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 1)]
        public VarString nameVar;

        [CoreVarVal("icon_key", "String", TheFieldLength = 255, Caption="Icon Key", Importance = 7)]
        public VarString icon_keyVar;

        [CoreVarVal("tag_line", "String", TheFieldLength = 255, Caption="Tag Line", Importance = 8)]
        public VarString tag_lineVar;

        [CoreVarVal("explanation", "Text", Caption="Explanation", Importance = 9)]
        public VarText explanationVar;

        [CoreVarVal("action_key", "String", TheFieldLength = 255, Caption="Action Key", Importance = 10)]
        public VarString action_keyVar;

        [CoreVarVal("the_n_class_order", "Int64", Caption="The N Class Order", Importance = 11)]
        public VarInt64 the_n_class_orderVar;

        [CoreVarVal("only_developer", "Boolean", Caption="Only Developer", Importance = 12)]
        public VarBoolean only_developerVar;

        [CoreVarVal("only_super", "Boolean", Caption="Only Super", Importance = 13)]
        public VarBoolean only_superVar;

        [CoreVarVal("only_extra", "String", TheFieldLength = 255, Caption="Only Extra", Importance = 14)]
        public VarString only_extraVar;

        [CoreVarVal("is_view", "Boolean", Caption="Is View", Importance = 15)]
        public VarBoolean is_viewVar;

        [CoreVarVal("only_contextmenu", "Boolean", Caption="Only Contextmenu", Importance = 16)]
        public VarBoolean only_contextmenuVar;

        [CoreVarVal("only_screen", "Boolean", Caption="Only Screen", Importance = 17)]
        public VarBoolean only_screenVar;

        [CoreVarVal("only_single", "Boolean", Caption="Only Single", Importance = 18)]
        public VarBoolean only_singleVar;

        [CoreVarVal("only_multiple", "Boolean", Caption="Only Multiple", Importance = 19)]
        public VarBoolean only_multipleVar;

        [CoreVarVal("cust_specific", "Boolean", Caption="Customer Specific", Importance = 20)]
        public VarBoolean cust_specificVar;

        [CoreVarVal("cust_list_csv", "String", TheFieldLength = 255, Caption="Customer List CSV Format", Importance = 21)]
        public VarString cust_list_csvVar;

        [CoreVarVal("call_function", "String", TheFieldLength = 255, Caption="Called Function", Importance = 22)]
        public VarString call_functionVar;

        [CoreVarVal("vivid", "Int32", Caption="Vivid", Importance = 26)]
        public VarInt32 vividVar;

        [CoreVarVal("aspect", "String", TheFieldLength = 255, Caption="Aspect", Importance = 27)]
        public VarString aspectVar;

        [CoreVarVal("rendered_code", "Text", Caption="Rendered Code", Importance = 28)]
        public VarText rendered_codeVar;

        [CoreVarVal("include_handler", "Boolean", Caption="Include Handler", Importance = 29)]
        public VarBoolean include_handlerVar;

        public n_action_auto()
        {
            StaticInit();
            the_n_sys_uidVar = new VarString(this, the_n_sys_uidAttribute);
            the_n_class_uidVar = new VarString(this, the_n_class_uidAttribute);
            nameVar = new VarString(this, nameAttribute);
            icon_keyVar = new VarString(this, icon_keyAttribute);
            tag_lineVar = new VarString(this, tag_lineAttribute);
            explanationVar = new VarText(this, explanationAttribute);
            action_keyVar = new VarString(this, action_keyAttribute);
            the_n_class_orderVar = new VarInt64(this, the_n_class_orderAttribute);
            only_developerVar = new VarBoolean(this, only_developerAttribute);
            only_superVar = new VarBoolean(this, only_superAttribute);
            only_extraVar = new VarString(this, only_extraAttribute);
            is_viewVar = new VarBoolean(this, is_viewAttribute);
            only_contextmenuVar = new VarBoolean(this, only_contextmenuAttribute);
            only_screenVar = new VarBoolean(this, only_screenAttribute);
            only_singleVar = new VarBoolean(this, only_singleAttribute);
            only_multipleVar = new VarBoolean(this, only_multipleAttribute);
            cust_specificVar = new VarBoolean(this, cust_specificAttribute);
            cust_list_csvVar = new VarString(this, cust_list_csvAttribute);
            call_functionVar = new VarString(this, call_functionAttribute);
            vividVar = new VarInt32(this, vividAttribute);
            aspectVar = new VarString(this, aspectAttribute);
            rendered_codeVar = new VarText(this, rendered_codeAttribute);
            include_handlerVar = new VarBoolean(this, include_handlerAttribute);
        }

        public override string ClassId
        { get { return "n_action"; } }

        public String the_n_sys_uid
        {
            get  { return (String)the_n_sys_uidVar.Value; }
            set  { the_n_sys_uidVar.Value = value; }
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

        public String action_key
        {
            get  { return (String)action_keyVar.Value; }
            set  { action_keyVar.Value = value; }
        }

        public Int64 the_n_class_order
        {
            get  { return (Int64)the_n_class_orderVar.Value; }
            set  { the_n_class_orderVar.Value = value; }
        }

        public Boolean only_developer
        {
            get  { return (Boolean)only_developerVar.Value; }
            set  { only_developerVar.Value = value; }
        }

        public Boolean only_super
        {
            get  { return (Boolean)only_superVar.Value; }
            set  { only_superVar.Value = value; }
        }

        public String only_extra
        {
            get  { return (String)only_extraVar.Value; }
            set  { only_extraVar.Value = value; }
        }

        public Boolean is_view
        {
            get  { return (Boolean)is_viewVar.Value; }
            set  { is_viewVar.Value = value; }
        }

        public Boolean only_contextmenu
        {
            get  { return (Boolean)only_contextmenuVar.Value; }
            set  { only_contextmenuVar.Value = value; }
        }

        public Boolean only_screen
        {
            get  { return (Boolean)only_screenVar.Value; }
            set  { only_screenVar.Value = value; }
        }

        public Boolean only_single
        {
            get  { return (Boolean)only_singleVar.Value; }
            set  { only_singleVar.Value = value; }
        }

        public Boolean only_multiple
        {
            get  { return (Boolean)only_multipleVar.Value; }
            set  { only_multipleVar.Value = value; }
        }

        public Boolean cust_specific
        {
            get  { return (Boolean)cust_specificVar.Value; }
            set  { cust_specificVar.Value = value; }
        }

        public String cust_list_csv
        {
            get  { return (String)cust_list_csvVar.Value; }
            set  { cust_list_csvVar.Value = value; }
        }

        public String call_function
        {
            get  { return (String)call_functionVar.Value; }
            set  { call_functionVar.Value = value; }
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

        public String rendered_code
        {
            get  { return (String)rendered_codeVar.Value; }
            set  { rendered_codeVar.Value = value; }
        }

        public Boolean include_handler
        {
            get  { return (Boolean)include_handlerVar.Value; }
            set  { include_handlerVar.Value = value; }
        }

    }
    public partial class n_action
    {
        public static n_action New(Context x)
        {  return (n_action)x.Item("n_action"); }

        public static n_action GetById(Context x, String uid)
        { return (n_action)x.GetById("n_action", uid); }

        public static n_action QtO(Context x, String sql)
        { return (n_action)x.QtO("n_action", sql); }

        public static n_action GetByName(Context x, String name, String extraSql = "")
        { return (n_action)x.GetByName("n_action", name, extraSql); }
    }
}
