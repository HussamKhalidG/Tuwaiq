using Website1.ViewModels;

namespace Website1.Models
{
    public class Patient
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalId { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Age => Convert.ToInt32((DateTime.Today - DateOfBirth).TotalDays / 365);

        public PatientVM ToPatientVM()
        {
            return new PatientVM
            {
                Id = Id,
                FullName = FullName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                NationalId = NationalId,
                PhoneNumber = PhoneNumber
            };
        }

        public PatientCreateVM ToPatientCreateVM()
        {
            return new PatientCreateVM
            {
                Id = Id,
                FullName = FullName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                NationalId = NationalId,
                PhoneNumber = PhoneNumber
            };
        }

        public PatientUpdateVM ToPatientUpdateVM()
        {
            return new PatientUpdateVM
                {
                Id = Id,
                FullName = FullName,
                DateOfBirth = DateOfBirth,
                Email = Email,
                NationalId = NationalId,
                PhoneNumber = PhoneNumber
            };
        }

    }
}
