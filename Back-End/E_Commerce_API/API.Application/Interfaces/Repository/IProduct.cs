using E_Commerce_API.Application.Interfaces.DTOs;

namespace E_Commerce_API.Application.Interfaces.Repository
{
  public interface IProduct<TProduct>
  where TProduct : class
  {
      Task<List<decimal>> GetByPriceListID(List<int> listID);
      Task<IEnumerable<IDTO<TProduct>>> GetAllProducts();
  }
}