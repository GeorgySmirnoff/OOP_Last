using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class RangePersentRest : ICalcPercentRest
    {
        private List<Tuple<decimal, double>> ranges;

        public RangePersentRest(List<Tuple<decimal, double>> ranges)
        {
            this.ranges = ranges;
        }

        public double CalcPercentRest(Account account)
        {
            var pair = ranges.FirstOrDefault(t => t.Item1 > account.Balance);
            if (pair != null)
                return pair.Item2;
            else
                return ranges.Last().Item2;
        }
    }
}

