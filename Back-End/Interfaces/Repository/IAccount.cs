using Back_End.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
namespace Back_End.Interfaces
{
  public interface IAccount<TUser> where TUser : class
  {
      Task<IdentityResult> Register(RegisterDTO register);
      Task<SignInResult> Login(LoginDTO login);
      Task Logout();
  }
}