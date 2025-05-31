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
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _userService.Register(registerDto);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin,employee")]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _userService.Login(loginDto);
            return CreateResponse(result);
        }

        [HttpPost("logout")]
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
        public async Task<IActionResult> CheckUser(string email)
        {
            var result = await _userService.CheckUser(email);
            return CreateResponse(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("check-with-password")]
        public async Task<IActionResult> CheckUserWithPassword([FromBody] LoginDto loginDto)
        {
            var result = await _userService.CheckUserWithPassword(loginDto);
            return CreateResponse(result);
        }
    }
}
