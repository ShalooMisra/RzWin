using System;
using System.Collections;
using System.Text;
using System.IO;

using NewMethodx;

namespace Tie
{
    public delegate void ChunkJobEventHandler(Job_TxChunk j);

    public class Job_TxChunk : TieJob
    {
        public static long ChunkSize = 1024 * 20;

        public event ChunkJobEventHandler GotChunk;
        public event ChunkJobEventHandler TransferComplete;

        public void FireGotChunkEvent()
        {
            if (GotChunk != null)
                GotChunk(this);
        }

        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public long TotalLength = 0;
        public long TotalChunks = 0;
        public long LastChunkSize = 0;

        public long DoneLength = 0;
        public long DoneChunks = 0;

        public DateTime StartTime;

        public Job_TxChunk(TieEnd e)
            : base(e)
        {
            Name = "TxChunk";
        }

        public override void BeforeDo()
        {
            StartTime = DateTime.Now;
            TieEnd.CheckLocalTempFolder();
            base.BeforeDo();
        }

        public void SendSummary()
        {
            TieMessage m = new TieMessage(xEnd.GetSessionFrom(), "chunk_summary", TargetSession);
            m.ContentString = GetSummaryContent();
            Send(m);
            AddNeutral("Sent data summary");
        }

        public virtual String GetSummaryContent()
        {
            return Tools.Xml.BuildXmlProp("total_length", TotalLength) + Tools.Xml.BuildXmlProp("total_chunks", TotalChunks);
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                TieMessage reply;
                switch (m.FunctionName)
                {
                    case "chunk_summary":
                        
                        //get the stats
                        HandleSummaryMessage(m);
                        DoneLength = 0;
                        DoneChunks = 0;
                        StartTime = DateTime.Now;

                        AddNeutral("Got tx summary: " + Tools.Number.LongFormat(TotalLength) + " bytes to send");
                        InitChunkSaving();

                        if (Cancelled)
                            return;

                        RequestNextChunk();

                        break;
                    case "data_chunk":

                        if (Cancelled)
                            return;

                        long ci = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "chunk_index");
                        long l = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "chunk_length");
                        long exp = DoneChunks;
                        long rec = DoneLength + l;

                        //make sure ci is what's expected
                        if (ci != exp)
                        {
                            ResultStatus = "Received chunk " + ci.ToString() + " when expecting " + exp.ToString();
                            Completed = true;
                            Success = false;
                            return;
                        }

                        if (rec > TotalLength)
                        {
                            ResultStatus = "Received " + rec.ToString() + " bytes when expecting " + TotalLength.ToString();
                            Completed = true;
                            Success = false;
                            return;
                        }

                        SaveChunk(Convert.FromBase64String(Tools.Xml.ReadXmlProp(m.ContentNode, "chunk_data")));
                        
                        DoneLength += l;
                        DoneChunks++;
                        exp = DoneChunks;

                        FireGotChunkEvent();

                        if (DoneLength == TotalLength && DoneChunks == TotalChunks)
                        {
                            MarkCompleted();
                            AfterDo();
                        }
                        else
                        {
                            reply = GetReply(m);
                            reply.FunctionName = "data_chunk_request";
                            reply.ContentString = Tools.Xml.BuildXmlProp("chunk_index", exp.ToString());
                            Send(reply);
                        }
                        break;
                    case "data_chunk_request":

                        Byte[] b = GetNextChunk();
                        String s = Convert.ToBase64String(b);

                        reply = GetReply(m);
                        reply.FunctionName = "data_chunk";
                        reply.ContentString = Tools.Xml.BuildXmlProp("chunk_index", DoneChunks) + Tools.Xml.BuildXmlProp("chunk_length", b.Length) + Tools.Xml.BuildXmlProp("chunk_data", s);

                        DoneChunks++;
                        DoneLength += b.Length;

                        Send(reply);
                        FireGotChunkEvent();

                        if (DoneLength == TotalLength)
                        {
                            FinishReading();
                            MarkCompleted();
                        }

                        break;
                    case "cancel_request":
                        KillThread();
                        Cancelled = true;
                        Completed = true;
                        Success = false;
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("TxChunk Error: " + ex.Message);
            }
        }

        public void MarkCompleted()
        {
            Completed = true;
            Success = true;
            TimeSpan t = DateTime.Now.Subtract(StartTime);
            ResultStatus = "Transfer complete: " + DoneLength.ToString() + " in " + Tools.Dates.FormatHMS(t.TotalSeconds);
            if (TransferComplete != null)
                TransferComplete(this);
        }

        public override void Cancel()
        {
            try
            {
                base.Cancel();
                TieMessage reply = GetReply();
                reply.FunctionName = "cancel_request";
                Send(reply);
            }
            catch { }
        }

        public virtual void SaveChunk(Byte[] chunk)
        {
            AddLog("SaveChunk is not overridden.");
        }

        public virtual void HandleSummaryMessage(TieMessage m)
        {
            TotalLength = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "total_length");
            TotalChunks = Tools.Xml.ReadXmlProp_Long(m.ContentNode, "total_chunks");
        }

        public virtual void InitChunkSaving()
        {
            AddLog("InitChunkSaving is not overridden.");
        }

        public virtual Byte[] GetNextChunk()
        {
            AddLog("GetNextChunk is not overridden.");
            return null;
        }

        public virtual void FinishReading()
        {

        }

        public void InitChunks(long len)
        {
            long whole_chunks = len / ChunkSize;
            long last_chunk_size = len % ChunkSize;
            long total_chunks = whole_chunks;
            if( last_chunk_size > 0 )
                total_chunks++;

            TotalLength = len;
            TotalChunks = total_chunks;
            LastChunkSize = last_chunk_size;
        }

        public Double CompletedPercent
        {
            get
            {
                if (TotalLength == 0)
                    return 0;

                try
                {
                    return Convert.ToDouble((Convert.ToDecimal(DoneLength) / Convert.ToDecimal(TotalLength)) * 100);
                }
                catch { return 0; }
            }
        }

        public long ElapsedSeconds
        {
            get
            {
                TimeSpan t = DateTime.Now.Subtract(StartTime);
                return Convert.ToInt64(t.TotalSeconds);
            }
        }

        public void RequestFiles(String strPath)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "files_request", TargetSession);
            reply.ContentString = Tools.Xml.BuildXmlProp("folder_path", Tools.Folder.ConditionFolderName(strPath));
            Send(reply);
        }

        private String GetDriveList()
        {
            DriveInfo[] ary = System.IO.DriveInfo.GetDrives();
            StringBuilder sb = new StringBuilder();
            try
            {
                foreach (DriveInfo f in ary)
                {
                    sb.Append("<drive>");
                    try
                    {
                        sb.Append(Tools.Xml.BuildXmlProp("name", f.Name));
                        sb.Append(Tools.Xml.BuildXmlProp("volume_label", f.VolumeLabel));
                        sb.Append(Tools.Xml.BuildXmlProp("total_size", f.TotalSize.ToString()));
                        sb.Append(Tools.Xml.BuildXmlProp("total_freespace", f.TotalFreeSpace.ToString()));
                    }
                    catch { }
                    sb.Append("</drive>");
                }
            }
            catch
            {
            }
            return sb.ToString();
        }

        private String GetFolderList(String strPath)
        {
            try
            {
                if (!Tools.Strings.StrExt(strPath))
                    return "";

                StringBuilder sb = new StringBuilder();
                String[] ary = Directory.GetDirectories(strPath);
                foreach (String s in ary)
                {
                    sb.Append("<folder>");
                    sb.Append(Tools.Xml.BuildXmlProp("name", Tools.Folder.GetTopLevelFolderName(s)));
                    sb.Append("</folder>");
                }
                return sb.ToString();
            }
            catch { return ""; }
        }

        private String GetFileList(String strPath)
        {
            try
            {
                if (!Tools.Strings.StrExt(strPath))
                    return "";

                StringBuilder sb = new StringBuilder();
                String[] ary = Directory.GetFiles(strPath);
                foreach (String s in ary)
                {
                    FileInfo f = new FileInfo(s);

                    sb.Append("<file>");
                    sb.Append(Tools.Xml.BuildXmlProp("name", Path.GetFileName(s)));
                    sb.Append(Tools.Xml.BuildXmlProp("length", f.Length.ToString()));
                    sb.Append(Tools.Xml.BuildXmlProp("last_write", f.LastWriteTime.ToString()));
                    sb.Append("</file>");
                }
                return sb.ToString();
            }
            catch { return ""; }
        }


        public void RequestNextChunk()
        {
            TieMessage r = new TieMessage(xEnd.GetSessionFrom(), "data_chunk_request", TargetSession);
            Send(r);
        }

    }
}
