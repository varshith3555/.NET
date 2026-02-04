using System;

class FileUpload
{
    static void Main()
    {
        string fileName = "report.exe";
        int fileSize = 8; 

        try
        {
            if(!fileName.EndsWith(".pdf"))
            {
                throw new Exception("Invalid file type. Only PDF files are allowed.");
            }

            if(fileSize > 5)
            {
                throw new Exception("File size exceeds the maximum limit.");
            }
            Console.WriteLine("File uploaded successfully.");
        }
        catch(Exception ex)
        {
            Console.WriteLine("Upload failed: " + ex.Message);
        }
    }
}
