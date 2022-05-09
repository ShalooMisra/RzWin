using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace NewMethod.Original.nEdits
{
    public partial class nEdit_Picture : nEdit
    {
        public nBlobHandle TheHandle;

        public nEdit_Picture()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Image i = TheHandle.GetAsImage();
            if (i == null)
                PictureClear();
            else
                PictureSet(i);
        }

        public override String Caption
        {
            get
            {
                return base.lblCaption.Text;
            }
            set
            {
                base.lblCaption.Text = value;
                DoResize();
            }
        }

        public override void DoResize()
        {
            base.DoResize();

            try
            {
                pic.Left = 5;
                pic.Width = this.ClientRectangle.Width - 10;
                pic.Height = this.ClientRectangle.Height - (pic.Top + 5);
            }
            catch { }
        }

        public void PictureSet(Image i)
        {
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.BackgroundImage = i;
        }

        public void PictureClear()
        {
            pic.BackgroundImage = null;
            pic.BackColor = Color.Gainsboro;
        }

        private void lblSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (AboutToSet != null)
            {
                AboutToSet(this, null);
                return;
            }

            String file = ToolsWin.FileSystem.ChooseAFile();
            if (!File.Exists(file))
                return;

            TheHandle.SetFromFile(file);
            PictureSet(Image.FromFile(file));
        }

        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TheHandle.SetToNull();
            PictureClear();
        }
        public event EventHandler AboutToSet;
    }
}
