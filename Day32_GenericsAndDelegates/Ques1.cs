using System;                                   // TODO: needed for Console

public class Program1                             
{
    public static void Main()                      
    {
        int a = 10;                                
        int b = 20;                                

        Swap<int>(ref a, ref b);                   

        Console.WriteLine($"a={a}, b={b}");        

        string x = "Varshith";                        
        string y = "Reddy";                        

        Swap(ref x, ref y);                         
        Console.WriteLine($"x={x}, y={y}");         
    }

    // ✅ TODO: Students must implement only this function
    public static void Swap<T>(ref T left, ref T right)
    {
        // TODO: Swap values using a temporary variable
        T temp = left;
        left = right;
        right = temp;
    }
}