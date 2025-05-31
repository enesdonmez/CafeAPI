using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;


namespace CafeAPI.Application.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseDto<List<string>>> GetAllRoles()
        {
            try
            {
                var roles = await _roleRepository.GetAllRolesAsync();
                if (roles != null && roles.Any())
                    return new ResponseDto<List<string>> { IsSuccess = true, Data = roles, Message = "Roller başarıyla alındı" };
                return new ResponseDto<List<string>> { IsSuccess = false, Data = null, Message = "Hiç rol bulunamadı", ErrorCode = ErrorCodes.NotFound };
            }
            catch (Exception)
            {
                return new ResponseDto<List<string>> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> AddRoleToUser(string email, string roleName)
        {
            try
            {
                var result = await _roleRepository.AddRoleToUserAsync(email, roleName);
                if (result)
                    return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Rol atama başarılı" };

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Rol atama başarısız", ErrorCode = ErrorCodes.BadRequest };
            }
            catch (Exception)
            {

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> CreateRole(string roleName)
        {
            try
            {
                var result = await _roleRepository.CreateRoleAsync(roleName);
                if (result)
                    return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Rol oluşturma başarılı" };

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Rol oluşturma başarısız", ErrorCode = ErrorCodes.BadRequest };

            }
            catch (Exception)
            {

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> DeleteRole(string roleName)
        {
            try
            {
                var result = await _roleRepository.DeleteRoleAsync(roleName);
                if (result)
                    return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Rol silme başarılı" };

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Rol silme başarısız", ErrorCode = ErrorCodes.BadRequest };
            }
            catch (Exception)
            {

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }
    }
}
