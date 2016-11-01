using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace _03_Async
{
    class Program
    {
        delegate UInt64 AsyncSumDel(UInt64 n);

        static UInt64 Sum(UInt64 n)
        {
            UInt64 sum = 1;
            for (UInt64 i = 0; i < n; i++)
                sum += i;

            Thread.Sleep(3000);

            return sum;
        }

        static void Method(IAsyncResult ar)
        {
            AsyncResult res = (AsyncResult)ar;
            AsyncSumDel result = (AsyncSumDel)res.AsyncDelegate;

            Console.WriteLine("Result: {0}", result.EndInvoke(ar));
        }

        static void Main(string[] args)
        {
            AsyncSumDel del = Sum;

            IAsyncResult ar = del.BeginInvoke(1000000, Method, null);

            Console.ReadKey();
            
            //Console.WriteLine("Start method...");
            //UInt64 res = del.Invoke(1000000);
            //Console.WriteLine("Result: {0}", res);
        }
    }
}
