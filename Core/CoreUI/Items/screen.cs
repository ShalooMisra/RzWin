using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;

using Core;

namespace CoreUI
{
    public class screen : screenBase
    {
        public static CoreVarRefManyAttribute SpotsAllAttribute;
        public static CoreVarValAttribute NameAttribute;

        //tells waiting threads to show or transmit changes
        public ManualResetEvent AsyncCheck = new ManualResetEvent(false);
        public List<String> ControlsToRemove = new List<string>();
        public String CurrentPageId = "";

        //primarily for the web right now, need to be abstracted away from js
        //i know these should be in like 'ScreenWeb'
        //but that doesn't work with single inheritance to create a platform-independent screen
        public List<String> ScriptsToRun = new List<String>();
        public String SessionId = "";

        public void Flow()
        {
            AsyncCheck.Set();
        }

        public void FlowIfChanged()
        {
            if (ChangesToSend)
                Flow();
        }

        public screen(ItemArgs a)
            : base(a)
        {
            BackColor = Color.LightSeaGreen;
            HideOverflow = false;
        }

        public virtual bool ChangesToSend
        {
            get
            {
                return ContainsChanges || ControlsToRemove.Count > 0 || ScriptsToRun.Count > 0;
            }
        }

        public virtual void SpotsAllInit(Context x)
        {
            SpotsInit(x, SpotsAllVar.RefsGet(x));

            foreach (spot s in SpotsAllVar.RefsList(x))
            {
                s.StateObjectInit(x);
            }
        }

        public virtual spot SpotCreate(Context x)
        {
            return new spot(new ItemArgs(x));
        }

        public void SpotDelete(Context context, spot s)
        {
            context.TheDelta.Delete(context, s);
            s.RemoveFromParent(context);
            SpotsAllVar.RefsRemove(context, s);
        }

        public virtual void Positions(Context context, SpotActArgs args)
        {
        }
    }

    public class screenLogic : screenLogicBase
    {
    }
    public class screenLogicBase
    {
    }
}
