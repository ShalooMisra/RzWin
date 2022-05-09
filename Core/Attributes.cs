using System;
using System.Collections.Generic;
using System.Text;

using Tools.Database;
using Core.Display;

namespace Core
{
    //[AttributeUsage(AttributeTargets.Class |
    //AttributeTargets.Constructor |
    //AttributeTargets.Field |
    //AttributeTargets.Method |
    //AttributeTargets.Property,
    //AllowMultiple = true)]

    public class CoreAttribute : Attribute, IComparable
    {
        public String Name = "";
        public int Importance = 0;

        public CoreAttribute(String name) : this(name, -1)
        {
        }

        public CoreAttribute(String name, int importance)
        {
            Name = name;
            Importance = importance;
        }

        public int CompareTo(Object x)
        {
            try
            {
                int other = ((CoreAttribute)x).Importance;
                return Importance.CompareTo(other);
            }
            catch { return 0; }
        }

        public void RenderStatic(CodeBuilder cb)
        {
            cb.AppendLine("        static " + AttributeType + "Attribute " + Name + "Attribute;");
        }

        public void RenderStaticAssign(CodeBuilder cb)
        {
            cb.AppendLine("                case \"" + Name + "\":");
            cb.AppendLine("                    " + Name + "Attribute = (" + AttributeType + "Attribute)attr;");
            cb.AppendLine("                    break;");
        }

        public virtual String AttributeType
        {
            get
            {
                return "";
            }
        }

        public virtual void RenderDeclare(CodeBuilder cb)
        {
            cb.AppendLine(Indent + "[" + AttributeType + "(\"" + Name + "\"" + RenderDeclareExtraPositional() + RenderDeclareExtraNamed() + ")]");
        }

        public virtual String RenderDeclareExtraPositional()
        {
            return "";
        }

        public virtual String RenderDeclareExtraNamed()
        {
            String ret = "";

            if (SystemSupport)
                ret += ", SystemSupport=true";

            if (m_Caption != "")
                ret += ", Caption=\"" + Caption + "\"";

            if( Importance != -1 )
                ret += ", Importance = " + Importance.ToString();

            return ret;
        }

        bool m_SystemSupport = false;
        public bool SystemSupport
        {
            get
            {
                return m_SystemSupport;
            }

            set
            {
                m_SystemSupport = value;
            }
        }

        String m_Caption = "";
        public String Caption
        {
            get
            {
                if (m_Caption == "")
                    return Tools.Strings.NiceFormat(Name);
                else
                    return Tools.Strings.NiceFormat(m_Caption);
            }
            set
            {
                m_Caption = value;
            }
        }

        public String CaptionPlural
        {
            get
            {
                return Tools.Strings.PluralizeName(Caption);
            }
        }

        public virtual String Indent
        {
            get
            {
                return "    ";
            }
        }

        public static int CompareByName(CoreAttribute a1, CoreAttribute a2)
        {
            return a1.Name.CompareTo(a2.Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class CoreSysAttribute : CoreAttribute
    {
        String m_BaseSystem = "";
        public String BaseSystem
        {
            get
            {
                return m_BaseSystem;
            }

            set
            {
                m_BaseSystem = value;
            }
        }

        public CoreSysAttribute(String name)
            : base(name)
        {
        }

        public override string AttributeType
        {
            get
            {
                return "CoreSys";
            }
        }

        public override void RenderDeclare(CodeBuilder cb)
        {
            base.RenderDeclare(cb);

            String bs = "";
            if (Tools.Strings.StrExt(BaseSystem))
                bs = BaseSystem;
            else
                bs = "Sys";

            cb.AppendLine("    public partial class Sys" + Name + "_auto : " + bs);
        }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]     
    public class CoreClassAttribute: CoreAttribute
    {
        String m_SysName = "";
        public String SysName
        {
            get
            {
                return m_SysName;
            }
            set
            {
                m_SysName = value;
            }
        }

        public String BaseClass;
        public bool Abstract = false;
        public bool MenuItem = false;

        public CoreClassAttribute(String name)
            : base(name, -1)
        {
        }

        public override string AttributeType
        {
            get
            {
                return "CoreClass";
            }
        }

        public override void RenderDeclare(CodeBuilder cb)
        {
            base.RenderDeclare(cb);
            String bs = BaseClass;
            if (!Tools.Strings.StrExt(bs))
                bs = "Core.Item";
            cb.AppendLine("    public partial class " + Name + "_auto : " + bs + "");
        }

        public override string RenderDeclareExtraNamed()
        {
            String ret = base.RenderDeclareExtraNamed();
            if (Abstract)
                ret += ", Abstract = true";
            if (MenuItem)
                ret += ", MenuItem = true";
            return ret;
        }

        public bool LowestLevelIs
        {
            get
            {
                if (BaseClass == null)
                    return true;

                switch (BaseClass)
                {
                    case "Core.Item":
                    case "Core.ItemClassic":
                        return true;
                    default:
                        return false;
                }
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarAttribute : CoreAttribute
    {
        public String TheTypeName;
        public String TheTypeNameShort
        {
            get
            {
                return Tools.Strings.ParseDelimitLast(TheTypeName, ".");
            }
        }

        public Alignment AlignmentDefault = Alignment.Left;
        public String FormatDefault = "";
        

        public CoreVarAttribute(String name, String type_name)
            : this(name, type_name, -1)
        {

        }

        public CoreVarAttribute(String name, String type_name, int importance)
            : base(name, importance)
        {
            TheTypeName = type_name;
        }

        protected virtual String VariableTypeShort
        {
            get
            {
                switch (TheTypeNameShort)
                {
                    case "Text":
                    case "Blob":
                        return "String";
                    default:
                        return TheTypeNameShort;
                }
            }
        }

        bool m_ReadOnly = false;
        public bool ReadOnly
        {
            get
            {
                return m_ReadOnly;
            }

            set
            {
                m_ReadOnly = value;
            }
        }

        public bool SearchCriteria = false;

        public virtual void FieldsAppend(List<Field> fields)
        {
            
        }

        public virtual void RenderInit(CodeBuilder cb, CoreClassAttribute class_attr)
        {

        }

        public virtual void RenderExtra(CodeBuilder cb)
        {
          
        }

        public override string RenderDeclareExtraNamed()
        {
            String ret = base.RenderDeclareExtraNamed();
            if (SearchCriteria)
                ret += ", SearchCriteria = true";
            return ret;
        }

        public override string Indent
        {
            get
            {
                return base.Indent + "    ";
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarValAttribute : CoreVarAttribute, IComparable
    {
        protected ValueUse m_ValueUse = ValueUse.Any;
        public ValueUse ValueUse
        {
            get
            {
                return m_ValueUse;
            }

            set
            {
                m_ValueUse = value;
            }
        }

        bool m_SetCheck = false;
        public bool SetCheck
        {
            get
            {
                return m_SetCheck;
            }

            set
            {
                m_SetCheck = value;
            }
        }

        bool m_Transactional = false;
        public bool Transactional
        {
            get
            {
                return m_Transactional;
            }

            set
            {
                m_Transactional = value;
            }
        }

        public CoreVarValAttribute(String name, FieldType type, int length)
            : this(name, type.ToString(), -1)
        {
            TheFieldLength = length;
        }

        public CoreVarValAttribute(String name, String type_name)
            : this(name, type_name, -1)
        {

        }

        public CoreVarValAttribute(String name, String type_name, int importance)
            : base(name, type_name, importance)
        {
            switch (TheTypeNameShort)
            {
                case "DateTime":
                    this.TheFieldType = FieldType.DateTime;
                    break;
                case "Double":
                    this.TheFieldType = FieldType.Double;
                    break;
                case "Int32":
                    this.TheFieldType = FieldType.Int32;
                    break;
                case "Int64":
                    this.TheFieldType = FieldType.Int64;
                    break;
                case "Boolean":
                    this.TheFieldType = FieldType.Boolean;
                    break;
                case "Text":
                    this.TheFieldType = FieldType.Text;
                    break;
                case "Blob":
                    this.TheFieldType = FieldType.Blob;
                    break;
                case "Unknown":
                    this.TheFieldType = FieldType.Unknown;
                    break;
            }
        }

        public override string AttributeType
        {
            get
            {
                return "CoreVarVal";
            }
        }

        public override void RenderDeclare(CodeBuilder cb)
        {
            base.RenderDeclare(cb);
            cb.AppendLine("        public Var" + TheTypeNameShort + " " + Name + "Var;");
            cb.AppendLine("");
        }

        public override string RenderDeclareExtraPositional()
        {
            return RenderDeclareExtraVarValPositional() + base.RenderDeclareExtraPositional();
        }

        public override string RenderDeclareExtraNamed()
        {
            return RenderDeclareExtraVarValNamed() + base.RenderDeclareExtraNamed();
        }

        protected virtual String RenderDeclareExtraVarValPositional()
        {
            return ", \"" + TheTypeName + "\"";
        }

        protected virtual String RenderDeclareExtraVarValNamed()
        {
            return RenderDeclareExtraVarValNamed(true);  //temporary
        }

        public String RenderDeclareExtraVarValNamed(bool includeLength)
        {
            String field = "";
            if (TheFieldName != null)
            {
                if (!Tools.Strings.StrCmp(Name, TheFieldName))
                    field = ", TheFieldName = \"" + TheFieldName + "\"";
            }

            if (includeLength && TheFieldType == FieldType.String && TheFieldLength > 0)
                field = ", TheFieldLength = " + TheFieldLength.ToString();

            String set = "";
            if (SetCheck)
                set = ", SetCheck = true";

            String tran = "";
            if (Transactional)
                tran = ", Transactional = true";

            String vuse = "";
            if (ValueUse != ValueUse.Any)
                vuse = ", ValueUse = ValueUse." + ValueUse.ToString();

            return field + set + tran + vuse;
        }

        public override void RenderInit(CodeBuilder cb, CoreClassAttribute class_attr)
        {
            cb.AppendLine("            " + Name + "Var = new Var" + TheTypeNameShort + "(this, " + Name + "Attribute);");
        }

        public override void RenderExtra(CodeBuilder cb)
        {
            cb.AppendLine("        public " + VariableTypeShort + " " + Name + "");
            cb.AppendLine("        {");
            cb.AppendLine("            get  { return (" + VariableTypeShort + ")" + Name + "Var.Value; }");

            if (!Transactional)
                cb.AppendLine("            set  { " + Name + "Var.Value = value; }");
            
            cb.AppendLine("        }");
            cb.AppendLine("");

            if (Transactional && TheTypeNameShort == "Double")
            {
                cb.AppendLine("        public virtual void " + Name + "_Add(Context context, Double amount)");
                cb.AppendLine("        {");
                cb.AppendLine("            " + Name + "Var.Value = ((Double)" + Name + "Var.Value + amount);");
                cb.AppendLine("            TransValueUpdate(context, \"" + Name + "\", TransValueUpdateOp.Add, amount);");
                cb.AppendLine("        }");

                cb.AppendLine("        public virtual void " + Name + "_Subtract(Context context, Double amount)");
                cb.AppendLine("        {");
                cb.AppendLine("            " + Name + "Var.Value = ((Double)" + Name + "Var.Value - amount);");
                cb.AppendLine("            TransValueUpdate(context, \"" + Name + "\", TransValueUpdateOp.Subtract, amount);");
                cb.AppendLine("        }");
            }
        }

        protected FieldType m_TheFieldType = FieldType.String;
        public virtual FieldType TheFieldType
        {
            get
            {
                return m_TheFieldType;
            }

            set
            {
                m_TheFieldType = value;
            }
        }

        protected int m_TheFieldLength = -1;

        public int TheFieldLength
        {
            get
            {
                return m_TheFieldLength;
            }

            set
            {
                m_TheFieldLength = value;
            }
        }

        String m_TheFieldName;
        public String TheFieldName
        {
            get
            {
                if (m_TheFieldName == null)
                    return Name;
                else
                    return m_TheFieldName;
            }

            set
            {
                m_TheFieldName = value;
            }
        }

        public override void FieldsAppend(List<Field> fields)
        {
            base.FieldsAppend(fields);

            Field f = new Field(TheFieldName, TheFieldType, TheFieldLength);
            f.ValueUse = ValueUse;
            if (!fields.Contains(f))
                fields.Add(f);
            else
            {
                ;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarValEnumAttribute : CoreVarValAttribute, IComparable
    {
        public CoreVarValEnumAttribute(String name, String type_name)
            : base(name, type_name)
        {

        }

        public override string AttributeType
        {
            get
            {
                return "CoreVarValEnum";
            }
        }

        public override void RenderDeclare(CodeBuilder cb)
        {
            base.RenderDeclare(cb);
            cb.AppendLine("        public VarEnum<" + TheTypeName + "> " + Name + "Var;");
            cb.AppendLine("");
        }

        public override void RenderInit(CodeBuilder cb, CoreClassAttribute class_attr)
        {
            cb.AppendLine("            " + Name + "Var = new VarEnum<" + TheTypeName + ">(new ItemArgs(a.TheContext, this), AttributeGet(\"" + Name + "Var\"));");
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarValBlobAttribute : CoreVarValAttribute, IComparable
    {
        public CoreVarValBlobAttribute(String name)
            : base(name, "Blob")
        {

        }

        public override string AttributeType
        {
            get
            {
                return "CoreVarValBlob";
            }
        }

        public override void FieldsAppend(List<Field> fields)
        {
            base.FieldsAppend(fields);
            fields.Add(new Field(BlobDataFieldName, FieldType.Blob));
            fields.Add(new Field(BlobThumbFieldName, FieldType.Blob));
            fields.Add(new Field(BlobExtensionFieldName, FieldType.String));
        }

        protected override string RenderDeclareExtraVarValPositional()
        {
            //return base.RenderDeclareExtraVarVal();
            return "";
        }

        protected override string RenderDeclareExtraVarValNamed()
        {
            //return base.RenderDeclareExtraVarValNamed();
            return "";
        }

        public String FixedBlobFieldName = "";
        public String BlobDataFieldName
        {
            get
            {
                return Name + "_blob_data";
            }
        }

        public String BlobThumbFieldName
        {
            get
            {
                return Name + "_blob_thumb";
            }
        }

        public String BlobExtensionFieldName
        {
            get
            {
                return Name + "_blob_extension";
            }
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarRefAttribute : CoreVarAttribute
    {
        public String ThisTypeName;
        public String ThisTypeNameShort
        {
            get
            {
                return Tools.Strings.ParseDelimitLast(ThisTypeName, ".");
            }
        }

        public QueryRef TheQuery;

        //this is the name of the property that the referenced items have that refer back to this
        //so for recipe.ingredients, the name of the prop is 'Ingredients' and the revese name is 'TheRecipe',
        //because each ingredient has a property named 'TheRecipe' pointing back to the recipe item
        public String ReverseName = "";

        private string m_LinkField = "";
        public String LinkField
        {
            get
            {
                return m_LinkField;
            }
            set
            {
                m_LinkField = value;
            }
        }

        public CoreVarRefAttribute(String name, String this_type_name, String type_name, String reverseName, String linkField)
            : base(name, type_name)
        {
            ThisTypeName = this_type_name;
            ReverseName = reverseName;
            LinkField = linkField;
        }

        String m_IdThis = "";
        public String IdThis
        {
            get
            {
                return m_IdThis;
            }

            set
            {
                m_IdThis = value;
            }
        }

        String m_IdThat = "";
        public String IdThat
        {
            get
            {
                return m_IdThat;
            }

            set
            {
                m_IdThat = value;
            }
        }

        public override string RenderDeclareExtraPositional()
        {
            String ret = base.RenderDeclareExtraPositional();
            ret += ", \"" + ThisTypeName + "\"";
            ret += ", \"" + TheTypeName + "\"";
            ret += ", \"" + ReverseName + "\"";
            ret += ", \"" + LinkField + "\"";
            return ret;
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarRefSingleAttribute : CoreVarRefAttribute
    {
        public CoreVarRefSingleAttribute(String name, String this_type_name, String that_type_name, String reverseName, String linkField) : base(name, this_type_name, that_type_name, reverseName, linkField)
        {
            TheQuery = new QueryRef(ThisTypeNameShort, TheTypeNameShort, new ExpressionBinaryOperator(new ExpressionFieldUid(), BinaryOperatorType.Equality, new ExpressionItemRefSingleId(Name)));            
        }
        
        public override void FieldsAppend(List<Field> fields)
        {
            base.FieldsAppend(fields);
            if( Tools.Strings.StrExt(LinkField) )
                fields.Add(new Field(LinkField, FieldType.String, 256));
        }

        public override void RenderDeclare(CodeBuilder cb)
        {
            base.RenderDeclare(cb);
            cb.AppendLine("        public VarRefSingle<" + ThisTypeName + ", " + TheTypeName + "> " + Name + "Var;");
            cb.AppendLine("");
        }

        public override string AttributeType
        {
            get
            {
                return "CoreVarRefSingle";
            }
        }

        public override void RenderInit(CodeBuilder cb, CoreClassAttribute class_attr)
        {
            cb.AppendLine("            " + Name + "Var = new VarRefSingle<" + ThisTypeName + ", " + TheTypeName + ">(this, " + Name + "Attribute);");
        }
    }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class CoreVarRefManyAttribute : CoreVarRefAttribute
    {
        public CoreVarRefManyAttribute(String name, String this_type_name, String that_type_name, String reverseName, String linkField)
            : base(name, this_type_name, that_type_name, reverseName, linkField)
        { 
            TheQuery = new QueryRef(ThisTypeNameShort, TheTypeNameShort, new ExpressionBinaryOperator(new ExpressionIdentifier(LinkField), BinaryOperatorType.Equality, new ExpressionItemUid()));  //ReverseName + "_Uid"
        }

        //2012_04_14 why was the base fields append suppressed?
        //maybe because the field add for vals was incorrectly placed in var?
        //public override void FieldsAppend(List<Field> fields)
        //{
        //    //!!!//base.FieldsAppend(fields);
        //}

        //VarRefInstanceManyField

        public override void RenderDeclare(CodeBuilder cb)
        {
            base.RenderDeclare(cb);  
            if( Tools.Strings.StrExt(CollectedName) )
                cb.AppendLine("        public VarRefInstanceManyCollected<" + ThisTypeName + ", " + TheTypeName + "> " + Name + "Var;");
            else
                cb.AppendLine("        public VarRefMany<" + ThisTypeName + ", " + TheTypeName + "> " + Name + "Var;");
            cb.AppendLine("");
        }

        public override string RenderDeclareExtraNamed()
        {
            String ret = base.RenderDeclareExtraNamed();

            //2012_04_14 i don't remember what this collected option is for
            String collected = "";
            if (Tools.Strings.StrExt(collected))
                collected = ", CollectedName = \"" + CollectedName + "\"";

            ret += collected;

            return ret;
        }

        public override string AttributeType
        {
            get
            {
                return "CoreVarRefMany";
            }
        }

        public override void RenderInit(CodeBuilder cb, CoreClassAttribute class_attr)
        {
            if( Tools.Strings.StrExt(CollectedName) )
                cb.AppendLine("            " + Name + "Var = new VarRefInstanceManyCollected<" + ThisTypeName + ", " + TheTypeName + ">(this, " + Name + "Attribute, " + CollectedName + ");");
            else
                cb.AppendLine("            " + Name + "Var = new VarRefMany<" + ThisTypeName + ", " + TheTypeName + ">(this, " + Name + "Attribute);");
        }

        String m_CollectedName = "";
        public String CollectedName
        {
            get
            {
                return m_CollectedName;
            }

            set
            {
                m_CollectedName = value;
            }
        }
    }
}


