using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
namespace Back_End.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class ProductController: RepositoryController<Product>
{
    private readonly IRepository<Product> _product;

    public ProductController(IRepository<Product> product) : base (entity:product)
    {
        _product = product;
    }
}
