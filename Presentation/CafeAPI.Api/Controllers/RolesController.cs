using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _roleService.GetAllRoles();
            return CreateResponse(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto roleDto)
        {
            var result = await _roleService.CreateRole(roleDto.RoleName);
            return CreateResponse(result);
        }

        [HttpPost("add-role-to-user")]
        public async Task<IActionResult> AddRoleToUser(AddRoleToUserDto dto)
        {
            var result = await _roleService.AddRoleToUser(dto.Email, dto.RoleName);
            return CreateResponse(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var result = await _roleService.DeleteRole(roleName);
            return CreateResponse(result);
        }
    }
}
