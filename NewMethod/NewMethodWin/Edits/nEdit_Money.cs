using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tools.Database;

namespace NewMethod
{
    public partial class nEdit_Money : NewMethod.nEdit
    {
        protected ToolTip tTip = null;
        nDouble LastValue = 0;

        public nEdit_Money()
        {
            InitializeComponent();
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
        private bool m_EditCaption = false;
        public bool EditCaption
        {
            get
            {
                return m_EditCaption;
            }
            set
            {
                m_EditCaption = value;
            }
        }
        private bool m_FullDecimal = false;
        public bool FullDecimal
        {
            get
            {
                return m_FullDecimal;
            }
            set
            {
                m_FullDecimal = value;
            }
        }
        private bool m_RoundNearestCent = false;
        public bool RoundNearestCent
        {
            get
            {
                return m_RoundNearestCent;
            }
            set
            {
                m_RoundNearestCent = value;
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
        public Boolean zz_ShowErrorColor
        {
            get
            {
                return m_ShowErrorColor;
            }
            set
            {
                m_ShowErrorColor = value;
            }
        }
        private Boolean m_ShowErrorColor = true;
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
        public override string GetControlType()
        {
            return "money";
        }
        public override object GetValue()
        {
            if (CurrentProp == null)
            {
                try
                {
                    return (Object)Convert.ToDouble(nTools.MoneyFilter(txtValue.Text));
                }
                catch (Exception)
                {
                    //if( Tools.Strings.StrExt(txtValue.Text) )
                    //    context.TheLeader.Tell(txtValue.Text + " must be numeric.");
                    return 0;
                }
            }

            try
            {
                switch (CurrentProp.FieldType)
                {
                    case FieldType.Int32:
                        return (Object)Convert.ToInt32(nTools.MoneyFilter(txtValue.Text));
                    case FieldType.Int64:
                        return (Object)Convert.ToInt64(nTools.MoneyFilter(txtValue.Text));
                    case FieldType.Double:
                        return (Object)Convert.ToDouble(nTools.MoneyFilter(txtValue.Text));
                }
            }
            catch (Exception e)
            {
                switch (CurrentProp.FieldType)
                {
                    case FieldType.Int32:
                        return (Object)Convert.ToInt32(0);
                    case FieldType.Int64:
                        return (Object)Convert.ToInt64(0);
                    case FieldType.Double:
                        return (Object)Convert.ToDouble(0);
                }
            }

            return null;
        }
        public override void SetValue(object o)
        {
            if (o == null)
            {
                txtValue.Text = "";
            }
            else
            {
                nDouble d = 0;
                try
                {
                    d = o.ToString(); 
                }
                catch(Exception){}
                if (m_RoundNearestCent)
                    txtValue.Text = nTools.MoneyFormat(d);
                else
                    txtValue.Text = nTools.MoneyFormat_2_6(d);
            }
            Changed = false;
        }
        public override void ShowStyle()
        {
            //switch (CurrentProp.property_type)
            //{
            //    case (Int32)FieldType.Double:
            //        Double d = Convert.ToDouble(this.GetValue());
            //        try
            //        {
            //            if (Tools.Strings.StrExt(xStyle.strFormat))
            //                txtValue.Text = String.Format(xStyle.strFormat, d);
            //            else
            //                txtValue.Text = d.ToString();
            //        }
            //        catch (Exception ex)
            //        {
            //            txtValue.Text = d.ToString();
            //        }
            //        break;
            //    default:
            //        break;
            //}

            txtValue.Font = xStyle.xFont;
        }
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
                        base.DoResize();
                    }
                    catch (Exception ex)
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
                            if (Tools.Strings.StrExt(lblCaption.Text))
                            {
                                if (this.Width < lblCaption.Width)
                                    this.Width = lblCaption.Width + 1;
                            }
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
                            if (Tools.Strings.StrExt(lblCaption.Text))
                            {
                                if (this.Width < lblCaption.Width)
                                    this.Width = lblCaption.Width + 1;
                            }
                            lblCaption.TextAlign = GetAlignment(m_LabelLocation);
                            txtValue.Top = 0;
                            Int32 width = 0;
                            txtValue.Left = 0;
                            width = lblCaption.Left - txtValue.Left;
                            if (!Tools.Strings.StrExt(lblCaption.Text))
                                width = (this.Width - txtValue.Left) - 1;
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
            }
            catch (Exception)
            { }
        }
        public override void SetInfo(String s)
        {
            if (m_ShowNeedsSaveColor)
            {
                if (!Tools.Number.IsNumeric(txtValue.Text) && m_ShowErrorColor)
                {
                    ClearInfo();
                    if (LastValue == 0 && !Tools.Strings.StrExt(txtValue.Text))
                        return;
                    SetError("");
                    return;
                }
                nDouble thisvalue = txtValue.Text;
                if (LastValue != thisvalue)
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
        public override void SetError(String s)
        {
            picError.Visible = false;
            txtValue.BackColor = Color.MistyRose;
            if (tTip == null)
            {
                tTip = toolTip1;
                tTip.SetToolTip(txtValue, "This value is not numeric and will not be saved.");
            }
        }
        public override void ClearInfo()
        {
            picInfo.Visible = false;
            txtValue.BackColor = Color.White;
            LastValue = GetLastValue();
            if (tTip != null)
                tTip.SetToolTip(txtValue, "");
            tTip = null;
        }
        //Public Functions
        public Double GetValue_Double()
        {
            return Convert.ToDouble(GetValue());
        }
        //Private Functions
        private nDouble GetLastValue()
        {
            String value = txtValue.Text;
            nDouble d = txtValue.Text;
            if (value.Length > 1 && d == 0)
                return LastValue;
            return d;
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
        //Control Events
        private void lblCaption_Click(object sender, EventArgs e)
        {
            if (!m_EditCaption)
                return;
            String s = NMWin.Leader.AskForString("New Caption:", Caption, "New Caption");
            if (!Tools.Strings.StrExt(s))
                return;
            Caption = s;
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            Changed = true;
            NeedSave();
        }
        private void txtValue_Enter(object sender, EventArgs e)
        {
            try
            {
                //if (((NewMethod.Logic)SysNewMethod.ContextDefault.TheLogic).DoOriginalClear_nEditMoney())
                //{
                    if (!Tools.Strings.StrExt(txtValue.Text))
                        return;
                    if (!Tools.Number.IsNumeric(txtValue.Text))
                        return;
                    Double d = Double.Parse(txtValue.Text);
                    if (d == 0)
                        txtValue.Text = "";
                //}
                //else
                //    txtValue.SelectAll();
            }
            catch (Exception)
            { }
        }
        private void txtValue_Leave(object sender, EventArgs e)
        {
            if (!Tools.Strings.StrExt(txtValue.Text))
                txtValue.Text = "0";
            nDouble d = txtValue.Text;
            if (d == 0)
            {
                if (LastValue > 0 && IsNotZero(txtValue.Text))
                {
                    txtValue.Text = LastValue.MoneyFormat().Replace("$", "").ToString().Trim();
                    return;
                }
                else
                    txtValue.Text = "0.00";
            }
            txtValue.Text = d.MoneyFormat().Replace("$", "").ToString().Trim();
        }
        private void txtCurrency_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = true;
        }
        private void nEdit_Money_Resize(object sender, EventArgs e)
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

        private void txtValue_DoubleClick(object sender, EventArgs e)
        {
            DoubleClickHandle();
        }

        protected virtual void DoubleClickHandle()
        {

        }
    }
}

