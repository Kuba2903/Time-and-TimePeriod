using System.Diagnostics.CodeAnalysis;

namespace Time
{
    public readonly struct Time : IEquatable<Time>, IComparable<Time>
    {
        public readonly byte Hours { get; init; }
        public readonly byte Minutes { get; init; }
        public readonly byte Seconds { get; init; }

        public Time(byte hours, byte minutes, byte seconds)
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

            if (Hours > 23 || Minutes > 59 || Seconds > 59)
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return $"{Hours}:{Minutes}:{Seconds}";
        }

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
    }
}