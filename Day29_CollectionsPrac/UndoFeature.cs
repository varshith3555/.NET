class UndoFeature
{
    static void Main()
    {
        List<string> ops = new List<string>();
        int n = int.Parse(Console.ReadLine()!);
        for(int i = 0; i < n; i++)
        {
            string input = Console.ReadLine()!;
            ops.Add(input);
        }
        string finalTExt = ProcessOperations(ops);
        System.Console.WriteLine(finalTExt);
    }
    static string ProcessOperations(List<string> ops)
    {
        Stack<string> stack = new Stack<string>();
        foreach(var i in ops)
        {
            if(i.StartsWith("TYPE "))
            {
                string word = i.Substring(5);
                stack.Push(word);
            }
            else if(i == "UNDO")
            {
                if(stack.Count  > 0)
                    stack.Pop();
            }
        }
        List<string> words = new List<string>(stack);
        words.Reverse();

        return string.Join(" ", words);
    }
}