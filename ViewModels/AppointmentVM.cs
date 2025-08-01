using Website1.Models;

namespace Website1.ViewModels
{
    public class AppointmentVM
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } // Use Statuses enum if needed
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
