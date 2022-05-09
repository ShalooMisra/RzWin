//using System;
//using System.Collections.Generic;
//using System.Collections;
//using System.Text;
//using System.Data;
//using System.Windows.Forms;
//using System.Xml;

//namespace NewMethod
//{
//    public partial class n_class // : n_class_auto   //, IFrameworkClass
//    {
//        public static List<n_class> ClassClipboard;

//        public nArrayWithOrder Props = new nArrayWithOrder("property_order");
//        public nArray Meths = new nArray();

//        public nArray ParentRelates = new nArray();
//        public nArray ChildRelates = new nArray();
//        public nArray Actions = new nArray();
//        public nArray BaseClassRelates = new nArray();
//        public nArray DerivedClassRelates = new nArray();

//        public nRefresh xRefresh = new nRefresh();

//        //public void AddRelate(n_relate r)
//        //{
//        //    if (r.left_n_class_uid == this.unique_id)
//        //        ChildRelates.Add(r);
//        //    else
//        //        ParentRelates.Add(r);
//        //}

//        //public void AddInherit(n_relate r)
//        //{
//        //    if (r.left_n_class_uid == this.unique_id)
//        //        DerivedClassRelates.Add(r);
//        //    else
//        //        BaseClassRelates.Add(r);
//        //}

//        //public void RemoveRelate(n_relate r)
//        //{
//        //    if (r.RelateType == NewMethod.Enums.RelationshipType.ParentChild)
//        //    {
//        //        if (r.left_n_class_uid == this.unique_id)
//        //            ChildRelates.Remove(r);
//        //        else
//        //            ParentRelates.Remove(r);
//        //    }
//        //    else if (r.RelateType == NewMethod.Enums.RelationshipType.Inherit)
//        //    {
//        //        if (r.left_n_class_uid == this.unique_id)
//        //            DerivedClassRelates.Remove(r);
//        //        else
//        //            BaseClassRelates.Remove(r);
//        //    }
//        //    xRefresh.Refresh();
//        //}

//        public bool InitFromDatabase(nData data)
//        {
//            if( !InitPropsFromDatabase(data) )
//                return false;

//            if (!InitActionsFromDatabase(data))
//                return false;

//            //if (!InitRelatesFromDatabase(data)) //this is done all at once now, after init
//            //    return false;

//            return true;
//        }


//        public bool InitPropsFromDatabase(nData data)
//        {
//            Props.Clear();
//            ArrayList a = xSys.QtC("n_prop", FullPropSQL, data);
//            foreach (n_prop p in a)
//            {
//                AbsorbProperty(p);
//            }
//            return true;
//        }

//        public String FullPropSQL
//        {
//            get
//            {
//                return "select * from n_prop where the_n_class_uid = '" + unique_id + "' order by property_order";
//            }
//        }

//        public bool InitActionsFromDatabase(nData data)
//        {
//            Actions.Clear();
//            Actions.Add(xSys.QtC("n_action", FullActionSQL, data));
//            return true;
//        }

//        public String FullActionSQL
//        {
//            get
//            {
//                return "select * from n_action where the_n_class_uid = '" + unique_id + "' order by the_n_class_order";
//            }
//        }

//        public bool AppendRelatesFromDatabase(nData data, ArrayList a)
//        {
//            ArrayList t = xSys.QtC("n_relate", ParentRelateSQL, data);
//            foreach (n_relate r in t)
//            {
//                a.Add(r);
//            }
//            return true;
//        }

//        public String ParentRelateSQL
//        {
//            get
//            {
//                return "select * from n_relate where right_n_class_uid = '" + unique_id + "' order by name";
//            }
//        }

//        public override int GetGridColor()
//        {
//            if (needs_update)
//                return System.Drawing.Color.Red.ToArgb();
//            else
//                return base.GetGridColor();
//        }

//        public void ClearStructure()
//        {
//            //need to un-link all relationships first

//            Props = new nArrayWithOrder("property_order");
//            ParentRelates = new nArray();
//            ChildRelates = new nArray();
//            Actions = new nArray();
//        }

//        public override String FormalName
//        {
//            get
//            {
//                return class_name;
//            }
//        }

//        // the line /////////--------------------------------------------------------------------------

//        //Constructor
//        public n_class(n_sys xs)
//            : base(xs)
//        {

//        }


//        public override bool ISet_String(String strProp, String strValue)
//        {
//            try
//            {
//                switch (strProp.ToLower().Trim())
//                {
//                    case "date_created":
//                        date_created = DateTime.Parse(strValue);
//                        break;
//                    case "date_modified":
//                        date_modified = DateTime.Parse(strValue);
//                        break;
//                    case "grid_color":
//                        grid_color = Int32.Parse(strValue);
//                        break;
//                    case "icon_index":
//                        icon_index = Int32.Parse(strValue);
//                        break;
//                    case "is_expanded":
//                        is_expanded = Boolean.Parse(strValue);
//                        break;
//                    case "is_soft":
//                        is_soft = Boolean.Parse(strValue);
//                        break;
//                    case "needs_update":
//                        needs_update = Boolean.Parse(strValue);
//                        break;
//                    default:
//                        ISet(strProp, strValue);
//                        break;
//                }

//                return true;
//            }
//            catch (Exception)
//            {
//                return false;
//            }
//        }
//        public override string GetFriendlyName()
//        {
//            if (Tools.Strings.StrExt(class_tag))
//                return class_tag;
//            else
//                return "Class: " + this.class_name;
//        }
//        //Public Functions

//        //handled by structure
//        //public void InitFromDatabase(TreeNode xNode)
//        //{
//        //    try
//        //    {
//        //        GeneralInit(xNode);
//        //        InitPropsFromDatabase();
//        //        InitActionsFromDatabase();
//        //        UpdateNode();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        context.TheLeader.Comment("Error in InitFromDatabase on " + class_name + ": " + ex.Message);
//        //    }
//        //}
//        //public void InitFromArray(TreeNode xNode, ArrayList AllSystemProps, ArrayList AllSystemActions)
//        //{
//        //    try
//        //    {
//        //        GeneralInit(xNode);
//        //        InitPropsFromSystemArray(AllSystemProps);
//        //        InitActionsFromSystemArray(AllSystemActions);
//        //        UpdateNode();
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        context.TheLeader.Comment("Error in InitFromDatabase on " + class_name + ": " + ex.Message);
//        //    }
//        //}

 
//        //public void AbsorbMeth(n_meth m)
//        //{
//        //    m.GatherPars();
//        //    Meths.Add(m);
//        //}
//        //public n_meth AddNewMeth(String strName, String strType)
//        //{
//        //    //n_meth m = this.AddNew_the_n_meth();
//        //    //m.name = strName;
//        //    //m.data_type = strType;
//        //    //m.ISave();
//        //    //this.AbsorbMeth(m);

//        //    //return m;
//        //    return null;
//        //}

//        //needed
//        //public void InitRelates()
//        //{
//        //    BlankRelateHolders();

//        //    if (class_name == "pedestal")
//        //    {
//        //        ;
//        //    }

//        //    if (MyNodeRelate != null)
//        //    {
//        //        MyNodeRelate_Parent = MyNodeRelate.Nodes.Add("Parent");
//        //        MyNodeRelate_Child = MyNodeRelate.Nodes.Add("Child");
//        //    }

//        //    InitRelatesFromSystem(xSys, new ArrayList());
//        //}
//        //public void InitRelatesFromSystem(n_sys s, ArrayList UpdatedRelates)
//        //{
//        //    InitRelatesFromSystem(s, true, UpdatedRelates);
//        //    InitRelatesFromSystem(s, false, UpdatedRelates);
//        //}
//        //public void InitRelatesFromSystem(n_sys s, Boolean right, ArrayList UpdatedRelates)
//        //{
//        //    //n_relate r;
//        //    //foreach (DictionaryEntry d in s.AllRelates)
//        //    //{
//        //    //    r = (n_relate)d.Value;

//        //    //    if (r.unique_id == "78814a8de1fa40d19018bdff135f1cce")
//        //    //    {
//        //    //        ;
//        //    //    }

//        //    //    if (right && Tools.Strings.StrCmp(r.right_n_class_uid, this.unique_id))
//        //    //    {
//        //    //        UpdatedRelates.Add(r);
//        //    //        this.AbsorbRelate(r, false);
//        //    //    }
//        //    //    else if ((!right) && Tools.Strings.StrCmp(r.left_n_class_uid, this.unique_id))  //could this have been wrong all along???
//        //    //    {
//        //    //        UpdatedRelates.Add(r);
//        //    //        this.AbsorbRelate(r, true);
//        //    //    }
//        //    //}
//        //}
//        //public void UnInitRelatesFromSystem(n_sys s)
//        //{
//        //    UnInitRelatesFromSystem(s, true);
//        //    UnInitRelatesFromSystem(s, false);
//        //}
//        //public void UnInitRelatesFromSystem(n_sys s, Boolean right)
//        //{
//        //    n_relate r;
//        //    foreach (DictionaryEntry d in s.AllRelates)
//        //    {
//        //        r = (n_relate)d.Value;

//        //        if (right && Tools.Strings.StrCmp(r.right_n_class_uid, this.unique_id))
//        //        {
//        //            this.UnAbsorbRelate(r, false);
//        //        }
//        //        else if ((!right) && Tools.Strings.StrCmp(r.left_n_class_uid, this.unique_id))
//        //        {
//        //            this.UnAbsorbRelate(r, true);
//        //        }
//        //    }
//        //}


//        //public void AbsorbRelate(n_relate r)
//        //{
//        //    if (r.left_n_class_uid == unique_id)
//        //    {
//        //        r.LeftClass = this;
//        //    }
//        //    else
//        //    {
//        //        r.RightClass = this;
//        //    }
//        //    if (r.RelateType == NewMethod.Enums.RelationshipType.Inherit)
//        //        AddInherit(r);
//        //    else
//        //        AddRelate(r);
//        //}
//        //public void UnAbsorbRelate(n_relate r, bool as_parent)
//        //{
//        //    //if (as_parent)
//        //    //{
//        //    //    this.ChildRelates.Remove(r.unique_id);
//        //    //    r.LeftClass = null;
//        //    //    MyNodeRelate_Child.Nodes.Remove(r.MyNodeAsParent);
//        //    //}
//        //    //else
//        //    //{
//        //    //    this.ParentRelates.Remove(r.unique_id);
//        //    //    r.RightClass = null;
//        //    //    MyNodeRelate_Parent.Nodes.Remove(r.MyNodeAsChild); //false
//        //    //}
//        //}
//        //public void UpdateNode()
//        //{
//        //    if (MyNode == null)
//        //        return;

//        //    if (this.needs_update)
//        //        MyNode.ForeColor = System.Drawing.Color.Red;
//        //    else
//        //        MyNode.ForeColor = System.Drawing.Color.Blue;

//        //}
//        public void AbsorbNewProperty(n_prop p, bool AddToBottom)
//        {
//            MessageBox.Show("sysreorg");

//            //xSys.SetStructureChanged();

//            ////make sure it is in the right system
//            //p.xSys = xSys;
//            //p.the_n_class_uid = this.unique_id;

//            //n_prop pt = this.GetPropByOrder(p.property_order);
//            //if (pt != null)
//            //{
//            //    p.property_order = this.GetNextPropOrder(AddToBottom);
//            //}

//            //if (!p.ISave_ToAlternateData(xSys.xStructure.StructureData))
//            //{
//            //    System.Windows.Forms.MessageBox.Show("Failed prop save.");
//            //    return;
//            //}

//            //this.AbsorbProperty(p);
//            //this.SetSoft();

//            //p.SetSoft();

//            //MakeFieldExist(p);
//        }

//        //public void MakeAllFieldsExist()
//        //{
//        //    n_prop p;
//        //    foreach (DictionaryEntry d in this.CoalesceProps())
//        //    {
//        //        p = (n_prop)d.Value;
//        //        MakeFieldExist(p);
//        //    }
//        //}

//        //public void MakeFieldExist(n_prop p)
//        //{
//        //    //this will make sure the field exists in all sub-systems
//        //    //foreach (nData d in xSys.InstanceDataConnections)
//        //    //{
//        //        p.MakeFieldExist(xSys.xData, this);  //d
//        //    //}

//        //    //this makes sure that all of the derived classes in this and sub systems have the field
//        //    foreach (n_class c in GetDerivedClasses())
//        //    {
//        //        c.MakeFieldExist(p);
//        //    }
//        //}
//        //public void ClearNeedsUpdate()
//        //{
//        //    this.needs_update = false;
//        //    this.is_soft = false;
//        //    this.ISave();
//        //    xRefresh.Refresh();

//        //    n_prop p;
//        //    foreach (DictionaryEntry d in Props.AllByName)
//        //    {
//        //        p = (n_prop)d.Value;
//        //        p.SetHard();
//        //    }
//        //}
//        //public void AbsorbProperty(n_prop p)
//        //{
//        //    n_prop q;
//        //    p.xClass = this;
//        //    Props.Add(p);
//        //}
//        //public void InferOrderedProps()
//        //{

//        //    Props.AllInOrder = new SortedList();
//        //    n_prop p;

//        //    foreach (DictionaryEntry d in Props.AllByName)
//        //    {
//        //        p = (n_prop)d.Value;
//        //        Props.AllInOrder.Add(p.property_order, p);
//        //    }

//        //}
//        //public bool DeleteProperties()
//        //{
//        //    n_prop p;
//        //    foreach (DictionaryEntry d in Props.AllByName)
//        //    {
//        //        p = (n_prop)d.Value;
//        //        p.CompleteDelete();
//        //    }
//        //    SetSoft();
//        //    return true;
//        //}
//        //public bool DeleteRelates()
//        //{
//        //    ArrayList a;

//        //    a = new ArrayList(ChildRelates.All);
//        //    foreach (n_relate r in a)
//        //    {
//        //        r.CompleteDelete();
//        //    }
            
//        //    a = new ArrayList(ParentRelates.All);
//        //    foreach (n_relate r in a)
//        //    {
//        //        r.CompleteDelete();
//        //    }

//        //    a = new ArrayList(BaseClassRelates.All);
//        //    foreach (n_relate r in a)
//        //    {
//        //        r.CompleteDelete();
//        //    }

//        //    a = new ArrayList(DerivedClassRelates.All);
//        //    foreach (n_relate r in a)
//        //    {
//        //        r.CompleteDelete();
//        //    }

//        //    SetSoft();
//        //    return true;
//        //}

//        public int GetNextPropOrder()
//        {
//            return GetNextPropOrder(false);
//        }

//        public int GetNextPropOrder(bool AddToBottom)
//        {
//            n_prop p;
//            int highest = -1;
//            foreach (DictionaryEntry d in Props.AllInOrder)
//            {
//                p = (n_prop)d.Value;

//                if (AddToBottom || p.property_order < 1000)
//                {

//                    if (p.property_order > highest)
//                        highest = p.property_order;
//                }
//            }
//            return highest + 1;
//        }
//        public int GetNextRelatePropOrder()
//        {
//            n_prop p;
//            int lowest = 0;
//            foreach (DictionaryEntry d in Props.AllInOrder)
//            {
//                p = (n_prop)d.Value;

//                if (p.property_order < lowest)
//                    lowest = p.property_order;
//            }
//            return lowest - 1;
//        }
//        public n_prop GetPropByOrder(int ord)
//        {
//            try
//            {
//                return (n_prop)Props.GetByOrder(ord);
//            }
//            catch (Exception e)
//            {
//            }
//            return null;
//        }
//        //public void CreateStandardProps()
//        //{
//        //    CreateUniqueID();
//        //    MakeDefaultProp("date_created", "Date Created", 0, 1000, FieldType.DateTime);
//        //    MakeDefaultProp("date_modified", "Date Modified", 0, 1000, FieldType.DateTime);
//        //    MakeDefaultProp("grid_color", "Grid Color", 0, 1000, FieldType.Int32);
//        //    MakeDefaultProp("icon_index", "Icon Index", 0, 1000, FieldType.Int32);
//        //    SetSoft();
//        //}
//        //public n_prop CreateUniqueID()
//        //{
//        //    return MakeDefaultProp("unique_id", "Unique ID", 255, 0, FieldType.String);
//        //}
//        //public bool HasProp(String strProp)
//        //{
//        //    if (Props.HasName(strProp))
//        //        return true;

//        //    n_prop p = GetPropByName(strProp);
//        //    return (p != null);
//        //}
//        //public n_prop GetPropByName(String strName)
//        //{
//        //    try
//        //    {
//        //        n_prop p = (n_prop)Props.GetByName(strName);
//        //        if (p != null)
//        //            return p;

//        //        //parent/supporting classes
//        //        ArrayList a = GetBaseClasses();
//        //        foreach (n_class c in a)
//        //        {
//        //            p = c.GetPropByName(strName);
//        //            if (p != null)
//        //                return p;
//        //        }
//        //    }
//        //    catch (Exception e)
//        //    {
//        //    }
//        //    return null;
//        //}
//        //public void ReAbsorbProperty(n_prop p)
//        //{
//        //    //remove it
//        //    this.RemoveProp(p, false);

//        //    //reabsorb it
//        //    this.AbsorbProperty(p);

//        //    if (!is_abstract) 
//        //        MakeFieldExist(p);

//        //    p.SetSoft();
//        //}
//        //public void RemoveProp(n_prop p, bool also_delete)
//        //{
//        //    Props.Remove(p);

//        //    if (also_delete)
//        //        p.IDelete();

//        //    SetSoft();
//        //}


      
//        //public void RemoveChildRelate(n_relate r)
//        //{
//        //    this.SetSoft();
//        //    ChildRelates.Remove(r);
//        //}
//        //public void RemoveParentRelate(n_relate r)
//        //{
//        //    this.SetSoft();
//        //    ParentRelates.Remove(r);
//        //}

//        //public n_relate GetRelateByName(string strName, string strRelatedClassID)
//        //{
//        //    foreach (n_relate r in this.ChildRelates.All)
//        //    {
//        //        if (Tools.Strings.StrCmp(r.name, strName) && Tools.Strings.StrCmp(r.right_n_class_uid, strRelatedClassID))
//        //            return r;
//        //    }

//        //    foreach (n_relate r in this.ParentRelates.All)
//        //    {
//        //        if (Tools.Strings.StrCmp(r.name, strName) && Tools.Strings.StrCmp(r.left_n_class_uid, strRelatedClassID))
//        //            return r;
//        //    }

//        //    return null;
//        //}
//        //public n_prop GetPropByID(String strID)
//        //{
//        //    n_prop p = (n_prop)Props.GetByID(strID);
//        //    if (p != null)
//        //        return p;

//        //    ArrayList bases = GetBaseClasses();
//        //    foreach (n_class c in bases)
//        //    {
//        //        p = c.GetPropByID(strID);
//        //        if (p != null)
//        //            return p;
//        //    }

//        //    return null;
//        //}

//        public n_relate GetMainBaseRelate()
//        {
//            if (this.BaseClassRelates == null)
//                return null;

//            if (this.BaseClassRelates.Count == 0)
//                return null;

//            foreach (n_relate r in BaseClassRelates.All)
//            {
//                if (r.relate_type == (Int32)Enums.RelationshipType.Inherit)
//                {
//                    return r;
//                }
//            }
//            return null;
//        }
//        public ArrayList GetOtherBaseRelates()
//        {
//            ArrayList a = new ArrayList();
//            bool f = true;

//            if (BaseClassRelates == null)
//                return a;

//            foreach (n_relate r in BaseClassRelates.All)
//            {
//                if (r.relate_type == (Int32)Enums.RelationshipType.Inherit)
//                {
//                    if (!f)
//                    {
//                        a.Add(r);
//                    }
//                    f = false;
//                }
//            }
//            return a;
//        }
//        //public ArrayList GetBaseClasses()
//        //{
//        //    if (BaseClassRelates == null)
//        //        return new ArrayList();

//        //    ArrayList a = new ArrayList();
//        //    foreach (n_relate r in BaseClassRelates.All)
//        //    {
//        //        if (r.LeftClass != null)
//        //            a.Add(r.LeftClass);
//        //    }

//        //    return a;
//        //}
//        //public ArrayList GetDerivedClasses()
//        //{
//        //    if (ChildRelates == null)
//        //        return new ArrayList();

//        //    ArrayList a = new ArrayList();
//        //    foreach (n_relate r in ChildRelates.All)
//        //    {
//        //        if (r.relate_type == (Int32)Enums.RelationshipType.Inherit)
//        //        {
//        //            if (r.RightClass != null)
//        //                a.Add(r.RightClass);
//        //        }
//        //    }
//        //    return a;
//        //}

//        //public ArrayList CoalesceSortedProps(FrameworkCompareType t, bool include_zeros)
//        //{
//        //    SortedList l = CoalesceProps("", "", false, include_zeros);
//        //    ArrayList a = new ArrayList();
//        //    foreach (DictionaryEntry d in l)
//        //    {
//        //        n_prop p = (n_prop)d.Value;
                
//        //        if( include_zeros || IsSortedProp(p, t) )
//        //            a.Add(p);
//        //    }

//        //    a.Sort(new FrameworkCompare(t));
//        //    return a;
//        //}

//        //public SortedList CoalesceProps()
//        //{
//        //    return CoalesceProps("", "", false);
//        //}
//        //public SortedList CoalesceProps(Boolean bPropertyTag)
//        //{
//        //    return CoalesceProps("", "", bPropertyTag);
//        //}
//        //public SortedList CoalesceProps(String strExcludeNamespace, String strExcludeClass)
//        //{
//        //    return CoalesceProps(strExcludeNamespace, strExcludeClass, false);
//        //}
//        //public SortedList CoalesceProps(String strExcludeNamespace, String strExcludeClass, Boolean bPropertyTag)
//        //{
//        //    return CoalesceProps(strExcludeNamespace, strExcludeClass, bPropertyTag, false);
//        //}

//        //public SortedList CoalesceProps(String strExcludeNamespace, String strExcludeClass, Boolean bPropertyTag, bool IncludeSys)
//        //{
//        //    SortedList ret = new SortedList();
//        //    CoalesceProps(strExcludeNamespace, strExcludeClass, bPropertyTag, IncludeSys, ret);
//        //    return ret;
//        //}

//        //public void CoalesceProps(String strExcludeNamespace, String strExcludeClass, Boolean bPropertyTag, bool IncludeSys, SortedList s)
//        //{
//        //    ArrayList alreadyincluded = new ArrayList();
//        //    n_prop p;
//        //    try
//        //    {
//        //        if (Props.AllByName != null)
//        //        {
//        //            foreach (DictionaryEntry d in Props.AllByName)  //actual class props
//        //            {
//        //                try
//        //                {
//        //                    p = (n_prop)d.Value;
//        //                    if (!alreadyincluded.Contains(p.name.ToLower()))
//        //                    {
//        //                        if (bPropertyTag)
//        //                        {
//        //                            if (Tools.Strings.StrExt(p.property_tag))
//        //                            {
//        //                                s.Add(p.property_tag, p);
//        //                                alreadyincluded.Add(p.name.ToLower());
//        //                            }
//        //                        }
//        //                        else
//        //                        {
//        //                            s.Add(p.GetOrderedID(), p);
//        //                            alreadyincluded.Add(p.name.ToLower());
//        //                        }
//        //                    }
//        //                }
//        //                catch { }
//        //            }
//        //        }
//        //    }
//        //    catch (Exception ex1)
//        //    {
//        //        //context.TheLeader.Tell("Error in CoalesceProps: " + ex1.Message);
//        //    }

//        //    try
//        //    {

//        //        ArrayList bases = this.GetBaseClasses();  //base classes

//        //        //2010_06_14  this only went 2 layers deep until now!?!

//        //        foreach (n_class c in bases)
//        //        {
//        //            if (!Tools.Strings.StrCmp(strExcludeClass, c.class_name))
//        //            {
//        //                //c.CoalesceProps(

//        //                SortedList sx = c.CoalesceProps(strExcludeNamespace, strExcludeNamespace, bPropertyTag, IncludeSys);
//        //                foreach (DictionaryEntry dx in sx)
//        //                {
                            
//        //                    try
//        //                    {
//        //                        n_prop px = (n_prop)dx.Value;
//        //                        if (!alreadyincluded.Contains(px.name.ToLower()))
//        //                        {
//        //                            if (bPropertyTag)
//        //                            {
//        //                                if (Tools.Strings.StrExt(px.property_tag))
//        //                                {
//        //                                    s.Add(px.property_tag, px);
//        //                                    alreadyincluded.Add(px.name.ToLower());
//        //                                }
//        //                            }
//        //                            else
//        //                            {
//        //                                s.Add(px.GetOrderedID(), px);
//        //                                alreadyincluded.Add(px.name.ToLower());
//        //                            }
//        //                        }
//        //                    }
//        //                    catch { }
//        //                }
//        //            }
//        //        }
//        //    }
//        //    catch (Exception ex2)
//        //    {
//        //        context.TheLeader.Tell("Error in CoalesceProps: " + ex2.Message);
//        //    }
//        //    //return s;
//        //}
//        //public Dictionary<String, nObject> CoalesceActions()
//        //{
//        //    Dictionary<String, nObject> d = new Dictionary<String, nObject>();
//        //    if (Actions != null)
//        //    {
//        //        if (Actions.Count > 0)
//        //        {
//        //            foreach (n_action a in Actions.All)
//        //            {
//        //                try
//        //                {
//        //                    d.Add(a.unique_id, a);
//        //                }
//        //                catch { }
//        //            }
//        //        }
//        //    }
//        //    try
//        //    {
//        //        ArrayList bases = this.GetBaseClasses();
//        //        foreach (n_class c in bases)
//        //        {
//        //            if (c.Actions != null)
//        //            {
//        //                if (c.Actions.Count > 0)
//        //                {
//        //                    foreach (n_action a in c.Actions.All)
//        //                    {
//        //                        try
//        //                        {
//        //                            d.Add(a.unique_id, a);
//        //                        }
//        //                        catch { }
//        //                    }
//        //                }
//        //            }
//        //        }
//        //    }
//        //    catch (Exception ee)
//        //    {
//        //        context.TheLeader.Tell("Error in CoalesceProps: " + ee.Message);
//        //    }
//        //    return d;
//        //}
//        //public ArrayList CoalesceParentRelates()
//        //{
//        //    ArrayList s = new ArrayList();
//        //    try
//        //    {
//        //        if (ParentRelates != null)
//        //        {
//        //            foreach (n_relate r in ParentRelates.All)
//        //            {
//        //                if (r.relate_type != 1)
//        //                    s.Add(r);
//        //            }
//        //        }
//        //    }
//        //    catch (Exception ex1)
//        //    {
//        //        context.TheLeader.Tell("Error in CoalesceRelates: " + ex1.Message);
//        //    }
//        //    try
//        //    {
//        //        ArrayList bases = this.GetBaseClasses();
//        //        foreach (n_class c in bases)
//        //        {
//        //            foreach (n_relate r in c.ParentRelates.All)
//        //            {
//        //                if (r.relate_type != 1)
//        //                    s.Add(r);
//        //            }
//        //        }
//        //    }
//        //    catch (Exception ex2)
//        //    {
//        //        context.TheLeader.Tell("Error in CoalesceParentRelates: " + ex2.Message);
//        //    }
//        //    return s;
//        //}
//        //public string GetFieldList()
//        //{
//        //    n_prop p;
//        //    StringBuilder s = new StringBuilder();
//        //    bool b = false;

//        //    foreach (DictionaryEntry d in Props.AllInOrder)
//        //    {
//        //        p = (n_prop)d.Value;

//        //        if (b)
//        //            s.Append(", ");

//        //        s.Append(p.name);
//        //        b = true;
//        //    }
//        //    return s.ToString();
//        //}
//        //public bool CreateMyOwnDataStructure(nData xd)
//        //{
//        //    bool b = false;
//        //    if (!xd.MakeTableExist(class_name))
//        //        return false;

//        //    n_prop p;
//        //    foreach (DictionaryEntry d in Props.AllInOrder)
//        //    {
//        //        p = (n_prop)d.Value;
//        //        if (!xd.MakeFieldExist(class_name, p.name, p.property_type, p.property_length))
//        //            return false;
//        //    }
//        //    return true;
//        //}
//        //public void InitChoices()
//        //{
//        //    n_prop p;
//        //    foreach (DictionaryEntry d in Props.AllInOrder)
//        //    {
//        //        p = (n_prop)d.Value;
//        //        if (Tools.Strings.StrExt(p.the_n_choices_uid))
//        //        {
//        //            p.xChoices = xSys.GetChoicesByID(p.the_n_choices_uid);
//        //        }
//        //    }
//        //}
//        //public bool InheritsFromSomething()
//        //{
//        //    if (ParentRelates == null)
//        //        return false;

//        //    if (ParentRelates.Count == 0)
//        //        return false;

//        //    foreach (n_relate r in ParentRelates.All)
//        //    {
//        //        if (Tools.Strings.StrCmp(r.name, "inherit"))
//        //            return true;
//        //    }
//        //    return false;
//        //}
//        //Private Functions
//        //private void GeneralInit(TreeNode xNode)
//        //{
//        //    if (xNode != null)
//        //    {
//        //        MyNode = xNode.Nodes.Add(this.class_name);
//        //        MyNode.Tag = this;
//        //        MyNode.ImageIndex = nTools.GetIconIndex(NewMethod.Enums.IconType.GuidedClass);
//        //        MyNode.SelectedImageIndex = MyNode.ImageIndex;

//        //        if (is_abstract)
//        //            MyNode.ForeColor = System.Drawing.Color.Gray;

//        //        MyNodeProp = MyNode.Nodes.Add("Props");
//        //        MyNodeRelate = MyNode.Nodes.Add("Relates");
//        //    }
//        //}
//        //private void BlankRelateHolders()
//        //{
//        //    //ParentRelates = new SortedList();
//        //    //ChildRelates = new SortedList();
//        //}
//        //private n_prop MakeDefaultProp(String strProp, String strTag, int len, int ord, FieldType t)
//        //{
//        //    n_prop p;
//        //    if (!HasProp(strProp))
//        //    {
//        //        p = new n_prop(xSys);
//        //        p.name = strProp;
//        //        p.property_tag = strTag;
//        //        p.property_length = len;
//        //        p.property_order = ord;
//        //        p.property_type = (Int32)t;
//        //        p.the_n_class_uid = unique_id;
//        //        p.ISave();
//        //        AbsorbProperty(p);
//        //        SetSoft();
//        //        MakeFieldExist(p);
//        //        return p;
//        //    }
//        //    else
//        //    {
//        //        return null;
//        //    }
//        //}

//        //public bool HasGroupName(String sg)
//        //{
//        //    ArrayList classIds = new ArrayList();
//        //    classIds.Add(this.unique_id);
//        //    classIds.Add(this.class_name);

//        //    return xSys.xData.StatementExists("select * from n_group where the_n_class_uid in ( " + Tools.Data.GetIn(classIds) + " ) and name = '" + xSys.xData.SyntaxFilter(sg) + "'");
//        //}

//        //public n_group AddGroupName(String sg)
//        //{
//        //    n_group g = new n_group(xSys);
//        //    g.name = sg;
//        //    g.the_n_class_uid = this.class_name;  // this.unique_id;
//        //    g.ISave();
//        //    return g;
//        //}

//        //public ArrayList GetGroupNameArray(n_user u)
//        //{
//        //    String uw = "";
//        //    if (u != null)
//        //    {
//        //        if (!u.SuperUser)
//        //        {
//        //            String mt = "<none>";
//        //            if (Tools.Strings.StrExt(u.main_n_team_uid))
//        //                mt = u.main_n_team_uid;

//        //            uw = " and ( ( isnull(the_n_user_uid, '') = '' and isnull(the_n_team_uid, '') = '' ) or ( isnull(the_n_user_uid, '') = '" + u.unique_id + "' ) or ( isnull(the_n_team_uid, '') = '" + mt + "' ))";
//        //        }
//        //    }

//        //    ArrayList classIds = new ArrayList();
//        //    classIds.Add(this.unique_id);
//        //    classIds.Add(this.class_name);

//        //    return xSys.xData.GetScalarArray("select name from n_group where the_n_class_uid in ( " + Tools.Data.GetIn(classIds) + " ) and isnull(name, '') > '' " + uw + " order by name");
//        //}

//        //public String GetOrderFields()
//        //{
//        //    return "";
//        //}

//        //public ArrayList GetSortedProps(FrameworkCompareType t)
//        //{
//        //    return GetSortedProps(t, false);
//        //}

//        //public ArrayList GetSortedProps(FrameworkCompareType t, bool exclude_passwords)
//        //{
//        //    ArrayList v = new ArrayList();
//        //    foreach (n_prop p in Props.All)
//        //    {
//        //        if( !exclude_passwords || p.PropertyUse != NewMethod.Enums.DataUse.Password )
//        //        {
//        //            if (IsSortedProp(p, t))
//        //                v.Add(p);
//        //        }
//        //    }

//        //    v.Sort(new FrameworkCompare(t));
//        //    return v;
//        //}

//        //public bool IsSortedProp(n_prop p, FrameworkCompareType t)
//        //{
//        //    switch (t)
//        //    {
//        //        case FrameworkCompareType.Aspect:
//        //            if (Tools.Strings.StrExt(p.aspect))
//        //                return true;
//        //            break;
//        //        case FrameworkCompareType.Name:
//        //            if (Tools.Strings.StrExt(p.name))
//        //                return true;
//        //            break;
//        //        case FrameworkCompareType.Vivid:
//        //            if (p.vivid > 0)
//        //                return true;
//        //            break;
//        //    }
//        //    return false;
//        //}

//        //public ArrayList GetSortedActions(FrameworkCompareType t, bool single, bool multiple)
//        //{
//        //    ArrayList v = new ArrayList();
//        //    foreach (n_action a in Actions.All)
//        //    {
//        //        bool b = true;
//        //        if (a.only_single && !single)
//        //            b = false;

//        //        if (a.only_multiple && !multiple)
//        //            b = false;

//        //        if( b )
//        //        {
//        //            switch (t)
//        //            {
//        //                case FrameworkCompareType.Aspect:
//        //                    if (Tools.Strings.StrExt(a.aspect))
//        //                        v.Add(a);
//        //                    break;
//        //                case FrameworkCompareType.Name:
//        //                    if (Tools.Strings.StrExt(a.name))
//        //                        v.Add(a);
//        //                    break;
//        //                case FrameworkCompareType.Vivid:
//        //                    if (a.vivid > 0)
//        //                        v.Add(a);
//        //                    break;
//        //            }
//        //        }
//        //    }

//        //    v.Sort(new FrameworkCompare(t));
//        //    return v;
//        //}

//        //public n_menu BuildMenu()
//        //{
//        //    n_menu m = new n_menu(xSys);
//        //    m.the_n_class_uid = this.unique_id;
//        //    m.MenuTree = new ArrayList();

//        //    ArrayList a = GetSortedActions(FrameworkCompareType.Vivid, true, false);

//        //    foreach (n_action ax in Actions.All)
//        //    {
//        //        n_menu n = new n_menu(xSys);
//        //        n.xAction = ax;
//        //        n.icon_key = ax.icon_key;
//        //        n.tag_line = ax.tag_line;
//        //        n.name = ax.name;
//        //        m.MenuTree.Add(n);
//        //    }

//        //    return m;
//        //}

//        public String GetCaption(Enums.CountContext count)
//        {
//            if (!Tools.Strings.StrExt(class_tag))
//                return class_name;
//            else
//            {
//                switch (count)
//                {
//                    case NewMethod.Enums.CountContext.Multiple:
//                        if (Tools.Strings.StrExt(plural_tag))
//                            return plural_tag;
//                        else
//                            return class_tag;
//                    default:
//                        return class_tag;
//                }
//            }
//        }

//        public String GetTagLine(Enums.CountContext count)
//        {
//            switch (count)
//            {
//                case NewMethod.Enums.CountContext.Multiple:
//                    if (Tools.Strings.StrExt(plural_line))
//                        return plural_line;
//                    else
//                        return tag_line;                        
//                default:
//                    return tag_line;
//            }
//        }
//    }
//}
