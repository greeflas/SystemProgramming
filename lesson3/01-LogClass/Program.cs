using System;
using System.IO;
using System.Threading;

namespace _01_LogClass
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!File.Exists("person.log"))
            {
                File.Create("person.log");
                Thread.Sleep(300);
            }

            Person p1 = new Person()
            {
                Firstname = "Vasya",
                Lastname = "Pupkin",
                Birthday = new DateTime(1999, 05, 23)
            };
        }
    }
}
