using Microsoft.AspNetCore.Identity;
using option4mvc.Constants;

namespace option4mvc.Data
{
    public static class DbSeeder
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            //seed roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            //creating admin

            var user = new ApplicationUser
            {
                UserName = "mom.and.popcorn.shop@gmail.com",
                Email = "mom.and.popcorn.shop@gmail.com",
                Name = "Admin",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var UserInDb = await userManager.FindByEmailAsync(user.Email);
            if(UserInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }

        }
    }
}
