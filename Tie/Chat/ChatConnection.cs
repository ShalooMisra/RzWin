using System;
using System.Collections;
using System.Text;

using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

using NewMethod;
using nmTie;

namespace NewMethod.Chat
{
    public class ChatConnection : nmTie.TieConnection
    {
        public String UniqueApplicationID = "";
        public n_user TheUser;

        public ChatConnection(Socket s)
            : base(s)
        {

        }

        //no direct socket connection; must use its machine's xTie
        public ChatConnection(TieConnection c)
            : base((Socket)null) 
        {
        }

        public override string GetAsXML()
        {
            return base.GetAsXML() + "\r\n" + "<n_user_uid>" + TheUser.unique_id + "</n_user_uid><user_name>" + TheUser.name + "</user_name>";
        }

        public override String GetSummaryXml()
        {
            return "<n_user_uid>" + TheUser.unique_id + "</n_user_uid>" + "<user_name>" + TheUser.name + "</user_name>" + base.GetSummaryXml();
        }


    }
}
