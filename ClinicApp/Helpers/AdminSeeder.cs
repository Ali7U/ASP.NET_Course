using Microsoft.AspNetCore.Identity;

namespace ClinicApp;

public static class AdminSeeder
{
    public static async Task SeedAdminUser(WebApplication app)
    {
        // Create Scope
        var scope = app.Services.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        var adminEmail = "Ali@gmail.com";
        var adminPassword = "Admin@123456";

        // Find Admin User
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            // Create Admin User
            adminUser = new IdentityUser
            {
                UserName = adminEmail.Split("@")[0], 
                Email = adminEmail,
                EmailConfirmed = true
            };
            
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            
            if (!result.Succeeded)
            {
                throw new Exception("Can't create admin user");
            }
            
            // Assign Admin Role
            result = await userManager.AddToRoleAsync(adminUser, AppRoles.APP_ADMIN.ToString());    
            if(!result.Succeeded)
            {
                throw new Exception("Can't assign admin role to admin user");
            }
        }
    }
}