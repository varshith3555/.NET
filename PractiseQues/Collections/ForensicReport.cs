using System;

public class ForensicReport
{
    private Dictionary<string, DateTime> reportMap = new Dictionary<string, DateTime>();
    public Dictionary<string, DateTime> ReportMap
    {
        get{return reportMap;}
        set{reportMap = value;}
    }
    public void addReportDetails(String reportingOfficerName, DateTime reportFiledDate)
    {
        reportMap[reportingOfficerName] = reportFiledDate;
    }
    public List<string> getOfficersWhoFiledReportsOnDate(DateTime reportFiledDate)
    {
        return reportMap
                .Where(x => x.Value.Date == reportFiledDate.Date)
                .Select(x => x.Key)
                .ToList();
    } 
}
public class UserInterface2
{
    public static void Main()
    {
        ForensicReport r = new ForensicReport();
        System.Console.WriteLine("Enter number of reports to be added");
        int n = int.Parse(Console.ReadLine()!);

        System.Console.WriteLine("Enter the Forensic reports (Reporting Officer: Report Filed Date)");
        for(int i = 1; i <= n; i++)
        {
            string? input = Console.ReadLine();
            string[] parts = input.Split(":");
            r.addReportDetails(parts[0], DateTime.Parse(parts[1]));
        }

        System.Console.WriteLine("Enter the filed date to identify the reporting officers");
        DateTime date = DateTime.Parse(Console.ReadLine()!);

        var res = r.getOfficersWhoFiledReportsOnDate(date);
        if(res.Count > 0)
        {
            System.Console.WriteLine("Reports filed on the" + date + " are by ");
            foreach(var i in res)
            {
                System.Console.WriteLine(i);
            }
        }
        else
        {
            System.Console.WriteLine("No reporting officer filed the report");
        }
    }
}