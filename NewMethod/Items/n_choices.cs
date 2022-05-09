using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Windows.Forms;

using Core;

namespace NewMethod
{
    public partial class n_choices : n_choices_auto
    {
        public event NothingDelegate ChoicesChanged;
        public void ChoicesChangedFire()
        {
            if (ChoicesChanged != null)
                ChoicesChanged();
        }

        public static IUpdateListView UpdateThisListView = null;

        public ArrayList AllChoices;

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        //Public Functions
        public n_choice AddChoice(ContextNM context, String strName)
        {
            return AddChoice(context, strName, true);
        }
        public n_choice AddChoice(ContextNM context, String strName, Boolean bCacheChoiceList)
        {
            if (!Tools.Strings.StrExt(strName))
                return null;

            if (AllChoices == null)
                CacheChoiceList(context);

            n_choice c = GetChoice(context, strName);
            if (c != null)
                return c;

            c = this.AddNew_the_n_choice(context);
            c.name = strName;
            context.Insert(c);

            if (bCacheChoiceList)
                CacheChoiceList(context);

            return c;
        }
        public n_choice GetChoice(ContextNM context, String strName)
        {
            if( AllChoices == null )
                CacheChoiceList(context);

            foreach (n_choice c in AllChoices)
            {
                if (Tools.Strings.StrCmp(c.name, strName))
                    return c;
            }
            return null;
        }

        public void SplitChoices(ContextNM context, String strSplit)
        {
            CacheChoiceList(context);
            ArrayList remove = new ArrayList();
            ArrayList splits = new ArrayList();

            foreach (n_choice c in AllChoices)
            {
                if (Tools.Strings.HasString(c.name, strSplit))
                {
                    remove.Add(c);
                    String[] ary = Tools.Strings.Split(c.Name, strSplit);
                    foreach (String s in ary)
                    {
                        if (Tools.Strings.StrExt(s))
                            splits.Add(s.Trim());
                    }
                }
            }

            foreach (n_choice c in remove)
            {
                context.Delete(c);
            }

            CacheChoiceList(context);

            foreach (String s in splits)
            {
                n_choice c = GetChoice(context, s);
                if (c == null)
                    AddChoice(context, s);
            }

            CacheChoiceList(context);
        }

        public void DeleteChoices(ContextNM x)
        {
            x.Execute("delete from n_choice where the_n_choices_uid = '" + this.unique_id + "'");
        }
        public void AlphabetizeChoices(ContextNM x)
        {
            SortedList s = new SortedList();
            ArrayList a = this.Get_the_n_choice_collection(x);
            foreach(n_choice c in a)
            {
                try
                {
                    s.Add(c.name, c);
                }
                catch(Exception e)
                {
                    x.Delete(c);
                }
            }

            long l = 1;
            n_choice c2;
            foreach (DictionaryEntry d in s)
            {
                c2 = (n_choice)d.Value;
                c2.the_n_choices_order = l;
                x.Update(c2);
                l++;
            }
        }
        public void CacheChoiceList(ContextNM context)
        {
            //this should never happen, it should throw and exception if it comes up
            //if (context.TheData == null)
            //    AllChoices = new ArrayList();
            //else
                AllChoices = context.QtC("n_choice", "select * from n_choice where the_n_choices_uid = '" + this.unique_id + "' order by the_n_choices_order");
        }

        public List<n_choice> ChoicesList(ContextNM context)
        {
            if (AllChoices == null)
                CacheChoiceList(context);
            List<n_choice> ret = new List<n_choice>();
            foreach (n_choice c in AllChoices)
            {
                ret.Add(c);
            }            
            return ret;
        }

        public bool ChoiceContains(ContextNM context, String name)
        {
            foreach (n_choice c in ChoicesList(context))
            {
                if (Tools.Strings.StrCmp(c.name, name))
                    return true;
            }
            return false;
        }

        public void LoadComboBox(ContextNM context, System.Windows.Forms.ComboBox cb, Boolean bAlphabetizeList)
        {
            cb.Items.Clear();
            CacheChoiceList(context);
            if (bAlphabetizeList)
                AlphabetizeChoices(context);
            foreach (n_choice c in AllChoices)
            {
                cb.Items.Add(c.name);
            }
        }
        public n_choice AddNew_the_n_choice(ContextNM context)
        {
            n_choice c = new n_choice();
            c.the_n_choices_uid = this.unique_id;
            c.the_n_choices_order = GetNextOrder_the_n_choice(context);
            return c;
        }
        public ArrayList Get_the_n_choice_collection(ContextNM x)
        {
            return x.QtC("n_choice", "select * from n_choice where the_n_choices_uid = '" + this.unique_id + "'");
        }
        public int GetNextOrder_the_n_choice(ContextNM x)
        {
            return x.TheData.SelectScalarInt32("select count(*) from n_choice where the_n_choices_uid = '" + this.unique_id + "'") + 1;
        }

        public static Dictionary<String, ChoiceHandle> ChoiceHandles = null;
        public static ChoiceHandle ChoiceHandleGet(ContextNM context, String name)
        {
            if (ChoiceHandles == null)
                ChoiceHandles = new Dictionary<String, ChoiceHandle>();

            if (ChoiceHandles.ContainsKey(name.ToLower()))
                return ChoiceHandles[name.ToLower()];
            else
                return CacheChoiceList(context, name);
        }

        public static n_choices ChoicesMakeExist(ContextNM context, String name)
        {
            n_choices c = n_choices.GetByName(context, name);
            if (c == null)
            {
                c = (n_choices)context.Item("n_choices");   // new n_choices(context.xSys);
                c.name = name;
                context.Insert(c);
            }
            return c;
        }

        public static ChoiceHandle CacheChoiceList(ContextNM context, String name)
        {
            n_choices c = ChoicesMakeExist(context, name);

            if (ChoiceHandles == null)
                return null;

            ChoiceHandle h;

            if (ChoiceHandles.ContainsKey(name.ToLower()))
            {
                h = ChoiceHandles[name.ToLower()];
                h.Choices.Clear();
            }
            else
            {
                h = new ChoiceHandle();
                h.Name = c.name.ToLower();
                ChoiceHandles.Add(h.Name, h);
            }

            
            c.CacheChoiceList(context);
            foreach (n_choice cx in c.AllChoices)
            {
                h.Choices.Add(cx.name);
            }
            c = null;
            
            return h;
        }

        public static List<String> ChoiceListGet(ContextNM context, String name)
        {
            ChoiceHandle h = ChoiceHandleGet(context, name);
            if (h == null)
                return new List<String>();
            else
                return h.Choices;
        }

        public static void ChoiceMakeExist(ContextNM context, String list, String choice)
        {
            n_choices c = n_choices.GetByName(context, list);
            if (c == null)
                return;

            c.AddChoice(context, choice);
            CacheChoiceList(context, list);
        }

        public override string ToString()
        {
            return name;
        }
    }
    namespace Enums
    {
        public enum ChoiceType
        {
            Unknown = -1,
            None = 0,
            //string stuff
            FreeType = 1,
            SelectOnly = 2,
            MustSelect = 3,
        }
    }
    public interface IUpdateListView
    {
        void RefreshList();
    }
    public class ChoiceHandle
    {
        public String Name = "";
        public List<String> Choices = new List<String>();
    }
}
