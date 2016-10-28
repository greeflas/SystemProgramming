using System;   
using System.Threading;

namespace _01_Timer
{
    class Program
    {
        static int count = 0;

        static void Tick(object obj)
        {
            Timer t = obj as Timer;

            if (count < 10)
            { 
                count++;
                Console.WriteLine("Timer work!");
            }
            else
                t.Dispose();
        }

        static void Main(string[] args)
        {
            TimerCallback timertCallback = new TimerCallback(Tick);
            Timer timer = new Timer(timertCallback);
            timer.Change(1000, 1000);

            Console.ReadKey();
        }
    }
}
