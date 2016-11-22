using System;
using System.Reflection;

namespace _03_LoadStaticLib
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load lib and show classes
            Assembly assembly = Assembly.Load(AssemblyName.GetAssemblyName("CarLibrary.dll"));

            Module module = assembly.GetModule("CarLibrary.dll");

            foreach(Type t in module.GetTypes())
                Console.WriteLine(t.FullName);

            // Call method from lib
            Type type = assembly.GetType("CarLibrary.SecretCar");

            object o = Activator.CreateInstance(type, new object[] { "Toyota", 150, 110 });
            MethodInfo method = type.GetMethod("Acceleration");
            method.Invoke(o, null);
        }
    }
}
