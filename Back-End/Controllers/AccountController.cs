using Microsoft.AspNetCore.Mvc;
using Back_End.IRepository;
using Back_End.Models;
using Back_End.Services;
using Back_End.Models.InputModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authorization;
namespace Back_End.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AccountController: ControllerBase
{
    private readonly IAccount<User> _account;

    public AccountController(IAccount<User> account)
    {
        _account = account;
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(Models.InputModels.RegisterInputModel model)
    {
        var CurrentUser = new User
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            UserName = model.Email,
            Email = model.Email
        };
        var result = await _account.Register(CurrentUser, model.Password);
        if (result.Succeeded)
        {
            return Ok("Register Sucess");
        }
        else
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return BadRequest(result);
        }
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(Models.InputModels.LoginInputModel model)
    {
        var CurrentUser = new User
        {
            UserName = model.Email,
            Email = model.Email,
        };
            var result = await _account.Login(model.Email, model.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Login is Sucess");
            }
            else if (result.IsLockedOut)
            {
                return BadRequest(new { error = "Account locked out." });
            }
            else
            {
                return BadRequest(new { error = "Invalid username or password." });
            }
    }
    [HttpGet]
    public async Task<IActionResult> Logout()
    {
        await _account.Logout();
        return Ok();
    }

}
