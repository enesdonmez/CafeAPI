using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IRoleService
    {
        Task<ResponseDto<List<string>>> GetAllRoles();
        Task<ResponseDto<object>> CreateRole(string roleName);
        Task<ResponseDto<object>> AddRoleToUser(string email, string roleName);
        Task<ResponseDto<object>> DeleteRole(string roleName);
    }
}
