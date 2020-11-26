using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public abstract class AirTransport : Transport
    {

        public override double CalcTime(int distance)
        {
            return DistanceReducer(distance) / Speed;
        }
        public abstract double DistanceReducer(int distance);

    }
}
