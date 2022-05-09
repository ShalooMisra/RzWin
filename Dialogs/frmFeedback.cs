using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class frmFeedback : Form
    {
        //SysRz4 xSys;
        company CurrentCompany;
        feedback CurrentFeedback;

        public frmFeedback()
        {
            InitializeComponent();
        }
        public Boolean CompleteLoad(company c)
        {
            return CompleteLoad(c, null);
        }
        public Boolean CompleteLoad(company c, feedback f)
        {
            if (c == null)
                return false;
            CurrentCompany = c;
            if (f == null)
                NewFeedback();
            else
                CurrentFeedback = f;
            lblCompany.Text = CurrentCompany.companyname;
            lvFeedback.ShowTemplate("frmfeedback_feedback_view", "feedback", RzWin.User.TemplateEditor);
            ShowFeedback();
            SetCurrentFeedback();
            return true;
        }
        //Private Functions
        private void ShowFeedback()
        {
            try
            {
                lvFeedback.Clear();
                lvFeedback.ShowData("feedback", "the_company_uid = '" + CurrentCompany.unique_id + "'", "date_created desc", 200);
            }
            catch (Exception)
            { }
        }
        private void SetCurrentFeedback()
        {
            try
            {
                ClearFeedbackControls();
                if (CurrentFeedback == null)
                    return;
                txtComments.Text = CurrentFeedback.comment;
                cboType.Text = CurrentFeedback.feedback_type;
            }
            catch (Exception)
            { }
        }
        private void ClearFeedbackControls()
        {
            txtComments.Text = "";
            cboType.Text = ""; 
        }
        private void NewFeedback()
        {
            try
            {
                CurrentFeedback = new feedback();
                CurrentFeedback.the_company_uid = CurrentCompany.unique_id;
                CurrentFeedback.companyname = CurrentCompany.companyname;
                CurrentFeedback.the_n_user_uid = RzWin.User.unique_id;
                CurrentFeedback.agentname = RzWin.User.name;
            }
            catch (Exception)
            { }
        }
        private void SaveFeedback()
        {
            try
            {
                if (CurrentFeedback == null)
                    NewFeedback();
                if (!Tools.Strings.StrExt(cboType.Text))
                {
                    RzWin.Leader.Tell("You need to select a feedback type from the dropdown before saving.");
                    return;
                }
                if (!Tools.Strings.StrExt(txtComments.Text))
                {
                    if (!RzWin.Leader.AskYesNo("You are about to save feedback with no comments. Ok to continue?"))
                        return;
                }
                CurrentFeedback.comment = txtComments.Text;
                CurrentFeedback.feedback_type = cboType.Text;
                try   
                {
                    if (!Tools.Strings.StrExt(CurrentFeedback.unique_id))
                        CurrentFeedback.Insert(RzWin.Context);
                    else
                        CurrentFeedback.Update(RzWin.Context);
                    RzWin.Leader.Tell("Saved!");
                }
                catch
                {
                    RzWin.Leader.Tell("There was an error saving this feedback. Please try saving again.");
                }
            }
            catch
            { }
        }
        //Buttons
        private void cmdNew_Click(object sender, EventArgs e)
        {
            NewFeedback();
            SetCurrentFeedback();
        }
        private void cmdSave_Click(object sender, EventArgs e)
        {
            SaveFeedback();
        }
        //Control Events
        private void lvFeedback_AboutToThrow(object sender, ShowArgs args)
        {
            try
            {
                args.Handled = true;
                feedback f = (feedback)lvFeedback.GetSelectedObject();
                if (f == null)
                    return;
                CurrentFeedback = f;
                SetCurrentFeedback();
            }
            catch (Exception)
            { }
        }
    }
}