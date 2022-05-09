using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod.Views.Edits
{
    public partial class nEdit_Label : NewMethod.nEdit
    {
        public nEdit_Label()
        {
            InitializeComponent();
        }
        //Properties
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
                return lblValue.Font;
            }
            set
            {
                lblValue.Font = value;
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
                return lblValue.ForeColor;
            }
            set
            {
                lblValue.ForeColor = value;
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
        public String zz_Text
        {
            get
            {
                return lblValue.Text;
            }
            set
            {
                lblValue.Text = value;
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
        public ContentAlignment zz_TextAlign
        {
            get
            {
                return lblValue.TextAlign;
            }
            set
            {
                lblValue.TextAlign = value;
            }
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
        public Color zz_CaptionLabelBackColor
        {
            get
            {
                return lblCaption.BackColor;
            }
            set
            {
                lblCaption.BackColor = value;
                DoResize();
            }
        }
        public Color zz_ValueLabelBackColor
        {
            get
            {
                return lblValue.BackColor;
            }
            set
            {
                lblValue.BackColor = value;
                DoResize();
            }
        }
        //Public Override Functions
        public override void DoResize()
        {
            try
            {
                if (m_OriginalDesign)
                {
                    try
                    {
                        lblValue.Left = 0;
                        lblValue.Width = this.ClientRectangle.Width;
                        base.DoResize();
                    }
                    catch (Exception)
                    { }
                }
                else
                {
                    base.DoResize();
                    lblValue.AutoSize = true;
                    Int32 vW = lblValue.Width;
                    lblValue.AutoSize = false;
                    picError.Visible = false;
                    picInfo.Visible = false;
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
                            lblValue.Left = 0;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                            {
                                top = 0;
                                lblValue.BringToFront();
                            }
                            lblValue.Top = top + 1;
                            lblValue.Width = this.Width;
                            this.Height = lblValue.Bottom + 1;
                            break;
                        case LabelLocations.Left:
                            lblCaption.Top = 0;
                            lblCaption.Left = -2;
                            lblCaption.AutoSize = true;
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            lblValue.Top = 0;
                            Int32 left = lblCaption.Right + 1;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                left = 0;
                            lblValue.Left = left;
                            lblValue.Width = this.Width - lblValue.Left;
                            h1 = lblValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                lblValue.Top = (h2 - h1) / 2;
                            this.Height = height + 1;
                            if (this.Width <= lblCaption.Width + vW)
                                this.Width = lblCaption.Width + vW + 2;
                            break;
                        case LabelLocations.Right:
                            lblCaption.AutoSize = true;
                            lblCaption.Top = 0;
                            lblCaption.Left = this.Width - (lblCaption.Width - 2);
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            lblValue.Top = 0;
                            lblValue.Left = 0;
                            Int32 width = lblCaption.Left - lblValue.Left;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                width = this.Width - lblValue.Left;
                            lblValue.Width = width;
                            h1 = lblValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                lblValue.Top = (h2 - h1) / 2;
                            this.Height = height + 1;
                            if (this.Width <= lblCaption.Width + vW)
                                this.Width = lblCaption.Width + vW + 2;
                            break;
                        case LabelLocations.BottomLeft:
                        case LabelLocations.BottomCenter:
                        case LabelLocations.BottomRight:
                            lblValue.Top = 0;
                            lblCaption.Left = -2;
                            lblCaption.AutoSize = true;
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            top = lblValue.Bottom;
                            height = lblCaption.Height;
                            lblCaption.AutoSize = false;
                            lblCaption.Width = this.Width + 2;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            lblCaption.Height = height;
                            lblValue.Left = 0;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                            {
                                top = 0;
                                lblValue.BringToFront();
                            }
                            lblCaption.Top = top + 1;
                            lblValue.Width = this.Width;
                            this.Height = lblCaption.Bottom + 1;
                            break;
                    }
                }
            }
            catch { }
        }
        public override void SetValue(object o)
        {
            if (o == null)
                lblValue.Text = "";
            else
                lblValue.Text = o.ToString();
        }
        public override object GetValue()
        {
            return lblValue.Text; 
        }
        public String GetValue_String()
        {
            return lblValue.Text;
        }
        //Private Functions
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
        //Control Events
        private void nEdit_Label_Resize(object sender, EventArgs e)
        {
            DoResize();
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

