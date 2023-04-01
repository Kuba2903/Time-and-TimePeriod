
namespace Time
{
    class Program
    {
        public static void Main(string[] args)
        {
            Time time1 = new Time(20,30,10);
            Time time2 = new Time(20,30,10);

            TimePeriod timePeriod = new TimePeriod(2,1,1);
            TimePeriod timePeriod0 = new TimePeriod(10,30,10);
            time1--;
            Console.WriteLine(time1);
        }
    }
}