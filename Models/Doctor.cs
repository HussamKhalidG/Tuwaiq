using Website1.ViewModels;

namespace Website1.Models
{
    public class Doctor 
    {

        public int Id { get; set; }

        public string FullName { get; set; }
        //public String Specialty { get; set; }

        //public User User { get; set; }

        public List<Appointment> Appointments { get; set; }

    }
}
