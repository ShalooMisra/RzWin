using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace NewMethod
{
    public static class nDataManipilation
    {
        public static DataTable ProcessTable(DataTable d, List<ColumnAction> actions)
        {
            DataTable ret = new DataTable("temp_" + Tools.Strings.GetNewID());

            foreach (DataColumn c in d.Columns)
            {
                ret.Columns.Add(c.Caption, c.DataType);
            }

            Dictionary<String, DataRow> completed = new Dictionary<string, DataRow>(); 
            foreach (DataRow r in d.Rows)
            {
                int i = 0;
                String strKey = "";
                foreach (DataColumn c in d.Columns)
                {
                    switch (actions[i])
                    {
                        case ColumnAction.Compare:
                            strKey += "|<break>|";
                            object val = r[i];
                            if (val == null)
                                strKey += "<null>";
                            else
                                strKey += val.ToString();
                            break;
                    }
                    i++;
                 }


                //now the key is known, find the row
                DataRow rr = null;
                if (completed.ContainsKey(strKey.ToLower()))
                {
                    rr = completed[strKey.ToLower()];

                    i = 0;
                    foreach (DataColumn c in d.Columns)
                    {
                        switch (actions[i])
                        {
                            case ColumnAction.Coalesce:
                                String sn = nData.NullFilter(r[i]);
                                if (sn != "")
                                {
                                    String sc = nData.NullFilter(rr[i]);
                                    if (sc != "")
                                        sc += " / ";
                                    sc += sn;
                                    rr[i] = sc;
                                }
                                break;
                            case ColumnAction.First:
                                object x = rr[i];
                                if (x == null)
                                    rr[i] = r[i];
                                break;
                            case ColumnAction.Sum:
                                Double dd = nData.NullFilter_Double(rr[i]);
                                Double dn = nData.NullFilter_Double(r[i]);
                                rr[i] = (dd + dn);
                                break;
                        }
                        i++;
                    }
                }
                else
                {
                    object[] xa = new object[ret.Columns.Count];
                    i = 0;
                    foreach (DataColumn c in d.Columns)
                    {
                        xa[i] = r[i];
                        i++;
                    }

                    rr = ret.Rows.Add(xa);
                    completed.Add(strKey.ToLower(), rr);

                }
            }
            return ret;
        }
    }

    public enum ColumnAction
    {
        Compare = 0,
        Coalesce = 1,
        Sum = 2,
        First = 3,
    }
}
