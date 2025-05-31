using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Application.Services.Abstract;
using FluentValidation;

namespace CafeAPI.Application.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<RegisterDto> _registerValidator;

        public UserService(IUserRepository userRepository, IValidator<RegisterDto> registerValidator)
        {
            _userRepository = userRepository;
            _registerValidator = registerValidator;
        }

        public async Task<ResponseDto<UserDto>> CheckUser(string email)
        {
            try
            {
                var result = await _userRepository.CheckUserAsync(email);
                if (result.Email is not null)
                    return new ResponseDto<UserDto>
                    {
                        IsSuccess = true,
                        Data = result,
                        Message = "Kullanıcı bulundu.",
                    };

                return new ResponseDto<UserDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Kullanıcı bulunamadı.",
                    ErrorCode = ErrorCodes.NotFound
                };
            }
            catch (Exception)
            {
                return new ResponseDto<UserDto> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> CheckUserWithPassword(LoginDto dto)
        {
            try
            {
                var result = await _userRepository.CheckUserWithPasswordAsync(dto);
                if (result.Succeeded)
                    return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Kullanıcı doğrulandı." };

                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Kullanıcı doğrulanamadı.", ErrorCode = ErrorCodes.BadRequest };
            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task<ResponseDto<object>> Login(LoginDto dto)
        {
            try
            {
                var result = await _userRepository.LoginAsync(dto);
                if (result.Succeeded)
                    return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Giriş başarılı." };

                return new ResponseDto<object>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Giriş başarısız.",
                    ErrorCode = ErrorCodes.BadRequest
                };
            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }

        public async Task Logout()
        {
            await _userRepository.LogoutAsync();
        }

        public async Task<ResponseDto<object>> Register(RegisterDto dto)
        {
            try
            {
                var validationResult = await _registerValidator.ValidateAsync(dto);
                if (!validationResult.IsValid)
                {
                    return new ResponseDto<object>
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = string.Join(",", validationResult.Errors.Select(x => x.ErrorMessage)),
                        ErrorCode = ErrorCodes.ValidationError,
                    };
                }

                var result = await _userRepository.RegisterAsync(dto);
                if (result.Succeeded)
                    return new ResponseDto<object> { IsSuccess = true, Data = null, Message = "Kayıt olma başarılı" };
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = string.Join(",", result.Errors.Select(x => x.Description)), ErrorCode = ErrorCodes.BadRequest };

            }
            catch (Exception)
            {
                return new ResponseDto<object> { IsSuccess = false, Data = null, Message = "Bir Hata oluştu.", ErrorCode = ErrorCodes.Exception };
            }
        }
    }
}
