using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class Rz3_Screen : NewMethod.nView
    {
        public Rz3_Screen()
        {
            InitializeComponent();
        }

        public override void CompleteLoad()
        {
            base.CompleteLoad();
        }
        //public override void LoadForm()
        //{
        //    nObject o = GetCurrentObject();
        //    if (o != null)
        //    {
        //        o.LoadFormValues(this);
        //    }
        //    base.LoadForm();

        //}
        public override String GetCaption()
        {
            if (GetCurrentObject() == null)
            {
                return "";
            }
            else
            {
                return GetCurrentObject().ToString();
            }
        }
        public virtual void CheckActionArgs(ActArgs args)
        {

        }
        public virtual void FinishedAction(ActArgs args)
        {

        }
        public override void CompleteSave()
        {
            nObject o = GetCurrentObject();
            if (o != null)
            {
                NMWin.GrabFormValues(this, o);
            }
            ClearInfo();
            base.CompleteSave();
        }
    }
}