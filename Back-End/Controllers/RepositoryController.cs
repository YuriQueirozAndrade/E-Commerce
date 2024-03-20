using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Back_End.Interfaces;
namespace Back_End.Controllers;

[Route("[controller]/[action]")]
public class RepositoryController<TEntity,TDTO> : ControllerBase
where TEntity : class
where TDTO : IDTO<TEntity>
{
    private readonly IRepository<TEntity> _entity;

    public RepositoryController(IRepository<TEntity> entity)
    {
        _entity = entity;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TDTO entity)
    {
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


    [HttpPut]
    public async Task<IActionResult> Update(int id, TDTO entity)
    {
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
