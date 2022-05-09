using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class nEdit_Memo : NewMethod.nEdit, IEnableable
    {
        private ToolTip tTip = null;
        private String strLastValue = "";

        public nEdit_Memo()
        {
            InitializeComponent();
        }
        //Properties
        public ScrollBars zz_ScrollBars
        {
            get
            {
                return txtValue.ScrollBars;
            }
            set
            {
                txtValue.ScrollBars = value;
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

        bool m_DateLines = false;
        public bool DateLines
        {
            get
            {
                return m_DateLines;
            }

            set
            {
                m_DateLines = value;
            }
        }

        private Boolean m_OriginalDesign = true;
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
        //Public Override Functions
        public override object GetValue()
        {
            return (Object)txtValue.Text;
        }
        public override void SetValue(object o)
        {
            txtValue.Text = o.ToString();
            Changed = false;
        }
        public override void SetStyle(nStyle s)
        {
            txtValue.Font = s.xFont;
        }
        public override void DoResize()
        {
            if (m_OriginalDesign)
            {
                try
                {
                    lblCaption.Left = 0;
                    txtValue.Left = 0;
                    //txtValue.Width = (this.ClientRectangle.Width / 2);
                    txtValue.Width = base.GetClientWidth();
                    txtValue.Height = this.GetClientHeight() - txtValue.Top;
                    base.DoResize();
                }
                catch
                { }
            }
            else
            {
                try
                {
                    picError.Visible = false;
                    picInfo.Visible = false;
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
                            txtValue.Height = (this.Height - txtValue.Top) - 1;
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
                            txtValue.Height = this.Height;
                            h1 = txtValue.Height;
                            h2 = lblCaption.Height;
                            height = (h1 >= h2) ? h1 : h2;
                            if (h1 >= h2)
                                lblCaption.Top = (h1 - h2) / 2;
                            else
                                txtValue.Top = (h2 - h1) / 2;
                            //this.Height = height + 1;
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
                catch (Exception)
                { }
            }
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
        public override void ClearInfo()
        {
            picInfo.Visible = false;
            txtValue.BackColor = Color.White;
            strLastValue = txtValue.Text;
            if (tTip != null)
                tTip.SetToolTip(txtValue, "");
            tTip = null;
        }
        //Public Functions
        public String GetValue_String()
        {
            return txtValue.Text;
        }
        public void SetValue_String(String s)
        {
            SetValue((Object)s);
        }
        public void AppendLine(String s)
        {
            if (Tools.Strings.StrExt(txtValue.Text))
            {
                if (!txtValue.Text.EndsWith("\r\n"))
                    txtValue.AppendText("\r\n");
            }

            txtValue.AppendText(s);
        }
        public bool IncludesLine(String s)
        {
            return nTools.IncludesLine(txtValue.Text, s);
        }
        public void SortLines()
        {
            ArrayList a = nTools.SplitArray(txtValue.Text, "\r\n");
            a.Sort();
            txtValue.Text = "";
            foreach (String s in a)
            {
                AppendLine(s);
            }
        }
        public event GotKeyUpHandler zz_GotKeyUp;

        public void ScrollToText(String strText)
        {
            if (!Tools.Strings.HasString(txtValue.Text, strText))
                return;

            int i = txtValue.Text.ToLower().IndexOf(strText.ToLower());
            if (i == -1)
                return;

            txtValue.SelectionStart = i;
            txtValue.SelectionLength = strText.Length;
            txtValue.ScrollToCaret();
        }

        public void Enable(bool enable)
        {
            if (enable)
            {
                txtValue.ReadOnly = false;
                txtValue.Enabled = true;
            }
            else
            {
                txtValue.ReadOnly = true;
                txtValue.Enabled = true;
            }
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
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            Changed = true;
            NeedSave();
        }
        private void nEdit_Memo_Resize(object sender, EventArgs e)
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

        bool firstkey = true;
        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_DateLines && firstkey)
            {
                firstkey = false;
                txtValue.AppendText("\r\n" + DateTime.Now.ToString() + ": ");
                txtValue.ScrollToCaret();
            }
        }
        private void txtValue_KeyUp(object sender, KeyEventArgs e)
        {
            if (zz_GotKeyUp != null)
                zz_GotKeyUp(sender, e);
        }
    }
}

