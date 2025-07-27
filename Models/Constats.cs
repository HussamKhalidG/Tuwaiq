namespace Website1.Models
{
    public class Constats
    {


        public static List<Patient> Patients = new List<Patient>
        {
            new Patient
            {
                Id = 1,
                FullName = "John Doe",
                NationalId = "123456789",
                Email = "Alhazmi@gmail.com",
                PhoneNumber = "123-456-7890",
                DateOfBirth = new DateTime(1990, 1, 1)

            },

            new Patient
            {
                Id = 2,
                FullName = "Jbannan Doe",
                NationalId = "1223156789",
                Email = "Alhazmdci@gmail.com",
                PhoneNumber = "123-456-2390",
                DateOfBirth = new DateTime(1980, 1, 1)

            },

            new Patient
            {
                Id = 3,
                FullName = "nanana koko",
                NationalId = "12sadw6789",
                Email = "Alhadwzmi@gmail.com",
                PhoneNumber = "191-456-7890",
                DateOfBirth = new DateTime(2000, 1, 1)

            },


        };
    }
}


