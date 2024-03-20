using System.Reflection;
using Back_End.Data;
using Back_End.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
namespace Back_End.Services
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