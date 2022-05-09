using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace ToolsWin.Dialogs
{
    public partial class ImageChooser : ToolsWin.Dialogs.OKCancel
    {
        public static ImageHandle Choose(List<ImageHandle> images, ref bool noneSelected)
        {
            ImageChooser c = new ImageChooser();
            c.Init(images);
            c.ShowDialog();
            ImageHandle ret = c.SelectedImage;
            noneSelected = c.NoneSelected;

            try
            {
                c.Close();
                c.Dispose();
                c = null;
            }
            catch { }

            return ret;
        }

        public ImageHandle SelectedImage;
        public bool NoneSelected = false;

        public ImageChooser()
        {
            InitializeComponent();
        }

        public void Init(List<ImageHandle> handles)
        {
            lv.Items.Clear();

            lv.Items.Add("[no image]", 0);

            foreach (ImageHandle h in handles)
            {
                il.Images.Add(h.Name, h.Image);
                ListViewItem i = lv.Items.Add(Tools.Strings.NiceFormat(h.Name), h.Name);
                i.Tag = h;
            }
        }

        private void lv_DoubleClick(object sender, EventArgs e)
        {
            OK();
        }

        public override void Cancel()
        {
            SelectedImage = null;
            NoneSelected = false;
            base.Cancel();
        }

        public override void OK()
        {
            try
            {
                ListViewItem i = lv.SelectedItems[0];
                if (i.Tag == null)
                {
                    SelectedImage = null;
                    NoneSelected = true;
                }
                else
                {
                    NoneSelected = false;
                    SelectedImage = (ImageHandle)i.Tag;
                }
                base.OK();
            }
            catch { }
        }
    }
}
