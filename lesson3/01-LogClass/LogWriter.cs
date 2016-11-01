using System;
using System.IO;

namespace _01_LogClass
{
    class LogWriter : IDisposable
    {
        static LogWriter instance;
        static object lockObj = new object();

        public StreamWriter writer
        {
            get;
            private set;
        }

        LogWriter()
        {

        }

        LogWriter(string fileName)
        {
            writer = new StreamWriter(fileName);
        }

        public static LogWriter GetInstance(string fileName)
        {
            if(instance == null)
            {
                lock(lockObj)
                {
                    if (instance == null)
                    {
                        instance = new LogWriter(fileName);
                    }
                }
            }

            return instance;
        }

        public void Dispose()
        {
            writer.Close();
        }
    }
}
