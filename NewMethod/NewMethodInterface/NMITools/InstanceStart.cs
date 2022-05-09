using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class InstanceStart : UserControl, ICompleteLoad
    {
        n_sys xSys
        {
            get
            {
                return n_sys.ContextDefault.xSys;
            }
        }

        public InstanceStart()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            ShowClasses();
        }

        void ShowClasses()
        {
            fp.Controls.Clear();
            ArrayList a = xSys.xStructure.GetSortedClasses(FrameworkCompareType.Vivid);
            foreach (n_class c in a)
            {
                ShowClass(c);
            }
        }

        void ShowClass(n_class c)
        {
            ClassInstanceLine l = new ClassInstanceLine();
            fp.Controls.Add(l);
            l.CompleteLoad(xSys, c, NewMethod.Enums.CountContext.Multiple);
        }
    }
}
