 using System;
using System.Collections.Generic;
using System.Linq;

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

// 1. Generic patient queue with priority
public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();

    // TODO: Enqueue patient with priority (1=highest, 5=lowest)
    public void Enqueue(T patient, int priority)
    {
        if(priority < 1 || priority > 5)
            return;

        if(!_queues.ContainsKey(priority))
            _queues[priority] = new Queue<T>();

        _queues[priority].Enqueue(patient);
    }

    // TODO: Dequeue highest priority patient
    public T Dequeue()
    {
        foreach(var q in _queues)
        {
            if(q.Value.Count > 0)
                return q.Value.Dequeue();
        }
        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Peek without removing
    public T Peek()
    {
        foreach(var q in _queues)
        {
            if(q.Value.Count > 0)
                return q.Value.Peek();
        }
        throw new InvalidOperationException("Queue is empty");
    }

    // TODO: Get count by priority
    public int GetCountByPriority(int priority)
    {
        if(_queues.ContainsKey(priority))
        {
            return _queues[priority].Count;
        }
        return 0;
    }
}

// 2. Generic medical record
public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }

    // TODO: Add diagnosis with date
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        _diagnoses.Add(date.ToString() + " - " + diagnosis);
    }

    // TODO: Add treatment
    public void AddTreatment(string treatment, DateTime date)
    {
        _treatments[date] = treatment;
    }

    // TODO: Get treatment history
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        return _treatments.OrderBy(t => t.Key);
    }
}

// 3. Specialized patient types
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}

// 4. Generic medication system
public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();

    // TODO: Prescribe medication with dosage validation
    public void PrescribeMedication(T patient, string medication, Func<T, bool> dosageValidator)
    {
        if(!dosageValidator(patient))
            return;

        if(!_medications.ContainsKey(patient))
        {
            _medications[patient] = new List<(string, DateTime)>();
        }

        _medications[patient].Add((medication, DateTime.Now));
    }

    // TODO: Check for drug interactions
    public bool CheckInteractions(T patient, string newMedication)
    {
        if(!_medications.ContainsKey(patient))
            return false;

        return _medications[patient].Any(m => m.medication == newMedication);
    }
}

// 5. TEST SCENARIO
class Program5
{
    static void Main()
    {
        var p1 = new PediatricPatient
        {
            PatientId = 1,
            Name = "Child1",
            DateOfBirth = new DateTime(2018, 5, 1),
            BloodType = BloodType.A,
            Weight = 18
        };

        var p2 = new GeriatricPatient
        {
            PatientId = 2,
            Name = "Senior1",
            DateOfBirth = new DateTime(1950, 3, 10),
            BloodType = BloodType.O,
            MobilityScore = 6
        };

        var queue = new PriorityQueue<IPatient>();
        queue.Enqueue(p1, 2);
        queue.Enqueue(p2, 1);

        var record = new MedicalRecord<IPatient>(p1);
        record.AddDiagnosis("Fever", DateTime.Now);
        record.AddTreatment("Paracetamol", DateTime.Now);

        var meds = new MedicationSystem<IPatient>();
        meds.PrescribeMedication(p1, "Paracetamol", pat => true);

        Console.WriteLine(queue.Dequeue().Name);
    }
}
