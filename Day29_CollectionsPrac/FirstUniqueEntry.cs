class FirstUniqueEntry
{
    static List<int> GetFirstUniqueEntries(List<int> res)
    {
        HashSet<int> uni = new HashSet<int>();
        List<int> result = new List<int>();

        foreach(var i in res)
        {
            if (!uni.Contains(i))
            {
                uni.Add(i);
                result.Add(i);
            }
        }
        return result;
    }
    static void Main()
    {
        System.Console.WriteLine("Enter IDs separated by comma ");
        string input = Console.ReadLine();
        string[] parts = input.Split(",");
        List<int> data = new List<int>();
        foreach(var i in parts)
        {
            data.Add(int.Parse(i));
        }

        List<int> result = GetFirstUniqueEntries(data);
        foreach(var i in result)
        {
            System.Console.Write(i+" ");
        }
    }
}