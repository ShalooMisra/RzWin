using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Core;

namespace NewMethod
{
    [CoreClass("n_column")]
    public partial class n_column_auto : NewMethod.nObject
    {
        static n_column_auto()
        {
            Item.AttributesCache(typeof(n_column_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_template_uid":
                    the_n_template_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "field_name":
                    field_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "column_caption":
                    column_captionAttribute = (CoreVarValAttribute)attr;
                    break;
                case "column_width":
                    column_widthAttribute = (CoreVarValAttribute)attr;
                    break;
                case "column_alignment":
                    column_alignmentAttribute = (CoreVarValAttribute)attr;
                    break;
                case "column_order":
                    column_orderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "column_format":
                    column_formatAttribute = (CoreVarValAttribute)attr;
                    break;
                case "data_type":
                    data_typeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "name":
                    nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "relate_class":
                    relate_classAttribute = (CoreVarValAttribute)attr;
                    break;
                case "relate_name":
                    relate_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "function_name":
                    function_nameAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_enum":
                    is_enumAttribute = (CoreVarValAttribute)attr;
                    break;
                case "enum_datatype":
                    enum_datatypeAttribute = (CoreVarValAttribute)attr;
                    break;
                case "translate_enum":
                    translate_enumAttribute = (CoreVarValAttribute)attr;
                    break;
                case "is_entry_field":
                    is_entry_fieldAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_template_uidAttribute;
        static CoreVarValAttribute field_nameAttribute;
        static CoreVarValAttribute column_captionAttribute;
        static CoreVarValAttribute column_widthAttribute;
        static CoreVarValAttribute column_alignmentAttribute;
        static CoreVarValAttribute column_orderAttribute;
        static CoreVarValAttribute column_formatAttribute;
        static CoreVarValAttribute data_typeAttribute;
        static CoreVarValAttribute nameAttribute;
        static CoreVarValAttribute relate_classAttribute;
        static CoreVarValAttribute relate_nameAttribute;
        static CoreVarValAttribute function_nameAttribute;
        static CoreVarValAttribute is_enumAttribute;
        static CoreVarValAttribute enum_datatypeAttribute;
        static CoreVarValAttribute translate_enumAttribute;
        static CoreVarValAttribute is_entry_fieldAttribute;

        [CoreVarVal("the_n_template_uid", "String", Caption="Template ID")]
        public VarString the_n_template_uidVar;

        [CoreVarVal("field_name", "String", TheFieldLength = 255, Caption="Field Name", Importance = 1)]
        public VarString field_nameVar;

        [CoreVarVal("column_caption", "String", TheFieldLength = 255, Caption="Column Caption", Importance = 2)]
        public VarString column_captionVar;

        [CoreVarVal("column_width", "Int32", Caption="Column Width", Importance = 3)]
        public VarInt32 column_widthVar;

        [CoreVarVal("column_alignment", "Int32", Caption="Column Alignment", Importance = 4)]
        public VarInt32 column_alignmentVar;

        [CoreVarVal("column_order", "Int32", Caption="Column Order", Importance = 5)]
        public VarInt32 column_orderVar;

        [CoreVarVal("column_format", "String", TheFieldLength = 255, Caption="Column Format", Importance = 6)]
        public VarString column_formatVar;

        [CoreVarVal("data_type", "Int32", Caption="Data Type", Importance = 7)]
        public VarInt32 data_typeVar;

        [CoreVarVal("name", "String", TheFieldLength = 255, Caption="Name", Importance = 8)]
        public VarString nameVar;

        [CoreVarVal("relate_class", "String", TheFieldLength = 255, Caption="Relate Class", Importance = 9)]
        public VarString relate_classVar;

        [CoreVarVal("relate_name", "String", TheFieldLength = 255, Caption="Relate Name", Importance = 10)]
        public VarString relate_nameVar;

        [CoreVarVal("function_name", "String", TheFieldLength = 255, Caption="Function Name", Importance = 11)]
        public VarString function_nameVar;

        [CoreVarVal("is_enum", "Boolean", Caption="Is Enum", Importance = 12)]
        public VarBoolean is_enumVar;

        [CoreVarVal("enum_datatype", "String", TheFieldLength = 255, Caption="Enum Data Type", Importance = 13)]
        public VarString enum_datatypeVar;

        [CoreVarVal("translate_enum", "Boolean", Caption="Translate Enum", Importance = 14)]
        public VarBoolean translate_enumVar;

        [CoreVarVal("is_entry_field", "Boolean", Caption="Is Entry Field", Importance = 15)]
        public VarBoolean is_entry_fieldVar;

        public n_column_auto()
        {
            StaticInit();
            the_n_template_uidVar = new VarString(this, the_n_template_uidAttribute);
            field_nameVar = new VarString(this, field_nameAttribute);
            column_captionVar = new VarString(this, column_captionAttribute);
            column_widthVar = new VarInt32(this, column_widthAttribute);
            column_alignmentVar = new VarInt32(this, column_alignmentAttribute);
            column_orderVar = new VarInt32(this, column_orderAttribute);
            column_formatVar = new VarString(this, column_formatAttribute);
            data_typeVar = new VarInt32(this, data_typeAttribute);
            nameVar = new VarString(this, nameAttribute);
            relate_classVar = new VarString(this, relate_classAttribute);
            relate_nameVar = new VarString(this, relate_nameAttribute);
            function_nameVar = new VarString(this, function_nameAttribute);
            is_enumVar = new VarBoolean(this, is_enumAttribute);
            enum_datatypeVar = new VarString(this, enum_datatypeAttribute);
            translate_enumVar = new VarBoolean(this, translate_enumAttribute);
            is_entry_fieldVar = new VarBoolean(this, is_entry_fieldAttribute);
        }

        public override string ClassId
        { get { return "n_column"; } }

        public String the_n_template_uid
        {
            get  { return (String)the_n_template_uidVar.Value; }
            set  { the_n_template_uidVar.Value = value; }
        }

        public String field_name
        {
            get  { return (String)field_nameVar.Value; }
            set  { field_nameVar.Value = value; }
        }

        public String column_caption
        {
            get  { return (String)column_captionVar.Value; }
            set  { column_captionVar.Value = value; }
        }

        public Int32 column_width
        {
            get  { return (Int32)column_widthVar.Value; }
            set  { column_widthVar.Value = value; }
        }

        public Int32 column_alignment
        {
            get  { return (Int32)column_alignmentVar.Value; }
            set  { column_alignmentVar.Value = value; }
        }

        public Int32 column_order
        {
            get  { return (Int32)column_orderVar.Value; }
            set  { column_orderVar.Value = value; }
        }

        public String column_format
        {
            get  { return (String)column_formatVar.Value; }
            set  { column_formatVar.Value = value; }
        }

        public Int32 data_type
        {
            get  { return (Int32)data_typeVar.Value; }
            set  { data_typeVar.Value = value; }
        }

        public String name
        {
            get  { return (String)nameVar.Value; }
            set  { nameVar.Value = value; }
        }

        public String relate_class
        {
            get  { return (String)relate_classVar.Value; }
            set  { relate_classVar.Value = value; }
        }

        public String relate_name
        {
            get  { return (String)relate_nameVar.Value; }
            set  { relate_nameVar.Value = value; }
        }

        public String function_name
        {
            get  { return (String)function_nameVar.Value; }
            set  { function_nameVar.Value = value; }
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

        public Boolean translate_enum
        {
            get  { return (Boolean)translate_enumVar.Value; }
            set  { translate_enumVar.Value = value; }
        }

        public Boolean is_entry_field
        {
            get  { return (Boolean)is_entry_fieldVar.Value; }
            set  { is_entry_fieldVar.Value = value; }
        }

    }
    public partial class n_column
    {
        public static n_column New(Context x)
        {  return (n_column)x.Item("n_column"); }

        public static n_column GetById(Context x, String uid)
        { return (n_column)x.GetById("n_column", uid); }

        public static n_column QtO(Context x, String sql)
        { return (n_column)x.QtO("n_column", sql); }

        public static n_column GetByName(Context x, String name, String extraSql = "")
        { return (n_column)x.GetByName("n_column", name, extraSql); }
    }
}
