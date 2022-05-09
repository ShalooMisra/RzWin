using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public class RecallLogic
    {
        public virtual IItem RestoreViaClassAndId(ContextRz context, String ClassId, String Uid)
        {
            context.Reorg();
            return null;

            //if (!context.xSys.Recall)
            //{
            //    context.TheLeader.Error("This system isn't set up for Recall.");
            //    return null;
            //}

            //String strSQL = "select unique_id from " + ClassId + " where unique_id = '" + Uid + "'";
            //string s = context.xSys.xData.GetScalar(strSQL, "");
            //if (Tools.Strings.StrExt(s))
            //{
            //    context.TheLeader.Error("This " + ClassId + " already appears to exist in the main database.");
            //    return null;
            //}
            //s = context.xSys.recall_connection.GetScalar(strSQL, "");
            //if (!Tools.Strings.StrExt(s))
            //{
            //    context.TheLeader.Error("This " + ClassId + " wasn't found in the Recall system.");
            //    return null;
            //}
            //DataTable st = context.xSys.recall_connection.GetDataTable("select top 1 * from " + ClassId + "");
            //SortedList props = context.xSys.GetPropsByClass(ClassId);
            //strSQL = "";
            //ArrayList a = new ArrayList();
            //foreach (DictionaryEntry d in props)
            //{
            //    n_prop p = (n_prop)d.Value;
            //    //only restore fields that exist in the backup
            //    if (!p.IsUniqueID)
            //    {
            //        if (nData.HasField(st, p.name))
            //        {
            //            if (!nTools.IsInArray(p.name, a))
            //            {
            //                if (Tools.Strings.StrExt(strSQL))
            //                    strSQL += ", ";
            //                strSQL += p.name;
            //                a.Add(p.Name);
            //            }
            //        }
            //    }
            //}
            //strSQL = "insert into " + context.TheData.DatabaseName + ".dbo.partrecord(unique_id, " + strSQL + ") select top 1 unique_id, " + strSQL + " from " + ClassId + " where unique_id = '" + s + "' and recall_type = 3";
            //if (context.xSys.recall_connection.Execute(strSQL))
            //{
            //    IItem ret = context.TheSys.ItemGetByTag(context, new ItemTag(ClassId, s));
            //    context.TheLeader.Tell("Done.");
            //    return ret;
            //}
            //else
            //{
            //    context.TheLeader.Error("The restore was not successful.");
            //    return null;
            //}
        }

    }
}
