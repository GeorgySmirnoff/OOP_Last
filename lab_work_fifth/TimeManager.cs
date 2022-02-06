using System;
using System.Collections.Generic;
using System.Text;

namespace lab_work_fifth
{
    public class TimeManager
    {
        private static TimeManager instance;
        private DateTime? date = null;

        public static TimeManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new TimeManager();
                return instance;
            }
        }

        private TimeManager()
        { }

        public DateTime CurrentDate
        {
            get
            {
                if (date == null)
                    return DateTime.Now;
                return date.Value;
            }
            set
            {
                date = value;
            }
        }
    }
}
