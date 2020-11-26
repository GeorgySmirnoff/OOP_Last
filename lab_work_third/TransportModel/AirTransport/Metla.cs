using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class Metla : AirTransport
    {
        public override int Speed { get { return 20; } }

        public override string Name => "Метла";

        public override double DistanceReducer(int distance)
        {
            return distance - distance * ((distance / 1000) * 0.01);
        }
    }
}
