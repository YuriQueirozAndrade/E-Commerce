namespace Back_End.Interfaces
{
  public interface IBuyService<TOrder,TOrderItem>
  where TOrder : class
  where TOrderItem : class
  {
      Task<TOrder> CreateOrder(List<TOrderItem> entity, string UserID);
  }
}
