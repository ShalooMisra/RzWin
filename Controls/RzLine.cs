using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Rz5
{
    public partial class RzLine : NewMethod.nLine
    {
        public RzLine()
        {
            InitializeComponent();
        }

        public override void MakeNote()
        {
            if (CurrentObject == null)
                return;

            usernote n = usernote.New(RzWin.Context);
            n.by_mc_user_uid = RzWin.User.unique_id;
            n.for_mc_user_uid = RzWin.User.unique_id;
            n.subjectstring = "Note on " + CurrentObject.ToString();
            try
            {
                n.companyname = (String)CurrentObject.IGet("companyname");
            }
            catch { }

            n.notetext = "";
            n.shouldpopup = false;
            n.displaydate = DateTime.Now;
            n.Insert(RzWin.Context);

            n.CreateObjectLink(RzWin.Context, CurrentObject, CurrentObject.ToString());
            n.Update(RzWin.Context);

            TheContext.Show(n);
        }
    }
}
