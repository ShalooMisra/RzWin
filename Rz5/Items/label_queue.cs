using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;

using Core;
using NewMethod;

namespace Rz5
{
    public partial class label_queue : label_queue_auto
    {
        //Public Static Functions
        public static void ExportAddressList(ArrayList labels)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (label_queue q in labels)
                {
                    String[] ary = Tools.Strings.Split(q.split_address, "|");
                    foreach (String s in ary)
                    {
                        sb.Append("\"" + s.Replace("\"", "") + "\",");
                    }

                    sb.Append("\r\n");
                }

                String strFile = Tools.Folder.ConditionFolderName(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)) + "MailingAddresses_" + Tools.Folder.GetNowPath() + ".csv";
                Tools.Files.SaveFileAsString(strFile, sb.ToString());
                Tools.FileSystem.Shell(strFile);
            }
            catch { }
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
        //Public Functions
        public nObject GetObject(ContextRz context)
        {
            return (nObject)context.GetById(object_class, object_id);
        }
    }
}
