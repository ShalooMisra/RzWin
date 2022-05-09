using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Core;
//using CoreWin;
using NewMethod;
using Tools.Database;

namespace Rz5.Duties
{
    public class DropTempTables : nDuty
    {
        public DropTempTables()
            : base("DropTempTables", "DropTempTables")
        {

        }

        protected override void Run(ContextNM context)
        {
            ContextRz xrz = (ContextRz)context;

            base.Run(context);

            bool ret = true;

            DataTable allTables = ((DataConnectionSqlServer)context.TheData.TheConnection).GetTableTable();
            int droppedCount = 0;
            foreach (DataRow r in allTables.Rows)
            {
                String tableName = Tools.Data.NullFilterString(r["name"]);
                if (Tools.Strings.StartsWith(tableName, "temp_"))
                {
                    context.TheLeader.CommentEllipse("Dropping " + tableName);
                    try  
                    {
                        context.TheData.TheConnection.DropTable(tableName);
                        droppedCount++;
                    }
                    catch
                    {
                        context.TheLeader.Error("Failed to drop " + tableName);
                        ret = false;
                    }
                }
            }

            context.TheLeader.Comment("Dropped " + Tools.Strings.PluralizePhrase("table", droppedCount));

            if( ret )
                xrz.Logic.MarkConcern(xrz, "Database_RemoveTempTables");
        }
    }
}
