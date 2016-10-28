using System;
using System.Threading;

namespace _02_ThreadSuspendResume
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread my_thread = new MyThread();

            Thread.Sleep(1000);
            my_thread.thread.Suspend();

            Console.WriteLine("\nMain thread");

            my_thread.thread.Resume();
        }
    }
}
