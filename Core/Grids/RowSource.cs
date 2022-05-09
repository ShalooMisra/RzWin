using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Drawing;

namespace Core
{
    public abstract class RowSource : IEnumerable
    {
        public abstract int Count { get; }
        public abstract IEnumerator GetEnumerator();
        public virtual RowHandle Find(String rowId)
        {
            foreach (RowHandle h in this)
            {
                if (h.Uid == rowId)
                    return h;
            }
            return null;
        }

        public virtual void DeltaFrom(RowSource from, ColumnSource t, List<RowHandle> changed, List<RowHandle> added, List<RowHandle> removed)
        {
            List<String> thatIds = new List<string>();
            foreach (RowHandle h in from)
            {
                thatIds.Add(h.Uid);
            }

            foreach (RowHandle h in this)
            {
                RowHandle that = from.Find(h.Uid);
                if (that != null)
                {
                    thatIds.Remove(h.Uid);
                    if (that.ValueString(t) != h.ValueString(t))
                        changed.Add(h);
                }
                else
                {
                    added.Add(h);
                }
            }

            foreach (String id in thatIds)
            {
                removed.Add(from.Find(id));
            }
        }
        public virtual IItem TryFind(String classId, String itemId)
        {
            return null;
        }

        public virtual void TryRemove(IItem item)
        {
        }
    }

    public class RowSourceExplicit : RowSource
    {
        public List<RowHandle> Rows;

        public RowSourceExplicit(List<RowHandle> rows)
        {
            Rows = rows;
        }

        public override IEnumerator GetEnumerator()
        {
            return Rows.GetEnumerator();
        }

        public override int Count
        {
            get { return Rows.Count; }
        }

        public override void TryRemove(IItem item)
        {
            base.TryRemove(item);

            if (Rows != null)
            {
                foreach (RowHandle r in new List<RowHandle>(Rows))
                {
                    if (r.Uid == item.Uid)
                        Rows.Remove(r);
                }
            }
        }
    }

    public class RowHandleExplicit : RowHandle
    {
        protected Dictionary<String, Object> Values = new Dictionary<string, object>();

        protected Color m_BackColor = Color.White;
        public override Color BackColor
        {
            get
            {
                return m_BackColor;
            }
        }

        protected String m_Uid;
        public override string Uid
        {
            get
            {
                return m_Uid;
            }
        }

        public override object Value(string key)
        {
            if (Values.ContainsKey(key))
                return Values[key];
            else
                return null;
        }
    }

    public class RowSourceTable : RowSource
    {
        DataTable Table;
        public RowSourceTable(DataTable table)
        {
            Table = table;
        }

        public override IEnumerator GetEnumerator()
        {
            return new EnumeratorTable(Table);
        }

        public override int Count
        {
            get
            {
                if (Table == null)
                    return 0;

                return Table.Rows.Count;
            }
        }

        public DataTable GetDataTable()
        {
            return Table;
        }

        public override void TryRemove(IItem item)
        {
            base.TryRemove(item);

            if (Table != null)
            {
                List<DataRow> rows = new List<DataRow>();
                foreach (DataRow r in Table.Rows)
                {
                    rows.Add(r);
                }

                foreach (DataRow r in rows)
                {
                    if (Tools.Data.NullFilterString(r["unique_id"]) == item.Uid)
                        Table.Rows.Remove(r);
                }
            }
        }
    }

    public class EnumeratorTable : IEnumerator
    {
        DataTable Table;
        int RowIndex = -1;
        public EnumeratorTable(DataTable table)
        {
            Table = table;
        }

        public Object Current
        {
            get
            {
                return new RowHandleTable(Table.Rows[RowIndex]);
            }
        }

        public void Reset()
        {
            RowIndex = 0;
        }

        public bool MoveNext()
        {
            if (Table == null)
                return false;

            RowIndex++;
            return RowIndex < Table.Rows.Count;
        }

        public void Dispose()
        {
            Table = null;
        }
    }

    public class RowSourceItem : RowSource
    {
        public List<IItem> Items;

        public RowSourceItem(List<IItem> items)
        {
            Items = items;
        }

        //public RowSourceItem(ArrayList items)
        //{
        //    Items = new List<IItem>();
        //    foreach (IItem i in items)
        //    {
        //        Items.Add(i);
        //    }
        //}

        public override IEnumerator GetEnumerator()
        {
            return new EnumeratorItem(Items);
        }

        public override int Count
        {
            get { return Items.Count; }
        }

        public override IItem TryFind(string classId, string itemId)
        {
            IItem ret = base.TryFind(classId, itemId);
            if (ret != null)
                return ret;

            RowHandleItem h = (RowHandleItem)Find(itemId);
            if (h != null)
                return h.Item;

            return null;
        }

        public override void TryRemove(IItem item)
        {
            base.TryRemove(item);

            if (Items != null)
            {
                foreach (IItem i in new List<IItem>(Items))
                {
                    if (i.Uid == item.Uid)
                        Items.Remove(i);
                }
            }
        }
    }

    public class EnumeratorItem : IEnumerator
    {
        public List<IItem> Items;
        int RowIndex = -1;
        public EnumeratorItem(List<IItem> items)
        {
            Items = items;
        }

        public Object Current
        {
            get
            {
                return new RowHandleItem(Items[RowIndex]);
            }
        }

        public void Reset()
        {
            RowIndex = 0;
        }

        public bool MoveNext()
        {
            RowIndex++;
            return RowIndex < Items.Count;
        }

        public void Dispose()
        {
            Items = null;
        }
    }

    public abstract class RowHandle
    {
        public abstract Object Value(String key);
        public virtual Color ForeColor
        { 
            get
            {
                int c = 0;
                try { c = Tools.Data.NullFilterInt(Value("grid_color")); }
                catch { }
                if (c == 0)
                    return Color.Black;
                else
                    return Color.FromArgb(c);
            } 
        }
        public virtual Color BackColor { get { return Color.White; } }
        public virtual String Uid { get { return Tools.Data.NullFilterString(Value("unique_id")); } }
        public virtual String IconKey
        {
            get
            {
                try
                {
                    return RowHandle.GetIcon(Convert.ToInt32(Tools.Data.NullFilterIntegerFromIntOrLong(Value("icon_index"))));  //are some of these long vals in the database?
                }
                catch { return ""; }
            }
        }

        public static string GetIcon(int index)
        {
            index = index - 1;
            switch (index)
            {
                case 0:
                    return "cloud";
                case 1:
                    return "earth";
                case 2:
                    return "fire";
                case 3:
                    return "lightning";
                case 4:
                    return "dollar";
                case 5:
                    return "calendar";
                case 6:
                    return "plane";
                default:
                    return "";
            }
        }

        public virtual String ValueString(ColumnSource t)
        {
            StringBuilder sb = new StringBuilder();
            foreach (ColumnHandle col in t)
            {
                Object x = Value(col.Name);
                if (x == null || x == DBNull.Value)
                    sb.Append("|^|");
                else
                    sb.Append(x.ToString() + "|^|");
            }
            sb.Append("|^|" + IconKey);
            sb.Append("|^|" + BackColor);
            sb.Append("|^|" + ForeColor);
            return sb.ToString();
        }
    }

    public class RowHandleTable : RowHandle
    {
        protected DataRow Row;
        public RowHandleTable(DataRow r)
        {
            Row = r;
        }

        public override Object Value(String key)
        {
            return Row[key];
        }
    }

    public class RowHandleItem : RowHandle
    {
        public IItem Item;
        public RowHandleItem(IItem item)
        {
            Item = item;
        }

        public override Object Value(String key)
        {
            return Item.ValGet(key);
        }

        public override string Uid
        {
            get
            {
                return Item.Uid;
            }
        }
    }
}
