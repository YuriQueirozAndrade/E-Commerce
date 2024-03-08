
using Microsoft.AspNetCore.Mvc;
using Back_End.Interfaces;
namespace Back_End.Controllers;

[Route("[controller]/[action]")]
public class RepositoryController<TEntity> : ControllerBase where TEntity : class
{
    private readonly IRepository<TEntity> _entity;

    public RepositoryController(IRepository<TEntity> entity)
    {
        _entity = entity;
    }

    [HttpPost]
    public  async Task<IActionResult> Create(TEntity entity)
    {
        await _entity.Create(entity);
        return Created("{0} is Created", entity);
    }
    [HttpGet]
    public  async Task<IActionResult> Read(int Id)
    {
        return Ok(await _entity.GetByID(Id));
    }
    [HttpPut]
    public  async Task<IActionResult> Update(int ID, TEntity entity)
    {
        await _entity.Update(ID, entity);
        return Created("{0} is Updated", entity);
    }
    [HttpDelete]
    public  async Task<IActionResult> Delete(int ID, TEntity entity)
    {
        await _entity.Delete(ID);
        return Ok($"{entity} Deleted");
    }
}
