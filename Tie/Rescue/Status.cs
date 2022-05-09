//2013_03_14
//joel i think you duplicated a lot of the leader functionality here, and that's partly why rzrescue is so hard to debug.
//there's an rzrescue problem at phoneix and i'm trying to make this more strightforward.
//i realize its probably because we can't pass the leader down into Tools, but i'm going to try to replace that with actual C# exceptions

//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.IO;

//namespace Tie.Rescue
//{
//    public class RzRescueStatus
//    {
//        //Public Variables
//        public StringBuilder TheStatus = new StringBuilder();
//        public StringBuilder TheSummary = new StringBuilder();
//        //Private Variables
//        private long TheCount = 0;

//        //Constructors
//        public RzRescueStatus()
//        {
//            TieDuty.ReStartLogFile();
//        }
//        //Public Functions
//        public void SetStatus(string s)
//        {
//            if (!Tools.Strings.StrExt(s))
//                return;
//            TheStatus.AppendLine("[" + DateTime.Now.ToString() + "] " + s);
//            try
//            {
//                FileStream f = new FileStream(TieDuty.LogFileName, FileMode.Append, FileAccess.Write);
//                StreamWriter w = new StreamWriter(f);
//                w.WriteLine("[" + DateTime.Now.ToString() + "] " + s);
//                w.Close();
//                w.Dispose();
//                w = null;
//                f.Close();
//                f.Dispose();
//                f = null;
//            }
//            catch { }
//        }
//        public void AddSummaryLine(string proc, bool b, string resp)
//        {
//            if (!Tools.Strings.StrExt(proc))
//                return;
//            TheCount++;
//            TheSummary.AppendLine(TheCount.ToString() + ": " + proc + " : Result " + b.ToString() + (Tools.Strings.StrExt(resp) ? " - " + resp : ""));
//        }
//    }
//}
