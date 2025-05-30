﻿using CafeAPI.Application.Dtos.UserDtos;
using CafeAPI.Application.Interfaces;
using CafeAPI.Persistence.Identity;
using Microsoft.AspNetCore.Identity;

namespace CafeAPI.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;

        public UserRepository(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDto> CheckUserAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var role = await _userManager.GetRolesAsync(user);
                return new UserDto { Email = user.Email, Id = user.Id , RoleName = role.FirstOrDefault() };
            }
            return new UserDto();
        }

        public async Task<SignInResult> CheckUserWithPasswordAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            var  result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            return result;
        }

        public async Task<SignInResult> LoginAsync(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> RegisterAsync(RegisterDto dto)
        {
            var user = new AppIdentityUser
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Email,
                UserName = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            IdentityResult result = await _userManager.CreateAsync(user, dto.Password);
            return result;
        }
    }
}
