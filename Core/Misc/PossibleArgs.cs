using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class PossibleArgs
    {
        public int Count = 0;
        public int Limit = -1;
        public StringBuilder Log = new StringBuilder();
        public StringBuilder Details = new StringBuilder();
        public bool Possible = true;

        public PossibleArgs()
            : this(100)
        {

        }

        public PossibleArgs(int limit)
        {
            Limit = limit;
        }

        public bool LogAdd(String s)
        {            
            Log.AppendLine(s);
            Possible = false;
            Count++;
            return !OverLimit;
        }

        //here for compatibility with old ShipPossible
        public void AddMessage(String message)
        {
            LogAdd(message);
        }

        //this seems backwards; shouldn't OverLimit return true if count >= limit?
        public bool OverLimit
        {
            get
            {
                if (Limit > -1 && Count >= Limit)
                    return false;
                else
                    return true;
            }
        }

        public override string ToString()
        {
            return Log.ToString();
        }
    }
}
