using CafeAPI.Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace CafeAPI.Application.Services.Abstract
{
    public interface IUserRepository
    {
        Task<SignInResult> LoginAsync(LoginDto dto);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
    }
}
