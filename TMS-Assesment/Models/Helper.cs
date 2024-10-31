using Microsoft.AspNetCore.Identity;

namespace TMS_Assesment.Models
{
    public class Helper
    {
        public static async Task DataHelper(UserManager<TmsUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string roleName = "Admin";
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

            var user = new TmsUser
            {
                UserName = "ADMIN",
                Email = "admin@tms.com",
                User_Name = "Admin User"
            };

            if (await userManager.FindByEmailAsync(user.Email) == null)
            {
                await userManager.CreateAsync(user, "Password@123");
                await userManager.AddToRoleAsync(user, roleName);
            }
        }


    }
}
