using System;

namespace _03_Singleton
{
    class Singleton
    {
        static Singleton instance;
        static object lockObj = new object();

        Singleton()
        {
        }

        public static Singleton GetInstance()
        {
            if(instance == null)
            {
                lock (lockObj)
                {
                    if (instance == null)
                        instance = new Singleton();
                }
            }

            return instance;
        }
    }
}
