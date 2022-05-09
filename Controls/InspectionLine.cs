using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public delegate void InspectionLineChangeHandler();

    public partial class InspectionLine : UserControl
    {
        public event InspectionLineChangeHandler LineChanged;

        public nObject xObject;

        public InspectionLine()
        {
            InitializeComponent();
        }

        private void InspectionLine_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        private bool m_ShowNA = true;
        public bool ShowNA
        {
            get { return m_ShowNA; }
            set
            {
                m_ShowNA = value;
                DoResize();
            }
        }

        private void DoResize()
        {
            try
            {
                gb.Left = 0;
                gb.Top = 0;
                gb.Height = this.ClientRectangle.Height;
                gb.Width = this.ClientRectangle.Width;
                if (!m_ShowNotes)
                {
                    if (!ShowNA)
                    {
                        optNo.Top = optYes.Top;
                        optNo.Left = (gb.ClientRectangle.Width / 2) + optYes.Left;
                        optNA.Visible = false;
                        txtNotes.Width = gb.ClientRectangle.Width - (txtNotes.Left + 20);
                    }
                    else
                    {
                        int i = (gb.ClientRectangle.Width / 3);
                        optNA.Visible = true;
                        optNo.Top = optYes.Top;
                        optNo.Left = gb.ClientRectangle.Width - (i * 2);
                        optNA.Top = optYes.Top;
                        optNA.Left = gb.ClientRectangle.Width - i;
                        txtNotes.Width = 0;
                    }
                }
                else
                {
                    optNA.Visible = true;
                    txtNotes.Width = gb.ClientRectangle.Width - (txtNotes.Left + 20 + optNA.Width);
                    optNA.Left = txtNotes.Right;
                }
            }
            catch { }
        }

        public String m_Caption = "";
        public String Caption
        {
            get
            {
                return m_Caption;
            }

            set
            {
                m_Caption = value;
                gb.Text = m_Caption;
            }
        }

        public String m_FieldYesNo = "";
        public String FieldYesNo
        {
            get
            {
                return m_FieldYesNo;
            }

            set
            {
                m_FieldYesNo = value;
            }
        }

        public bool IsYes
        {
            get
            {
                return optYes.Checked;
            }
            set
            {
                optYes.Checked = true;
            }
        }
        public bool IsNo
        {
            get
            {
                return optNo.Checked;
            }
            set
            {
                optNo.Checked = true;
            }
        }
        public bool IsNA
        {
            get
            {
                return optNA.Checked;
            }
            set
            {
                optNA.Checked = true;
            }
        }

        public string FieldYesText
        {
            get
            {
                return optYes.Text;
            }
            set
            {
                optYes.Text = value;
            }
        }
        public string FieldNoText
        {
            get
            {
                return optNo.Text;
            }
            set
            {
                optNo.Text = value;
            }
        }
        public string FieldNAText
        {
            get
            {
                return optNA.Text;
            }
            set
            {
                optNA.Text = value;
            }
        }

        public String m_FieldNotes = "";
        public String FieldNotes
        {
            get
            {
                return m_FieldNotes;
            }

            set
            {
                m_FieldNotes = value;
            }
        }

        public bool YesNASelected
        {
            get
            {
                bool b = false;
                if (this.optYes.Checked || this.optNA.Checked)
                    b = true;
                return b;
            }
        }

        public bool YesNoNASelected
        {
            get
            {
                bool b = false;
                if (this.optYes.Checked || this.optNo.Checked || this.optNA.Checked)
                    b = true;
                return b;
            }
        }

        public bool m_ShowNotes = true;
        public bool ShowNotes
        {
            get
            {
                return m_ShowNotes;
            }
            set
            {
                m_ShowNotes = value;
                if (m_ShowNotes)
                    txtNotes.Visible = true;
                else
                {
                    txtNotes.Visible = false;
                    DoResize();
                }
            }
        }


        public void CompleteLoad()
        {
            try
            {
                if (Tools.Strings.StrExt(FieldNotes))
                    txtNotes.Text = (String)xObject.IGet(FieldNotes);
                else
                    txtNotes.Text = "";

                if (Tools.Strings.HasString(txtNotes.Text, "-NA-"))
                    optNA.Checked = true;
                else
                {
                    bool b = (bool)xObject.IGet(FieldYesNo);
                    if (b)
                        optYes.Checked = true;
                    else
                        optNo.Checked = true;
                }
            }
            catch (Exception ex)
            {
                RzWin.Leader.Tell(ex.Message);
            }
        }

        public void CompleteSave()
        {
            try
            {
                bool b = false;
                if (optYes.Checked)
                    b = true;
                else
                    b = false;

                if (Tools.Strings.StrExt(FieldYesNo))
                    xObject.ISet(FieldYesNo, (object)b);

                if (Tools.Strings.StrExt(FieldNotes))
                    xObject.ISet(FieldNotes, (object)txtNotes.Text);
            }
            catch (Exception ee)
            { }
        }

        public bool Checked
        {
            get
            {
                return optYes.Checked;
            }
        }

        public String Notes
        {
            get
            {
                return txtNotes.Text;
            }
            set
            {
                txtNotes.Text = value;
            }
        }

        public Boolean IsEmpty()
        {
            if (optYes.Checked)
                return false;
            if (optNo.Checked)
                return false;
            return true;
        }

        private void optYes_CheckedChanged(object sender, EventArgs e)
        {
            if (LineChanged != null)
                LineChanged();
        }

        private void optNo_CheckedChanged(object sender, EventArgs e)
        {            
            if (LineChanged != null)
                LineChanged();
        }

        private void optNA_CheckedChanged(object sender, EventArgs e)
        {
            if (optNA.Checked)
            {
                if (!Tools.Strings.HasString(txtNotes.Text, "-NA-"))
                    txtNotes.Text += "-NA-";
            }
            else
            {
                txtNotes.Text = txtNotes.Text.Replace("-NA-", "");
            }
        }

        public static string GetInspectionInfo(InspectionLine i, System.Windows.Forms.ComboBox c)
        {
            string s = "";
            if (i.IsYes)
                s = "yes_";
            else if (i.IsNo)
                s = "no_";
            else
                s = "na_";
            if (c != null)
                s += c.Text;
            return s;
        }
        public static void SetInspectionInfo(InspectionLine i, System.Windows.Forms.ComboBox c, string value)
        {
            string s = Tools.Strings.ParseDelimit(value, "_", 1).Trim();
            string v = Tools.Strings.ParseDelimit(value, "_", 2).Trim();
            switch (s.ToLower())
            {
                case "yes":
                    i.IsYes = true;
                    if (c != null)
                        c.Text = v;
                    break;
                case "no":
                    i.IsNo = true;
                    if (c != null)
                        c.Text = v;
                    break;
                default:
                    i.IsNA = true;
                    if (c != null)
                        c.Text = v;
                    break;
            }
        }
    }
}
