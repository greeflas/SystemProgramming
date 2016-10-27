using System;
using System.Threading;

namespace _01_Threading
{
    class Program
    {
        static void ThreadFunc()
        {
            int thread_id = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine("Start: {0}\n", thread_id);

            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(". ");
                Console.ResetColor();
            }

            Console.WriteLine("\nFinish: {0}", thread_id);
        }

        static void Main(string[] args)
        {
            var thread = new Thread(new ThreadStart(ThreadFunc));

            int thread_id = Thread.CurrentThread.ManagedThreadId;

            thread.Start();
            Console.WriteLine("Start: {0}\n", thread_id);

            for (int i = 0; i < 160; i++)
            {
                Thread.Sleep(20);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(". ");
                Console.ResetColor();
            }

            Console.WriteLine("\nFinish: {0}", thread_id);
        }
    }
}
