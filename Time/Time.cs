namespace Time
{
    public readonly struct Time
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
    }
}