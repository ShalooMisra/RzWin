using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewMethod;


namespace Rz5
{
    public interface IProcessControl
    {
        void CompleteLoad(nObject obj);
        Boolean CompleteSave();
        void SetCount(Int32 count);
        void SetFocus();
        void SetQtyFocus();
        Int32 GetTop();
        void SetTop(Int32 top);
        Int32 GetLeft();
        void SetLeft(Int32 top);
        void DoResize();
        Int32 GetMinHeight();
        Int32 GetMinWidth();
        nObject GetMainObject();
    }

    public partial class ProcessControlView : UserControl
    {
        private String sGBText = "";
        private Boolean bBottomOfScreen = false;
        private Boolean bShowOptions = false;
        private Int32 iTopMargin = 15;
        private Int32 iBottomMargin = 7;
        private Int32 iLeftMargin = 5;
        private Int32 iControlGap = 2;
        private Double dProcessControlHeight = 0;
        private Int32 dProcessControlViewableCount = 0;
        private Dictionary<Int32, IProcessControl> dControls;

        public ProcessControlView()
        {
            InitializeComponent();
        }
        public void CompleteLoad()
        {
            dControls = new Dictionary<Int32, IProcessControl>();
            SetLabel();
            DoResize();
        }
        public String GBText
        {
            get
            {
                return sGBText;
            }
            set
            {
                sGBText = value;
                GB.Text = sGBText;
            }
        }
        public Boolean BottomOfScreen
        {
            get
            {
                return bBottomOfScreen;
            }
            set
            {
                bBottomOfScreen = value;
                DoResize();
            }
        }
        public Boolean ShowOptions
        {
            get
            {
                return bShowOptions;
            }
            set
            {
                bShowOptions = value;
                DoResize();
            }
        }
        public Int32 TopMargin
        {
            get
            {
                return iTopMargin;
            }
            set
            {
                iTopMargin = value;
                iBottomMargin = iTopMargin / 2;
                DoResize();
            }
        }
        public Int32 LeftMargin
        {
            get
            {
                return iLeftMargin;
            }
            set
            {
                iLeftMargin = value;
                DoResize();
            }
        }
        public Int32 ControlGap
        {
            get
            {
                return iControlGap;
            }
            set
            {
                iControlGap = value;
            }
        }
        //Public Functions
        public void InsertProcessControl(IProcessControl xControl)
        {
            if (xControl == null)
                return;
            SetNewControl(xControl);
            SetLabel();
            SetScrollBar();
            DisplayControls();
        }
        public void ClearControlCollection()
        {
            dControls = new Dictionary<int, IProcessControl>();
            GB.Controls.Clear();
            SetLabel();
            SetScrollBar(); 
        }
        public void DoResize()
        {
            try
            {
                cmdOptions.Top = 0;
                cmdOptions.Left = this.Width - cmdOptions.Width;
                if (bShowOptions)
                    VS.Top = cmdOptions.Bottom;
                else
                    VS.Top = 0;
                if (bBottomOfScreen)
                {
                    if (bShowOptions)
                        VS.Height = this.Height - (15 + cmdOptions.Height);
                    else
                        VS.Height = this.Height - 15;
                }
                else
                {
                    if (bShowOptions)
                        VS.Height = this.Height - cmdOptions.Height;
                    else
                        VS.Height = this.Height;
                }
                VS.Left = this.Width - VS.Width;
                VS.BringToFront();
                GB.Top = -2;
                GB.Left = 0;
                GB.Width = this.Width - (VS.Width + 2);
                GB.Height = this.Height;
                lblCount.Top = -2;
                lblCount.Left = GB.Width - (lblCount.Width + 5);
                DisplayControls();
                SetScrollBar();
            }
            catch (Exception)
            { }
        }
        public Dictionary<Int32, IProcessControl> GetProcessControlsDictionary()
        {
            return dControls;
        }
        public ArrayList GetProcessControlsArray()
        {
            ArrayList a = new ArrayList();
            foreach (KeyValuePair<Int32, IProcessControl> kvp in dControls)
            {
                a.Add(kvp.Value);
            }
            return a;
        }
        public ArrayList GetMainObjectArray()
        {
            ArrayList a = new ArrayList();
            foreach (KeyValuePair<Int32, IProcessControl> kvp in dControls)
            {
                a.Add(kvp.Value.GetMainObject());
            }
            return a;
        }
        //Private Functions
        private void DisplayControls()
        {
            GB.Controls.Clear();
            IProcessControl ctrl;
            Boolean bIn = false;
            for (Int32 x = 1; x <= dControls.Count; x++)
            {
                if (!bIn)
                {
                    dControls.TryGetValue(x, out ctrl);
                    CalculateControlDimensions(ctrl, true);
                    bIn = true;
                }
                if (x - 1 >= VS.Value && x <= VS.Value + dProcessControlViewableCount)
                {
                    dControls.TryGetValue(x, out ctrl);
                    SetViewableControl(ctrl);
                }
            }
        }
        private void SetNewControl(IProcessControl ctrl)
        {
            Int32 i = dControls.Count + 1;
            ctrl.SetCount(i);
            dControls.Add(i, ctrl);
            ((Control)ctrl).Visible = false;
            GB.Controls.Add((Control)ctrl);
            GB.Controls.Remove((Control)ctrl);
            ((Control)ctrl).Visible = true;
        }
        private void SetScrollBar()
        {
            if (dControls == null)
            {
                VS.Maximum = 0;
                VS.Value = 0;
                return;
            }
            Int32 iMax = dControls.Count - dProcessControlViewableCount;
            if (iMax < 0)
                iMax = 0;
            if (dProcessControlViewableCount <= 0)
                iMax = 0;
            VS.Maximum = iMax;
            VS.Value = 0;
        }
        private void SetLabel()
        {
            lblCount.Text = "0";
            if(dControls!=null)
                lblCount.Text = dControls.Count.ToString();
        }
        private void CalculateControlDimensions(IProcessControl xControl)
        {
            CalculateControlDimensions(xControl, false);
        }
        private void CalculateControlDimensions(IProcessControl xControl, Boolean bRunAlways)
        {
            try
            {
                if (dControls == null)
                    return;
                if (dControls.Count <= 0 || dControls.Count > 1)
                {
                    if (!bRunAlways)
                        return;
                }
                if (xControl == null)
                    return;
                Double totalheight = (Double)GB.Height;
                if (totalheight > 205)
                {
                    totalheight = totalheight;
                }
                Double controlminheight = (Double)xControl.GetMinHeight() + (Double)iControlGap;
                Double countofviewablecontrols = (totalheight - ((Double)iTopMargin * 2)) / controlminheight;
                dProcessControlViewableCount = (Int32)countofviewablecontrols;
                Int32 leftover = GB.Height - (iTopMargin + iBottomMargin);
                leftover = leftover - ((Int32)controlminheight * dProcessControlViewableCount);
                dProcessControlHeight = (Double)xControl.GetMinHeight() + ((Double)(leftover / dProcessControlViewableCount));
            }
            catch(Exception)
            {}
        }
        private void SetViewableControl(IProcessControl ctrl)
        {
            try
            {
                Int32 index;
                index = GB.Controls.Count + 1;
                if (index == 1)
                {
                    ((Control)ctrl).Top = iTopMargin;
                    ((Control)ctrl).Left = iLeftMargin;
                    ((Control)ctrl).Width = GB.Width - (iLeftMargin * 2);
                }
                else
                {
                    Control c = GetControlByIndex(GB.Controls.Count);
                    if (c != null)
                    {
                        ((Control)ctrl).Top = c.Bottom + iControlGap;
                        ((Control)ctrl).Left = iLeftMargin;
                        ((Control)ctrl).Width = GB.Width - (iLeftMargin * 2);
                    }
                }
                ((Control)ctrl).Height = (Int32)dProcessControlHeight;
                ((Control)ctrl).Visible = true;
                ctrl.DoResize();
                GB.Controls.Add(((Control)ctrl));
            }
            catch (Exception)
            { }
        }
        private Control GetControlByIndex(Int32 index)
        {
            Int32 x = 0;
            Control ctrl = null;
            foreach (Control c in GB.Controls)
            {
                x++;
                ctrl = c;
                if (x == index)
                    return ctrl;
            }
            return null;
        }
        private Boolean IsProcessControl(Control c)
        {
            try
            {
                IProcessControl p = (IProcessControl)c;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Control Events
        private void ProcessControlView_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void VS_Scroll(object sender, ScrollEventArgs e)
        {
            DisplayControls();
        }
    }
}
