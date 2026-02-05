public class WordWand
{
    public static bool IsValid(string str)
    {
        foreach(var c in str)
        {
            if(!char.IsLetter(c) && c != ' ')
            {
                return false;
            }
        }
        return true;
    }

    public static void Main()
    {
        System.Console.WriteLine("Enter the sentence");
        string sen = Console.ReadLine()!;

        if (!IsValid(sen))
        {
            System.Console.WriteLine("Invalid Sentence");
            return;
        }

        string res = "";
        string[] words = sen.Split(" ");
        if(words.Length % 2 == 0)
        {
            for(int i=words.Length - 1; i >= 0; i--)
            {
                res += words[i] + " "; 
            }
        }
        else
        {
            foreach(var i in words)
            {
                char[] arr = i.ToCharArray();
                Array.Reverse(arr);
                res += new string(arr) + " ";
            }
        }
        System.Console.WriteLine(res);
    }
}