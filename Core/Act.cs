using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Core
{
    public class Act
    {
        public String Name;
        public ActHandler Handler;
        public ActPossibleHandler PossibleHandler;
        public ActConfirmHandler ConfirmHandler;
        public Color Color = Color.Black;
        //public String Group;

        //public Act(String name, ActHandler handler, ActPossibleHandler possibleHandler, ActConfirmHandler confirmHandler, String group) : this(name, handler, possibleHandler, confirmHandler)
        //{
        //    Group = group;
        //}

        public Act(String name, ActHandler handler, ActPossibleHandler possibleHandler, ActConfirmHandler confirmHandler) : this(name, handler, possibleHandler)
        {
            ConfirmHandler = confirmHandler;
        }

        public Act(String name, ActHandler handler, ActPossibleHandler possibleHandler) : this(name, handler)
        {
            PossibleHandler = possibleHandler;
        }

        public Act(String name, ActHandler handler) : this(name)
        {
            Handler = handler;
        }

        public Act(String name)
        {
            Name = name;
        }
    }  

    public class ActHandle
    {
        public Act TheAct;
        public List<ActHandle> SubActs = new List<ActHandle>();
        public List<String> Inserts = new List<string>();

        String m_Caption = null;
        public String Caption
        {
            get
            {
                if (Tools.Strings.StrExt(m_Caption))
                    return m_Caption;
                else
                    return Name;
            }

            set
            {
                m_Caption = value;
            }
        }

        String m_Name;
        public String Name
        {
            get
            {
                if (TheAct == null)
                    return m_Name;
                else
                    return TheAct.Name;
            }

            set
            {
                if (TheAct != null)
                    throw new Exception("Named act");

                m_Name = value;
            }
        }

        public String ActionParameters = "";

        public ActHandle(Act act)
        {
            TheAct = act;
        }

        public ActHandle(String name, String pars, String caption) : this(name, caption)
        {
            ActionParameters = pars;
        }

        public ActHandle(String name, String caption) : this(name)
        {
            Caption = caption;
        }

        public ActHandle(String name)
        {
            Name = name;
        }

        public void AddSubSeparator()
        {
            if( SubActs.Count > 0 && (!(SubActs[SubActs.Count - 1] is ActHandleSeparator)))
                SubActs.Add(new ActHandleSeparator());
        }

        public ActHandle Find(String id)
        {
            foreach (ActHandle h in SubActs)
            {
                if (h.TheAct != null)
                {
                    if (Tools.Strings.StrCmp(h.TheAct.Name, id))
                        return h;
                }
            }
            return null;
        }
    }

    public class ActHandleSeparator : ActHandle
    {
        public ActHandleSeparator()
            : base((Act)null)
        {
        }
    }

    public class ActSetup
    {
        public List<ActHandle> Handles = new List<ActHandle>();
        public bool IsRightClick = false;
        public IItems TheItems;

        public ActSetup()
        {

        }

        public ActSetup(IItems items)
        {
            TheItems = items;
        }

        public bool ItemsHas(Context x)
        {
            if (TheItems == null)
                return false;

            if (TheItems.AllGet(x).Count == 0)
                return false;

            return true;
        }

        public bool Multiple(Context x)
        {
            if (TheItems == null)
                return false;

            if (TheItems.AllGet(x).Count < 2)
                return false;

            return true;
        }

        public IItem FirstItem(Context x)
        {
            if (TheItems == null)
                return null;
            return TheItems.FirstGet(x);
        }

        public List<String> ClassIdsList(Context x)
        {
            if (TheItems == null)
                return new List<String>();

            return TheItems.ClassIdsList(x);
        }

        public void Add(ActHandle h)
        {
            Handles.Add(h);
        }

        public bool Closed = false;
        public void Close()
        {
            Closed = true;
        }

        public void Clear()
        {
            Handles.Clear();
            Closed = false;
        }

        public void Add(String caption, String name)
        {
            if (Closed)
                return;

            Handles.Add(new ActHandle(name, caption));
        }

        public void Add(String name)
        {
            if (Closed)
                return;

            Handles.Add(new ActHandle(name));
        }

        public String ClassIdSingleOrBlank(Context x)
        {
            if (TheItems == null)
                return "";

            List<String> ids = TheItems.ClassIdsList(x);
            if (ids.Count == 0 || ids.Count > 1)
                return "";

            return ids[0];
        }

        public bool Has(String name)
        {
            foreach (ActHandle h in Handles)
            {
                if (Tools.Strings.StrCmp(h.Name, name))
                    return true;
            }
            return false;
        }

        public ActHandle Find(String name)
        {
            foreach (ActHandle h in Handles)
            {
                if (Tools.Strings.StrCmp(h.Name, name))
                    return h;
            }
            return null;
        }

        public void AddSeparator()
        {
            if (Closed)
                return;

            if (Handles.Count == 0)
                return;
            else
            {
                if ((Handles[Handles.Count - 1]) is ActHandleSeparator)
                    return;
            }

            Handles.Add(new ActHandleSeparator());
        }
    }

    public class ActArgs
    {
        public Act TheAct;
        public IItems TheItems;
        public bool Handled = false;
        public bool ShouldClose = false;
        public bool ReturnOnly = false;
        public Context TheContext;  //this is just for the legacy string-based NM handlers.  needs to go

        String m_Name;
        public String Name
        {
            get
            {
                if (TheAct == null)
                    return m_Name;
                else
                    return TheAct.Name;
            }

            set
            {
                if (TheAct != null)
                    throw new Exception("Named act");

                m_Name = value;
            }
        }

        public String ActionName
        {
            get
            {
                return Name.Replace(" ", "").ToLower();
            }
        }

        public ActArgs()
        {

        }

        public ActArgs(String name) : this()
        {
            Name = name;
        }

        public ActArgs(Act act, IItems items)
        {
            TheAct = act;
            TheItems = items;
        }

        public ActArgs(Context x, String name) //temporary, just for the NM format
        {
            TheContext = x;
            Name = name;
        }

        public ActArgs(String name, IItems items) : this(name)
        {
            TheItems = items;
        }

        public ActArgs(IItems items) : this("", items)
        {
        }

        public bool ItemsHas(Context x)
        {
            if (TheItems == null)
                return false;

            if (TheItems.AllGet(x).Count == 0)
                return false;

            return true;
        }

        public bool Success = false;
        public ItemsInstance ItemsAffected;
        public Dictionary<String, Object> ResultInfo;

        public void Result(String key, Object value)
        {
            if (value == null)
                Success = false;
            else
            {
                Success = true;
                ResultInfo = new Dictionary<string, object>();
                ResultInfo.Add(key, value);
            }
        }

        public void Result(bool success)
        {
            Success = success;
        }

        public Object InfoFirst
        {
            get
            {
                if (ResultInfo == null)
                    return null;

                //isn't there a better way to get the first value?
                foreach (KeyValuePair<String, Object> k in ResultInfo)
                {
                    return k.Value;
                }

                return null;
            }
        }

        public String ClassIdSingleOrBlank(Context x)
        {
            if (TheItems == null)
                return "";

            List<String> ids = TheItems.ClassIdsList(x);
            if (ids.Count == 0 || ids.Count > 1)
                return "";

            return ids[0];
        }

        public void AbsorbHandle(ActHandle h)
        {
            if (h.TheAct != null)
            {
                Name = "";
                TheAct = h.TheAct;
            }
            else
            {
                TheAct = null;
                Name = h.Name;
            }
        }

        public bool Canceled = false;
    }

    public delegate void ActHandler(Context x, ActArgs args);
    public delegate bool ActPossibleHandler(Context x, ActSetup set);
    public delegate bool ActConfirmHandler(Context x, ActArgs args);
}
