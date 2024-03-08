using Microsoft.AspNetCore.Identity;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
namespace Back_End.Interfaces
{
  public interface IAccount<TUser> where TUser : class
  {
      Task<IdentityResult> Register(TUser user,string passwd);
      Task<SignInResult> Login(string user,string passwd,bool persistent, bool lockOnFail);
      Task Logout();
  }
}