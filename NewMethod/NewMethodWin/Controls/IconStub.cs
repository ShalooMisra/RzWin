using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class IconStub : UserControl
    {
        public nObject CurrentObject;

        public IconStub()
        {
            InitializeComponent();
        }
        //Public Functions
        public void CompleteLoad(nObject x)
        {
            CurrentObject = x;
            ctlKey.SetValue(x.IGet("icon_key"));
            if (Tools.Strings.StrExt(ctlKey.GetValue_String()))
                pic.Image = FilterImageBackGround(nTools.GetThumbnail(NMWin.ContextDefault.xSys.GetResourceImage(ctlKey.GetValue_String()), pic.Width, pic.Height), Color.Fuchsia);
            else
                pic.Image = null;
        }
        public void DoResize()
        {
            try
            {
                this.Height = 35;
                if (this.Width <= 170)
                    this.Width = 175;
                ctlKey.Width = (this.Width - ctlKey.Left) - 1;
            }
            catch (Exception)
            { }
        }
        //Private Functions
        private void SetIcon(String s)
        {
            CurrentObject.ISet("icon_key", s);
            NMWin.ContextDefault.Update(CurrentObject);
            CompleteLoad(CurrentObject);
        }
        private void ChooseIcon()
        {
            String s = frmIconChooser.Choose(NMWin.ContextDefault.xSys, this.ParentForm);
            if (Tools.Strings.StrExt(s))
                SetIcon(s);
        }
        private Image FilterImageBackGround(Image i, Color filter)
        {
            try
            {
                IM.Images.Clear();
                IM.Images.Add("new_img", i);
                IM.TransparentColor = filter;
                return IM.Images["new_img"];
            }
            catch (Exception)
            { return i; }
        }
        //Control Events
        private void pic_DoubleClick(object sender, EventArgs e)
        {
            ChooseIcon();
        }
        private void lblSet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChooseIcon();
        }
        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetIcon("");
        }
        private void IconStub_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}
