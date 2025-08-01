using System.ComponentModel.DataAnnotations;
using Website1.Helpers;
using Website1.Models;

namespace Website1.ViewModels
{
    public class CreateAccVM
    {

        public string Email { get; set; }

        public string Password { get; set; }

        [EnumDataType(typeof(AppRoles))]
        public string Role { get; set; } = null!;

        [Display(Name = "Profile Picture")]
        public IFormFile? ProfilePicture { get; set; }
    }
}
