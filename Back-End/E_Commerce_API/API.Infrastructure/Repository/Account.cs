using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.DTOs;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce_API.Infrastructure.Repository
{
    public class Account :IAccount<User> 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public Account(UserManager<User> userService, SignInManager<User> signInService)
        {
            _signInManager = signInService;
            _userManager = userService;
        }

        public async Task<IdentityResult> Register(RegisterDTO register)
        {
            User currentUser = register.ToEntity();
            var user = await _userManager.CreateAsync(currentUser,register.Password);
            await _userManager.AddToRoleAsync(currentUser,"USER");
            return user;
        }
        public async Task<SignInResult> Login(LoginDTO login)
        {
            return await _signInManager.PasswordSignInAsync(login.Email,login.Password,login.RememberMe,false);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}