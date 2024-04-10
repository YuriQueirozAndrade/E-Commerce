using E_Commerce_API.Application.Interfaces;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_API.Presentation.Controllers;

[Route("[controller]/[action]")]
public class RepositoryController<TEntity,TDTO> : ControllerBase
where TEntity : class
where TDTO : IDTO<TEntity>
{
    private readonly IRepository<TEntity> _entity;
    private readonly IUnityOfWork _unityOfWork;

    public RepositoryController(IRepository<TEntity> entity,IUnityOfWork unityOfWork)
    {
        _entity = entity;
        _unityOfWork = unityOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TDTO entity)
    {
        await _entity.Create(entity);
        await _unityOfWork.Commit();
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
        await _unityOfWork.Commit();
        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _entity.Delete(id);
        await _unityOfWork.Commit();
        return NoContent();
    }
}
