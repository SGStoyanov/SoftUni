/* Problem 2.	Asynchronous Timer
Create a class AsyncTimer that executes a given method each t seconds.
•	The constructor should accept 3 arguments: Action (a method to be called on every t milliseconds), ticks (the number of times the method should be called) and t (time interval between each tick in milliseconds).
•	The main program's execution should NOT be paused at any time (use some kind of background execution).*/

using System;

namespace _2.AsyncTimer
{
    class AsyncTimerStarter
    {
        private static void WriterMethod(string str)
        {
            Console.WriteLine(str);
        }

        private static void BeeperMethod(string s)
        {
            Console.Beep();
        }

        static void Main()
        {
            var job1 = new AsyncTimer(WriterMethod, 10, 2);
            job1.Start();

            var job2 = new AsyncTimer(BeeperMethod, 10, 5);
            job2.Start();
        }
    }
}