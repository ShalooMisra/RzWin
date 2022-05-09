using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ToolsWin;
using ToolsWin.Dialogs;
using Core;

namespace NewMethod.Win.Dialogs
{
    public partial class ObjectChooser : OKCancel
    {
        public static nObject Choose(ContextNM context, ListArgs args)
        {
            ObjectChooser chooser = new ObjectChooser();
            chooser.Init(context, args);
            chooser.ShowDialog();

            nObject ret = chooser.Result;

            try
            {
                chooser.Close();
                chooser.Dispose();
                chooser = null;
            }
            catch { }

            return ret;
        }

        public nObject Result = null;
        public ObjectChooser()
        {
            InitializeComponent();
        }

        public void Init(ContextNM x, ListArgs args)
        {
            lv.ShowData(args);
        }

        private void lv_AboutToThrow(object sender, ShowArgs args)
        {
            args.Handled = true;
            this.OK();
        }

        public override void OK()
        {
            Result = lv.GetSelectedObject();
            if (Result == null)
                return;

            base.OK();
        }

        public override void Cancel()
        {
            Result = null;
            base.Cancel();
        }
    }
}
