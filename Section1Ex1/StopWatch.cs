using System;

namespace Section1Ex1
{
    public class StopWatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isActive = false;
        private bool _hasBegun = false;

        public StopWatch () { }

        public TimeSpan Duration
        {
            get
            {
                var mseconds = (this._endTime - this._startTime);
                return mseconds;
            }

        }

        public void Start()
        {
            if (!_isActive)
            {
                this._startTime = DateTime.Now;
                Console.WriteLine("--> Start Time: {0}", this._startTime.ToString("HH:mm:ss.fff"));
                this._isActive = true;
                this._hasBegun = true;
            }
            else throw new InvalidOperationException(">> Warning: Please STOP the stopwatch before restarting");
        }


        public void Stop()
        {
            if (_hasBegun && _isActive)
            {
                this._endTime = DateTime.Now;
                Console.WriteLine("--> End Time: {0}", this._endTime.ToString("HH:mm:ss.fff")); 
                this._isActive = false;
            }
            else throw new InvalidOperationException(">> Advice: Please START the stopwatch");
        }


        public void ReportDuration()
        {
            if (_hasBegun && !_isActive)
            {
                Console.WriteLine("--> Elapsed Time: {0:c}", this.Duration);
            }
            else throw new Exception(">> StopWatch Advice: there is no elapsed time to report");
        }
        

    }

}
