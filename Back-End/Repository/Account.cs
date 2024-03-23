using Back_End.Interfaces;
using Microsoft.AspNetCore.Identity;
using Back_End.Models;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Back_End.Models.DTOs;
using Microsoft.VisualBasic;

namespace Back_End.Services
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