namespace Back_End.Interfaces
{
  public interface IShippingService<TEntity> where TEntity : class
  {
      TEntity CreateShipping();
  }
}
