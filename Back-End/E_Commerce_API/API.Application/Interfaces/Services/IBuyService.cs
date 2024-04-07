using E_Commerce_API.Application.Interfaces.DTOs;
using E_Commerce_API.Application.DTOs;

namespace E_Commerce_API.Application.Interfaces.Services
{
  public interface IBuyService<TOrder>
  where TOrder : class
  {
      Task<IDTO<TOrder>> CreateOrder(Cart cart);
  }
}
