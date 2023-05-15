using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_
{
    public class MinMaxSummary : SummaryStrategy
    {
        
        //minimum and maximum variables that identify the mimimum and maximum values in a list
        private int Minimum (List<int> numbers)
        {
            int min = numbers[0];
            foreach (int num in numbers)
            {
                if (num < min)
                {
                    min = num;
                }
            }
            return min;
        }

        private int Maximum (List<int> numbers)
        {
            int max = numbers[0];

            foreach (int num in numbers)
            {
                if (num > max)
                {
                    max = num;
                }
            }
            return max;
        }

        //method to print the minimum and maximum number of a list using the variables above
        public override void PrintSummary(List<int> numbers)
        {
            Console.WriteLine($"The minimum number is: {Minimum(numbers)}");
            Console.WriteLine($"The maximum number is: {Maximum(numbers)}");
        }

    }
}
