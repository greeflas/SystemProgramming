using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace _04_TaskReturnValue
{
    class Program
    {
        static string[] Firstnames = new string[]
        {
            "Vasya",
            "Petro",
            "Elizaveta"
        };

        static string[] Lastnames = new string[]
        {
            "Pupkin",
            "Nikolaev",
            "Ahvetov"
        };

        static List<Student> GetStudentList()
        {
            List<Student> students = new List<Student>();

            for (int i = 0; i < 3; i++)
            {
                Random r = new Random();
                int index = r.Next(0, 2);

                string firstname = Firstnames[index];
                string lastname = Lastnames[index];

                students.Add(new Student(firstname, lastname, r.Next(1, 12)));
                Thread.Sleep(200);
            }

            return students;
        }

        static void Main(string[] args)
        {
            Task< List<Student> > task = new Task< List<Student> >(GetStudentList);
            task.Start();
            List<Student> students = task.Result;

            foreach(Student s in students)
            {
                Console.WriteLine(s);
                Console.WriteLine();
            }
        }
    }
}
