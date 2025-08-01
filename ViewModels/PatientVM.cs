namespace Website1.ViewModels
{
    public class PatientVM
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age => Convert.ToInt32((DateTime.Today - DateOfBirth).TotalDays / 365);

        public List<AppointmentVM> Appointments { get; set; } = new List<AppointmentVM>();


    }
}

