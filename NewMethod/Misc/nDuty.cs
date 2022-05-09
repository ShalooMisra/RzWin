using System;
using System.Collections.Generic;
using System.Text;

namespace NewMethod
{
    public class nDuty
    {
        public String Name = "";
        public String Function = "";
        public nObject TheDuty = null;
 
        public nDuty(String name) : this(name, name)
        {
        }

        public nDuty(String name, String function)
        {
            Name = name;
            Function = function;
        }

        public void RunDuty(ContextNM x)
        {
            SetStatus(x, "Running " + Name + "...");
            Run(x);
            x.TheLeader.Done();
        }

        protected virtual void Run(ContextNM q)
        {
            switch (Function.ToLower().Trim())
            {
                case "":
                case "test function":
                    int rounds = Tools.Number.GetRandomInteger(2, 8);
                    for (int i = 0; i < rounds; i++)
                    {
                        for (int j = 0; j < 6; j++)
                        {
                            //if (nTools.GetControlKey())
                            //    throw new Exception("Error - Test");

                            System.Threading.Thread.Sleep(1000);
                            q.TheLeader.CommentEllipse("Still testing: " + i.ToString() + "/" + j.ToString());
                        }
                    }
                    break;
            }
        }

        private void SetStatus(ContextNM q, String s)
        {
            q.TheLeader.Comment(s);
        }
    }
}
