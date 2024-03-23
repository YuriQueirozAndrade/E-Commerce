using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Back_End.Models.DTOs;
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
    public async Task<IActionResult> Register(RegisterDTO register)
    {
        var result = await _account.Register(register);
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
    public async Task<IActionResult> Login(LoginDTO login)
    {
            var result = await _account.Login(login);
            if (result.Succeeded)
            {
                return Ok("Login is Sucess");
            }
            else
            {
                return BadRequest(new { error = "Invalid username or password." });
            }
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _account.Logout();
        return Ok();
    }
}
