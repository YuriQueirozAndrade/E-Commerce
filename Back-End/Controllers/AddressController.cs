using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Back_End.Models;
using Microsoft.AspNetCore.Authorization;
using Back_End.Services;
namespace Back_End.Controllers;

[ApiController]
[Authorize]
[Route("[controller]/[action]")]
public class AddressController: UserRepositoryController<Address>
{
    private readonly IUser<Address> _address;

    public AddressController(IUser<Address> address) : base (entity:address)
    {
        _address = address;
    }
}
