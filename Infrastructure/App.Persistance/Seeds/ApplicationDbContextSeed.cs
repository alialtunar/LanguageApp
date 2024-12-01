using App.Domain.Constants;
using App.Domain.Entities;
using App.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace App.Persistance.Seeds
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Moderator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //Seed Default User
            var defaultUser = new ApplicationUser
            {   FirstName = "Ali",
                LastName = "Altunar" ,
                UserName = UserDefaults.DefaultUsername.ToString(),
                Email = UserDefaults.DefaultEmail,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                await userManager.CreateAsync(defaultUser, UserDefaults.DefaultPassword);
                await userManager.AddToRoleAsync(defaultUser, UserDefaults.DefaultRole.ToString());
            }
        }
    }
}
