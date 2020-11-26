using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class Kentavr : GroundTransport
    {
        
        public Kentavr()
        {
            restDuration.Add(5);
            restDuration.Add(8);
        }

        public override int RestInterval => 8;

        public override int Speed => 15;

        public override string Name => "Кентавр";
    }
}
