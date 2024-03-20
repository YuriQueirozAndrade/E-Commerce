using Back_End.Data;
using Back_End.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace Back_End.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        private readonly DataBaseContext _dbContext;
        private readonly IResponseDTO<TEntity> _dto;
        public Repository (DataBaseContext dbContext,IResponseDTO<TEntity> dto)
        {
            _dto = dto;
            _dbContext = dbContext;
        }

        public async Task<TEntity> Create(IDTO<TEntity> entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity.ToEntity());
            await _dbContext.SaveChangesAsync();
            return entity.ToEntity();
        }
        public async Task<IDTO<TEntity>> GetByID(int Id)
        {
            return _dto.ToDto(await _dbContext.Set<TEntity>().FindAsync(Id));
        }
        public virtual async Task<EntityEntry> Update(int ID, IDTO<TEntity> entity)
        {
            var up = await _dbContext.Set<TEntity>().FindAsync(ID);
            entity.UpdateEntity(up);
            var res = _dbContext.Update<TEntity>(up);
            await _dbContext.SaveChangesAsync();
            return res;
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