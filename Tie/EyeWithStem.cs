using System;
using System.Collections.Generic;
using System.Text;

namespace Tie
{
    public class EyeWithStem : Eye
    {
        StemHook Stem = null;

        public void SetHook(StemHook s)
        {
            Stem = s;
            Stem.xEye = this;
        }

        public override void StartListening()
        {
            base.StartListening();

            if (Stem != null)
            {
                SetStatus("Starting the stem hook to " + Stem.HostName);
                String s = "";
                if (Stem.ConnectWithPersistence(ref s))
                {
                    SetStatus("Connected to " + Stem.HostName);
                }
                else
                {
                    SetStatus("Stem hook not connected: " + s);
                }
            }
        }

        public override void StopListening(bool notify)
        {
            Stem.Close();
            base.StopListening(notify);
        }
    }
}
