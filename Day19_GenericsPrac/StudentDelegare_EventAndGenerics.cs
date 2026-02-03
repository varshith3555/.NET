using System;
using System.Collections.Generic;
using System.Linq;

namespace MyConsoleApp.Day19_Generics;

public delegate void Notify(string message);

public class Student
{
    public string Name{ get; set; }
    public int Id{ get; set; }
    public int Marks1{ get; set; }
    public int Marks2{ get; set; }

    public double Avg =>(Marks1 + Marks2) / 2.0;

    public event Notify OnFail;

    public void CheckResult(int rank)
    {
        if(Avg < 40)
        {
            OnFail?.Invoke($"{Name} is FAILED with Avg {Avg} (Rank: {rank})");
        }
        else
        {
            Console.WriteLine($"Rank {rank}: {Name} Avg = {Avg}");
        }
    }
}

class StudentProgram
{
    public static void MainOld()
    {
        List<Student> stu = new List<Student>()
        {
            new Student(){Id=1, Name="Varshith", Marks1=99, Marks2=11},
            new Student(){Id=7, Name="Nani", Marks1=77, Marks2=33},
            new Student(){Id=3, Name="Mani", Marks1=33, Marks2=51}
        };

        var sorted = stu.OrderByDescending(s => s.Avg).ToList();

        int rank = 1;
        foreach(var s in sorted)
        {
            s.OnFail -= FailNotification;  
            s.OnFail += FailNotification;
            s.CheckResult(rank);
            rank++;
        }
    }

    public static void FailNotification(string msg)
    {
        Console.WriteLine(msg);
    }
}
