using Website1.ViewModels;

namespace Website1.Models
{
    public class Appointment
    {

        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string Status { get; set; } // e.g., Scheduled, Completed, Cancelled

        public DateTime CreatedAt { get; set; }

        public Patient Patient { get; set; }

        public Doctor Doctor { get; set; }

    }
}
