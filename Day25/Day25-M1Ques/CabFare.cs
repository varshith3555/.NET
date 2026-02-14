namespace M1Ques
{
    class Cab
    {
        public virtual double CalculateFare(int km)
        {
           return 0;
        }
    }
    class Mini : Cab
    {
        public override double CalculateFare(int km)
        {
           return km * 12;
        }
    }
    class Sedan : Cab
    {
        public override double CalculateFare(int km)
        {
           return km * 15 + 50;
        }
    }
    class SUV : Cab
    {
        public override double CalculateFare(int km)
        {
           return km * 18 + 100;
        }
    }
    class CanMain
    {
        public static void Main()
        {
            Cab  c = new Sedan();
            System.Console.WriteLine(c.CalculateFare(3));
            Cab b = new Mini();
            System.Console.WriteLine(b.CalculateFare(5));
            Cab a = new SUV();
            System.Console.WriteLine(a.CalculateFare(1));

        }
    }
}