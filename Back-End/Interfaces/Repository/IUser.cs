namespace Back_End.Interfaces
{
  public interface IUser<TEntity> : IRepository<TEntity> where TEntity : class
  {
      Task<IEnumerable<IDTO<TEntity>>> GetAllByUserID(string UserID);
  }
}
