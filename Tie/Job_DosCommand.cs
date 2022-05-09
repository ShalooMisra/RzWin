using System;
using System.Collections;
using System.Text;

using NewMethodx;

namespace Tie
{
    public class Job_DosCommand : TieJob
    {
        public String CommandName = "";
        public String CommandArguments = "";
        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public Job_DosCommand(TieEnd e)
            : base(e)
        {
            Name = "DOS Command";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();

                OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "dos_command_request", "");
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
                    case "dos_command_request":
                        TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "dos_command_result", TargetSession);
                        reply.JobID = m.JobID;
                        reply.ToSession = m.FromSession;

                        CommandName = Tools.Xml.ReadXmlProp(m.ContentNode, "command_name");
                        CommandArguments = Tools.Xml.ReadXmlProp(m.ContentNode, "command_arguments");
                        String s = "";
                        if (!Tools.FileSystem.ShellAndViewOutput(CommandName, CommandArguments, ref s, ""))
                            reply.ContentString = "<command_result>command failed</command_result>";
                        else
                            reply.ContentString = "<command_result>" + s + "</command_result>";

                        xEnd.Send(reply);
                        break;
                    case "dos_command_result":
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
                AddLog("DosCommand Error: " + ex.Message);
            }
        }

        public String GenerateContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Tools.Xml.BuildXmlProp("command_name", CommandName));
            sb.Append(Tools.Xml.BuildXmlProp("command_arguments", CommandArguments));
            return sb.ToString();
        }
    }
}
