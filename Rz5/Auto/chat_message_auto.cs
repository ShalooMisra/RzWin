using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Tools.Database;
using Core;

namespace Rz5
{
    [CoreClass("chat_message")]
    public partial class chat_message_auto : NewMethod.nObject
    {
        static chat_message_auto()
        {
            Item.AttributesCache(typeof(chat_message_auto), AttributeCache);
        }

        static void StaticInit()
        {

        }

        public static void AttributeCache(CoreAttribute attr)
        {
            switch (attr.Name)
            {
                case "the_n_user_uid":
                    the_n_user_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "chat_text":
                    chat_textAttribute = (CoreVarValAttribute)attr;
                    break;
                case "recipient":
                    recipientAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sender":
                    senderAttribute = (CoreVarValAttribute)attr;
                    break;
                case "sender_machine":
                    sender_machineAttribute = (CoreVarValAttribute)attr;
                    break;
                case "session_uid":
                    session_uidAttribute = (CoreVarValAttribute)attr;
                    break;
                case "chat_date_utc":
                    chat_date_utcAttribute = (CoreVarValAttribute)attr;
                    break;
            }
        }

        static CoreVarValAttribute the_n_user_uidAttribute;
        static CoreVarValAttribute chat_textAttribute;
        static CoreVarValAttribute recipientAttribute;
        static CoreVarValAttribute senderAttribute;
        static CoreVarValAttribute sender_machineAttribute;
        static CoreVarValAttribute session_uidAttribute;
        static CoreVarValAttribute chat_date_utcAttribute;

        [CoreVarVal("the_n_user_uid", "String", TheFieldLength = 255, Caption="The N User Uid", Importance = 1)]
        public VarString the_n_user_uidVar;

        [CoreVarVal("chat_text", "Text", Caption="Chat Text", Importance = 2)]
        public VarText chat_textVar;

        [CoreVarVal("recipient", "String", TheFieldLength = 255, Caption="Recipient", Importance = 3)]
        public VarString recipientVar;

        [CoreVarVal("sender", "String", TheFieldLength = 255, Caption="Sender", Importance = 4)]
        public VarString senderVar;

        [CoreVarVal("sender_machine", "String", TheFieldLength = 255, Caption="Sender Machine", Importance = 5)]
        public VarString sender_machineVar;

        [CoreVarVal("session_uid", "String", TheFieldLength = 255, Caption="Session Uid", Importance = 6)]
        public VarString session_uidVar;

        [CoreVarVal("chat_date_utc", "DateTime", Caption="Chat Date Utc", Importance = 7)]
        public VarDateTime chat_date_utcVar;

        public chat_message_auto()
        {
            StaticInit();
            the_n_user_uidVar = new VarString(this, the_n_user_uidAttribute);
            chat_textVar = new VarText(this, chat_textAttribute);
            recipientVar = new VarString(this, recipientAttribute);
            senderVar = new VarString(this, senderAttribute);
            sender_machineVar = new VarString(this, sender_machineAttribute);
            session_uidVar = new VarString(this, session_uidAttribute);
            chat_date_utcVar = new VarDateTime(this, chat_date_utcAttribute);
        }

        public override string ClassId
        { get { return "chat_message"; } }

        public String the_n_user_uid
        {
            get  { return (String)the_n_user_uidVar.Value; }
            set  { the_n_user_uidVar.Value = value; }
        }

        public String chat_text
        {
            get  { return (String)chat_textVar.Value; }
            set  { chat_textVar.Value = value; }
        }

        public String recipient
        {
            get  { return (String)recipientVar.Value; }
            set  { recipientVar.Value = value; }
        }

        public String sender
        {
            get  { return (String)senderVar.Value; }
            set  { senderVar.Value = value; }
        }

        public String sender_machine
        {
            get  { return (String)sender_machineVar.Value; }
            set  { sender_machineVar.Value = value; }
        }

        public String session_uid
        {
            get  { return (String)session_uidVar.Value; }
            set  { session_uidVar.Value = value; }
        }

        public DateTime chat_date_utc
        {
            get  { return (DateTime)chat_date_utcVar.Value; }
            set  { chat_date_utcVar.Value = value; }
        }

    }
    public partial class chat_message
    {
        public static chat_message New(Context x)
        {  return (chat_message)x.Item("chat_message"); }

        public static chat_message GetById(Context x, String uid)
        { return (chat_message)x.GetById("chat_message", uid); }

        public static chat_message QtO(Context x, String sql)
        { return (chat_message)x.QtO("chat_message", sql); }
    }
}
