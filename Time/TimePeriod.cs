using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public readonly struct TimePeriod
    {
        public readonly long Seconds { get; init; }

        public readonly long Minutes { get; init; }
        public readonly long Hours { get; init; }
        public TimePeriod(long hours, long minutes, long seconds = 0)
        {
            /*seconds += (time.Hours * 3600) + (time.Minutes * 60) + time.Seconds ;*/

            if (hours > 59 || seconds > 59)
            {
                throw new ArgumentException();
            }
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public TimePeriod(long seconds)
        {
            this.Hours = seconds / 3600;
            this.Minutes = (seconds % 3600) / 60;
            this.Seconds = seconds % 60;
        }

        public TimePeriod(string time)
        {
            var parts = time.Split(':');
            Hours = byte.Parse(parts[0]);
            Minutes = byte.Parse(parts[1]);
            Seconds = byte.Parse(parts[2]);

            if (parts.Length > 3)
            {
                throw new ArgumentException("Too many arguments");
            }
            else if (Minutes > 59 ||  Seconds > 59)
            {
                throw new ArgumentException();
            }
        }


        public override string ToString()
        {
            return $"{Hours.ToString("00")}:{Minutes.ToString("00")}:{Seconds.ToString("00")}";
        }
    }
}
