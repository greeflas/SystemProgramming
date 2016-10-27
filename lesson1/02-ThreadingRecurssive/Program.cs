using System;
using System.Threading;

namespace _02_ThreadingRecurssive
{
    class Program
    {
        static int counter = 0;

        static void Increment()
        {
            int id = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Start thread id: {0}", id);

            if(counter < 100)
            {
                counter++;
                var thread = new Thread(Increment);
                
                thread.Start();
                thread.Join();
            }

            Console.WriteLine("Finish: {0}", id);
        }

        static void Main(string[] args)
        {
            var thread = new Thread(Increment);
            thread.Start();
            thread.Join();
        }
    }
}
