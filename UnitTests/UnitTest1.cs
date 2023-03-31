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
        
    }
}