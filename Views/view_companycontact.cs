using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Tools;
using ToolsWin;
using Core;
using NewMethod;
using System.Collections.Generic;
using CoreWin;

namespace Rz5
{
    public partial class view_companycontact : ViewPlusMenu
    {
        //Public Variables
        public companycontact CurrentContact;
        public Enums.ContactType LastType = Enums.ContactType.Unknown;
        //Protected Variables
        protected bool Loading = false;
        //Private Functions
        private QuotesView quotes_view = null;
        private String OriginalNotes = "";

        //Constructors
        public view_companycontact()
        {
            InitializeComponent();
            gbPhone.Visible = false;
        }
        //Public Override Functions
        public override void CompleteLoad()
        {
            Loading = true;
            //if (!Rz3App.xLogic.IsCTG)
            //{
                //ts.TabPages.Remove(pageWebsite);
                //ts.TabPages.Remove(pageWebsite2);
            //}
            //else
            //{
            //    pageWebsite.Text = "ctg123";
            //    pageWebsite2.Text = "FL";
            //}
            agent.AllowChange = RzWin.User.SuperUser;
            CurrentContact = (companycontact)GetCurrentObject();
            agent.CurrentObject = CurrentContact;
            agent.CurrentIDField = "base_mc_user_uid";
            agent.CurrentNameField = "agentname";
            agent.SetUserName();
            if (!RzWin.Context.CheckPermit("Contact:Assign:CanAssignAllContacts"))
                agent.Enabled = false;
            ctStub.CurrentObject = CurrentContact;
            ctStub.SetType();
            base.CompleteLoad();
            ts.TabPages.Remove(pageCalls);
            ts.TabPages.Remove(pagePhoneNumbers);
            //ts.TabPages.Remove(pageWebsite);
            //ts.TabPages.Remove(pageWebsite2);
            ts.TabPages.Remove(pageFeedback);
            LastType = CurrentContact.ContactType;
            ShowNotes();
            Loading = false;
            OriginalNotes = CurrentContact.contactnotes;
            ctl_contactnotes.Enabled = true;
            ctl_contactnotes.Enable(true);
            ctl_contactnotes.zz_ScrollBars = ScrollBars.Both;
            //if (Rz3App.xLogic.IsCTG)
            //{
            //    xActions.EnableJustSaveAndExit();
            //    xActions.EnableDelete = false;
            //}
            if (quotes_view == null)
            {
                quotes_view = new QuotesViewSimple();
                pageQuotes.Controls.Add(quotes_view);
                quotes_view.Dock = DockStyle.Fill;
                quotes_view.Init();
            }
            ctl_timezone.LoadList();
            //ctl_personality_type.LoadList(); // May not be necessary - KT 10-8-2014
            //cbo_personality_type.SelectedItem = CurrentContact.personality_type;
            if (CurrentContact.personality_type.Length > 0)
            {
                lbl_expect.Visible = true;
                lbl_trait.Visible = true;
                lbl_interact.Visible = true;
            }

            if (CurrentContact.personality_type == "Amicable")
            {
                lbl_expectation.Text = "Don't like confrontation.  They won't tell you what they are thinking.";
                lbl_traits.Text = "Kind, warm, gentle; will go out of their way to help you.";
                lbl_interaction.Text = "Ask a lot of questions.  Be selectively assertive.";
               
            }
            else if (CurrentContact.personality_type == "Analytical")
            {
                lbl_expectation.Text = "Calls and sales process will be longer.  Can't be forced to make a decision.";
                lbl_traits.Text = "Cautious, precise, detail-oriented, slow to make decisions.";
                lbl_interaction.Text = "Present facts.  Be consistent with your interactions and follow-through.";
            }
            else if (CurrentContact.personality_type == "Driver")
            {
                lbl_expectation.Text = "Have a system and process for everything.";
                lbl_traits.Text = "Blunt, direct, know what's best.";
                lbl_interaction.Text = "Be blunt and direct, don't 'Waste their time'.";
            }
            else if (CurrentContact.personality_type == "Expressive")
            {
                lbl_expectation.Text = "Don't tend to listen.  They like to talk.";
                lbl_traits.Text = "Social, outgoing, life of the party.";
                lbl_interaction.Text = "Listen.  Be upbeat and Excited.";
            }               
            else
            {
                lbl_expectation.Text = "";
                lbl_traits.Text = "";
                lbl_interaction.Text = "";
            }

            LoadAffiliateContol();
                //RzWin.User.GetSetting_Boolean(RzWin.Context, "can_release_anyone")
            
        }

        private void LoadAffiliateContol()
        {
            //affiliate_info i = new affiliate_info();
            //s.Text = "Set split commisison for all batch lines.";
            ////s.CompleteLoad(RzWin.Context, xDeal.split_commission_agent_uid, xDeal.split_commission_type);
            //s.isModal = true;
            //s.CompleteLoad(RzWin.Context, xDeal);
            ////https://www.youtube.com/watch?v=8aDsXyiBLsI
            //Form scForm = new Form();
            //scForm.Controls.Add(s);
            //scForm.AutoSize = true;
            //scForm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //var result = scForm.ShowDialog();

            //if (result == DialogResult.OK)
            //{
            //    RzWin.Context.TheSysRz.TheQuoteLogic.SetSplitCommission(RzWin.Context, xDeal.base_mc_user_uid, xDeal, s.SplitCommissionAgent.unique_id, s.SplitCommissionType);
            //    xDeal.split_commission_agent_uid = s.SplitCommissionAgent.unique_id;
            //    xDeal.split_commission_agent_name = s.SplitCommissionAgent.name;
            //    xDeal.split_commission_type = s.SplitCommissionType;
            //    xDeal.Update(RzWin.Context);

            //    CompleteLoadSplitCommission();
            //}
        }

        public override void CompleteSave()
        {
            if (ctl_personality_type.GetValue_String().Length < 1)
            {
                lbl_expect.Visible = false;
                lbl_trait.Visible = false;
                lbl_interact.Visible = false;
            }
            SaveNewNotes();
            CheckAlternatePhone();
            //SaveAffiliateInfo();
            base.CompleteSave();
        }

        //private void SaveAffiliateInfo()
        //{
        //    throw new NotImplementedException();
        //}

        //Public Virtual Functions
        public virtual void CompleteDispose()
        {
            try
            {
                quotes_view.Dispose();
                quotes_view = null;
            }
            catch { }
        }
        public virtual void SetLastNote(String s)
        {

        }
        public virtual void HandleRelease()
        {

        }
        public virtual void HandleAssign(NewMethod.n_user u)
        {

        }
        public virtual bool MayRelease(ContextRz x)
        {
            if (Tools.Strings.StrExt(CurrentContact.base_mc_user_uid))
            {
                if (!RzWin.User.SuperUser && (!Tools.Strings.StrCmp(CurrentContact.base_mc_user_uid, RzWin.User.unique_id)))
                {
                    if (!RzWin.User.IsTeamCaptainOf(x, CurrentContact.base_mc_user_uid))
                    {
                        if (!RzWin.Logic.IsUserAssistantOf(RzWin.Context, CurrentContact.base_mc_user_uid))
                        {
                            if (!RzWin.User.GetSetting_Boolean(RzWin.Context, "can_release_anyone"))
                            {
                                if (RzWin.User.IsOnTeamWith(RzWin.Context, CurrentContact.base_mc_user_uid) && RzWin.User.GetSetting_Boolean(RzWin.Context, "can_release_anyone_on_team"))
                                {
                                    return true;
                                }
                                else
                                {
                                    RzWin.Leader.ShowNoRight();
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                RzWin.Context.TheLeader.TellTemp("This contact is already un-assigned");
                return false;
            }

            String s = "";
            if (!CurrentContact.MayAssign(x, RzWin.User, ref s))
            {
                RzWin.Context.TheLeader.TellTemp("This contact cannot be released.\r\n\r\n" + s);
                return false;
            }

            return true;
        }
        public virtual void PickAnAddress()
        {
            if (!Tools.Strings.StrExt(CurrentContact.base_company_uid))
            {
                RzWin.Leader.Tell("This contact is not yet linked to a company.");
                return;
            }

            List<Object> objects = new List<object>();
            foreach (Object x in RzWin.Context.QtC("companyaddress", "select * from companyaddress where base_company_uid = '" + CurrentContact.base_company_uid + "' order by description"))
            {
                objects.Add(x);
            }

            companyaddress a = (companyaddress)frmChooseObject.ChooseFromCollection(objects);
            if (a != null)
            {
                CompleteSave();
                CurrentContact.AbsorbAddress(a);
                CurrentContact.Update(RzWin.Context);
                CompleteLoad();
            }
        }
        public virtual void ViewWebPhone()
        {

        }
        public virtual void ChangeWebPhone()
        {

        }
        public virtual void AddNote(String s)
        {
            String sx = ctl_contactnotes.GetValue_String().Trim();
            if (!sx.EndsWith("\r\n"))
                sx += "\r\n";
            sx += nTools.DateFormat_ShortDateTime(DateTime.Now) + " : " + s;
            ctl_contactnotes.SetValue_String(sx);
        }
        //Protected Override Functions
        protected override void DoResize()
        {
            base.DoResize();

            try
            {
                //if (Rz3App.xLogic.UseMergedQuotes)
                //{
                //    result_fquotes.Left = 0;
                //    result_fquotes.Top = 0;
                //    result_fquotes.Width = pageQuotes.ClientRectangle.Width;
                //    result_fquotes.Height = pageQuotes.ClientRectangle.Height;
                //}
                //else
                //{
                //    result_qquotes.Left = 0;
                //    result_qquotes.Top = 0;
                //    result_qquotes.Width = pageQuotes.ClientRectangle.Width;
                //    result_qquotes.Height = Convert.ToInt32(pageQuotes.ClientRectangle.Height / 2);

                //    result_fquotes.Left = 0;
                //    result_fquotes.Top = result_qquotes.Bottom;
                //    result_fquotes.Width = pageQuotes.ClientRectangle.Width;
                //    result_fquotes.Height = pageQuotes.ClientRectangle.Height - result_fquotes.Top;
                //}

                result_orders.Top = 0;
                result_orders.Left = gbOrderOptions.Right + 5;
                result_orders.Height = pageOrders.ClientRectangle.Height;
                result_orders.Width = pageOrders.ClientRectangle.Width;

                lvPhone.Width = pagePhoneNumbers.ClientRectangle.Width - lvPhone.Left;
                lvPhone.Height = pagePhoneNumbers.ClientRectangle.Height - lvPhone.Top;

                ctl_contactnotes.Left = 0;
                ctl_contactnotes.Width = (this.ClientRectangle.Width - 300) / 2;
                ctl_contactnotes.Height = this.ClientRectangle.Height - ctl_contactnotes.Top;

                pNotes.Top = ctl_contactnotes.Top - 4;
                pNotes.BringToFront();

                result_notes.Left = ctl_contactnotes.Right;
                result_notes.Top = pNotes.Bottom;
                result_notes.Height = this.ClientRectangle.Height - result_notes.Top;
                result_notes.Width = ctl_contactnotes.Width;

                lblClearDuplicateNotes.Top = result_notes.Top;
                lblClearDuplicateNotes.Left = result_notes.Right - lblClearDuplicateNotes.Width;
                lblClearDuplicateNotes.BringToFront();

            }
            catch (Exception)
            { }
        }
        //Private Functions
        private void CheckAlternatePhone()
        {
            //if (Rz3App.xLogic.IsCTG)
            //{
            //    if (Tools.Strings.StrExt(ctl_primaryphone.GetValue_String()) && Tools.Strings.StrExt(ctl_alternatephone.GetValue_String()))
            //    {
            //        phonecall.AddAlternatePhone((ContextNM)TheContext, ctl_primaryphone.GetValue_String(), ctl_alternatephone.GetValue_String(), "Alternate");
            //    }
            //}
        }
        private void SaveNewNotes()
        {
            String s = ctl_contactnotes.GetValue_String();
            String[] ary = Tools.Strings.SplitLines(s);
            ArrayList x = new ArrayList();
            foreach (String line in ary)
            {
                if (!Tools.Strings.StrExt(line))
                    continue;
                if (!HasNoteLine(line))
                    x.Add(line);
            }
            if (x.Count > 0)
                SaveAsNote(x);
            OriginalNotes = ctl_contactnotes.GetValue_String();
        }
        private bool HasNoteLine(string line)
        {
            if (!Tools.Strings.StrExt(OriginalNotes))
                return false;
            string[] str = Tools.Strings.Split(OriginalNotes, "\r\n");
            foreach (string s in str)
            {
                if (Tools.Strings.StrCmp(line, s))
                    return true;
            }
            return false;
        }
        private void SaveAsNote(ArrayList a)
        {
            contactnote n = CurrentContact.GetNewNote(RzWin.Context);
            int i = 0;
            foreach (String s in a)
            {
                if (i > 0)
                    n.notetext += "\r\n";
                n.notetext += s;
                i++;
                SetLastNote(s);
            }
            n.Update(RzWin.Context);
            a.Clear();
            TabPageCore oi = RzWin.Form.TabGetByID(CurrentContact.base_company_uid);
            if (oi != null)
            {
                if (oi.TheControl is view_company)
                {
                    view_company vc = (view_company)oi.TheControl;
                    company comp = company.GetById(RzWin.Context, CurrentContact.base_company_uid);
                    vc.TheItem = comp;
                    vc.CurrentCompany = comp;
                }
            }
        }
        private void ShowCallLogs()
        {
            lvCalls.ShowTemplate("calllog", "calllog", RzWin.User.TemplateEditor);
            lvCalls.ShowData("calllog", "base_companycontact_uid = '" + CurrentContact.unique_id + "'", "DATECALL DESC", 200);
        }
        private void ShowNotes()
        {
            result_notes.ShowTemplate("companynotes", "contactnote", RzWin.User.TemplateEditor);
            result_notes.ShowData("contactnote", " ( base_companycontact_uid = '" + CurrentContact.unique_id + "'  or  (  base_company_uid = '" + CurrentContact.base_company_uid + "' and isnull(contactname, '') > '' and contactname = '" + RzWin.Context.Filter(CurrentContact.contactname) + "'  )  ) and isnull(ISACCOUNTING, 0) = 0", "NOTEDATE DESC ", SysNewMethod.ListLimitDefault);
        }
        private void ShowCalls()
        {
            wbCalls.ReloadWB();

            if (!Tools.Strings.StrExt(CurrentContact.primaryphone))
                return;

            //String strCompanyPhone = CurrentContact.xSys.xData.GetScalar("select primaryphone from company where unique_id = '" + CurrentContact.base_company_uid + "'", "");
            //strCompanyPhone = nTools.DistillPhoneNumber(strCompanyPhone);
            //bool boolCompany = Tools.Strings.StrCmp(strCompanyPhone, nTools.DistillPhoneNumber(CurrentContact.primaryphone));

            //strColor = "";
            //if( boolCompany )
            //    strColor = "#222222";
            //else
            String strColor = "blue";

            String strSQL = CurrentContact.GetPhoneCallSQL(RzWin.Context, "username, direction, calldate, phonenumber, duration");
            DataTable d = RzWin.Context.Select(strSQL);
            if (!Tools.Data.DataTableExists(d))
            {
                wbCalls.Add("No calls were found.");
                return;
            }

            foreach (DataRow r in d.Rows)
            {
                wbCalls.Add("<font color=" + strColor + ">" + nData.NullFilter_Date(r["calldate"]).ToString() + "&nbsp;&nbsp;" + nData.NullFilter_String(r["direction"]) + "&nbsp;&nbsp;" + nData.NullFilter_String(r["phonenumber"]) + "&nbsp;&nbsp;" + Tools.Dates.FormatHMS(Convert.ToInt32(nData.NullFilter_Long(r["duration"]))) + "&nbsp;&nbsp;" + nData.NullFilter_String(r["username"]) + "</font><br>");
            }

            wbCalls.Add(Tools.Number.LongFormat(d.Rows.Count) + " call(s).");

            if (RzWin.User.IsDeveloper())
            {
                wbCalls.Add("<br>SQL:<br><br>" + strSQL);
            }
        }
        private void ShowReqs()
        {
            if (RzWin.Logic.UseMergedQuotes)
            {
                result_reqs.ShowTemplate("contact-orderbatches", "dealheader", RzWin.User.TemplateEditor);
                result_reqs.ShowData("dealheader", "unique_id in ( select the_dealheader_uid from dealcompany where the_companycontact_uid = '" + CurrentContact.unique_id + "' )", "date_created desc", 100);
            }
            else
            {
                result_reqs.ShowTemplate("contact-reqs", "req", RzWin.User.TemplateEditor);
                result_reqs.ShowData("req", "base_companycontact_uid = '" + CurrentContact.unique_id + "'", "datecreated desc", 100);
            }
        }
        private void ShowQuotes()
        {
            //if (!Rz3App.xLogic.UseMergedQuotes)
            //{
            //    result_qquotes.ShowTemplate("COMPANYQUOTES", "quote", Rz3App.xUser.TemplateEditor);
            //    result_qquotes.ShowData("quote", "quotetype = 'giving out' and base_companycontact_uid = '" + CurrentContact.unique_id + "'", "quotedate desc", SysNewMethod.ListLimitDefault);
            //}

            //result_fquotes.ShowTemplate("COMPANYFORMALQUOTES", "orddet", Rz3App.xUser.TemplateEditor);
            //result_fquotes.ShowData("orddet", " base_companycontact_uid = '" + Rz3App.RzWin.Context.Filter(CurrentContact.unique_id) + "' or base_ordhed_uid in (select unique_id from ordhed where ordhed.ordertype = 'quote' and ordhed.base_companycontact_uid = '" + CurrentContact.unique_id + "')", "orderdate desc", SysNewMethod.ListLimitDefault);

            quotes_view.RunSearchByCompany(CurrentContact.base_company_uid, CurrentContact.unique_id);
        }
        private void ShowBids()
        {
            result_bids.ShowTemplate("COMPANYQUOTESRFQ", "orddet_rfq", RzWin.User.TemplateEditor);
            result_bids.ShowData("orddet_rfq", "base_companycontact_uid = '" + CurrentContact.unique_id + "'", "orderdate desc", SysNewMethod.ListLimitDefault);
        }
        private void ShowOrders()
        {
            String sw = "";
            if (optQuote.Checked)
                sw = "quote";
            else if (optSales.Checked)
                sw = "sales";
            else if (optPurchase.Checked)
                sw = "purchase";
            else if (optInvoices.Checked)
                sw = "invoice";
            else if (optRMAs.Checked)
                sw = "rma";
            else if (optVRMA.Checked)
                sw = "vendrma";
            if (Tools.Strings.StrExt(sw))
                sw = "base_companycontact_uid = '" + CurrentContact.unique_id + "' and ordertype = '" + sw + "'";
            else
                sw = "base_companycontact_uid = '" + CurrentContact.unique_id + "'";
            result_orders.ShowTemplate("COMPANYORDERS", "ordhed", RzWin.User.TemplateEditor);
            result_orders.ShowData("ordhed", sw, "orderdate desc", SysNewMethod.ListLimitDefault);
        }
        private void ShowFeedback()
        {
            wbFeedback.Clear();
            wbFeedback.Add(RzWin.Context.SelectScalarString("select top 1 feedback from companycontact where unique_id = '" + CurrentContact.unique_id + "'"));
        }
        private void ShowPhoneNumbers()
        {
            lvPhone.Items.Clear();
            if (CurrentContact.companynumber <= 0)
            {
                cmdViewPhone.Enabled = false;
                cmdChangePhone.Enabled = false;
            }



            //DataTable t = CurrentContact.RzWin.Context.Select("select * from alternatephone where base_companycontact_uid = '" + CurrentContact.unique_id + "'");

            DataTable t = phonecall.GetAlternates(RzWin.Context, CurrentContact.primaryphone);

            if (t == null)
            {
                lvPhone.Items.Add("No alternate numbers were found.");
                return;
            }

            if (t.Rows.Count == 0)
            {
                lvPhone.Items.Add("No alternate numbers were found.");
                return;
            }

            foreach (DataRow r in t.Rows)
            {
                ListViewItem l = lvPhone.Items.Add(nData.NullFilter_String((String)r["Alternate Number"]) + " alternate for " + nData.NullFilter_String((String)r["Main Number"]));
                l.Tag = nData.NullFilter_String((String)r["unique_id"]);
                l.SubItems.Add(nData.NullFilter_String((String)r["description"]));
            }
        }
        //Buttons
        private void cmdAddPhone_Click(object sender, EventArgs e)
        {

            if (!Tools.Strings.StrExt(CurrentContact.primaryphone))
            {
                RzWin.Leader.Tell("Please enter a primary phone number for this contact before adding alternate ones.");
                return;
            }

            String strPhone = RzWin.Leader.AskForString("What number do you need to add?", "", "Number?");
            strPhone = nTools.StripPhoneNumber(strPhone);

            if (!Tools.Strings.StrExt(strPhone))
                return;

            String strDescription = RzWin.Leader.AskForString("How do you want to describe this number for this contact?", "Alternate Line", "Description");

            String s = RzWin.Context.SelectScalarString("select realphone from alternatephone where phone = '" + strPhone + "'");

            if (Tools.Strings.StrExt(s))
            {
                RzWin.Context.TheLeader.TellTemp("This phone number has already been entered as an alternate phone number for " + s + ".");
                return;
            }

            phonecall.AddAlternatePhone(RzWin.Context, CurrentContact.primaryphone, strPhone, strDescription);
            ShowPhoneNumbers();
        }
        private void cmdBad_Click(object sender, EventArgs e)
        {
            String strReason = "";
            if (!CurrentContact.MayAssign(RzWin.Context, RzWin.User, ref strReason))
            {
                RzWin.Leader.Tell("This contact could not be marked as 'Bad Record' because " + strReason);
                return;
            }

            if (!RzWin.Leader.AreYouSure("assign this contact to 'Bad Record'"))
                return;

            NewMethod.n_user yUser = NewMethod.n_user.GetByName(RzWin.Context, "Bad Record");
            if (yUser == null)
            {
                RzWin.Context.TheLeader.TellTemp("The 'Bad Record' agent account could not be found.");
                return;
            }

            CompleteSave();
            CurrentContact.base_mc_user_uid = yUser.unique_id;
            CurrentContact.agentname = yUser.name;
            CurrentContact.Update(RzWin.Context);
            CompleteLoad();
        }
        private void cmdRelease_Click(object sender, EventArgs e)
        {
            if (!MayRelease(RzWin.Context))
                return;

            CompleteSave();

            switch (RzWin.User.Name.ToLower().Trim())
            {
                case "recognin technologies":
                    CurrentContact.agentname = "";
                    break;
                case "joe santora":
                    CurrentContact.agentname = "Released: " + RzWin.User.name;
                    break;
                case "john mclaughlin":
                    CurrentContact.agentname = "Released: " + RzWin.User.name;
                    break;
                case "john maclaughlin":
                    CurrentContact.agentname = "Released: " + RzWin.User.name;
                    break;
                case "brian gilchrist":
                    CurrentContact.agentname = "Released: " + RzWin.User.name;
                    break;
                default:
                    n_team t = n_team.GetById(RzWin.Context, RzWin.User.main_n_team_uid);
                    if (t == null)
                        CurrentContact.agentname = "Released: " + RzWin.User.name;
                    else
                        CurrentContact.agentname = "Team: " + t.name;
                    break;
            }

            HandleRelease();

            CurrentContact.base_mc_user_uid = "";
            CurrentContact.Update(RzWin.Context);
            CompleteLoad();
        }
        private void cmdClaim_Click(object sender, EventArgs e)
        {
            CompleteSave();
            if (CurrentContact.TryAssign(RzWin.Context, (n_user)RzWin.Context.xUser))
                CompleteLoad();
        }
        private void cmdPick_Click(object sender, EventArgs e)
        {
            PickAnAddress();
        }
        private void cmdAssign_Click(object sender, EventArgs e)
        {
            String s = "";
            if (!CurrentContact.MayAssign(RzWin.Context, RzWin.User, ref s))
            {
                RzWin.Leader.Tell("This contact cannot be assiged: " + s);
                return;
            }

            n_user u = (n_user)NewMethod.n_user.Choose(RzWin.Context, RzWin.User.SuperUser);
            if (u == null)
                return;

            //user_activity.AddActivity(RzWin.Context, "Contact Assignment", CurrentContact.ToString() + " was assigned from '" + CurrentContact.agentname + "' to " + u.name, CurrentContact);

            CompleteSave();
            CurrentContact.UserObjectSet(u);
            CurrentContact.Update(RzWin.Context);
            CompleteLoad();

            HandleAssign(u);
        }
        private void cmdViewPhone_Click(object sender, EventArgs e)
        {
            ViewWebPhone();
        }
        private void cmdChangePhone_Click(object sender, EventArgs e)
        {
            ChangeWebPhone();
        }
        private void cmdNoAnswer_Click(object sender, EventArgs e)
        {
            AddNote("No Answer");
        }
        private void cmdVoiceMail_Click(object sender, EventArgs e)
        {
            AddNote("Voice Mail");
        }
        private void cmdWrongNumber_Click(object sender, EventArgs e)
        {
            AddNote("Wrong Number");
        }
        private void cmdBadEmail_Click(object sender, EventArgs e)
        {
            AddNote("Bad Email");
        }
        private void cmdSE_Click(object sender, EventArgs e)
        {
            HandleAction(this, new ActArgs(RzWin.Form.TheContextNM, "saveandexit"));
        }
        private void cmdSentEmail_Click(object sender, EventArgs e)
        {
            AddNote("Sent Email");
        }
        private void cmdFollowUp_Click(object sender, EventArgs e)
        {
            DateTime d = frmChooseDate.ChooseDate(DateTime.Now, "Follow Up Date", this.ParentForm);
            if (!Tools.Dates.DateExists(d))
                return;

            d = DateTime.Parse(nTools.DateFormat(d) + " " + nTools.TimeFormat(DateTime.Now));

            AddNote("Follow Up");

            usernote n = usernote.New(RzWin.Context);
            n.subjectstring = "Contact " + CurrentContact.ToString();
            n.notetext = n.subjectstring;
            n.companyname = CurrentContact.companyname;
            n.shouldpopup = true;
            n.Insert(RzWin.Context);

            n.displaydate = d;
            n.Update(RzWin.Context);

            n.CreateObjectLink(RzWin.Context, CurrentContact, CurrentContact.ToString());
        }
        private void cmdUnClaim_Click(object sender, EventArgs e)
        {
            if (!MayRelease(RzWin.Context))
                return;

            CompleteSave();
            CurrentContact.agentname = "";
            CurrentContact.base_mc_user_uid = "";
            CurrentContact.Update(RzWin.Context);
            CompleteLoad();
        }
        //Control Events
        private void view_companycontact_Resize(object sender, EventArgs e)
        {
            DoResize();
        }
        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ts.SelectedTab == pageCalls)
            {
                ShowCalls();
                return;
            }
            if (ts.SelectedTab == pageReqs)
            {
                ShowReqs();
                return;
            }
            if (ts.SelectedTab == pageQuotes)
            {
                ShowQuotes();
                return;
            }
            if (ts.SelectedTab == pageBids)
            {
                ShowBids();
                return;
            }
            if (ts.SelectedTab == pageOrders)
            {
                ShowOrders();
                return;
            }
            if (ts.SelectedTab == pageFeedback)
            {
                ShowFeedback();
                return;
            }

            if (ts.SelectedTab == pagePhoneNumbers)
            {
                ShowPhoneNumbers();
                return;
            }
            if (ts.SelectedTab == pageCallLogs)
            {
                ShowCallLogs();
                return;
            }
        }
        private void optAll_CheckedChanged(object sender, EventArgs e)
        {
            ShowOrders();
        }
        private void result_reqs_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            company c = CurrentContact.TheCompanyVar.RefGet(RzWin.Context);
            dealheader.ShowManualDeal(RzWin.Context, c, CurrentContact);
        }
        private void result_qquotes_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            orddet_quote b = orddet_quote.New(RzWin.Context);
            b.agentname = RzWin.Context.xUser.name;
            b.base_mc_user_uid = RzWin.Context.xUser.unique_id;
            company c = CurrentContact.TheCompanyVar.RefGet(RzWin.Context);
            if (c != null)
            {
                b.base_company_uid = c.unique_id;
                b.companyname = c.companyname;
            }
            if (CurrentContact != null)
            {
                b.base_companycontact_uid = CurrentContact.unique_id;
                b.contactname = CurrentContact.contactname;
            }
            b.orderdate = DateTime.Now;
            b.Insert(RzWin.Context);
            RzWin.Context.Show(b);
        }
        private void result_bids_AboutToAdd(object sender, AddArgs args)
        {            
            args.Handled = true;
            orddet_rfq b = orddet_rfq.New(RzWin.Context);
            b.agentname = RzWin.Context.xUser.name;
            b.base_mc_user_uid = RzWin.Context.xUser.unique_id;
            company c = CurrentContact.TheCompanyVar.RefGet(RzWin.Context);
            if (c != null)
            {
                b.base_company_uid = c.unique_id;
                b.companyname = c.companyname;
            }
            if (CurrentContact != null)
            {
                b.base_companycontact_uid = CurrentContact.unique_id;
                b.contactname = CurrentContact.contactname;
            }
            b.orderdate = DateTime.Now;
            b.Insert(RzWin.Context);
            RzWin.Context.Show(b);
        }
        private void result_notes_AboutToAdd(object sender, AddArgs args)
        {
            args.Handled = true;
            contactnote n = CurrentContact.GetNewNote(RzWin.Context);
            RzWin.Context.Show(n);
        }
        private void lvCalls_AboutToAdd(object sender, AddArgs args)
        {
            try
            {
                args.Handled = true;
                calllog n = calllog.New(RzWin.Context);
                n.base_company_uid = CurrentContact.base_company_uid;
                n.base_companycontact_uid = CurrentContact.unique_id;
                n.callcompanyname = CurrentContact.companyname;
                n.contactname = CurrentContact.contactname;
                n.base_mc_user_uid = RzWin.User.unique_id;
                n.agentname = RzWin.User.name;
                n.datecall = System.DateTime.Now;
                n.Insert(RzWin.Context);
                RzWin.Context.Show(n);
            }
            catch (Exception)
            { }
        }
        private void lblRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ShowWebsiteInfo(wbWebsite, Rz3App.xLogic.GetWebsiteData(), Rz3App.xLogic.GetWebsiteSetup() );
        }
        private void lblRefresh2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //ShowWebsiteInfo(wbWebsite2, Rz3App.xLogic.GetAlternateWebData(), Rz3App.xLogic.GetAlternateWebsiteSetup());
        }
        private void lblNoAnswer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNote("No Answer");
        }
        private void lblVoiceMail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNote("Voice Mail");
        }
        private void lblWrongNumber_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNote("Wrong Number");
        }
        private void lblBadEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddNote("Bad Email");
        }
        private void lblClearDuplicateNotes_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ArrayList nids = result_notes.GetAllIDs();
            if (nids.Count < 2)
                return;

            if (!RzWin.Leader.AreYouSure("clear duplicate notes for " + CurrentContact.ToString()))
                return;

            foreach (String s in nids)
            {
                contactnote n = (contactnote)RzWin.Context.GetById("contactnote", s);
                if (n != null)
                {
                    if (RzWin.Context.Data.StatementExists("select * from contactnote where base_companycontact_uid = '" + CurrentContact.unique_id + "' and datediff(d, notedate, cast('" + nTools.DateFormat(n.notedate) + "' as datetime)) = 0 and unique_id <> '" + n.unique_id + "' and notetext = '" + RzWin.Context.Filter(n.notetext) + "'"))
                        n.Delete(RzWin.Context);
                }
            }

            result_notes.ReDoSearch();
        }
        private void lblCheckPhone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //phonecall.InspectPhoneNumber(ctl_primaryphone.GetValue_String());
        }
        private void lblCheckAlternatePhone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //phonecall.InspectPhoneNumber(ctl_alternatephone.GetValue_String());
        }

        private void ctl_personality_type_SelectionChanged(GenericEvent e)
        {
            if (ctl_personality_type.GetValue_String().Length > 0)
            {
                lbl_expect.Visible = true;
                lbl_trait.Visible = true;
                lbl_interact.Visible = true;
            }




            if (ctl_personality_type.cboValue.Text == "Amicable")
            {
                lbl_expectation.Text = "Don't like confrontation.  They won't tell you what they are thinking.";
                lbl_traits.Text = "Kind, warm, gentle; will go out of their way to help you.";
                lbl_interaction.Text = "Ask a lot of questions.  Be selectively assertive.";

            }
            else if (ctl_personality_type.cboValue.Text == "Analytical")
            {
                lbl_expectation.Text = "Calls and sales process will be longer.  Can't be forced to make a decision.";
                lbl_traits.Text = "Cautious, precise, detail-oriented, slow to make decisions.";
                lbl_interaction.Text = "Present facts.  Be consistent with your interactions and follow-through.";
            }
            else if (ctl_personality_type.cboValue.Text == "Driver")
            {
                lbl_expectation.Text = "Have a system and process for everything.";
                lbl_traits.Text = "Blunt, direct, know what's best.";
                lbl_interaction.Text = "Be blunt and direct, don't 'Waste their time'.";
            }
            else if (ctl_personality_type.cboValue.Text == "Expressive")
            {
                lbl_expectation.Text = "Don't tend to listen.  They like to talk.";
                lbl_traits.Text = "Social, outgoing, life of the party.";
                lbl_interaction.Text = "Listen.  Be upbeat and Excited.";
            }
            else
            {
                lbl_expectation.Text = "";
                lbl_traits.Text = "";
                lbl_interaction.Text = "";
            }
            
        }

        

        

       
    }
}

