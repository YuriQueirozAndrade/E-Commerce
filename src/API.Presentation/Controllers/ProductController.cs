using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Application.DTOs;
using E_Commerce_API.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Presentation.Controllers;

[ApiController]
[Authorize(Policy = "RequireAdministratorRole")]
[Route("[controller]/[action]")]
public class ProductController: RepositoryController<Product,ProductDTO>
{
    private readonly IProduct<Product> _product;

    public ProductController(IRepository<Product> repository, IProduct<Product> product,IUnityOfWork unityOfWork) : base (entity:repository,unityOfWork:unityOfWork)
    {
        _product = product;
    }
    [HttpGet]
    public async Task<IEnumerable<IDTO<Product>>> ReadAllProducts()
    {
        return await _product.GetAllProducts();
    }
}
