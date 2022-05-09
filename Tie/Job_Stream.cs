using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Threading;
using System.Data;
using System.Xml;

using NewMethodx;

namespace Tie
{
    public class Job_Stream : TieJob
    {
        public TieStream xStream;

        public event StreamProgressHandler GotProgress;
        public event StreamStatusHandler GotStatus;

        public int CurrentProgress = 0;
        public String CurrentStatus = "";

        public void FireGotProgress(int progress)
        {
            CurrentProgress = progress;
            if( GotProgress != null )
                GotProgress(progress);
        }

        public void FireGotStatus(String s)
        {
            CurrentStatus = s;
            if (GotStatus != null)
                GotStatus(s);
        }

        public Job_Stream(TieEnd e)
            : base(e)
        {
            Name = "Stream";
        }

        public void SetStream(TieStream s)
        {
            xStream = s;
            xStream.StreamCompleted += new StreamEventHandler(xStream_StreamCompleted);
            xStream.StreamFailed += new StreamEventHandler(xStream_StreamFailed);
            xStream.GotSteppedProgress += new StreamProgressHandler(xStream_GotSteppedProgress);
            xStream.GotStatus += new StreamStatusHandler(xStream_GotStatus);
        }

        void xStream_GotSteppedProgress(int progress)
        {
            SendProgress(progress);
        }

        void xStream_StreamFailed(TieStream s, string message)
        {
            SendStreamFailed(message);
        }

        void xStream_GotStatus(string status)
        {
            SendStatus(status);
        }

        void xStream_StreamCompleted(TieStream s, string message)
        {
            SendStreamComplete();
        }

        public void ReDo()
        {
            Do();
        }

        public override void Do()
        {
            try
            {
                FireGotProgress(0);
                Name = xStream.Caption;
                BeforeDo();

                SendStreamRequest();
            }
            catch (Exception)
            { }
        }

        public void SendStreamRequest()
        {
            TieMessage OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "stream_request", TargetSession);
            OriginalMessage.ContentString = GetPointXml();
            AddLog("Sending stream request...");

            if (!Send(OriginalMessage))
            {
                ;
            }
        }

        private String GetPointXml()
        {
            return "<StreamPoints><StreamPoint>" + xStream.SourcePoint.GetXml() + "</StreamPoint><StreamPoint>" + xStream.DestPoint.GetXml() + "</StreamPoint></StreamPoints>";
        }

        private void ReadPointXml(TieMessage m)
        {
            XmlNodeList l = m.ContentNode.SelectNodes("StreamPoints/StreamPoint");

            if (l.Count != 2)
            {
                xStream.SourcePoint = new StreamPoint(StreamPointType.None);
                xStream.DestPoint = new StreamPoint(StreamPointType.None);
                return;
            }
            
            xStream.SourcePoint = StreamPoint.Parse(l[0]);
            xStream.DestPoint = StreamPoint.Parse(l[1]);
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                TieMessage reply;
                switch (m.FunctionName)
                {
                    case "stream_request":
                        AddLog("Received stream request...");

                        SetStream(new TieStream());

                        ReadPointXml(m);
                        reply = GetReply(m);
                        String s = "";
                        if (xStream.HasValidPoints(ref s))
                        {
                            reply.FunctionName = "stream_ready";
                        }
                        else
                        {
                            reply.FunctionName = "stream_failed";
                            reply.ContentString = Tools.Xml.BuildXmlProp("error_message", s);
                        }
                        Send(reply);
                        break;
                    case "stream_ready":
                        AddPositive("Connection made");
                        reply = GetReply(m);
                        reply.FunctionName = "begin_stream";
                        xStream.FireAllProgress(0);
                        Send(reply);
                        break;
                    case "stream_failed":
                        String strError = Tools.Xml.ReadXmlProp(m.ContentNode, "error_message");
                        AddNegative("Stream failed: " + strError);
                        ResultStatus = strError;
                        Success = false;
                        AfterDo();
                        break;
                    case "begin_stream":
                        xStream.BeginStream();
                        break;
                    case "cancel_stream":
                        xStream.CancelStream();
                        reply = GetReply(m);
                        reply.FunctionName = "stream_cancelled";
                        Send(reply);
                        break;
                    case "stream_cancelled":
                        AddPositive("Stream cancelled.");
                        xStream.FireAllProgress(0);
                        Success = false;
                        AfterDo();
                        break;
                    case "stream_complete":
                        AddPositive("Stream complete.");
                        Success = true;
                        FireGotProgress(100);
                        AfterDo();
                        break;
                    case "stream_progress":
                        int p = Tools.Xml.ReadXmlProp_Integer(m.ContentNode, "progress_value");
                        FireGotProgress(p);
                        break;
                    case "stream_status":
                        FireGotStatus(Tools.Xml.ReadXmlProp(m.ContentNode, "status_text"));
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("SQL Error: " + ex.Message);
            }
        }

        public void SendStreamFailed(String s)
        {
            TieMessage reply = GetReply();
            reply.FunctionName = "stream_failed";
            reply.ContentString = Tools.Xml.BuildXmlProp("error_message", s);
            Send(reply);
        }

        public void SendCancelRequest()
        {
            Completed = true;
            Success = false;
            Cancelled = true;

            TieMessage reply = GetReply();
            reply.FunctionName = "cancel_stream";
            Send(reply);
            AddInfo("Cancel request sent");
        }

        public void SendProgress(int p)
        {
            TieMessage reply = GetReply();
            reply.FunctionName = "stream_progress";
            reply.ContentString = Tools.Xml.BuildXmlProp("progress_value", p);
            Send(reply);
        }

        public void SendStatus(String s)
        {
            TieMessage reply = GetReply();
            reply.FunctionName = "stream_status";
            reply.ContentString = Tools.Xml.BuildXmlProp("status_text", s);
            Send(reply);
        }

        public void SendStreamComplete()
        {
            TieMessage reply = GetReply();
            reply.FunctionName = "stream_complete";
            Send(reply);
        }
    }
}
