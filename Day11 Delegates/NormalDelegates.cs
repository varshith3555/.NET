namespace Delegates
{
    public delegate double Normal1(int x, float y, double z);
    public delegate void Normal2(int x, float y, double z);
    public delegate bool Normal3(string msg);
    class Normal
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
            Normal1 n1 = AddNum1;
            double res = n1.Invoke(3, 3.5f, 5.44);
            System.Console.WriteLine(res);

            Normal2 n2= AddNum2;
            n2.Invoke(3, 3.5f, 5.44);

            Normal3 n3 = AddNum3;
            bool status = n3.Invoke("Hello");
            System.Console.WriteLine(status);
        }
    }
}