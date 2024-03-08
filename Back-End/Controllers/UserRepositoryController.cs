using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Back_End.Services;
using Back_End.Interfaces;
namespace Back_End.Controllers;

[Route("[controller]/[action]")]
public class UserRepositoryController<TEntity> : ControllerBase where TEntity : class
{
    private readonly IUser<TEntity> _entity;

    public UserRepositoryController(IUser<TEntity> entity)
    {
        _entity = entity;
    }

    [HttpPost]
    public  async Task<IActionResult> Create(TEntity entity)
    {
        entity.GetType().GetProperty("UserId").SetValue(entity,User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _entity.Create(entity);
        return Created("{0} is Created", entity);
    }
    [HttpGet]
    public  async Task<IActionResult> Read(int Id)
    {
        return Ok(await _entity.GetByID(Id));
    }
    [HttpGet]
    public async Task<IActionResult> ReadAll()
    {
        return Ok(await _entity.GetAllByUserID(User.FindFirstValue(ClaimTypes.NameIdentifier)));
    }
    [HttpPut]
    public  async Task<IActionResult> Update(int ID, TEntity entity)
    {
        entity.GetType().GetProperty("UserId").SetValue(entity,User.FindFirstValue(ClaimTypes.NameIdentifier));
        await _entity.Update(ID, entity);
        return Created("{0} is Created", entity);
    }
    [HttpDelete]
    public  async Task<IActionResult> Delete(int ID, TEntity entity)
    {
        await _entity.Delete(ID);
        return Ok($"{entity} Deleted");
    }
}
