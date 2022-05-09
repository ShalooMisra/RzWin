using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using NewMethod;
using Core;

namespace Rz5
{
    public partial class affiliate : affiliate_auto
    {

        n_user TheNoteCompanyOwner;
        company TheCompany;

        //Public Override Functions

        public override void HandleAction(ActArgs args)
        {
            switch (args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }
        //public override string ToString()
        //{
        //    //return "Note about " + companyname + " on " + nTools.DateFormat_ShortDateTime(notedate);
        //}


        public override bool CanBeViewedBy(ContextNM context, ShowArgs args)
        {

            //TheCompany = company.GetById(context, base_company_uid);
            //TheNoteCompanyOwner = n_user.GetById(context, TheCompany.base_mc_user_uid);
            //return context.xUser.IsAssistantLeaderTo(context, TheNoteCompanyOwner);
            return false;
        }
        public override bool CanBeEditedBy(ContextNM context, ShowArgs args)
        {
            //if (context.xUser.SuperUser)
            //    return true;

            //TheCompany = company.GetById(context, base_company_uid);
            //if (context.CheckPermit(Permissions.ThePermits.EditAllContacts))
            //    return true;

            //return context.xUser.unique_id == TheCompany.base_mc_user_uid;
            return false;
        }

        public override void Updating(Context context)
        {
            //base.Updating(context);
            //if (Tools.Strings.StrExt(contactname))
            //    this.base_companycontact_uid = context.SelectScalarString("select unique_id from companycontact where base_company_uid = '" + this.base_company_uid + "' and contactname = '" + context.Filter(contactname) + "'");
            //else
            //    this.base_companycontact_uid = "";
        }

        public n_user UserObjectGet(ContextRz context)
        {
            throw new NotImplementedException();
        }

        public void UserObjectSet(n_user value)
        {
            throw new NotImplementedException();
        }
    }
}
