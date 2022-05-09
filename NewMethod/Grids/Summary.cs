using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace NewMethod.Grids
{
    public class Summary
    {
        public ContextNM TheContext;
        public virtual String TheClass
        {
            get
            {
                return "";
            }
        }

        public virtual String TheTemplate
        {
            get
            {
                return "";
            }
        }

        public virtual String TheOrder
        {
            get
            {
                return "unique_id";
            }
        }

        public virtual String YProperty
        {
            get
            {
                return "";
            }
        }

        public virtual String YCaption
        {
            get
            {
                return YProperty;
            }
        }

        public virtual String XProperty
        {
            get
            {
                return "";
            }
        }

        public virtual String XCaption
        {
            get
            {
                return XProperty;
            }
        }

        public List<SummaryColumn> Columns = new List<SummaryColumn>();
        public List<SummaryRow> Rows = new List<SummaryRow>();

        public virtual void Init(ContextNM x)
        {
            TheContext = x;
        }

        public virtual void Calc()
        {
            Columns.Clear();
            Rows.Clear();

            ColsCalc();
            RowsCalc();
        }

        public virtual void ColsCalc()
        {
            ArrayList cols = TheContext.TheData.SelectScalarArray("select distinct(" + XProperty + ") from " + TheClass + " where " + WhereClause + " order by " + XProperty);
            cols = XOrder(cols);
            foreach (String s in cols)
            {
                Columns.Add(new SummaryColumn(s));
            }
        }

        public virtual void RowsCalc()
        {
            //get a list of the distinct y axis
            ArrayList a = TheContext.TheData.SelectScalarArray("select distinct(" + YProperty + ") from " + TheClass + " where " + WhereClause + " order by " + YProperty);
            a = YOrder(a);
            foreach (String s in a)
            {
                SummaryRow r = new SummaryRow(s);
                foreach (SummaryColumn col in Columns)
                {
                    int count = TheContext.TheData.SelectScalarInt32("select count(*) from " + TheClass + " where " + WhereCalc(r, col));
                    SummaryValue v = new SummaryValue();
                    v.Count = count;
                    r.Values.Add(v);
                }

                Rows.Add(r);
            }
        }

        String WhereCalc(SummaryRow r, SummaryColumn col)
        {
            return WhereClause + " and " + YProperty + " = '" + TheContext.TheData.Filter(r.Name) + "' and " + XProperty + " = '" + TheContext.TheData.Filter(col.Name) + "'";
        }

        public virtual ListArgs ListArgsGet(SummaryRow row, SummaryColumn col)
        {
            ListArgs ret = new ListArgs(TheContext);
            ret.TheClass = TheClass;
            ret.TheTable = TheClass;
            ret.TheTemplate = TheTemplate;
            ret.TheWhere = WhereCalc(row, col);
            ret.TheOrder = TheOrder;
            return ret;
        }

        public virtual ArrayList XOrder(ArrayList a)
        {
            return a;
        }

        public virtual ArrayList YOrder(ArrayList a)
        {
            return a;
        }

        public virtual String WhereClause
        {
            get
            {
                return " unique_id > ''";
            }
        }
    }

    public class SummaryColumn
    {
        public String Name;
        public SummaryColumn(String name)
        {
            Name = name;
        }
    }

    public class SummaryRow
    {
        public String Name;
        public List<SummaryValue> Values = new List<SummaryValue>();

        public SummaryRow(String name)
        {
            Name = name;
        }        
    }

    public class SummaryValue
    {
        public int Count;
    }
}
