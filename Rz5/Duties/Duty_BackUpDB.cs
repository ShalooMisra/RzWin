using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using NewMethod;
using Tools.Database;

namespace Rz5
{
    public class Duty_BackUpDB : nDuty
    {
        public Duty_BackUpDB()
            : base("BackUp Database", "BackUp Database")
        {

        }
        protected override void Run(ContextNM q)
        {
            base.Run(q);
            String filename = q.TheSys.Name + "_" + System.DateTime.Now.Year.ToString() + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Month.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Day.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Hour.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Minute.ToString(), 2) + "_" + Tools.Strings.Right("00" + System.DateTime.Now.Second.ToString(), 2) + ".bak";
            String path = n_set.GetSetting(q, "backup_folder");
            if (!Tools.Strings.StrExt(path))
            {
                path = nTools.GetDriveLetter() + ":\\";
                n_set.SetSetting(q, "backup_folder", path);
            }
            if (Tools.Strings.StrCmp(path, "<click to select>"))
            {
                path = nTools.GetDriveLetter() + ":\\";
                n_set.SetSetting(q, "backup_folder", path);
            }
            String backup_file = Tools.Folder.ConditionFolderName(path) + filename;
            if (!Tools.Strings.StrExt(backup_file))
                throw new Exception("Could not get a backup file.");

            DoBackup((ContextRz)q, backup_file);
        }
        private bool DoBackup(ContextRz q, String s)
        {
            ContextRz xrz = (ContextRz)q;
            q.TheLeader.Comment("Parforming backup to: " + s);
            String err = "";
            if (((DataConnectionSqlServer)q.TheData.TheConnection).Backup(ref s, ref err))
            {
                xrz.Logic.MarkConcern(q, "Database_Backup");
                return true;
            }
            else
            {
                q.TheLeader.Error("Backup error: " + err);
                return false;
            }
        }
    }
}


