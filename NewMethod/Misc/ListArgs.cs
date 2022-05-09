using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Core;
using Tools.Database;

namespace NewMethod
{
    public class ListArgs
    {
        public ContextNM TheContext;
        public String TheCaption = "";
        public String TheClass = "";
        private String m_TheClassAlias = "";
        public String TheClassAlias
        {
            get
            {
                if (!Tools.Strings.StrExt(m_TheClassAlias))
                    m_TheClassAlias = TheClass;
                return m_TheClassAlias;
            }

            set
            {
                m_TheClassAlias = value;
            }
        }
        public String TheTemplate = "";
        public String TheTemplateBase = "";  //if TheTemplate isn't found, the template to copy in to start with
        public string TheGroup = "";
        public String TheWhere = "";
        public String TheOrder = "";
        public String TheHTMLData = "";
        public int TheLimit = -1;
        public String TheTable = "";
        public string TheInnerJoin = "";
        public string ThePrepareStatement = "";
        public Colorizer TheColorizer = new ColorizerSimple();
        //public Dictionary<String, nObject> LiveObjects = null;
        public IItems LiveItems = null;
        public bool AddAllow = true;
        public bool UnlimitedAllow = true;
        public bool ExportAllow = true;        
        public String ExtraClassInfo = "";
        public bool HeaderOnly = false;
        private string z_TheUIDTable = "";
        public String TheUIDTable
        {
            get
            {
                if (!Tools.Strings.StrExt(z_TheUIDTable))
                {
                    if (Tools.Strings.StrExt(TheTable))
                        return TheTable;
                    else
                        return TheClass;
                }
                else
                    return z_TheUIDTable;
            }
            set
            {
                z_TheUIDTable = value;
            }
        }
        private string z_TheGridColorTable = "";
        public String TheGridColorTable
        {
            get
            {
                if (!Tools.Strings.StrExt(z_TheGridColorTable))
                {
                    if (Tools.Strings.StrExt(TheTable))
                        return TheTable;
                    else
                        return TheClass;
                }
                else
                    return z_TheGridColorTable;
            }
            set
            {
                z_TheGridColorTable = value;
            }
        }
        private string z_TheIconTable = "";
        public String TheIconTable
        {
            get
            {
                if (!Tools.Strings.StrExt(z_TheIconTable))
                {
                    if (Tools.Strings.StrExt(TheTable))
                        return TheTable;
                    else
                        return TheClass;
                }
                else
                    return z_TheIconTable;
            }
            set
            {
                z_TheIconTable = value;
            }
        }
        public bool AddQueryStringsHas
        {
            get
            {
                if (m_AddQueryStrings == null)
                    return false;
                if (m_AddQueryStrings.Count == 0)
                    return false;
                return true;
            }
        }

        public ArrayList AddCaptions = new ArrayList();
        public String AddCaption
        {
            get
            {
                if (AddCaptions.Count == 0)
                    return "";
                return (String)AddCaptions[0];
            }

            set
            {
                AddCaptions.Clear();
                AddCaptions.Add(value);
            }
        }

        ArrayList m_AddQueryStrings = null;
        public ArrayList AddQueryStrings
        {
            get
            {
                if (m_AddQueryStrings == null)
                    m_AddQueryStrings = new ArrayList();
                return m_AddQueryStrings;
            }
        }

        public bool OptionsAllow = true;
        public bool SaveAllow = true;
        public String UniqueID = "";
        public DataConnection TheConnection = null;
        public nSQL SQL = null;
        public ArrayList PrepareArgs = null;
        
        //public String AddQueryString = "";

        //Constructors
        public ListArgs(ContextNM x)
        {
            TheContext = x;
            UniqueID = Tools.Strings.GetNewID();
            ExportAllow = x.xUser.ExportAllow(x);  // NewMethod.MenuSetup.AllowExcelExport;
        }
        //Public Virtual Functions
        public virtual void PrepareTables()
        {
            //KT This was empty, refactored data from RzSensible
            {
                if (PrepareArgs == null)
                    return;
                if (PrepareArgs.Count <= 0)
                    return;
                foreach (ListArgs a in PrepareArgs)
                {
                    DataSql d = a.TheContext.Data;
                    if (d == null)
                        continue;
                    d.Execute(a.ThePrepareStatement);
                }
                TheHTMLData = GetHTMLTableView();
            }
        }
        public virtual void CleanUpTables()
        {
            //KT This was empty, refactored data from RzSensible
            if (PrepareArgs == null)
                return;
            if (PrepareArgs.Count <= 0)
                return;

            foreach (ListArgs a in PrepareArgs)
            {
                DataSql d = a.TheContext.Data;
                if (d == null)
                    continue;
                d.Execute("drop table " + a.TheTable);
            }
            //if (Tools.Strings.StrExt(TheHTMLFile))
            //    ShowHTMLFile(TheHTMLFile);
        }

        //KT 5-4-2016 - Modified to handle MySQL as well.
        public String RenderSql(ContextNM context, bool isMySql = false)
        {
            

            String ret = "select ";
            if(!isMySql)
            {
                if (TheLimit > 0)
                    ret += " top " + TheLimit.ToString();
                else if (TheLimit == -2)  //or should this be the 0/-1 default?
                {
                    //no limit
                }
                else
                    ret += " top 1000";
            }
           
            
            ret += " * from " + TheTable;
            if (Tools.Strings.StrExt(TheWhere))
                ret += " where " + TheWhere;
            if (Tools.Strings.StrExt(TheOrder))
                ret += " order by " + TheOrder;
            if(isMySql)
            {
                if (TheLimit > 0)
                    ret += " Limit " + TheLimit.ToString();
                else if (TheLimit == -2)  //or should this be the 0/-1 default?
                {
                    //no limit
                }
                else
                    ret += " Limit  1000";
            }

            return ret;
        }

        public String RenderSqlWithoutSystem(Context x, n_template t)
        {
            return RenderSql(x, t, "");
        }

        public String RenderSql(Context x, n_template t)
        {
            return RenderSql(x, t, this.TheUIDTable + ".unique_id," + this.TheGridColorTable + ".grid_color," + this.TheIconTable + ".icon_index");
        }

        public String RenderSql(Context x, n_template t, String extraFields)
        {
            String table = this.TheTable;
            if (table == "")
                table = this.TheClass;
            String fields = extraFields;
            foreach (DictionaryEntry d in t.AllColumns)
            {
                if (fields != "")
                    fields += ", ";
                n_column c = (n_column)d.Value;
                fields += table + "." + c.field_name + " as " + c.field_name;
            }
            String sql = "select ";
            if (this.TheLimit > 0)
                sql += " top " + this.TheLimit.ToString() + " ";
            sql += fields;
            sql += " from " + table;
            if (this.TheInnerJoin != "")
                sql += " inner join " + this.TheInnerJoin;
            if (this.TheWhere != "")
                sql += " where " + this.TheWhere;
            if (this.TheGroup != "")
                sql += " group by " + this.TheGroup;
            if (this.TheOrder != "")
                sql += " order by " + this.TheOrder;
            return sql;
        }

        public virtual ActSetup ActSetupCreate()
        {
            return new ActSetup();
        }
        //KT Refactored from RzSensible
        //Private Functions
        private string GetHTMLTableView()
        {
            StringBuilder sb = new StringBuilder();
            string last_table = "";
            foreach (ListArgs a in PrepareArgs)
            {
                if (!Tools.Strings.StrExt(last_table))
                    last_table = a.TheTable;
                else if (Tools.Strings.StrExt(last_table))
                {
                    if (Tools.Strings.StrCmp(last_table, a.TheTable))
                        continue;
                }
                DataSql d = a.TheContext.Data;
                if (d == null)
                    continue;
                DataTable dt = d.Select("select * from " + a.TheTable);
                if (dt == null)
                    continue;
                if (dt.Rows.Count <= 0)
                    continue;
                if (!TheContext.Data.FieldExists(a.TheTable, "partrecord_part"))
                    continue;
                string ResultPrice = "";
                string ResultPercent = "";
                string ResultPriceCol = "";
                string ResultPercentCol = "";
                string ResultsType = "";
                foreach (DataColumn dc in dt.Columns)
                {
                    if (Tools.Strings.StrCmp(dc.Caption, "unique_id") || Tools.Strings.StrCmp(dc.Caption, "partrecord_price") || Tools.Strings.StrCmp(dc.Caption, "partrecord_part"))
                        continue;
                    if (dc.Caption.ToLower().Contains("lowest_sales") || dc.Caption.ToLower().Contains("lowest_purchase") || dc.Caption.ToLower().Contains("avg_sales") || dc.Caption.ToLower().Contains("avg_purchase"))
                    {
                        if (!dc.Caption.ToLower().Contains("perc_diff"))
                        {
                            ResultPrice = dc.Caption;
                            ResultsType = FilterColumnCaption(dc.Caption);
                            ResultPriceCol = "    <td width=\"25%\" bgcolor=\"#E4E4E4\">" + FilterColumnCaption(dc.Caption) + "</td>";
                        }
                        else
                        {
                            ResultPercent = dc.Caption;
                            ResultPercentCol = "    <td width=\"25%\" bgcolor=\"#E4E4E4\">" + FilterColumnCaption(dc.Caption) + "</td>";
                        }
                    }
                }
                sb.AppendLine("<table border=\"1\" width=\"100%\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"100%\">");
                sb.AppendLine("<table border=\"0\" width=\"100%\">");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"100%\" colspan=\"4\">" + ResultsType + "</td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("  <tr>");
                sb.AppendLine("    <td width=\"25%\" bgcolor=\"#E4E4E4\">Part Number</td>");
                sb.AppendLine("    <td width=\"25%\" bgcolor=\"#E4E4E4\">Part Price</td>");
                sb.AppendLine(ResultPriceCol);
                sb.AppendLine(ResultPercentCol);
                sb.AppendLine("  </tr>");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.AppendLine("  <tr>");
                    sb.AppendLine("    <td width=\"25%\">" + dr["partrecord_part"].ToString() + "</td>");
                    sb.AppendLine("    <td width=\"25%\">$" + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr["partrecord_price"])) + "</td>");
                    sb.AppendLine("    <td width=\"25%\">$" + Tools.Number.MoneyFormat_2_6(nData.NullFilter_Double(dr[ResultPrice])) + "</td>");
                    sb.AppendLine("    <td width=\"25%\">" + Convert.ToInt32(nData.NullFilter_Double(dr[ResultPercent])).ToString() + "%</td>");
                    sb.AppendLine("  </tr>");
                }
                sb.AppendLine("</table>");
                sb.AppendLine("    </td>");
                sb.AppendLine("  </tr>");
                sb.AppendLine("</table><p>&nbsp;</p>");
            }
            return sb.ToString();
            //string folder = Tools.Folder.ConditionFolderName(Tools.Folder.GetAppPath()) + "Junk\\";
            //if (!Tools.Folder.FolderExists(folder))
            //    Tools.Folder.MakeFolderExist(folder);
            //string file = folder + Tools.Strings.GetNewID() + ".html";
            //if (!Tools.Files.SaveFileAsString(file, sb.ToString()))
            //     return "";
            //return file;
        }
        private string FilterColumnCaption(string s)
        {
            string build = "";
            string[] hold = Tools.Strings.Split(s, "_");
            foreach (string ss in hold)
            {
                if (!Tools.Strings.StrExt(ss))
                    continue;
                build += CapFirstChar(ss) + " ";
            }
            return build.Trim();
        }
        private string CapFirstChar(string s)
        {
            string build = "";
            char[] hold = s.ToCharArray();
            bool first = false;
            foreach (char c in hold)
            {
                if (!Tools.Strings.StrExt(c.ToString()))
                    continue;
                if (!first)
                {
                    build += c.ToString().ToUpper();
                    first = true;
                }
                else
                    build += c.ToString().ToLower();
            }
            return build.Trim();
        }
        private void ShowHTMLFile(string file)
        {
            if (!Tools.Strings.StrExt(file))
                return;
            if (!Tools.Files.FileExists(file))
                return;
            Tools.Files.OpenFileInDefaultViewer(file);
        }



        public interface IGenericNotify
        {
            void Notify(Object n);
        }





    }
    public class Colorizer
    {
        public virtual Color RowForeColor(DataRow dr)
        {
            return Color.Black;
        }
        public virtual Color RowForeColor(nObject o)
        {
            return Color.Black;
        }
    }
    public class ColorizerSimple : Colorizer
    {
        public override Color RowForeColor(DataRow dr)
        {
            try
            {
                if (dr == null)
                    return base.RowForeColor(dr);
                return nTools.GetColorFromInt(Tools.Data.NullFilterInt(dr["grid_color"]));
            }
            catch { }
            return base.RowForeColor(dr);
        }
        public override Color RowForeColor(nObject o)
        {
            try
            {
                if (o == null)
                    return base.RowForeColor(o);
                return nTools.GetColorFromInt(o.grid_color);
            }
            catch { }
            return base.RowForeColor(o);
        }
      

    }    
}
