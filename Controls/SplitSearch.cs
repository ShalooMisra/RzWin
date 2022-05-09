using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class SplitSearch : UserControl
    {
        public bool IsSplit = false;
        public ArrayList AllNotify;
        public int RightOffset = 0;

        public SplitSearch()
        {
            InitializeComponent();
        }

        public virtual void CompleteLoad()
        {
            LoadTemplates();
        }

        public virtual void ClearNotifySelection()
        {
            if (AllNotify != null)
                AllNotify.Clear();

            AllNotify = null;
        }

        public virtual void SetNotifySelection(NewMethod.ListArgs.IGenericNotify n)
        {
            ClearNotifySelection();

            AllNotify = new ArrayList();
            AllNotify.Add(n);
        }

        public virtual void NotifyAll(String strClass, String strID)
        {
            //be sure it will be needed before actually querying the database for the object
            if (AllNotify == null)
                return;

            if (AllNotify.Count <= 0)
                return;

            nObject o = (nObject)RzWin.Context.GetById(strClass, strID);
            if (o == null)
                return;

            NotifyAll(o);
        }

        public virtual void NotifyAll(nObject o)
        {
            if (AllNotify == null)
                return;

            foreach (NewMethod.ListArgs.IGenericNotify n in AllNotify)
            {
                n.Notify(o);
            }
        }

        public virtual void LoadTemplates()
        {

        }

        public virtual void DoResize()
        {

        }

        private void SplitSearch_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual int GetRowLimit()
        {
            return 200;
        }

        private void xDisplay2_ObjectClicked(object sender, ObjectClickArgs args)
        {
            NotifyAll(args.GetObject());
        }

        public virtual void TopClicked(nObject xObject)
        {

        }

        public virtual void SwitchBoth()
        {

        }

        public virtual void SetTwo()
        {

        }

        private void xDisplay_ObjectClicked(object sender, ObjectClickArgs args)
        {
            TopClicked(args.GetObject());
            NotifyAll(args.GetObject());
        }

        public virtual void HandleCommand(String strCommand)
        {
            switch (strCommand.ToLower())
            {
                default:
                    break;
            }
        }
    }
}
