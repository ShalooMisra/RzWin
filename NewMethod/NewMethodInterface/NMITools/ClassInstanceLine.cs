using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NewMethod
{
    public partial class ClassInstanceLine : UserControl
    {
        public n_sys InstanceSys;
        public n_class CurrentClass;

        public ClassInstanceLine()
        {
            InitializeComponent();
        }

        public void CompleteLoad(n_sys instance_sys, n_class c, Enums.CountContext count)
        {
            InstanceSys = instance_sys;
            CurrentClass = c;

            lblClassName.Text = c.GetCaption(count);
            lblDescription.Text = c.GetTagLine(count);

            lblSysName.Text = "System Name: " + c.class_name;
            picIcon.Image = c.xSys.GetResourceImage_Trans(c.icon_key);
        }

        private void lblList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InstanceSys.ThrowObjectList(CurrentClass.class_name, "", CurrentClass.GetOrderFields(), "auto-" + CurrentClass.ClassName, -1, CurrentClass.class_tag + " List");
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            nObject x = InstanceSys.MakeObject(CurrentClass.class_name);
            x.ISave();
            InstanceSys.ThrowObjectUp(x);
        }
    }
}
