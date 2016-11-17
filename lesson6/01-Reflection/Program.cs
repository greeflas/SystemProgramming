using System;
using System.Reflection;

namespace LessonReflection
{
    class Program
    {
        static void DisplayClassInfo(Type t)
        {
            Console.WriteLine("Name: {0}", t.Name);
            Console.WriteLine("Base type: {0}", t.BaseType);
        }

        static void DisplayMethods(Type t)
        {
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method);
            }
        }

        static void DisplayFields(Type t)
        {
            FieldInfo[] fields = t.GetFields();
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field);
            }
        }

        static void DisplayProperties(Type t)
        {
            PropertyInfo[] properties = t.GetProperties();
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property);
            }
        }

        static void Main(string[] args)
        {
            var MyType = new TestType();

            /* Getting type */
            // 1
            Type t = MyType.GetType();
            Console.WriteLine(t);

            // 2
            t = Type.GetType("LessonReflection.TestType");
            Console.WriteLine(t);

            /* Methods of class Type */
            Console.WriteLine("\n\tClass info");
            DisplayClassInfo(t);

            Console.WriteLine("\n\tMethods");
            DisplayMethods(t);

            Console.WriteLine("\n\tFields");
            DisplayFields(t);

            Console.WriteLine("\n\tProperties");
            DisplayProperties(t);
        }
    }
}
