using CafeAPI.Application.Dtos.AuthDtos;
using CafeAPI.Application.Dtos.ResponseDtos;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IAuthService
    {
        Task<ResponseDto<object>> GenerateToken(TokenDto dto);
    }
}
