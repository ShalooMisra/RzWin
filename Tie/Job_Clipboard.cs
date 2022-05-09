using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Windows.Forms;

using NewMethodx;

namespace Tie
{
    public delegate void GotClipboardTextHandler(Job_Clipboard job, String text);

    public class Job_Clipboard : TieJob
    {
        public event GotClipboardTextHandler GotClipboardText;

        TieMessage OriginalMessage;
        TieMessage ReturnMessage;

        public String OriginalName = "";
        public String NewName = "";
        public String ActionType = "";

        public Job_Clipboard(TieEnd e)
            : base(e)
        {
            Name = "Clipboard";
        }

        public override void Do()
        {
            try
            {
                BeforeDo();
                RequestClipboard();
            }
            catch (Exception)
            { }
        }

        public void RequestClipboard()
        {
            OriginalMessage = new TieMessage(xEnd.GetSessionFrom(), "clipboard_request", TargetSession);
            OriginalMessage.JobID = this.UniqueID;
            OriginalMessage.ContentString = "";

            AddLog("Sending clipboard request...");
            Send(OriginalMessage);
        }

        public override void GotMessage(TieMessage m)
        {
            try
            {
                TieMessage reply;
                switch (m.FunctionName)
                {
                    case "clipboard_request":
                        SendMyClipboard(m);
                        break;
                    case "set_clipboard_text":
                        reply = GetReply(m);
                        bool success = false;
                        try
                        {
                            String sc = Encoding.Unicode.GetString(Convert.FromBase64String(Tools.Xml.ReadXmlProp(m.ContentNode, "clipboard_text")));
                            if (sc == "")
                                Clipboard.Clear();
                            else
                                Clipboard.SetText(sc);
                            
                            reply.ContentString = Tools.Xml.BuildXmlProp("success", true);
                            success = true;
                        }
                        catch (Exception ex)
                        {
                            reply.ContentString = Tools.Xml.BuildXmlProp("success", false) + Tools.Xml.BuildXmlProp("error_message", ex.Message);
                        }
                        Send(reply);

                        if (success)
                            SendMyClipboard(m);
                        break;
                    case "clipboard_result":
                        String s = Encoding.Unicode.GetString(Convert.FromBase64String(Tools.Xml.ReadXmlProp(m.ContentNode, "clipboard_text")));
                        if (GotClipboardText != null)
                            GotClipboardText(this, s);
                        break;
                    default:
                        base.GotMessage(m);
                        break;
                }
            }
            catch (Exception ex)
            {
                AddLog("Clipboard Error: " + ex.Message);
            }
        }

        private void SendMyClipboard(TieMessage m)
        {
            TieMessage reply = new TieMessage(xEnd.GetSessionFrom(), "clipboard_result", TargetSession);
            reply.JobID = m.JobID;
            reply.ToSession = m.FromSession;
            reply.ContentString = Tools.Xml.BuildXmlProp("clipboard_text", Convert.ToBase64String(Encoding.Unicode.GetBytes(Clipboard.GetText())), false);
            Send(reply);
        }

        public void SetClipText(String strText)
        {
            TieMessage m = new TieMessage(xEnd.GetSessionFrom(), "set_clipboard_text", TargetSession);
            m.JobID = this.UniqueID;
            m.ContentString = Tools.Xml.BuildXmlProp("clipboard_text", Convert.ToBase64String(Encoding.Unicode.GetBytes(strText)), false);
            AddLog("Sending clipboard set request...", JobLogType.Info);
            Send(m);
        }
    }
}
