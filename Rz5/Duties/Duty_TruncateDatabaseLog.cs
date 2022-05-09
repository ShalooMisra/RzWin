using System;
using System.Collections.Generic;
using System.Text;
using NewMethod;
//using CoreWin;
using Tools.Database;

namespace Rz5
{
    public class Duty_TruncateDatabaseLog : nDuty
    {
        public Duty_TruncateDatabaseLog()
            : base("Truncate Database Log", "Truncate Database Log")
        {

        }

        protected override void Run(ContextNM context)
        {
            ContextRz xrz = (ContextRz)context;

            base.Run(context);
            ((DataConnectionSqlServer)context.TheData.TheConnection).TruncateLog();

            if (context.xSys.Recall && context.xSys.RecallConnection.ConnectPossible())
                    ((DataConnectionSqlServer)context.xSys.RecallConnection).TruncateLog();

            //if (!Tools.Strings.StrCmp(context.TheData.ServerName, xrz.Logic.AvailabilityConnection.ServerName))
            //{
            //    if (xrz.Logic.AvailabilityConnection.ConnectPossible())
            //        xrz.Logic.AvailabilityConnection.TruncateLog();
            //}
        }
    }
}
