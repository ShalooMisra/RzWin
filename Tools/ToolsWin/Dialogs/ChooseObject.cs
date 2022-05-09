using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ToolsWin.Dialogs
{
    public partial class ChooseObject : OKCancel
    {
        public static List<Object> Choose(List<Object> objects)
        {
            ChooseObject form = new ChooseObject();
            form.Init(objects);
            form.ShowDialog();

            List<Object> ret = form.SelectedObjects;

            try
            {
                form.Close();
                form.Dispose();
                form = null;
            }
            catch { }

            return ret;
        }

        public static Object ChooseSingle(List<Object> objects)
        {
            ChooseObject form = new ChooseObject();
            form.Init(objects, singleMode: true);
            form.ShowDialog();

            List<Object> ret = form.SelectedObjects;

            try
            {
                form.Close();
                form.Dispose();
                form = null;
            }
            catch { }

            if (ret.Count == 1)
                return ret[0];
            else
                return null;
        }

        public List<Object> SelectedObjects = new List<object>();
        bool SingleMode = false;

        public ChooseObject()
        {
            InitializeComponent();
        }

        public void Init(List<Object> objects, bool singleMode = false)
        {
            SingleMode = singleMode;
            lv.Items.Clear();
            lv.CheckBoxes = !singleMode;
            foreach (Object x in objects)
            {
                ListViewItem i = lv.Items.Add(x.ToString());
                i.Tag = x;
            }
        }

        public override void Cancel()
        {
            SelectedObjects.Clear();
            base.Cancel();
        }

        public override void OK()
        {
            SelectedObjects.Clear();

            if (SingleMode)
            {
                SelectedObjects.Add(lv.SelectedItems[0].Tag);
            }
            else
            {
                foreach (ListViewItem i in lv.CheckedItems)
                {
                    SelectedObjects.Add(i.Tag);
                }
            }

            if (SelectedObjects.Count == 0)
                return;

            base.OK();
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            if (SingleMode && lv.SelectedItems.Count == 1)
                OK();
        }
    }
}
