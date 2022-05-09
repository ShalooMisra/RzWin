using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NewMethod;

namespace Rz5
{
    public partial class frmEmailSelection : Form
    {
        //Private Variables
        private string ContactName = "";
        private string EmailAddress = "";
        private string AttachmentFile = "";

        //Constructors
        public frmEmailSelection()
        {
            InitializeComponent();
        }
        //Public Functions
        public bool CompleteLoad()
        {
            return true;
        }
        public bool CompleteLoad(company c)
        {
            if (c == null)
                return false;
            if (Tools.Strings.StrExt(c.primarycontact))
                ContactName = " " + c.primarycontact;
            if (!Tools.Strings.StrExt(c.primaryemailaddress))
                return false;
            EmailAddress = c.primaryemailaddress;
            return true;
        }
        public bool CompleteLoad(companycontact c)
        {
            if (c == null)
                return false;
            if (Tools.Strings.StrExt(c.preferred_name))
                ContactName = " " + c.preferred_name;
            if (!Tools.Strings.StrExt(c.primaryemailaddress))
                return false;
            EmailAddress = c.primaryemailaddress;
            return true;
        }
        //Private Functions
        private string GetEmailTemplate()
        {
            string phone = "";
            string fax = "";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html>");
            sb.AppendLine("<head>");
            sb.AppendLine("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">");
            sb.AppendLine("<meta name=\"GENERATOR\" content=\"Microsoft FrontPage 4.0\">");
            sb.AppendLine("<meta name=\"ProgId\" content=\"FrontPage.Editor.Document\">");
            sb.AppendLine("<title>Contact Email</title>");
            sb.AppendLine("</head>");
            sb.AppendLine("<body>");
            sb.AppendLine("<table border=\"0\" width=\"100%\">");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><font face=\"Times New Roman\" size=\"3\">[GREET],</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><font face=\"Times New Roman\" size=\"3\">[BODY]</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><font face=\"Times New Roman\" size=\"3\"><br>[COMMENT]</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><font face=\"Times New Roman\" size=\"3\"><br>[SALUTE]</font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("  <tr>");
            sb.AppendLine("    <td width=\"100%\"><font size=\"2\"><font face=\"Times New Roman\"><br></font><b><i><font face=\"Times New Roman\" color=\"black\" size=\"2\"><span style=\"FONT-WEIGHT: bold; FONT-SIZE: 10pt; COLOR: windowtext; FONT-STYLE: italic; mso-bidi-font-size: 12.0pt\">");
            sb.AppendLine("      " + RzWin.User.name + "</span></font></i></b>");
            sb.AppendLine("      <br><font face=\"Times New Roman\" color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext\">I-Net");
            sb.AppendLine("      Technologies, Inc.</span></font><font color=\"black\"><span style=\"COLOR: windowtext\"><o:p>");
            sb.AppendLine("      </o:p>");
            sb.AppendLine("      </span></font>");
            sb.AppendLine("      <br class=\"MsoNormal\"><font face=\"Times New Roman\" color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext\">International");
            sb.AppendLine("      Sales Director</span></font><font color=\"black\"><span style=\"COLOR: windowtext\"><o:p>");
            sb.AppendLine("      </o:p>");
            sb.AppendLine("      </span></font>");
            sb.AppendLine("      <br class=\"MsoNormal\"><span class=\"GramE\"><font face=\"Times New Roman\" color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext\">direct</span></font></span><font color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext\">");
            if (Tools.Strings.StrExt(RzWin.User.phone))
                phone = "/ " + RzWin.User.phone;
            sb.AppendLine("      877-509-4638 " + phone + "</span><span style=\"COLOR: windowtext\"><o:p>");
            sb.AppendLine("      </o:p>");
            sb.AppendLine("      </span></font>");
            sb.AppendLine("      <br class=\"MsoNormal\"><font face=\"Times New Roman\" color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext\">fax<span class=\"GramE\">&nbsp;&nbsp;");
            if (Tools.Strings.StrExt(RzWin.User.fax_number))
                fax = "/ " + RzWin.User.fax_number;
            sb.AppendLine("      561</span>-265-4160 " + fax + "</span></font><font color=\"black\"><span style=\"COLOR: windowtext\"><o:p>");
            sb.AppendLine("      </o:p>");
            sb.AppendLine("      </span></font>");
            sb.AppendLine("      <br class=\"MsoNormal\"><font face=\"Times New Roman\" color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext\"><a title=\"http://www.i-nettech.com/\" href=\"http://www.i-nettech.com\"><span style=\"mso-bidi-font-size: 12.0pt\">www.i-nettech.com</span></a></span></font><font color=\"black\"><span style=\"COLOR: windowtext\"><o:p>");
            sb.AppendLine("      </o:p>");
            sb.AppendLine("      </span></font>");
            sb.AppendLine("      <br class=\"MsoNormal\"><font face=\"Arial\" color=\"black\" size=\"2\"><span style=\"FONT-SIZE: 10pt; COLOR: windowtext; FONT-FAMILY: Arial\">________________________________________________</span></font><font color=\"black\"><span style=\"COLOR: windowtext\"><o:p>");
            sb.AppendLine("      </o:p>");
            sb.AppendLine("      </span></font>");
            sb.AppendLine("      <br class=\"MsoNormal\"><font face=\"Times New Roman\" color=\"black\"><span style=\"color: windowtext\">Confidentiality");
            sb.AppendLine("      Notice: The information contained in this e-mail message, including any");
            sb.AppendLine("      attachments,&nbsp;is confidential and privileged information.&nbsp; Any");
            sb.AppendLine("      unauthorized review, use, disclosure, or distribution is prohibited.&nbsp;");
            sb.AppendLine("      If you are not an intended recipient, please notify the sender immediately");
            sb.AppendLine("      by reply e-mail and delete this message and associated attachments.&nbsp;");
            sb.AppendLine("      Thank you.</span></font></font></td>");
            sb.AppendLine("  </tr>");
            sb.AppendLine("</table>");
            sb.AppendLine("</body>");
            sb.AppendLine("</html>");
            return sb.ToString();
        }
        private void SendEmail(string HTML)
        {
            try
            {
                String err = "";
                //RzWin.Context.TheSysRz.TheEmailLogic.SendOutlookEmail(EmailAddress, HTML, "I-Net", false, true, null, AttachmentFile, false, null, null, null, null, null, false, ref err);
                RzWin.Context.TheSysRz.TheEmailLogic.SendEmail(RzWin.Context, new List<string>() { EmailAddress }, HTML, "I-Net", false, true, null, null, null, true, null, null, false, ref err);

                //ToolsOffice.OutlookOffice.SendOutlookMessage(EmailAddress, HTML, "I-Net", false, true, "", AttachmentFile, false, null, "", "", "", "", ref err);
                this.Close();
            }
            catch { }
        }
        private void PrepAttachment()
        {
            MessageBox.Show("reorg");

            //try
            //{
            //    filelink f = (filelink)Rz3App.xSys.QtO("filelink", "select * from filelink where filetype = 'pdf' and linktype = 'inet_linecard' and linkname = 'INet LineCard'");
            //    if (f == null)
            //        return;
            //    f.LoadPictureData();
            //    string file = f.SaveDataAsFile("LineCard");
            //    if (!Tools.Strings.StrExt(file))
            //        return;
            //    if (!System.IO.File.Exists(file))
            //        return;
            //    AttachmentFile = file;
            //}
            //catch { }
        }
        //Link Labels
        private void linkLabel19_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string body = "";
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                body = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Here is my contact information per our conversation.   I-Net Technologies is an ISO and ESD compliant stocking distributor, serving all corners of the globe. I-Net specializes in obsolete & hard to find components, and the company also has long outstanding consignment agreements in place with large OEMs and manufacturers worldwide. With two impressive warehouse facilities to stock product we can also provide excess inventory solutions for you. I-Net also provides comprehensive rebate programs, financing and terms. With over 50 years of combined experience in the business the company prides itself in providing the best in customer satisfaction.";
                string phone = "";
                if (Tools.Strings.StrExt(RzWin.User.phone))
                    phone = "/ " + RzWin.User.phone;
                string email = "";
                if (Tools.Strings.StrExt(RzWin.User.email_address))
                    email = ", or you can e-mail me at <A href=\"mailto:" + RzWin.User.email_address + "\">" + RzWin.User.email_address + "</A>";
                body += "<p></p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Please do not hesitate to call me at 1-877-509-4638 " + phone + " with your requirements and we will be happy to assist you" + email + ".<br>";
                body += "I invite you to visit our web-site in the coming weeks at <A href=\"http://www.i-nettech.com/\">www.i-nettech.com</A> (under construction).<p></p>";
                body += "Also, attached is our line card which is viewable with Adobe Acrobat.<br>if you don’t have Adobe you can download it for free at  <A href=\"http://www.adobe.com/products/acrobat/readstep2.html\">www.adobe.com/products/acrobat/readstep2.html</A>";
                HTML = HTML.Replace("[BODY]", body);
                HTML = HTML.Replace("[COMMENT]", "Please contact me with your requirement needs.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                PrepAttachment();
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel12_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It's been a while, hope all is well.  Anything new ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Just checking to see if there is anything new we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Just checking to see if there is anything we can help you with today.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Anything new or upcoming in the near future ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel13_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Anything we can help you with before the weekend ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel14_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Anything we can help you with before the end of the month ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel17_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It's been a while, hope all is well.  Anything new ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Happy Holidays.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel18_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;It's been a while, hope all is well.  Anything new ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Happy New Year.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope you had a good weekend.  Just checking to see if you have anything new we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope you had a good weekend.  Just checking to see if you have any new requirements we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Anything new ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Is there anything new we can help you with ?");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Just checking to see if there is anything new we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel9_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Just checking to see if you have any immediate electronic component requirements we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel10_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Just checking to see if you have any immediate electronic requirements we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel11_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hi" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Hope all is well.  Just checking to see if you have any immediate requirements we can help you with.");
                HTML = HTML.Replace("[COMMENT]", "Please advise.");
                HTML = HTML.Replace("[SALUTE]", "Best Regards.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel15_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hola" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tienes algo nuevo que podemos ayudar ?");
                HTML = HTML.Replace("[COMMENT]", "Avisame.");
                HTML = HTML.Replace("[SALUTE]", "Saludos.");
                SendEmail(HTML);
            }
            catch { }
        }
        private void linkLabel16_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string HTML = GetEmailTemplate();
                HTML = HTML.Replace("[GREET]", "Hola" + ContactName);
                HTML = HTML.Replace("[BODY]", "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Tienes algunas partes cortos que podemos ayudar ?");
                HTML = HTML.Replace("[COMMENT]", "Avisame.");
                HTML = HTML.Replace("[SALUTE]", "Saludos.");
                SendEmail(HTML);
            }
            catch { }
        }
    }
}
