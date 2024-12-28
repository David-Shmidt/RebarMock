using Microsoft.AspNetCore.Identity;

namespace RebarMock.Identity
{
    public class RolesCreator
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var rolesManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = new string[] {"Admin", "Manager" , "User"};

            foreach (var roleName in roleNames)
            {
                var roleExist = await rolesManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await rolesManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
