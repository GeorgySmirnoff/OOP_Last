using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class FixPercentRest : ICalcPercentRest
    {
        private double percent;

        public FixPercentRest(double percent)
        {
            this.percent = percent;
        }

        public double CalcPercentRest(Account account)
        {
            return percent;
        }
    }
}
