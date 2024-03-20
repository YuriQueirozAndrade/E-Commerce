using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace Back_End.Controllers;

[ApiController]
[Authorize(Roles = "Admin")]
[Route("[controller]/[action]")]
public class ProductController: RepositoryController<Product,ProductDTO>
{
    private readonly IRepository<Product> _product;

    public ProductController(IRepository<Product> product) : base (entity:product)
    {
        _product = product;
    }
}
