namespace Back_End.Interfaces
{
  public interface IOrderItemService<TEntity,TDto>
  where TEntity : class
  where TDto : class
  {
      List<TEntity> CreateOrderItem(List<TDto> dto);
  }
}