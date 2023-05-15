using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockClass
{
    public class Clock
    {
        private Counter _hrs = new Counter("hrs");
        private Counter _mins = new Counter("mins");
        private Counter _secs = new Counter("secs");


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

        public void Reset()
        {
            _hrs.Reset();
            _mins.Reset();
            _secs.Reset();
        }

        public string Time
        {
            get
            {
                return $"{_hrs.Ticks.ToString("00")}:{_mins.Ticks.ToString("00")}:{_secs.Ticks.ToString("00")}";

            }
        }
    }
}
