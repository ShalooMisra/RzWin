using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IVarRef : IVar
    {
        void Init(Context x, ItemsInstance items, bool includeReverse);
        Type RefType { get; }
        IVarRef ReverseGet(Context x, IItem target_item);
        ShowArgs ShowArgsCreate(Context x, IItems items);
        void RefsRemoveAll(Context x);
        bool Initialized { get; }
        void UnInitialize();
    }
    public interface IVarRefSingle : IVarRef
    {
        String ReferenceId { get; }
        IItem RefItemGet(Context x);
        String ReverseName { get; }

        void RefItemSet(Context x, IItem value);
        void RefItemSet(Context x, IItem value, bool includeReverse);

        void RefRemove(Context x);
        void RefRemove(Context x, bool includeReverse);
    }
    public interface IVarRefMany : IVarRef
    {
        IItem RefAddNewItem(Context x);
        int RefsCount(Context x);
        IItems RefsGetAsItems(Context x);
        IItem Find(Context x, String uid);

        void RefsAdd(Context x, IItems items);
        void RefsAdd(Context x, IItems items, bool includeReverse);

        void RefsRemove(Context x, IItems items);
        void RefsRemove(Context x, IItems items, bool includeReverse);        
    }

    public abstract class VarRef<TFrom, TTo> : Var, IVarRef
    {
        public bool m_Initialized = false;
        public bool Initialized
        {
            get
            {
                return m_Initialized;
            }

            set
            {
                m_Initialized = value;
            }
        }

        public virtual void UnInitialize()
        {
            Initialized = false;
        }

        public CoreVarRefAttribute TheAttributeRef
        {
            get
            {
                return (CoreVarRefAttribute)TheAttribute;
            }
        }

        public VarRef(IItem parent, CoreVarAttribute attr) : base(parent, attr)
        {
        }

        public void Init(Context x)
        {
            Init(x, null, true);
        }

        public abstract void Init(Context x, ItemsInstance items, bool includeReverse);

        public Type RefType
        {
            get
            {
                return typeof(TTo);
            }
        }

        public abstract void RefsRemoveAll(Context x);

        //public virtual void ReverseInit(Context x, IItems items)
        //{
        //}

        //public virtual void RefsClear(Context x)
        //{

        //}

        public IVarRef ReverseGet(Context x, IItem target_item)
        {
            if (target_item == null)
                return null;

            return (IVarRef)target_item.VarGetByName(TheAttributeRef.ReverseName);
        }

        public String ReverseName
        {
            get
            {
                return TheAttributeRef.ReverseName;
            }
        }

        public virtual IItem RefCreate(Context x)
        {
            return x.TheSys.ItemCreate(typeof(TTo).Name);  //, new ItemArgs(x)
        }
        public virtual ShowArgs ShowArgsCreate(Context x, IItems items)
        {
            return null;
        }

        //public ItemsInstance RefsGetCopy(Context x)
        //{
        //    return new ItemsInstance(x, RefsGet(x));
        //}

        //protected virtual bool AddingNewPossible(Context x, AddArgs args)
        //{
        //    return false;
        //}
        //protected virtual bool AddingNew(Context x, AddArgs args)
        //{
        //    return false;
        //}

        //public virtual bool RefsAdd(Context x, IItems items)
        //{
        //    return true;
        //}

        //public override bool RefsAdd(Context x, IItems items)
        //{
        //    if (!base.RefsAdd(x, items))
        //        return false;

        //    if (!RefsGet(x).Add(x, items))
        //        return false;

        //    RefsChanged(x);
        //    return true;
        //}

        protected virtual void RefsChanged(Context x)
        {
            m_Value = this.ToString();
        }

        protected virtual QueryClass QueryCreate(Context context)
        {
            return TheAttributeRef.TheQuery;
        }
    }
    public class VarRefSingle<TFrom, TTo> : VarRef<TFrom, TTo>, IVarRefSingle
    {
        public IItem Item;

        String m_ReferenceId = "";
        public virtual String ReferenceId
        {
            get
            {
                return m_ReferenceId;
            }

            set
            {
                m_ReferenceId = value;
            }
        }

        public VarRefSingle(IItem parent, CoreVarAttribute attr) : base(parent, attr)
        {
        }

        public override void Init(Context x, ItemsInstance items, bool includeReverse)
        {
            if( Initialized || Item != null )
                throw new Exception("Init called on initialized ref");

            if (Parent == null)
                throw new Exception("Missing ref parent");

            //use the passed in item when possible, otherwise use the instances from the database
            if (items != null)
            {
                if (items.Count != 1)
                    throw new Exception("Single item init on multiple");

                if (ReferenceId != "" && items.First.Uid != ReferenceId)  //the case where ReferenceId == "" is specific to NM where the actual data work isn't done by core
                    throw new Exception("Incorrect reference");

                Item = items.First;

                //for nm?
                ReferenceId = Item.Uid;
            }
            else
            {
                //for nm?
                if (ReferenceId == "" && (!(Parent is Item)))
                    ReferenceId = (String)Parent.ValGet(TheAttributeRef.LinkField);

                if (ReferenceId == "")
                {
                    //item remains null, but the init is complete
                    Initialized = true;
                    return;
                }

                ItemsInstance hold =  x.TheData.SelectInstances(x, QueryCreate(x), Parent);

                if (hold.Count == 0)
                {
                    //item remains null, but the init is complete
                    Initialized = true;
                    return;
                }

                if (hold.Count > 1)
                    throw new Exception("Single reference returned multiple results");

                Item = hold.First;
            }

            Initialized = true;

            if(includeReverse)
            {
                //set the reverse reverences on the single refs back to the parent item
                if (Tools.Strings.StrExt(this.TheAttributeRef.ReverseName))
                {
                    //reverse
                    Var v = Item.VarGetByName(this.TheAttributeRef.ReverseName);
                    IVarRefMany rev = (IVarRefMany)v;

                    if (rev == null)
                    {
                        //should this be an error?
                        x.TheLeader.Error("Missing reverse reference: " + this.TheAttributeRef.ReverseName);
                    }
                    else
                        rev.Init(x, new ItemsInstance(x, this.Parent), false);
                }
            }
        }

        public override void UnInitialize()
        {
            base.UnInitialize();
            Item = null;
        }

        public override void RefsRemoveAll(Context x)
        {
            RefSet(x, default(TTo));
        }

        public override string ToString()
        {
            if (Item == null)
                return "";

            return Item.ToString();
        }

        public TTo RefGet(Context x)
        {
            if (!Initialized)
                Init(x);

            if (Item == null)
                return default(TTo);

            return (TTo)Item;
        }

        public TTo RefDirect
        {
            get
            {
                return (TTo)Item;
            }
        }

        public IItem RefItemGet(Context x)
        {
            Object o = RefGet(x);
            return (IItem)o;
        }
        
        public void RefItemSet(Context x, IItem value)
        {
            RefItemSet(x, value, true);
        }

        public void RefItemSet(Context x, IItem value, bool includeReverse)
        {
            RefSet(x, (TTo)((Object)value), includeReverse);
        }

        public void RefSet(Context x, TTo value)
        {
            RefSet(x, value, true);
        }

        public virtual void RefSet(Context x, TTo value, bool includeReverse)
        {
            //cache the reference so it can be formally removed if the new reference is null or different
            if (!Initialized)
            {
                if (value != null)
                {
                    //for nm?
                    if (ReferenceId == "" && (!(Parent is Item)))  //for actual items, there's no link field property
                        ReferenceId = (String)Parent.ValGet(TheAttributeRef.LinkField);

                    if (ReferenceId == ((IItem)value).Uid)
                    {
                        //this is for when the item being passed in is already the item, by id, that's called for by the reference id
                        //this probably won't be an issue in core but in NM it happens a lot where the id property gets set,
                        //then the item gets saved, then the ref setting happens
                        ItemsInstance inst = new ItemsInstance();
                        inst.Add(x, (IItem)value);
                        Init(x, inst, includeReverse);
                    }
                    else
                        Init(x);
                }
                else
                    Init(x);
            }

            //if the value is being cleared by setting it to null
            if (value == null)
            {
                RefRemove(x, true);
                return;
            }

            if( Item != null)
            {
                //same instance
                if( Object.ReferenceEquals(Item, value))
                    return;

                //different instance, same object id
                //2012_04_15 it traditionally just returned, but maybe it should grab the different instance instead?
                //because now the related item won't have the instance that the calling code expects
                
                //going to take this out for now, allowing the reference to be removed and re-added to the instances involved
                //this should not happen now with the above id checking
                //if (Item.Uid == ((IItem)value).Uid)  //    return;
                //    x.TheLeader.Tell("Same id, different instance");

                RefRemove(x, true);
            }

            Object v = value;
            Item = (IItem)v;
            ReferenceId = Item.Uid;
            Changed = true;

            //for nm?
            //2013_01_24 added try, was failing in skylattice
            try
            {
                Parent.ValSet(TheAttributeRef.LinkField, Item.Uid);
            }
            catch { }
            
            x.TheDelta.Update(x, Parent);

            if (includeReverse)
            {
                //needs to add to the reverse
                IVarRefMany reverse_new = (IVarRefMany)ReverseGet(x, Item);
                if (reverse_new != null)
                {
                    reverse_new.RefsAdd(x, this.Parent, false);
                }
            }

            RefsChanged(x);
        }
        //protected override void RefsChanged(Context x)
        //{
        //    base.RefsChanged(x);
        //    Object o = RefGet(x);
        //    if (o == null)
        //    {
        //        m_Value = null;
        //        ReferenceId = "";
        //    }
        //    else
        //    {
        //        IItem ix = (IItem)o;
        //        m_Value = ix.ToString();
        //        ReferenceId = ix.Uid;
        //    }
        //    //ValuesChangedSet(x, true);
        //}
        
        protected override void FieldValuesAppend(Context x, List<Tools.Database.FieldValue> values, bool changed_only)
        {
            values.Add(new Tools.Database.FieldValue(TheAttributeRef.LinkField, Tools.Database.FieldType.String, 256, ReferenceId)); //ReferenceId
        }

        public override void Absorb(Context x, System.Data.DataRow r)
        {
            base.Absorb(x, r);
            ReferenceId = Tools.Data.NullFilterString(r[TheAttributeRef.LinkField]);
        }

        public void RefRemove(Context x)
        {
            RefRemove(x, true);
        }

        public void RefRemove(Context x, bool includeReverse)
        {
            if (includeReverse)
            {
                IItem i = (IItem)RefGet(x);  //this does the init
                if (i != null)
                {
                    IVarRefMany reverse = (IVarRefMany)ReverseGet(x, i);
                    if (reverse != null)
                        reverse.RefsRemove(x, Parent, false);
                }
            }

            ReferenceId = "";
            Changed = true;

            //for nm?
            //2013_03_21 added try, was failing in skylattice
            try { Parent.ValSet(TheAttributeRef.LinkField, ""); }
            catch { }
            
            x.TheDelta.Update(x, Parent);
            Item = null;
        }
    }
    public class VarRefMany<TFrom, TTo> : VarRef<TFrom, TTo>, IVarRefMany
    {
        public bool NoCache = false;  //for relates like company->excess or user->phonecall that are too bulky to be cached
        public ItemsInstance m_TheItems = null;

        public VarRefMany(IItem parent, CoreVarAttribute attr) : base(parent, attr)
        {

        }

        public override void Init(Context x, ItemsInstance items, bool includeReverse)
        {
            if( Initialized || m_TheItems != null )
                throw new Exception("Init called on initialized ref");

            if (Parent == null)
                throw new Exception("Missing ref parent");

            ItemsInstance hold = x.TheData.SelectInstances(x, QueryCreate(x), Parent);
            m_TheItems = new ItemsInstance();

            //use the passed in items when possible, otherwise use the instances from the database
            foreach (IItem i in hold.All)
            {
                if (items == null)
                    m_TheItems.AddSingle(i);
                else
                {
                    IItem h = items.ByIdGet(x, i.Uid);
                    if (h == null)
                        m_TheItems.AddSingle(i);
                    else
                        m_TheItems.AddSingle(h);
                }
            }
           
                if (includeReverse)
                    SetReverseReferences(x);
        
            Initialized = true;
        }

        public override void UnInitialize()
        {
            base.UnInitialize();
            m_TheItems = null;
        }

        void SetReverseReferences(Context x)
        {
            //set the reverse reverences on the single refs back to the parent item
            if (Tools.Strings.StrExt(this.TheAttributeRef.ReverseName))
            {
                foreach (IItem i in m_TheItems.All)
                {
                    //reverse
                    Var v = i.VarGetByName(this.TheAttributeRef.ReverseName);
                    IVarRefSingle rev = (IVarRefSingle)v;

                    if (rev == null)
                    {
                        //should this be an error?
                        x.TheLeader.Error("Missing reverse reference: " + this.TheAttributeRef.ReverseName);
                    }
                    else
                        rev.Init(x, new ItemsInstance(x, this.Parent), false);
                }
            }
        }

        public ItemsInstance RefsGet(Context x)
        {
            if (!Initialized)
                Init(x);

            return m_TheItems;
        }

        public int RefsCount(Context x)
        {
            return RefsGet(x).Count;
        }

        public override string ToString()
        {
            return Tools.Strings.PluralizeName(typeof(TTo).Name);

            //this was an interesting way to do it, building up the names for the first few
            //if (m_TheItems == null)
            //    return base.ToString();  //this will return the string value, which is the summary

            //if (m_TheItems.Count == 0 || m_TheItems.Count > 3)
            //{
            //    if (!Tools.Strings.StrExt(TheAttributeRef.TheTypeName))
            //        return m_TheItems.Count.ToString();
            //    else
            //        return Tools.Strings.PluralizePhrase(TheAttributeRef.TheTypeNameShort, m_TheItems.Count);
            //}
            //else
            //{
            //    StringBuilder sb = new StringBuilder();
            //    int c = 0;
            //    foreach (IItem i in m_TheItems.All)
            //    {
            //        if (c > 0)
            //            sb.Append(", ");
            //        sb.Append(i.ToString());
            //        c++;
            //    }
            //    return sb.ToString();
            //}
        }

        public IItem Find(Context x, String uid)
        {
            return m_TheItems.ByIdGet(x, uid);
        }

        public void RefsAdd(Context x, IItems items)
        {
            RefsAdd(x, items, true);
        }

        public virtual void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            if (!Initialized)
            {
                //in case the database already has the id structure for the item being added
                //the item being added has to be available to init, because it might get picked up from the database
                ItemsInstance inst = new ItemsInstance();
                inst.Add(x, items);

                Init(x, inst, false);  //don't include reverse; that's handled below
            }
            List<IItem> itemList = items.AllGet(x);
            foreach (IItem i in itemList)
            {
                if( !m_TheItems.ContainsId(x, i.Uid) )
                    m_TheItems.Add(x, i);
            }

            if (includeReverse)
            {
                foreach (IItem i in itemList)
                {
                    //2012_04_15 don't need to do this in multi; the saving should be on the single side, called below in RefItemSet
                    //i.ValSet(LinkField, Parent.Uid);
                    //x.TheDelta.Update(x, i);

                    if (Tools.Strings.StrExt(TheAttributeRef.ReverseName))
                    {
                        IVarRefSingle single = (IVarRefSingle)ReverseGet(x, i);
                        if (single == null)
                            throw new Exception("Missing reverse reference");

                        single.RefItemSet(x, this.Parent, false);
                    }
                }
            }

            RefsChanged(x);
        }

        // 2012_04_15 is this even used?
        //protected override bool AddingNewPossible(Context x, AddArgs args)
        //{
        //    return true;
        //}
        //protected override bool AddingNew(Context x, AddArgs args)
        //{
        //    Item ret = (Item)x.TheSys.ItemCreate(typeof(TTo).Name, new ItemArgs(x));

        //    x.TheDelta.Insert(x, ret);

        //    RefsAdd(x, ret);

        //    if (args.Added == null)
        //        args.Added = new List<IItem>();
        //    args.Added.Add(ret);

        //    x.TheDelta.Update(x, this.Parent);
        //    x.TheDelta.Update(x, ret);
        //    return true;
        //}

        public IItem RefAddNewItem(Context x)
        {
            return (IItem)RefAddNew(x);
        }

        public virtual TTo RefAddNew(Context x)
        {
            if (!Initialized)
                Init(x);

            //it would be nice to optimize this so that there's only 1 call to the database
            //this way there's the insert, then the update after the relationship is set
            //how could this ref's parent item be passed to the new item to initialize the reference all at once?

            IItem i = RefCreate(x);
            x.TheDelta.Insert(x, i);
            RefsAdd(x, i);
            return (TTo)i;
        }

        public override void RefsRemoveAll(Context x)
        {
            ItemsInstance itemsToRemove = new ItemsInstance(x, RefsGet(x));  //copy the items to a separate list first
            RefsRemove(x, itemsToRemove);
        }

        public void RefsRemove(Context x, IItems items)
        {
            RefsRemove(x, items, true);
        }

        public virtual void RefsRemove(Context x, IItems items, bool includeReverse)
        {
            if (!Initialized)
            {
                //init with the passed in items so that the references will be set as tightly as possible before the remove
                ItemsInstance inst = new ItemsInstance(x, items);
                Init(x, inst, true);
            }

            m_TheItems.Remove(x, items);

            //added 2012_04_22
            x.TheDelta.Update(x, Parent);

            RefsChanged(x);

            if (includeReverse)
            {
                //reverse
                if (Tools.Strings.StrExt(this.TheAttributeRef.ReverseName))
                {
                    foreach (IItem i in items.AllGet(x))
                    {
                        //reverse
                        Var v = i.VarGetByName(this.TheAttributeRef.ReverseName);
                        IVarRefSingle rev = (IVarRefSingle)v;

                        if (rev == null)
                        {
                            //should this be an error?
                            x.TheLeader.Error("Missing reverse reference: " + this.TheAttributeRef.ReverseName);
                        }
                        else
                            rev.RefRemove(x, false);
                    }
                }
            }
        }



        public IItem ByIdGet(Context x, String uid)  //changed from TTo due to a new inexplicable compile error
        {
            foreach (IItem i in RefsList(x))
            {
                if (i.Uid == uid)
                    return (IItem)i;
            }
            return null;  //never used this before, suggested by the error message of returning null
        }
        public List<TTo> RefsList(Context context)
        {
            List<TTo> ret = new List<TTo>();

            foreach (IItem i in RefsGet(context).All)
            {
                ret.Add((TTo)i);
            }

            return ret;
        }
        public bool RefMoveAfter(IItem move, IItem after)
        {
            bool ret = m_TheItems.MoveAfter(move, after);
            if (ret)
                m_Reordered = true;
            return ret;
        }
        bool m_Reordered;
        public bool Reordered
        {
            get
            {
                return m_Reordered;
            }
        }
        public void UpdateAll(Context x)
        {
            foreach (IItem i in RefsList(x))
            {
                x.TheDelta.Update(x, i);
            }
        }
        //public override void RefsClear(Context x)
        //{
        //    //2011_11_09 this should really go to each one and explicitly clear it, right?
        //    if (m_TheItems != null)
        //        m_TheItems.Clear(x);
        //}

        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass c = new QueryClass(typeof(TTo).Name);
            c.Where = new ExpressionBinaryOperator(new ExpressionIdentifier(TheAttributeRef.LinkField), BinaryOperatorType.Equality, new ExpressionLiteralString(Parent.Uid));
            return c;
        }

        public int CountGet(Context x)
        {
            if (!Initialized)
                Init(x);

            return m_TheItems.Count;
        }

        public IItems RefsGetAsItems(Context x)
        {
            if (!Initialized)
                Init(x);

            return m_TheItems;
        }
    }
    public class VarRefManyLinecode<TFrom, TTo> : VarRefMany<TFrom, TTo>
    {
        String LinecodeField = "";
        public VarRefManyLinecode(IItem parent, CoreVarAttribute attr, String linecode_field) : base(parent, attr)
        {
            LinecodeField = linecode_field;
        }
        protected override QueryClass QueryCreate(Context context)
        {
            QueryClass c = base.QueryCreate(context);
            c.OrderBy.Add(new QueryOrder(new QueryField(LinecodeField)));
            return c;
        }

        public int MaxLinecodeGet(Context x)
        {
            int ret = 0;
            foreach (IItem i in RefsList(x))
            {
                Int32 l = Convert.ToInt32(i.ValGet(LinecodeField));
                if( l > ret )
                    ret = l;
            }
            return ret;
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            //this should get the max linecode, not the count.
            //what if there were 2 added, then the first one was deleted, then another added?  then both would have linecode 2
            //int lc = CountGet(x);  

            int lc = MaxLinecodeGet(x);  
            
            lc++;
            foreach(IItem i in items.AllGet(x))
            {
                i.ValSet(LinecodeField, lc);
                x.TheDelta.Update(x, i);
                lc++;
            }
            base.RefsAdd(x, items, includeReverse); //calls update on each
        }

        public override void RefsRemove(Context x, IItems items, bool do_reverse)
        {
            int lc = 1;
            foreach (IItem i in RefsList(x))  //smooth the ones left
            {
                i.ValSet(LinecodeField, lc);
                x.TheDelta.Update(x, i);
                lc++;
            }
            base.RefsRemove(x, items, do_reverse);
        }
    }
}
