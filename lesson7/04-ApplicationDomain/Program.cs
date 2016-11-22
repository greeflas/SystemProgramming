using System;
using System.Threading;

namespace _04_ApplicationDomain
{
    class Program
    {
        static void InitDomain()
        {
            AppDomain myDomain = AppDomain.CreateDomain("My domain");
            myDomain.ExecuteAssembly(@"D:\Shop\Shop.WinForm.exe");

            AppDomain.Unload(myDomain);
        }

        static void Main(string[] args)
        {
            Thread thread = new Thread(new ThreadStart(InitDomain));
            thread.Start();

            Console.WriteLine("Input path to assembly");
            Console.Write("> ");
            string path_to_assembly = Console.ReadLine();
        }
    }
}
