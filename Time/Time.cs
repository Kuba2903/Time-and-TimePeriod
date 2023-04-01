using System.Diagnostics.CodeAnalysis;

namespace Time
{
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {
        public readonly byte Hours { get; init; }
        public readonly byte Minutes { get; init; }
        public readonly byte Seconds { get; init; }

        public Time(byte hours = 0, byte minutes = 0, byte seconds = 0)
        {
            if(hours > 23 || minutes > 59 || seconds > 59)
            {
                throw new ArgumentException();
            }
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public Time(string time)
        {
            var parts = time.Split(':');
            Hours = byte.Parse( parts[0]);
            Minutes = byte.Parse(parts[1]);
            Seconds = byte.Parse(parts[2]);

            if(parts.Length > 3)
            {
                throw new ArgumentException("Too many arguments");
            }
            else if (Hours > 23 || Minutes > 59 || Seconds > 59)
            {
                throw new ArgumentException();
            }
        }

        public override string ToString() => $"{Hours.ToString("00")}:{Minutes.ToString("00")}:{Seconds.ToString("00")}";

        public bool Equals(Time other)
        {
            if(this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds)
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
            if(obj is Time)
            {
                return Equals((Time)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode() => (Hours, Minutes, Seconds).GetHashCode();

        public int CompareTo(Time other)
        {
            if(this.Hours > other.Hours)
            {
                return 1;
            }else if(this.Hours == other.Hours && this.Minutes > other.Minutes)
            {
                return 1;
            }else if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds > other.Seconds)
            {
                return 1;
            }else { return 0;}
        }

        public static bool operator ==(Time left, Time right) => left.Equals(right);
        public static bool operator !=(Time left, Time right) => !left.Equals(right);
        public static bool operator >(Time left, Time right) => left.CompareTo(right) > 0;
        public static bool operator <(Time left, Time right) => right.CompareTo(left) > 0;
        public static bool operator >=(Time left, Time right) => left.CompareTo(right) > 0 || left.Equals(right);
        public static bool operator <=(Time left, Time right) => right.CompareTo(left) > 0 || right.Equals(left);
        public static Time operator +(Time left, TimePeriod right) => Time.Plus(left, right);
        public static Time operator -(Time left, TimePeriod right) => Time.Minus(left, right);
        public static Time operator ++(Time other) => new Time(Convert.ToByte( other.Hours + 1), other.Minutes, other.Seconds);
        public static Time operator --(Time other) => new Time(Convert.ToByte( other.Hours - 1), other.Minutes, other.Seconds);

        public Time Plus(TimePeriod time)
        {
            long seconds = (time.Hours * 3600) + (time.Minutes * 60) + (time.Seconds);

            byte h = Convert.ToByte( seconds / 3600);
            byte m = Convert.ToByte( (seconds % 3600) / 60);
            byte s = Convert.ToByte( seconds % 60);

            h += this.Hours;
            m += this.Minutes;
            s += this.Seconds;
            
            return new Time(h, m, s);
        }

        public static Time Plus(Time left, TimePeriod right)
        {
            long seconds = (right.Hours * 3600) + (right.Minutes * 60) + (right.Seconds);

            byte h = Convert.ToByte(seconds / 3600);
            byte m = Convert.ToByte((seconds % 3600) / 60);
            byte s = Convert.ToByte(seconds % 60);

            h += left.Hours;
            m += left.Minutes;
            s += left.Seconds;

            return new Time(h, m, s);
        }

        public Time Minus(TimePeriod time)
        {
            long seconds = (time.Hours * 3600) + (time.Minutes * 60) + (time.Seconds);

            byte h = Convert.ToByte(seconds / 3600);
            byte m = Convert.ToByte((seconds % 3600) / 60);
            byte s = Convert.ToByte(seconds % 60);

            byte Timeh = this.Hours;
            byte Timem = this.Minutes;
            byte Times = this.Seconds;

            Timeh -= h;
            Timem -= m;
            Times -= s;
            return new Time(Timeh, Timem, Times);
        }

        public static Time Minus(Time time, TimePeriod timePeriod)
        {
            long seconds = (timePeriod.Hours * 3600) + (timePeriod.Minutes * 60) + (timePeriod.Seconds);

            byte h = Convert.ToByte(seconds / 3600);
            byte m = Convert.ToByte((seconds % 3600) / 60);
            byte s = Convert.ToByte(seconds % 60);

            byte Timeh = time.Hours;
            byte Timem = time.Minutes;
            byte Times = time.Seconds;

            Timeh -= h;
            Timem -= m;
            Times -= s;
            return new Time(Timeh, Timem, Times);
        }
    }
}