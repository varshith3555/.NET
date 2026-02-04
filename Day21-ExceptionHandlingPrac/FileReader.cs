class FileReader
{
    public static void Main()
    {
        string filePath  = "C:\\Users\\varshith\\LPUEx\\SQLSERVER\\SQL-Training\\Day5\\Indexing.sql";
        try
        {
            string content = File.ReadAllText(filePath );
            System.Console.WriteLine(content);
        }catch(FileNotFoundException)
        {
            System.Console.WriteLine("File not found");
        }catch(UnauthorizedAccessException)
        {
            System.Console.WriteLine("Access denied");
        }
    }
}