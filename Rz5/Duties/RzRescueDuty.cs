using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

//using Tie;
//using Tie.Rescue;
using NewMethod;

namespace Rz5
{
    public class RzRescueDuty : nDuty
    {
        //Constructors
        public RzRescueDuty() : base("RzRescue", "RzRescue")
        {

        }
        //Public Override Functions
        protected override void Run(ContextNM q)
        {
            base.Run(q);

            //ActuallyRunRescue((ContextRz)q);
        }
        //Protected Virtual Functions
        protected virtual String RescueId(ContextRz context)
        {
            return Tools.Strings.NiceFormat(context.Logic.CompanyIdentifier);
        }
        //Protected Functions
        //protected virtual void InitDatabases(ContextRz context, RzRescueManager r)
        //{
        //    RzRescueDatabase db = InitMainDatabase(context);
        //    if (db == null)
        //        throw new Exception("No main database");
        //    r.Databases.Add(db);
        //}
        //protected virtual RzRescueDatabase InitMainDatabase(ContextRz context)
        //{
        //    if (!Tools.Strings.StrExt(RescueId(context)))
        //        return null;

        //    mc_duty d = null;
        //    try { d = (mc_duty)TheDuty; }
        //    catch { }
        //    string dbName = "";
        //    if (d != null)
        //        dbName = d.duty_targets;

        //    if (!Tools.Strings.StrExt(dbName))
        //        dbName = context.TheData.DatabaseName;

        //    if (!Tools.Strings.StrExt(dbName))
        //        return null;

        //    RzRescueDatabase db = new RzRescueDatabase();

        //    FtpInfo ftp = new FtpInfo();
        //    db.Sites.Add(ftp);

        //    ftp.Server = "mike.recognin.com";
        //    ftp.Folder = RescueId(context);
        //    ftp.User = RescueId(context);
        //    ftp.Password = RescueId(context);

        //    db.Server = context.TheData.ServerName;
        //    db.Database = dbName;
        //    db.User = context.TheData.UserName;
        //    db.Password = context.TheData.UserPassword;

        //    return db;
        //}
        ////Private Functions
        //protected void ActuallyRunRescue(ContextRz q)
        //{
        //    string folder = GetBackUpFolder();

        //    RzRescueManager.RootFolder = folder;
        //    RzRescueManager r = new RzRescueManager();

        //    InitDatabases(q, r);
        //    r.RunRescue();
        //}
        //protected virtual String GetBackUpFolder()
        //{
        //    String folder = Tools.Strings.Left(Tools.FileSystem.GetAppPath(), 1) + @":\";
        //    if (!Directory.Exists(folder))
        //        throw new Exception("No root folder found: " + folder);

        //    folder += @"RzRescue\";

        //    if (!Directory.Exists(folder))
        //        Directory.CreateDirectory(folder);

        //    return folder;
        //}
        //protected void RenderSuccessLog(ContextNM q, RzRescueStatus status)
        //{
        //    if (q == null)
        //        return;
        //    if (status == null)
        //        return;
        //    q.TheLeader.Comment("Backup Success! RzRescue Quick Status below:");
        //    string[] str = Tools.Strings.Split(status.TheSummary.ToString(), "\r\n");
        //    foreach (string s in str)
        //    {
        //        if (!Tools.Strings.StrExt(s))
        //            continue;
        //        q.TheLeader.Comment(s);
        //    }
        //    q.TheLeader.Comment("\r\n-------------------------------------------\r\n");
        //    q.TheLeader.Comment("Backup Success! RzRescue Log below:");
        //    str = Tools.Strings.Split(status.TheStatus.ToString(), "\r\n");
        //    foreach (string s in str)
        //    {
        //        if (!Tools.Strings.StrExt(s))
        //            continue;
        //        q.TheLeader.Comment(s);
        //    }
        //}
        //protected void RenderErrorLog(ContextNM q, RzRescueStatus status)
        //{
        //    if (q == null)
        //        return;
        //    if (status == null)
        //        return;
        //    q.TheLeader.Error("Backup failed, RzRescue Quick Status below:");
        //    string[] str = Tools.Strings.Split(status.TheSummary.ToString(), "\r\n");
        //    foreach (string s in str)
        //    {
        //        if (!Tools.Strings.StrExt(s))
        //            continue;
        //        q.TheLeader.Error(s);
        //    }
        //    q.TheLeader.Error("\r\n-------------------------------------------\r\n");
        //    q.TheLeader.Error("Backup failed, RzRescue Log below:");
        //    str = Tools.Strings.Split(status.TheStatus.ToString(), "\r\n");
        //    foreach (string s in str)
        //    {
        //        if (!Tools.Strings.StrExt(s))
        //            continue;
        //        q.TheLeader.Error(s);
        //    }
        //}
    }
}
