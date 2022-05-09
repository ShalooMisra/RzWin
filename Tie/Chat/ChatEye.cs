using System;
using System.Collections;
using System.Text;

using System.Net;
using System.Net.Sockets;

using Tie;

//test comment 10
namespace Rz3_Common
{
    public class ChatEye : Eye
    {
        public n_sys xSys;

        public override ClientConnection GetNewConnection(Socket handler)
        {
            ChatConnection c = new ChatConnection(handler);
            return (TieConnection)c;
        }

        public override void GotHello(TieMessage m)
        {
            lock (AllConnections.SyncRoot)
            {
                base.GotHello(m);
                ChatConnection x = (ChatConnection)m.MyConnection;

                //see if it is already connected
                if (x.SaidHello)
                    return;

                x.SaidHello = true;

                String strUserID = m.GetContentItem("n_user_uid");
                if (nTools.StrExt(strUserID))
                    x.TheUser = n_user.GetByID(xSys, strUserID);
                else
                    x.TheUser = n_user.GetByName(xSys, "recognin technologies");

                if (x.TheUser == null)
                {
                    x.TheUser = new n_user(xSys);
                    x.TheUser.name = m.GetContentItem("user_name");
                    x.TheUser.unique_id = strUserID;
                    if (!nTools.StrExt(x.TheUser.name))
                        x.TheUser.name = "Unknown";
                }

                if (GotLiveConnection != null)
                    GotLiveConnection(x);
            }
        }

        public override void RemoveConnection(TieConnection c)
        {
            base.RemoveConnection(c);

            if (LostLiveConnection != null)
                LostLiveConnection((ChatConnection)c);
        }
    }
}
