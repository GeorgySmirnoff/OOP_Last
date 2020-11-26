using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public abstract class GroundTransport : Transport
    {
        protected List<double> restDuration = new List<double>();
        
        public abstract int RestInterval
        {
            get; 
        }

        public override double CalcTime(int distance)
        {
            
            int d = 0;
            int t = 0;
            double timeRest = 0;
            while (d < distance)
            {
                t++;
                d = t * Speed;
                if (t % RestInterval == 0) timeRest += RestDuration(t / RestInterval);
            }
            return t + timeRest;
        }

        public virtual double RestDuration(int numOfStop)
        {
            if (numOfStop >= restDuration.Count)
            {
                return restDuration[restDuration.Count - 1];
            }
            else return restDuration[numOfStop];
        }



    }
}
