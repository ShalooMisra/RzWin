using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Tools;

namespace NewMethod
{
    public partial class nEdit_List : NewMethod.nEdit
    {
        public delegate void SelectionChangedHandler(GenericEvent e);
        public delegate void GenericEventHandler(GenericEvent e);
        public event SelectionChangedHandler SelectionChanged;
        public event GenericEventHandler KeyBeingPressed;
        public n_choices CurrentChoices;
        private ToolTip tTip = null;
        private String strLastValue = "";

        public nEdit_List()
        {
            InitializeComponent();
        }
        //Properties
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
        private bool m_AllowEdit = false;
        public bool AllowEdit
        {
            get
            {
                return m_AllowEdit;
            }

            set
            {
                m_AllowEdit = value;
                if (m_OriginalDesign)
                {
                    lblEdit.Visible = m_AllowEdit;
                    lblRefresh.Visible = m_AllowEdit;
                }
                else
                {
                    cmdLink.Visible = m_AllowEdit;
                }
            }
        }
        private String m_SimpleList;
        public String SimpleList
        {
            get
            {
                return m_SimpleList;
            }
            set
            {
                try
                {
                    m_SimpleList = value;
                    cboValue.Items.Clear();
                    if (m_SimpleList != null)
                    {
                        String[] a = m_SimpleList.Split("|".ToCharArray());
                        foreach (String s in a)
                        {
                            if (Tools.Strings.StrExt(s))
                                cboValue.Items.Add(s);
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
        }
        private String m_ListName;
        public String ListName
        {
            get
            {
                return m_ListName;
            }
            set
            {
                m_ListName = value;
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
        public ComboBoxStyle zz_DropDownStyle
        {
            get
            {
                return cboValue.DropDownStyle;
            }
            set
            {
                cboValue.DropDownStyle = value;
            }
        }

        //Public Override Functions
        public override void DoResize()
        {
            if (m_OriginalDesign)
            {
                try
                {
                    lblEdit.Left = this.ClientRectangle.Width - lblEdit.Width;
                    lblRefresh.Left = lblEdit.Left - lblRefresh.Width;
                    lblCaption.Left = 0;
                    cboValue.Left = 0;
                    //cboValue.Width = (this.ClientRectangle.Width / 2);
                    cboValue.Width = base.GetClientWidth();
                    base.DoResize();
                }
                catch (Exception ex)
                { }
            }
            else
            {
                lblRefresh.Visible = false;
                lblEdit.Visible = false;
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
                        //if (this.Width < lblCaption.Width + 2)
                        //    this.Width = lblCaption.Width + 4;
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
                if (Tools.Strings.StrExt(lblCaption.Text) && (lblCaption.Top > cboValue.Top))
                {
                    cmdLink.Top = cboValue.Top + 1;
                    cmdLink.Left = cboValue.Right - 8;
                }
                else
                {
                    cmdLink.Top = cboValue.Top - 2;
                    cmdLink.Left = cboValue.Right - 8;
                }
                cmdLink.Font = new Font(FontFamily.GenericSansSerif, (float)8.25);
                cmdLink.Width = 6;
                cmdLink.Height = 7;
                cmdLink.BringToFront();
                cmdLink.Visible = m_AllowEdit;
            }
        }
        public override void SetValue(object o)
        {


            if (cboValue.DataSource != null)//KT Accomodate AddFromDictionary.
                cboValue.Text = SetValueFromDictionary(o.ToString());
            else
                cboValue.Text = o.ToString();
            base.SetValue(o);
        }

        private string SetValueFromDictionary(string key)
        {
            string ret = key;
            foreach (KeyValuePair<string, string> kvp in cboValue.Items)
            {
                if (kvp.Key == key)
                    ret = kvp.Value;
            }

            return ret;
        }

        public override void ShowStyle()
        {
            cboValue.Font = xStyle.xFont;
        }
        public override object GetValue()
        {
            object ret = cboValue.Text;
            if (cboValue.DataSource != null)//KT Accomodate AddFromDictionary.
            {

                if (cboValue.SelectedValue != null)
                    if (!string.IsNullOrEmpty(cboValue.SelectedValue.ToString()))
                        ret = cboValue.SelectedValue.ToString();
            }

            return ret;
        }
        public override String GetControlType()
        {
            return "list";
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
        //Public Functions
        public void LoadList()
        {
            LoadList(false);
        }
        public void LoadList(Boolean bCreate)
        {
            cboValue.Items.Clear();
            if (!Tools.Strings.StrExt(ListName))
                return;
            CurrentChoices = NMWin.ContextDefault.xSys.GetChoicesByName(ListName);
            if (CurrentChoices == null)
            {
                if (!bCreate)
                    return;
                CurrentChoices = n_choices.New(NMWin.ContextDefault);
                CurrentChoices.name = ListName;
                CurrentChoices.Insert(NMWin.ContextDefault);
                if (NMWin.ContextDefault.xSys.AllChoices != null)
                    NMWin.ContextDefault.xSys.AllChoices.Add(CurrentChoices);

            }
            if (NMWin.User != null)
            {
                if (NMWin.User.SuperUser)
                    AllowEdit = true;
            }
            LoadChoices(CurrentChoices);
        }
        public void LoadList(String list)
        {
            ListName = list;
            cboValue.Items.Clear();
            List<String> ls = n_choices.ChoiceListGet(NMWin.ContextDefault, list);
            foreach (String l in ls)
            {
                cboValue.Items.Add(l);
            }
        }

        public void LoadChoices(n_choices c)
        {
            cboValue.Items.Clear();
            if (c == null)
                return;
            c.CacheChoiceList(NMWin.ContextDefault);
            if (c.AllChoices == null)
                return;
            //List<string> listAllChoices = c.AllChoices.Cast<string>().ToList();
            foreach (n_choice ch in c.AllChoices)
            {
                cboValue.Items.Add(ch.name);
            }
        }

        public void LoadArray(ArrayList a)
        {
            cboValue.Items.Clear();
            foreach (String s in a)
            {
                cboValue.Items.Add(s);
            }
        }

        public void LoadListString(List<String> strings)
        {
            cboValue.Items.Clear();           
            foreach (String s in strings)
            {
                cboValue.Items.Add(s);
            }
        }

        public String GetValue_String()
        {
            return Convert.ToString(GetValue());
        }
        public ComboBox GetCombo()
        {
            return cboValue;
        }
        public void ClearList()
        {
            //KT Accomodate AddFromDictionary.
            if (cboValue.DataSource == null)
            {
                ListName = "";
                String s = cboValue.Text;
                bool c = Changed;
                cboValue.Items.Clear();
                cboValue.Text = s;
                Changed = c;
            }
            else
                cboValue.DataSource = null;


        }
        public bool Includes(String s)
        {
            try
            {
                return nTools.IsInArray(GetItemArray(), s);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void Add(String s)
        {
            Add(s, false);
        }
        public void Add(String s, bool only_unique)
        {
            if (only_unique)
            {
                if (Includes(s))
                    return;
            }

            cboValue.Items.Add(s);
        }
        public void AddIfNotBlank(String s)
        {
            if (!Tools.Strings.StrExt(s))
                return;

            cboValue.Items.Add(s);
        }

        public void AddFromDictionary(Dictionary<string, string> cboDict)
        {
            // Dont Add Empties
            Dictionary<string, string> bindDict = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> kvp in cboDict)
            {
                if (!string.IsNullOrEmpty(kvp.Key)) //Must have a key
                    if (!string.IsNullOrEmpty(kvp.Value))
                    {
                        //Take this oppty to concatentate the value
                        string concat = kvp.Key + " (" + kvp.Value + ")";
                        bindDict.Add(kvp.Key, concat);
                    }

            }

            if (cboDict.Count <= 0)
                return;
            cboValue.DataSource = new BindingSource(bindDict, null);
            cboValue.DisplayMember = "Value";
            cboValue.ValueMember = "Key";
            //string value = ((KeyValuePair<string, string>)comboBox1.SelectedItem).Value;

        }
        public void AddOnTopIfNotBlank(String s)
        {
            if (!Tools.Strings.StrExt(s))
                return;

            ArrayList a = GetItemArray();

            cboValue.Items.Clear();
            cboValue.Items.Add(s);
            foreach (String st in a)
            {
                cboValue.Items.Add(st);
            }
        }
        public ArrayList GetItemArray()
        {
            ArrayList a = new ArrayList();
            foreach (Object o in cboValue.Items)
            {
                a.Add(o.ToString());
            }
            return a;
        }
        public void AddFromArray(ArrayList a)
        {
            foreach (String s in a)
            {
                cboValue.Items.Add(s);
            }
        }
        public void AddFromArray(String[] a)
        {
            foreach (String s in a)
            {
                cboValue.Items.Add(s);
            }
        }
        public String GetCurrentList()
        {
            StringBuilder sb = new StringBuilder();
            foreach (String s in cboValue.Items)
            {
                sb.AppendLine(s);
            }
            return sb.ToString();
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
        private void ShowLinks()
        {
            mnu.Show(System.Windows.Forms.Cursor.Position);
        }
        //Menus
        private void editChoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentChoices == null)
            {
                CurrentChoices = n_choices.ChoicesMakeExist(NMWin.ContextDefault, ListName);
            }

            if (CurrentChoices != null)
            {
                CurrentChoices.ChoicesChanged += new NothingDelegate(CurrentChoices_ChoicesChanged);
                NMWin.ContextDefault.Show(CurrentChoices);
            }
        }

        void CurrentChoices_ChoicesChanged()
        {
            ListRefresh();
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListRefresh();
        }

        public void ListRefresh()
        {
            if (CurrentChoices != null)
                LoadChoices(CurrentChoices);
        }

        //Buttons
        private void cmdLink_Click(object sender, EventArgs e)
        {
            ShowLinks();
        }
        //Control Events
        private void cboValue_TextChanged(object sender, EventArgs e)
        {
            Changed = true;
            NeedSave();
        }
        private void cboValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            Changed = true;
            NeedSave();

            if (SelectionChanged != null)
                SelectionChanged(new GenericEvent());
        }
        private void cboValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyBeingPressed != null)
            {
                GenericEvent ge = new GenericEvent();
                KeyBeingPressed(ge);
                if (ge.Handled)
                    e.Handled = true;
            }
            if (AllCaps)
            {
                char[] c = e.KeyChar.ToString().ToUpper().ToCharArray();
                e.KeyChar = c[0];
            }
        }
        private void cboValue_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void lblEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentChoices != null)
                NMWin.ContextDefault.Show(CurrentChoices);
        }
        private void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (CurrentChoices != null)
                LoadChoices(CurrentChoices);
        }
        private void nEdit_List_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void LoadEnum(String strEnum)
        {
            Type t = Type.GetType(strEnum);
            if (t == null)
                return;
            LoadEnum(t);
        }

        public void LoadEnum(Type t)
        {
            cboValue.Items.Clear();
            try
            {
                String[] s = Enum.GetNames(t);
                foreach (String name in s)
                {
                    cboValue.Items.Add(name);
                }
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

        public void DisableFreeType()
        {
            cboValue.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}

