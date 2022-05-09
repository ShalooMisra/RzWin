using System;
using System.Collections;
using System.Text;
using System.IO;

using NewMethodx;

namespace Tie
{
    public class Job_TxFile : Job_TxChunk
    {
        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public String RemoteFile = "";
        public String LocalFile = "";
        public String ActualRemoteFile = "";

        public String HoldingPath = "";
        public BinaryWriter HoldingStream;
        public BinaryReader ReadingStream;

        public bool HereToThere = false;
        public bool OpenOnComplete = false;

        public Job_TxFile(TieEnd e)
            : base(e)
        {
            Name = "TxFile";
        }

        public override void Do()
        {
            try
            {
                Name = "TxFile " + RemoteFile;
                BeforeDo();

                if (HereToThere)
                {
                    OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "send_file", TargetSession);
                    OriginalMessage.ContentString = Tools.Xml.BuildXmlProp("file_name", LocalFile);
                    OriginalMessage.ContentString += Tools.Xml.BuildXmlProp("save_name", RemoteFile);

                    AddPositive("Sending file send request...");
                    if (!Send(OriginalMessage))
                    {
                        ;
                    }
                }
                else
                {
                    OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "transfer_file", TargetSession);
                    OriginalMessage.ContentString = Tools.Xml.BuildXmlProp("file_name", RemoteFile);
                    AddLog("Sending file transfer request...");
                    if (!Send(OriginalMessage))
                    {
                        ;
                    }
                }
            }
            catch (Exception)
            { }
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                switch (m.FunctionName)
                {
                    case "send_file":
                        TieMessage rep = GetReply(m);
                        LocalFile = Tools.Xml.ReadXmlProp(m.ContentNode, "save_name");
                        LocalFile = TranslateFileName(LocalFile);

                        if (File.Exists(LocalFile))
                        {
                            rep.FunctionName = "file_already_exists";
                            rep.ContentString = Tools.Xml.BuildXmlProp("file_name", LocalFile);
                        }
                        else
                        {
                            rep.FunctionName = "transfer_file";
                            rep.ContentString = Tools.Xml.BuildXmlProp("file_name", Tools.Xml.ReadXmlProp(m.ContentNode, "file_name"));
                        }
                        Send(rep);
                        break;
                    case "transfer_file":
                        
                        AddNeutral("Got transfer_file request");

                        LocalFile = Tools.Xml.ReadXmlProp(m.ContentNode, "file_name");
                        LocalFile = TranslateFileName(LocalFile);
                        if (!File.Exists(LocalFile))
                        {
                            TieMessage reply = GetReply(m); 
                            reply.FunctionName = "file_not_found";
                            Send(reply);
                            AddNegative("File not found: " + LocalFile);
                        }
                        else
                        {
                            //set up the chunk system
                            FileInfo f = new FileInfo(LocalFile);
                            ReadingStream = new BinaryReader(new FileStream(LocalFile, FileMode.Open, FileAccess.Read)); 
                            InitChunks(f.Length);
                            
                            //send the summary
                            SendSummary();
                        }
                        break;
                    case "file_not_found":
                        Completed = true;
                        Success = false;
                        ResultStatus = "File not found.";
                        AfterDo();
                        break;
                    case "file_already_exists":
                        Completed = true;
                        Success = false;
                        ResultStatus = "File already exists.";
                        AfterDo();
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("TxFile Error: " + ex.Message);
                AddNegative("TxFile Error: " + ex.Message);
            }
        }

        public override void HandleSummaryMessage(TieMessage m)
        {
            ActualRemoteFile = Tools.Xml.ReadXmlProp(m.ContentNode, "actual_file_name");
            base.HandleSummaryMessage(m);
        }

        public override String GetSummaryContent()
        {
            return Tools.Xml.BuildXmlProp("actual_file_name", LocalFile) + base.GetSummaryContent();
        }

        public override void InitChunkSaving()
        {
            try
            {
                HoldingPath = TieEnd.LocalTempFolder + "tx_" + UniqueID + ".dat";
                if (File.Exists(HoldingPath))
                    File.Delete(HoldingPath);
                HoldingStream = new BinaryWriter(new FileStream(HoldingPath, FileMode.Create, FileAccess.Write));
            }
            catch (Exception ex)
            {
                SendGenericError("Error in InitChunkSaving: " + ex.Message);
            }
        }

        public override void SaveChunk(byte[] chunk)
        {
            HoldingStream.Write(chunk);
        }

        public override byte[] GetNextChunk()
        {
            long left = TotalLength - DoneLength;
            long len = 0;
            if (left > ChunkSize)
                len = ChunkSize;
            else
                len = left;

            return ReadingStream.ReadBytes(Convert.ToInt32(len));
        }

        public override void BeforeDo()
        {
            if (Tools.Strings.StrExt(LocalFile) && !HereToThere)
            {
                if (File.Exists(LocalFile))
                {
                    System.Windows.Forms.MessageBox.Show("Local file " + LocalFile + " already exists.");
                    AddLog("Local file " + LocalFile + " already exists.");
                }
            }

            base.BeforeDo();
        }

        public override void AfterDo()
        {
            try
            {
                HoldingStream.Close();
            }
            catch { }

            if (Success)
            {
                String strShow = HoldingPath;

                if (Tools.Strings.StrExt(LocalFile))
                {
                    if (!File.Exists(LocalFile))
                    {
                        File.Copy(HoldingPath, LocalFile);
                        strShow = LocalFile;
                    }
                }
                else
                {
                    if (Tools.Strings.StrExt(ActualRemoteFile))
                        strShow = TieEnd.LocalTempFolder + Path.GetFileName(ActualRemoteFile);
                    else
                        strShow = TieEnd.LocalTempFolder + Path.GetFileName(RemoteFile);

                    if (File.Exists(strShow))
                        File.Delete(strShow);
                    File.Copy(HoldingPath, strShow);
                }

                if (OpenOnComplete)
                    Tools.Files.OpenFileInDefaultViewer(strShow);
            }

            base.AfterDo();
        }

        public override void FinishReading()
        {
            try
            {
                ReadingStream.Close();
            }
            catch { }

            if (HereToThere)
            {
                FireJobFinishedEvent();
            }
        }
    }
}
