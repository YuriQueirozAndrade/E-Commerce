using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Back_End.Interfaces
{
  public interface IRepository<TEntity> where TEntity : class
  {
      Task<TEntity> Create(TEntity entity);
      ValueTask<TEntity> GetByID(int ID);
      Task<EntityEntry> Update(int ID, TEntity entity);
      Task<TEntity> Delete(int ID);
  }
}
