using Back_End.Data;
using Back_End.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Back_End.Services
{
    public class UserRepository<TEntity> :Repository<TEntity>, IUser<TEntity> where TEntity : class
    {
        private readonly DataBaseContext _dbuser;
        public UserRepository (DataBaseContext dbuser) : base(dbContext:dbuser)
        {
            _dbuser = dbuser;
        }
        public async Task<IEnumerable<TEntity>> GetAllByUserID(string UserID)
        {
            return await _dbuser.Set<TEntity>().Where(e => e.GetType().GetProperty("UserId").GetValue(e) == UserID).ToListAsync();
        }
    }
}