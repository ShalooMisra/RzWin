using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_template")]
    public partial class n_template_auto : NewMethod.nObject
    {
        static n_template_auto()
        {
            Item.AttributesCache(typeof(n_template_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_class_uid":
                    the_n_class_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "template_name":
                    template_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "class_name":
                    class_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "background_repeat":
                    background_repeatAttribute = (CoreVarValAttribute)attr;
                    break;
                case "color_1":
                    color_1Attribute = (CoreVarValAttribute)attr;
                    break;
                case "color_2":
                    color_2Attribute = (CoreVarValAttribute)attr;
                    break;
                case "color_3":
                    color_3Attribute = (CoreVarValAttribute)attr;
                    break;
                case "color_4":
                    color_4Attribute = (CoreVarValAttribute)attr;
                    break;
                case "color_5":
                    color_5Attribute = (CoreVarValAttribute)attr;
                    break;
                case "color_6":
                    color_6Attribute = (CoreVarValAttribute)attr;
                    break;
                case "use_gridlines":
                    use_gridlinesAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_class_uidAttribute;
        static CoreVarValAttribute template_nameAttribute;
        static CoreVarValAttribute class_nameAttribute;
        static CoreVarValAttribute background_repeatAttribute;
        static CoreVarValAttribute color_1Attribute;
        static CoreVarValAttribute color_2Attribute;
        static CoreVarValAttribute color_3Attribute;
        static CoreVarValAttribute color_4Attribute;
        static CoreVarValAttribute color_5Attribute;
        static CoreVarValAttribute color_6Attribute;
        static CoreVarValAttribute use_gridlinesAttribute;

        [CoreVarVal("the_n_class_uid", "String", Caption="Class ID")]
        public VarString the_n_class_uidVar;

        [CoreVarVal("template_name", "String", TheFieldLength = 255, Caption="Template Name", Importance = 1)]
        public VarString template_nameVar;

        [CoreVarVal("class_name", "String", TheFieldLength = 255, Caption="Class Name", Importance = 2)]
        public VarString class_nameVar;

        [CoreVarVal("background_repeat", "Int32", Caption="Background Repeat", Importance = 3)]
        public VarInt32 background_repeatVar;

        [CoreVarVal("color_1", "Int32", Caption="Color 1", Importance = 4)]
        public VarInt32 color_1Var;

        [CoreVarVal("color_2", "Int32", Caption="Color 2", Importance = 5)]
        public VarInt32 color_2Var;

        [CoreVarVal("color_3", "Int32", Caption="Color 3", Importance = 6)]
        public VarInt32 color_3Var;

        [CoreVarVal("color_4", "Int32", Caption="Color 4", Importance = 7)]
        public VarInt32 color_4Var;

        [CoreVarVal("color_5", "Int32", Caption="Color 5", Importance = 8)]
        public VarInt32 color_5Var;

        [CoreVarVal("color_6", "Int32", Caption="Color 6", Importance = 9)]
        public VarInt32 color_6Var;

        [CoreVarVal("use_gridlines", "Boolean", Caption="Use Gridlines", Importance = 10)]
        public VarBoolean use_gridlinesVar;

        public n_template_auto()
        {
            StaticInit();
            the_n_class_uidVar = new VarString(this, the_n_class_uidAttribute);
            template_nameVar = new VarString(this, template_nameAttribute);
            class_nameVar = new VarString(this, class_nameAttribute);
            background_repeatVar = new VarInt32(this, background_repeatAttribute);
            color_1Var = new VarInt32(this, color_1Attribute);
            color_2Var = new VarInt32(this, color_2Attribute);
            color_3Var = new VarInt32(this, color_3Attribute);
            color_4Var = new VarInt32(this, color_4Attribute);
            color_5Var = new VarInt32(this, color_5Attribute);
            color_6Var = new VarInt32(this, color_6Attribute);
            use_gridlinesVar = new VarBoolean(this, use_gridlinesAttribute);
        }

        public override string ClassId
        { get { return "n_template"; } }

        public String the_n_class_uid
        {
            get  { return (String)the_n_class_uidVar.Value; }
            set  { the_n_class_uidVar.Value = value; }
        }

        public String template_name
        {
            get  { return (String)template_nameVar.Value; }
            set  { template_nameVar.Value = value; }
        }

        public String class_name
        {
            get  { return (String)class_nameVar.Value; }
            set  { class_nameVar.Value = value; }
        }

        public Int32 background_repeat
        {
            get  { return (Int32)background_repeatVar.Value; }
            set  { background_repeatVar.Value = value; }
        }

        public Int32 color_1
        {
            get  { return (Int32)color_1Var.Value; }
            set  { color_1Var.Value = value; }
        }

        public Int32 color_2
        {
            get  { return (Int32)color_2Var.Value; }
            set  { color_2Var.Value = value; }
        }

        public Int32 color_3
        {
            get  { return (Int32)color_3Var.Value; }
            set  { color_3Var.Value = value; }
        }

        public Int32 color_4
        {
            get  { return (Int32)color_4Var.Value; }
            set  { color_4Var.Value = value; }
        }

        public Int32 color_5
        {
            get  { return (Int32)color_5Var.Value; }
            set  { color_5Var.Value = value; }
        }

        public Int32 color_6
        {
            get  { return (Int32)color_6Var.Value; }
            set  { color_6Var.Value = value; }
        }

        public Boolean use_gridlines
        {
            get  { return (Boolean)use_gridlinesVar.Value; }
            set  { use_gridlinesVar.Value = value; }
        }

    }
    public partial class n_template
    {
        public static n_template New(Context x)
        {  return (n_template)x.Item("n_template"); }

        public static n_template GetById(Context x, String uid)
        { return (n_template)x.GetById("n_template", uid); }

        public static n_template QtO(Context x, String sql)
        { return (n_template)x.QtO("n_template", sql); }
    }
}
