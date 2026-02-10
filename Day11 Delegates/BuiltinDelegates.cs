using System;
namespace Delegates
{
    class Built
    {
        public static double AddNum1(int x, float y, double z)
        {
            return x + y + z;
        }
        public static void AddNum2(int x, float y, double z)
        {
            System.Console.WriteLine(x + y + z);
        }
        public static bool AddNum3(string str)
        {
            if(str.Length > 3)
                return true;
            return false;
        }

        static void Main()
        {
            Func<int, float, double, double> n1 = AddNum1;
            double res = n1.Invoke(3, 5.5f, 5.44);
            System.Console.WriteLine(res);

            // Anonymous methods
            // Func<int, float, double, double> n1 = (x, y, z) => x + y + z;
            // double res = n1.Invoke(3, 5.5f, 5.44);
            // System.Console.WriteLine(res);

            
            // Action<int, float, double> n2= AddNum2;
            // n2(3, 5.5f, 5.44);
            Action<int, float, double> n2= (x,y,z) => System.Console.WriteLine(x + y + z);
            n2(3, 5.5f, 5.44);

            Predicate<string> n3 = AddNum3;
            bool status1 = n3.Invoke("Hello");
            System.Console.WriteLine(status1);

            Predicate<int> p = x => x % 2 == 0;
            bool status2 = p(4);
            System.Console.WriteLine(status2);

        }
    }
}