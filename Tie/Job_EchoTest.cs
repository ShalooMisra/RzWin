using System;
using System.Collections;
using System.Text;

using NewMethodx;

namespace Tie
{
    public class Job_EchoTest : TieJob
    {
        public int ContentSize = 1024 * 2;        
        TieMessage OriginalMessage;
        TieMessage EchoMessage;

        public Job_EchoTest(TieEnd e) : base(e)
        {
            Name = "Echo Test";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();

                OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "echo_request", TargetSession);
                OriginalMessage.JobID = this.UniqueID;
                OriginalMessage.ContentString = GenerateContent(ContentSize);

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
                    case "echo_request":
                        m.ToSession = m.FromSession;
                        m.FromSession = xEnd.GetSessionFrom();
                        m.FunctionName = "echo_result";
                        xEnd.Send(m);
                        break;
                    case "echo_result":
                        EchoMessage = m;
                        AddLog("Received echo...");

                        if (m.ContentString.Length == 0)
                        {
                            Success = false;
                            ResultStatus = "The echo content was blank";
                        }
                        else if (m.ContentString != OriginalMessage.ContentString)
                        {
                            Success = false;
                            ResultStatus = "The echo content did not match";
                        }
                        else
                        {
                            Success = true;
                            ResultStatus = "Match!";
                        }

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
                AddLog("EchoTest Error: " + ex.Message);
            }
        }

        public String GenerateContent(int len)
        {
            int x = 0;
            StringBuilder sb = new StringBuilder();
            while (x < len)
            {
                String s = Tools.Number.GetRandomInteger().ToString();
                sb.Append(s);
                x += s.Length;
            }
            return sb.ToString();
        }
    }
}
