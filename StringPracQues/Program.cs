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

        System.Console.WriteLine("Enter the no of elements");
        int n = int.Parse(Console.ReadLine()!);
        
        List<int> list = new List<int>(); 
        System.Console.WriteLine("Enter the elements");
        for(int i = 0; i < n; i++)
        {
            int temp = int.Parse(Console.ReadLine()!);
            list.Add(temp);
        }
        
        HashSet<int> uniqueNumbers = new HashSet<int>(list);
        foreach(int num in uniqueNumbers)
        {
            Console.Write(num + " ");
        }
        #endregion
    }
}