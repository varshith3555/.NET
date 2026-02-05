using System;

public class FlipKey
{
    public string CleanseAndInvert(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return string.Empty;
        }
        if(input.Length < 6)
        {
            return string.Empty;
        }
        foreach(var i in input)
        {
            if (!char.IsLetter(i))
            {
                return string.Empty;
            }
        }

        input = input.ToLower();

        string res = "";
        foreach(var i in input)
        {
            if((int)i % 2 != 0)
            {
                res += i;
            }
        }

        char[] array = res.ToCharArray();
        Array.Reverse(array);
        
        for(int i = 0; i < array.Length; i++)
        {
            if (i % 2 == 0)
            {
                array[i] = char.ToUpper(array[i]);
            }
        }
        return new string(array);
    }

    public static void Main()
    {
        FlipKey k = new FlipKey();
        System.Console.WriteLine("Enter the input");
        string? input = Console.ReadLine();

        string method = k.CleanseAndInvert(input ?? string.Empty);
        if (string.IsNullOrEmpty(method))
        {
            System.Console.WriteLine("Invalid Input");
        }
        else
        {
            System.Console.WriteLine("The generated key is - " + method);
        }
    }
}