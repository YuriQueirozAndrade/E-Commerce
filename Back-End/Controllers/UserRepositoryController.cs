using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
using Microsoft.AspNetCore.Authorization;
namespace Back_End.Controllers;

[Route("[controller]/[action]")]
public class UserRepositoryController<TEntity,TDTO> : ControllerBase
where TEntity : class
where TDTO : IDTO<TEntity>,IUserProperties
{
    private readonly IUser<TEntity> _entity;
    public UserRepositoryController(IUser<TEntity> entity)
    {
        _entity = entity;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TDTO entity)
    {
        entity.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _entity.Create(entity);
        return Created("{0}",entity);
    }

    [HttpGet]
    public async Task<IActionResult> Read(int id)
    {
        var entity = await _entity.GetByID(id);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpGet]
    public async Task<IEnumerable<IDTO<TEntity>>> ReadAll()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        IEnumerable<IDTO<TEntity>> entities = await _entity.GetAllByUserID(userId);
        return entities;
    }
    
    [HttpPut]
    public async Task<IActionResult> Update(int id, TDTO entity)
    {
        entity.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        await _entity.Update(id, entity);
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _entity.Delete(id);
        return NoContent();
    }
}
