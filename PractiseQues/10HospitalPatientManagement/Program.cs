using System;

namespace HospitalPatientManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hospital Patient Management System");
            var hospitalManager = new HospitalManager();

            // Add patients
            hospitalManager.AddPatient("Alice Johnson", 45, "O+");
            hospitalManager.AddPatient("Bob Smith", 52, "A+");
            hospitalManager.AddPatient("Charlie Brown", 38, "B+");
            hospitalManager.AddPatient("Diana Prince", 29, "AB-");
            hospitalManager.AddPatient("Eve Davis", 67, "O-");

            // Add doctors
            hospitalManager.AddDoctor("Dr. Sarah Wilson", "Cardiology");
            hospitalManager.AddDoctor("Dr. Michael Scott", "Cardiology");
            hospitalManager.AddDoctor("Dr. Emily White", "Orthopedics");
            hospitalManager.AddDoctor("Dr. James Black", "Neurology");
            hospitalManager.AddDoctor("Dr. Lisa Green", "Dermatology");

            // Schedule appointments
            Console.WriteLine("Scheduling Appointments:");
            bool app1 = hospitalManager.ScheduleAppointment(2001, 3001, DateTime.Now.AddHours(2));
            Console.WriteLine($"Alice with Dr. Sarah Wilson: {(app1 ? "Scheduled" : "Failed")}");

            bool app2 = hospitalManager.ScheduleAppointment(2002, 3001, DateTime.Now.AddHours(3));
            Console.WriteLine($"Bob with Dr. Sarah Wilson: {(app2 ? "Scheduled" : "Failed")}");

            bool app3 = hospitalManager.ScheduleAppointment(2003, 3003, DateTime.Now.AddHours(4));
            Console.WriteLine($"Charlie with Dr. Emily White: {(app3 ? "Scheduled" : "Failed")}");

            // Display doctors by specialization
            Console.WriteLine("\nDoctors by Specialization:");
            var grouped = hospitalManager.GroupDoctorsBySpecialization();
            foreach (var spec in grouped)
            {
                Console.WriteLine($"\n{spec.Key}:");
                foreach (var doctor in spec.Value)
                {
                    Console.WriteLine($"  - {doctor.Name} (ID: {doctor.DoctorId})");
                }
            }

            // Display today's appointments
            Console.WriteLine("\nToday's Appointments:");
            var todayAppointments = hospitalManager.GetTodayAppointments();
            if (todayAppointments.Count == 0)
            {
                Console.WriteLine("No appointments scheduled for today.");
            }
            else
            {
                foreach (var appointment in todayAppointments)
                {
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentId} | Patient ID: {appointment.PatientId}");
                    Console.WriteLine($"  Doctor ID: {appointment.DoctorId} | Time: {appointment.AppointmentTime:yyyy-MM-dd HH:mm}");
                    Console.WriteLine($"  Status: {appointment.Status}");
                }
            }
        }
    }
}
