using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;

namespace NewMethod
{
    public class nArray
    {
        public ArrayList All = new ArrayList();
        public Dictionary<String, nObject> AllByID = new Dictionary<string, nObject>();
        public SortedList AllByName = new SortedList();

        public nArray()
        {

        }

        public virtual void Clear()
        {
            All = new ArrayList();
            AllByID = new Dictionary<string, nObject>();
            AllByName = new SortedList();
        }

        public virtual void Add(nObject x)
        {
            All.Add(x);
            AllByID.Add(x.unique_id, x);

            String name = x.ToString().ToLower();
            if (Tools.Strings.StrExt(name) && !AllByName.ContainsKey(name))
                AllByName.Add(name, x);
            else
            {
                ;
            }
        }

        public void Add(ArrayList a)
        {
            foreach (nObject x in a)
            {
                Add(x);
            }
        }

        public virtual void Remove(nObject x)
        {
            All.Remove(x);
            try
            {
                AllByID.Remove(x.unique_id);
            }
            catch { }
            try
            {
                AllByName.Remove(x.ToString().ToLower());
            }
            catch { }
        }

        public int Count
        {
            get
            {
                return All.Count;
            }
        }

        public bool HasName(String strName)
        {
            return AllByName.ContainsKey(strName.ToLower());
        }

        public nObject GetByName(String strName)
        {
            try
            {
                return (nObject)AllByName[strName.ToLower()];
            }
            catch { return null; }
        }

        public nObject GetByID(String strID)
        {
            try
            {
                return AllByID[strID];
            }
            catch { return null; }
        }

        public String NameToID(String strName)
        {
            try
            {
                nObject x = GetByName(strName);
                if( x == null )
                    return "";
                return x.unique_id;
            }
            catch { return ""; }
        }

        public String IDToName(String strID)
        {
            try
            {
                nObject x = GetByID(strID);
                if (x == null)
                    return "";
                return x.ToString();
            }
            catch { return ""; }
        }

        //public int AddFromXmlDB(SysNewMethod xSys, String strClass, String strXmlFile)
        //{
        //    XmlDocument d = new XmlDocument();
        //    d.Load(strXmlFile);
        //    XmlNodeList l = d.SelectNodes("objects/object");
        //    int i = 0;
        //    foreach (XmlNode n in l)
        //    {
        //        nObject x = xSys.MakeObject(strClass);
        //        x.CreateFromXml(n);
        //        Add(x);
        //        i++;
        //    }
        //    return i;
        //}
    }

    public class nArrayWithOrder : nArray
    {
        public String OrderPropName = "";
        public SortedList AllInOrder = new SortedList();

        public nArrayWithOrder(String strOrderProp) : base()
        {
            OrderPropName = strOrderProp;
        }

        public override void Clear()
        {
            base.Clear();
            AllInOrder = new SortedList();
        }

        public override void Add(nObject x)
        {
            base.Add(x);
            try
            {
                AllInOrder.Add((int)x.IGet(OrderPropName), x);
            }
            catch { }
        }

        public override void Remove(nObject x)
        {
            base.Remove(x);
            try
            {
                AllInOrder.Remove((int)x.IGet(OrderPropName));
            }
            catch { }
        }

        public nObject GetByOrder(int order)
        {
            try
            {
                return (nObject)AllInOrder[order];
            }
            catch { return null; }
        }
    }
}
