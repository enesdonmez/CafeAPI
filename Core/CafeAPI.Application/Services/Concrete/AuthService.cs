using CafeAPI.Application.Dtos.AuthDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Helpers;
using CafeAPI.Application.Services.Abstract;

namespace CafeAPI.Application.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly TokenHelper _tokenHelper;

        public AuthService(TokenHelper tokenHelper)
        {
            _tokenHelper = tokenHelper;
        }

        public async Task<ResponseDto<object>> GenerateToken(TokenDto dto)
        {
			try
			{
				string token = _tokenHelper.GenerateToken(dto);
                if (!string.IsNullOrEmpty(token))
                    return new ResponseDto<object> { IsSuccess = true, Data = token, Message = "Token oluşturuldu" };

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Token oluşturulamadı", ErrorCode = ErrorCodes.BadRequest };
            }
			catch (Exception)
			{
				return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "bir hata olustu" ,ErrorCode = ErrorCodes.Exception };
			}
        }
    }
}
