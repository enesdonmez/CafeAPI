using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.UserDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IUserService
    {
        Task<ResponseDto<object>> Register(RegisterDto dto);
        Task<ResponseDto<object>> DefaultRegister(RegisterDto dto);
        Task<ResponseDto<object>> Login(LoginDto dto);
        Task Logout();
        Task<ResponseDto<UserDto>> CheckUser(string email);
        Task<ResponseDto<object>> CheckUserWithPassword(LoginDto dto);

    }
}
