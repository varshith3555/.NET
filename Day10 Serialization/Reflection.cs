using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace MyConsoleApp.Day10_Serialization
{
    public class Reflection
    {
        public int Id;
        private string Name;
    }
    class ReflectionMain
    {
        static void Main()
        {
            Reflection r = new Reflection();
            var props = r.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name);
            }
            Console.ReadLine();
        }
    }
}
