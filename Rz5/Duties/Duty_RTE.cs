using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using NewMethod;
//using CoreWin;

namespace Rz5
{
    public class Duty_RTE : nDuty
    {
        public Duty_RTE()
            : base("RTE", "RTE")
        {


        }

        protected override void Run(ContextNM q)
        {
            base.Run(q);

            System.Threading.Thread.Sleep(1000 * 60 * 11);  //11 minutes, so its over the 5 minute threshold

            int x = 0;
            int y = 1;
            int z = y / x;
        }
    }
}
