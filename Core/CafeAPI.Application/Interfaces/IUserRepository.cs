﻿using CafeAPI.Application.Dtos.UserDtos;
using Microsoft.AspNetCore.Identity;

namespace CafeAPI.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<SignInResult> LoginAsync(LoginDto dto);
        Task LogoutAsync();
        Task<IdentityResult> RegisterAsync(RegisterDto dto);
        Task<UserDto> CheckUserAsync(string email);
        Task<SignInResult> CheckUserWithPasswordAsync(LoginDto dto);
    }
}
