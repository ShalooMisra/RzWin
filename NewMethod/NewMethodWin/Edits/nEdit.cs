using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using Tools;
using Core;

namespace NewMethod
{
    public delegate void SaveHandler(Object sender, SaveArgs args);
    public delegate void ChangeHandler(GenericEvent e);

    public partial class nEdit : UserControl
    {
        public VarVal CurrentProp;
        public nStyle xStyle;
        public Boolean HasError = false;

        public nEdit()
        {
            InitializeComponent();
        }
        //Properties
        private bool m_changed = false;
        public bool Changed
        {
            get
            {
                return m_changed;
            }
            set
            {
                m_changed = value;
                if (m_changed)
                {
                    SetInfo("Click 'Save' to commit this change to the database.");
                }
                else
                {
                    ClearInfo();
                }
            }
        }
        protected bool m_Bold = false;
        public virtual bool Bold
        {
            get
            {
                return m_Bold;
            }
            set
            {
                m_Bold = value;
                if (m_Bold)
                    lblCaption.Font = new Font(lblCaption.Font, FontStyle.Bold);
                else
                    lblCaption.Font = new Font(lblCaption.Font, FontStyle.Regular);
            }
        }
        public virtual String Caption
        {
            get
            {
                return "";
            }
            set
            {
                return;
            }
        }

        public virtual bool IsBlank
        {
            get
            {
                return false;
            }
        }

        private bool m_UseParentBackColor = false;
        public bool UseParentBackColor
        {
            get
            {
                return m_UseParentBackColor;
            }
            set
            {
                m_UseParentBackColor = value;

                if (m_UseParentBackColor)
                {
                    try
                    {
                        this.BackColor = this.Parent.BackColor;
                    }
                    catch (Exception ex)
                    { }
                }
            }
        }
        public virtual Font zz_LabelFont
        {
            get
            {
                return lblCaption.Font;
            }
            set
            {
                lblCaption.Font = value;
                DoResize();
            }
        }
        public virtual Color zz_LabelColor
        {
            get
            {
                return lblCaption.ForeColor;
            }
            set
            {
                lblCaption.ForeColor = value;
                DoResize();
            }
        }
        //Public Events
        public event SaveHandler SaveRequest;
        public event ChangeHandler DataChanged;
        //Public Virtual Functions
        public virtual void DoResize()
        {
            try
            {
                //lblCaption.Width = this.ClientRectangle.Width;
                picInfo.Top = 0;
                picInfo.Left = this.ClientRectangle.Width - picInfo.Width;
            }
            catch (Exception)
            { }
        }
        public virtual String GetControlType()
        {
            return "";
        }
        public virtual Object GetValue()
        {
            return null;
        }
        public virtual void SetValue(Object o)
        {
            ChangedOff();
            DoResize();
        }
        public virtual void SetCaption(String strCaption)
        {
            lblCaption.Text = strCaption;
        }
        public virtual void NeedSave()
        {
            if (SaveRequest != null)
                SaveRequest(this, new SaveArgs());
            RaiseChangedEvent();
        }
        public virtual void ReSetStyle(nStyle s)
        {
            xStyle = s;
            ShowStyle();
        }
        public virtual void SetStyle(nStyle s)
        {
            xStyle = s;
            ShowStyle();
        }
        public virtual void ShowStyle()
        {

        }
        public virtual void SetInfo(String s)
        {
            picInfo.Visible = true;
        }
        public virtual void ClearInfo()
        {
            picInfo.Visible = false;
        }
        public virtual void SetError(String s)
        {
            HasError = true;
        }
        public virtual void ClearError()
        {
            HasError = false;
        }
        //Public Functions
        public void ChangedOn()
        {
            Changed = true;
            lblCaption.ForeColor = System.Drawing.Color.Blue;
            RaiseChangedEvent();
        }
        public void RaiseChangedEvent()
        {
            if (DataChanged != null)
                DataChanged(new GenericEvent());
        }
        public void ChangedOff()
        {
            Changed = false;
            //lblCaption.ForeColor = System.Drawing.Color.Black;
        }
        public int GetClientWidth()
        {
            //return Convert.ToInt32((Convert.ToDouble(this.ClientRectangle.Width) * 0.85));
            return this.ClientRectangle.Width;
        }
        public int GetClientHeight()
        {
            //return Convert.ToInt32((Convert.ToDouble(this.ClientRectangle.Height) * 0.85));
            return this.ClientRectangle.Height;
        }
        public Boolean IsNotZero(String value)
        {
            Char[] chars = value.ToCharArray();
            nDouble d = 0;
            nDouble dd = 0;
            foreach (char c in chars)
            {
                if (Tools.Number.IsNumeric(c.ToString()))
                {
                    dd = c.ToString();
                    d += dd;
                }
            }
            return (d > 0);
        }
        //Control Events
        private void nEdit_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void nEdit_MouseMove(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        public virtual void SetFocusSelectAll()
        {

        }
    }

    public class nStyle
    {
        public Font xFont;
        public String strFormat = "";
        public int intDecimals = -1;
        public nStyle(Font f, string s, int i)
        {
            xFont = f;
            strFormat = s;
            intDecimals = i;
        }
    }

    public class SaveArgs
    {
        public String Reason;
        public Boolean Handled;
        public SaveArgs()
        {
            Handled = false;
        }
    }
}
