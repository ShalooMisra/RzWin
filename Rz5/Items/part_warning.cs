using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class part_warning : part_warning_auto
    {
        public static void ImportPartWarningERAI(ContextNM x, string file)
        {
            if (!Tools.Strings.StrExt(file))
                return;
            string[] str = Tools.Strings.Split(Tools.Files.OpenFileAsString(file), "\r\n");
            if (str == null)
                return;
            if (str.Length <= 0)
                return;

            x.Execute("delete from part_warning where other_info = 'ERAI Import'");
            
            foreach (string s in str)
            {
                if (!Tools.Strings.StrExt(s))
                    continue;
                string[] split = Tools.Strings.Split(s, "|");
                if (split == null)
                    continue;
                if (split.Length <= 0)
                    continue;
                part_warning p = part_warning.New(x);
                p.part_number = PartObject.StripPart(split[2]);
                string desc = "";
                if (Tools.Strings.StrExt(split[1].Trim()) && Tools.Strings.StrExt(split[3].Trim()))
                    desc = split[1].Trim() + "|" + split[3].Trim();
                else
                    desc = split[1].Trim() + split[3].Trim();
                p.country = desc;
                p.date_reported = Convert.ToDateTime(split[7]);
                p.notes = split[6].Replace("&nbsp;", "").Trim();
                p.other_info = "ERAI Import";
                x.Insert(p);
            }
        }
        public static void ImportPartWarningIDEA(ContextNM x, string file)
        {
            if (!Tools.Strings.StrExt(file))
                return;
            if (Tools.Strings.StrCmp(Tools.Files.GetFileExtention(file), "xls") || Tools.Strings.StrCmp(Tools.Files.GetFileExtention(file), "xlsx"))
            {
                DataTable dt = ToolsOffice.ExcelOffice.OpenExcelAsDataTable(file, "Suspect Counterfeit List$");
                if (dt == null)
                    return;
                if (dt.Rows.Count <= 0)
                    return;
                x.Execute("delete from part_warning where other_info = 'IDEA Import'");
                bool first = true;
                foreach (DataRow dr in dt.Rows)
                {
                    if (first)
                    {
                        first = false;
                        continue;
                    }
                    part_warning p = part_warning.New(x);
                    if (!Tools.Strings.StrExt(dr[1].ToString()))
                        continue;
                    p.part_number = PartObject.StripPart(dr[1].ToString().Trim());
                    if (Tools.Strings.StrExt(dr[0].ToString()))
                        p.date_reported = Convert.ToDateTime(dr[0].ToString());
                    p.notes = dr[5].ToString().Trim();
                    p.other_info = "IDEA Import";
                    x.Insert(p);
                }
            }
        }
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
    }
}
