using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;
using NewMethod;

namespace Rz5
{
    public class HomeLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup acts)
        {
            ActHandle h = new ActHandle(new Act("Home", new ActHandler(HomeShow)));
            acts.Add(h);

            h.SubActs.Add(new ActHandle(new Act("Chat", new ActHandler(Chat))));
            h.SubActs.Add(new ActHandle(new Act("Switch User", new ActHandler(SwitchUser))));
            h.SubActs.Add(new ActHandle(new Act("New Note", new ActHandler(NoteNewShow))));

            if(PhoneReportAllow(x) )
                h.SubActs.Add(new ActHandle(new Act("Phone Report", new ActHandler(PhoneReportShow))));
    
            h.SubActs.Add(new ActHandle(new Act("Chat History", new ActHandler(ChatHistoryShow))));
        }

        protected virtual bool PhoneReportAllow(Context x)
        {
            return true;
        }

        public void SwitchUser(Context x, ActArgs args)
        {
            ((ContextRz)x).TheSysRz.TheUserLogicRz.UserChange((ContextRz)x);
        }
        public void Chat(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ChatWithSomeone((ContextRz)x);
        }
        public void HomeShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).HomeScreenShow((ContextRz)x);
            args.Result(true);
        }
        public void NoteNewShow(Context x, ActArgs args)
        {
            x.Show(NoteCreate((ContextRz)x));
            args.Result(true);
        }
        public virtual usernote NoteCreate(ContextRz x)
        {
            usernote n = usernote.New(x);
            x.Insert(n);
            n.is_pending = true;
            n.shouldpopup = true;
            x.Update(n);
            return n;
        }
        public void PhoneReportShow(Context x, ActArgs args)
        {
            PhoneReportShow((ContextRz)x);
            args.Result(true);
        }
        public virtual void PhoneReportShow(ContextRz x)
        {
            if (!x.xUser.CheckPermit(x, "Sales:View:PhoneReport"))
            {
                x.TheLeader.ShowNoRight();
                return;
            }
            x.Leader.PhoneReportShow(x);
        }
        public void ChatHistoryShow(Context x, ActArgs args)
        {
            ChatHistoryShow((ContextRz)x);
            args.Result(true);
        }
        public virtual void ChatHistoryShow(ContextRz x)
        {
            x.Leader.ChatHistoryShow(x);
        }
    }
}
