using System.Security.Principal;
using Microsoft.VisualBasic;

class Program{
    static void Main(){

        #region Reverse
        // string input1 = Console.ReadLine()!;
        // string rev = "";
        // for(int i = input1.Length - 1; i >= 0; i--)
        // {
        //     rev += input1[i];
        // }
        // System.Console.WriteLine(rev);
        #endregion

        #region largest element
        // int[] arr = {1,3,7,9};
        // int max = arr[0];
        // foreach(var i in arr)
        // {
        //     if(i > max)
        //     {
        //         max = i;
        //     }
        // }
        // System.Console.WriteLine(max);
        #endregion

        #region Remove duplicates

        // System.Console.WriteLine("Enter the no of elements");
        // int n = int.Parse(Console.ReadLine()!);

        // List<int> list = new List<int>(); 
        // System.Console.WriteLine("Enter the elements");
        // for(int i = 0; i < n; i++)
        // {
        //     int temp = int.Parse(Console.ReadLine()!);
        //     list.Add(temp);
        // }
        
        // HashSet<int> uniqueNumbers = new HashSet<int>(list);
        // foreach(int num in uniqueNumbers)
        // {
        //     Console.Write(num + " ");
        // }
        #endregion

        #region Frequency
        // System.Console.WriteLine("Enter the no. of elements");
        // int n = int.Parse(Console.ReadLine()!);
        // int[] arr = new int[n];
        // for(int i = 0; i < n; i++)
        // {
        //     arr[i] += int.Parse(Console.ReadLine()!);
        // }

        // Dictionary<int, int> count = new Dictionary<int, int>();
        // foreach(var i in arr)
        // {
        //     if (count.ContainsKey(i))
        //     {
        //         count[i]++;
        //     }
        //     else
        //     {
        //         count[i] = 1;
        //     }
        // }
        // foreach(var i in count)
        // {
        //     System.Console.WriteLine(i.Key + " " + i.Value);
        // }
        #endregion
        #region Palindrome
        // string input = Console.ReadLine();
        // char[] storing=input.ToCharArray();
        // int i=0;
        // int j=input.Length-1;
        // while (i <= j)
        // {
        //     char temp=storing[i];
        //     storing[i]=storing[j];
        //     storing[j]=temp;
        //     i++;
        //     j--;
        // }
        // string inputNew=new string(storing);
        // Console.WriteLine("Palindrome Check: "+(input==inputNew));
        #endregion


        #region SumOfElements
        Console.WriteLine("Enter the num of elements: ");
        int n = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the elements: ");
        int[] elements = new int[n];
        for (int i = 0; i < n; i++)
        {
            elements[i] = int.Parse(Console.ReadLine()!);
        }
        int sum = elements.Sum(e=>e);
        // foreach (var item in elements)
        // {
        //     sum += item;
        // }
        Console.WriteLine("Sum of elemets: " + sum);
        #endregion

        
    }
}