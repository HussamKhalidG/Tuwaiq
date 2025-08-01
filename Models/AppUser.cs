using Microsoft.AspNetCore.Identity;
using Website1.ViewModels;

namespace Website1.Models
{
    public class AppUser : IdentityUser
    {

        public byte[]? ProfilePicture { get; set; }

    }
}
