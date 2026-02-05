public class RobotSafetyException: Exception
{
    public RobotSafetyException(string Message) : base(Message)
    {
        
    }
}

public class RobotazardAuditor
{
    public double CalculateHazardRisk(double armPrecision,int workerDensity,string machineryState)
    {
        double riskFactor=0;
        double risk=0;
        if(armPrecision<0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error:  Arm precision must be 0.0-1.0");
        }
        if(workerDensity<1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }
        if (machineryState != "Worn" && machineryState != "Faulty" && machineryState != "Critical")
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }
        if (machineryState == "Worn")
        {
            riskFactor=1.3;
        }
        else if(machineryState == "Faulty")
        {
            riskFactor=2.0;
        }
        else if(machineryState=="Critical")
        {
            riskFactor=3.0;
        }
        risk=((1.0-armPrecision)*15.0)+(workerDensity*riskFactor);
        return risk;
    }
}
public class Robot
{
    public static void Main(string[] args)
    {
        RobotazardAuditor robo=new RobotazardAuditor();
        System.Console.WriteLine("Enter Arm Precision (0.0 - 1.0): ");
        double armPrecision=double.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter Worker Density (1 - 20): ");
        int workerDensity=int.Parse(Console.ReadLine()!);
        System.Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical): ");
        string machineryState=Console.ReadLine()!;
        
        try{
            double result=robo.CalculateHazardRisk(armPrecision,workerDensity,machineryState);
            System.Console.WriteLine($"Robot Hazard Risk Score: {result}");
        }
        catch(RobotSafetyException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}
