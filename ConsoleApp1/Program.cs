
namespace Time
{
    class Program
    {
        public static void Main(string[] args)
        {
            Time time1 = new Time(20,30,5);

            TimePeriod timePeriod = new TimePeriod(100000);
            Console.WriteLine(timePeriod);

        }
    }
}