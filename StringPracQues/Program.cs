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
        int[] arr = {1,3,7,9};
        int max = arr[0];
        foreach(var i in arr)
        {
            if(i > max)
            {
                max = i;
            }
        }
        System.Console.WriteLine(max);
        #endregion

    }
}