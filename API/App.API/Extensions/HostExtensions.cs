using App.Domain.Entities;
using App.Persistance.Seeds;
using Microsoft.AspNetCore.Identity;

namespace App.API.Extensions
{
    public static class HostExtensions
    {
        public static async Task InitializeDatabaseAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                    await ApplicationDbContextSeed.SeedEssentialAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Veritabanı seed işlemi sırasında bir hata oluştu.");
                    throw;
                }
            }
        }
    }
}
