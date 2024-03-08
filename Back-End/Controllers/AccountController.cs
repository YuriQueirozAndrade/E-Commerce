using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
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
            var result = await _account.Login(model.Email, model.Password, model.RememberMe, false);
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

    [HttpGet]
    public IActionResult ReadUser()
    {
        return Ok(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
