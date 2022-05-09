using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class VarEmail : VarString
    {
        public VarEmail(IItem parent, CoreVarAttribute attr)
            : base(parent, attr)
        {
            //SendEmailAct = new Act(new ItemArgs(a.TheContext, this), AttributeActGet("SendEmailAct", new ActHandler(SendEmail)));
        }

        //[CoreVarVal("Domain", "String", ReadOnly = true)]
        //public VarString DomainVar
        //{
        //    get
        //    {
        //        return new VarString(new ItemArgs(this), AttributeGet("DomainVar"), ParseEmailDomain(ValueString));
        //    }
        //}

        //[CoreVarVal("Suffix", "String", ReadOnly = true)]
        //public VarString SuffixVar
        //{
        //    get
        //    {
        //        return new VarString(new ItemArgs(this), AttributeGet("SuffixVar"), ParseEmailSuffix(ValueString));
        //    }
        //}

        public static String ParseEmailDomain(String strEmail)
        {
            String s = Tools.Strings.ParseDelimit(strEmail, "@", 2);
            return s;
        }
        public static String ParseEmailSuffix(String strEmail)
        {
            if (strEmail.ToLower().EndsWith(".mod.uk"))
                return "mod.uk";

            String[] sx = Tools.Strings.Split(strEmail.Trim(), ".");
            if (sx.Length < 2)
                return "";
            return sx[sx.Length - 1].Trim();
        }

        //[CoreAct("SendEmail")]
        //public Act SendEmailAct;
        //public static void SendEmail(Context x, ActArgs args)
        //{
        //    foreach(VarEmail em in args.TheItems.AllGet(x))
        //    {
        //        Tools.FileSystem.Shell("mailto:" + em.ValueString);
        //    }
        //    args.Result(true);
        //}

        protected override bool ValueAcceptable(Context x, string v, ref string message)
        {
            if (!base.ValueAcceptable(x, v, ref message))
                return false;
            if (Tools.Email.IsEmailAddress(v))
            {
                return true;
            }
            else
            {
                message = v + " is not a valid email address";
                return false;
            }
        }
    }
}
