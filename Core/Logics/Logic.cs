using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class Logic
    {
        public List<Act> Acts;
        public List<Act> ActsInstance;

        public Logic()
        {
            Acts = new List<Act>();
            ActsInstance = new List<Act>();
        }

        //public void ActsList(Context x, ActSetup set)
        //{
        //    if (set.ItemsHas(x))
        //    {
        //        ActsListInstance(x, set);
        //    }
        //    else
        //    {
        //        ActsListStatic(x, set);
        //    }
        //}

        public virtual void ActsListStatic(Context x, ActSetup set)
        {
            foreach (Act a in Acts)
            {
                if (a.PossibleHandler != null)
                {
                    if (!a.PossibleHandler(x, set))
                        continue;
                }

                set.Add(new ActHandle(a));
            }
        }

        public virtual void ActsListInstance(Context x, ActSetup set)
        {
            foreach (Act a in ActsInstance)
            {
                if (a.PossibleHandler != null)
                {
                    if (!a.PossibleHandler(x, set))
                        continue;
                }

                set.Add(new ActHandle(a));
            }
        }

        public virtual void ActStatic(Context x, ActArgs args)
        {

        }

        public virtual void ActInstance(Context x, ActArgs args)
        {
            if (args.TheAct != null && args.TheAct.Handler != null)
            {
                if (args.TheAct.ConfirmHandler != null)
                {
                    if (!args.TheAct.ConfirmHandler(x, args))
                    {
                        args.Handled = true;  //user cancel
                        args.Canceled = true;
                        return;
                    }
                }
             
                args.TheAct.Handler(x, args);
                args.Handled = true;  //assume handled for live delegate acts
            }
        }
    }

    public class LogicCore : Logic
    {
        public virtual void Init(Context x)
        {
        }
    }
}
