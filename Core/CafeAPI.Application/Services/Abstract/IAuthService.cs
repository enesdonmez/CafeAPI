using CafeAPI.Application.Dtos.AuthDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.UserDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> GenerateToken(LoginDto dto);
    }
}
