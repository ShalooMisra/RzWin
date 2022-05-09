using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class ItemLogic : Logic
    {
        public Act DeleteAct;
        public Act GrabAct;
        protected bool AllowOpen = false;

        public ItemLogic()
        {
            ActsInstance.Add(new Act("Open", Open, OpenPossible));
            ActsInstance.Add(new Act("Delete", Delete, DeletePossible, DeleteConfirm));
            //ActsInstance.Add(new Act("Grab", Grab));
        }

        public virtual void Open(Context x, ActArgs args)
        {
            x.Show(args.TheItems);
            args.Result(true);
        }

        public virtual bool OpenPossible(Context x, ActSetup set)
        {
            return set.IsRightClick && AllowOpen;
        }

        public virtual bool DeleteConfirm(Context x, ActArgs args)
        {
            //return x.TheLeader.AreYouSure("delete " + args.TheItems.CountGet(x) + args.TheItems.Caption);
            return x.TheLeader.AreYouSure("delete " + args.TheItems.CountGet(x) + " items");
        }

        public virtual void Delete(Context x, ActArgs args)
        {
            //if (DeleteConfirm(x, args))
            //{
                foreach (IItem i in args.TheItems.AllGet(x))
                {

                    x.TheDelta.Delete(x, i);

                }
                args.Result(true);
            //}
            
        }

        public virtual bool DeletePossible(Context x, ActSetup set)
        {
            foreach (IItem i in set.TheItems.AllGet(x))
            {
                if (!i.DeletePossible(x))
                    return false;
            }
            return true;
        }

        //public void Grab(Context x, ActArgs args)
        //{
        //    x.TheLeader.GrabBag = new ItemsInstance(x, args.TheItems);
        //    args.Result(true);
        //}
    }
}
