using Microsoft.AspNetCore.Mvc;
using E_Commerce_API.Core.Entities;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Application.DTOs;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
namespace E_Commerce_API.Presentation.Controllers;

[Route("[controller]/[action]")]
[Authorize]
public class AddressController : UserRepositoryController<Address,AddressDTO>
{
    public AddressController(IUser<Address> entity): base(entity:entity)
    {
    }
}
