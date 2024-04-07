using E_Commerce_API.Infrastructure.Data;
using E_Commerce_API.Application.Interfaces.Repository;
using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace E_Commerce_API.Infrastructure.Repository
{
    public class UserRepository<TEntity> :Repository<TEntity>, IUser<TEntity> where TEntity : class, IUserProperties
    {
        private readonly DataBaseContext _dbuser;
        private readonly IResponseDTO<TEntity> _dtouser;
        public UserRepository (DataBaseContext dbuser, IResponseDTO<TEntity> dtouser) : base(dbContext:dbuser,dto:dtouser)
        {
            _dtouser = dtouser;
            _dbuser = dbuser;
        }
        public async Task<IEnumerable<IDTO<TEntity>>> GetAllByUserID(string UserID)
        {
            var ListEntity = await _dbuser.Set<TEntity>().Where(e => e.UserId == UserID).ToListAsync();
            return _dtouser.ToDtoList(ListEntity);
        }
    }
}