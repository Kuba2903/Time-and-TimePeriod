
namespace Time
{
    class Program
    {
        public static void Main(string[] args)
        {
            Time time = new Time(21,50,49);
            Time time1 = new Time(20,50,49);

            Console.WriteLine(time <= time1);

        }
    }
}