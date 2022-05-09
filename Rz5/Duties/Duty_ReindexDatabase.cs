using System;
using System.Collections.Generic;
using System.Text;

using NewMethod;

namespace Rz5
{
    public class Duty_ReindexDatabase : nDuty
    {
        public Duty_ReindexDatabase(): base("Reindex Database", "Reindex Database")
        {

        }
        protected override void Run(ContextNM x)
        {
            base.Run(x);
            //context.Logic.MakeRz3IndexesExist();   //we don't want to make the indexes exist over and over.  that would remove custom ones
            //return q.xSys.xData.Reindex();
            throw new Exception("Reorg");
        }
    }
}

