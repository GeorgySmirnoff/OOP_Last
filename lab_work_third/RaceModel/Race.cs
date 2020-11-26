using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class Race<T> where T: Transport
    {
        private List<Transport> transports = new List<Transport>();

        private int distance;

        public Race(int distance)
        {
            this.distance = distance;
        }

        public void Register(T transport)
        {
                transports.Add(transport);
        }
        
        public Transport Start()
        {
            double[] times = new double[transports.Count];
            for(int i = 0; i < transports.Count; i++)
            {
                times[i] = transports[i].CalcTime(distance);
            }
            double minTime = times[0];
            int indexMin = 0;
            for(int i = 0; i < transports.Count; i++)
            {
                if (times[i] < minTime) 
                {
                    minTime = times[i];
                    indexMin = i;                
                } 
            }
            return transports[indexMin];
        }
    }
}
