using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models.DTOs;
using Back_End.Models;
using System.Security.Claims;
using Back_End.Services;
using Microsoft.AspNetCore.Authorization;
namespace Back_End.Controllers;

[Route("[controller]/[action]")]
[Authorize]
public class AddressController : UserRepositoryController<Address,AddressDTO>
{
    private readonly IUser<Address> _entity;
    public AddressController(IUser<Address> entity): base(entity:entity)
    {
        _entity = entity;
    }
}
