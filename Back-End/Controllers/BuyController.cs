using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
using System.Security.Claims;
using Back_End.Models.InputModels;
namespace Back_End.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class OrderController: ControllerBase
{
    private readonly IBuyService<Order,BuyInputModel> _order;

    public OrderController(IBuyService<Order,BuyInputModel> order)
    {
        _order = order;
    }

[HttpPost]
public async Task<IActionResult> Buy(List<BuyInputModel> model)
{
  return Created("prod created", await _order.CreateOrder(model, User.FindFirstValue(ClaimTypes.NameIdentifier)));
}
}
