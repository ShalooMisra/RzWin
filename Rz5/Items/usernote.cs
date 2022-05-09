using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Drawing;

using Tools;
//using ToolsWin;
using Core;
//using CoreWin;
using NewMethod;

namespace Rz5
{
    public partial class usernote : usernote_auto
    {
        //Public Static Functions
        public void CompanyApply(ContextNM context)
        {
            ArrayList notes = new ArrayList();
            notes.Add(this);
            usernote.CompanyApply((ContextRz)context, notes);
        }

        public static void CompanyApply(ContextRz context, ArrayList notes)
        {
            company c = null;
            companycontact cc = null;
            context.Leader.ChooseCompany(context, ref c, ref cc);
            if (c == null)
                return;
            foreach (usernote n in notes)
            {
                n.base_company_uid = c.unique_id;
                n.companyname = c.companyname;
                if (cc != null)
                {
                    n.the_companycontact_uid = cc.unique_id;
                    n.contactname = cc.contactname;
                }
                n.Update(context);
            }
        }

        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch(args.ActionName.ToLower())
            {
                case "postpone":
                    DoAction_Postpone(args);
                    break;
                case "reply":
                    DoAction_Reply(args);
                    break;
                case "dismiss":
                    DoAction_Dismiss(args);
                    break;
                case "doclose":
                    DoAction_Close(args);
                    break;
                case "forward":
                    Forward((ContextRz)args.TheContext, true);
                    break;
                case "applyacompany":
                    CompanyApply((ContextNM)args.TheContext);
                    break;
                default:
                    base.HandleAction(args);
                    break;
            }
        }

        public override void Inserting(Context x)
        {
            ContextRz xrz = (ContextRz)x;
            if( !Tools.Strings.StrExt(by_mc_user_uid) )
                by_mc_user_uid = xrz.xUser.unique_id;
            if( !Tools.Strings.StrExt(for_mc_user_uid) )
                for_mc_user_uid = xrz.xUser.unique_id;

            displaydate = DateTime.Now;
            date_created = DateTime.Now;
            base.Inserting(x);            
        }

        public override void Updating(Context x)
        {
            ContextRz xrz = (ContextRz)x;

            NewMethod.n_user.FillIn(xrz, this, "by_mc_user_uid", "createdbyname");
            NewMethod.n_user.FillIn(xrz, this, "for_mc_user_uid", "createdforname");
            company.FillIn(xrz, this, "base_company_uid", "companyname");
            if (Tools.Strings.StrExt(this.base_company_uid) && Tools.Strings.StrExt(this.the_companycontact_uid))
                companycontact.FillIn(xrz, this, "the_companycontact_uid", "contactname", this.base_company_uid);
            //company.SetLastActivity(this.base_company_uid, this.displaydate);

            if (is_task)
            {
                grid_color = ColorByStatus(current_status).ToArgb();

                TagNamedSet("Status", current_status);
                TagNamedSet("Size", task_size);
                TagNamedSet("Type", task_type);

                tag_summary = Tools.Strings.CommaSeparateBlanksIgnore(TagsNotNamed);
            }

            base.Updating(x);
        }

        public static Color ColorByStatus(String s)
        {
            switch (s)
            {
                case "Need More Info":
                    return  Color.Red;
                case "Done":
                    return Color.Blue;
                case "Ready To Test":
                    return Color.Green;
                case "Closed":
                    return Color.Gray;
                default:
                    return Color.Black;
            }
        }

        //Public Functions
        public void CreateObjectLink(ContextRz context, nObject xObject, String strCaption)
        {
            if( xObject == null )
                return;
            filelink xLink = filelink.New(context);
            xLink.linktype = "Note";
            xLink.objectclass = "usernote";
            xLink.objectid = unique_id;
            xLink.objectclass2 = xObject.ClassId;
            xLink.objectid2 = xObject.unique_id;
            xLink.linkname = strCaption;
            if(Tools.Strings.StrCmp(xObject.ClassId, "company"))
            {
                this.base_company_uid = xObject.unique_id;
                context.Update(this);
            }
            else if (Tools.Strings.StrCmp(xObject.ClassId, "companycontact"))
            {
                companycontact cc = null;
                if (xObject is companycontact)
                    cc = (companycontact)xObject;
                this.base_company_uid = cc.base_company_uid;
                this.the_companycontact_uid = cc.unique_id;
                context.Update(this);
            }
            context.Insert(xLink);
        }

        public void DoAction_Postpone(ActArgs args)
        {
            ContextRz xrz = (ContextRz)args.TheContext;
            DateTime selectedDate = xrz.TheLeaderRz.AskPostpone(xrz, this.displaydate);
            if (!Tools.Dates.DateExists(selectedDate))
                return;

            this.displaydate = selectedDate;
        }
        public usernote DoAction_Reply(ActArgs args)
        {
            return Reply(args, true);
        }
        public usernote Reply(ActArgs args, bool show)
        {
            usernote xNote = usernote.New(args.TheContext);
            args.TheContext.Insert(xNote);
            xNote.notetext = "\r\n\r\n" + notetext;
            xNote.createdforname = "";
            xNote.createdbyname = "";
            xNote.for_mc_user_uid = by_mc_user_uid;
            xNote.by_mc_user_uid = for_mc_user_uid;
            xNote.is_pending = true;
            xNote.shouldpopup = true;
            xNote.subjectstring = subjectstring;
            xNote.companyname = companyname;
            xNote.fullpartnumber = fullpartnumber;
            args.TheContext.Update(xNote);
            //add the links

            ArrayList a = args.TheContext.QtC("filelink", "SELECT * FROM filelink WHERE OBJECTID = '" + unique_id + "'");
            foreach (filelink xLink in a)
            {
                filelink z = (filelink)xLink.CloneValues(args.TheContext);
                z.objectid = xNote.unique_id;
                args.TheContext.Insert(z);
            }

            if (show)
                args.TheContext.Show(xNote);
            args.ShouldClose = true;
            return xNote;
        }
        public usernote DoAction_Forward(ContextRz context)
        {
            return Forward(context, true);
        }
        public usernote Forward(ContextRz context, bool show)
        {
            usernote xNote = usernote.New(context);
            context.Insert(xNote);
            xNote.notetext = "\r\n\r\nForwarded on " + nTools.DateFormat_ShortDateTime(System.DateTime.Now) + ":\r\n" + notetext;
            xNote.for_mc_user_uid = by_mc_user_uid;
            xNote.by_mc_user_uid = by_mc_user_uid;
            xNote.is_pending = true;
            xNote.shouldpopup = true;
            xNote.subjectstring = subjectstring;
            xNote.companyname = companyname;
            xNote.fullpartnumber = fullpartnumber;
            context.Update(xNote);
            //add the links
            ArrayList a = context.QtC("filelink", "SELECT * FROM filelink WHERE OBJECTID = '" + unique_id + "'");
            foreach(filelink xLink in a)
            {
                filelink z = (filelink)xLink.CloneValues(context);
                z.objectid = xNote.unique_id;
                context.Insert(z);
            }
            if (show)
                context.Show(xNote);
            //args.ShouldClose = true;
            return xNote;
        }
        public void DoAction_Dismiss(ActArgs args)
        {
            DoAction_Close(args);
        }
        public void DoAction_Close(ActArgs args)
        {
            //this.isclosed = true;
            this.shouldpopup = false;
            args.TheContext.Update(this);
            args.ShouldClose = true;
        }
        public String GetClipHTML(ContextRz context)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<b>From:</b>&nbsp;" + this.createdbyname + "<br>");
            sb.AppendLine("<b>To:</b>&nbsp;" + this.createdforname + "<br>");
            sb.AppendLine("<b>On:</b>&nbsp;" + nTools.DateFormat_ShortDateTime(this.date_created) + "<br>");
            sb.AppendLine("<b>Subject:</b>&nbsp;" + this.subjectstring + "<br>");

            ArrayList objects = LinkedObjects(context);
            if (objects.Count > 0)
            {
                sb.AppendLine("Attachments:<br>");
                foreach (filelink xLink in objects)
                {
                    if (Tools.Strings.StrExt(xLink.linkname))
                    {
                        sb.AppendLine(xLink.linkname + "<br>");
                    }
                }
            }

            sb.AppendLine("<br><hr><br>");
            sb.AppendLine(nTools.ConvertTextToHTML_AllowBreaks(notetext));
            return sb.ToString();
        }

        public ArrayList LinkedObjects(ContextRz context)
        {
            return context.QtC("filelink", "SELECT * FROM filelink WHERE OBJECTID = '" + unique_id + "'");
        }

        //Private Functions
        private void DeleteNotes(ContextRz context)
        {
            if (!Tools.Strings.StrExt(notetype))
            {
                context.Delete(this);
                return;
            }

            if (!Tools.Strings.StrExt(the_ordhed_uid))
            {
                context.Delete(this);
                return;
            }

            switch(notetype.ToLower())
            {
                case "packingslipcomplete":
                case "creditcheck":
                case "pickticketcreate":
                case "cccharged":
                case "purchaseordercreation":
                    DeleteSimilarNotes(context);
                    break;
                default:
                    context.Delete(this);
                    break;
            }
        }
        private void DeleteSimilarNotes(ContextRz context)
        {
            context.Execute("delete from usernote where the_ordhed_uid = '" + the_ordhed_uid + "' and notetype = '" + notetype + "'");
        }

        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {
            return true;
        }

        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            return true;
        }

        public override bool CanBeDeletedBy(ContextNM context, ShowArgs args)
        {
            return true;
        }

        public static ArrayList GetByObject(ContextRz context, nObject x)
        {
            return GetByObject(context, x, false);
        }

        public static ArrayList GetByObject(ContextRz context, nObject x, bool desc)
        {
            String s = "select * from usernote where unique_id in ( select objectid from filelink where objectid2 = '" + x.unique_id + "') order by displaydate";
            if (desc)
                s += " desc";

            return context.QtC("usernote", s);
        }

        //tasks

        VarRefTasks m_Tasks = null;

        public IItems TasksGetItems(ContextNM context)
        {
            return m_Tasks.RefsGetAsItems(context);
        }

        public List<usernote> TasksGet(ContextNM context)
        {
            List<usernote> ret = new List<usernote>();
            foreach (usernote n in TasksGetItems(context).AllGet(context))
            {
                ret.Add(n);
            }
            return ret;
        }

        //public void TasksInsertBefore(ContextNM context, ArrayList tasks, usernote before)
        //{
        //    List<usernote> result = new List<usernote>();

        //    foreach (usernote n in TasksGet(context))
        //    {
        //        if (tasks.Contains(n))
        //            continue;

        //        if (n == before)
        //        {
        //            foreach (usernote insert in tasks)
        //            {
        //                result.Add(insert);
        //            }                    
        //        }

        //        result.Add(n);
        //    }

        //    //this would unhook any listviews tied to this instance of m_tasks; that needs to be preserved
        //    //m_Tasks = result;

        //    m_Tasks.Replace(result);

        //    //m_Tasks.Clear();
        //    //foreach (usernote ins in result)
        //    //{
        //    //    m_Tasks.Add(ins.unique_id, ins);
        //    //}

        //    TasksSave(context);
        //}

        public List<usernote> FoldersGet(ContextNM context)
        {
            List<usernote> ret = new List<usernote>();
            foreach (usernote n in TasksGet(context))
            {
                if( n.is_folder)
                    ret.Add(n);
            }
            return ret;
        }

        void TasksInit(ContextNM context)
        {
            m_Tasks = new VarRefTasks(this);
        }

        public List<String> TaskIds(ContextNM context)
        {
            List<String> ret = new List<string>();
            foreach (usernote n in TasksGetItems(context).AllGet(context))
            {
                ret.Add(n.unique_id);
            }
            return ret;
        }

        public void TasksSave(ContextNM context)
        {
            StringBuilder c = new StringBuilder();
            foreach (usernote n in TasksGet(context))
            {
                c.AppendLine(n.unique_id);
            }
            child_info = c.ToString();
            context.Update(this);
        }

        public usernote FolderAdd(ContextNM context)
        {
            String name = context.TheLeader.AskForString("Folder name");
            if (!Tools.Strings.StrExt(name))
                return null;

            usernote n = usernote.FolderGetBySubject(context, name);
            if (n != null)
            {
                context.TheLeader.Error("A folder with the name " + name + " already exists");
                return null;
            }

            return FolderAdd(context, name);
        }

        public usernote FolderAdd(ContextNM context, String name)
        {
            usernote ret = usernote.New(context);
            ret.is_task = true;
            ret.is_folder = true;
            ret.subjectstring = name;
            context.Insert(ret);

            TaskAdd(context, ret);

            TasksInit(context);
            m_Tasks.RefsAdd(context, ret);
            return ret;
        }

        public usernote TaskAdd(ContextNM context)
        {
            usernote n = usernote.New(context);
            context.Insert(n);

            n.is_folder = false;
            n.is_task = true;

            if (Tools.Strings.StrExt(this.for_mc_user_uid))
                n.CreatedFor = (n_user)context.xSys.Users.GetByID(for_mc_user_uid);

            context.Update(n);
            TaskAdd(context, n);

            return n;
        }

        public void TaskAdd(ContextNM context, usernote add)
        {
            if( m_Tasks == null )
                TasksInit(context);
            m_Tasks.RefsAdd(context, add);
        }

        public void TaskRemove(ContextNM context, usernote remove)
        {
            if (m_Tasks == null)
                TasksInit(context);

            m_Tasks.RefsRemove(context, remove);

            //m_Tasks.RemoveById(context, remove.unique_id);
            TasksSave(context);
        }

        public void TasksReCache(ContextNM context)
        {
            if (m_Tasks != null)
            {
                //m_Tasks.Clear(context);  //this disappeared during the reorg?
                m_Tasks = null;
            }

            TasksInit(context);
        }

        public static ListArgs TaskSearchArgsGet(ContextNM context, TaskSearchParameters pars)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheClass = "usernote";
            ret.TheTemplate = "task_notes";
            ret.AddAllow = false;
            ret.TheWhere = "isnull(is_task, 0) = 1 and isnull(is_folder, 0) = 0 ";
            
            if( Tools.Strings.StrExt(pars.SearchTerm) )
                ret.TheWhere += " and ( subjectstring like '%" + context.Filter(pars.SearchTerm) + "%' or notetext like '%" + context.Filter(pars.SearchTerm) + "%' or tags like '%" + context.Filter(pars.SearchTerm) + "%' )";

            if (Tools.Strings.StrExt(pars.ByUserId))
                ret.TheWhere += " and by_mc_user_uid = '" + pars.ByUserId + "'";

            if (Tools.Strings.StrExt(pars.ForUserId))
                ret.TheWhere += " and for_mc_user_uid = '" + pars.ForUserId + "'";

            foreach (String tag in pars.Tags)
            {                
                ret.TheWhere += " and CHARINDEX('<" + context.Filter(tag) + ">', tags) > 0 ";
            }

            ret.TheOrder = "date_created";
            return ret;
        }

        public static usernote FolderRootMakeExist(ContextNM context, NewMethod.n_user u)
        {
            usernote ret = usernote.FolderGetBySubject(context, "Priorities For " + u.Name);
            if (ret == null)
            {
                ret = usernote.New(context);
                ret.subjectstring = "Priorities For " + u.Name;
                ret.CreatedBy = u;
                ret.CreatedFor = u;
                ret.is_task = true;
                ret.is_folder = true;
                context.Insert(ret);
            }

            if (!Tools.Strings.StrCmp(ret.for_mc_user_uid, u.unique_id))
            {
                ret.CreatedFor = u;
                context.Update(ret);
            }

            ret.TasksInit(context);

            List<usernote> remove = new List<usernote>();
            foreach (usernote n in ret.TasksGet(context))
            {
                if (n.current_status == "Closed" || !Tools.Strings.StrCmp(n.createdforname, u.name))
                    remove.Add(n);
            }

            foreach (usernote rem in remove)
            {
                ret.TaskRemove(context, rem);
            }

            //add the ones that aren't already there
            String sql = "select * from usernote where for_mc_user_uid = '" + u.unique_id + "' and isnull(isclosed, 0) = 0 and current_status <> 'Closed' and unique_id <> '" + ret.unique_id + "'";
            List<String> ids = ret.TaskIds(context);
            if( ids.Count > 0 )
                sql += " and unique_id not in ( " + Tools.Data.GetIn(ids) + " ) ";
            sql += " order by importance, date_created";

            ArrayList notes = context.QtC("usernote", sql);
            if (notes.Count > 0)
            {
                foreach (usernote n in notes)
                {
                    ret.TaskAdd(context, n);
                }
                ret.TasksSave(context);
            }
            
            return ret;
        }

        //public static usernote FolderPriorityMakeExist(ContextNM context, NewMethod.n_user u)
        //{
        //    usernote p = FolderRootMakeExist(context, u);
        //    return p.FolderSubMakeExist(context, "Priorities For " + u.name);
        //}

        //public static usernote FolderPriorityMakeExistFromTo(ContextNM context, NewMethod.n_user from, NewMethod.n_user to)
        //{
        //    usernote p = FolderPriorityMakeExist(context, to);
        //    usernote ret = p.FolderSubMakeExist(context, "Priorities For " + to.Name + " From " + from.name);
        //    ret.CreatedBy = from;
        //    ret.CreatedFor = from;
        //    ret.IUpdate();

        //    usernote r = FolderRootMakeExist(context, from);
        //    r.TaskAdd(context, ret);

        //    return ret;
        //}

        public usernote FolderSubGetBySubject(ContextNM context, String name)
        {
            foreach (usernote n in TasksGet(context))
            {
                if (Tools.Strings.StrCmp(n.subjectstring, name))
                    return n;
            }

            return null;
        }

        public static usernote FolderGetBySubject(ContextNM context, String subject)
        {
            return FolderGetBySubject(context, subject, "");
        }

        public static usernote FolderGetBySubject(ContextNM context, String subject, String except_id)
        {
            String sql = "select * from usernote where is_task = 1 and is_folder = 1 and subjectstring = '" + context.Filter(subject) + "'";
            if( Tools.Strings.StrExt(except_id) )
                sql += " and unique_id <> '" + except_id + "'";
            return (usernote)context.QtO("usernote", sql);
        }

        public bool FolderChangePossible(ContextNM context, String name)
        {
            if( !Tools.Strings.StrExt(name) )
            {
                context.TheLeader.Error("Enter a name");
                return false;
            }

            usernote n = FolderGetBySubject(context, name, this.unique_id);
            if (n != null)
            {
                context.TheLeader.Error("The folder " + name + " already exists");
                return false;
            }

            return true;
        }

        public usernote FolderSubMakeExist(ContextNM context, String name)
        {
            usernote ret = FolderSubGetBySubject(context, name);
            if (ret != null)
                return ret;

            ret = FolderAdd(context, name);
            return ret;
        }

        public ListArgs TaskArgsGet(ContextNM context)
        {
            ListArgs ret = new ListArgs(context);
            ret.LiveItems = TasksGetItems(context);
            ret.TheClass = "usernote";
            ret.TheTemplate = "task_notes";
            ret.AddAllow = false;
            return ret;
        }

        public override string ToString()
        {
            return subjectstring;
        }

        public NewMethod.n_user CreatedBy
        {
            set
            {
                if( value == null )
                {
                    by_mc_user_uid = "";
                    createdbyname = "";
                }
                else
                {
                    by_mc_user_uid = value.unique_id;
                    createdbyname = value.name;
                }
            }            
        }

        public NewMethod.n_user CreatedFor
        {
            set
            {
                if (value == null)
                {
                    for_mc_user_uid = "";
                    createdforname = "";
                }
                else
                {
                    for_mc_user_uid = value.unique_id;
                    createdforname = value.name;
                }
            }
        }

        public void AttachmentsCalc(ContextRz context)
        {
            attachment_count = context.Logic.PictureData.ScalarInt32("select count(*) from partpicture where the_orddet_uid = '" + unique_id + "'");
        }

        public void AttachmentsShow(ContextRz context)
        {
            context.Reorg();
            //try
            //{
            //    frmPartPictureViewer xPPV = new frmPartPictureViewer();
            //    xPPV.CompleteLoad();
            //    xPPV.LoadFormBy(this);
            //    xPPV.ShowPartNumberLink = false;
            //    xPPV.ShowDialog();
            //    AttachmentsCalc();
            //    IUpdate();
            //}
            //catch (Exception)
            //{
            //}
        }

        public List<String> Tags
        {
            get
            {
                List<String> ret = new List<string>();
                String[] chunks = Tools.Strings.Split(tags, ">");
                foreach (String c in chunks)
                {
                    if( c.Length > 0 )
                        ret.Add(c.Substring(1));
                }
                return ret;
            }

            set
            {
                StringBuilder sb = new StringBuilder();
                foreach (String s in value)
                {
                    sb.Append("<" + s.Replace("<", "[").Replace(">", "]") + ">");
                }
                tags = sb.ToString();
            }
        }

        public List<String> TagsNamed
        {
            get
            {
                List<String> ret = new List<string>();
                foreach (String tag in Tags)
                {
                    if (tag.Contains(":"))
                        ret.Add(tag);
                }
                return ret;                
            }
        }

        public List<String> TagsNotNamed
        {
            get
            {
                List<String> ret = new List<string>();
                foreach (String tag in Tags)
                {
                    if (!tag.Contains(":"))
                        ret.Add(tag);
                }
                return ret;
            }
        }

        public void TagNamedSet(String name, String value)
        {
            List<String> from = Tags;
            List<String> to = new List<string>();
            foreach (String tag in from)
            {
                if (!tag.StartsWith(name + ":"))
                    to.Add(tag);
            }

            if (Tools.Strings.StrExt(value))  //leave it out if the new value is blank
                to.Add(name + ":" + value);

            Tags = to;
        }

        public void EventAdd(ContextNM context, String from_status, String from_user, String note)
        {
            task_event evt = task_event.New(context);
            evt.event_date = DateTime.Now;
            evt.User = context.xUser;
            evt.from_user = from_user;
            evt.to_user = createdforname;
            evt.from_status = from_status;
            evt.to_status = current_status;
            evt.notes = note;
            evt.task_uid = unique_id;
            context.Insert(evt);
        }

        public String Summary
        {
            get
            {
                String ret = "";

                if (Tools.Strings.StrExt(task_type))
                    ret += "(" + task_type + ")";
                
                if( Tools.Strings.StrExt(subjectstring) )
                    ret += " " + subjectstring;

                if( Tools.Strings.StrExt(companyname) )
                    ret += " [" + companyname + "]";

                if (Tools.Strings.StrExt(tag_summary))
                    ret += " " + tag_summary;

                return ret;
            }
        }
    }

    public class TaskSearchParameters
    {
        public String ForUserId = "";
        public String ByUserId = "";
        public String SearchTerm = "";
        public List<String> Tags = new List<String>();

        public bool Valid
        {
            get
            {
                if (Tools.Strings.StrExt(SearchTerm))
                    return true;

                if (Tools.Strings.StrExt(ByUserId))
                    return true;

                if (Tools.Strings.StrExt(ForUserId))
                    return true;

                if (Tags.Count > 0)
                    return true;

                return false;
            }
        }

        public void TagAddIfExists(String name, String value)
        {
            if (!Tools.Strings.StrExt(value))
                return;

            Tags.Add(name + ":" + value);
        }
    }

    public class VarRefTasks : VarRefMany<usernote, usernote>
    {
        usernote ParentNote
        {
            get
            {
                return (usernote)Parent;
            }
        }

        public VarRefTasks(usernote parent) : base(parent, new CoreVarRefManyAttribute("Tasks", "Rz4.usernote", "Rz4.usernote", "", ""))
        {
        }

        //this was for the tree structure of the tasks, right?
        //public override void TheItemsInit(Context x, ItemsInstance items)
        //{
        //    m_TheItems = new ItemsInstanceWatched();
        //    foreach (String s in Tools.Strings.SplitLinesList(ParentNote.child_info))
        //    {
        //        if (Tools.Strings.StrExt(s))
        //        {
        //            usernote n = usernote.GetByID(((ContextNM)x).xSys, s);
        //            if (n != null)
        //                m_TheItems.AddSingle(n);
        //        }
        //    }
        //}

        public void Replace(Context x, List<usernote> tasks)
        {
            m_TheItems.Clear(x);
            foreach (usernote n in tasks)
            {
                m_TheItems.AddSingle(n);
            }
        }

        public override void RefsAdd(Context x, IItems items, bool includeReverse)
        {
            base.RefsAdd(x, items, includeReverse);
            ParentNote.TasksSave((ContextNM)x);
        }
    }
}