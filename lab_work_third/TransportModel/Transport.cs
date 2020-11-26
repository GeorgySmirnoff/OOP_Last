using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_third
{
    public abstract class Transport
    {
        public abstract double CalcTime(int distance);
        public abstract int Speed
        {
            get;
        }
        public abstract string Name
        {
            get;
        }
    }
}
