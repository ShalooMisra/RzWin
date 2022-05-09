using System;
using System.Collections;
using System.Text;

using Core;
using CoreDevelop;
using CoreWin;

namespace NewMethod
{
    public class nLanguage_CSharp : nLanguage
    {
        public nLanguage_CSharp()
        {
            language = Enums.Language.CSharp;
        }

        public override String GetSystemCode(n_sys sys)
        {
            StringBuilder s = new StringBuilder();

            s.AppendLine("using System;");
            s.AppendLine("using System.Collections;");
            s.AppendLine("using System.Text;");
            s.AppendLine("using NewMethod;");
            s.AppendLine("");

            s.AppendLine("namespace " + sys.system_name);
            s.AppendLine("{");

            //if sys has a parent system other than NM, it should inherit from its parent system, right?
            //hmm.  is that the better way to go than the system chain???
            //but then how would each system track its collection of children?
            //inheritance is inheritance of logic, not data, stupid.  each one will still have a separate child collection

            //now with multiple system inheritance, it can only inherit logic from 1 system.
            //just the first one for now.

            if (sys.ParentSystems.Count == 0)
                s.AppendLine("    public partial class n_sys_" + sys.system_name + " : n_sys");
            else
                s.AppendLine("    public partial class n_sys_" + sys.system_name + " : " + ((n_sys)sys.ParentSystems.All[0]).system_name + ".n_sys_" + ((n_sys)sys.ParentSystems.All[0]).system_name);

            s.AppendLine("    {");

            s.AppendLine("        public n_sys_" + sys.system_name + "(n_sys xs): base(xs)");
            s.AppendLine("        {");
            s.AppendLine("            this.system_name = \"" + sys.system_name + "\";");
            s.AppendLine("        }");

            s.AppendLine("        public override nObject MakeObject(String strClass, n_sys s)");
            s.AppendLine("        {");
            s.AppendLine("            nObject o = null;");
            s.AppendLine("            switch (strClass.ToLower().Trim())");
            s.AppendLine("            {");

            n_class c;

            if (sys.xStructure.Classes.AllByName.Count == 0)
            {
                s.AppendLine("                case \"\":");
                s.AppendLine("                    return base.MakeObject(strClass, s);");
            }
            else
            {
                foreach (DictionaryEntry d in sys.xStructure.Classes.AllByName)
                {
                    c = (n_class)d.Value;
                    if (!c.is_abstract)
                    {
                        s.AppendLine("                case \"" + c.class_name.ToLower() + "\":");
                        s.AppendLine("                    o = new " + c.class_name.ToLower() + "(s);");
                        s.AppendLine("                    break;");
                    }
                }
            }

            s.AppendLine("                default:");

            //s.AppendLine("            if (this.HasClass(strClass))");
            //s.AppendLine("                return this.MakeBlankInstance(strClass, s);");

            //s.AppendLine("            if (this.ParentSystem != null)");
            //s.AppendLine("            {");
            //s.AppendLine("                o = ParentSystem.MakeObject(strClass, s);");
            //s.AppendLine("                if (o != null)");
            //s.AppendLine("                    return o;");
            //s.AppendLine("            }");
            //s.AppendLine("            return this.MakeBlankInstance(strClass, s);");

            //s.AppendLine("                    o = MakeSupportingObject(strClass, s);");
            s.AppendLine("                    if (o == null)");
            s.AppendLine("                        return base.MakeObject(strClass, s);");
            s.AppendLine("                    break;");

            s.AppendLine("            }");
            s.AppendLine("            return base.MakeObject(strClass, s, o);");
            //s.AppendLine("            if (this.IsSoft(strClass))");
            //s.AppendLine("            {");
            //s.AppendLine("                o.AddSoftProps();");
            //s.AppendLine("            }");

            //s.AppendLine("            return o;");
            s.AppendLine("        }");
            s.AppendLine("    }");
            s.AppendLine("}");

            return s.ToString();
        }
        //Public Functions
        //public bool SetObjectCode(n_class c)
        //{
        //    String s = this.GetObjectCode(c);
        //    String strFile = c.xSys.GetRootFolder() + "iobjects\\auto\\" + c.class_name + "_auto.cs";
        //    nTools.MakeBackup(strFile);
        //    Tools.Files.SaveFileAsString(strFile, s);
        //    return true;
        //}
        public String GetStubCode(n_class c)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using System.Windows.Forms;");
            sb.AppendLine("using NewMethod;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + c.xSys.system_name);
            sb.AppendLine("{");
            sb.AppendLine("    public partial class " + c.class_name + " ");
            sb.AppendLine("    {");
            sb.AppendLine("");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }

        public bool RunCoreCode(n_class c)
        {
            String file = @"c:\Eternal\Code\" + CoreSystemConvertToFolder(c.xSys.system_name) + @"\Auto\" + c.class_name + "Base.cs";
            Tools.FileSystem.SaveFileAsString(file, RenderCoreCode(c));
            return true;
        }

        public String CoreSystemConvertToFolder(String name)
        {
            switch(name.ToLower())
            {
                case "newmethod":
                    return "NMCore";
                default:
                    return name;
            }
        }

        public BoxClass ConvertToCore(n_class x)
        {
            ContextDevelop context = new ContextDevelop();
            context.TheLeader = new LeaderWinUser(null);
            context.TheDelta = new DeltaDevelopCache();

            BoxSys bs = new BoxSys(x.xSys.system_name);
            bs.TheAttribute = new CoreSysAttribute(x.xSys.system_name);

            BoxClass bc = new BoxClass(bs, new CoreClassAttribute(x.class_name));
            bs.ClassAdd(context, bc);

            SortedList props_total;
            SortedList props_without_main;
            n_relate main_base = x.GetMainBaseRelate();
            ArrayList other_bases = x.GetOtherBaseRelates();
            bool inherit = (main_base != null);

            if (!inherit)
            {
                bc.TheClassAttribute.BaseClass = "Core.ItemClassic";
                props_total = x.Props.AllByName;
                props_without_main = x.Props.AllByName;
            }
            else
            {
                bc.TheClassAttribute.BaseClass = main_base.LeftClass.xSys.system_name + "." + main_base.LeftClass.class_name;
                props_total = x.CoalesceProps();
                props_without_main = x.CoalesceProps(main_base.xSys.system_name, main_base.LeftClass.class_name);
            }

            foreach (DictionaryEntry o in props_without_main)
            {
                n_prop p = (n_prop)o.Value;

                switch (p.name.ToLower())
                {
                    case "unique_id":
                    case "date_created":
                    case "date_modified":
                    case "grid_color":
                        continue;
                }

                if (p.property_order < 1000)
                {
                    Type t = null;
                    switch (p.property_type)
                    {
                        case (Int32)NewMethod.Enums.DataType.Integer:
                            t = typeof(int);
                            break;
                        case (Int32)NewMethod.Enums.DataType.Long:
                            t = typeof(long);
                            break;
                        case (Int32)NewMethod.Enums.DataType.Float:
                            t = typeof(double);
                            break;
                        case (Int32)NewMethod.Enums.DataType.Date:
                            t = typeof(DateTime);
                            break;
                        case (Int32)NewMethod.Enums.DataType.Boolean:
                            t = typeof(bool);
                            break;
                        case (Int32)NewMethod.Enums.DataType.Blob:
                            continue;
                        default:
                            t = typeof(String);
                            break;
                    }

                    BoxMember m = new BoxMember(new CoreVarValAttribute(p.name, t.FullName));
                    bc.MemberAdd(context, m);
                }
            }

            return bc;
        }

        public String RenderCoreCode(n_class x)
        {
            return ConvertToCore(x).Render(false);
        }

        //Alternate Object Rendering Code
        public Boolean RunAlternateCode(n_class c)
        {
            if (!SetAltObjectCode_Auto(c))
                return false;

            if (!SetAltObjectCode_Main(c))
                return false;

            return true;
        }
        public Boolean SetAltObjectCode_Auto(n_class c)
        {
            try
            {
                String s = this.GetAltObjectCode_Auto(c);
                String strFile = c.xSys.GetRootFolder() + "iobjects\\auto\\";

                if (!System.IO.Directory.Exists(strFile))
                {
                    try
                    {
                        System.IO.Directory.CreateDirectory(strFile);
                    }
                    catch
                    {
                        return false;
                    }
                }

                strFile += c.class_name + "_auto.cs";

                nTools.MakeBackup(strFile);
                return Tools.Files.SaveFileAsString(strFile, s);
            }
            catch (Exception ee)
            { nError.HandleError(ee); return false; }
        }
        public String GetAltObjectCode_Auto(n_class x)
        {
            SortedList props_total;
            SortedList props_without_main;
            n_relate main_base = x.GetMainBaseRelate();
            ArrayList other_bases = x.GetOtherBaseRelates();
            bool inherit = (main_base != null);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("");
            sb.AppendLine("using NewMethod;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + x.xSys.system_name);
            sb.AppendLine("{");
            if (!inherit)
            {
                sb.AppendLine("    public partial class " + x.class_name + "_auto: nObject ");
                props_total = x.Props.AllByName;
                props_without_main = x.Props.AllByName;
            }
            else
            {
                sb.AppendLine("    public partial class " + x.class_name + "_auto: " + main_base.LeftClass.xSys.system_name + "." + main_base.LeftClass.class_name + " ");
                props_total = x.CoalesceProps();
                props_without_main = x.CoalesceProps(main_base.xSys.system_name, main_base.LeftClass.class_name);
            }
            sb.AppendLine("    {");
            sb.AppendLine("        //Properties");
            string strType;
            string strInit;
            n_prop p;
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                switch (p.property_type)
                {
                    case (Int32)NewMethod.Enums.DataType.Integer:
                        strType = "Int32";
                        strInit = "0";
                        break;
                    case (Int32)NewMethod.Enums.DataType.Long:
                        strType = "Int64";
                        strInit = "0";
                        break;
                    case (Int32)NewMethod.Enums.DataType.Float:
                        strType = "Double";
                        strInit = "0";
                        break;
                    case (Int32)NewMethod.Enums.DataType.Date:
                        strType = "DateTime";
                        strInit = "";
                        break;
                    case (Int32)NewMethod.Enums.DataType.Boolean:
                        strType = "Boolean";
                        strInit = "false";
                        break;
                    default:
                        strType = "String";
                        strInit = "\"\"";
                        break;
                }
                if (!Tools.Strings.StrCmp(p.name, "unique_id") && p.property_order < 1000)
                {
                    if (p.property_type == (Int32)NewMethod.Enums.DataType.Blob)
                    {
                        sb.AppendLine("        public nBlobHandle " + p.name);
                        sb.AppendLine("        {");
                        sb.AppendLine("            get");
                        sb.AppendLine("            {");
                        sb.AppendLine("                return new nBlobHandle(xSys, ClassName, \"" + p.name + "\", unique_id);");
                        sb.AppendLine("            }");
                        sb.AppendLine("        }");
                    }
                    else
                    {
                        if (Tools.Strings.StrExt(strInit))
                            sb.AppendLine("        public " + strType + " m_" + p.name + " = " + strInit + ";");
                        else
                            sb.AppendLine("        public " + strType + " m_" + p.name + ";");
                        sb.AppendLine("        public Boolean b_" + p.name + " = false;");
                        sb.AppendLine("        public " + strType + " " + p.name);
                        sb.AppendLine("        {");
                        sb.AppendLine("            get");
                        sb.AppendLine("            {");
                        sb.AppendLine("                return m_" + p.name + ";");
                        sb.AppendLine("            }");
                        sb.AppendLine("            set");
                        sb.AppendLine("            {");
                        sb.AppendLine("                m_" + p.name + " = value;");
                        sb.AppendLine("                b_" + p.name + " = true;");
                        sb.AppendLine("            }");
                        sb.AppendLine("        }");
                    }
                }
            }
            sb.AppendLine("");
            sb.AppendLine("        //Constructor");
            sb.AppendLine("        public " + x.class_name + "_auto(n_sys xs): base(xs)");
            sb.AppendLine("        {");
            sb.AppendLine("            Hard = true;");
            sb.AppendLine("            ClassName = \"" + x.class_name + "\";");
            sb.AppendLine("        }");
            sb.AppendLine("        //Public Static Functions");
            sb.AppendLine("        public static " + x.class_name + " GetByID(n_sys s, String strID)");
            sb.AppendLine("        {");
            sb.AppendLine("            return (" + x.class_name + ")s.GetByID(\"" + x.class_name + "\", strID);");
            sb.AppendLine("        }");
            n_prop byname = (n_prop)x.Props.GetByName("name");
            if (byname != null)
            {
                sb.AppendLine("        public static " + x.class_name + " GetByName(n_sys s, String strName)");
                sb.AppendLine("        {");
                sb.AppendLine("            return GetByName(s, strName, \"\");");
                sb.AppendLine("        }");
                sb.AppendLine("        public static " + x.class_name + " GetByName(n_sys s, String strName, String strExtraWhere)");
                sb.AppendLine("        {");
                sb.AppendLine("            try");
                sb.AppendLine("            {");
                sb.AppendLine("                String strSQL = \"select * from " + x.class_name + " where name = '\" + s.xData.SyntaxFilter(strName) + \"'\";");
                sb.AppendLine("                if (Tools.Strings.StrExt(strExtraWhere))");
                sb.AppendLine("                    strSQL = strSQL + \" and \" + strExtraWhere;");
                sb.AppendLine("                return (" + x.class_name + ")s.QtO(\"" + x.class_name + "\", strSQL);");
                sb.AppendLine("            }");
                sb.AppendLine("            catch(Exception ee)");
                sb.AppendLine("            {");
                sb.AppendLine("                nError.HandleError(ee);");
                sb.AppendLine("                return null;");
                sb.AppendLine("            }");
                sb.AppendLine("        }");
            }
            String actioncontent = GetAutoActionStubs(x);
            if (Tools.Strings.StrExt(actioncontent))
                sb.Append(actioncontent);
            sb.AppendLine("        //Public Override Functions");
            sb.AppendLine("        public override void SetClassID(String sid)");
            sb.AppendLine("        {");
            sb.AppendLine("            " + x.class_name + ".class_uid = sid;");
            sb.AppendLine("        }");
            sb.AppendLine("        public override String GetClassID()");
            sb.AppendLine("        {");
            sb.AppendLine("            return " + x.class_name + ".class_uid;");
            sb.AppendLine("        }");
            sb.AppendLine("        public override bool ICreate(n_sys s, DataRow iRow)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                xSys = s;");
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                {
                    switch (p.property_type)
                    {
                        case (Int32)NewMethod.Enums.DataType.Integer:
                            strType = "Int32";
                            strInit = "0";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Long:
                            strType = "Int64";
                            strInit = "0";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Float:
                            strType = "Double";
                            strInit = "0";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Date:
                            strType = "DateTime";
                            strInit = "";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Boolean:
                            strType = "Boolean";
                            strInit = "false";
                            break;
                        default:
                            strType = "String";
                            strInit = "\"\"";
                            break;
                    }
                    sb.AppendLine("                " + p.name + " = (" + strType + ")nData.NullFilter_" + strType + "(iRow[\"" + p.name + "\"]);");
                }
            }
            sb.AppendLine("                return base.ICreate(s, iRow);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch(Exception ee)");
            sb.AppendLine("            {");
            sb.AppendLine("                nError.HandleError(ee);");
            sb.AppendLine("                return base.ICreate(s, iRow);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public override void GetSaveSQL(nSQL xSQL)");
            sb.AppendLine("        {");
            sb.AppendLine("            try");
            sb.AppendLine("            {");
            sb.AppendLine("                if (AllVars != null)");
            sb.AppendLine("                {");
            sb.AppendLine("                    base.GetSoftSaveSQL(xSQL);");
            sb.AppendLine("                    return;");
            sb.AppendLine("                }");
            sb.AppendLine("                StringBuilder sbFields = new StringBuilder();");
            sb.AppendLine("                StringBuilder sbValues = new StringBuilder();");
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                    sb.AppendLine("                sbFields.Append(\", " + p.name + "\");");
            }
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                {
                    switch (p.property_type)
                    {
                        case (Int32)NewMethod.Enums.DataType.Integer:
                            sb.AppendLine("                sbValues.Append(\", \" + " + p.name + ".ToString());");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Long:
                            sb.AppendLine("                sbValues.Append(\", \" + " + p.name + ".ToString());");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Float:
                            sb.AppendLine("                sbValues.Append(\", \" + " + p.name + ".ToString());");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Date:
                            sb.AppendLine("                if (!Tools.Dates.DateExists(" + p.name + "))");
                            sb.AppendLine("                {");
                            switch (p.name.ToLower())
                            {
                                case "date_created":
                                    sb.AppendLine("                    " + p.name + " = xSys.xData.GetServerNow();");
                                    break;
                                case "date_modified":
                                    sb.AppendLine("                    " + p.name + " = xSys.xData.GetServerNow();");
                                    break;
                                default:
                                    sb.AppendLine("                    " + p.name + " = Tools.Dates.NullDate;");
                                    break;
                            }
                            sb.AppendLine("                }");
                            sb.AppendLine("                sbValues.Append(\", '\" + nData.DateFilterString(" + p.name + ") + \"'\");");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Boolean:
                            sb.AppendLine("                sbValues.Append(\", \" + nData.BoolFilter(" + p.name + ") + \"\");");
                            break;
                        default:
                            switch (p.property_type)
                            {
                                case (Int32)NewMethod.Enums.DataType.List:
                                    sb.AppendLine("                sbValues.Append(\", '\" + xSys.xData.SyntaxFilter(Tools.Strings.Left(" + p.name + ", 255)) + \"'\");");
                                    break;
                                case (Int32)NewMethod.Enums.DataType.String:
                                    int l = p.property_length;
                                    if (l <= 0)
                                        l = 50;
                                    sb.AppendLine("                sbValues.Append(\", '\" + xSys.xData.SyntaxFilter(Tools.Strings.Left(" + p.name + ", " + l.ToString() + ")) + \"'\");");
                                    break;
                                case (Int32)NewMethod.Enums.DataType.Memo:
                                    sb.AppendLine("                sbValues.Append(\", '\" + xSys.xData.SyntaxFilter(" + p.name + ") + \"'\");");
                                    break;
                            }
                            break;
                    }
                }
            }
            sb.AppendLine("                xSQL.AddInsertFields(sbFields.ToString());");
            sb.AppendLine("                xSQL.AddInsertValues(sbValues.ToString());");
            sb.AppendLine("                base.GetSaveSQL(xSQL);");
            sb.AppendLine("            }");
            sb.AppendLine("            catch(Exception ee)");
            sb.AppendLine("            {");
            sb.AppendLine("                nError.HandleError(ee);");
            sb.AppendLine("                base.GetSaveSQL(xSQL);");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("        public override void GetUpdateSQL(nSQL xSQL)");
            sb.AppendLine("        {");
            sb.AppendLine("            bool b = false;");
            sb.AppendLine("            if (AllVars != null)");
            sb.AppendLine("            {");
            sb.AppendLine("                base.GetSoftUpdateSQL(xSQL);");
            sb.AppendLine("                return;");
            sb.AppendLine("            }");
            sb.AppendLine("            StringBuilder sb = new StringBuilder();");
            int j = 0;
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                {
                    if (p.property_type == (Int32)NewMethod.Enums.DataType.Date)
                    {
                        sb.AppendLine("            if (!Tools.Dates.DateExists(" + p.name + "))");
                        sb.AppendLine("            {");
                        switch (p.name.ToLower())
                        {
                            case "date_created":
                                sb.AppendLine("            " + p.name + " = xSys.xData.GetServerNow();");
                                break;
                            case "date_modified":
                                sb.AppendLine("            " + p.name + " = xSys.xData.GetServerNow();");
                                break;
                            default:
                                sb.AppendLine("            if( b_" + p.name + " )"); //only set this if it isn't an auto date.  otherwise this forces an update even when a value hasn't changed
                                sb.AppendLine("                " + p.name + " = Tools.Dates.NullDate;");
                                break;
                        }
                        sb.AppendLine("            }");
                    }
                    sb.AppendLine("            if( b_" + p.name + " )");
                    sb.AppendLine("            {");
                    sb.AppendLine("                  if (b) sb.Append(\", \");");
                    sb.Append("                      sb.Append(\"" + p.name + " = ");
                    switch (p.property_type)
                    {
                        case (Int32)NewMethod.Enums.DataType.Integer:
                            sb.Append(" \" + " + p.name + ".ToString());");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Long:
                            sb.Append(" \" + " + p.name + ".ToString());");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Float:
                            sb.Append(" \" + " + p.name + ".ToString());");
                            break;
                        case (Int32)NewMethod.Enums.DataType.Date:
                            sb.Append(" '\" + nData.DateFilterString(" + p.name + ") + \"'\");");
                            strInit = "";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Boolean:
                            sb.Append(" \" + nData.BoolFilter(" + p.name + ") + \"\");");
                            break;
                        default:
                            switch (p.property_type)
                            {
                                case (Int32)NewMethod.Enums.DataType.List:
                                    sb.Append(" '\" + xSys.xData.SyntaxFilter(Tools.Strings.Left(" + p.name + ", 255)) + \"'\");");
                                    break;
                                case (Int32)NewMethod.Enums.DataType.String:
                                    int l = p.property_length;
                                    if (l <= 0)
                                        l = 50;
                                    sb.Append(" '\" + xSys.xData.SyntaxFilter(Tools.Strings.Left(" + p.name + ", " + l.ToString() + ")) + \"'\");");
                                    break;
                                default:
                                    sb.Append(" '\" + xSys.xData.SyntaxFilter(" + p.name + ") + \"'\");");
                                    break;
                            }
                            break;
                    }
                    sb.Append("\r\n");
                    sb.AppendLine("                b = true;");
                    sb.AppendLine("            }");
                }
            }
            sb.AppendLine("            xSQL.AddUpdateString(sb.ToString());");
            sb.AppendLine("            base.GetUpdateSQL(xSQL);");
            sb.AppendLine("        }");


            ArrayList SetProps = new ArrayList();
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                {
                    SetProps.Add(p);
                }
            }

            if (SetProps.Count > 0)
            {

                sb.AppendLine("        public override bool ISet(String strProp, Object val)");
                sb.AppendLine("        {");
                sb.AppendLine("            switch (strProp.ToLower().Trim())");
                sb.AppendLine("            {");
                foreach (n_prop px in SetProps)
                {
                    switch (px.property_type)
                    {
                        case (Int32)NewMethod.Enums.DataType.Integer:
                            strType = "Int32";
                            strInit = "0";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Long:
                            strType = "Int64";
                            strInit = "0";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Float:
                            strType = "Double";
                            strInit = "0";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Date:
                            strType = "DateTime";
                            strInit = "";
                            break;
                        case (Int32)NewMethod.Enums.DataType.Boolean:
                            strType = "Boolean";
                            strInit = "false";
                            break;
                        default:
                            strType = "String";
                            strInit = "\"\"";
                            break;
                    }

                    sb.AppendLine("                case \"" + px.name.ToLower() + "\":");
                    sb.AppendLine("                    " + px.name + " = (" + strType + ")nData.NullFilter_" + strType + "(val);");
                    sb.AppendLine("                    return true;");

                }
                sb.AppendLine("            }");
                sb.AppendLine("            return base.ISet(strProp, val);");
                sb.AppendLine("        }");
            }

            ArrayList GetProps = new ArrayList();
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                {
                    GetProps.Add(p);
                }
            }

            if (GetProps.Count > 0)
            {
                sb.AppendLine("        public override Object IGet(String strProp)");
                sb.AppendLine("        {");
                sb.AppendLine("            switch (strProp.ToLower().Trim())");
                sb.AppendLine("            {");
                foreach (n_prop px in GetProps)
                {
                    sb.AppendLine("                case \"" + px.name + "\":");
                    sb.AppendLine("                    return (Object)" + px.name + ";");
                }
                sb.AppendLine("            }");
                sb.AppendLine("            return base.IGet(strProp);");
                sb.AppendLine("        }");

            }

            sb.AppendLine("        public override void SetChanged(bool changed)");
            sb.AppendLine("        {");
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!Tools.Strings.StrCmp(p.name, "unique_id") && p.property_order < 1000 && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                    sb.AppendLine("            b_" + p.name + " = changed;");
            }
            sb.AppendLine("            base.SetChanged(changed);");
            sb.AppendLine("        }");
            sb.AppendLine("        public override bool IsClean()");
            sb.AppendLine("        {");
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!Tools.Strings.StrCmp(p.name, "unique_id") && p.property_order < 1000 && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                    sb.AppendLine("            if (b_" + p.name + ") return false;");
            }
            sb.AppendLine("            return base.IsClean();");
            sb.AppendLine("        }");
            sb.AppendLine("        public override bool FieldChanged(string strField)");
            sb.AppendLine("        {");
            StringBuilder st = new StringBuilder();
            bool bt = false;
            st.AppendLine("            switch (strField.ToLower())");
            st.AppendLine("            {");
            foreach (DictionaryEntry o in props_without_main)
            {
                p = (n_prop)o.Value;
                if (!p.IsFramework && p.property_type != (Int32)NewMethod.Enums.DataType.Blob)
                {
                    st.AppendLine("                case \"" + p.name + "\":");
                    st.AppendLine("                    return b_" + p.name + ";");
                    bt = true;
                }
            }
            st.AppendLine("            }");
            if (bt)
                sb.Append(st.ToString());
            sb.AppendLine("            return base.FieldChanged(strField);");
            sb.AppendLine("        }");


            sb.AppendLine("        public override void HandleAction(ActionArgs args)");
            sb.AppendLine("        {");
            sb.AppendLine("            switch (args.ActionName.ToLower())");
            sb.AppendLine("            {");
            x.InitActionsFromDatabase();
            if (x.Actions != null)
            {
                foreach (n_action a in x.Actions.All)
                {
                    try
                    {
                        if (a != null)
                        {
                            if (Tools.Strings.StrExt(a.action_key) && Tools.Strings.StrExt(a.call_function))
                            {
                                sb.AppendLine("                case \"" + a.action_key + "\":");
                                sb.AppendLine("                    " + FilterCallFunction(a.call_function) + ";");
                                sb.AppendLine("                    break;");
                            }
                        }
                    }
                    catch { }
                }
            }
            sb.AppendLine("                default:");
            sb.AppendLine("                    base.HandleAction(args);");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.AppendLine("    public partial class " + x.class_name + " : " + x.class_name + "_auto");
            sb.AppendLine("    {");
            sb.AppendLine("        //Public Static Virtual Vars");
            if (!inherit)
            {
                sb.AppendLine("        public static SortedList AllProps = null;");
                sb.AppendLine("        public static String class_uid = \"\";");
            }
            sb.AppendLine("    }");
            sb.AppendLine("}");
            return sb.ToString();
        }
        public Boolean SetAltObjectCode_Main(n_class c)
        {
            String strFile = c.xSys.GetRootFolder() + "iobjects\\" + c.class_name + ".cs";
            if (System.IO.File.Exists(strFile))
                return true;
            String s = this.GetAltObjectCode_Main(c);
            Tools.Files.SaveFileAsString(strFile, s);
            return true;
        }
        public String GetAltObjectCode_Main(n_class x)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Collections;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine("using System.Data;");
            sb.AppendLine("using NewMethod;");
            sb.AppendLine("");
            sb.AppendLine("namespace " + x.xSys.system_name);
            sb.AppendLine("{");
            sb.AppendLine("    public partial class " + x.class_name + " : " + x.class_name + "_auto");
            sb.AppendLine("    {");
            sb.AppendLine("        //Constructor");
            sb.AppendLine("        public " + x.class_name + "(n_sys xs): base(xs)");
            sb.AppendLine("        {");
            sb.AppendLine("            Hard = true;");
            sb.AppendLine("            ClassName = \"" + x.class_name.Trim() + "\";");
            sb.AppendLine("        }");
            sb.AppendLine("        //Public Static Functions");
            sb.AppendLine("        public static void HandleAction_Multiple(ActionArgs args, ArrayList objects)");
            sb.AppendLine("        {");
            sb.AppendLine("");
            sb.AppendLine("        }");
            sb.AppendLine("        //Public Override Functions");
            sb.AppendLine("        public override void HandleAction(ActionArgs args)");
            sb.AppendLine("        {");
            sb.AppendLine("            switch (args.ActionName.ToLower())");
            sb.AppendLine("            {");
            sb.AppendLine("                default:");
            sb.AppendLine("                    base.HandleAction(args);");
            sb.AppendLine("                    break;");
            sb.AppendLine("            }");
            sb.AppendLine("        }");
            sb.AppendLine("    }");
            sb.Append(GetAutoActionStubs(x));
            sb.AppendLine("}");
            return sb.ToString();
        }
        private String GetAutoActionStubs(n_class c)
        {
            n_relate main_base = c.GetMainBaseRelate();
            bool inherit = (main_base != null);
            StringBuilder sb = new StringBuilder();
            StringBuilder ret = new StringBuilder();
            c.InitActionsFromDatabase();
            if (c.Actions != null)
            {
                foreach (n_action a in c.Actions.All)
                {
                    try
                    {
                        if (a != null)
                        {
                            if (a.HasCode())
                            {
                                sb.AppendLine(a.rendered_code);
                            }
                            else
                            {
                                if (Tools.Strings.StrExt(a.action_key) && Tools.Strings.StrExt(a.call_function))
                                {
                                    String propername = Tools.Strings.ParseDelimit(a.call_function, "(", 1).Trim();
                                    sb.AppendLine("        public virtual void " + a.call_function);
                                    sb.AppendLine("        {");
                                    sb.AppendLine("            nStatus.NeedImplement(ClassName + \":" + propername + "\");");
                                    sb.AppendLine("        }");
                                }
                            }
                        }
                    }
                    catch { }
                }
            }
            if (Tools.Strings.StrExt(sb.ToString()))
            {
                ret.AppendLine("        //Public Virtual Functions");
                ret.Append(sb.ToString());
            }
            return ret.ToString();
        }
        private String MixWithMainFile(String filecontents, String actioncontent)
        {
            String beforeactions = Tools.Strings.ParseDelimit(filecontents, "//Start Action Stubs", 1).Trim();
            String afteractions = Tools.Strings.ParseDelimit(filecontents, "//End Action Stubs", 2).Trim();
            StringBuilder sb = new StringBuilder();
            if (Tools.Strings.StrExt(afteractions))
            {
                sb.AppendLine(beforeactions);
                sb.Append(actioncontent);
                sb.Append(afteractions);
            }
            else
                sb.AppendLine(InsertAtEndOfFile(filecontents, actioncontent));
            return sb.ToString();
        }
        private String InsertAtEndOfFile(String filecontents, String actioncontent)
        {
            StringBuilder sb = new StringBuilder();
            String[] ary = Tools.Strings.Split(filecontents, "\r\n");
            Stack stk = new Stack();
            foreach (String s in ary)
            {
                if (Tools.Strings.StrCmp(s, "{"))
                    stk.Push(s);
                if (Tools.Strings.StrCmp(s, "}"))
                {
                    stk.Pop();
                    if (stk.Count == 1)
                    {
                        sb.AppendLine(s);
                        sb.AppendLine(actioncontent);
                        continue;
                    }
                }
                sb.AppendLine(s);
            }
            return sb.ToString();
        }
        private String FilterCallFunction(String callfunction)
        {
            String paramz = Tools.Strings.ParseDelimit(callfunction, "(", 2).Trim();
            paramz = Tools.Strings.ParseDelimit(paramz, ")", 1).Trim();
            String[] pz = Tools.Strings.Split(paramz, ",");
            String begin = Tools.Strings.ParseDelimit(callfunction, "(", 1).Trim();
            paramz = "";
            foreach (String s in pz)
            {
                if (Tools.Strings.StrExt(s))
                {
                    String pname = Tools.Strings.ParseDelimit(s, " ", 2).Trim();
                    if (Tools.Strings.StrExt(pname))
                    {
                        if (Tools.Strings.StrExt(paramz))
                            paramz += ", " + pname;
                        else
                            paramz = pname;
                    }
                }
            }
            return begin + "(" + paramz + ")";
        }
        private String GetCallFunctionName(String callfunction)
        {
            String hold = Tools.Strings.ParseDelimit(callfunction, "(", 1).Trim();
            String[] ary = Tools.Strings.Split(hold, " ");
            String functionname = "";
            for (Int32 i = ary.Length - 1; i > 0; i--)
            {
                if (!Tools.Strings.StrExt(ary[i]))
                    continue;
                else
                {
                    functionname = ary[i];
                    break;
                }
            }
            hold = "(" + Tools.Strings.ParseDelimit(callfunction, "(", 2).Trim();
            return functionname + hold;
        }
    }

    namespace Enums
    {
        public enum Language
        {
            CSharp = 1,
        }

        public enum AccessSpecifier
        {
            Public = 0,
            Protected = 1,
            Private = 2,
        }
    }


    public abstract class nLanguage
    {
        public Enums.Language language;
        //public abstract String GetObjectCode(n_class x);
        public abstract String GetSystemCode(n_sys sys);
    }
}
