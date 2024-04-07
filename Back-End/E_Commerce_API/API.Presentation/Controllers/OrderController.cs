using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.DTOs;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Application.Interfaces.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace E_Commerce_API.Presentation.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class UserOrderController: ControllerBase
{
    private readonly IBuyService<Order> _order;
    private readonly IUser<Order> _user;

    public UserOrderController(IBuyService<Order> order, IUser<Order> user)
    {
      _order = order;
      _user = user;
    }

    [HttpPost]
    public async Task<IActionResult> Buy(Cart orderItem)
    {
      orderItem.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
      return Created("prod created", await _order.CreateOrder(orderItem));
    }
    [HttpGet]
    public async Task<IActionResult> ReadByID(int ID)
    {
      return Created("prod created", await _user.GetByID(ID));
    }
    [HttpGet]
    public async Task<IEnumerable<IDTO<Order>>> ReadAll()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        IEnumerable<IDTO<Order>> entities = await _user.GetAllByUserID(userId);
        return entities;
    }
}
