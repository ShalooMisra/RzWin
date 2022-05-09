using System;
using System.Collections;
using System.Text;
using Tools.Database;

namespace NewMethod
{
    public enum SQLClause
    {
        None = 0,
        And = 1,
        Or = 2,
    }

    public class nSQL
    {
        public string strClass = "";
        public String strWhere = "";
        public String strOrder = "";
        public long lngLimit = -1;
        public string strTemplate = "";
        public bool IsAbsolute = false;
        public string strAlternateTable = "";

        public String UpdateString = "";
        public String InsertFields = "";
        public String InsertValues = "";

        public SQLClause Clause;
        public ArrayList SubClauses;

        public nSQL(bool absolute)
        {
            IsAbsolute = absolute;
        }

        public nSQL()
        {

        }

        public nSQL(String strUpdate)
        {
            UpdateString = strUpdate;
        }

        public void AddInsertFields(String s)
        {
            //this is done by the automated logic
            //that's why this problem didn't show up until the update stage
            //if (Tools.Strings.StrExt(InsertFields))
            //    InsertFields += ", ";
            InsertFields += s;
        }

        public void AddInsertValues(String s)
        {
            //if (Tools.Strings.StrExt(InsertValues))
            //    InsertValues += ", ";
            InsertValues += s;
        }

        public void AddUpdateString(String s)
        {
            if (Tools.Strings.StrExt(s))
            {
                if (Tools.Strings.StrExt(UpdateString))
                    UpdateString += ", ";

                UpdateString += s;
            }
        }

        public nSQL(String strFields, String strValues)
        {
            InsertFields = strFields;
            InsertValues = strValues;
        }

        public static String GetDateRangeSQL(String strField, DateTime start, DateTime end)
        {
            return " " + strField + " between cast( '" + nTools.DateFormat(start) + " 00:00:00' as datetime) and cast( '" + nTools.DateFormat(end) + " 23:59:59' as datetime) ";
        }

        public void AddWhere(ContextNM x, String strField, String strValue)
        {
            AddWhere(x, strField, strValue, false);
        }

        public void AddWhere(ContextNM x, String strField, String strValue, bool force_fuzzy)
        {
            if (!Tools.Strings.StrExt(strValue))
                return;

            if (strValue.Length > 6 || force_fuzzy)
                AddWhere(x, strField, strValue, NewMethod.Enums.CompareType.LikeVeryFuzzy, FieldType.String);
            else if( strValue.Length > 2 )
                AddWhere(x, strField, strValue, NewMethod.Enums.CompareType.LikeFuzzy, FieldType.String);
            else
                AddWhere(x, strField, strValue, NewMethod.Enums.CompareType.LikeTrailing, FieldType.String);
        }

        public void AddWhere_Phone(ContextNM x, String strField, String strValue)
        {
            if (!Tools.Strings.StrExt(strValue))
                return;

            if (strValue.Length > 4)
            {
                strValue = strValue.Replace("-", "%");
                strField = "replace(" + strField + ", '-', '')";
                AddWhere(x, strField, strValue, NewMethod.Enums.CompareType.LikeFuzzy, FieldType.String);
            }
            else
            {
                strValue = strValue.Replace("-", "");
                AddWhere(x, strField, strValue, NewMethod.Enums.CompareType.LikeTrailing, FieldType.String);
            }
        }

        //public void AddWhere(n_sys xs, String strField, String strValue)
        //{
        //    if (!Tools.Strings.StrExt(strValue))
        //        return;

        //    if (strValue.Length > 4)
        //        AddWhere(xs, strField, strValue, NewMethod.Enums.CompareType.LikeFuzzy, FieldType.String);
        //    else
        //        AddWhere(xs, strField, strValue, NewMethod.Enums.CompareType.LikeTrailing, FieldType.String);
        //}

        public void AddWhere_Date(SysNewMethod xs, String strField, DateTime d1, DateTime d2)
        {
            if (!Tools.Dates.DateExists(d1))
                return;

            CheckAdd();
            if (!Tools.Dates.DateExists(d2))
            {
                AddDirectWhere(" " + strField + " >= '" + Tools.Dates.DateFormatRegardlessOfWindowsSettings(d1) + " 12:00:00 AM'");
            }
            else
            {
                Tools.Dates.DateRange dr = new Tools.Dates.DateRange(d1, d2);
                AddDirectWhere(" ( " + dr.GetSQL(strField) + " ) ");
            }
        }

        public void AddDirectWhere(String s)
        {
            strWhere += " " + s;
        }

        public void AddDirectWhereAnd(String s)
        {
            if (Tools.Strings.StrExt(strWhere))
                strWhere += " and ";

            strWhere += " " + s;
        }

        public void AddDirectWhereOr(String s)
        {
            if (Tools.Strings.StrExt(strWhere))
                strWhere += " or ";

            strWhere += " " + s;
        }

        public void AddWhere(ContextNM x, String strField, String strValue, Enums.CompareType ct)
        {
            AddWhere(x, strField, strValue, ct, FieldType.String);
        }

        public void AddWhere_Boolean(ContextNM x, String strField, bool value)
        {
            CheckAdd();
            
            if( value )
                AddDirectWhere(" isnull(" + strField + ", 0) = 1");
            else
                AddDirectWhere(" isnull(" + strField + ", 0) = 0"); 
        }

        public void CheckAdd()
        {
            if (IsAbsolute)
                CheckAddAnd();
            else
                CheckAddOr();
        }

        public void AddWhere(ContextNM context, String strField, String strValue, Enums.CompareType ct, FieldType dt )
        {
            if (!Tools.Strings.StrExt(strValue))
                return;

            if (Tools.Strings.StrCmp(strValue, "<blank>"))
                strValue = "";

            CheckAdd();

            if (dt == FieldType.String)
            {
                switch (ct)
                {
                    case NewMethod.Enums.CompareType.LikeFuzzy:
                    case NewMethod.Enums.CompareType.NotLikeFuzzy:
                        strValue = "'%" + context.TheData.Filter(strValue) + "%'";
                        break;
                    case NewMethod.Enums.CompareType.LikeVeryFuzzy:
                        strValue = "'%" + context.TheData.Filter(strValue.Replace(" ", "%")) + "%'";
                        break;
                    case NewMethod.Enums.CompareType.LikeLeading:
                        strValue = "'%" + context.TheData.Filter(strValue) + "'";
                        break;
                    case NewMethod.Enums.CompareType.NotLikeTrailing:
                    case NewMethod.Enums.CompareType.LikeTrailing:
                        strValue = "'" + context.TheData.Filter(strValue) + "%'";
                        break;
                    default:
                        strValue = "'" + context.TheData.Filter(strValue) + "'";
                        break;
                }
            }

            switch( ct )
            {
                case NewMethod.Enums.CompareType.Equal:
                    strWhere += strField + " = " + strValue;
                    break;
                case NewMethod.Enums.CompareType.NotEqual:
                    strWhere += "isnull(" + strField + ", '') <> " + strValue;
                    break;
                case NewMethod.Enums.CompareType.GreaterThan:
                    strWhere += strField + " > " + strValue;
                    break;
                case NewMethod.Enums.CompareType.LessThan:
                    strWhere += strField + " < " + strValue;
                    break;
                case NewMethod.Enums.CompareType.In:
                    strWhere += strField + " in (" + strValue + ")";
                    break;
                case NewMethod.Enums.CompareType.NotIn:
                    strWhere += strField + " not in (" + strValue + ")";
                    break;
                case NewMethod.Enums.CompareType.NotLikeTrailing:
                case NewMethod.Enums.CompareType.NotLikeFuzzy:
                    strWhere += strField + " not like " + strValue;
                    break;
                default:
                    strWhere += strField + " like " + strValue;
                    break;
            }
        }

        public void CheckAddOr()
        {
            if (Tools.Strings.StrExt(strWhere))
                strWhere += " or ";
        }

        public void CheckAddAnd()
        {
            if (Tools.Strings.StrExt(strWhere))
                strWhere += " and ";
        }

        public void AddNonAbsolute(nSQL ns)
        {
            if (!Tools.Strings.StrExt(ns.strWhere))
                return;

            CheckAddAnd();
            strWhere += " ( ";
            strWhere += ns.strWhere;
            strWhere += " ) ";
        }

        public nSQL AddClause(SQLClause c)
        {
            if (SubClauses == null)
                SubClauses = new ArrayList();
            nSQL x = new nSQL();
            x.Clause = c;
            SubClauses.Add(x);
            return x;
        }

        public nSQL AddClause(SQLClause c, String strWhere)
        {
            if (SubClauses == null)
                SubClauses = new ArrayList();
            nSQL x = new nSQL();
            x.Clause = c;
            SubClauses.Add(x);
            x.strWhere = strWhere;
            return x;
        }

        public String RenderSQL()
        {
            StringBuilder sb = new StringBuilder();
            RenderSQL(0, sb);
            return sb.ToString();
        }

        public void RenderSQL(int level, StringBuilder sb)
        {
            if( Tools.Strings.StrExt(strWhere) )
                sb.Append(IndentLevel(level - 1) + strWhere);

            if( SubClauses != null )
            {
                if( !IsBlank )
                    level++;

                int i = 0;
                foreach(nSQL s in SubClauses)
                {
                    if (s.HasContents())
                    {
                        //if (i == 0)
                        //    strSQL += " ";
                        //else
                        if( i > 0 )
                            sb.Append("\r\n" + IndentLevel(level) + s.Clause.ToString() + "\r\n");

                        i++;

                        bool brackets = s.HasSubClausesWithWhere();
                        //bool brackets = true;
                        if( s.Clause == SQLClause.Or )
                            brackets = true;

                        if (brackets)
                            sb.Append(IndentLevel(level) + "(\r\n");

                        s.RenderSQL(level + 1, sb);

                        if (brackets)
                            sb.Append("\r\n" + IndentLevel(level) + ")\r\n");
                    }
                }
            }
        }

        public bool IsBlank
        {
            get
            {
                return !Tools.Strings.StrExt(strWhere) && Clause == SQLClause.None;
            }
        }

        private String IndentLevel(int level)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < level; i++)
            {
                sb.Append("    ");
            }
            return sb.ToString();
        }

        public bool HasContents()
        {
            if (Tools.Strings.StrExt(strWhere))
                return true;

            if (SubClauses == null)
                return false;

            return SubClauses.Count > 0;
        }

        public bool HasSubClauses()
        {
            if (SubClauses == null)
                return false;

            return (SubClauses.Count > 0);
        }

        public bool HasSubClausesWithWhere()
        {
            if (SubClauses == null)
                return false;

            if (SubClauses.Count == 0)
                return false;

            return true;

            //foreach (nSQL x in SubClauses)
            //{
            //    if (Tools.Strings.StrExt(x.strWhere))
            //        return true;
            //}
            //return false;
        }
    }

    namespace Enums
    {
        public enum CompareType
        {
            Equal = 0,
            NotEqual = 1,            
            LikeLeading = 2,
            LikeTrailing = 3,
            LikeFuzzy = 4,
            LikeVeryFuzzy = 5,
            GreaterThan = 6,
            LessThan = 7,
            In = 8,
            NotIn = 9,
            NotLikeTrailing = 10,
            NotLikeFuzzy = 11,
        }
    }
}
