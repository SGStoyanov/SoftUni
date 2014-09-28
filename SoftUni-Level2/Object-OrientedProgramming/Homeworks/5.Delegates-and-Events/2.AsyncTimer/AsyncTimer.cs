using System;
using System.Threading;

namespace _2.AsyncTimer
{
    public class AsyncTimer
    {
        // According to ReSharper, the correct naming convention for fields is like this, starting with _
        private readonly Action<string> _actionMethod;
        private int _ticks;
        private int _interval;

        public int Ticks
        {
            get { return this._ticks; }
            set
            {
                if (value < 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Ticks couldn't be an empty argument or a negative number");
                }
                this._ticks = value;
            }
        }

        public int Interval
        {
            get { return this._interval; }
            set
            {
                if (value < 0 || string.IsNullOrEmpty(value.ToString()))
                {
                    throw new ArgumentException("Time couldn't be an empty argument or a negative number");
                }
                this._interval = value;
            }
        }

        public AsyncTimer(Action<string> actionMethod, int ticks, int interval)
        {
            this._actionMethod = actionMethod;
            this._ticks = ticks;
            this._interval = interval;
        }

        private void DoWork()
        {
            while (this._ticks > 0)
            {
                Thread.Sleep(this._interval * 1000); // Converting the sleep time to seconds instead of milliseconds

                if (_actionMethod != null)
                {
                    _actionMethod(this._ticks + "");
                }

                this._ticks--;
            }
        }

        public void Start()
        {
            var thread = new Thread(this.DoWork);
            thread.Start();
        }
    }
}