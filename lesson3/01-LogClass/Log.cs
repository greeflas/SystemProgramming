using System;
using System.Threading;

namespace _01_LogClass
{
    class Log
    {
        object locked = new object();

        public Thread thread;
        string PropertyName;
        string FileName;

        public Log(string PropertyName, string FileName)
        {
            this.PropertyName = PropertyName;
            this.FileName = FileName;

            thread = new Thread(Run);
            thread.Start();
        }

        void Run()
        {
            lock(locked)
            {
                LogWriter logWriter = LogWriter.GetInstance(FileName);
                logWriter.writer.WriteLine("{0} propertie has been changed.", PropertyName);
                logWriter.writer.Flush();

                Thread.Sleep(500);
            }
        }
    }
}
