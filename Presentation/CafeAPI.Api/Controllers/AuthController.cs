using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CafeAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/auth/generateToken")]
        public async Task<IActionResult> GenerateToken([FromBody] LoginDto dto)
        {
            var result = await _authService.GenerateToken(dto);
            return CreateResponse(result);
        }
    }
}
