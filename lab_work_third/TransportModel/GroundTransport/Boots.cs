using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class Boots : GroundTransport
    {
        public Boots()
        {
            restDuration.Add(10);
            restDuration.Add(5);
        }

        public override int RestInterval => 60;

        public override int Speed => 6;

        public override string Name => "Ботинки";
    }
}
