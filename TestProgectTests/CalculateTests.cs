using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProgect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProgect.Tests
{
    [TestClass()]
    public class CalculateTests
    {
        [TestMethod()]
        public void PointsTest()
        {
            var men = new User
            {
                ID = 1,
                Registration = new DateTime(2021, 10, 01),
                LastActivity = new DateTime(2021, 10, 19)
            };
            var men2 = new User
            {
                ID = 2,
                Registration = new DateTime(2021, 10, 02),
                LastActivity = new DateTime(2021, 10, 20)
            };
            var exepted = new DataPoint(metric: 18, value: 2);

            var list = new List<User>
            {
                men,
                men2,
                new User
                {
                    ID = 3,
                    LastActivity = new DateTime(2021, 10, 19),
                    Registration = new DateTime(2021, 10, 17)
                }
            };

            var calc = new Calculate();
            var resultMethod = calc.Points(list);

            Assert.IsTrue(resultMethod.Count() == 2);
            var firstResult = resultMethod.First();
            Assert.AreEqual(firstResult, exepted);
        }

        [TestMethod()]
        public void RolingRetentionXDayTest()
        {
            var men = new User
            {
                ID = 1,
                Registration = new DateTime(2021, 10, 01),
                LastActivity = new DateTime(2021, 10, 19)
            };
            var men2 = new User
            {
                ID = 2,
                Registration = new DateTime(2021, 10, 02),
                LastActivity = new DateTime(2021, 10, 05)
            };
            var men3 = new User
            {
                ID = 3,
                Registration = new DateTime(2021, 10, 17),
                LastActivity = new DateTime(2021, 10, 18)
            };
            var list = new List<User>
            {
                men,
                men2
            };

            var today = new DateTime(2021, 10, 20);

            double expected = 1d/2 * 100;

            var calc = new Calculate();
            double resultMethod = calc.RolingRetentionXDay(list, today, 7);

            Assert.AreEqual(expected , resultMethod);
        }
    }
}