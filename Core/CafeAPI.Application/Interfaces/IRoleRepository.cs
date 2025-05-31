namespace CafeAPI.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<List<string>> GetAllRolesAsync();
        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> AddRoleToUserAsync(string email, string roleName);
        Task<bool> DeleteRoleAsync(string roleName);
    }
}
