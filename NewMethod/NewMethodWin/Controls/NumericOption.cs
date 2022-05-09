using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class NumericOption : UserControl
    {
        public NumericOption()
        {
            InitializeComponent();
        }

        public bool IsEquals
        {
            get
            {
                return optEquals.Checked;
            }
        }

        public bool IsAtLeast
        {
            get
            {
                return optAtLeast.Checked;
            }
        }

        public bool IsRange
        {
            get
            {
                return optRange.Checked;
            }
        }

        public String GetValue()
        {
            return Tools.Strings.ParseDelimit(ctl.GetValue_String(), ":", 1);
        }

        public String Caption
        {
            set
            {
                ctl.Caption = value;
            }

            get
            {
                return ctl.Caption;
            }
        }

        public void SetValue(String s)
        {
            ctl.SetValue(s);
        }

        public String SimpleList
        {
            get
            {
                return ctl.SimpleList;
            }

            set
            {
                ctl.SimpleList = value;
            }
        }
    }
}
