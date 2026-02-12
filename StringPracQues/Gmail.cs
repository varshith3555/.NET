using System.ComponentModel.DataAnnotations;

class Example
{
    static  void Main()
    {
        #region Gmail
        string input = Console.ReadLine()!.ToLower();
        if (!input.Contains("@"))
        {
            System.Console.WriteLine("Invalid Email");
            return;
        }
        int count = 0;
        foreach(var i in input)
        {
            if(i == '@')
            {
                count++;
            }
            else
            {
                continue;
            }
        }
        if(count != 1)
        {
            System.Console.WriteLine("Invalid Email");
        }
        string[] parts = input.Split("@");
        foreach(var i in parts[0])
        {
            if(!char.IsLetterOrDigit(i))
            {
                System.Console.WriteLine("Invalid Email");
            }    
        }
        
        if (parts[1] != "gmail.com")
        {
            Console.WriteLine("Invalid Email");
            return;
        }  
        #endregion   
    
    }
}