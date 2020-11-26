using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class KoverSamolet : AirTransport
    {
        public override int Speed { get { return 10; } }

        public override string Name => "Ковер-самолет";

        public override double DistanceReducer(int distance)
        {
            double result;
            if(distance < 1000)
            {
                result = distance;
            }
            else if(distance < 5000)
            {
                result = distance - distance * 0.03;
            }
            else if(distance < 10000)
            {
                result = distance - distance * 0.1;
            }
            else result = distance - distance * 0.05;
            return result;
        }
    }
}
