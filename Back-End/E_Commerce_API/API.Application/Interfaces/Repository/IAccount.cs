using E_Commerce_API.Application.DTOs;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace E_Commerce_API.Application.Interfaces.Repository
{
  public interface IAccount<TUser> where TUser : class
  {
      Task<IdentityResult> Register(RegisterDTO register);
      Task<SignInResult> Login(LoginDTO login);
      Task Logout();
  }
}