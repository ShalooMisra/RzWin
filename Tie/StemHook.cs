using System;
using System.Collections.Generic;
using System.Text;

namespace Tie
{
    public class StemHook : Hook
    {
        public EyeWithStem xEye;

        public override void ProcessMessage(TieMessage m)
        {
            SetStatus("Got stem message: " + m.ToSession);
            //xEye.Proce
        }

        public override void GotMessage(TieMessage m)
        {
            SetStatus("Got stem message: " + m.ToSession);
            return;
        }
    }
}
