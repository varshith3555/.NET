using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalPatientManagement
{
    public class HospitalManager
    {
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<Appointment> appointments = new List<Appointment>();
        private int patientId = 2001;
        private int doctorId = 3001;
        private int appointmentId = 4001;

        public void AddPatient(string name, int age, string bloodGroup)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Patient name cannot be empty.");

            patients.Add(new Patient
            {
                PatientId = patientId++,
                Name = name,
                Age = age,
                BloodGroup = bloodGroup
            });
        }

        public void AddDoctor(string name, string specialization)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Doctor name cannot be empty.");

            doctors.Add(new Doctor
            {
                DoctorId = doctorId++,
                Name = name,
                Specialization = specialization
            });
        }

        public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
        {
            var patient = patients.FirstOrDefault(p => p.PatientId == patientId);
            if (patient == null)
                throw new Exception("Patient not found.");

            var doctor = doctors.FirstOrDefault(d => d.DoctorId == doctorId);
            if (doctor == null)
                throw new Exception("Doctor not found.");

            appointments.Add(new Appointment
            {
                AppointmentId = appointmentId++,
                PatientId = patientId,
                DoctorId = doctorId,
                AppointmentTime = time,
                Status = "Scheduled"
            });

            return true;
        }

        public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
        {
            var grouped = new Dictionary<string, List<Doctor>>();
            foreach (var doctor in doctors)
            {
                if (!grouped.ContainsKey(doctor.Specialization))
                    grouped[doctor.Specialization] = new List<Doctor>();
                grouped[doctor.Specialization].Add(doctor);
            }
            return grouped;
        }

        public List<Appointment> GetTodayAppointments()
        {
            DateTime today = DateTime.Now.Date;
            return appointments.Where(a => a.AppointmentTime.Date == today && a.Status == "Scheduled").ToList();
        }
    }
}
