using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Website1.Models;

namespace Website1.Helpers
{
    public static class AdminSeeder
    {

        public static async Task CreateAdmin(WebApplication App)
        {
            var scope = App.Services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();


            var adminEmail = "AdminAccount@gmail.com";
            var password = "Hh123456!";

            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(admin, password);
                if (!result.Succeeded)
                {
                    throw new Exception($"YOU COULDNT MAKE THE ACCOUNT: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }

                result = await userManager.AddToRoleAsync(admin, AppRoles.Admin.ToString());
                if (!result.Succeeded)
                {
                    throw new Exception($"Failed to add admin user to Admin role: {string.Join(", ", result.Errors.Select(e => e.Description))}");
                }
            }
        }        

    }    
}
