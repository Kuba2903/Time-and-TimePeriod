using System.Data;


namespace UnitTests
{
    using Time;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor()
        {
            Time time = new Time();
            string exp = "00:00:00";
            Assert.AreEqual(exp, time.ToString());

            Time time1 = new Time(21, 30);
            string exp1 = "21:30:00";
            Assert.AreEqual(exp1, time1.ToString());

            Time time2 = new Time(24, 60,65);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructor2()
        {
            Time time = new Time("17:43:3");
            string exp = "17:43:03";
            Assert.AreEqual(exp, time.ToString());

            Time time0 = new Time("20:00:00:00");
        }

        [TestMethod]
        public void TestEquals()
        {
            Time time = new Time("15:30:10");
            Time time1 = new Time(15, 30, 10);

            var a = time.Equals(time1);
            Assert.AreEqual(true, a);

            var b = time != time1;
            Assert.AreEqual(false, b);
        }

        [TestMethod]
        public void TestCompareTo()
        {
            Time time = new Time("15:30:10");
            Time time1 = new Time(20);
            Time time2 = new Time();

            var a = time1 > time; Assert.AreEqual(true, a);
            var b = time2 < time; Assert.AreEqual(true , b);

        }

        [TestMethod]
        public void TestAdding()
        {
            Time time = new Time(10, 30);
            TimePeriod period = new TimePeriod(5,10,55);

            Time exp = new Time(15, 40, 55);
            Assert.AreEqual(exp, time + period);
        }

        [TestMethod]
        public void TestSubtracting()
        {
            Time time = new Time(10, 30,55);
            TimePeriod period = new TimePeriod(5, 10, 55);

            Time exp = new Time(5, 20, 0);
            Assert.AreEqual(exp, time - period);
        }
        ////////////TimePeriod
        ///

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestConstructorPeriod()
        {
            TimePeriod period = new TimePeriod(100000);
            string exp = "27:46:40";
            Assert.AreEqual(exp, period.ToString());


            TimePeriod period0 = new TimePeriod("20:61:00");
        }

        [TestMethod]

        public void TestEqualsTimePeriod()
        {
            TimePeriod time0 = new TimePeriod(10,0,0);
            TimePeriod time1 = new TimePeriod(36000);

            var a = TimePeriod.Equals(time0, time1);
            Assert.AreEqual(true, a);
        }

        [TestMethod]
        public void TestCompareTimePeriod()
        {
            TimePeriod time0 = new TimePeriod("26:10:45");
            TimePeriod time1 = new TimePeriod(20,31);

            var a = time0 > time1;
            Assert.AreEqual(true, a);
        }

        [TestMethod]
        public void TestAddingTimePeriod()
        {
            TimePeriod time0 = new TimePeriod(5,0,0);
            TimePeriod time1 = new TimePeriod(25, 30, 50);

            TimePeriod exp = new TimePeriod(30, 30, 50);
            time0 += time1;
            Assert.AreEqual(exp,time0);
        }

        [TestMethod]
        public void TestSubtractingTimePeriod()
        {
            TimePeriod time0 = new TimePeriod(30, 30, 50);
            TimePeriod time1 = new TimePeriod(25, 30, 50);

            TimePeriod exp = new TimePeriod(5, 0, 0);
            time0 -= time1;
            Assert.AreEqual(exp, time0);
        }
    }
}