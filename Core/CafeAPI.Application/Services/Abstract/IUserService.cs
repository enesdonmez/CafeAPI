using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.UserDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IUserService
    {
        Task<ResponseDto<object>> Register(RegisterDto dto);
    }
}
