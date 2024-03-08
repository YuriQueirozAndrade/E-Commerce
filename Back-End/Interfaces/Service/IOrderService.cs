namespace Back_End.Interfaces
{
  public interface IOrderService<TEntity> where TEntity : class
  {
      TEntity CreateOrder(decimal TotalAmount, string UserID);
  }
}