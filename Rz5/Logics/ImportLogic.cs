using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Core;
using NewMethod;

namespace Rz5
{
    public class ImportLogic : NewMethod.Logic
    {
        public override void ActsListStatic(Context x, ActSetup acts)
        {
            ContextRz xrz = (ContextRz)x;
            if (xrz.CheckPermit(Permissions.ThePermits.ImportLineItems))
            {
                ActHandle h = new ActHandle(new Act("Import", new ActHandler(ImportShow)));
                acts.Add(h);
                
                if (xrz.CheckPermit(Permissions.ThePermits.ImportCompanies))
                {
                    
                    h.SubActs.Add(new ActHandle(new Act("Import Companies and Contacts", new ActHandler(ImportCompanies))));
                    h.SubActs.Add(new ActHandle(new Act("Manage Inventory Imports", new ActHandler(ManageImportsShow))));
                    //h.SubActs.Add(new ActHandle(new Act("Import Contacts", new ActHandler(ImportContacts))));
                }

                h.AddSubSeparator();
                h.SubActs.Add(new ActHandle(new Act("Export Inventory", new ActHandler(ExportInventory))));
            }
        }

        public void ManageImportsShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ManageImportsShow((ContextRz)x);
        }

        public void ImportShow(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ImportShow((ContextRz)x);
            args.Result(true);
        }
        public void ExportInventory(Context x, ActArgs args)
        {
            ((ILeaderRz)x.TheLeader).ExportInventory((ContextRz)x);
            args.Result(true);
        }
        public virtual void ImportCompanies(Context x, ActArgs args)
        {
            ((ContextRz)x).Leader.ImportCompanies((ContextRz)x, args);
        }
        public virtual void ImportContacts(Context x, ActArgs args)
        {
            ((ContextRz)x).Leader.ImportContacts((ContextRz)x, args);
        }
        public virtual void ImportRz3AbsorbLineExtra(orddet_line l, DataRow r, string type)
        {
            //do nothing
        }
    }
}




