using System;
using System.Collections;
using System.Text;

using NewMethodx;

namespace Tie
{
    public class Job_UpdateOriginals : TieJob
    {
        TieMessage OriginalMessage;
        TieMessage ReturnMessage;
        public bool RunLatest = true;

        StringBuilder sb = new StringBuilder();

        public Job_UpdateOriginals(TieEnd e)
            : base(e)
        {
            Name = "Update Originals";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();

                OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "update_originals_request", TargetSession);
                OriginalMessage.JobID = this.UniqueID;
                OriginalMessage.ContentString = GenerateContent();

                AddLog("Sending request...");
                if (!xEnd.Send(OriginalMessage))
                {
                    ;
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
                    case "update_originals_request":

                        xEnd.SetStatus("Got originals update request.");

                        TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "update_originals_result", TargetSession);
                        reply.JobID = m.JobID;
                        reply.ToSession = m.FromSession;

                        if (xEnd.ServerEnd)
                        {
                            xEnd.SetStatus("Update failed: the server end cannot be updated.");
                            reply.ContentString = "<command_success>false</command_success><command_result>The server end cannot be updated.</command_result>";
                        }
                        else
                        {
                            RunLatest = Tools.Xml.ReadXmlProp_Boolean(m.ContentNode, "run_latest");
                            TieKnot k = new TieKnot();
                            k.SetStatus += new KnotStatusHandler(k_SetStatus);
                            if (!k.UpdateIsNeeded())
                            {
                                reply.ContentString = "<command_success>true</command_success><command_result>No update is needed</command_result>";
                                RunLatest = false;
                            }
                            else
                            {
                                if (k.DownloadUpdates())
                                {
                                    k.CheckPinUpdate(TieTack.GetTackNameFromFolder(Tools.Folder.GetTopLevelFolderName(Tools.FileSystem.GetAppPath())));
                                    reply.ContentString = "<command_success>true</command_success>";
                                }
                                else
                                {
                                    reply.ContentString = "<command_success>false</command_success><command_result>" + sb.ToString() + "</command_result>";
                                    RunLatest = false;
                                }
                            }

                            k.SetStatus -= new KnotStatusHandler(k_SetStatus);
                            k = null;
                        }

                        xEnd.Send(reply);

                        if (RunLatest)
                        {
                            m.FunctionName = "run_latest_pin";
                            xEnd.GotMessage(m);
                        }

                        break;
                    case "update_originals_result":
                        ReturnMessage = m;
                        AddLog("Received response...");

                        ResultStatus = Tools.Xml.ReadXmlProp(ReturnMessage.ContentNode, "command_result");
                        Success = Tools.Xml.ReadXmlProp_Boolean(ReturnMessage.ContentNode, "command_success");

                        AddLog(ResultStatus);
                        AfterDo();
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                xEnd.SetStatus("UpdateOriginals Error: " + ex.Message);
                AddLog("UpdateOriginals Error: " + ex.Message);
            }
        }

        void k_SetStatus(string status)
        {
            sb.AppendLine(status);
        }

        public String GenerateContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("run_latest", RunLatest));
            return sb.ToString();
        }
    }
}
