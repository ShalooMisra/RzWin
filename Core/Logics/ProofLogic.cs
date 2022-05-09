using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Core
{
    public class ProofLogic
    {
        public bool InProveMode = false;

        public ProveResult Prove(Context x)
        {
            ProveResult r = new ProveResult();
            
            try
            {
                r.Start();
                Prove(x, r);
                r.End();
            }
            catch (Exception ex)
            {
                r.Passed = false;
                r.Log("Failed: " + ex.Message);
            }

            return r;
        }

        public virtual void Prove(Context x, ProveResult result)
        {
            foreach (CoreClassHandle h in x.TheSys.CoreClassesList())
            {
                if (h.TheAttribute.Abstract)
                    continue;

                try
                {
                    ProveClassStructure(x, h);
                }
                catch (Exception ex)
                {
                    result.Passed = false;
                    result.Log("Failed on " + h.Name + ": " + ex.Message);
                }
            }
        }

        protected virtual void ProveClassStructure(Context x, CoreClassHandle h)
        {
            int countBefore = x.TheData.SelectScalarInt32("select count(*) from " + h.Name);

            Item i = TestItem(x, h);

            //basic confirm
            x.Insert(i);
            Confirm(x, i, true);

            String originalId = i.Uid;

            //changes
            ProgressiveChanges(i);
            x.Update(i);
            Confirm(x, i, true);

            //in a transaction
            Context xx = x.Clone();
            String tid = xx.BeginTran();

            ProgressiveChanges(i);
            ConfirmNot(x, i);  //confirm that this is in fact making changes
            x.Update(i);

            xx.CommitTran(tid);

            Confirm(xx, i, true);

            //in a failed transaction
            tid = xx.BeginTran();

            ProgressiveChanges(i);
            xx.Update(i);
            ConfirmNot(xx, i);  //not applied yet

            String missingField = "thisfielddoesntexist";
            while(xx.TheData.TheConnection.FieldExists(h.Name, missingField) )
            {
                missingField += "x";
            }

            xx.Execute("update " + h.Name + " set " + missingField + " = 'x'");

            try
            {
                xx.CommitTran(tid);
                throw new Exception("A transaction that should have failed passed");
            }
            catch
            {
                ConfirmNot(xx, i);  //not applied because of the tran failure
            }

            tid = xx.BeginTran();
            xx.Delete(i);  //i is invalid right now

            try
            {
                xx.CommitTran(tid);  //should pass the sql but fail because zero affected
                throw new Exception("Delete transaction should have failed");
            }
            catch
            {

            }

            if (!i.Invalid)
                throw new Exception("Item shold be invalid after failed transaction");

            try
            {
                xx.Delete(i);
                throw new Exception("Error missed on deleting invalid item");
            }
            catch
            {

            }

            int countAfter = x.TheData.SelectScalarInt32("select count(*) from " + h.Name);

            if( countAfter != (countBefore + 1))
                throw new Exception("Count mis-match after invalid on " + h.Name);

            i.Invalid = false;
            i.Uid = originalId;
            xx.Delete(i);

            countAfter = x.TheData.SelectScalarInt32("select count(*) from " + h.Name);
            if (countBefore != countAfter)
                throw new Exception("Count mis-match on " + h.Name);

            try
            {
                //this should fail right away
                x.Execute("update " + h.Name + " set " + missingField + " = 'x'");
                throw new Exception("Sql should have failed");
            }
            catch
            {
            }
        }

        protected void Confirm(Context x, Item i, bool expectedToPass)
        {
            DataTable d = x.Select("select * from " + i.TableName + " where " + x.TheData.UidField + " = '" + x.TheData.Filter(i.Uid) + "'");
            if (d == null)
                throw new Exception("Bad query");

            if (d.Rows.Count == 0)
                throw new Exception("No result");

            if (d.Rows.Count > 1)
                throw new Exception("> 1 result");

            foreach (VarVal v in i.VarValsGet())
            {
                if (v is IEnumVar || v is VarBlob)  //can't compare these yet
                    continue;

                Object dataValue = d.Rows[0][v.Name];

                if (dataValue == null || dataValue == DBNull.Value)
                    throw new Exception("Null saved value");
                else if (!v.ValueSame(dataValue))
                {
                    if (expectedToPass)
                    {
                        ;
                    }
                    throw new Exception("Saved value mis-match");
                }
            }            
        }

        protected void ConfirmNot(Context x, Item i)
        {
            try
            {
                Confirm(x, i, false);
                throw new Exception("Unexpected confirm");
            }
            catch { }
        }

        public virtual Item TestItem(Context x, CoreClassHandle h)
        {
            Item ret = x.Item(h.Name);

            if (h.Name == "orddet_quote")
            {
                ;
            }

            foreach (CoreVarValAttribute p in h.VarValsGet())
            {
                Object v = Tools.Data.GetTestValue(p.TheFieldType, p.TheFieldLength);
                ret.ValSet(p.Name, v);
            }
            return ret;
        }

        static int progressiveChangeCounter = 0;
        protected virtual void ProgressiveChanges(Item i)
        {
            progressiveChangeCounter++;
            foreach (VarVal v in i.VarValsGet())
            {
                v.Value = Tools.Data.GetTestValueProgressive(v.TheValAttribute.TheFieldType, v.TheValAttribute.TheFieldLength, progressiveChangeCounter);
            }
        }

    }
    public class ProveResult
    {
        public bool Passed = true;
        public TimeSpan Duration;
        DateTime StartTime;
        DateTime EndTime;
        StringBuilder LogString = new StringBuilder();
        public Dictionary<String, IItem> Items = new Dictionary<string, IItem>();

        public void Start()
        {
            StartTime = DateTime.Now;
        }
        public void End()
        {
            EndTime = DateTime.Now;
            Duration = EndTime.Subtract(StartTime);
        }
        public void Log(String s)
        {
            LogString.AppendLine(s);
        }
        public override string ToString()
        {
            return LogString.ToString();
        }
    }
}
