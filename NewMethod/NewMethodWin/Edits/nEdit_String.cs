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
    public delegate void GotEnterHandler();
    public delegate void GotKeyUpHandler(object sender, KeyEventArgs e);
    public partial class nEdit_String : NewMethod.nEdit, IEnableable
    {
        private Int32 o_top = 0;
        private ToolTip tTip = null;
        private String strLastValue = "";

        public nEdit_String()
        {
            InitializeComponent();
        }
        //Properties
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
        public Boolean AllCaps
        {
            get
            {
                return bAllCaps;
            }
            set
            {
                bAllCaps = value;
            }
        }
        private Boolean bAllCaps = false;
        private Char cPasswordChar = new Char();
        public Char PasswordChar
        {
            get
            {
                return cPasswordChar;
            }
            set
            {
                cPasswordChar = value;
                txtValue.PasswordChar = value;
            }
        }
        private bool m_IsURL = false;
        public Boolean IsURL
        {
            get
            {
                return m_IsURL;
            }
            set
            {
                m_IsURL = value;
            }
        }
        private bool m_IsEmail = false;
        public Boolean IsEmail
        {
            get
            {
                return m_IsEmail;
            }
            set
            {
                m_IsEmail = value;
            }
        }
        public Font zz_TextFont
        {
            get
            {
                return txtValue.Font;
            }
            set
            {
                txtValue.Font = value;
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
                return txtValue.ForeColor;
            }
            set
            {
                txtValue.ForeColor = value;
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
                return txtValue.Text;
            }
            set
            {
                txtValue.Text = value;
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
        public Boolean m_ShowLinkButton = false;
        public Boolean zz_ShowLinkButton
        {
            get
            {
                return m_ShowLinkButton;
            }
            set
            {
                m_ShowLinkButton = value;
            }
        }
        public HorizontalAlignment zz_TextAlign
        {
            get
            {
                return txtValue.TextAlign;
            }
            set
            {
                txtValue.TextAlign = value;
            }
        }
        public Boolean zz_Enabled
        {
            get
            {
                return txtValue.Enabled;
            }
            set
            {
                txtValue.Enabled = value;
                DoResize();
            }
        }
        //Public Events
        public event GotEnterHandler GotEnter;
        public event GotKeyUpHandler zz_GotKeyUp;
        //Public Override Functions
        public override void DoResize()
        {
            try
            {
                if (m_OriginalDesign)
                {
                    try
                    {
                        lblCaption.Left = 0;
                        txtValue.Left = 0;
                        txtValue.Width = base.GetClientWidth();
                        if (o_top == 0)
                            o_top = txtValue.Top;
                        else
                            txtValue.Top = o_top;
                        //if (LinkLabel.Visible)
                        //    lblCaption.Width = (base.GetClientWidth() / 2);
                        //else
                        lblCaption.Width = base.GetClientWidth();

                        //SetLinkText();
                        base.DoResize();
                    }
                    catch
                    { }
                }
                else
                {
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
                            txtValue.Left = 0;

                            if (!Tools.Strings.StrExt(lblCaption.Text))
                            {
                                top = 0;
                                txtValue.BringToFront();
                            }
                            txtValue.Top = top + 1;
                            txtValue.Width = this.Width;
                            this.Height = txtValue.Bottom + 1;
                            break;
                        case LabelLocations.Left:
                            lblCaption.Top = 0;
                            lblCaption.Left = -2;
                            lblCaption.AutoSize = true;
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            txtValue.Top = 0;
                            Int32 left = lblCaption.Right + 1;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                left = 0;
                            txtValue.Left = left;
                            txtValue.Width = this.Width - txtValue.Left;
                            h1 = txtValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                txtValue.Top = (h2 - h1) / 2;
                            this.Height = height + 1;
                            break;
                        case LabelLocations.Right:
                            lblCaption.AutoSize = true;
                            lblCaption.Top = 0;
                            lblCaption.Left = this.Width - (lblCaption.Width - 2);
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            txtValue.Top = 0;
                            txtValue.Left = 0;
                            Int32 width = lblCaption.Left - txtValue.Left;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                width = this.Width - txtValue.Left;
                            txtValue.Width = width;
                            h1 = txtValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                txtValue.Top = (h2 - h1) / 2;
                            this.Height = height + 1;
                            break;
                        case LabelLocations.BottomLeft:
                        case LabelLocations.BottomCenter:
                        case LabelLocations.BottomRight:
                            txtValue.Top = 0;
                            lblCaption.Left = -2;
                            lblCaption.AutoSize = true;
                            if (this.Width < lblCaption.Width + 2)
                                this.Width = lblCaption.Width + 4;
                            top = txtValue.Bottom;
                            height = lblCaption.Height;
                            lblCaption.AutoSize = false;
                            lblCaption.Width = this.Width + 2;
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            lblCaption.Height = height;
                            txtValue.Left = 0;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                            {
                                top = 0;
                                txtValue.BringToFront();
                            }
                            lblCaption.Top = top + 1;
                            txtValue.Width = this.Width;
                            this.Height = lblCaption.Bottom + 1;
                            break;
                    }
                }

                if (Tools.Strings.StrExt(lblCaption.Text) && (lblCaption.Top > txtValue.Top))
                {
                    cmdLink.Top = txtValue.Top + 1;
                    cmdLink.Left = txtValue.Right - (cmdLink.Width + 1);
                }
                else
                {
                    cmdLink.Top = txtValue.Top - 2;
                    cmdLink.Left = txtValue.Right - 8;
                }

            }
            catch (Exception)
            { }
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
        public override object GetValue()
        {
            return (Object)txtValue.Text;
        }
        public override void SetValue(object o)
        {
            txtValue.Text = o.ToString();
            Changed = false;
            base.SetValue(o);
        }
        public override void ShowStyle()
        {
            txtValue.Font = xStyle.xFont;
        }
        public override void SetInfo(String s)
        {
            if (m_ShowNeedsSaveColor)
            {
                if (!Tools.Strings.StrCmp(strLastValue, txtValue.Text))
                {
                    picInfo.Visible = false;
                    txtValue.BackColor = Color.Lavender;
                    if (tTip == null)
                    {
                        tTip = toolTip1;
                        tTip.SetToolTip(txtValue, "Value has been changed, but not saved.");
                    }
                }
                else
                {
                    ClearInfo();
                }
            }
        }
        public void SetUse(ValueUse u)
        {
            switch (u)
            {
                case ValueUse.Email:
                    IsEmail = true;
                    m_ShowLinkButton = true;
                    break;
                case ValueUse.Url:
                    IsURL = true;
                    m_ShowLinkButton = true;
                    break;
            }
        }
        public override void ClearInfo()
        {
            picInfo.Visible = false;
            txtValue.BackColor = Color.White;
            strLastValue = txtValue.Text;
            if (tTip != null)
                tTip.SetToolTip(txtValue, "");
            tTip = null;
        }
        public override void SetError(String s)
        {
            picInfo.Visible = false;
            txtValue.BackColor = Color.Lavender;
            toolTip1.SetToolTip(txtValue, "The value entered is not acceptable. This value will not be saved.");
            HasError = true;
        }
        public override void ClearError()
        {
            picInfo.Visible = false;
            txtValue.BackColor = Color.White;
            toolTip1.SetToolTip(txtValue, "");
            HasError = false;
        }
        //Public Functions
        public String GetValue_String()
        {
            return txtValue.Text;
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
        private void SetLink()
        {
            try
            {
                cmdLink.Visible = false;
                if (m_ShowLinkButton && Tools.Strings.StrExt(txtValue.Text))
                {
                    cmdLink.Visible = true;
                    cmdLink.BringToFront();
                }
            }
            catch (Exception)
            { }
        }
        //Control Events
        private void nEdit_String_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '\r':
                case '\n':
                    e.Handled = true;
                    if (GotEnter != null)
                        GotEnter();
                    break;
            }
            if (AllCaps)
            {
                char[] c = e.KeyChar.ToString().ToUpper().ToCharArray();
                e.KeyChar = c[0];
            }
        }
        private void txtValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (zz_GotKeyUp != null)
                zz_GotKeyUp(sender, e);
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (AllCaps)
                txtValue.Text = txtValue.Text.ToUpper();
            Changed = true;
            NeedSave();
            SetLink();
            //DoResize();  //this can cause an infinite loop
        }

        public override void SetFocusSelectAll()
        {
            try
            {
                txtValue.Focus();
                txtValue.SelectAll();
            }
            catch { }
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

        private void cmdLink_Click(object sender, EventArgs e)
        {
            ShowLinks();
        }

        void ShowLinks()
        {
            if (IsEmail)
            {
                if (nTools.IsEmailAddress(GetValue_String()))
                {
                    mnuEmail.Visible = true;
                    mnuEmail.Tag = GetValue_String();

                    mnuDomain.Visible = true;
                    mnuDomain.Tag = "www." + nTools.ParseEmailDomain(GetValue_String());

                    mnu.Show(System.Windows.Forms.Cursor.Position);

                }
            }

            if (IsURL)
            {
                mnuEmail.Visible = false;

                mnuDomain.Visible = true;
                mnuDomain.Tag = GetValue_String();

                mnu.Show(System.Windows.Forms.Cursor.Position);
            }
        }

        private void mnuEmail_Click(object sender, EventArgs e)
        {
            String err = "";            
            //ToolsOffice.OutlookOffice.SendOutlookMessage((String)mnuEmail.Tag, ref err);
        }

        private void mnuDomain_Click(object sender, EventArgs e)
        {
            ToolsWin.WebWin.BrowseWebAddress((String)mnuDomain.Tag);
        }

        public void Enable(bool enable)
        {
            if (enable)
            {
                txtValue.ReadOnly = false;
            }
            else
            {
                txtValue.ReadOnly = true;
            }
        }
    }
}


