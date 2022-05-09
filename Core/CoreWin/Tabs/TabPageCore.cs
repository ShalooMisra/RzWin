using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

using Tools;
using ToolsWin;
using Core;

namespace CoreWin
{
    public partial class TabPageCore : System.Windows.Forms.TabPage
    {
        public event CloseHandler CloseRequest;
        public event ShowExternalHandler ShowExternal;
        public TabControl MyTabControl;
        public Control TheControl;
        PictureBox pic;
        public String TabID = "";
        public String OriginalCaption = "";
        public Boolean Locked = false;
        private EventHandler picclick;
        ToolTip tip;
        public IItem TheItem;
        public UserControl TheView;

        public TabPageCore()
        {
            InitializeComponent();
            tip = new ToolTip();
            LoadPic();
        }
        protected override void Dispose(bool disposing)
        {
            CompleteDispose();
            base.Dispose(disposing);
        }
        public void CompleteDispose()
        {
            try
            {
                TheItem = null;
                TheView = null;

                MyTabControl = null;
                CloseRequest = null;
                ShowExternal = null;
                if (tip != null)
                    tip.Dispose();
                tip = null;

                if (TheControl != null)
                {
                    try
                    {
                        RemoveControlReferences();
                        TheControl.Dispose();
                        TheControl = null;
                    }
                    catch (Exception)
                    { }
                }

                CutPicClick();
                if (pic != null)
                {
                    try
                    {
                        Controls.Remove(pic);
                        pic.Dispose();
                        pic = null;
                    }
                    catch (Exception)
                    { }
                }
            }
            catch { }
        }
        public void SetControl(Control c)
        {
            TheControl = c;
            Controls.Add(c);

            if (TheControl is ViewBase)
            {
                ViewBase cr = (ViewBase)TheControl;
                cr.CloseRequest += new CloseHandler(cr_CloseRequest);
            }

        }
        public void ShowUpdateIcon()
        {
            ImageKey = "Update";
        }
        void cr_CloseRequest(object sender, CloseArgs args)
        {
            SendCloseRequest(this, new CloseArgs());
        }
        public void ReleaseControl()  //does not dispose the control
        {
            if (TheControl == null)
                return;

            RemoveControlReferences();

            TheControl = null;
        }
        void RemoveControlReferences()
        {
            if (TheControl == null)
                return;

            if (TheControl is ViewBase)
            {
                ViewBase cr = (ViewBase)TheControl;
                cr.CloseRequest -= new CloseHandler(cr_CloseRequest);
            }

            Controls.Remove(TheControl);
        }
        public void Lock()
        {
            Locked = true;
            ImageKey = "lock";
        }
        public void UnLock()
        {
            Locked = false;
            ImageKey = "";
        }
        public bool IsValid
        {
            get
            {
                return TopLevelControl != null && TheControl != null;
            }
        }
        private void CutPicClick()
        {
            if (picclick != null)
            {
                if( pic != null )
                    pic.Click -= picclick;
    
                picclick = null;
            }
        }
        private void LoadPic()
        {
            try
            {
                //Assembly _assembly;
                //Stream _imageStream;
                //_assembly = Assembly.GetExecutingAssembly();
                //_imageStream = _assembly.GetManifestResourceStream("<nm>.Original.graphics.step-out1.png");
                //Image i = new Bitmap(_imageStream);
                pic = new PictureBox();
                pic.BackColor = System.Drawing.Color.LightBlue;  //white
                //pic.Width = i.Width;
                //pic.Height = i.Height;
                pic.Width = 8;
                pic.Height = 8;


                CutPicClick();
                picclick = new EventHandler(pic_Click);
                pic.Click += picclick;
                //pic.Image = i;
                this.Controls.Add(pic);
                pic.BringToFront();
                this.tip.SetToolTip(this.pic, "Open this tab in a separate window");
                DoResize();
            }
            catch (Exception)
            { }
        }
        void pic_Click(object sender, EventArgs e)
        {
            if (ShowExternal != null)
                ShowExternal(this);
        }
        public bool SendCloseRequest(object sender, CloseArgs e)
        {
            if (CloseRequest == null)
                return false;

            CloseRequest(this, e);
            return true;
        }
        public void General_CloseRequest(object sender, CloseArgs e)
        {
            if (CloseRequest != null)
            {
                CloseArgs c = new CloseArgs();
                CloseRequest(this, c);
                if (c.Handled)
                    return;
            }

            MyTabControl.TabPages.Remove(this);
        }
        public virtual void DoResize()
        {
            if (pic != null)
            {
                pic.Left = this.ClientRectangle.Width - pic.Width;
                pic.Top = this.ClientRectangle.Height - pic.Height;
            }

            if (TheControl != null)
            {
                TheControl.Left = 0;
                TheControl.Top = 0;
                TheControl.Width = this.ClientRectangle.Width;
                TheControl.Height = this.ClientRectangle.Height;
            }
        }
        private void TabPageCore_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TabPageCore
            // 
            this.Resize += new System.EventHandler(this.TabPageCore_Resize);
            this.ResumeLayout(false);

        }
        public bool HasTheFocus
        {
            get
            {
                if( MyTabControl == null )
                    return false;

                if( !IsValid )
                    return false;

                try
                {
                    return MyTabControl.SelectedTab == this;
                }
                catch
                {
                    return false;
                }
            }
        }
        public void SetCaption(string caption)
        {
            if (!Tools.Strings.StrExt(caption))
                return;
            this.Text = caption;
            TabID = caption.ToLower().Replace(" ", "").Trim();
        }
    }
}

