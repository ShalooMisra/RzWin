using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class Trail
    {
        public String Uid = Tools.Strings.GetNewID();
        public String Name;
        public Dictionary<String, Stop> Stops = new Dictionary<String, Stop>();
        public bool CanceledIs = false;

        public Trail(Context context, String name)
        {
            Name = name;
        }

        public virtual bool Note(String stop_name, String tag, String value)
        {
            if (!Stops.ContainsKey(stop_name))
                return false;

            Stop s = Stops[stop_name];
            return s.Note(tag, value);
        }

        public void Next(Context x)
        {
            if (CanceledIs)
            {
                Canceled(x);
                return;
            }

            foreach (KeyValuePair<String, Stop> k in Stops)
            {
                if (!k.Value.CompleteIs)
                {
                    k.Value.Show(x);
                    return;
                }
            }

            Finished(x);
        }

        public virtual void Canceled(Context context)
        {
            context.TheLeader.Tell(Name + " was cancelled");
        }

        public virtual void Finished(Context context)
        {
            //context.TheLeader.Tell(Name + " is complete");
        }

        public void StopAdd(Stop s)
        {
            Stops.Add(s.Uid, s);
        }

        public List<Stop> StopsList
        {
            get
            {
                List<Stop> ret = new List<Stop>();
                foreach (KeyValuePair<String, Stop> k in Stops)
                {
                    ret.Add(k.Value);
                }
                return ret;
            }
            
        }
    }
    public class Stop
    {
        public Trail TheTrail;
        public String Uid = Tools.Strings.GetNewID();
        public bool Answered = false;

        public Stop(Context context, Trail t)
        {
            TheTrail = t;
        }

        public virtual bool Note(String tag, String value)
        {
            return false;
        }

        public virtual bool CompleteIs
        {
            get
            {
                return Answered;
            }
        }

        public virtual void Show(Context context)
        {

        }

        public virtual void Prepare(Context context)
        {
        }
    }
    public class StopAreYouSure : Stop
    {
        public String Message = "";
        public StopAreYouSure(Context context, Trail t, String message) : base(context, t)
        {
            Message = message;
        }

        public void Answer(bool yes)
        {
            if (!yes)
            {
                TheTrail.CanceledIs = true;               
            }
            Answered = true;
        }
    }
    public class StopYesNo : Stop
    {
        public String Message = "";
        public StopYesNo(Context context, Trail t, String message)
            : base(context, t)
        {
            Message = message;
        }

        public void Answer(bool yes)
        {
            if (!yes)
            {
                TheTrail.CanceledIs = true;
            }
            Answered = true;
        }
    }
}
