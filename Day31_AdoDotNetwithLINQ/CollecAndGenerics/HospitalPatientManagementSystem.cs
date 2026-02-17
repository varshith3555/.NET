using System;
using System.Collections.Generic;
using System.Linq;

// Task 1: Patient class
public class Patient
{
    // Properties with encapsulation
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }
    public List<string> MedicalHistory { get; set; }
    public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }
}

// Task 2: HospitalManager class
public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (!_patients.ContainsKey(id))
        {
            Patient patient = new Patient(id, name, age, condition);
            _patients.Add(id, patient);
        }
        else
        {
            Console.WriteLine("Patient ID already exists");
        }
    }
    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        if (_patients.ContainsKey(patientId))
        {
            _appointmentQueue.Enqueue(_patients[patientId]);
        }
        else
        {
            Console.WriteLine("Patient not found");
        }
    }
    // Process next appointment (remove from queue)
    public Patient ProcessNextAppointment()
    {
        if (_appointmentQueue.Count > 0)
        {
            return _appointmentQueue.Dequeue();
        }
        else
        {
            Console.WriteLine("No appointments in queue");
            return null;
        }
    }

    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        return _patients.Values.Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}
class Program
{
    static void Main()
    {
        HospitalManager manager = new HospitalManager();

        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");

        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name);   // John Doe

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count);  // 1
    }
}
