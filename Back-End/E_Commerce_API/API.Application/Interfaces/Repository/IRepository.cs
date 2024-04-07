using E_Commerce_API.Application.Interfaces.DTOs;
namespace E_Commerce_API.Application.Interfaces.Repository
{
  public interface IRepository<TEntity> where TEntity : class
  {
      Task<TEntity> Create(IDTO<TEntity> entity);
      Task<TEntity> Create(TEntity entity);
      Task<IDTO<TEntity>> GetByID(int ID);
      Task<TEntity> Update(int ID, IDTO<TEntity> entity);
      Task<TEntity> Delete(int ID);
  }
}
