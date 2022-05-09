using System;
using System.Collections;
using System.Text;

namespace Tie
{
    public interface ITieRefresh
    {
        void RefreshTieItem();
        bool InvokeRequired { get; }
        Object Invoke(Delegate method);
        Object Invoke(Delegate method, Object[] pars);
    } 

    public class TieRefresh
    {
        private ArrayList RefreshItems;
        public void AddItem(ITieRefresh r)
        {
            if (RefreshItems == null)
                RefreshItems = new ArrayList();

            lock (RefreshItems.SyncRoot)
            {
                RefreshItems.Add(r);
            }
        }

        public void Refresh()
        {
            if (RefreshItems == null)
                return;

            lock (RefreshItems.SyncRoot)
            {
                foreach (ITieRefresh r in RefreshItems)
                {
                    if (r.InvokeRequired)
                        r.Invoke(new RefreshItemHandler(RefreshOneItem), new object[] { r });
                    else
                        RefreshOneItem(r);
                }
            }
        }
        delegate void RefreshItemHandler(ITieRefresh r);
        public void RefreshOneItem(ITieRefresh r)
        {
            r.RefreshTieItem();
        }
    }
}
