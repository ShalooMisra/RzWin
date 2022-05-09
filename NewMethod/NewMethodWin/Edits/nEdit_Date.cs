using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nEdit_Date : NewMethod.nEdit
    {
        private DateTime m_value = Tools.Dates.GetNullDate();
        private ToolTip tTip = null;
        private String strLastDate = "";
        private bool bNoDateClick = false;

        public nEdit_Date()
        {
            InitializeComponent();
            SetValue(Tools.Dates.GetNullDate());
        }
        //Properties
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
        private bool m_AllowClear = false;
        public bool AllowClear
        {
            get
            {
                return m_AllowClear;
            }
            set
            {
                m_AllowClear = value;
                lblClear.Visible = m_AllowClear;
                lblClear.BringToFront();
                DoResize();
            }
        }
        private bool m_SuppressEdit = false;
        public bool SuppressEdit
        {
            get
            {
                return m_SuppressEdit;
            }
            set
            {
                m_SuppressEdit = value;
            }
        }
        public Boolean zz_ShowNeedsSaveColor
        {
            get
            {
                return m_ShowNeedsSaveColor;
            }
            set
            {
                m_ShowNeedsSaveColor = value;
                DoResize();
            }
        }
        private Boolean m_ShowNeedsSaveColor = true;
        public Boolean zz_OriginalDesign
        {
            get
            {
                return m_OriginalDesign;
            }
            set
            {
                m_OriginalDesign = value;
                DoResize();
            }
        }
        private Boolean m_OriginalDesign = true;
        public Font zz_TextFont
        {
            get
            {
                return dt.Font;
            }
            set
            {
                dt.Font = value;
                lblFixed.Font = value;
                lblNoDate.Font = value;
                DoResize();
            }
        }
        private bool m_UseGlobalFont = false;
        public Boolean zz_UseGlobalFont
        {
            get
            {
                return m_UseGlobalFont;
            }
            set
            {
                m_UseGlobalFont = value;
                if (m_UseGlobalFont)
                {
                    zz_TextFont = GlobalFont;
                    zz_LabelFont = GlobalFont;
                    DoResize();
                }
            }
        }
        private Font GlobalFont = new Font(FontFamily.GenericSansSerif, 8);
        public Font zz_GlobalFont
        {
            get
            {
                return GlobalFont;
            }
            set
            {
                GlobalFont = value;
                if (m_UseGlobalFont)
                {
                    zz_TextFont = value;
                    zz_LabelFont = value;
                }
                DoResize();
            }
        }
        public Color zz_TextColor
        {
            get
            {
                return dt.ForeColor;
            }
            set
            {
                dt.ForeColor = value;
                DoResize();
            }
        }
        private bool m_UseGlobalColor = false;
        public Boolean zz_UseGlobalColor
        {
            get
            {
                return m_UseGlobalColor;
            }
            set
            {
                m_UseGlobalColor = value;
                if (m_UseGlobalColor)
                {
                    zz_TextColor = GlobalColor;
                    zz_LabelColor = GlobalColor;
                    DoResize();
                }
            }
        }
        private Color GlobalColor = Color.Black;
        public Color zz_GlobalColor
        {
            get
            {
                return GlobalColor;
            }
            set
            {
                GlobalColor = value;
                if (m_UseGlobalColor)
                {
                    zz_TextColor = value;
                    zz_LabelColor = value;
                }
                DoResize();
            }
        }
        private LabelLocations m_LabelLocation = LabelLocations.TopLeft;
        public LabelLocations zz_LabelLocation
        {
            get
            {
                return m_LabelLocation;
            }
            set
            {
                m_LabelLocation = value;
                DoResize();
            }
        }
        //Public Override Functions
        public override void DoResize()
        {
            if (m_OriginalDesign)
            {
                try
                {
                    dt.Left = 0;
                    dt.Width = Convert.ToInt32(this.ClientRectangle.Width * 0.8);
                    //if (AllowClear)
                    //    this.Height = lblClear.Bottom;
                    base.DoResize();
                }
                catch (Exception)
                { }
            }
            else
            {
                lblFixed.Visible = false;
                lbl.Visible = false;
                lblClear.Visible = false;
                picInfo.Visible = false;
                picError.Visible = false;
                base.DoResize();
                Int32 top = 0;
                Int32 height = 0;
                Int32 h1 = 0;
                Int32 h2 = 0;
                switch (m_LabelLocation)
                {
                    case LabelLocations.TopLeft:
                    case LabelLocations.TopCenter:
                    case LabelLocations.TopRight:
                        lblCaption.Top = 0;
                        lblCaption.Left = -2;
                        lblCaption.AutoSize = true;
                        if (this.Width < lblCaption.Width + 2)
                            this.Width = lblCaption.Width + 4;
                        top = lblCaption.Bottom;
                        height = lblCaption.Height;
                        lblCaption.AutoSize = false;
                        lblCaption.Width = this.Width + 2;
                        lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                        lblCaption.Height = height;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Left = 0;
                            dt.Left = pChanged.Left + 3;
                            lblFixedDate.Left = dt.Left;
                            lblNoDate.Left = dt.Left;

                        }
                        else
                        {
                            dt.Left = 0;
                            lblFixedDate.Left = dt.Left;
                            lblNoDate.Left = dt.Left;

                        }
                        if (!Tools.Strings.StrExt(lblCaption.Text))
                        {
                            top = 0;
                            dt.BringToFront();
                        }
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = top + 1;
                            dt.Top = pChanged.Top + 3;
                            pChanged.Width = this.Width;
                            dt.Width = pChanged.Width - 6;
                            lblFixedDate.Top = dt.Top;
                            lblNoDate.Top = dt.Top;
                            lblFixedDate.Width = dt.Width;
                            lblNoDate.Width = dt.Width;
                            lblFixedDate.Height = dt.Height;
                            lblNoDate.Height = dt.Height;
                            pChanged.Height = dt.Height + 6;
                            this.Height = pChanged.Bottom + 1;
                        }
                        else
                        {
                            dt.Top = top + 1;
                            dt.Width = this.Width;
                            lblFixedDate.Top = dt.Top;
                            lblNoDate.Top = dt.Top;
                            lblFixedDate.Width = dt.Width;
                            lblNoDate.Width = dt.Width;
                            lblFixedDate.Height = dt.Height;
                            lblNoDate.Height = dt.Height;
                            this.Height = dt.Bottom + 1;
                        }

                        //if (AllowClear)
                        //    this.Height = lblClear.Bottom;

                        break;
                    case LabelLocations.Left:
                        lblCaption.Top = 0;
                        lblCaption.Left = -2;
                        lblCaption.AutoSize = true;
                        if (this.Width < lblCaption.Width + 2)
                            this.Width = lblCaption.Width + 4;
                        lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = 0;
                            dt.Top = pChanged.Top + 3;
                            lblFixedDate.Top = dt.Top;
                            lblNoDate.Top = dt.Top;
                        }
                        else
                        {
                            dt.Top = 0;
                            lblFixedDate.Top = 0;
                            lblNoDate.Top = 0;
                        }
                        Int32 left = lblCaption.Right + 1;
                        if (!Tools.Strings.StrExt(lblCaption.Text))
                            left = 0;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Left = left;
                            dt.Left = pChanged.Left + 3;
                            lblFixedDate.Left = dt.Left;
                            lblNoDate.Left = dt.Left;
                            pChanged.Width = this.Width - pChanged.Left;
                            dt.Width = pChanged.Width - 6;
                            lblFixedDate.Width = dt.Width;
                            lblNoDate.Width = dt.Width;
                        }
                        else
                        {
                            dt.Left = left;
                            lblFixedDate.Left = left;
                            lblNoDate.Left = left;
                            dt.Width = this.Width - dt.Left;
                            lblFixedDate.Width = dt.Width;
                            lblNoDate.Width = dt.Width;
                        }
                        pChanged.Height = dt.Height + 6;
                        h1 = (m_ShowNeedsSaveColor) ? pChanged.Height : dt.Height;
                        h2 = lblCaption.Height;
                        height = (h1 >= h2) ? h1 : h2;
                        if (h1 >= h2)
                            lblCaption.Top = (h1 - h2) / 2;
                        else
                        {
                            if (m_ShowNeedsSaveColor)
                            {
                                pChanged.Top = (h2 - h1) / 2;
                                dt.Top = pChanged.Top + 3;
                            }
                            else
                            {
                                dt.Top = (h2 - h1) / 2;
                            }
                        }
                        lblFixedDate.Top = dt.Top;
                        lblNoDate.Top = dt.Top;
                        lblFixedDate.Height = dt.Height;
                        lblNoDate.Height = dt.Height;
                        this.Height = height + 1;
                        break;
                    case LabelLocations.Right:
                        lblCaption.AutoSize = true;
                        lblCaption.Top = 0;
                        lblCaption.Left = this.Width - (lblCaption.Width - 2);
                        if (this.Width < lblCaption.Width + 2)
                            this.Width = lblCaption.Width + 4;
                        lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = 0;
                            dt.Top = pChanged.Top + 3;
                            pChanged.Left = 0;
                            dt.Left = pChanged.Left + 3;
                            lblFixedDate.Top = dt.Top;
                            lblNoDate.Top = dt.Top;
                            lblFixedDate.Left = dt.Left;
                            lblNoDate.Left = dt.Left;
                        }
                        else
                        {
                            dt.Top = 0;
                            dt.Left = 0;
                            lblFixedDate.Top = 0;
                            lblNoDate.Top = 0;
                            lblFixedDate.Left = 0;
                            lblNoDate.Left = 0;
                        }
                        Int32 width = lblCaption.Left - ((m_ShowNeedsSaveColor) ? pChanged.Left : dt.Left);
                        if (!Tools.Strings.StrExt(lblCaption.Text))
                            width = this.Width - ((m_ShowNeedsSaveColor) ? pChanged.Left : dt.Left);
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Width = width;
                            dt.Width = pChanged.Width - 6;
                        }
                        else
                            dt.Width = width;
                        lblFixedDate.Width = dt.Width;
                        lblNoDate.Width = dt.Width;
                        pChanged.Height = dt.Height + 6;
                        h1 = ((m_ShowNeedsSaveColor) ? pChanged.Height : dt.Height);
                        h2 = lblCaption.Height;
                        height = (h1 >= h2) ? h1 : h2;
                        if (h1 >= h2)
                            lblCaption.Top = (h1 - h2) / 2;
                        else
                        {
                            if (m_ShowNeedsSaveColor)
                            {
                                pChanged.Top = (h2 - h1) / 2;
                                dt.Top = pChanged.Top + 3;
                            }
                            else
                                dt.Top = (h2 - h1) / 2;
                        }
                        lblFixedDate.Top = dt.Top;
                        lblNoDate.Top = dt.Top;
                        lblFixedDate.Height = dt.Height;
                        lblNoDate.Height = dt.Height;
                        this.Height = height + 1;
                        break;
                    case LabelLocations.BottomLeft:
                    case LabelLocations.BottomCenter:
                    case LabelLocations.BottomRight:
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = 0;
                            dt.Top = pChanged.Top + 3;
                            lblFixedDate.Top = dt.Top;
                            lblNoDate.Top = dt.Top;
                        }
                        else
                            dt.Top = 0;
                        lblCaption.Left = -2;
                        lblCaption.AutoSize = true;
                        if (this.Width < lblCaption.Width + 2)
                            this.Width = lblCaption.Width + 4;
                        pChanged.Height = dt.Height + 6;
                        if (m_ShowNeedsSaveColor)
                            top = pChanged.Bottom;
                        else
                            top = dt.Bottom;
                        height = lblCaption.Height;
                        lblCaption.AutoSize = false;
                        lblCaption.Width = this.Width + 2;
                        lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                        lblCaption.Height = height;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Left = 0;
                            dt.Left = pChanged.Left + 3;
                        }
                        else
                            dt.Left = 0;
                        lblFixedDate.Left = dt.Left;
                        lblNoDate.Left = dt.Left;
                        if (!Tools.Strings.StrExt(lblCaption.Text))
                        {
                            top = 0;
                            dt.BringToFront();
                        }
                        lblCaption.Top = top + 1;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Width = this.Width;
                            dt.Width = pChanged.Width - 6;
                        }
                        else
                            dt.Width = this.Width;
                        lblFixedDate.Width = dt.Width;
                        lblNoDate.Width = dt.Width;
                        lblFixedDate.Height = dt.Height;
                        lblNoDate.Height = dt.Height;
                        this.Height = lblCaption.Bottom + 1;
                        break;
                }
                if (Tools.Strings.StrExt(lblCaption.Text) && (lblCaption.Top > dt.Top))
                {
                    cmdLink.Top = dt.Top + 1;
                    cmdLink.Left = dt.Right - (cmdLink.Width + 1);
                }
                else
                {
                    cmdLink.Top = dt.Top - 2;
                    cmdLink.Left = dt.Right - 8;
                }
                if (this.Width < 105)
                    this.Width = 105;
            }
        }
        public override object GetValue()
        {
            return (Object)m_value;
        }
        public override void SetValue(object o)
        {
            if (m_SuppressEdit)
            {
                if (m_OriginalDesign)
                {
                    dt.Visible = false;
                    lbl.Visible = false;
                    lblFixed.Visible = true;
                    if (o == null)
                        lblFixed.Text = "<No Date>";
                    else
                        lblFixed.Text = nTools.DateFormat_Extra((DateTime)o);
                }
                else
                {
                    dt.Visible = false;
                    lblNoDate.Visible = false;
                    lblFixedDate.Visible = true;
                    lblFixedDate.BringToFront();
                    if (o == null)
                        lblFixedDate.Text = "<No Date>";
                    else
                        lblFixedDate.Text = nTools.DateFormat_Extra((DateTime)o);
                }
            }
            else
            {
                lblFixed.Visible = false;
                try
                {
                    if (!Tools.Dates.DateExists(Convert.ToDateTime(o)))
                    {
                        SetNoDate();
                    }
                    else
                    {
                        if (m_OriginalDesign)
                        {
                            lbl.Visible = false;
                            dt.Visible = true;
                            m_value = Convert.ToDateTime(o);
                            dt.Value = m_value;
                            if (m_AllowClear)
                                lblClear.Visible = true;
                        }
                        else
                        {
                            dt.Visible = true;
                            lblFixedDate.Visible = false;
                            lblNoDate.Visible = false;
                            m_value = Convert.ToDateTime(o);
                            dt.Value = m_value;
                            if (m_AllowClear)
                                cmdLink.Visible = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    SetNoDate();
                }
            }
            Changed = false;
        }
        public override void SetStyle(nStyle s)
        {
            dt.Font = s.xFont;
        }
        public override void SetInfo(String s)
        {
            if (m_ShowNeedsSaveColor)
            {
                if (!Tools.Strings.StrCmp(strLastDate, dt.Value.ToShortDateString()) || bNoDateClick)
                {
                    picInfo.Visible = false;
                    pChanged.Visible = true;
                    pChanged.SendToBack();
                    if (tTip == null)
                    {
                        tTip = toolTip1;
                        tTip.SetToolTip(dt, "Value has been changed, but not saved.");
                    }
                }
                else
                {
                    ClearInfo();
                }
            }
        }
        public override void ClearInfo()
        {
            if (bNoDateClick)
            {
                bNoDateClick = false;
                return;
            }
            picInfo.Visible = false;
            pChanged.Visible = false;
            if (lblNoDate.Visible)
                strLastDate = "";
            else
                strLastDate = dt.Value.ToShortDateString();
            if (tTip != null)
                tTip.SetToolTip(dt, "");
            tTip = null;
        }
        //Public Functions
        public DateTime GetValue_Date()
        {
            return (DateTime)GetValue();
        }
        public void ClearDate()
        {
            SetNoDate();
            if (!Tools.Strings.StrExt(strLastDate))
                ClearInfo();
        }
        //Private Functions
        private void SetNoDate()
        {
            if (m_OriginalDesign)
            {
                lbl.Visible = true;
                lblClear.Visible = false;
                dt.Visible = false;
                m_value = Tools.Dates.GetNullDate();
            }
            else
            {
                dt.Visible = false;
                cmdLink.Visible = false;
                lblNoDate.BringToFront();
                lblNoDate.Visible = true;
                lblFixedDate.Visible = false;
                m_value = Tools.Dates.GetNullDate();
            }
        }
        private void ShowLinks()
        {
            mnu.Show(System.Windows.Forms.Cursor.Position);
        }
        private ContentAlignment GetAlignment(LabelLocations l)
        {
            switch (l)
            {
                case LabelLocations.TopLeft:
                case LabelLocations.BottomLeft:
                    return ContentAlignment.TopLeft;
                case LabelLocations.TopCenter:
                case LabelLocations.BottomCenter:
                    return ContentAlignment.TopCenter;
                case LabelLocations.TopRight:
                case LabelLocations.BottomRight:
                    return ContentAlignment.TopRight;
                case LabelLocations.Left:
                case LabelLocations.Right:
                    return ContentAlignment.TopLeft;
                default:
                    return ContentAlignment.TopLeft;
            }
        }
        //Buttons
        private void cmdLink_Click(object sender, EventArgs e)
        {
            ShowLinks();
        }
        //Menus
        private void clearDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearDate();
        }
        //Control Events
        private void dt_ValueChanged(object sender, EventArgs e)
        {
            if (m_OriginalDesign)
            {
                Changed = true;
                m_value = dt.Value;
                NeedSave();
                RaiseChangedEvent();
            }
            else
            {
                Changed = true;
                NeedSave();
                RaiseChangedEvent();
                m_value = dt.Value;
            }
        }
        private void dt_DropDown(object sender, EventArgs e)
        {
            if (ToolsWin.Keyboard.GetControlAndShiftKeys())
            {
                SetNoDate();
            }
            else
            {
                if (!Tools.Dates.DateExists(dt.Value))
                    dt.Value = System.DateTime.Now;
            }
        }
        private void lbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            dt.Visible = true;
            lbl.Visible = false;
            SetValue(System.DateTime.Now);
            RaiseChangedEvent();
            //System.Windows.Forms.Message.Create(dt.Handle, System.Windows.Forms.
        }
        private void nEdit_Date_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lblClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetNoDate();
        }
        private void lblNoDate_Click(object sender, EventArgs e)
        {
            bNoDateClick = true;
            dt.Visible = true;
            lblFixedDate.Visible = false;
            lblNoDate.Visible = false;
            SetValue(System.DateTime.Now);
            Changed = true;
        }
        private void lbl_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        //Enums
        public enum LabelLocations
        {
            TopLeft = 0,
            TopCenter = 1,
            TopRight = 2,
            Left = 3,
            Right = 4,
            BottomLeft = 5,
            BottomCenter = 6,
            BottomRight = 7
        }
    }
}

