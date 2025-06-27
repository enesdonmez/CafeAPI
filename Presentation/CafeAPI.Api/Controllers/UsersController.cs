using CafeAPI.Application.Dtos.ResponseDtos;
using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [EndpointDescription("Yeni bir kullanıcı kaydı oluşturur.")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _userService.Register(registerDto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPost("login")]
        [EndpointDescription("Kullanıcı girişi yapar.")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _userService.Login(loginDto);
            return CreateResponse(result);
        }

        [HttpPost("logout")]
        [EndpointDescription("Kullanıcı çıkışı yapar.")]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            return CreateResponse<object>(new ResponseDto<object>
            {
                IsSuccess = true,
                Message = "Çıkış başarılı."
            });
        }

        [Authorize(Roles = "admin")]
        [HttpGet("check/{email}")]
        [EndpointDescription("Belirtilen e-posta adresine sahip kullanıcıyı kontrol eder.")]
        public async Task<IActionResult> CheckUser(string email)
        {
            var result = await _userService.CheckUser(email);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("check-with-password")]
        [EndpointDescription("E-posta ve şifre ile kullanıcı doğrulaması yapar.")]
        public async Task<IActionResult> CheckUserWithPassword([FromBody] LoginDto loginDto)
        {
            var result = await _userService.CheckUserWithPassword(loginDto);
            return CreateResponse(result);
        }

        [HttpPost("default-register")]
        [EndpointDescription("Varsayılan rollerle yeni kullanıcı kaydı oluşturur.")]
        public async Task<IActionResult> RegisterDefault(RegisterDto registerDto)
        {
            var result = await _userService.DefaultRegister(registerDto);
            return CreateResponse(result);
        }
    }
}
