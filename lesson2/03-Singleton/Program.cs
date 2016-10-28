using System;
using System.Threading;

namespace _03_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton s1 = Singleton.GetInstance();
            Console.WriteLine(s1.GetHashCode());

            Singleton s2 = Singleton.GetInstance();
            Console.WriteLine(s2.GetHashCode());
        }
    }
}
