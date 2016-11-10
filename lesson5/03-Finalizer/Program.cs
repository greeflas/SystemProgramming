using System;

namespace _03_Finalizer
{
    class Finalizer
    {
        ~Finalizer()
        {
            for (int i = 0; i < 1000; i++)
                Console.Write(". ");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Finalizer f = new Finalizer();
            GC.Collect(); // Release
            // f = null; // Debug

            Console.ReadKey();
        }
    }
}
