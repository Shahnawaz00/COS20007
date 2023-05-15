using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_
{
    public class AverageSummary : SummaryStrategy
    {
        //average variable that calculates the average of all the numbers a the list
        private float Average (List<int> numbers)
        {
            float sum = 0;
            float average;

            foreach (int num in numbers)
            {
                sum += num;
            }
            average = sum / numbers.Count;

            return average;
        }

        //method to print the average number of a list using the variable above
        public override void PrintSummary(List<int> numbers)
        {
           
            Console.WriteLine($"The average is: {Average(numbers)}");
        }
    }
}
