using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
using Back_End.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
namespace Back_End.Controllers;

[ApiController]
[Authorize(Policy = "RequireAdministratorRole")]
[Route("[controller]/[action]")]
public class ProductController: RepositoryController<Product,ProductDTO>
{
    private readonly IProduct<Product> _product;

    public ProductController(IRepository<Product> repository, IProduct<Product> product) : base (entity:repository)
    {
        _product = product;
    }
    [HttpGet]
    public async Task<IEnumerable<IDTO<Product>>> ReadAllProducts()
    {
        return await _product.GetAllProducts();
    }
}
