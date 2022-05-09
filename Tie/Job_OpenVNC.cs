using System;
using System.Collections;
using System.Text;

using NewMethodx;

namespace Tie
{
    public class Job_OpenVNC : TieJob
    {
        public String VNCAddress = "";
        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public Job_OpenVNC(TieEnd e)
            : base(e)
        {
            Name = "Open VNC";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();

                OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "open_vnc_request", TargetSession);
                OriginalMessage.JobID = this.UniqueID;
                OriginalMessage.ContentString = GenerateContent();

                AddLog("Sending request...");
                Send(OriginalMessage);
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
                    case "open_vnc_request":
                        TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "open_vnc_result", TargetSession);
                        reply.JobID = m.JobID;
                        reply.ToSession = m.FromSession;

                        VNCAddress = Tools.Xml.ReadXmlProp(m.ContentNode, "vnc_address");

                        if (!Tools.Files.SaveFileAsString("c:\\reverse_ip.txt", VNCAddress))
                            reply.ContentString = "<command_result>command failed</command_result>";
                        else
                            reply.ContentString = "<command_result>VNC IP set to " + VNCAddress + "</command_result>";

                        xEnd.Send(reply);
                        break;

                    case "open_vnc_result":
                        ReturnMessage = m;
                        AddLog("Received response...");

                        ResultStatus = Tools.Xml.ReadXmlProp(ReturnMessage.ContentNode, "command_result");
                        Success = true;

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
                AddLog("OpenVNC Error: " + ex.Message);
            }
        }

        public String GenerateContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("vnc_address", VNCAddress));
            return sb.ToString();
        }
    }
}
