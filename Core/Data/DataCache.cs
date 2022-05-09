using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class DataCache
    {
        public static bool CacheMode = true;
        public static Dictionary<String, IItem> CacheItems;

        public static void Init()
        {
            CacheItems = new Dictionary<string, IItem>();
            CacheMode = true;
        }

        public static IItem Get(String uid)
        {
            try
            {
                return CacheItems[uid];
            }
            catch { return null; }
        }

        public static void Add(IItem item)
        {
            if (CacheItems.ContainsKey(item.Uid))
                return;

            CacheItems.Add(item.Uid, item);
        }

        public static void Remove(String uid)
        {
            CacheItems.Remove(uid);
        }

        //public static event ChangeHandler Change;

        //public static void ChangeFire(Context x, ChangeArgs args, IItems items)
        //{
        //    if (Change != null)
        //        Change(x, args, items);
        //}
    }
}
