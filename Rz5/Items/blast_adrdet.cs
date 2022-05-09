using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Tools;
using Core;
using NewMethod;

namespace Rz5
{
    public partial class blast_adrdet : blast_adrdet_auto
    {
        public static Dictionary<String, NewMethod.n_user> dUsers = new Dictionary<String, NewMethod.n_user>();
        public override void Updating(Context x)
        {
            contact_first_name = Tools.Strings.NiceFormat(Tools.People.FirstNameParse(contact_name));
            base.Updating(x);
        }
        public nEmailMessage GetAsEmailMessage(ContextRz context, blast_emailtemplate xTemplate, blast_emailserver xServer)
        {
            contact_name = context.Logic.FilterContactName(contact_name);
            nEmailMessage m = context.TheSysRz.TheEmailLogic.GetEmailMessage(xTemplate, xServer);
            m.ServerName = xServer.servername;
            m.ServerPort = xServer.serverport;
            m.ServerUserName = xServer.username;
            m.ServerPassword = xServer.password;
            m.SSLRequired = xServer.ssl_required;
            if( Tools.Strings.StrExt(agent_email) )
                m.FromAddress = agent_email;
            else
                m.FromAddress = xServer.fromaddress;
            if (Tools.Email.IsEmailAddress(reply_to_address))
                m.ReplyToAddress =  reply_to_address;
            else
                m.ReplyToAddress = m.FromAddress;
            if( Tools.Strings.StrExt(agent_name) )
                m.FromName = agent_name;
            else if( Tools.Strings.StrExt(xServer.fromname) )
                m.FromName = xServer.fromname;
            m.Subject = BuildSubject(context, xTemplate);
            m.ToAddress = email_adr;
            if( Tools.Strings.StrExt(contact_name) )
                m.ToName = contact_name;
            if(xTemplate.is_text)
            {
                m.IsHTML = false;
                m.TextBody = BuildBody(context, xTemplate);
            }
            else
            {
                m.IsHTML = true;
                m.HTMLBody = BuildBody(context, xTemplate);
            }
            if (Tools.Strings.StrExt(xTemplate.attachments))
            {
                String[] atts = Tools.Strings.Split(xTemplate.attachments.Replace("\r", ""), "\n");
                foreach (String att in atts)
                {
                    m.AddAttachment(att);
                }
            }
            //if (Rz3App.xLogic.IsAAT && Tools.Strings.StrCmp(xServer.fromaddress, "<n_user.email_address>"))
            //    AdjustUserSettings(ref m);
            return m;
        }
        private void AdjustUserSettings(ContextRz context, ref nEmailMessage m)
        {
            try
            {
                company c = company.GetById(context, the_company_uid);
                if (c == null)
                    return;
                NewMethod.n_user u = null;
                try { dUsers.TryGetValue(c.base_mc_user_uid, out u); }
                catch { return; }
                if (u == null)
                    return;
                m.ServerUserName = u.email_address;
                m.FromAddress = u.email_address;
                m.FromName = u.name;
            }
            catch { }
        }
        public String BuildSubject(ContextRz context, blast_emailtemplate xTemplate)
        {
            return DoReplacements(context, xTemplate, xTemplate.email_subject);
        }
        public String BuildBody(ContextRz context, blast_emailtemplate xTemplate)
        {
            return DoReplacements(context, xTemplate, xTemplate.email_body);
        }
        public String DoReplacements(ContextRz context, blast_emailtemplate xTemplate, String original)
        {
            String work = original;
            work = ReplaceTag(work, "CompanyName", company_name);
            work = ReplaceTag(work, "ContactName", contact_name);
            if (Tools.Strings.StrExt(contact_first_name))
                work = ReplaceTag(work, "DearContactFirstNameComma", "Dear " + contact_first_name + ",");
            else
                work = ReplaceTag(work, "DearContactFirstNameComma", "");
            work = ReplaceTag(work, "ContactFirstName", contact_first_name);
            work = ReplaceTag(work, "AgentName", agent_name);
            work = ReplaceTag(work, "AgentEmail", agent_email);
            work = ReplaceTag(work, "ContactEmail", email_adr);
            work = ReplaceTag(work, "WebLogin", website_login);
            work = ReplaceTag(work, "weblogin", website_login);
            work = ReplaceTag(work, "WebPassword", website_password);
            work = ReplaceTag(work, "webpassword", website_password);
            work = ReplaceTag(work, "website_member.web_login", website_login);
            work = ReplaceTag(work, "website_member.web_password", website_password);
            work = ReplaceTag(work, "SEOTRACKING", xTemplate.seo_id);

            company c = null;
            if( Tools.Strings.StrExt(the_company_uid) )
                c = company.GetById(context, the_company_uid);
            if(c != null)
            {
                work = ReplaceTag(work, "company.companyname", c.companyname);
                work = ReplaceTag(work, "company.agentname", c.agentname);
                work = ReplaceTag(work, "company.creditcardnumber", c.creditcardnumber);
                work = ReplaceTag(work, "company.creditcardtype", c.creditcardtype);
                work = ReplaceTag(work, "company.primarycontact", c.primarycontact);
                work = ReplaceTag(work, "company.primaryemailaddress", c.primaryemailaddress);
                work = ReplaceTag(work, "company.primaryfax", c.primaryfax);
                work = ReplaceTag(work, "company.primaryphone", c.primaryphone);
                work = ReplaceTag(work, "company.primarywebaddress", c.primarywebaddress);
                work = ReplaceTag(work, "company.zipcode", c.zipcode);
            }
            return work;
        }
        public String ReplaceTag(String strIn, String strTag, String strReplace)
        {
            return strIn.Replace("<" + strTag + ">", strReplace).Replace("&lt;" + strTag + "&gt;", strReplace);
        }
        //Public Override Functions
        public override void HandleAction(ActArgs args)
        {
            switch(args.ActionName.ToLower())
            {
                default:
                    base.HandleAction(args);
                    break;
            }
        }
    }
}