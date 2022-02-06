using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_work_fifth
{
    public class NullPersentRest : ICalcPercentRest
    {
        public double CalcPercentRest(Account account)
        {
            return 0;
        }
    }
}