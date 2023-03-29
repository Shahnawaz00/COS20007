using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockClass
{
    public class Clock
    {
        Counter _hrs = new Counter("hrs");
        Counter _mins = new Counter("mins");
        Counter _secs = new Counter("secs");

        public Counter Hours
        {
            get
            {
                return _hrs;
            }
        }
        public Counter Minutes
        {
            get
            {
                return _mins;
            }
        }
        public Counter Seconds
        {
            get
            {
                return _secs;
            }
        }

        public void Tick()
        {
            if (_secs.Ticks <= 58)
            {
                _secs.Increment();
            }
             else if (_mins.Ticks <= 58)
            {
                _mins.Increment();

                _secs.Reset();
            }
             else if (_hrs.Ticks <= 22)
            {
                _hrs.Increment();

                _mins.Reset();
                _secs.Reset();
            } 
             else
            {
                _hrs.Reset();
                _mins.Reset();
                _secs.Reset();
            }
        }

        public void Print()
        {
            Console.WriteLine("{0}:{1}:{2}", _hrs.Ticks.ToString("00"), _mins.Ticks.ToString("00"), _secs.Ticks.ToString("00"));
        }
    }
}
