using Back_End.IRepository;
using Microsoft.AspNetCore.Identity;
using Back_End.Models;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Back_End.Services
{
    public class Account :IAccount<User> 
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public Account(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IdentityResult> Register(User user,string passwd)
        {
           return await _userManager.CreateAsync(user,passwd);
        }
        public async Task<SignInResult> Login(string user,string passwd,bool persistent = false, bool lockOnFail = false)
        {
            return await _signInManager.PasswordSignInAsync(user,passwd,persistent,lockOnFail);
        }
        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}