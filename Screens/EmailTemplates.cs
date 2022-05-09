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
    public partial class EmailTemplates : UserControl, ICompleteLoad
    {
        public EmailTemplates()
        {
            InitializeComponent();
        }

        public void CompleteLoad()
        {
            lvTemplates.ShowTemplate("email_templates", "emailtemplate", RzWin.User.TemplateEditor);
            lvTemplates.ShowData("emailtemplate", "isnull(templatename, '') > ''", "templatename");
            nObject x = lvTemplates.GetFirstObject();
            if (x == null)
                TheView.Visible = false;
            else
                LoadTemplate((emailtemplate)x);
            
            DoResize();
        }

        private void LoadTemplate(emailtemplate t)
        {
            if (t == null)
            {
                TheView.Visible = false;
                return;
            }

            TheView.Visible = true;
            TheView.SetCurrentObject(t);
            TheView.CompleteLoad();
        }

        private void EmailTemplates_Resize(object sender, EventArgs e)
        {
            DoResize();
        }

        public void DoResize()
        {
            try
            {
                cmdNew.Top = 0;
                cmdNew.Left = 0;

                lvTemplates.Left = 0;
                lvTemplates.Top = cmdNew.Bottom;
                lvTemplates.Height = this.ClientRectangle.Height - (lvTemplates.Top + 3);

                TheView.Top = 0;
                TheView.Left = lvTemplates.Right;
                TheView.Width = this.ClientRectangle.Width - lvTemplates.Width;
                TheView.Height = this.ClientRectangle.Height;
            }
            catch (Exception)
            { }
        }

        private void lvTemplates_ObjectClicked(object sender, ObjectClickArgs args)
        {
            LoadTemplate((emailtemplate)args.GetObject());
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            CreateNewTemplate();
        }

        private void CreateNewTemplate()
        {
            emailtemplate e = emailtemplate.New(RzWin.Context);
            e.templatename = "New Template (" + DateTime.Now.ToShortDateString() + ")";
            e.Insert(RzWin.Context);
            if (e != null)
                LoadTemplate(e);
        }
    }
}
