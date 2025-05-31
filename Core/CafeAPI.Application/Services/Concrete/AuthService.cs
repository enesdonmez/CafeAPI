using CafeAPI.Application.Dtos.AuthDtos;
using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Helpers;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;

namespace CafeAPI.Application.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly TokenHelper _tokenHelper;
        private readonly IUserRepository _userRepository;

        public AuthService(TokenHelper tokenHelper, IUserRepository userRepository)
        {
            _tokenHelper = tokenHelper;
            _userRepository = userRepository;
        }

        public async Task<ResponseDto<object>> GenerateToken(LoginDto dto)
        {
			try
			{
                var check_user = await _userRepository.CheckUserAsync(dto.Email);
                if (!string.IsNullOrEmpty(check_user.Id))
                {
                    var user = await _userRepository.CheckUserWithPasswordAsync(dto);
                    if (user.Succeeded)
                    {
                        var tokenDto = new TokenDto
                        {
                            Email = dto.Email,
                            Id = check_user.Id,
                            Role = check_user.RoleName
                        };
                        string token = _tokenHelper.GenerateToken(tokenDto);
                        if (!string.IsNullOrEmpty(token))
                            return new ResponseDto<object> { IsSuccess = true, Data = new { token = token }, Message = "Token oluşturuldu" };
                    }
                    return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Token oluşturulamadı", ErrorCode = ErrorCodes.BadRequest };
                }

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Token oluşturulamadı", ErrorCode = ErrorCodes.BadRequest };
            }
			catch (Exception)
			{
				return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "bir hata olustu" ,ErrorCode = ErrorCodes.Exception };
			}
        }
    }
}
