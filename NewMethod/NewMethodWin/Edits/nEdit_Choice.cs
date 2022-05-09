using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Core;
using Tools.Database;

namespace NewMethod
{
    public partial class nEdit_Choice : NewMethod.nEdit
    {
        private bool AllowType = true;
        private ToolTip tTip = null;
        private String strLastValue = "";

        public nEdit_Choice()
        {
            InitializeComponent();
            LoadImages();
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
                return cboValue.Font;
            }
            set
            {
                cboValue.Font = value;
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
                return cboValue.ForeColor;
            }
            set
            {
                cboValue.ForeColor = value;
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
        public Boolean zz_ShowNeedsSaveColor
        {
            get
            {
                return m_ShowNeedsSaveColor;
            }
            set
            {
                m_ShowNeedsSaveColor = value;
            }
        }
        private Boolean m_ShowNeedsSaveColor = true;
        //Public Override Functions
        public override void DoResize()
        {
            try
            {
                if (m_OriginalDesign)
                {
                    cboValue.Width = this.Width - (cboValue.Left * 2);
                    LinkLabel.Width = this.Width - LinkLabel.Left;
                }
                else
                {
                    picError.Visible = false;
                    picInfo.Visible = false;
                    LinkLabel.Visible = false;
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
                            cboValue.Left = 0;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                            {
                                top = 0;
                                cboValue.BringToFront();
                            }
                            cboValue.Top = top + 1;
                            cboValue.Width = this.Width;
                            this.Height = cboValue.Bottom + 1;
                            break;
                        case LabelLocations.Left:
                            lblCaption.Top = 0;
                            lblCaption.Left = -2;
                            lblCaption.AutoSize = true;
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            cboValue.Top = 0;
                            Int32 left = lblCaption.Right + 1;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                left = 0;
                            cboValue.Left = left;
                            cboValue.Width = this.Width - cboValue.Left;
                            h1 = cboValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                cboValue.Top = (h2 - h1) / 2;
                            this.Height = height + 1;
                            break;
                        case LabelLocations.Right:
                            lblCaption.AutoSize = true;
                            lblCaption.Top = 0;
                            lblCaption.Left = this.Width - (lblCaption.Width - 2);
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            cboValue.Top = 0;
                            cboValue.Left = 0;
                            Int32 width = lblCaption.Left - cboValue.Left;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                width = this.Width - cboValue.Left;
                            cboValue.Width = width;
                            h1 = cboValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                cboValue.Top = (h2 - h1) / 2;
                            this.Height = height + 1;
                            break;
                        case LabelLocations.BottomLeft:
                        case LabelLocations.BottomCenter:
                        case LabelLocations.BottomRight:
                            cboValue.Top = 0;
                            lblCaption.Left = -2;
                            lblCaption.AutoSize = true;
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            top = cboValue.Bottom;
                            height = lblCaption.Height;
                            lblCaption.AutoSize = false;
                            lblCaption.Width = this.Width + 2;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            lblCaption.Height = height;
                            cboValue.Left = 0;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                            {
                                top = 0;
                                cboValue.BringToFront();
                            }
                            lblCaption.Top = top + 1;
                            cboValue.Width = this.Width;
                            this.Height = lblCaption.Bottom + 1;
                            break;
                    }
                    pEmail.Left = (cboValue.Right - pEmail.Width) - 18;
                    Int32 ch = (cboValue.Height - pEmail.Height) / 2;
                    pEmail.Top = ch + cboValue.Top + 1;
                    pWeb.Left = pEmail.Left;
                    pWeb.Top = pEmail.Top + 2;
                }
            }
            catch (Exception)
            { }
        }
        public override object GetValue()
        {
            return (Object)cboValue.Text;
        }
        public override void SetValue(object o)
        {
            ShowChoices();
            cboValue.Text = o.ToString();
            if (m_OriginalDesign)
                SetLinkText();
            else
                SetLinkPics();
            Changed = false;
        }
        public override void SetStyle(nStyle s)
        {
            cboValue.Font = s.xFont;
        }
        public override void SetInfo(String s)
        {
            if (m_ShowNeedsSaveColor)
            {
                if (!Tools.Strings.StrCmp(strLastValue, cboValue.Text))
                {
                    picInfo.Visible = false;
                    cboValue.BackColor = Color.Lavender;
                    if (tTip == null)
                    {
                        tTip = toolTip1;
                        tTip.SetToolTip(cboValue, "Value has been changed, but not saved.");
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
            picInfo.Visible = false;
            cboValue.BackColor = Color.White;
            strLastValue = cboValue.Text;
            if (tTip != null)
                tTip.SetToolTip(cboValue, "");
            tTip = null;
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
        private void ShowChoices()
        {
            cboValue.Items.Clear();

            //temporary
            AllowType = false;

            //AllowType = true;

            //if( CurrentProp == null )
            //    return;

            //if( CurrentProp.xChoices == null )
            //    return;

            //foreach (n_choice c in CurrentProp.xChoices.AllChoices)
            //{
            //    cboValue.Items.Add(c.name);
            //}

            //AllowType = (CurrentProp.choice_type == (Int32)Enums.ChoiceType.FreeType);
        }
        private void SetLinkPics()
        {
            if (CurrentProp == null)
                return;
            switch (CurrentProp.ValueUse )
            {
                case ValueUse.Url:
                    pEmail.Visible = false;
                    pWeb.Visible = true;
                    pWeb.BringToFront();
                    break;
                case ValueUse.Email:
                    pEmail.Visible = true;
                    pEmail.BringToFront();
                    pWeb.Visible = false;
                    break;
                default:
                    pEmail.Visible = false;
                    pWeb.Visible = false;
                    break;
            }
        }
        private void SetLinkText()
        {
            switch (CurrentProp.ValueUse)
            {
                case ValueUse.Url:
                    LinkLabel.Visible = true;
                    SetLinkText_URL();
                    break;
                case ValueUse.Email:
                    LinkLabel.Visible = true;
                    SetLinkText_Email();
                    break;
                default:
                    LinkLabel.Text = "";
                    LinkLabel.Visible = false;
                    break;
            }
        }
        private void SetLinkText_URL()
        {
            LinkLabel.Text = "http://" + cboValue.Text;
        }
        private void SetLinkText_Email()
        {
            LinkLabel.Text = "mailto:" + cboValue.Text;
        }
        private void LoadImages()
        {
            pEmail.Image = IM16.Images["email"];
            pWeb.Image = IM16.Images["web"];
        }
        //Control Events
        private void cboValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!AllowType)
            {
                e.KeyChar = (char)0;
                e.Handled = true;
            }
        }
        private void cboValue_TextChanged(object sender, EventArgs e)
        {
            Changed = true;
            NeedSave();
            if (m_OriginalDesign)
                SetLinkText();
            else
                SetLinkPics();
        }
        private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Tools.FileSystem.Shell("firefox.exe", LinkLabel.Text);
        }
        private void nEdit_Choice_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void pEmail_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.StrExt(cboValue.Text))
                Tools.FileSystem.Shell("iexplore", "mailto:" + cboValue.Text);
        }
        private void pWeb_Click(object sender, EventArgs e)
        {
            if (Tools.Strings.StrExt(cboValue.Text))
                Tools.FileSystem.Shell("iexplore", "http://" + cboValue.Text);
        }
        private void cboValue_Resize(object sender, EventArgs e)
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

