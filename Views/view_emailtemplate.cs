using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using NewMethod;

namespace Rz5
{
    public partial class view_emailtemplate : ViewPlusMenu
    {
        public emailtemplate CurrentTemplate
        {
            get
            {
                return (emailtemplate)TheItem;
            }
        }

        public view_emailtemplate()
        {
            InitializeComponent();
        }
        //Public Override Functions

        public override void CompleteLoad()
        {
            if (CurrentTemplate.IsOrder)
            { 
                ctl_ordertype.Visible = true;
                lv.Visible = true;
                ctl_emailfooter.Visible = true;
                lv.ShowTemplate(CurrentTemplate.GetTemplateID(), "orddet", RzWin.User.TemplateEditor);
            }
            else
            {
                ctl_ordertype.Visible = false;
                lv.Visible = false;
                ctl_emailfooter.Visible = false;
            }
            DoResize();
            base.CompleteLoad();
        }
        protected override void DoResize()
        {
            try
            {
                base.DoResize();
                //if (this.Width < 559)
                //    this.Width = 558;
                //if (this.Height < 413)
                //    this.Height = 412;

                ts.Left = 0;
                ts.Top = 0;
                ts.Width = xActions.Left;
                ts.Height = this.Height;

                ctl_templatename.Width = pageTemplate.ClientRectangle.Width - (ctl_templatename.Left * 2);
                ctl_subjectstring.Width = ctl_templatename.Width;
                ctl_emailbody.Width = ctl_templatename.Width;
                lv.Width = ctl_templatename.Width;
                ctl_emailfooter.Width = ctl_templatename.Width;
                ctl_ordertype.Left = ctl_templatename.Right - ctl_ordertype.Width;
                ctl_class_name.Width = (ctl_ordertype.Left - ctl_class_name.Left) - 2;
                ctl_emailbody.Height = ((pageTemplate.ClientRectangle.Height - ctl_subjectstring.Bottom) - (lv.Height + 4)) / 2;
                lv.Top = ctl_emailbody.Bottom + 2;
                ctl_emailfooter.Top = lv.Bottom + 2;
                ctl_emailfooter.Height = (pageTemplate.ClientRectangle.Height - ctl_emailfooter.Top) - 2;
            }
            catch (Exception)
            { }
        }

        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ts.SelectedTab == pagePreview)
                ShowPreview();
        }

        nObject ExampleObject = null;
        void ShowPreview()
        {       
            wbPreview.ReloadWB();

            try
            {

                if (ExampleObject == null)
                {
                    String strClass = "";
                    String strDate = "";
                    switch (CurrentTemplate.class_name.ToLower().Trim())
                    {
                        case "ordhed":
                        case "order":
                            strClass = ordhed.MakeOrdhedName(CurrentTemplate.ordertype);
                            strDate = "orderdate";
                            break;
                        default:
                            strClass = CurrentTemplate.class_name.ToLower().Trim();
                            strDate = "date_created";
                            break;
                    }

                    //get a recent, but not the most recent, object, for the most likely chance of getting an item that's completely filled in.
                    ArrayList a = RzWin.Context.SelectScalarArray("select top 10 unique_id from " + strClass + " order by " + strDate + " desc");
                    if (a.Count > 0)
                        ExampleObject = (nObject)RzWin.Context.GetById(strClass, (String)a[a.Count - 1]);
                }

                if (ExampleObject == null)
                    return;

                String sub = "";
                if (CurrentTemplate.is_text)
                {

                    wbPreview.Add(nTools.ConvertTextToHTML(CurrentTemplate.GetHtml(RzWin.Context, ExampleObject, ref sub)));
                }
                else
                {
                    wbPreview.Add(CurrentTemplate.GetHtml(RzWin.Context, ExampleObject, ref sub));
                }
            }
            catch { }
        }
    }
}

