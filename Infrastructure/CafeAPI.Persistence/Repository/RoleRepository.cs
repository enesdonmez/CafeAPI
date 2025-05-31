using CafeAPI.Application.Interfaces;
using CafeAPI.Persistence.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CafeAPI.Persistence.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly RoleManager<AppIdentityRole> _roleManager;

        public RoleRepository(RoleManager<AppIdentityRole> roleManager, UserManager<AppIdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<bool> AddRoleToUserAsync(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
                return false;

            var existsRole = await _roleManager.RoleExistsAsync(roleName);
            if (!existsRole)
                return false;

            var result = await _userManager.AddToRoleAsync(user, roleName);
            if (result.Succeeded)
                return true;

            return false;
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
                return false;

            var existsRole = await _roleManager.RoleExistsAsync(roleName);
            if (existsRole)
                return false;

            var result = await _roleManager.CreateAsync(new AppIdentityRole(roleName));
            if (result.Succeeded)
                return true;

            return false;
        }

        public async Task<bool> DeleteRoleAsync(string roleName)
        {

            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
                return false;

            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }

        public async Task<List<string>> GetAllRolesAsync()
        {
            var roles = await _roleManager.Roles.AsNoTracking().ToListAsync();
            if (roles == null || !roles.Any())
                return new List<string>();

            return roles.Select(r => r.Name).ToList();
        }
    }
}
