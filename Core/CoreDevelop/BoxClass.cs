using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

using Core;

namespace CoreDevelop
{
    public class BoxClass : Box
    {
        //Public Variables
        public BoxSys TheBoxSys;
        public CoreClassAttribute TheClassAttribute
        {
            get
            {
                return (CoreClassAttribute)TheAttribute;
            }
        }
        public Type TheType;
        public Dictionary<String, BoxVar> Vars = new Dictionary<string, BoxVar>();
        public List<BoxVar> VarsList
        {
            get
            {
                List<BoxVar> ret = new List<BoxVar>();
                foreach (KeyValuePair<String, BoxVar> k in Vars)
                {
                    ret.Add(k.Value);
                }
                return ret;
            }
        }

        //Constructors
        public BoxClass(BoxSys s, CoreClassAttribute attr) : this(s, attr, null, null)
        {

        }
        public BoxClass(BoxSys s, CoreClassAttribute attr, Type t, Assembly assembly) : base(attr)
        {
            TheBoxSys = s;
            TheType = t;
            if( assembly != null )
                MembersLoad(assembly);
        }
        //Public Functions
        public void Write()
        {
            Write(false);
        }
        public void Write(bool removed)
        {
            String code_file = CodeBaseFileFind();
            String code_data = Render(removed);
            if (File.Exists(code_file))
            {
                String folder = @"c:\Bilge\CoreDevelop\CodeArchive\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                folder += TheBoxSys.Name + @"\";
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                String archive_name = folder + Path.GetFileNameWithoutExtension(code_file) + "_" + Tools.Folder.GetNowPathPlusTime() + "_" + Tools.Strings.GetNewID() + ".cs";
                File.Copy(code_file, archive_name);
            }
            Tools.Files.SaveStringAsFile(code_file, code_data, true);
            LiveFileCheck();
        }
        public String Render(bool removed)
        {
            CodeBuilder cb = new CodeBuilder();
            //Using
            cb.AppendLine("using System;");
            cb.AppendLine("using System.Collections.Generic;");
            cb.AppendLine("using System.Text;");
            cb.AppendLine("using System.Reflection;");
            cb.AppendLine("using Tools.Database;");
            cb.AppendLine("using Core;");
            cb.AppendLine("");
            //Namespace
            cb.AppendLine("namespace " + TheBoxSys.Name);
            cb.AppendLine("{");
            if (removed)
                cb.Append("//");
            TheClassAttribute.RenderDeclare(cb);
            cb.AppendLine("    {");
            //Static constructor
            cb.AppendLine("        static " + Name + "_auto()");
            cb.AppendLine("        {");
            cb.AppendLine("            Item.AttributesCache(typeof(" + Name + "_auto), AttributeCache);");
            cb.AppendLine("        }");
            cb.AppendLine("");
            cb.AppendLine("        static void StaticInit()");
            cb.AppendLine("        {");
            cb.AppendLine("");
            cb.AppendLine("        }");
            cb.AppendLine("");
            //Static declarations
            cb.AppendLine("        public static void AttributeCache(CoreAttribute attr)");
            cb.AppendLine("        {");
            cb.AppendLine("            switch (attr.Name)");
            cb.AppendLine("            {");
            foreach (BoxVar m in VarsList)
            {
                m.TheAttribute.RenderStaticAssign(cb);
            }
            cb.AppendLine("            }");
            cb.AppendLine("        }");
            cb.AppendLine("");
            foreach (BoxVar m in VarsList)
            {
                m.TheAttribute.RenderStatic(cb);
            }
            cb.AppendLine("");
            //Member declarations
            foreach (BoxVar m in VarsList)
            {
                m.TheAttribute.RenderDeclare(cb);
            }
            //Constructor
            cb.AppendLine("        public " + Name + "_auto()");
            cb.AppendLine("        {");
            cb.AppendLine("            StaticInit();");
            //Member initialization
            foreach (BoxVar m in VarsList)
            {
                ((CoreVarAttribute)m.TheAttribute).RenderInit(cb, this.TheClassAttribute);
            }
            cb.AppendLine("        }");
            cb.AppendLine("");
            cb.AppendLine("        public override string ClassId");
            cb.AppendLine("        { get { return \"" + Name + "\"; } }");
            cb.AppendLine("");
            //Member extras
            foreach (BoxVar m in VarsList)
            {
                ((CoreVarAttribute)m.TheAttribute).RenderExtra(cb);
            }
            cb.AppendLine("    }");
            cb.AppendLine("    public partial class " + Name + "");
            cb.AppendLine("    {");
            cb.AppendLine("        public static " + Name + " New(Context x)");
            cb.AppendLine("        {  return (" + Name + ")x.Item(\"" + Name + "\"); }");
            cb.AppendLine("");
            cb.AppendLine("        public static " + Name + " GetById(Context x, String uid)");
            cb.AppendLine("        { return (" + Name + ")x.GetById(\"" + Name + "\", uid); }");
            cb.AppendLine("");
            cb.AppendLine("        public static " + Name + " QtO(Context x, String sql)");
            cb.AppendLine("        { return (" + Name + ")x.QtO(\"" + Name + "\", sql); }");
            if (VarContainsAnyCase("name"))
            {
                cb.AppendLine("");
                cb.AppendLine("        public static " + Name + " GetByName(Context x, String name, String extraSql = \"\")");
                cb.AppendLine("        { return (" + Name + ")x.GetByName(\"" + Name + "\", name, extraSql); }");
            }
            cb.AppendLine("    }");
            cb.AppendLine("}");
            return cb.ToString();
        }
        public void LiveFileCheck()
        {
            String live = CodeLiveFileFind();
            if (!File.Exists(live))
                Tools.Files.SaveStringAsFile(live, LiveFileRender(), true);
        }
        public String LiveFileRender()
        {
            CodeBuilder cb = new CodeBuilder();
            cb.AppendLine("using System;");
            cb.AppendLine("using System.Collections.Generic;");
            cb.AppendLine("using System.Text;");
            cb.AppendLine("");
            cb.AppendLine("using Core;");
            cb.AppendLine("");
            cb.AppendLine("namespace " + TheBoxSys.Name + "");
            cb.AppendLine("{");
            cb.AppendLine("    public partial class " + Name + " : " + Name + "_auto");
            cb.AppendLine("    {");
            cb.AppendLine("        public " + Name + "()");
            cb.AppendLine("        {");
            cb.AppendLine("");
            cb.AppendLine("        }");
            cb.AppendLine("    }");
            cb.AppendLine("}");
            return cb.ToString();
        }
        public String CodeBaseFileFind()
        {
            return Tools.Folder.ConditionFolderName(TheBoxSys.TheTag.CodePath) + @"Auto\" + Name + "_auto.cs";
        }
        public String CodeLiveFileFind()
        {
            return Tools.Folder.ConditionFolderName(TheBoxSys.TheTag.CodePath) + @"Items\" + Name + ".cs";
        }
        public int VarCount()
        {
            if (VarsList == null)
                return 0;
            return VarsList.Count;
        }
        public int VarCountNoRefs()
        {
            if (VarsList == null)
                return 0;
            int count = 0;
            foreach (BoxVar b in VarsList)
            {
                if (!(b.TheAttribute is CoreVarRefAttribute))
                    count++;
            }
            return count;
        }
        public int RefCount()
        {
            if (VarsList == null)
                return 0;
            int count = 0;
            foreach (BoxVar b in VarsList)
            {
                if (b.TheAttribute is CoreVarRefAttribute)
                    count++;
            }
            return count;
        }
        public BoxVar VarAdd(ContextDevelop context, ClassExpandArgs args)
        {
            args.Name = BoxSys.MakeValidIdentifierVar(args.Name);
            if (VarContainsAnyCase(args.Name, args.Caption))
                throw new Exception("This name is already in use");
            if (!args.List)
            {
                if (args.Type == Tools.Database.FieldType.SingleRef)
                    return VarRefAddSingleToMany(context, args.ListClass, args.Name, args.Caption);
                else
                    return VarValAdd(context, args.Type.ToString(), args.Name, args.Caption);
            }
            else
                return VarRefAddOneToMany(context, BoxSys.MakeValidIdentifierClass(args.ListClass.ToLower()), args.Name, args.Caption);                
        }
        public BoxVar VarValAdd(ContextDevelop context, String type_name, String name, String caption)
        {
            CoreVarValAttribute a = null;
            switch (type_name)
            {
                case "Blob":
                    a = new CoreVarValBlobAttribute(name);
                    break;
                default:
                    a = new CoreVarValAttribute(name, type_name);
                    break;
            }
            a.Importance = Vars.Count;
            a.Caption = caption;
            BoxVar v = new BoxVar(a);
            VarAdd(context, v);
            return v;
        }
        public bool VarContainsAnyCase(String name)
        {
            return VarContainsAnyCase(name, "");
        }
        public bool VarContainsAnyCase(String name, String caption)  //does not allow case mixing
        {
            foreach (BoxVar v in this.VarsList)
            {
                if (Tools.Strings.StrCmp(v.Name, name) || (caption != "" && Tools.Strings.StrCmp(v.TheAttribute.Caption, caption)))
                    return true;
            }
            return false;
        }
        public BoxVar AddName(ContextDevelop xd)
        {
            return VarAdd(xd, new ClassExpandArgs("name", "Name", Tools.Database.FieldType.String));
        }
        public void VarAdd(ContextDevelop context, BoxVar v)
        {
            Vars.Add(v.Name, v);
        }
        public void VarRemove(ContextDevelop context, BoxVar v)
        {
            Vars.Remove(v.Name);
            if (v.TheAttribute is CoreVarRefAttribute)
            {
                CoreVarRefAttribute a = (CoreVarRefAttribute)v.TheAttribute;
                if (a == null)
                    return;
                if (TheBoxSys == null)
                    return;
                BoxClass c = null;
                TheBoxSys.Classes.TryGetValue(a.TheTypeNameShort, out c);
                if (c == null)
                    return;
                BoxVar vv = null;
                c.Vars.TryGetValue(a.ReverseName, out vv);
                if (vv == null)
                    return;
                c.VarRemove(context, vv);
            }
        }
        //Private Static Functions
        private static bool FilterMembersByAttributeType(MemberInfo info, object state)
        {
            Type desired_attribute_type = (Type)state;
            object[] attrs = info.GetCustomAttributes(desired_attribute_type, false);
            return (attrs.Length > 0);
        }
        //Private Functions
        private void MembersLoad(Assembly assembly)
        {
            Type bType = assembly.GetType(TheBoxSys.Name + "." + TheClassAttribute.Name + "_auto");
            MemberInfo[] members = bType.FindMembers(MemberTypes.All, BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly, new MemberFilter(FilterMembersByAttributeType), typeof(CoreVarAttribute));
            foreach (MemberInfo info in members)
            {
                Object[] attrs = info.GetCustomAttributes(typeof(CoreVarAttribute), true);
                BoxVar b = new BoxVar((CoreVarAttribute)attrs[0]);
                Vars.Add(b.TheAttribute.Name, b);
            }
        }
        private BoxVar VarRefAddOneToMany(ContextDevelop context, String referenceClass, String varName, String varCaption)
        {
            BoxClass referenceBox = TheBoxSys.Classes[referenceClass];
            if (referenceBox == null)
                throw new Exception(referenceClass + " not found");
            String reverseName = Tools.Strings.FilterTrash(varName + TheAttribute.Name);
            String linkFieldName = (TheAttribute.Name + "_" + varName + "_uid").ToLower();
            CoreVarRefManyAttribute ma = new CoreVarRefManyAttribute(varName, TheAttribute.Name, referenceClass, reverseName, linkFieldName);
            ma.Caption = varCaption;
            ma.Importance = Vars.Count;
            BoxVar ret = new BoxVar(ma);
            VarAdd(context, ret);
            CoreVarRefSingleAttribute sa = new CoreVarRefSingleAttribute(reverseName, referenceClass, TheAttribute.Name, varName, linkFieldName);
            sa.Caption = TheAttribute.Name;
            sa.Importance = referenceBox.Vars.Count;
            referenceBox.VarAdd(context, new BoxVar(sa));
            return ret;
        }
        private BoxVar VarRefAddSingleToMany(ContextDevelop context, String referenceClass, String varName, String varCaption)
        {
            BoxClass referenceBox = null;
            TheBoxSys.Classes.TryGetValue(referenceClass.ToLower(), out referenceBox);
            if (referenceBox == null)
                throw new Exception(referenceClass + " not found");
            String linkFieldName = (TheAttribute.Name + "_" + varName + "_uid").ToLower();
            String reverseName = Tools.Strings.FilterTrash(varName + TheAttribute.Name);
            CoreVarRefSingleAttribute sa = new CoreVarRefSingleAttribute(varName, TheAttribute.Name, referenceClass, reverseName, linkFieldName);
            sa.Caption = Tools.Strings.NiceFormat(varCaption);
            sa.Importance = Vars.Count;
            VarAdd(context, new BoxVar(sa));
            CoreVarRefManyAttribute ma = new CoreVarRefManyAttribute(reverseName, referenceClass, TheAttribute.Name, varName, linkFieldName);
            ma.Caption = Tools.Strings.NiceFormat(TheAttribute.Name);
            ma.Importance = referenceBox.Vars.Count;
            BoxVar ret = new BoxVar(ma);
            referenceBox.VarAdd(context, ret);
            return ret;
        }
    }
}