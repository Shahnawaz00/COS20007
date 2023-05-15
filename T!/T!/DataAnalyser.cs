using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_
{
    public class DataAnalyser
    {
        //private local variables 
        private List<int> _numbers;
        private SummaryStrategy _strategy;

        //default constructor with average summary as default strategy
        public DataAnalyser() : this (new List<int>(), new AverageSummary()) { }

        //constructor
        public DataAnalyser(List<int> numbers, SummaryStrategy strategy)
        {
            _numbers = numbers;
            _strategy = strategy;
        }

        //add a number method
        public void AddNumber(int num)
        {
            _numbers.Add(num);
        }

        //summarize method to print summary
        public void Summarise()
        {
            _strategy.PrintSummary(_numbers);
        }

        //property for _strategy, read and write 
        public SummaryStrategy Strategy
        {
            get 
            {
                return _strategy;
            }
            set 
            {
                _strategy = value; 
            }
        }
    }

}
