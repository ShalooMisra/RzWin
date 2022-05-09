using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web.SessionState;

namespace CoreWeb
{
    public class CoreWebApp : System.Web.HttpApplication
    {
        protected virtual void ApplicationStart()
        {
            SupportingFilesImport();
            AsyncLinkPageBase.LeaderFactory = new LeaderFactory(LeaderCreate);
        }

        protected virtual void SupportingFilesImport()
        {
            if (Tools.Misc.IsDevelopmentMachine())
            {
                ScriptImport("Core.js");
                ScriptImport("CoreResize.js");
                ScriptImport("CoreTable.js");
                ScriptImport("CoreMenu.js");
                FileImport("Styles", "Core.css");
            }
        }

        protected virtual LeaderWebUser LeaderCreate(String sessionId, HttpSessionState session, ViewHandle viewHandle, AsyncScreenHandle screenHandle)
        {
            return new LeaderWebUser(session, viewHandle, screenHandle);
        }

        protected virtual String DevFolder
        {
            get
            {
                return "";
            }
        }

        protected void FileImport(String folder, String file)
        {
            FileImport(folder, file, @"c:\eternal\code\Core\CoreWeb\");
        }

        protected void FileImport(String folder, String file, String basePath)
        {
            try
            {
                File.Delete(DevFolder + folder + @"\" + file);
            }
            catch { }

            try
            {
                File.Copy(basePath + folder + @"\" + file, DevFolder + folder +  @"\" + file);
            }
            catch { }
        }

        protected void ScriptImport(String script)
        {
            FileImport("Scripts", script);
        }

        protected virtual void ApplicationBeginRequest()
        {
            //if ((Request.Url.AbsoluteUri.ToLower().Contains("asynclink.aspx") || Request.Url.AbsoluteUri.ToLower().Contains("action.aspx")) && Request.Cookies["ASP.NET_SessionId"] != null)
            //{
            //    lock (CoreWeb.AsyncLinkPageBase.RequestSessionIds)
            //    {
            //        CoreWeb.AsyncLinkPageBase.RequestSessionIds.Add(Request, Request.Cookies["ASP.NET_SessionId"].Value);
            //    }
            //    Request.Cookies.Remove("ASP.NET_SessionId");
            //}
        }

        protected virtual void ApplicationEndRequest()
        {
            //lock (CoreWeb.AsyncLinkPageBase.RequestSessionIds)
            //{
            //    CoreWeb.AsyncLinkPageBase.RequestSessionIds.Remove(Request);
            //}
        }

        protected virtual void ApplicationEnd()
        {

        }
    }
}
