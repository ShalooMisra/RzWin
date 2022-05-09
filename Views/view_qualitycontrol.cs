using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Tools;
using NewMethod;
using Core;
using Rz5;

namespace Rz5
{
    public partial class view_qualitycontrol : ViewPlusMenu//NewMethod.nView
    {
        public event EventHandler SaveCompleted;

        //Public Variables
        public qualitycontrol TheQC
        {
            get
            {
                return (qualitycontrol)GetCurrentObject();
            }
        }
        //public n_sys xSys;
        public qualitycontrol CurrentInspection
        {
            get
            {
                return TheQC;
            }
        }
        public partrecord CurrentPart;
        public orddet_line CurrentDetail;
        public ordhed CurrentOrder;
        //Protected Variables
        protected ArrayList LineCol = new ArrayList();

        //Constructors
        public view_qualitycontrol()
        {
            InitializeComponent();
            foreach (InspectionLine l in GetInspectionLines())
            {
                    l.LineChanged += new InspectionLineChangeHandler(l_LineChanged);
            }
        }
        //Public Virtual Functions
        public virtual ArrayList GetInspectionLines()
        {
            ArrayList ret = new ArrayList();
            return GetInspectionLines(ret);
        }
        public virtual ArrayList GetInspectionLines(ArrayList ret)
        {
            foreach (Control c in Controls)
            {
                if (c.GetType() == Type.GetType("InspectionLine"))
                    ret.Add(c);
            }

            ret.AddRange(GetInspectionLinesFlow());

            return ret;
        }
        public virtual bool AllQuestionsAnswered(StringBuilder sb)
        {
            return true;
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            ctl_test_performed.LoadList(true);
            //if (Rz3App.xLogic.IsNasco && NoTrueValues())
            //{
            //    foreach (InspectionLine l in GetInspectionLines())
            //    {
            //        l.xObject = CurrentInspection;
            //    }
            //}
            //else
            //{
                NMWin.LoadFormValues(this, CurrentInspection);
                foreach (InspectionLine l in GetInspectionLines())
                {
                    l.xObject = CurrentInspection;
                    l.CompleteLoad();
                }
                SetOtherValues();
            //}
            if (CurrentOrder != null)
            {
                cmdAlert.Text = "Alert " + CurrentOrder.agentname;
                cmdAlert.Tag = CurrentOrder.base_mc_user_uid;
            }
            base.CompleteLoad();
            CheckProblem();

            //if (Rz3App.xLogic.IsNasco)
            //{
            //    insScan.Caption = "Consistent Markings?";
            //    insPrePhotoWeight.Visible = false;
            //    insLeavingPhotos.Visible = false;
            //    ins_gold_standard.Visible = false;
            //}
            //cmdTesting.Visible = Rz3App.xLogic.IsNasco;
            //lblPrint.Visible = (CurrentDetail != null);
        }
        public override void CompleteSave()
        {
            NMWin.GrabFormValues(this, CurrentInspection);
            foreach (InspectionLine l in GetInspectionLines())
            {
                l.CompleteSave();
                LineCol.Add(l);        
            }
            
            if( CurrentDetail != null )
                CurrentInspection.the_orddet_uid = CurrentDetail.unique_id;
    
            GrabOtherValues();
            UpdateOtherObjects();
            base.CompleteSave();
        }

        public override String GetCaption()
        {
            if (CurrentInspection == null)
            {
                return "";
            }
            else
            {
                return "Inspection on " + nTools.DateFormat(CurrentInspection.date_created);
            }
        }
        public override void HandleCommand(string strCommand)
        {
            String err = "";
            base.HandleCommand(strCommand);
            if (Tools.Strings.StrCmp(strCommand, "SaveAndExit"))
            {
                if (SaveCompleted != null)
                    SaveCompleted(null, null);
            }
            else if (Tools.Strings.StrCmp(strCommand, "Print"))
                RzWin.Form.ShowHTML(HtmlGetAs(), "Inspection Report");
            else if (Tools.Strings.StrCmp(strCommand, "Email"))
                //ToolsOffice.OutlookOffice.SendOutlookMessage("", HtmlGetAs(), "Inspection Of " + CurrentPart.fullpartnumber, false, true, "", "", false, null, "", "", "", "", ref err);
                //RzWin.Context.TheSysRz.TheEmailLogic.SendOutlookEmail("", HtmlGetAs(), "Inspection Of " + CurrentPart.fullpartnumber, false, true, "", "", false, null, "", "", "", "", true, ref err);
            RzWin.Context.TheSysRz.TheEmailLogic.SendEmail(RzWin.Context, new List<string>() { "rz_inspection@sensiblemicro.com" }, HtmlGetAs(), "Inspection Of " + CurrentPart.fullpartnumber, false, true, null, null, null, true, null, null, false, ref err);

        }
        //Public Functions
        //public Boolean CheckNascoCompleted()
        //{
        //    //if (!Tools.Strings.StrExt(ctl_condition.GetValue_String()))
        //    //    return false;
        //    //if (!Tools.Strings.StrExt(ctl_packaging.GetValue_String()))
        //    //    return false;
        //    //if (!Tools.Strings.StrExt(ctl_parts_per_package.GetValue_String()))
        //    //    return false;
        //    foreach (InspectionLine l in GetInspectionLines())
        //    {
        //        if (!l.Enabled)
        //            continue;
        //        if (!l.Visible)
        //            continue;
        //        if (l.IsEmpty())
        //            return false;             
        //    }
        //    ArrayList pics = CurrentDetail.QtC("partpicture", "select * from partpicture where the_orddet_uid = '" + CurrentDetail.unique_id + "'");
        //    if (pics == null)
        //        return false;
        //    if (pics.Count <= 2)
        //        return false;
        //    return true;
        //}
        //Protected Virtual Functions
        protected virtual ArrayList GetInspectionLinesFlow()
        {
            ArrayList ret = new ArrayList();
            foreach (Control c in fp.Controls)
            {
                if (c is InspectionLine)
                    ret.Add(c);
            }
            return ret;
        }
        protected virtual ArrayList GetInspectionLinesForPrint()
        {
            return GetInspectionLines();
        }
        protected virtual String HtmlGetAs()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h2>Incoming Inspection Checklist</h2><hr>");
            sb.AppendLine("<br><b>Part Number:</b>&nbsp;&nbsp;" + CurrentDetail.fullpartnumber);
            sb.AppendLine("<br><b>Quantity:</b>&nbsp;&nbsp;" + Tools.Number.LongFormat(CurrentDetail.quantity_unpacked));
            sb.AppendLine("<br><b>Date Code:</b>&nbsp;&nbsp;" + CurrentDetail.datecode);
            sb.AppendLine("<br><b>Manufacturer:</b>&nbsp;&nbsp;" + CurrentDetail.manufacturer);
            sb.AppendLine("<br><br>");
            foreach (InspectionLine l in GetInspectionLines())
            {
                sb.Append("<br>" + l.Caption + ":&nbsp;");
                if (l.Checked)
                    sb.Append("Y");
                else
                    sb.Append("N");
                if (Tools.Strings.StrExt(l.Notes))
                    sb.Append("&nbsp;-" + l.Notes);
            }
            return sb.ToString();
        }
        //Private Functions
        private void DoResize()
        {
            try
            {
                fp.Height = this.ClientRectangle.Height - fp.Top;
            }
            catch { }
        }
        private Boolean NoTrueValues()
        {
            try
            {
                if (CurrentInspection == null)
                    return true;

                foreach (CoreVarValAttribute p in RzWin.Context.Sys.PropsGetByClass("qualitycontrol"))
                {
                    if (p.TheFieldType == Tools.Database.FieldType.Boolean)
                    {
                        Boolean b = (Boolean)CurrentInspection.IGet(p.Name);
                        if (b == true)
                            return false;
                    }
                }
                return true;
            }
            catch
            { return true; }
        }
        private void l_LineChanged()
        {
            CalcVisible();
        }
        private void CalcVisible()
        {
            insCertsMatch.Enabled = insCerts.IsYes;
            insReportPackageDamage.Enabled = insGoodPackage.IsNo;
        }
        private void CheckProblem()
        {
            if (ctl_has_problem.GetValue_Boolean())
            {
                cmdAlert.Enabled = true;
                ctl_problem_notes.Enabled = true;
            }
            else
            {
                cmdAlert.Enabled = false;
                ctl_problem_notes.Enabled = false;
            }
        }
        private void SetOtherValues()
        {
            if (CurrentInspection == null)
                return;
            if (CurrentInspection.lead_free_na)
            {
                optLeadFreeNA.Checked = true;
                optLeadFreePass.Checked = false;
                optLeadFreeFailed.Checked = false;
            }
            else if (CurrentInspection.lead_free_pass)
            {
                optLeadFreeNA.Checked = false;
                optLeadFreePass.Checked = true;
                optLeadFreeFailed.Checked = false;
            }
            else
            {
                optLeadFreeNA.Checked = false;
                optLeadFreePass.Checked = false;
                optLeadFreeFailed.Checked = true;
            }
            insLeadFree.xObject = CurrentInspection;
            insLeadFree.CompleteLoad();
        }
        private void GrabOtherValues()
        {
            if (CurrentInspection == null)
                return;
            if (optLeadFreeNA.Checked)
            {
                CurrentInspection.lead_free_na = true;
                CurrentInspection.lead_free_pass = false; 
            }
            else if (optLeadFreePass.Checked)
            {
                CurrentInspection.lead_free_na = false;
                CurrentInspection.lead_free_pass = true;
            }
            else
            {
                CurrentInspection.lead_free_na = false;
                CurrentInspection.lead_free_pass = false;
            }
            insLeadFree.CompleteSave();
        }
        private void UpdateOtherObjects()
        {
            try
            {
                if (CurrentPart == null)
                    return;
                if (CurrentDetail == null)
                    return;
                CurrentPart.expected_quantity = 0;
                if (Tools.Strings.StrExt(CurrentInspection.condition))
                {
                    CurrentPart.condition = CurrentInspection.condition;
                    CurrentDetail.condition = CurrentInspection.condition;
                }
                if (Tools.Strings.StrExt(CurrentInspection.packaging))
                {
                    CurrentPart.packaging = CurrentInspection.packaging;
                    CurrentDetail.packaging = CurrentInspection.packaging;
                }
                if (Tools.Strings.StrExt(CurrentInspection.parts_per_package))
                {
                    try { CurrentPart.partsperpack = Convert.ToInt32(CurrentInspection.parts_per_package); }
                    catch { }
                    try { CurrentDetail.partsperpack = Convert.ToInt32(CurrentInspection.parts_per_package); }
                    catch { }
                }
                CurrentPart.Update(RzWin.Context);
                CurrentDetail.Update(RzWin.Context);
            }
            catch { }
        }
        private void CompleteDispose()
        {
            try
            {
                this.lblAddLog.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAddLog_LinkClicked);
                this.lblViewNotes.LinkClicked -= new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblViewNotes_LinkClicked);
                this.ctl_has_problem.DataChanged -= new NewMethod.ChangeHandler(this.ctl_has_problem_DataChanged);
                this.cmdAlert.Click -= new System.EventHandler(this.cmdAlert_Click);

                foreach (InspectionLine l in LineCol)
                {
                    l.LineChanged -= new InspectionLineChangeHandler(l_LineChanged);
                    l.Dispose();
                }

                LineCol.Clear();
                LineCol = null;
            }
            catch { }
        }
        //Buttons
        private void cmdAlert_Click(object sender, EventArgs e)
        {
            String s = "";
            try
            {
                if (cmdAlert.Tag != null)
                {
                    s = (String)cmdAlert.Tag;
                }
            }
            catch { }

            NewMethod.n_user u = NewMethod.n_user.GetById(RzWin.Context, s);
            s = "";
            if (u != null)
                s = u.email_address;

            String err = "";
            //ToolsOffice.OutlookOffice.SendOutlookMessage(s, "", "Quality Control Issue", false, true, "", "", false, null, "", "", "", "", ref err);
            //RzWin.Context.TheSysRz.TheEmailLogic.SendOutlookEmail(s, "", "Quality Control Issue", false, true, "", "", false, null, "", "", "", "", true, ref err);
            RzWin.Context.TheSysRz.TheEmailLogic.SendEmail(RzWin.Context,new List<string>() { s }, "", "Quality Control Issue", false, true, null, null, null, true, null, null, false, ref err);


        }
        private void cmdTesting_Click(object sender, EventArgs e)
        {
            RzWin.Logic.ShowPartTestingScreen(RzWin.Context, TheQC);
        }
        //Control Events
        private void lblAddLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String s = RzWin.Leader.AskForString("Log note:", "", true, "Note");
            if (!Tools.Strings.StrExt(s))
                return;

            String ex = ctl_internalcomment.GetValue_String();
            if( Tools.Strings.StrExt(ex) )
                ex += "\r\n\r\n";

            ex += "By " + RzWin.User.name + " on " + nTools.DateFormat_ShortDateTime(DateTime.Now) + "\r\n" + s;

            ctl_internalcomment.SetValue_String(ex);
            CompleteSave();
        }
        private void lblViewNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Tools.FileSystem.PopText(ctl_internalcomment.GetValue_String());
            RzWin.Leader.Tell(ctl_internalcomment.GetValue_String());
        }
        private void ctl_has_problem_DataChanged(GenericEvent e)
        {
            CheckProblem();
        }
        private void view_qualitycontrol_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
    }
}