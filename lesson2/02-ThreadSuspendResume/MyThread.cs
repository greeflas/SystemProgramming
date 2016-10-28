using System;
using System.Threading;

namespace _02_ThreadSuspendResume
{
    class MyThread
    {
        public Thread thread;

        public MyThread()
        {
            thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        void Run()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 70; i++)
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }
            Console.ResetColor();
        }
    }
}
