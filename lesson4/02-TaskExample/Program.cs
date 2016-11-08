using System;
using System.Threading.Tasks;

namespace _02_TaskExample
{
    class Program
    {
        static void ShowNumber(object length)
        {
            int max = (int)length;

            for (int i = 0; i < max; i++)
            {
                if((i % 21 == 0) || (i % 99 == 0))
                    Console.WriteLine(i);
            }
        }

        static void Main(string[] args)
        {
            Task task = new Task(ShowNumber, 50000);
            task.Start();

            task.Wait();
            //Task.WaitAll(task);
        }
    }
}
