using System;
using System.IO;
using System.Threading;

namespace _04_LockThread
{
    class Program
    {
        static object lockObj = new object();
        static ReaderWriterLockSlim readWriteLock = new ReaderWriterLockSlim();

        static void NotEven()
        {
            for (int i = 0; i < 100; i++)
            {
                if(i % 2 != 0)
                {
                    lock(lockObj)
                    {
                        readWriteLock.EnterWriteLock();

                        StreamWriter sw = new StreamWriter("../../data/test.txt", true);
                        sw.WriteLine(i);
                        sw.Close();

                        readWriteLock.ExitWriteLock();

                        Console.WriteLine("{0} saved {0}", Thread.CurrentThread.GetHashCode(), i);
                    }
                }
                Thread.Sleep(300);
            }
        }

        static void Even()
        {
            for (int i = 0; i < 100; i++)
            {
                if (i % 2 == 0)
                {
                    lock (lockObj)
                    {
                        readWriteLock.EnterWriteLock();

                        StreamWriter sw = new StreamWriter("../../data/test.txt", true);
                        sw.WriteLine(i);
                        sw.Close();

                        readWriteLock.ExitWriteLock();

                        Console.WriteLine("{0} saved {0}", Thread.CurrentThread.GetHashCode(), i);
                    }
                }
                Thread.Sleep(50);
            }
        }

        static void Main(string[] args)
        {
            if(!File.Exists("../../data/test.txt"))
            {
                File.Create("../../data/test.txt");
            }

            Thread th1 = new Thread(new ThreadStart(NotEven));
            th1.Start();

            Thread th2 = new Thread(new ThreadStart(Even));
            th2.Start();
        }
    }
}
