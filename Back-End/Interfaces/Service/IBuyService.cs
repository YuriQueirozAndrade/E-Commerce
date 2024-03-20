using Back_End.Models.DTOs;

namespace Back_End.Interfaces
{
  public interface IBuyService<TOrder>
  where TOrder : class
  {
      Task<IDTO<TOrder>> CreateOrder(Cart cart);
  }
}
