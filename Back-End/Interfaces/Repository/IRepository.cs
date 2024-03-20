using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Back_End.Interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
      Task<TEntity> Create(IDTO<TEntity> entity);
      Task<IDTO<TEntity>> GetByID(int ID);
      Task<EntityEntry> Update(int ID, IDTO<TEntity> entity);
      Task<TEntity> Delete(int ID);
  }
}
