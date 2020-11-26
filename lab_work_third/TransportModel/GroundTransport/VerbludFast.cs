using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public class VerbludFast : GroundTransport
    {
        public VerbludFast()
        {
            restDuration.Add(5);
            restDuration.Add(6.5);
            restDuration.Add(8);
        }

        public override int RestInterval => 10;

        public override int Speed => 40;

        public override string Name => "Верблюд скороход";
    }
}
