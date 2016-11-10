using System;

namespace _04_IDisposable
{
    class ResourceWrapper : IDisposable
    {
        bool disposed = false;

        ~ResourceWrapper()
        {
            CleanUp(false);
        }

        public void Dispose()
        {
            CleanUp(true);
            GC.SuppressFinalize(this);
        }

        void CleanUp(bool clean)
        {
            if(!disposed)
            {
                if(clean)
                {
                    Console.WriteLine("Resourse cleaning...");

                }

                Console.WriteLine("Finalized!");
            }

            disposed = true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using (ResourceWrapper wrapp = new ResourceWrapper())
            {
                Console.WriteLine(wrapp);
            }

            ResourceWrapper wrapp2 = new ResourceWrapper();
            Console.WriteLine(wrapp2);

            wrapp2.Dispose();
            wrapp2.Dispose();
            wrapp2.Dispose();
            wrapp2.Dispose();

            ResourceWrapper wrapp3 = new ResourceWrapper();
            Console.ReadKey();
        }
    }
}
