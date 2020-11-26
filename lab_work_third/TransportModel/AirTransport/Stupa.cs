using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class Stupa : AirTransport
    {
        public override int Speed { get { return 8; } }

        public override string Name => "Ступа";

        public override double DistanceReducer(int distance)
        {
            return distance - distance * 0.06;
        }
    }
}
