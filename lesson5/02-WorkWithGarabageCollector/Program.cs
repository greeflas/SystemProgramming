using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_WorkWithGarabageCollector
{
    class Person
    {
        string firstname;
        string lastname;
        uint age;

        public Person()
        {
            firstname = "";
            lastname = "";
            age = 0;
        }

        public void Init(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Person p = new Person();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start memory: {0}", GC.GetTotalMemory(false));

            Person obj = new Person();
            Console.WriteLine("Object generation: {0}", GC.GetGeneration(obj));
            Console.WriteLine("Memory after object creation: {0}", GC.GetTotalMemory(false));

            obj.Init(1000);
            Console.WriteLine("Object generation after creation trash: {0}", GC.GetGeneration(obj));
            Console.WriteLine("Memory after creation trash: {0}", GC.GetTotalMemory(false));

            GC.Collect();
            Console.WriteLine("Object generation after collect: {0}", GC.GetGeneration(obj));
            Console.WriteLine("Memory after collect: {0}", GC.GetTotalMemory(false));
        }
    }
}
