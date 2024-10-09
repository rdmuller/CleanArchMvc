using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace CleanArchMvc.Infra.Data.Identity;
public class SeedUserRoleInitial : ISeedUserRoleInitial
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, 
        RoleManager<IdentityRole> roleManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
    }

    public void SeedRoles()
    {
        AddRole("user");
        AddRole("admin");
    }

    public void SeedUsers()
    {
        AddUser("usuario@localhost", "User", "!Password123");
        AddUser("admin@localhost", "Admin", "!Password123");
    }

    private void AddUser(string email, string role, string Password)
    {
        if (_userManager.FindByEmailAsync(email).Result == null)
        {
            ApplicationUser user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                NormalizedUserName = email.ToUpper(),
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            IdentityResult result = _userManager.CreateAsync(user, Password).Result;

            if (result.Succeeded)
            {
                _userManager.AddToRoleAsync(user, role).Wait();
            }
        }
    }

    private void AddRole(string role)
    {
        if (!_roleManager.RoleExistsAsync(role).Result)
        {
            var identityRole = new IdentityRole
            {
                Name = role,
                NormalizedName = role.ToUpper(),
            };

            _roleManager.CreateAsync(identityRole).Wait();
        }
    }
}