using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class DoubleGorbVerblud : GroundTransport
    {
        public DoubleGorbVerblud()
        {
            restDuration.Add(5);
            restDuration.Add(8);
        }

        public override int RestInterval => 30;

        public override int Speed => 10;

        public override string Name => "Двугорбый верблюд";
    }
}
