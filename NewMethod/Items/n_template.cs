using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Core;
using Tools.Database;

namespace NewMethod
{
    public partial class n_template : n_template_auto
    {
        public static n_template CopiedTemplate;
        public SortedList AllColumns = new SortedList();

        public void ReabsorbColumns(ContextNM x)
        {
            AllColumns = null;
            GatherColumns(x);

            //SortedList newList = new SortedList();
            //foreach (n_column c in ColumnsList(x))
            //{
            //    newList.Add(c.column_order, c);
            //}

            //SortedList oldList = AllColumns;
            //AllColumns = newList;
            //oldList.Clear();
            //oldList = null;
        }
        public int GetColumnIndexByProperty(String strProp)
        {
            try
            {
                int i = 0;
                foreach (DictionaryEntry d in AllColumns)
                {
                    n_column c = (n_column)d.Value;
                    if (Tools.Strings.StrCmp(c.field_name, strProp))
                        return i;

                    i++;
                }
                return -1;
            }
            catch { return -1; }
            
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        //Public Functions
        public void SaveColumnsDisconnected(ContextNM x)
        {
            String s = "";
            foreach (DictionaryEntry d in AllColumns)
            {
                n_column c = (n_column)d.Value;
                s += c.unique_id + "|";
            }
            n_set.SetSetting(x, "columns_for_template_" + unique_id, s);
        }
        public List<n_column> ColumnsList(ContextNM x)
        {
            List<n_column> ret = new List<n_column>();
                
            if (AllColumns == null)
                GatherColumns(x);

            if (AllColumns == null)
                return ret;

            foreach (DictionaryEntry d in AllColumns)
            {
                ret.Add((n_column)d.Value);
            }

            return ret;
        }
        public void GatherColumns(ContextNM x)
        {
            AllColumns = new SortedList();
            ArrayList a = x.QtC("n_column", "select * from n_column where the_n_template_uid = '" + this.unique_id + "' order by column_order");

            List<String> fields = new List<string>();
            foreach (n_column c in a)
            {
                if (fields.Contains(c.field_name.ToLower()))
                    continue;

                AbsorbColumn(x, c);

                fields.Add(c.field_name.ToLower());
            }
        }
        public void CreateDefaultColumns(ContextNM x)
        {
            ArrayList a = x.xSys.GetMainProperties(this.class_name);
            if (a != null)
            {
                AddColumnsFromArray(x, a);
                return;
            }

            CoreClassHandle cl = null;
            try
            {
                cl = x.TheSys.CoreClassGet(class_name);
            }
            catch (Exception e)
            {
                return;
            }

            //this always needed work anyway
            //a = cl.GetSortedProps(FrameworkCompareType.Vivid, true);
            //if (a.Count > 0)
            //{
            //    AddColumnsFromPropArray(a);
            //    return;
            //}

            AllColumns = new SortedList();

            n_column c;
            int j = 0;
            foreach (CoreVarValAttribute p in cl.VarValsGet())
            {
                switch (p.Name)
                {
                    case "date_created":
                    case "date_modified":
                    case "grid_color":
                    case "icon_index":
                        break;
                    default:
                        c = new n_column();
                        this.InitNewColumn(c);
                        c.AbsorbProp(p);
                        x.Insert(c);
                        this.AbsorbColumn(x, c);

                        j++;

                        if (j > 4)
                            return;

                        break;
                }
            }
        }
        public void AddColumnsFromArray(ContextNM x, ArrayList a)
        {
            CoreClassHandle c = x.TheSys.CoreClassGet(class_name);
            if (c == null)
                return;
            foreach (String s in a)
            {
                CoreVarValAttribute p = c.VarValGet(s);
                if (p != null)
                    AddColumnByProp(x, c, p);
            }
        }
        public void AddColumnsFromPropArray(ContextNM context, ArrayList a)
        {
            if (a.Count == 0)
                return;

            int sofar = 0;
            int each = 100 / a.Count;

            ArrayList firstfew = new ArrayList();

            foreach (CoreVarValAttribute p in a)
            {
                try
                {
                    n_column c = new n_column();
                    this.InitNewColumn(c);
                    c.AbsorbProp(p);

                    //how wide?
                    switch (p.TheFieldType)
                    {
                        case FieldType.Int32:
                        case FieldType.Int64:
                            c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                            c.column_width = 8;
                            c.column_format = "{0:###,###,##0}";
                            break;
                        case FieldType.Double:
                            c.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                            c.column_width = 10;
                            //switch (p.FieldUse)
                            //{
                            //    case NewMethod.Enums.DataUse.RoundMoney:
                            //        c.column_format = "{0:C}";
                            //        break;
                            //    case NewMethod.Enums.DataUse.FractionMoney:
                            //        c.column_format = "{0:###,###,##0.00####}";
                            //        break;
                            //    default:
                                    c.column_format = "{0:G}";
                                    break;
                            //}
                            break;
                        case FieldType.DateTime:
                            c.column_width = 10;
                            c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                            c.column_format = "{0:M/d hh:mm}";
                            break;
                        case FieldType.Boolean:
                            c.column_width = 5;
                            c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                            c.column_format = "YN";
                            break;
                        default:
                            c.column_width = each;
                            break;
                    }

                    context.Insert(c);
                    this.AbsorbColumn(context, c);

                    sofar += c.column_width;
                    if (firstfew.Count < 2)
                        firstfew.Add(c);

                }
                catch
                {

                }
            }

            if (sofar < 100 && firstfew.Count > 0)
            {
                int left = 100 - sofar;
                foreach (n_column col in firstfew)
                {
                    col.column_width += (left / firstfew.Count);
                    context.Update(col);
                }
            }
        }
        public bool HasColumn(String strName, String strClass, String strRelate)
        {
            if (AllColumns == null)
                return false;

            n_column c = GetColumn(strName, strClass, strRelate);
            return (c != null);
        }
        public n_column GetColumn(String strName, String strClass, String strRelate)
        {
            if (AllColumns == null)
                return null;

            n_column c;
            foreach (DictionaryEntry d in AllColumns)
            {
                c = (n_column)d.Value;
                if (Tools.Strings.StrCmp(c.field_name, strName) && Tools.Strings.StrCmp(c.relate_class, strClass) && Tools.Strings.StrCmp(c.relate_name, strRelate))
                    return c;
            }
            return null;
        }
        public void AddColumnByProp(Context x, CoreClassHandle cl, CoreVarValAttribute p)
        {
            n_column c = new n_column();
            this.InitNewColumn(c);
            c.AbsorbProp(p);

            x.Insert(c);
            this.AbsorbColumn(x, c);
        }
        public n_column AddColumnByField(Context x, String field)
        {
            n_column c = new n_column();
            this.InitNewColumn(c);
            c.field_name = field;

            CoreVarValAttribute attr = x.Sys.CoreClassGet(class_name).VarValGet(field);
            if (attr != null)
            {
                switch (attr.TheFieldType)
                {
                    case FieldType.Int32:
                    case FieldType.Int64:
                        c.column_alignment = 1;
                        c.column_format = "{0:G}";
                        break;
                    case FieldType.Double:
                        c.column_alignment = 1;
                        c.column_format = "{0:###,###,##0.00####}";
                        break;
                    case FieldType.Boolean:
                        c.column_alignment = 2;
                        c.column_format = "yblank";
                        break;
                    case FieldType.DateTime:
                        c.column_alignment = 2;
                        c.column_format = "{0:d}";
                        break;
                }
                c.data_type = (int)attr.TheFieldType;
            }

            x.Insert(c);
            this.AbsorbColumn(x, c);
            return c;
        }        
        public void RemoveColumnByProp(Context x, CoreVarAttribute p)
        {
            RemoveColumnByPropName(x, p.Name);
        }
        public void RemoveColumnByPropName(Context x, String name)
        {
            n_column c = this.GetColumnByName(name);
            while (c != null)  //remove them all in case of duplicates
            {
                x.Delete(c);
                AllColumns.Remove(c.column_order);
                c = this.GetColumnByName(name);
            }
        }
        public void InitNewColumn(n_column c)
        {
            c.the_n_template_uid = this.unique_id;
            c.column_order = this.GetNextColumnOrder();
        }
        public n_column GetColumnByName(String strName)
        {
            n_column c;
            foreach (DictionaryEntry d in AllColumns)
            {
                c = (n_column)d.Value;
                if (Tools.Strings.StrCmp(c.field_name, strName))
                {
                    return c;
                }
            }

            return null;
        }
        public int GetNextColumnOrder()
        {
            if (AllColumns == null)
                return 0;

            n_column c;
            int highest = -1;
            foreach (DictionaryEntry d in AllColumns)
            {
                c = (n_column)d.Value;
                if (c.column_order > highest)
                    highest = c.column_order;

            }
            return highest + 1;
        }
        public void AbsorbColumn(Context x, n_column c)
        {
            try
            {
                if (AllColumns.ContainsKey(c.column_order))
                {
                    while (AllColumns.ContainsKey(c.column_order))
                        c.column_order++;
                    c.Update(x);
                }

                AllColumns.Add(c.column_order, c);
            }
            catch (Exception)
            { }
        }
        public void ChangeColumnOrder(Context context, n_column c, int new_order)
        {
            n_column x = GetColumnByOrder(new_order);
            if (x != null)
            {
                AllColumns.Remove(x.column_order);
                x.column_order = (this.GetNextColumnOrder() + 1);
                context.Update(x);
                this.AbsorbColumn(context, x);
            }

            AllColumns.Remove(c.column_order);
            c.column_order = new_order;
            context.Update(c);
            this.AbsorbColumn(context, c);
        }
        public n_column GetColumnByOrder(int ord)
        {
            try
            {
                return (n_column)AllColumns[ord];
            }
            catch (Exception e)
            {
            }
            return null;
        }
        public void RemoveAllColumns(ContextNM x)
        {
            x.Execute("delete from n_column where the_n_template_uid = '" + this.unique_id + "'");
            GatherColumns(x);
        }
        public void AbsorbColumns(ContextNM x, n_template t)
        {
            foreach (DictionaryEntry d in t.AllColumns)
            {
                n_column c = (n_column)d.Value;
                n_column n = (n_column)c.CloneValues(x);
                n.the_n_template_uid = unique_id;
                x.Insert(n);
                AbsorbColumn(x, n);
            }
        }
        public SortedList GetColumns(ContextNM x)
        {
            if( AllColumns == null )
                this.GatherColumns(x);

            return AllColumns;
        }
        public ArrayList GetColumnArray()
        {
            ArrayList a = new ArrayList();
            if( AllColumns == null )
                return a;

            foreach (DictionaryEntry d in AllColumns)
            {
                n_column c = (n_column)d.Value;
                a.Add(c);
            }
            return a;
        }
        public String GetHTMLTableRow(ContextNM x, nObject o)
        {
            return GetHTMLTableRow(x, o, "black");
        }
        public String GetHTMLTableRow(ContextNM x, nObject o, String strColor)
        {
            SortedList colColumns = this.GetColumns(x);
            StringBuilder strHTML = new StringBuilder();

            strHTML.AppendLine("<tr>");
            n_column xColumn;
            foreach (DictionaryEntry d in colColumns)
            {
                xColumn = (n_column)d.Value;
                strHTML.Append("<td><font color=" + strColor + " ><b>" + xColumn.column_caption + "</b></font></td>");
            }
            strHTML.AppendLine("</tr>");
            strHTML.AppendLine("<tr>");
            foreach (DictionaryEntry d in colColumns)
            {
                xColumn = (n_column)d.Value;
                switch (xColumn.data_type)
                {
                    case (Int32)FieldType.String:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + (String)o.IGet(xColumn.field_name) + "</font></td>");
                        break;
                    case (Int32)FieldType.Text:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + (String)o.IGet(xColumn.field_name) + "</font></td>");
                        break;
                    case (Int32)FieldType.Int64:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + Tools.Number.LongFormat((long)o.IGet(xColumn.field_name)) + "</font></td>");
                        break;
                    case (Int32)FieldType.Int32:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + Tools.Number.LongFormat((int)o.IGet(xColumn.field_name)) + "</font></td>");
                        break;
                    case (Int32)FieldType.Boolean:
                        break;
                    case (Int32)FieldType.Double:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.MoneyFormat_2_6((Double)o.IGet(xColumn.field_name)) + "</font></td>");
                        break;
                    case (Int32)FieldType.DateTime:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.DateFormat((DateTime)o.IGet(xColumn.field_name)) + "</font></td>");
                        break;
                }
            }
            strHTML.AppendLine("</tr>");
            return strHTML.ToString();
        }
        public n_template Duplicate(ContextNM x, String strNewName)
        {
            n_template t = (n_template)this.CloneValues(x);
            t.template_name = strNewName;
            x.Insert(t);

            this.GatherColumns(x);
            foreach (DictionaryEntry d in this.AllColumns)
            {
                n_column c = (n_column)d.Value;
                n_column c2 = (n_column)c.CloneValues(x);
                c2.the_n_template_uid = t.unique_id;
                x.Insert(c2);
            }
            return t;
        }
        public static n_template Create(ContextNM x, String class_name, String template_name)
        {
            n_template ret = (n_template)x.Item("n_template");
            ret.template_name = template_name;
            //ret.the_n_class_uid = xs.GetClassID(class_name);
            ret.class_name = class_name;
            ret.use_gridlines = true;
            x.Insert(ret);
            ret.CreateDefaultColumns(x);
            return ret;
        }
        public String GetHTMLTableRowOnlyHeader(ContextNM x, String strColor)
        {
            return GetHTMLTableRowOnlyHeader(strColor, this.GetColumns(x));
        }
        public String GetHTMLTableRowOnlyHeader(String strColor, SortedList colColumns)
        {
            StringBuilder strHTML = new StringBuilder();

            strHTML.AppendLine("<tr>");
            n_column xColumn;
            foreach (DictionaryEntry d in colColumns)
            {
                xColumn = (n_column)d.Value;
                strHTML.Append("<td><font color=" + strColor + " ><b>" + xColumn.column_caption + "</b></font></td>");
            }
            strHTML.AppendLine("</tr>");
            return strHTML.ToString();
        }
        public String GetHTMLTableRowOnlyRow(ContextNM x, nObject o, String strColor)
        {
            return GetHTMLTableRowOnlyRow(o, strColor, this.GetColumns(x));
        }
        public String GetHTMLTableRowOnlyRow(nObject o, String strColor, SortedList colColumns)
        {
            StringBuilder strHTML = new StringBuilder();

            strHTML.AppendLine("<tr>");
            n_column xColumn;
            foreach (DictionaryEntry d in colColumns)
            {
                xColumn = (n_column)d.Value;
                switch (xColumn.data_type)
                {
                    case (Int32)FieldType.String:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + (String)o.IGet(xColumn.field_name) + "</font>&nbsp;</td>");
                        break;
                    case (Int32)FieldType.Text:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + (String)o.IGet(xColumn.field_name) + "</font>&nbsp;</td>");
                        break;
                    case (Int32)FieldType.Int64:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + Tools.Number.LongFormat((long)o.IGet(xColumn.field_name)) + "</font>&nbsp;</td>");
                        break;
                    case (Int32)FieldType.Int32:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + Tools.Number.LongFormat((int)o.IGet(xColumn.field_name)) + "</font>&nbsp;</td>");
                        break;
                    case (Int32)FieldType.Boolean:
                        break;
                    case (Int32)FieldType.Double:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.MoneyFormat_2_6((Double)o.IGet(xColumn.field_name)) + "</font>&nbsp;</td>");
                        break;
                    case (Int32)FieldType.DateTime:
                        strHTML.AppendLine("<td><font color=" + strColor + " >" + nTools.DateFormat((DateTime)o.IGet(xColumn.field_name)) + "</font>&nbsp;</td>");
                        break;
                }
            }
            strHTML.AppendLine("</tr>");
            return strHTML.ToString();
        }
        public static n_template GetByName(Context x, String templateName)
        {
            return (n_template)x.TheData.GetByWhere(x, "n_template", "template_name = '" + x.TheData.Filter(templateName) + "'");
        }
        public List<FieldType> ColumnTypes(ContextNM x)
        {
            List<n_column> cl = ColumnsList(x);
            List<FieldType> fl = new List<FieldType>();
            foreach (n_column col in cl)
            {
                fl.Add((FieldType)col.data_type);
            }
            return fl;
        }
        public List<String> ColumnCaptions(ContextNM x)
        {
            List<n_column> cl = ColumnsList(x);
            List<String> ret = new List<String>();
            foreach (n_column col in cl)
            {
                ret.Add(col.column_caption);
            }
            return ret;
        }
    }
}
