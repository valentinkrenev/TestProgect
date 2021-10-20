using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProgect
{
    public interface ICalculator
    {
        double RolingRetentionXDay(List<User> users, DateTime toDay, int countDay = 7);
        IEnumerable<DataPoint> Points(List<User> users);
    }
    public class Calculate : ICalculator
    {
        public IEnumerable<DataPoint> Points(List<User> users)
        {
            return users.Select(x => (x.LastActivity - x.Registration)).GroupBy(x => x).Select(x => new DataPoint((int)x.Key.TotalDays, x.Count()));
        }

        public double RolingRetentionXDay(List<User> users, DateTime today, int countDays)
        {
            double top = users.Count(x => (x.LastActivity - x.Registration).TotalDays >= countDays);
            double all = users.Count(x => (today - x.Registration).TotalDays >= countDays);
            double result = top / all * 100;
            return result;
        }
    }
}
