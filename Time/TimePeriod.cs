using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time
{
    public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public readonly long Seconds { get; init; }

        public readonly long Minutes { get; init; }
        public readonly long Hours { get; init; }
        public TimePeriod(long hours, long minutes, long seconds = 0)
        {

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

        public TimePeriod(Time t1, Time t2)
        {
            long t1Seconds = 0;
            long t2Seconds = 0;
            t1Seconds += (t1.Hours * 3600) + (t1.Minutes * 60) + (t1.Seconds);
            t2Seconds += (t2.Hours * 3600) + (t2.Minutes * 60) + (t2.Seconds);

            if (t1Seconds > t2Seconds)
            {
                t1Seconds = t1Seconds - t2Seconds;
                this.Hours = t1Seconds / 3600;
                this.Minutes = (t1Seconds % 3600) / 60;
                this.Seconds = t1Seconds % 60;
            }else if(t2Seconds > t1Seconds)
            {
                t2Seconds = t2Seconds - t1Seconds;
                this.Hours = t2Seconds / 3600;
                this.Minutes = (t2Seconds % 3600) / 60;
                this.Seconds = t2Seconds % 60;
            }
            else
            {
                this.Hours = 0;
                this.Minutes = 0;
                this.Seconds = 0;
            }
        }

        public override string ToString() => $"{Hours.ToString("00")}:{Minutes.ToString("00")}:{Seconds.ToString("00")}";

        public bool Equals(TimePeriod other)
        {
            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is TimePeriod)
            {
                return Equals((TimePeriod)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() => (Hours,Minutes,Seconds).GetHashCode();

        public int CompareTo(TimePeriod other)
        {
            if (this.Hours > other.Hours)
            {
                return 1;
            }
            else if (this.Hours == other.Hours && this.Minutes > other.Minutes)
            {
                return 1;
            }
            else if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds > other.Seconds)
            {
                return 1;
            }
            else { return 0; }
        }

        public static bool operator ==(TimePeriod left, TimePeriod right) => left.Equals(right);
        public static bool operator !=(TimePeriod left, TimePeriod right) => !left.Equals(right);
        public static bool operator >(TimePeriod left, TimePeriod right) => left.CompareTo(right) > 0;
        public static bool operator <(TimePeriod left, TimePeriod right) => right.CompareTo(left) > 0;
        public static bool operator >=(TimePeriod left, TimePeriod right) => left.CompareTo(right) > 0 || left.Equals(right);
        public static bool operator <=(TimePeriod left, TimePeriod right) => right.CompareTo(left) > 0 || right.Equals(left);
        public static TimePeriod operator +(TimePeriod left,TimePeriod right) => TimePeriod.Plus(left,right);
        public static TimePeriod operator -(TimePeriod left, TimePeriod right) => TimePeriod.Minus(left,right);
        public static TimePeriod operator ++(TimePeriod other) => new TimePeriod(other.Hours + 1, other.Minutes, other.Seconds);
        public static TimePeriod operator --(TimePeriod other) => new TimePeriod(other.Hours - 1, other.Minutes, other.Seconds);

        public TimePeriod Plus(TimePeriod other)
        {
            long this_seconds = 0;
            long other_seconds = 0;
            this_seconds += (this.Hours * 3600) + (this.Minutes * 60) + (this.Seconds);
            other_seconds += (other.Hours * 3600) + (other.Minutes * 60) + (other.Seconds);
            this_seconds += other_seconds;

            return new TimePeriod(this_seconds/3600,(this_seconds % 3600)/60,this_seconds % 60);
        }

        public static TimePeriod Plus(TimePeriod left, TimePeriod right)
        {
            long this_seconds = 0;
            long other_seconds = 0;
            this_seconds += (left.Hours * 3600) + (left.Minutes * 60) + (left.Seconds);
            other_seconds += (right.Hours * 3600) + (right.Minutes * 60) + (right.Seconds);
            this_seconds += other_seconds;

            return new TimePeriod(this_seconds / 3600, (this_seconds % 3600) / 60, this_seconds % 60);
        }

        public TimePeriod Minus(TimePeriod other)
        {
            long this_seconds = 0;
            long other_seconds = 0;
            this_seconds += (this.Hours * 3600) + (this.Minutes * 60) + (this.Seconds);
            other_seconds += (other.Hours * 3600) + (other.Minutes * 60) + (other.Seconds);
            this_seconds -= other_seconds;

            return new TimePeriod(this_seconds / 3600, (this_seconds % 3600) / 60, this_seconds % 60);
        }

        public static TimePeriod Minus(TimePeriod left,TimePeriod right)
        {
            long this_seconds = 0;
            long other_seconds = 0;
            this_seconds += (left.Hours * 3600) + (left.Minutes * 60) + (left.Seconds);
            other_seconds += (right.Hours * 3600) + (right.Minutes * 60) + (right.Seconds);
            this_seconds -= other_seconds;

            return new TimePeriod(this_seconds / 3600, (this_seconds % 3600) / 60, this_seconds % 60);
        }
    }
}
