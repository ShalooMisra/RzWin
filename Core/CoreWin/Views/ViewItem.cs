using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Core;
using ToolsWin;
using Core.Display;

namespace CoreWin.Views
{
    public partial class ViewItem : ViewBase, IView
    {
        public Item TheItem;

        public ViewItem()
        {
            InitializeComponent();
        }
        void CompleteDispose()
        {
            try
            {
                this.Resize -= new System.EventHandler(this.ViewItem_Resize);
            }
            catch { }
        }
        public virtual void Init(Item item)
        {
            TheItem = item;
        }

        private void ViewItem_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        //protected override void ChangeHandle(Context x, ChangeArgs args, IItems items)
        //{
        //    base.ChangeHandle(x, args, items);
        //    if (items.IdIncludes(TheItem.Uid))
        //    {
        //        switch (args.TheType)
        //        {
        //            case ChangeType.Refresh:
        //            case ChangeType.Update:

        //                break;
        //            case ChangeType.Remove:
        //                CloseRequestSend();
        //                break;
        //        }
        //    }
        //}

        public virtual IItem ItemFindByTag(ItemTag t)
        {
            return null;
        }
    }
}
