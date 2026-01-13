using System;
using System.Collections.Generic;
using System.Text;

namespace MyConsoleApp.Day5_Abstract___Project_References
{
    public class MainApp
    {
        public static void Main(string[] args)
        {
            Algebra m = new Algebra();
            int sum = m.Add(1, 3);
            Console.WriteLine("Sum = " + sum);

            AeroScience aeroScience = new AeroScience();
            double lift = aeroScience.AeroDynamics(1.225, 50, 20, 1.2);
            Console.WriteLine("Lift Force = " + lift);

            SciLogin sl = new SciLogin();
            sl.LogIn("Capp", "123");
            sl.LogOut();
        }
    }
}
