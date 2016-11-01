using System;
using System.Threading;

namespace _02_ThreadPool
{
    class Program
    {
        static void ShowThreadInfo()
        {
            int avalibleWorkThreads;
            int avalibleIOThreads;
            int maxWorkThreads;
            int minIOThreads;

            ThreadPool.GetAvailableThreads(out avalibleWorkThreads, out avalibleIOThreads);
            ThreadPool.GetMaxThreads(out maxWorkThreads, out minIOThreads);

            Console.WriteLine("Work threads: {0}", avalibleWorkThreads);
            Console.WriteLine("IO threads: {0}", avalibleIOThreads);
            Console.WriteLine("Max work threads: {0}", maxWorkThreads);
            Console.WriteLine("Max IO threads: {0}", minIOThreads);
        }

        static void Main(string[] args)
        {
            ShowThreadInfo();
        }
    }
}
