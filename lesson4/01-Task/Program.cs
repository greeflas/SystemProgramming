using System;
using System.Threading;
using System.Threading.Tasks;

namespace _01_Task
{
    class Program
    {
        static void Method()
        {
            for (int i = 0; true; i++)
            {
                Console.Write("* ");
                Thread.Sleep(200);
            }
        }

        static void Main(string[] args)
        {
            Action action = new Action(Method);
            Task task = new Task(action);
            task.Start();

            for (int i = 0; i < 40; i++)
            {
                Console.Write(". ");
                Thread.Sleep(200);
            }

            Console.ReadKey();
        }
    }
}
