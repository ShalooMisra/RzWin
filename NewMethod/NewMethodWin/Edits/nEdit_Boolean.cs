using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public delegate void CheckChangedHandler(Object sender); 
    public partial class nEdit_Boolean : NewMethod.nEdit
    {

        private ToolTip tTip = null;
        private Boolean bLastValue = false;

        public nEdit_Boolean()
        {
            InitializeComponent();
            base.lblCaption.Visible = false;
        }

        public override void SetCaption(string strCaption)
        {
            base.SetCaption(strCaption);
            chkValue.Text = strCaption;
            lblCaption.Text = strCaption;
            lblCaption.Visible = true;
        }

        ////Properties
        public override String Caption
        {
            get
            {
                return base.lblCaption.Text;
            }
            set
            {
                try
                {
                    base.lblCaption.Text = value;
                    base.lblCaption.Visible = true;
                    DoResize();
                }
                catch(Exception ee)
                {
                    String ss = ee.Message;
                }
            }
        }
        public override bool Bold
        {
            get
            {
                return base.Bold;
            }
            set
            {
                base.Bold = value;

                if (m_Bold)
                    chkValue.Font = new Font(lblCaption.Font, FontStyle.Bold);
                else
                    chkValue.Font = new Font(lblCaption.Font, FontStyle.Regular);

                lblCaption.Font = chkValue.Font;
            }
        }
        
        public Boolean zz_OriginalDesign
        {
            get
            {
                return false;
            }
            set
            {
            }
        }
        public Boolean zz_CheckValue
        {
            get
            {
                return chkValue.Checked;
            }
            set
            {
                chkValue.Checked = value;
            }
        }
        private LabelLocations m_LabelLocation = LabelLocations.Right;
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
                DoResize();
            }
        }
        private Boolean m_ShowNeedsSaveColor = true;
        //Public Events
        public event CheckChangedHandler CheckChanged;
        //Public Override Functions
        public override void DoResize()
        {
            try
            {
                //base.DoResize();

                pChanged.SendToBack();
                if (!m_ShowNeedsSaveColor)
                    pChanged.Visible = false;

                picInfo.Visible = false; 
                if (!Tools.Strings.StrExt(lblCaption.Text))
                {
                    if (m_ShowNeedsSaveColor)
                    {
                        pChanged.Top = 0;
                        pChanged.Left = 0;
                        chkValue.Top = 3;
                        chkValue.Left = 3;
                        this.Width = pChanged.Width;
                        this.Height = pChanged.Height;
                    }
                    else
                    {
                        chkValue.Top = 0;
                        chkValue.Left = 0;
                        this.Width = 13;
                        this.Height = 13;
                    }
                    return;
                }
                switch (m_LabelLocation)
                {
                    case LabelLocations.Right:
                        if (m_ShowNeedsSaveColor && lblCaption.Height < pChanged.Height)
                            lblCaption.Top = 2;
                        else
                            lblCaption.Top = 0;
                        pChanged.Left = 0;
                        if (m_ShowNeedsSaveColor)
                            chkValue.Left = pChanged.Left + 3;
                        else
                            chkValue.Left = 0;
                        if (lblCaption.Height < pChanged.Height && m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = 0;
                            chkValue.Top = pChanged.Top + 3;
                            this.Height = pChanged.Height;
                        }
                        else if (lblCaption.Height < 13)
                        {
                            chkValue.Top = 0;
                            this.Height = 13;
                        }
                        else
                        {
                            if (m_ShowNeedsSaveColor)
                            {
                                pChanged.Top = (lblCaption.Height - pChanged.Height) / 2;
                                chkValue.Top = pChanged.Top + 3;
                                this.Height = lblCaption.Height;
                            }
                            else
                            {
                                chkValue.Top = (lblCaption.Height - 13) / 2;
                                this.Height = lblCaption.Height;
                            }
                        }
                        if (m_ShowNeedsSaveColor)
                        {
                            lblCaption.Left = pChanged.Right;
                            this.Width = pChanged.Width + lblCaption.Width;
                        }
                        else
                        {
                            lblCaption.Left = chkValue.Right - 2;
                            this.Width = chkValue.Width + lblCaption.Width;
                        }
                        break;
                    case LabelLocations.Left:
                        if (m_ShowNeedsSaveColor && lblCaption.Height < pChanged.Height)
                            lblCaption.Top = 2;
                        else
                            lblCaption.Top = 0;
                        lblCaption.Left = -2;
                        if (lblCaption.Height < pChanged.Height && m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = 0;
                            chkValue.Top = pChanged.Top + 3;
                            this.Height = pChanged.Height;
                        }
                        else if (lblCaption.Height < 13)
                        {
                            chkValue.Top = 0;
                            this.Height = 13;
                        }
                        else
                        {
                            if (m_ShowNeedsSaveColor)
                            {
                                pChanged.Top = (lblCaption.Height - pChanged.Height) / 2;
                                chkValue.Top = pChanged.Top + 3;
                                this.Height = lblCaption.Height;
                            }
                            else
                            {
                                chkValue.Top = (lblCaption.Height - 13) / 2;
                                this.Height = lblCaption.Height;
                            }
                        }
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Left = lblCaption.Right;
                            chkValue.Left = pChanged.Left + 3;
                            this.Width = pChanged.Width + lblCaption.Width;
                        }
                        else
                        {
                            chkValue.Left = lblCaption.Right;
                            this.Width = chkValue.Width + lblCaption.Width;
                        }
                        break;
                    case LabelLocations.Top:
                        lblCaption.Top = 0;
                        lblCaption.Left = -2;
                        if (lblCaption.Width < pChanged.Width && m_ShowNeedsSaveColor)
                            this.Width = pChanged.Width;
                        else if (lblCaption.Width < 13)
                            this.Width = 13;
                        else
                            this.Width = lblCaption.Width;
                        Int32 hh = 0;
                        if (m_ShowNeedsSaveColor)
                        {
                            hh = (this.Width - pChanged.Width) / 2;
                            pChanged.Top = lblCaption.Bottom + 2;
                            chkValue.Top = pChanged.Top + 3;
                        }
                        else
                        {
                            hh = (this.Width - 13) / 2;
                            chkValue.Top = lblCaption.Bottom + 2;
                        }
                        if (hh < 0)
                            hh = 0;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Left = hh;
                            chkValue.Left = pChanged.Left + 3;
                        }
                        else
                            chkValue.Left = hh;
                        if (m_ShowNeedsSaveColor)
                            this.Height = pChanged.Bottom;
                        else
                            this.Height = chkValue.Bottom;
                        break;
                    case LabelLocations.Bottom:
                        if (m_ShowNeedsSaveColor)
                            lblCaption.Top = pChanged.Height + 2;
                        else
                            lblCaption.Top = 15;
                        lblCaption.Left = -2;
                        if (lblCaption.Width < pChanged.Width && m_ShowNeedsSaveColor)
                            this.Width = pChanged.Width;
                        else if (lblCaption.Width < 13)
                            this.Width = 13;
                        else
                            this.Width = lblCaption.Width;
                        Int32 hh2 = 0;
                        if (m_ShowNeedsSaveColor)
                            hh2 = (this.Width - pChanged.Width) / 2;
                        else
                            hh2 = (this.Width - 13) / 2;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Top = 0;
                            chkValue.Top = pChanged.Top + 3;
                        }
                        else
                            chkValue.Top = 0;
                        if (hh2 < 0)
                            hh2 = 0;
                        if (m_ShowNeedsSaveColor)
                        {
                            pChanged.Left = hh2;
                            chkValue.Left = pChanged.Left + 3;
                        }
                        else
                            chkValue.Left = hh2;
                        this.Height = lblCaption.Bottom;
                        break;
                }
            }
            catch (Exception)
            { }
        }
        public override object GetValue()
        {
            return (Object)chkValue.Checked;
        }
        public override void SetValue(object o)
        {
            chkValue.Checked = (Boolean)o;
            Changed = false;
        }
        public override void ShowStyle()
        {
            chkValue.Font = xStyle.xFont;
        }
        public override void SetInfo(String s)
        {
            if (m_ShowNeedsSaveColor)
            {
                if (bLastValue != chkValue.Checked)
                {
                    picInfo.Visible = false;
                    pChanged.Visible = true;
                    pChanged.SendToBack();
                    if (tTip == null)
                    {
                        tTip = toolTip1;
                        tTip.SetToolTip(this, "Value has been changed, but not saved.");
                        tTip.SetToolTip(chkValue, "Value has been changed, but not saved.");
                        tTip.SetToolTip(lblCaption, "Value has been changed, but not saved.");
                        tTip.SetToolTip(pChanged, "Value has been changed, but not saved.");
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
            pChanged.Visible = false;
            bLastValue = chkValue.Checked;
            if (tTip != null)
            {
                tTip.SetToolTip(this, "");
                tTip.SetToolTip(chkValue, "");
                tTip.SetToolTip(lblCaption, "");
                tTip.SetToolTip(pChanged, "");
            }
            tTip = null;
        }
        //Public Functions
        public bool GetValue_Boolean()
        {
            return (bool)GetValue();
        }
        public Int32 GetValue_Int32()
        {
            return Convert.ToInt32(GetValue());
        }
        //Control Events
        private void chkValue_CheckedChanged(object sender, EventArgs e)
        {
            Changed = true;
            NeedSave();

            if (CheckChanged != null)
                CheckChanged(this);
        }
        private void nEdit_Boolean_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        //Enums
        public enum LabelLocations
        {
            Top = 0,
            Left = 1,
            Right = 2,
            Bottom = 3,
        }
    }
}

