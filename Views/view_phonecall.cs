using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5.Views
{
    public partial class view_phonecall : ViewPlusMenu
    {
        phonecall CurrentCall
        {
            get
            {
                return (phonecall)GetCurrentObject();
            }
        }

        public view_phonecall()
        {
            InitializeComponent();
        }

        public override void CompleteLoad()
        {
            wb.ReloadWB();
            wb.Add(CurrentCall.calldate.ToString());
            wb.Add("<br>Number: " + CurrentCall.phonenumber);
            wb.Add("<br>Key: " + CurrentCall.strippedphone);
            wb.Add("<br>Stat Count: " + CurrentCall.stats_count.ToString());
            wb.Add("<br>Stat Message: " + nTools.ConvertTextToHTML_AllowBreaks(CurrentCall.stats_message));
            base.CompleteLoad();
        }
    }
}
