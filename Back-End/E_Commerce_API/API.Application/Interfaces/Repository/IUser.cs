using E_Commerce_API.Application.Interfaces.DTOs;
namespace E_Commerce_API.Application.Interfaces.Repository
{
  public interface IUser<TEntity> : IRepository<TEntity> where TEntity : class
  {
      Task<IEnumerable<IDTO<TEntity>>> GetAllByUserID(string UserID);
  }
}
