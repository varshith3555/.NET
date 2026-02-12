using Microsoft.VisualBasic;

class Program{
    static void Main(){

        #region Reverse
        string input1 = Console.ReadLine()!;
        string rev = "";
        for(int i = input1.Length - 1; i >= 0; i--)
        {
            rev += input1[i];
        }
        System.Console.WriteLine(rev);
        #endregion
    }
}