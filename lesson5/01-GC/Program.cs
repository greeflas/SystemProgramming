using System;

namespace _01_GC
{
    class Program
    {
        class Test
        {
            int[] arr = new int[100000000];

            public void Method(int i)
            {
                Console.WriteLine(i);
            }

            ~Test()
            {
                Console.WriteLine("Object {0} has been removed!", this.GetHashCode());
            }
        }

        static void Main(string[] args)
        {
            Test[] arr = new Test[1000];

            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = new Test();
                    arr[i].Method(i);
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}
