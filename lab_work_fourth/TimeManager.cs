using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Backup
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
