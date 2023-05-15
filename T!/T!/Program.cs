using System;

namespace T_
{
    public class Program
    {
        public static void Main()
        {
            
            List<int> list = new List<int> {1,0,3,8,3,0,6,8,2 };

            MinMaxSummary minmaxSummary = new MinMaxSummary();
            AverageSummary averageSummary = new AverageSummary();

            DataAnalyser data = new DataAnalyser(list, minmaxSummary);

            data.Summarise();

            data.AddNumber(0);
            data.AddNumber(1);
            data.AddNumber(2);

            data.Strategy = averageSummary;

            data.Summarise();
        }
    }
}