using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public delegate void nLineHandler(nLine l, nObject xObject, bool delete);

    public partial class nLine : UserControl
    {
        public ContextNM TheContext
        {
            get
            {
                return NMWin.ContextDefault;
            }
        }
        public int CommandLeft = 0;

        public event EventHandler ReloadRequest;
        public void FireReloadRequest()
        {
            if (ReloadRequest != null)
                ReloadRequest(this, null);
        }

        public event nLineHandler CloseRequest;
        public void FireCloseRequest(bool delete)
        {
            if (CloseRequest != null)
                CloseRequest(this, CurrentObject, delete);
        }

        public event nLineHandler ExpandedChanged;
        public void FireExpandedChanged()
        {
            if (ExpandedChanged != null)
                ExpandedChanged(this, null, false);
        }

        public event EventHandler SavedObject;
        protected void FireSavedObject()
        {
            if (SavedObject != null)
                SavedObject(this, null);
        }

        nObject m_CurrentObject = null;
        public nObject CurrentObject
        {
            get
            {
                return m_CurrentObject;
            }

            set
            {
                m_CurrentObject = value;
            }
        }
        bool m_IsExpanded = false;
        public bool IsExpanded
        {
            get
            {
                return m_IsExpanded;
            }

            set
            {
                m_IsExpanded = value;
            }
        }
        public int OriginalHeight = 0;

        public nLine()
        {
            InitializeComponent();
            if( OriginalHeight == 0 )
                OriginalHeight = this.Height;
            ShowExpanded();
        }

        public virtual void InitUn()
        {
            try
            {
                pic.Image = null;
            }
            catch { }
        }

        public bool m_AllowExpand = false;
        public bool AllowExpand
        {
            get
            {
                return m_AllowExpand;
            }

            set
            {
                m_AllowExpand = value;
                picExpand.Visible = m_AllowExpand;
            }
        }

        public bool m_HideControlBox = false;
        public virtual bool HideControlBox
        {
            get
            {
                return m_HideControlBox;
            }

            set
            {
                m_HideControlBox = value;
                pCommands.Visible = !m_HideControlBox;
                picTop.Visible = !m_HideControlBox;
                picLeft.Visible = !m_HideControlBox;
                picRight.Visible = !m_HideControlBox;
                picBottom.Visible = !m_HideControlBox;
            }
        }

        private void nLine_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public virtual void DoResize()
        {
            try
            {
                if (CommandLeft == 0)
                    pCommands.Left = this.ClientRectangle.Width - (pCommands.Width + 2);
                else
                    pCommands.Left = CommandLeft;

                picTop.Dock = DockStyle.Top;
                picLeft.Dock = DockStyle.Left;
                picRight.Dock = DockStyle.Right;
                picBottom.Dock = DockStyle.Bottom;
                pic.Height = this.ClientRectangle.Height - 4;

                picExpand.Left = picLeft.Width;
                picExpand.Top = this.ClientRectangle.Height - (picExpand.Height + picBottom.Height);

            }
            catch { }
        }

        public void SetImage(Image i)
        {
            pic.Image = i;
        }

        public void SetColor(Color c)
        {
            picLeft.BackColor = c;
            picRight.BackColor = c;
            picTop.BackColor = c;
            picBottom.BackColor = c;
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {   
            try
            {
                CompleteSave();
            }
            catch (Exception ex)
            {
                NMWin.ContextDefault.Leader.Tell(ex.Message);
            }
        }

        private void cmdSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                CompleteSave();
                FireCloseRequest(false);
            }
            catch (Exception ex)
            {
                NMWin.ContextDefault.Leader.Tell(ex.Message);
            }
        }

        public virtual void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentObject, null);
            NMWin.ContextDefault.TheDelta.Update(NMWin.ContextDefault, CurrentObject);
            FireSavedObject();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (!NMWin.Leader.AreYouSure("delete " + CurrentObject.ToString()))
                return;
            NMWin.ContextDefault.Delete(CurrentObject);            
            FireCloseRequest(true);
        }

        private void cmdClip_Click(object sender, EventArgs e)
        {
            if (CurrentObject != null)
            {
                if (NMWin.User != null)
                    NMWin.User.AddClipObject(NMWin.ContextDefault, CurrentObject, true);
            }
        }

        public virtual void ShowExpanded()
        {
            if( IsExpanded )
                picExpand.BackgroundImage = imExpand.Images["up"];
            else
                picExpand.BackgroundImage = imExpand.Images["down"];
        }

        public virtual void DoExpand()
        {
            IsExpanded = !IsExpanded;
            ShowExpanded();
            FireExpandedChanged();
        }

        private void picExpand_Click(object sender, EventArgs e)
        {
            DoExpand();
        }

        public virtual void ReSetFocus()
        {

        }

        private void cmdNotes_Click(object sender, EventArgs e)
        {
            MakeNote();
        }

        public virtual void MakeNote()
        {

        }

        public virtual void HeightInit()
        {

        }
    }

    public interface InLine : IDisposable
    {
        int Left { get; set; }
        int Top { get; set; }
        int Width { get; set; }
        void SetImage(Image i);
        bool IsExpanded { get; set; }
        void CompleteSave();
        nObject CurrentObject { get; set; }
        void HeightInit();
    }
}
