using System;
using System.Collections;
using System.Text;

namespace NewMethod
{
    public class nRefresh
    {
        public ArrayList Items = new ArrayList();
        public void Refresh()
        {
            foreach (IRefreshable r in Items)
            {
                if (r.RefreshControl.InvokeRequired)
                    r.RefreshControl.Invoke(new ActualRefreshHandler(ActualRefresh), new object[] { r });
                else
                    ActualRefresh(r);                
            }
        }

        delegate void ActualRefreshHandler(IRefreshable r);
        void ActualRefresh(IRefreshable r)
        {
            try
            {
                r.DoRefresh();
            }
            catch { }
        }

        public void Add(IRefreshable r)
        {
            if (r == null)
                return;

            Items.Add(r);
        }

        public void Remove(IRefreshable r)
        {
            try
            {
                Items.Remove(r);
            }
            catch { }
        }
    }

    public interface IRefreshable
    {
        void DoRefresh();
        System.Windows.Forms.Control RefreshControl { get; }
    }
}
