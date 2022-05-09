using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Core;

namespace NewMethod
{
    public partial class nSearch : UserControl
    {
        public SysNewMethod xSys
        {
            get { return NMWin.ContextDefault.Sys; }
        }
        public String FriendlyName = "";
        public CoreClassHandle CurrentClass;

        public nSearch()
        {
            InitializeComponent();
        }
        //Public Functions
        public virtual void CompleteLoad(CoreClassHandle c)
        {
            //if (c == null)
            //    return false;
            CurrentClass = c;
            DoResize();
        }
        public virtual void DoResize()
        {
        }
        public virtual String GetWhere()
        {
            return "";
        }
    }
}
