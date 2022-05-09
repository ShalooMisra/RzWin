using System;
using System.Collections.Generic;
using System.Text;

using Core;
using System.Collections;
using NewMethod;

namespace Rz5
{
    public partial class creditmemo_hed : creditmemo_hed_auto
    {
        List<creditmemo_det> Details;

        public creditmemo_hed()
        {

        }
        public override string ToString()
        {
            return "Credit Memo " + ordernumber;
        }
        public override void Updating(Context x)
        {
            base.Updating(x);
            ordertotal = 0;
            foreach (creditmemo_det d in DetailsList((ContextRz)x))
            {
                d.Updating((ContextRz)x);
                ordertotal += d.total_price;
            }
        }
        public void AbsorbCompany(ContextRz context, company xCompany)
        {
            if (xCompany == null)
            {
                companyname = "";
                base_company_uid = "";
            }
            else
            {
                companyname = xCompany.companyname;
                base_company_uid = xCompany.unique_id;
            }
        }
        public void AbsorbContact(ContextRz context, companycontact xContact)
        {
            if (xContact == null)
            {
                contactname = "";
                base_companycontact_uid = "";
            }
            else
            {
                contactname = xContact.contactname;
                base_companycontact_uid = xContact.unique_id;
            }
        }
        public int PictureCount(ContextRz context, bool countLines = true, String extraWhere = "")
        {
            List<String> details_ids = new List<string>();
            foreach (creditmemo_det l in DetailsList(context))
            {
                details_ids.Add(l.unique_id);
            }
            String search = "select count(*) from partpicture where ( the_ordhed_uid = '" + this.unique_id + "'";
            if (countLines && details_ids.Count > 0)
                search += " or the_orddet_uid in (" + Tools.Data.GetIn(details_ids) + ")";
            search += " ) ";
            if (Tools.Strings.StrExt(extraWhere))
                search += " and " + extraWhere;
            return context.TheLogicRz.PictureData.GetScalar_Integer(search);
        }
        public List<creditmemo_det> DetailsList(ContextRz context, bool force_recache = false)
        {
            if (Details == null || Details.Count <= 0)
                force_recache = true;
            if (force_recache)
            {
                ArrayList a = context.QtC("creditmemo_det", "select * from creditmemo_det where the_creditmemo_hed_uid = '" + unique_id + "'");
                Details = new List<creditmemo_det>();
                foreach (creditmemo_det c in a)
                {
                    Details.Add(c);
                }
            }
            return Details;
        }
        public ListArgs DetailArgsGet(ContextRz context)
        {
            ListArgs ret = new ListArgs(context);
            ret.TheClass = "creditmemo_det";
            ret.TheTable = "creditmemo_det";                        
            ret.TheTemplate = "creditmemo_det_lv";            
            ret.AddAllow = true;
            ret.AddCaption = "Add A New Credit Memo Line";
            ret.TheCaption = "Credit Memo Line Items";
            ret.TheWhere = "the_creditmemo_hed_uid = '" + unique_id + "'";
            return ret;
        }
        public bool CanAssignCompany(ContextRz context, company c)
        {
            if (c.is_locked)
            {
                context.Leader.Tell(c.ToString() + " is marked as 'Locked'");
                if (!context.xUser.SuperUser)
                    return false;
            }

            if (c.HasAnyProblems)
            {
                context.TheLeader.Error("Please note that '" + c.companyname + "' has been " + c.ProblemDescription + ".");
                context.Logic.NotifyAccounting(context, this, "Problem Customer Credit Memo", "This Credit Memo was created for a problem customer.");
            }
            return true;
        }
        public bool CanAssignContact(ContextRz context, companycontact c)
        {
            if (context.xUser.SuperUser)
                return true;
            if (c.bad_data)
            {
                context.TheLeader.Error(c.ToString() + " is marked as having bad contact data, and cannot be assigned to a Credit Memo.");
                return false;
            }
            if (Tools.Strings.StrCmp(c.agentname, "bad record"))
            {
                context.TheLeader.Error(c.ToString() + " is marked as 'BAD RECORD', and cannot be assigned to a Credit Memo.");
                return false;
            }
            if (!Tools.Strings.StrExt(c.base_mc_user_uid))
                return true;
            if (Tools.Strings.StrCmp(c.base_mc_user_uid, context.xUser.unique_id))
                return true;
            return true;
        }
        public creditmemo_det GetNewDetail(ContextRz context)
        {
            creditmemo_det d = new creditmemo_det();
            d.Type = this.Type;
            d.base_company_uid = this.base_company_uid;
            d.base_companycontact_uid = this.base_companycontact_uid;
            d.companyname = this.companyname;
            d.contactname = this.contactname;
            d.orderdate = this.orderdate;
            d.ordernumber = this.ordernumber;
            d.the_creditmemo_hed_uid = this.unique_id;
            d.linecode = GetNextLineCode(context);
            d.Insert(context);
            return d;
        }
        public int GetNextLineCode(ContextRz context)
        {
            int winner = 0;
            foreach (creditmemo_det d in DetailsList(context))
            {
                int l = d.linecode;
                if (l > winner)
                    winner = l;
            }
            return winner + 1;
        }
        public creditmemo_det DetailsByIdGet(ContextRz context, string id)
        {
            foreach (creditmemo_det d in DetailsList(context))
            {
                if (Tools.Strings.StrCmp(d.unique_id, id))
                    return d;
            }
            return null;
        }
        public void NumberChange(ContextRz context)
        {
            if (!context.xUser.CheckPermit(context, "Orders:Numbering:ChangeOrderNumbers", true))
                return;
            String s = context.TheLeader.AskForString("New Credit Memo number", ordernumber, false);
            if (!Tools.Strings.StrExt(s))
                return;
            if (Tools.Strings.StrCmp(s, ordernumber))
                return;
            string id = context.SelectScalarString("select unique_id from creditmemo_hed where ordernumber = '" + context.Filter(s) + "'");
            if (Tools.Strings.StrExt(id))
            {
                context.TheLeader.Tell("There is already a Credit Memo in the system with the number: " + s);
                return;
            }
            ordernumber = s;
            UpdateLineOrderNumbers(context);
            context.Update(this);
        }
        public void DateChange(ContextRz context)
        {
            DateTime d = context.TheLeaderRz.ChooseDate(orderdate, "Choose a new order date:");
            if (!Tools.Dates.DateExists(d))
                return;
            orderdate = d;
            context.TheDelta.Update(context, this);
            foreach (creditmemo_det detail in DetailsList(context))
            {
                detail.orderdate = d;
                context.TheDelta.Update(context, detail);
            }
        }
        public void UpdateLineOrderNumbers(ContextRz context)
        {
            if (!Tools.Strings.StrExt(ordernumber))
                return;
            foreach (creditmemo_det d in DetailsList(context))
            {
                d.ordernumber = ordernumber;
                context.Update(d);
            }
        }
        public bool PostCreditMemoPossible(ContextRz context)
        {
            if (posted_credit)
                return false;  //already posted
            if (ordertotal == 0)
                return false;
            PossibleArgs args = new PossibleArgs();
            if (!Tools.Strings.StrExt(base_company_uid))
            {
                args.LogAdd("There is no company associated with this Credit Memo.");
                args.Possible = false;
            }
            foreach (creditmemo_det d in DetailsList(context))
            {
                d.PostPossible(context, args);
            }
            return args.Possible;
        }
        public void Post(ContextRz context)
        {
            ContextRz xx = (ContextRz)context.Clone();
            foreach (creditmemo_det d in DetailsList(context))
            {
                try
                {
                    xx.BeginTran();
                    if (context.Accounts.Enabled && !posted_credit)
                    {
                        d.PostCreditToTransaction(xx);
                        posted_credit_Set(xx, true);
                    }
                    xx.CommitTran();
                }
                catch (Exception ex)
                {
                    context.Leader.Tell("The process failed; incomplete transactions will be rolled back.\r\n\r\n" + ex.Message);
                    Invalidate(context);
                    return;
                }
            }
        }
        public void posted_credit_Set(Context context, bool value)
        {
            this.posted_creditVar.Value = value;
            context.Execute("update " + TableName + " set posted_credit = " + Tools.Database.DataConnectionSqlServer.BoolFilter(value) + " where unique_id = '" + unique_id + "'");
        }
        public PaymentType Type
        {
            get
            {
                if (type == "")
                    return PaymentType.Customer;
                PaymentType enumValue = (PaymentType)Enum.Parse(typeof(PaymentType), type.Replace(" ", ""));
                return enumValue;
            }
            set
            {
                type = Tools.Strings.NiceEnum(value.ToString());
            }
        }
    }
}
