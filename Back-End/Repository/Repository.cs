using Back_End.Data;
using Back_End.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Back_End.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private readonly DataBaseContext _dbContext;
        public Repository (DataBaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async ValueTask<TEntity> GetByID(int Id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(Id);
        }
        public virtual async Task<EntityEntry> Update(int ID, TEntity entity)
        {
            await _dbContext.Set<TEntity>().FindAsync(ID);
            var up = _dbContext.Update<TEntity>(entity);
            await _dbContext.SaveChangesAsync();
            return up;
        }
        public async Task<TEntity> Delete(int ID)
        {
           var ent = await _dbContext.Set<TEntity>().FindAsync(ID);
           _dbContext.Remove<TEntity>(ent);
           await _dbContext.SaveChangesAsync();
           return ent;
        }
    }
}