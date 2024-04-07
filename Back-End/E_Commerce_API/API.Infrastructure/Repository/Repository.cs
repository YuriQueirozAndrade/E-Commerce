using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Application.Interfaces.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace E_Commerce_API.Infrastructure.Repository
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
            return entity.ToEntity();
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public async Task<IDTO<TEntity>> GetByID(int ID)
        {
            return _dto.ToDto(await _dbContext.Set<TEntity>().FindAsync(ID));
        }
        public virtual async Task<TEntity> Update(int ID, IDTO<TEntity> entity)
        {
            var up = await _dbContext.Set<TEntity>().FindAsync(ID);
            entity.UpdateEntity(up);
            var res = _dbContext.Update<TEntity>(up);
            return entity.ToEntity();
        }
        public async Task<TEntity> Delete(int ID)
        {
           var ent = await _dbContext.Set<TEntity>().FindAsync(ID);
           _dbContext.Remove<TEntity>(ent);
           return ent;
        }
    }
}