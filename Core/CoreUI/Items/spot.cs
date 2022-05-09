using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Core;

namespace CoreUI
{
    public class spot : spotBase
    {
        public static CoreVarValAttribute top_absAttribute;
        public static CoreVarValAttribute left_absAttribute;
        public static CoreVarValAttribute width_absAttribute;
        public static CoreVarValAttribute height_absAttribute;
        public static CoreVarValAttribute alternate_class_idAttribute;
        public static CoreVarValAttribute spot_infoAttribute;
        public static CoreVarValEnumAttribute view_typeAttribute;
        public static CoreVarRefSingleAttribute ScreenAttribute;
        public static CoreVarRefSingleAttribute SpotAttribute;
        public static CoreVarRefManyAttribute SpotsAttribute;

        public Object StateObject;
        //public bool RenderClickToSave = false;

        //spot Parent;
        //public List<spot> Spots = new List<spot>();
        public bool Changed = false;
        public bool ContainsChanges = false;
        public bool HideOverflow = true;
        public bool CenterHoriz = false;

        public spot(ItemArgs a)
            : base(a)
        {

        }

        public virtual void SpotsInit(Context x, ItemsInstance allSpots)
        {
            SpotsVar.TheItemsInit(x, allSpots);
            foreach (spot s in SpotsVar.RefsList(x))
            {
                s.SpotsInit(x, allSpots);
            }
        }

        public virtual void StateObjectInit(Context x)
        {
        }

        public virtual void StateObjectAction(Context x, SpotActArgs args)
        {
            switch (args.ActionId)
            {
                case "move":
                    Move(x, args);
                    break;
                case "view":
                    View(x, args);
                    break;
            }
        }

        protected void Move(Context x, SpotActArgs args)
        {
            String left = args.Var(Uid + "_dot_left");
            String top = args.Var(Uid + "_dot_top");
            if (Tools.Number.IsNumeric(left) && Tools.Number.IsNumeric(top))
            {
                Location = new Point(Tools.Number.ToInt(left), Tools.Number.ToInt(top));
                x.TheDelta.Update(x, this);
            }
        }

        protected void View(Context x, SpotActArgs args)
        {
            switch (args.ActionParams.ToLower())
            {
                case "point":
                    view_typeVar.ValueEnumSet(x, SpotViewType.Point);
                    break;
                case "normal":
                default:
                    view_typeVar.ValueEnumSet(x, SpotViewType.Normal);
                    break;
            }

            Change();
        }

        public void ChangedSpots(Context x, List<spot> changed)
        {
            if (Changed)
            {
                changed.Add(this);
            }
            else
            {
                foreach (spot c in SpotsVar.RefsList(x))
                {
                    c.ChangedSpots(x, changed);
                }
            }
        }

        String m_TestValue = "Test Value";
        public String TestValue
        {
            get
            {
                return m_TestValue;
            }

            set
            {
                m_TestValue = value;
                Change();
            }
        }

        public Point Location
        {
            get
            {
                return new Point(Convert.ToInt32(left_abs), Convert.ToInt32(top_abs));
            }

            set
            {
                left_abs = value.X;
                top_abs = value.Y;
                Change();
            }
        }

        public Size Size
        {
            get
            {
                return new Size(Convert.ToInt32(width_abs), Convert.ToInt32(height_abs));
            }

            set
            {
                width_abs = value.Width;
                height_abs = value.Height;
                Change();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(Location, Size);
            }
        }

        Color m_BackColor = Color.White;
        public Color BackColor
        {
            get
            {
                return m_BackColor;
            }

            set
            {
                m_BackColor = value;
                Change();
            }
        }

        public void Change()
        {
            //if (Changed)
            //    return;

            Changed = true;
            if (Parent != null)
                Parent.ChildChanged();
        }

        public void ChildChanged()
        {
            //if (ContainsChanges)  //this seemed like a timesaver but it skipped the parent update
            //    return;

            ContainsChanges = true;
            if (Parent != null)
                Parent.ChildChanged();
        }

        public void ChangeClear(Context x)
        {
            Changed = false;
            ContainsChanges = false;
            foreach (spot c in SpotsVar.RefsList(x))
            {
                c.ChangeClear(x);
            }
        }

        public void RemoveFromParent(Context x)
        {
            if (Parent == null)
                return;

            Parent.SpotsVar.RefsRemove(x, this);
        }

        public spot Parent
        {
            get
            {
                try
                {
                    return SpotVar.RefDirect;
                }
                catch { return null; }
            }
        }

        public virtual String IconKey(Context context)
        {
            return "Item";
        }

        public virtual String Caption(Context context)
        {
            return StateObject.ToString();
        }
    }

    public class spotLogic : spotLogicBase
    {
    }

    public class spotLogicBase
    {
    }

    public class SpotDisplayer
    {
        public SpotHandle Spot;
        public SpotDisplayer(SpotHandle item)
        {
            Spot = item;
        }

        public static event SpotDisplayerNeededHandler SpotDisplayerNeeded;

        public static SpotDisplayer SpotDisplayerFind(SpotHandle s)
        {
            if (SpotDisplayerNeeded == null)
                return null;

            return SpotDisplayerNeeded(s);
        }
    }

    public delegate SpotDisplayer SpotDisplayerNeededHandler(SpotHandle s);

    public class VarRefInstanceManyCollected<TFrom, TTo> : VarRefInstanceMany<TFrom, TTo>
    {
        public IVarRefSingle TheCollection;
        public VarRefInstanceManyCollected(IItem parent, CoreVarAttribute attr, IVarRefSingle collection)
            : base(parent, attr)
        {
            TheCollection = collection;
        }

        public override bool RefsAdd(Context x, IItems items)
        {
            if (!base.RefsAdd(x, items))
                return false;

            IVarRefMany many = TheCollectionReverse(x);
            if (many != null)
            {
                many.RefsAdd(x, items);

                //foreach (IItem i in items.AllGet(x))
                //{
                //    //for the item being added, set the instance of the collected parent
                //    IVarRefSingle sing = i.VarGetByName(TheCollection.Reverse
                //}
            }
            return true;
        }

        public override void RefsRemove(Context x, IItems items, bool do_reverse)
        {
            base.RefsRemove(x, items, do_reverse);
            IVarRefMany many = TheCollectionReverse(x);
            if (many != null)
                many.RefsRemove(x, items);
        }

        public IVarRefMany TheCollectionReverse(Context x)
        {
            IItem i = TheCollection.RefItemGet(x);
            if (i == null)
                return null;

            return (IVarRefMany)i.VarGetByName(TheCollection.ReverseName);
        }
    }



    public enum SpotViewType
    {
        Normal = 0,
        Point = 1,
    }
}
