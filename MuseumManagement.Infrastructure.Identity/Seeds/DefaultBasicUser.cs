using Microsoft.AspNetCore.Identity;
using MuseumManagement.Infrastructure.Identity.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MuseumManagement.Infrastructure.Identity.Seeds
{
    public static class DefaultBasicUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "SuperAdmin",
                Email = "SuperAdmin@SuperAdmin.com",
                Name = "Sulaiman",
                PhoneNumber = "00967773050577",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Sulaiman@12345");
                    await userManager.AddToRoleAsync(defaultUser, "SuperAdmin");
                }

            }
        }
    }
}
